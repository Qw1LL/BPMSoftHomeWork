namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Web.Common;

	#region Class: ProcessEngineService

	/// <summary>
	/// The web service that provides access to the <see cref="ProcessEngine" /> methods.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ProcessEngineService : BaseService
	{

		#region Methods: Private

		private static readonly ILog _log = LogManager.GetLogger("Process");

		private static Dictionary<string, object> GetSchemaParameterValues(UserConnection userConnection,
				BaseProcessSchemaElement baseSchemaElement, IEnumerable<CompleteParameter> completeParameters) {
			var schemaParameterValues = new Dictionary<string, object>();
			var schemaElement = (IProcessParametersMetaInfo)baseSchemaElement;
			ProcessSchemaParameterCollection schemaElementParameters = schemaElement.ForceGetParameters();
			foreach (CompleteParameter parameter in completeParameters) {
				ProcessSchemaParameter userTaskParameter = schemaElementParameters.FindByName(parameter.key);
				if (userTaskParameter == null) {
					continue;
				}
				var dataParameter = new Parameter {
					Value = parameter.value
				};
				BPMSoft.Core.DataValueType dataValueType = userTaskParameter.DataValueType;
				if (dataValueType is DateTimeDataValueType && dataParameter.Value == null) {
					dataParameter.Value = "null";
				}
				object parameterValue = dataParameter.GetValue(userConnection, userTaskParameter.DataValueType);
				schemaParameterValues[userTaskParameter.Name] = parameterValue;
			}
			return schemaParameterValues;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns information that represents a set of the process entry points.
		/// </summary>
		/// <param name="entitySchemaUId">Unique identifier of the entity schema.</param>
		/// <param name="entityId">Identifier of the entity.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public List<ResponceEntryPoints> GetProcessEntryPointsData(string entitySchemaUId, string entityId) {
			entitySchemaUId.CheckArgumentNullOrEmpty("entitySchemaUId");
			entityId.CheckArgumentNullOrEmpty("entityId");
			UserConnection userConnection = UserConnection;
			var response = new List<ResponceEntryPoints>();
			var entryPointSelect =
				(Select)new Select(userConnection)
					.Column("SysProcessElementDataId")
				.From("EntryPoint")
				.Where("EntitySchemaUId").IsEqual(Column.Parameter(new Guid(entitySchemaUId)))
				.And("EntityId").IsEqual(Column.Parameter(new Guid(entityId)))
				.And("IsActive").IsEqual(Column.Parameter(true));
			IProcessEngine processEngine = userConnection.IProcessEngine;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = entryPointSelect.ExecuteReader(dbExecutor)) {
					DBTypeConverter dbTypeConverter = userConnection.DBTypeConverter;
					while (reader.Read()) {
						Guid elementId = dbTypeConverter.DBValueToGuid(reader[0]);
						var sysProcessElementData = new SysProcessElementData(userConnection);
						if (!sysProcessElementData.FetchFromDB(elementId)) {
							continue;
						}
						Guid sysProcessId = sysProcessElementData.SysProcessId;
						Process process = processEngine.FindProcessByUId(sysProcessId.ToString(), true);
						if (process == null) {
							continue;
						}
						var processActivity = (ProcessActivity)process.FindFlowElementByUId(elementId);
						BaseProcessSchemaElement schemaElement = processActivity.GetSchemaElement();
						response.Add(new ResponceEntryPoints{
							id = elementId.ToString(),
							caption = schemaElement.Caption
						});
					}
				}
			}
			return response;
		}

		/// <summary>
		/// Completes execution of the process element.
		/// </summary>
		/// <param name="procElUId">Unique identifier of the process element.</param>
		/// <param name="parameters">Parameters.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public int CompleteExecution(Guid procElUId, List<CompleteParameter> parameters) {
			UserConnection userConnection = UserConnection;
			IProcessEngine processEngine = userConnection.ProcessEngine;
			try {
				BaseProcessSchemaElement schemaElement = processEngine.GetSchemaElement(procElUId);
				Dictionary<string, object> nameValues = GetSchemaParameterValues(userConnection, schemaElement, parameters);
				ProcessDescriptor descriptor = processEngine.CompleteExecuting(procElUId, nameValues);
				return descriptor.WaitingUserTasksCount;
			} catch(BPMSoft.Common.ItemNotFoundException) {
				_log.Warn($"Attempt to complete the process element with Id '{procElUId}', but that element was not found.");
				return -1;
			}
		}

		/// <summary>
		/// Executes the process element.
		/// </summary>
		/// <param name="procElUId">Unique identifier of the process element.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public void ExecuteProcessElement(Guid procElUId) {
			UserConnection userConnection = UserConnection;
			IProcessEngine processEngine = userConnection.ProcessEngine;
			processEngine.ExecuteProcessElementByUId(procElUId);
		}

		#endregion

		#region DataContract

		#region Class: ResponceEntryPoints

		[DataContract]
		public class ResponceEntryPoints {

			#region Properties: Public

			[DataMember]
			public string id { get; set; }

			[DataMember]
			public string caption { get; set; }

			#endregion

		}

		#endregion

		#region Class: CompleteParameter

		[DataContract]
		public class CompleteParameter {

			#region Properties: Public

			[DataMember]
			public string key { get; set; }

			[DataMember]
			public object value { get; set; }

			#endregion

		}

		#endregion

		#endregion

	}

	#endregion

}

