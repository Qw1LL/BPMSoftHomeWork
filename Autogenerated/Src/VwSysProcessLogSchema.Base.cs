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

	#region Class: VwSysProcessLogSchema

	/// <exclude/>
	public class VwSysProcessLogSchema : BPMSoft.Configuration.SysProcessLogSchema
	{

		#region Constructors: Public

		public VwSysProcessLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessLogSchema(VwSysProcessLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessLogSchema(VwSysProcessLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			RealUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			Name = "VwSysProcessLog";
			ParentSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8756e5fb-6161-4877-8b62-5a2786bca3ff")) == null) {
				Columns.Add(CreateArchivedColumn());
			}
			if (Columns.FindByUId(new Guid("a1918e8a-f2e6-4394-921a-17adb901e8aa")) == null) {
				Columns.Add(CreateDurationInSecondsColumn());
			}
			if (Columns.FindByUId(new Guid("2db6540c-a7ae-4091-9abb-2e0969442fd6")) == null) {
				Columns.Add(CreateHasTraceDataColumn());
			}
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			return column;
		}

		protected virtual EntitySchemaColumn CreateArchivedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8756e5fb-6161-4877-8b62-5a2786bca3ff"),
				Name = @"Archived",
				CreatedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				ModifiedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInSecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("a1918e8a-f2e6-4394-921a-17adb901e8aa"),
				Name = @"DurationInSeconds",
				CreatedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				ModifiedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHasTraceDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2db6540c-a7ae-4091-9abb-2e0969442fd6"),
				Name = @"HasTraceData",
				CreatedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				ModifiedInSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
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
			return new VwSysProcessLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessLog

	/// <summary>
	/// Process log.
	/// </summary>
	public class VwSysProcessLog : BPMSoft.Configuration.SysProcessLog
	{

		#region Constructors: Public

		public VwSysProcessLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessLog";
		}

		public VwSysProcessLog(VwSysProcessLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Archived.
		/// </summary>
		public bool Archived {
			get {
				return GetTypedColumnValue<bool>("Archived");
			}
			set {
				SetColumnValue("Archived", value);
			}
		}

		/// <summary>
		/// Duration, seconds.
		/// </summary>
		public Decimal DurationInSeconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInSeconds");
			}
			set {
				SetColumnValue("DurationInSeconds", value);
			}
		}

		/// <summary>
		/// Trace data available.
		/// </summary>
		public bool HasTraceData {
			get {
				return GetTypedColumnValue<bool>("HasTraceData");
			}
			set {
				SetColumnValue("HasTraceData", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessLogDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcessLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessLog_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysProcessLog_PRMPortalEventsProcess<TEntity> where TEntity : VwSysProcessLog
	{

		public VwSysProcessLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessLog_BaseEventsProcess";
			SchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b");
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

	#region Class: VwSysProcessLog_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcessLog_BaseEventsProcess : VwSysProcessLog_BaseEventsProcess<VwSysProcessLog>
	{

		public VwSysProcessLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessLog_BaseEventsProcess

	public partial class VwSysProcessLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessLogEventsProcess

	/// <exclude/>
	public class VwSysProcessLogEventsProcess : VwSysProcessLog_BaseEventsProcess
	{

		public VwSysProcessLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

