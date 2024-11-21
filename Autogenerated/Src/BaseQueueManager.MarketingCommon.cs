namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;
	using System.Linq;

	#region Class: BaseQueueManager

	/// <summary>
	/// Contains methods to work with queue.
	/// Operates with <see cref="BaseQueueMessage"/>.
	/// </summary>
	[Obsolete("7.18.2 | Class is deprecated, use BPMSoft.Configuration.BaseTaskQueueManager<T> instead.")]
	public abstract class BaseQueueManager<T> where T : BaseQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BaseQueueManager"/>.
		/// </summary>
		/// <param name="userConnection"></param>
		public BaseQueueManager(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		/// <summary>
		/// Schema name of queue entity.
		/// </summary>
		protected abstract string QueueSchemaName { get; }

		/// <summary>
		/// Schema name of operational queue entity.
		/// </summary>
		protected abstract string QueueOpSchemaName { get; }

		/// <summary>
		/// Linked record message column name.
		/// </summary>
		protected abstract string RecordColumnName { get; }

		/// <summary>
		/// Queue message priority by default.
		/// </summary>
		protected virtual int DefaultMessagePriority => 0;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="ILog"/> logger.
		/// </summary>
		public abstract ILog Logger { get; set; }

		#endregion

		#region Events: Public

		/// <summary>
		/// Invoking after any <see cref="T"/> has been moved into the operational table.
		/// </summary>
		public event EventHandler<T> OnMessageDequeued;

		#endregion

		#region Methods: Private

		private T GetTopMessage(bool isOperationalQuery, IEnumerable<int> messageTypes) {
			var topMessage = default(T);
			var messageSelect = GetTopMessageSelect(isOperationalQuery, messageTypes);
			messageSelect.SpecifyNoLockHints();
			messageSelect.ExecuteReader(dataReader => {
				var id = dataReader.GetColumnValue<Guid>("Id");
				var json = dataReader.GetColumnValue<string>("Message");
				var retries = dataReader.GetColumnValue<int>("MaxRetryCount");
				topMessage = CreateMessage(id, json, retries);
			});
			return topMessage;
		}

		private T GetTopOperationalMessage(IEnumerable<int> messageTypes) {
			var message = GetTopMessage(isOperationalQuery: true, messageTypes);
			if (message == default(T)) {
				return default(T);
			}
			message.MaxRetryCount--;
			if (message.MaxRetryCount <= 0) {
				DeleteMessageById(message.Id, isOperationalQuery: true);
				if (message.MaxRetryCount < 0) {
					return default(T);
				}
			} else {
				UpdateMessageRetryCount(message.Id, message.MaxRetryCount);
			}
			return message;
		}

		private void UpdateMessageRetryCount(Guid id, int maxRetryCount) {
			var update = new Update(UserConnection, QueueOpSchemaName)
				.Set("MaxRetryCount", Column.Parameter(maxRetryCount))
				.Where("Id").IsEqual(Column.Parameter(id)) as Update;
			update.WithHints(new RowLockHint());
			update.Execute();
		}

		private void DeleteMessageById(Guid messageId, bool isOperationalQuery) {
			var schemaName = GetSchemaName(isOperationalQuery);
			var delete = new Delete(UserConnection)
				.From(schemaName)
				.Where("Id").IsEqual(Column.Parameter(messageId));
			delete.Execute();
		}

		private void InsertMessageToOpTable(T message) {
			var insert = GetInternalInsertMessageQueryTemplate(isOperationalQuery: true);
			SetQueryParameters(ref insert, message);
			insert.Execute();
		}

		private void FireOnMessageDequeuedEvent(T message) {
			var handler = OnMessageDequeued;
			if (handler != null) {
				handler.Invoke(this, message);
			}
		}

		private T InternalDequeue(IEnumerable<int> messageTypes) {
			var message = default(T);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction();
				message = GetTopOperationalMessage(messageTypes);
				if (message == null) {
					message = GetTopMessage(isOperationalQuery: false, messageTypes);
					if (message == null) {
						dbExecutor.CommitTransaction();
						return null;
					}
					InsertMessageToOpTable(message);
					DeleteMessageById(message.Id, isOperationalQuery: false);
				}
				dbExecutor.CommitTransaction();
				Logger.Debug($"{message} dequeued.");
			}
			FireOnMessageDequeuedEvent(message);
			DeleteMessageById(message.Id, isOperationalQuery: true);
			return message;
		}

		private Insert GetInternalInsertMessageQueryTemplate(bool isOperationalQuery) {
			var insert = GetInsertMessageQueryTemplate(isOperationalQuery);
			insert.InitializeParameters();
			return insert;
		}

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
		/// Returns schema name of queue entity.
		/// </summary>
		/// <param name="isOperationalQuery">Flag to indicate operational table usage.</param>
		/// <returns>Schema name.</returns>
		protected string GetSchemaName(bool isOperationalQuery) => isOperationalQuery
			? QueueOpSchemaName
			: QueueSchemaName;

		/// <summary>
		/// Returns <see cref="Insert"/> query template to enqueue message.
		/// </summary>
		/// <param name="isOperationalQuery">Flag to indicate operational table usage.</param>
		/// <returns><see cref="Insert"/> query.</returns>
		protected virtual Insert GetInsertMessageQueryTemplate(bool isOperationalQuery) {
			var schemaName = GetSchemaName(isOperationalQuery);
			return new Insert(UserConnection)
				.Into(schemaName)
				.Set("Id", new QueryParameter("Id", null, "Guid"))
				.Set("CreatedOn", new QueryParameter("CreatedOn", null, "DateTime"))
				.Set("MaxRetryCount", new QueryParameter("MaxRetryCount", null, "Integer"))
				.Set("Message", new QueryParameter("Message", null, "MaxSizeText"))
				.Set("MessageType", new QueryParameter("MessageType", null, "Integer"))
				.Set("EstimatedRowsCount", new QueryParameter("EstimatedRowsCount", null, "Integer"))
				.Set("EstimatedTime", new QueryParameter("EstimatedTime", 1, "Integer"));
		}

		/// <summary>
		/// Fills values for query parameters with enqueued message properties.
		/// </summary>
		/// <param name="insert"><see cref="Insert"/> query to enqueue message.</param>
		/// <param name="message">Instance of <see cref="T"/> message to enqueue.</param>
		protected virtual void SetQueryParameters(ref Insert insert, T message) {
			var parameters = insert.Parameters;
			parameters.GetByName("Id").Value = message.Id;
			parameters.GetByName("CreatedOn").Value = DateTime.UtcNow;
			parameters.GetByName("MaxRetryCount").Value = message.MaxRetryCount;
			parameters.GetByName("Message").Value = message.ToString();
			parameters.GetByName("MessageType").Value = message.GetMessageType();
			parameters.GetByName("EstimatedRowsCount").Value = message.EstimatedRowsCount;
			parameters.GetByName("EstimatedTime").Value = (message.EstimatedRowsCount / 500) + 1;
		}

		/// <summary>
		/// Returns <see cref="Select"/> query to get top message in queue.
		/// </summary>
		/// <param name="isOperationalQuery">Flag to indicate operational table usage.</param>
		/// <param name="messageTypes">Allowed message types to be selected.</param>
		/// <returns><see cref="Select"/> query.</returns>
		protected virtual Select GetTopMessageSelect(bool isOperationalQuery, IEnumerable<int> messageTypes) {
			var schemaName = GetSchemaName(isOperationalQuery);
			return new Select(UserConnection).Top(1)
					.Column("Id")
					.Column("Message")
					.Column("MaxRetryCount")
				.From(schemaName)
				.Where("MessageType").In(Column.Parameters(messageTypes))
				.OrderByAsc("CreatedOn") as Select;
		}

		/// <summary>
		/// Returns instance of <see cref="T"/> message.
		/// </summary>
		/// <param name="id">Unique identifier.</param>
		/// <param name="json">Serialized message.</param>
		/// <param name="retries">Retries count.</param>
		/// <returns><see cref="T"/> message.</returns>
		protected abstract T CreateMessage(Guid id, string json, int retries);

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
		/// Adds few items into queue. Works synchronously.
		/// </summary>
		/// <param name="messages">A list of <see cref="T"/> to enqueue.</param>
		/// <returns>A number of items that had been enqueued.</returns>
		public virtual int Enqueue(IEnumerable<T> messages) {
			if (messages.IsNullOrEmpty()) {
				return 0;
			}
			var insert = GetInternalInsertMessageQueryTemplate(isOperationalQuery: false);
			var result = 0;
			foreach (var message in messages) {
				SetQueryParameters(ref insert, message);
				result += insert.Execute();
				Logger.Debug($"{message} enqueued.");
			}
			return result;
		}

		/// <summary>
		/// Tries to extract fist message from queue filtered by allowed types.
		/// </summary>
		/// <param name="messageTypes">A list of message types to filter messages.</param>
		/// <returns>Instance of dequeued message or null in case of empty queue.</returns>
		public virtual T Dequeue(IEnumerable<int> messageTypes) {
			messageTypes.CheckArgumentNull("messageTypes");
			if (messageTypes.IsEmpty()) {
				return null;
			}
			return InternalDequeue(messageTypes);
		}

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

