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

	#region Class: SysOperationAuditSchema

	/// <exclude/>
	public class SysOperationAuditSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysOperationAuditSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysOperationAuditSchema(SysOperationAuditSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysOperationAuditSchema(SysOperationAuditSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			RealUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			Name = "SysOperationAudit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
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
			if (Columns.FindByUId(new Guid("ac32b7ac-2006-4789-9e8d-1e46436811a5")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("95d3ce80-8ed6-465a-9e57-0c9a8acf9f0e")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("bd277f78-c845-40cc-b686-7ea4bea1317f")) == null) {
				Columns.Add(CreateResultColumn());
			}
			if (Columns.FindByUId(new Guid("14260b25-ce7c-4d2f-a1e7-4788fe72af62")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("de44d071-4768-41f7-93d7-5b56260e1b15")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			column.CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("ac32b7ac-2006-4789-9e8d-1e46436811a5"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("95d3ce80-8ed6-465a-9e57-0c9a8acf9f0e"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("7a8084be-bb98-48f0-b227-bae6050a1a40"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bd277f78-c845-40cc-b686-7ea4bea1317f"),
				Name = @"Result",
				ReferenceSchemaUId = new Guid("d13590dc-314e-4edc-a2c2-7db0e82e672e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("14260b25-ce7c-4d2f-a1e7-4788fe72af62"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateClientIPColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d98f99db-ab89-406d-abba-f406652f0e43"),
				Name = @"ClientIP",
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("de44d071-4768-41f7-93d7-5b56260e1b15"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				ModifiedInSchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysOperationAudit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysOperationAudit_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysOperationAuditSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysOperationAuditSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6"));
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAudit

	/// <summary>
	/// Audit log.
	/// </summary>
	public class SysOperationAudit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysOperationAudit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysOperationAudit";
		}

		public SysOperationAudit(SysOperationAudit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Type.
		/// </summary>
		public SysOperationType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as SysOperationType);
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
		/// Result.
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
			var process = new SysOperationAudit_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysOperationAuditDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysOperationAuditInserting", e);
			Loading += (s, e) => ThrowEvent("SysOperationAuditLoading", e);
			Validating += (s, e) => ThrowEvent("SysOperationAuditValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysOperationAudit(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAudit_BaseEventsProcess

	/// <exclude/>
	public partial class SysOperationAudit_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysOperationAudit
	{

		public SysOperationAudit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysOperationAudit_BaseEventsProcess";
			SchemaUId = new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1685a98f-d6cc-4c1b-bcdc-c38145963ae6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _sysOperationAuditEventSubProcess;
		public ProcessFlowElement SysOperationAuditEventSubProcess {
			get {
				return _sysOperationAuditEventSubProcess ?? (_sysOperationAuditEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SysOperationAuditEventSubProcess",
					SchemaElementUId = new Guid("ffc3697f-ed26-44fd-9241-5788ba8fe049"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseSysOperationAuditLoadingStartMessage;
		public ProcessFlowElement BaseSysOperationAuditLoadingStartMessage {
			get {
				return _baseSysOperationAuditLoadingStartMessage ?? (_baseSysOperationAuditLoadingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseSysOperationAuditLoadingStartMessage",
					SchemaElementUId = new Guid("2e208d63-0110-4cd1-805e-d797ed287705"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _sysOperationAuditChekCanRightScriptTask;
		public ProcessScriptTask SysOperationAuditChekCanRightScriptTask {
			get {
				return _sysOperationAuditChekCanRightScriptTask ?? (_sysOperationAuditChekCanRightScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SysOperationAuditChekCanRightScriptTask",
					SchemaElementUId = new Guid("3c74ec06-8480-4e14-ad0d-ac6e3e7bd302"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SysOperationAuditChekCanRightScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SysOperationAuditEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SysOperationAuditEventSubProcess };
			FlowElements[BaseSysOperationAuditLoadingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseSysOperationAuditLoadingStartMessage };
			FlowElements[SysOperationAuditChekCanRightScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SysOperationAuditChekCanRightScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SysOperationAuditEventSubProcess":
						break;
					case "BaseSysOperationAuditLoadingStartMessage":
						e.Context.QueueTasks.Enqueue("SysOperationAuditChekCanRightScriptTask");
						break;
					case "SysOperationAuditChekCanRightScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseSysOperationAuditLoadingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SysOperationAuditEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseSysOperationAuditLoadingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseSysOperationAuditLoadingStartMessage";
					result = BaseSysOperationAuditLoadingStartMessage.Execute(context);
					break;
				case "SysOperationAuditChekCanRightScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysOperationAuditChekCanRightScriptTask";
					result = SysOperationAuditChekCanRightScriptTask.Execute(context, SysOperationAuditChekCanRightScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SysOperationAuditChekCanRightScriptTaskExecute(ProcessExecutingContext context) {
			CheckCanViewSysOperationAudit();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysOperationAuditLoading":
							if (ActivatedEventElements.Contains("BaseSysOperationAuditLoadingStartMessage")) {
							context.QueueTasks.Enqueue("BaseSysOperationAuditLoadingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysOperationAudit_BaseEventsProcess

	/// <exclude/>
	public class SysOperationAudit_BaseEventsProcess : SysOperationAudit_BaseEventsProcess<SysOperationAudit>
	{

		public SysOperationAudit_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysOperationAudit_BaseEventsProcess

	public partial class SysOperationAudit_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckCanViewSysOperationAudit() {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanViewSysOperationAudit");
		}

		#endregion

	}

	#endregion


	#region Class: SysOperationAuditEventsProcess

	/// <exclude/>
	public class SysOperationAuditEventsProcess : SysOperationAudit_BaseEventsProcess
	{

		public SysOperationAuditEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

