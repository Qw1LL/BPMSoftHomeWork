namespace BPMSoft.Configuration.Deduplication
{
	using Newtonsoft.Json;
	using System.Collections.Generic;

	#region Class: DuplicatesRuleBody

	[JsonObject(MemberSerialization.OptIn)]
	public class DuplicatesRuleBody
	{

		#region Properties: Public

		[JsonProperty(PropertyName = "filters")]
		public List<DuplicatesRuleFilter> Filters { get; set; }

		[JsonProperty(PropertyName = "rootSchemaName")]
		public string RootSchemaName { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			var duplicatesRuleBody2 = (DuplicatesRuleBody)obj;
			if (duplicatesRuleBody2 == null) {
				return false;
			}
			var defaultStringComparer = EqualityComparer<string>.Default;
			var result = defaultStringComparer.Equals(RootSchemaName,
				duplicatesRuleBody2.RootSchemaName);
			if (Filters == null && duplicatesRuleBody2 == null) {
				return result;
			}
			var filtersHashSet = new HashSet<DuplicatesRuleFilter>(Filters);
			result = result && filtersHashSet.SetEquals(duplicatesRuleBody2.Filters);
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleFilter

	[JsonObject(MemberSerialization.OptIn)]
	public class DuplicatesRuleFilter
	{

		#region Properties: Public

		[JsonProperty(PropertyName = "schemaName")]
		public string SchemaName { get; set; }

		[JsonProperty(PropertyName = "columnName")]
		public string ColumnName { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "rootSchemaColumns")]
		public List<string> RootSchemaColumns { get; set; }

		[JsonProperty(PropertyName = "sourceColumnUId")]
		public string SourceColumnUId { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			return GetHashCode() == obj.GetHashCode();
		}

		public override int GetHashCode() {
			unchecked {
				var hashCode = SchemaName.GetHashCode();
				if (Type == null) {
					hashCode = hashCode * 19 + ColumnName.GetHashCode();
				} else {
					hashCode = hashCode * 19 + Type.GetHashCode();
				}
				if (SourceColumnUId != null) {
					hashCode = hashCode * 19 + SourceColumnUId.GetHashCode();
				}
				return hashCode;
			}
		}

		#endregion

	}

	#endregion

}
