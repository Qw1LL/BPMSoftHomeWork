namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;

	#region Class: OperationAgent

	public class MultiDeleteOperationAgent : IOperationAgent, IRecordProcessedHandler
	{

		#region Enums: Protected

		[Flags]
		protected enum OperationState
		{
			Wait = 1,
			Progress = 2,
			Error = 3,
			Done = 4,
			Canceled = 5
		}

		#endregion

		#region Constants: Private

		private const string MULTI_DELETE_QUEUE = "MultiDeleteQueue";
		private const string MULTI_DELETE_DENY_REASON = "MultiDeleteDenyReason";
		private const int DEFAULT_NUMBER_ITEMS_RETURNED = 100;
		private const int RECORD_IN_QUEUE_LIFETIME = 1;
		private const int ERROR_RECORD_LIFETIME = 90;

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("MultiDelete");
		private readonly object _numberItemsLock = new object();
		private readonly object _operationLock = new object();
		private readonly UserConnection _userConnection;
		private readonly IDictionary<string, object> _parameters;
		private readonly string[] _requiredParameters = { "OperationKey", "SchemaName" };
		private int _queueCount;
		private int _returnedCount;

		#endregion

		#region Constructors: Public

		public MultiDeleteOperationAgent(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			_parameters = parameters;
			ValidateParameters();
		}

		#endregion

		#region Properties: Propected

		protected static ILog Log {
			get {
				return _log;
			}
		}

		private Guid _operationKey;
		protected Guid OperationKey {
			get {
				if (_operationKey.Equals(default(Guid))) {
					_operationKey = (Guid)_parameters["OperationKey"];
				}
				return _operationKey;
			}
		}

		private string _entitySchemaName;
		public string EntitySchemaName {
			get {
				return _entitySchemaName ?? (_entitySchemaName = GetEntitySchemaName());
			}
		}

		private Guid? _entitySchemaUId;

		public Guid? EntitySchemaUId {
			get {
				return _entitySchemaUId ?? (_entitySchemaUId = GerEntitySchemaUId());
			}
		}

		private IDictionary<string, Guid> _multiDeleteDenyReasons;
		protected IDictionary<string, Guid> MultiDeleteDenyReasons {
			get {
				return _multiDeleteDenyReasons ?? (_multiDeleteDenyReasons = GetMultiDeleteDenyReason());
			}
		}

		private bool? _isRoot;
		public bool IsRoot {
			get {
				return (bool)(_isRoot ?? (_isRoot = GetEntityIsRoot()));
			}
		}

		#endregion

		#region Properties: Public

		private int _numberItemsReturned;
		public int NumberItemsReturned {
			get {
				if (!_numberItemsReturned.Equals(default(int))) {
					return _numberItemsReturned;
				}
				lock (_numberItemsLock) {
					_numberItemsReturned = GetNumberItemsReturned();
				}
				return _numberItemsReturned;
			}
			set {
				lock (_numberItemsLock) {
					if (value > 0) {
						_numberItemsReturned = value;
					} else if (_numberItemsReturned.Equals(default(int))) {
						_numberItemsReturned = GetDefaultNumberItemsReturned();
					}
				}
			}
		}

		#endregion

		#region Methods: Private

		private void ValidateParameters() {
			foreach (string parameterName in _requiredParameters) {
				if (!_parameters.ContainsKey(parameterName)) {
					ThrowArgumentNullException(parameterName);
				}
			}
		}

		private IDictionary<string, Guid> GetMultiDeleteDenyReason() {
			var select = GetSelectQueryDenyReasons();
			return SelectExecutor(select, GetDenyReason)
				.ToDictionary(item => item.Key, item => item.Value);
		}

		private string GetEntitySchemaName() {
			var schemaName = (string)_parameters["SchemaName"];
			return schemaName;
		}

		private bool GetEntityIsRoot() {
			var result = false;
			if (_parameters.ContainsKey("IsRoot")) {
				result = (bool)_parameters["IsRoot"];
			}
			return result;
		}

		private Guid GerEntitySchemaUId() {
			return _userConnection.EntitySchemaManager.GetInstanceByName(EntitySchemaName).UId;
		}
		
		/// <summary>
		/// Returns entity primary column name.
		/// </summary>
		/// <returns>Primary column name.</returns>
		private string GetPrimaryColumnName() {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(EntitySchemaName);
			return entitySchema.PrimaryColumn.Name;
		}

		private string GetExceptionName(Exception exception) {
			if (exception == null) {
				return string.Empty;
			}
			var exceptionType = exception.GetType();
			return exceptionType.Name;
		}

		private Guid GetDenyReasonId(Exception exception) {
			string exceptionName = GetExceptionName(exception);
			return MultiDeleteDenyReasons.ContainsKey(exceptionName)
				? MultiDeleteDenyReasons[exceptionName]
				: GetDefaultDeleteDenyReason(exception);
		}


		private Guid GetDefaultDeleteDenyReason(Exception exception) {
			string exceptionName = GetExceptionName(exception);
			string logTemplate = "An unknown exception: name:'{0}'\r\n";
			Log.InfoFormat(logTemplate, exceptionName, exception);
			return MultiDeleteDenyReasons["Exception"];
		}

		private IEnumerable<T> SelectExecutor<T>(Select select, Func<IDataReader, T> predicate) {
			var collection = new List<T>();
			try {
				using (var dbExecutor = _userConnection.EnsureDBConnection()) {
					using (var reader = select.ExecuteReader(dbExecutor)) {
						while (reader.Read()) {
							var result = predicate(reader);
							collection.Add(result);
						}
					}
				}
			} catch (Exception ex) {
				Log.Error(ex.Message, ex);
				throw;
			}

			return collection;
		}

		private int GetNumberItemsReturned() {
			int result;
			object parameterValue;
			string parameterName = "NumberItemsReturned";
			if (_parameters.TryGetValue(parameterName, out parameterValue)) {
				result = (int)parameterValue;
			} else {
				result = GetDefaultNumberItemsReturned();
			}
			if (result.Equals(default(int))) {
				ThrowArgumentNullException(parameterName);
			}
			return result;
		}

		private void ThrowArgumentNullException(string parameterName) {
			var exception = new ArgumentNullException(parameterName);
			Log.Error(exception.Message, exception);
			throw exception;
		}

		private int GetDefaultNumberItemsReturned() {
			return Core.Configuration.SysSettings.GetValue(_userConnection, "DefaultNumberItemsReturned", DEFAULT_NUMBER_ITEMS_RETURNED);
		}

		private Select GetSelectQueryFromEntity() {
			var sysAdminUnitId = _userConnection.CurrentUser.Id;
			var entityName = EntitySchemaName;
			var primaryColumnName = GetPrimaryColumnName();
			return new Select(_userConnection).Top(NumberItemsReturned)
					.Column(Column.Parameter(EntitySchemaUId)).As("EntitySchemaUId")
					.Column(primaryColumnName).As("RecordId")
					.Column(Column.Parameter(sysAdminUnitId)).As("SysAdminUnitId")
					.Column(Column.Parameter(OperationKey)).As("OperationKey")
					.Column(Column.Parameter(OperationState.Wait)).As("State")
					.Column(Column.Parameter(IsRoot)).As("IsRoot")
					.Distinct()
				.From(entityName);
		}

		private Select GetSelectQueryFromEntityWithCondition(IEnumerable<Guid> recordIds) {
			var select = GetSelectQueryFromEntity();
			var primaryColumnName = GetPrimaryColumnName();
			return select.Where(primaryColumnName).In(Column.Parameters(recordIds)) as Select;
		}

		private IEnumerable<Guid> Paging(IEnumerable<Guid> collection, int iteration) {
			return collection.Skip(iteration * NumberItemsReturned).Take(NumberItemsReturned);
		}

		private Update GetUpdateQueryState(OperationState state) {
			return new Update(_userConnection, MULTI_DELETE_QUEUE)
				.Set("State", Column.Parameter(state));
		}

		private Update GetUpdateQueryRecordsState(IEnumerable<Guid> recordIds, OperationState state) {
			var update = GetUpdateQueryState(state);
			return update
				.Where("RecordId").In(Column.Parameters(recordIds)) as Update;
		}

		private Update GetUpdateQueryRecordsState(Guid recordId, OperationState state) {
			var update = GetUpdateQueryState(state);
			return update
				.Where("RecordId").In(Column.Parameter(recordId)) as Update;
		}

		private Select GetSelectQueryRecordIds() {
			var select = new Select(_userConnection);
			if (_parameters.ContainsKey("PreviousOperationKey")) {
				select = GetSelectQueryForCascade();
			} else {
				select = GetSelectQueryRecordIdsWithState();
			}
			return select;
		}

		private Select GetSelectQueryForCascade() {
			var select = GetSelectQueryRecordIdsWithState(OperationState.Error,
				(Guid)_parameters["PreviousOperationKey"]);
			select.And("DenyReasonId").Not().IsEqual(Column.Parameter(MultiDeleteDenyReasons["SecurityException"]));
			return select;
		}

		#endregion

		#region Methods: Protected

		protected virtual Select GetSelectQueryDenyReasons() {
			var select = new Select(_userConnection)
					.Column("Id").As("Id")
					.Column("Code").As("Code")
				.From(MULTI_DELETE_DENY_REASON);
			return select;
		}

		protected virtual KeyValuePair<string, Guid> GetDenyReason(IDataReader reader) {
			var result = new KeyValuePair<string, Guid>();
			if (!reader.IsDBNull(reader.GetOrdinal("Id"))) {
				var id = reader.GetColumnValue<Guid>("Id");
				var code = reader.GetColumnValue<string>("Code");
				result = new KeyValuePair<string, Guid>(code, id);
			}
			return result;
		}

		protected virtual int InsertMultiDeleteQueue(IEnumerable<Guid> recordIds) {
			var select = GetSelectQueryFromEntityWithCondition(recordIds);
			var insert = new InsertSelect(_userConnection)
				.Into(MULTI_DELETE_QUEUE)
				.Set("EntitySchemaUId", "RecordId", "SysAdminUnitId", "OperationKey", "State", "IsRoot")
				.FromSelect(select);
			return insert.Execute();
		}

		protected virtual int InsertMultiDeleteQueue(IEnumerable<Guid> recordIds, Guid entitySchemaUId) {
			var sysAdminUnitId = _userConnection.CurrentUser.Id;
			var insertCount = 0;
			foreach (Guid recordId in recordIds) {
				var insert = new Insert(_userConnection).Into(MULTI_DELETE_QUEUE)
				.Set("SysAdminUnitId", Column.Parameter(sysAdminUnitId))
				.Set("RecordId", Column.Parameter(recordId))
				.Set("OperationKey", Column.Parameter(OperationKey))
				.Set("State", Column.Parameter(OperationState.Wait))
				.Set("EntitySchemaUId", Column.Parameter(entitySchemaUId));
				insertCount += insert.Execute();
			}
			return insertCount;
		}

		protected virtual Select GetSelectQueryRecordIdsWithState(OperationState state = OperationState.Wait,
				Guid operationKey = new Guid()) {
			if (operationKey == Guid.Empty) {
				operationKey = OperationKey;
			}
			Select select = new Select(_userConnection).Top(NumberItemsReturned)
				.Column("RecordId")
				.From(MULTI_DELETE_QUEUE)
				.Where("State").IsEqual(Column.Parameter(state))
					.And("OperationKey").IsEqual(Column.Parameter(operationKey))
					.And("EntitySchemaUId").IsEqual(Column.Parameter(EntitySchemaUId)) as Select;
			if (state == OperationState.Wait) {
				select = select.And("IsRoot").IsEqual(Column.Parameter(IsRoot)) as Select;
			}
			return select.OrderByAsc("CreatedOn") as Select;
		}

		protected virtual Guid GetRecordId(IDataReader reader) {
			Guid result = Guid.Empty;
			if (!reader.IsDBNull(reader.GetOrdinal("RecordId"))) {
				result = reader.GetColumnValue<Guid>("RecordId");
			}
			return result;
		}

		protected virtual void ClearMultiDeleteQueue() {
			var currentDate = DateTime.UtcNow;
			var recordInQueueLifetime = currentDate.AddDays(-RECORD_IN_QUEUE_LIFETIME);
			var errorRecordLifetime = currentDate.AddDays(-ERROR_RECORD_LIFETIME);
			var delete = new Delete(_userConnection)
				.From(MULTI_DELETE_QUEUE)
				.Where()
					.OpenBlock()
						.OpenBlock("CreatedOn").IsLess(Column.Parameter(recordInQueueLifetime))
							.And("State").IsNotEqual(Column.Parameter(OperationState.Error))
						.CloseBlock()
						.Or()
						.OpenBlock("CreatedOn").IsLess(Column.Parameter(errorRecordLifetime))
							.And("State").IsEqual(Column.Parameter(OperationState.Error))
						.CloseBlock()
					.CloseBlock();
			int deleteCount = delete.Execute();
			Log.InfoFormat("Deletes '{0}' records from queue.", deleteCount);
		}

		#endregion

		#region IOperationAgent Members

		public virtual bool MoreAvaliable {
			get { return _queueCount != _returnedCount; }
		}

		public virtual IEnumerable<Guid> GetNextItems() {
			lock (_operationLock) {
				var select = GetSelectQueryRecordIds();
				IEnumerable<Guid> recordIds = SelectExecutor(select, GetRecordId);
				if (recordIds == null || !recordIds.Any()) {
					_returnedCount = _queueCount;
					return null;
				}
				var update = GetUpdateQueryRecordsState(recordIds, OperationState.Progress);
				try {
					update.Execute();
				} catch (Exception ex) {
					Log.Error(ex.Message, ex);
					throw;
				}
				_returnedCount += recordIds.Count();
				return recordIds;
			}
		}

		public virtual void UpdateRecordInfo(Guid recordId, Exception exception) {
			var state = exception == null ? OperationState.Done : OperationState.Error;
			Update update = GetUpdateQueryRecordsState(recordId, state);
			if (state == OperationState.Error) {
				Guid denyReasonId = GetDenyReasonId(exception);
				update.Set("Message", Column.Parameter(exception.Message));
				update.Set("DenyReasonId", Column.Parameter(denyReasonId));
			}
			try {
				update.Execute();
			} catch (Exception ex) {
				Log.Error(ex.Message, ex);
				throw;
			}
		}

		public virtual void Enqueue(IEnumerable<Guid> recordIds) {
			ClearMultiDeleteQueue();
			lock (_operationLock) {
				var iteration = 0;
				int queueCount;
				do {
					IEnumerable<Guid> collection = Paging(recordIds, iteration++);
					if (collection == null || !collection.Any()) {
						return;
					}
					try {
						queueCount = InsertMultiDeleteQueue(collection);
					} catch (Exception ex) {
						Log.Error(ex.Message, ex);
						throw;
					}
					_queueCount += queueCount;
					Log.InfoFormat("Sets '{0}' records to queue.", queueCount);
				} while (queueCount > 0);
			}
		}

		public virtual void HandleRecordProcessed(object sender, RecordProcessedEventArgs args) {
			UpdateRecordInfo(args.RecordId, args.Exception);
		}

		#endregion
	}

	#endregion
}


