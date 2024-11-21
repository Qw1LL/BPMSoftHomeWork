namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: SimilarLeadSearchHelper

	/// <summary>
	/// Implement search of duplicates.
	/// </summary>
	public class SimilarLeadSearchHelper {

		#region Fields: Private

		private UserConnection _userConnection;

		private DeduplicationSearch _deduplicationSearch;

		#endregion

		#region Methods: Private

		private List<Guid> GetLeadsQualifiedEntityIds(List<Guid> leadIds, string schemaName) {
			List<Guid> contactIds = new List<Guid>();
			if (leadIds.Count > 0) {
				string entityColumnName = string.Format("Qualified{0}", schemaName);
				var leadEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Lead");
				leadEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
				leadEsq.AddColumn(entityColumnName);
				object[] ignoredLeadStatus = new object[] { LeadConsts.DisqualifiedUId, LeadConsts.NotInterestedUId,
					LeadConsts.SatisfiedUId };
				leadEsq.Filters.Add(leadEsq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "QualifyStatus",
					ignoredLeadStatus));
				leadEsq.Filters.Add(leadEsq.CreateIsNotNullFilter(entityColumnName));
				object[] searchIds = leadIds.Select(id => (object)id).ToArray();
				leadEsq.Filters.Add(leadEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", searchIds,
					false));
				var contactIdForLead = leadEsq.GetEntityCollection(_userConnection);
				string valueColumnName = string.Format("{0}Id", entityColumnName);
				contactIds = contactIdForLead.Select(entity =>
					entity.GetTypedColumnValue<Guid>(valueColumnName)).ToList();
			}
			return contactIds;
		}

		private void AddColumnsFromMatching(EntitySchemaQuery esq, SimilarSearchXmlMatch similarSearchXmlMatching) {
			var columnsMatching = similarSearchXmlMatching.EntityColumns;
			foreach (KeyValuePair<string, SimilarSearchXmlMatch.Rule> rule in columnsMatching) {
				esq.AddColumn(rule.Key);
			}
		}

		private List<Guid> FindLeadSimilarContacts(Guid leadId) {
			List<Guid> similarRecords = new List<Guid>();
			SimilarSearchXmlMatch leadToContactXmlMatching = GetLeadToContactXmlMatching();
			SimilarSearchXmlMatch leadToLeadXmlMatching = GetLeadXmlMatchingg();
			EntitySchemaQuery esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Lead");
			AddColumnsFromMatching(esq, leadToContactXmlMatching);
			AddColumnsFromMatching(esq, leadToLeadXmlMatching);
			esq.AddColumn("QualifiedContact");
			Entity lead = esq.GetEntity(_userConnection, leadId);
			if (lead != null) {
				XmlDocument contactSearchValues 
					= _deduplicationSearch.CreateXmlSimilarSearchValue(lead,leadToContactXmlMatching);
				XmlDocument leadSearchValues 
					= _deduplicationSearch.CreateXmlSimilarSearchValue(lead, leadToLeadXmlMatching);
				List<Guid> contactIds = _deduplicationSearch.FindSimilarEntity("Contact", leadId, contactSearchValues);
				List<Guid> leadIds = _deduplicationSearch.FindSimilarEntity("Lead", leadId, leadSearchValues);
				List<Guid> leadsContactIds = GetLeadsQualifiedEntityIds(leadIds, "Contact");
				contactIds.AddRange(leadsContactIds);
				similarRecords = contactIds.Distinct().ToList();
				Guid qualifiedContact = lead.GetTypedColumnValue<Guid>("QualifiedContactId");
				similarRecords.Remove(qualifiedContact);
			}
			return similarRecords;
		}

		private List<Guid> FindLeadSimilarAccounts(Guid leadId) {
			List<Guid> similarRecords = new List<Guid>();
			SimilarSearchXmlMatch leadToAccountXmlMatching = GetLeadToAccountXmlMatching();
			SimilarSearchXmlMatch leadToLeadXmlMatching = GetLeadXmlMatchingg();
			EntitySchemaQuery esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Lead");
			AddColumnsFromMatching(esq, leadToAccountXmlMatching);
			AddColumnsFromMatching(esq, leadToLeadXmlMatching);
			esq.AddColumn("QualifiedAccount");
			Entity lead = esq.GetEntity(_userConnection, leadId);
			if (lead != null) {
				XmlDocument accountSearchValues
					= _deduplicationSearch.CreateXmlSimilarSearchValue(lead, leadToAccountXmlMatching);
				XmlDocument leadSearchValues
					= _deduplicationSearch.CreateXmlSimilarSearchValue(lead, leadToLeadXmlMatching);
				List<Guid> accountIds = _deduplicationSearch.FindSimilarEntity("Account", leadId, accountSearchValues);
				List<Guid> leadIds = _deduplicationSearch.FindSimilarEntity("Lead", leadId, leadSearchValues);
				List<Guid> leadsAccountIds = GetLeadsQualifiedEntityIds(leadIds, "Account");
				accountIds.AddRange(leadsAccountIds);
				similarRecords = accountIds.Distinct().ToList();
				Guid qualifiedAccount = lead.GetTypedColumnValue<Guid>("QualifiedAccountId");
				similarRecords.Remove(qualifiedAccount);
			}
			return similarRecords;
		}

		private List<Guid> FindLeadSimilarLeads(Guid leadId) {
			List<Guid> similarRecords = new List<Guid>();
			SimilarSearchXmlMatch leadToLeadXmlMatching = GetLeadXmlMatchingg();
			EntitySchemaQuery esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Lead");
			AddColumnsFromMatching(esq, leadToLeadXmlMatching);
			Entity lead = esq.GetEntity(_userConnection, leadId);
			if (lead != null) {
				XmlDocument searchValues 
					= _deduplicationSearch.CreateXmlSimilarSearchValue(lead, leadToLeadXmlMatching);
				similarRecords = _deduplicationSearch.FindSimilarEntity("Lead", leadId, searchValues);
			}
			return similarRecords;
		}

		#endregion

		#region Methods: Protected

		protected virtual SimilarSearchXmlMatch GetLeadToContactXmlMatching() {
			var matching = new SimilarSearchXmlMatch();
			matching.SourceSchemaName = "Lead";
			matching.DestinationSchemaName = "Contact";
			var entityColumns = new Dictionary<string, SimilarSearchXmlMatch.Rule>();
			entityColumns["Contact"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Name",
				SchemaName = "Contact"
			};
			entityColumns["Email"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Number",
				SchemaName = "ContactCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.EmailId)
			};
			entityColumns["BusinesPhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "SearchNumber",
				SchemaName = "ContactCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.WorkPhoneId)
			};
			entityColumns["MobilePhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "SearchNumber",
				SchemaName = "ContactCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.MobilePhoneId)
			};
			entityColumns["Website"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Number",
				SchemaName = "ContactCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.WebId)
			};
			entityColumns["City"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CityId",
				SchemaName = "ContactAddress"
			};
			entityColumns["Country"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CountryId",
				SchemaName = "ContactAddress"
			};
			matching.EntityColumns = entityColumns;
			return matching;
		}

		protected virtual SimilarSearchXmlMatch GetLeadToAccountXmlMatching() {
			var matching = new SimilarSearchXmlMatch();
			matching.SourceSchemaName = "Lead";
			matching.DestinationSchemaName = "Account";
			var entityColumns = new Dictionary<string, SimilarSearchXmlMatch.Rule>();
			entityColumns["Account"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Name",
				SchemaName = "Account"
			};
			entityColumns["Email"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Number",
				SchemaName = "AccountCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.EmailId)
			};
			entityColumns["BusinesPhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "SearchNumber",
				SchemaName = "AccountCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.WorkPhoneId)
			};
			entityColumns["MobilePhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "SearchNumber",
				SchemaName = "AccountCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.MobilePhoneId)
			};
			entityColumns["Website"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Number",
				SchemaName = "AccountCommunication",
				TypeId = Guid.Parse(CommunicationTypeConsts.WebId)
			};
			entityColumns["City"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CityId",
				SchemaName = "AccountAddress"
			};
			entityColumns["Country"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CountryId",
				SchemaName = "AccountAddress"
			};
			matching.EntityColumns = entityColumns;
			return matching;
		}

		protected virtual SimilarSearchXmlMatch GetLeadXmlMatchingg() {
			var matching = new SimilarSearchXmlMatch();
			matching.SourceSchemaName = "Lead";
			matching.DestinationSchemaName = "Lead";
			var entityColumns = new Dictionary<string, SimilarSearchXmlMatch.Rule>();
			entityColumns["Contact"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Contact",
				SchemaName = "Lead"
			};
			entityColumns["Account"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Account",
				SchemaName = "Lead"
			};
			entityColumns["Email"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Email",
				SchemaName = "Lead"
			};
			entityColumns["BusinesPhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "BusinesPhone",
				SchemaName = "Lead"
			};
			entityColumns["MobilePhone"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "MobilePhone",
				SchemaName = "Lead"
			};
			entityColumns["Website"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "Website",
				SchemaName = "Lead"
			};
			entityColumns["City"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CityId",
				SchemaName = "Lead"
			};
			entityColumns["Country"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "CountryId",
				SchemaName = "Lead"
			};
			entityColumns["LeadType"] = new SimilarSearchXmlMatch.Rule {
				ColumnName = "LeadTypeId",
				SchemaName = "Lead"
			};
			matching.EntityColumns = entityColumns;
			return matching;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		/// <param name="deduplicationSearch">Instance of <see cref="DeduplicationSearch"/>.</param>
		public SimilarLeadSearchHelper(UserConnection userConnection, DeduplicationSearch deduplicationSearch) {
			_userConnection = userConnection;
			_deduplicationSearch = deduplicationSearch;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Performs search lead similar records.
		/// </summary>
		/// <param name="schemaName">Schema name.</param>
		/// <param name="leadId">Lead's unique identifier.</param>
		/// <returns>Collection of unique identifiers.</returns>
		public List<Guid> FindLeadSimilarRecords(string schemaName, Guid leadId) {
			List<Guid> similarRecords = new List<Guid>();
			if (schemaName == "Contact") {
				similarRecords = FindLeadSimilarContacts(leadId);
			} else if (schemaName == "Account") {
				similarRecords = FindLeadSimilarAccounts(leadId);
			} else if (schemaName == "Lead") {
				similarRecords = FindLeadSimilarLeads(leadId);
			}
			return similarRecords;
		}

		#endregion
	}

	#endregion

}


