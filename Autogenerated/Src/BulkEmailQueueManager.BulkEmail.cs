namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;

	#region Class: BulkEmailQueueManager

	/// <summary>
	/// Contains methods to work with <see cref="BulkEmailQueue"/> queue.
	/// Operates with <see cref="BulkEmailQueueMessage"/>.
	/// </summary>
	public class BulkEmailQueueManager : BaseAudienceQueueManager<BulkEmailQueueMessage>
	{

		#region Constructors: Public

		/// <inheritdoc />
		public BulkEmailQueueManager(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Properties: Protected

		/// <inheritdoc />
		protected override string QueueSchemaName => nameof(BulkEmailQueue);

		/// <inheritdoc />
		protected override string QueueOpSchemaName => nameof(BulkEmailQueueOp);

		/// <inheritdoc />
		protected override string RecordColumnName => BulkEmailQueueMessage.RecordName;

		/// <inheritdoc />
		protected override int DefaultMessagePriority => 25;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Logger.
		/// </summary>
		private ILog _logger;
		public override ILog Logger {
			get => _logger ?? (_logger = MailingUtilities.Log);
			set => _logger = value;
		}

		#endregion

		#region Methods: Private

		private bool CheckBulkEmailMessagesExist(Guid bulkEmailId) {
			var messageSelect = new Select(UserConnection)
				.Column("Id")
				.From(GetSchemaName(true))
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId))
				.Union(new Select(UserConnection)
				.Top(1)
				.Column("Id")
				.From(GetSchemaName(false))
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId))) as Select;
			var select = new Select(UserConnection).Column(Func.Count("Id")).From(messageSelect).As("T");
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<int>() > 0;
		}

		private Select GetTriggeredSendMessagesCountSelect() {
			var select =
				new Select(UserConnection)
					.Column(Func.Count("Id"))
				.From(GetSchemaName(false))
				.Where("Priority").IsEqual(Column.Const(50)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion


		#region Methods: Protected

		/// <inheritdoc />
		protected override BulkEmailQueueMessage CreateMessage(Guid id, string json, int retries) =>
			BulkEmailQueueMessage.Create(id, json, retries);

		/// <inheritdoc />
		protected override Insert GetInsertMessageQueryTemplate(bool isOperationalQuery) {
			var insert = base.GetInsertMessageQueryTemplate(isOperationalQuery);
			return insert
				.Set("BulkEmailId", new QueryParameter("BulkEmailId", null, "Guid"));
		}

		/// <inheritdoc />
		protected override void SetQueryParameters(ref Insert insert, BulkEmailQueueMessage message) {
			base.SetQueryParameters(ref insert, message);
			var parameters = insert.Parameters;
			parameters.GetByName("BulkEmailId").Value = message.BulkEmailId;
		}

		/// <inheritdoc />
		protected override Select GetTopMessageSelect(bool isOperationalQuery, IEnumerable<int> messageTypes) {
			var select = base.GetTopMessageSelect(isOperationalQuery, messageTypes);
			select.OrderByItems.Clear();
			return select
				.OrderByDesc("Priority")
				.OrderByAsc("CreatedOn") as Select ;
		}

		/// <inheritdoc />
		protected override int GetLastPositionForRecord(Guid recordId) {
			var triggeredSendCountSelect = GetTriggeredSendMessagesCountSelect();
			var lastMessagePositionSelect = GetLastAudienceMessagePositionSelect(recordId);
			var select =
				new Select(UserConnection).Top(1)
					.Column(triggeredSendCountSelect).As("TopPriorityCount")
					.Column(Func.IsNull(Column.SubSelect(lastMessagePositionSelect), Column.Parameter(0)))
						.As("RowNumber")
				.From(GetSchemaName(false));
			select.SpecifyNoLockHints();
			select.ExecuteSingleRecord(x => {
				var rowNumber = x.GetColumnValue<int>("RowNumber");
				if (rowNumber == 0) {
					return 0;
				}
				var topPriorityCount = x.GetColumnValue<int>("TopPriorityCount");
				return topPriorityCount + rowNumber;
			}, out int result);
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Checks existence of messages in queue for bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Identifier of the bulk email.</param>
		/// <returns>True when queue contains messages for bulk email.</returns>
		public virtual bool CheckMessagesExist(Guid bulkEmailId) {
			return CheckBulkEmailMessagesExist(bulkEmailId);
		}

		#endregion

	}

	#endregion

}

