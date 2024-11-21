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

	#region Class: VwSSPSysAdminUnitSchema

	/// <exclude/>
	public class VwSSPSysAdminUnitSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public VwSSPSysAdminUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSSPSysAdminUnitSchema(VwSSPSysAdminUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSSPSysAdminUnitSchema(VwSSPSysAdminUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			RealUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			Name = "VwSSPSysAdminUnit";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentRoleColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ef7430aa-ef07-49b9-81f2-bbb571383276")) == null) {
				Columns.Add(CreateSysAdminUnitTypeValueColumn());
			}
			if (Columns.FindByUId(new Guid("bc884e13-7c48-47c4-a7c3-cca07d49637c")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("cb5e30e1-88a5-4e56-bdf5-8ac5b923eb81")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("147f727d-8727-49c8-a8a8-7940e7d041de")) == null) {
				Columns.Add(CreateIsDirectoryEntryColumn());
			}
			if (Columns.FindByUId(new Guid("152f4f27-7c72-4900-aec1-800c29c25054")) == null) {
				Columns.Add(CreateTimeZoneIdColumn());
			}
			if (Columns.FindByUId(new Guid("84224e12-b439-4acc-a7bc-dfab0376499d")) == null) {
				Columns.Add(CreateUserPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("95a71407-8d12-4be1-b68a-0be00d656410")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("ac3048f6-5669-4cc0-aee1-d97ecd8b8c36")) == null) {
				Columns.Add(CreateSynchronizeWithLDAPColumn());
			}
			if (Columns.FindByUId(new Guid("7ab8be01-fbeb-4349-9a58-862822584bcc")) == null) {
				Columns.Add(CreateLDAPEntryColumn());
			}
			if (Columns.FindByUId(new Guid("8a57f744-d0d8-4ed7-a6fb-33fe1a947949")) == null) {
				Columns.Add(CreateLDAPEntryIdColumn());
			}
			if (Columns.FindByUId(new Guid("88703249-cb90-48eb-84f3-bea0a61235ab")) == null) {
				Columns.Add(CreateLDAPEntryDNColumn());
			}
			if (Columns.FindByUId(new Guid("101cbc07-7abd-46dc-8753-3dd33f7b900f")) == null) {
				Columns.Add(CreateLoggedInColumn());
			}
			if (Columns.FindByUId(new Guid("ce54b0a2-0416-4960-8a29-b0a6bb5a1149")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("079955c0-9132-4cde-b162-5c932c01ce67")) == null) {
				Columns.Add(CreateLoginAttemptCountColumn());
			}
			if (Columns.FindByUId(new Guid("67f67dca-c733-4194-9226-4b07206b5729")) == null) {
				Columns.Add(CreateSourceControlLoginColumn());
			}
			if (Columns.FindByUId(new Guid("5208d7fa-179f-4db7-b674-434bbaed2c4e")) == null) {
				Columns.Add(CreateSourceControlPasswordColumn());
			}
			if (Columns.FindByUId(new Guid("08a549a5-cf3d-4931-9e93-db478f97046a")) == null) {
				Columns.Add(CreatePasswordExpireDateColumn());
			}
			if (Columns.FindByUId(new Guid("38c9ef28-0900-458c-849c-d38784445961")) == null) {
				Columns.Add(CreateHomePageColumn());
			}
			if (Columns.FindByUId(new Guid("7796b084-9060-4d7b-b64e-f008508e6878")) == null) {
				Columns.Add(CreateConnectionTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.IsLocalizable = false;
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitTypeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ef7430aa-ef07-49b9-81f2-bbb571383276"),
				Name = @"SysAdminUnitTypeValue",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateParentRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80350a28-2287-47c7-b0e7-c8af5a248d4a"),
				Name = @"ParentRole",
				ReferenceSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bc884e13-7c48-47c4-a7c3-cca07d49637c"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cb5e30e1-88a5-4e56-bdf5-8ac5b923eb81"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDirectoryEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("147f727d-8727-49c8-a8a8-7940e7d041de"),
				Name = @"IsDirectoryEntry",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("152f4f27-7c72-4900-aec1-800c29c25054"),
				Name = @"TimeZoneId",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateUserPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("HashText")) {
				UId = new Guid("84224e12-b439-4acc-a7bc-dfab0376499d"),
				Name = @"UserPassword",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("95a71407-8d12-4be1-b68a-0be00d656410"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSynchronizeWithLDAPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ac3048f6-5669-4cc0-aee1-d97ecd8b8c36"),
				Name = @"SynchronizeWithLDAP",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7ab8be01-fbeb-4349-9a58-862822584bcc"),
				Name = @"LDAPEntry",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8a57f744-d0d8-4ed7-a6fb-33fe1a947949"),
				Name = @"LDAPEntryId",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateLDAPEntryDNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("88703249-cb90-48eb-84f3-bea0a61235ab"),
				Name = @"LDAPEntryDN",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateLoggedInColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("101cbc07-7abd-46dc-8753-3dd33f7b900f"),
				Name = @"LoggedIn",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ce54b0a2-0416-4960-8a29-b0a6bb5a1149"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCulture"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLoginAttemptCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("079955c0-9132-4cde-b162-5c932c01ce67"),
				Name = @"LoginAttemptCount",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceControlLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("67f67dca-c733-4194-9226-4b07206b5729"),
				Name = @"SourceControlLogin",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateSourceControlPasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("SecureText")) {
				UId = new Guid("5208d7fa-179f-4db7-b674-434bbaed2c4e"),
				Name = @"SourceControlPassword",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordExpireDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("08a549a5-cf3d-4931-9e93-db478f97046a"),
				Name = @"PasswordExpireDate",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateHomePageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("38c9ef28-0900-458c-849c-d38784445961"),
				Name = @"HomePage",
				ReferenceSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7796b084-9060-4d7b-b64e-f008508e6878"),
				Name = @"ConnectionType",
				CreatedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				ModifiedInSchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSSPSysAdminUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSSPSysAdminUnit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSSPSysAdminUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSSPSysAdminUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f1216816-1e84-4057-8803-1710de78c14c"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSSPSysAdminUnit

	/// <summary>
	/// Portal user (view).
	/// </summary>
	public class VwSSPSysAdminUnit : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public VwSSPSysAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSSPSysAdminUnit";
		}

		public VwSSPSysAdminUnit(VwSSPSysAdminUnit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type.
		/// </summary>
		public int SysAdminUnitTypeValue {
			get {
				return GetTypedColumnValue<int>("SysAdminUnitTypeValue");
			}
			set {
				SetColumnValue("SysAdminUnitTypeValue", value);
			}
		}

		/// <exclude/>
		public Guid ParentRoleId {
			get {
				return GetTypedColumnValue<Guid>("ParentRoleId");
			}
			set {
				SetColumnValue("ParentRoleId", value);
				_parentRole = null;
			}
		}

		/// <exclude/>
		public string ParentRoleName {
			get {
				return GetTypedColumnValue<string>("ParentRoleName");
			}
			set {
				SetColumnValue("ParentRoleName", value);
				if (_parentRole != null) {
					_parentRole.Name = value;
				}
			}
		}

		private VwSSPSysAdminUnit _parentRole;
		/// <summary>
		/// Inherited from.
		/// </summary>
		public VwSSPSysAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = LookupColumnEntities.GetEntity("ParentRole") as VwSSPSysAdminUnit);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Employee.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <summary>
		/// Domain user.
		/// </summary>
		public bool IsDirectoryEntry {
			get {
				return GetTypedColumnValue<bool>("IsDirectoryEntry");
			}
			set {
				SetColumnValue("IsDirectoryEntry", value);
			}
		}

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string UserPassword {
			get {
				return GetTypedColumnValue<string>("UserPassword");
			}
			set {
				SetColumnValue("UserPassword", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <summary>
		/// Synchronize with LDAP.
		/// </summary>
		public bool SynchronizeWithLDAP {
			get {
				return GetTypedColumnValue<bool>("SynchronizeWithLDAP");
			}
			set {
				SetColumnValue("SynchronizeWithLDAP", value);
			}
		}

		/// <summary>
		/// LDAP element.
		/// </summary>
		public string LDAPEntry {
			get {
				return GetTypedColumnValue<string>("LDAPEntry");
			}
			set {
				SetColumnValue("LDAPEntry", value);
			}
		}

		/// <summary>
		/// LDAP element Id.
		/// </summary>
		public string LDAPEntryId {
			get {
				return GetTypedColumnValue<string>("LDAPEntryId");
			}
			set {
				SetColumnValue("LDAPEntryId", value);
			}
		}

		/// <summary>
		/// LDAP element unique name.
		/// </summary>
		public string LDAPEntryDN {
			get {
				return GetTypedColumnValue<string>("LDAPEntryDN");
			}
			set {
				SetColumnValue("LDAPEntryDN", value);
			}
		}

		/// <summary>
		/// Logged in now.
		/// </summary>
		public bool LoggedIn {
			get {
				return GetTypedColumnValue<bool>("LoggedIn");
			}
			set {
				SetColumnValue("LoggedIn", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Number of logon attempts.
		/// </summary>
		public int LoginAttemptCount {
			get {
				return GetTypedColumnValue<int>("LoginAttemptCount");
			}
			set {
				SetColumnValue("LoginAttemptCount", value);
			}
		}

		/// <summary>
		/// Repository login.
		/// </summary>
		public string SourceControlLogin {
			get {
				return GetTypedColumnValue<string>("SourceControlLogin");
			}
			set {
				SetColumnValue("SourceControlLogin", value);
			}
		}

		/// <summary>
		/// Repository password.
		/// </summary>
		public string SourceControlPassword {
			get {
				return GetTypedColumnValue<string>("SourceControlPassword");
			}
			set {
				SetColumnValue("SourceControlPassword", value);
			}
		}

		/// <summary>
		/// Password expiration date.
		/// </summary>
		public DateTime PasswordExpireDate {
			get {
				return GetTypedColumnValue<DateTime>("PasswordExpireDate");
			}
			set {
				SetColumnValue("PasswordExpireDate", value);
			}
		}

		/// <exclude/>
		public Guid HomePageId {
			get {
				return GetTypedColumnValue<Guid>("HomePageId");
			}
			set {
				SetColumnValue("HomePageId", value);
				_homePage = null;
			}
		}

		/// <exclude/>
		public string HomePageCaption {
			get {
				return GetTypedColumnValue<string>("HomePageCaption");
			}
			set {
				SetColumnValue("HomePageCaption", value);
				if (_homePage != null) {
					_homePage.Caption = value;
				}
			}
		}

		private SysModule _homePage;
		/// <summary>
		/// Home page.
		/// </summary>
		public SysModule HomePage {
			get {
				return _homePage ??
					(_homePage = LookupColumnEntities.GetEntity("HomePage") as SysModule);
			}
		}

		/// <summary>
		/// Connection type.
		/// </summary>
		public int ConnectionType {
			get {
				return GetTypedColumnValue<int>("ConnectionType");
			}
			set {
				SetColumnValue("ConnectionType", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSSPSysAdminUnit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSSPSysAdminUnitDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwSSPSysAdminUnitInserting", e);
			Validating += (s, e) => ThrowEvent("VwSSPSysAdminUnitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSSPSysAdminUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSSPSysAdminUnit_BaseEventsProcess

	/// <exclude/>
	public partial class VwSSPSysAdminUnit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : VwSSPSysAdminUnit
	{

		public VwSSPSysAdminUnit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSSPSysAdminUnit_BaseEventsProcess";
			SchemaUId = new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f1216816-1e84-4057-8803-1710de78c14c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwSSPSysAdminUnit_BaseEventsProcess

	/// <exclude/>
	public class VwSSPSysAdminUnit_BaseEventsProcess : VwSSPSysAdminUnit_BaseEventsProcess<VwSSPSysAdminUnit>
	{

		public VwSSPSysAdminUnit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSSPSysAdminUnit_BaseEventsProcess

	public partial class VwSSPSysAdminUnit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: VwSSPSysAdminUnitEventsProcess

	/// <exclude/>
	public class VwSSPSysAdminUnitEventsProcess : VwSSPSysAdminUnit_BaseEventsProcess
	{

		public VwSSPSysAdminUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

