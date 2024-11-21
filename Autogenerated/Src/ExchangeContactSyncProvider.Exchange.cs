namespace BPMSoft.Sync.Exchange
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common.Json;
	using BPMSoft.Common;
	using Newtonsoft.Json.Linq;
	using Exchange = Microsoft.Exchange.WebServices.Data;
	using BPMSoft.Core.Factories;

	#region Class: ExchangeContactSyncProvider

	/// <summary>
	/// Class for synchronization with Exchange contacts.
	/// </summary>
	public class ExchangeContactSyncProvider: BaseExchangeSyncProvider
	{

		#region Fields: Private

		private readonly BaseExchangeSyncProvider _provider;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of <see cref="ExchangeContactSyncProvider" /> with passed <paramref name="settings"/>.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <param name="senderEmailAddress">Sender email address.</param>
		/// <param name="settings"><see cref="ContactExchangeSettings"/> instance.</param>
		public ExchangeContactSyncProvider(UserConnection userConnection, string senderEmailAddress,
				ContactExchangeSettings settings = null) : base(ExchangeUtility.Log) {
			_provider = ClassFactory.Get<BaseExchangeSyncProvider>("ExchangeContactSyncProvider",
					new ConstructorArgument("userConnection", userConnection),
					new ConstructorArgument("senderEmailAddress", senderEmailAddress),
					new ConstructorArgument("settings", settings));
			TimeZone = userConnection.CurrentUser.TimeZone;
			_provider.GetExternalItemsFiltersHandler = GetContactFilters;
			_provider.GetFullItemHandler = GetFullContact;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// User synchronization settings.
		/// </summary>
		protected TimeZoneInfo TimeZone {
			get;
			private set;
		}

		public override Guid StoreId => _provider.StoreId;

		public ContactExchangeSettings UserSettings => _provider.GetSettings() as ContactExchangeSettings;

		public Exchange.ExchangeService Service { 
			get {
				var type = _provider.GetType();
				var serviceField = type.GetProperty("Service", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
				var value = serviceField.GetValue(_provider) as Exchange.ExchangeService;
				return value;
			}
		}

		#endregion

		#region Methods:Public

		/// <summary>
		/// <see cref="RemoteProvider.NeedMetaDataActualization"/>
		/// </summary>
		public override bool NeedMetaDataActualization() {
			return _provider.NeedMetaDataActualization();
		}

		/// <summary>
		/// <see cref="RemoteProvider.CollectNewItems"/>
		/// </summary>
		public override IEnumerable<LocalItem> CollectNewItems(SyncContext context) {
			return _provider.CollectNewItems(context);
		}

		/// <summary>
		/// Updates last synchronization date value.
		/// </summary>
		/// <param name="context"><see cref="SyncContext"/> instance.</param>
		public override void CommitChanges(SyncContext context) {
			_provider.CommitChanges(context);
		}

		/// <summary>
		/// <see cref="RemoteProvider.CreateNewSyncItem"/>
		/// </summary>
		public override IRemoteItem CreateNewSyncItem(SyncItemSchema schema) {
			return _provider.CreateNewSyncItem(schema);
		}

		/// <summary>
		/// <see cref="ExchangeSyncProvider.EnumerateChanges"/>
		/// </summary>
		public override IEnumerable<IRemoteItem> EnumerateChanges(SyncContext context) {
			return _provider.EnumerateChanges(context);
		}

		/// <summary>
		/// <see cref="RemoteProvider.KnownTypes"/>
		/// </summary>
		public override IEnumerable<Type> KnownTypes() {
			return _provider.KnownTypes();
		}

		/// <summary>
		/// <see cref="ExchangeSyncProvider.LoadSyncItem(SyncItemSchema, string)"/>
		/// </summary>
		public override IRemoteItem LoadSyncItem(SyncItemSchema schema, string id) {
			return _provider.LoadSyncItem(schema, id);
		}

		/// <summary>
		/// <see cref="RemoteProvider.GetLocallyModifiedItemsMetadata"/>
		/// </summary>
		public override IEnumerable<ItemMetadata> GetLocallyModifiedItemsMetadata(SyncContext context,
				EntitySchemaQuery modifiedItemsEsq) {
			return _provider.GetLocallyModifiedItemsMetadata(context, modifiedItemsEsq);
		}

		/// <summary>
		/// <see cref="ExchangeSyncProvider.ApplyChanges"/>
		/// </summary>
		public override void ApplyChanges(SyncContext context, IRemoteItem syncItem) {
			_provider.ApplyChanges(context, syncItem);
		}

		public virtual Exchange.SearchFilter GetContactFilters() {
			throw new NotImplementedException();
		}

		public virtual Exchange.Contact GetFullContact(string itemId) {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion

	#region Class: AddressDetail

	/// <summary>
	/// ###### ###### ######## ########## #########.
	/// </summary>
	public class AddressDetail
	{

		#region Constructors: Public

		/// <summary>
		/// ############## ##### ######### ####### <see cref="AddressDetail"/> ######### ###########.
		/// </summary>
		/// <param name="city">########## ############# ######.</param>
		/// <param name="country">########## ############# ######.</param>
		/// <param name="region">########## ############# #######.</param>
		public AddressDetail(Guid city, Guid country, Guid region) {
			CityId = city;
			CountryId = country;
			RegionId = region;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id ######.
		/// </summary>
		public Guid CityId {
			get;
			set;
		}

		/// <summary>
		/// Id ######.
		/// </summary>
		public Guid CountryId {
			get;
			set;
		}

		/// <summary>
		/// Id #######.
		/// </summary>
		public Guid RegionId {
			get;
			set;
		}

		#endregion


	}

	#endregion

	#region Class: ContactExchangeSettings

	/// <summary>
	/// ############# ###### ######### ############ ### ########## ############# #########.
	/// </summary>
	public class ContactExchangeSettings : ExchangeSettings
	{

		#region Constructors: Public

				/// <summary>
		/// ############## ######### ############ ### ########## ############# #########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="senderEmailAddress">######## ##### ############, ######### ######## ##### #######.</param>
		public ContactExchangeSettings(UserConnection userConnection, string senderEmailAddress)
			: base(userConnection, senderEmailAddress) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ### ######## ########### # ########.
		/// </summary>
		public Guid LinkContactToAccountType {
			get;
			set;
		}

		/// <summary>
		/// ####, ####### # ####### ########## ######## ################ ######## ## #### ########.
		/// </summary>
		public DateTime LoadContactsFromDate {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############# ######## ## Exchange.
		/// </summary>
		public bool ImportContacts {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############# ### ######## ## Exchange.
		/// </summary>
		public bool ImportContactsAll {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ###### ######### ########## ############ ## ############ #####.
		/// </summary>
		public bool ImportContactsFromFolders {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ###### ######### ########## ############ ## ############ #########.
		/// </summary>
		public bool ImportContactsFromCategories {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ######## ## ########## #########.
		/// </summary>
		public bool ExportContacts {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ### ######## ## ########## #########.
		/// </summary>
		public bool ExportContactsAll {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ######### ######## ## ########## #########.
		/// </summary>
		public bool ExportContactsSelected {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ########### ## ########## #########.
		/// </summary>
		public bool ExportContactsEmployers {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ######## ## ########## #########.
		/// </summary>
		public bool ExportContactsCustomers {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ## ######## ## ########## #########,
		/// # ####### # ####### <see cref="Contact.Owner"/> ###### ####### ####### ############.
		/// </summary>
		public bool ExportContactsOwner {
			get;
			set;
		}

		/// <summary>
		/// #######, ###########, ### ########## ############## ######## ## ############### ##### ########## #########.
		/// </summary>
		public bool ExportContactsFromGroups {
			get;
			set;
		}

		/// <summary>
		/// A flag indicating whether it is possible to import contacts.
		/// </summary>
		public bool CanImportContactsFromExchange {
			get;
			set;
		}

		/// <summary>
		/// A flag indicating whether you can export contacts.
		/// </summary>
		public bool CanExportContactsToExchange {
			get; 
			set;
		}

		#endregion

		#region Methods: Private

		private static string GetLocalizableStringValue(UserConnection userConnection, string lczName) {
			return new LocalizableString(userConnection.Workspace.ResourceStorage, "ExchangeContactSyncProvider",
							"LocalizableStrings." + lczName + ".Value").ToString();
		}

		private static string GetSyncSettingsDoesNotExistLczValue(UserConnection userConnection) {
			return GetLocalizableStringValue(userConnection, "ContactSyncSettingsDoesNotExist");
		}
		
		/// <summary>
		/// Initializes the rights of access to transactions of import/export with MS Exchange.
		/// </summary>
		private void InitializePermissions(UserConnection userConnection) {
			CanImportContactsFromExchange = userConnection.DBSecurityEngine.GetCanExecuteOperation("CanImportContactsFromExchange", userConnection.CurrentUser.Id);
			CanExportContactsToExchange = userConnection.DBSecurityEngine.GetCanExecuteOperation("CanExportContactsToExchange", userConnection.CurrentUser.Id);
		}


		/// <summary>
		/// Returns <see cref="DateTime"/> instance converted to user timezone.
		/// </summary>
		/// <param name="utcDateTime"><see cref="DateTime"/> instance.</param>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		/// <returns><see cref="DateTime"/> instance converted to user timezone.</returns>
		private DateTime GetUserDateTime(DateTime utcDateTime, UserConnection userConnection) {
			return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime.Kind == DateTimeKind.Utc ?
				utcDateTime : utcDateTime.ToUniversalTime(), userConnection.CurrentUser.TimeZone);
		}

		private void InitSyncConfigData(UserConnection userConnection) {
			Select select = new Select(userConnection).Top(1)
					.Column("cs", "LastSyncDate")
					.Column("cs", "LoadContactsFromDate")
					.Column("cs", "LinkContactToAccountId")
					.Column("cs", "ImportContacts")
					.Column("cs", "ImportContactsAll")
					.Column("cs", "ImportContactsFromFolders")
					.Column("cs", "ImportContactsFromCategories")
					.Column("cs", "ExportContacts")
					.Column("cs", "ExportContactsAll")
					.Column("cs", "ExportContactsSelected")
					.Column("cs", "ExportContactsEmployers")
					.Column("cs", "ExportContactsCustomers")
					.Column("cs", "ExportContactsOwner")
					.Column("cs", "ExportContactsFromGroups")
					.Column("cs", "ImportContactsFolders")
					.Column("cs", "ExportContactsGroups")
				.From("ContactSyncSettings").As("cs")
				.InnerJoin("MailboxSyncSettings").As("ms").On("ms", "Id").IsEqual("cs", "MailboxSyncSettingsId")
					.Where("ms", "SenderEmailAddress").IsEqual(Column.Parameter(SenderEmailAddress))
					.And("ms", "SysAdminUnitId").IsEqual(Column.Parameter(userConnection.CurrentUser.Id)) as Select;
			using (DBExecutor dbExec = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExec)) {
					if (!reader.Read()) {
						throw new ApplicationException(
								string.Format(GetSyncSettingsDoesNotExistLczValue(userConnection),
								SenderEmailAddress));
					}
					LastSyncDate = GetUserDateTime(DateTime.SpecifyKind(reader.GetColumnValue<DateTime>("LastSyncDate"),
						DateTimeKind.Utc), userConnection);
					LoadContactsFromDate = GetUserDateTime(DateTime.SpecifyKind(
						reader.GetColumnValue<DateTime>("LoadContactsFromDate"),
						DateTimeKind.Utc), userConnection);
					LinkContactToAccountType = reader.GetColumnValue<Guid>("LinkContactToAccountId");
					if (CanImportContactsFromExchange) {
						ImportContacts = reader.GetColumnValue<bool>("ImportContacts");
						ImportContactsAll = reader.GetColumnValue<bool>("ImportContactsAll");
						ImportContactsFromFolders = reader.GetColumnValue<bool>("ImportContactsFromFolders");
						ImportContactsFromCategories = reader.GetColumnValue<bool>("ImportContactsFromCategories");
						RemoteFolderUIds = GetFoldersInfo(reader.GetColumnValue<string>("ImportContactsFolders"));
					}
					if (CanExportContactsToExchange) {
						ExportContacts = reader.GetColumnValue<bool>("ExportContacts");
						ExportContactsAll = reader.GetColumnValue<bool>("ExportContactsAll");
						ExportContactsSelected = reader.GetColumnValue<bool>("ExportContactsSelected");
						ExportContactsEmployers = reader.GetColumnValue<bool>("ExportContactsEmployers");
						ExportContactsCustomers = reader.GetColumnValue<bool>("ExportContactsCustomers");
						ExportContactsOwner = reader.GetColumnValue<bool>("ExportContactsOwner");
						ExportContactsFromGroups = reader.GetColumnValue<bool>("ExportContactsFromGroups");
						LocalFolderUIds = GetFoldersInfo(reader.GetColumnValue<string>("ExportContactsGroups"));
					}
				}
			}
		}

		private static IDictionary<string, Guid> GetFoldersInfo(string serializedFolders) {
			var result = new Dictionary<string, Guid>();
			var foldersArray = Json.Deserialize(serializedFolders) as JArray;
			if (foldersArray == null) {
				return result;
			}
			foreach (JToken folder in foldersArray) {
				result.Add(folder.Value<string>("Path"), new Guid(folder.Value<string>("Id")));
			}
			return result;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties(UserConnection userConnection) {
			RemoteFolderUIds = new Dictionary<string, Guid>();
			LocalFolderUIds = new Dictionary<string, Guid>();
			InitializePermissions(userConnection);
			InitSyncConfigData(userConnection);
		}

		#endregion

	}

	#endregion

}
