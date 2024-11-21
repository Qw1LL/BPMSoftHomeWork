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
	using Core.Store;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Messaging.Common;
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

	#region Class: ESNNotificationSchema

	/// <exclude/>
	public class ESNNotificationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ESNNotificationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ESNNotificationSchema(ESNNotificationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ESNNotificationSchema(ESNNotificationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			RealUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			Name = "ESNNotification";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("844c5e36-7fd7-41c7-81dd-574e8b70c45f")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d7674e34-9064-4227-bc8b-79558b834159")) == null) {
				Columns.Add(CreateIsReadColumn());
			}
			if (Columns.FindByUId(new Guid("b94951c9-bac5-42a0-9c71-66c3726225f7")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("e11dab4a-4030-4014-be31-70700c3f11f8")) == null) {
				Columns.Add(CreateSocialMessageColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			column.CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("844c5e36-7fd7-41c7-81dd-574e8b70c45f"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("50ccb888-a445-4deb-95d1-452c96fcd984"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9")
			};
		}

		protected virtual EntitySchemaColumn CreateIsReadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d7674e34-9064-4227-bc8b-79558b834159"),
				Name = @"IsRead",
				CreatedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b94951c9-bac5-42a0-9c71-66c3726225f7"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				CreatedInPackageId = new Guid("85692de8-da76-4104-833d-8e3ae998c1d9")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e11dab4a-4030-4014-be31-70700c3f11f8"),
				Name = @"SocialMessage",
				ReferenceSchemaUId = new Guid("b0e78c23-7095-4d59-b8eb-c10243bcd67b"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				ModifiedInSchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411"),
				CreatedInPackageId = new Guid("fe67a13d-f941-4162-b1b9-3bbef244841b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ESNNotification(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ESNNotification_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ESNNotificationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ESNNotificationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("104d30b1-458a-49b9-8464-aef17d78b411"));
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotification

	/// <summary>
	/// Feed notification.
	/// </summary>
	public class ESNNotification : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ESNNotification(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ESNNotification";
		}

		public ESNNotification(ESNNotification source)
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
		public string TypeAction {
			get {
				return GetTypedColumnValue<string>("TypeAction");
			}
			set {
				SetColumnValue("TypeAction", value);
				if (_type != null) {
					_type.Action = value;
				}
			}
		}

		private ESNNotificationType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public ESNNotificationType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ESNNotificationType);
			}
		}

		/// <summary>
		/// Read.
		/// </summary>
		public bool IsRead {
			get {
				return GetTypedColumnValue<bool>("IsRead");
			}
			set {
				SetColumnValue("IsRead", value);
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

		/// <exclude/>
		public Guid SocialMessageId {
			get {
				return GetTypedColumnValue<Guid>("SocialMessageId");
			}
			set {
				SetColumnValue("SocialMessageId", value);
				_socialMessage = null;
			}
		}

		/// <exclude/>
		public string SocialMessageMessage {
			get {
				return GetTypedColumnValue<string>("SocialMessageMessage");
			}
			set {
				SetColumnValue("SocialMessageMessage", value);
				if (_socialMessage != null) {
					_socialMessage.Message = value;
				}
			}
		}

		private SocialMessage _socialMessage;
		/// <summary>
		/// Message.
		/// </summary>
		public SocialMessage SocialMessage {
			get {
				return _socialMessage ??
					(_socialMessage = LookupColumnEntities.GetEntity("SocialMessage") as SocialMessage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ESNNotification_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ESNNotificationDeleted", e);
			Inserting += (s, e) => ThrowEvent("ESNNotificationInserting", e);
			Updated += (s, e) => ThrowEvent("ESNNotificationUpdated", e);
			Validating += (s, e) => ThrowEvent("ESNNotificationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ESNNotification(this);
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotification_ESNEventsProcess

	/// <exclude/>
	public partial class ESNNotification_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ESNNotification
	{

		public ESNNotification_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ESNNotification_ESNEventsProcess";
			SchemaUId = new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("104d30b1-458a-49b9-8464-aef17d78b411");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eSNNotificationUpdatedEventSubProcess;
		public ProcessFlowElement ESNNotificationUpdatedEventSubProcess {
			get {
				return _eSNNotificationUpdatedEventSubProcess ?? (_eSNNotificationUpdatedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ESNNotificationUpdatedEventSubProcess",
					SchemaElementUId = new Guid("c2b010f9-61ab-4ea2-b964-57c415c6bbf2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _eSNNotificationUpdatedStartMessage;
		public ProcessFlowElement ESNNotificationUpdatedStartMessage {
			get {
				return _eSNNotificationUpdatedStartMessage ?? (_eSNNotificationUpdatedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ESNNotificationUpdatedStartMessage",
					SchemaElementUId = new Guid("f1451171-9471-4041-a2ba-7841b823f74d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _eSNNotificationUpdatedScriptTask;
		public ProcessScriptTask ESNNotificationUpdatedScriptTask {
			get {
				return _eSNNotificationUpdatedScriptTask ?? (_eSNNotificationUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ESNNotificationUpdatedScriptTask",
					SchemaElementUId = new Guid("2d64ce2b-b2ac-40a3-b6b0-89d874594319"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ESNNotificationUpdatedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ESNNotificationUpdatedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { ESNNotificationUpdatedEventSubProcess };
			FlowElements[ESNNotificationUpdatedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ESNNotificationUpdatedStartMessage };
			FlowElements[ESNNotificationUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ESNNotificationUpdatedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ESNNotificationUpdatedEventSubProcess":
						break;
					case "ESNNotificationUpdatedStartMessage":
						e.Context.QueueTasks.Enqueue("ESNNotificationUpdatedScriptTask");
						break;
					case "ESNNotificationUpdatedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ESNNotificationUpdatedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ESNNotificationUpdatedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ESNNotificationUpdatedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ESNNotificationUpdatedStartMessage";
					result = ESNNotificationUpdatedStartMessage.Execute(context);
					break;
				case "ESNNotificationUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ESNNotificationUpdatedScriptTask";
					result = ESNNotificationUpdatedScriptTask.Execute(context, ESNNotificationUpdatedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ESNNotificationUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			var changedColumns = Entity.GetChangedColumnValues();
			if (changedColumns.Any(column => column.Name == "IsRead")) {
				PublishClientNotificationInfo("update");
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ESNNotificationUpdated":
							if (ActivatedEventElements.Contains("ESNNotificationUpdatedStartMessage")) {
							context.QueueTasks.Enqueue("ESNNotificationUpdatedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ESNNotification_ESNEventsProcess

	/// <exclude/>
	public class ESNNotification_ESNEventsProcess : ESNNotification_ESNEventsProcess<ESNNotification>
	{

		public ESNNotification_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: ESNNotificationEventsProcess

	/// <exclude/>
	public class ESNNotificationEventsProcess : ESNNotification_ESNEventsProcess
	{

		public ESNNotificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

