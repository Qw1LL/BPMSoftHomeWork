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

	#region Class: SysPrcEntityHistorySchema

	/// <exclude/>
	public class SysPrcEntityHistorySchema : BPMSoft.Configuration.SysBaseProcessEntitySchema
	{

		#region Constructors: Public

		public SysPrcEntityHistorySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcEntityHistorySchema(SysPrcEntityHistorySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcEntityHistorySchema(SysPrcEntityHistorySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			RealUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			Name = "SysPrcEntityHistory";
			ParentSchemaUId = new Guid("60a89d9d-9ede-4d78-97b9-5e20373db518");
			ExtendParent = false;
			CreatedInPackageId = new Guid("db484552-1edf-492e-83ab-076c107943f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f72f4a90-4d85-4337-bdfe-45ef7904c759")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f72f4a90-4d85-4337-bdfe-45ef7904c759"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("c8cd120d-c91b-4104-bad0-88b1b892a49d"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"),
				ModifiedInSchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"),
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
			return new SysPrcEntityHistory(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcEntityHistory_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcEntityHistorySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcEntityHistorySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcEntityHistory

	/// <summary>
	/// System process entity history.
	/// </summary>
	public class SysPrcEntityHistory : BPMSoft.Configuration.SysBaseProcessEntity
	{

		#region Constructors: Public

		public SysPrcEntityHistory(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcEntityHistory";
		}

		public SysPrcEntityHistory(SysPrcEntityHistory source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysPrcHistoryLog _sysProcess;
		/// <summary>
		/// Process.
		/// </summary>
		public SysPrcHistoryLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysPrcHistoryLog);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcEntityHistory_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcEntityHistoryDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcEntityHistory(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcEntityHistory_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcEntityHistory_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysBaseProcessEntity_BaseEventsProcess<TEntity> where TEntity : SysPrcEntityHistory
	{

		public SysPrcEntityHistory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcEntityHistory_BaseEventsProcess";
			SchemaUId = new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3ff70cac-48aa-48e2-9b39-76952e10a18e");
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

	#region Class: SysPrcEntityHistory_BaseEventsProcess

	/// <exclude/>
	public class SysPrcEntityHistory_BaseEventsProcess : SysPrcEntityHistory_BaseEventsProcess<SysPrcEntityHistory>
	{

		public SysPrcEntityHistory_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcEntityHistory_BaseEventsProcess

	public partial class SysPrcEntityHistory_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcEntityHistoryEventsProcess

	/// <exclude/>
	public class SysPrcEntityHistoryEventsProcess : SysPrcEntityHistory_BaseEventsProcess
	{

		public SysPrcEntityHistoryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

