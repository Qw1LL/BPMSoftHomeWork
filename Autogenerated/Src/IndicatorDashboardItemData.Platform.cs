namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using Common;
	using Core.Entities;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: IndicatorDashboardSelectBuilder

	public class IndicatorDashboardItemSelectBuilder : BaseDashboardItemSelectBuilder
	{

		#region Constructor: Public

		public IndicatorDashboardItemSelectBuilder(UserConnection userConnection, string schemaName, int timeZoneOffset, JToken parameters)
			: base(userConnection, schemaName, timeZoneOffset, parameters) {
		}

		#endregion

		#region Properties: Public

		public Dictionary<string, object> EntityColumnMap;

		public int? ColumnDataValueType;

		#endregion

		#region Methods: Public

		public override Select Build() {
			string columnPath = Parameters.Value<string>("columnName");
			if (string.IsNullOrEmpty(columnPath)) {
				columnPath = Esq.RootSchema.PrimaryColumn.ColumnValueName;
			}
			EntitySchemaQueryExpression columnExpression = EntitySchemaQuery.CreateSchemaColumnExpression(
				Esq.RootSchema, columnPath);
			columnExpression.UId = Guid.NewGuid();
			AggregationType columnAggregationType = AggregationType.Count;
			string aggregationType = Parameters.Value<string>("aggregationType");
			if (!string.IsNullOrEmpty(aggregationType)) {
				columnAggregationType = (AggregationType)Enum.Parse(typeof(AggregationType),
					aggregationType);
			}
			var queryFunction = new EntitySchemaAggregationQueryFunction(columnAggregationType.ToStrict(),
				columnExpression, Esq);
			ColumnDataValueType = GetColumnDataValueType(columnExpression);
			Esq.AddColumn(queryFunction);
			EntityColumnMap = new Dictionary<string, object>();
			EntityColumnMap["valueAlias"] = queryFunction.QueryAlias;
			EntityColumnMap["dataValueType"] = columnExpression.SchemaColumn.DataValueType;
			string filterData = Parameters.Value<string>("filterData");
			AddFilterByJson(filterData);
			return base.Build();
		}

		#endregion
	}

	#endregion

	#region Class: IndicatorDashboardItemData

	/// <summary>
	/// Indicator dashboard widget.
	/// </summary>
	[DashboardItemData("Indicator")]
	public class IndicatorDashboardItemData : BaseDashboardItemData
	{
		
		#region Constructor: Public

		public IndicatorDashboardItemData(string name, JObject config, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, userConnection, timeZoneOffset) {
		}
		
		public IndicatorDashboardItemData(string name, JObject config, string bindingColumnValue, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, bindingColumnValue, userConnection, timeZoneOffset) {
		}

		#endregion

		#region Properties: Protected

		protected override List<string> DataProperties
		{
			get
			{
				List<string> dataProperties = base.DataProperties;
				dataProperties.AddRange(new List<string> { "columnName", "aggregationType" });
				return dataProperties;
			}
		}

		#endregion

		#region Methods: Private

		private object GetData(IndicatorDashboardItemSelectBuilder dashboardSelectBuilder) {
			ApplySectionBindingFilter(dashboardSelectBuilder);
			Select select = dashboardSelectBuilder.Build();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						object value = GetValueByColumnMap(dataReader, dashboardSelectBuilder.EntityColumnMap);
						return value;
					}
				}
			}
			return null;
		}

		private JArray GetGridColumns() {
			var columns = new JArray();
			string schemaName = GetSchemaName();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			string primaryDisplayColumnName = entitySchema.FindPrimaryDisplayColumnName();
			if (primaryDisplayColumnName != null) {
				columns.Add(DashboardDataUtils.GetGridColumnConfig(entitySchema, primaryDisplayColumnName));
			}
			string columnPath = Parameters.Value<string>("columnName");
			if (!string.IsNullOrEmpty(columnPath)) {
				columns.Add(DashboardDataUtils.GetGridColumnConfig(entitySchema, columnPath));
			}
			if (columns.Count == 0) {
				columns.Add(DashboardDataUtils.GetGridColumnConfig(entitySchema, entitySchema.CreatedByColumn.Name));
				columns.Add(DashboardDataUtils.GetGridColumnConfig(entitySchema, entitySchema.CreatedOnColumn.Name));
			}
			return columns;
		}

		private JArray GetGridRecords(JArray columns, int rowCount, int rowOffset) {
			var data = new JArray();
			DashboardGridDataSelectBuilder selectBuilder = CreateDashboardGridDataSelectBuilder(columns);
			string filterData = Parameters.Value<string>("filterData");
			selectBuilder.AddFilterByJson(filterData);
			selectBuilder.EsqOptions = new EntitySchemaQueryOptions {
				PageableRowCount = rowCount,
				RowsOffset = rowOffset,
				PageableDirection = PageableSelectDirection.Current,
				PageableConditionValues = new Dictionary<string, object>()
			};
			Select select = selectBuilder.Build();
			var entityColumnMap = selectBuilder.EntityColumnsMap;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var dataItem = new JObject();
						foreach (var map in entityColumnMap) {
							object value = GetValueByColumnMap(dataReader, (Dictionary<string, object>)map.Value);
							dataItem.Add(new JProperty(map.Key, value));
						}
						data.Add(dataItem);
					}
				}
			}
			return data;
		}

		#endregion

		#region Methods: Protected

		protected virtual DashboardGridDataSelectBuilder CreateDashboardGridDataSelectBuilder(JArray columns) {
			string schemaName = GetSchemaName();
			return new DashboardGridDataSelectBuilder(UserConnection, schemaName, TimeZoneOffset, columns);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns data for indicator dashboard item.
		/// </summary>
		public override JObject GetJson() {
			JObject itemObject = base.GetJson();
			CopyProperties(itemObject);
			if (string.IsNullOrEmpty(GetSchemaName())) {
				return itemObject;
			}
			IndicatorDashboardItemSelectBuilder selectBuilder = GetSelectBuilder();
			object value = GetData(selectBuilder);
			itemObject["dataValueType"] = selectBuilder.ColumnDataValueType;
			itemObject.Add(new JProperty("data", value));
			return itemObject;
		}

		/// <summary>
		/// Returns instance of select builder.
		/// </summary>
		public virtual IndicatorDashboardItemSelectBuilder GetSelectBuilder() {
			return new IndicatorDashboardItemSelectBuilder(UserConnection, GetSchemaName(), TimeZoneOffset, Parameters);
		}

		/// <summary>
		/// Returns columns config for data.
		/// </summary>
		public virtual JObject GetGridDataConfig() {
			var itemObject = new JObject();
			JArray gridColumns = GetGridColumns();
			string schemaName = GetSchemaName();
			itemObject["columns"] = gridColumns;
			itemObject["schemaName"] = schemaName;
			return itemObject;
		}

		/// <summary>
		/// Returns display data.
		/// </summary>
		public virtual JArray GetGridData(int rowCount, int rowOffset) {
			var itemObject = new JObject();
			JArray gridColumns = GetGridColumns();
			return GetGridRecords(gridColumns, rowCount, rowOffset);
		}

		#endregion

	}

	#endregion
}
