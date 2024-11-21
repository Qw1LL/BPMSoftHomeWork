namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;
	using BPMSoft.Core;
	using CoreConfig = Core.Configuration;

	#region Class: AccountSocialLeadGenRestProvider

	/// <summary>
	/// Provide information from account service.
	/// </summary>
	public class AccountSocialLeadGenRestProvider : SocialLeadGenRestProvider
	{

		#region Properties: Private

		/// <summary>
		/// System settings name for base tenant service url.
		/// </summary>
		private readonly string _socialAccountServiceUrlSysSettingCode = "SocialAccountServiceUrl";

		#endregion

		#region Properties: Private

		/// <summary>
		/// Tenant service url value.
		/// </summary>
		private string SocialAccountServiceUrl {
			get {
				return CoreConfig.SysSettings.GetValue(UserConnection, _socialAccountServiceUrlSysSettingCode).ToString();
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor of a class.
		/// </summary>
		/// <param name="userConnection">Instance of UserConnection.</param>
		public AccountSocialLeadGenRestProvider(UserConnection userConnection)
			: base(userConnection) { }

		#endregion

		#region Methods: Public

		public void CreateAccount(string bpmstudioUrl, bool pingBPMStudioInstance) {
			string url = $"{SocialAccountServiceUrl}/api/account/create";
			var data = new {
				BPMStudioUrl = bpmstudioUrl,
				PingBPMStudioInstance = pingBPMStudioInstance,
				IsActive = true
			};
			SendTokenizedPostRequest<SocialLeadGenRestProviderResponse>(url, data);
		}

		public void UpdateAccount(string bpmstudioUrl, bool pingBPMStudioInstance) {
			string url = $"{SocialAccountServiceUrl}/api/account/update";
			var data = new {
				BPMStudioUrl = bpmstudioUrl,
				PingBPMStudioInstance = pingBPMStudioInstance,
				IsActive = true
			};
			SendTokenizedPostRequest<SocialLeadGenRestProviderResponse>(url, data);
		}

		public AccountRestResponse GetMyAccount() {
			string url = $"{SocialAccountServiceUrl}/api/account/me";
			var response = SendTokenizedPostRequest<AccountRestResponse>(url, null);
			return response;
		}

		public LandingInfoRestResponse FindWebForm(Guid webFormId) {
			string url = $"{SocialAccountServiceUrl}/api/bpmstudio/webForms/find";
			var data = new LandingInfoRestRequest {
				BPMStudioWebFormId = webFormId
			};
			var response = SendTokenizedPostRequest<LandingInfoRestResponse>(url, data);
			return response;
		}

		public void UnsubscribeWebForm(Guid webFormId) {
			string url = $"{SocialAccountServiceUrl}/api/bpmstudio/webForms/unsubscribe";
			var data = new LandingUnsubscribeRestRequest {
				BPMStudioWebFormId = webFormId
			};
			SendTokenizedPostRequest<LandingInfoRestResponse>(url, data);
		}

		public string GenerateSessionToken() {
			string url = $"{SocialAccountServiceUrl}/api/account/generateSessionToken";
			var response = SendTokenizedPostRequest<SessionTokenRestResponse>(url, null);
			return response.SessionToken;
		}

		/// <summary>
		/// Calls API of account service for retrieve list of integrations.
		/// </summary>
		/// <returns>Instace of <see cref="IntegrationListResponse">IntegrationListResponse</see> class.</returns>
		public IntegrationListResponse GetIntegrationList() {
			string url = $"{SocialAccountServiceUrl}/api/integration/list";
			var response = SendTokenizedPostRequest<IntegrationListResponse>(url, null);
			return response;
		}

		/// <summary>
		/// Calls API of account service for create integration.
		/// </summary>
		public void CreateIntegration(Integration integration) {
			string url = $"{SocialAccountServiceUrl}/api/integration/create";
			var data = new IntegrationRequest { IntegrationData = integration };
			SendTokenizedPostRequest<SocialLeadGenRestProviderResponse>(url, data);
		}

		/// <summary>
		/// Calls API of account service for update integration.
		/// </summary>
		public void UpdateIntegration(Integration integration) {
			string url = $"{SocialAccountServiceUrl}/api/integration/update";
			var data = new IntegrationRequest { IntegrationData = integration };
			SendTokenizedPostRequest<SocialLeadGenRestProviderResponse>(url, data);
		}


		/// <summary>
		/// Calls API of account service for retrieve integration.
		/// </summary>
		/// <param name="id">Id of integration.</param>
		/// <returns>Instace of <see cref="IntegrationResponse">IntegrationResponse</see> class.</returns>
		public IntegrationResponse GetIntegration(Guid id) {
			string url = $"{SocialAccountServiceUrl}/api/integration/get";
			var data = new {
				id = id,
				actualizeFormsFromLinkedIn = true
			};
			var response = SendTokenizedPostRequest<IntegrationResponse>(url, data);
			return response;
		}

		/// <summary>
		/// Calls API of account service for retrieve list of ad accounts.
		/// </summary>
		/// <returns>Instace of <see cref="LinkedInAdAccountListResponse">LinkedInAdAccountListResponse</see> class.</returns>
		public LinkedInAdAccountListResponse GetLinkedInAdAccounts() {
			string url = $"{SocialAccountServiceUrl}/api/linkedIn/adAccount/list";
			var response = SendTokenizedPostRequest<LinkedInAdAccountListResponse>(url, null);
			return response;
		}

		/// <summary>
		/// Calls API of account service for retrieve aggregated list of predefined fields.
		/// </summary>
		/// <returns>Instace of <see cref="LinkedInAdAccountListResponse">LinkedInAdAccountListResponse</see> class.</returns>
		public AccountApiPredefinedFieldsResponse GetLinkedInPredefinedField(string adAccountId) {
			string url = $"{SocialAccountServiceUrl}/api/linkedIn/form/predefinedFields";
			var data = new {
				adAccountId = adAccountId
			};
			var response = SendTokenizedPostRequest<AccountApiPredefinedFieldsResponse>(url, data);
			return response;
		}

		/// <summary>
		/// Calls API of account service for retrieve form fields.
		/// </summary>
		/// <returns>Instace of <see cref="LinkedInAdAccountListResponse">LinkedInAdAccountListResponse</see> class.</returns>
		public AccountApiFormFieldsResponse GetLinkedInFormFields(string adAccountId, long formId) {
			string url = $"{SocialAccountServiceUrl}/api/linkedIn/form/formFields";
			var data = new {
				adAccountId = adAccountId,
				formId = formId
			};
			var response = SendTokenizedPostRequest<AccountApiFormFieldsResponse>(url, data);
			return response;
		}

		/// <summary>
		/// Calls API of account service for list of forms for AdAccount.
		/// </summary>
		/// <returns>Instace of <see cref="AccountApiFormListResponse">AccountApiFormListResponse</see> class.</returns>
		public AccountApiFormListResponse GetLinkedInForms(string adAccountId) {
			string url = $"{SocialAccountServiceUrl}/api/linkedIn/form/list";
			var data = new {
				adAccountId
			};
			var response = SendTokenizedPostRequest<AccountApiFormListResponse>(url, data);
			return response;
		}

		/// <summary>
		/// Calls directly API of account service.
		/// </summary>
		/// <param name="url">Destination url.</param>
		/// <param name="data">Destination request data.</param>
		/// <returns>Raw response as string.</returns>
		public string ProxyRequest(string url, string data) {
			string fullUrl = $"{SocialAccountServiceUrl}{url}";
			var response = SendTokenizedPostRequest(fullUrl, data);
			return response;
		}

		#endregion

	}

	#endregion

}
