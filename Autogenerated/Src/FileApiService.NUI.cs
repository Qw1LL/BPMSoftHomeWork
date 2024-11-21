namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Web.Http.Abstractions;

	#region Class: FileApiService

	[DefaultServiceRoute, SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FileApiService : BaseService, IReadOnlySessionState
	{

		#region Constructors: Public

		public FileApiService():base() {
			_fileUploadInfoFactory = GetFileUploadInfo;
		}

		public FileApiService(UserConnection userConnection, FileRepository fileRepository,
				Func<Stream, IFileUploadInfo> fileUploadInfoFactory): base(userConnection) {
			_fileRepository = fileRepository;
			_fileUploadInfoFactory = fileUploadInfoFactory;
		}
		
		#endregion
		
		#region Properties: Private

		private FileRepository _fileRepository;

		/// <summary>
		/// File manager.
		/// </summary>
		private FileRepository FileRepository {
			get {
				if (_fileRepository == null) {
					_fileRepository = ClassFactory.Get<FileRepository>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _fileRepository;
			}
		}

		private readonly Func<Stream, IFileUploadInfo> _fileUploadInfoFactory;
		
		#endregion

		#region Methods: Private

		private IFileUploadInfo GetFileUploadInfo(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = ClassFactory.Get<FileUploadInfo>(
				new ConstructorArgument("fileContent", fileContent),
#if NETSTANDARD2_0
				new ConstructorArgument("request", HttpContext.Current.Request),
#else
				new ConstructorArgument("request", new System.Web.HttpRequestWrapper(System.Web.HttpContext.Current.Request)),
#endif
				new ConstructorArgument("storage", UserConnection.Workspace.ResourceStorage));
			return fileUploadInfo;
		}

		#endregion

		#region Methods: Public
		
		/// <summary>
		/// Uploads file.
		/// </summary>
		/// <param name="fileContent">File data stream.</param>
		/// <returns>Upload result.</returns>
		[Obsolete("7.19.0| Use \"UploadFile\" instead")]
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Upload", ResponseFormat = WebMessageFormat.Json)]
		public string Upload(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = _fileUploadInfoFactory(fileContent);
			if (FileRepository.UploadFile(fileUploadInfo)) {
				return "Ok";
			}
			return string.Empty;
		}
		
		/// <summary>
		/// Uploads file.
		/// </summary>
		/// <param name="fileContent">File data stream.</param>
		/// <returns>Upload result.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
			ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse UploadFile(Stream fileContent) {
			IFileUploadInfo fileUploadInfo = _fileUploadInfoFactory(fileContent);
			var response = new ConfigurationServiceResponse();
			try {
				response.Success = FileRepository.UploadFile(fileUploadInfo);
			} catch (Exception ex) {
				response.Exception = ex;
				response.Success = false;
			}
			return response;
		}

		#endregion

	}

	#endregion

}
