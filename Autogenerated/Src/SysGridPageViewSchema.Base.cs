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

	#region Class: SysGridPageViewSchema

	/// <exclude/>
	public class SysGridPageViewSchema : BPMSoft.Configuration.BaseHierarchicalLookupSchema
	{

		#region Constructors: Public

		public SysGridPageViewSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysGridPageViewSchema(SysGridPageViewSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysGridPageViewSchema(SysGridPageViewSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			RealUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			Name = "SysGridPageView";
			ParentSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("47cd7475-20e2-40f3-8afa-c76617d5be63")) == null) {
				Columns.Add(CreateSysGridPageColumn());
			}
			if (Columns.FindByUId(new Guid("a9765746-1acf-4ac4-8db1-8915bfb25a63")) == null) {
				Columns.Add(CreateDataSourceFilterCodeColumn());
			}
			if (Columns.FindByUId(new Guid("79130bc5-dee6-4370-8fc5-febefedbe87d")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("fe570165-a7aa-486d-a674-7c65804eebe1")) == null) {
				Columns.Add(CreateSysStoringStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysGridPageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("47cd7475-20e2-40f3-8afa-c76617d5be63"),
				Name = @"SysGridPage",
				ReferenceSchemaUId = new Guid("d19658bd-987d-4cd5-9006-0e9d6edc9104"),
				CreatedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDataSourceFilterCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a9765746-1acf-4ac4-8db1-8915bfb25a63"),
				Name = @"DataSourceFilterCode",
				CreatedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("79130bc5-dee6-4370-8fc5-febefedbe87d"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysStoringStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fe570165-a7aa-486d-a674-7c65804eebe1"),
				Name = @"SysStoringState",
				ReferenceSchemaUId = new Guid("e4fa976c-9880-4a93-b3ad-50ea19d5d807"),
				CreatedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1cff82ae-b8bf-4dc2-b68f-2cb4c2fb72b8"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
				ModifiedInSchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"),
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
			return new SysGridPageView(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysGridPageView_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysGridPageViewSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysGridPageViewSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020"));
		}

		#endregion

	}

	#endregion

	#region Class: SysGridPageView

	/// <summary>
	/// List view list.
	/// </summary>
	public class SysGridPageView : BPMSoft.Configuration.BaseHierarchicalLookup
	{

		#region Constructors: Public

		public SysGridPageView(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysGridPageView";
		}

		public SysGridPageView(SysGridPageView source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private SysGridPageView _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysGridPageView Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysGridPageView);
			}
		}

		/// <exclude/>
		public Guid SysGridPageId {
			get {
				return GetTypedColumnValue<Guid>("SysGridPageId");
			}
			set {
				SetColumnValue("SysGridPageId", value);
				_sysGridPage = null;
			}
		}

		private SysGridPage _sysGridPage;
		/// <summary>
		/// List page.
		/// </summary>
		public SysGridPage SysGridPage {
			get {
				return _sysGridPage ??
					(_sysGridPage = LookupColumnEntities.GetEntity("SysGridPage") as SysGridPage);
			}
		}

		/// <summary>
		/// Filter code.
		/// </summary>
		public string DataSourceFilterCode {
			get {
				return GetTypedColumnValue<string>("DataSourceFilterCode");
			}
			set {
				SetColumnValue("DataSourceFilterCode", value);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <exclude/>
		public Guid SysStoringStateId {
			get {
				return GetTypedColumnValue<Guid>("SysStoringStateId");
			}
			set {
				SetColumnValue("SysStoringStateId", value);
				_sysStoringState = null;
			}
		}

		/// <exclude/>
		public string SysStoringStateName {
			get {
				return GetTypedColumnValue<string>("SysStoringStateName");
			}
			set {
				SetColumnValue("SysStoringStateName", value);
				if (_sysStoringState != null) {
					_sysStoringState.Name = value;
				}
			}
		}

		private SysStoringObjectState _sysStoringState;
		/// <summary>
		/// Status.
		/// </summary>
		public SysStoringObjectState SysStoringState {
			get {
				return _sysStoringState ??
					(_sysStoringState = LookupColumnEntities.GetEntity("SysStoringState") as SysStoringObjectState);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysGridPageView_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysGridPageViewDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysGridPageViewDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysGridPageViewInserted", e);
			Inserting += (s, e) => ThrowEvent("SysGridPageViewInserting", e);
			Saved += (s, e) => ThrowEvent("SysGridPageViewSaved", e);
			Saving += (s, e) => ThrowEvent("SysGridPageViewSaving", e);
			Validating += (s, e) => ThrowEvent("SysGridPageViewValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysGridPageView(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysGridPageView_BaseEventsProcess

	/// <exclude/>
	public partial class SysGridPageView_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseHierarchicalLookup_BaseEventsProcess<TEntity> where TEntity : SysGridPageView
	{

		public SysGridPageView_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysGridPageView_BaseEventsProcess";
			SchemaUId = new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ed5075ee-1bd8-4783-8deb-39ec149dc020");
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

	#region Class: SysGridPageView_BaseEventsProcess

	/// <exclude/>
	public class SysGridPageView_BaseEventsProcess : SysGridPageView_BaseEventsProcess<SysGridPageView>
	{

		public SysGridPageView_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysGridPageView_BaseEventsProcess

	public partial class SysGridPageView_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysGridPageViewEventsProcess

	/// <exclude/>
	public class SysGridPageViewEventsProcess : SysGridPageView_BaseEventsProcess
	{

		public SysGridPageViewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

