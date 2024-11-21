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

	#region Class: VwSysAdminUnitHierarchySchema

	/// <exclude/>
	public class VwSysAdminUnitHierarchySchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysAdminUnitHierarchySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysAdminUnitHierarchySchema(VwSysAdminUnitHierarchySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysAdminUnitHierarchySchema(VwSysAdminUnitHierarchySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28");
			RealUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28");
			Name = "VwSysAdminUnitHierarchy";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b31766a4-96b7-4991-b612-90571fbfed5c")) == null) {
				Columns.Add(CreateNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("90d96804-4e57-4940-982e-3a5164e29f6a"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28"),
				ModifiedInSchemaUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b31766a4-96b7-4991-b612-90571fbfed5c"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28"),
				ModifiedInSchemaUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysAdminUnitHierarchy(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysAdminUnitHierarchy_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysAdminUnitHierarchySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysAdminUnitHierarchySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnitHierarchy

	/// <summary>
	/// Administration object hierarchy.
	/// </summary>
	public class VwSysAdminUnitHierarchy : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysAdminUnitHierarchy(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysAdminUnitHierarchy";
		}

		public VwSysAdminUnitHierarchy(VwSysAdminUnitHierarchy source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysAdminUnitHierarchy_BaseEventsProcess(UserConnection);
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
			return new VwSysAdminUnitHierarchy(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysAdminUnitHierarchy_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysAdminUnitHierarchy_BaseEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwSysAdminUnitHierarchy
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwSysAdminUnitHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysAdminUnitHierarchy_BaseEventsProcess";
			SchemaUId = new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0390aba6-ca67-4e53-9479-e0867c41eb28");
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

	#region Class: VwSysAdminUnitHierarchy_BaseEventsProcess

	/// <exclude/>
	public class VwSysAdminUnitHierarchy_BaseEventsProcess : VwSysAdminUnitHierarchy_BaseEventsProcess<VwSysAdminUnitHierarchy>
	{

		public VwSysAdminUnitHierarchy_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysAdminUnitHierarchy_BaseEventsProcess

	public partial class VwSysAdminUnitHierarchy_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysAdminUnitHierarchyEventsProcess

	/// <exclude/>
	public class VwSysAdminUnitHierarchyEventsProcess : VwSysAdminUnitHierarchy_BaseEventsProcess
	{

		public VwSysAdminUnitHierarchyEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

