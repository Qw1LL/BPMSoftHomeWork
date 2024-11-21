namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.DB;
	using Core.Entities;
	using BPMSoft.Core.Factories;

	#region  Class: ImportEntitiesDataProvider

	[DefaultBinding(typeof(IImportEntitiesDataProvider), Name = nameof(ImportEntitiesDataProvider))]
	public class ImportEntitiesDataProvider: IImportEntitiesDataProvider
	{
		#region Constants: Private

		private const int MaxParametersCountPerQueryChunk = 1900;
		private const int MaxRowForInsertPerQueryChunk = 1000;

		private const string _bufferedImportEntitySchemaName = "BufferedImportEntity";

		#endregion

		#region  Fields: Private

		private ImportLogger _logger;
		private EntitySchema _schema;
		private IColumnsAggregatorFactory _columnsAggregatorFactory;
		private IColumnsAggregatorAdapter _columnsProcessor;
		private readonly string _importExcelRowIndex = "ImportExcelRowIndex";

		#endregion

		#region Constructors: Public

		public ImportEntitiesDataProvider(UserConnection userConnection) {
			UserConnection = userConnection;
			InitializeLogger();
		}

		public ImportEntitiesDataProvider(UserConnection userConnection, IColumnsAggregatorAdapter columnsProcessor) : this(
				userConnection) {
			_columnsProcessor = columnsProcessor;
			InitializeLogger();
		}

		#endregion

		#region Properties: Private

		private IColumnsAggregatorAdapter ColumnsProcessor => _columnsProcessor ??
				(_columnsProcessor = ColumnsAggregatorFactory?.GetColumnsAggregator(UserConnection));

		private IColumnsAggregatorFactory ColumnsAggregatorFactory => _columnsAggregatorFactory ??
				(_columnsAggregatorFactory = ClassFactory.Get<IColumnsAggregatorFactory>());

		private ImportLogger Logger => _logger ?? (_logger = new ImportLogger(UserConnection));

		private UserConnection UserConnection { get; }

		#endregion

		#region Methods: Private

		private Delete GetBufferedImportEntityDeleteQuery(object importSessionId = null) {
			var delete = new Delete(UserConnection)
				.From(_bufferedImportEntitySchemaName);
			if (importSessionId != null) {
				delete.Where("ImportSessionId").IsEqual(Column.Parameter(importSessionId));
			}
			return delete;
		}

		private Insert GetBufferedImportEntityInsertQuery() {
			var bufferedImportEntity = new Insert(UserConnection).Into(_bufferedImportEntitySchemaName);
			return bufferedImportEntity;
		}

		private IEnumerable<IEnumerable<ImportEntity>> GetImportEntitiesChunks(IEnumerable<ImportEntity> entities,
				IEnumerable<ImportColumn> keyColumns) {
			var entitiesList = entities.ToList();
			var columnsList = keyColumns.ToList();
			var maxParamsPerChunk = Math.Abs(MaxParametersCountPerQueryChunk / (columnsList.Count + 2));
			maxParamsPerChunk = Math.Min(MaxRowForInsertPerQueryChunk, maxParamsPerChunk);
			var chunksCount = (int)Math.Ceiling(entitiesList.Count / (double)maxParamsPerChunk);
			return entitiesList.SplitOnParts(chunksCount);
		}

		private List<Guid> GetPersistedImportSessionIds() {
			var sessionIds = new List<Guid>();
			var select = new Select(UserConnection).Distinct()
				.Column("ImportSessionId")
				.From(_bufferedImportEntitySchemaName);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						sessionIds.Add(dataReader.GetColumnValue<Guid>("ImportSessionId"));
					}
				}
			}
			return sessionIds;
		}

		private void InitializeLogger() {
			BufferedImportEntitySaveDBError += Logger.HandleErrorMessage;
		}

		private void InnerSaveImportEntitiesToDB(IEnumerable<ImportEntity> entities,
				IEnumerable<ImportColumn> keyColumns,
				Guid importSessionId) {
			var importColumns = keyColumns.ToList();
			if (importColumns.IsEmpty()) {
				return;
			}
			var entitiesList = GetImportEntitiesChunks(entities, importColumns);
			foreach (var entitiesBatch in entitiesList) {
				InsertBatchToDb(importSessionId, importColumns, entitiesBatch);
			}
		}

		private void InsertBatchToDb(Guid importSessionId, List<ImportColumn> importColumns, IEnumerable<ImportEntity> entitiesBatch) {
			try {
				var insertQuery = GetBufferedImportEntityInsertQuery();
				foreach (var importEntity in entitiesBatch) {
					insertQuery.Values();
					SetBufferedImportEntityInsertColumnValues(importEntity, insertQuery,
							importColumns);
					insertQuery.Set("ImportSessionId", Column.Parameter(importSessionId));
					insertQuery.Set(_importExcelRowIndex, Column.Parameter((int)importEntity.RowIndex));
				}
				insertQuery.Execute();
			} catch (Exception e) {
				OnBufferedImportEntitySaveDBError(new ErrorMessageEventArgs {
					ImportSessionId = importSessionId,
					Exception = e,
					Message = e.Message
				});
			}
		}

		private void SetBufferedImportEntityInsertColumnValues(ImportEntity importEntity, Insert insertQuery,
				IEnumerable<ImportColumn> keyColumns) {
			var schemaColumns = _schema.Columns;
			foreach (var c in keyColumns.Select((c, i) => (Column: c, Index: i + 1))) {
				var column = c.Column;
				var index = c.Index;
				var columnName = $"Column{index}";
				var destination = column.Destinations.FirstOrDefault();
				if (destination == null) {
					throw new ArgumentNullOrEmptyException(nameof(destination));
				}
				var dataValueType = schemaColumns.GetByName(destination.ColumnName).DataValueType;
				var columnValue = importEntity.FindColumnValue(column);
				var valueForSave = columnValue == null 
						? dataValueType.DefValue
						: ColumnsProcessor.FindValueForSave(destination, columnValue);
				insertQuery.Set(columnName, Column.Parameter(valueForSave, dataValueType));
			}
		}

		#endregion

		#region Methods: Protected

		protected void OnBufferedImportEntitySaveDBError(ErrorMessageEventArgs eventArgs) {
			BufferedImportEntitySaveDBError?.Invoke(this, eventArgs);
		}

		protected virtual bool SaveImportEntitiesToDB(IEnumerable<ImportEntity> entities,
				IEnumerable<ImportColumn> keyColumns,
				Guid importSessionId) {
			var success = true;
			Logger.FileName = importSessionId.ToString();
			try {
				var importEntities = entities.ToList();
				CleanBufferedImportEntities(importSessionId);
				InnerSaveImportEntitiesToDB(importEntities, keyColumns, importSessionId);
			} catch (Exception e) {
				success = false;
				OnBufferedImportEntitySaveDBError(new ErrorMessageEventArgs {
						ImportSessionId = importSessionId,
						Exception = e,
						Message = e.Message
				});
			}
			Logger.SaveLog();
			return success;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Clears data from BufferedImportEntity table by provided <paramref name="importSessionId" />
		/// </summary>
		/// <param name="importSessionId"></param>
		public void CleanBufferedImportEntities(Guid importSessionId) {
			Logger.FileName = importSessionId.ToString();
			try {
				var delete = GetBufferedImportEntityDeleteQuery(importSessionId);
				delete.Execute();
			} catch (Exception e) {
				OnBufferedImportEntitySaveDBError(new ErrorMessageEventArgs {
						ImportSessionId = importSessionId,
						Exception = e,
						Message = e.Message
				});
			}
			Logger.SaveLog();
		}

		public void CleanOldImportEntitiesRawData(Func<Guid, ImportParameters> findImportParametersFunc) {
			try {
				var savedSessionIds = GetPersistedImportSessionIds();
				var notActualIds = savedSessionIds.Where(id => findImportParametersFunc(id) == null)
					.Select(i => Column.Parameter(i));
				var queryColumnExpressions = notActualIds.ToList();
				if (queryColumnExpressions.Count > 0) {
					var delete = GetBufferedImportEntityDeleteQuery();
					delete.Where("ImportSessionId").In(queryColumnExpressions);
					delete.Execute();
				}
			} catch (Exception e) {
				OnBufferedImportEntitySaveDBError(new ErrorMessageEventArgs {
						ImportSessionId = Guid.Empty,
						Exception = e,
						Message = e.Message
				});
				throw;
			}
			Logger.SaveLog();
		}

		public bool SaveImportEntitiesToDB(ImportParameters parameters, IEnumerable<ImportColumn> keyColumns) {
			_schema = UserConnection.EntitySchemaManager.GetInstanceByUId(parameters.RootSchemaUId);
			return SaveImportEntitiesToDB(parameters.Entities, keyColumns, parameters.ImportSessionId);
		}

		/// <summary>
		/// Check available key columns count.
		/// </summary>
		/// <param name="keyColumnsCount">Key columns count.</param>
		/// <returns>Result validate.</returns>
		public bool ValidateKeyColumnsCount(int keyColumnsCount) {
			var bufferedImportEntitySchema =
					UserConnection.EntitySchemaManager.GetInstanceByName(_bufferedImportEntitySchemaName);
			var columns = bufferedImportEntitySchema.Columns;
			var lastKeyColumn = columns.Any(c => c.Name == $"Column{keyColumnsCount}");
			return lastKeyColumn;
		}

		#endregion

		public event EventHandler<ErrorMessageEventArgs> BufferedImportEntitySaveDBError;
	}

	#endregion
}

