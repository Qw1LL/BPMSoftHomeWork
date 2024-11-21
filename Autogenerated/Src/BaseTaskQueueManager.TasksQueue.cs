namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;
	
	#region Class: BaseTaskQueueManager

	/// <summary>
	/// Contains methods to work with queue.
	/// Operates with <see cref="BaseQueueMessage"/>.
	/// </summary>
	public abstract class BaseTaskQueueManager<T> where T : BaseTaskQueueMessage
	{

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="BaseQueueManager"/>.
		/// </summary>
		/// <param name="userConnection"></param>
		public BaseTaskQueueManager(UserConnection userConnection) {
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

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="ILog"/> logger.
		/// </summary>
		public abstract ILog Logger { get; set; }

		/// <summary>
		/// Queue message priority by default.
		/// </summary>
		protected virtual int DefaultMessagePriority => 0;

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
				.Set("Priority", new QueryParameter("Priority", null, "Integer"))
				.Set("MessageType", new QueryParameter("MessageType", null, "Integer"));
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
			parameters.GetByName("Priority").Value = message.GetPriority();
			parameters.GetByName("MessageType").Value = message.GetMessageType();
		}

		/// <summary>
		/// Returns <see cref="Select"/> query to get top message in queue.
		/// </summary>
		/// <param name="isOperationalQuery">Flag to indicate operational table usage.</param>
		/// <param name="messageTypes">Allowed message types to be selected.</param>
		/// <returns><see cref="Select"/> query.</returns>
		protected virtual Select GetTopMessageSelect(bool isOperationalQuery, IEnumerable<int> messageTypes) {
			var schemaName = GetSchemaName(isOperationalQuery);
			var select = new Select(UserConnection).Top(1)
					.Column(nameof(BaseTaskQueue.Id))
					.Column(nameof(BaseTaskQueue.Message))
					.Column(nameof(BaseTaskQueue.MaxRetryCount))
					.Column(nameof(BaseTaskQueue.Priority))
				.From(schemaName)
				.OrderByDesc(nameof(BaseTaskQueue.Priority))
				.OrderByAsc(nameof(BaseTaskQueue.CreatedOn)) as Select;
			if (messageTypes == default(IEnumerable<int>)) {
				return select;
			}
			return select.Where(nameof(BaseTaskQueue.MessageType)).In(Column.Parameters(messageTypes)) as Select;
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
		/// Handler on <see cref="OnMessageDequeued"/> event.
		/// </summary>
		/// <param name="message">Instanse of <see cref="T"/> to process.</param>
		protected virtual void FireOnMessageDequeuedEvent(T message) {
			var handler = OnMessageDequeued;
			if (handler != null) {
				handler.Invoke(this, message);
			}
		}

		/// <summary>
		/// Logs enqueue message action.
		/// </summary>
		/// <param name="message"></param>
		protected virtual void LogEnqueue(T message) {
			Logger.Debug($"{message} enqueued.");
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
				LogEnqueue(message);
			}
			return result;
		}

		/// <summary>
		/// Tries to extract first message from queue filtered by allowed types.
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
		/// Tries to extract first message from queue.
		/// </summary>
		/// <returns>Instance of dequeued message or null in case of empty queue.</returns>
		public virtual T Dequeue() => InternalDequeue(default(IEnumerable<int>));

		#endregion

	}

	#endregion

}

