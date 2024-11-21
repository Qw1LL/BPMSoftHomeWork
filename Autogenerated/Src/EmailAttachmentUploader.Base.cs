namespace BPMSoft.Configuration {
	using System;
	using System.IO;
	using IntegrationApi.Interfaces;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: EmailAttachmentUploader

	[DefaultBinding(typeof(IFileUploader), Name = "EmailAttachmentUploader")]
	public class EmailAttachmentUploader : IFileUploader
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public EmailAttachmentUploader(UserConnection uc) {
			_userConnection = uc;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IFileUploader.UploadAttach(Guid, string, byte[])"/>
		public void UploadAttach(Guid fileId, string name, byte[] data) {
			var fileRepository = ClassFactory.Get<FileRepository>(new ConstructorArgument("userConnection", _userConnection));
			var fileEntityInfo = new FileEntityUploadInfo("ActivityFile", fileId, name) {
				Content = new MemoryStream(data),
				TotalFileLength = data.Length
			};
			fileRepository.UploadFile(fileEntityInfo, false);
		}

		#endregion

	}

	#endregion

}

