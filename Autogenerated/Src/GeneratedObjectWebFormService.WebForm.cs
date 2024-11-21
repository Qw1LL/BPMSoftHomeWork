namespace BPMSoft.Configuration.GeneratedWebFormService
{
	using System.Net;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using System;

	#region Class: GeneratedObjectWebFormService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GeneratedObjectWebFormService : BaseService
	{
		
		#region Constructors

		public GeneratedObjectWebFormService() {
		}

		public GeneratedObjectWebFormService(IWebFormHandler webFormHandler, HttpContext httpContext,
				UserConnection userConnection) {
			WebFormHandler = webFormHandler;
			_httpContext = httpContext;
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets the current HTTP context.
		/// </summary>
		/// <value>
		/// The current HTTP context.
		/// </value>
		private HttpContext _httpContext;
		protected virtual HttpContext CurrentHttpContext =>
			_httpContext ?? (_httpContext = HttpContextAccessor.GetInstance());

		private UserConnection _userConnection;
		protected override UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = CurrentHttpContext.Session?["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				var appConnection = (AppConnection)CurrentHttpContext.Application["AppConnection"];
				_userConnection = appConnection.SystemUserConnection;
				return _userConnection;
			}
		}

		private IWebFormHandler _webFormHandler;
		protected IWebFormHandler WebFormHandler {
			get {
				return _webFormHandler ?? (_webFormHandler = new WebFormHandler(UserConnection));
			}
			set { _webFormHandler = value; }
		}

		private IWebFormHandler _webFormAsyncHandler;
		protected IWebFormHandler WebFormAsyncHandler {
			get {
				return _webFormAsyncHandler ?? (_webFormAsyncHandler = new WebFormAsyncHandler(UserConnection));
			}
			set { _webFormAsyncHandler = value; }
		}

		#endregion

		#region Methods: Private

		private void SetOptionsCORS() {
			CurrentHttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
			CurrentHttpContext.Response.AddHeader("Access-Control-Allow-Methods", "POST");
			CurrentHttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
		}

		private void SetHeaderCORS() {
			CurrentHttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
		}

		private WebFormSavingResult GetOptionedSavingResult(IWebFormHandler handler, FormData formData) {
			var result = new OptionedWebFormSavingResult();
			if (formData.options.extendResponseWithExceptionType) {
				result.exceptionType = (handler as WebFormHandler)?.Exception?.GetType().Name ?? string.Empty;
			}
			return result;
		}

		private WebFormSavingResult GetErrorSavingResult(IWebFormHandler handler, FormData formData) {
			WebFormSavingResult savingResult;
			if (handler is WebFormHandler && formData.options != null) {
				savingResult = GetOptionedSavingResult(handler, formData);
			} else {
				savingResult = new WebFormSavingResult();
			}
			savingResult.resultMessage = handler.ErrorMessage;
			savingResult.resultCode = -1;
			return savingResult;
		}

		private WebFormSavingResult GetSuccessSavingResult() {
			var resultObject = new WebFormSavingResult();
			resultObject.resultMessage = GeneratedWebFormLczUtilities
				.GetLczStringValue("DataIsSavedSuccessfullyMessage", "GeneratedObjectWebFormService", UserConnection);
			resultObject.resultCode = 0;
			return resultObject;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "OPTIONS", UriTemplate = "SaveWebFormObjectData")]
		public void GetWebFormObjectDataRequestOptions() {
			SetOptionsCORS();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveWebFormObjectData",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string SaveWebFormObjectData(FormData formData) {
			SetHeaderCORS();
			if (UserConnection == null ||
				formData == null ||
				formData.formFieldsData == null) {
				return string.Empty;
			}
			SessionHelper.SpecifyWebOperationIdentity(CurrentHttpContext, UserConnection.CurrentUser);
			GeneralResourceStorage.SetCurentCulture(UserConnection.CurrentUser.Culture);
			var webFormHandler = UserConnection.GetIsFeatureEnabled("WebFormAsyncHandler")
					&& formData.contactFieldsData != null && formData.contactFieldsData.Length > 0
				? WebFormAsyncHandler
				: WebFormHandler;
			webFormHandler.HandleForm(formData);
			if (!webFormHandler.Success) {
				return Json.Serialize(GetErrorSavingResult(webFormHandler, formData));
			}
			return Json.Serialize(GetSuccessSavingResult());
		}

		#endregion

	}

	#endregion


	#region Class: WebFormSavingResult

	public class WebFormSavingResult
	{
		#region Properties: Public

		public string resultMessage {
			get;
			set;
		}

		public int resultCode {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: ExtendedExceptionWebFormSavingResult

	/// <summary>
	/// Extends <see cref="WebFormSavingResult"/> with additional optional properties.
	/// </summary>
	public class OptionedWebFormSavingResult : WebFormSavingResult
	{

		#region Properties: Public

		/// <summary>
		/// Contains exception type name.
		/// </summary>
		public string exceptionType {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: FormDefaultValuesData

	public class FormDefaultValuesData
	{
		#region Properties: Public

		public string columnName {
			get;
			set;
		}

		public string value {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class:FormDefaultGuidValue

	public class FormDefaultGuidValue
	{
		#region Properties: Public

		public string value {
			get;
			set;
		}

		public string displayValue {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: FormFieldsData

	public class FormFieldsData
	{
		#region Properties: Public

		public string name {
			get;
			set;
		}

		public string value {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: FormDataOptions

	/// <summary>
	/// Contains addidional options for SaveWebFormObjectData
	/// </summary>
	public class FormDataOptions
	{

		#region Properties: Public

		/// <summary>
		/// Flag indicates that needs include exception type in response when it throws during saving entity.
		/// </summary>
		public bool extendResponseWithExceptionType {
			get;
			set;
		}

		/// <summary>
		/// Flag indicates that needs to execute referer header validation.
		/// </summary>
		public bool disableRefererPolicy {
			get;
			set;
		}

		#endregion

	}

	#endregion

	#region Class: FormData

	public class FormData {

		#region Properties: Public

		public string formId {
			get;
			set;
		}

		public FormFieldsData[] formFieldsData {
			get;
			set;
		}

		public FormFieldsData[] contactFieldsData {
			get;
			set;
		}

		public FormDataOptions options {
			get;
			set;
		}

		#endregion
	}

	#endregion

	#region Class: ValidationResult

	public class ValidationResult
	{
		#region Properties: Public

		public bool Succes {
			get;
			set;
		}

		public string Message {
			get;
			set;
		}

		#endregion
	}

	#endregion

}

