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

	#region Class: SocialSubscriptionSchema

	/// <exclude/>
	public class SocialSubscriptionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialSubscriptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialSubscriptionSchema(SocialSubscriptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialSubscriptionSchema(SocialSubscriptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			RealUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			Name = "SocialSubscription";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("633449ea-c77c-48d9-a9c8-87ebb34469b1")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("104d73ab-c727-474b-9cf4-af0147a1219d")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("abc6403d-21f8-4f7b-8170-c4ba56d0a987")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("affa939d-fce9-440d-9fc6-63f414e72b1b")) == null) {
				Columns.Add(CreateCanUnsubscribeColumn());
			}
			if (Columns.FindByUId(new Guid("db0b24a8-df76-46fc-a1de-45da92921c8a")) == null) {
				Columns.Add(CreateRightsChangedOnColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			column.CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("633449ea-c77c-48d9-a9c8-87ebb34469b1"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("104d73ab-c727-474b-9cf4-af0147a1219d"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("abc6403d-21f8-4f7b-8170-c4ba56d0a987"),
				Name = @"EntityId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateCanUnsubscribeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("affa939d-fce9-440d-9fc6-63f414e72b1b"),
				Name = @"CanUnsubscribe",
				CreatedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateRightsChangedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("db0b24a8-df76-46fc-a1de-45da92921c8a"),
				Name = @"RightsChangedOn",
				CreatedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				ModifiedInSchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"),
				CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SocialSubscription(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialSubscription_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialSubscriptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialSubscriptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialSubscription

	/// <summary>
	/// Follow.
	/// </summary>
	public class SocialSubscription : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialSubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialSubscription";
		}

		public SocialSubscription(SocialSubscription source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User/Group.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Object instance.
		/// </summary>
		public Guid EntityId {
			get {
				return GetTypedColumnValue<Guid>("EntityId");
			}
			set {
				SetColumnValue("EntityId", value);
			}
		}

		/// <summary>
		/// Can unfollow.
		/// </summary>
		public bool CanUnsubscribe {
			get {
				return GetTypedColumnValue<bool>("CanUnsubscribe");
			}
			set {
				SetColumnValue("CanUnsubscribe", value);
			}
		}

		/// <summary>
		/// User permissions last updated on.
		/// </summary>
		public DateTime RightsChangedOn {
			get {
				return GetTypedColumnValue<DateTime>("RightsChangedOn");
			}
			set {
				SetColumnValue("RightsChangedOn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialSubscription_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialSubscriptionDeleted", e);
			Deleting += (s, e) => ThrowEvent("SocialSubscriptionDeleting", e);
			Inserting += (s, e) => ThrowEvent("SocialSubscriptionInserting", e);
			Saved += (s, e) => ThrowEvent("SocialSubscriptionSaved", e);
			Validating += (s, e) => ThrowEvent("SocialSubscriptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialSubscription(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialSubscription_ESNEventsProcess

	/// <exclude/>
	public partial class SocialSubscription_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialSubscription
	{

		public SocialSubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialSubscription_ESNEventsProcess";
			SchemaUId = new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7ba1a2a3-2c59-4260-b4a7-6b89cf30803b");
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
					SchemaElementUId = new Guid("697d4079-0935-4a0d-981f-d8c9aa1bf692"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _socialSubscriptionDeleting;
		public ProcessFlowElement SocialSubscriptionDeleting {
			get {
				return _socialSubscriptionDeleting ?? (_socialSubscriptionDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialSubscriptionDeleting",
					SchemaElementUId = new Guid("386e7f1b-d24b-40fe-96b0-1e29cd147983"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _removeSubscription;
		public ProcessScriptTask RemoveSubscription {
			get {
				return _removeSubscription ?? (_removeSubscription = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemoveSubscription",
					SchemaElementUId = new Guid("0251fa70-850c-497d-a3a2-a6e36b9c8e2a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemoveSubscriptionExecute,
				});
			}
		}

		private ProcessFlowElement _socialSubscriptionSaved;
		public ProcessFlowElement SocialSubscriptionSaved {
			get {
				return _socialSubscriptionSaved ?? (_socialSubscriptionSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SocialSubscriptionSaved",
					SchemaElementUId = new Guid("42fd8612-4082-4d26-86e2-2698cbf0a8c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _removeUnsubscription;
		public ProcessScriptTask RemoveUnsubscription {
			get {
				return _removeUnsubscription ?? (_removeUnsubscription = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "RemoveUnsubscription",
					SchemaElementUId = new Guid("77c926dd-359a-4b80-a880-874c98b73cbd"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = RemoveUnsubscriptionExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SocialSubscriptionDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialSubscriptionDeleting };
			FlowElements[RemoveSubscription.SchemaElementUId] = new Collection<ProcessFlowElement> { RemoveSubscription };
			FlowElements[SocialSubscriptionSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SocialSubscriptionSaved };
			FlowElements[RemoveUnsubscription.SchemaElementUId] = new Collection<ProcessFlowElement> { RemoveUnsubscription };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SocialSubscriptionDeleting":
						e.Context.QueueTasks.Enqueue("RemoveSubscription");
						break;
					case "RemoveSubscription":
						break;
					case "SocialSubscriptionSaved":
						e.Context.QueueTasks.Enqueue("RemoveUnsubscription");
						break;
					case "RemoveUnsubscription":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SocialSubscriptionDeleting");
			ActivatedEventElements.Add("SocialSubscriptionSaved");
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
				case "SocialSubscriptionDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialSubscriptionDeleting";
					result = SocialSubscriptionDeleting.Execute(context);
					break;
				case "RemoveSubscription":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemoveSubscription";
					result = RemoveSubscription.Execute(context, RemoveSubscriptionExecute);
					break;
				case "SocialSubscriptionSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SocialSubscriptionSaved";
					result = SocialSubscriptionSaved.Execute(context);
					break;
				case "RemoveUnsubscription":
					context.QueueTasks.Dequeue();
					context.SenderName = "RemoveUnsubscription";
					result = RemoveUnsubscription.Execute(context, RemoveUnsubscriptionExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool RemoveSubscriptionExecute(ProcessExecutingContext context) {
			var entityId = Entity.GetTypedColumnValue<Guid>("EntityId");
			var userId = Entity.GetTypedColumnValue<Guid>("SysAdminUnitId");
			
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnitInRole");
			var sysAdminUnitColumn = esq.AddColumn("SysAdminUnitRoleId");
			var userFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit", userId);
			esq.Filters.Add(userFilter); 
			var groups = esq.GetEntityCollection(UserConnection);
			if (groups.Count > 0) {
				var groupIds = new List<object>(groups.Count);
				foreach (var userGroup in groups) {
					var groupId = (object)userGroup.GetColumnValue("SysAdminUnitRoleId");
					groupIds.Add(groupId);
				}
				esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialSubscription");
				var userColumn = esq.AddColumn("SysAdminUnit");
				var channelFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", entityId);
				esq.Filters.Add(channelFilter);
				var groupsFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit", groupIds);
				esq.Filters.Add(groupsFilter);
				var subscribers = esq.GetEntityCollection(UserConnection);
				if (subscribers.Count > 1) {
					var insert = new Insert(UserConnection).Into("SocialUnsubscription")
						.Set("SysAdminUnitId", Column.Parameter(userId))
						.Set("EntityId", Column.Parameter(entityId));
					insert.Execute();
				}
			}
			
			return true;
		}

		public virtual bool RemoveUnsubscriptionExecute(ProcessExecutingContext context) {
			var entityId = Entity.GetTypedColumnValue<Guid>("EntityId");
			var userId = Entity.GetTypedColumnValue<Guid>("SysAdminUnitId");
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SocialUnsubscription") {
				UseAdminRights = false
			};
			esq.AddAllSchemaColumns();
			var userFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit", userId);
			esq.Filters.Add(userFilter); 
			var channelFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "EntityId", entityId);
			esq.Filters.Add(channelFilter);
			var records = esq.GetEntityCollection(UserConnection);
			if (records.Count > 0) {
				var record = records[0];
				record.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
				record.Delete();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SocialSubscriptionDeleting":
							if (ActivatedEventElements.Contains("SocialSubscriptionDeleting")) {
							context.QueueTasks.Enqueue("SocialSubscriptionDeleting");
						}
						break;
					case "SocialSubscriptionSaved":
							if (ActivatedEventElements.Contains("SocialSubscriptionSaved")) {
							context.QueueTasks.Enqueue("SocialSubscriptionSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SocialSubscription_ESNEventsProcess

	/// <exclude/>
	public class SocialSubscription_ESNEventsProcess : SocialSubscription_ESNEventsProcess<SocialSubscription>
	{

		public SocialSubscription_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialSubscription_ESNEventsProcess

	public partial class SocialSubscription_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialSubscriptionEventsProcess

	/// <exclude/>
	public class SocialSubscriptionEventsProcess : SocialSubscription_ESNEventsProcess
	{

		public SocialSubscriptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

