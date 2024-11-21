namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: DuplicatesSettingDTO

	public class DuplicatesSettingDTO
	{

		#region Properties: Public

		public string SchemaName { get; set; }
		public bool IsActive { get; set; }
		public bool UseAtSave { get; set; }
		public string DeduplicationColumns { get; set; }

		#endregion

		#region Methods: Private

		private string JavaScriptStringEncode(string value) =>
			HttpUtility.JavaScriptStringEncode(value ?? string.Empty);

		#endregion

		#region Methods: Public

		public override string ToString() {
			var sb = new StringBuilder("{");
			sb.Append($"'SchemaName':'{JavaScriptStringEncode(SchemaName)}',");
			sb.Append($"'IsActive':{IsActive.ToString().ToLower()},");
			sb.Append($"'UseAtSave':{UseAtSave.ToString().ToLower()},");
			sb.Append($"'DeduplicationColumns':{DeduplicationColumns}}}");
			return sb.ToString();
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleDTO

	public class DuplicatesRuleDTO
	{

		#region Properties: Public

		public Guid Id { get; set; }
		public string SchemaName { get; set; }
		public string SearchSchemaName { get; set; }
		public string RuleName { get; set; }
		public bool IsActive { get; set; }
		public bool UseAtSave { get; set; }
		public DuplicatesRuleBody RuleBody { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			var duplicatesRuleDTO2 = (DuplicatesRuleDTO)obj;
			var defaultStringComparer = EqualityComparer<string>.Default;
			var result = defaultStringComparer.Equals(SchemaName, duplicatesRuleDTO2.SchemaName);
			result = result && defaultStringComparer.Equals(SearchSchemaName,
				 duplicatesRuleDTO2.SearchSchemaName);
			result = result && defaultStringComparer.Equals(RuleName, duplicatesRuleDTO2.RuleName);
			result = result && IsActive == duplicatesRuleDTO2.IsActive;
			result = result && UseAtSave == duplicatesRuleDTO2.UseAtSave;
			return RuleBody == null && duplicatesRuleDTO2.RuleBody == null
				? result
				: result && RuleBody != null && RuleBody.Equals(duplicatesRuleDTO2.RuleBody);
		}
		public override int GetHashCode() {
			unchecked {
				var hashCode = Id.GetHashCode();
				hashCode = (hashCode * 397) ^ (SchemaName != null ? SchemaName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (SearchSchemaName != null ? SearchSchemaName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (RuleName != null ? RuleName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ IsActive.GetHashCode();
				hashCode = (hashCode * 397) ^ UseAtSave.GetHashCode();
				hashCode = (hashCode * 397) ^ (RuleBody != null ? RuleBody.GetHashCode() : 0);
				return hashCode;
			}
		}

		#endregion

	}

	#endregion

}
