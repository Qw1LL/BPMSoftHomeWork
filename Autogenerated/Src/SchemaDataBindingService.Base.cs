namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Packages;
	using BPMSoft.Core.Tasks;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Common;

	#region Class: SchemaDataBindingBackgroundTaskParameters

	public class SchemaDataBindingBackgroundTaskParameters
	{
		#region Properties: Public

		public string SchemaName {
			get;
			set;
		}

		public Guid[] RecordIds {
			get;
			set;
		}

		public Guid SysPackageUId {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: SchemaDataBindingBackgroundTask

	public class SchemaDataBindingBackgroundTask : IBackgroundTask<SchemaDataBindingBackgroundTaskParameters>, IUserConnectionRequired
	{

		#region Fields: Private

		private IDataBindingController _dataBindingController;
		private readonly int _maxDescriptorLength = 400;

		#endregion

		#region Properties: Private

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection UserConnection {
			get;
			set;
		}

		/// <summary>
		/// Data binding controller.
		/// </summary>
		private IDataBindingController DataBindingController =>
				_dataBindingController ?? (_dataBindingController = ClassFactory.Get<IDataBindingController>(
					new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private string GetLocalizableString(string className, string resourceName) {
			var localizableString = $"LocalizableStrings.{resourceName}.Value";
			string result = new LocalizableString(UserConnection.ResourceStorage,
				className, localizableString);
			return result;
		}

		private void CreateRemindings(string schemaName, Guid[] recordIds, DataBindingControllerResult result) {
			if (result == null) {
				return;
			}
			CreateErrorRemindings(schemaName, result);
			CreateSuccessReminding(schemaName, recordIds, result);
		}

		private void CreateSuccessReminding(string schemaName, Guid[] recordIds, DataBindingControllerResult result) {
			string remindSubject = GetLocalizableString("SchemaDataBindingService", "SuccessCaption");
			string successMessage = GetSuccessRemindingMessage(recordIds, result);
			Guid? remindingRecordId = recordIds.Length == 1 ? (Guid?)recordIds[0] : null;
			SaveReminding(schemaName, remindSubject, successMessage, remindingRecordId);
		}

		private string GetSuccessRemindingMessage(Guid[] recordIds, DataBindingControllerResult result) {
			var countErrorMessages = GetCountErrorMessages(result);
			int successfulBindCount = recordIds.Count() - countErrorMessages;
			string bindDataMessage = successfulBindCount == recordIds.Count() ? 
				GetLocalizableString("SchemaDataBindingService", "SuccessMessage") : 
				GetLocalizableString("SchemaDataBindingService", "ErrorCaption");
			return string.Format(bindDataMessage, successfulBindCount, recordIds.Count(), countErrorMessages);
		}

		private Dictionary<Guid, string> GetBindedRecords(string schemaName, DataBindingControllerResult result) {
			List<Guid> recordIds = result.ResultMessages?.Keys.ToList();
			if (recordIds == null || recordIds.Count == 0) {
				return null;
			}
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			if (entitySchema.PrimaryDisplayColumn == null) {
				return null;
			}
			EntitySchemaQuery bindedRecordsESQ = GetBindedRecordsESQ(entitySchema, recordIds);
			EntityCollection collectionRecords = bindedRecordsESQ.GetEntityCollection(UserConnection);
			return collectionRecords.ToDictionary(e => e.PrimaryColumnValue, e => e.PrimaryDisplayColumnValue);
			 
		}

		private EntitySchemaQuery GetBindedRecordsESQ(EntitySchema entitySchema, List<Guid> recordIds) {
			var bindedRecordsESQ = new EntitySchemaQuery(entitySchema);
			bindedRecordsESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			if (entitySchema.PrimaryDisplayColumn != null) {
				bindedRecordsESQ.AddColumn(entitySchema.GetPrimaryDisplayColumnName());
			}
			bindedRecordsESQ.Filters.Add(bindedRecordsESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"Id",
				recordIds.Cast<object>().ToArray()));
			return bindedRecordsESQ;
		}

		private string GetPrimaryDisplayColumnValue(Guid recordId, Dictionary<Guid, string> bindedRecords) {
			return bindedRecords?.Any() == true && bindedRecords.TryGetValue(recordId, out var result)
				? result
				: string.Empty;
			
		}

		private void CreateErrorRemindings(string schemaName, DataBindingControllerResult result) {
			if (!HasErrors(result)) {
				return;
			}

			string remindSubject = GetLocalizableString("SchemaDataBindingService", "ErrorMessage");
			var bindedRecords = GetBindedRecords(schemaName, result);
			foreach (var errorMessage in result.ResultMessages) {
				var recordId = errorMessage.Key;
				var displayColumnValue = GetPrimaryDisplayColumnValue(recordId, bindedRecords);
				var errorText = GetFirstErrorMessage(errorMessage.Value);
				var remindErrorText = GetRemindErrorMessage(errorText);
				var remindErrorMessage = !string.IsNullOrEmpty(displayColumnValue) ?
					$"{displayColumnValue}. {remindErrorText}" :
					remindErrorText;
				SaveReminding(schemaName, remindSubject, remindErrorMessage, recordId);
			}
		}

		private bool HasErrors(DataBindingControllerResult result) {
			return !result.Success && result.ResultMessages?.Any() == true;
		}

		private string GetRemindErrorMessage(ItemValidationMessage validationMessage) {
			return validationMessage.Message.Message;
		}

		private int GetCountErrorMessages(DataBindingControllerResult bindResult) {
			return !HasErrors(bindResult) ? 
				0 : 
				bindResult.ResultMessages.Sum(item => GetFirstErrorMessage(item.Value) != null ? 1 : 0);
		}

		private ItemValidationMessage GetFirstErrorMessage(Collection<ItemValidationMessage> messages) {
			return messages.FirstOrDefault(rm => rm.Message.MessageType == MessageType.Error);
		}

		private void SaveReminding(string schemaName, string infoMessage, string description, Guid? recordId = null) {
			var currentUser = UserConnection.CurrentUser;
			var remindTime = currentUser.GetCurrentDateTime();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			Reminding reminding = new Reminding(UserConnection);
			reminding.SetDefColumnValues();
			reminding.AuthorId = currentUser.ContactId;
			reminding.SourceId = RemindingConsts.RemindingSourceAuthorId;
			reminding.ContactId = currentUser.ContactId;
			reminding.RemindTime = remindTime;
			reminding.PopupTitle = infoMessage;
			if (recordId != null) {
				reminding.SubjectId = recordId.Value;
			}
			reminding.SubjectCaption = PrepareRemindingSubjectCaption(description);
			reminding.SysEntitySchemaId = entitySchema.UId;
			reminding.Save();
		}

		private string PrepareRemindingSubjectCaption(string subjectCaption) {
			int maxTextLength = 500;
			if (subjectCaption.Length > maxTextLength) {
				subjectCaption = subjectCaption.Substring(0, maxTextLength);
			}
			return subjectCaption;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IBackgroundTask.Run(TParameters)"/>
		public void Run(SchemaDataBindingBackgroundTaskParameters parameters) {
			DataBindingControllerResult result =
				DataBindingController.GenerateBindings(parameters.SchemaName, parameters.RecordIds, parameters.SysPackageUId);
			CreateRemindings(parameters.SchemaName, parameters.RecordIds, result);
		}

		/// <inheritdoc cref="IUserConnectionRequired.SetUserConnection(UserConnection)"/>
		public void SetUserConnection(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

	}

	#endregion

	#region Class: SchemaDataBindingService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SchemaDataBindingService : BaseService
	{

		#region Properties: Protected

		protected int MaxAllowedRecordsForMultiselect => 1000;

		#endregion

		#region Constructor: Public

		public SchemaDataBindingService() : base() { }
		public SchemaDataBindingService(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Methods: Private

		private bool IsCanManageSolution() {
			return UserConnection.DBSecurityEngine.GetCanExecuteOperation("CanManageSolution");
		}

		private Guid[] GetPrimaryColumnValuesFromFilters(string schemaName, string filterConfig) {
			var filters = JsonConvert.DeserializeObject<BPMSoft.Nui.ServiceModel.DataContract.Filters>(filterConfig);
			var select = new BPMSoft.Nui.ServiceModel.DataContract.SelectQuery {
				RootSchemaName = schemaName,
				Filters = filters,
				UseLocalization = true
			};
			var esq = select.BuildEsq(UserConnection);
			var primaryColumnName = esq.RootSchema.GetPrimaryColumnName();
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			return entities.Select(x => x.GetTypedColumnValue<Guid>(primaryColumnName)).ToArray();
		}

		private ConfigurationServiceResponse GetErrorResponse(string localizableStringCode) {
			var localizableStringFullCode = $"LocalizableStrings.{localizableStringCode}.Value";
			var message = new LocalizableString(UserConnection.ResourceStorage,
				"SchemaDataBindingService", localizableStringFullCode);
			return new ConfigurationServiceResponse(new Exception(message));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generates bindings for records with its subordinate elements.
		/// </summary>
		/// <param name="schemaName">Name of schema.</param>
		/// <param name="recordIds">Ids of records to be binding.</param>
		/// <returns>Service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse GenerateBindings(string schemaName, Guid[] recordIds, Guid sysPackageUId) {
			if (!IsCanManageSolution()) {
				return GetErrorResponse("UserCannotManageSolutionMessage");
			}
			if (recordIds.Length > MaxAllowedRecordsForMultiselect) {
				return GetErrorResponse("TooManyRecordsSelectedMessage");
			}
			Task.StartNewWithUserConnection<SchemaDataBindingBackgroundTask, SchemaDataBindingBackgroundTaskParameters>(
				new SchemaDataBindingBackgroundTaskParameters {
					SchemaName = schemaName,
					RecordIds = recordIds,
					SysPackageUId = sysPackageUId
				}
			);
			return new ConfigurationServiceResponse();
		}

		/// <summary>
		/// Generates bindings for records with its subordinate elements.
		/// </summary>
		/// <param name="schemaName">Name of schema.</param>
		/// <param name="filterConfig">Filter to get records for binding.</param>
		/// <returns>Service response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse GenerateBindingsByFilter(string schemaName, string filterConfig,
				Guid sysPackageUId) {
			var recordIds = GetPrimaryColumnValuesFromFilters(schemaName, filterConfig);
			return GenerateBindings(schemaName, recordIds, sysPackageUId);
		}

		#endregion

	}

	#endregion

}

