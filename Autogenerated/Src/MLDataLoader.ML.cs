namespace BPMSoft.Configuration.ML
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Common;
	using Common.Json;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Core.Factories;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using Nui.ServiceModel.Extensions;

	#region Interface: IMLDataLoader

	/// <summary>
	/// Loads data for machine learning.
	/// </summary>
	public interface IMLDataLoader
	{

		/// <summary>
		/// Loads the data by chunks, executing given handler on each.
		/// </summary>
		/// <param name="select">The <see cref="Select"/> query for loading data.</param>
		/// <param name="onChunkLoaded">Action that executes on each serialized data chunk loaded from the database.
		/// </param>
		/// <returns>Number of loaded rows.</returns>
		int LoadData(Select select, Action<string, int> onChunkLoaded);

		/// <summary>
		/// Loads the data for prediction.
		/// </summary>
		/// <param name="select">The <see cref="Select"/> query for loading data.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <returns>Dictionary, where the key is the field name, the value is the field's value.</returns>
		Dictionary<string, object> LoadDataForPrediction(Select select, Guid entityId);

		/// <summary>
		/// Loads the data for prediction by chunks, executing given handler on each.
		/// </summary>
		/// <param name="select">The <see cref="Select"/> query for loading data.</param>
		/// <param name="onChunkLoaded">Action that executes on each data chunk loaded from the database.
		/// </param>
		void LoadDataForPrediction(Select select, Action<IList<Dictionary<string, object>>> onChunkLoaded);
	}

	#endregion

	#region Class: MLDataLoaderConfig

	/// <summary>
	/// Configuration parameters for ML data loader.
	/// </summary>
	public class MLDataLoaderConfig
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the size of the upload data chunk.
		/// </summary>
		/// <value>
		/// The size of the chunk. Default value is 1000 records.
		/// </value>
		public int ChunkSize { get; set; } = 1000;

		/// <summary>
		/// Gets or sets the minimum records count.
		/// </summary>
		/// <value>
		/// The minimum records count.
		/// </value>
		public int MinRecordsCount { get; set; } = 1;

		/// <summary>
		/// Gets or sets the maximum records count, allowed to upload.
		/// </summary>
		/// <value>
		/// The maximum records count. Default value is 75k.
		/// </value>
		public int MaxRecordsCount { get; set; } = 75000;

		#endregion

	}

	#endregion

	#region Class: MLDataLoader

	/// <summary>
	/// Provides a base class for implementations of the <see cref="IMLDataLoader"/> interface.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ML.IMLDataLoader" />
	[DefaultBinding(typeof(IMLDataLoader))]
	public class MLDataLoader : IMLDataLoader
	{

		#region Constants: Private

		private const string PrimaryQueryColumnName = "Id";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly MLDataLoaderConfig _config = new MLDataLoaderConfig();
		private readonly MLModelEventsNotifier _modelEventsNotifier;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="MLDataLoader"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public MLDataLoader(UserConnection userConnection) {
			_userConnection = userConnection;
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", _userConnection);
			_modelEventsNotifier = ClassFactory.Get<MLModelEventsNotifier>(userConnectionArg);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MLDataLoader"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="config">Configuration of data loading process.</param>
		public MLDataLoader(UserConnection userConnection, MLDataLoaderConfig config) {
			_userConnection = userConnection;
			_config = config;
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", _userConnection);
			_modelEventsNotifier = ClassFactory.Get<MLModelEventsNotifier>(userConnectionArg);
		}

		#endregion

		#region Properties: Private

		private IQueryInterpreter _queryInterpreter;
		private IQueryInterpreter QueryInterpreter =>
			_queryInterpreter ?? (_queryInterpreter = ClassFactory.Get<IQueryInterpreter>());

		#endregion

		#region Methods: Private

		private static void AddOrderByItemsConditions(Select select, PageableSelectOptions options, DataRow lastRow) {
			options.OrderByItemsConditions.Clear();
			foreach (OrderByItem orderByItem in select.OrderByItems) {
				string queryColumnAlias = orderByItem.Expression.SourceColumnAlias;
				QueryColumnExpression column = GetColumnByName(select, queryColumnAlias);
				column.Alias = queryColumnAlias;
				object value = lastRow[queryColumnAlias];
				QueryParameter orderByParameter = new QueryParameter(queryColumnAlias, value);
				options.AddCondition(column, orderByItem, orderByParameter);
			}
		}

		private static QueryColumnExpression FindColumnByName(Select select, string queryColumnAlias) {
			QueryColumnExpressionCollection columns = select.Columns;
			QueryColumnExpression column = columns.FindByAlias(queryColumnAlias) ?? columns.Find(
				expression => expression.SourceColumnAlias == queryColumnAlias && expression.Alias.IsNullOrEmpty());
			return column;
		}

		private static QueryColumnExpression GetColumnByName(Select select, string queryColumnAlias) {
			QueryColumnExpression column = FindColumnByName(select, queryColumnAlias);
			if (column == null) {
				string message = $"Select expression does not contain column with alias '{queryColumnAlias}'. It must "
					+ "present as it is used in ORDER BY clause.";
				throw new InvalidTrainSetQueryException(message);
			}
			return column;
		}

		private static void ReplaceFiltersWithPrimaryFieldCondition(Select select, Guid entityId,
				QueryColumnExpression idExpression) {
			select.Condition.Clear();
			select.Top(1).Where(idExpression.SourceAlias, idExpression.SourceColumnAlias)
				.IsEqual(Column.Parameter(entityId));
		}

		private void ReplaceInnerWithLeftJoins(Select select) {
			select.Joins.Where(join => join.JoinType == JoinType.Inner)
				.ForEach(join => join.JoinType = JoinType.LeftOuter);
		}

		private Select InterpreteSelectQuery(string expression, Dictionary<string, object> parameters = null) {
			if (parameters == null) {
				parameters = new Dictionary<string, object>();
			}
			parameters.Add("userConnection", _userConnection);
			return QueryInterpreter.InterpreteSelectQuery(expression, parameters);
		}

		private QueryColumnExpression GetSelectIdColumnExpression(Select select, string selectExpression = null) {
			QueryColumnExpression idExpression = FindColumnByName(select, PrimaryQueryColumnName);
			if (idExpression == null) {
				string message = "Select expression doesn't contain {0} column. Expression: {1}";
				throw new InvalidTrainSetQueryException(string.Format(message, PrimaryQueryColumnName,
					selectExpression ?? select.GetSqlText()));
			}
			idExpression.Alias = PrimaryQueryColumnName;
			return idExpression;
		}

		private Select CreateIdsSelect(string serializedFilters, Guid rootObjectUId) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			var jsonFilters
				= Json.Deserialize<Nui.ServiceModel.DataContract.Filters>(serializedFilters);
			EntitySchema objectSchema = entitySchemaManager.GetInstanceByUId(rootObjectUId);
			IEntitySchemaQueryFilterItem esqFilters
				= jsonFilters.BuildEsqFilter(objectSchema.UId, _userConnection);
			var objectEsq = new EntitySchemaQuery(entitySchemaManager, objectSchema.Name) {
				UseAdminRights = false
			};
			objectEsq.PrimaryQueryColumn.IsVisible = true;
			objectEsq.Filters.Add(esqFilters);
			Select idsSelectQuery = objectEsq.GetSelectQuery(_userConnection);
			return idsSelectQuery;
		}

		private void AddIdsFilters(Select select, Guid rootObjectUId, string filterData,
				QueryColumnExpression idExpression) {
			select.Condition.Clear();
			var subSelect = CreateIdsSelect(filterData, rootObjectUId);
			select.Top(1).Where(idExpression.SourceAlias, idExpression.SourceColumnAlias)
				.IsEqual(Column.SubSelect(subSelect));
		}

		private int LoadData(Select select, Action<DataTable> onChunkLoaded, string selectExpression = null) {
			select.CheckArgumentNull("selectQuery");
			onChunkLoaded.CheckArgumentNull("onChunkLoaded");
			int chunkSize = _config.ChunkSize;
			int maxRecordsCount = _config.MaxRecordsCount;
			int minRecordsCount = _config.MinRecordsCount;
			QueryColumnExpression idExpression = GetSelectIdColumnExpression(select, selectExpression);
			var lastValueParameter = new QueryParameter("IdLastValue", null);
			var pageableSelectCondition = new PageableSelectCondition {
				LastValueParameter = lastValueParameter,
				LeftExpression = idExpression,
				OrderByItem = new OrderByItem(idExpression, OrderDirectionStrict.Ascending)
			};
			var options = new PageableSelectOptions(pageableSelectCondition, chunkSize, PageableSelectDirection.First);
			Select pageableSelect = select.ToPageable(options);
			bool hasRecords = true;
			int totalRecordsCount = 0;
			bool useMaxRecordsLimit = maxRecordsCount > 0;
			var lastRecordIds = new HashSet<string>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection(QueryKind.Limited)) {
				while (hasRecords && (!useMaxRecordsLimit || totalRecordsCount < maxRecordsCount)) {
					hasRecords = false;
					using (IDataReader dr = pageableSelect.ExecuteReader(dbExecutor)) {
						var dataTable = new DataTable();
						dataTable.Load(dr);
						int recordsCount = dataTable.Rows.Count;
						totalRecordsCount += recordsCount;
						if (totalRecordsCount < minRecordsCount && recordsCount < chunkSize) {
							throw new NotEnoughDataForTrainingException(
								$"There's not enough data for upload. Minimal number: {minRecordsCount}," +
								$" Current: {totalRecordsCount}");
						}
						if (recordsCount == 0) {
							continue;
						}
						hasRecords = true;
						DataRow lastRow = dataTable.Rows[recordsCount - 1];
						string rowId = lastRow["Id"]?.ToString();
						if (string.IsNullOrEmpty(rowId)) {
							throw new Exception("Rowset can't contain a record with empty Id");
						}
						if (lastRecordIds.Contains(rowId)) {
							throw new InvalidOperationException($"Record with id {rowId} is uploading more than once " +
								$"which would cause infinite loop. Send this information to Support Team:\n " +
								$"{string.Join(",", lastRecordIds)}");
						}
						lastRecordIds.Add(rowId);
						onChunkLoaded(dataTable);
						lastValueParameter.Value = new Guid(rowId);
						options.Direction = PageableSelectDirection.Next;
						AddOrderByItemsConditions(select, options, lastRow);
						pageableSelect = select.ToPageable(options);
					}
				}
			}
			return totalRecordsCount;
		}

		private IList<Dictionary<string, object>> LoadData(Select select) {
			var loadedData = new List<Dictionary<string, object>>();
			ReplaceInnerWithLeftJoins(select);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection(QueryKind.Limited)) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var item = new Dictionary<string, object>();
						for (var i = 0; i < reader.FieldCount; i++) {
							string fieldName = reader.GetName(i);
							item[fieldName] = reader.GetColumnValue(fieldName);
						}
						loadedData.Add(item);
					}
				}
			}
			return loadedData;
		}

		private void OnTrainingChunkLoaded(DataTable dataTable, Action<string, int> onChunkLoaded) {
			string jsonString = JsonConvert.SerializeObject(dataTable, new IsoDateTimeConverter());
			onChunkLoaded(jsonString, dataTable.Rows.Count);
		}

		private void OnPredictionChunkLoaded(DataTable dataTable,
				Action<IList<Dictionary<string, object>>> onChunkLoaded) {
			IEnumerable<DataColumn> columns = dataTable.Columns.Cast<DataColumn>();
			var list = dataTable.AsEnumerable().Select(
					dataRow => columns
						.Where(column => !(dataRow[column] is DBNull))
						.Select(column => new {
							Column = column.ColumnName, Value = dataRow[column]
						}).ToDictionary(data => data.Column, data => data.Value))
				.ToList();
			onChunkLoaded(list);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads the data by chunks, executing given handler on each.
		/// </summary>
		/// <param name="select">The <see cref="Select" /> query for loading data.</param>
		/// <param name="onChunkLoaded">Action that executes on each serialized data chunk loaded from the database.
		/// </param>
		/// <returns>
		/// Number of loaded rows.
		/// </returns>
		public virtual int LoadData(Select select, Action<string, int> onChunkLoaded) {
			select.CheckArgumentNull(nameof(select));
			onChunkLoaded.CheckArgumentNull("onChunkLoaded");
			return LoadData(select, dataTable => OnTrainingChunkLoaded(dataTable, onChunkLoaded));
		}

		/// <summary>
		/// Loads the data for prediction.
		/// </summary>
		/// <param name="select">The <see cref="Select" /> query for loading data.</param>
		/// <param name="entityId">The entity identifier.</param>
		/// <returns>
		/// Dictionary, where the key is the field name, the value is the field's value.
		/// </returns>
		public Dictionary<string, object> LoadDataForPrediction(Select select, Guid entityId) {
			var idExpression = GetSelectIdColumnExpression(select);
			ReplaceFiltersWithPrimaryFieldCondition(select, entityId, idExpression);
			return LoadData(select).First();
		}

		/// <summary>
		/// Loads the data for prediction by chunks, executing given handler on each.
		/// </summary>
		/// <param name="select">The <see cref="Select" /> query for loading data.</param>
		/// <param name="onChunkLoaded">Action that executes on each data chunk loaded from the database.</param>
		public void LoadDataForPrediction(Select select, Action<IList<Dictionary<string, object>>> onChunkLoaded) {
			LoadData(select, dataTable => OnPredictionChunkLoaded(dataTable, onChunkLoaded));
		}

		#endregion

	}

	#endregion

}

