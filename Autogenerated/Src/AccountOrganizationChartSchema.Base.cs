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

	#region Class: AccountOrganizationChartSchema

	/// <exclude/>
	public class AccountOrganizationChartSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AccountOrganizationChartSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountOrganizationChartSchema(AccountOrganizationChartSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountOrganizationChartSchema(AccountOrganizationChartSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4");
			RealUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4");
			Name = "AccountOrganizationChart";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
			RightSchemaName = @"SysAccountOrgChartRight";
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCustomDepartmentNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ad047738-5932-4583-a0cf-20fac6df579a")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("22add15e-3272-43bd-8e2d-9c2bca1724dc")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("d0c2ab3b-4608-4e73-9912-28836d2546af")) == null) {
				Columns.Add(CreateManagerColumn());
			}
			if (Columns.FindByUId(new Guid("c9b351ce-90b8-407f-985c-aa416f25df04")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad047738-5932-4583-a0cf-20fac6df579a"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCustomDepartmentNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5964887b-fe21-4176-ac49-0a7eac8aeb71"),
				Name = @"CustomDepartmentName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("22add15e-3272-43bd-8e2d-9c2bca1724dc"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d0c2ab3b-4608-4e73-9912-28836d2546af"),
				Name = @"Manager",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c9b351ce-90b8-407f-985c-aa416f25df04"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d5a9b3b4-04ef-46b7-b58e-3922daada1ec"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				ModifiedInSchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountOrganizationChart(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountOrganizationChart_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountOrganizationChartSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountOrganizationChartSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountOrganizationChart

	/// <summary>
	/// Account organizational structure.
	/// </summary>
	public class AccountOrganizationChart : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AccountOrganizationChart(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountOrganizationChart";
		}

		public AccountOrganizationChart(AccountOrganizationChart source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Division.
		/// </summary>
		public string CustomDepartmentName {
			get {
				return GetTypedColumnValue<string>("CustomDepartmentName");
			}
			set {
				SetColumnValue("CustomDepartmentName", value);
			}
		}

		/// <exclude/>
		public Guid DepartmentId {
			get {
				return GetTypedColumnValue<Guid>("DepartmentId");
			}
			set {
				SetColumnValue("DepartmentId", value);
				_department = null;
			}
		}

		/// <exclude/>
		public string DepartmentName {
			get {
				return GetTypedColumnValue<string>("DepartmentName");
			}
			set {
				SetColumnValue("DepartmentName", value);
				if (_department != null) {
					_department.Name = value;
				}
			}
		}

		private Department _department;
		/// <summary>
		/// Department.
		/// </summary>
		public Department Department {
			get {
				return _department ??
					(_department = LookupColumnEntities.GetEntity("Department") as Department);
			}
		}

		/// <exclude/>
		public Guid ManagerId {
			get {
				return GetTypedColumnValue<Guid>("ManagerId");
			}
			set {
				SetColumnValue("ManagerId", value);
				_manager = null;
			}
		}

		/// <exclude/>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
				if (_manager != null) {
					_manager.Name = value;
				}
			}
		}

		private Contact _manager;
		/// <summary>
		/// Manager.
		/// </summary>
		public Contact Manager {
			get {
				return _manager ??
					(_manager = LookupColumnEntities.GetEntity("Manager") as Contact);
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
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentCustomDepartmentName {
			get {
				return GetTypedColumnValue<string>("ParentCustomDepartmentName");
			}
			set {
				SetColumnValue("ParentCustomDepartmentName", value);
				if (_parent != null) {
					_parent.CustomDepartmentName = value;
				}
			}
		}

		private AccountOrganizationChart _parent;
		/// <summary>
		/// Part of.
		/// </summary>
		public AccountOrganizationChart Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as AccountOrganizationChart);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountOrganizationChart_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountOrganizationChartDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountOrganizationChartDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountOrganizationChartInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountOrganizationChartInserting", e);
			Saved += (s, e) => ThrowEvent("AccountOrganizationChartSaved", e);
			Saving += (s, e) => ThrowEvent("AccountOrganizationChartSaving", e);
			Validating += (s, e) => ThrowEvent("AccountOrganizationChartValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountOrganizationChart(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountOrganizationChart_BaseEventsProcess

	/// <exclude/>
	public partial class AccountOrganizationChart_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AccountOrganizationChart
	{

		public AccountOrganizationChart_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountOrganizationChart_BaseEventsProcess";
			SchemaUId = new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa59be08-4036-420d-87ab-288d21ae2ed4");
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

	#region Class: AccountOrganizationChart_BaseEventsProcess

	/// <exclude/>
	public class AccountOrganizationChart_BaseEventsProcess : AccountOrganizationChart_BaseEventsProcess<AccountOrganizationChart>
	{

		public AccountOrganizationChart_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountOrganizationChart_BaseEventsProcess

	public partial class AccountOrganizationChart_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AccountOrganizationChartEventsProcess

	/// <exclude/>
	public class AccountOrganizationChartEventsProcess : AccountOrganizationChart_BaseEventsProcess
	{

		public AccountOrganizationChartEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

