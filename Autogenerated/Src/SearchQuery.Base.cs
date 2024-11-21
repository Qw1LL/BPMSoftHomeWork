namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Newtonsoft.Json;

	#region Class: SearchQuery

	[DataContract]
	public class SearchQuery
	{

		#region Properties: Public

		[DataMember(Name = "schemaName", IsRequired = false)]
		public string SchemaName { get; set; }

		[DataMember(Name = "columns", IsRequired = false)]
		public List<string> Columns { get; set; }

		[DataMember(Name = "rules", IsRequired = false)]
		[JsonProperty(PropertyName = "rules")]
		public List<SearchQueryRule> Rules { get; set; }

		[DataMember(Name = "from", IsRequired = false)]
		public int? From { get; set; }

		[DataMember(Name = "size", IsRequired = false)]
		public int? Size { get; set; }

		[DataMember(Name = "primaryColumnValue", IsRequired = false)]
		public Guid? PrimaryColumnValue { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			var query2 = (SearchQuery)obj;
			var result = SchemaName.Equals(query2.SchemaName);
			result = result && Columns.All(query2.Columns.Contains) && Columns.Count == query2.Columns.Count;
			var firstRulesHashSet = new HashSet<SearchQueryRule>(Rules);
			result = result && firstRulesHashSet.SetEquals(query2.Rules);
			result = result && From.Equals(query2.From);
			result = result && Size.Equals(query2.Size);
			result = result && PrimaryColumnValue.Equals(query2.PrimaryColumnValue);
			return result;
		}

		#endregion

	}

	#endregion

	#region Class: SearchQueryRule

	[DataContract]
	public class SearchQueryRule
	{
		
		#region Properties: Public

		[DataMember(Name = "filters", IsRequired = false)]
		public List<SearchQueryFilter> Filters { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			var rule2 = (SearchQueryRule)obj;
			var firstFiltersExceptSecondFilters = this.Filters.Except(rule2.Filters);
			var secondFiltersExceptFirstFilters = rule2.Filters.Except(this.Filters);
			return !firstFiltersExceptSecondFilters.Any() && !secondFiltersExceptFirstFilters.Any();
		}

		public override int GetHashCode() {
			unchecked {
				int hash = 19;
				foreach (var queryFilter in Filters) {
					hash = hash * 31 + queryFilter.GetHashCode();
				}
				return hash;
			}
		}

		#endregion

	}

	#endregion

	#region Class: SearchQueryFilter

	[DataContract]
	public class SearchQueryFilter
	{

		#region Properties: Public

		[DataMember(Name = "schemaName", IsRequired = false)]
		public string SchemaName { get; set; }

		[DataMember(Name = "columnName", IsRequired = false)]
		public string ColumnName { get; set; }

		[DataMember(Name = "value", IsRequired = false)]
		public List<string> Value { get; set; }

		[DataMember(Name = "type", IsRequired = false)]
		public string Type { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			return this.GetHashCode() == obj.GetHashCode();
		}

		public override int GetHashCode() {
			unchecked {
				var hashCode = 3;
				hashCode = hashCode * 19 + SchemaName.GetHashCode();
				if (Value != null) {
					foreach(var item in Value) {
						hashCode = hashCode * 19 + item.GetHashCode();
					}
				}
				if (Type == null) {
					hashCode = hashCode * 19 + ColumnName.GetHashCode();
				}
				else {
					hashCode = hashCode * 19 + Type.GetHashCode();
				}
				return hashCode;
			}
		}

		#endregion

	}

	#endregion

}
