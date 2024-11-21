namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common.ServiceRouting;
	using BPMSoft.Web.Common;
	using BPMSoft.Configuration.Section;

	#region Class: ContactForMention

	/// <summary>
	/// POCO class for contact item used for mention in a feed.
	/// </summary>
	[DataContract]
	[DebuggerDisplay("{Name}")]
	public class ContactForMention
	{

		#region Constructors: Public

		public ContactForMention() {}

		public ContactForMention(IDataReader dataReader): this(dataReader, "Name") {}

		public ContactForMention(IDataReader dataReader, string primaryDisplayColumnName, string connectionType = "") {
			Id = dataReader.GetColumnValue<Guid>("Id");
			ImageId = dataReader.GetColumnValue<Guid>("PhotoId");
			Name = dataReader.GetColumnValue<string>(primaryDisplayColumnName);
			Email = dataReader.GetColumnValue<string>("Email");
			ConnectionType = connectionType == string.Empty ?
				dataReader.GetColumnValue<string>("SysAdminUnit.ConnectionType") : connectionType;
		}

		#endregion

		#region Properties: Public

		internal string ConnectionType { get; set; }

		[DataMember(Name = "value")]
		public Guid Id { get; set; }

		[DataMember(Name = "primaryImage")]
		public Guid ImageId { get; set; }

		[DataMember(Name = "displayValue")]
		public string Name { get; set; }

		[DataMember(Name = "secondaryInfo")]
		public string Email { get; set; }

		#endregion

	}

	#endregion

	#region Class: ESNFeedModuleService

	[ServiceContract]
	[DefaultServiceRoute, SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ESNFeedModuleService : BaseService
	{

		#region Constants: Private

		/// <summary>
		/// Mention contacts page size.
		/// </summary>
		public static readonly int MentionContactsPageSize = 5;

		#endregion

		#region Properties: Private

		private EntitySchema _contactSchema;

		private EntitySchema ContactSchema =>
			_contactSchema ?? (_contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact"));

		#endregion

		#region Properties: Public

		private string _sysAdminUnitId;
		public string SysAdminUnitId {
			get => _sysAdminUnitId ?? (_sysAdminUnitId = UserConnection.CurrentUser.Id.ToString());
			set => _sysAdminUnitId = value;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Add filters to contact <see cref="EntitySchemaQuery"/> instance.
		/// </summary>
		/// <param name="entitySchemaQuery">Contact <see cref="EntitySchemaQuery"/> instance.</param>
		/// <param name="columnPath"></param>
		private static void AddIsActiveFilter(EntitySchemaQuery entitySchemaQuery, string columnPath) {
			IEntitySchemaQueryFilterItem adminUnitFilter =
				entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, columnPath, true);
			adminUnitFilter.Name = "AdminUnitIsActive";
			entitySchemaQuery.Filters.Add(adminUnitFilter);
		}

		private static void AddConnectionTypeFilter(EntitySchemaQuery rightsSubQuery, int connectionType) {
			IEntitySchemaQueryFilterItem adminUnitFilter1 =
				rightsSubQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "ConnectionType", connectionType);
			adminUnitFilter1.Name = "AdminUnitConnectionType";
			rightsSubQuery.Filters.Add(adminUnitFilter1);
		}

		private static void AddConnectionType(EntitySchemaQuery esq) {
			EntitySchemaQueryColumn connectionTypeColumn = esq.AddColumn("[SysAdminUnit:Contact].ConnectionType")
				.OrderByAsc();
			connectionTypeColumn.OrderPosition = 1;
		}

		/// <summary>
		/// Add right query conditions to <see cref="Select"/> instance.
		/// </summary>
		/// <param name="select">Contact <see cref="Select"/> instance.</param>
		private void AddSelectQueryConditions(Select select) {
			var rightsConditions = GetRightQueryCondition(select);
			if (rightsConditions != null
				&& (ContactSchema.AdministratedByRecords
				|| UserConnection.CurrentUser.ConnectionType == UserType.SSP)) {
				select.And(rightsConditions);
			}
		}

		/// <summary>
		/// Create <see cref="QueryCondition"/> for contact <see cref="EntitySchema"/>.
		/// </summary>
		/// <param name="select">Contact <see cref="Select"/> instance.</param>
		/// <returns>Contact <see cref="QueryCondition"/>.</returns>
		private QueryCondition GetRightQueryCondition(Select select) {
			var securityEngine = UserConnection.DBSecurityEngine;
			return UserConnection.DBSecurityEngine.GetRecordsByRightCondition(new RecordsByRightOptions {
				EntitySchemaName = ContactSchema.Name,
				EntitySchemaSourceAlias = select.SourceExpression.Alias,
				RightEntitySchemaName = securityEngine.GetRecordRightsSchemaName(ContactSchema.Name),
				Operation = EntitySchemaRecordRightOperation.Read,
				PrimaryColumnName = ContactSchema.GetPrimaryColumnName(),
				UserId = UserConnection.CurrentUser.Id,
				UseDenyRecordRights = ContactSchema.UseDenyRecordRights
			});
		}

		/// <summary>
		/// Add additional <see cref="ContactForMention"/> instances for ssp users.
		/// </summary>
		/// <param name="entitySchemaUId"><see cref="EntitySchema"/> instance unique identifier.</param>
		/// <param name="entityId"><see cref="Entity"/> instance identifier.</param>
		/// <param name="searchName">Part of contact's name that will be used to filter result list.</param>
		/// <param name="contacts"><see cref="ContactForMention"/> collection.</param>
		private void AddContactsForSspUser(Guid entitySchemaUId, Guid entityId, string searchName,
				List<ContactForMention> contacts) {
			if (UserConnection.CurrentUser.ConnectionType != UserType.SSP ||
				!UserConnection.GetIsFeatureEnabled("IsSSPContactSocialMentions") ||
				contacts.Count >= MentionContactsPageSize || !entitySchemaUId.IsNotEmpty()) {
				return;
			}
			contacts.AddRangeIfNotExists(GetCurrentPageContactsForMention(searchName, entitySchemaUId, entityId));
			if (contacts.Count < MentionContactsPageSize) {
				contacts.AddRangeIfNotExists(GetContactsByRulesForMention(searchName));
			}
			contacts.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
		}

		/// <summary>
		/// Create contact <see cref="EntitySchemaQuery"/> instance.
		/// </summary>
		/// <returns>Contact <see cref="EntitySchemaQuery"/> instance</returns>
		private EntitySchemaQuery GetContactEsq() {
			return new EntitySchemaQuery(ContactSchema) {
				RowCount = MentionContactsPageSize,
				UseAdminRights = false,
				IgnoreDisplayValues = true
			};
		}

		/// <summary>
		/// Add columns to contact <see cref="EntitySchemaQuery"/> instance.
		/// </summary>
		/// <param name="esq">Contact <see cref="EntitySchemaQuery"/> instance.</param>
		private void AddEsqColumns(EntitySchemaQuery esq) {
			esq.PrimaryQueryColumn.IsVisible = false;
			esq.AddColumn(ContactSchema.GetPrimaryColumnName());
			esq.AddColumn(ContactSchema.PrimaryImageColumn.Name);
			string primaryDisplayColumnName = ContactSchema.GetPrimaryDisplayColumnName();
			var primaryDisplayColumn = esq.AddColumn(primaryDisplayColumnName).OrderByAsc();
			primaryDisplayColumn.OrderPosition = 0;
			if (primaryDisplayColumnName != "Email") {
				esq.AddColumn("Email");
			}
		}

		private void AddSearchFilter(EntitySchemaQuery esq, string searchName,
			FilterComparisonType searchType) {
			var searchFilter =
				esq.CreateFilterWithParameters(searchType, ContactSchema.GetPrimaryDisplayColumnName(), searchName);
			esq.Filters.Add(searchFilter);
		}
		/// <summary>
		/// Add filters to contact <see cref="EntitySchemaQuery"/> instance.
		/// </summary>
		/// <param name="esq">Contact <see cref="EntitySchemaQuery"/> instance.</param>
		/// <param name="searchName">Part of contact's name that will be used to filter result list.</param>
		/// <param name="searchType">Type of filtering. Should be used only binary operations like StartWith, Contains,
		/// etc.</param>
		private void AddEsqFilters(EntitySchemaQuery esq, string searchName, FilterComparisonType searchType) {
			var searchFilter = esq.CreateFilterWithParameters(searchType,
				ContactSchema.GetPrimaryDisplayColumnName(), searchName);
			esq.Filters.Add(searchFilter);
			AddIsActiveFilter(esq, "[SysAdminUnit:Contact].Active");
		}

		private List<ContactForMention> LoadContacts(string searchName, FilterComparisonType searchType) {
			var displayColumnName = ContactSchema.GetPrimaryDisplayColumnName();
			var contacts = GetGeneralContacts(searchName, searchType, displayColumnName);
			var contactsCount = contacts.Count;
			if (contactsCount < MentionContactsPageSize) {
				contacts.AddRange(GetPortalContacts(searchName, searchType, displayColumnName, MentionContactsPageSize - contactsCount));
			}
			return contacts;
		}

		private IEnumerable<ContactForMention> GetPortalContacts(string searchName, FilterComparisonType searchType, string displayColumnName, int contactsCount) {
			var connectionType = 1;
			var esq = CreateEsqForSelectContacts(searchName, searchType, connectionType);
			esq.RowCount = contactsCount;
			var select = esq.GetSelectQuery(UserConnection);
			var contacts = select.ExecuteEnumerable(reader =>
					new ContactForMention(reader, displayColumnName, connectionType.ToString())).ToList();
			return contacts;
		}

		private List<ContactForMention> GetGeneralContacts(string searchName, FilterComparisonType searchType, string displayColumnName) {
			var connectionType = 0;
			var esq = CreateEsqForSelectContacts(searchName, searchType, connectionType);
			var select = esq.GetSelectQuery(UserConnection);
			var contacts = select.ExecuteEnumerable(reader =>
					new ContactForMention(reader, displayColumnName, connectionType.ToString())).ToList();
			return contacts;
		}

		private EntitySchemaQuery CreateEsqForSelectContacts(string searchName, FilterComparisonType searchType, int connectionType) {
			var esq = GetContactEsq();
			esq.UseAdminRights = ContactSchema.AdministratedByRecords || UserConnection.CurrentUser.ConnectionType == UserType.SSP;
			AddEsqColumns(esq);
			AddSearchFilter(esq, searchName, searchType);
			EntitySchemaQueryFilter rightsFilter = esq.CreateExistsFilter("[SysAdminUnit:Contact].Id");
			rightsFilter.Name = "ActiveFilter";
			EntitySchemaQuery rightsSubQuery = rightsFilter.RightExpressions[0].SubQuery;
			AddIsActiveFilter(rightsSubQuery, "Active");
			AddConnectionTypeFilter(rightsSubQuery, connectionType);
			esq.Filters.Add(rightsFilter);
			return esq;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns <see cref="Contact"/> identifiers from current page columns.
		/// </summary>
		/// <param name="schemaName"><see cref="EntitySchema"/> name.</param>
		/// <param name="contactColumns"><see cref="EntitySchemaColumn"/> name collection</param>
		/// <param name="entityId"><see cref="Entity"/> instance identifier.</param>
		/// <returns><see cref="Contact"/> identifiers from current page columns.</returns>
		protected List<Guid> GetCurrentPageContactIds(string schemaName, List<string> contactColumns, Guid entityId) {
			var contactIds = new List<Guid>();
			var select =
				new Select(UserConnection).Top(MentionContactsPageSize).Distinct()
				.From(schemaName)
				.Where("Id").IsEqual(Column.Parameter(entityId)) as Select;
			foreach (string column in contactColumns) {
				select = select.Column(column);
			}
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						foreach (var column in contactColumns) {
							var contactId = dataReader.GetColumnValue<Guid>(column);
							if (contactId.IsNotEmpty()) {
								contactIds.AddIfNotExists(contactId);
							}
						}
					}
				}
			}
			return contactIds;
		}

		/// <summary>
		/// Returns <see cref="Select"/> instance for current page contacts.
		/// </summary>
		/// <param name="contactIds"><see cref="Contact"/> identifiers from current page columns.</param>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <returns><see cref="Select"/> instance for current page contacts.</returns>
		protected Select GetCurrentPageContactsForMentionSelect(List<Guid> contactIds, string searchName, string primaryDisplayColumnName) {
			var sysAdminUnitSubSelect =
				new Select(UserConnection)
					.Column("Id")
				.From("SysAdminUnit")
				.Where("SysAdminUnit", "ContactId").IsEqual("Contact", "Id")
					.And("SysAdminUnit", "Active").IsEqual(Column.Parameter(true)) as Select;
			var select = new Select(UserConnection).Distinct()
					.Column("Contact", "Id")
					.Column("Contact", primaryDisplayColumnName).As("Name")
					.Column("Contact", "PhotoId")
					.Column("Contact", "Email")
					.Column("SysAdminUnit", "ConnectionType").As("SysAdminUnit.ConnectionType")
				.From("Contact")
				.InnerJoin("SysAdminUnit").On("SysAdminUnit", "ContactId").IsEqual("Contact", "Id")
				.Where("Contact", "Id").In(Column.Parameters(contactIds))
					.And("Contact", "Name").ConsistsWith(Column.Parameter(searchName))
					.And().Exists(sysAdminUnitSubSelect) as Select;
			return select;
		}

		/// <summary>
		/// Returns additional contacts used for mention in feed (by using macros @...)
		/// from current page contact columns.
		/// </summary>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <param name="entitySchemaUId"><see cref="EntitySchema"/> instance unique identifier.</param>
		/// <param name="entityId"><see cref="Entity"/> instance identifier.</param>
		/// <returns>The list of emails for contacts from current page.</returns>
		protected List<ContactForMention> GetCurrentPageContactsForMention(string searchName, Guid entitySchemaUId,
				Guid entityId) {
			var sectionManager = ClassFactory.Get<ISectionManager>(new ConstructorArgument("uc", UserConnection),
				new ConstructorArgument("sectionType", UserType.General.ToString()));
			var columnAccessList = sectionManager.GetSspColumnAccessList(entitySchemaUId);
			var entitySchema = UserConnection.EntitySchemaManager.FindInstanceByUId(entitySchemaUId);
			var primaryDisplayColumnName = entitySchema.Name == ContactSchema.Name ? entitySchema.GetPrimaryDisplayColumnName() : "Name";
			var contactColumns = entitySchema.Columns.Where(column => columnAccessList.Contains(column.UId)
				&& column.ReferenceSchema?.Name == ContactSchema.Name)
				.Select(column => column.ColumnValueName).ToList();
			if (contactColumns.IsEmpty()) {
				return new List<ContactForMention>();
			}
			var contactIds = GetCurrentPageContactIds(entitySchema.Name, contactColumns, entityId);
			if (contactIds.IsEmpty()) {
				return new List<ContactForMention>();
			}
			var select = GetCurrentPageContactsForMentionSelect(contactIds, searchName, primaryDisplayColumnName);
			IEnumerable<ContactForMention> contacts = select.ExecuteEnumerable(reader => new ContactForMention(reader, primaryDisplayColumnName));
			return contacts.ToList();
		}

		/// <summary>
		/// Returns additional contacts used for mention in feed (by using macros @...) from
		/// "User mention search rules" lookup.
		/// </summary>
		/// <param name="searchName">Part of <see cref="Contact"/> name that will be used to filter result list.</param>
		/// <returns>The list of contacts that could be used for mention in feed that exist in
		/// "User mention search rules" lookup.</returns>
		protected List<ContactForMention> GetContactsByRulesForMention(string searchName) {
			var socialMentionSearchRuleEntityRepository = new SocialMentionSearchRuleEntityRepository(UserConnection);
			return socialMentionSearchRuleEntityRepository.GetContactsForMentionByRules(searchName);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void DeletePostComment(string postCommentId, string parentPostId) {
			var socialMessageESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialMessage");
			socialMessageESQ.AddAllSchemaColumns();
			var message = socialMessageESQ.GetEntity(UserConnection, postCommentId);
			if (message != null) {
				message.Delete();
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void UpdatePostComment(string editedMessage, string postMessageId) {
			var socialChannelESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialMessage");
			socialChannelESQ.AddAllSchemaColumns();
			var message = socialChannelESQ.GetEntity(UserConnection, postMessageId);
			if (message != null) {
				message.SetColumnValue("Message", editedMessage);
				message.Save();
			}
		}

		/// <summary>
		/// Gets contacts used for mention in feed (by using macros @...).
		/// </summary>
		/// <param name="entitySchemaUId"><see cref="EntitySchema"/> instance unique identifier.</param>
		/// <param name="entityId"><see cref="Entity"/> instance identifier.</param>
		/// <param name="searchName">Part of contact's name that will be used to filter result list.</param>
		/// <param name="searchType">Type of filtering. Should be used only binary operations like StartWith, Contains,
		/// etc.</param>
		/// <returns>The list of contacts that could be used for mention in feed.</returns>
		/// <remarks>This method is used for Portal connection too, so it shouldn't use SysAdminUnit entity.</remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "result")]
		public List<ContactForMention> GetContactsForMention(Guid entitySchemaUId, Guid entityId,
				string searchName = "", FilterComparisonType searchType = FilterComparisonType.StartWith) {
			searchName = searchName.TrimEnd();
			List<ContactForMention> contacts;
			if (UserConnection.GetIsFeatureEnabled("SimplifyContactMention")) {
				contacts = LoadContacts(searchName, searchType);
			} else {
				var esq = GetContactEsq();
				AddEsqColumns(esq);
				AddConnectionType(esq);
				AddEsqFilters(esq, searchName, searchType);
				var select = esq.GetSelectQuery(UserConnection);
				var displayColumnName = ContactSchema.GetPrimaryDisplayColumnName();
				AddSelectQueryConditions(select);
				contacts = select.ExecuteEnumerable(reader => new ContactForMention(reader, displayColumnName))
					.ToList();
			}
			AddContactsForSspUser(entitySchemaUId, entityId, searchName, contacts);
			contacts.Sort((c1, c2) => c1.ConnectionType.CompareTo(c2.ConnectionType));
			return contacts;
		}

		#endregion

	}

	#endregion

}

