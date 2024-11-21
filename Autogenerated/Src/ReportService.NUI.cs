namespace BPMSoft.Configuration.ReportService
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Text;
	using System.Text.RegularExpressions;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Drawing.Wordprocessing;
	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Wordprocessing;
	using global::Common.Logging;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using OpenXmlDrawing = DocumentFormat.OpenXml.Drawing;
	using OpenXmlPictures = DocumentFormat.OpenXml.Drawing.Pictures;
	using OpenXmlDrawingProcessing = DocumentFormat.OpenXml.Drawing.Wordprocessing;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.ExportToExcel;
	using BPMSoft.Configuration.SerializedEsqFilterConvertation;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;
	using HttpUtility = System.Web.HttpUtility;
	using FeatureUtilities = BPMSoft.Configuration.FeatureUtilities;
	using SysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Struct: PictureData

	public struct PictureData
	{

		public string FieldName;

		public string PictureId;

		public OpenXmlDrawingProcessing.DocProperties DocProperties;

		public OpenXmlPictures.Picture Picture;

		public PictureData(string fieldName, string pictureId, OpenXmlDrawingProcessing.DocProperties docProperties,
				OpenXmlPictures.Picture picture) {
			FieldName = fieldName;
			PictureId = pictureId;
			DocProperties = docProperties;
			Picture = picture;
		}

	}

	#endregion

	#region Class: ReportConfig

	public class ReportConfig
	{

		private readonly UserConnection _userConnection;

		public bool IgnorePictureAspectRatio;
		public bool DisableFillingTableFieldsOutsideTables;

		public ReportConfig(UserConnection userConnection) {
			_userConnection = userConnection;
			InitConfig();
		}

		private void InitConfig() {
			IgnorePictureAspectRatio = SysSettings.GetValue(_userConnection, "IgnorePictureAspectRatio", false);
			DisableFillingTableFieldsOutsideTables = SysSettings.GetValue(_userConnection, "DisableFillingTableFieldsOutsideTables",
				false);
		}
	}

	#endregion

	#region Class: DataValue

	public class DataValue
	{

		#region Contructors: Public

		public DataValue(DataValueType valueType, object data) {
			ValueType = valueType;
			Data = data;
		}

		#endregion

		#region Properties: Public

		public DataValueType ValueType { get; set; }

		public object Data { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReportData

	[Serializable]
	public class ReportData
	{

		#region Properties : Public

		public string Caption { get; set; }

		public byte[] Data { get; set; }

		public string Format { get; set; }

		#endregion

	}

	#endregion

	#region Class: ReportService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ReportService : BaseService
	{

		#region Constructors: Public

		public ReportService() : base() { }

		public ReportService(UserConnection userConnection) : base(userConnection) { }

		#endregion

#if !NETSTANDARD2_0

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("BPMSoft");

		#endregion

#endif

		#region Methods: Private

		private void AssignExcelResponseContent(string fileName, Stream exportStream) {
			const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet; charset=utf-8";
			var encodedFileName = HttpUtility.UrlEncode(fileName, Encoding.UTF8);
			var contentLength = exportStream.Length;
			var contentDisposition = string.Format("attachment; filename=\"{0}.xlsx\"; filename*=UTF-8''{0}.xlsx", encodedFileName);
			ClassFactory.Get<WebResponseProcessor>().AssignFileResponseContent(HttpContextAccessor.GetInstance(), contentType, contentLength, contentDisposition);
		}

		#endregion

		#region CreateReport

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped)]
		public string CreateReport(string entitySchemaUId, string reportSchemaUId, string templateId, string recordId,
				string reportParameters, bool convertInPDF) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			string key = reportHelper.CreateReport(entitySchemaUId, reportSchemaUId, templateId, recordId,
				reportParameters, convertInPDF);
			return key;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Wrapped)]
		public string[] CreateReportsList(string entitySchemaUId, string reportSchemaUId, string templateId,
				string[] recordIds, string reportParameters, bool convertInPDF) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			var keys = new string[recordIds.Length];
			for (var i = 0; i < recordIds.Length; i++) {
				keys[i] = reportHelper.CreateReport(entitySchemaUId, reportSchemaUId, templateId, recordIds[i],
					reportParameters, convertInPDF);
			}
			return keys;
		}

		[OperationContract]
		[WebGet(UriTemplate = "GetReportFile/{key}")]
		public Stream GetReportFile(string key) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			Stream reportStream = reportHelper.GetReportFile(key);
			return reportStream;
		}

		#endregion

		#region ExportData

#if NETFRAMEWORK && OldUI

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ExportFiltersResponse GetExportFiltersKey(string data) {
			var response = new ExportFiltersResponse();
			try {
				response.Key = SendExportFilters(data);
			} catch (InvalidObjectStateException e) {
				response.MaxEntityRowCount = UserConnection.AppConnection.MaxEntityRowCount;
				response.Exception = e;
			} catch (Exception e) {
				response.Exception = e;
			}
			return response;
		}

#endif

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
		public ExportToExcelResponse GetExportToExcelKey(string esqSerialized) {
			ClassFactory.ReBind<IRepository<StorableStreamEntity>, StreamRedisRepositorySecurityDecorator>();
			try {
				var exportToExcelService = ClassFactory.Get<ExportToExcelService>();
				return exportToExcelService.PrepareExport(esqSerialized);
			} catch (Exception exception) {
				return new ExportToExcelResponse(exception);
			}
		}

#if NETFRAMEWORK && OldUI

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public string SendExportFilters(string data) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			string key = reportHelper.SendExportFilters(data);
			return key;
		}

		[OperationContract]
		[WebGet(UriTemplate = "GetExportFilteredData/{urlEntitySchemaName}/{filtersContextKey}")]
		public Stream GetExportFilteredData(string urlEntitySchemaName, string filtersContextKey) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			Stream exportStream = reportHelper.GetExportFilteredData(urlEntitySchemaName, filtersContextKey);
			return exportStream;
		}

#endif

		[OperationContract]
		[WebGet(UriTemplate = "GetExportToExcelData/{filtersContextKey}/{fileName}")]
		public Stream GetExportToExcelData(string filtersContextKey, string fileName) {
			ClassFactory.ReBind<IRepository<StorableStreamEntity>, StreamRedisRepositorySecurityDecorator>();
			var exportService = ClassFactory.Get<ExportToExcelService>();
			var excelStream = (MemoryStream)exportService.GetExcelStream(filtersContextKey);
			var exportStream = new MemoryStream();
			excelStream.WriteTo(exportStream);
			exportStream.Seek(0, SeekOrigin.Begin);
			AssignExcelResponseContent(fileName, exportStream);
			return exportStream;
		}

#if NETFRAMEWORK && OldUI

		public MemoryStream createCsvStream(UserConnection userConnection, string entitySchemaName,
				string serializedParameters) {
			var reportHelper = ClassFactory.Get<ReportHelper>();
			MemoryStream stream = reportHelper.createCsvStream(userConnection, entitySchemaName, serializedParameters);
			return stream;
		}

#endif

		#endregion

#if !NETSTANDARD2_0

		#region DevExpressReport

		public ReportData GenerateDevExpressReport(string entitySchemaUId, string reportSchemaId, string recordId,
				string reportParameters) {
			var reportGenerator = ClassFactory.Get<IReportGenerator>("DevExpress");
			var configuration = new ReportGeneratorConfiguration {
				ReportTemplateId = !string.IsNullOrEmpty(reportSchemaId) ? new Guid(reportSchemaId) : Guid.Empty,
				EntitySchemaUId = !string.IsNullOrEmpty(entitySchemaUId) ? new Guid(entitySchemaUId) : Guid.Empty,
				RecordId = !string.IsNullOrEmpty(recordId) ? new Guid(recordId) : Guid.Empty,
				ReportParameters = !string.IsNullOrEmpty(reportParameters)
					? JsonConvert.DeserializeObject<Dictionary<string, object>>(reportParameters)
					: null
			};
			ReportData report = reportGenerator.Generate(UserConnection, configuration);
			_log.ErrorFormat("DevExpress report with caption: {0} and reportTemplateId: {1} was generate {2}",
				report.Caption, reportSchemaId, DateTime.Now);
			return report;
		}

		#endregion

