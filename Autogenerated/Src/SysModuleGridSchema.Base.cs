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

	#region Class: SysModuleGridSchema

	/// <exclude/>
	public class SysModuleGridSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleGridSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleGridSchema(SysModuleGridSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleGridSchema(SysModuleGridSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148");
			RealUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148");
			Name = "SysModuleGrid";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b7706795-9fcb-4283-8b48-bcea32f005b0")) == null) {
				Columns.Add(CreateSysModuleEntityColumn());
			}
			if (Columns.FindByUId(new Guid("1bf5bab3-a2b0-40a0-b866-a0918fbd80dc")) == null) {
				Columns.Add(CreateHasAllItemsViewColumn());
			}
			if (Columns.FindByUId(new Guid("8424da7b-c749-49b5-bd3f-d1e9547b85d5")) == null) {
				Columns.Add(CreateSysPageSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b7706795-9fcb-4283-8b48-bcea32f005b0"),
				Name = @"SysModuleEntity",
				ReferenceSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				CreatedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				ModifiedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateHasAllItemsViewColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1bf5bab3-a2b0-40a0-b866-a0918fbd80dc"),
				Name = @"HasAllItemsView",
				CreatedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				ModifiedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysPageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("8424da7b-c749-49b5-bd3f-d1e9547b85d5"),
				Name = @"SysPageSchemaUId",
				CreatedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
				ModifiedInSchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148"),
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
			return new SysModuleGrid(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleGrid_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleGridSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleGridSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("98540489-9681-4140-9fdb-9a19eb53c148"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGrid

	/// <summary>
	/// Section list.
	/// </summary>
	public class SysModuleGrid : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleGrid(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleGrid";
		}

		public SysModuleGrid(SysModuleGrid source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// Section object.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = LookupColumnEntities.GetEntity("SysModuleEntity") as SysModuleEntity);
			}
		}

		/// <summary>
		/// Show view &quot;All&quot;.
		/// </summary>
		public bool HasAllItemsView {
			get {
				return GetTypedColumnValue<bool>("HasAllItemsView");
			}
			set {
				SetColumnValue("HasAllItemsView", value);
			}
		}

		/// <summary>
		/// Unique identifier of list page.
		/// </summary>
		public Guid SysPageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysPageSchemaUId");
			}
			set {
				SetColumnValue("SysPageSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleGrid_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleGridDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysModuleGridDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysModuleGridInserted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleGridInserting", e);
			Saved += (s, e) => ThrowEvent("SysModuleGridSaved", e);
			Saving += (s, e) => ThrowEvent("SysModuleGridSaving", e);
			Validating += (s, e) => ThrowEvent("SysModuleGridValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleGrid(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleGrid_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleGrid_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleGrid
	{

		public SysModuleGrid_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleGrid_BaseEventsProcess";
			SchemaUId = new Guid("98540489-9681-4140-9fdb-9a19eb53c148");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("98540489-9681-4140-9fdb-9a19eb53c148");
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

	#region Class: SysModuleGrid_BaseEventsProcess

	/// <exclude/>
	public class SysModuleGrid_BaseEventsProcess : SysModuleGrid_BaseEventsProcess<SysModuleGrid>
	{

		public SysModuleGrid_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleGrid_BaseEventsProcess

	public partial class SysModuleGrid_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleGridEventsProcess

	/// <exclude/>
	public class SysModuleGridEventsProcess : SysModuleGrid_BaseEventsProcess
	{

		public SysModuleGridEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

