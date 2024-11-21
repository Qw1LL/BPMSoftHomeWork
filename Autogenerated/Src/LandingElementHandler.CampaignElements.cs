namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Attributes;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.EventHandler;
	using BPMSoft.Core.DB;
	using CoreCampaignSchema = Core.Campaign.CampaignSchema;

	#region Class: LandingElementHandler

	/// <summary>
	/// Contains methods for maintaining landing elements in campaign.
	/// </summary>
	public sealed class LandingElementHandler : LandingElementHandlerBase, IOnCampaignValidate, IOnCampaignCopy,
		IOnCampaignAfterSave
	{

		#region Properties: Protected

		/// <summary>
		/// Handler's name for logging.
		/// </summary>
		protected override string ElementHandlerName => nameof(LandingElementHandler);

		#endregion

		#region Methods: Protected

		protected override IEnumerable<CampaignSchemaElement> GetLandingElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignLandingElement>();
		}

		/// <summary>
		/// Retrieves web form identifier from the campaign element.
		/// </summary>
		protected override Guid GetLandingId(CampaignSchemaElement element) {
			var landingElement = element as CampaignLandingElement;
			return landingElement == null
				? Guid.Empty
				: landingElement.LandingId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates landing elements on campaign validation. Searches inactive landing and adds to the schema.
		/// </summary>
		public void OnValidate() {
			HandleValidate();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(2)]
		public void OnCopy() {
			HandleCopy();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		public void OnAfterSave() {
			HandleAfterSave();
		}

		#endregion

	}

	#endregion

	#region Class: StartLandingElementHandler

	/// <summary>
	/// Contains methods for maintaining start landing elements in campaign.
	/// </summary>
	public sealed class StartLandingElementHandler : LandingElementHandlerBase, IOnCampaignValidate,
		IOnCampaignCopy, IOnCampaignAfterSave
	{

		#region Properties: Protected

		/// <summary>
		/// Handler's name for logging.
		/// </summary>
		protected override string ElementHandlerName => nameof(StartLandingElementHandler);

		#endregion

		#region Methods: Private

		private Dictionary<Guid, string> GetLandingsWithUnknownEntity(
			IEnumerable<CampaignSchemaElement> landingSchemaElements) {
			var invalidLandings = new Dictionary<Guid, string>();
			var landingIds = GetLandingIds(landingSchemaElements);
			if (landingIds.Count() == 0) {
				return invalidLandings;
			}
			var landingEntitySelect = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From("CampaignLandingEntity").As("cle")
				.InnerJoin("SysSchema").As("ssi").On("ssi", "UId").IsEqual("cle", "EntityObjectId")
				.Where("ssi", "Name").IsEqual("ss", "Name") as Select;
			var landingsSelect = new Select(UserConnection)
				.Column("gwf", "Id")
				.Column("ss", "Name")
				.From("GeneratedWebForm").As("gwf")
				.InnerJoin("LandingType").As("lt").On("lt", "Id").IsEqual("gwf", "TypeId")
				.InnerJoin("SysSchema").As("ss").On("ss", "UId").IsEqual("lt", "SchemaUidId")
				.Where("gwf", "Id").In(Column.Parameters(landingIds))
				.And().Not().Exists(landingEntitySelect) as Select;
			landingsSelect.SpecifyNoLockHints();
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = landingsSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var landingId = dataReader.GetColumnValue<Guid>("Id");
						var name = dataReader.GetColumnValue<string>("Name");
						var schema = UserConnection.EntitySchemaManager.GetInstanceByName(name);
						invalidLandings.Add(landingId, schema.Caption);
					}
				}
			}
			return invalidLandings;
		}

		private void ValidateLandingEntity() {
			var landingSchemaElements = GetLandingElements(CampaignSchema);
			if (!landingSchemaElements.Any()) {
				return;
			}
			var landings = GetLandingsWithUnknownEntity(landingSchemaElements);
			WriteValidationInfo(landingSchemaElements, landings, CampaignValidationInfoLevel.Error,
				GetLczStringValue(nameof(LandingElementHandler), "LandingWithUnknownEntityWarning"));
		}

		#endregion

		#region Methods: Protected

		protected override IEnumerable<CampaignSchemaElement> GetLandingElements(CoreCampaignSchema schema) {
			return schema.FlowElements.OfType<CampaignStartLandingElement>();
		}

		/// <summary>
		/// Retrieves web form identifier from the campaign element.
		/// </summary>
		protected override Guid GetLandingId(CampaignSchemaElement element) {
			var landingElement = element as CampaignStartLandingElement;
			return landingElement == null
				? Guid.Empty
				: landingElement.LandingId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates landing elements on campaign validation. Searches inactive landing and adds to the schema.
		/// </summary>
		[Order(1)]
		public void OnValidate() {
			HandleValidate();
			ValidateLandingEntity();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		[Order(1)]
		public void OnCopy() {
			HandleCopy();
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		[Order(-3)]
		public void OnAfterSave() {
			HandleAfterSave();
		}

		#endregion

	}

	#endregion

	#region Class: LandingElementHandlerBase

	/// <summary>
	/// Contains base methods for maintaining landing and start landing elements in campaign.
	/// </summary>
	public abstract class LandingElementHandlerBase : CampaignEventHandlerBase
	{

		#region Fields: Private

		private Guid _landingSchemaUId = new Guid("41AE7D8D-BEC3-41DF-A6F0-2AB0D08B3967");

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Handler's name for logging.
		/// </summary>
		protected abstract string ElementHandlerName { get; }

		#endregion

		#region Methods: Private

		private Dictionary<Guid, string> GetInactiveLandings(
			IEnumerable<CampaignSchemaElement> landingSchemaElements) {
			var inactiveLandings = new Dictionary<Guid, string>();
			var landingIds = GetLandingIds(landingSchemaElements);
			if (landingIds.Count() == 0) {
				return inactiveLandings;
			}
			var landingsStatusSelect = new Select(UserConnection)
				.Column("Id")
				.Column("Name")
				.Column("StateId")
				.From("GeneratedWebForm")
				.Where("Id").In(Column.Parameters(landingIds))
				.And("StateId").IsEqual(Column.Parameter(LendingConsts.NoactiveLendingStateId)) as Select;
			landingsStatusSelect.WithHints(new NoLockHint());
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = landingsStatusSelect.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var landingId = dataReader.GetColumnValue<Guid>("Id");
						var name = dataReader.GetColumnValue<string>("Name");
						inactiveLandings.Add(landingId, name);
					}
				}
			}
			return inactiveLandings;
		}

		private IEnumerable<CampaignSchemaElement> GetModifiedLandingElements() {
			var currentElements = GetLandingElements(CampaignSchema);
			if (CampaignSchema.InitialSchema == null) {
				return currentElements;
			}
			var initialElements = GetLandingElements(CampaignSchema.InitialSchema);
			var sameElements = initialElements.Join(currentElements,
					initial => initial.UId,
					current => current.UId,
					(initial, current) => (GetLandingId(initial) == GetLandingId(current), current))
				.Where(x => x.Item1)
				.Select(x => x.Item2);
			return currentElements.Except(sameElements);
		}

		private void UpdateConnectedLandingInfo(IEnumerable<CampaignSchemaElement> elements) {
			foreach (var element in elements) {
				var id = GetLandingId(element);
				var landingId = id.IsEmpty() ? null as Guid? : id;
				UpdateCampaignItemConnectedRecordInfo(element.UId, _landingSchemaUId, landingId);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Filters all flow elements and returns the list of landing elements.
		/// </summary>
		/// <param name="schema">Campaign schema with flow elements.</param>
		/// <returns>List of landing campaign elements.</returns>
		protected abstract IEnumerable<CampaignSchemaElement> GetLandingElements(CoreCampaignSchema schema);


		/// <summary>
		/// Retrieves web form identifier from the campaign element.
		/// </summary>
		protected abstract Guid GetLandingId(CampaignSchemaElement landingElement);

		/// <summary>
		/// Retrieves web form identifiers from the campaign elements.
		/// </summary>
		protected IEnumerable<Guid> GetLandingIds(IEnumerable<CampaignSchemaElement> landingElements) {
			return landingElements.Select(x => GetLandingId(x)).Where(x => x.IsNotEmpty()).ToList();
		}

		/// <summary>
		/// Writest validation results to campaign validation info.
		/// </summary>
		protected void WriteValidationInfo(IEnumerable<CampaignSchemaElement> landingSchemaElements,
				Dictionary<Guid, string> invalidLandings, CampaignValidationInfoLevel level, string message) {
			foreach (var landing in invalidLandings) {
				var invalidLanding = landingSchemaElements.FirstOrDefault(x => GetLandingId(x) == landing.Key);
				if (invalidLanding == null) {
					continue;
				}
				string validationInfoMessage = string.Format(message, invalidLanding.Caption, landing.Value);
				CampaignSchema.AddValidationInfo(validationInfoMessage, level);
			}
		}

		/// <summary>
		/// Validates landing elements on campaign validation. Searches inactive landing and adds to the schema.
		/// </summary>
		protected void HandleValidate() {
			var landingSchemaElements = GetLandingElements(CampaignSchema);
			if (!landingSchemaElements.Any()) {
				return;
			}
			var inactiveLandings = GetInactiveLandings(landingSchemaElements);
			WriteValidationInfo(landingSchemaElements, inactiveLandings, CampaignValidationInfoLevel.Warning,
				GetLczStringValue(nameof(LandingElementHandler), "InactiveLandingWarning"));
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been copied.
		/// </summary>
		protected void HandleCopy() {
			try {
				var allElements = GetLandingElements(CampaignSchema);
				UpdateConnectedLandingInfo(allElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(ElementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		/// <summary>
		/// Updates connected records info (RecordId and SchemaUId fields) after campaign has been saved.
		/// </summary>
		protected void HandleAfterSave() {
			try {
				var modifiedElements = GetModifiedLandingElements();
				UpdateConnectedLandingInfo(modifiedElements);
			} catch (Exception ex) {
				CampaignLogger.ErrorFormat(ElementHandlerName, ex, CampaignSchema.EntityId);
				throw;
			}
		}

		#endregion

	}

	#endregion

}
