namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: FillProcessElementNotifications

	/// <summary>
	/// Provides method to register notification event of the process elements which are needed with user interaction.
	/// </summary>
	public class FillProcessElementNotifications
	{

		#region Constants: Private

		private const string PublishNotificationMethodName = "PublishNotification";
		private const string InitializeFlowElementPropertiesMethodName = "InitializeFlowElementProperties";
		
		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly LinkedList<string> _messages = new LinkedList<string>();
		private readonly Action<string, MessageType> _writeLog = (message, messageType) => { };
		private readonly BindingFlags _binding = BindingFlags.Instance | BindingFlags.NonPublic;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance with specified user connection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="writeLog">Delegate to write log information.</param>
		public FillProcessElementNotifications(UserConnection userConnection, Action<string, MessageType> writeLog) {
			userConnection.CheckArgumentNull("userConnection");
			_userConnection = userConnection;
			if (writeLog != null) {
				_writeLog = writeLog;
			}
		}

		#endregion

		#region Properties: Private

		private MethodInfo _publishNotificationMethod;
		private MethodInfo PublishNotificationMethod {
			get {
				if (_publishNotificationMethod == null) {
					_publishNotificationMethod = GetPublishNotificationMethod();
				}
				return _publishNotificationMethod;
			}
		}

		private MethodInfo _initializeFlowElementProperties;
		private MethodInfo InitializeFlowElementProperties {
			get {
				if (_initializeFlowElementProperties == null) {
					_initializeFlowElementProperties = GetInitializeFlowElementPropertiesMethod();
				}
				return _initializeFlowElementProperties;
			}
		}

		#endregion

		#region Methods: Private

		private MethodInfo GetPublishNotificationMethod() {
			Type type = typeof(ProcessActivity);
			return type.GetMethods(_binding)
				.Where(method => {
					return method.Name == PublishNotificationMethodName;
				}).First();
		}

		private MethodInfo GetInitializeFlowElementPropertiesMethod() {
			Type type = typeof(ProcessComponentSet);
			var argumentTypes = new [] {
				typeof(ProcessFlowElement),
				typeof(bool)
			};
			MethodInfo method =
				type.GetMethod(InitializeFlowElementPropertiesMethodName, _binding, null, argumentTypes, null);
			return method;
		}

		private void UpdateProcessElementData(ProcessFlowElement processFlowElement){
			var processElement = (ProcessActivity)processFlowElement;
			processElement.WritePropertiesDataToDB(_userConnection);
		}

		private void InitializeProcessElement(ProcessFlowElement processElement) {
			var arguments = new object[] {
				processElement, true
			};
			InitializeFlowElementProperties.Invoke(processElement.Owner, arguments);
		}

		private string GetExceptionMessage(Exception e) {
			return e.InnerException == null ? e.Message : e.InnerException.Message;
		}

		private void AddErrorInfo(Process process, ProcessFlowElement processElement, Exception e) {
			string message = string.Format(
				"	process id: {0}, process name: {1}, process element id {2}, process element name {3}",
				process.UId,
				process.Name,
				processElement.UId,
				processElement.Name);
			string exceptionMessage = GetExceptionMessage(e);
			message += " Throws exception: " + exceptionMessage;
			_messages.AddLast(message);
		}

		private void PublishNotification(string processUId) {
			IProcessEngine processEngine = _userConnection.IProcessEngine;
			Process process = processEngine.FindProcessByUId(processUId, true);
			if (process == null || process.Status != ProcessStatus.Running) {
				return;
			}
			var schema = (BaseProcessSchema)process.Schema;
			bool canUseFlowEngine = ProcessSchemaManager.GetCanUseFlowEngine(_userConnection, schema);
			foreach (Collection<ProcessFlowElement> processElements in process.FlowElements.Values) {
				foreach (ProcessFlowElement processElement in processElements) {
					if (processElement.Status != ProcessStatus.Running) {
						continue;
					}
					if (processElement.IsProcess) {
						PublishNotification(processElement.UId.ToString());
						continue;
					}
					object showExecutionPage;
					if (!processElement.TryGetPropertyValue("ShowExecutionPage", out showExecutionPage)) {
						continue;
					}
					if (canUseFlowEngine) {
						try {
							InitializeProcessElement(processElement);
						}
						catch (Exception e) {
							AddErrorInfo(process, processElement, e);
							continue;
						}
					}
					try {
						PublishNotificationMethod.Invoke(processElement, null);
						UpdateProcessElementData(processElement);
					}
					catch (Exception e) {
						AddErrorInfo(process, processElement, e);
					}
				}
			}
		}

		private IEnumerable<Guid> GetProcessIds() {
			var runningStatusId = _userConnection.ProcessEngine.ProcessActivityStatus[ProcessStatus.Running];
			var activeprocesses = new Select(_userConnection)
				.Column("SPL", "Id")
				.From("SysProcessLog").As("SPL").WithHints(Hints.NoLock)
				.Where("SPL", "Id").IsEqual("SPD", "Id")
				.And("SPL", "StatusId").IsEqual(Column.Parameter(runningStatusId));
			var sysProcessDataSelect =
				(Select)new Select(_userConnection)
					.Column("SPD", "Id")
					.From("SysProcessData").As("SPD").WithHints(Hints.NoLock)
					.Where("SPD", "ParentId").IsNull()
					.And().Exists(activeprocesses);
			var processIds = new LinkedList<Guid>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = sysProcessDataSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid processId = reader.GetColumnValue<Guid>("Id");
						processIds.AddLast(processId);
					}
				}
			}
			return processIds;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers notification event of the process elements which are needed with user interaction.
		/// </summary>
		public void Run() {
			IEnumerable<Guid> processIds = new LinkedList<Guid>();
			try {
				processIds = GetProcessIds();
			}
			catch (Exception e) {
				string message = GetExceptionMessage(e);
				_writeLog(message, MessageType.Warning);
			}
			foreach (Guid processId in processIds) {
				string id = processId.ToString();
				try {
					_writeLog(string.Format("Process \"{0}\"", id), MessageType.Information);
					PublishNotification(id);
				}
				catch (Exception e) {
					string message = GetExceptionMessage(e);
					_writeLog(message, MessageType.Warning);
				}
				finally {
					if (_messages.Count != 0) {
						var sb = new StringBuilder();
						foreach (string currentMessage in _messages) {
							sb.Append(currentMessage);
							sb.AppendLine();
						}
						_messages.Clear();
						_writeLog(sb.ToString(), MessageType.Warning);
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

