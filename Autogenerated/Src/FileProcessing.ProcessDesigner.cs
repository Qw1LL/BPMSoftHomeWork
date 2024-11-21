namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.File;
	using BPMSoft.File.Abstractions;
	using IFile = BPMSoft.File.Abstractions.IFile;

	#region Enum: ResultActionTypeEnum

	/// <summary>
	/// Determines the result action to execute.
	/// </summary>
	public enum ResultActionTypeEnum
	{
		/// <summary>
		/// Save result to object file.
		/// </summary>
		SaveToFiles,

		/// <summary>
		/// Store result to result parameter.
		/// </summary>
		UseInProcess
	}

	#endregion

	#region Class: FileCopyResults

	/// <summary>
	/// Represents file copy results.
	/// </summary>
	public class FileCopyResults
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets entity file locators of read object files.
		/// </summary>
		public IList<EntityFileLocator> SourceFileLocators { get; set; }

		/// <summary>
		/// Gets or sets entity file locators of created object files.
		/// </summary>
		public IList<EntityFileLocator> TargetFileLocators { get; set; }

		#endregion

	}

	#endregion

	#region Interface: IFileProcessing

	/// <summary>
	/// Provides methods for the processing files.
	/// </summary>
	public interface IFileProcessing
	{

		#region Methods: Public

		/// <summary>
		/// Copies an existing files to new files.
		/// </summary>
		/// <param name="settings">Object files copy settings.</param>
		/// <returns>Identifiers of read and created object files.</returns>
		FileCopyResults Copy(ObjectFilesCopySettings settings);

		/// <summary>
		/// Returns file identifiers.
		/// </summary>
		/// <param name="esq">ESQ.</param>
		/// <returns>List of file locators.</returns>
		IList<EntityFileLocator> GetFileLocators(EntitySchemaQuery esq);

		#endregion

	}

	#endregion

	#region Class: FileProcessing

	/// <inheritdoc />
	public class FileProcessing : IFileProcessing
	{

		#region Constants: Public

		public const int DefVersion = 1;

		#endregion

		#region Fields: Private

		private readonly IReadOnlyList<string> _columnNamesToRead = new List<string> {
			"Name",
			"Type",
			"Size"
		}.AsReadOnly();
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Creates a new instance of the <see cref="FileProcessing"/> type.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public FileProcessing(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		private bool _isInitializedUseFileStorageInProcessUserTasks;
		private bool _useFileStorageInProcessUserTasks;

		/// <summary>
		/// Gets or sets value that indicates the feature "FeatureUseFileStorageInProcessUserTasks" state.
		/// </summary>
		public bool UseFileStorageInProcessUserTasks {
			get {
				if (_isInitializedUseFileStorageInProcessUserTasks) {
					return _useFileStorageInProcessUserTasks;
				}
				return GlobalAppSettings.FeatureUseFileStorageInProcessUserTasks;
			}
			set {
				_useFileStorageInProcessUserTasks = value;
				_isInitializedUseFileStorageInProcessUserTasks = true;
			}
		}

		#endregion

		#region Methods: Private

		private static EntitySchemaQuery InitializeEntitySchemaQuery(EntitySchemaQuery esq) {
			esq.UseAdminRights = false;
			esq.CanReadUncommitedData = true;
			esq.IgnoreDisplayValues = true;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq;
		}

		private static IList<EntitySchemaColumn> AddEntitySchemaQueryColumns(EntitySchemaQuery esq,
				EntitySchema targetSchema, IReadOnlyList<string> columnNamesToRead) {
			var schemaColumnsToRead = new List<EntitySchemaColumn>();
			EntitySchemaColumnCollection targetSchemaColumns = targetSchema.Columns;
			foreach (string columnNameToRead in columnNamesToRead) {
				EntitySchemaColumn targetSchemaColumn = targetSchemaColumns.GetByName(columnNameToRead);
				schemaColumnsToRead.Add(targetSchemaColumn);
				esq.AddColumn(columnNameToRead);
			}
			return schemaColumnsToRead;
		}

		private static void CopyColumnValue(Entity sourceEntity, Entity targetEntity,
				IList<EntitySchemaColumn> schemaColumnsToRead) {
			foreach (EntitySchemaColumn schemaColumn in schemaColumnsToRead) {
				string columnValueName = schemaColumn.ColumnValueName;
				EntityColumnValue entityColumnValue = sourceEntity.FindEntityColumnValue(columnValueName);
				if (entityColumnValue.IsLoaded) {
					targetEntity.SetColumnValue(columnValueName, entityColumnValue.Value);
				}
			}
		}

		private Entity CreateTargetEntity(EntitySchema targetSchema) {
			Entity targetEntity = targetSchema.CreateEntity(_userConnection);
			targetEntity.SetDefColumnValues();
			targetEntity.SetColumnValue("Version", DefVersion);
			return targetEntity;
		}

		private FileCopyResults InternalCopy(ObjectFilesCopySettings settings) {
			EntitySchemaQuery esq = InitializeEntitySchemaQuery(settings.EntitySchemaQuery);
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			EntitySchema targetSchema = entitySchemaManager.GetInstanceByUId(settings.TargetEntitySchemaUId);
			IList<EntitySchemaColumn> schemaColumnsToRead = AddEntitySchemaQueryColumns(esq, targetSchema,
				_columnNamesToRead);
			EntitySchemaColumnCollection targetSchemaColumns = targetSchema.Columns;
			bool isSetConnectedObject = settings.ConnectedObjectColumnUId.IsNotEmpty() &&
				settings.ConnectedObjectId.IsNotEmpty();
			string connectedObjectColumnName = string.Empty;
			if (isSetConnectedObject) {
				EntitySchemaColumn connectedObjectColumn = targetSchemaColumns
					.GetByUId(settings.ConnectedObjectColumnUId);
				connectedObjectColumnName = connectedObjectColumn.ColumnValueName;
			}
			EntityCollection sourceEntities = esq.GetEntityCollection(_userConnection);
			IFileCopier copier = ClassFactory.Get<IFileCopier>();
			var sourceFileLocators = new List<EntityFileLocator>();
			var targetFileLocators = new List<EntityFileLocator>();
			foreach (Entity sourceEntity in sourceEntities) {
				Entity targetEntity = CreateTargetEntity(targetSchema);
				if (isSetConnectedObject) {
					targetEntity.SetColumnValue(connectedObjectColumnName, settings.ConnectedObjectId);
				}
				CopyColumnValue(sourceEntity, targetEntity, schemaColumnsToRead);
				copier.Copy(sourceEntity, targetEntity);
				targetEntity.UseAdminRights = false;
				targetEntity.Save();
				var sourceFileLocator = new EntityFileLocator(esq.RootSchema.Name, sourceEntity.PrimaryColumnValue);
				var targetFileLocator = new EntityFileLocator(targetSchema.Name, targetEntity.PrimaryColumnValue);
				sourceFileLocators.Add(sourceFileLocator);
				targetFileLocators.Add(targetFileLocator);
			}
			return new FileCopyResults {
				SourceFileLocators = sourceFileLocators,
				TargetFileLocators = targetFileLocators
			};
		}

		private FileCopyResults CopyUseFileFactory(ObjectFilesCopySettings settings) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			EntitySchema targetEntitySchema = entitySchemaManager.GetInstanceByUId(settings.TargetEntitySchemaUId);
			EntitySchemaColumn connectedColumn = targetEntitySchema.Columns.FindByUId(
				settings.ConnectedObjectColumnUId);
			IFileFactory fileFactory = _userConnection.GetFileFactory().WithRightsDisabled();
			EntitySchemaQuery esq = settings.EntitySchemaQuery;
			IList<EntityFileLocator> sourceFileLocators = GetFileLocators(esq);
			var targetFileLocators = new List<EntityFileLocator>();
			foreach (EntityFileLocator sourceFileLocator in sourceFileLocators) {
				Guid entityId = Guid.NewGuid();
				var targetFileLocator = new EntityFileLocator(targetEntitySchema.Name, entityId);
				IFile targetFile = CreateFile(fileFactory, targetFileLocator, connectedColumn,
					settings.ConnectedObjectId);
				targetFileLocators.Add(targetFileLocator);
				IFile sourceFile = fileFactory.Get(sourceFileLocator);
				sourceFile.Copy(targetFile);
			}
			return new FileCopyResults {
				SourceFileLocators = sourceFileLocators,
				TargetFileLocators = targetFileLocators
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates new object file.
		/// </summary>
		/// <param name="fileFactory"><see cref="BPMSoft.File.Abstractions.IFileFactory" /> instance.</param>
		/// <param name="fileLocator">File locator for new file.</param>
		/// <param name="connectedColumn">Connected object column.</param>
		/// <param name="connectedObjectId">Connected object unique identifier.</param>
		/// <returns>Created file.</returns>
		public static IFile CreateFile(IFileFactory fileFactory, EntityFileLocator fileLocator,
				EntitySchemaColumn connectedColumn, Guid connectedObjectId) {
			IFile file = fileFactory.Create(fileLocator);
			if (connectedColumn != null) {
				file.SetAttribute(connectedColumn.ColumnValueName, connectedObjectId);
			}
			file.SetAttribute("Version", DefVersion);
			return file;
		}

		/// <inheritdoc />
		public FileCopyResults Copy(ObjectFilesCopySettings settings) {
			return UseFileStorageInProcessUserTasks ? CopyUseFileFactory(settings) : InternalCopy(settings);
		}

		/// <inheritdoc />
		public IList<EntityFileLocator> GetFileLocators(EntitySchemaQuery esq) {
			esq = InitializeEntitySchemaQuery(esq);
			var fileLocators = new List<EntityFileLocator>();
			string schemaName = esq.RootSchema.Name;
			Select select = esq.GetSelectQuery(_userConnection);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var id = dataReader.GetColumnValue<Guid>("Id");
						var fileLocator = new EntityFileLocator(schemaName, id);
						fileLocators.Add(fileLocator);
					}
				}
			}
			return fileLocators;
		}

		#endregion

	}

	#endregion

}

