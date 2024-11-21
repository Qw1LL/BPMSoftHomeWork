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

	#region Class: VwSspAdminUnitSchema

	/// <exclude/>
	public class VwSspAdminUnitSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSspAdminUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSspAdminUnitSchema(VwSspAdminUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSspAdminUnitSchema(VwSspAdminUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e");
			RealUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e");
			Name = "VwSspAdminUnit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreatePortalAccountColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("93b4f121-8303-4ca9-95bb-93214e6641c9")) == null) {
				Columns.Add(CreateParentRoleColumn());
			}
			if (Columns.FindByUId(new Guid("1eed6bc9-e7b7-41ab-a018-45cd13f2ac13")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("79110c4e-3410-4c49-8242-76e05a188636")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("a74a6bba-86f1-4e06-b8a7-72d183edeae9")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("faee4395-d1f0-4f65-9c14-0726514211c5")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("759b3bd6-2f88-4005-9ab8-001879e8f2ca")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("84f48198-3703-4b68-93fa-a8b477abe655")) == null) {
				Columns.Add(CreateConnectionTypeColumn());
			}
			if (Columns.FindByUId(new Guid("310b2fcd-a22f-43b0-aa0f-703ca1295042")) == null) {
				Columns.Add(CreateSysAdminUnitTypeColumn());
			}
			if (Columns.FindByUId(new Guid("15df631f-2187-44f2-8e5f-83d9a1f145ba")) == null) {
				Columns.Add(CreateLicenseNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateParentRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("93b4f121-8303-4ca9-95bb-93214e6641c9"),
				Name = @"ParentRole",
				ReferenceSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b0726bf3-fef6-481b-acc7-c606de3410aa"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1eed6bc9-e7b7-41ab-a018-45cd13f2ac13"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("79110c4e-3410-4c49-8242-76e05a188636"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a74a6bba-86f1-4e06-b8a7-72d183edeae9"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("faee4395-d1f0-4f65-9c14-0726514211c5"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("759b3bd6-2f88-4005-9ab8-001879e8f2ca"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateConnectionTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("84f48198-3703-4b68-93fa-a8b477abe655"),
				Name = @"ConnectionType",
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreatePortalAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7020fc3-f013-4e81-a072-38b003e8fce2"),
				Name = @"PortalAccount",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("310b2fcd-a22f-43b0-aa0f-703ca1295042"),
				Name = @"SysAdminUnitType",
				ReferenceSchemaUId = new Guid("e58cf897-de3a-48fb-a0a2-38943bf0ad06"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected virtual EntitySchemaColumn CreateLicenseNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("15df631f-2187-44f2-8e5f-83d9a1f145ba"),
				Name = @"LicenseName",
				CreatedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				ModifiedInSchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"),
				CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSspAdminUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSspAdminUnit_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSspAdminUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSspAdminUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSspAdminUnit

	/// <summary>
	/// VwSspAdminUnit.
	/// </summary>
	public class VwSspAdminUnit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSspAdminUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSspAdminUnit";
		}

		public VwSspAdminUnit(VwSspAdminUnit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private VwSspAdminUnit _parentRole;
		/// <summary>
		/// Parent role.
		/// </summary>
		public VwSspAdminUnit ParentRole {
			get {
				return _parentRole ??
					(_parentRole = LookupColumnEntities.GetEntity("ParentRole") as VwSspAdminUnit);
			}
		}

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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
		/// Contact.
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

		/// <exclude/>
		public Guid PortalAccountId {
			get {
				return GetTypedColumnValue<Guid>("PortalAccountId");
			}
			set {
				SetColumnValue("PortalAccountId", value);
				_portalAccount = null;
			}
		}

		/// <exclude/>
		public string PortalAccountName {
			get {
				return GetTypedColumnValue<string>("PortalAccountName");
			}
			set {
				SetColumnValue("PortalAccountName", value);
				if (_portalAccount != null) {
					_portalAccount.Name = value;
				}
			}
		}

		private Account _portalAccount;
		/// <summary>
		/// Account.
		/// </summary>
		public Account PortalAccount {
			get {
				return _portalAccount ??
					(_portalAccount = LookupColumnEntities.GetEntity("PortalAccount") as Account);
			}
		}

		/// <exclude/>
		public Guid SysAdminUnitTypeId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitTypeId");
			}
			set {
				SetColumnValue("SysAdminUnitTypeId", value);
				_sysAdminUnitType = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitTypeName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitTypeName");
			}
			set {
				SetColumnValue("SysAdminUnitTypeName", value);
				if (_sysAdminUnitType != null) {
					_sysAdminUnitType.Name = value;
				}
			}
		}

		private SysAdminUnitType _sysAdminUnitType;
		/// <summary>
		/// Type.
		/// </summary>
		public SysAdminUnitType SysAdminUnitType {
			get {
				return _sysAdminUnitType ??
					(_sysAdminUnitType = LookupColumnEntities.GetEntity("SysAdminUnitType") as SysAdminUnitType);
			}
		}

		/// <summary>
		/// License name.
		/// </summary>
		public string LicenseName {
			get {
				return GetTypedColumnValue<string>("LicenseName");
			}
			set {
				SetColumnValue("LicenseName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSspAdminUnit_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSspAdminUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSspAdminUnit_SSPEventsProcess

	/// <exclude/>
	public partial class VwSspAdminUnit_SSPEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSspAdminUnit
	{

		public VwSspAdminUnit_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSspAdminUnit_SSPEventsProcess";
			SchemaUId = new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("83d6c406-8e3c-4ef3-ac23-522d7026aa4e");
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

	#region Class: VwSspAdminUnit_SSPEventsProcess

	/// <exclude/>
	public class VwSspAdminUnit_SSPEventsProcess : VwSspAdminUnit_SSPEventsProcess<VwSspAdminUnit>
	{

		public VwSspAdminUnit_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSspAdminUnit_SSPEventsProcess

	public partial class VwSspAdminUnit_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSspAdminUnitEventsProcess

	/// <exclude/>
	public class VwSspAdminUnitEventsProcess : VwSspAdminUnit_SSPEventsProcess
	{

		public VwSspAdminUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

