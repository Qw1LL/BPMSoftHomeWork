namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.File;
	using BPMSoft.WebApp;

	#region Class: ObjectFileProcessingUserTask

	/// <summary>
	/// Represents user task to process object files.
	/// </summary>
	public partial class ObjectFileProcessingUserTask
	{

		#region Properties: Public

		private IFileProcessing _fileProcessing;

		/// <summary>
		/// Gets or sets instance that provides methods for the processing files.
		/// </summary>
		public IFileProcessing FileProcessing {
			get => _fileProcessing ?? (_fileProcessing = new FileProcessing(UserConnection));
			set => _fileProcessing = value;
		}

		#endregion

		#region Methods: Private

		private void SetCreatedObjectFileIds(IList<EntityFileLocator> createdFileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (EntityFileLocator createdFileLocator in createdFileLocators) {
				var compositeObject = new CompositeObject {
					{ "Id", createdFileLocator.RecordId }
				};
				compositeObjectList.Add(compositeObject);
			}
			CreatedObjectFileIds = compositeObjectList;
		}

		private void SetReadObjectFiles(IList<EntityFileLocator> fileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (EntityFileLocator fileLocator in fileLocators) {
				var compositeObject = new CompositeObject {
					{ "File",  fileLocator }
				};
				compositeObjectList.Add(compositeObject);
			}
			ObjectFiles = compositeObjectList;
		}

		private void ReadFiles(EntitySchemaQuery esq) {
			IList<EntityFileLocator> fileLocators = FileProcessing.GetFileLocators(esq);
			SetReadObjectFiles(fileLocators);
			SetCreatedObjectFileIds(new List<EntityFileLocator>());
		}

		private void CopyFiles(EntitySchemaQuery esq) {
			var settings = new ObjectFilesCopySettings {
				EntitySchemaQuery = esq,
				TargetEntitySchemaUId = TargetEntitySchemaUId,
				ConnectedObjectId = ConnectedObjectId,
				ConnectedObjectColumnUId = ConnectedObjectColumnUId
			};
			FileCopyResults fileCopyResults = FileProcessing.Copy(settings);
			SetReadObjectFiles(fileCopyResults.SourceFileLocators);
			SetCreatedObjectFileIds(fileCopyResults.TargetFileLocators);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema sourceSchema = entitySchemaManager.GetInstanceByUId(SourceEntitySchemaUId);
			ResultActionTypeEnum actionType = (ResultActionTypeEnum)ResultActionType;
			var esq = new EntitySchemaQuery(sourceSchema) {
				RowCount = RecordsToRead
			};
			ProcessUserTaskUtilities.SpecifyESQFilters(UserConnection, this, sourceSchema, esq, DataSourceFilters);
			ProcessUserTaskUtilities.SpecifyESQOrderByStatement(esq, OrderByInfo);
			IEntitySchemaQueryFilterItem filterItem = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type",
				FileConsts.FileTypeUId);
			esq.Filters.Add(filterItem);
			if (actionType == ResultActionTypeEnum.SaveToFiles) {
				CopyFiles(esq);
			} else if (actionType == ResultActionTypeEnum.UseInProcess) {
				ReadFiles(esq);
			} else {
				throw new NotSupportedException(actionType.ToLocalizedString());
			}
			return true;
		}

		#endregion

	}

	#endregion

}
