namespace BPMSoft.Configuration.WordReportGenerator
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.IO;
	using System.Linq;
	using DocumentFormat.OpenXml;
	using DocumentFormat.OpenXml.Packaging;
	using Newtonsoft.Json.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.ReportService;
	using BPMSoft.Configuration.SerializedEsqFilterConvertation;
	using FeatureUtilities = BPMSoft.Configuration.FeatureUtilities;

	#region Class: WordReportGenerator

	/// <summary>
	/// Provides report generating functionality.
	/// </summary>
	[DefaultBinding(typeof(IReportGenerator), Name = "Word")]
	public class WordReportGenerator : IReportGenerator
	{

		#region Class: ReportTemplateSettings

		private class ReportTemplateSettings
		{

			#region Properties: Public

			public Guid Id { get; set; }

			public string EntitySchemaName { get; set; }

			public string Caption { get; set; }

			public string MacrosSettings { get; set; }

			public byte[] TemplateData { get; set; }

			#endregion
		}

		#endregion

		#region Methods: Private

		private bool CanUse7xFilters(UserConnection userConnection) {
			return FeatureUtilities.GetIsFeatureEnabled(userConnection, "Use7xFiltersForWordReports");
		}

		private string ChooseBetweenMacrosListAndMacrosSettings(UserConnection userConnection, string macrosList, string macrosSettings) {
			if (CanUse7xFilters(userConnection)) {
				return !string.IsNullOrEmpty(macrosSettings) ? macrosSettings : macrosList;
			} else {
				return macrosList;
			}
		}

		private byte[] GetTemplateFile(UserConnection userConnection, Guid templateId) {
			var template = userConnection.EntitySchemaManager
				.GetInstanceByName("SysModuleReport")
				.CreateEntity(userConnection);
			if (!template.FetchFromDB("Id", templateId, new string[] { "File" })) {
				throw new ItemNotFoundException(templateId.ToString());
			}
			return template.GetBytesValue("File");
		}

		private ReportTemplateSettings GetReportTemplateSettings(UserConnection userConnection, Guid templateId) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysModuleReport");
			var captionColumnName = esq.AddColumn("Caption").Name;
			var macrosListColumnName = esq.AddColumn("MacrosList").Name;
			var macrosSettingsColumnName = esq.AddColumn("MacrosSettings").Name;
			var entitySchemaNameColumnName = esq.AddColumn("SysModule.SysModuleEntity.[SysSchema:UId:SysEntitySchemaUId].Name").Name;
			var entity = esq.GetEntity(userConnection, templateId);
			if (entity == null) {
				throw new ItemNotFoundException(templateId.ToString());
			}
			string macrosList = entity.GetTypedColumnValue<string>(macrosListColumnName);
			string macrosSettings = entity.GetTypedColumnValue<string>(macrosSettingsColumnName);
			return new ReportTemplateSettings {
				Id = templateId,
				Caption = entity.GetTypedColumnValue<string>(captionColumnName),
				EntitySchemaName = entity.GetTypedColumnValue<string>(entitySchemaNameColumnName),
				MacrosSettings = ChooseBetweenMacrosListAndMacrosSettings(userConnection, macrosList, macrosSettings),
				TemplateData = GetTemplateFile(userConnection, templateId)
			};
		}

		private Dictionary<string, DataValue> GetEntityValuesByColumnName(UserConnection userConnection,
				ReportTemplateSettings reportTemplateSettings, Guid recordId, Collection<string> captions) {
			Dictionary<string, string> dicEsq = new Dictionary<string, string>();
			Dictionary<string, DataValue> fillDic = new Dictionary<string, DataValue>();
			if (captions.Count == 0) {
				return fillDic;
			}
			var expressionConverterHelper = new ExpressionConverterHelper();
			Dictionary<string, ColumnMacros> dicMacros = new Dictionary<string, ColumnMacros>();
			var entitySchemaManager = userConnection.EntitySchemaManager;
			var entitySchema = entitySchemaManager.GetInstanceByName(reportTemplateSettings.EntitySchemaName);
			var esq = new EntitySchemaQuery(entitySchemaManager, entitySchema.Name);
			if (string.IsNullOrEmpty(reportTemplateSettings.MacrosSettings)) {
				return fillDic;
			}
			var macrosList = Json.Deserialize(reportTemplateSettings.MacrosSettings) as JArray;
			foreach (string item in captions) {
				var fullColumnName = item.Trim();
				var currentMacrosList = expressionConverterHelper.MacrosList(fullColumnName);
				var columnName = expressionConverterHelper.GetColumnName(fullColumnName);
				if (currentMacrosList.Count > 0 && !dicMacros.ContainsKey(fullColumnName)) {
					dicMacros.Add(fullColumnName, new ColumnMacros {
						Name = fullColumnName,
						ColumnName = columnName,
						MacrosList = currentMacrosList
					});
				}
				if (!dicEsq.ContainsKey(columnName)) {
					AddColumnToEntitySchemaQuery(userConnection, esq, columnName, macrosList, dicEsq);
				}
			}
			EntitySchemaQueryExpressionCollection selectingQueryExpressions = esq.Columns.GetSelectingExpressions();
			if (selectingQueryExpressions.Count == 0) {
				return fillDic;
			}
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", recordId));
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			if (entityCollection.Count > 0) {
				AdditionalMacrosUtility additionalMacrosUtility = new AdditionalMacrosUtility(userConnection);
				foreach (KeyValuePair<string, string> item in dicEsq) {
					Entity entity = entityCollection[0];
					EntitySchemaColumn entityColumnName = entity.Schema.Columns.GetByName(item.Value);
					object value = additionalMacrosUtility.GetReportColumnValue(entity, entityColumnName);
					fillDic.Add(item.Key, new DataValue(entityColumnName.DataValueType, value));
					if (dicMacros.Count(d => d.Value.ColumnName == item.Key) > 0) {
						foreach (var macrosItem in dicMacros.Where(d => d.Value.ColumnName == item.Key)) {
							ColumnMacros macros = macrosItem.Value;
							ExpressionConverterValue macrosValue =
								expressionConverterHelper.GetValue(macros.MacrosList, value);
							fillDic.Add(macrosItem.Key, new DataValue(macrosValue.ValueType, macrosValue.Data));
						}
					}
				}
			}
			return fillDic;
		}

		private void AddColumnToEntitySchemaQuery(UserConnection userConnection, EntitySchemaQuery query, string caption, JArray columns,
				Dictionary<string, string> dicEsq) {
			JObject column = null;
			string macrosColumn = string.Empty;
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
				if (string.IsNullOrEmpty(column.Value<string>("aggregationType"))
						|| string.Compare(column.Value<string>("aggregationType"), "None", true) == 0) {
					queryColumn = query.AddColumn(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
					if (queryColumn.DisplayExpression != null) {
						string displayValueMetaPath = queryColumn.DisplayExpression.Path;
						query.RemoveColumn(queryColumn.Name);
						queryColumn = query.AddColumn(displayValueMetaPath);
					}
				} else {
					EntitySchemaQuery subQuery;
					string queryColumnName = StringUtilities.CleanUpColumnName(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")));
					string uniqueSuffix = query.Columns.Any(x => x.Name == queryColumnName)
						? query.Columns.Count.ToString()
						: string.Empty;
					queryColumn = query.AddColumn(
						query.RootSchema.GetSchemaColumnPathByMetaPath(column.Value<string>("metaPath")),
						(AggregationTypeStrict)Enum.Parse(typeof(AggregationTypeStrict),
						column.Value<string>("aggregationType")),
						out subQuery);
					var subFiltersStr = column.Value<string>("subFilters");
					if (!string.IsNullOrEmpty(subFiltersStr)) {
						subQuery.AddSerializedFilter(userConnection, subFiltersStr);
					}
					queryColumn.Name = queryColumnName + uniqueSuffix;
				}
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
			dicEsq.Add(macrosColumn, queryColumn.Name);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Generates DevExpress report.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="configuration">Provides configuration for report generator.</param>
		/// <returns>Returns prepared report.</returns>
		public ReportData Generate(UserConnection userConnection, ReportGeneratorConfiguration configuration) {
			var templateId = configuration.ReportTemplateId;
			var recordId = configuration.RecordId;
			var reportTemplateSettings = GetReportTemplateSettings(userConnection, templateId);
			using (MemoryStream stream = new MemoryStream()) {
				stream.Write(reportTemplateSettings.TemplateData, 0, reportTemplateSettings.TemplateData.Length);
				using (WordprocessingDocument docx = WordprocessingDocument.Open(stream, true)) {
					var openXmlUtility = new OpenXmlUtility(userConnection);
					Collection<string> captions = openXmlUtility.GetMergeFieldName(docx);
					Dictionary<string, DataValue> dic = GetEntityValuesByColumnName(userConnection, reportTemplateSettings, recordId, captions);
					WordprocessingDocument report = openXmlUtility.GetWordReport(docx, dic);
					var additionalMacrosUtility = new AdditionalMacrosUtility(userConnection);
					additionalMacrosUtility.FillAdditionalMacros(report, recordId, reportTemplateSettings.EntitySchemaName, templateId);
					docx.Close();
				}
				stream.Seek(0, SeekOrigin.Begin);
				return new ReportData {
					Caption = reportTemplateSettings.Caption,
					Format = "docx",
					Data = stream.ToArray()
				};
			}
		}

		#endregion

	}

	#endregion

}

