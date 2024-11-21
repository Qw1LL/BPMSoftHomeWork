namespace BPMSoft.Configuration
{
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.ComponentSpace.Interfaces;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Services;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.SSO.OpenId;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: MainMenuService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class MainMenuService : BaseService
	{

		#region Properties: Private

		private HttpContext Context { get; set; } = HttpContext.Current;

		#endregion

		#region Methods: Public

		private void FireLogoutEvents() {
			var logoutEventHandlers = ClassFactory.GetAll<ILogoutEventHandler>();
			foreach (var logoutHandler in logoutEventHandlers) {
				logoutHandler.HandleEvent(UserConnection);
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Logout", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "RedirectLocation")]
		public string Logout() {
			var samlProviderApi = ClassFactory.Get<ISamlServiceProviderApi>();
			IOpenIdAuthorizeInitiator openIdAuthorizeInitiator = ClassFactory.Get<IOpenIdAuthorizeInitiator>();
			var result = string.Empty;
			if (samlProviderApi.GetCanDoSlo()) {
				result = samlProviderApi.InitiateSlo();
			} else if (openIdAuthorizeInitiator.IsAuthenticatedUsingOpenId(UserConnection)) {
				result = openIdAuthorizeInitiator.GetOpenIdEndSessionUrl(UserConnection);
			}
			if (result.IsNullOrEmpty()) {
				FireLogoutEvents();
				var userSessionManager = ClassFactory.Get<IUserSessionManager>();
				userSessionManager.Logout();
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "LogoutOpenId", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "RedirectLocation")]
		public string LogoutOpenId(string redirectUrl) {
			IOpenIdAuthorizeInitiator openIdAuthorizeInitiator = ClassFactory.Get<IOpenIdAuthorizeInitiator>();
			var result = string.Empty;
			if (openIdAuthorizeInitiator.IsAuthenticatedUsingOpenId(UserConnection)) {
				result = openIdAuthorizeInitiator.GetOpenIdEndSessionUrl(UserConnection, redirectUrl);
			}
			if (result.IsNullOrEmpty()) {
				FireLogoutEvents();
				var userSessionManager = ClassFactory.Get<IUserSessionManager>();
				userSessionManager.Logout();
			}
			return result;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetCanAccessConfigurationSettings", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool GetCanAccessConfigurationSettings() {
			var operations = new string[] {
				"CanManageAdministration",
				"CanManageProcessDesign",
				"CanManageChangeLog",
				"CanManageSolution",
				"CanManageLookups",
				"CanViewConfiguration"
			};
			var result = false;
			foreach (var operation in operations) {
				result = result || UserConnection.DBSecurityEngine.GetCanExecuteOperation(operation);
				if (result) {
					break;
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}
