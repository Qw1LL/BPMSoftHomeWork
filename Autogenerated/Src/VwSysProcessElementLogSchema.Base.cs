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

	#region Class: VwSysProcessElementLogSchema

	/// <exclude/>
	public class VwSysProcessElementLogSchema : BPMSoft.Configuration.SysBasePrcElLogSchema
	{

		#region Constructors: Public

		public VwSysProcessElementLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysProcessElementLogSchema(VwSysProcessElementLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysProcessElementLogSchema(VwSysProcessElementLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4");
			RealUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4");
			Name = "VwSysProcessElementLog";
			ParentSchemaUId = new Guid("293f3c3a-0dfb-4677-aa00-ac2a2628eaab");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1dfa8b22-74a5-4663-a6c1-86686ebac382")) == null) {
				Columns.Add(CreateArchivedColumn());
			}
			if (Columns.FindByUId(new Guid("c52e6f01-bc34-4072-9694-7790f58a47b2")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
			if (Columns.FindByUId(new Guid("8f641a97-3b61-45a3-8438-612e757dd014")) == null) {
				Columns.Add(CreateHasTraceDataColumn());
			}
			if (Columns.FindByUId(new Guid("ea779696-5e24-4b01-82ec-4b87c9541dc0")) == null) {
				Columns.Add(CreateDurationInSecondsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateArchivedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1dfa8b22-74a5-4663-a6c1-86686ebac382"),
				Name = @"Archived",
				CreatedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				ModifiedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c52e6f01-bc34-4072-9694-7790f58a47b2"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("9db2a9f8-c736-4323-b8de-55371bf53f6b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				ModifiedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateHasTraceDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8f641a97-3b61-45a3-8438-612e757dd014"),
				Name = @"HasTraceData",
				CreatedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				ModifiedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInSecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("ea779696-5e24-4b01-82ec-4b87c9541dc0"),
				Name = @"DurationInSeconds",
				CreatedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
				ModifiedInSchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"),
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
			return new VwSysProcessElementLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysProcessElementLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysProcessElementLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysProcessElementLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessElementLog

	/// <summary>
	/// Process items log.
	/// </summary>
	public class VwSysProcessElementLog : BPMSoft.Configuration.SysBasePrcElLog
	{

		#region Constructors: Public

		public VwSysProcessElementLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysProcessElementLog";
		}

		public VwSysProcessElementLog(VwSysProcessElementLog source)
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

		private VwSysProcessLog _sysProcess;
		/// <summary>
		/// Process instance.
		/// </summary>
		public VwSysProcessLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as VwSysProcessLog);
			}
		}

		/// <summary>
		/// Trace data exists.
		/// </summary>
		public bool HasTraceData {
			get {
				return GetTypedColumnValue<bool>("HasTraceData");
			}
			set {
				SetColumnValue("HasTraceData", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysProcessElementLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysProcessElementLogDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysProcessElementLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysProcessElementLog_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysProcessElementLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysBasePrcElLog_BaseEventsProcess<TEntity> where TEntity : VwSysProcessElementLog
	{

		public VwSysProcessElementLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysProcessElementLog_BaseEventsProcess";
			SchemaUId = new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5d3f02cf-a6d8-4352-ad7f-1610697d7dd4");
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

	#region Class: VwSysProcessElementLog_BaseEventsProcess

	/// <exclude/>
	public class VwSysProcessElementLog_BaseEventsProcess : VwSysProcessElementLog_BaseEventsProcess<VwSysProcessElementLog>
	{

		public VwSysProcessElementLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysProcessElementLog_BaseEventsProcess

	public partial class VwSysProcessElementLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysProcessElementLogEventsProcess

	/// <exclude/>
	public class VwSysProcessElementLogEventsProcess : VwSysProcessElementLog_BaseEventsProcess
	{

		public VwSysProcessElementLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

