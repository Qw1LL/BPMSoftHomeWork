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

	#region Class: PortalMessage_PortalMessageFeed_BPMSoftSchema

	/// <exclude/>
	public class PortalMessage_PortalMessageFeed_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PortalMessage_PortalMessageFeed_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PortalMessage_PortalMessageFeed_BPMSoftSchema(PortalMessage_PortalMessageFeed_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PortalMessage_PortalMessageFeed_BPMSoftSchema(PortalMessage_PortalMessageFeed_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			RealUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			Name = "PortalMessage_PortalMessageFeed_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("dcea5dd7-bf2c-4316-8f37-0f60ebf486d1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ce7cc40f-f98b-4286-9cb0-5ba46f6c3ebb")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5ea77165-6b18-479b-920f-09df0aa69dc7")) == null) {
				Columns.Add(CreateEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("9438b617-43b8-48a2-9295-c63f9171ea31")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("e9fa984c-8b2f-487b-ba68-880d0e6341b5")) == null) {
				Columns.Add(CreateFromPortalColumn());
			}
			if (Columns.FindByUId(new Guid("2d698665-d88f-40b4-9704-0167afde0398")) == null) {
				Columns.Add(CreateHideOnPortalColumn());
			}
			if (Columns.FindByUId(new Guid("73a884dd-94c3-4c7f-85ef-132e8a33d78b")) == null) {
				Columns.Add(CreateIsNotPublishedColumn());
			}
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ce7cc40f-f98b-4286-9cb0-5ba46f6c3ebb"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("dcea5dd7-bf2c-4316-8f37-0f60ebf486d1")
			};
		}

		protected virtual EntitySchemaColumn CreateEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5ea77165-6b18-479b-920f-09df0aa69dc7"),
				Name = @"EntityId",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("dcea5dd7-bf2c-4316-8f37-0f60ebf486d1")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("9438b617-43b8-48a2-9295-c63f9171ea31"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("dcea5dd7-bf2c-4316-8f37-0f60ebf486d1")
			};
		}

		protected virtual EntitySchemaColumn CreateFromPortalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e9fa984c-8b2f-487b-ba68-880d0e6341b5"),
				Name = @"FromPortal",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("9a791aa1-dec4-4ad9-96bd-f73a91975239"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateHideOnPortalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2d698665-d88f-40b4-9704-0167afde0398"),
				Name = @"HideOnPortal",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("9a791aa1-dec4-4ad9-96bd-f73a91975239"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsNotPublishedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("73a884dd-94c3-4c7f-85ef-132e8a33d78b"),
				Name = @"IsNotPublished",
				CreatedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				ModifiedInSchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"),
				CreatedInPackageId = new Guid("cab85636-6266-4f93-8b0b-9dac20f5b8d8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PortalMessage_PortalMessageFeed_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PortalMessage_PortalMessageFeedEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PortalMessage_PortalMessageFeed_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PortalMessage_PortalMessageFeed_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0"));
		}

		#endregion

	}

	#endregion

	#region Class: PortalMessage_PortalMessageFeed_BPMSoft

	/// <summary>
	/// Портальное сообщение.
	/// </summary>
	public class PortalMessage_PortalMessageFeed_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PortalMessage_PortalMessageFeed_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PortalMessage_PortalMessageFeed_BPMSoft";
		}

		public PortalMessage_PortalMessageFeed_BPMSoft(PortalMessage_PortalMessageFeed_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Column 1.
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
		/// Column 1.
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
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// С портала.
		/// </summary>
		public bool FromPortal {
			get {
				return GetTypedColumnValue<bool>("FromPortal");
			}
			set {
				SetColumnValue("FromPortal", value);
			}
		}

		/// <summary>
		/// Скрыто на портале.
		/// </summary>
		public bool HideOnPortal {
			get {
				return GetTypedColumnValue<bool>("HideOnPortal");
			}
			set {
				SetColumnValue("HideOnPortal", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public bool IsNotPublished {
			get {
				return GetTypedColumnValue<bool>("IsNotPublished");
			}
			set {
				SetColumnValue("IsNotPublished", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PortalMessage_PortalMessageFeedEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PortalMessage_PortalMessageFeed_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("PortalMessage_PortalMessageFeed_BPMSoftInserting", e);
			Updating += (s, e) => ThrowEvent("PortalMessage_PortalMessageFeed_BPMSoftUpdating", e);
			Validating += (s, e) => ThrowEvent("PortalMessage_PortalMessageFeed_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PortalMessage_PortalMessageFeed_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: PortalMessage_PortalMessageFeedEventsProcess

	/// <exclude/>
	public partial class PortalMessage_PortalMessageFeedEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PortalMessage_PortalMessageFeed_BPMSoft
	{

		public PortalMessage_PortalMessageFeedEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PortalMessage_PortalMessageFeedEventsProcess";
			SchemaUId = new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("36fb7666-f45c-48f7-be50-178c7adbe3c0");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1bvcbsq;
		public ProcessFlowElement EventSubProcess1bvcbsq {
			get {
				return _eventSubProcess1bvcbsq ?? (_eventSubProcess1bvcbsq = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1bvcbsq",
					SchemaElementUId = new Guid("c164cabb-2191-46e9-8223-61e9219260a7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _portalMessageInsertingStartMessage1;
		public ProcessFlowElement PortalMessageInsertingStartMessage1 {
			get {
				return _portalMessageInsertingStartMessage1 ?? (_portalMessageInsertingStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "PortalMessageInsertingStartMessage1",
					SchemaElementUId = new Guid("2837fb54-0bec-4e9a-ada7-8e4d4d89ebfc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _portalMessageInsertingScriptTask1;
		public ProcessScriptTask PortalMessageInsertingScriptTask1 {
			get {
				return _portalMessageInsertingScriptTask1 ?? (_portalMessageInsertingScriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "PortalMessageInsertingScriptTask1",
					SchemaElementUId = new Guid("ad287d2c-375f-466b-8965-346b9716dd4a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = PortalMessageInsertingScriptTask1Execute,
				});
			}
		}

		private ProcessThrowMessageEvent _portalMessageInsertingIntermediateThrowMessageEvent1;
		public ProcessThrowMessageEvent PortalMessageInsertingIntermediateThrowMessageEvent1 {
			get {
				return _portalMessageInsertingIntermediateThrowMessageEvent1 ?? (_portalMessageInsertingIntermediateThrowMessageEvent1 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "PortalMessageInsertingIntermediateThrowMessageEvent1",
					SchemaElementUId = new Guid("8965bd4e-3bfd-44e2-8afa-3e798b508a95"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "PortalMessageInserting",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1bvcbsq.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1bvcbsq };
			FlowElements[PortalMessageInsertingStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalMessageInsertingStartMessage1 };
			FlowElements[PortalMessageInsertingScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalMessageInsertingScriptTask1 };
			FlowElements[PortalMessageInsertingIntermediateThrowMessageEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { PortalMessageInsertingIntermediateThrowMessageEvent1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1bvcbsq":
						break;
					case "PortalMessageInsertingStartMessage1":
						e.Context.QueueTasks.Enqueue("PortalMessageInsertingScriptTask1");
						break;
					case "PortalMessageInsertingScriptTask1":
						e.Context.QueueTasks.Enqueue("PortalMessageInsertingIntermediateThrowMessageEvent1");
						break;
					case "PortalMessageInsertingIntermediateThrowMessageEvent1":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("PortalMessageInsertingStartMessage1");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1bvcbsq":
					context.QueueTasks.Dequeue();
					break;
				case "PortalMessageInsertingStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "PortalMessageInsertingStartMessage1";
					result = PortalMessageInsertingStartMessage1.Execute(context);
					break;
				case "PortalMessageInsertingScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "PortalMessageInsertingScriptTask1";
					result = PortalMessageInsertingScriptTask1.Execute(context, PortalMessageInsertingScriptTask1Execute);
					break;
				case "PortalMessageInsertingIntermediateThrowMessageEvent1":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "PortalMessageInserting");
					result = PortalMessageInsertingIntermediateThrowMessageEvent1.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool PortalMessageInsertingScriptTask1Execute(ProcessExecutingContext context) {
			Entity.SetColumnValue("FromPortal", UserConnection is SSPUserConnection);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "PortalMessage_PortalMessageFeed_BPMSoftInserting":
							if (ActivatedEventElements.Contains("PortalMessageInsertingStartMessage1")) {
							context.QueueTasks.Enqueue("PortalMessageInsertingStartMessage1");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: PortalMessage_PortalMessageFeedEventsProcess

	/// <exclude/>
	public class PortalMessage_PortalMessageFeedEventsProcess : PortalMessage_PortalMessageFeedEventsProcess<PortalMessage_PortalMessageFeed_BPMSoft>
	{

		public PortalMessage_PortalMessageFeedEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PortalMessage_PortalMessageFeedEventsProcess

	public partial class PortalMessage_PortalMessageFeedEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

