namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Reflection;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Reporting.FastReportEngine;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Reporting.Abstractions.Data;
	using BPMSoft.Reporting.FastReport;
	using DataValueType = BPMSoft.Nui.ServiceModel.DataContract.DataValueType;
	using EntityCollection = BPMSoft.Core.Entities.EntityCollection;
	using EntitySchema = BPMSoft.Core.Entities.EntitySchema;
	using FilterType = BPMSoft.Nui.ServiceModel.DataContract.FilterType;
	using IMsWordReportGenerator = IReportGenerator;
	using IFastReportGenerator = BPMSoft.Reporting.Abstractions.IReportGenerator;

	#region Class: ReportEngine

	/// <inheritdoc cref="IReportEngine"/>
	[DefaultBinding(typeof(IReportEngine))]
	public class ReportEngine : IReportEngine
	{

		#region Class: ReportInfo

		private class ReportTemplateInfo : IReportTemplateInfo
		{

			#region Properties: Public

			public Guid Id { get; set; }

			public string Caption { get; set; }

			public string TypeName { get; set; }

			public ReportType Type => GetReportType(TypeName);

			public string EntitySchemaName { get; set; }

			public Guid TemplateId { get; set; }

			public bool ConvertInPDF { get; set; }

			#endregion

		}

		#endregion

		#region Class: ReportResult

		private class ReportResult : IReportResult
		{

			#region Properties: Public

			public byte[] Data { get; set; }

			public Guid RecordId { get; set; }

			public IReportTemplateInfo ReportTemplateInfo { get; set; }

			public string ReportExtension { get; set;  }

			#endregion

		}

		#endregion

		#region Fields: Private

		private static readonly Dictionary<string, ReportType> _reportTypeNameMap =
			new Dictionary<string, ReportType>();
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Private

		static ReportEngine() {
			InitReportTypeNameMap();
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ReportEngine"/> type.
		/// </summary>
		/// <param name="userConnection">Instance of the <see cref="UserConnection"/> to initialize current
		/// instance with.</param>
		public ReportEngine(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static void InitReportTypeNameMap() {
			Type enumType = typeof(ReportType);
			foreach (object enumValue in Enum.GetValues(enumType)) {
				var enumTypeField = enumType.GetField(enumValue.ToString());
				var descriptionAttribute = enumTypeField.GetCustomAttribute<DescriptionAttribute>();
				if (descriptionAttribute != null) {
					_reportTypeNameMap[descriptionAttribute.Description] = (ReportType)enumValue;
				}
			}
		}

		private static ReportType GetReportType(string reportTypeName) {
			return _reportTypeNameMap.TryGetValue(reportTypeName, out var reportType)
				? reportType
				: 0;
		}

		private static Filters CreateSingleRecordFilters(Guid recordId) {
			var filterCollection = new Dictionary<string, Filter>();
			var filter = new Filter {
				FilterType = FilterType.CompareFilter,
				LeftExpression = new BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.SchemaColumn,
					ColumnPath = "Id"
				},
				ComparisonType = FilterComparisonType.Equal,
				RightExpression = new BaseExpression {
					ExpressionType = EntitySchemaQueryExpressionType.Parameter,
					Parameter = new Parameter {
						DataValueType = DataValueType.Guid,
						Value = recordId,
					}
				}
			};
			filterCollection.Add("SingleRecordFilter", filter);
			var filters = new Filters {
				FilterType = FilterType.FilterGroup,
				LogicalOperation = LogicalOperationStrict.And,
				Items = filterCollection
			};
			return filters;
		}

		private static IReportResult GetReportResult(byte[] reportData, Guid recordId,
				IReportTemplateInfo reportTemplateInfo, string reportExtension) {
			return new ReportResult {
				Data = reportData,
				RecordId = recordId,
				ReportTemplateInfo = reportTemplateInfo,
				ReportExtension = reportExtension
			};
		}

		private EntitySchemaQuery GetReportsEntitySchemaQuery() {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName("SysModuleReport");
			var esq = new EntitySchemaQuery(entitySchema) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Caption");
			esq.AddColumn("Type.Name").Name = "TypeName";
			esq.AddColumn("SysReportSchemaUId");
			esq.AddColumn("SysModule.SysModuleEntity.[SysSchema:UId:SysEntitySchemaUId].Name")
				.Name = "EntitySchemaName";
			esq.AddColumn("ConvertInPDF");
			return esq;
		}

		private ReportTemplateInfo GetReportInfoFromDb(Guid id) {
			EntitySchemaQuery esq = GetReportsEntitySchemaQuery();
			Entity entity = esq.GetEntity(_userConnection, id);
			if (entity != null) {
				var reportInfo = new ReportTemplateInfo {
					Id = id,
					Caption = entity.GetTypedColumnValue<string>("Caption"),
					TypeName = entity.GetTypedColumnValue<string>("TypeName"),
					EntitySchemaName = entity.GetTypedColumnValue<string>("EntitySchemaName"),
					ConvertInPDF = entity.GetTypedColumnValue<bool>("ConvertInPDF")
				};
				reportInfo.TemplateId = reportInfo.Type == ReportType.MsWord
					? id
					: entity.GetTypedColumnValue<Guid>("SysReportSchemaUId");
				return reportInfo;
			}
			string messageTemplate = new LocalizableString(_userConnection.Workspace.ResourceStorage, "ReportEngine",
				"LocalizableStrings.ReportNotFoundById.Value");
			string message = string.Format(messageTemplate, id);
			throw new ArgumentException(message);
		}

		private IEnumerable<Guid> GetRecordIdsByFilters(string entitySchemaName, Filters filters) {
			EntitySchemaManager entitySchemaManager = _userConnection.EntitySchemaManager;
			EntitySchema schema = entitySchemaManager.GetInstanceByName(entitySchemaName);
			IEntitySchemaQueryFilterItem esqFilters = filters.BuildEsqFilter(schema.UId, _userConnection);
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchemaName) {
				UseAdminRights = false
			};
			esq.PrimaryQueryColumn.IsVisible = true;
			esq.Filters.Add(esqFilters);
			Select select = esq.GetSelectQuery(_userConnection);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						var columnValue = dataReader.GetColumnValue<Guid>("Id");
						yield return columnValue;
					}
				}
			}
		}

		private IEnumerable<IReportResult> GenerateFastReportReport(ReportSettings settings,
				ReportTemplateInfo reportTemplateInfo) {
			const string reportExtension = ".pdf";
			if (settings.IsSeparateReports) {
				IEnumerable<Guid> recordIds = GetRecordIdsByFilters(reportTemplateInfo.EntitySchemaName,
					settings.Filters);
				foreach (Guid recordId in recordIds) {
					Filters singleRecordFilter = CreateSingleRecordFilters(recordId);
					byte[] reportData = GenerateReport(reportTemplateInfo.TemplateId, singleRecordFilter);
					yield return GetReportResult(reportData, recordId, reportTemplateInfo, reportExtension);
				}
			} else {
				byte[] reportData = GenerateReport(reportTemplateInfo.TemplateId);
				yield return GetReportResult(reportData, Guid.Empty, reportTemplateInfo, reportExtension);
			}
			byte[] GenerateReport(Guid templateId, Filters filters = null) {
				IFastReportGenerator reportGenerator = GetFastReportGenerator();
				var reportParameters = new Dictionary<string, object> {
					["EsqFilters"] = new Dictionary<string, Filters> {
						[reportTemplateInfo.EntitySchemaName] = filters ?? settings.Filters
					}
				};
				var task = reportGenerator.Generate(templateId, reportParameters, ReportFormat.Pdf);
				return task.Result;
			}
		}

		private IEnumerable<IReportResult> GenerateMsWordReport(ReportSettings settings,
				ReportTemplateInfo reportTemplateInfo) {
			var recordIds = GetRecordIdsByFilters(reportTemplateInfo.EntitySchemaName, settings.Filters);
			foreach (Guid recordId in recordIds) {
				IMsWordReportGenerator reportGenerator = GetMsWordReportGenerator();
				var configuration = new ReportGeneratorConfiguration {
					RecordId = recordId,
					ReportTemplateId = reportTemplateInfo.TemplateId
				};
				ReportData reportData = reportGenerator.Generate(_userConnection, configuration);
				IPdfConverter pdfConverter = null;
				bool convertInPdf = reportTemplateInfo.ConvertInPDF &&
					ClassFactory.TryGet("PdfConverter", out pdfConverter);
				if (convertInPdf) {
					reportData.Data = pdfConverter.Convert(reportData.Data);
					reportData.Format = "pdf";
				}
				yield return GetReportResult(reportData.Data, recordId, reportTemplateInfo, $".{reportData.Format}");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns a FastReport report generator.
		/// </summary>
		/// <returns>Instance of the <see cref="BPMSoft.Reporting.Abstractions.IReportGenerator"/> type.</returns>
		protected virtual IFastReportGenerator GetFastReportGenerator() {
			var reportTemplateProvider = new FastReportTemplateProvider(_userConnection);
			var dataSourceBuilderResolver = new FastReportDataSourceBuilderResolver(_userConnection);
			return new ReportGenerator(reportTemplateProvider, dataSourceBuilderResolver);
		}

		/// <summary>
		/// Returns a Microsoft Word report generator.
		/// </summary>
		/// <returns>Instance of the <see cref="BPMSoft.Configuration.IReportGenerator"/> type.</returns>
		protected virtual IMsWordReportGenerator GetMsWordReportGenerator() {
			return ClassFactory.Get<IMsWordReportGenerator>("Word");
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IReportEngine.Generate" />
		/// <exception cref="NotSupportedException">Throws when the report type is not supported.</exception>
		public IEnumerable<IReportResult> Generate(ReportSettings settings) {
			ReportTemplateInfo reportTemplateInfo = GetReportInfoFromDb(settings.Id);
			switch (reportTemplateInfo.Type) {
				case ReportType.MsWord:
					return GenerateMsWordReport(settings, reportTemplateInfo);
				case ReportType.FastReport:
					return GenerateFastReportReport(settings, reportTemplateInfo);
				default:
					string messageTemplate = new LocalizableString(_userConnection.Workspace.ResourceStorage,
						"ReportEngine", "LocalizableStrings.UnsupportedReportType.Value");
					string message = string.Format(messageTemplate, reportTemplateInfo.Type.ToString());
					throw new NotSupportedException(message);
			}
		}

		/// <inheritdoc cref="IReportEngine.GetReportTemplates" />
		public IReadOnlyList<IReportTemplateInfo> GetReportTemplates() {
			var result = new List<ReportTemplateInfo>();
			EntitySchemaQuery esq = GetReportsEntitySchemaQuery();
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			foreach (Entity entity in entityCollection) {
				var info = new ReportTemplateInfo {
					Id = entity.GetTypedColumnValue<Guid>("Id"),
					Caption = entity.GetTypedColumnValue<string>("Caption"),
					TypeName = entity.GetTypedColumnValue<string>("TypeName"),
					EntitySchemaName = entity.GetTypedColumnValue<string>("EntitySchemaName")
				};
				result.Add(info);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

