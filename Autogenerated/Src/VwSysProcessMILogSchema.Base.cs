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

	#region Class: VwSysProcessMILogSchema

	/// <exclude/>
	public class VwSysProcessMILogSchema : BPMSoft.Configuration.VwSysProcessLogSchema
	{

		#region Constructors: Public

		public VwSysProcessMILogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessMILogSchema(VwSysProcessMILogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessMILogSchema(VwSysProcessMILogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
			RealUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
			Name = "VwSysProcessMILog";
			ParentSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b4d75afd-57cb-44b7-a6db-b075f9b33795");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d6c888e9-0010-49a2-ad85-3b7871521aec")) == null) {
				Columns.Add(CreateIteratorElementColumn());
			}
			if (Columns.FindByUId(new Guid("9f30408a-2321-4c1c-aa3f-ac7ce58088c9")) == null) {
				Columns.Add(CreateIterationNumberColumn());
			}
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIteratorElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d6c888e9-0010-49a2-ad85-3b7871521aec"),
				Name = @"IteratorElement",
				ReferenceSchemaUId = new Guid("be731fb7-87ab-479b-a188-37175a60b813"),
				IsIndexed = true,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e"),
				ModifiedInSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateIterationNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9f30408a-2321-4c1c-aa3f-ac7ce58088c9"),
				Name = @"IterationNumber",
				CreatedInSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e"),
				ModifiedInSchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysProcessMILog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessMILog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessMILogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessMILogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessMILog

	/// <summary>
	/// Process multi instance log.
	/// </summary>
	public class VwSysProcessMILog : BPMSoft.Configuration.VwSysProcessLog
	{

		#region Constructors: Public

		public VwSysProcessMILog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessMILog";
		}

		public VwSysProcessMILog(VwSysProcessMILog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid IteratorElementId {
			get {
				return GetTypedColumnValue<Guid>("IteratorElementId");
			}
			set {
				SetColumnValue("IteratorElementId", value);
				_iteratorElement = null;
			}
		}

		private SysPrcSchemaElement _iteratorElement;
		/// <summary>
		/// IteratorElement.
		/// </summary>
		public SysPrcSchemaElement IteratorElement {
			get {
				return _iteratorElement ??
					(_iteratorElement = LookupColumnEntities.GetEntity("IteratorElement") as SysPrcSchemaElement);
			}
		}

		/// <summary>
		/// Iteration.
		/// </summary>
		public int IterationNumber {
			get {
				return GetTypedColumnValue<int>("IterationNumber");
			}
			set {
				SetColumnValue("IterationNumber", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessMILog_BaseEventsProcess(UserConnection);
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
			return new VwSysProcessMILog(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessMILog_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessMILog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.VwSysProcessLog_BaseEventsProcess<TEntity> where TEntity : VwSysProcessMILog
	{

		public VwSysProcessMILog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessMILog_BaseEventsProcess";
			SchemaUId = new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ad8a1a3-1c8b-44b3-8a1d-f9bac60fb56e");
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

	#region Class: VwSysProcessMILog_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcessMILog_BaseEventsProcess : VwSysProcessMILog_BaseEventsProcess<VwSysProcessMILog>
	{

		public VwSysProcessMILog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessMILog_BaseEventsProcess

	public partial class VwSysProcessMILog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessMILogEventsProcess

	/// <exclude/>
	public class VwSysProcessMILogEventsProcess : VwSysProcessMILog_BaseEventsProcess
	{

		public VwSysProcessMILogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

