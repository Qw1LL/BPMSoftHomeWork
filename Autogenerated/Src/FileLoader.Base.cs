namespace BPMSoft.Configuration.FileLoad
{
	using System;
	using System.Data;
	using System.IO;
	using global::Common.Logging;
	using BPMSoft.Configuration.FileUpload;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.File;
	using BPMSoft.File.Abstractions;

	#region Class: FileLoader

	/// <summary>
	/// Represents class for loading file.
	/// </summary>
	public class FileLoader
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of the <see cref="FileLoader"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public FileLoader(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private bool _isInitializedFeatureUseFileApi;
		private bool _featureUseFileApi;

		/// <summary>
		/// Gets or sets value that indicates the feature "FeatureUseFileApi" state.
		/// </summary>
		private bool UseFileApi {
			get {
				if (_isInitializedFeatureUseFileApi) {
					return _featureUseFileApi;
				}
				return GlobalAppSettings.FeatureUseFileApi;
			}
			set {
				_featureUseFileApi = value;
				_isInitializedFeatureUseFileApi = true;
			}
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Gets user connection.
		/// </summary>
		protected UserConnection UserConnection => _userConnection;

		/// <summary>
		/// Gets logger.
		/// </summary>
		protected readonly ILog Log = LogManager.GetLogger("FileLoader");

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag indicating whether to use a content stream when loading a file.
		/// </summary>
		public bool UseContentStreamOnFileLoad { get; set; }

		#endregion

		#region Methods: Private

		private bool GetCanUseFileApi(EntitySchema entitySchema) {
			Entity entity = entitySchema.CreateEntity(UserConnection);
			return UseFileApi && (entity is BPMSoft.Configuration.File);
		}

		private IFileUploadInfo LoadFileUsingFileApi(string entitySchemaName, Guid fileId, BinaryWriter binaryWriter) {
			var fileLocator = new EntityFileLocator(entitySchemaName, fileId);
			IFile file = _userConnection.GetFileFactory().Get(fileLocator);
			if (!file.Exists) {
				Log.Info($"LoadFile: file not found with Id: ${fileId}");
				return null;
			}
			var fileInfo = new FileEntityUploadInfo(entitySchemaName, fileId, file.Name) {
				TotalFileLength = file.Length
			};
			if (UseContentStreamOnFileLoad) {
				fileInfo.File = file;
			} else {
				using (Stream stream = file.Read()) {
					stream.CopyTo(binaryWriter.BaseStream);
					binaryWriter.Flush();
				}
			}
			return fileInfo;
		}

		private IFileUploadInfo LoadFile(Guid fileId, BinaryWriter binaryWriter, EntitySchema entitySchema) {
			Entity entity = entitySchema.CreateEntity(UserConnection);
			var selectData = (Select)new Select(UserConnection)
					.Column("Name")
					.Column(Func.DataLength("Data")).As("Size")
					.Column("Data")
				.From(entity.SchemaName).WithHints(Hints.NoLock)
				.Where("Id").IsEqual(Column.Parameter(fileId));
			selectData.SpecifyNoLockHints();
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectData.ExecuteReader(executor, CommandBehavior.SequentialAccess)) {
					if (reader.Read()) {
						string fileName = reader["Name"].ToString();
						int sizeColumnIndex = reader.GetOrdinal("Size");
						object sizeValue = reader[sizeColumnIndex];
						if (DBNull.Value.Equals(sizeValue)) {
							Log.Info($"LoadFile: file size is null for fileId: ${fileId}");
							return null;
						}
						int size = UserConnection.DBTypeConverter.DBValueToInt(sizeValue);
						long offset = 0;
						const int bufferOffset = 0;
						const int chunkSize = 524288;
						var buffer = new byte[chunkSize];
						while (offset < size) {
							Array.Clear(buffer, 0, buffer.Length);
							long realBytes = reader.GetBytes(2, offset, buffer, bufferOffset, chunkSize);
							if (realBytes <= 0) {
								break;
							}
							offset += realBytes;
							binaryWriter.Write(buffer, 0, Convert.ToInt32(realBytes));
							binaryWriter.Flush();
						}
						return new FileEntityUploadInfo(entitySchema.Name, fileId, fileName) {
							TotalFileLength = size
						};
					}
				}
			}
			Log.Info($"LoadFile: file not found with Id: ${fileId}");
			return null;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Checks file access rights.
		/// </summary>
		/// <param name="entitySchema">Entity schema.</param>
		/// <param name="recordId">Identifier of the file entity.</param>
		/// <returns>Returns <c>true</c> when file can be read.</returns>
		protected bool CheckReadFileAccess(EntitySchema entitySchema, Guid recordId) {
			DBSecurityEngine securityEngine = UserConnection.DBSecurityEngine;
			SchemaRecordRightLevels rights = securityEngine.GetEntitySchemaRecordRightLevel(entitySchema, recordId);
			return (rights & SchemaRecordRightLevels.CanRead) == SchemaRecordRightLevels.CanRead;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads file.
		/// </summary>
		/// <param name="entitySchemaUId">UId of the entity schema.</param>
		/// <param name="fileId">Identifier of the file entity.</param>
		/// <param name="binaryWriter">Binary writer.</param>
		/// <returns>Information about uploaded file.</returns>
		public virtual IFileUploadInfo LoadFile(Guid entitySchemaUId, Guid fileId, BinaryWriter binaryWriter) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByUId(entitySchemaUId);
			if (!CheckReadFileAccess(entitySchema, fileId)) {
				Log.Info($"LoadFile: CheckReadFileAccess = false for fileId: ${fileId}");
				return null;
			}
			return GetCanUseFileApi(entitySchema)
				? LoadFileUsingFileApi(entitySchema.Name, fileId, binaryWriter)
				: LoadFile(fileId, binaryWriter, entitySchema);
		}

		#endregion

	}

	#endregion

}

