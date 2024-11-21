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

	#region Class: GridDashboardItemData

	/// <summary>
	/// Grid dashboard widget.
	/// </summary>
	[DashboardItemData("DashboardGrid")]
	public class GridDashboardItemData : BaseDashboardItemData
	{

		#region Constructor: Public

		public GridDashboardItemData(string name, JObject config, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, userConnection, timeZoneOffset) {
		}

		public GridDashboardItemData(string name, JObject config, string bindingColumnValue, UserConnection userConnection, int timeZoneOffset)
			: base(name, config, bindingColumnValue, userConnection, timeZoneOffset) {
		}

		#endregion

		#region Properties: Protected

		protected DashboardGridDataSelectBuilder selectBuilder;

		#endregion

		#region Properties: Protected

		protected override List<string> DataProperties
		{
			get
			{
				List<string> dataProperties = base.DataProperties;
				dataProperties.AddRange(new List<string> { "orderColumn", "rowCount", "gridConfig" });
				return dataProperties;
			}
		}

		#endregion

		#region Methods: Private

		private JArray GetData() {
			var data = new JArray();
			if (string.IsNullOrEmpty(GetSchemaName())) {
				return data;
			}
			DashboardGridDataSelectBuilder selectBuilder = GetSelectBuilder();
			ApplySectionBindingFilter(selectBuilder);
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

		private JArray GetColumns() {
			var columns = new JArray();
			JArray items = GetGridConfigColumns();
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName(GetSchemaName());
			string primaryDisplayColumnName = entitySchema.FindPrimaryDisplayColumnName();
			string primaryKeyColumnName = entitySchema.GetPrimaryColumnName();
			string primaryColumnAlias = string.Empty;
			foreach (JObject columnItem in items) {
				string columnPath = DashboardDataUtils.GetColumnPath(columnItem);
				string columnCaption = columnItem.Value<string>("caption");
				if (string.IsNullOrEmpty(columnCaption)) {
					columnCaption = columnPath;
				}
				var columnConfig = new JObject();
				columnConfig["name"] = columnPath;
				columnConfig["caption"] = columnCaption;
				columnConfig["type"] = columnItem.Value<string>("type");
				columnConfig["position"] = columnItem["position"];
				if (string.IsNullOrEmpty(columnItem.Value<string>("dataValueType"))) {
					Dictionary<string, object> map = (Dictionary<string, object>)selectBuilder.EntityColumnsMap[columnPath];
					var type = (DataValueType)map["dataValueType"];
					columnConfig["dataValueType"] = (int)BPMSoft.Nui.ServiceModel.Extensions.DataValueTypeExtension.ToEnum(type);
				} else {
					columnConfig["dataValueType"] = columnItem.Value<int>("dataValueType");
				}
				if (columnPath != primaryDisplayColumnName) {
					columnConfig["referenceSchemaName"] = columnItem.Value<string>("referenceSchemaName");
				}
				columns.Add(columnConfig);
			}
			return columns;
		}

		private JArray GetGridConfigColumns() {
			JToken gridConfig = Parameters.Value<JToken>("gridConfig");
			return gridConfig.Value<JArray>("items");
		}

		#endregion

		#region Methods: Protected

		protected virtual DashboardGridDataSelectBuilder CreateSelectBuilder(JArray columns) {
			selectBuilder = new DashboardGridDataSelectBuilder(UserConnection, GetSchemaName(), TimeZoneOffset, columns);
			return selectBuilder;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns data for datagrid dashboard item.
		/// </summary>
		public override JObject GetJson() {
			JObject itemObject = base.GetJson();
			CopyProperties(itemObject);
			itemObject["data"] = GetData();
			itemObject["columns"] = GetColumns();
			itemObject["schemaName"] = GetSchemaName();
			return itemObject;
		}

		/// <summary>
		/// Returns instance of select builder.
		/// </summary>
		public virtual DashboardGridDataSelectBuilder GetSelectBuilder() {
			JArray columns = GetGridConfigColumns();
			var builder = CreateSelectBuilder(columns);
			if (!string.IsNullOrEmpty(Parameters.Value<string>("rowCount"))) {
				builder.Esq.RowCount = Parameters.Value<int>("rowCount");
			}
			string filterData = Parameters.Value<string>("filterData");
			builder.AddFilterByJson(filterData);
			return builder;
		}

		#endregion

	}

	#endregion

}
