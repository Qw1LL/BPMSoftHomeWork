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

	#region Class: SysPrcElementTraceLogSchema

	/// <exclude/>
	public class SysPrcElementTraceLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPrcElementTraceLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPrcElementTraceLogSchema(SysPrcElementTraceLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPrcElementTraceLogSchema(SysPrcElementTraceLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5");
			RealUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5");
			Name = "SysPrcElementTraceLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2c390fe5-a97d-4685-b004-24cbfad1f54a")) == null) {
				Columns.Add(CreateTraceEventColumn());
			}
			if (Columns.FindByUId(new Guid("56bbd4ec-cb97-4d31-a065-aac2da13ee67")) == null) {
				Columns.Add(CreateElementDataColumn());
			}
			if (Columns.FindByUId(new Guid("60aefb0c-1625-4a6f-a736-dc7316e31d7e")) == null) {
				Columns.Add(CreateProcessDataColumn());
			}
			if (Columns.FindByUId(new Guid("9edc97a6-c8aa-41b3-a75c-4f027858f0d4")) == null) {
				Columns.Add(CreateSysProcessElementLogColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTraceEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("2c390fe5-a97d-4685-b004-24cbfad1f54a"),
				Name = @"TraceEvent",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				ModifiedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d")
			};
		}

		protected virtual EntitySchemaColumn CreateElementDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("56bbd4ec-cb97-4d31-a065-aac2da13ee67"),
				Name = @"ElementData",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				ModifiedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("60aefb0c-1625-4a6f-a736-dc7316e31d7e"),
				Name = @"ProcessData",
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				ModifiedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessElementLogColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9edc97a6-c8aa-41b3-a75c-4f027858f0d4"),
				Name = @"SysProcessElementLog",
				ReferenceSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
				ModifiedInSchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"),
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
			return new SysPrcElementTraceLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPrcElementTraceLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPrcElementTraceLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPrcElementTraceLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcElementTraceLog

	/// <summary>
	/// SysPrcElementTraceLog.
	/// </summary>
	public class SysPrcElementTraceLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPrcElementTraceLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPrcElementTraceLog";
		}

		public SysPrcElementTraceLog(SysPrcElementTraceLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// TraceEvent.
		/// </summary>
		public int TraceEvent {
			get {
				return GetTypedColumnValue<int>("TraceEvent");
			}
			set {
				SetColumnValue("TraceEvent", value);
			}
		}

		/// <summary>
		/// ElementData.
		/// </summary>
		public string ElementData {
			get {
				return GetTypedColumnValue<string>("ElementData");
			}
			set {
				SetColumnValue("ElementData", value);
			}
		}

		/// <summary>
		/// ProcessData.
		/// </summary>
		public string ProcessData {
			get {
				return GetTypedColumnValue<string>("ProcessData");
			}
			set {
				SetColumnValue("ProcessData", value);
			}
		}

		/// <exclude/>
		public Guid SysProcessElementLogId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessElementLogId");
			}
			set {
				SetColumnValue("SysProcessElementLogId", value);
				_sysProcessElementLog = null;
			}
		}

		/// <exclude/>
		public string SysProcessElementLogCaption {
			get {
				return GetTypedColumnValue<string>("SysProcessElementLogCaption");
			}
			set {
				SetColumnValue("SysProcessElementLogCaption", value);
				if (_sysProcessElementLog != null) {
					_sysProcessElementLog.Caption = value;
				}
			}
		}

		private SysProcessElementLog _sysProcessElementLog;
		/// <summary>
		/// SysProcessElementLog.
		/// </summary>
		public SysProcessElementLog SysProcessElementLog {
			get {
				return _sysProcessElementLog ??
					(_sysProcessElementLog = LookupColumnEntities.GetEntity("SysProcessElementLog") as SysProcessElementLog);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPrcElementTraceLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPrcElementTraceLogDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPrcElementTraceLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPrcElementTraceLog_BaseEventsProcess

	/// <exclude/>
	public partial class SysPrcElementTraceLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPrcElementTraceLog
	{

		public SysPrcElementTraceLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPrcElementTraceLog_BaseEventsProcess";
			SchemaUId = new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("330bb874-aa5d-4449-887d-fe649f89f9e5");
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

	#region Class: SysPrcElementTraceLog_BaseEventsProcess

	/// <exclude/>
	public class SysPrcElementTraceLog_BaseEventsProcess : SysPrcElementTraceLog_BaseEventsProcess<SysPrcElementTraceLog>
	{

		public SysPrcElementTraceLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPrcElementTraceLog_BaseEventsProcess

	public partial class SysPrcElementTraceLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPrcElementTraceLogEventsProcess

	/// <exclude/>
	public class SysPrcElementTraceLogEventsProcess : SysPrcElementTraceLog_BaseEventsProcess
	{

		public SysPrcElementTraceLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

