namespace BPMSoft.Configuration.Reporting.Word.Services
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Text.RegularExpressions;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Configuration.Reporting.Word.Worker;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.ServiceModelContract;
	using BPMSoft.Web.Common;
	using HttpContext = BPMSoft.Web.Http.Abstractions.HttpContext;
#if NETSTANDARD2_0
	using TS = BPMSoft.Web.Http.Abstractions;
#else
	using MS = System.Web;
#endif
	using TSConfiguration = BPMSoft.Core.Configuration;

	#region Class: WordReportingDesignService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class WordReportingDesignService : BaseService
	{

		#region Constants: Private

		private const string WordMimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

		#endregion

		#region Fields: Private

		private FileUploader _fileUploader;

		private IWordReportDesignWorker _reportWorker;

		private WebResponseProcessor _webResponseProcessor;

		#endregion

		#region Constructors: Public

		public WordReportingDesignService() { }

		public WordReportingDesignService(UserConnection userConnection, IFileUploadInfo fileUploadInfo)
			: base(userConnection) { }

		#endregion

		#region Properties: Private

		private IWordReportDesignWorker ReportWorker =>
			_reportWorker ?? (_reportWorker = ClassFactory.Get<IWordReportDesignWorker>());

		private WebResponseProcessor WebResponseProcessor =>
			_webResponseProcessor ?? (_webResponseProcessor = ClassFactory.Get<WebResponseProcessor>());

		private FileUploader FileUploader =>
			_fileUploader ?? (_fileUploader =
				ClassFactory.Get<FileUploader>(new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		private IFileUploadInfo GetFileUploadInfo(Stream fileContent) {
			return ClassFactory.Get<FileUploadInfo>(new ConstructorArgument("fileContent", fileContent),
#if NETSTANDARD2_0
				new ConstructorArgument("request", TS.HttpContext.Current.Request),
#else
				new ConstructorArgument("request", new MS.HttpRequestWrapper(MS.HttpContext.Current.Request)),
#endif
				new ConstructorArgument("storage", UserConnection.Workspace.ResourceStorage));
		}

		private string ConvertBytesToMb(decimal bytes) {
			var mb = (bytes / 1024) / 1024;
			return mb.ToString();
		}

		private BaseResponse GetResponse(bool isSuccess, int? errorCode, string message = "") {
			var response = new BaseResponse {
				Success = isSuccess
			};
			if (!isSuccess && errorCode.HasValue) {
				response.ErrorInfo = new ErrorInfo {
					Message = message,
					ErrorCode = errorCode.ToString()
				};
			}
			return response;
		}

		private void SetResponseHttpStatus(HttpStatusCode statusCode) {
#if NETSTANDARD2_0
			HttpContext context = HttpContext.Current;
#else
			WebOperationContext context = WebOperationContext.Current;
#endif
			if (context == null) {
				return;
			}
#if NETSTANDARD2_0
			var response = context.Response;
			response.StatusCode = (int)statusCode;
#else
			OutgoingWebResponseContext outgoingResponse = context.OutgoingResponse;
			outgoingResponse.StatusCode = statusCode;
#endif
		}

		private decimal GetMaxFileSizeFromSysSettings() {
			int value = TSConfiguration.SysSettings.GetValue(UserConnection, "FileImportMaxFileSize", 0);
			return FileSizeConverter.MbToBytes(value);
		}

		private bool IsLastChunk(string byteRange) {
			var regex = new Regex(@"\d+-(?<uploadedBytes>[-]?\d+)/(?<totalBytes>\d+)$");
			var uploadedBytes = Convert.ToInt32(regex.Match(byteRange).Groups["uploadedBytes"].Value);
			var totalBytes = Convert.ToInt32(regex.Match(byteRange).Groups["totalBytes"].Value);
			//TODO: FileApi send uploadedBytes without one byte
			//MS Word plugin send correct uploadedBytes value
			return uploadedBytes == totalBytes || uploadedBytes + 1 == totalBytes;
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public WordReportMainInfoDto[] GetWordReportMainInfoCollection() {
			return ReportWorker.GetReportsCollection().ToArray();
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public WordReportSettingsDto GetWordReportSettings(Guid reportId) {
			return ReportWorker.GetReportSettings(reportId);
		}

		[OperationContract]
		[WebGet(UriTemplate = "DownloadReportTemplate/{reportId}")]
		public Stream DownloadReportTemplate(string reportId) {
			var reportGuid = new Guid(reportId);
			try {
				(Stream file, string caption) = ReportWorker.DownloadTemplate(reportGuid);
				string contentDisposition = $"attachment; filename*=UTF-8''{Uri.EscapeDataString(caption)}.docx";
				WebResponseProcessor.AssignFileResponseContent(HttpContextAccessor.GetInstance(), WordMimeType,
					file?.Length ?? 0, contentDisposition);
				return file;
			} catch (ItemNotFoundException) {
				throw new WebFaultException(HttpStatusCode.NotFound);
			} catch (Exception) {
				throw new WebFaultException(HttpStatusCode.MethodNotAllowed);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UploadReportTemplate", ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse UploadReportTemplate(Stream fileContent) {
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			string reportId = httpContext.Request.QueryString["reportId"];
			Guid report = new Guid(reportId);
			IFileUploadInfo fileUploadInfo = GetFileUploadInfo(fileContent);
			decimal maxFileSize = GetMaxFileSizeFromSysSettings();
			var uploadSettings = new FileUploadConfig(fileUploadInfo) {
				SetCustomColumnsFromConfig = false,
				MaxFileSize = maxFileSize
			};
			try {
				FileUploader.UploadFile(uploadSettings);
				if (IsLastChunk(uploadSettings.ByteRange)) {
					Stream template = ReportWorker.ValidateTemplate(uploadSettings.FileId);
					ReportWorker.SaveTemplate(template, report);
					SetResponseHttpStatus(HttpStatusCode.Created);
				}
			} catch (ArgumentException ex) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.NotAcceptable);
			} catch (ItemNotFoundException ex) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.NotFound);
			} catch (MaxFileSizeExceededException ex) {
				SetResponseHttpStatus(HttpStatusCode.LengthRequired);
				return GetResponse(false, (int)HttpStatusCode.LengthRequired, ConvertBytesToMb(uploadSettings.MaxFileSize));
			} catch (Exception ex) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.MethodNotAllowed);
			}
			return GetResponse(true, null);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public BaseResponse CopyReportTemplate(Guid sourceReportId, Guid destinationReportId) {
			try {
				ReportWorker.CopyTemplate(sourceReportId, destinationReportId);
				return GetResponse(true, null);
			} catch (ItemNotFoundException) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.NotFound);
			} catch (SecurityException) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.Forbidden);
			} catch (Exception) {
				SetResponseHttpStatus(HttpStatusCode.InternalServerError);
				return GetResponse(false, (int)HttpStatusCode.InternalServerError);
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		public BaseResponse RemoveReportTemplate(Guid reportId) {
			try {
				ReportWorker.RemoveTemplate(reportId);
			} catch (ItemNotFoundException) {
				return GetResponse(false, (int)HttpStatusCode.NotFound);
			} catch (Exception) {
				return GetResponse(false, (int)HttpStatusCode.MethodNotAllowed);
			}
			return GetResponse(true, null);
		}

		#endregion

	}

	#endregion

}

