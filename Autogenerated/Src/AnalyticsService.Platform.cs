namespace BPMSoft.Configuration.AnalyticsService
{
	using System;
	using System.IO;
	using System.Text;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	/// <summary>
	/// Provides web-service for work with dashboard data.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class AnalyticsService: BaseService, System.Web.SessionState.IReadOnlySessionState
	{

		#region Methods: Private

		private MemoryStream GetResponseStream(JToken json) {
			string responseBody = json != null ? json.ToString() : string.Empty;
			string contentType = "application/json; charset=utf-8";
			byte[] data = Encoding.UTF8.GetBytes(responseBody);
#if !NETSTANDARD2_0
			WebOperationContext.Current.OutgoingResponse.ContentType = contentType;
#else
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			httpContext.Response.ContentType = contentType;
			httpContext.Response.Headers["Content-Length"] = data.Length.ToString();
#endif
			return new MemoryStream(data);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns dashboard's view config by id.
		/// </summary>
		/// <param name="id">Dashboard id.</param>
		/// <returns>JSON data with view config of dashboard.</returns>
		/// <remarks>Result parameter name "items".</remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDashboardViewConfig", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetDashboardViewConfig(Guid id) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JObject json = utils.GetDashboardViewConfig(id);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns dashboard's data by id.
		/// </summary>
		/// <param name="id">Dashboard id.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <returns>JSON data with config and data of dashboard.</returns>
		/// <remarks>Result parameter name "items".</remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDashboardData", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetDashboardData(Guid id, int timeZoneOffset) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JObject json = utils.GetDashboardData(id, timeZoneOffset);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns dashboard item data by name.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <returns>JSON data with config and data of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDashboardItemData", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetDashboardItemData(Guid dashboardId, string itemName, int timeZoneOffset) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JObject json = utils.GetDashboardItemData(dashboardId, itemName, timeZoneOffset);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns dashboard item data by parent records filter.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <param name="bindingColumnValue">Value for section binding filter.</param>
		/// <returns>JSON data with config and data of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetDashboardItemDataForSection", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetDashboardItemDataForSection(Guid dashboardId, string itemName, int timeZoneOffset, string bindingColumnValue) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JObject json = utils.GetDashboardItemDataForSection(dashboardId, itemName, timeZoneOffset, bindingColumnValue);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns chart's display data.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Count of skipped rows.</param>
		/// <param name="serieIndex">Index of serie.</param>
		/// <returns>JSON data with config and data of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChartGridData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetChartGridData(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount,
				int rowOffset, int serieIndex) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JToken json = utils.GetChartGridData(dashboardId, itemName, timeZoneOffset, rowCount, rowOffset,
				serieIndex);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns chart's filtered display data.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Count of skipped rows.</param>
		/// <param name="filterValue">Value of filter.</param>
		/// <param name="serieIndex">Index of serie.</param>
		/// <returns>JSON data with config and data of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChartGridDataByFilter", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetChartGridDataByFilter(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount,
				int rowOffset, string filterValue, int serieIndex) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JToken json = utils.GetChartGridDataByFilter(dashboardId, itemName, timeZoneOffset, rowCount, rowOffset,
				filterValue, serieIndex);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns chart's display data columns config.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <returns>JSON data with columns config of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetChartGridDataConfigs", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetChartGridDataConfigs(Guid dashboardId, string itemName) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JArray json = utils.GetChartGridDataConfigs(dashboardId, itemName);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns indicator's display data columns config.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <returns>JSON data with columns config of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIndicatorGridDataConfig", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetIndicatorGridDataConfig(Guid dashboardId, string itemName) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JObject json = utils.GetIndicatorGridDataConfig(dashboardId, itemName);
			return GetResponseStream(json);
		}

		/// <summary>
		/// Returns indicator's display data.
		/// </summary>
		/// <param name="dashboardId">Dashboard id.</param>
		/// <param name="itemName">Dashboard item name.</param>
		/// <param name="timeZoneOffset">Time zone offset in minutes.</param>
		/// <param name="rowCount">Count of rows.</param>
		/// <param name="rowOffset">Count of skipped rows.</param>
		/// <returns>JSON data with config and data of dashboard item.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIndicatorGridData", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Stream GetIndicatorGridData(Guid dashboardId, string itemName, int timeZoneOffset, int rowCount,
				int rowOffset) {
			var utils = new AnalyticsServiceUtils(UserConnection);
			JToken json = utils.GetIndicatorGridData(dashboardId, itemName, timeZoneOffset, rowCount, rowOffset);
			return GetResponseStream(json);
		}

		#endregion

	}

}

