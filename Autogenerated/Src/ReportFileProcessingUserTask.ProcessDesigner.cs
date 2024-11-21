namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.File;
	using BPMSoft.File.Abstractions;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using EntitySchemaColumn = BPMSoft.Core.Entities.EntitySchemaColumn;
	using ReportSettings = BPMSoft.Configuration.ReportSettings;

	#region Class: ReportFileProcessingUserTask

	/// <summary>
	/// Represents user task to generate report files.
	/// </summary>
	public partial class ReportFileProcessingUserTask
	{

		#region Properties: Public

		private IReportEngine _reportEngine;

		/// <summary>
		/// Gets or sets instance that provides methods for generating reports.
		/// </summary>
		public IReportEngine ReportEngine {
			get => _reportEngine ?? (_reportEngine = new ReportEngine(UserConnection));
			set => _reportEngine = value;
		}

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

		private static string GenerateSeparateReportSuffix(IReadOnlyDictionary<Guid, string> reportNameColumns,
				IReportResult report, int index) {
			return reportNameColumns?[report.RecordId].IsNotEmpty() == true
				? $". {reportNameColumns[report.RecordId]}"
				: $" ({index})";
		}

		private static IFileLocator SaveToFile(IFile reportFile, IReportResult report, string fileName) {
			reportFile.Name = fileName;
			reportFile.Write(report.Data);
			return reportFile.FileLocator;
		}

		private void SetReportFiles(IEnumerable<IFileLocator> fileLocators) {
			var compositeObjectList = new CompositeObjectList<CompositeObject>();
			foreach (IFileLocator fileLocator in fileLocators) {
				var compositeObject = new CompositeObject {
					{ "File",  fileLocator }
				};
				compositeObjectList.Add(compositeObject);
			}
			ReportFiles = compositeObjectList;
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

		private Func<IFile> GetFileFactory() {
			Func<IFile> fileFactory;
			ResultActionTypeEnum actionType = (ResultActionTypeEnum)ResultActionType;
			switch (actionType) {
				case ResultActionTypeEnum.SaveToFiles:
					fileFactory = GetEntityFileFactory();
					break;
				case ResultActionTypeEnum.UseInProcess:
					fileFactory = CreateTempFile;
					break;
				default:
					throw new NotSupportedException(actionType.ToLocalizedString());
			}
			return fileFactory;
		}

		private Dictionary<Guid, string> GetReportNameColumns(string entitySchemaName, Filters filters) {
			var result = new Dictionary<Guid, string>();
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema schema = entitySchemaManager.GetInstanceByName(entitySchemaName);
			IEntitySchemaQueryFilterItem esqFilters = filters.BuildEsqFilter(schema.UId, UserConnection);
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchemaName) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsVisible = true;
			EntitySchemaColumn column = schema.Columns.GetByUId(ReportNameDataSourceColumnUId);
			esq.AddColumn(column.Name);
			esq.Filters.Add(esqFilters);
			Select select = esq.GetSelectQuery(UserConnection);
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var key = dataReader.GetColumnValue<Guid>("Id");
						var value = dataReader.GetColumnValue<string>(column.Name);
						result.Add(key, value);
					}
				}
			}
			return result;
		}

		private void SaveReports(IEnumerable<IReportResult> reports, Func<IReportResult, int, string> nameGenerator) {
			var reportFiles = new List<IFileLocator>();
			CreatedObjectFileIds = new CompositeObjectList<CompositeObject>();
			Func<IFile> fileFactory = GetFileFactory();
			int index = 1;
			foreach (IReportResult report in reports) {
				string fileName = nameGenerator(report, index);
				IFile resultFile = fileFactory();
				IFileLocator fileLocator = SaveToFile(resultFile, report, fileName);
				reportFiles.Add(fileLocator);
				index++;
			}
			SetReportFiles(reportFiles);
		}

		private Func<IReportResult, int, string> GetFileNameGenerator(Filters filters) {
			Dictionary<Guid, string>  reportNameColumns = null;
			string reportPrefix = null;
			return (report, index) => {
				if (reportNameColumns == null && ReportNameDataSourceColumnUId.IsNotEmpty()) {
					reportNameColumns = GetReportNameColumns(report.ReportTemplateInfo.EntitySchemaName, filters);
				}
				reportPrefix = reportPrefix ?? GetReportPrefix(report.ReportTemplateInfo);
				string fileName = IsSeparateReports
					? reportPrefix + GenerateSeparateReportSuffix(reportNameColumns, report, index)
					: reportPrefix;
				return fileName + report.ReportExtension;
			};
		}

		private string GetReportPrefix(IReportTemplateInfo templateInfo) {
			return ReportName.IsNotNullOrEmpty() && ReportNameDataSourceColumnUId.IsEmpty()
				? templateInfo.Caption + ". " + ReportName
				: templateInfo.Caption;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override bool InternalExecute(ProcessExecutingContext context) {
			Filters filters = ProcessUserTaskUtilities.GetInitializedFilters(Owner, DataSourceFilters);
			var reportSettings = new ReportSettings {
				Id = ReportId,
				Filters = filters,
				IsSeparateReports = IsSeparateReports
			};
			IEnumerable<IReportResult> reports = ReportEngine.Generate(reportSettings);
			Func<IReportResult, int, string> nameGenerator = GetFileNameGenerator(filters);
			SaveReports(reports, nameGenerator);
			return true;
		}

		#endregion

	}

	#endregion

}
