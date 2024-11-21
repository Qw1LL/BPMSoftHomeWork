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
	using BPMSoft.UI.WebControls.ResourceHandlers;

	#region Class: ChartSerieDashboardItemSelectBuilder

	public class ChartSerieDashboardItemSelectBuilder : BaseDashboardItemSelectBuilder
	{

		#region Constants: Private

		private const string XAxisColumnAlias = "xAxis";

		#endregion
		
		#region Constructor: Public

		public ChartSerieDashboardItemSelectBuilder(UserConnection userConnection, string schemaName, int timeZoneOffset,
				JToken parameters, JToken serieParameters, bool orderByGroupField)
			: base(userConnection, schemaName, timeZoneOffset, parameters) {
			_serieParameters = serieParameters;
			OrderByGroupField = orderByGroupField;
		}

		#endregion

		#region Properties: Protected

		protected bool OrderByGroupField
		{
			get;
			private set;
		}

		private readonly JToken _serieParameters;
		protected JToken SerieParameters
		{
			get
			{
				return _serieParameters;
			}
		}

		private string _columnPath;
		protected virtual string ColumnPath
		{
			get
			{
				if (_columnPath.IsNullOrEmpty()) {
					_columnPath = SerieParameters.Value<string>("xAxisColumn");
					if (string.IsNullOrEmpty(_columnPath)) {
						_columnPath = Esq.RootSchema.PrimaryColumn.ColumnValueName;
					}
				}
				return _columnPath;
			}
		}

		#endregion

		#region Properties: Public

		public JObject SerieConfig;

		public bool HasDateTimeFormat
		{
			get
			{
				string dateTimeFormat = Parameters.Value<string>("dateTimeFormat");
				return !string.IsNullOrEmpty(dateTimeFormat);
			}
		}

		private string _groupColumnPath;
		public virtual string GroupColumnPath
		{
			get
			{
				if (_groupColumnPath.IsNullOrEmpty()) {
					_groupColumnPath = SerieParameters.Value<string>("yAxisColumn");
					if (string.IsNullOrEmpty(_groupColumnPath)) {
						_groupColumnPath = Esq.RootSchema.PrimaryColumn.ColumnValueName;
					}
				}
				return _groupColumnPath;
			}
		}

		#endregion

		#region Methods: Private

		private int GetOrderPriority(EntitySchemaDatePartQueryFunctionInterval interval) {
			int priority;
			switch (interval) {
				case EntitySchemaDatePartQueryFunctionInterval.Month:
					priority = 1;
					break;
				case EntitySchemaDatePartQueryFunctionInterval.Week:
					priority = 2;
					break;
				case EntitySchemaDatePartQueryFunctionInterval.Weekday:
					priority = 3;
					break;
				case EntitySchemaDatePartQueryFunctionInterval.Day:
					priority = 4;
					break;
				case EntitySchemaDatePartQueryFunctionInterval.Hour:
					priority = 5;
					break;
				case EntitySchemaDatePartQueryFunctionInterval.HourMinute:
					priority = 6;
					break;
				default:
					priority = 0;
					break;
			}
			return priority;
		}

		private SortedDictionary<int, string> GetSortedDateTimeFormats(string dateTimeFormat) {
			var priorityDict = new SortedDictionary<int, string>();
			string[] dateTimeFormats = dateTimeFormat.Split(';');
			foreach (var format in dateTimeFormats) {
				EntitySchemaDatePartQueryFunctionInterval interval = DashboardDataUtils.GetDatePartInterval(format);
				priorityDict.Add(GetOrderPriority(interval), format);
			}
			return priorityDict;
		}

		private void AddDateTimeColumnsByFormat(string dateTimeFormat) {
			SortedDictionary<int, string> dateTimeFormats = GetSortedDateTimeFormats(dateTimeFormat);
			int index = 0;
			foreach (int key in dateTimeFormats.Keys) {
				var format = dateTimeFormats[key];
				string alias = "DatePart" + index;
				EntitySchemaDatePartQueryFunctionInterval interval = DashboardDataUtils.GetDatePartInterval(format);
				EntitySchemaQueryExpression columnExpression =
					EntitySchemaQuery.CreateSchemaColumnExpression(Esq.RootSchema, ColumnPath);
				columnExpression.UId = Guid.NewGuid();
				var queryFunction = new EntitySchemaDatePartQueryFunction(Esq, interval, columnExpression);
				queryFunction.SpecifyQueryAlias(alias);
				columnExpression.ParentQuery = queryFunction.ParentQuery;
				var esqExpression = new EntitySchemaQueryExpression(queryFunction) {
					UId = Guid.NewGuid()
				};
				EntitySchemaQueryColumn column = Esq.AddColumn(esqExpression.Function);
				var map = new Dictionary<string, object> {
					["format"] = format,
					["valueAlias"] = alias
				};
				entityColumnsMap[alias] = map;
				if (OrderByGroupField) {
					ApplyColumnOrder(column);
				}
				index++;
			}
		}

		private EntitySchemaQueryColumn AddAggregatedColumn(JObject yAxisConfig) {
			AggregationType columnAggregationType = AggregationType.Count;
			string aggregationType = SerieParameters.Value<string>("func");
			if (!string.IsNullOrEmpty(aggregationType)) {
				columnAggregationType = (AggregationType)Enum.Parse(typeof(AggregationType),
					aggregationType);
			}
			EntitySchemaQueryExpression columnExpression = EntitySchemaQuery.CreateSchemaColumnExpression(
				Esq.RootSchema, GroupColumnPath);
			columnExpression.UId = Guid.NewGuid();
			var queryFunction = new EntitySchemaAggregationQueryFunction(columnAggregationType.ToStrict(),
				columnExpression, Esq);
			if (columnAggregationType == AggregationType.Count) {
				queryFunction.AggregationEvalType = AggregationEvalType.Distinct;
			}
			EntitySchemaQueryColumn column = Esq.AddColumn(queryFunction);
			var columnMap = new Dictionary<string, object>();
			columnMap["valueAlias"] = column.ValueExpression.Function.QueryAlias;
			columnMap["dataValueType"] = columnExpression.SchemaColumn.DataValueType;
			entityColumnsMap[GroupColumnPath] = columnMap;
			yAxisConfig["dataValueType"] = GetColumnDataValueType(columnExpression);
			return column;
		}

		private void ApplyColumnOrder(EntitySchemaQueryColumn column) {
			string orderDirection = Parameters.Value<string>("orderDirection");
			if (!string.IsNullOrEmpty(orderDirection)) {
				column.OrderDirection = (OrderDirection)Enum.Parse(typeof(OrderDirection),
					orderDirection);
			}
		}

		#endregion

		#region Methods: Public

		public override Select Build() {
			entityColumnsMap = new Dictionary<string, object>();
			JObject xAxisConfig = SerieConfig.Value<JObject>("xAxis");
			JObject yAxisConfig = SerieConfig.Value<JObject>("yAxis");
			string dateTimeFormat = Parameters.Value<string>("dateTimeFormat");
			if (HasDateTimeFormat) {
				AddDateTimeColumnsByFormat(dateTimeFormat);
				xAxisConfig["dateTimeFormat"] = dateTimeFormat;
			} else {
				EntitySchemaQueryColumn column = Esq.AddColumn(ColumnPath);
				Dictionary<string, object> map = MapColumn(column, XAxisColumnAlias);
				entityColumnsMap[XAxisColumnAlias] = map;
				xAxisConfig["dataValueType"] = GetColumnDataValueType(column);
				if (OrderByGroupField) {
					ApplyColumnOrder(column);
				}
			}
			var useEmptyValue = Parameters.Value<string>("useEmptyValue");
			SerieConfig.Add(new JProperty("useEmptyValue", useEmptyValue));
			EntitySchemaQueryColumn aggregatedColumn = AddAggregatedColumn(yAxisConfig);
			if (!OrderByGroupField) {
				ApplyColumnOrder(aggregatedColumn);
			}
			Select select = base.Build();
			return select;
		}

		#endregion
	}

	#endregion

	#region Class: ChartDashboardItemData

	/// <summary>
	/// Chart dashboard widget.
	/// </summary>
	[DashboardItemData("Chart")]
	public class ChartDashboardItemData : BaseDashboardItemData
	{

		#region Constructor: Public

		public ChartDashboardItemData(string name, JObject config, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, userConnection, timeZoneOffset) {
		}

		public ChartDashboardItemData(string name, JObject config, string bindingColumnValue, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, bindingColumnValue, userConnection, timeZoneOffset) {
		}

		#endregion

		#region Properties: Protected

		protected override List<string> DataProperties
		{
			get
			{
				List<string> dataProperties = base.DataProperties;
				dataProperties.AddRange(new List<string> { "seriesConfig", "orderBy", "func", "type",
						"xAxisColumn", "yAxisColumn", "YAxisCaption", "yAxisConfig" });
				return dataProperties;
			}
		}

		protected override string SchemaNameProperty
		{
			get
			{
				return "schemaName";
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Gets value for chart's Y Axis.
		/// </summary>
		private object GetYAxisValue(IDataReader dataReader, ChartSerieDashboardItemSelectBuilder chartSerieDashboardSelectBuilder) {
			var entityColumnsMap = chartSerieDashboardSelectBuilder.EntityColumnsMap;
			var columnMap = (Dictionary<string, object>)entityColumnsMap[chartSerieDashboardSelectBuilder.GroupColumnPath];
			object value = GetValueByColumnMap(dataReader, columnMap);
			return value;
		}

		/// <summary>
		/// Gets value for chart's X Axis.
		/// </summary>
		private object GetXAxisValue(IDataReader dataReader, ChartSerieDashboardItemSelectBuilder chartSerieDashboardSelectBuilder) {
			var xAxis = new JObject();
			foreach (var map in chartSerieDashboardSelectBuilder.EntityColumnsMap) {
				if (map.Key != chartSerieDashboardSelectBuilder.GroupColumnPath) {
					var columnMap = (Dictionary<string, object>)map.Value;
					object value = GetValueByColumnMap(dataReader, columnMap);
					if (chartSerieDashboardSelectBuilder.HasDateTimeFormat) {
						xAxis.Add(new JProperty((string)columnMap["format"], value));
					} else {
						return value;
					}
				}
			}
			if (chartSerieDashboardSelectBuilder.HasDateTimeFormat) {
				return xAxis;
			}
			return null;
		}

		private JObject GetItemByXAxis(JArray array, JToken targetXAxis) {
			foreach (JObject item in array) {
				JToken xAxis = item.Value<JToken>("xAxis");
				if (JToken.DeepEquals(targetXAxis, xAxis)) {
					return item;
				}
			}
			return null;
		}

		private JArray GetData(List<JArray> data) {
			var groupedData = new JArray();
			bool shouldSetXAxisAsYAxis = ShouldSetXAxisAsYAxis(data);
			foreach (JArray serieData in data) {
				foreach (JObject item in serieData) {
					JToken xAxis = item.Value<JToken>("xAxis");
					if (shouldSetXAxisAsYAxis) {
						item.TrySetPropertyValue("xAxis", item["yAxis"].Value<String>());
						xAxis = item.Value<JToken>("xAxis");
					}
					JObject newItem = GetItemByXAxis(groupedData, xAxis);
					if (newItem == null) {
						newItem = new JObject();
						newItem.Add(new JProperty("xAxis", xAxis));
						newItem["yAxis"] = new JArray();
						groupedData.Add(newItem);
					}
				}
			}
			foreach (JObject item in groupedData) {
				JToken xAxis = item.Value<JToken>("xAxis");
				foreach (JArray serieData in data) {
					object value = 0;
					JObject foundItem = GetItemByXAxis(serieData, xAxis);
					if (foundItem != null) {
						value = foundItem["yAxis"];
					}
					item.Value<JArray>("yAxis").Add(value);
				}
			}
			return groupedData;
		}
		
		private bool ShouldSetXAxisAsYAxis(List<JArray> data) {
			bool result = true;
			foreach (JArray serieData in data) {
				foreach (JObject item in serieData) {
					JToken xAxis = item.Value<JToken>("xAxis");
					JToken yAxis = item.Value<JToken>("yAxis");
					if (!IsTokenNullOrEmpty(xAxis) || IsTokenNullOrEmpty(yAxis) || yAxis.Type == JTokenType.Array ||
						yAxis.Type == JTokenType.Object) {
						result = false;
						break;
					}
				}
			}
			return result;
		}
		
		private bool IsTokenNullOrEmpty(JToken token) {
			return token == null ||
				token.Type == JTokenType.Array && !token.HasValues ||
				token.Type == JTokenType.Object && !token.HasValues ||
				token.Type == JTokenType.String && token.ToString() == String.Empty ||
				token.Type == JTokenType.Null;
		}

		private JObject GetChartConfig() {
			var config = new JObject();
			config["xAxisDefaultCaption"] = Parameters.Value<string>("xAxisDefaultCaption");
			config["yAxisDefaultCaption"] = Parameters.Value<string>("yAxisDefaultCaption");
			return config;
		}

		private JObject GetSerieConfig(JToken serieParameters) {
			var xAxis = new JObject();
			xAxis.Add(new JProperty("caption", serieParameters.Value<string>("XAxisCaption")));
			var yAxis = new JObject();
			yAxis.Add(new JProperty("caption", serieParameters.Value<string>("YAxisCaption")));
			var serieConfig = new JObject();
			serieConfig.Add(new JProperty("type", serieParameters.Value<string>("type")));
			serieConfig.Add(new JProperty("style", serieParameters.Value<string>("styleColor")));
			serieConfig.Add(new JProperty("xAxis", xAxis));
			serieConfig.Add(new JProperty("yAxis", yAxis));
			return serieConfig;
		}

		private JArray GetSerieData(JArray seriesConfig, JToken serieParameters) {
			string schemaName = serieParameters.Value<string>(SchemaNameProperty);
			if (string.IsNullOrEmpty(schemaName)) {
				return new JArray();
			}
			JObject serieConfig = GetSerieConfig(serieParameters);
			serieConfig["schemaName"] = schemaName;
			serieConfig["schemaCaption"] = GetSchemaCaption(schemaName);
			var selectBuilder = GetSelectBuilder(schemaName, serieParameters, serieConfig);
			SetChartFilters(selectBuilder, serieParameters);
			Select select = selectBuilder.Build();
			var data = new JArray();
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var dataItem = new JObject();
						object xAxis = GetXAxisValue(dataReader, selectBuilder);
						dataItem.Add(new JProperty("xAxis", xAxis));
						object yAxis = GetYAxisValue(dataReader, selectBuilder);
						dataItem.Add(new JProperty("yAxis", yAxis));
						data.Add(dataItem);
					}
				}
			}
			seriesConfig.Add(serieConfig);
			return data;
		}

		private void AddUseEmptyValuesFilters(BaseDashboardItemSelectBuilder builder, JToken serieParameters) {
			string column = serieParameters.Value<string>("xAxisColumn");
			if (string.IsNullOrEmpty(column)) {
				column = builder.Esq.RootSchema.PrimaryColumn.ColumnValueName;
			}
			builder.Esq.Filters.Add(builder.Esq.CreateFilter(FilterComparisonType.IsNotNull, column));
		}

		private void SetChartFilters(BaseDashboardItemSelectBuilder builder, JToken serieParameters) {
			var useEmptyValue = Parameters.Value<string>("useEmptyValue");
			if (useEmptyValue.IsNullOrEmpty() || useEmptyValue.Equals("False")) {
				AddUseEmptyValuesFilters(builder, serieParameters);
			}
			string filterData = serieParameters.Value<string>("filterData");
			builder.AddFilterByJson(filterData);
			ApplySectionBindingFilter(builder, serieParameters);
		}

		private void SetSerieFilter(DashboardGridDataSelectBuilder builder, JToken serieParameters, string filterValue) {
			string filterColumn = serieParameters.Value<string>("xAxisColumn");
			if (filterValue != null) {
				string dateTimeFormat = Parameters.Value<string>("dateTimeFormat");
				bool hasDateTimeFormat = !string.IsNullOrEmpty(dateTimeFormat);
				if (hasDateTimeFormat) {
					builder.AddDatePartFilter(filterColumn, filterValue, dateTimeFormat);
				} else {
					builder.AddFilter(filterColumn, filterValue);
				}
			} else {
				IEntitySchemaQueryFilterItem isNullFilter = builder.Esq.CreateIsNullFilter(filterColumn);
				builder.Esq.Filters.Add(isNullFilter);
			}
		}

		private DashboardGridDataSelectBuilder GetDashboardGridDataSelectBuilder(JArray columns, int rowCount,
				int rowOffset, int serieIndex) {
			string schemaName = GetSchemaName(serieIndex);
			DashboardGridDataSelectBuilder builder = CreateDashboardGridDataSelectBuilder(columns, schemaName);
			builder.EsqOptions = new EntitySchemaQueryOptions {
				PageableRowCount = rowCount,
				RowsOffset = rowOffset,
				PageableDirection = PageableSelectDirection.Current,
				PageableConditionValues = new Dictionary<string, object>()
			};
			return builder;
		}

		private JToken GetParameters(int serieIndex) {
			if (serieIndex == 0) {
				return Parameters;
			} else {
				JArray chartSeriesConfig = Parameters.Value<JArray>("seriesConfig");
				return chartSeriesConfig[serieIndex - 1];
			}
		}

		private string GetSchemaName(int serieIndex) {
			JToken parameters = GetParameters(serieIndex);
			return parameters.Value<string>(SchemaNameProperty);
		}

		private JArray GetGridRecords(JArray columns, int rowCount, int rowOffset, int serieIndex, bool useFilter = false, string filterValue = null) {
			var data = new JArray();
			string schemaName = GetSchemaName(serieIndex);
			if (!string.IsNullOrEmpty(schemaName)) {
				DashboardGridDataSelectBuilder selectBuilder =
					GetDashboardGridDataSelectBuilder(columns, rowCount, rowOffset, serieIndex);
				JToken serieParameters = GetParameters(serieIndex);
				SetChartFilters(selectBuilder, serieParameters);
				if (useFilter) {
					SetSerieFilter(selectBuilder, serieParameters, filterValue);
				}
				Select select = selectBuilder.Build();
				Dictionary<string, object> entityColumnMap = selectBuilder.EntityColumnsMap;
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
			}
			return data;
		}

		private JArray GetProfileGridColumns(int serieIndex) {
			string profileKey = "DashboardsModule_DashboardModule" + Name + "ChartModule";
			UserProfileResourceHandler handler = GetUserProfileResourceHandler(profileKey);
			byte[] profileByte = handler.Fetch();
			string profileDataStr = Encoding.UTF8.GetString(profileByte);
			var profileData = (JObject)Json.Deserialize(profileDataStr);
			JToken parameters = GetParameters(serieIndex);
			string entitySchemaName = parameters.Value<string>(SchemaNameProperty);
			string xAxisColumn = parameters.Value<string>("xAxisColumn");
			string yAxisColumn = parameters.Value<string>("yAxisColumn");
			if (yAxisColumn == null) {
				yAxisColumn = "Id";
			}
			string chartKey = String.Format("{0}_{1}_{2}", entitySchemaName, xAxisColumn, yAxisColumn);
			var chartProfile = profileData[chartKey] as JObject;
			if (chartProfile != null) {
				var listedConfig = (string)chartProfile["listedConfig"];
				if (listedConfig != null) {
					var data = (JObject)Json.Deserialize(listedConfig);
					return data["items"] as JArray;
				}
			}
			return null;
		}

		private void SetReferenceSchemaNames(string rootSchemaName, JArray gridColumns) {
			EntitySchema entitySchema = null;
			foreach (JObject columnItem in gridColumns) {
				if (columnItem.Value<int>("dataValueType") == (int)BPMSoft.Nui.ServiceModel.DataContract.DataValueType.Lookup &&
						string.IsNullOrEmpty(columnItem.Value<string>("referenceSchemaName"))) {
					string columnPath = DashboardDataUtils.GetColumnPath(columnItem);
					columnPath = DashboardDataUtils.ClearColumnPathSuffix(columnPath);
					if (entitySchema == null) {
						entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(rootSchemaName);
					}
					EntitySchemaColumn column = entitySchema.FindSchemaColumnByPath(columnPath);
					if (column.ReferenceSchema != null) {
						columnItem["referenceSchemaName"] = column.ReferenceSchema.Name;
					}
				}
			}
		}

		private JObject GetGridColumnConfig(EntitySchema entitySchema, string columnPath) {
			EntitySchemaColumn column = entitySchema.FindSchemaColumnByPath(columnPath);
			var data = new JObject();
			data.Add(new JProperty("caption", (string)column.Caption));
			data.Add(new JProperty("metaPath", columnPath));
			DataValueType columnValueType = column.DataValueType;
			data.Add(new JProperty("dataValueType", (int)Nui.ServiceModel.Extensions.DataValueTypeExtension.ToEnum(columnValueType)));
			return data;
		}

		private JArray GetDefaultGridColumns(int serieIndex) {
			var columns = new JArray();
			string schemaName = GetSchemaName(serieIndex);
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			string primaryDisplayColumnName = entitySchema.FindPrimaryDisplayColumnName();
			if (primaryDisplayColumnName != null) {
				columns.Add(GetGridColumnConfig(entitySchema, primaryDisplayColumnName));
			}
			string xAxisColumn = Parameters.Value<string>("xAxisColumn");
			if (xAxisColumn != primaryDisplayColumnName) {
				columns.Add(GetGridColumnConfig(entitySchema, xAxisColumn));
			}
			string yAxisColumn = Parameters.Value<string>("yAxisColumn");
			if (yAxisColumn != null && yAxisColumn != "Id") {
				columns.Add(GetGridColumnConfig(entitySchema, yAxisColumn));
			}
			return columns;
		}

		private JArray GetGridColumns(int serieIndex) {
			JArray gridColumns = GetProfileGridColumns(serieIndex);
			if (gridColumns == null) {
				gridColumns = GetDefaultGridColumns(serieIndex);
			}
			return gridColumns;
		}

		private JObject GetGridConfigBySerieIndex(int serieIndex) {
			var itemObject = new JObject();
			JArray gridColumns = GetGridColumns(serieIndex);
			string schemaName = GetSchemaName(serieIndex);
			SetReferenceSchemaNames(schemaName, gridColumns);
			itemObject["columns"] = gridColumns;
			itemObject["schemaName"] = schemaName;
			return itemObject;
		}

		#endregion

		#region Methods: Protected

		protected virtual DashboardGridDataSelectBuilder CreateDashboardGridDataSelectBuilder(JArray columns, string schemaName) {
			return new DashboardGridDataSelectBuilder(UserConnection, schemaName, TimeZoneOffset, columns);
		}

		protected virtual UserProfileResourceHandler GetUserProfileResourceHandler(string profileKey) {
			return new UserProfileResourceHandler(UserConnection, profileKey);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns data for chart dashboard item.
		/// </summary>
		public override JObject GetJson() {
			JObject itemObject = base.GetJson();
			JObject chartConfig = GetChartConfig();
			JArray chartSeriesConfig = Parameters.Value<JArray>("seriesConfig");
			if (chartSeriesConfig == null) {
				chartSeriesConfig = new JArray();
			}
			var seriesConfig = new JArray();
			var data = new List<JArray>();
			JArray serieData = GetSerieData(seriesConfig, Parameters);
			data.Add(serieData);
			foreach (JToken chartSerieConfig in chartSeriesConfig) {
				serieData = GetSerieData(seriesConfig, chartSerieConfig);
				data.Add(serieData);
			}
			chartConfig["seriesConfig"] = seriesConfig;
			string orderDirection = "asc";
			if ((OrderDirection)Enum.Parse(typeof(OrderDirection), Parameters.Value<string>("orderDirection")) == OrderDirection.Descending) {
				orderDirection = "desc";
			}
			chartConfig["orderDirection"] = orderDirection;
			chartConfig["orderBy"] = Parameters.Value<string>("orderBy");
			itemObject["chartConfig"] = chartConfig;
			itemObject["style"] = Parameters.Value<string>("styleColor");
			itemObject["data"] = GetData(data);
			return itemObject;
		}

		/// <summary>
		/// Returns instance of select builder.
		/// </summary>
		public virtual ChartSerieDashboardItemSelectBuilder GetSelectBuilder(string schemaName, JToken serieParameters,
				JObject serieConfig) {
			string orderBy = Parameters.Value<string>("orderBy");
			bool orderByGroupField = orderBy == "GroupByField";
			var chartSerieDashboardSelectBuilder = new ChartSerieDashboardItemSelectBuilder(UserConnection, schemaName,
				TimeZoneOffset, Parameters, serieParameters, orderByGroupField) {
				SerieConfig = serieConfig
			};
			return chartSerieDashboardSelectBuilder;
		}

		/// <summary>
		/// Returns display data for chart dashboard item.
		/// </summary>
		public virtual JArray GetGridData(int rowCount, int rowOffset, int serieIndex) {
			JArray gridColumns = GetGridColumns(serieIndex);
			return GetGridRecords(gridColumns, rowCount, rowOffset, serieIndex);
		}

		/// <summary>
		/// Returns display data for chart dashboard item.
		/// </summary>
		public virtual JArray GetGridDataByFilter(int rowCount, int rowOffset, string filterValue, int serieIndex) {
			JArray gridColumns = GetGridColumns(serieIndex);
			return GetGridRecords(gridColumns, rowCount, rowOffset, serieIndex, true, filterValue);
		}

		/// <summary>
		/// Returns columns config for data.
		/// </summary>
		public virtual JArray GetGridDataConfigs() {
			var gridDataConfigs = new JArray();
			JToken itemObject = GetGridConfigBySerieIndex(0);
			gridDataConfigs.Add(itemObject);
			JArray chartSeriesConfig = Parameters.Value<JArray>("seriesConfig");
			if (chartSeriesConfig != null) {
				for (int serieIndex = 1; serieIndex <= chartSeriesConfig.Count; serieIndex++) {
					JToken serieItemObject = GetGridConfigBySerieIndex(serieIndex);
					gridDataConfigs.Add(serieItemObject);
				}
			}
			return gridDataConfigs;
		}

		#endregion

	}

	#endregion

}
