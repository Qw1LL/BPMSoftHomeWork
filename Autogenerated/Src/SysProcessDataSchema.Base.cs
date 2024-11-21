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

	#region Class: SysProcessDataSchema

	/// <exclude/>
	public class SysProcessDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessDataSchema(SysProcessDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessDataSchema(SysProcessDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIwASsJpZRQMic2g2i0kJO77YPx4Index() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("d4c8e45f-a17b-472d-b37d-94a227b8debc");
			index.Name = "IwASsJpZRQMic2g2i0kJO77YPx4";
			index.CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			index.ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("75021314-355a-4356-b6c4-d05301b11200"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			EntitySchemaIndexColumn schemaElementUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("f5c0604e-4efd-4fae-bf61-0a69e6ff59f7"),
				ColumnUId = new Guid("e2e5f9a4-7291-4ceb-ba3b-e38fb3b42d7d"),
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(schemaElementUIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			RealUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			Name = "SysProcessData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
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

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("bdaec6dd-fa17-4438-96af-474e692b7774")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("0a18dab1-9f46-4422-a1a0-76a8fe63a531")) == null) {
				Columns.Add(CreatePropertiesDataColumn());
			}
			if (Columns.FindByUId(new Guid("6e56371b-fd89-4209-9687-b04390feb8e4")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("e2e5f9a4-7291-4ceb-ba3b-e38fb3b42d7d")) == null) {
				Columns.Add(CreateSchemaElementUIdColumn());
			}
			if (Columns.FindByUId(new Guid("decee029-f11d-0343-c2b9-f24a42bb7cb7")) == null) {
				Columns.Add(CreateDataVersionColumn());
			}
			if (Columns.FindByUId(new Guid("f5323258-739b-b33f-c863-a97d509ae4c7")) == null) {
				Columns.Add(CreateWorkflowStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
			};
			column.ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bdaec6dd-fa17-4438-96af-474e692b7774"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1f72ebb7-3d38-4c1b-8c06-988c1343d9c7"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("67aea5ed-2170-41fd-8328-ffc91f8b6d07"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePropertiesDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("0a18dab1-9f46-4422-a1a0-76a8fe63a531"),
				Name = @"PropertiesData",
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("6e56371b-fd89-4209-9687-b04390feb8e4"),
				Name = @"Status",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e2e5f9a4-7291-4ceb-ba3b-e38fb3b42d7d"),
				Name = @"SchemaElementUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDataVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("decee029-f11d-0343-c2b9-f24a42bb7cb7"),
				Name = @"DataVersion",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkflowStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("f5323258-739b-b33f-c863-a97d509ae4c7"),
				Name = @"WorkflowState",
				CreatedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				ModifiedInSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIwASsJpZRQMic2g2i0kJO77YPx4Index());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessData_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessData

	/// <summary>
	/// Process data.
	/// </summary>
	public class SysProcessData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessData";
		}

		public SysProcessData(SysProcessData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Process schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
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

		private SysProcessData _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysProcessData Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysProcessData);
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

		/// <summary>
		/// Execution state.
		/// </summary>
		public int Status {
			get {
				return GetTypedColumnValue<int>("Status");
			}
			set {
				SetColumnValue("Status", value);
			}
		}

		/// <summary>
		/// Diagram item.
		/// </summary>
		public Guid SchemaElementUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaElementUId");
			}
			set {
				SetColumnValue("SchemaElementUId", value);
			}
		}

		/// <summary>
		/// Data version.
		/// </summary>
		public int DataVersion {
			get {
				return GetTypedColumnValue<int>("DataVersion");
			}
			set {
				SetColumnValue("DataVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessData_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessDataDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessDataDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessDataInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessDataInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessDataSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessDataSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessData(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessData_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessData_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessData
	{

		public SysProcessData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessData_BaseEventsProcess";
			SchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954");
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

	#region Class: SysProcessData_BaseEventsProcess

	/// <exclude/>
	public class SysProcessData_BaseEventsProcess : SysProcessData_BaseEventsProcess<SysProcessData>
	{

		public SysProcessData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessData_BaseEventsProcess

	public partial class SysProcessData_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessDataEventsProcess

	/// <exclude/>
	public class SysProcessDataEventsProcess : SysProcessData_BaseEventsProcess
	{

		public SysProcessDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

