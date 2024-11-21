namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Threading.Tasks;
	using System.Web;
	using System.Xml.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Configuration.Reporting.FastReportEngine;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using BPMSoft.Reporting.Abstractions.Data;
	using BPMSoft.Reporting.DataSource.Abstractions;
	using BPMSoft.Reporting.FastReport;
	using BPMSoft.Reporting.FastReport.Abstractions;
	using BPMSoft.Web.Common;
	using BaseResponse = BPMSoft.Core.ServiceModelContract.BaseResponse;
	using ErrorInfo = BPMSoft.Core.ServiceModelContract.ErrorInfo;
	using HttpContext = BPMSoft.Web.Http.Abstractions.HttpContext;

	#region Class: FastReportSerializableException

	[Obsolete("7.15.3")]
	[DataContract]
	public class FastReportSerializableException
	{

		#region Constructors: Public

		public FastReportSerializableException(Exception exception) {
			Message = exception.Message;
			StackTrace = exception.StackTrace;
			if (exception is AggregateException) {
				InnerException = new FastReportSerializableException(exception.InnerException);
			}
		}

		#endregion

		#region Properties: Public

		[DataMember]
		public string Message { get; set; }

		[DataMember]
		public string StackTrace { get; set; }

		[DataMember]
		public FastReportSerializableException InnerException { get; set; }

		#endregion

	}

	#endregion

	#region Class: FastReportGenerationException

	[Obsolete("7.15.3")]
	[Serializable]
	[KnownType(typeof(FastReportSerializableException))]
	public class FastReportGenerationException : ApplicationException
	{

		#region Constructors: Protected

		protected FastReportGenerationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext) {
			ExceptionDetail = (FastReportSerializableException)serializationInfo.GetValue(nameof(ExceptionDetail), typeof(FastReportSerializableException));
		}

		#endregion

		#region Constructors: Public

		public FastReportGenerationException() {
		}

		public FastReportGenerationException(string message) : base(message) {
		}

		public FastReportGenerationException(string message, Exception innerException) : base(message, innerException) {
		}

		public FastReportGenerationException(Exception innerException) : base("Error during report generation") {
			ExceptionDetail = new FastReportSerializableException(innerException);
		}

		#endregion

		#region Properties: Public

		public FastReportSerializableException ExceptionDetail { get; }

		#endregion

		#region Methods: Public

		public override void GetObjectData(SerializationInfo info, StreamingContext context) {
			base.GetObjectData(info, context);
			info.AddValue(nameof(ExceptionDetail), ExceptionDetail, typeof(FastReportSerializableException));
		}

		#endregion

	}

	#endregion

	#region Class: FastReportService

	[Obsolete("7.15.3")]
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class FastReportService : BaseService
	{

		#region Constructors: Public

		public FastReportService() { }

		public FastReportService(UserConnection userConnection) : base(userConnection) { }

		#endregion

		#region Properties: Private

		private WebResponseProcessor WebResponseProcessor => ClassFactory.Get<WebResponseProcessor>();

		#endregion

		#region Methods: Private

		private IReportTemplateProvider GetReportTemplateProvider() {
			return new FastReportTemplateProvider(UserConnection);
		}

		private IDataSourceBuilderResolver GetDataSourceBuilderResolver() {
			return new FastReportDataSourceBuilderResolver(UserConnection);
		}

		private ReportGenerator CreateReportGenerator() {
			IReportTemplateProvider reportTemplateProvider = GetReportTemplateProvider();
			IDataSourceBuilderResolver dataSourceBuilderResolver = GetDataSourceBuilderResolver();
			return new ReportGenerator(reportTemplateProvider, dataSourceBuilderResolver);
		}

		private byte[] InternalCreateReport(Guid templateId, Dictionary<string, object> parameters) {
			var reportGenerator = CreateReportGenerator();
			var task = reportGenerator.Generate(templateId, parameters, ReportFormat.Pdf);
			return task.Result;
		}

		private string PushToSessionData(KeyValuePair<string, byte[]> data) {
			var sessionKey = $"ReportCacheKey_{Guid.NewGuid()}";
			UserConnection.SessionData[sessionKey] = data;
			return sessionKey;
		}

		private KeyValuePair<string, byte[]> PopFromSessionData(string sessionKey) {
			var data = (KeyValuePair<string, byte[]>)UserConnection.SessionData[sessionKey];
			UserConnection.SessionData.Remove(sessionKey);
			return data;
		}

		private Task<IDataSource> BuildDataSource(IDataSourceBuilder dataSourceBuilder, Guid dataSourceId) {
			return dataSourceBuilder
				.SetDataSourceId(dataSourceId)
				.Build();
		}

		private string GetReportCaption(Guid templateId) {
			var sysModuleReportEntitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("SysModuleReport");
			var reportEsq = new EntitySchemaQuery(sysModuleReportEntitySchema);
			reportEsq.AddColumn("Caption");
			reportEsq.Filters.Add(
				reportEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysReportSchemaUId", templateId)
			);
			var sysModuleReports = reportEsq.GetEntityCollection(UserConnection);
			var sysModuleReport = sysModuleReports.First();
			return sysModuleReport.GetTypedColumnValue<string>("Caption");
		}

		private IEnumerable<IDataSource> GetReportDataSources(Guid templateId) {
			IDataSourceBuilderResolver dataSourceBuilderResolver = GetDataSourceBuilderResolver();
			var builders = dataSourceBuilderResolver.ResolveAll(templateId);
			var dataSourceTasks = builders.Select(x => BuildDataSource(x.Value, x.Key));
			return Task.WhenAll(dataSourceTasks).Result;
		}

		private string ApplyDataSources(string reportTemplate, Guid templateId) {
			IEnumerable<IDataSource> dataSources = GetReportDataSources(templateId);
			var reportDataSourceApplier = new ReportDataSourceApplier();
			foreach (var dataSource in dataSources) {
				reportTemplate = reportDataSourceApplier.ApplyDataSource(reportTemplate, dataSource);
			}
			return reportTemplate;
		}

		private string GetReportTemplate(Guid templateId) {
			IReportTemplateProvider templateProvider = GetReportTemplateProvider();
			string reportTemplate = templateProvider.Get(templateId).Result;
			return ApplyDataSources(reportTemplate, templateId);
		}

		private XDocument GetReportXmlDocument(Stream reportStream) {
			return XDocument.Load(reportStream);
		}

		private void RemoveReportDataSources(XDocument reportXmlDocument) {
			var dictionaryElement = reportXmlDocument.Root
				.Elements()
				.FirstOrDefault(element => element.Name == "Dictionary");
			dictionaryElement.Elements("ReportDataSourceConnection").Remove();
			dictionaryElement.Elements("Relation").Remove();
		}

		private string SerializeReport(XDocument reportXmlDocument) {
			string result;
			using (var stream = new MemoryStream()) {
				reportXmlDocument.Save(stream);
				stream.Seek(0, SeekOrigin.Begin);
				using (var streamReader = new StreamReader(stream)) {
					result = streamReader.ReadToEnd();
				}
			}
			return result.Replace("&#xD", "&#13")
				.Replace("&#xA", "&#10")
				.Replace("&#x9", "&#9");
		}

		private void SaveReportTemplate(Guid reportTemplateId, string reportTemplate) {
			var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("FastReportTemplate");
			var entity = entitySchema.CreateEntity(UserConnection);
			entity.FetchFromDB(reportTemplateId);
			entity.SetColumnValue("Data", reportTemplate);
			entity.Save();
		}

		#endregion

		#region Methods: Public

		[Obsolete("7.15.3")]
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public string CreateReport(Guid reportTemplateId, string reportCaption, string reportSchemaName, string reportFilters) {
			try {
				var reportParameters = new Dictionary<string, object> {
					["EsqFilters"] = new Dictionary<string, Filters> {
						[reportSchemaName] = JsonConvert.DeserializeObject<Filters>(reportFilters)
					}
				};
				var reportBytes = InternalCreateReport(reportTemplateId, reportParameters);
				return PushToSessionData(new KeyValuePair<string, byte[]>($"{Uri.EscapeDataString(reportCaption)}.pdf", reportBytes));
			} catch (Exception exception) {
				throw new WebFaultException<FastReportGenerationException>(
					new FastReportGenerationException(exception),
					HttpStatusCode.InternalServerError);
			}
		}

		[Obsolete("7.15.3")]
		[OperationContract]
		[WebGet(UriTemplate = "GetReportFile/{key}")]
		public Stream GetReportFile(string key) {
			var data = PopFromSessionData(key);
			string contentDisposition = "attachment; filename*=UTF-8''" + data.Key;
			var reportStream = new MemoryStream(data.Value);
			WebResponseProcessor.AssignFileResponseContent(HttpContextAccessor.GetInstance(), "application/pdf; charset=UTF-8", reportStream.Length, contentDisposition);
			return reportStream;
		}

		[Obsolete("7.15.3")]
		[OperationContract]
		[WebGet(UriTemplate = "DownloadReportTemplate/{templateId}")]
		public Stream DownloadReportTemplate(string templateId) {
			var reportTemplateId = new Guid(templateId);
			string templateString = GetReportTemplate(reportTemplateId);
			var reportCaption = GetReportCaption(reportTemplateId);
			string contentDisposition = $"attachment; filename*=UTF-8''{Uri.EscapeDataString(reportCaption)}.frx";
			var reportTemplateStream = templateString.ToStream();
			WebResponseProcessor.AssignFileResponseContent(HttpContextAccessor.GetInstance(), "application/xml",
				reportTemplateStream.Length, contentDisposition);
			return reportTemplateStream;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UploadReportTemplate", ResponseFormat = WebMessageFormat.Json)]
		public BaseResponse UploadReportTemplate() {
			try {
				HttpContext httpContext = HttpContextAccessor.GetInstance();
				var templateId = httpContext.Request.QueryString["templateId"];
				var reportTemplateId = new Guid(templateId);
				var reportXmlDocument = GetReportXmlDocument(httpContext.Request.Files["file"].InputStream);
				RemoveReportDataSources(reportXmlDocument);
				var reportTemplate = SerializeReport(reportXmlDocument);
				SaveReportTemplate(reportTemplateId, reportTemplate);
				return new BaseResponse { Success = true };
			} catch (Exception e) {
				throw new WebFaultException<BaseResponse>(
					new BaseResponse {
						Success = false,
						ErrorInfo = new ErrorInfo {
							Message = e.Message,
							StackTrace = e.StackTrace
						}
					},
					HttpStatusCode.InternalServerError);
			}
		}

		#endregion

	}

	#endregion

}

