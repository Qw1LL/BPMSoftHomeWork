namespace BPMSoft.Configuration.ReportService
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Text;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common.Json;
	using BPMSoft.Nui.ServiceModel.Extensions;
	using BPMSoft.Web.Http.Abstractions;
	using HttpUtility = System.Web.HttpUtility;
	using SelectQuery = BPMSoft.Nui.ServiceModel.DataContract.SelectQuery;
	using BPMSoft.Core.Factories;
	using BPMSoft.UI.WebControls.Utilities;

	public class ReportHelper
	{

		#region Fields: Private

		private readonly IHttpContextAccessor _httpContextAccessor;

		private WebResponseProcessor WebResponseProcessor => ClassFactory.Get<WebResponseProcessor>();

		#endregion

		#region Constructors: Public

		public ReportHelper()
			: this(HttpContext.HttpContextAccessor) {
		}

		public ReportHelper(IHttpContextAccessor httpContextAccessor) {
			_httpContextAccessor = httpContextAccessor;
		}

		#endregion

		#region Properties: Private

		private UserConnection _userConnection;
		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection {
			get {
				HttpContext httpContext = _httpContextAccessor.GetInstance();
				return _userConnection ?? (_userConnection = (UserConnection)httpContext.Session["UserConnection"]);
			}
			set => _userConnection = value;
		}

		#endregion

		#region CreateReport

		public virtual string CreateReport(string entitySchemaUId, string reportSchemaUId, string templateId,
				string recordId, string reportParameters, bool convertInPDF) {
			string key = string.Format("ReportCacheKey_{0}", Guid.NewGuid());
			ReportData data = null;
			bool isDevExpress = string.IsNullOrEmpty(templateId);
			var reportService = new ReportService {
				HttpContextAccessor = _httpContextAccessor
			};
			if (isDevExpress) {
#if !NETSTANDARD2_0
				data = reportService.GenerateDevExpressReport(entitySchemaUId, reportSchemaUId,
					recordId, reportParameters);
#else
				throw new NotSupportedException("DevExpress reports are not supported.");
#endif
			} else {
				data = reportService.GenerateMSWordReport(templateId, recordId, convertInPDF);
			}
			UserConnection.SessionData[key] = new ReportData {
				Caption = Uri.EscapeDataString(data.Caption),
				Data = data.Data,
				Format = data.Format
			};
			return key;
		}

		public virtual Stream GetReportFile(string key) {
			object reportObj = UserConnection.SessionData[key];
			UserConnection.SessionData.Remove(key);
			var report = (ReportData)reportObj;
			string reportCaption = HttpUtility.UrlPathEncode(report.Caption) + "." + report.Format;
			string contentType = report.Format == "pdf"
				? "application/pdf; charset=UTF-8"
				: "application/octet-stream; charset=UTF-8";
			string contentDisposition = "attachment; filename*=UTF-8''" + reportCaption + "";
			var reportStream = new MemoryStream(report.Data);
			WebResponseProcessor.AssignFileResponseContent(_httpContextAccessor.GetInstance(), contentType, reportStream.Length, contentDisposition);
			return reportStream;
		}

		#endregion

#if NETFRAMEWORK

		#region ExportData

		public virtual string GetCsvContent(string data) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanExportGrid");
			var selectQuery = Json.Deserialize<SelectQuery>(data);
			EntitySchemaQuery entitySchemaQuery = selectQuery.BuildEsq(UserConnection);
			EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			char csvDelimiter = SysSettings.GetValue(UserConnection, "CSVDelimiter").ToString()[0];
			var csvConverter = new CsvConverter(csvDelimiter);
			var csvLines = csvConverter.GetCsvContent(entitySchemaQuery, entityCollection);
			var stringBuilder = new StringBuilder();
			foreach (string csvLine in csvLines) {
				stringBuilder.Append(csvLine);
				stringBuilder.AppendLine();
			}
			return stringBuilder.ToString();
		}

		public virtual string GenerateExportFilterKey() {
			return string.Format("ExportFilterKey_{0}", Guid.NewGuid());
		}

		public virtual string SendExportFilters(string data) {
			string key = GenerateExportFilterKey();
			UserConnection.SessionData[key] = GetCsvContent(data);
			return key;
		}

		public virtual Stream GetExportFilteredData(string entitySchemaName, string filtersContextKey) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanExportGrid");
			string serializedParameters = UserConnection.SessionData[filtersContextKey].ToString();
			MemoryStream exportStream = createCsvStream(UserConnection, entitySchemaName, serializedParameters);
			string contentDisposition = "attachment; filename=\"" + entitySchemaName + ".csv\"";
			string contentType = "text/csv";
			WebResponseProcessor.AssignFileResponseContent(_httpContextAccessor.GetInstance(), contentType, exportStream.Length, contentDisposition);
			exportStream.Seek(0, SeekOrigin.Begin);
			return exportStream;
		}

		public virtual MemoryStream createCsvStream(UserConnection userConnection, string entitySchemaName,
				string serializedParameters) {
			var result = new MemoryStream();
			string csvCodePage = SysSettings.GetValue(userConnection, "CSVCodePage").ToString();
			EncodingInfo[] encodings = Encoding.GetEncodings();
			bool found = encodings.Any(encodingInfo => encodingInfo.Name == csvCodePage);
			if (!found) {
				throw new FormatException("csvCodePage");
			}
			Encoding encode = Encoding.GetEncoding(csvCodePage);
			byte[] newline = encode.GetBytes(Environment.NewLine);
			byte[] preamble = encode.GetPreamble();
			byte[] buf = encode.GetBytes(serializedParameters);
			result.Write(preamble, 0, preamble.Length);
			result.Write(buf, 0, buf.Length);
			result.Write(newline, 0, newline.Length);
			return result;
		}

		#endregion

#endif

	}

}

