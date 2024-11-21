namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core.Entities;

	#region Class: ProcessEmailUserTaskMacrosHelper

	public class EmailTemplateUserTaskMacrosHelper : BaseEmailUserTaskMacrosHelper
	{

		#region Constructors: Public

		public EmailTemplateUserTaskMacrosHelper(EmailTemplateUserTask userTask)
			: base(userTask) {
		}

		#endregion

		#region Methods: Private

		private bool IsProcessEmailUserTaskMacrosExists(List<MacrosInfo> macrosInfos) {

			return macrosInfos.Any(macrosInfo => macrosInfo.Id != Guid.Empty
				&& macrosInfo.ParentId == GetMacrosWorkerId());
		}

		#endregion

		#region Methods: Protected

		protected override Guid GetMacrosWorkerId() {
			return new Guid("E6281614-F65B-448C-BAB0-5B1C88D3A380");
		}

		protected override string GetMacrosValue(KeyValuePair<string, string> macros) {
			if (UserTask.SendEmailType == (int)BPMSoft.Configuration.ProcessDesigner.SendEmailType.Auto) {
				return macros.Value;
			} else {
				return base.GetMacrosValue(macros);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns arguments for macros values
		/// </summary>
		/// <param name="entityName">Entity name which used to get arguments.</param>
		/// <param name="recordId">Record which used to get arguments.</param>
		/// <param name="macrosInfos">Macros storage.</param>
		/// <returns>Arguments.</returns>
		public override Dictionary<Guid, Object> GetMacrosArguments(string entityName, Guid recordId,
				List<MacrosInfo> macrosInfos) {

			Dictionary<Guid, Object> arguments = base.GetMacrosArguments(entityName, recordId, macrosInfos);
			if (IsProcessEmailUserTaskMacrosExists(macrosInfos)) {
				arguments.Add(GetMacrosWorkerId(), UserTask);
			}
			return arguments;
		}

		#endregion

	}

	#endregion

	#region Class: RecipientEntityMacrosWorker

	[MacrosWorker("{E6281614-F65B-448C-BAB0-5B1C88D3A380}")]
	public class RecipientEntityMacrosWorker : IMacrosWorker
	{

		#region Fields: Private

		private readonly MacrosLoggerHelper _logger = new MacrosLoggerHelper("MacrosHelperV2");

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected virtual ProcessSchemaUserTask GetProcessSchemaUserTask(ProcessFlowElement userTask) {
			ProcessSchema processSchema = userTask.Owner.ProcessSchema;
			return (ProcessSchemaUserTask)processSchema.GetBaseElementByUId(userTask.SchemaElementUId);
		}

		protected virtual ProcessSchemaParameter GetParameterByName(ProcessSchemaUserTask userTaskSchema,
				string parameterName) {
			return userTaskSchema.Parameters.FindByName(parameterName);
		}

		protected virtual bool GetIsUseFlowEngine(EmailTemplateUserTask userTask) {
			return !userTask.Owner.IsEmbedded &&
				 ProcessSchemaManager.GetCanUseFlowEngine(userTask.UserConnection, userTask.Owner.ProcessSchema);
		}

		[Obsolete("7.12.4 | Method is not in use and will be removed in upcoming builds")]
		protected virtual object GetParameterValue(EmailTemplateUserTask userTask, Guid parameterUId) {
			var schemaElement = (IParametrizedProcessSchemaElement)userTask.GetSchemaElement();
			var parameters = schemaElement.ForceGetParameters();
			var parameter = parameters.GetByUId(parameterUId);
			return userTask.GetParameterValue(parameter);
		}

		protected object GetParameterValue(EmailTemplateUserTask userTask, ProcessSchemaParameter parameter) {
			return userTask.GetParameterValue(parameter);
		}

		protected virtual string GetEntityPrimaryColumnDisplayName(EmailTemplateUserTask userTask,
				object parameterValue, ProcessSchemaParameter parameter) {
			string result = null;
			EntitySchema referenceSchema = parameter.ReferenceSchema;
			Entity entity = referenceSchema.CreateEntity(userTask.UserConnection);
			if (entity.FetchPrimaryInfoFromDB(referenceSchema.GetPrimaryColumnName(), parameterValue)) {
				result = entity.PrimaryDisplayColumnValue;
			}
			return result;
		}

		protected Dictionary<string, string> GetMacrosValues(EmailTemplateUserTask userTask,
				IEnumerable<MacrosInfo> macrosInfoCollection) {
			ProcessSchemaUserTask userTaskSchema = GetProcessSchemaUserTask(userTask);
			var macrosValues = new Dictionary<string, string>();
			var lookupParameters = new List<ProcessSchemaParameter>();
			foreach (MacrosInfo macrosInfo in macrosInfoCollection) {
				ProcessSchemaParameter parameter = GetParameterByName(userTaskSchema, macrosInfo.Alias);
				if (parameter == null) {
					_logger.Log("Parameter for macros {0} is not found", macrosInfo.Alias);
					continue;
				}
				object propertyValue = GetParameterValue(userTask, parameter);
				if (propertyValue != null) {
					_logger.Log("Property value is {0}", propertyValue);
					macrosValues.Add(macrosInfo.Alias, propertyValue.ToString());
					lookupParameters.Add(parameter);
				}
			}
			foreach (ProcessSchemaParameter parameter in lookupParameters) {
				string entityDisplayName = GetEntityPrimaryColumnDisplayName(userTask,
					macrosValues[parameter.Name], parameter);
				if (!string.IsNullOrEmpty(entityDisplayName)) {
					_logger.Log("Entity display value is {0}", entityDisplayName);
					macrosValues[parameter.Name] = entityDisplayName;
				}
			}
			return macrosValues;
		}

		#endregion

		#region Methods: Public

		public Dictionary<string, string> Proceed(IEnumerable<MacrosInfo> macrosInfoCollection) {
			return null;
		}

		public Dictionary<string, string> Proceed(IEnumerable<MacrosInfo> macrosInfoCollection, object arguments) {
			var userTask = arguments as EmailTemplateUserTask;
			if (userTask == null) {
				_logger.Log("Email user task is empty");
				return null;
			}
			return GetMacrosValues(userTask, macrosInfoCollection);
		}

		public Dictionary<object, Dictionary<string, string>> ProcceedCollection(
				IEnumerable<MacrosInfo> macrosInfoCollection) {
			return null;
		}

		public Dictionary<object, Dictionary<string, string>> ProcceedCollection(
				IEnumerable<MacrosInfo> macrosInfoCollection,
			object arguments) {
			return null;
		}

		#endregion

	}

	#endregion

}
