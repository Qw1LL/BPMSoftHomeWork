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


	#region Class: GaugeDashboardSelectBuilder

	public class GaugeDashboardItemSelectBuilder : BaseDashboardItemSelectBuilder
	{

		#region Constructor: Public

		public GaugeDashboardItemSelectBuilder(UserConnection userConnection, string schemaName, int timeZoneOffset, JToken parameters)
			: base(userConnection, schemaName, timeZoneOffset, parameters) {
		}

		#endregion

		#region Properties: Public

		public Dictionary<string, object> EntityColumnMap;

		public int? ColumnDataValueType;

		#endregion

		#region Methods: Public

		public override Select Build() {
			string columnPath = Parameters.Value<string>("aggregationColumn");
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

	#region Class: GaugeDashboardItemData

	/// <summary>
	/// Indicator dashboard widget.
	/// </summary>
	[DashboardItemData("Gauge")]
	public class GaugeDashboardItemData : BaseDashboardItemData
	{
		#region Constructor: Public

		public GaugeDashboardItemData(string name, JObject config, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, userConnection, timeZoneOffset) {
		}

		public GaugeDashboardItemData(string name, JObject config, string bindingColumnValue, UserConnection userConnection, int timeZoneOffset)
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

		private object GetData(GaugeDashboardItemSelectBuilder dashboardSelectBuilder) {
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
			GaugeDashboardItemSelectBuilder selectBuilder = GetSelectBuilder();
			object value = GetData(selectBuilder);
			itemObject["dataValueType"] = selectBuilder.ColumnDataValueType;
			itemObject.Add(new JProperty("data", value));
			itemObject["min"] = Parameters.Value<int?>("min");
			itemObject["middleFrom"] = Parameters.Value<int?>("middleFrom");
			itemObject["middleTo"] = Parameters.Value<int?>("middleTo");
			itemObject["max"] = Parameters.Value<int?>("max");
			itemObject["orderDirection"] = Parameters.Value<int?>("orderDirection");
			return itemObject;
		}

		/// <summary>
		/// Returns instance of select builder.
		/// </summary>
		public virtual GaugeDashboardItemSelectBuilder GetSelectBuilder() {
			return new GaugeDashboardItemSelectBuilder(UserConnection, GetSchemaName(), TimeZoneOffset, Parameters);
		}

		#endregion

	}

	#endregion

}
