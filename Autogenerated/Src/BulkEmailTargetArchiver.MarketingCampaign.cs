namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: BulkEmailTargetArchiver

	public class BulkEmailTargetArchiver
	{

		#region Fields: Private

		private readonly DBExecutor _dbExecutor;
		private readonly UserConnection _userConnection;
		private readonly int _batchSize = 5000;

		#endregion

		#region Constructors: Public

		public BulkEmailTargetArchiver(DBExecutor dbExecutor) {
			_dbExecutor = dbExecutor;
			_userConnection = _dbExecutor.UserConnection;
		}

		#endregion

		#region Methods: Private

		private Select GetBulkEmailTargetArchivingQuery(string sourceSchemaName, string targetSchemaName,
			DateTime archivePeriod, List<string> columnList) {
			var selectQuery = new Select(_userConnection);
			foreach (string column in columnList) {
				selectQuery.Column("s", column);
			}
			selectQuery.Top(_batchSize);
			selectQuery.From(sourceSchemaName).As("s").WithHints(Hints.NoLock)
				.Where("s", "ModifiedOn").IsLessOrEqual(new QueryParameter(archivePeriod))
				.And().Not().Exists(new Select(_userConnection)
				.Column(Column.Parameter(1))
				.From(targetSchemaName).As("t")
				.Where("t", "Id")
				.IsEqual("s", "Id"));
			return selectQuery;
		}

		private List<string> GetSchemaColumnsNames(string schemaName) {
			EntitySchemaManager manager = _userConnection.EntitySchemaManager;
			var schema = manager.GetInstanceByName(schemaName);
			var columnList = schema.Columns.Select(col => col.ColumnValueName).ToList();
			return columnList;
		}

		private void DeleteArchiveLevel(string sourceSchemaName, string targetSchemaName) {
			int processedRecords;
			do {
				var deleteQuery = new Delete(_userConnection).From(sourceSchemaName)
					.Where("Id").In(new Select(_userConnection)
						.Top(_batchSize)
						.Column("s", "Id")
						.From(sourceSchemaName).As("s")
						.Where().Exists(new Select(_userConnection)
							.Column(Column.Parameter(1))
							.From(targetSchemaName)
							.Where(targetSchemaName, "Id")
							.IsEqual("s", "Id")));
				processedRecords = deleteQuery.Execute(_dbExecutor);
			} while (processedRecords != 0);
		}

		private int InsertArchiveLevel(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod) {
			var columnList = GetSchemaColumnsNames(targetSchemaName);
			var oldBulkEmailTargetSelect =
				GetBulkEmailTargetArchivingQuery(sourceSchemaName, targetSchemaName, archivePeriod, columnList);
			var insertSelectCommand = new InsertSelect(_userConnection)
				.Into(targetSchemaName).Set(columnList).FromSelect(oldBulkEmailTargetSelect);
			return insertSelectCommand.Execute(_dbExecutor);
		}

		#endregion

		#region Methods: Public

		public int Archive(string sourceSchemaName, string targetSchemaName, DateTime archivePeriod) {
			var insertedCount = InsertArchiveLevel(sourceSchemaName, targetSchemaName, archivePeriod);
			DeleteArchiveLevel(sourceSchemaName, targetSchemaName);
			return insertedCount;
		}

		#endregion

	}

	#endregion

}