#endif

		#region MSWordReport

		public ReportData GenerateMSWordReport(string urlTemplateId, string urlRecordUId, bool convertInPDF) {
			var templateId = new Guid(urlTemplateId);
			var openXmlUtility = new OpenXmlUtility(UserConnection);
			var reportGenerator = ClassFactory.Get<IReportGenerator>("Word");
			var configuration = new ReportGeneratorConfiguration {
				RecordId = new Guid(urlRecordUId),
				ReportTemplateId = templateId
			};
			var result = reportGenerator.Generate(UserConnection, configuration);
			IPdfConverter pdfConverter = null;
			convertInPDF = convertInPDF && ClassFactory.TryGet("PdfConverter", out pdfConverter);
			if (convertInPDF) {
				result.Data = pdfConverter.Convert(result.Data);
				result.Format = "pdf";
			}
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: WordFieldUtility

	public class WordFieldUtility
	{
		#region Constants: Private

		/// <summary>
		/// English Metric Units (EMUs) are related to the Open XML format.
		/// </summary>
		private const int _metricConstant = 914400;

		#endregion

		#region Fields: Public

		public static readonly Regex MergeFormat =
		new Regex(@"
			MERGEFIELD\s+(?<Name>.+?)(?=\s\\[\*bfmv])
			(?:\s+\\\*\s+(?<Format>\w+)(?=\s\\[\*bfmv]))?
			(?:\s\\b\s(?:(?<TextBefore>\w+)|\x22(?<TextBefore>.*?)(?<!\\)\x22))?
			(?:\s\\f\s(?:(?<TextAfter>\w +)|\x22(?<TextAfter>.*?)(?<!\\)\x22))?
			(?:\s(?<M>\\m))?
			(?:\s(?<V>\\v))?",
			RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
		#endregion

		#region Methods: Private

		private static string GetFieldNameWithOptions(SimpleField field, out string[] switches, out string[] options) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			switches = new string[0];
			options = new string[3];
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction)) {
				Match m = MergeFormat.Match(instruction);
				if (m.Success) {
					fieldname = m.Groups["Name"].ToString().Trim();
					options[0] = m.Groups["Format"].Value.Trim();
					options[1] = m.Groups["TextBefore"].Value.Trim();
					options[2] = m.Groups["TextAfter"].Value.Trim();
					int pos = fieldname.IndexOf("[#");
					if (pos > 0) {
						return fieldname;
					}
					pos = fieldname.IndexOf('#');
					if (pos > 0) {
						switches = fieldname.Substring(pos + 1).ToLower()
							.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
						fieldname = fieldname.Substring(0, pos);
					}
				}
			}
			return fieldname;
		}

		private static string ToTitleCase(string toConvert) {
			return ToTitleCaseHelper(toConvert, string.Empty);
		}

		private static string ToTitleCaseHelper(string toConvert, string alreadyConverted) {
			if (string.IsNullOrEmpty(toConvert)) {
				return alreadyConverted;
			}
			int indexOfFirstSpace = toConvert.IndexOf(' ');
			string firstWord, restOfString;
			if (indexOfFirstSpace != -1) {
				firstWord = toConvert.Substring(0, indexOfFirstSpace);
				restOfString = toConvert.Substring(indexOfFirstSpace).Trim();
			} else {
				firstWord = toConvert.Substring(0);
				restOfString = string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(alreadyConverted);
			stringBuilder.Append(" ");
			stringBuilder.Append(firstWord.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture));
			if (firstWord.Length > 1) {
				stringBuilder.Append(firstWord.Substring(1).ToLower(CultureInfo.CurrentCulture));
			}
			return ToTitleCaseHelper(restOfString, stringBuilder.ToString());
		}

		private static string[] ApplyFormatting(string format, string fieldValue, string preText, string postText) {
			string[] valuesToReturn = new string[3];
			if ("Upper".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToUpper(CultureInfo.CurrentCulture);
			} else if ("Lower".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToLower(CultureInfo.CurrentCulture);
			} else if ("FirstCap".Equals(format)) {
				if (!string.IsNullOrEmpty(fieldValue)) {
					valuesToReturn[0] = fieldValue.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
					if (fieldValue.Length > 1) {
						valuesToReturn[0] = valuesToReturn[0] + fieldValue.Substring(1)
							.ToLower(CultureInfo.CurrentCulture);
					}
				}
				if (!string.IsNullOrEmpty(preText)) {
					valuesToReturn[1] = preText.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
					if (fieldValue.Length > 1) {
						valuesToReturn[1] = valuesToReturn[1] + preText.Substring(1).ToLower(CultureInfo.CurrentCulture);
					}
				}
				if (!string.IsNullOrEmpty(postText)) {
					valuesToReturn[2] = postText.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
					if (fieldValue.Length > 1) {
						valuesToReturn[2] = valuesToReturn[2] + postText.Substring(1).ToLower(CultureInfo.CurrentCulture);
					}
				}
			} else if ("Caps".Equals(format)) {
				valuesToReturn[0] = ToTitleCase(fieldValue);
				valuesToReturn[1] = ToTitleCase(preText);
				valuesToReturn[2] = ToTitleCase(postText);
			} else {
				valuesToReturn[0] = fieldValue;
				valuesToReturn[1] = preText;
				valuesToReturn[2] = postText;
			}
			return valuesToReturn;
		}

		/// <summary>
		/// Converts string to array of <see cref="DocumentFormat.OpenXml.OpenXmlElement"/> elements.
		/// </summary>
		/// <param name="text">Source text.</param>
		/// <returns>Array of OpenXmlElement elements.</returns>
		private static IEnumerable<OpenXmlElement> GetTextElements(string text) {
			if (string.IsNullOrEmpty(text)) {
				return null;
			}
			var elements = new List<OpenXmlElement>();
			string[] breakSplitting = text.Split(new string[] { "\n" }, StringSplitOptions.None);
			bool isFirstBreak = true;
			foreach (string breakSplittingElement in breakSplitting) {
				if (!isFirstBreak) {
					elements.Add(new Break());
				}
				isFirstBreak = false;
				bool isFirstTab = true;
				string[] tabSplitting = breakSplittingElement.Split(new string[] { "\t" }, StringSplitOptions.None);
				foreach (string tabSplittingElement in tabSplitting) {
					if (!isFirstTab) {
						elements.Add(new TabChar());
					}
					elements.Add(new Text(tabSplittingElement));
					isFirstTab = false;
				}
			}
			return elements;
		}

		/// <summary>
		/// Converts string to <see cref="DocumentFormat.OpenXml.Wordprocessing.Run"/> element.
		/// </summary>
		/// <param name="text">Source text.</param>
		/// <param name="placeholder">Placeholder.</param>
		/// <returns>Run element.</returns>
		private static Run GetRunElementForText(string text, SimpleField placeholder) {
			Run run = new Run();
			if (placeholder != null) {
				IEnumerable<RunProperties> descendants = placeholder.Descendants<RunProperties>();
				RunProperties placeholderRunProperties = descendants.FirstOrDefault();
				if (placeholderRunProperties != null) {
					string outerXml = placeholderRunProperties.OuterXml;
					if (!string.IsNullOrEmpty(outerXml)) {
						run.Append(new RunProperties(outerXml));
					}
				}
			}
			IEnumerable<OpenXmlElement> elements = GetTextElements(text);
			if (elements != null) {
				run.Append(elements);
			}
			return run;
		}

		private static Paragraph GetPreOrPostParagraphToInsert(string text, SimpleField fieldToMimic) {
			Run runToInsert = GetRunElementForText(text, fieldToMimic);
			Paragraph paragraphToInsert = new Paragraph();
			paragraphToInsert.Append(runToInsert);
			return paragraphToInsert;
		}

		/// <summary>
		/// Updates picture data extents parameters.
		/// </summary>
		/// <param name="imageStream">Image stream.</param>
		/// <param name="pictureData">Picture data.</param>
		private static void UpdatePictureDataExtents(MemoryStream imageStream, PictureData pictureData) {
			var image = new Bitmap(imageStream);
			imageStream.Position = 0;
			OpenXmlDrawing.Extents extents = pictureData.Picture.ShapeProperties.Transform2D.Extents;
			extents.Cx = image.Width * (long)(_metricConstant / image.HorizontalResolution);
			extents.Cy = image.Height * (long)(_metricConstant / image.VerticalResolution);
		}

		/// <summary>
		/// Returns image stream.
		/// </summary>
		/// <param name="values">Data values dictionary.</param>
		/// <param name="pictureData">Picture data.</param>
		/// <returns></returns>
		private static MemoryStream GetImageStream(Dictionary<string, DataValue> values, PictureData pictureData) {
			DataValue dataValue;
			if (!values.TryGetValue(pictureData.FieldName, out dataValue)) {
				return null;
			}
			if (dataValue == null || dataValue.Data == null) {
				return null;
			}
			MemoryStream imageStream = dataValue.Data as MemoryStream;
			if (imageStream == null || imageStream.Length == 0) {
				return null;
			}
			return imageStream;
		}

		/// <summary>
		/// Removes Run from OpenXML element with appropriate picture.
		/// </summary>
		/// <param name="element">OpenXmlElement element.</param>
		/// <param name="pictureId">Appropriate picture id.</param>
		/// <returns></returns>
		private static void RemovePictureRun(OpenXmlElement element, string pictureId) {
			var elements = element.Descendants<Run>().Where(x =>
				x.Descendants<DocumentFormat.OpenXml.Drawing.Blip>().Any(y => y.Embed.Value == pictureId));
			if (elements.IsEmpty()) {
				return;
			}
			Run run = elements.First();
			run.Remove();
		}

		#endregion

		#region Methods: Public

		public static string GetFieldName(SimpleField field) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction)) {
				Match m = MergeFormat.Match(instruction);
				if (m.Success) {
					fieldname = m.Groups["Name"].ToString().Trim();
				}
			}
			return fieldname;
		}

		public static OpenXmlDrawingProcessing.DocProperties GetPictureDocProperties(OpenXmlPictures.Picture picture) {
			OpenXmlElement parent = picture.Parent.Parent.Parent;
			return parent.Descendants<OpenXmlDrawingProcessing.DocProperties>().FirstOrDefault();
		}

		public static Dictionary<string, PictureData> GetPicturesData(OpenXmlElement element) {
			var pictures = element.Descendants<OpenXmlPictures.Picture>()
				.Where(picture => GetPictureDocProperties(picture) != null)
				.ToArray();
			var docPropList = pictures
				.Select(picture => GetPictureDocProperties(picture).Id.InnerText)
				.ToArray();
			Dictionary<string, PictureData> picturesData = new Dictionary<string, PictureData>();
			foreach (var docProp in docPropList) {
				if (picturesData.ContainsKey(docProp)) {
					continue;
				}
				var pictureData = pictures
					.Where(picture => (docProp == GetPictureDocProperties(picture)?.Id?.InnerText)
						&& (!string.IsNullOrEmpty(GetPictureDocProperties(picture)?.Name?.Value)))
					.Select(picture => new {
						fieldName = GetPictureDocProperties(picture)?.Name?.Value,
						pictureId = picture?.BlipFill?.Blip?.Embed?.Value,
						docProperties = GetPictureDocProperties(picture),
						picture = picture
					}).FirstOrDefault();
				if (pictureData == null) {
					continue;
				}
				picturesData.Add(docProp,
					new PictureData(pictureData.fieldName, pictureData.pictureId, pictureData.docProperties, pictureData.picture));
			};
			return picturesData;
		}

		private static bool CanRemovePictureRun(PictureData picture, OpenXmlElement element) {
			return picture.Picture.FirstChild.InnerXml?.Contains("name=\"\"") == true && element is TableRow;
		}

		/// <summary>
		/// Fills the word fields in the element.
		/// </summary>
		/// <param name="values">Filling values.</param>
		/// <param name="element">Replacing element.</param>
		/// <param name="mainDocumentPart">Main document part.</param>
		public static void FillWordFieldsInElement(Dictionary<string, DataValue> values, OpenXmlElement element,
				MainDocumentPart mainDocumentPart, ReportConfig config = null) {
			string[] switches;
			string[] options;
			string[] formattedText;
			DataValue dataValue = null;
			SimpleField[] fieldsList = element.Descendants<SimpleField>().ToArray();
			foreach (SimpleField field in fieldsList) {
				string fieldname = GetFieldNameWithOptions(field, out switches, out options);
				if (string.IsNullOrEmpty(fieldname)) {
					continue;
				}
				if (!values.TryGetValue(fieldname, out dataValue)) {
					continue;
				}
				string stringDataValue = string.Empty;
				if (dataValue != null) {
					stringDataValue = dataValue.Data.ToString();
				}
				formattedText = ApplyFormatting(options[0], stringDataValue, options[1], options[2]);
				OpenXmlElement fieldParent = field.Parent;
				if (!string.IsNullOrEmpty(options[1])) {
					fieldParent.InsertBeforeSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[1], field));
				}
				if (!string.IsNullOrEmpty(options[2])) {
					fieldParent.InsertAfterSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[2], field));
				}
				string formattedTextValue = formattedText[0];
				if (fieldParent is Run) {
					var elements = GetTextElements(formattedTextValue);
					if (elements != null) {
						field.InsertGroupAfterSelf(elements);
					}
					fieldParent.RemoveChild(field);
				} else {
					fieldParent.ReplaceChild<SimpleField>(GetRunElementForText(formattedTextValue, field), field);
				}
			}
			Dictionary<string, PictureData> picturesData = GetPicturesData(element);
            foreach (KeyValuePair<string, PictureData> pictureData in picturesData) {
				MemoryStream imageStream = GetImageStream(values, pictureData.Value);
				string pictureId = pictureData.Value.PictureId;
				if (imageStream != null) {
					if (config?.IgnorePictureAspectRatio != true) {
						UpdatePictureDataExtents(imageStream, pictureData.Value);
					}
					var imagePart = mainDocumentPart.GetPartById(pictureId);
					//Note: FeedData always close stream
					using (MemoryStream stream = new MemoryStream()) {
						imageStream.CopyTo(stream);
						imageStream.Position = 0;
						stream.Position = 0;
						imagePart.FeedData(stream);
					}
					//Mark image as already processed
					pictureData.Value.DocProperties.Name.Value = string.Empty;
				} else if (CanRemovePictureRun(pictureData.Value, element)) {
					RemovePictureRun(element, pictureId);
				}
			}
		}

		#endregion

	}

	#endregion

	#region Class: OpenXmlElementExtensions

	/// <summary>
	/// Provides utility methods for working with OpenXmlElement.
	/// </summary>
	public static class OpenXmlElementExtensions
	{

		#region Methods: Public

		/// <summary>
		/// Inserts a group of <see cref="DocumentFormat.OpenXml.OpenXmlElement"/> after anchor element.
		/// </summary>
		/// <param name="anchorElement">Element after which elements are inserted.</param>
		/// <param name="elements">Inserted elements.</param>
		/// <returns>Last inserted element.</returns>
		/// <exception cref="ArgumentNullException">If null is received as the <paramref name="elements"> parameter.</exception>
		public static OpenXmlElement InsertGroupAfterSelf(this OpenXmlElement anchorElement,
				IEnumerable<OpenXmlElement> elements) {
			if (elements == null) {
				throw new ArgumentNullException("elements");
			}
			foreach (OpenXmlElement element in elements) {
				anchorElement = anchorElement.InsertAfterSelf<OpenXmlElement>(element);
			}
			return anchorElement;
		}

		#endregion

	}

	#endregion

	#region Class: BaseOpenXmlUtility

	public class BaseOpenXmlUtility
	{

		#region Methods: Private

		private bool CheckRunCharType(Run run, FieldCharValues type) {
			return run.HasChildren && run.Descendants<FieldChar>().Any() &&
				run.Descendants<FieldChar>().FirstOrDefault(x => x.FieldCharType == type) != null;
		}

		#endregion

		#region Methods: Protected

		protected void ConvertFieldCodes(OpenXmlElement mainElement, bool isReplacingConvertion, Dictionary<string,
				DataValue> values) {
			Run[] runs = mainElement.Descendants<Run>().ToArray();
			if (runs.Length == 0)
				return;
			var preparedRuns = new List<Run>();
			Dictionary<Run, Run[]> newfields = new Dictionary<Run, Run[]>();
			int cursor = 0;
			do {
				Run run = runs[cursor];
				if (preparedRuns.Contains(run)) {
					cursor++;
					continue;
				}
				OpenXmlElement parent = run.Parent;
				RunBlock runBlock = null;
				foreach (Run innerRun in parent.ChildElements.OfType<Run>()) {
					preparedRuns.Add(innerRun);
					if (CheckRunCharType(innerRun, FieldCharValues.Begin)) {
						runBlock = new RunBlock();
					}
					if (runBlock != null) {
						runBlock.InnerItems.Add(innerRun);
						if (innerRun.HasChildren && innerRun.ChildElements.OfType<FieldCode>().Any()) {
							runBlock.instruction += innerRun.GetFirstChild<FieldCode>().Text;
						}
						if (innerRun.HasChildren && innerRun.ChildElements.OfType<RunProperties>().Any()) {
							runBlock.RunProperties = innerRun.GetFirstChild<RunProperties>();
						}
					}
					if (CheckRunCharType(innerRun, FieldCharValues.End) && runBlock != null) {
						var newRun = runBlock.GenerateNewRun(isReplacingConvertion, values);
						if (newRun != null) {
							newfields.Add(newRun, runBlock.InnerItems.ToArray());
						}
						runBlock = null;
					}
				}
				if (runBlock != null) {
					var newRun = runBlock.GenerateNewRun(isReplacingConvertion, values);
					if (newRun != null) {
						newfields.Add(newRun, runBlock.InnerItems.ToArray());
					}
				}
				cursor++;
			} while (cursor < runs.Length);
			foreach (KeyValuePair<Run, Run[]> kvp in newfields) {
				kvp.Value[0].Parent.ReplaceChild(kvp.Key, kvp.Value[0]);
				for (int i = 1; i < kvp.Value.Length; i++)
					kvp.Value[i].Remove();
			}
		}

		#endregion

	}

	#endregion

	#region Class: OpenXmlUtility

	public class OpenXmlUtility : BaseOpenXmlUtility
	{

		#region Fields: Private

		UserConnection userConnection;

		#endregion

		#region Constructors: Public

		public OpenXmlUtility(UserConnection userConnection) {
			this.userConnection = userConnection;
		}

		#endregion

		#region Methods: Internal

		internal Collection<string> GetMergeFieldName(WordprocessingDocument docx) {
			Collection<string> dic = new Collection<string>();
			ConvertFieldCodes(docx.MainDocumentPart.Document, false, new Dictionary<string, DataValue>());
			foreach (var field in docx.MainDocumentPart.Document.Descendants<SimpleField>()) {
				string fieldname = WordFieldUtility.GetFieldName(field);
				if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
					dic.Add(fieldname);
				}
			}
			foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
				ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
				foreach (var field in fpart.Footer.Descendants<SimpleField>()) {
					string fieldname = WordFieldUtility.GetFieldName(field);
					if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
						dic.Add(fieldname);
					}
				}
			}
			foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
				ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
				foreach (var field in hpart.Header.Descendants<SimpleField>()) {
					string fieldname = WordFieldUtility.GetFieldName(field);
					if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
						dic.Add(fieldname);
					}
				}
			}
			Dictionary<string, PictureData> picturesData =
				WordFieldUtility.GetPicturesData(docx.MainDocumentPart.Document);
			foreach (var pictureData in picturesData) {
				if (!dic.Contains(pictureData.Value.FieldName)) {
					dic.Add(pictureData.Value.FieldName);
				}
			}
			return dic;
		}

		[Obsolete("7.15.0")]
		internal Collection<string> GetMergeFieldName(byte[] data) {
			Collection<string> dic = new Collection<string>();
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					ConvertFieldCodes(docx.MainDocumentPart.Document, false, new Dictionary<string, DataValue>());
					foreach (var field in docx.MainDocumentPart.Document.Descendants<SimpleField>()) {
						string fieldname = WordFieldUtility.GetFieldName(field);
						if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
							dic.Add(fieldname);
						}
					}
					foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
						ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
						foreach (var field in fpart.Footer.Descendants<SimpleField>()) {
							string fieldname = WordFieldUtility.GetFieldName(field);
							if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
								dic.Add(fieldname);
							}
						}
					}
					foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
						ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
						foreach (var field in hpart.Header.Descendants<SimpleField>()) {
							string fieldname = WordFieldUtility.GetFieldName(field);
							if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
								dic.Add(fieldname);
							}
						}
					}
					Dictionary<string, PictureData> picturesData =
						WordFieldUtility.GetPicturesData(docx.MainDocumentPart.Document);
					foreach (var pictureData in picturesData) {
						if (!dic.Contains(pictureData.Value.FieldName)) {
							dic.Add(pictureData.Value.FieldName);
						}
					}
				}
			}
			return dic;
		}

		internal WordprocessingDocument GetWordReport(WordprocessingDocument docx, Dictionary<string, DataValue> values) {
			ConvertFieldCodes(docx.MainDocumentPart.Document, true, values);
			var config = new ReportConfig(userConnection);
			WordFieldUtility.FillWordFieldsInElement(values, docx.MainDocumentPart.Document, docx.MainDocumentPart, config);
			docx.MainDocumentPart.Document.Save();
			foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
				ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
				WordFieldUtility.FillWordFieldsInElement(values, hpart.Header, docx.MainDocumentPart, config);
				hpart.Header.Save();
			}
			foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
				ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
				WordFieldUtility.FillWordFieldsInElement(values, fpart.Footer, docx.MainDocumentPart, config);
				fpart.Footer.Save();
			}
			docx.MainDocumentPart.Document.Save();
			return docx;
		}

		[Obsolete("7.15.0")]
		internal byte[] GetWordReport(byte[] data, Dictionary<string, DataValue> values) {
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					ConvertFieldCodes(docx.MainDocumentPart.Document, true, values);
					var config = new ReportConfig(userConnection);
					WordFieldUtility.FillWordFieldsInElement(values, docx.MainDocumentPart.Document,
						docx.MainDocumentPart, config);
					docx.MainDocumentPart.Document.Save();
					foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
						ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
						WordFieldUtility.FillWordFieldsInElement(values, hpart.Header, docx.MainDocumentPart, config);
						hpart.Header.Save();
					}
					foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
						ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
						WordFieldUtility.FillWordFieldsInElement(values, fpart.Footer, docx.MainDocumentPart, config);
						fpart.Footer.Save();
					}
					docx.MainDocumentPart.Document.Save();
					docx.Close();
				}
				stream.Seek(0, SeekOrigin.Begin);
				byte[] dataArray = stream.ToArray();
				return dataArray;
			}
		}

		#endregion

	}

	#endregion

	#region Class: AdditionalMacrosUtility

	public class AdditionalMacrosUtility : BaseOpenXmlUtility
	{

		#region Fields: Private

		UserConnection userConnection;
		Dictionary<string, string> columnsName = new Dictionary<string, string>();
		List<string> macrosColumnsCaptions = new List<string>();
		private Dictionary<string, byte[]> _imageBytesCache = new Dictionary<string, byte[]>();

		#endregion

		#region Constructors: Public

		public AdditionalMacrosUtility(UserConnection userConnection) {
			this.userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool CanUse7xFilters() {
			return FeatureUtilities.GetIsFeatureEnabled(userConnection, "Use7xFiltersForWordReports");
		}

		private string ChooseBetweenOldAndNewFilterConfiguration(string oldConfig, string newConfig) {
			if (CanUse7xFilters()) {
				return !string.IsNullOrEmpty(newConfig) ? newConfig : oldConfig;
			} else {
				return oldConfig;
			}
		}

		private JArray GetMacrosSettingsFromEntity(Entity entity) {
			var macrosList = entity.GetTypedColumnValue<string>("MacrosList");
			var macrosSettings = entity.GetTypedColumnValue<string>("MacrosSettings");
			return Json.Deserialize(ChooseBetweenOldAndNewFilterConfiguration(macrosList, macrosSettings)) as JArray;
		}

		private string GetFilterSettingsFromEntity(Entity entity) {
			var filterData = entity.GetBytesValue("Filter");
			var filterStr = filterData != null ? Encoding.UTF8.GetString(filterData, 0, filterData.Length) : null;
			var filterSettings = entity.GetTypedColumnValue<string>("FilterSettings");
			return ChooseBetweenOldAndNewFilterConfiguration(filterStr, filterSettings);
		}

		private void GetAdditionalMacrosesData(EntityCollection additionalMacroses, string[] macrosCaptionParts,
			string macrosDetailCaption, AdditionalMacrosesData macrosData, string baseSchemaName) {
			if (macrosCaptionParts.Length < 2) {
				return;
			}
			var baseSchema = userConnection.EntitySchemaManager.FindInstanceByName(baseSchemaName);
			string macrosColumnCaption = string.Empty;
			for (int i = 1; i < macrosCaptionParts.Length; i++) {
				macrosColumnCaption += macrosCaptionParts[i];
				if (i != macrosCaptionParts.Length - 1) {
					macrosColumnCaption += ".";
				}
			}
			if (macrosData.Captions.Contains(macrosColumnCaption)) {
				return;
			}
			foreach (var macros in additionalMacroses) {
				var columns = GetMacrosSettingsFromEntity(macros);
				for (var i = 0; i < columns.Count; i++) {
					var column = columns[i];
					if (macros.GetTypedColumnValue<string>("Caption") == macrosDetailCaption
							&& (column.Value<string>("caption") == macrosColumnCaption ||
								column.Value<string>("metaPathCaption") == macrosColumnCaption)) {
						macrosData.Captions.Add(macrosColumnCaption);
						macrosData.SortDirections.Add(column.Value<string>("sort"));
						macrosData.SortPositions.Add(i + 1);
						if (macrosData.SchemaUId == Guid.Empty) {
							macrosData.SchemaUId = macros.GetTypedColumnValue<Guid>("ObjectId");
							macrosData.AdditionalMacros = macros;
						}
						macrosData.ReferenceColumnCaption = macros.GetTypedColumnValue<string>("ReferenceColumn");
						macrosData.IsEmptyTableHide = macros.GetTypedColumnValue<bool>("IsEmptyTableHide");
						string objectColumnPath = macros.GetTypedColumnValue<string>("ObjectColumnPath");
						if (!string.IsNullOrEmpty(objectColumnPath)) {
							macrosData.ObjectColumnPath = objectColumnPath;
						} else {
							macrosData.ObjectColumnPath = baseSchema.PrimaryColumn.UId.ToString();
						}
					}
				}
			}
		}

		private WordprocessingDocument FillTableFieldsOutsideTables(WordprocessingDocument docx, Guid recordId,
				EntityCollection additionalMacroses, string schemaName) {
			OpenXmlUtility openXmlUtility = new OpenXmlUtility(userConnection);
			var dic = openXmlUtility.GetMergeFieldName(docx);
			var dics = new Dictionary<string, DataValue>();
			var expressionConverterHelper = new ExpressionConverterHelper();
			var baseSchema = userConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			foreach (var macrosCaption in dic) {
				var currentMacrosList = expressionConverterHelper.MacrosList(macrosCaption);
				var columnName = expressionConverterHelper.GetColumnName(macrosCaption);
				string[] macrosCaptionParts = columnName.Split(new char[] { '.' });
				if (macrosCaptionParts.Length < 2) {
					continue;
				}
				var macrocDetailCaption = macrosCaptionParts[0];
				string macrosColumnCaption = string.Empty;
				for (int z = 1; z < macrosCaptionParts.Length; z++) {
					macrosColumnCaption += macrosCaptionParts[z];
					if (z != macrosCaptionParts.Length - 1) {
						macrosColumnCaption += ".";
					}
				}
				Guid columnUId = Guid.Empty;
				Guid schemaUId = Guid.Empty;
				Entity additionalMacros = null;
				var referenceColumnCaption = string.Empty;
				var baseFilterPath = string.Empty;
				foreach (var macros in additionalMacroses) {
					var columns = GetMacrosSettingsFromEntity(macros);
					foreach (var column in columns) {
						var isColumnMatch =
							macros.GetTypedColumnValue<string>("Caption") == macrocDetailCaption &&
							(column.Value<string>("caption") == macrosColumnCaption || column.Value<string>("metaPathCaption") == macrosColumnCaption);
						if (isColumnMatch) {
							if (schemaUId == Guid.Empty) {
								schemaUId = macros.GetTypedColumnValue<Guid>("ObjectId");
								additionalMacros = macros;
							}
							referenceColumnCaption = macros.GetTypedColumnValue<string>("ReferenceColumn");
							baseFilterPath = macros.GetTypedColumnValue<string>("ObjectColumnPath");
							if (string.IsNullOrEmpty(baseFilterPath)) {
								baseFilterPath = baseSchema.PrimaryColumn.UId.ToString();
							}
						}
					}
				}
				if (schemaUId == Guid.Empty) {
					continue;
				}
				EntityCollection entityCollection = GetEntityValuesByColumnName(recordId, schemaUId,
					new List<string>() { macrosColumnCaption }, new List<string>() { string.Empty },
					referenceColumnCaption, additionalMacros, schemaName, baseFilterPath, new List<int> { 0 });
				if (entityCollection == null || entityCollection.Count == 0) {
					dics.Add(macrosCaption, null);
				} else {
					var dataValue = GetColumnValue(entityCollection[0], columnsName.First().Value);
					if (currentMacrosList.Count > 0) {
						if (!dics.ContainsKey(macrosCaption)) {
							var macrosValue = expressionConverterHelper.GetValue(currentMacrosList, dataValue.Data);
							dics.Add(macrosCaption, new DataValue(macrosValue.ValueType, macrosValue.Data));
						}
					} else {
						dics.Add(macrosCaption, dataValue);
					}
				}
			}
			docx = openXmlUtility.GetWordReport(docx, dics);
			return docx;
		}

		private EntityCollection GetEntityValuesByColumnName(Guid entityId, Guid objectId, List<string> captions,
				List<string> sortDirections, string referenceColumnName, Entity additionalMacros, string baseSchemaName,
				string baseFilterPath, List<int> sortPositions) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var baseEntitySchema = entitySchemaManager.GetInstanceByName(baseSchemaName);
			object filterValue = entityId;
			if (baseFilterPath.ToLower() != baseEntitySchema.PrimaryColumn.UId.ToString().ToLower()) {
				var filterValueEsq = new EntitySchemaQuery(entitySchemaManager, baseEntitySchema.Name);
				var filterValueColumn = filterValueEsq.AddColumn(
					baseEntitySchema.GetSchemaColumnPathByMetaPath(baseFilterPath));
				var filterEntity = filterValueEsq.GetEntity(userConnection, entityId);
				if (filterEntity != null) {
					var schemaColumn = filterEntity.Schema.Columns.GetByName(filterValueColumn.Name);
					filterValue = filterEntity.GetTypedColumnValue<object>(schemaColumn.ColumnValueName);
				}
			}
			var entitySchema = entitySchemaManager.GetInstanceByUId(objectId);
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			var macrosList = GetMacrosSettingsFromEntity(additionalMacros);
			columnsName = new Dictionary<string, string>();
			for (int index = 0; index < captions.Count; index++) {
				AddColumnToEntitySchemaQuery(esq, captions[index], sortDirections[index], sortPositions[index], macrosList);
			}
			string referenceColumnPath = string.Empty;
			if (IsMetaPath(referenceColumnName)) {
				referenceColumnPath = entitySchema.GetSchemaColumnPathByMetaPath(referenceColumnName);
			} else {
				referenceColumnPath = FindByCaption(entitySchema, referenceColumnName).Name;
			}
			esq.Filters.Add(
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, referenceColumnPath, filterValue));
			var filterStr = GetFilterSettingsFromEntity(additionalMacros);
			if (!string.IsNullOrEmpty(filterStr)) {
				esq.AddSerializedFilter(userConnection, filterStr);
			}
			return esq.GetEntityCollection(userConnection);
		}

		private void AddColumnToEntitySchemaQuery(EntitySchemaQuery query, string caption, string sortDirection,
				int orderPosition, JArray columns) {
			JObject column = null;
			var macrosColumn = string.Empty;
			for (int i = 0; i < columns.Count; i++) {
				var metaPathCaptionColumn = columns[i].Value<string>("metaPathCaption");
				var captionColumn = columns[i].Value<string>("caption");
				metaPathCaptionColumn = metaPathCaptionColumn.Replace("\\", "\\\\");
				captionColumn = captionColumn.Replace("\\", "\\\\");
				if (captionColumn.Trim() == caption.Trim()) {
					column = columns[i] as JObject;
					macrosColumn = captionColumn.Trim();
					break;
				} else if (metaPathCaptionColumn.Trim() == caption.Trim()) {
					column = columns[i] as JObject;
					macrosColumn = metaPathCaptionColumn.Trim();
					break;
				}
			}
			if (column == null) {
				return;
			}
			EntitySchemaQueryColumn queryColumn = null;
			foreach (var esqColumn in query.Columns) {
				if (esqColumn.Caption.Value == column.Value<string>("caption")
						|| esqColumn.Caption.Value == column.Value<string>("metaPathCaption")) {
					queryColumn = esqColumn;
				}
			}
			if (queryColumn == null) {
				if (string.IsNullOrEmpty(column.Value<string>("aggregationType")) ||
						string.Compare(column.Value<string>("aggregationType"), "None", true) == 0) {
					queryColumn = query.AddColumn(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
					if (queryColumn.DisplayExpression != null) {
						string displayValueMetaPath = queryColumn.DisplayExpression.Path;
						query.RemoveColumn(queryColumn.Name);
						queryColumn = query.AddColumn(displayValueMetaPath);
					}
				} else {
					EntitySchemaQuery subQuery = null;
					queryColumn = query.AddColumn(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")),
						(AggregationTypeStrict)Enum.Parse(typeof(AggregationTypeStrict), column.Value<string>("aggregationType")),
						out subQuery);
					var subFiltersStr = column.Value<string>("subFilters");
					if (!string.IsNullOrEmpty(subFiltersStr)) {
						subQuery.AddSerializedFilter(userConnection, subFiltersStr);
					}
					queryColumn.Name = StringUtilities.CleanUpColumnName(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
				}
			}
			if (!string.IsNullOrEmpty(sortDirection)) {
				queryColumn.OrderDirection = (OrderDirection)Enum.Parse(typeof(OrderDirection), sortDirection);
				queryColumn.OrderPosition = orderPosition;
			}
			queryColumn.UId = !string.IsNullOrEmpty(column.Value<string>("columnUId")) &&
				!new Guid(column.Value<string>("columnUId")).IsEmpty()
				? new Guid(column.Value<string>("columnUId"))
				: Guid.NewGuid();
			if (!string.IsNullOrEmpty(column.Value<string>("caption"))) {
				queryColumn.Caption = column.Value<string>("caption");
			} else if (!string.IsNullOrEmpty(column.Value<string>("metaPathCaption"))) {
				queryColumn.Caption = column.Value<string>("metaPathCaption");
			}
			queryColumn.IsAlwaysSelect = true;
			queryColumn.IsVisible = true;
			if (!columnsName.ContainsKey(macrosColumn)) {
				columnsName.Add(macrosColumn, queryColumn.Name);
			}
		}

		private T GetFirstParent<T>(OpenXmlElement element) where T : OpenXmlElement {
			if (element.Parent == null) {
				return null;
			}
			if (element.Parent.GetType() == typeof(T)) {
				return element.Parent as T;
			}
			return GetFirstParent<T>(element.Parent);
		}

		private EntityCollection GetAllAdditionalMacros(Guid templateId) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var additionalMacrosES = entitySchemaManager.GetInstanceByName("SysModuleReportTable");
			var additionalMacrosESQ = new EntitySchemaQuery(entitySchemaManager, additionalMacrosES.Name);
			additionalMacrosESQ.AddColumn("MacrosList");
			additionalMacrosESQ.AddColumn("MacrosSettings");
			additionalMacrosESQ.AddColumn("ObjectId");
			additionalMacrosESQ.AddColumn("ReferenceColumn");
			additionalMacrosESQ.AddColumn("Caption");
			additionalMacrosESQ.AddColumn("Filter");
			additionalMacrosESQ.AddColumn("FilterSettings");
			additionalMacrosESQ.AddColumn("ObjectColumnPath");
			additionalMacrosESQ.AddColumn("ObjectColumnCaption");
			additionalMacrosESQ.AddColumn("ReferenceColumnCaption");
			additionalMacrosESQ.AddColumn("IsEmptyTableHide");
			additionalMacrosESQ.Filters.Add(
			additionalMacrosESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"SysModuleReport", templateId));
			return additionalMacrosESQ.GetEntityCollection(userConnection);
		}

		/// <summary>
		/// Returns report date column value.
		/// </summary>
		/// <param name="value">Column value.</param>
		/// <returns>String.</returns>
		private string GetReportDateColumnValue(string value) {
			DateTime date = DateTime.Parse(value);
			return date.ToString("d");
		}

		/// <summary>
		/// Returns report decimal column value.
		/// </summary>
		/// <param name="decimalValue">Decimal value.</param>
		/// <param name="separator">Number decimal separator.</param>
		/// <returns>String.</returns>
		private string GetReportDecimalColumnValue(Entity entity, EntitySchemaColumn entityColumn) {
			decimal decimalValue = entity.GetTypedColumnValue<decimal>(entityColumn);
			return FormatDecimalValue(decimalValue);
		}

		private string FormatDecimalValue(decimal value) {
			string formattedValue = string.Empty;
			string separator = SysSettings.GetValue<string>(userConnection, "ReportDecimalSeparator", string.Empty);
			if (!string.IsNullOrEmpty(separator)) {
				NumberFormatInfo numberFormatInfo = new NumberFormatInfo() {
					NumberDecimalSeparator = separator,
					NumberGroupSeparator = string.Empty
				};
				formattedValue = value.ToString(numberFormatInfo);
			} else {
				formattedValue = value.ToString();
			}
			return formattedValue;
		}

		private DataValue GetColumnValue(Entity entity, string columnName) {
			var column = entity.Schema.Columns.GetByName(columnName);
			object value = GetReportColumnValue(entity, column);
			return new DataValue(column.DataValueType, value);
		}

		private EntitySchemaColumn FindByCaption(EntitySchema schema, string caption) {
			foreach (var item in schema.Columns) {
				if (item.Caption.Value.Equals(caption)) {
					return item;
				}
			}
			return null;
		}

		private void ClonePicture(MainDocumentPart mainDocumentPart, OpenXmlPictures.Picture picture) {
			string imageId = picture.BlipFill.Blip.Embed.Value;
			int picturesCount = mainDocumentPart.GetPartsOfType<ImagePart>().Count();
			ImagePart mediaPart = (ImagePart)mainDocumentPart.GetPartById(imageId);
			ImagePart newMediaPart = mainDocumentPart.AddImagePart(mediaPart.ContentType);
			byte[] imageBytes = GetImageBytesFromMainDocumentPart(mainDocumentPart, imageId);
			using (var mediaStream = new MemoryStream(imageBytes)) {
				newMediaPart.FeedData(mediaStream);
			}
			string newMediaPartId = mainDocumentPart.GetIdOfPart(newMediaPart);
			string newImageId = (picturesCount + 1).ToString();
			DocProperties docProperties = WordFieldUtility.GetPictureDocProperties(picture);
			docProperties.Id.InnerText = newImageId;
			picture.BlipFill.Blip.Embed.Value = newMediaPartId;
			picture.NonVisualPictureProperties.NonVisualDrawingProperties.Id.InnerText = newImageId;
		}

		private void RemovePicture(MainDocumentPart mainDocumentPart, OpenXmlPictures.Picture picture) {
			string mediaId = picture.BlipFill.Blip.Embed.Value;
			try {
				mainDocumentPart.DeletePart(mediaId);
			} catch (ArgumentOutOfRangeException) {
				//Do nothing
			}
			if (picture.Parent != null) {
				picture.Parent.RemoveChild<OpenXmlPictures.Picture>(picture);
			}
		}

		private bool IsMetaPath(string path) {
			string firstRefElement = path.Split('.')[0];
			Guid newGuid;
			return Guid.TryParse(firstRefElement, out newGuid);
		}

		private string GetReportMoneyColumnValue(Entity entity, EntitySchemaColumn entityColumn) {
			decimal value = Math.Round(entity.GetTypedColumnValue<decimal>(entityColumn),
				BPMSoft.Core.Configuration.SysSettings.GetValue(entity.UserConnection,
					"MoneyFieldDisplayPrecision", 2), MidpointRounding.AwayFromZero);
			return FormatDecimalValue(value);
		}

		private void FillMacrosColumnCaptions(EntityCollection additionalMacroses) {
			foreach (Entity macros in additionalMacroses) {
				var columns = GetMacrosSettingsFromEntity(macros);
				foreach (var column in columns) {
					macrosColumnsCaptions.Add(string.Format("{0}.{1}", macros.GetTypedColumnValue<string>("Caption"),
						column.Value<string>("caption")));
				}
			}
		}

		private void FillMacrosData(string macrosCaption, string schemaName, EntityCollection additionalMacroses,
				Dictionary<string, AdditionalMacrosesData> additionalMacrosesData) {
			string[] macrosCaptionParts = Regex.Split(macrosCaption, @"\.(?=\S+)");
			string macrosDetailCaption = macrosCaptionParts[0];
			if (!additionalMacrosesData.ContainsKey(macrosDetailCaption)) {
				additionalMacrosesData.Add(macrosDetailCaption, new AdditionalMacrosesData());
			}
			GetAdditionalMacrosesData(additionalMacroses, macrosCaptionParts, macrosDetailCaption,
				additionalMacrosesData[macrosDetailCaption], schemaName);
		}

		private void FillConversionMacrosData(string fullColumnName, string macrosCaption, Dictionary<string, ColumnMacros> dicMacros) {
			var expressionConverterHelper = new ExpressionConverterHelper();
			List<ExpressionConverterElement> currentMacrosList = expressionConverterHelper.MacrosList(fullColumnName);
			if (currentMacrosList.Count > 0 && !dicMacros.ContainsKey(fullColumnName)) {
				dicMacros.Add(fullColumnName, new ColumnMacros {
					Name = fullColumnName,
					ColumnName = macrosCaption,
					MacrosList = currentMacrosList
				});
			}
		}

		private void FillMacrosDataFromSimpleFields(TableRow tableRow, string schemaName, EntityCollection additionalMacroses,
				Dictionary<string, AdditionalMacrosesData> additionalMacrosesData, Dictionary<string, ColumnMacros> dicMacros) {
			var expressionConverterHelper = new ExpressionConverterHelper();
			foreach (var simpleField in tableRow.Descendants<SimpleField>()) {
				string fullColumnName = WordFieldUtility.GetFieldName(simpleField);
				string macrosCaption = expressionConverterHelper.GetColumnName(fullColumnName);
				FillConversionMacrosData(fullColumnName, macrosCaption, dicMacros);
				FillMacrosData(macrosCaption, schemaName, additionalMacroses, additionalMacrosesData);
			}
		}

		private void FillMacrosDataFromPictureFields(TableRow tableRow, string schemaName, EntityCollection additionalMacroses,
				Dictionary<string, AdditionalMacrosesData> additionalMacrosesData) {
			foreach (var pictureField in tableRow.Descendants<OpenXmlPictures.Picture>()) {
				DocProperties pictureProperties = WordFieldUtility.GetPictureDocProperties(pictureField);
				string macrosCaption = tableRow.Descendants<DocProperties>()
					.FirstOrDefault(x => x.Id.InnerText == pictureProperties.Id.InnerText).Name.Value;
				FillMacrosData(macrosCaption, schemaName, additionalMacroses, additionalMacrosesData);
			}
		}

		private void FillMacrosData(Table table, string schemaName, EntityCollection additionalMacroses,
				out Dictionary<string, AdditionalMacrosesData> additionalMacrosesData,
				out Dictionary<string, ColumnMacros> dicMacros) {
			dicMacros = new Dictionary<string, ColumnMacros>();
			additionalMacrosesData = new Dictionary<string, AdditionalMacrosesData>();
			foreach (TableRow tableRow in table.ChildElements.OfType<TableRow>()) {
				FillMacrosDataFromSimpleFields(tableRow, schemaName, additionalMacroses, additionalMacrosesData, dicMacros);
				FillMacrosDataFromPictureFields(tableRow, schemaName, additionalMacroses, additionalMacrosesData);
			}
		}

		private bool IsPictureUsedInDocument(WordprocessingDocument docx, string pictureId) {
			return new OpenXmlElement[] { docx.MainDocumentPart.Document }
				.Concat(docx.MainDocumentPart.HeaderParts.Select(headerPart => headerPart.Header))
				.Concat(docx.MainDocumentPart.FooterParts.Select(footerPart => footerPart.Footer))
				.SelectMany(elementContainer => elementContainer.Descendants<OpenXmlPictures.Picture>())
				.Any(x => x.BlipFill.Blip.Embed.Value == pictureId);
		}

		private void CollectUnusedPictures(WordprocessingDocument docx, Table table, List<OpenXmlPictures.Picture> unusedPictures) {
			foreach (TableRow tableRow in table.ChildElements.OfType<TableRow>()) {
				foreach (OpenXmlPictures.Picture picture in tableRow.Descendants<OpenXmlPictures.Picture>()) {
					string pictureId = picture.BlipFill.Blip.Embed.Value;
					if (!IsPictureUsedInDocument(docx, pictureId)) {
						unusedPictures.Add(picture);
					}
				}
			}
		}

		private void RemoveUnusedResources(WordprocessingDocument docx, List<OpenXmlPictures.Picture> unusedPictures,
				List<Table> tablesToDelete) {
			foreach (OpenXmlPictures.Picture picture in unusedPictures) {
				RemovePicture(docx.MainDocumentPart, picture);
			}
			unusedPictures.Clear();
			foreach (Table table in tablesToDelete) {
				table.Parent.RemoveChild(table);
			}
			tablesToDelete.Clear();
		}

		private void FillTableUsingMacrosData(Guid recordId, string schemaName, WordprocessingDocument docx,
				Table table, Dictionary<string, AdditionalMacrosesData> additionalMacrosesData,
				Dictionary<string, ColumnMacros> dicMacros, List<Table> tablesToDelete) {
			var expressionConverterHelper = new ExpressionConverterHelper();
			TableRow macrosRow = null;
			TableRow[] rows = table.ChildElements.OfType<TableRow>().ToArray();
			var config = new ReportConfig(userConnection);
			foreach (var macrosDataItem in additionalMacrosesData) {
				var macrosData = macrosDataItem.Value;
				var macrosDetailCaption = macrosDataItem.Key;
				if (macrosData.SchemaUId == Guid.Empty) {
					continue;
				}
				EntityCollection entityCollection = GetEntityValuesByColumnName(recordId,
					macrosData.SchemaUId, macrosData.Captions, macrosData.SortDirections,
					macrosData.ReferenceColumnCaption, macrosData.AdditionalMacros, schemaName,
					macrosDataItem.Value.ObjectColumnPath, macrosData.SortPositions);
				if (entityCollection.Count == 0 && macrosData.IsEmptyTableHide) {
					tablesToDelete.Add(table);
				}
				for (int i = 0; i < entityCollection.Count; i++) {
					for (int j = 0; j < rows.Length; j++) {
						macrosRow = rows[j];
						TableRow tableRow = macrosRow.Clone() as TableRow;
						Dictionary<string, DataValue> values = new Dictionary<string, DataValue>();
						foreach (var columnName in columnsName) {
							var cleanColumnName = string.Concat(macrosDetailCaption, ".", columnName.Key);
							var columnValue = GetColumnValue(entityCollection[i], columnName.Value);
							values.Add(cleanColumnName, columnValue);
							if (dicMacros.Count(d => d.Value.ColumnName == cleanColumnName) > 0) {
								foreach (var macrosItem in dicMacros.Where(d => d.Value.ColumnName == cleanColumnName)) {
									var macros = macrosItem.Value;
									var macrosValue = expressionConverterHelper.GetValue(macros.MacrosList, columnValue.Data);
									values.Add(macrosItem.Key, new DataValue(macrosValue.ValueType, macrosValue.Data));
								}
							}
						}
						foreach (OpenXmlPictures.Picture picture in tableRow.Descendants<OpenXmlPictures.Picture>()) {
							ClonePicture(docx.MainDocumentPart, picture);
						}
						if (!tableRow.Descendants<SimpleField>().Any() &&
							!tableRow.Descendants<OpenXmlPictures.Picture>().Any()) {
							continue;
						}
						if (macrosRow.Parent != table) {
							continue;
						}
						WordFieldUtility.FillWordFieldsInElement(values, tableRow, docx.MainDocumentPart, config);
						table.InsertBefore<TableRow>(tableRow, macrosRow);
						if (i == entityCollection.Count - 1) {
							table.RemoveChild<TableRow>(macrosRow);
						}
					}
				}
			}
		}

		private void FillTableAdditionalMacros(WordprocessingDocument docx, Table table, string schemaName,
				EntityCollection additionalMacroses, Guid recordId, List<Table> tablesToDelete,
				List<OpenXmlPictures.Picture> unusedPictures) {
			Dictionary<string, AdditionalMacrosesData> additionalMacrosesData;
			Dictionary<string, ColumnMacros> dicMacros;
			FillMacrosData(table, schemaName, additionalMacroses, out additionalMacrosesData, out dicMacros);
			FillTableUsingMacrosData(recordId, schemaName, docx, table, additionalMacrosesData, dicMacros, tablesToDelete);
			CollectUnusedPictures(docx, table, unusedPictures);
		}

		private byte[] GetImageBytesFromMainDocumentPart(MainDocumentPart mainDocumentPart, string imageId) {
			// Cache result because, can’t open a file in the zip package more than once for writing.
			if (_imageBytesCache.TryGetValue(imageId, out byte[] imageBytes)) {
				return imageBytes;
			} else {
				var imagePart = (ImagePart)mainDocumentPart.GetPartById(imageId);
				using (Stream imageStream = imagePart.GetStream()) {
					imageBytes = imageStream.ReadAllBytes();
					_imageBytesCache.Add(imageId, imageBytes);
				}
				return imageBytes;
			}
		}

		#endregion

		#region Methods: Internal

		internal WordprocessingDocument FillAdditionalMacros(WordprocessingDocument docx, Guid recordId,
				string schemaName, Guid templateId) {
			EntityCollection additionalMacroses = GetAllAdditionalMacros(templateId);
			if (additionalMacroses.Count == 0) {
				return docx;
			}
			FillMacrosColumnCaptions(additionalMacroses);
			ConvertFieldCodes(docx.MainDocumentPart.Document, false, new Dictionary<string, DataValue>());
			var unusedPictures = new List<OpenXmlPictures.Picture>();
			var tablesToDelete = new List<Table>();
			foreach (Table table in docx.MainDocumentPart.Document.Descendants<Table>()) {
				if (table.Descendants<SimpleField>().Any() || table.Descendants<OpenXmlPictures.Picture>().Any()) {
					FillTableAdditionalMacros(docx, table, schemaName, additionalMacroses, recordId, tablesToDelete, unusedPictures);
				}
			}
			foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
				foreach (Table table in hpart.Header.Descendants<Table>()) {
					FillTableAdditionalMacros(docx, table, schemaName, additionalMacroses, recordId, tablesToDelete, unusedPictures);
				}
				hpart.Header.Save();
			}
			foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
				foreach (Table table in fpart.Footer.Descendants<Table>()) {
					FillTableAdditionalMacros(docx, table, schemaName, additionalMacroses, recordId, tablesToDelete, unusedPictures);
				}
				fpart.Footer.Save();
			}
			RemoveUnusedResources(docx, unusedPictures, tablesToDelete);
			var reportConfig = new ReportConfig(userConnection);
			if (!reportConfig.DisableFillingTableFieldsOutsideTables) {
				FillTableFieldsOutsideTables(docx, recordId, additionalMacroses, schemaName);
			}
			docx.MainDocumentPart.Document.Save();
			return docx;
		}

		[Obsolete("7.15.0")]
		internal byte[] FillAdditionalMacros(byte[] data, Guid recordId, string schemaName, Guid templateId) {
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					FillAdditionalMacros(docx, recordId, schemaName, templateId);
					docx.Close();
					return stream.ToArray();
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns report column value.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="entityColumn">Entity schema column.</param>
		/// <returns>Object.</returns>
		public object GetReportColumnValue(Entity entity, EntitySchemaColumn entityColumn) {
			if (entityColumn.DataValueType is BinaryDataValueType ||
					entityColumn.DataValueType is ImageDataValueType) {
				return entity.GetStreamValue(entityColumn.Name);
			} else {
				string stringValue = entity.GetTypedColumnValue<string>(entityColumn);
				if (!string.IsNullOrEmpty(stringValue)) {
					if (entityColumn.DataValueType is DateDataValueType) {
						stringValue = GetReportDateColumnValue(stringValue);
					}
					if (entityColumn.DataValueType is FloatDataValueType) {
						if (entityColumn.DataValueType is MoneyDataValueType) {
							stringValue = GetReportMoneyColumnValue(entity, entityColumn);
						} else {
							stringValue = GetReportDecimalColumnValue(entity, entityColumn);
						}
					}
				}
				return stringValue;
			}
		}

		#endregion

		#region Class: AdditionalMacrosesData

		class AdditionalMacrosesData
		{

			#region Constructors: Public

			public AdditionalMacrosesData() {
				Captions = new List<string>();
				SortDirections = new List<string>();
			}

			#endregion

			#region Properties: Public

			public List<string> Captions { get; set; }

			public List<string> SortDirections { get; set; }

			public List<int> SortPositions { get; } = new List<int>();

			public Guid SchemaUId { get; set; }

			public string ReferenceColumnCaption { get; set; }

			public Entity AdditionalMacros { get; set; }

			public string ObjectColumnPath { get; set; }

			public string ObjectColumnCaption { get; set; }

			public bool IsEmptyTableHide { get; set; }

			#endregion

		}

		#endregion

	}

	#endregion

	#region Class: ColumnMacros

	public class ColumnMacros
	{

		#region Properties: Public

		public string Name { get; set; }

		public string ColumnName { get; set; }

		public List<ExpressionConverterElement> MacrosList { get; set; }

		#endregion

	}

	#endregion

	#region Class: RunBlock

	public class RunBlock
	{
		#region Properties: Public

		private List<Run> _innerItems = new List<Run>();
		public List<Run> InnerItems { get { return _innerItems; } }

		public string instruction = null;

		public RunProperties RunProperties { get; set; }

		#endregion

		#region Methods: Public

		public Run GenerateNewRun(bool isReplacingConvertion, Dictionary<string, DataValue> values) {
			if (!string.IsNullOrEmpty(instruction) && instruction.IndexOf("MERGEFIELD") >= 0) {
				Match m = WordFieldUtility.MergeFormat.Match(instruction.Replace("\"", string.Empty));
				string fieldName = string.Empty;
				if (m.Success) {
					fieldName = m.Groups["Name"].ToString().Trim();
				}
				if (!isReplacingConvertion || values.ContainsKey(fieldName)) {
					var run = new Run();
					if (RunProperties != null)
						run.AppendChild(RunProperties.CloneNode(true));
					SimpleField simplefield = new SimpleField { Instruction = instruction };
					run.AppendChild(simplefield);
					return run;
				}
			}
			return null;
		}

		#endregion
	}

	#endregion

	#region Class: WebResponseProcessor

	public class WebResponseProcessor
	{

		/// <summary>
		/// Assigns file stream response.
		/// </summary>
		/// <param name="httpContext"><see cref="HttpContext"/>.</param>
		/// <param name="contentType">Response content type.</param>
		/// <param name="contentLength">Response content length.</param>
		/// <param name="contentDisposition">Response content disposition.</param>
		public virtual void AssignFileResponseContent(HttpContext httpContext, string contentType, long contentLength, string contentDisposition) {
#if !NETSTANDARD2_0
			WebOperationContext.Current.OutgoingResponse.ContentType = contentType;
			WebOperationContext.Current.OutgoingResponse.ContentLength = contentLength;
			WebOperationContext.Current.OutgoingResponse.Headers.Add("Content-Disposition", contentDisposition);
#else
			HttpResponse response = httpContext.Response;
			response.ContentType = contentType;
			response.Headers["Content-Length"] = contentLength.ToString(CultureInfo.InvariantCulture);
			response.Headers["Content-Disposition"] = contentDisposition;
#endif
		}
	}

	#endregion

}

