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

	#region Class: SysProcessElementDataSchema

	/// <exclude/>
	public class SysProcessElementDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessElementDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessElementDataSchema(SysProcessElementDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessElementDataSchema(SysProcessElementDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIeGV46q92Yh7YpRPv9rviUBKJ8PsIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("a3065856-f8c9-4635-be60-0192d88c7b87");
			index.Name = "IeGV46q92Yh7YpRPv9rviUBKJ8Ps";
			index.CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			index.ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn sysProcessIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2f2df186-8df9-489d-a65e-40822d09f1ad"),
				ColumnUId = new Guid("939fbb3e-2b0d-45d8-b980-a4e75813d6c8"),
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysProcessIdIndexColumn);
			EntitySchemaIndexColumn schemaElementUIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("3920d4a6-dd1f-4e25-ac6a-4f55534fa6dd"),
				ColumnUId = new Guid("e7255940-a6ee-43c1-9d19-fa9241fbe43d"),
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(schemaElementUIdIndexColumn);
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("c933e7f8-3ea1-4e14-bce2-347e5b37d0a8"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			RealUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			Name = "SysProcessElementData";
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e7255940-a6ee-43c1-9d19-fa9241fbe43d")) == null) {
				Columns.Add(CreateSchemaElementUIdColumn());
			}
			if (Columns.FindByUId(new Guid("939fbb3e-2b0d-45d8-b980-a4e75813d6c8")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
			if (Columns.FindByUId(new Guid("0c7ef153-853a-4bae-a7cd-3d6b398eedc3")) == null) {
				Columns.Add(CreatePropertiesDataColumn());
			}
			if (Columns.FindByUId(new Guid("d4602173-b946-4053-a06d-78386878e03d")) == null) {
				Columns.Add(CreateSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("f0c0d1fa-4763-42bb-9db8-87197b368d8e")) == null) {
				Columns.Add(CreateStatusColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
			};
			column.ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.IsIndexed = false;
			column.ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSchemaElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e7255940-a6ee-43c1-9d19-fa9241fbe43d"),
				Name = @"SchemaElementUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("939fbb3e-2b0d-45d8-b980-a4e75813d6c8"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("35db7a28-0df7-4ec9-9019-02ab1b2d9954"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePropertiesDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("0c7ef153-853a-4bae-a7cd-3d6b398eedc3"),
				Name = @"PropertiesData",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c4495418-3856-4b45-9bff-193c21560c41"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d4602173-b946-4053-a06d-78386878e03d"),
				Name = @"SchemaUId",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("6ea8707e-10c3-4269-8547-de023eaaca13")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f0c0d1fa-4763-42bb-9db8-87197b368d8e"),
				Name = @"Status",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				ModifiedInSchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIeGV46q92Yh7YpRPv9rviUBKJ8PsIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessElementData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessElementData_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessElementDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessElementDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementData

	/// <summary>
	/// Process item data.
	/// </summary>
	public class SysProcessElementData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessElementData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessElementData";
		}

		public SysProcessElementData(SysProcessElementData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		private SysProcessData _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysProcessData SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysProcessData);
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
		/// Schema.
		/// </summary>
		public Guid SchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaUId");
			}
			set {
				SetColumnValue("SchemaUId", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessElementData_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessElementDataDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysProcessElementDataDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysProcessElementDataInserted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessElementDataInserting", e);
			Saved += (s, e) => ThrowEvent("SysProcessElementDataSaved", e);
			Saving += (s, e) => ThrowEvent("SysProcessElementDataSaving", e);
			Validating += (s, e) => ThrowEvent("SysProcessElementDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessElementData(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementData_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessElementData_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessElementData
	{

		public SysProcessElementData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessElementData_BaseEventsProcess";
			SchemaUId = new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a195aa99-8c5b-47e0-a9a6-9bac0ddd5bd0");
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

	#region Class: SysProcessElementData_BaseEventsProcess

	/// <exclude/>
	public class SysProcessElementData_BaseEventsProcess : SysProcessElementData_BaseEventsProcess<SysProcessElementData>
	{

		public SysProcessElementData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessElementData_BaseEventsProcess

	public partial class SysProcessElementData_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessElementDataEventsProcess

	/// <exclude/>
	public class SysProcessElementDataEventsProcess : SysProcessElementData_BaseEventsProcess
	{

		public SysProcessElementDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

