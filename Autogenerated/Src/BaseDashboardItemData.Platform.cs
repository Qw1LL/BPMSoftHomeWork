namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Threading;
	using Core.DB;
	using Core.Factories;
	using Core.Process;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: BaseDashboardItemSelectBuilder

	public class BaseDashboardItemSelectBuilder : IDashboardItemSelectBuilder
	{
		#region Constants: Private

		private const short MinutesInDay = 24 * 60;

		#endregion

		#region Constructor: Public

		public BaseDashboardItemSelectBuilder(UserConnection userConnection, string schemaName, int timeZoneOffset, JToken parameters) {
			_userConnection = userConnection;
			Parameters = parameters;
			CancellationToken cancellationToken = GetCancellationToken();
			if (cancellationToken != CancellationToken.None) {
				var schema = userConnection.EntitySchemaManager.GetInstanceByName(schemaName);
				Esq = new EntitySchemaQuery(schema, cancellationToken);
			} else {
				Esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, schemaName);
			}
			TimeZoneOffset = timeZoneOffset;
		}

		public BaseDashboardItemSelectBuilder(UserConnection userConnection, EntitySchemaQuery entitySchemaQuery) {
			_userConnection = userConnection;
			Esq = entitySchemaQuery;
			TimeZoneOffset = 0;
		}

		#endregion

		#region Properties: Protected

		private readonly UserConnection _userConnection;
		protected UserConnection UserConnection
		{
			get
			{
				return _userConnection;
			}
		}

		protected JToken Parameters
		{
			get;
			private set;
		}

		protected int TimeZoneOffset
		{
			get;
			private set;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Dictionary with columns parameters.
		/// </summary>
		protected Dictionary<string, object> entityColumnsMap;
		public Dictionary<string, object> EntityColumnsMap
		{
			get
			{
				return entityColumnsMap;
			}
		}

		/// <summary>
		/// Entity schema query.
		/// </summary>
		public EntitySchemaQuery Esq
		{
			get;
			private set;
		}

		/// <summary>
		/// Entity schema query options.
		/// </summary>
		public EntitySchemaQueryOptions EsqOptions = null;

		#endregion

		#region Methods: Private

		private void SetParameterValueTimeZoneOffset(QueryParameter param) {
			if (param == null) {
				return;
			}
			Guid dataValueTypeUId = Guid.Empty;
			if (param.ValueType != null) {
				dataValueTypeUId = param.ValueType.UId;
			} else {
				if (param.Value is DateTime) {
					dataValueTypeUId = DataValueType.DateTimeDataValueTypeUId;
				} else if (param.Value is TimeSpan) {
					dataValueTypeUId = DataValueType.TimeDataValueTypeUId;
				}
			}
			if (dataValueTypeUId.Equals(DataValueType.TimeDataValueTypeUId)) {
				TimeSpan timeValue = (TimeSpan)param.Value;
				TimeSpan timeOffset = TimeSpan.FromMinutes(-TimeZoneOffset);
				param.Value = timeValue.Add(timeOffset);
			} else if (dataValueTypeUId.Equals(DataValueType.DateTimeDataValueTypeUId)) {
				DateTime value = (DateTime)param.Value;
				param.Value = value.AddMinutes(-TimeZoneOffset);
			}
		}

		private void UpdateConditions(QueryCondition conditions) {
			if (conditions.Count > 0) {
				foreach (QueryCondition condition in conditions) {
					UpdateConditions(condition);
				}
			} else {
				QueryColumnExpression leftExpression = conditions.LeftExpression;
				if (leftExpression != null) {
					SetParameterValueTimeZoneOffset(leftExpression.Parameter);
					var datePartFunction = leftExpression.Function as DatePartQueryFunction;
					if (datePartFunction != null) {
						datePartFunction.UtcOffset = TimeZoneOffset;
					}
				}
				if (conditions.RightExpressions != null) {
					foreach (QueryColumnExpression expression in conditions.RightExpressions) {
						SetParameterValueTimeZoneOffset(expression.Parameter);
						object function = expression.Function;
						if (function != null) {
							var expressionProperty = function.GetType().GetProperty("Expression");
							if (expressionProperty != null) {
								var functionExpression = (QueryColumnExpression)expressionProperty.GetValue(function, null);
								if (functionExpression != null) {
									SetParameterValueTimeZoneOffset(functionExpression.Parameter);
								}
							}
						}
					}
				}
			}
		}

		private void ApplyTimeZoneOffsetInColumnsCollection(QueryColumnExpressionCollection columns) {
			foreach (var column in columns) {
				var datePartFunction = column.Function as DatePartQueryFunction;
				if (datePartFunction != null) {
					datePartFunction.UtcOffset = TimeZoneOffset;
				}
			}
		}

		private void ApplyTimeZoneOffsetToDateTimeFunctions(Select select) {
			ApplyTimeZoneOffsetInColumnsCollection(select.Columns);
			ApplyTimeZoneOffsetInColumnsCollection(select.GroupByItems);
		}

		private void SetRigthExpression(EntitySchemaQueryFilter filter, object value) {
			filter.RightExpressions.Clear();
			EntitySchemaQueryExpression parameter =
				EntitySchemaQuery.CreateParameterExpression(value, filter.LeftExpression.SchemaColumn.DataValueType);
			filter.RightExpressions.Add(parameter);
		}

		private void ApplyFilterParameterByDateQueryFunction(DateTime currentDate, EntitySchemaQueryFilterCollection filters) {
			EntitySchemaQueryFilter firstFilter = (EntitySchemaQueryFilter)filters[0];
			EntitySchemaQueryFilter secondFilter = (EntitySchemaQueryFilter)filters[1];
			EntitySchemaQueryExpression firstExpression = firstFilter.RightExpressions[0];
			EntitySchemaQueryExpression secondExpression = secondFilter.RightExpressions[0];
			var firstFunction = firstExpression.Function as EntitySchemaBaseCurrentDateQueryFunction;
			var secondFunction = secondExpression.Function as EntitySchemaBaseCurrentDateQueryFunction;
			if (firstExpression.Function.GetType() == typeof(EntitySchemaCurrentDateQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.DateTimeToDate(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.DateTimeToDate(currentDate, secondFunction.Offset));
			} else if (firstExpression.Function.GetType() == typeof(EntitySchemaStartOfCurrentWeekQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.StartOfWeek(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.StartOfWeek(currentDate, secondFunction.Offset));
			} else if (firstExpression.Function.GetType() == typeof(EntitySchemaStartOfCurrentMonthQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.StartOfMonth(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.StartOfMonth(currentDate, secondFunction.Offset));
			} else if (firstExpression.Function.GetType() == typeof(EntitySchemaStartOfCurrentQuarterQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.StartOfQuarter(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.StartOfQuarter(currentDate, secondFunction.Offset));
			} else if (firstExpression.Function.GetType() == typeof(EntitySchemaStartOfCurrentHalfYearQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.StartOfHalfYear(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.StartOfHalfYear(currentDate, secondFunction.Offset));
			} else if (firstExpression.Function.GetType() == typeof(EntitySchemaStartOfCurrentYearQueryFunction)) {
				SetRigthExpression(firstFilter, DateTimeUtilities.StartOfYear(currentDate, firstFunction.Offset));
				SetRigthExpression(secondFilter, DateTimeUtilities.StartOfYear(currentDate, secondFunction.Offset));
			}
		}

		private bool IsDateMacrosFilter(EntitySchemaQueryFilterCollection filterCollection) {
			if (filterCollection.Count == 2) {
				var firstFilter = filterCollection[0] as EntitySchemaQueryFilter;
				var secondFilter = filterCollection[1] as EntitySchemaQueryFilter;
				if (firstFilter != null && firstFilter.RightExpressions.Count == 1 &&
						secondFilter != null && secondFilter.RightExpressions.Count == 1) {
					EntitySchemaQueryExpression firstExpression = firstFilter.RightExpressions[0];
					EntitySchemaQueryExpression secondExpression = secondFilter.RightExpressions[0];
					var firstFunction = firstExpression.Function as EntitySchemaBaseCurrentDateQueryFunction;
					var secondFunction = secondExpression.Function as EntitySchemaBaseCurrentDateQueryFunction;
					if (firstFunction != null && secondFunction != null) {
						return true;
					}
				}
			}
			return false;
		}

		private void ApplyDateOffsetForDateMacrosFilters(DateTime currentDate, EntitySchemaQueryFilterCollection filterCollection) {
			foreach (IEntitySchemaQueryFilterItem filterItem in filterCollection) {
				var subFilterCollection = filterItem as EntitySchemaQueryFilterCollection;
				if (subFilterCollection != null) {
					if (IsDateMacrosFilter(subFilterCollection)) {
						ApplyFilterParameterByDateQueryFunction(currentDate, subFilterCollection);
					} else {
						ApplyDateOffsetForDateMacrosFilters(currentDate, subFilterCollection);
					}
				}
			}
		}

		private void ApplyDateOffset(IEntitySchemaQueryFilterItem filterCollection) {
			var queryFilterCollection = filterCollection as EntitySchemaQueryFilterCollection;
			if (queryFilterCollection.Count == 0) {
				return;
			}
			int dateOffset = 0;
			DateTime serverDate = GetServerDateTime();
			double todayMinutesPassed = serverDate.TimeOfDay.TotalMinutes;
			if (todayMinutesPassed < -TimeZoneOffset) {
				dateOffset = -1;
			} else if ((todayMinutesPassed + TimeZoneOffset) > MinutesInDay) {
				dateOffset = 1;
			} else {
				return;
			}
			var currentDate = serverDate.Date.AddDays(dateOffset);
			ApplyDateOffsetForDateMacrosFilters(currentDate, queryFilterCollection);
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns current date and time on server.
		/// </summary>
		protected virtual DateTime GetServerDateTime() {
			return DateTime.UtcNow;
		}

		/// <summary>
		/// Returns CancellationToken for current request.
		/// </summary>
		protected virtual CancellationToken GetCancellationToken() {
			return HttpContext.Current.Response.ClientDisconnectedToken;
		}

		/// <summary>
		/// Returns column's data value type.
		/// </summary>
		protected int? GetColumnDataValueType(EntitySchemaQueryColumn column) {
			return GetColumnDataValueType(column.ValueExpression);
		}

		/// <summary>
		/// Returns column's data value type.
		/// </summary>
		protected int? GetColumnDataValueType(EntitySchemaQueryExpression expression) {
			if (expression.SchemaColumn == null) {
				return null;
			}
			DataValueType columnValueType = expression.SchemaColumn.DataValueType;
			return (int)BPMSoft.Nui.ServiceModel.Extensions.DataValueTypeExtension.ToEnum(columnValueType);
		}

		protected Dictionary<string, object> MapColumn(EntitySchemaQueryColumn column) {
			return MapColumn(column, column.Name + "Value");
		}
		
		protected Dictionary<string, object> MapColumn(EntitySchemaQueryColumn column, string valueAlias) {
			var map = new Dictionary<string, object>();
			map["valueAlias"] = valueAlias;
			column.SetForcedQueryColumnValueAlias(valueAlias);
			if (column.IsLookup) {
				map["isLookup"] = true;
				string displayValueAlias = valueAlias + "DisplayValue";
				map["displayValueAlias"] = displayValueAlias;
				column.SetForcedQueryDisplayColumnValueAlias(displayValueAlias);
			}
			if (column.ValueExpression.RootSchema != null) {
				var schemaColumn = column.ValueExpression.SchemaColumn;
				if (schemaColumn != null) {
					map["dataValueType"] = schemaColumn.DataValueType;
				}
			}
			return map;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Builds select query for data load.
		/// </summary>
		public virtual Select Build() {
			Select select;
			if (EsqOptions == null) {
				select = Esq.GetSelectQuery(UserConnection);
			} else {
				select = Esq.GetSelectQuery(UserConnection, EsqOptions);
			}
			ApplyTimeZoneOffsetToDateTimeFunctions(select);
			UpdateConditions(select.Condition);
			return select;
		}

		/// <summary>
		/// Applies filters to current entity schema query.
		/// </summary>
		public void AddFilterByJson(string filterData) {
			if (string.IsNullOrEmpty(filterData)) {
				return;
			}
			var userConnectionArgument = new ConstructorArgument("userConnection", UserConnection);
			var processDataContractFilterConverter = ClassFactory.Get<IProcessDataContractFilterConverter>(
				userConnectionArgument);
			IEntitySchemaQueryFilterItem filterCollection = processDataContractFilterConverter.
				ConvertToEntitySchemaQueryFilterItem(Esq, filterData);
			if (filterCollection != null) {
				ApplyDateOffset(filterCollection);
				Esq.Filters.Add(filterCollection);
			}
		}

		/// <summary>
		/// Adds filter to entity schema query.
		/// </summary>
		/// <param name="filterColumn">Column for filtration</param>
		/// <param name="filterValue">Filter value</param>
		public void AddFilter(string filterColumn, string filterValue) {
			if (filterValue.IsNotNullOrEmpty()) {
				var filter = Esq.CreateFilterWithParameters(FilterComparisonType.Equal, filterColumn, filterValue);
				Esq.Filters.Add(filter);
			}
		}

		/// <summary>
		/// Adds include filter to entity schema query.
		/// </summary>
		/// <param name="filterColumn">Column for filtration</param>
		/// <param name="recordIds">Filter values</param>
		public void AddIncludeFilter(string filterColumn, Guid[] recordIds) {
			if (recordIds != null && recordIds.Length > 0) {
				var filter = new EntitySchemaQueryFilter(FilterComparisonType.Equal) {
					LeftExpression = Esq.CreateSchemaColumnExpression(filterColumn)
				};
				recordIds.ForEach(recordId =>
					filter.RightExpressions.Add(EntitySchemaQuery.CreateParameterExpression(recordId)));
				Esq.Filters.Add(filter);
			}
		}

		#endregion

	}

	#endregion

	#region Class: BaseDashboardItemData

	/// <summary>
	/// Base class of dashboard widget.
	/// </summary>
	public class BaseDashboardItemData : IDashboardItemData
	{

		#region Constructor: Public

		public BaseDashboardItemData(string name, JObject config, UserConnection userConnection, int timeZoneOffset) {
			_config = config;
			_parameters = Config.Value<JToken>("parameters");
			_userConnection = userConnection;
			Name = name;
			Caption = _parameters.Value<string>("caption");
			WidgetType = Config.Value<string>("widgetType");
			TimeZoneOffset = timeZoneOffset;
			BindingColumnValue = null;
		}

		public BaseDashboardItemData(string name, JObject config, string bindingColumnValue, UserConnection userConnection, int timeZoneOffset)
			: this(name, config, userConnection, timeZoneOffset){
			BindingColumnValue = bindingColumnValue;
		}

		#endregion

		#region Properties: Protected

		protected virtual List<string> DataProperties
		{
			get
			{
				return new List<string> {"caption", "entitySchemaName", "filterData", "sectionId", "schemaName",
						"sectionBindingColumn", "primaryColumnName", "orderDirection"};
			}
		}

		protected virtual string SchemaNameProperty
		{
			get
			{
				return "entitySchemaName";
			}
		}

		protected string BindingColumnValue
		{
			get;
			private set;
		}

		protected virtual string SectionBindingColumnProperty
		{
			get
			{
				return "sectionBindingColumn";
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// User connection. 
		/// </summary>
		protected UserConnection _userConnection;
		public UserConnection UserConnection
		{
			get
			{
				return _userConnection;
			}
		}

		private readonly JObject _config;
		public JObject Config
		{
			get
			{
				return _config;
			}
		}

		private readonly JToken _parameters;
		public JToken Parameters
		{
			get
			{
				return _parameters;
			}
		}

		/// <summary>
		/// Dashboard item name.
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Dashboard item caption.
		/// </summary>
		public string Caption
		{
			get;
			private set;
		}

		/// <summary>
		/// Dashboard item widget type.
		/// </summary>
		public string WidgetType
		{
			get;
			protected set;
		}

		/// <summary>
		/// Time zone offset.
		/// </summary>
		public int TimeZoneOffset
		{
			get;
			private set;
		}

		#endregion

		#region Methods: Private

		private JObject GetLookupValueByColumnMap(object value, IDataReader dataReader, Dictionary<string, object> columnMap) {
			var lookupValue = new JObject();
			lookupValue.Add(new JProperty("displayValue",
				dataReader.GetColumnValue((string)columnMap["displayValueAlias"])));
			lookupValue.Add(new JProperty("value", value));
			return lookupValue;
		}

		private JObject GetPrimaryDisplayValueByColumnMap(object value, IDataReader dataReader, Dictionary<string, object> columnMap) {
			var primaryDisplayColumnValue = new JObject();
			primaryDisplayColumnValue.Add(new JProperty("value",
				dataReader.GetColumnValue((string)columnMap["primaryKeyColumnAlias"])));
			primaryDisplayColumnValue.Add(new JProperty("displayValue", value));
			return primaryDisplayColumnValue;
		}

		private bool TryParseDateTimeValue(object value, out object result) {
			result = value;
			if (value is TimeSpan) {
				result = DateTime.MinValue + (TimeSpan)value;
			}
			if (result is DateTime) {
				result = ((DateTime)result).ToString("u");
				return true;
			}
			return false;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns column's value.
		/// </summary>
		protected object GetValueByColumnMap(IDataReader dataReader, Dictionary<string, object> columnMap) {
			object value = dataReader.GetColumnValue((string)columnMap["valueAlias"]);
			if (columnMap.ContainsKey("isLookup")) {
				return GetLookupValueByColumnMap(value, dataReader, columnMap);
			}
			if (columnMap.ContainsKey("isPrimaryDisplayColumn")) {
				return GetPrimaryDisplayValueByColumnMap(value, dataReader, columnMap);
			}
			object parsedValue;
			if (TryParseDateTimeValue(value, out parsedValue)) {
				return parsedValue;
			} else {
				return value;
			}
		}

		/// <summary>
		/// Copies all non data properties to item.
		/// </summary>
		protected void CopyProperties(JObject itemObject) {
			List<string> dataProperties = DataProperties;
			foreach (JProperty viewProperty in Parameters) {
				if (!dataProperties.Contains(viewProperty.Name)) {
					itemObject[viewProperty.Name] = viewProperty.Value;
				}
			}
		}

		/// <summary>
		/// Returns entity schema name.
		/// </summary>
		protected string GetSchemaName() {
			return Parameters.Value<string>(SchemaNameProperty);
		}

		/// <summary>
		/// Returns entity schema caption.
		/// </summary>
		protected string GetSchemaCaption(string schemaName) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			return schema.Caption;
		}

		/// <summary>
		/// Applies filters by parent records.
		/// </summary>
		protected void ApplySectionBindingFilter(BaseDashboardItemSelectBuilder builder, JToken parameters = null) {
			if (parameters == null) {
				parameters = Parameters;
			}
			var sectionBindingColumn = parameters.Value<string>(SectionBindingColumnProperty);
			if (sectionBindingColumn.IsNotNullOrEmpty()) {
				builder.AddFilter(sectionBindingColumn, BindingColumnValue);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns data for dashboard item.
		/// </summary>
		public virtual JObject GetJson()  {
			var itemObject = new JObject();
			itemObject["name"] = Name;
			itemObject["caption"] = Caption;
			itemObject["widgetType"] = WidgetType;
			return itemObject;
		}

		#endregion

	}

	#endregion

}
