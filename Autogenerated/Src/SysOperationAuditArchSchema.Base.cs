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

	#region Class: SysOperationAuditArchSchema

	/// <exclude/>
	public class SysOperationAuditArchSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysOperationAuditArchSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysOperationAuditArchSchema(SysOperationAuditArchSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysOperationAuditArchSchema(SysOperationAuditArchSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			RealUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			Name = "SysOperationAuditArch";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateClientIPColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aa6999c4-0a5e-4013-ba29-78dbd6bfcb0d")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d62f7a30-6130-4496-9c2a-ecca64cfd7c8")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("c8a2e079-b969-49bf-a572-2c3ece20dd9b")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("19f4d83d-045c-492b-85d5-aede10046819")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("a1e9811a-a1c2-4dc6-be08-a34ec5ffe9ab")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			column.CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("aa6999c4-0a5e-4013-ba29-78dbd6bfcb0d"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d62f7a30-6130-4496-9c2a-ecca64cfd7c8"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c8a2e079-b969-49bf-a572-2c3ece20dd9b"),
				Name = @"Result",
				ReferenceSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("19f4d83d-045c-492b-85d5-aede10046819"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bea6436e-911d-4aec-bbf7-d9cd48d1c903"),
				Name = @"ClientIP",
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a1e9811a-a1c2-4dc6-be08-a34ec5ffe9ab"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				ModifiedInSchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysOperationAuditArch(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysOperationAuditArch_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysOperationAuditArchSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysOperationAuditArchSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7"));
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAuditArch

	/// <summary>
	/// Archive of system operations audit log.
	/// </summary>
	public class SysOperationAuditArch : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysOperationAuditArch(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysOperationAuditArch";
		}

		public SysOperationAuditArch(SysOperationAuditArch source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private SysOperationType _type;
		/// <summary>
		/// Event type.
		/// </summary>
		public SysOperationType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysOperationType);
			}
		}

		/// <summary>
		/// Event date.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid ResultId {
			get {
				return GetTypedColumnValue<Guid>("ResultId");
			}
			set {
				SetColumnValue("ResultId", value);
				_result = null;
			}
		}

		/// <exclude/>
		public string ResultName {
			get {
				return GetTypedColumnValue<string>("ResultName");
			}
			set {
				SetColumnValue("ResultName", value);
				if (_result != null) {
					_result.Name = value;
				}
			}
		}

		private SysOperationResult _result;
		/// <summary>
		/// Event result.
		/// </summary>
		public SysOperationResult Result {
			get {
				return _result ??
					(_result = LookupColumnEntities.GetEntity("Result") as SysOperationResult);
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
		/// IP address.
		/// </summary>
		public string ClientIP {
			get {
				return GetTypedColumnValue<string>("ClientIP");
			}
			set {
				SetColumnValue("ClientIP", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysOperationAuditArch_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysOperationAuditArchDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysOperationAuditArchInserting", e);
			Loading += (s, e) => ThrowEvent("SysOperationAuditArchLoading", e);
			Validating += (s, e) => ThrowEvent("SysOperationAuditArchValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysOperationAuditArch(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAuditArch_BaseEventsProcess

	/// <exclude/>
	public partial class SysOperationAuditArch_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysOperationAuditArch
	{

		public SysOperationAuditArch_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysOperationAuditArch_BaseEventsProcess";
			SchemaUId = new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ad2cf340-cf67-4694-b1ab-a07d163420a7");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _sysOperationAuditArchEventSubProcess;
		public ProcessFlowElement SysOperationAuditArchEventSubProcess {
			get {
				return _sysOperationAuditArchEventSubProcess ?? (_sysOperationAuditArchEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysOperationAuditArchEventSubProcess",
					SchemaElementUId = new Guid("7e1be344-1e91-4c1e-8d5e-af7caa35a7b8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysOperationAuditArchLoadingStartMessage;
		public ProcessFlowElement BaseSysOperationAuditArchLoadingStartMessage {
			get {
				return _baseSysOperationAuditArchLoadingStartMessage ?? (_baseSysOperationAuditArchLoadingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysOperationAuditArchLoadingStartMessage",
					SchemaElementUId = new Guid("e2c89e03-cff3-45fc-9284-e0dc66b2f3e3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysOperationAuditArchChekCanRightScriptTask;
		public ProcessScriptTask SysOperationAuditArchChekCanRightScriptTask {
			get {
				return _sysOperationAuditArchChekCanRightScriptTask ?? (_sysOperationAuditArchChekCanRightScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysOperationAuditArchChekCanRightScriptTask",
					SchemaElementUId = new Guid("ce323912-8fa6-47bd-ada3-c5993bd005a2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysOperationAuditArchChekCanRightScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysOperationAuditArchEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysOperationAuditArchEventSubProcess };
			FlowElements[BaseSysOperationAuditArchLoadingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysOperationAuditArchLoadingStartMessage };
			FlowElements[SysOperationAuditArchChekCanRightScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysOperationAuditArchChekCanRightScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysOperationAuditArchEventSubProcess":
						break;
					case "BaseSysOperationAuditArchLoadingStartMessage":
						e.Context.QueueTasks.Enqueue("SysOperationAuditArchChekCanRightScriptTask");
						break;
					case "SysOperationAuditArchChekCanRightScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseSysOperationAuditArchLoadingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysOperationAuditArchEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseSysOperationAuditArchLoadingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysOperationAuditArchLoadingStartMessage";
					result = BaseSysOperationAuditArchLoadingStartMessage.Execute(context);
					break;
				case "SysOperationAuditArchChekCanRightScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysOperationAuditArchChekCanRightScriptTask";
					result = SysOperationAuditArchChekCanRightScriptTask.Execute(context, SysOperationAuditArchChekCanRightScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysOperationAuditArchChekCanRightScriptTaskExecute(ProcessExecutingContext context) {
			CheckCanViewSysOperationAudit();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysOperationAuditArchLoading":
							if (ActivatedEventElements.Contains("BaseSysOperationAuditArchLoadingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysOperationAuditArchLoadingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAuditArch_BaseEventsProcess

	/// <exclude/>
	public class SysOperationAuditArch_BaseEventsProcess : SysOperationAuditArch_BaseEventsProcess<SysOperationAuditArch>
	{

		public SysOperationAuditArch_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysOperationAuditArch_BaseEventsProcess

	public partial class SysOperationAuditArch_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckCanViewSysOperationAudit() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanViewSysOperationAudit");
		}

		#endregion

	}

	#endregion


	#region Class: SysOperationAuditArchEventsProcess

	/// <exclude/>
	public class SysOperationAuditArchEventsProcess : SysOperationAuditArch_BaseEventsProcess
	{

		public SysOperationAuditArchEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

