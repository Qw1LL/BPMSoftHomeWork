namespace BPMSoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Configuration.ProcessDesigner;
	using BPMSoft.Configuration.Utils;
	using BPMSoft.Core.Entities;

	#region Class: ProcessEmailUserTaskMacrosHelper

	public class ProcessEmailUserTaskMacrosHelper : BaseEmailUserTaskMacrosHelper
	{

		#region Constructors: Public

		public ProcessEmailUserTaskMacrosHelper(EmailTemplateUserTask userTask)
			: base(userTask) {
		}

		#endregion

		#region Methods: Private

		private static List<string> GetMacrosesFromBody(string body) {
			const string pattern = "((?:<img(?:[^>]+?)data-value=\"))((?:.*?))((?:\".*?\\/*>))";
			return (from Match match in Regex.Matches(body, pattern)
					select match.Value).ToList();
		}

		#endregion

		#region Methods: Protected

		protected override Guid GetMacrosWorkerId() {
			return new Guid("BD01ED85-6946-4E20-89A4-E18B1F415BA6");
		}

		protected override MacrosInfo CreateMacrosInfo(string macros) {
			MacrosInfo macrosInfo = base.CreateMacrosInfo(macros);
			macrosInfo.Id = GetMacrosWorkerId();
			return macrosInfo;
		}

		protected override string ReplaceMacros(string template, Dictionary<string, string> macrosValues) {
			string result = template;
			foreach (KeyValuePair<string, string> item in macrosValues) {
				result = result.Replace(item.Key, item.Value);
			}
			return result;
		}

		protected override List<string> GetMacrosCollectionFromSourceText(string sourceText) {
			return GetMacrosesFromBody(sourceText);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns arguments for macros values
		/// </summary>
		/// <param name="entityName">Entity name which used to get arguments.</param>
		/// <param name="recordId">Record which used to get arguments.</param>
		/// <param name="macrosInfos">Macros storage.</param>
		/// <returns>Arguments.</returns>
		public override Dictionary<Guid, object> GetMacrosArguments(string entityName, Guid recordId,
				List<MacrosInfo> macrosInfos) {


			Dictionary<Guid, object> arguments = base.GetMacrosArguments(entityName, recordId, macrosInfos);
			arguments.Add(GetMacrosWorkerId(), UserTask);
			return arguments;
		}

		#endregion

	}

	#endregion

	#region Class: ProcessEmailUserTaskMacrosWorker

	[MacrosWorker("{BD01ED85-6946-4E20-89A4-E18B1F415BA6}")]
	public class ProcessEmailUserTaskMacrosWorker : IMacrosWorker
	{
		#region Constants: Private

		private const string GuidPattern = "[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}";

		#endregion

		#region Fields: Private

		private readonly string _parameterPattern = $"((?<=Parameter:{{){GuidPattern})";
		private readonly string _elementPattern = $"((?<=Element:{{){GuidPattern})";
		private readonly string _entityColumnPattern = $"((?<=EntityColumn:{{){GuidPattern})";

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		private static string GetMacrosValueByPattern(string pattern, string macrosText) {
			string result = null;
			Regex regex = new Regex(pattern);
			if (regex.IsMatch(macrosText)) {
				var match = regex.Match(macrosText);
				result = match.Value;
			}
			return result;
		}

		private static string GetDefaultMacrosValue(SendEmailType sendEmailType, string macros) {
			return sendEmailType == SendEmailType.Auto
				? string.Empty
				: GetHighlightedMacros(macros);
		}

		private static string ExtractImgAlt(string htmlText) {
			string pattern = @"\<img.+alt=\""([^\""]*)";
			var matches = Regex.Matches(htmlText, pattern);
			return matches.Count > 0 && matches[0].Groups.Count > 1 ? matches[0].Groups[1].Value : "";
		}

		private static string GetHighlightedMacros(string macros) {
			return String.Format("<div style=\"{0} {1}\">{2}</div>", "background-color: yellow;",
					"display: inline;",	ExtractImgAlt(macros));
		}

		private static string GetDefaultElementId(ProcessFlowElement process) {
			return (process != null && process.Owner == null && process.SchemaElementUId != null)
				? process.SchemaElementUId.ToString()
				: Guid.Empty.ToString();
		}

		private string GetEntityParameterDisplayValue(ProcessSchemaParameter parameter, object parameterValue, ProcessParameterMapInfo parameterMapInfo) {
			EntitySchemaColumn entityColumn = parameter.ReferenceSchema.GetSchemaColumnByMetaPath(parameterMapInfo.SubParameterMetaPath);
			return entityColumn.DataValueType.GetDisplayValue(parameterValue);
		}

		private string GetMacrosValue(EmailTemplateUserTask userTask, object parameterValue, string macros) {
			string columnUId = GetMacrosValueByPattern(_entityColumnPattern, macros);
			var parameterMapInfo = GetProcessParameterMapInfo(userTask.Owner, macros);
			var parameter = userTask.Owner.FindParameter(parameterMapInfo);
			string value = string.IsNullOrEmpty(columnUId) || !(parameter.DataValueType is EntityDataValueType)
				? parameter.DataValueType.GetDisplayValue(parameterValue)
				: GetEntityParameterDisplayValue(parameter, parameterValue, parameterMapInfo);
			return value;
		}

		#endregion

		#region Methods: Protected

		protected object GetParameterValue(EmailTemplateUserTask userTask, string macros) {
			// TODO rewrite using userTask.Owner.GetParameterValueByMetaPath(macros) for both cases
			var process = userTask.Owner;
			object parameterValue;
			if (userTask.CanUseFlowEngine) {
				var valueProvider = process.ParameterValueProvider;
				var parameterMapInfo = GetProcessParameterMapInfo(process, macros);
				parameterValue = valueProvider.GetParameterValue(parameterMapInfo);
			} else {
				parameterValue = process.GetParameterValueByMetaPath(macros);
			}
			return parameterValue;
		}

		protected ProcessParameterMapInfo GetProcessParameterMapInfo(Process process, string macros) {
			string elementId = GetMacrosValueByPattern(_elementPattern, macros) ?? GetDefaultElementId(process);
			Match parameterMatch = Regex.Match(macros, _parameterPattern);
			string columnUId = GetMacrosValueByPattern(_entityColumnPattern, macros);
			var parameterMapInfo = new ProcessParameterMapInfo(elementId, parameterMatch.Value);
			if (!string.IsNullOrEmpty(columnUId)) {
				parameterMapInfo.SubParameterMetaPath = columnUId;
			}
			return parameterMapInfo;
		}

		protected string GetMacrosValue(object parameterValue, string macros) {
			string columnUId = GetMacrosValueByPattern(_entityColumnPattern, macros);
			string value = string.IsNullOrEmpty(columnUId) || !(parameterValue is Entity)
				? parameterValue.ToString()
				: GetMacrosColumnValue(parameterValue, columnUId);
			return value;
		}

		protected string GetMacrosColumnValue(object macrosValue, string columnUId) {
			var value = string.Empty;
			var entity = (Entity)macrosValue;
			var column = entity.Schema.GetSchemaColumnByMetaPath(columnUId);
			var columnName = column.ColumnValueName;
			if (entity.GetIsColumnValueLoaded(columnName)) {
				value = entity.GetColumnValue(columnName).ToString();
			}
			return value;
		}

		#endregion

		#region Methods: Public

		public Dictionary<string, string> Proceed(IEnumerable<MacrosInfo> macrosInfoCollection) {
			return null;
		}

		public Dictionary<string, string> Proceed(IEnumerable<MacrosInfo> macrosInfoCollection, object arguments) {
			if (!(arguments is EmailTemplateUserTask userTask)) {
				return null;
			}
			return macrosInfoCollection
				.GroupBy(macros => macros.Alias)
				.Select(duplicateGroup => duplicateGroup.First())
				.Select(macrosInfo => {
					var macrosAlias = macrosInfo.Alias;
					var parameterValue = GetParameterValue(userTask, macrosAlias);
					string resultMacrosValue = GetDefaultMacrosValue((SendEmailType)userTask.SendEmailType, macrosAlias);
					if (parameterValue != null) {
						string handledMacrosValue = string.Empty;
						if (GlobalAppSettings.FeatureEmailMacrosParametersEvaluation) {
							handledMacrosValue = GetMacrosValue(userTask, parameterValue, macrosAlias);
						} else {
							handledMacrosValue = GetMacrosValue(parameterValue, macrosAlias);
						}
						if (!handledMacrosValue.EqualsDefaultValue<DateTime>()) {
							resultMacrosValue = handledMacrosValue;
						}
					}
					return (macrosAlias, resultMacrosValue);
				})
				.ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
		}

		public Dictionary<object, Dictionary<string, string>> ProcceedCollection(
				IEnumerable<MacrosInfo> macrosInfoCollection) {
			return null;
		}

		public Dictionary<object, Dictionary<string, string>> ProcceedCollection(
				IEnumerable<MacrosInfo> macrosInfoCollection, object arguments) {
			return null;
		}

		#endregion

	}

	#endregion

	#region Class: DefaultValueCompareUtility

	internal static class DefaultValueCompareUtility
	{
		public static bool EqualsDefaultValue<T>(this string input) where T : struct {
			try {
				var converter = TypeDescriptor.GetConverter(typeof(T));
				object convertFromString = converter.ConvertFromString(input);
				if (convertFromString == null) {
					return false;
				}
				return EqualityComparer<T>.Default.Equals((T)convertFromString, default(T));
			} catch (Exception) {
				return false;
			}
		}
	}

	#endregion

}
