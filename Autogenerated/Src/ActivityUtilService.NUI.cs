namespace BPMSoft.Configuration
{
	using System;
	using System.IO;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Common.ServiceRouting;

	#region Class: ActivityUtilService

	/// <summary>
	/// Utility service class for working with <see cref="Activity"/>.
	/// </summary>
	[DefaultServiceRoute]
	[SspServiceRoute]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ActivityUtilService: BaseService
	{
		#region Methods: Public

		/// <summary>
		/// Create <cref name="ActivityFile"/> record.
		/// </summary>
		/// <param name="jsonActivityFile"><cref name="JsonActivityFile"/> instance.</param>
		/// <returns><cref name="ActivityFile"/> record identifier.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid CreateActivityFileEntity(JsonActivityFile jsonActivityFile) {
			var fileRepository = ClassFactory.Get<FileRepository>(
						new ConstructorArgument("userConnection", UserConnection));
			var fileId = Guid.NewGuid();
			byte[] data = Convert.FromBase64String(jsonActivityFile.Data);
			var fileEntityInfo = new FileEntityUploadInfo("ActivityFile", fileId, jsonActivityFile.Name);
			fileEntityInfo.ParentColumnName = "Activity";
			fileEntityInfo.ParentColumnValue = jsonActivityFile.ActivityId;
			fileEntityInfo.TotalFileLength = jsonActivityFile.Size;
			fileEntityInfo.Content = new MemoryStream(data);
			fileEntityInfo.TypeId = jsonActivityFile.TypeId;
			fileEntityInfo.Version = jsonActivityFile.Version;
			fileRepository.UploadFile(fileEntityInfo);
							   
			return fileId;

		}

		/// <summary>
		/// Create file record.
		/// </summary>
		/// <param name="jsonEntityFile"><cref name="JsonEntityFile"/> instance.</param>
		/// <returns>New record identifier.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public Guid CreateFileEntity(JsonEntityFile jsonEntityFile) {
			var fileRepository = ClassFactory.Get<FileRepository>(
					new ConstructorArgument("userConnection", UserConnection));
			var fileId = Guid.NewGuid();
			byte[] data = Convert.FromBase64String(jsonEntityFile.Data);
			var fileEntityInfo = new FileEntityUploadInfo(jsonEntityFile.EntityName, fileId, jsonEntityFile.Name);
			fileEntityInfo.ParentColumnName = jsonEntityFile.EntityColumnName;
			fileEntityInfo.ParentColumnValue = jsonEntityFile.EntityId;
			fileEntityInfo.TotalFileLength = jsonEntityFile.Size;
			fileEntityInfo.Content = new MemoryStream(data);
			fileEntityInfo.TypeId = jsonEntityFile.TypeId;
			fileEntityInfo.Version = jsonEntityFile.Version;
			fileRepository.UploadFile(fileEntityInfo);	 
			
			return fileId;
		}

		#endregion

	}

	#endregion

	#region Class: BaseJsonFile

	/// <summary>
	/// Base JSON file object.
	/// </summary>
	[DataContract]
	public class BaseJsonFile
	{

		#region Properties: Public

		/// <summary>
		/// File name.
		/// </summary>
		[DataMember(Name = "name")]
		public string Name;

		/// <summary>
		/// File data.
		/// </summary>
		[DataMember(Name = "data")]
		public string Data;

		/// <summary>
		/// File type identifier.
		/// </summary>
		[DataMember(Name = "typeId")]
		public Guid TypeId;

		/// <summary>
		/// File size.
		/// </summary>
		[DataMember(Name = "size")]
		public int Size;

		/// <summary>
		/// File version.
		/// </summary>
		[DataMember(Name = "version")]
		public int Version;

		#endregion
	}

	#endregion

	#region Class: JsonActivityFile

	/// <summary>
	/// JSON object with <see cref="ActivityFile"/> properties.
	/// </summary>
	[DataContract]
	public class JsonActivityFile : BaseJsonFile
	{

		#region Properties: Public

		/// <summary>
		/// <see cref="ActivityFile"/> activity identifier.
		/// </summary>
		[DataMember(Name = "activityId")]
		public Guid ActivityId;

		#endregion
	}

	#endregion

	#region Class: JsonEntityFile

	/// <summary>
	/// Generic entity file JSON object.
	/// </summary>
	[DataContract]
	public class JsonEntityFile: BaseJsonFile
	{

		#region Properties: Public

		/// <summary>
		/// Parent entity name.
		/// </summary>
		[DataMember(Name = "entityName")]
		public string EntityName;

		/// <summary>
		/// Parent entity unique identifier.
		/// </summary>
		[DataMember(Name = "entityId")]
		public Guid EntityId;

		/// <summary>
		/// Parent entity lookup column name.
		/// </summary>
		[DataMember(Name = "entityColumnName")]
		public string EntityColumnName;

		#endregion
	}

	#endregion

}

