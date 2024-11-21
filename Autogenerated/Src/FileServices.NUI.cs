namespace BPMSoft.Configuration.FileService
{
	using System;
	using System.Globalization;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Common;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core.Factories;
	using BPMSoft.File.Abstractions;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: FileService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FileService : BaseService, IReadOnlySessionState
	{

		#region Properties: Private

		private FileRepository _fileRepository;

		/// <summary>
		/// File manager.
		/// </summary>
		private FileRepository FileRepository =>
			_fileRepository ?? (_fileRepository = ClassFactory.Get<FileRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		private HttpContext CurrentContext => HttpContextAccessor.GetInstance();

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets response content disposition header value.
		/// </summary>
		/// <param name="fileName">File name.</param>
		/// <returns>Content disposition header value.</returns>
		protected virtual string GetResponseContentDisposition(string fileName) {
			var userConnectionArg = new ConstructorArgument("httpContext", CurrentContext);
			var responseContentDisposition = ClassFactory.Get<DownloadFileNameEncoder>(userConnectionArg);
			return responseContentDisposition.GenerateName(fileName,
				UserConnection.GetIsFeatureEnabled("UseUrlPathEncodeForGenerateFileName"));
		}

		/// <summary>
		/// Sets outgoing response content length.
		/// </summary>
		protected virtual void SetOutgoingResponseContentLength(int size) {
			CurrentContext.Response.Headers["Content-Length"] = size.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Sets outgoing response content type.
		/// </summary>
		protected virtual void SetOutgoingResponseContentType() {
			CurrentContext.Response.ContentType = "application/octet-stream";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Load file
		/// </summary>
		/// <param name="entitySchemaUId">EntitySchema UId</param>
		/// <param name="fileId">File Id</param>
		[OperationContract]
		[WebGet(UriTemplate = "GetFile/{entitySchemaUId}/{fileId}")]
		public Stream GetFile(string entitySchemaUId, string fileId) {
			SetOutgoingResponseContentType();
			var buffer = new MemoryStream();
			FileRepository.UseContentStreamOnFileLoad =
				UserConnection.GetIsFeatureEnabled("UseContentStreamOnFileLoad");
			IFileUploadInfo fileInfo = FileRepository.LoadFile(new Guid(entitySchemaUId), new Guid(fileId),
				new BinaryWriter(buffer));
			if (fileInfo == null) {
				return Stream.Null;
			}
			SetOutgoingResponseContentLength(Convert.ToInt32(fileInfo.TotalFileLength));
			string contentDisposition = GetResponseContentDisposition(fileInfo.FileName);
			CurrentContext.Response.AddHeader("Content-Disposition", contentDisposition);
			MimeTypeResult mimeTypeResult = MimeTypeDetector.GetMimeType(fileInfo.FileName);
			CurrentContext.Response.ContentType = mimeTypeResult.HasError
				? "application/octet-stream"
				: mimeTypeResult.Type;
#if NETFRAMEWORK

			// TODO Use abstract api instead of straight usage of WCF api.
			OperationContext context = OperationContext.Current;
			if (context != null) {
				System.ServiceModel.Channels.HttpResponseMessageProperty responseMessageProperty =
					new System.ServiceModel.Channels.HttpResponseMessageProperty {
						Headers = {
							["Content-Type"] = CurrentContext.Response.ContentType
						}
					};
				string httpResponsePropertyKey = System.ServiceModel.Channels.HttpResponseMessageProperty.Name;
				context.OutgoingMessageProperties[httpResponsePropertyKey] = responseMessageProperty;
			}
#endif
			if (fileInfo is FileEntityUploadInfo fileEntityUploadInfo && fileEntityUploadInfo.File != null) {
				Stream content = fileEntityUploadInfo.File.Read();
				return content;
			}
			buffer.Flush();
			buffer.Seek(0, SeekOrigin.Begin);
			return buffer;
		}

		#endregion
	}

	#endregion
}

