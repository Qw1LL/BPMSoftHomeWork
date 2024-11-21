namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.File;
	using BPMSoft.File.Abstractions;

	#region Class: ProcessFileProcessingUserTask

	/// <summary>
	/// Represents user task to process files from process parameter.
	/// </summary>
	public partial class ProcessFileProcessingUserTask
	{

		#region Properties: Public

		private IFileFactory _fileFactory;

		/// <summary>
		/// Gets or sets instance that implements <see cref="IFileFactory"/> interface.
		/// </summary>
		public IFileFactory FileFactory {
			get => _fileFactory ?? (_fileFactory = UserConnection.GetFileFactory().WithRightsDisabled());
			set => _fileFactory = value;
		}

		#endregion

		#region Methods: Private

		private void SetObjectFiles(IEnumerable<IFileLocator> fileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (IFileLocator fileLocator in fileLocators) {
				var compositeObject = new CompositeObject {
					{ "ObjectFile",  fileLocator }
				};
				compositeObjectList.Add(compositeObject);
			}
			ObjectFiles = compositeObjectList;
		}

		private Func<IFile> GetEntityFileFactory() {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema targetEntitySchema = entitySchemaManager.GetInstanceByUId(TargetEntitySchemaUId);
			EntitySchemaColumn connectedColumn = targetEntitySchema.Columns.FindByUId(ConnectedObjectColumnUId);
			return () => {
				Guid fileId = Guid.NewGuid();
				var compositeObject = new CompositeObject {
					{ "Id", fileId }
				};
				((CompositeObjectList<CompositeObject>)CreatedObjectFileIds).Add(compositeObject);
				var fileLocator = new EntityFileLocator(targetEntitySchema.Name, fileId);
				return FileProcessing.CreateFile(FileFactory, fileLocator, connectedColumn, ConnectedObjectId);
			};
		}

		private void SaveEntityFiles() {
			var objectFiles = new List<IFileLocator>();
			CreatedObjectFileIds = new CompositeObjectList<CompositeObject>();
			Func<IFile> fileFactory = GetEntityFileFactory();
			foreach (ICompositeObject compositeObject in Files) {
				if (compositeObject.TryGetValue("File", out IFileLocator sourceFileLocator)) {
					IFile sourceFile = UserConnection.GetFile(sourceFileLocator);
					IFile targetFile = fileFactory();
					targetFile.Name = sourceFile.Name;
					sourceFile.Copy(targetFile);
					objectFiles.Add(targetFile.FileLocator);
				}
			}
			SetObjectFiles(objectFiles);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			ResultActionTypeEnum actionType = (ResultActionTypeEnum)ResultActionType;
			if (actionType == ResultActionTypeEnum.SaveToFiles) {
				SaveEntityFiles();
			} else {
				throw new NotSupportedException(actionType.ToLocalizedString());
			}
			return true;
		}

		#endregion

	}

	#endregion

}
