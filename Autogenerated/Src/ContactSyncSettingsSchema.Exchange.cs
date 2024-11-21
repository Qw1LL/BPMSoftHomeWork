namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: ContactSyncSettingsSchema

	/// <exclude/>
	public class ContactSyncSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactSyncSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactSyncSettingsSchema(ContactSyncSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactSyncSettingsSchema(ContactSyncSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			RealUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			Name = "ContactSyncSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1857d6cc-4dd8-4fe7-bb6c-764e36fbd401")) == null) {
				Columns.Add(CreateImportContactsColumn());
			}
			if (Columns.FindByUId(new Guid("3f303942-6360-4c68-be30-8e4dcdcd50ab")) == null) {
				Columns.Add(CreateImportContactsAllColumn());
			}
			if (Columns.FindByUId(new Guid("fe5bb4b5-83d5-4bfa-9da3-b763d463e3f6")) == null) {
				Columns.Add(CreateImportContactsFromFoldersColumn());
			}
			if (Columns.FindByUId(new Guid("8f2584c3-7d7d-41b1-afef-7c728f86d0af")) == null) {
				Columns.Add(CreateImportContactsFromCategoriesColumn());
			}
			if (Columns.FindByUId(new Guid("0f19e212-b9f1-46ed-b867-65c019df259d")) == null) {
				Columns.Add(CreateLinkContactToAccountColumn());
			}
			if (Columns.FindByUId(new Guid("cd22b101-75d7-4647-b6cc-8dacb7487f68")) == null) {
				Columns.Add(CreateExportContactsAllColumn());
			}
			if (Columns.FindByUId(new Guid("2e26864f-596a-49bb-8d41-c927410a2e39")) == null) {
				Columns.Add(CreateExportContactsSelectedColumn());
			}
			if (Columns.FindByUId(new Guid("311dc25b-258c-47af-8aff-949acd7eaf98")) == null) {
				Columns.Add(CreateExportContactsEmployersColumn());
			}
			if (Columns.FindByUId(new Guid("0dd336e9-cad5-41b4-a02b-a605ff86c2d9")) == null) {
				Columns.Add(CreateExportContactsCustomersColumn());
			}
			if (Columns.FindByUId(new Guid("5133841f-df33-4778-affd-3a28294aa539")) == null) {
				Columns.Add(CreateExportContactsOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("3c4eae93-35b3-45fb-b1e0-60f5e40d3d10")) == null) {
				Columns.Add(CreateExportContactsFromGroupsColumn());
			}
			if (Columns.FindByUId(new Guid("8ecdb25f-287e-4e55-9a71-02a4a9a448fa")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("611c2f35-57df-4470-bce4-65e53971899f")) == null) {
				Columns.Add(CreateLastSyncDateColumn());
			}
			if (Columns.FindByUId(new Guid("9f5569be-0c50-43b3-926e-8dbb620d7ff4")) == null) {
				Columns.Add(CreateLoadContactsFromDateColumn());
			}
			if (Columns.FindByUId(new Guid("9dcb834a-5305-4d3d-89e6-b3542a13c37b")) == null) {
				Columns.Add(CreateExportContactsColumn());
			}
			if (Columns.FindByUId(new Guid("be18b76d-8843-4d5d-9dfd-9f47e3219a73")) == null) {
				Columns.Add(CreateImportContactsFoldersColumn());
			}
			if (Columns.FindByUId(new Guid("706e6b49-ac4e-45f4-8fe7-fc6831bbbfcb")) == null) {
				Columns.Add(CreateImportContactsCategoriesColumn());
			}
			if (Columns.FindByUId(new Guid("a1c38f1d-7ab1-4d2d-be76-ea8113437464")) == null) {
				Columns.Add(CreateExportContactsGroupsColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			column.CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73");
			return column;
		}

		protected virtual EntitySchemaColumn CreateImportContactsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1857d6cc-4dd8-4fe7-bb6c-764e36fbd401"),
				Name = @"ImportContacts",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateImportContactsAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3f303942-6360-4c68-be30-8e4dcdcd50ab"),
				Name = @"ImportContactsAll",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateImportContactsFromFoldersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fe5bb4b5-83d5-4bfa-9da3-b763d463e3f6"),
				Name = @"ImportContactsFromFolders",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateImportContactsFromCategoriesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8f2584c3-7d7d-41b1-afef-7c728f86d0af"),
				Name = @"ImportContactsFromCategories",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkContactToAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f19e212-b9f1-46ed-b867-65c019df259d"),
				Name = @"LinkContactToAccount",
				ReferenceSchemaUId = new Guid("8c1021cc-4836-4355-977e-f65c332d92be"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"3f59b466-3535-4bb2-b9b4-bca48b43fd38"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cd22b101-75d7-4647-b6cc-8dacb7487f68"),
				Name = @"ExportContactsAll",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsSelectedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2e26864f-596a-49bb-8d41-c927410a2e39"),
				Name = @"ExportContactsSelected",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsEmployersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("311dc25b-258c-47af-8aff-949acd7eaf98"),
				Name = @"ExportContactsEmployers",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsCustomersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0dd336e9-cad5-41b4-a02b-a605ff86c2d9"),
				Name = @"ExportContactsCustomers",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5133841f-df33-4778-affd-3a28294aa539"),
				Name = @"ExportContactsOwner",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsFromGroupsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3c4eae93-35b3-45fb-b1e0-60f5e40d3d10"),
				Name = @"ExportContactsFromGroups",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8ecdb25f-287e-4e55-9a71-02a4a9a448fa"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateLastSyncDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("611c2f35-57df-4470-bce4-65e53971899f"),
				Name = @"LastSyncDate",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			};
		}

		protected virtual EntitySchemaColumn CreateLoadContactsFromDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("9f5569be-0c50-43b3-926e-8dbb620d7ff4"),
				Name = @"LoadContactsFromDate",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9dcb834a-5305-4d3d-89e6-b3542a13c37b"),
				Name = @"ExportContacts",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("f4dad6d8-e90c-404a-81b9-255599719041")
			};
		}

		protected virtual EntitySchemaColumn CreateImportContactsFoldersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("be18b76d-8843-4d5d-9dfd-9f47e3219a73"),
				Name = @"ImportContactsFolders",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateImportContactsCategoriesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("706e6b49-ac4e-45f4-8fe7-fc6831bbbfcb"),
				Name = @"ImportContactsCategories",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected virtual EntitySchemaColumn CreateExportContactsGroupsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1c38f1d-7ab1-4d2d-be76-ea8113437464"),
				Name = @"ExportContactsGroups",
				CreatedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				ModifiedInSchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"),
				CreatedInPackageId = new Guid("43a72267-b2f6-464f-af52-bc7506959e73")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactSyncSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactSyncSettings_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactSyncSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactSyncSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactSyncSettings

	/// <summary>
	/// Contact synchronization settings.
	/// </summary>
	public class ContactSyncSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactSyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactSyncSettings";
		}

		public ContactSyncSettings(ContactSyncSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Import contacts.
		/// </summary>
		public bool ImportContacts {
			get {
				return GetTypedColumnValue<bool>("ImportContacts");
			}
			set {
				SetColumnValue("ImportContacts", value);
			}
		}

		/// <summary>
		/// Import all contacts.
		/// </summary>
		public bool ImportContactsAll {
			get {
				return GetTypedColumnValue<bool>("ImportContactsAll");
			}
			set {
				SetColumnValue("ImportContactsAll", value);
			}
		}

		/// <summary>
		/// Import contacts from folders.
		/// </summary>
		public bool ImportContactsFromFolders {
			get {
				return GetTypedColumnValue<bool>("ImportContactsFromFolders");
			}
			set {
				SetColumnValue("ImportContactsFromFolders", value);
			}
		}

		/// <summary>
		/// Import contacts from categories.
		/// </summary>
		public bool ImportContactsFromCategories {
			get {
				return GetTypedColumnValue<bool>("ImportContactsFromCategories");
			}
			set {
				SetColumnValue("ImportContactsFromCategories", value);
			}
		}

		/// <exclude/>
		public Guid LinkContactToAccountId {
			get {
				return GetTypedColumnValue<Guid>("LinkContactToAccountId");
			}
			set {
				SetColumnValue("LinkContactToAccountId", value);
				_linkContactToAccount = null;
			}
		}

		/// <exclude/>
		public string LinkContactToAccountName {
			get {
				return GetTypedColumnValue<string>("LinkContactToAccountName");
			}
			set {
				SetColumnValue("LinkContactToAccountName", value);
				if (_linkContactToAccount != null) {
					_linkContactToAccount.Name = value;
				}
			}
		}

		private LinkContactToAccount _linkContactToAccount;
		/// <summary>
		/// Connect contacts to accounts.
		/// </summary>
		public LinkContactToAccount LinkContactToAccount {
			get {
				return _linkContactToAccount ??
					(_linkContactToAccount = LookupColumnEntities.GetEntity("LinkContactToAccount") as LinkContactToAccount);
			}
		}

		/// <summary>
		/// Export all contacts.
		/// </summary>
		public bool ExportContactsAll {
			get {
				return GetTypedColumnValue<bool>("ExportContactsAll");
			}
			set {
				SetColumnValue("ExportContactsAll", value);
			}
		}

		/// <summary>
		/// Export selected contacts.
		/// </summary>
		public bool ExportContactsSelected {
			get {
				return GetTypedColumnValue<bool>("ExportContactsSelected");
			}
			set {
				SetColumnValue("ExportContactsSelected", value);
			}
		}

		/// <summary>
		/// Export employee contacts.
		/// </summary>
		public bool ExportContactsEmployers {
			get {
				return GetTypedColumnValue<bool>("ExportContactsEmployers");
			}
			set {
				SetColumnValue("ExportContactsEmployers", value);
			}
		}

		/// <summary>
		/// Export customer contacts.
		/// </summary>
		public bool ExportContactsCustomers {
			get {
				return GetTypedColumnValue<bool>("ExportContactsCustomers");
			}
			set {
				SetColumnValue("ExportContactsCustomers", value);
			}
		}

		/// <summary>
		/// Export my contacts.
		/// </summary>
		public bool ExportContactsOwner {
			get {
				return GetTypedColumnValue<bool>("ExportContactsOwner");
			}
			set {
				SetColumnValue("ExportContactsOwner", value);
			}
		}

		/// <summary>
		/// Export contacts from folders.
		/// </summary>
		public bool ExportContactsFromGroups {
			get {
				return GetTypedColumnValue<bool>("ExportContactsFromGroups");
			}
			set {
				SetColumnValue("ExportContactsFromGroups", value);
			}
		}

		/// <exclude/>
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		/// <summary>
		/// LastSyncDate.
		/// </summary>
		public DateTime LastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("LastSyncDate");
			}
			set {
				SetColumnValue("LastSyncDate", value);
			}
		}

		/// <summary>
		/// LoadContactsFromDate.
		/// </summary>
		public DateTime LoadContactsFromDate {
			get {
				return GetTypedColumnValue<DateTime>("LoadContactsFromDate");
			}
			set {
				SetColumnValue("LoadContactsFromDate", value);
			}
		}

		/// <summary>
		/// Export contacts.
		/// </summary>
		public bool ExportContacts {
			get {
				return GetTypedColumnValue<bool>("ExportContacts");
			}
			set {
				SetColumnValue("ExportContacts", value);
			}
		}

		/// <summary>
		/// Contact folders for import.
		/// </summary>
		public string ImportContactsFolders {
			get {
				return GetTypedColumnValue<string>("ImportContactsFolders");
			}
			set {
				SetColumnValue("ImportContactsFolders", value);
			}
		}

		/// <summary>
		/// Contact categories for import.
		/// </summary>
		public string ImportContactsCategories {
			get {
				return GetTypedColumnValue<string>("ImportContactsCategories");
			}
			set {
				SetColumnValue("ImportContactsCategories", value);
			}
		}

		/// <summary>
		/// Contact folders for export.
		/// </summary>
		public string ExportContactsGroups {
			get {
				return GetTypedColumnValue<string>("ExportContactsGroups");
			}
			set {
				SetColumnValue("ExportContactsGroups", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactSyncSettings_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactSyncSettingsDeleted", e);
			Inserting += (s, e) => ThrowEvent("ContactSyncSettingsInserting", e);
			Updating += (s, e) => ThrowEvent("ContactSyncSettingsUpdating", e);
			Validating += (s, e) => ThrowEvent("ContactSyncSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactSyncSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactSyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public partial class ContactSyncSettings_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactSyncSettings
	{

		public ContactSyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactSyncSettings_ExchangeEventsProcess";
			SchemaUId = new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9aba4e21-c6b8-46bc-8277-61daf4beac1a");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _updatingEventSubProcess;
		public ProcessFlowElement UpdatingEventSubProcess {
			get {
				return _updatingEventSubProcess ?? (_updatingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "UpdatingEventSubProcess",
					SchemaElementUId = new Guid("2cc57a23-ff6d-40ed-ae70-2b43060f03ea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactSyncSettingsUpdatingStartMessage;
		public ProcessFlowElement ContactSyncSettingsUpdatingStartMessage {
			get {
				return _contactSyncSettingsUpdatingStartMessage ?? (_contactSyncSettingsUpdatingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactSyncSettingsUpdatingStartMessage",
					SchemaElementUId = new Guid("c3361d18-e4e1-4450-bac6-6e1b9eb0d82c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _contactSyncSettingsUpdatingThrowMessage;
		public ProcessThrowMessageEvent ContactSyncSettingsUpdatingThrowMessage {
			get {
				return _contactSyncSettingsUpdatingThrowMessage ?? (_contactSyncSettingsUpdatingThrowMessage = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "ContactSyncSettingsUpdatingThrowMessage",
					SchemaElementUId = new Guid("57e8984f-1407-42e3-9e02-f24d3d8ddc8b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ContactSyncSettingsUpdating",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _contactSyncSettingsUpdatingScriptTask;
		public ProcessScriptTask ContactSyncSettingsUpdatingScriptTask {
			get {
				return _contactSyncSettingsUpdatingScriptTask ?? (_contactSyncSettingsUpdatingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ContactSyncSettingsUpdatingScriptTask",
					SchemaElementUId = new Guid("8dfa6675-3c34-4696-ab72-0a886cb07806"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ContactSyncSettingsUpdatingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[UpdatingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdatingEventSubProcess };
			FlowElements[ContactSyncSettingsUpdatingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSyncSettingsUpdatingStartMessage };
			FlowElements[ContactSyncSettingsUpdatingThrowMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSyncSettingsUpdatingThrowMessage };
			FlowElements[ContactSyncSettingsUpdatingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactSyncSettingsUpdatingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "UpdatingEventSubProcess":
						break;
					case "ContactSyncSettingsUpdatingStartMessage":
						e.Context.QueueTasks.Enqueue("ContactSyncSettingsUpdatingThrowMessage");
						break;
					case "ContactSyncSettingsUpdatingThrowMessage":
						e.Context.QueueTasks.Enqueue("ContactSyncSettingsUpdatingScriptTask");
						break;
					case "ContactSyncSettingsUpdatingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContactSyncSettingsUpdatingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "UpdatingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ContactSyncSettingsUpdatingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactSyncSettingsUpdatingStartMessage";
					result = ContactSyncSettingsUpdatingStartMessage.Execute(context);
					break;
				case "ContactSyncSettingsUpdatingThrowMessage":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "ContactSyncSettingsUpdating");
					result = ContactSyncSettingsUpdatingThrowMessage.Execute(context);
					break;
				case "ContactSyncSettingsUpdatingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactSyncSettingsUpdatingScriptTask";
					result = ContactSyncSettingsUpdatingScriptTask.Execute(context, ContactSyncSettingsUpdatingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ContactSyncSettingsUpdatingScriptTaskExecute(ProcessExecutingContext context) {
			foreach (EntityColumnValue value in Entity.GetChangedColumnValues()) {
				if (!value.Value.Equals(value.OldValue)) {
					Entity.SetColumnValue("LastSyncDate", null);
					return true;
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContactSyncSettingsUpdating":
							if (ActivatedEventElements.Contains("ContactSyncSettingsUpdatingStartMessage")) {
							context.QueueTasks.Enqueue("ContactSyncSettingsUpdatingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactSyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public class ContactSyncSettings_ExchangeEventsProcess : ContactSyncSettings_ExchangeEventsProcess<ContactSyncSettings>
	{

		public ContactSyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactSyncSettings_ExchangeEventsProcess

	public partial class ContactSyncSettings_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactSyncSettingsEventsProcess

	/// <exclude/>
	public class ContactSyncSettingsEventsProcess : ContactSyncSettings_ExchangeEventsProcess
	{

		public ContactSyncSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

