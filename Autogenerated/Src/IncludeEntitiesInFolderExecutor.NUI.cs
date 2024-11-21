namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: FolderActionParameters

	public class FolderActionParameters {

		#region Properties: Public
		public string EntitySchemaName { get; set; }
		public string EntityColumnNameInFolderEntity { get; set; }
		public Guid FolderId { get; set; }

		#endregion
	}

	#endregion

	#region Class: IncludeEntitiesInFolderExecutor

	/// <inhetitdoc cref="IIncludeEntitiesInFolderExecutor"/>
	[DefaultBinding(typeof(IIncludeEntitiesInFolderExecutor), Name = nameof(IncludeEntitiesInFolderExecutor))]
	public class IncludeEntitiesInFolderExecutor : IIncludeEntitiesInFolderExecutor {

		#region Constants: Private

		private const int MaxParametersCountPerQueryChunk = 1000;
		private const string FolderColumnName = "FolderId";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly FolderActionParameters _parameters;
		private string _entityColumnNameInDb;

		#endregion

		#region Properties: Private

		private QueryColumnExpression FolderQueryParameter => Column.Parameter(_parameters.FolderId);
		private string EntityColumnNameInDb {
			get {
				if (_entityColumnNameInDb == null) {
					var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName(_parameters.EntitySchemaName);
					_entityColumnNameInDb = entitySchema?.Columns.First(column => column.Name == _parameters.EntityColumnNameInFolderEntity).ColumnValueName;
				}
				return _entityColumnNameInDb;
			}
		}

		#endregion

		#region Constructors: Public

		public IncludeEntitiesInFolderExecutor(UserConnection userConnection, FolderActionParameters parameters) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			parameters.CheckArgumentNull(nameof(parameters));
			_userConnection = userConnection;
			_parameters = parameters;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<IEnumerable<Guid>> GetRecordChunks(IEnumerable<Guid> records) {
			var recordsCount = records.Count();
			var chunksCount = (int)Math.Ceiling(recordsCount / (double)MaxParametersCountPerQueryChunk);
			return records.SplitOnParts(chunksCount);
		}

		private int InsertRecordChunksToDb(IEnumerable<Guid> newRecords) {
			var affectedRows = 0;
			var recordChunks = GetRecordChunks(newRecords);
			recordChunks.ForEach(chunk => affectedRows += InsertChunkToDb(chunk));
			return affectedRows;
		}

		private int InsertChunkToDb(IEnumerable<Guid> chunk) {

			var insertQuery = new Insert(_userConnection).Into(_parameters.EntitySchemaName);
			foreach (var record in chunk) {
				insertQuery.Values();
				insertQuery.Set(EntityColumnNameInDb, Column.Parameter(record));
				insertQuery.Set(FolderColumnName, FolderQueryParameter);
			}

			return insertQuery.Execute();
		}

		private HashSet<Guid> GetRecordsExistsInFolder() {
			var columnName = EntityColumnNameInDb;
			var selectQuery = new Select(_userConnection)
				.Distinct()
				.Column(columnName)
				.From(_parameters.EntitySchemaName)
				.Where(FolderColumnName).IsEqual(FolderQueryParameter) as Select;
			return selectQuery.ExecuteEnumerable(x => x.GetColumnValue<Guid>(columnName)).ToHashSet();
		}

		private IEnumerable<Guid> ExcludeExistsRecords(HashSet<Guid> recordsToAdd) {
			var existsRecords = GetRecordsExistsInFolder();
			recordsToAdd.RemoveRange(existsRecords);
			return recordsToAdd;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref= "IIncludeEntitiesInFolderExecutor"/>
		public int Execute(string[] primaryColumnValues) {
			primaryColumnValues.CheckArgumentNull(nameof(primaryColumnValues));
			var recordsToProcess = primaryColumnValues.Select(recordId => Guid.Parse(recordId)).ToHashSet();
			recordsToProcess.CheckArgumentNull(nameof(recordsToProcess));
			var newRecords = ExcludeExistsRecords(recordsToProcess);
			if (!newRecords.Any()) {
				return 0;
			}
			return InsertRecordChunksToDb(newRecords);
		}

		#endregion
	}

	#endregion

}

