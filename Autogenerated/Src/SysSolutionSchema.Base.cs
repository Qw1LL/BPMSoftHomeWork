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

	#region Class: SysSolutionSchema

	/// <exclude/>
	[IsVirtual]
	public class SysSolutionSchema : BPMSoft.Configuration.BaseHierarchicalLookupSchema
	{

		#region Constructors: Public

		public SysSolutionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSolutionSchema(SysSolutionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSolutionSchema(SysSolutionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			RealUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			Name = "SysSolution";
			ParentSchemaUId = new Guid("5a39bd7c-8880-456c-aaf7-7645ce114e62");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7bd91b1e-0531-4218-b184-1f1d32d732b4")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("c914c21e-af08-4360-874f-b9b21db2765f")) == null) {
				Columns.Add(CreateAssemblyDataColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			return column;
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7bd91b1e-0531-4218-b184-1f1d32d732b4"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb"),
				ModifiedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected virtual EntitySchemaColumn CreateAssemblyDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("c914c21e-af08-4360-874f-b9b21db2765f"),
				Name = @"AssemblyData",
				CreatedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb"),
				ModifiedInSchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb"),
				CreatedInPackageId = new Guid("773ffacd-4a58-4934-8cb2-5bf23386d08f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSolution(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSolution_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSolutionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSolutionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("98897199-8e6a-4863-bbf4-5507820eeedb"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSolution

	/// <summary>
	/// Resolution.
	/// </summary>
	public class SysSolution : BPMSoft.Configuration.BaseHierarchicalLookup
	{

		#region Constructors: Public

		public SysSolution(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSolution";
		}

		public SysSolution(SysSolution source)
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

		private SysSolution _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysSolution Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysSolution);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSolution_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSolutionDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSolutionDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSolutionInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSolutionInserting", e);
			Saved += (s, e) => ThrowEvent("SysSolutionSaved", e);
			Saving += (s, e) => ThrowEvent("SysSolutionSaving", e);
			Validating += (s, e) => ThrowEvent("SysSolutionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSolution(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSolution_BaseEventsProcess

	/// <exclude/>
	public partial class SysSolution_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseHierarchicalLookup_BaseEventsProcess<TEntity> where TEntity : SysSolution
	{

		public SysSolution_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSolution_BaseEventsProcess";
			SchemaUId = new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("98897199-8e6a-4863-bbf4-5507820eeedb");
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

	#region Class: SysSolution_BaseEventsProcess

	/// <exclude/>
	public class SysSolution_BaseEventsProcess : SysSolution_BaseEventsProcess<SysSolution>
	{

		public SysSolution_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSolution_BaseEventsProcess

	public partial class SysSolution_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSolutionEventsProcess

	/// <exclude/>
	public class SysSolutionEventsProcess : SysSolution_BaseEventsProcess
	{

		public SysSolutionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

