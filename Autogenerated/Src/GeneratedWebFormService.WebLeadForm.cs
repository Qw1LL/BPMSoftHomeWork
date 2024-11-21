namespace BPMSoft.Configuration.GeneratedWebFormService
{
	using System;
	using System.Globalization;
	using System.IO;
	using System.Net;
	using System.Text;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Web.Http.Abstractions;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GeneratedWebFormService
	{
		#region Constructors: Public

		public GeneratedWebFormService() {
			string referrer = null;
			if (HttpContext.Current.Request.UrlReferrer != null) {
				referrer = HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
			}
			var validator = new GeneratedWebFormValidator(referrer, UserConnection);
			var defaultValueManager = new LeadDefaultValueManager();
			Mapper = new FormDataToEntityMapper(validator, defaultValueManager, UserConnection);
		}
		
		public GeneratedWebFormService(IFormDataToEntityMapper mapper) {
			Mapper = mapper;
		}

		#endregion

		#region Properties: Protected

		private HttpContext _httpContext;
		protected virtual HttpContext CurrentHttpContext {
			get => _httpContext ?? (_httpContext = HttpContext.Current);
			set => _httpContext = value;
		}

		private UserConnection _userConnection;
		protected UserConnection UserConnection {
			get {
				if (_userConnection != null) {
					return _userConnection;
				}
				_userConnection = CurrentHttpContext.Session["UserConnection"] as UserConnection;
				if (_userConnection != null) {
					return _userConnection;
				}
				var appConnection = (AppConnection)CurrentHttpContext.Application["AppConnection"];
				_userConnection = appConnection.SystemUserConnection;
				return _userConnection;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Instance of IFormDataToEntityMapper.
		/// </summary>
		public IFormDataToEntityMapper Mapper { get; set; }

		#endregion

		#region Methods: Private

		private WebFormSavingResult GetSuccessSavingResult() {
			return new WebFormSavingResult {
				resultMessage = GeneratedWebFormLczUtilities
					.GetLczStringValue("DataIsSavedSuccessfullyMessage", "GeneratedWebFormService", UserConnection),
				resultCode = 0
			};
		}

		private WebFormSavingResult GetErrorSavingResult(string message) {
			return new WebFormSavingResult {
				resultMessage = message,
				resultCode = -1
			};
		}

		private void AssignResponseContent(string contentType, long streamLength, string contentDisposition) {
#if !NETSTANDARD2_0
			WebOperationContext.Current.OutgoingResponse.ContentType = contentType;
			WebOperationContext.Current.OutgoingResponse.ContentLength = streamLength;
			WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", contentDisposition);
#else
			HttpContext httpContext = CurrentHttpContext;
			httpContext.Response.ContentType = contentType;
			httpContext.Response.Headers["Content-Length"] = streamLength.ToString(CultureInfo.InvariantCulture);
			httpContext.Response.AddHeader("Content-Disposition", contentDisposition);
#endif
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SendFormDataToSave(string data) {
			if (UserConnection == null) {
				return string.Empty;
			}
			string key = $"DataToSaveKey_{Guid.NewGuid()}";
			UserConnection.SessionData[key] = data;
			return key;
		}

		[OperationContract]
		[WebGet(UriTemplate = "SaveFormDataToFile/{fileName}/{dataContextKey}")]
		public Stream SaveFormDataToFile(string fileName, string dataContextKey) {
			if (UserConnection == null) {
				return null;
			}
			string dataContext = UserConnection.SessionData[dataContextKey].ToString();
			var encoding = new UTF8Encoding();
			var stream = new MemoryStream();
			byte[] encodeData = encoding.GetBytes(dataContext);
			stream.Write(encodeData, 0, encodeData.Length);
			stream.Seek(0, SeekOrigin.Begin);
			string contentType = "text/plain";
			string contentDispositionValue = "attachment; filename=\"" + fileName + "\"";
			AssignResponseContent(contentType, stream.Length, contentDispositionValue);
			return stream;
		}

		[OperationContract]
		[WebInvoke(Method = "OPTIONS", UriTemplate = "SaveWebFormLeadData")]
		public void GetWebFormLeadDataRequestOptions() {
#if !NETSTANDARD2_0
			var outgoingResponseHeaders = WebOperationContext.Current.OutgoingResponse.Headers;
			outgoingResponseHeaders.Add("Access-Control-Allow-Origin", "*");
			outgoingResponseHeaders.Add("Access-Control-Allow-Methods", "POST");
			outgoingResponseHeaders.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept");
#else
			HttpContext httpContext = CurrentHttpContext;
			httpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
			httpContext.Response.AddHeader("Access-Control-Allow-Methods", "POST");
			httpContext.Response.AddHeader("Access-Control-Allow-Headers", "Origin, Content-Type, Accept");
#endif
		}

		/// <summary>
		/// Creates lead basing on landing page data.
		/// </summary>
		/// <param name="formData">Object with landing page data.</param>
		/// <returns> JSON string. 
		/// Contains serialized object with fields:
		/// resultCode - Rerusns 0 is query executed successfully, otherwise -1.
		/// resultMessage - Message with result execution text. </returns>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "SaveWebFormLeadData",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		public string SaveWebFormLeadData(FormData formData) {
#if !NETSTANDARD2_0
			WebOperationContext webOperationContext = WebOperationContext.Current;
			string incomingRequestOrigin = webOperationContext.IncomingRequest.Headers["Origin"];
			webOperationContext.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", incomingRequestOrigin);
#else
			HttpContext httpContext = CurrentHttpContext;
			string incomingRequestOrigin = httpContext.Request.Headers["Origin"];
			httpContext.Response.AddHeader("Access-Control-Allow-Origin", incomingRequestOrigin);
#endif
			if (UserConnection == null) {
				return string.Empty;
			}
			var webFormHandler = new WebFormHandler(UserConnection);
			webFormHandler.HandleForm(formData);
			if (!webFormHandler.Success) {
				return Json.Serialize(GetErrorSavingResult(webFormHandler.ErrorMessage));
			}
			return Json.Serialize(GetSuccessSavingResult());
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
	}

	#region Class: LeadPostProcess

	/// <summary>
	/// LeadPostProcess replaced class.
	/// </summary>
	public class LeadPostProcess
	{

		#region Methods: Public

		/// <summary>
		/// Post cookie to tracking service.
		/// </summary>
		/// <param name="leadEntity">Lead entity.</param>
		public virtual void PostBpmSessionId(UserConnection userConnection, Entity leadEntity) {
		}

		#endregion

	}

	#endregion

}

