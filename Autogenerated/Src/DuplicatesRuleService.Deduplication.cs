namespace BPMSoft.Configuration.Deduplication
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Newtonsoft.Json;
	using BPMSoft.Core.Factories;

	#region Class: DuplicatesFiltersDTO

	public class DuplicatesFiltersDTO
	{
		public Guid Id { get; set; }
		public List<DuplicatesRuleFilter> Filters { get; set; }
	}

	#endregion

	#region Class: DuplicatesRuleFilterDTO

	[JsonObject(MemberSerialization.OptIn)]
	public class DuplicatesRuleFilterDTO
	{

		#region Propterties: Public

		[JsonProperty(PropertyName = "schemaName")]
		public string SchemaName { get; set; }

		[JsonProperty(PropertyName = "columnName")]
		public string ColumnName { get; set; }
		
		[JsonProperty(PropertyName = "rootSchemaColumns")]
		public List<string> RootSchemaColumns { get; set; }

		[JsonProperty(PropertyName = "isDetail")]
		public bool IsDetail { get; set; }

		#endregion

		#region Methods: Public

		public override bool Equals(object obj) {
			return GetHashCode() == obj.GetHashCode();
		}

		public override int GetHashCode() {
			unchecked {
				var hashCode = (SchemaName != null ? SchemaName.GetHashCode() : 0);
				if (ColumnName != null) {
					hashCode = (hashCode * 397) ^ (ColumnName != null ? ColumnName.GetHashCode() : 0);
				} else {
					hashCode = (hashCode * 397) ^ (RootSchemaColumns != null ? RootSchemaColumns.GetHashCode() : 0);
				}
				hashCode = (hashCode * 397) ^ IsDetail.GetHashCode();
				return hashCode;
			}
		}

		#endregion

	}

	#endregion

	#region Class: DuplicatesRuleService

	/// <summary>
	/// Represents endpoint for duplicates rules domain. 
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class DuplicatesRuleService
	{

		#region Properties: Protected

		private IDuplicatesRuleManager _duplicatesRuleManager;
		protected IDuplicatesRuleManager DuplicatesRuleManager =>
			_duplicatesRuleManager ?? (_duplicatesRuleManager = ClassFactory.Get<IDuplicatesRuleManager>());

		#endregion

		#region Methods: Public

		/// <summary>
		/// Check is entity schema deduplication rule exists.
		/// </summary>
		/// <param name="entitySchemaUid">Entity schema uid.</param>
		/// <returns>Is entity schema deduplication rule exists.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "isExists")]
		public bool CheckIsDuplicationRuleExist(string entitySchemaUid) {
			return Guid.TryParse(entitySchemaUid, out var uid) && DuplicatesRuleManager.GetIsDuplicationRuleExist(uid);
		}

		/// <summary>
		/// Returns filters list by ruleId
		/// </summary>
		/// <param name="ruleId">Rule id</param>
		/// <returns>Rule list</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<DuplicatesRuleFilterDTO> GetDuplicatesRuleFilters(string ruleId) {
			return Guid.TryParse(ruleId, out var id) 
				? DuplicatesRuleManager.GetDuplicatesRuleFilters(id)
				: null;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedResponse,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool SaveRuleFilters(DuplicatesFiltersDTO dto) {
			// TODO: implement save rules
			return false;
		}

		#endregion

	}

	#endregion

}
