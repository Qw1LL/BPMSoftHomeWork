namespace BPMSoft.Configuration.Deduplication
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;

	#region Class: DeduplicationConfigurationScriptBuilder

	/// <summary>
	/// Deduplication configuration script builder.
	/// </summary>
	public class DeduplicationConfigurationScriptBuilder : ICustomConfigurationScriptBuilder
	{

		#region Fields: Private

		private readonly IDuplicatesRuleRepository _duplicatesRuleRepository;

		#endregion

		#region Properties: Protected

		protected virtual HashSet<string> DeduplicationRulesExclusionSchemas => new HashSet<string> {"Lead"};

		#endregion

		#region Constructors: Public

		public DeduplicationConfigurationScriptBuilder(IDuplicatesRuleRepository duplicatesRuleRepository) =>
			_duplicatesRuleRepository = duplicatesRuleRepository;

		#endregion

		#region Methods: Private

		private string BuildDuplicateColumnSettings(IEnumerable<DuplicatesRuleDTO> rules) {
			var result = string.Empty;
			var duplicateRuleFiltersHashSet = new HashSet<DuplicatesRuleFilter>();
			foreach (var rule in rules) {
				var ruleBody = rule.RuleBody;
				if (ruleBody == null || ruleBody.Filters == null) {
					return result;
				}
				foreach (var filter in ruleBody.Filters) {
					duplicateRuleFiltersHashSet.Add(filter);
				}
			}
			return Json.Serialize(duplicateRuleFiltersHashSet);
		}

		private DuplicatesSettingDTO GetDuplicatesSettingsDTO(IEnumerable<DuplicatesRuleDTO> nonEmptyBodyRules,
					string duplicateSchemaName, bool onlyIsActive = false) {
			IEnumerable<DuplicatesRuleDTO> deduplicationBodySourceMatchedRules;
			if (onlyIsActive) {
				deduplicationBodySourceMatchedRules = nonEmptyBodyRules.Where(rule => rule.IsActive == true);
			} else {
				deduplicationBodySourceMatchedRules = DeduplicationRulesExclusionSchemas.Contains(duplicateSchemaName)
					? nonEmptyBodyRules.Where(rule => rule.IsActive == true)
					: nonEmptyBodyRules.Where(rule => rule.UseAtSave == true);
			}
				
			return new DuplicatesSettingDTO {
				SchemaName = duplicateSchemaName,
				IsActive = nonEmptyBodyRules.Any(rule => rule.IsActive == true),
				UseAtSave = nonEmptyBodyRules.Any(rule => rule.UseAtSave == true),
				DeduplicationColumns = BuildDuplicateColumnSettings(deduplicationBodySourceMatchedRules)
			};
		}

		private List<DuplicatesSettingDTO> GetDuplicatesSettings(IEnumerable<DuplicatesRuleDTO> duplicateRules, bool onlyIsActive = false) {
			var duplicateSchemaNames = duplicateRules.Select(rule => rule.SchemaName).Distinct();
			var result = new List<DuplicatesSettingDTO>();
			foreach (var duplicateSchemaName in duplicateSchemaNames) {
				var nonEmptyBodyRules = duplicateRules.Where(rule => rule.SchemaName == duplicateSchemaName 
					&& rule.RuleBody != null && (rule.SchemaName == rule.SearchSchemaName || string.IsNullOrEmpty(rule.SearchSchemaName)));
				if (nonEmptyBodyRules.Count() > 0) {
					var duplicateSettingsDTO = GetDuplicatesSettingsDTO(nonEmptyBodyRules, duplicateSchemaName, onlyIsActive);
					result.Add(duplicateSettingsDTO);
				}
			}
			return result;
		}
		
		private List<string> GetSchemaRules(List<DuplicatesSettingDTO> duplicateSettings, string schemaRulePrefix = null) {
			schemaRulePrefix = schemaRulePrefix ?? string.Empty;
			var schemasRules = new List<string>();
			var schemaNames = duplicateSettings.Select(rule => rule.SchemaName).Distinct();
			foreach (var schemaName in schemaNames) {
				var schemaSettings = duplicateSettings.FirstOrDefault(rule => rule.SchemaName == schemaName);
				var schemaRuleString = $"'{schemaRulePrefix}{schemaName}':";
				schemaRuleString += schemaSettings.ToString();
				schemasRules.Add(schemaRuleString);
			}
			return schemasRules;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="ICustomConfigurationScriptBuilder.BuildScript"/>
		public string BuildScript(UserConnection userConnection) {
			var duplicatesRules = _duplicatesRuleRepository.GetDuplicatesRules(userConnection, userConnection.SessionCache);
			var duplicateSettings = GetDuplicatesSettings(duplicatesRules);
			var activeDuplicateSettings = GetDuplicatesSettings(duplicatesRules, true);
			var stringBuilder = new StringBuilder("BPMSoft.configuration.DeduplicationSettings={");
			var schemasRules = GetSchemaRules(duplicateSettings);
			var activeSchemasRules = GetSchemaRules(activeDuplicateSettings, "ActiveRules_");
			schemasRules.AddRange(activeSchemasRules);
			stringBuilder.Append(string.Join(",", schemasRules));
			stringBuilder.Append("};");
			return stringBuilder.ToString();
		}


		#endregion

	}

	#endregion

}
