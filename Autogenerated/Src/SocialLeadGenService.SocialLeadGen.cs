namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using static BPMSoft.Configuration.SocialLeadGen.Integration.MetadataSettings.SettingsSocialBase;
	using CoreConfig = Core.Configuration;
	using Newtonsoft.Json;
	using System.Text;

	#region Class: GetIntegrationListResponse

	/// <summary>
	/// Response with information of integration list.
	/// </summary>
	[DataContract]
	public class GetIntegrationListResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets integrations list.
		/// </summary>
		[DataMember(Name = "integrations")]
		public IEnumerable<Integration> Integrations { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetIntegrationRequest

	/// <summary>
	/// Request of integration data.
	/// </summary>
	[DataContract]
	public class GetIntegrationRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration unique identificator.
		/// </summary>
		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetIntegrationResponse

	/// <summary>
	/// Response with information of integration.
	/// </summary>
	[DataContract]
	public class GetIntegrationResponse : Integration
	{
	}

	#endregion

	#region Class: CreateIntegrationRequest

	/// <summary>
	/// Response with information of integration.
	/// </summary>
	[DataContract]
	public class CreateIntegrationRequest : Integration
	{
	}

	#endregion

	#region Class: UpdateIntegrationRequest

	/// <summary>
	/// Response with information of integration.
	/// </summary>
	[DataContract]
	public class UpdateIntegrationRequest : Integration
	{
	}

	#endregion

	#region Class: DeleteIntegrationRequest

	/// <summary>
	/// Response with information of integration.
	/// </summary>
	[DataContract]
	public class DeleteIntegrationRequest : Integration
	{
	}

	#endregion

	#region Class: GetLinkedinAdAccountListResponse

	/// <summary>
	/// Cloud response DTO with information of integration list.
	/// </summary>
	[DataContract]
	public class GetLinkedinAdAccountListResponse
	{

		#region Class: Integration

		/// <summary>
		/// Class for describing integration.
		/// </summary>
		[DataContract]
		public class LinkedInAdAccount
		{

			#region Properties: Public

			/// <summary>
			/// Gets or sets ad account unique identificator.
			/// </summary>
			[DataMember(Name = "id")]
			public string Id { get; set; }

			/// <summary>
			/// Gets or sets ad account name.
			/// </summary>
			[DataMember(Name = "name")]
			public string Name { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration list.
		/// </summary>
		[DataMember(Name = "linkedinAdAccounts")]
		public IEnumerable<LinkedInAdAccount> LinkedinAdAccounts { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetEntitiesListRequest

	/// <summary>
	/// Request DTO of schema entity list.
	/// </summary>
	[DataContract]
	public class GetEntitiesListRequest
	{
		#region Properties: Public

		/// <summary>
		/// Collection of schema name used for filtration.
		/// </summary>
		[DataMember(Name = "name")]
		public IEnumerable<string> Name { get; set; }

		#endregion
	}

	#endregion

	#region Class: GetEntitiesListResponse

	/// <summary>
	/// Cloud response DTO with information of integration list.
	/// </summary>
	[DataContract]
	public class GetEntitiesListResponse
	{ 

		#region Class: Integration

		/// <summary>
		/// Class for describing integration.
		/// </summary>
		[DataContract]
		public class Entity
		{

			#region Properties: Public

			/// <summary>
			/// Gets or sets entity unique identificator.
			/// </summary>
			[DataMember(Name = "uId")]
			public Guid UId { get; set; }

			/// <summary>
			/// Gets or sets entity caption.
			/// </summary>
			[DataMember(Name = "caption")]
			public string Caption { get; set; }

			/// <summary>
			/// Gets or sets entity name.
			/// </summary>
			[DataMember(Name = "name")]
			public string Name { get; set; }

			/// <summary>
			/// Gets or sets primary display column name.
			/// </summary>
			[DataMember(Name = "primaryDisplayColumnName")]
			public string PrimaryDisplayColumnName { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration list.
		/// </summary>
		[DataMember(Name = "entities")]
		public IEnumerable<Entity> Entities { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetLinkedInPredefinedFieldRequest

	[DataContract]
	public class GetLinkedInPredefinedFieldRequest
	{

		#region Properties: Public

		[DataMember(Name = "adAccountId")]
		public string AdAccountId { get; set; }

		#endregion
	}

	#endregion

	#region Class: GetLinkedInPredefinedFieldResponse

	public class GetLinkedInPredefinedFieldResponse
	{

		#region Class: FieldItem

		public class FieldItem
		{

			#region Properties: Public

			[DataMember(Name = "id")]
			public string Id { get; set; }

			[DataMember(Name = "displayValue")]
			public string DisplayValue { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "predefinedFields")]
		public IEnumerable<FieldItem> PredefinedFields { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetLinkedInFormFieldsRequest

	[DataContract]
	public class GetLinkedInFormFieldsRequest
	{

			#region Properties: Public

			[DataMember(Name = "adAccountId")]
			public string AdAccountId { get; set; }

			[DataMember(Name = "formId")]
			public long FormId { get; set; }
			
			#endregion

	}

	#endregion

	#region Class: GetLinkedInFormFieldsResponse

	[DataContract]
	public class GetLinkedInFormFieldsResponse
	{

		#region Class: FieldItem

		public class FieldItem
		{

			#region Properties: Public

			[DataMember(Name = "id")]
			public string Id { get; set; }

			[DataMember(Name = "displayValue")]
			public string DisplayValue { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		[DataMember(Name = "predefinedFields")]
		public IEnumerable<FieldItem> PredefinedFields { get; set; }


		[DataMember(Name = "customMultipleChoiceQuestions")]
		public IEnumerable<FieldItem> CustomMultipleChoiceQuestions { get; set; }


		[DataMember(Name = "customQuestions")]
		public IEnumerable<FieldItem> CustomQuestions { get; set; }


		[DataMember(Name = "consents")]
		public IEnumerable<FieldItem> Consents { get; set; }


		[DataMember(Name = "hiddenFields")]
		public IEnumerable<FieldItem> HiddenFields { get; set; }

		#endregion

	}

	#endregion

	#region Class: GetLinkedInFormListRequest

	[DataContract]
	public class GetLinkedInFormListRequest
	{

		#region Properties: Public

		[DataMember(Name = "adAccountId")]
		public string AdAccountId { get; set; }

		#endregion
	}

	#endregion

	#region Class: GetLinkedInFormListResponse

	[DataContract]
	public class GetLinkedInFormListResponse
	{

		#region Class: Form

		[DataContract]
		public class Form
		{

			#region Properties: Public

			[DataMember(Name = "id")]
			public long Id { get; set; }

			[DataMember(Name = "name")]
			public string Name { get; set; }

			[DataMember(Name = "linkedInCreatedTime")]
			public string LinkedInCreatedTime { get; set; }

			[DataMember(Name = "linkedInStatus")]
			public string LinkedInStatus { get; set; }

			#endregion

		}

		#endregion


		#region Properties: Public

		[DataMember(Name = "forms")]
		public IEnumerable<Form> Forms { get; set; }

		#endregion
	}

	#endregion

	#region Class: SocialLeadGenService

	/// <summary>
	/// Class to work with lead generation cloud service.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SocialLeadGenService : BaseService, IReadOnlySessionState
	{
		#region Fields: Private

		private const string _dateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fff";

		#endregion

		#region Properties: Private

		private AccountSocialLeadGenRestProvider _restProvider;

		private AccountSocialLeadGenRestProvider RestProvider {
			get {
				if (_restProvider == null) {
					_restProvider = new AccountSocialLeadGenRestProvider(UserConnection);
				}
				return _restProvider;
			}
			set {
				_restProvider = value;
			}
		}

		private string _accountServiceUrl;

		private string AccountServiceUrl {
			get {
				if (string.IsNullOrEmpty(_accountServiceUrl)) {
					_accountServiceUrl = CoreConfig.SysSettings.GetValue(UserConnection, AccountServiceAddressSettingsName).ToString();
					return _accountServiceUrl;
				}
				else {
					return _accountServiceUrl;
				}
			}
		}

		private string AccountServiceAddressSettingsName => "SocialAccountServiceUrl";

		private HttpContext CurrentContext => HttpContextAccessor.GetInstance();

		#endregion

		#region Methods: Private

		private string GetLczStringValue(string lczName) {
			var localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczName);
			var localizableString = new LocalizableString(
				UserConnection.Workspace.ResourceStorage, "SocialLeadGenService", localizableStringName);
			var value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		private BaseResponse GenerateErrorBaseResponse(string errorMessage) {
			var responseObj = new BaseResponse {
				Success = false,
				ErrorInfo = new ErrorInfo {
					Message = string.Format(GetLczStringValue("ServiceCallErrorMesagePattern"), errorMessage)
				}
			};
			return responseObj;
		}

		private void GenerateServiceCallFaultResponse(string errorMessage) {
			var responseObj = GenerateErrorBaseResponse(errorMessage);
			throw new WebFaultException<BaseResponse>(responseObj, HttpStatusCode.InternalServerError);
		}

		private string ConvertDateTimeUseUserTimeZone(string dateTimeStr, bool toUtc) {
			if (string.IsNullOrEmpty(dateTimeStr) || string.IsNullOrWhiteSpace(dateTimeStr)) {
				return dateTimeStr;
			}
			var dateTime = DateTime.Parse(dateTimeStr);
			TimeZoneInfo userTimeZone = UserConnection.CurrentUser.TimeZone;
			var convertedDateTime = toUtc
				? TimeZoneInfo.ConvertTimeToUtc(dateTime, userTimeZone)
				: TimeZoneInfo.ConvertTimeFromUtc(dateTime, userTimeZone);
			return convertedDateTime.ToString(_dateTimeFormat);
		}

		private void ConvertMappingDateTime(MappingData mappingData, bool toUtc) {
			var schema = UserConnection.EntitySchemaManager.GetInstanceByName(mappingData.EntitySchemaName);
			mappingData.Columns.ForEach(x => {
				var column = schema.Columns.FindByName(x.Name);
				if (column != null && column.DataValueType.IsDateTime
					&& (column.DataValueType as DateTimeDataValueType).Kind == DateTimeValueKind.DateTime
					&& x.Value.Const != default) {
					x.Value.Const = ConvertDateTimeUseUserTimeZone(x.Value.Const, toUtc);
				}
			});
		}

		private void ConvertFormCreatedTime(SocialForm form, bool toUtc) {
			if (form.LinkedInCreatedTime != default) {
				form.LinkedInCreatedTime = ConvertDateTimeUseUserTimeZone(form.LinkedInCreatedTime, toUtc);
			}
		}

		private void ConvertIntegrationDateTime<T>(ref T integration, bool toUtc) where T : Integration {
			var defaultMapping = integration.Metadata.LinkedIn?.Mapping;
			if (defaultMapping != default) {
				ConvertMappingDateTime(defaultMapping, toUtc);
			}
			integration.Metadata.LinkedIn?.Forms?.ForEach(f => {
				if (f.Mapping != default) {
					ConvertMappingDateTime(f.Mapping, toUtc);
				}
				ConvertFormCreatedTime(f, toUtc);
			});
			
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns account creation info.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateAccount", BodyStyle = WebMessageBodyStyle.Wrapped, 
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateAccount(AccountRequest createAccountRequest) {
			try {
				RestProvider.CreateAccount(createAccountRequest.BPMStudioDomain, createAccountRequest.PingBPMStudioInstance);
			} catch (SocialLeadGenRestProviderException ex) {
				GenerateServiceCallFaultResponse(ex.Message);
			}
		}

		/// <summary>
		/// Returns update account info.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateAccount", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateAccount(AccountRequest updateAccountRequest) {
			try {
				RestProvider.UpdateAccount(updateAccountRequest.BPMStudioDomain, updateAccountRequest.PingBPMStudioInstance);
			} catch (SocialLeadGenRestProviderException ex) {
				GenerateServiceCallFaultResponse(ex.Message);
			}
		}

		/// <summary>
		/// Returns self account.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetAccount", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public AccountInfoResponse GetAccount() {
			var response = RestProvider.GetMyAccount();
			return new AccountInfoResponse {
				IsAccountExists = (response.AccountId != Guid.Empty),
				AccountId = response.AccountId,
				BPMStudioUrl = response.BPMStudioUrl,
				IsActive = response.IsActive
			};
		}

		/// <summary>
		/// Returns session token and account endpoint.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GenerateSessionToken", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public SessionTokenResponse GenerateSessionToken() {
			var response = RestProvider.GenerateSessionToken();
			return new SessionTokenResponse {
				AccountServiceUrl = AccountServiceUrl,
				SessionToken = response
			};
		}

		/// <summary>
		/// Returns info about landing subscribtion.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetSubscribtion", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public LandingSubscribtionResponse GetSubscribtion(LandingSubscriptionRequest subscribtionRequest) {
			var response = RestProvider.FindWebForm(subscribtionRequest.LandingId);
			return new LandingSubscribtionResponse {
				FormName = response.FormName,
				PageName = response.PageName,
				PageId = response.PageId,
				IsLeadGenSubscribed = !string.IsNullOrEmpty(response.PageId)
			};
		}

		/// <summary>
		/// Returns info about deleting landing subscribtion.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteSubscribtion", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public LandingSubscribtionResponse DeleteSubscribtion(LandingSubscriptionRequest unsubscribtionRequest) {
			RestProvider.UnsubscribeWebForm(unsubscribtionRequest.LandingId);
			return new LandingSubscribtionResponse {
				FormName = string.Empty,
				PageName = string.Empty,
				PageId = string.Empty,
				IsLeadGenSubscribed = false
			};
		}

		/// <summary>
		/// Returns list of integration.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIntegrationList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetIntegrationListResponse GetIntegrationList() {
			var response = RestProvider.GetIntegrationList();
			return new GetIntegrationListResponse {
				Integrations = response.Integrations.Select(x => new Integration {
					Id = x.Id,
					IsActive = x.IsActive,
					Name = x.Name,
					Type = x.Type
				})
			};
		}

		/// <summary>
		/// Returns integration.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetIntegration", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetIntegrationResponse GetIntegration(GetIntegrationRequest request) {
			var response = RestProvider.GetIntegration(request.Id);
			var integration = response.IntegrationData;
			ConvertIntegrationDateTime(ref integration, toUtc: false);
			return new GetIntegrationResponse {
				Id = integration.Id,
				IsActive = integration.IsActive,
				Name = integration.Name,
				Type = integration.Type,
				Metadata = integration.Metadata
			};
		}

		/// <summary>
		/// Create integration.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateIntegration", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateIntegration(CreateIntegrationRequest request) {
			try {
				ConvertIntegrationDateTime(ref request, toUtc: true);
				RestProvider.CreateIntegration(request);
			} catch (SocialLeadGenRestProviderException ex) {
				GenerateServiceCallFaultResponse(ex.Message);
			}
		}

		/// <summary>
		/// Update integration.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateIntegration", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdateIntegration(UpdateIntegrationRequest request) {
			try {
				ConvertIntegrationDateTime(ref request, toUtc: true);
				RestProvider.UpdateIntegration(request);
			} catch (SocialLeadGenRestProviderException ex) {
				GenerateServiceCallFaultResponse(ex.Message);
			}
		}

		/// <summary>
		/// Delete integration.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "DeleteIntegration", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void DeleteIntegration(DeleteIntegrationRequest request) {
			return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetLinkedinAdAccountList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetLinkedinAdAccountListResponse GetLinkedinAdAccountList() {
			var response = RestProvider.GetLinkedInAdAccounts();
			return new GetLinkedinAdAccountListResponse {
				LinkedinAdAccounts = response.AdAccounts
					.Select(x => new GetLinkedinAdAccountListResponse.LinkedInAdAccount {
						Id = x.AdAccountId,
						Name = x.AdAccountName
					})
			};
		}

		/// <summary>
		/// Get entities.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetEntities", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetEntitiesListResponse GetEntities(GetEntitiesListRequest request) {
			request = request ?? new GetEntitiesListRequest { Name = new string[] { "Lead" } };
			var allEntities = UserConnection.EntitySchemaManager.GetItems();
			var query = allEntities.Where(e => {
				return
					e.SafeInstance?.IsDBView == false
					&& e.SafeInstance?.IsVirtual == false;
				});
			if (request != null && request.Name != null) {
				query = query.Where(e => request.Name.Contains(e.Name));
			}
			return new GetEntitiesListResponse {
				Entities = query.Select(e => {
					return new GetEntitiesListResponse.Entity {
						UId = e.UId,
						Name = e.Name,
						Caption = e.Caption,
						PrimaryDisplayColumnName = e.SafeInstance.PrimaryDisplayColumn.Name
					};
				})
			};
		}

		/// <summary>
		/// Requests list of predefined fields for linkedin form.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetLinkedInPredefinedField", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetLinkedInPredefinedFieldResponse GetLinkedInPredefinedField(GetLinkedInPredefinedFieldRequest request) {
			var responseObj = RestProvider.GetLinkedInPredefinedField(request.AdAccountId);
			return new GetLinkedInPredefinedFieldResponse {
				PredefinedFields = responseObj.PredefinedQuestions?.Select(x => new GetLinkedInPredefinedFieldResponse.FieldItem {
					Id = x.PredefinedField,
					DisplayValue = x.PredefinedField
				})
			};
		}

		/// <summary>
		/// Requests list of fields for linkedin form.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetLinkedInFormFields", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetLinkedInFormFieldsResponse GetLinkedInFormFields(GetLinkedInFormFieldsRequest request) {
			var responseObj = RestProvider.GetLinkedInFormFields(request.AdAccountId, request.FormId);
			return new GetLinkedInFormFieldsResponse {
				PredefinedFields = responseObj.PredefinedQuestions?.Select(x => new GetLinkedInFormFieldsResponse.FieldItem {
					Id = x.PredefinedField,
					DisplayValue = x.PredefinedField,
				}),
				CustomQuestions = responseObj.CustomTextQuestions?.Select(x => new GetLinkedInFormFieldsResponse.FieldItem {
					Id = x.Id,
					DisplayValue = x.QuestionText
				}),
				CustomMultipleChoiceQuestions = responseObj.CustomMultipleChoiceQuestions?.Select(x => new GetLinkedInFormFieldsResponse.FieldItem {
					Id = x.Name,
					DisplayValue = x.QuestionText
				}),
				Consents = responseObj.Consents?.Select(x => new GetLinkedInFormFieldsResponse.FieldItem {
					Id = x.Id.ToString(),
					DisplayValue = x.ConsentText
				}),
				HiddenFields = responseObj.HiddenFields?.Select(x => new GetLinkedInFormFieldsResponse.FieldItem {
					Id = x.Name,
					DisplayValue = x.Name
				})

			};
		}

		/// <summary>
		/// Requests list of forms for linkedin adaccount.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "GetLinkedInFormList", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GetLinkedInFormListResponse GetLinkedInFormList(GetLinkedInFormListRequest request) {
			var responseObj = RestProvider.GetLinkedInForms(request.AdAccountId);
			return new GetLinkedInFormListResponse {
				Forms = responseObj.Forms.Select(x => new GetLinkedInFormListResponse.Form {
					Id = x.Id,
					Name = x.Name,
					LinkedInCreatedTime = x.LinkedInCreatedTime,
					LinkedInStatus = x.LinkedInStatus
				})
			};
		}

		/// <summary>
		/// Calls directly API of remote service.
		/// </summary>
		/// <param name="stream">Proxied request</param>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "ProxyRequest", BodyStyle = WebMessageBodyStyle.Bare)]
		public void ProxyRequest(System.IO.Stream stream) {
			var requestBody = stream.GetContent();
			var url = CurrentContext.Request.QueryString["proxyto"];
			var responseBody = string.Empty;
			try {
				responseBody = RestProvider.ProxyRequest(url, requestBody);
			} catch (SocialLeadGenRestProviderException ex) {
				var responseObj = GenerateErrorBaseResponse(ex.Message);
				responseBody = JsonConvert.SerializeObject(responseObj);
#if !NETSTANDARD2_0
				WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
#else
				{
					CurrentContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				}
#endif

			} finally {
				var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
				CurrentContext.Response.OutputStream.Write(responseBodyBytes, 0, responseBodyBytes.Length);
#if !NETSTANDARD2_0
				WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
#else
				{
					CurrentContext.Response.ContentType = "application/json";
				}
#endif
			}
		}

		#endregion

	}

	#endregion

}
