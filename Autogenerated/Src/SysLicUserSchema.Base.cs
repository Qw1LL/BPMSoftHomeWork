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

	#region Class: SysLicUserSchema

	/// <exclude/>
	public class SysLicUserSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLicUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLicUserSchema(SysLicUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLicUserSchema(SysLicUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f");
			RealUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f");
			Name = "SysLicUser";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("70baaf33-7ef6-430f-aa11-772b12f96cae")) == null) {
				Columns.Add(CreateSysLicPackageColumn());
			}
			if (Columns.FindByUId(new Guid("8e86eec6-d855-4730-a3c1-17ba27026f92")) == null) {
				Columns.Add(CreateSysUserColumn());
			}
			if (Columns.FindByUId(new Guid("5cb31d3d-5d2b-4e2f-a6c3-b7d55a6e0c03")) == null) {
				Columns.Add(CreateActiveColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysLicPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("70baaf33-7ef6-430f-aa11-772b12f96cae"),
				Name = @"SysLicPackage",
				ReferenceSchemaUId = new Guid("bba64ad2-ff65-46f4-911d-4068aa0af48a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				ModifiedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysUserColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8e86eec6-d855-4730-a3c1-17ba27026f92"),
				Name = @"SysUser",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				ModifiedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5cb31d3d-5d2b-4e2f-a6c3-b7d55a6e0c03"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				ModifiedInSchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLicUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLicUser_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLicUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLicUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLicUser

	/// <summary>
	/// User licenses.
	/// </summary>
	public class SysLicUser : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLicUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLicUser";
		}

		public SysLicUser(SysLicUser source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysLicPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysLicPackageId");
			}
			set {
				SetColumnValue("SysLicPackageId", value);
				_sysLicPackage = null;
			}
		}

		/// <exclude/>
		public string SysLicPackageName {
			get {
				return GetTypedColumnValue<string>("SysLicPackageName");
			}
			set {
				SetColumnValue("SysLicPackageName", value);
				if (_sysLicPackage != null) {
					_sysLicPackage.Name = value;
				}
			}
		}

		private SysLicPackage _sysLicPackage;
		/// <summary>
		/// Product.
		/// </summary>
		public SysLicPackage SysLicPackage {
			get {
				return _sysLicPackage ??
					(_sysLicPackage = LookupColumnEntities.GetEntity("SysLicPackage") as SysLicPackage);
			}
		}

		/// <exclude/>
		public Guid SysUserId {
			get {
				return GetTypedColumnValue<Guid>("SysUserId");
			}
			set {
				SetColumnValue("SysUserId", value);
				_sysUser = null;
			}
		}

		/// <exclude/>
		public string SysUserName {
			get {
				return GetTypedColumnValue<string>("SysUserName");
			}
			set {
				SetColumnValue("SysUserName", value);
				if (_sysUser != null) {
					_sysUser.Name = value;
				}
			}
		}

		private SysAdminUnit _sysUser;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysUser {
			get {
				return _sysUser ??
					(_sysUser = LookupColumnEntities.GetEntity("SysUser") as SysAdminUnit);
			}
		}

		/// <summary>
		/// License active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLicUser_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLicUserDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysLicUserDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysLicUserInserted", e);
			Inserting += (s, e) => ThrowEvent("SysLicUserInserting", e);
			Saved += (s, e) => ThrowEvent("SysLicUserSaved", e);
			Saving += (s, e) => ThrowEvent("SysLicUserSaving", e);
			Validating += (s, e) => ThrowEvent("SysLicUserValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLicUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLicUser_BaseEventsProcess

	/// <exclude/>
	public partial class SysLicUser_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLicUser
	{

		public SysLicUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLicUser_BaseEventsProcess";
			SchemaUId = new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("75ac6ca6-1ee2-434f-be99-524b8dabc99f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("b968f1f6-6ba4-480c-aae0-5f273aed6ea6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysLicUserInserting;
		public ProcessFlowElement SysLicUserInserting {
			get {
				return _sysLicUserInserting ?? (_sysLicUserInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysLicUserInserting",
					SchemaElementUId = new Guid("007886e7-91b1-4583-85e4-8232f66362af"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysLicUserSaving;
		public ProcessFlowElement SysLicUserSaving {
			get {
				return _sysLicUserSaving ?? (_sysLicUserSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysLicUserSaving",
					SchemaElementUId = new Guid("abb443af-233d-43ec-b1e7-92b008d4ac16"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _sysLicUserDeleting;
		public ProcessFlowElement SysLicUserDeleting {
			get {
				return _sysLicUserDeleting ?? (_sysLicUserDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SysLicUserDeleting",
					SchemaElementUId = new Guid("4e765c9b-cfb2-4a20-9577-fe9b513ab762"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _validateCanChangeRecord;
		public ProcessScriptTask ValidateCanChangeRecord {
			get {
				return _validateCanChangeRecord ?? (_validateCanChangeRecord = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ValidateCanChangeRecord",
					SchemaElementUId = new Guid("06820a37-929f-4115-aa33-0e2a1b80f636"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ValidateCanChangeRecordExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SysLicUserInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { SysLicUserInserting };
			FlowElements[SysLicUserSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SysLicUserSaving };
			FlowElements[SysLicUserDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { SysLicUserDeleting };
			FlowElements[ValidateCanChangeRecord.SchemaElementUId] = new Collection<ProcessFlowElement> { ValidateCanChangeRecord };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SysLicUserInserting":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
					case "SysLicUserSaving":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
					case "SysLicUserDeleting":
						e.Context.QueueTasks.Enqueue("ValidateCanChangeRecord");
						break;
					case "ValidateCanChangeRecord":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SysLicUserInserting");
			ActivatedEventElements.Add("SysLicUserSaving");
			ActivatedEventElements.Add("SysLicUserDeleting");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SysLicUserInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysLicUserInserting";
					result = SysLicUserInserting.Execute(context);
					break;
				case "SysLicUserSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysLicUserSaving";
					result = SysLicUserSaving.Execute(context);
					break;
				case "SysLicUserDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SysLicUserDeleting";
					result = SysLicUserDeleting.Execute(context);
					break;
				case "ValidateCanChangeRecord":
					context.QueueTasks.Dequeue();
					context.SenderName = "ValidateCanChangeRecord";
					result = ValidateCanChangeRecord.Execute(context, ValidateCanChangeRecordExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ValidateCanChangeRecordExecute(ProcessExecutingContext context) {
			UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageLicUsers");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SysLicUserInserting":
							if (ActivatedEventElements.Contains("SysLicUserInserting")) {
							context.QueueTasks.Enqueue("SysLicUserInserting");
						}
						break;
					case "SysLicUserSaving":
							if (ActivatedEventElements.Contains("SysLicUserSaving")) {
							context.QueueTasks.Enqueue("SysLicUserSaving");
						}
						break;
					case "SysLicUserDeleting":
							if (ActivatedEventElements.Contains("SysLicUserDeleting")) {
							context.QueueTasks.Enqueue("SysLicUserDeleting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SysLicUser_BaseEventsProcess

	/// <exclude/>
	public class SysLicUser_BaseEventsProcess : SysLicUser_BaseEventsProcess<SysLicUser>
	{

		public SysLicUser_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLicUser_BaseEventsProcess

	public partial class SysLicUser_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLicUserEventsProcess

	/// <exclude/>
	public class SysLicUserEventsProcess : SysLicUser_BaseEventsProcess
	{

		public SysLicUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

