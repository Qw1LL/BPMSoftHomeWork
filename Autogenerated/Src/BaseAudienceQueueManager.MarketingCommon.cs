namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: BaseAudienceQueueManager

	/// <summary>
	/// Contains methods to work with queue.
	/// Operates with <see cref="BaseQueueMessage"/>.
	/// </summary>
	public abstract class BaseAudienceQueueManager<T> : BaseTaskQueueManager<T> where T : BaseQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BaseAudienceQueueManager"/>.
		/// </summary>
		/// <param name="userConnection"></param>
		public BaseAudienceQueueManager(UserConnection userConnection) : base(userConnection) {}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Linked record message column name.
		/// </summary>
		protected abstract string RecordColumnName { get; }

		#endregion

		#region Methods: Private

		private int GetEstimatedTime(int position) {
			var subSelect = new Select(UserConnection)
				.Top(position)
				.Column("EstimatedTime").As("EstimatedTime")
				.From(GetSchemaName(false))
				.OrderByDesc("Priority")
				.OrderByAsc("CreatedOn") as Select;
			var select = new Select(UserConnection)
				.Column(Func.IsNull(Func.Sum("sub", "EstimatedTime"), Column.Parameter(0)))
				.From(subSelect).As("sub");
			select.SpecifyNoLockHints();
			return select.ExecuteScalar<int>();
		}

		private Dictionary<Guid, int> GetTasksInProgress() {
			var select = new Select(UserConnection)
				.Column(RecordColumnName)
				.Column("EstimatedTime")
				.From(GetSchemaName(true));
			select.SpecifyNoLockHints();
			var result = new Dictionary<Guid, int>();
			select.ExecuteReader(r => {
				var id = r.GetColumnValue<Guid>(RecordColumnName);
				var eta = r.GetColumnValue<int>("EstimatedTime");
				result.Add(id, eta);
			});
			return result;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns <see cref="Insert"/> query template to enqueue message.
		/// </summary>
		/// <param name="isOperationalQuery">Flag to indicate operational table usage.</param>
		/// <returns><see cref="Insert"/> query.</returns>
		protected override Insert GetInsertMessageQueryTemplate(bool isOperationalQuery) {
			var insert = base.GetInsertMessageQueryTemplate(isOperationalQuery);
			return insert
				.Set("EstimatedRowsCount", new QueryParameter("EstimatedRowsCount", null, "Integer"))
				.Set("EstimatedTime", new QueryParameter("EstimatedTime", 1, "Integer"));
		}

		/// <summary>
		/// Fills values for query parameters with enqueued message properties.
		/// </summary>
		/// <param name="insert"><see cref="Insert"/> query to enqueue message.</param>
		/// <param name="message">Instance of <see cref="T"/> message to enqueue.</param>
		protected override void SetQueryParameters(ref Insert insert, T message) {
			base.SetQueryParameters(ref insert, message);
			var parameters = insert.Parameters;
			parameters.GetByName("EstimatedRowsCount").Value = message.EstimatedRowsCount;
			parameters.GetByName("EstimatedTime").Value = (message.EstimatedRowsCount / 500) + 1;
		}

		/// <summary>
		/// Returns <see cref="Select"/> query to get current record last message position in queue.
		/// </summary>
		/// <param name="recordId">Unique identifier of message linker record.</param>
		/// <returns><see cref="Select"/> query.</returns>
		protected Select GetLastAudienceMessagePositionSelect(Guid recordId) {
			var subSelect =
				new Select(UserConnection)
					.Column(RecordColumnName)
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						null,
						new QueryColumnExpression("CreatedOn"),
						OrderDirection.Ascending)).As("RowNum")
				.From(GetSchemaName(false))
				.Where("Priority").IsEqual(Column.Parameter(DefaultMessagePriority)) as Select;
			var select =
				new Select(UserConnection)
					.Column(Func.Max("RowNum"))
				.From(subSelect).As("Sub")
				.Where(RecordColumnName).IsEqual(Column.Parameter(recordId)) as Select;
			select.SpecifyNoLockHints();
			return select;
		}

		/// <summary>
		/// Returns position of last message for record in queue.
		/// </summary>
		/// <param name="recordId">Unique identifier of record.</param>
		/// <returns>Position of last message for record in queue.</returns>
		protected virtual int GetLastPositionForRecord(Guid recordId) {
			var lastMessagePositionSelect = GetLastAudienceMessagePositionSelect(recordId);
			return lastMessagePositionSelect.ExecuteScalar<int>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Estimation data of message processing for current record.
		/// </summary>
		/// <param name="recordId">Identifier of the record.</param>
		/// <returns>Tuple of estimated data (position in queue and time to be executed)
		/// for current record.</returns>
		public virtual (int position, int eta) GetEstimationForRecord(Guid recordId) {
			var tasksInProgress = GetTasksInProgress();
			var position = GetLastPositionForRecord(recordId);
			if (position == 0) {
				return tasksInProgress.ContainsKey(recordId)
					? (1, tasksInProgress[recordId])
					: (0, 0);
			}
			var estimatedTime = GetEstimatedTime(position);
			var taskInProgressEta = tasksInProgress.Values.Sum();
			return tasksInProgress.Keys.IsNotEmpty()
				? (position + 1, estimatedTime + taskInProgressEta)
				: (position, estimatedTime);
		}

		#endregion

	}

	#endregion

}

