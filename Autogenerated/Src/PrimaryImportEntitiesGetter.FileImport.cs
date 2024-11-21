namespace BPMSoft.Configuration.FileImport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.Entities;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region  Class: PrimaryImportEntitiesGetter

	/// <summary>
	/// An instance of this class is responsible for getting primary import entities.
	/// </summary>
	[DefaultBinding(typeof(IPrimaryImportEntitiesGetter), Name = nameof(PrimaryImportEntitiesGetter))]
	public class PrimaryImportEntitiesGetter : ImportEntitiesGetter, IPrimaryImportEntitiesGetter
	{
		#region Constants: Private

		private const string _bufferSchemaName = "BufferedImportEntity";
		private const string _bufImportSessionIdColName = "ImportSessionId";
		private const string _typeUIdPropertyName = "TypeUId";
		private const string _bufImportExcelRowIndexName = "ImportExcelRowIndex";

		#endregion

		#region Properties: Private

		private IImportEntitiesDataProvider _importEntitiesDataProvider;

		private IImportEntitiesDataProvider ImportEntitiesDataProvider => _importEntitiesDataProvider ??
			(_importEntitiesDataProvider = ClassFactory.Get<IImportEntitiesDataProvider>(
					new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("columnsProcessor", ColumnsProcessor)));

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates instance of type <see cref="PrimaryImportEntitiesGetter" />.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="columnsProcessor">Columns processor.</param>
		public PrimaryImportEntitiesGetter(UserConnection userConnection, IColumnsAggregatorAdapter columnsProcessor)
				: base(userConnection, columnsProcessor) { }

		#endregion

		#region Properties: Protected

		protected virtual int QueryChunkSize => (int)Math.Ceiling(MaxEntityRowCount / 3.0);

		#endregion

		#region Methods: Private

		/// <summary>
		/// Adds entities collection to list.
		/// </summary>
		/// <param name="esq">Entity schema query.</param>
		/// <param name="entities">List of entities.</param>
		private void AddEntitiesRange(EntitySchemaQuery esq, List<Entity> entities) {
			var entityCollection = esq.GetEntityCollection(UserConnection);
			entities.AddRange(entityCollection);
		}

		private void FindExistedImportEntities(EntitySchemaQuery esq, ImportParameters parameters,
				IEnumerable<ImportColumn> keyColumns, List<Entity> entities) {
			var rootSchema = esq.RootSchema;
			var expressions = GetKeyColumnsExpressions(rootSchema, keyColumns);
			if (UserConnection.GetIsFeatureEnabled("UseExplicitCastInDuplicatesSearchOnDataImport")) {
				entities.AddRange(LoadEntityCollection(parameters, rootSchema, expressions));
				return;
			}
			AddEntitiesSearchQueryColumns(esq, expressions);
			AddEntitiesSearchQueryFilters(esq, expressions, parameters.ImportSessionId);
			AddEntitiesRange(esq, entities);
		}

		private EntityCollection LoadEntityCollection(ImportParameters parameters, EntitySchema rootSchema, IEnumerable<ColumnExpression> expressions) {
			var entityCollection = new EntityCollection(UserConnection, rootSchema);
			var query = rootSchema.CreateSelect(UserConnection, rootSchema.Columns, true, out var columnMapping);
			AddJoinToBufferedTable(query, expressions, columnMapping);
			AddSessionIdCondition(parameters.ImportSessionId, query);
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var dataReader = query.ExecuteReader(dbExecutor)) {
					entityCollection.Load(dataReader, columnMapping);
				}
			}
			return entityCollection;
		}

		private static void AddSessionIdCondition(Guid importSessionId, Select select) {
			if (select.HasCondition) {
				select.And(_bufferSchemaName, "ImportSessionId")
								.IsEqual(Column.Parameter(importSessionId));
			} else {
				select.Where(_bufferSchemaName, "ImportSessionId")
								.IsEqual(Column.Parameter(importSessionId));
			}
		}

		private void AddJoinToBufferedTable(Select select, IEnumerable<ColumnExpression> keyColumnExpressions,
			EntitySchemaColumnMap columnMapping) {

			var rowIndexColumnName = "ImportExcelRowIndex";
			select = select.Column(_bufferSchemaName, rowIndexColumnName).As(rowIndexColumnName);
			columnMapping.Add(rowIndexColumnName, rowIndexColumnName);
			
			var firstColumn = keyColumnExpressions.First();
			select = select.Join(JoinType.Inner, _bufferSchemaName).As(_bufferSchemaName)
				.On(_bufferSchemaName, firstColumn.BufferedColumnName)
				.IsEqual(GetCastQueryFunction(select.SourceExpression.Alias, firstColumn)) as Select;
			
			foreach (var keyColumn in keyColumnExpressions.Skip(1)) {
				select = select.And(keyColumn.BufferedColumnName)
				.IsEqual(GetCastQueryFunction(select.SourceExpression.Alias, keyColumn)) as Select;
			}
		}

		private CastQueryFunction GetCastQueryFunction(string alias, ColumnExpression column) =>
			Func.Cast(alias, column.ColumnValueName + (column.IsLookupColumn ? column.PrimaryColumnName:""), 
				new MaxSizeTextDataValueType(UserConnection.DataValueTypeManager));

		private void FindImportEntityDuplicate(EntitySchemaQuery esq, List<Entity> entities, ImportParameters parameters,
				IEnumerable<ImportColumn> keyColumns, Func<ColumnExpression, object> columnValueAction) {
			var mainFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			esq.Filters.Add(mainFilterGroup);
			var importColumns = keyColumns.ToList();
			var keyColumnsCount = importColumns.Count();
			foreach (var importEntity in parameters.Entities) {
				var columnsExpressions = GetKeyColumnsValues(parameters, importEntity, importColumns);
				if (!columnsExpressions.Any()) {
					continue;
				}
				var filters = GetKeyColumnsFilters(esq, columnsExpressions,
						columnValueAction);
				mainFilterGroup.Add(filters);
				var parametersCount = mainFilterGroup.Count * keyColumnsCount;
				if (parametersCount >= MaxQueryParametersCount) {
					AddEntitiesRange(esq, entities);
					esq.ResetSelectQuery();
					mainFilterGroup.Clear();
				}
			}
			if (mainFilterGroup.Any()) {
				AddEntitiesRange(esq, entities);
			}
		}

		private ColumnExpression GetColumnExpression(int index, ImportColumnDestination destination) {
			var columnExpression = new ColumnExpression {
					BufferedColumnName = $"Column{index}",
					ColumnValueName = destination.ColumnName,
					ComparisonType = FilterComparisonType.Equal
			};
			return columnExpression;
		}

		private IEnumerable<ColumnExpression> GetKeyColumnsExpressions(EntitySchema rootSchema,
				IEnumerable<ImportColumn> keyColumns) {
			var columnsExpressions = new List<ColumnExpression>();
			foreach (var item in keyColumns.Select((c, i) => (Column: c, Index: i + 1))) {
				var column = item.Column;
				var index = item.Index;
				foreach (var destination in column.Destinations) {
					if (!destination.SchemaUId.Equals(rootSchema.UId) || !destination.IsKey) {
						continue;
					}
					var schemaColumn = rootSchema.Columns.FindByName(destination.ColumnName);
					var isLookupColumn = schemaColumn.IsLookupType;
					var columnExpression = GetColumnExpression(index, destination);
					if (isLookupColumn) {
						columnExpression.IsLookupColumn = true;
						columnExpression.PrimaryColumnName = schemaColumn.ReferenceSchema.GetPrimaryColumnName();
					}
					columnsExpressions.Add(columnExpression);
				}
			}
			return columnsExpressions;
		}

		/// <summary>
		/// Gets key columns filters.
		/// </summary>
		/// <param name="esq">Entity schema query.</param>
		/// <param name="columnsExpressions">Columns keyColumnExpressions.</param>
		/// <param name="columnValueAction">Column value action.</param>
		/// <returns>Key columns filters.</returns>
		private EntitySchemaQueryFilterCollection GetKeyColumnsFilters(EntitySchemaQuery esq,
				List<ColumnExpression> columnsExpressions, Func<ColumnExpression, object> columnValueAction) {
			var filters = new EntitySchemaQueryFilterCollection(esq);
			foreach (var columnExpression in columnsExpressions) {
				var keyColumnFilter = esq.CreateFilterWithParameters(
						columnExpression.ComparisonType, columnExpression.ColumnValueName,
						columnValueAction(columnExpression));
				filters.Add(keyColumnFilter);
			}
			return filters;
		}

		/// <summary>
		/// Gets key columns values.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <param name="importEntity">Import entity.</param>
		/// <param name="keyColumns">Key columns.</param>
		/// <returns>Key columns values.</returns>
		private List<ColumnExpression> GetKeyColumnsValues(ImportParameters parameters, ImportEntity importEntity,
				IEnumerable<ImportColumn> keyColumns) {
			var columnsExpressions = new List<ColumnExpression>();
			foreach (var column in keyColumns) {
				var columnValue = importEntity.FindColumnValue(column);
				if (columnValue == null) {
					continue;
				}
				foreach (var destination in column.Destinations) {
					if (!destination.SchemaUId.Equals(parameters.RootSchemaUId) || !destination.IsKey) {
						continue;
					}
					var valueForSave = ColumnsProcessor.FindValueForSave(destination, columnValue);
					if (valueForSave == null) {
						continue;
					}
					columnsExpressions.Add(new ColumnExpression {
							ColumnValueName = destination.ColumnName,
							ComparisonType = FilterComparisonType.Equal,
							ColumnValue = valueForSave,
							DataValueTypeUId = Guid.Parse(destination.Properties[_typeUIdPropertyName].ToString())
					});
				}
			}
			return columnsExpressions;
		}

		/// <summary>
		/// Gets primary entities.
		/// </summary>
		/// <param name="parameters">Import parameters.</param>
		/// <param name="keyColumns">Key columns.</param>
		/// <param name="columnValueAction">Column value action.</param>
		/// <returns>Primary entities.</returns>
		private List<Entity> GetPrimaryEntities(ImportParameters parameters, IEnumerable<ImportColumn> keyColumns,
				Func<ColumnExpression, object> columnValueAction) {
			var entities = new List<Entity>();
			var rootSchema = GetRootSchema(parameters);
			var esq = CreateEntitiesSearchQuery(rootSchema);
			if (UserConnection.GetIsFeatureEnabled("HighestSpeedFileImport") && parameters.CanUseImportEntitiesStorage) {
				FindExistedImportEntities(esq, parameters, keyColumns, entities);
			} else {
				FindImportEntityDuplicate(esq, entities, parameters, keyColumns, columnValueAction);
			}
			return entities;
		}

		/// <summary>
		/// Returns column value. If column is text column trims column value.
		/// </summary>
		/// <param name="columnExpression">Column expression.</param>
		/// <returns>Column value.</returns>
		private object GetTrimmedTextColumnValue(ColumnExpression columnExpression) {
			var columnValue = columnExpression.ColumnValue;
			if (IsTextDataValueType(columnExpression.DataValueTypeUId)) {
				columnValue = columnValue.ToString().Trim();
			}
			return columnValue;
		}

		/// <summary>
		/// Defines if data value type is text data value type.
		/// </summary>
		/// <param name="dataValueTypeUId">Data value type identifier.</param>
		/// <returns>If it is text data value type.</returns>
		private bool IsTextDataValueType(Guid dataValueTypeUId) =>
				dataValueTypeUId.Equals(DataValueType.ShortTextDataValueTypeUId)
			|| dataValueTypeUId.Equals(DataValueType.MediumTextDataValueTypeUId)
			|| dataValueTypeUId.Equals(DataValueType.LongTextDataValueTypeUId)
			|| dataValueTypeUId.Equals(DataValueType.MaxSizeTextDataValueTypeUId)
			|| dataValueTypeUId.Equals(DataValueType.SecureTextDataValueTypeUId)
			|| dataValueTypeUId.Equals(DataValueType.TextDataValueTypeUId);

		private void IterateColumnExpressions(IEnumerable<ColumnExpression> expressions,
				Func<string, string, ColumnExpression, bool> iterator) {
			var joinPath = GetJoinPath(expressions.FirstOrDefault());
			foreach (var columnExpression in expressions) {
				var columnName = columnExpression.IsLookupColumn
					? columnExpression.PrimaryColumnName
					: columnExpression.ColumnValueName;
				if (columnName.IsNullOrEmpty()) {
					continue;
				}
				var continueIteration = iterator(columnName, joinPath, columnExpression);
				if (!continueIteration) {
					break;
				}
			}
		}

		private string GetJoinPath(ColumnExpression expression) {
			var columnName = expression.IsLookupColumn
				? expression.PrimaryColumnName
				: expression.ColumnValueName;
			var columnPath = $"=[{_bufferSchemaName}:{expression.BufferedColumnName}:{columnName}]";
			if (expression.IsLookupColumn) {
				columnPath = $"{expression.ColumnValueName}.{columnPath}";
			}
			return columnPath;
		}

		private void ClearBufferedTable(Guid importSessionId) {
			if (UserConnection.GetIsFeatureEnabled("HighestSpeedFileImport")) {
				ImportEntitiesDataProvider.CleanBufferedImportEntities(importSessionId);
			}
		}

		private void SaveRawImportEntities(ImportParameters parameters, IEnumerable<ImportColumn> keyColumns) {
			if (!UserConnection.GetIsFeatureEnabled("HighestSpeedFileImport")) {
				return;
			}
			if (!parameters.CanUseImportEntitiesStorage) {
				return;
			}
			ImportEntitiesDataProvider.SaveImportEntitiesToDB(parameters, keyColumns);
		}

		private bool AddKeyColumnsFilterToQuery(string joinPath, ColumnExpression columnExpression, 
			EntitySchemaQuery esq) {
			IEntitySchemaQueryFilterItem filter = esq.CreateFilter(FilterComparisonType.Equal, 
					$"{joinPath}.{columnExpression.BufferedColumnName}", 
					columnExpression.ColumnValueName);
			esq.Filters.Add(filter);
			return true;
		}
		
		#endregion

		#region Methods: Protected

		protected virtual void AddBufferedEntitiesKeyColumnsFilter(EntitySchemaQuery esq,
				IEnumerable<ColumnExpression> keyColumnsExpressions) {
			var bufferSchema = UserConnection.EntitySchemaManager.GetInstanceByName(_bufferSchemaName);
			IterateColumnExpressions(keyColumnsExpressions, (columnName, joinPath, columnExpression) => 
				AddKeyColumnsFilterToQuery(joinPath, columnExpression, esq));
		}

		protected virtual void AddBufferedEntitiesSearchQueryColumn(EntitySchemaQuery esq,
				IEnumerable<ColumnExpression> keyColumns) {
			IterateColumnExpressions(keyColumns, (columnName, joinPath, expression) => {
				var column = esq.AddColumn($"{joinPath}.{_bufImportExcelRowIndexName}");
				column.Name = _bufImportExcelRowIndexName;
				return false;
			});
		}

		protected virtual void AddBufferedEntitiesSessionIdFilter(EntitySchemaQuery esq, Guid importSessionId,
				IEnumerable<ColumnExpression> keyColumnsExpressions) {
			IterateColumnExpressions(keyColumnsExpressions, (columnName, joinPath, keyColumnExpression) => {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, $"{joinPath}.{_bufImportSessionIdColName}",
						importSessionId));
				return false;
			});
		}

		protected virtual void AddEntitiesSearchQueryColumns(EntitySchemaQuery esq,
				IEnumerable<ColumnExpression> columnsExpressions) {
			AddBufferedEntitiesSearchQueryColumn(esq, columnsExpressions);
		}

		protected virtual void AddEntitiesSearchQueryFilters(EntitySchemaQuery esq,
				IEnumerable<ColumnExpression> columnsExpressions, Guid importSessionId) {
			AddBufferedEntitiesKeyColumnsFilter(esq, columnsExpressions);
			AddBufferedEntitiesSessionIdFilter(esq, importSessionId, columnsExpressions);
		}

		protected override void ApplyEntitiesSearchQueryOptions(EntitySchemaQuery esq) {
			base.ApplyEntitiesSearchQueryOptions(esq);
			if (UserConnection.DBEngine.DBEngineType != DBEngineType.Oracle) {
				esq.ChunkSize = QueryChunkSize;
			}
			esq.Filters.LogicalOperation = LogicalOperationStrict.And;
		}

		protected virtual EntitySchema GetRootSchema(ImportParameters parameters) => UserConnection.EntitySchemaManager
			.GetInstanceByUId(parameters.RootSchemaUId);

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IPrimaryImportEntitiesGetter"/>
		public virtual IEnumerable<Entity> Get(ImportParameters parameters, IEnumerable<ImportColumn> keyColumns) {
			var entities = new List<Entity>();
			if (!keyColumns.Any()) {
				return entities;
			}
			var importColumns = keyColumns.ToList();
			try {
				SaveRawImportEntities(parameters, keyColumns);
				entities.AddRange(GetPrimaryEntities(parameters, importColumns,
						columnExpression => columnExpression.ColumnValue));
				if (!UserConnection.GetIsFeatureEnabled("HighestSpeedFileImport")) {
					entities.AddRange(GetPrimaryEntities(parameters, importColumns, GetTrimmedTextColumnValue));
				}
			} finally {
				ClearBufferedTable(parameters.ImportSessionId);
			}
			return entities;
		}

		#endregion

		#region Custom Class: ColumnExpression

		/// <summary>
		/// An instance of this class contains column name, comparison type, column value, column data value type.
		/// </summary>
		protected class ColumnExpression
		{
			#region  Fields: Public

			/// <summary>
			/// Name of column in buffered import entity table.
			/// </summary>
			public string BufferedColumnName;

			/// <summary>
			/// Column value.
			/// </summary>
			public object ColumnValue;

			/// <summary>
			/// Column name.
			/// </summary>
			public string ColumnValueName;

			/// <summary>
			/// Comparison type.
			/// </summary>
			public FilterComparisonType ComparisonType;

			/// <summary>
			/// Column data value type identifier.
			/// </summary>
			public Guid DataValueTypeUId;

			/// <summary>
			/// Primary column name of linked entity.
			/// </summary>
			public string PrimaryColumnName;

			/// <summary>
			/// Primary display column name of linked entity.
			/// </summary>
			[Obsolete("7.13.3 | Field is deprecated, use PrimaryColumnName instead.")]
			public string DisplayColumnName;

			/// <summary>
			/// Flag indicating that column is lookup.
			/// </summary>
			public bool IsLookupColumn;

			#endregion
		}

		#endregion
	}

	#endregion
}

