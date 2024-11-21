namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using CoreSysSettings = Core.Configuration.SysSettings;

	#region Class: CampaignQueueManager

	/// <summary>
	/// Contains methods to work with <see cref="CampaignQueue"/> queue.
	/// Operates with <see cref="CampaignQueueItem"/>.
	/// </summary>
	public class CampaignQueueManager : ICampaignQueueManager
	{

		#region Constants: Private

		private const string CampaignQueueTable = nameof(CampaignQueue);
		private const string ItemIdColumnName = nameof(CampaignQueue.Id);
		private const string ContactIdColumnName = nameof(CampaignQueue.ContactId);
		private const string CampaignParticipantIdColumnName = nameof(CampaignQueue.CampaignParticipantId);
		private const string CampaignItemIdColumnName = nameof(CampaignQueue.CampaignItemId);
		private const string CreatedOnColumnName = nameof(CampaignQueue.CreatedOn);
		private const string ExpirationPeriodColumnName = nameof(CampaignQueue.ExpirationPeriod);
		private const string LinkedEntityIdColumnName = nameof(CampaignQueue.LinkedEntityId);
		private const string EntitySchemaUIdColumnName = nameof(CampaignQueue.EntitySchemaUId);
		private const string ContactIdColumnAlias = "ContactId";
		private const string CampaignParticipantIdColumnAlias = "CampaignParticipantId";
		private const int LimitBatchSize = 500;

		#endregion

		#region Constructors: Public

		public CampaignQueueManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection { get; }

		private string ContactIdAliasNotSpecifiedExceptionMessage 
			=> UserConnection.GetLocalizableString(GetType().Name, "ContactIdAliasNotSpecified");

		#endregion

		#region Properties: Public

		/// <summary>
		/// Logger.
		/// </summary>
		private ILog _logger;
		public ILog Logger {
			get => _logger ?? (_logger = LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName));
			set => _logger = value;
		}

		/// <summary>
		/// Max number of items processed simultaneously per campaign item.
		/// </summary>
		private int _maxBatchSize = int.MinValue;
		public int MaxBatchSize {
			get {
				if (_maxBatchSize < 0) {
					var value = CoreSysSettings.GetValue(UserConnection, "CampaignQueueSingleBatchSize", 100);
					_maxBatchSize = Math.Max(value, 0);
				}
				return Math.Min(_maxBatchSize, LimitBatchSize);
			}
			set {
				_maxBatchSize = value;
			}
		}

		#endregion

		#region Methods: Private

		private Insert GetInsertItemQuery() {
			var insert = new Insert(UserConnection)
				.Into(CampaignQueueTable)
				.Set(ItemIdColumnName, new QueryParameter(ItemIdColumnName, null, "Guid"))
				.Set(CampaignItemIdColumnName, new QueryParameter(CampaignItemIdColumnName, null, "Guid"))
				.Set(ContactIdColumnName, new QueryParameter(ContactIdColumnName, null, "Guid"))
				.Set(LinkedEntityIdColumnName, new QueryParameter(LinkedEntityIdColumnName, null, "Guid"))
				.Set(EntitySchemaUIdColumnName, new QueryParameter(EntitySchemaUIdColumnName, null, "Guid"))
				.Set(CreatedOnColumnName, new QueryParameter(CreatedOnColumnName, null, "DateTime"))
				.Set(ExpirationPeriodColumnName, new QueryParameter(ExpirationPeriodColumnName, null, "Integer"))
				.Set(CampaignParticipantIdColumnName, new QueryParameter(CampaignParticipantIdColumnName, null, "Guid"));
			insert.InitializeParameters();
			return insert;
		}

		private IEnumerable<CampaignQueueItem> GetTopItems(int batchSize) {
			var result = new List<CampaignQueueItem>();
			var campaignItemSubSelect = new Select(UserConnection)
				.Top(1)
				.Column(Func.IsNull(Column.SourceColumn(CampaignItemIdColumnName), Column.Const(Guid.Empty)))
					.As("CampaignItemId")
				.From(CampaignQueueTable)
				.OrderByAsc(ExpirationPeriodColumnName) as Select;
			campaignItemSubSelect.SpecifyNoLockHints();
			var select = new Select(UserConnection)
				.Top(batchSize)
				.Column(Func.Max(ItemIdColumnName)).As(ItemIdColumnName)
				.Column(Func.Min(CreatedOnColumnName)).As(CreatedOnColumnName)
				.Column(ContactIdColumnName)
				.Column(CampaignParticipantIdColumnName)
				.Column(Func.Max(LinkedEntityIdColumnName)).As(LinkedEntityIdColumnName)
				.Column(Func.Max(EntitySchemaUIdColumnName)).As(EntitySchemaUIdColumnName)
				.Column(CampaignItemIdColumnName)
				.Column(ExpirationPeriodColumnName)
				.From(CampaignQueueTable)
				.Where(CampaignItemIdColumnName).IsEqual(Column.SubSelect(campaignItemSubSelect))
				.GroupBy(ContactIdColumnName)
				.GroupBy(CampaignParticipantIdColumnName)
				.GroupBy(CampaignItemIdColumnName)
				.GroupBy(ExpirationPeriodColumnName) as Select;
			select.SpecifyNoLockHints();
			select.ExecuteReader(dataReader => {
				var id = dataReader.GetColumnValue<Guid>(ItemIdColumnName);
				var contactId = dataReader.GetColumnValue<Guid>(ContactIdColumnName);
				var campaignParticipantId = dataReader.GetColumnValue<Guid>(CampaignParticipantIdColumnName);
				var linkedEntityId = dataReader.GetColumnValue<Guid>(LinkedEntityIdColumnName);
				var entitySchemaUId = dataReader.GetColumnValue<Guid>(EntitySchemaUIdColumnName);
				var campaignItemId = dataReader.GetColumnValue<Guid>(CampaignItemIdColumnName);
				var createdOn = dataReader.GetColumnValue<DateTime>(CreatedOnColumnName);
				var expirationPeriod = dataReader.GetColumnValue<int>(ExpirationPeriodColumnName);
				var item = new CampaignQueueItem {
					ContactId = contactId,
					CampaignItemId = campaignItemId,
					CampaignParticipantId = campaignParticipantId,
					LinkedEntityId = linkedEntityId,
					EntitySchemaUId = entitySchemaUId,
					Id = id,
					CreatedOn = createdOn,
					ExpirationPeriod = expirationPeriod
				};
				result.Add(item);
			});
			return result;
		}

		private void DeleteItemsById(IEnumerable<Guid> itemIds) {
			if (itemIds.IsNullOrEmpty()) {
				return;
			}
			var delete = new Delete(UserConnection)
				.From(CampaignQueueTable)
				.Where(ItemIdColumnName).In(Column.Parameters(itemIds));
			delete.Execute();
		}

		private void DeleteItemsByCampaignItemId(IEnumerable<Guid> campaignItemIds) {
			if (campaignItemIds.IsNullOrEmpty()) {
				return;
			}
			var delete = new Delete(UserConnection)
				.From(CampaignQueueTable)
				.Where(CampaignItemIdColumnName).In(Column.Parameters(campaignItemIds));
			delete.Execute();
		}

		private QueryColumnExpression GetContactIdColumnExpression(Select contactsSelect) {
			var contactColumn = contactsSelect.Columns.FirstOrDefault(c => c.Alias == ContactIdColumnAlias);
			if (contactColumn == null) {
				throw new Exception(ContactIdAliasNotSpecifiedExceptionMessage);
			}
			return contactColumn.Clone() as QueryColumnExpression;
		}

		private QueryColumnExpression GetCampaignParticipantIdColumnExpression(Select contactsSelect) {
			var campaignParticipantColumn = contactsSelect.Columns
				.FirstOrDefault(c => c.Alias == CampaignParticipantIdColumnAlias);
			if (campaignParticipantColumn == null) {
				return Column.Const(null);
			}
			return campaignParticipantColumn.Clone() as QueryColumnExpression;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Adds single item to queue. Works synchronously.
		/// </summary>
		/// <param name="item">An instance of <see cref="CampaignQueueItem"/> to enqueue.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		public int Enqueue(CampaignQueueItem item) {
			if (item == null) {
				return 0;
			}
			return Enqueue(new[] { item });
		}

		/// <summary>
		/// Adds few items to queue. Works synchronously.
		/// </summary>
		/// <param name="items">A list of <see cref="CampaignQueueItem"/> instances to enqueue.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		public int Enqueue(IEnumerable<CampaignQueueItem> items) {
			if (items.IsNullOrEmpty()) {
				return 0;
			}
			var insert = GetInsertItemQuery();
			var result = 0;
			foreach (var item in items) {
				insert.Parameters.GetByName(ItemIdColumnName).Value = item.Id;
				insert.Parameters.GetByName(CampaignItemIdColumnName).Value = item.CampaignItemId;
				insert.Parameters.GetByName(ContactIdColumnName).Value = item.ContactId;
				insert.Parameters.GetByName(CreatedOnColumnName).Value = item.CreatedOn;
				insert.Parameters.GetByName(ExpirationPeriodColumnName).Value = item.ExpirationPeriod;
				insert.Parameters.GetByName(CampaignParticipantIdColumnName).Value =
					item.CampaignParticipantId.IsEmpty() ? (Guid?)null : item.CampaignParticipantId;
				insert.Parameters.GetByName(LinkedEntityIdColumnName).Value =
					item.LinkedEntityId.IsEmpty() ? (Guid?)null : item.LinkedEntityId;
				insert.Parameters.GetByName(EntitySchemaUIdColumnName).Value =
					item.LinkedEntityId.IsEmpty() ? (Guid?)null : item.EntitySchemaUId;
				result += insert.Execute();
				Logger.Debug($"{item} enqueued.");
			}
			return result;
		}

		/// <summary>
		/// Adds all contacts from <paramref name="contactsSelect"/> to <see cref="CampaignQueue"/>.
		/// </summary>
		/// <param name="contactsSelect">Select query which contains contacts to add.
		/// For correct method work <paramref name="contactsSelect"/> need contains column 
		/// with alias "ContactId".</param>
		/// <param name="campaignItemId">Campaign step identifier.</param>
		/// <param name="expirationPeriod">Expiration for all records which will created 
		/// from <paramref name="contactsSelect"/>.</param>
		/// <returns>A number of items that has been enqueued.</returns>
		public int Enqueue(Select contactsSelect, Guid campaignItemId, int expirationPeriod) {
			var contactColumn = GetContactIdColumnExpression(contactsSelect);
			var campaignParticipantColumn = GetCampaignParticipantIdColumnExpression(contactsSelect);
			contactsSelect.Columns.Clear();
			contactsSelect
				.Column(Column.Parameter(campaignItemId))
				.Column(contactColumn)
				.Column(campaignParticipantColumn)
				.Column(Column.Parameter(DateTime.UtcNow))
				.Column(Column.Parameter(expirationPeriod));
			var insertSelectToQueue = new InsertSelect(contactsSelect.UserConnection)
				.Into(CampaignQueueTable)
				.Set(CampaignItemIdColumnName, ContactIdColumnName, CampaignParticipantIdColumnName,
					CreatedOnColumnName, ExpirationPeriodColumnName)
				.FromSelect(contactsSelect);
			return insertSelectToQueue.Execute();
		}

		/// <summary>
		/// Tries to extract <see cref="MaxBatchSize"/> items from queue.
		/// </summary>
		/// <returns>A list of dequeued items.</returns>
		public IEnumerable<CampaignQueueItem> Dequeue() {
			IEnumerable<CampaignQueueItem> items;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				items = GetTopItems(MaxBatchSize);
				DeleteItemsById(items.Select(x => x.Id));
				dbExecutor.CommitTransaction();
			}
			return items;
		}

		/// <summary>
		/// Clears <see cref="CampaignQueueItem"/> from <see cref="CampaignQueue"/> 
		/// by <see cref="CampaignQueueItem.CampaignItemId"/> which match with <paramref name="campaignItemIds"/>.
		/// </summary>
		/// <param name="campaignItemIds">List of the campaign item identifiers.</param>
		public void ClearByCampaignItems(List<Guid> campaignItemIds) {
			DeleteItemsByCampaignItemId(campaignItemIds);
		}

		#endregion

	}

	#endregion

}

