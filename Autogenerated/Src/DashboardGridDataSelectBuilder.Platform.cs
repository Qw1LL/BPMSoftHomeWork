namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Text;
	using Common;
	using Core.Entities;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: DashboardGridDataSelectBuilder

	public class DashboardGridDataSelectBuilder : BaseDashboardItemSelectBuilder
	{

		#region Fields: Private

		private JArray _columns;

		#endregion

		#region Constructor: Public

		public DashboardGridDataSelectBuilder(UserConnection userConnection, string schemaName, int timeZoneOffset, JArray columns)
			: base(userConnection, schemaName, timeZoneOffset, null) {
			SchemaName = schemaName;
			_columns = columns;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Entity schema name.
		/// </summary>
		public string SchemaName
		{
			get;
			private set;
		}

		#endregion

		#region Methods: Private

		private void SetColumnOrder(JObject columnItem, EntitySchemaQueryColumn column) {
			string orderDirection = columnItem.Value<string>("orderDirection");
			if (!string.IsNullOrEmpty(orderDirection)) {
				column.OrderDirection = (OrderDirection)Enum.Parse(typeof(OrderDirection),
					orderDirection);
				column.OrderPosition = columnItem.Value<int>("orderPosition");
			}
		}

		private EntitySchemaQueryColumn AddQueryColumn(JObject columnItem, string columnPath) {
			columnPath = DashboardDataUtils.ClearColumnPathSuffix(columnPath);
			string filterData = columnItem.Value<string>("serializedFilter");
			string aggregationType = columnItem.Value<string>("aggregationType");
			AggregationType columnAggregationType = AggregationType.None;
			if (!string.IsNullOrEmpty(aggregationType)) {
				columnAggregationType = (AggregationType)Enum.Parse(typeof(AggregationType),
					aggregationType);
			}
			EntitySchemaQueryColumn column;
			if (columnAggregationType != AggregationType.None && !string.IsNullOrEmpty(filterData)) {
				EntitySchemaQuery subQuery;
				column = Esq.AddColumn(columnPath, columnAggregationType.ToStrict(), out subQuery);
				var dashboardData = new BaseDashboardItemSelectBuilder(UserConnection, subQuery);
				dashboardData.AddFilterByJson(filterData);
			} else {
				column = Esq.AddColumn(columnPath);
				if (!string.IsNullOrEmpty(aggregationType)) {
					column.SummaryType = columnAggregationType;
				}
			}
			SetColumnOrder(columnItem, column);
			return column;
		}

		private void AddQueryColumns() {
			entityColumnsMap = new Dictionary<string, object>();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(SchemaName);
			string primaryDisplayColumnName = entitySchema.FindPrimaryDisplayColumnName();
			string primaryKeyColumnName = entitySchema.GetPrimaryColumnName();
			string primaryColumnAlias = string.Empty;
			foreach (JObject columnItem in _columns) {
				string columnPath = DashboardDataUtils.GetColumnPath(columnItem);
				if (entityColumnsMap.ContainsKey(columnPath)) {
					continue;
				}
				EntitySchemaQueryColumn column = AddQueryColumn(columnItem, columnPath);
				Dictionary<string, object> map = MapColumn(column);
				entityColumnsMap[columnPath] = map;
				if (columnPath == primaryKeyColumnName) {
					primaryColumnAlias = (string)map["valueAlias"];
				}
			}
			if (primaryColumnAlias.IsNullOrEmpty() && primaryKeyColumnName.IsNotNullOrEmpty()) {
				EntitySchemaQueryColumn primaryKeyColumn = Esq.AddColumn(primaryKeyColumnName);
				entityColumnsMap[primaryKeyColumnName] = MapColumn(primaryKeyColumn);
			}
		}

		private EntitySchemaQueryFilter GetDatePartFilter(EntitySchemaQueryExpression columnExpression, int datePartValue, EntitySchemaDatePartQueryFunctionInterval interval) {
			var queryFunction = new EntitySchemaDatePartQueryFunction(Esq, interval, columnExpression);
			var filter = new EntitySchemaQueryFilter(FilterComparisonType.Equal) {
				LeftExpression = new EntitySchemaQueryExpression(queryFunction)
			};
			EntitySchemaQueryExpression rightExpression = EntitySchemaQuery.CreateParameterExpression(datePartValue);
			filter.RightExpressions.Add(rightExpression);
			return filter;
		}

		#endregion

		#region Methods: Public

		public override Select Build() {
			AddQueryColumns();
			return base.Build();
		}

		/// <summary>
		/// Adds filter(s) for column date part(s).
		/// </summary>
		/// <param name="filterColumn">Column for filtration</param>
		/// <param name="filterValue">Stringified JSON object with values</param>
		/// <param name="dateTimeFormat">Date parts separated by ';'</param>
		public void AddDatePartFilter(string filterColumn, string filterValue, string dateTimeFormat) {
			string[] dateTimeFormats = dateTimeFormat.Split(';');
			var filterValueObj = (JObject)Json.Deserialize(filterValue);
			EntitySchemaQueryExpression columnExpression = Esq.CreateSchemaColumnExpression(filterColumn);
			foreach (var format in dateTimeFormats) {
				var datePartValue = filterValueObj.Value<int>(format);
				EntitySchemaDatePartQueryFunctionInterval interval = DashboardDataUtils.GetDatePartInterval(format);
				var filter = GetDatePartFilter(columnExpression, datePartValue, interval);
				Esq.Filters.Add(filter);
			}
		}

		#endregion

	}

	#endregion

}

