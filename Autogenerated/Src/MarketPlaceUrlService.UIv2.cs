namespace BPMSoft.Configuration
{
	using System;
	using System.Net;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MarketPlaceUrlService : BaseService, IReadOnlySessionState {

		#region Fields: Private

		private string _urlTemplate = null;
		private string _userCulture = null;
		private string _customerId = null;

		#endregion

		#region Properties: Public

		public string UrlTemplate {
			get {
				return _urlTemplate ?? GlobalAppSettings.MarketPlaceUrlTemplate;
			}
		}

		public string CurrentUserCulture {
			get {
				return _userCulture ?? UserConnection.CurrentUser.Culture.Name;
			}
		}

		public string CustomerId {
			get {
				//TODO
				return _customerId ?? "0";
			}
		}

		#endregion

		#region Constructor: Public
		public MarketPlaceUrlService() { }

		public MarketPlaceUrlService(string urlTemplate, string userCulture, string customerId) {
			_urlTemplate = urlTemplate;
			_userCulture = userCulture;
			_customerId = customerId;
		}

		#endregion

		#region Methods: Private

		private string GetUrlValidated(string url) {
			Uri validUri;
			Uri.TryCreate(url, UriKind.Absolute, out validUri);
			return validUri?.AbsoluteUri;
		}

		private bool GetUrlIsAvailable(string url) {
			var request = (HttpWebRequest)(WebRequest.Create(url));
			var isAvailable = false;
			using (var response = (HttpWebResponse)request.GetResponse()) {
				isAvailable = ((int)response.StatusCode < 400);
			}
			return isAvailable;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get url for MarketPlace widget.
		/// </summary>
		/// <returns>URL string.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetUrlMarketPlace", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string GetUrlMarketPlace(string productCode) {
			
			if (string.IsNullOrEmpty(productCode)) {
				
				return null;
				
			}
			
			var urlWithParam = string.Format(UrlTemplate, CurrentUserCulture, productCode, CustomerId);
			var marketPlaceUrl = GetUrlValidated(urlWithParam);
			try {
				if (!string.IsNullOrEmpty(marketPlaceUrl) && GetUrlIsAvailable(marketPlaceUrl)) {
					return marketPlaceUrl;
				} else {
					return null;
				}
			} catch {
				return null;
			}
		}

		#endregion

	}
}
