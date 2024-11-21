namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.EventTypePostProcess;
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

	#region Class: SiteEventTypeSchema

	/// <exclude/>
	public class SiteEventTypeSchema : BPMSoft.Configuration.SiteEventType_SiteEvent_BPMSoftSchema
	{

		#region Constructors: Public

		public SiteEventTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeSchema(SiteEventTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeSchema(SiteEventTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751");
			Name = "SiteEventType";
			ParentSchemaUId = new Guid("e7274000-f0ef-4995-991a-37f0ace69fe3");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("24d403b3-30c6-4bb0-9d5c-59839df24194")) == null) {
				Columns.Add(CreateSelectorTypeColumn());
			}
			if (Columns.FindByUId(new Guid("bf9e6aef-7fd8-43c8-bd90-2f6c9e58f20c")) == null) {
				Columns.Add(CreateWebsiteEventTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0f1649c7-bc5a-4c7f-815e-b6450b7d55fa")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("c71e4e08-5f92-4e94-8702-52e4eda27ffa")) == null) {
				Columns.Add(CreateIdentifierColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSelectorTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("24d403b3-30c6-4bb0-9d5c-59839df24194"),
				Name = @"SelectorType",
				ReferenceSchemaUId = new Guid("a68f8a18-acad-491f-90fe-af5cd59191cc"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				ModifiedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2")
			};
		}

		protected virtual EntitySchemaColumn CreateWebsiteEventTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bf9e6aef-7fd8-43c8-bd90-2f6c9e58f20c"),
				Name = @"WebsiteEventType",
				ReferenceSchemaUId = new Guid("b7962cd4-c1b4-4937-846a-0e54fe403d84"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				ModifiedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"91f91131-7edf-4238-abec-113ff689ba84"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0f1649c7-bc5a-4c7f-815e-b6450b7d55fa"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				ModifiedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIdentifierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c71e4e08-5f92-4e94-8702-52e4eda27ffa"),
				Name = @"Identifier",
				CreatedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				ModifiedInSchemaUId = new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventType_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventType

	/// <summary>
	/// Событие сайта.
	/// </summary>
	public class SiteEventType : BPMSoft.Configuration.SiteEventType_SiteEvent_BPMSoft
	{

		#region Constructors: Public

		public SiteEventType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventType";
		}

		public SiteEventType(SiteEventType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SelectorTypeId {
			get {
				return GetTypedColumnValue<Guid>("SelectorTypeId");
			}
			set {
				SetColumnValue("SelectorTypeId", value);
				_selectorType = null;
			}
		}

		/// <exclude/>
		public string SelectorTypeName {
			get {
				return GetTypedColumnValue<string>("SelectorTypeName");
			}
			set {
				SetColumnValue("SelectorTypeName", value);
				if (_selectorType != null) {
					_selectorType.Name = value;
				}
			}
		}

		private SelectorType _selectorType;
		/// <summary>
		/// Как идентифицировать элемент.
		/// </summary>
		public SelectorType SelectorType {
			get {
				return _selectorType ??
					(_selectorType = LookupColumnEntities.GetEntity("SelectorType") as SelectorType);
			}
		}

		/// <exclude/>
		public Guid WebsiteEventTypeId {
			get {
				return GetTypedColumnValue<Guid>("WebsiteEventTypeId");
			}
			set {
				SetColumnValue("WebsiteEventTypeId", value);
				_websiteEventType = null;
			}
		}

		/// <exclude/>
		public string WebsiteEventTypeName {
			get {
				return GetTypedColumnValue<string>("WebsiteEventTypeName");
			}
			set {
				SetColumnValue("WebsiteEventTypeName", value);
				if (_websiteEventType != null) {
					_websiteEventType.Name = value;
				}
			}
		}

		private WebsiteEventType _websiteEventType;
		/// <summary>
		/// Тип события сайта.
		/// </summary>
		public WebsiteEventType WebsiteEventType {
			get {
				return _websiteEventType ??
					(_websiteEventType = LookupColumnEntities.GetEntity("WebsiteEventType") as WebsiteEventType);
			}
		}

		/// <summary>
		/// Активно.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Column 1.
		/// </summary>
		public string Identifier {
			get {
				return GetTypedColumnValue<string>("Identifier");
			}
			set {
				SetColumnValue("Identifier", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventType_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeDeleted", e);
			Saved += (s, e) => ThrowEvent("SiteEventTypeSaved", e);
			Validating += (s, e) => ThrowEvent("SiteEventTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventType(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventType_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventType_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.SiteEventType_SiteEventEventsProcess<TEntity> where TEntity : SiteEventType
	{

		public SiteEventType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventType_EventTrackingEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("381d5c8e-7c61-4c5b-ad0a-5c2c05ea7751");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _savedEventSubProcess;
		public ProcessFlowElement SavedEventSubProcess {
			get {
				return _savedEventSubProcess ?? (_savedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SavedEventSubProcess",
					SchemaElementUId = new Guid("3ac999a9-cf9f-4ee6-951e-dafa1e96bae9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _savedScriptTask;
		public ProcessScriptTask SavedScriptTask {
			get {
				return _savedScriptTask ?? (_savedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SavedScriptTask",
					SchemaElementUId = new Guid("d9d655b7-c434-4a76-b0e2-da15a2100853"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _startMessageSiteEventTypeSaved;
		public ProcessFlowElement StartMessageSiteEventTypeSaved {
			get {
				return _startMessageSiteEventTypeSaved ?? (_startMessageSiteEventTypeSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageSiteEventTypeSaved",
					SchemaElementUId = new Guid("698b7eed-ae70-4203-9cb5-5a88879793ed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SavedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SavedEventSubProcess };
			FlowElements[SavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SavedScriptTask };
			FlowElements[StartMessageSiteEventTypeSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageSiteEventTypeSaved };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SavedEventSubProcess":
						break;
					case "SavedScriptTask":
						break;
					case "StartMessageSiteEventTypeSaved":
						e.Context.QueueTasks.Enqueue("SavedScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessageSiteEventTypeSaved");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SavedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SavedScriptTask";
					result = SavedScriptTask.Execute(context, SavedScriptTaskExecute);
					break;
				case "StartMessageSiteEventTypeSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageSiteEventTypeSaved";
					result = StartMessageSiteEventTypeSaved.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SavedScriptTaskExecute(ProcessExecutingContext context) {
			EventTypePostProcess.EventTypePostProcess.SetEventType(UserConnection);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SiteEventTypeSaved":
							if (ActivatedEventElements.Contains("StartMessageSiteEventTypeSaved")) {
							context.QueueTasks.Enqueue("StartMessageSiteEventTypeSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventType_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventType_EventTrackingEventsProcess : SiteEventType_EventTrackingEventsProcess<SiteEventType>
	{

		public SiteEventType_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventType_EventTrackingEventsProcess

	public partial class SiteEventType_EventTrackingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SiteEventTypeEventsProcess

	/// <exclude/>
	public class SiteEventTypeEventsProcess : SiteEventType_EventTrackingEventsProcess
	{

		public SiteEventTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

