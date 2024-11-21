namespace BPMSoft.Configuration
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.UI.WebControls.Controls;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Wordprocessing;
	using OpenXmlPictures = DocumentFormat.OpenXml.Drawing.Pictures;
	using OpenXmlDrawingProcessing = DocumentFormat.OpenXml.Drawing.Wordprocessing;
	using System.Globalization;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using TSConfiguration = BPMSoft.Configuration;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.FileUpload;

	#region WordReportUtility

	public struct PictureData {

		public string FieldName;

		public string PictureId;

		public OpenXmlDrawingProcessing.DocProperties DocProperties;

		public PictureData(string fieldName, string pictureId, OpenXmlDrawingProcessing.DocProperties docProperties) {
			FieldName = fieldName;
			PictureId = pictureId;
			DocProperties = docProperties;
		}

	}

	public class DataValue
	{
		#region Contructors: Public
		
		public DataValue(DataValueType valueType, object data) {
			ValueType = valueType;
			Data = data;
		}

		#endregion

		#region Properties: Public

		public DataValueType ValueType {
			get;
			set;
		}

		public object Data {
			get;
			set;
		}

		#endregion

	}

	public class PictureUtility
	{

		#region Methods: Public

		public static OpenXmlDrawingProcessing.DocProperties GetPictureDocProperties(OpenXmlPictures.Picture picture) {
			OpenXmlElement parent = picture.Parent.Parent.Parent;
			return parent.Descendants<OpenXmlDrawingProcessing.DocProperties>().FirstOrDefault();
		}

		public static Dictionary<string, PictureData> GetPicturesData(OpenXmlElement element) {
			var docPropList = element.Descendants<OpenXmlPictures.Picture>()
				.Select(picture => new {
					propId = GetPictureDocProperties(picture).Id.InnerText
				}).ToList();
			Dictionary<string, PictureData> picturesData = new Dictionary<string, PictureData>();
			foreach(var docProp in docPropList) {
				if (picturesData.ContainsKey(docProp.propId)) {
					continue;
				}
				var pictureData = element.Descendants<OpenXmlPictures.Picture>()
					.Where(picture => (docProp.propId == GetPictureDocProperties(picture).Id.InnerText)
						&& (!string.IsNullOrEmpty(GetPictureDocProperties(picture).Name.Value)))
					.Select(picture => new {
						fieldName = GetPictureDocProperties(picture).Name.Value,
						pictureId = picture.BlipFill.Blip.Embed.Value,
						docProperties = GetPictureDocProperties(picture) 
					}).FirstOrDefault();
				if (pictureData == null) {
					continue;
				}
				picturesData.Add(docProp.propId, new PictureData(pictureData.fieldName, pictureData.pictureId, pictureData.docProperties));
			}
			return picturesData;
		}

		#endregion

	}

	public class WordReportUtility
	{

		#region Constants: Private

		const string FileNameMacros = "{0}File";

		#endregion

		#region Properties: Private
		
		UserConnection userConnection;
		
		#endregion

		#region Constructors: Public

		public WordReportUtility(UserConnection userConnection)
		{
			this.userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private string GetSchemaNameByTemplateId(Guid templateId)
		{
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var reportES = entitySchemaManager.GetInstanceByName("SysModuleReport"); 
			var reportESQ = new EntitySchemaQuery(entitySchemaManager, reportES.Name);
			reportESQ.AddColumn(reportES.GetPrimaryColumnName());
			reportESQ.AddColumn("SysModule");
			var entitySchemaColumnName = reportESQ.AddColumn("SysModule.SysModuleEntity.SysEntitySchemaUId").Name;
			reportESQ.Filters.Clear();
			reportESQ.Filters.Add(
			reportESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"Id",
				templateId));
			var reportCollection = reportESQ.GetEntityCollection(userConnection);
			if(reportCollection.Count > 0) {
				var reportEntity  = reportCollection[0];
				var schemaColumnName = reportEntity.Schema.Columns.GetByName(entitySchemaColumnName);
				var schemaId = reportEntity.GetTypedColumnValue<object>(schemaColumnName);
				return entitySchemaManager.GetInstanceByUId(new Guid(schemaId.ToString())).Name;
			}
			return string.Empty;
		}

		private string GetMacrosListByTemplateId(Guid templateId) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var reportES = entitySchemaManager.GetInstanceByName("SysModuleReport"); 
			var reportESQ = new EntitySchemaQuery(entitySchemaManager, reportES.Name);
			var macroslistColumnName = reportESQ.AddColumn("MacrosList").Name;
			reportESQ.Filters.Add(
			reportESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"Id",
				templateId));
			var reportCollection = reportESQ.GetEntityCollection(userConnection);
			if(reportCollection.Count > 0) {
				var reportEntity  = reportCollection[0];
				return reportEntity.GetTypedColumnValue<string>(macroslistColumnName);
			}
			return string.Empty;
		}

		private byte[] GetTemplateSource(Guid templateId)
		{
			var report = userConnection.EntitySchemaManager.GetInstanceByName("SysModuleReport").CreateEntity(userConnection);
			if (report.FetchFromDB("Id", templateId, new Collection<string> {
					"MacrosList", "File"})) {
				string macrosList = report.GetTypedColumnValue<string>("MacrosList");
				return report.GetBytesValue("File");
			}
			return new byte[1]; 
		}

		private Guid SaveReportToFile(byte[] buffer, string schemaName, Guid selectedNode, string reportName)
		{
			using (var reportStream = new MemoryStream(buffer)) {
				var fileRepository = ClassFactory.Get<FileRepository>(
					new ConstructorArgument("userConnection", userConnection));
				var fileSchemaName = string.Format(FileNameMacros, schemaName);
				var fileId = Guid.NewGuid();
				var fileName = string.Format("{0}.docx", reportName);
				var fileEntityInfo = new FileEntityUploadInfo(fileSchemaName, fileId, fileName);
				fileEntityInfo.ParentColumnName = schemaName;
				fileEntityInfo.ParentColumnValue = selectedNode;
				fileEntityInfo.TotalFileLength = reportStream.Length;
				fileEntityInfo.Content = reportStream;
				fileRepository.UploadFile(fileEntityInfo);
				return fileId;
			}
		}

		private string GetTemplateNameByUId(Guid templateId) {
			var report = userConnection.EntitySchemaManager.GetInstanceByName("SysModuleReport").CreateEntity(userConnection);
			if (report.FetchFromDB("Id", templateId, new Collection<string> {"Caption"})) {
				return report.GetTypedColumnValue<string>("Caption");
			}
			return string.Empty;
		}

		private static void DisableEmptyEntitySchemaQueryFilters(
				IEnumerable<IEntitySchemaQueryFilterItem> queryFilterCollection) {
			foreach (var item in queryFilterCollection) {
				var filter = item as EntitySchemaQueryFilter;
				if (filter != null) {
					if (filter.RightExpressions.Count == 0 && filter.ComparisonType != FilterComparisonType.IsNull &&
							filter.ComparisonType != FilterComparisonType.IsNotNull) {
						filter.IsEnabled = false;
						continue;
					}
					if (filter.LeftExpression != null &&
							filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
						DisableEmptyEntitySchemaQueryFilters(filter.LeftExpression.SubQuery.Filters);
					}
					foreach (var rightExpression in filter.RightExpressions) {
						if (rightExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
							DisableEmptyEntitySchemaQueryFilters(rightExpression.SubQuery.Filters);
						}
					}
				} else {
					DisableEmptyEntitySchemaQueryFilters((EntitySchemaQueryFilterCollection)item);
				}
			}
		}

		private void AddColumnToEntitySchemaQuery(EntitySchemaQuery query, string caption, JArray columns, Dictionary<string, string> dicESQ) {
			JObject column = null;
			var macrosColumn = string.Empty;
			for (int i = 0; i < columns.Count; i++) {
				var captionColumn = columns[i].Value<string>("caption");
				if (captionColumn.Contains(@"\")) {
					for (int j = 0; j < captionColumn.Length; j++) {
						if (captionColumn[j] == '\\') {
							captionColumn = captionColumn.Insert(j, @"\");
							j++;
						}
					}
				}
				if (captionColumn == caption) {
					column = columns[i] as JObject;
					macrosColumn = captionColumn;
					break;
				}
			}
			if (column == null) {
				return;
			}
			EntitySchemaQueryColumn queryColumn = null;
			foreach (var esqColumn in query.Columns) {
				if (esqColumn.Caption.Value == column.Value<string>("caption")) {
					queryColumn = esqColumn;
				}
			}
			if (queryColumn == null) {
				if (string.IsNullOrEmpty(column.Value<string>("aggregationType"))
					|| string.Compare(column.Value<string>("aggregationType"), "None", true) == 0) {
					queryColumn = query.AddColumn(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
					if (queryColumn.DisplayExpression != null) {
						string displayValueMetaPath = queryColumn.DisplayExpression.Path;
						query.RemoveColumn(queryColumn.Name);
						queryColumn = query.AddColumn(displayValueMetaPath);
					}
				} else {
					EntitySchemaQuery subQuery = null;
					queryColumn = query.AddColumn(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")), 
						(AggregationTypeStrict)Enum.Parse(typeof(AggregationTypeStrict), column.Value<string>("aggregationType")),
						out subQuery);
					if (!string.IsNullOrEmpty(column.Value<string>("subFilters"))) {
						var converter = new DataSourceFiltersJsonConverter(userConnection,
							subQuery.RootSchema) {
								PreventRegisteringClientScript = true
							};
						var filters = JsonConvert.DeserializeObject<DataSourceFilterCollection>(
								column.Value<string>("subFilters"), converter);
						EntitySchemaQueryFilterCollection esqFilters =
							filters.ToEntitySchemaQueryFilterCollection(subQuery);
						DisableEmptyEntitySchemaQueryFilters(esqFilters);
						subQuery.Filters.Add(esqFilters);
					}
					queryColumn.Name = StringUtilities.CleanUpColumnName(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
				}
			}
			queryColumn.UId = !string.IsNullOrEmpty(column.Value<string>("columnUId")) && 
				!new Guid(column.Value<string>("columnUId")).IsEmpty()
					? new Guid(column.Value<string>("columnUId")) 
					: Guid.NewGuid();
			if (!string.IsNullOrEmpty(column.Value<string>("caption"))) {
				queryColumn.Caption = column.Value<string>("caption");
			}
			queryColumn.IsAlwaysSelect = true;
			queryColumn.IsVisible = true;
			dicESQ.Add(macrosColumn, queryColumn.Name);
		}

		private Dictionary<string, DataValue> GetEntityValuesByColumnName(Guid entityId, string entityName, Collection<string> captions, Guid templateId) {	
			Dictionary<string, string> dicESQ = new Dictionary<string, string>();
			Dictionary<string, DataValue> fillDic = new Dictionary<string, DataValue>();
			if (captions.Count == 0) {
				return fillDic;
			}
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName(entityName); 
			var ESQ = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			string macroslist = GetMacrosListByTemplateId(templateId);
			if (string.IsNullOrEmpty(macroslist)) {
				return fillDic;
			}
			var macrosList = Json.Deserialize(macroslist) as JArray;
			foreach(var item in captions) {
				AddColumnToEntitySchemaQuery(ESQ, item, macrosList, dicESQ);
			}
			ESQ.Filters.Add(
			ESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"Id", entityId));
			var entityCollection = ESQ.GetEntityCollection(userConnection);
			if(entityCollection.Count > 0) {
				foreach(var item in dicESQ) {
					var entityEntity  = entityCollection[0];
					var entityColumnName = entityEntity.Schema.Columns.GetByName(item.Value);
					object value = null;
					if ((entityColumnName.DataValueType is BinaryDataValueType) || 
						(entityColumnName.DataValueType is ImageDataValueType)) {
						value = entityEntity.GetStreamValue(entityColumnName.Name);
					} else {
						string stringValue = entityEntity.GetTypedColumnValue<string>(entityColumnName);
						if (entityColumnName.DataValueType is DateDataValueType && !string.IsNullOrEmpty(stringValue)) {
							DateTime date = DateTime.Parse(stringValue);
							value = date.ToString("d", userConnection.CurrentUser.Culture);
						}
						value = stringValue;
					}
					fillDic.Add(item.Key, new DataValue(entityColumnName.DataValueType, value));
				}
			}
			return fillDic;
		}

		private EntitySchemaColumn FindByCaption(EntitySchema schema, string caption) {
			foreach (var item in schema.Columns) {
				if (item.Caption.Value.Equals(caption)) {
					return item;
				}
			}
			return null;
		}

		#endregion

		#region Methods: Public

		public Guid GenerateReport(Guid templateId, Guid recordUId)
		{
			OpenXmlUtility openXmlUtility = new OpenXmlUtility(userConnection);
			string schemaName = GetSchemaNameByTemplateId(templateId);
			string reportName = GetTemplateNameByUId(templateId);
			byte[] data = GetTemplateSource(templateId);
			Collection<string> captions = openXmlUtility.GetMergeFieldName(data);
			Dictionary<string, DataValue> dic = GetEntityValuesByColumnName(recordUId, schemaName, captions, templateId);
			byte[] byteArray = openXmlUtility.GetWordReport(data, dic);
			AdditionalMacrosUtility additionalMacrosUtility = new AdditionalMacrosUtility(userConnection);
			byte[] reportBytes = additionalMacrosUtility.FillAdditionalMacros(byteArray, recordUId, schemaName, templateId);	
			var fileId = Guid.Empty;
			if ((bool)BPMSoft.Core.Configuration.SysSettings.GetValue(userConnection, "SaveWordReportAsRecordAttachment")) {
				 fileId = SaveReportToFile(reportBytes, schemaName, recordUId, reportName);
			} else {
				var response = System.Web.HttpContext.Current.Response;
				TSConfiguration.PageResponse.Write(response, reportBytes, 
					string.Format("{0}.docx", reportName), TSConfiguration.ContentType.XmlType);
			}
			return fileId;
		}

		#endregion

	}

	#endregion

	#region OpenXmlUtility

	public class OpenXmlUtility
	{

		#region Constructors: Public

		public OpenXmlUtility(UserConnection userConnection)
		{ }

		#endregion

		#region Properties: Private

		private readonly Regex mergeFormat =
			new Regex(@"^[\s]*MERGEFIELD[\s]+(?<name>[\s\w\(\)\.\,\-\\\/]+){1}\\\*
			[\s]*(\\\*[\s]+(?<Format>[\w]*){1})?
			[\s]*(\\b[\s]+[""]?(?<PreText>[^\\]*){1})?
			[\s]*(\\f[\s]+[""]?(?<PostText>[^\\]*){1})?",
			RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);

		#endregion

		#region Methods: Private

		private string GetFieldName(SimpleField field) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction))
			{
				Match m = mergeFormat.Match(instruction);
				if (m.Success)
				{
					fieldname = m.Groups["name"].ToString().Trim();
				}
			}
			return fieldname;
		}

		private void ConvertFieldCodes(OpenXmlElement mainElement, bool isReplacingConvertion, Dictionary<string, DataValue> values) {
			Run[] runs = mainElement.Descendants<Run>().ToArray();
			if (runs.Length == 0) return;
			Dictionary<Run, Run[]> newfields = new Dictionary<Run, Run[]>();
			int cursor = 0;
			do {
				Run run = runs[cursor];
				if (run.HasChildren && run.Descendants<FieldChar>().Count() > 0
					&& (run.Descendants<FieldChar>().First().FieldCharType & FieldCharValues.Begin) == FieldCharValues.Begin) {
					List<Run> innerRuns = new List<Run>();
					innerRuns.Add(run);
					bool found = false;
					string instruction = null;
					RunProperties runprop = null;
					do {
						cursor++;
						run = runs[cursor];
						innerRuns.Add(run);
						if (run.HasChildren && run.Descendants<FieldCode>().Count() > 0) {
							instruction += run.GetFirstChild<FieldCode>().Text;
						}
						if (run.HasChildren && run.Descendants<FieldChar>().Count() > 0
							&& (run.Descendants<FieldChar>().First().FieldCharType & FieldCharValues.End) == FieldCharValues.End) {
							found = true;
						}
						if (run.HasChildren && run.Descendants<RunProperties>().Count() > 0) {
							runprop = run.GetFirstChild<RunProperties>();
						}
					} while (found == false && cursor < runs.Length);
					if (!found) {
						throw new Exception("Found a Begin FieldChar but no End !");
					}
					if (!string.IsNullOrEmpty(instruction)) {
						Match m = mergeFormat.Match(instruction.Replace("\"", string.Empty));
						var fieldname = string.Empty;
						if (m.Success) {
							fieldname = m.Groups["name"].ToString().Trim();
						}
						if (!isReplacingConvertion || values.ContainsKey(fieldname)) {
							Run newrun = new Run();
							if (runprop != null)
								newrun.AppendChild(runprop.CloneNode(true));
							SimpleField simplefield = new SimpleField();
							simplefield.Instruction = instruction;
							newrun.AppendChild(simplefield);
							newfields.Add(newrun, innerRuns.ToArray());
						}
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

		private void FillWordFieldsInElement(Dictionary<string, DataValue> values, OpenXmlElement element, MainDocumentPart mainDocumentPart) {
			string[] switches;
			string[] options;
			string[] formattedText;
			DataValue dataValue = null;
			var fieldsList = element.Descendants<SimpleField>().ToArray();
			foreach (var field in fieldsList) {
				string fieldname = GetFieldNameWithOptions(field, out switches, out options);
				if (string.IsNullOrEmpty(fieldname)) {
					continue;
				}
				if ((!values.TryGetValue(fieldname, out dataValue)) || (dataValue == null)) {
					continue;
				}
				formattedText = ApplyFormatting(options[0], dataValue.Data.ToString(), options[1], options[2]);
				if (!string.IsNullOrEmpty(options[1])) {
					field.Parent.InsertBeforeSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[1], field));
				}
				if (!string.IsNullOrEmpty(options[2])) {
					field.Parent.InsertAfterSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[2], field));
				}
				field.Parent.ReplaceChild<SimpleField>(GetRunElementForText(formattedText[0], field), field);
			}
			Dictionary<string, PictureData> picturesData = PictureUtility.GetPicturesData(element);
			foreach (var pictureData in picturesData) {
				if (!values.TryGetValue(pictureData.Value.FieldName, out dataValue)) {
					continue;
				}
				if (dataValue == null) {
					continue;
				}
				if (dataValue.Data == null) {
					continue;
				}
				MemoryStream imageStream = (MemoryStream)dataValue.Data;
				if (imageStream.Length == 0) {
					continue;
				}
				var imagePart = mainDocumentPart.GetPartById(pictureData.Value.PictureId);
				//Note: FeedData always close stream
				using (MemoryStream stream = new MemoryStream()) {
					imageStream.CopyTo(stream);
					imageStream.Position = 0;
					stream.Position = 0;
					imagePart.FeedData(stream);
				}
				//Mark image as already processed
				pictureData.Value.DocProperties.Name.Value = string.Empty;
			}
		}

		private string GetFieldNameWithOptions(SimpleField field, out string[] switches, out string[] options) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			switches = new string[0];
			options = new string[3];
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction)) {
				Match m = mergeFormat.Match(instruction);
				if (m.Success) {
					fieldname = m.Groups["name"].ToString().Trim();
					options[0] = m.Groups["Format"].Value.Trim();
					options[1] = m.Groups["PreText"].Value.Trim();
					options[2] = m.Groups["PostText"].Value.Trim();
					int pos = fieldname.IndexOf('#');
					if (pos > 0) {
						switches = fieldname.Substring(pos + 1).ToLower().Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
						fieldname = fieldname.Substring(0, pos);
					}
				}
			}
			return fieldname;
		}
	
		private string[] ApplyFormatting(string format, string fieldValue, string preText, string postText) {
			string[] valuesToReturn = new string[3];
			if ("UPPER".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToUpper(CultureInfo.CurrentCulture);
			} else if ("LOWER".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToLower(CultureInfo.CurrentCulture);
			} else if ("FirstCap".Equals(format)) {
				if (!string.IsNullOrEmpty(fieldValue)) {
					valuesToReturn[0] = fieldValue.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
					if (fieldValue.Length > 1) {
						valuesToReturn[0] = valuesToReturn[0] + fieldValue.Substring(1).ToLower(CultureInfo.CurrentCulture);
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

		private Paragraph GetPreOrPostParagraphToInsert(string text, SimpleField fieldToMimic) {
			Run runToInsert = GetRunElementForText(text, fieldToMimic);
			Paragraph paragraphToInsert = new Paragraph();
			paragraphToInsert.Append(runToInsert);
			return paragraphToInsert;
		}

		private Run GetRunElementForText(string text, SimpleField placeHolder) {
			string rpr = null;
			if (placeHolder != null) {
				foreach (RunProperties placeholderrpr in placeHolder.Descendants<RunProperties>()) {
					rpr = placeholderrpr.OuterXml;
					break;  // break at first
				}
			}
			Run r = new Run();
			if (!string.IsNullOrEmpty(rpr)) {
				r.Append(new RunProperties(rpr));
			}
			if (!string.IsNullOrEmpty(text)) {
				string[] split = text.Split(new string[] { "\n" }, StringSplitOptions.None);
				bool first = true;
				foreach (string s in split) {
					if (!first) {
						r.Append(new Break());
					}
					first = false;
					bool firsttab = true;
					string[] tabsplit = s.Split(new string[] { "\t" }, StringSplitOptions.None);
					foreach (string tabtext in tabsplit) {
						if (!firsttab) {
							r.Append(new TabChar());
						}

						r.Append(new Text(tabtext));
						firsttab = false;
					}
				}
			}

			return r;
		}

		private string ToTitleCase(string toConvert) {
			return ToTitleCaseHelper(toConvert, string.Empty);
		}

		private string ToTitleCaseHelper(string toConvert, string alreadyConverted) {
			if (string.IsNullOrEmpty(toConvert)) {
				return alreadyConverted;
			} else {
				int indexOfFirstSpace = toConvert.IndexOf(' ');
				string firstWord, restOfString;

				if (indexOfFirstSpace != -1) {
					firstWord = toConvert.Substring(0, indexOfFirstSpace);
					restOfString = toConvert.Substring(indexOfFirstSpace).Trim();
				} else {
					firstWord = toConvert.Substring(0);
					restOfString = string.Empty;
				}

				StringBuilder sb = new StringBuilder();

				sb.Append(alreadyConverted);
				sb.Append(" ");
				sb.Append(firstWord.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture));

				if (firstWord.Length > 1) {
					sb.Append(firstWord.Substring(1).ToLower(CultureInfo.CurrentCulture));
				}

				return ToTitleCaseHelper(restOfString, sb.ToString());
			}
		}
		#endregion
		
		#region Methods: Internal
		
		internal Collection<string> GetMergeFieldName(byte[] data) {
			Collection<string> dic = new Collection<string>();
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
								
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					ConvertFieldCodes(docx.MainDocumentPart.Document, false, new Dictionary<string, DataValue>());
					foreach (var field in docx.MainDocumentPart.Document.Descendants<SimpleField>()) {
						string fieldname = GetFieldName(field);
						if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
							dic.Add(fieldname);
						}
					}
					foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
						ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
						foreach (var field in fpart.Footer.Descendants<SimpleField>()) {
							string fieldname = GetFieldName(field);
							if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
								dic.Add(fieldname);
							}
						}
					}
					foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
						ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
						foreach (var field in hpart.Header.Descendants<SimpleField>()) {
							string fieldname = GetFieldName(field);
							if (!string.IsNullOrEmpty(fieldname) && !dic.Contains(fieldname)) {
								dic.Add(fieldname);
							}
						}
					}
					Dictionary<string, PictureData> picturesData = 
						PictureUtility.GetPicturesData(docx.MainDocumentPart.Document);
					foreach (var pictureData in picturesData) {
						if (!dic.Contains(pictureData.Value.FieldName)) {
							dic.Add(pictureData.Value.FieldName);
						}
					}
				}
			}
			return dic;
		}

		internal byte[] GetWordReport(byte[] data, Dictionary<string, DataValue> values) {
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					ConvertFieldCodes(docx.MainDocumentPart.Document, true, values);
					FillWordFieldsInElement(values, docx.MainDocumentPart.Document, docx.MainDocumentPart);
					docx.MainDocumentPart.Document.Save();  
					foreach (HeaderPart hpart in docx.MainDocumentPart.HeaderParts) {
						ConvertFieldCodes(hpart.Header, false, new Dictionary<string, DataValue>());
						FillWordFieldsInElement(values, hpart.Header, docx.MainDocumentPart);
						hpart.Header.Save(); 
					}
					foreach (FooterPart fpart in docx.MainDocumentPart.FooterParts) {
						ConvertFieldCodes(fpart.Footer, false, new Dictionary<string, DataValue>());
						FillWordFieldsInElement(values, fpart.Footer, docx.MainDocumentPart);
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

	#region AdditionalMacrosUtility

	public class AdditionalMacrosUtility
	{

		#region Constructors: Public

		public AdditionalMacrosUtility(UserConnection userConnection){
			this.userConnection	= userConnection;
		}

		#endregion

		#region Properties: Private

		UserConnection userConnection;
		Dictionary<string, string> columnsName = new Dictionary<string, string>();
		List<string> macrosColumnsCaptions = new List<string>();
		readonly Regex mergeFormat =
			new Regex(@"^[\s]*MERGEFIELD[\s]+(?<name>[\s\w\(\)\.\,\-\d\\\/]+){1}\\\*
			[\s]*(\\\*[\s]+(?<Format>[\w]*){1})?
			[\s]*(\\b[\s]+[""]?(?<PreText>[^\\]*){1})?
			[\s]*(\\f[\s]+[""]?(?<PostText>[^\\]*){1})?",
			RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);

		#endregion

		#region Methods: Private

		private byte[] FillTableFieldsOutsideTables(byte[] data, Guid recordId, EntityCollection additionalMacroses) {
			OpenXmlUtility openXmlUtility = new OpenXmlUtility(userConnection);
			var dic = openXmlUtility.GetMergeFieldName(data);
			var dics = new Dictionary<string, DataValue>();
			foreach (var macrosCaption in dic){
				string[] macrosCaptionParts = macrosCaption.Split(new char[] {'.'});
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
				Guid schemaUId = Guid.Empty;
				Entity additionalMacros = null;
				var referenceColumnCaption = string.Empty;
				foreach (var macros in additionalMacroses) {
					var columns = Json.Deserialize(macros.GetTypedColumnValue<string>("MacrosList")) as JArray;
					foreach (var column in columns) {
						if (macros.GetTypedColumnValue<string>("Caption") == macrocDetailCaption
							&& column.Value<string>("caption") == macrosColumnCaption)  {
							if (schemaUId == Guid.Empty) {
								schemaUId = macros.GetTypedColumnValue<Guid>("ObjectId");
								additionalMacros = macros;
							}
							referenceColumnCaption = macros.GetTypedColumnValue<string>("ReferenceColumn");
						}
					}
				}
				if (schemaUId == Guid.Empty) {
					continue;
				}
				EntityCollection entityCollection = GetEntityValuesByColumnName(recordId, schemaUId, new List<string>() {macrosColumnCaption}, new List<string>() {string.Empty},
					FindByCaption(userConnection.EntitySchemaManager.FindInstanceByUId(schemaUId), referenceColumnCaption).Name, additionalMacros); 
				if(entityCollection == null || entityCollection.Count == 0){
					dics.Add(macrosCaption, null);
				} else {
					dics.Add(macrosCaption, GetColumnValue(entityCollection[0], columnsName.First().Value));
				}
			}
			data = openXmlUtility.GetWordReport(data, dics);
			return data;
		}

		private EntityCollection GetEntityValuesByColumnName(Guid entityId, Guid objectId, List<string> captions, List<string> sortDirections, string referenceColumnName, Entity additionalMacros) {	
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByUId(objectId); 
			var ESQ = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			string macroslist = Json.Deserialize(additionalMacros.GetTypedColumnValue<string>("MacrosList")).ToString();
			if (string.IsNullOrEmpty(macroslist)) {
				return null;
			}
			var macrosList = Json.Deserialize(macroslist) as JArray;
			columnsName = new Dictionary<string, string>();
			int orderPosition = 1;
			for(int index = 0; index < captions.Count; index++) {
				AddColumnToEntitySchemaQuery(ESQ, captions[index], sortDirections[index], orderPosition, macrosList);
				if (!string.IsNullOrEmpty(sortDirections[index])) {
					orderPosition++;
				}
			}
			ESQ.Filters.Add(
			ESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				referenceColumnName, entityId));
			var data = additionalMacros.GetBytesValue("Filter");
			if (data != null) {
				string filters = UTF8Encoding.UTF8.GetString(data, 0, data.Length);
				if (!String.IsNullOrEmpty(filters)) {
					var jsonConverter = new DataSourceFiltersJsonConverter(userConnection, entitySchema)
						{ PreventRegisteringClientScript = true };
					var filterCollection = Json.Deserialize(filters, typeof(DataSourceFilterCollection), 
						new List<JsonConverter> { jsonConverter }) as DataSourceFilterCollection;
					if (filterCollection != null) {
						ESQ.Filters.Add(filterCollection.ToEntitySchemaQueryFilterCollection(ESQ));
					}
				}
			}
			return ESQ.GetEntityCollection(userConnection);
		}

		private void AddColumnToEntitySchemaQuery(EntitySchemaQuery query, string caption, string sortDirection, int orderPosition, JArray columns) {
			JObject column = null;
			var macrosColumn = string.Empty;
			for (int i = 0; i < columns.Count; i++) {
				var captionColumn = columns[i].Value<string>("caption");
				if (captionColumn.Contains(@"\")) {
					for (int j = 0; j < captionColumn.Length; j++) {
						if (captionColumn[j] == '\\') {
							captionColumn = captionColumn.Insert(j, @"\");
							j++;
						}
					}
				}
				if (captionColumn == caption) {
					column = columns[i] as JObject;
					macrosColumn = captionColumn;
					break;
				}
			}
			if (column == null) {
				return;
			}
			EntitySchemaQueryColumn queryColumn = null;
			foreach (var esqColumn in query.Columns) {
				if (esqColumn.Caption.Value == column.Value<string>("caption")) {
					queryColumn = esqColumn;
				}
			}
			if (queryColumn == null) {
				if (string.IsNullOrEmpty(column.Value<string>("aggregationType"))
					|| string.Compare(column.Value<string>("aggregationType"), "None", true) == 0) {
					queryColumn = query.AddColumn(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
					if (queryColumn.DisplayExpression != null) {
						string displayValueMetaPath = queryColumn.DisplayExpression.Path;
						query.RemoveColumn(queryColumn.Name);
						queryColumn = query.AddColumn(displayValueMetaPath);
					}
				} else {
					EntitySchemaQuery subQuery = null;
					queryColumn = query.AddColumn(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")), 
						(AggregationTypeStrict)Enum.Parse(typeof(AggregationTypeStrict), column.Value<string>("aggregationType")),
						out subQuery);
					if (!string.IsNullOrEmpty(column.Value<string>("subFilters"))) {
						var converter = new DataSourceFiltersJsonConverter(userConnection,
							subQuery.RootSchema) {
								PreventRegisteringClientScript = true
							};
						var filters = JsonConvert.DeserializeObject<DataSourceFilterCollection>(
								column.Value<string>("subFilters"), converter);
						EntitySchemaQueryFilterCollection esqFilters =
							filters.ToEntitySchemaQueryFilterCollection(subQuery);
						DisableEmptyEntitySchemaQueryFilters(esqFilters);
						subQuery.Filters.Add(esqFilters);
					}
					queryColumn.Name = StringUtilities.CleanUpColumnName(query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
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
			}
			queryColumn.IsAlwaysSelect = true;
			queryColumn.IsVisible = true;
			if (!columnsName.ContainsKey(macrosColumn)) {
				columnsName.Add(macrosColumn, queryColumn.Name);
			}
		}

		private void FillWordFieldsInElement(Dictionary<string, DataValue> values, OpenXmlElement element, MainDocumentPart mainDocumentPart) {
			string[] switches;
			string[] options;
			string[] formattedText;
			DataValue dataValue = null;
			var fieldsList = element.Descendants<SimpleField>().ToArray();
			foreach (var field in fieldsList) {
				string fieldname = GetFieldNameWithOptions(field, out switches, out options);
				if (string.IsNullOrEmpty(fieldname)) {
					continue;
				}
				if ((!values.TryGetValue(fieldname, out dataValue)) || (dataValue == null)) {
					continue;
				}
				formattedText = ApplyFormatting(options[0], dataValue.Data.ToString(), options[1], options[2]);
				if (!string.IsNullOrEmpty(options[1])) {
					field.Parent.InsertBeforeSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[1], field));
				}
				if (!string.IsNullOrEmpty(options[2])) {
					field.Parent.InsertAfterSelf<Paragraph>(GetPreOrPostParagraphToInsert(formattedText[2], field));
				}
				field.Parent.ReplaceChild<SimpleField>(GetRunElementForText(formattedText[0], field), field);
			}
			Dictionary<string, PictureData> picturesData = PictureUtility.GetPicturesData(element);
			foreach (var pictureData in picturesData) {
				if (!values.TryGetValue(pictureData.Value.FieldName, out dataValue)) {
					continue;
				}
				if (dataValue == null) {
					continue;
				}
				if (dataValue.Data == null) {
					continue;
				}
				MemoryStream imageStream = (MemoryStream)dataValue.Data;
				if (imageStream.Length == 0) {
					continue;
				}
				var imagePart = mainDocumentPart.GetPartById(pictureData.Value.PictureId);
				//Note: FeedData always close stream
				using (MemoryStream stream = new MemoryStream()) {
					imageStream.CopyTo(stream);
					imageStream.Position = 0;
					stream.Position = 0;
					imagePart.FeedData(stream);
				}
				//Mark image as already processed
				pictureData.Value.DocProperties.Name.Value = string.Empty;
			}
		}

		private Run GetRunElementForText(string text, SimpleField placeHolder) {
			string rpr = null;
			if (placeHolder != null) {
				foreach (RunProperties placeholderrpr in placeHolder.Descendants<RunProperties>()) {
					rpr = placeholderrpr.OuterXml;
					break;  
				}
			}
			Run r = new Run();
			if (!string.IsNullOrEmpty(rpr)) {
				r.Append(new RunProperties(rpr));
			}
			if (!string.IsNullOrEmpty(text)) {
				string[] split = text.Split(new string[] { "\n" }, StringSplitOptions.None);
				bool first = true;
				foreach (string s in split) {
					if (!first) {
						r.Append(new Break());
					}
					first = false;
					bool firsttab = true;
					string[] tabsplit = s.Split(new string[] { "\t" }, StringSplitOptions.None);
					foreach (string tabtext in tabsplit) {
						if (!firsttab) {
							r.Append(new TabChar());
						}
						r.Append(new Text(tabtext));
						firsttab = false;
					}
				}
			}
			return r;
		}

	  private void GetAdditionalMacrosesData(EntityCollection additionalMacroses, string[] macrosCaptionParts, 
			ref Guid schemaUId, ref List<string>captions, ref List<string>sortDirections, 
			ref string macrosDetailCaption, ref string referenceColumnCaption, ref Entity additionalMacros) {
			if (macrosCaptionParts.Length < 2) {
				return;
			}
			macrosDetailCaption = macrosCaptionParts[0];
			string macrosColumnCaption = string.Empty;
			for (int i = 1; i < macrosCaptionParts.Length; i++) {
				macrosColumnCaption += macrosCaptionParts[i];
				if (i != macrosCaptionParts.Length - 1) {
					macrosColumnCaption += ".";
				}
			}
			foreach (var macros in additionalMacroses) {
				var columns = Json.Deserialize(macros.GetTypedColumnValue<string>("MacrosList")) as JArray;
				foreach (var column in columns) {
					if (macros.GetTypedColumnValue<string>("Caption") == macrosDetailCaption
						&& column.Value<string>("caption") == macrosColumnCaption) {
						captions.Add(macrosColumnCaption);
						sortDirections.Add(column.Value<string>("sort"));
						if (schemaUId == Guid.Empty) {
							schemaUId = macros.GetTypedColumnValue<Guid>("ObjectId");
							referenceColumnCaption = macros.GetTypedColumnValue<string>("ReferenceColumn");
							additionalMacros = macros;
						}
						referenceColumnCaption = macros.GetTypedColumnValue<string>("ReferenceColumn");
					}
				}
			}
		}

	private void ConvertFieldCodes(OpenXmlElement mainElement) {
			Run[] runs = mainElement.Descendants<Run>().ToArray();
			if (runs.Length == 0) return;
			Dictionary<Run, Run[]> newfields = new Dictionary<Run, Run[]>();
			int cursor = 0;
			do {
				Run run = runs[cursor];
				var row = GetFirstParent<TableRow>(run);
				if (run.HasChildren && run.Descendants<FieldChar>().Count() > 0
					&& (run.Descendants<FieldChar>().First().FieldCharType & FieldCharValues.Begin) == FieldCharValues.Begin) {
					List<Run> innerRuns = new List<Run>();
					innerRuns.Add(run);
					bool found = false;
					string instruction = null;
					RunProperties runprop = null;
					do {
						cursor++;
						run = runs[cursor];
						innerRuns.Add(run);
						if (run.HasChildren && run.Descendants<FieldCode>().Count() > 0) {
							instruction += run.GetFirstChild<FieldCode>().Text;
						}
						if (run.HasChildren && run.Descendants<FieldChar>().Count() > 0
							&& (run.Descendants<FieldChar>().First().FieldCharType & FieldCharValues.End) == FieldCharValues.End) {
							found = true;
						}
						if (run.HasChildren && run.Descendants<RunProperties>().Count() > 0) {
							runprop = run.GetFirstChild<RunProperties>();
						}
					} while (found == false && cursor < runs.Length);
					if (!found) {
						throw new Exception("Found a Begin FieldChar but no End !");
					}
					if (!string.IsNullOrEmpty(instruction)) {
						Match m = mergeFormat.Match(instruction.Replace("\"", string.Empty));
						var fieldname = string.Empty;
						if (m.Success) {
							fieldname = m.Groups["name"].ToString().Trim();
						}
						if (macrosColumnsCaptions.Contains(fieldname) && row != null) {
							Run newrun = new Run();
							if (runprop != null)
								newrun.AppendChild(runprop.CloneNode(true));
							SimpleField simplefield = new SimpleField();
							simplefield.Instruction = instruction;
							newrun.AppendChild(simplefield);
							newfields.Add(newrun, innerRuns.ToArray());
						}
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

		private string GetFieldName(SimpleField field) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction))
			{
				Match m = mergeFormat.Match(instruction);
				if (m.Success)
				{
					fieldname = m.Groups["name"].ToString().Trim();
				}
			}
			return fieldname;
		}

		private T GetFirstParent<T>(OpenXmlElement element) where T : OpenXmlElement {
			if (element.Parent == null) {
				return null;
			}
			else if (element.Parent.GetType() == typeof(T)) {
				return element.Parent as T;
			} else {
				return GetFirstParent<T>(element.Parent);
			}
		}

		private EntityCollection GetAllAdditionalMacros(Guid templateId) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var additionalMacrosES = entitySchemaManager.GetInstanceByName("SysModuleReportTable"); 
			var additionalMacrosESQ = new EntitySchemaQuery(entitySchemaManager, additionalMacrosES.Name);
			additionalMacrosESQ.AddColumn("MacrosList");
			additionalMacrosESQ.AddColumn("Object");
			additionalMacrosESQ.AddColumn("ReferenceColumn");
			additionalMacrosESQ.AddColumn("Caption");
			additionalMacrosESQ.AddColumn("Filter");
			additionalMacrosESQ.Filters.Add(
			additionalMacrosESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"SysModuleReport",templateId));
			return additionalMacrosESQ.GetEntityCollection(userConnection);
		}

		private DataValue GetColumnValue(Entity entity, string columnName) {
			var column = entity.Schema.Columns.GetByName(columnName);
			object value = null;
			if ((column.DataValueType is BinaryDataValueType) || 
				(column.DataValueType is ImageDataValueType)) {
				value = entity.GetStreamValue(column.Name);
			} else {
				string stringValue = entity.GetTypedColumnValue<string>(column);
				if (column.DataValueType is DateDataValueType) {
					if (!string.IsNullOrEmpty(stringValue)) {
						DateTime date = DateTime.Parse(stringValue);
						stringValue = date.ToString("d", userConnection.CurrentUser.Culture);
					}
				}
				value = stringValue;
			}
			return new DataValue(column.DataValueType, value);
		}

		private EntitySchema FindSchemaByCaption(string caption) {
			var entitySchemaManager = userConnection.EntitySchemaManager;
			foreach (var schema in entitySchemaManager.GetItems()) {
				if (schema.Caption.Value == caption) {
					return entitySchemaManager.GetInstanceByName(schema.Name);
				}
			}
			return null;
		}

		private EntitySchemaColumn FindByCaption(EntitySchema schema, string caption) {
			foreach (var item in schema.Columns) {
				if (item.Caption.Value.Equals(caption)) {
					return item;
				}
			}
			return null;
		}

		private string[] ApplyFormatting(string format, string fieldValue, string preText, string postText) {
			string[] valuesToReturn = new string[3];
			if ("UPPER".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToUpper(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToUpper(CultureInfo.CurrentCulture);
			} else if ("LOWER".Equals(format)) {
				valuesToReturn[0] = fieldValue.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[1] = preText.ToLower(CultureInfo.CurrentCulture);
				valuesToReturn[2] = postText.ToLower(CultureInfo.CurrentCulture);
			} else if ("FirstCap".Equals(format)) {
				if (!string.IsNullOrEmpty(fieldValue)) {
					valuesToReturn[0] = fieldValue.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture);
					if (fieldValue.Length > 1) {
						valuesToReturn[0] = valuesToReturn[0] + fieldValue.Substring(1).ToLower(CultureInfo.CurrentCulture);
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

		private Paragraph GetPreOrPostParagraphToInsert(string text, SimpleField fieldToMimic) {
			Run runToInsert = GetRunElementForText(text, fieldToMimic);
			Paragraph paragraphToInsert = new Paragraph();
			paragraphToInsert.Append(runToInsert);
			return paragraphToInsert;
		}

		private string GetFieldNameWithOptions(SimpleField field, out string[] switches, out string[] options) {
			var a = field.GetAttribute("instr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			switches = new string[0];
			options = new string[3];
			string fieldname = string.Empty;
			string instruction = a.Value.Replace("\"", string.Empty);
			if (!string.IsNullOrEmpty(instruction)) {
				Match m = mergeFormat.Match(instruction);
				if (m.Success) {
					fieldname = m.Groups["name"].ToString().Trim();
					options[0] = m.Groups["Format"].Value.Trim();
					options[1] = m.Groups["PreText"].Value.Trim();
					options[2] = m.Groups["PostText"].Value.Trim();
					int pos = fieldname.IndexOf('#');
					if (pos > 0) {
						switches = fieldname.Substring(pos + 1).ToLower().Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
						fieldname = fieldname.Substring(0, pos);
					}
				}
			}
			return fieldname;
		}

		private  string ToTitleCase(string toConvert) {
			return ToTitleCaseHelper(toConvert, string.Empty);
		}

		private  string ToTitleCaseHelper(string toConvert, string alreadyConverted) {
			if (string.IsNullOrEmpty(toConvert)) {
				return alreadyConverted;
			} else {
				int indexOfFirstSpace = toConvert.IndexOf(' ');
				string firstWord, restOfString;
				if (indexOfFirstSpace != -1) {
					firstWord = toConvert.Substring(0, indexOfFirstSpace);
					restOfString = toConvert.Substring(indexOfFirstSpace).Trim();
				} else {
					firstWord = toConvert.Substring(0);
					restOfString = string.Empty;
				}
				StringBuilder sb = new StringBuilder();
				sb.Append(alreadyConverted);
				sb.Append(" ");
				sb.Append(firstWord.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture));
				if (firstWord.Length > 1) {
					sb.Append(firstWord.Substring(1).ToLower(CultureInfo.CurrentCulture));
				}
				return ToTitleCaseHelper(restOfString, sb.ToString());
			}
		}

		private string GetMacrosListByObjectId(Guid objectId, EntityCollection additionalMacroses) {
			foreach (var macros in additionalMacroses) {
				if (macros.GetTypedColumnValue<Guid>("ObjectId") == objectId) {
					return Json.Deserialize(macros.GetTypedColumnValue<string>("MacrosList")).ToString();
				}
				
			}
			return string.Empty;
		}

		private static void DisableEmptyEntitySchemaQueryFilters(
				IEnumerable<IEntitySchemaQueryFilterItem> queryFilterCollection) {
			foreach (var item in queryFilterCollection) {
				var filter = item as EntitySchemaQueryFilter;
				if (filter != null) {
					if (filter.RightExpressions.Count == 0 && filter.ComparisonType != FilterComparisonType.IsNull &&
							filter.ComparisonType != FilterComparisonType.IsNotNull) {
						filter.IsEnabled = false;
						continue;
					}
					if (filter.LeftExpression != null &&
							filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
						DisableEmptyEntitySchemaQueryFilters(filter.LeftExpression.SubQuery.Filters);
					}
					foreach (var rightExpression in filter.RightExpressions) {
						if (rightExpression.ExpressionType == EntitySchemaQueryExpressionType.SubQuery) {
							DisableEmptyEntitySchemaQueryFilters(rightExpression.SubQuery.Filters);
						}
					}
				} else {
					DisableEmptyEntitySchemaQueryFilters((EntitySchemaQueryFilterCollection)item);
				}
			}
		}

		private void ClonePicture(MainDocumentPart mainDocumentPart, OpenXmlPictures.Picture picture) {
			string mediaId = picture.BlipFill.Blip.Embed.Value;
			int picturesCount = mainDocumentPart.GetPartsOfType<ImagePart>().Count();
			ImagePart mediaPart = (ImagePart)mainDocumentPart.GetPartById(mediaId);
			Stream mediaStream = mediaPart.GetStream();
			mediaStream.Position = 0;
			ImagePart newMediaPart = mainDocumentPart.AddImagePart(mediaPart.ContentType);
			newMediaPart.FeedData(mediaStream);
			string newMediaPartId = mainDocumentPart.GetIdOfPart(newMediaPart);
			string newImageId = (picturesCount + 1).ToString();
			OpenXmlDrawingProcessing.DocProperties docProperties = PictureUtility.GetPictureDocProperties(picture);
			docProperties.Id.InnerText = newImageId;
			picture.BlipFill.Blip.Embed.Value = newMediaPartId;
			picture.NonVisualPictureProperties.NonVisualDrawingProperties.Id.InnerText = newImageId;
		}

		private void RemovePicture(MainDocumentPart mainDocumentPart, OpenXmlPictures.Picture picture) {
			string mediaId = picture.BlipFill.Blip.Embed.Value;
			try {
				mainDocumentPart.DeletePart(mediaId);
			} catch(ArgumentOutOfRangeException) {
				//Do nothing
			}
			if (picture.Parent != null) {
				picture.Parent.RemoveChild(picture);
			}
		}

		#endregion

		#region Methods: Internal

		internal byte[] FillAdditionalMacros(byte[] data, Guid recordId, string schemaName, Guid templateId) {
			EntityCollection additionalMacroses = GetAllAdditionalMacros(templateId);
			if (additionalMacroses.Count == 0) {
				return data;
			}
			foreach (var macros in additionalMacroses) {
				var columns = Json.Deserialize(macros.GetTypedColumnValue<string>("MacrosList")) as JArray;
				foreach (var column in columns) {
					macrosColumnsCaptions.Add(string.Format("{0}.{1}", macros.GetTypedColumnValue<string>("Caption"), column.Value<string>("caption")));
				}
			}
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(data, 0, data.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					ConvertFieldCodes(docx.MainDocumentPart.Document);
					List<OpenXmlPictures.Picture> unusedPictures = new List<OpenXmlPictures.Picture>();
					foreach (var table in docx.MainDocumentPart.Document.Descendants<Table>()) {
						if ((table.Descendants<SimpleField>().Count() == 0) && table.Descendants<OpenXmlPictures.Picture>().Count() == 0) {
							continue;
						}
						TableRow macrosRow = null;
						var rows = table.ChildElements.OfType<TableRow>().ToArray();
						var rowsCount = rows.Count();
						var captions = new List<string>();
						var sortDirections = new List<string>();
						Guid schemaUId = Guid.Empty;
						string macrosDetailCaption = string.Empty;
						string referenceColumnCaption = string.Empty;
						Entity additionalMacros = null;
						for (int i = 0; i < rowsCount; i++) {
							macrosRow = rows[i];

							#region SimpleFields
							foreach (var simpleField in rows[i].Descendants<SimpleField>()) {
								string macrosCaption = GetFieldName(simpleField);
								string[] macrosCaptionParts = macrosCaption.Split(new char[] {'.'});
								GetAdditionalMacrosesData(additionalMacroses, macrosCaptionParts, ref schemaUId, ref captions, 
									ref sortDirections, ref macrosDetailCaption, ref referenceColumnCaption, ref additionalMacros);
							}
							#endregion

							#region PictureFields
							foreach (var pictureField in rows[i].Descendants<OpenXmlPictures.Picture>()) {
								var field = rows[i].Descendants<OpenXmlDrawingProcessing.DocProperties>()
									.Where(picture => picture.Id.InnerText == 
										PictureUtility.GetPictureDocProperties(pictureField).Id.InnerText)
									.Select(prop => new {
										macrosCaption = prop.Name.Value
									}).FirstOrDefault();
								string[] macrosCaptionParts = field.macrosCaption.Split(new char[] { '.' });
								GetAdditionalMacrosesData(additionalMacroses, macrosCaptionParts, ref schemaUId, ref captions, 
									ref sortDirections, ref macrosDetailCaption, ref referenceColumnCaption, ref additionalMacros);
							}
							#endregion

						}
						if (schemaUId == Guid.Empty) {
							continue;
						}
						EntityCollection entityCollection = GetEntityValuesByColumnName(recordId, schemaUId, captions, sortDirections,
							FindByCaption(userConnection.EntitySchemaManager.FindInstanceByUId(schemaUId), referenceColumnCaption).Name, additionalMacros); 
						if(entityCollection == null){
							return data;
						}
						for (int i = 0; i < entityCollection.Count; i++) {
							TableRow tableRow = macrosRow.Clone() as TableRow;
							Dictionary<string, DataValue> values = new Dictionary<string, DataValue>();
							foreach (var columnName in columnsName) {
								values.Add(string.Concat(macrosDetailCaption, ".", columnName.Key), GetColumnValue(entityCollection[i], columnName.Value));
							}
							foreach (OpenXmlPictures.Picture picture in tableRow.Descendants<OpenXmlPictures.Picture>()) {
								ClonePicture(docx.MainDocumentPart, picture);
							}
							FillWordFieldsInElement(values, tableRow, docx.MainDocumentPart);
							table.InsertBefore<TableRow>(tableRow, macrosRow);
						}
						//Collect unused resources
						foreach (OpenXmlPictures.Picture picture in macrosRow.Descendants<OpenXmlPictures.Picture>()) {
							//Find all pictures with same resource
							var mediaId = picture.BlipFill.Blip.Embed.Value;
							var pictures = docx.MainDocumentPart.Document.Descendants<OpenXmlPictures.Picture>()
								.Where(pic => pic.BlipFill.Blip.Embed.Value == mediaId)
								.ToList();
							if (pictures.Count == 1) {
								unusedPictures.Add(picture);
							}
						}
						table.RemoveChild<TableRow>(macrosRow);
					}
					foreach(OpenXmlPictures.Picture picture in unusedPictures) {
						RemovePicture(docx.MainDocumentPart, picture);
					}
					unusedPictures.Clear();
					docx.MainDocumentPart.Document.Save();
					docx.Close();
					return FillTableFieldsOutsideTables(stream.ToArray(), recordId, additionalMacroses);
				}
			}
		}

		#endregion

	}

	#endregion
}

