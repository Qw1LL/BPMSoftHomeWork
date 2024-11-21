 namespace BPMSoft.Configuration
 {
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.Campaign.StartSignal;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: CampaignSignalEntityHandler

	/// <summary>
	/// Class to handle on campaign signal entity events.
	/// </summary>
	public class CampaignSignalEntityHandler : ICampaignSignalEntityHandler
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="CampaignSignalEntityHandler" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public CampaignSignalEntityHandler(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
		}

		#endregion

		#region Properties: Protected

		private ILog _logger;

		/// <summary>
		/// Instance of campaign logger.
		/// </summary>
		protected ILog CampaignLogger {
			get => _logger ?? (_logger = LogManager.GetLogger(CampaignConstants.CampaignLoggerName));
			set => _logger = value;
		}

		private ICampaignQueueManager _campaignQueueManager;

		/// <summary>
		/// Instance of <see cref="CampaignQueueManager" />.
		/// </summary>
		protected ICampaignQueueManager CampaignQueueManager {
			get => _campaignQueueManager ?? (_campaignQueueManager = new CampaignQueueManager(UserConnection));
			set => _campaignQueueManager = value;
		}

		/// <summary>
		/// Time (in minutes) that tells, how long signal queue items are actual.
		/// </summary>
		private int _signalQueueItemLifeTime = int.MinValue;
		public int SignalQueueItemLifeTime {
			get {
				if (_signalQueueItemLifeTime < 0) {
					var value = Core.Configuration.SysSettings.GetValue(UserConnection,
						"CampaignTriggeredQueueTimeout", 60);
					_signalQueueItemLifeTime = Math.Max(value, 0);
				}
				return _signalQueueItemLifeTime;
			}
			set {
				_signalQueueItemLifeTime = value;
			}
		}

		#endregion

		#region Methods: Private

		private bool IsLinkedEntityAvailable(string entitySchemaName) =>
			UserConnection.GetIsFeatureEnabled("CampaignAudienceImport") && entitySchemaName != "Contact";

		private List<CampaignQueueItem> GetQueueItemsByEntityId(Guid entityId, Guid entitySchemaUId, 
				Guid campaignItemId, string contactColumnPath) {
			var result = new List<CampaignQueueItem>();
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
			var esQuery = new EntitySchemaQuery(entitySchema);
			var contactColumn = esQuery.AddColumn(contactColumnPath);
			esQuery.IsDistinct = true;
			var filter = esQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", entityId);
			esQuery.Filters.Add(filter);
			var isNotNullContactFilter = esQuery.CreateIsNotNullFilter(contactColumnPath);
			esQuery.Filters.Add(isNotNullContactFilter);
			var entities = esQuery.GetEntityCollection(UserConnection);
			var linkedEntityId = IsLinkedEntityAvailable(entitySchema.Name) ? entityId : default(Guid);
			foreach (var entity in entities) {
				var columnNames = entity.GetColumnValueNames();
				var contactColumnName = columnNames.FirstOrDefault() ?? contactColumn.Name;
				var contactId = entity.GetTypedColumnValue<Guid>(contactColumnName);
				result.Add(new CampaignQueueItem {
					ContactId = contactId,
					CampaignItemId = campaignItemId,
					ExpirationPeriod = SignalQueueItemLifeTime,
					LinkedEntityId = linkedEntityId,
					EntitySchemaUId = entitySchemaUId
				});
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns path to contact column for the entity of requested campaign item.
		/// </summary>
		/// <param name="campaignItemId">Campaign signal item id.</param>
		/// <returns>Contact column path.</returns>
		protected virtual string GetContactColumnPath(Guid campaignItemId) {
			var select = new Select(UserConnection)
				.Column("cse", "ContactColumn")
				.From("CampaignItem", "ci")
				.LeftOuterJoin("CampaignSignalEntity").As("cse").On("ci", "RecordId").IsEqual("cse", "Id")
				.Where("ci", "Id").IsEqual(Column.Parameter(campaignItemId, "Guid")) as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<string>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets ContactId from entity that triggered event and adds to campaign queue.
		/// </summary>
		/// <param name="entitySchemaUId">Unique identifier of entity schema that has triggered event.</param>
		/// <param name="entityId">Id of entity that has triggered event.</param>
		/// <param name="campaignItemId">Unique identifier of triggered campaign start signal element.</param>
		public void Handle(Guid entitySchemaUId, Guid entityId, Guid campaignItemId) {
			var contactColumnPath = GetContactColumnPath(campaignItemId);
			if (!string.IsNullOrWhiteSpace(contactColumnPath)) {
				 var queueItems = GetQueueItemsByEntityId(entityId, entitySchemaUId, campaignItemId,
					 contactColumnPath);
				CampaignQueueManager.Enqueue(queueItems);
			} else {
				var message = string.Format("Contact column path was not found for campaign item: {0}.",
					campaignItemId);
				CampaignLogger.Error(message);
			}
		}

		#endregion

	}

	#endregion

	#region Class: CampaignLandingEntityHandler

	/// <summary>
	/// Handles entity signals for <see cref="CampaignStartLandingElement"/>.
	/// </summary>
	public class CampaignLandingEntityHandler : CampaignSignalEntityHandler
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="CampaignLandingEntityHandler" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public CampaignLandingEntityHandler(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Provides query info for the specified landing.
		/// </summary>
		private LandingContactQueryProvider _queryProvider;
		public LandingContactQueryProvider LandingQueryProvider {
			get => _queryProvider ?? (_queryProvider = new LandingContactQueryProvider(UserConnection));
			set => _queryProvider = value;
		}

		#endregion

		#region Methods: Protected

		protected override string GetContactColumnPath(Guid campaignItemId) {
			var select = new Select(UserConnection)
				.Column("RecordId")
				.From("CampaignItem")
				.Where("Id").IsEqual(Column.Parameter(campaignItemId)) as Select;
			select.SpecifyNoLockHints();
			var landingId = select.ExecuteScalar<Guid>();
			return LandingQueryProvider.GetLandingEntityContactColumn(landingId);
		}

		#endregion

	}

	#endregion
	
	#region Class: CampaignEventEntityHandler

	/// <summary>
	/// Handles entity signals for <see cref="CampaignStartEventElement"/>.
	/// </summary>
	public class CampaignEventEntityHandler : CampaignSignalEntityHandler
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="CampaignEventEntityHandler" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public CampaignEventEntityHandler(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Protected

		protected override string GetContactColumnPath(Guid campaignItemId) {
			return "Contact.Id";
		}

		#endregion

	}

	#endregion
}

