namespace BPMSoft.Configuration.Reporting.Word.Worker
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Security;
	using System.ServiceModel.Web;
	using DocumentFormat.OpenXml.Packaging;
	using BPMSoft.Configuration.RightsService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using ItemNotFoundException = BPMSoft.Configuration.ItemNotFoundException;

	#region Class: WordReportingDesignWorker

	/// <summary>
	/// Provides report generating functionality.
	/// </summary>
	public class WordReportingDesignWorker : IWordReportDesignWorker
	{

		#region Constants: Private

		private const string IdColumnName = "Id";
		private const string FileColumnName = "File";
		private const string TypeIdColumnName = "TypeId";
		private const string CopyRightAccessErrorMessage =
			"Current user haven`t rights for edit record with '{0}' id";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public WordReportingDesignWorker(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool CanUse7xFilters(UserConnection userConnection) {
			return FeatureUtilities.GetIsFeatureEnabled(userConnection, "Use7xFiltersForWordReports");
		}

		private string ChooseBetweenMacrosListAndMacrosSettings(string macrosList, string macrosSettings) {
			if (CanUse7xFilters(_userConnection)) {
				return !string.IsNullOrEmpty(macrosSettings) ? macrosSettings : macrosList;
			} else {
				return macrosList;
			}
		}

		private IEntitySchemaQueryFilterItem ReportTypeFilter(EntitySchemaQuery esq) {
			return esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type.Name", "MS Word");
		}

		private DataObjectSettingsDto GetDataSettingsDto(Guid reportId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysModuleReport");
			var macrosListColumnName = esq.AddColumn("MacrosList").Name;
			var macrosSettingsColumnName = esq.AddColumn("MacrosSettings").Name;
			var sysEntitySchemaUIdColumnName = esq.AddColumn("SysModule.SysModuleEntity.SysEntitySchemaUId").Name;
			var sysSchemaCaptionColumnName =
				esq.AddColumn("SysModule.SysModuleEntity.[VwSysSchemaInWorkspace:UId:SysEntitySchemaUId].Caption").Name;
			var entity = esq.GetEntity(_userConnection, reportId);
			if (entity == null) {
				throw new WebFaultException(HttpStatusCode.NotFound);
			}
			var macrosList = entity.GetTypedColumnValue<string>(macrosListColumnName);
			var macrosSettigns = entity.GetTypedColumnValue<string>(macrosSettingsColumnName);
			return new DataObjectSettingsDto {
				Caption = entity.GetTypedColumnValue<string>(sysSchemaCaptionColumnName),
				MacrosCollection = ChooseBetweenMacrosListAndMacrosSettings(macrosList, macrosSettigns),
				EntitySchemaUId = entity.GetTypedColumnValue<Guid>(sysEntitySchemaUIdColumnName),
			};
		}

		private RightsHelper GetRightsServiceHelper() {
			return ClassFactory.Get<RightsHelper>(new ConstructorArgument("userConnection", _userConnection));
		}

		private DataObjectSettingsDto[] GetTableDataDto(Guid reportId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysModuleReportTable");
			var captionColumnName = esq.AddColumn("Caption").Name;
			var objectIdColumnName = esq.AddColumn("ObjectId").Name;
			var macrosListColumnName = esq.AddColumn("MacrosList").Name;
			var macrosSettingsColumnName = esq.AddColumn("MacrosSettings").Name;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysModuleReport", reportId));
			var collection = esq.GetEntityCollection(_userConnection);
			return collection.Select(x => new DataObjectSettingsDto {
				Caption = x.GetTypedColumnValue<string>(captionColumnName),
				EntitySchemaUId = x.GetTypedColumnValue<Guid>(objectIdColumnName),
				MacrosCollection = ChooseBetweenMacrosListAndMacrosSettings(
					x.GetTypedColumnValue<string>(macrosListColumnName), 
					x.GetTypedColumnValue<string>(macrosSettingsColumnName))
			}).ToArray();
		}

		private Entity GetTemplateFile(Guid fileId) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("SysReportTemplate");
			Entity entity = entitySchema.CreateEntity(_userConnection);
			if (!entity.FetchFromDB(fileId)) {
				throw new ItemNotFoundException(_userConnection, fileId.ToString(), "WordReportingDesignWorker");
			}
			return entity;
		}

		private void SaveEntityFile(Stream template, Guid reportId) {
			Entity entity = GetReportEntity(reportId);
			entity.SetStreamValue(FileColumnName, template);
			entity.Save();
		}

		private Entity GetReportEntity(Guid reportId) {
			EntitySchema entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("SysModuleReport");
			var esq = new EntitySchemaQuery(entitySchema);
			esq.AddAllSchemaColumns();
			esq.Filters.Add(ReportTypeFilter(esq));
			Entity result = esq.GetEntity(_userConnection, reportId);
			if (result == null) {
				throw new ItemNotFoundException(_userConnection, reportId.ToString(), "WordReportingDesignWorker");
			}
			return result;
		}

		private void ClearTempTemplate(Guid reportId) {
			var date = DateTime.Now.AddDays(-1).Date;
			Query delete = new Delete(_userConnection)
				.From("SysReportTemplate")
				.Where("ReportId")
					.IsEqual(Column.Parameter(reportId))
				.Or("CreatedOn")
					.IsGreaterOrEqual(Column.Parameter(date));
			delete.Execute();
		}

		private void ValidateUserAccessRight(string schemaName, params Guid[] reportIds) {
			RightsHelper rightsHelper = GetRightsServiceHelper();
			foreach (var reportId in reportIds) {
				bool canEdit = rightsHelper.GetCanEditSchemaRecordRight(schemaName, reportId);
				if (!canEdit) {
					throw new SecurityException(string.Format(CopyRightAccessErrorMessage, reportId));
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get all reports.
		/// </summary>
		/// <returns>Returns reports collection.</returns>
		public IEnumerable<WordReportMainInfoDto> GetReportsCollection() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysModuleReport");
			var idColumnName = esq.AddColumn(IdColumnName).Name;
			var captionColumnName = esq.AddColumn("Caption").Name;
			var sysModuleIdColumnName = esq.AddColumn("SysModule.Id").Name;
			var sysModuleCaptionColumnName = esq.AddColumn("SysModule.Caption").Name;
			esq.Filters.Add(ReportTypeFilter(esq));
			return esq.GetEntityCollection(_userConnection).Select(x => new WordReportMainInfoDto {
				ReportId = x.GetTypedColumnValue<Guid>(idColumnName),
				ReportCaption = x.GetTypedColumnValue<string>(captionColumnName),
				SysModuleId = x.GetTypedColumnValue<Guid>(sysModuleIdColumnName),
				SysModuleCaption = x.GetTypedColumnValue<string>(sysModuleCaptionColumnName)
			});
		}

		/// <summary>
		/// Get report.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		/// <returns>Returns report.</returns>
		public WordReportSettingsDto GetReportSettings(Guid reportId) {
			DataObjectSettingsDto settings = GetDataSettingsDto(reportId);
			DataObjectSettingsDto[] tables = GetTableDataDto(reportId);
			return new WordReportSettingsDto {
				ReportId = reportId,
				MainDataObjectSettings = settings,
				TableDataObjectSettingsCollection = tables
			};
		}

		/// <summary>
		/// Upload report template.
		/// </summary>
		/// <param name="template">Template stream.</param>
		/// <param name="reportId">Report id.</param>
		public void SaveTemplate(Stream template, Guid reportId) {
			SaveEntityFile(template, reportId);
			ClearTempTemplate(reportId);
		}

		public Stream ValidateTemplate(Guid fileId) {
			try {
				Entity entity = GetTemplateFile(fileId);
				var bytes = entity.GetBytesValue(FileColumnName);
				MemoryStream stream = new MemoryStream(bytes);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, false)) {
					docx.Close();
				}
				stream.Seek(0, SeekOrigin.Begin);
				return stream;
			} catch (Exception e) {
				throw new ArgumentException(e.Message);
			}
		}

		/// <summary>
		/// Remove report template.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		/// <returns>Returns base response.</returns>
		public void RemoveTemplate(Guid reportId) {
			SaveEntityFile(null, reportId);
		}

		/// <summary>
		/// Download report template.
		/// </summary>
		/// <param name="reportId">Report id.</param>
		/// <returns>Returns template stream.</returns>
		public (Stream, string) DownloadTemplate(Guid reportId) {
			var entity = GetReportEntity(reportId);
			var file = entity.GetStreamValue(FileColumnName);
			var caption = entity.GetColumnValue("Caption").ToString();
			return (file, caption);
		}

		/// <summary>
		/// Copies report template file from source record to destination record.
		/// </summary>
		/// <param name="sourceReportId">Source report id.</param>
		/// <param name="destinationReportId">Destination report id.</param>
		public void CopyTemplate(Guid sourceReportId, Guid destinationReportId) {
			Entity entity = GetReportEntity(sourceReportId);
			var typeId = entity.GetTypedColumnValue<Guid>(TypeIdColumnName);
			ValidateUserAccessRight(entity.SchemaName, sourceReportId, destinationReportId);
			var selectQuery = new Select(_userConnection)
				.Column(FileColumnName)
				.From(entity.SchemaName)
				.Where(IdColumnName).IsEqual(Column.Parameter(sourceReportId))
				.And(TypeIdColumnName).IsEqual(Column.Parameter(typeId)) as Select;
			var updateQuery = new Update(_userConnection, entity.SchemaName)
				.Set(FileColumnName, selectQuery)
				.Where(IdColumnName).IsEqual(Column.Parameter(destinationReportId));
			updateQuery.Execute();
		}

		#endregion

	}

	#endregion

}

