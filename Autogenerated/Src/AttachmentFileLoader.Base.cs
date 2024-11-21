namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.Linq;
	using EmailContract.DTO;
	using IntegrationApi.Interfaces;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	/// <summary>
	/// Functionality for downloading attachments.
	/// </summary>
	[DefaultBinding(typeof(IAttachmentFileLoader))]
	public class AttachmentFileLoader : IAttachmentFileLoader 
	{

		#region Fields: Private

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection _userConnection;

		/// <summary>
		/// File manager.
		/// </summary>
		private FileRepository _fileRepository;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// .ctor.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public AttachmentFileLoader(UserConnection userConnection) {
			_userConnection = userConnection;
			_fileRepository = ClassFactory.Get<FileRepository>(
				new ConstructorArgument("userConnection", _userConnection));
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IAttachmentFileLoader.GetAttachment(Guid, Guid)"/>
		public Attachment GetAttachment(Guid entitySchemaUId, Guid fileId) {
			var attach = new Attachment();
			using (var memoryStream = new MemoryStream()) { 
				var bwriter = new BinaryWriter(memoryStream);
				var fileInfo = _fileRepository.LoadFile(entitySchemaUId, fileId, bwriter);
				attach.Name = fileInfo.FileName;
				attach.Id = fileInfo.FileId.ToString();
				attach.SetData(memoryStream.ToArray());
			}
			return attach;
		}

		#endregion

	}
}
