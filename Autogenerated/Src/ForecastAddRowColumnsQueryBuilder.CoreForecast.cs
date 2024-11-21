namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastAddRowColumnsQueryBuilder

	/// <summary>
	/// Provides methods for building query by adding columns to forecast row select.
	/// </summary>
	public interface IForecastAddRowColumnsQueryBuilder
	{
		/// <summary>
		/// Decorates select query with add columns expressions.
		/// </summary>
		/// <param name="select">Forecast row select.</param>
		/// <param name="columns">Columns to add.</param>
		/// <param name="parameters">Forecast metadata parameters.</param>
		void AddColumnsToSelect(Select select, IEnumerable<KeyValuePair<int, string>> columns,
			AddRowColumnsQueryBuilderParams parameters);
	}

	#endregion

	/// <summary>
	/// Parameters for AddRowColumnsQueryBuilder operation.
	/// </summary>
	public class AddRowColumnsQueryBuilderParams
	{
		/// <summary>
		/// Forecast entity schema on which forecast is built.
		/// </summary>
		public EntitySchema ForecastSchema { get; set; }

		/// <summary>
		/// Alias of forecast entity table in select.
		/// </summary>
		public string SelectEntityAlias { get; set; }
	}

	#region Class: ForecastAddRowColumnsQueryBuilder

	///<inheritdoc />
 	[DefaultBinding(typeof(IForecastAddRowColumnsQueryBuilder))]
	public class ForecastAddRowColumnsQueryBuilder : IForecastAddRowColumnsQueryBuilder
	{

		#region Constants: Private

		private const string IdColumnName = "Id";
		private const string LczIdColumnName = "RecordId";

		#endregion

		#region Fields: Private

		private Select _select;
		private EntitySchemaColumn _entityColumn;
		private EntitySchema _forecastEntitySchema;
		private EntitySchema _prevEntitySchema;
		private string _columnName;
		private string _hierarchyColumnNameAlias;
		private string _nameColumnName;
		private string _prevSchemaName;
		private string _prevTableAlias;
		private string _refColumnIdName;
		private string _tableAlias;
		private string _tableLczAlias;
		private string _forecastEntityAlias;

		#endregion

		#region Constructors: Public

		public ForecastAddRowColumnsQueryBuilder(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private void AddColumnPart(string[] columnsPathParts, string columnPathPart, int index) {
			var displayColumn = _entityColumn.ReferenceSchema.GetPrimaryDisplayColumn();
			bool isLocalizable = false;
			if (displayColumn != null) {
				isLocalizable = displayColumn.IsLocalizable;
			}
			_refColumnIdName = columnPathPart + IdColumnName;
			_tableAlias = $"E{index}E{_prevSchemaName}{_refColumnIdName}";
			_tableLczAlias = "";
			if (isLocalizable) {
				_tableLczAlias = _tableAlias + "lcz";
			}
			var lastIndex = columnsPathParts.Count() - 1;
			var isLastPart = index == lastIndex;
			if (isLastPart) {
				AddLastPartColumn(isLocalizable);
			}
			if (_entityColumn.IsLookupType) {
				AddLookupColumn(isLastPart, isLocalizable);
			}
		}

		private void AddColumnToSelect(KeyValuePair<int, string> column) {
			var columnsPathParts = SplitColumnValueByParts(column);
			_prevSchemaName = _forecastEntityAlias;
			_prevTableAlias = _prevSchemaName;
			_prevEntitySchema = _forecastEntitySchema;
			var index = 0;
			columnsPathParts.ForEach(columnPathPart => {
				_hierarchyColumnNameAlias = $"hierarchyColumn{column.Key}";
				_entityColumn = _prevEntitySchema.GetSchemaColumnByPath(columnPathPart);
				var schema = _entityColumn.ReferenceSchema;
				_columnName = _entityColumn.Name;
				_nameColumnName = _entityColumn.DisplayColumnValueName.Replace(_columnName, "");
				var isLeafColumn = IsLeafColumn(_forecastEntitySchema, _columnName);
				if (isLeafColumn || schema == null) {
					_nameColumnName = _columnName;
					SetLeafColumn(_forecastEntitySchema);
				} else {
					AddColumnPart(columnsPathParts, columnPathPart, index);
					_prevTableAlias = _tableAlias;
					_prevSchemaName = index.ToString();
					_prevEntitySchema = schema;
				}
				index++;
			});
		}

		private void AddLastPartColumn(bool isLocalizable) {
			if (isLocalizable) {
				_select.Column(GetCoalesceQueryFunction(_tableLczAlias, _tableAlias, _nameColumnName))
					.As(_hierarchyColumnNameAlias);
			} else {
				_select.Column(_tableAlias, _nameColumnName).As(_hierarchyColumnNameAlias);
			}
		}

		private void AddLocalizationJoin(string lczSchemaName, string tableAlias, string lczTableAlias) {
			if (!_select.Joins.Exists(lczSchemaName)) {
				_select.Join(JoinType.LeftOuter, lczSchemaName).As(lczTableAlias)
					.On(tableAlias, IdColumnName).IsEqual(lczTableAlias, LczIdColumnName)
					.And(lczTableAlias, "SysCultureId")
						.IsEqual(Column.Parameter(UserConnection.CurrentUser.SysCultureId));
			}
		}

		private void AddLookupColumn(bool isLastPart, bool isLocalizable) {
			string idColumnName = _entityColumn.ColumnValueName.Replace(_columnName, "");
			if (isLastPart) {
				_select.Column(_tableAlias, idColumnName).As($"{_hierarchyColumnNameAlias}{IdColumnName}");
			}
			if (!_select.Joins.Exists(_tableAlias)) {
				var referenceSchemaName = _entityColumn.ReferenceSchema.Name;
				var joinCondition = _select.Join(JoinType.LeftOuter, referenceSchemaName).As(_tableAlias)
					.On(_prevTableAlias, _refColumnIdName).IsEqual(_tableAlias, IdColumnName);
				if (isLocalizable) {
					AddLocalizationJoin(_entityColumn.ReferenceSchema.LocalizationSchemaName, _tableAlias,
						_tableLczAlias);
				}
			}
		}

		private CoalesceQueryFunction GetCoalesceQueryFunction(string lczTableAlias, string tableAlias, string columnName) {
			return Func.Coalesce(new QueryColumnExpression(lczTableAlias, columnName),
				new QueryColumnExpression(tableAlias, columnName));
		}

		private bool IsLeafColumn(EntitySchema forecastEntitySchema, string columnName) {
			return forecastEntitySchema.PrimaryDisplayColumn.Name.Equals(columnName);
		}

		private void SetLeafColumn(EntitySchema entitySchema) {
			if (entitySchema.PrimaryDisplayColumn.IsLocalizable) {
				var lczAlias = _forecastEntityAlias + "lcz";
				_select.Column(GetCoalesceQueryFunction(lczAlias, _forecastEntityAlias, _columnName)).As(_hierarchyColumnNameAlias);
				AddLocalizationJoin(entitySchema.LocalizationSchemaName, _forecastEntityAlias, lczAlias);
			} else {
				_select.Column(_forecastEntityAlias, _columnName).As(_hierarchyColumnNameAlias);
			}
			_select.Column(_forecastEntityAlias, IdColumnName).As($"{_hierarchyColumnNameAlias}{IdColumnName}");
		}

		private string[] SplitColumnValueByParts(KeyValuePair<int, string> column) {
			return column.Value.Split('.');
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public void AddColumnsToSelect(Select select, IEnumerable<KeyValuePair<int, string>> columns,
				AddRowColumnsQueryBuilderParams parameters) {
			_select = select;
			_forecastEntitySchema = parameters.ForecastSchema;
			_forecastEntityAlias = parameters.SelectEntityAlias;
			columns.OrderByDescending(c => c.Key).ForEach(column => {
				AddColumnToSelect(column);
			});
			_select.Distinct();
		}

		#endregion

	}

	#endregion

}

