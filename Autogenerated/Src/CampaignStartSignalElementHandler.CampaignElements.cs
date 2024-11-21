namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: CampaignStartSignalElementHandler

	/// <summary>
	/// Contains methods for maintaining campaign start signal element.
	/// </summary>
	public sealed class CampaignStartSignalElementHandler : CampaignEventHandlerBase, IOnCampaignAfterSave,
		IOnCampaignValidate, IOnCampaignStart, IOnCampaignFinalize, IOnCampaignCopy
	{

		#region Constants: Private

		private const string ElementHandlerName = nameof(CampaignStartSignalElementHandler);

		#endregion

		#region Constructors: Public

		public CampaignStartSignalElementHandler() {
			_elementHandlerName = GetType().Name;
		}

		#endregion

		#region Fields: Private

		private Guid _signalEntitySchemaUId = new Guid("9CFC5A8A-FCC9-4634-A7A9-84500C8CCB14");

		private readonly IEnumerable<Type> _validNotSessionedElementTypes = new List<Type> {
			typeof(AddCampaignParticipantElement),
			typeof(ExitFromCampaignElement),
			typeof(CampaignLandingElement),
			typeof(CampaignEventElement),
			typeof(CampaignAddEventAudienceElement)
		};

		#endregion

		#region Fields: Protected

		protected string _elementHandlerName;

		#endregion

		#region Properties: Private

		private bool IsCampaignStatusRun => CampaignSchema.StatusId == CampaignConsts.RunCampaignStatusId;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets campaign logger. Instance of <see cref="ICampaignExecutionLogger"/>.
		/// </summary>
		private ICampaignExecutionLogger _campaignExecutionLogger;
		public ICampaignExecutionLogger CampaignExecutionLogger {
			get =>
				_campaignExecutionLogger ?? (_campaignExecutionLogger = ClassFactory.Get<ICampaignExecutionLogger>(
					new ConstructorArgument("userConnection",
						UserConnection)));
			set => _campaignExecutionLogger = value;
		}

		/// <summary>
		/// Gets or sets the campaign scheduler. Instance of <see cref="ICampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignTimeScheduler _campaignTimeScheduler;
		public ICampaignTimeScheduler CampaignTimeScheduler {
			get => _campaignTimeScheduler ?? (_campaignTimeScheduler = new CampaignTimeScheduler(UserConnection));
			set => _campaignTimeScheduler = value;
		}

		#endregion

		#region Methods: Private

		private void LogError(Guid actionId, string errorText) {
			try {
				var logInfo = new CampaignLogInfo {
					CampaignId = CampaignSchema.EntityId,
					Action = actionId,
					IsSuccess = false,
					ErrorText = errorText
				};
				CampaignExecutionLogger.LogAction(logInfo);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat("Exception has occured when logging actions for campaign {0}",
						ex, CampaignSchema.EntityId);
			}
		}

		private void ActualizeCampaignSignalListeners() {
			var schemaManager = (CampaignSchemaManager)UserConnection.GetSchemaManager("CampaignSchemaManager");
			schemaManager.ActualizeCampaignSchemaInfo(CampaignSchema, UserConnection);
		}

		private void RemoveCampaignSignalListeners() {
			var schemaManager = (CampaignSchemaManager)UserConnection.GetSchemaManager("CampaignSchemaManager");
			schemaManager.UnregisterStartSignalEvents(CampaignSchema);
		}

		private IEnumerable<CampaignStartSignalElement> GetSignalElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignStartSignalElement>();
		}

		private string GetNamesOfElements<T>(IEnumerable<T> elements, string delimiter = ",\n")
				where T : CampaignSchemaElement {
			return elements.Select(x => x.Caption).Aggregate((i, j) => i + delimiter + j);
		}

		private IEnumerable<Guid> GetExistingSignalEntityIds() {
			var existingEntityIds = new List<Guid>();
			var exisitingEntitiesSelect = new Select(UserConnection)
				.Column("EntityObjectId")
				.From("CampaignSignalEntity");
			exisitingEntitiesSelect.SpecifyNoLockHints();
			exisitingEntitiesSelect.ExecuteReader(reader => existingEntityIds
				.Add(reader.GetColumnValue<Guid>("EntityObjectId")));
			return existingEntityIds;
		}

		private void ValidateEntitySchemaUId(IEnumerable<CampaignStartSignalElement> signalElements) {
			var schemaUIds = GetExistingSignalEntityIds();
			var invalidElements = signalElements.Where(x => {
				var hasCorrectSignalEntity = !schemaUIds.Contains(x.EntitySchemaUId);
				var isStartSignalElement = x.GetType().IsEquivalentTo(typeof(CampaignStartSignalElement));
				return isStartSignalElement && hasCorrectSignalEntity;
			}).ToList();
			if (invalidElements.Any()) {
				string message = GetLczStringValue(_elementHandlerName, "NotExistingSignalEntityError");
				string validationInfoMessage = string.Format(message, GetNamesOfElements(invalidElements));
				CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Error);
			}
		}

		private void ValidateEntityChangedColumns(IEnumerable<CampaignStartSignalElement> signalElements) {
			var invalidElements = signalElements.Where(x => x.EntitySignal == EntityChangeType.Updated &&
				!x.HasEntityColumnChange).ToList();
			if (invalidElements.Any()) {
				string message = GetLczStringValue(_elementHandlerName, "EmptyEntityColumnsWarning");
				string validationInfoMessage = string.Format(message, GetNamesOfElements(invalidElements));
				CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Warning);
			}
		}

		private void ValidateEntityFilters(IEnumerable<CampaignStartSignalElement> signalElements) {
			var invalidElements = signalElements.Where(x => !x.HasEntityFilters).ToList();
			if (invalidElements.Any()) {
				string message = GetLczStringValue(_elementHandlerName, "EmptyEntityFilterWarning");
				string validationInfoMessage = string.Format(message, GetNamesOfElements(invalidElements));
				CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Warning);
			}
		}

		private void UpdateSignalEntityInfo(IEnumerable<CampaignStartSignalElement> elements) {
			foreach (var element in elements) {
				var signalEntityId = element.SignalEntityId.IsEmpty() ? null as Guid? : element.SignalEntityId;
				UpdateCampaignItemConnectedRecordInfo(element.UId, _signalEntitySchemaUId, signalEntityId);
			}
		}

		private bool IsIncludedIntoFragment(CampaignSchemaElement element, List<Guid> visitedElements) {
			if ((element as CampaignStartSignalElement) != null) {
				return true;
			}
			if (visitedElements.Contains(element.UId)) {
				return false;
			}
			visitedElements.Add(element.UId);
			foreach (var incomingElement in element.Incomings) {
				if (IsIncludedIntoFragment(incomingElement, visitedElements)) {
					return true;
				}
			}
			return false;
		}

		private IEnumerable<CampaignSchemaElement> GetInvalidCustomElements() {
			var notSessionedElements = CampaignSchema.FlowElements
				.Where(x => !x.ElementType.HasFlag(CampaignSchemaElementType.Sessioned)
					&& !_validNotSessionedElementTypes.Contains(x.GetType()));
			var invalidElements = notSessionedElements
				.Where(x => IsIncludedIntoFragment(x, new List<Guid>()));
			return invalidElements;
		}

		private void ValidateNotSessionalElementsInFragment() {
			if (!GetSignalElements(CampaignSchema).Any()) {
				return;
			}
			var invalidCustomElements = GetInvalidCustomElements().ToList();
			if (invalidCustomElements.Any()) {
				var elementsDelimiter = ", ";
				string message = GetLczStringValue(_elementHandlerName, "LinkedCustomElementsException");
				string validationInfoMessage = string.Format(message, 
					GetNamesOfElements(invalidCustomElements, elementsDelimiter));
				CampaignSchema.AddValidationInfo(validationInfoMessage, CampaignValidationInfoLevel.Warning);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Applies methods for campaign start signal element after campaign schema saved.
		/// </summary>
		[Order(-2)]
		public void OnAfterSave() {
			try {
				if (IsCampaignStatusRun) {
					ActualizeCampaignSignalListeners();
				}
				var elements = GetSignalElements(CampaignSchema);
				UpdateSignalEntityInfo(elements);
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnAfterSaveException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies validation rules for signal elements on campaign validation.
		/// </summary>
		[Order(1)]
		public void OnValidate() {
			try {
				var signalElements = GetSignalElements(CampaignSchema);
				ValidateEntitySchemaUId(signalElements);
				ValidateEntityChangedColumns(signalElements);
				ValidateEntityFilters(signalElements);
				ValidateNotSessionalElementsInFragment();
			}
			catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnValidateException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign start signal element on start.
		/// </summary>
		[Order(2)]
		public void OnStart() {
			try {
				var jobConfig = CampaignTimeScheduler.GetNextFireTime(CampaignSchema, null);
				if (jobConfig.ScheduledAction != CampaignScheduledAction.ScheduledStart) {
					ActualizeCampaignSignalListeners();
				}
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnStartException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				LogError(CampaignConsts.CampaignLogTypeCampaignStart, message);
				throw;
			}
		}

		/// <summary>
		/// Applies methods for campaign start signal element on stop.
		/// </summary>
		[Order(-1)]
		public void OnFinalize() {
			try {
				RemoveCampaignSignalListeners();
			} catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnFinalizeException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				LogError(CampaignConsts.CampaignLogTypeCampaignStop, message);
				throw;
			}
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(2)]
		public void OnCopy() {
			try {
				var elements = GetSignalElements(CampaignSchema);
				UpdateSignalEntityInfo(elements);
			}
			catch (Exception ex) {
				string message = GetLczStringValue(ElementHandlerName, "OnCopyException");
				CampaignLogger.ErrorFormat(message, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}

