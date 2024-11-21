namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common.Json;
	using BPMSoft.Core.Entities;

	#region Class: AnalyticsServiceUtils

	/// <summary>
	/// Provides methods for retrieving dashboard configs and data.
	/// </summary>
	public class AnalyticsServiceUtils {
		

		#region Constructor: Public

		public AnalyticsServiceUtils(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection. 
		/// </summary>
		private readonly UserConnection _userConnection;
		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		#endregion

		#region Methods: Private

		private JObject FetchDashboardItemsData(Guid id) {
			EntitySchema dashboardSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysDashboard");
			Entity dashboardEntity = dashboardSchema.CreateEntity(UserConnection);
			string itemsStr = string.Empty;
			string viewConfigStr = string.Empty;
			if (dashboardEntity.FetchFromDB(dashboardSchema.PrimaryColumn.ColumnValueName, id,
					new List<string> { "Items", "ViewConfig" })) {
				itemsStr = dashboardEntity.GetTypedColumnValue<string>("Items");
				viewConfigStr = dashboardEntity.GetTypedColumnValue<string>("ViewConfig");
			}
			if (!string.IsNullOrEmpty(itemsStr)) {
				var result = new JObject();
				result.Add(new JProperty("items", Json.Deserialize(itemsStr)));
				result.Add(new JProperty("viewConfig", Json.Deserialize(viewConfigStr)));
				return result;
			} 
			return null;
		}

		private IDashboardItemData GetDashboardItemDataInstance(string widgetType, string dashboardName, JObject config, int timeZoneOffset) {
			var factory = new DashboardItemDataFactory(_userConnection);
			IDashboardItemData instance = factory.CreateInstance(widgetType, dashboardName, config, timeZoneOffset);
			if (instance == null) {
				instance = factory.CreateConcreteInstance(typeof(BaseDashboardItemData), dashboardName, config, timeZoneOffset);
			}
			return instance;
		}

		private JObject GetDashboardItemJSON(string dashboardName, JObject config, int timeZoneOffset) {
			string widgetType = config.Value<string>("widgetType");
			IDashboardItemData instance = GetDashboardItemDataInstance(widgetType, dashboardName, config, timeZoneOffset);
			return instance.GetJson();
		}

		private JObject GetDashboardItemJSONForSection(string dashboardName, JObject config, string bindingColumnValue, int timeZoneOffset) {
			string widgetType = config.Value<string>("widgetType");
			var factory = new DashboardItemDataFactory(_userConnection);
			IDashboardItemData instance = factory.CreateInstance(widgetType, dashboardName, config, bindingColumnValue, timeZoneOffset);
			return instance.GetJson();
		}

		private JObject GetDashboardItemConfig(Guid dashboardId, string itemName) {
			JObject config = FetchDashboardItemsData(dashboardId);
			if (config == null) {
				return null;
			}
			JToken dashboards = config.Value<JToken>("items");
			return dashboards.Value<JObject>(itemName);
		}

		#endregion

		#region Methods: Protected

		protected virtual ChartDashboardItemData GetChartDashboardItemData(string itemName, JObject itemConfig, int timeZoneOffset) {
			return new ChartDashboardItemData(itemName, itemConfig, UserConnection, timeZoneOffset);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns view config for dashboard.
		/// </summary>
		public JObject GetDashboardViewConfig(Guid id) {
			var result = new JObject();
			var items = new JArray();
			JObject config = FetchDashboardItemsData(id);
			if (config != null) {
				JToken dashboards = config.Value<JToken>("items");
				JArray viewConfigs = config.Value<JArray>("viewConfig");
				foreach (JObject viewConfig in viewConfigs) {
					string dashboardName = viewConfig.Value<string>("name");
					JObject value = dashboards.Value<JObject>(dashboardName);
					if (value == null) {
						continue;
					}
					JObject item = (JObject)viewConfig.DeepClone();
					item["widgetType"] = value.Value<string>("widgetType");
					items.Add(item);
				}
			}
			result["items"] = items;
			return result;
		}

		/// <summary>
		/// Returns config and data for dashboard.
		/// </summary>
		public JObject GetDashboardData(Guid id, int timeZoneOffset) {
			var result = new JObject();
			var items = new JArray();
			JObject config = FetchDashboardItemsData(id);
			if (config != null) {
				JToken dashboards = config.Value<JToken>("items");
				JArray viewConfig = config.Value<JArray>("viewConfig");
				foreach (JObject item in viewConfig) {
					string dashboardName = item.Value<string>("name");
					JObject value = dashboards.Value<JObject>(dashboardName);
					if (value == null) {
						continue;
					}
					items.Add(GetDashboardItemJSON(dashboardName, value, timeZoneOffset));
				}
			}
			result["items"] = items;
			return result;
		}

		/// <summary>
		/// Returns config and data for dashboard item.
		/// </summary>
		public JObject GetDashboardItemData(Guid dashboardId, string itemName, int timeZoneOffset) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName); 
			if (itemConfig == null) {
				return null;
			}
			return GetDashboardItemJSON(itemName, itemConfig, timeZoneOffset);
		}

		/// <summary>
		/// Returns config and data for dashboard item.
		/// </summary>
		public JObject GetDashboardItemDataForSection(Guid dashboardId, string itemName, int timeZoneOffset, string bindingColumnValue) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName); 
			if (itemConfig == null) {
				return null;
			}
			return GetDashboardItemJSONForSection(itemName, itemConfig, bindingColumnValue, timeZoneOffset);
		}

		/// <summary>
		/// Returns grid data for chart item.
		/// </summary>
		public JArray GetChartGridData(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount,
				int rowOffset, int serieIndex) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName); 
			if (itemConfig == null) {
				return null;
			}
			ChartDashboardItemData chartDashboardItemData = GetChartDashboardItemData(itemName, itemConfig,
				timeZoneOffset);
			return chartDashboardItemData.GetGridData(rowCount, rowOffset, serieIndex);
		}

		/// <summary>
		/// Returns grid data for chart item by filter.
		/// </summary>
		public JArray GetChartGridDataByFilter(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount,
				int rowOffset, string filterValue, int serieIndex) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName);
			if (itemConfig == null) {
				return null;
			}
			ChartDashboardItemData chartDashboardItemData = GetChartDashboardItemData(itemName, itemConfig,
				timeZoneOffset);
			return chartDashboardItemData.GetGridDataByFilter(rowCount, rowOffset, filterValue, serieIndex);
		}

		/// <summary>
		/// Returns data columns config for chart item.
		/// </summary>
		public JArray GetChartGridDataConfigs(Guid dashboardId, string itemName) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName);
			if (itemConfig == null) {
				return null;
			}
			ChartDashboardItemData chartDashboardItemData = GetChartDashboardItemData(itemName, itemConfig, 0);
			return chartDashboardItemData.GetGridDataConfigs();
		}

		/// <summary>
		/// Returns data columns config for indicator item.
		/// </summary>
		public JObject GetIndicatorGridDataConfig(Guid dashboardId, string itemName) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName);
			if (itemConfig == null) {
				return null;
			}
			IndicatorDashboardItemData dashboardItemData = new IndicatorDashboardItemData(itemName, itemConfig, UserConnection, 0);
			return dashboardItemData.GetGridDataConfig();
		}

		/// <summary>
		/// Returns config and grid data for indicator item.
		/// </summary>
		public JArray GetIndicatorGridData(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount, int rowOffset) {
			JObject itemConfig = GetDashboardItemConfig(dashboardId, itemName);
			if (itemConfig == null) {
				return null;
			}
			IndicatorDashboardItemData dashboardItemData = new IndicatorDashboardItemData(itemName, itemConfig, UserConnection,
				timeZoneOffset);
			return dashboardItemData.GetGridData(rowCount, rowOffset);
		}

		#endregion

	}

	#endregion

}
