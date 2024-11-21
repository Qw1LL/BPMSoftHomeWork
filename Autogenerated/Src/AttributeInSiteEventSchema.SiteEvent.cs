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

	#region Class: AttributeInSiteEvent_SiteEvent_BPMSoftSchema

	/// <exclude/>
	public class AttributeInSiteEvent_SiteEvent_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AttributeInSiteEvent_SiteEvent_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AttributeInSiteEvent_SiteEvent_BPMSoftSchema(AttributeInSiteEvent_SiteEvent_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AttributeInSiteEvent_SiteEvent_BPMSoftSchema(AttributeInSiteEvent_SiteEvent_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			RealUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			Name = "AttributeInSiteEvent_SiteEvent_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateStringValueColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0090b19c-a4c7-4715-afb2-2fb6d716930a")) == null) {
				Columns.Add(CreateSiteEventAttributeColumn());
			}
			if (Columns.FindByUId(new Guid("dbab435f-266f-4e00-ba8b-ff4facac9f2a")) == null) {
				Columns.Add(CreateListItemValueColumn());
			}
			if (Columns.FindByUId(new Guid("4b78b2c5-72f6-4a34-ba9c-d4b0a2c61344")) == null) {
				Columns.Add(CreateIntValueColumn());
			}
			if (Columns.FindByUId(new Guid("c5411baa-4254-440c-9e1a-49a8d5ed1168")) == null) {
				Columns.Add(CreateFloatValueColumn());
			}
			if (Columns.FindByUId(new Guid("8beac038-2db4-4e2f-8355-626cd444bc4a")) == null) {
				Columns.Add(CreateBooleanValueColumn());
			}
			if (Columns.FindByUId(new Guid("ee940c14-92c8-46b4-a4d5-7ff3fd0d2c58")) == null) {
				Columns.Add(CreateProductValueColumn());
			}
			if (Columns.FindByUId(new Guid("bd85be31-baf9-4352-8755-6a7f426898e2")) == null) {
				Columns.Add(CreateSiteEventColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			column.CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSiteEventAttributeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0090b19c-a4c7-4715-afb2-2fb6d716930a"),
				Name = @"SiteEventAttribute",
				ReferenceSchemaUId = new Guid("f65a195e-31b6-4db8-93a8-e7985f482c14"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateListItemValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dbab435f-266f-4e00-ba8b-ff4facac9f2a"),
				Name = @"ListItemValue",
				ReferenceSchemaUId = new Guid("0db0c5bb-0ff9-4e93-81a3-30451163dbb8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateStringValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("77e7695a-bacb-4e76-8308-8e6a04a9476c"),
				Name = @"StringValue",
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateIntValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("4b78b2c5-72f6-4a34-ba9c-d4b0a2c61344"),
				Name = @"IntValue",
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateFloatValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c5411baa-4254-440c-9e1a-49a8d5ed1168"),
				Name = @"FloatValue",
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateBooleanValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8beac038-2db4-4e2f-8355-626cd444bc4a"),
				Name = @"BooleanValue",
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateProductValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ee940c14-92c8-46b4-a4d5-7ff3fd0d2c58"),
				Name = @"ProductValue",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected virtual EntitySchemaColumn CreateSiteEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bd85be31-baf9-4352-8755-6a7f426898e2"),
				Name = @"SiteEvent",
				ReferenceSchemaUId = new Guid("93a880c8-dea8-47d5-9b79-1d7fd8259ca0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				ModifiedInSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"),
				CreatedInPackageId = new Guid("2a23e39e-fab7-43e0-a89e-cc22e5c8d6ed")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AttributeInSiteEvent_SiteEvent_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AttributeInSiteEvent_SiteEventEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AttributeInSiteEvent_SiteEvent_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AttributeInSiteEvent_SiteEvent_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6839c7b8-f847-4cef-81cd-6554e7502730"));
		}

		#endregion

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEvent_BPMSoft

	/// <summary>
	/// Атрибут в событии сайта.
	/// </summary>
	public class AttributeInSiteEvent_SiteEvent_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AttributeInSiteEvent_SiteEvent_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AttributeInSiteEvent_SiteEvent_BPMSoft";
		}

		public AttributeInSiteEvent_SiteEvent_BPMSoft(AttributeInSiteEvent_SiteEvent_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SiteEventAttributeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventAttributeId");
			}
			set {
				SetColumnValue("SiteEventAttributeId", value);
				_siteEventAttribute = null;
			}
		}

		/// <exclude/>
		public string SiteEventAttributeName {
			get {
				return GetTypedColumnValue<string>("SiteEventAttributeName");
			}
			set {
				SetColumnValue("SiteEventAttributeName", value);
				if (_siteEventAttribute != null) {
					_siteEventAttribute.Name = value;
				}
			}
		}

		private SiteEventAttribute _siteEventAttribute;
		/// <summary>
		/// Атрибут.
		/// </summary>
		public SiteEventAttribute SiteEventAttribute {
			get {
				return _siteEventAttribute ??
					(_siteEventAttribute = LookupColumnEntities.GetEntity("SiteEventAttribute") as SiteEventAttribute);
			}
		}

		/// <exclude/>
		public Guid ListItemValueId {
			get {
				return GetTypedColumnValue<Guid>("ListItemValueId");
			}
			set {
				SetColumnValue("ListItemValueId", value);
				_listItemValue = null;
			}
		}

		/// <exclude/>
		public string ListItemValueName {
			get {
				return GetTypedColumnValue<string>("ListItemValueName");
			}
			set {
				SetColumnValue("ListItemValueName", value);
				if (_listItemValue != null) {
					_listItemValue.Name = value;
				}
			}
		}

		private SiteEventAttrListItem _listItemValue;
		/// <summary>
		/// Значение(Список).
		/// </summary>
		public SiteEventAttrListItem ListItemValue {
			get {
				return _listItemValue ??
					(_listItemValue = LookupColumnEntities.GetEntity("ListItemValue") as SiteEventAttrListItem);
			}
		}

		/// <summary>
		/// Значение.
		/// </summary>
		public string StringValue {
			get {
				return GetTypedColumnValue<string>("StringValue");
			}
			set {
				SetColumnValue("StringValue", value);
			}
		}

		/// <summary>
		/// Значение(Числовое).
		/// </summary>
		public int IntValue {
			get {
				return GetTypedColumnValue<int>("IntValue");
			}
			set {
				SetColumnValue("IntValue", value);
			}
		}

		/// <summary>
		/// Значение(Дробное).
		/// </summary>
		public Decimal FloatValue {
			get {
				return GetTypedColumnValue<Decimal>("FloatValue");
			}
			set {
				SetColumnValue("FloatValue", value);
			}
		}

		/// <summary>
		/// Значение(Логическое).
		/// </summary>
		public bool BooleanValue {
			get {
				return GetTypedColumnValue<bool>("BooleanValue");
			}
			set {
				SetColumnValue("BooleanValue", value);
			}
		}

		/// <exclude/>
		public Guid ProductValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductValueId");
			}
			set {
				SetColumnValue("ProductValueId", value);
				_productValue = null;
			}
		}

		/// <exclude/>
		public string ProductValueName {
			get {
				return GetTypedColumnValue<string>("ProductValueName");
			}
			set {
				SetColumnValue("ProductValueName", value);
				if (_productValue != null) {
					_productValue.Name = value;
				}
			}
		}

		private Product _productValue;
		/// <summary>
		/// Значение(Связь с продуктом).
		/// </summary>
		public Product ProductValue {
			get {
				return _productValue ??
					(_productValue = LookupColumnEntities.GetEntity("ProductValue") as Product);
			}
		}

		/// <exclude/>
		public Guid SiteEventId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventId");
			}
			set {
				SetColumnValue("SiteEventId", value);
				_siteEvent = null;
			}
		}

		/// <exclude/>
		public string SiteEventSource {
			get {
				return GetTypedColumnValue<string>("SiteEventSource");
			}
			set {
				SetColumnValue("SiteEventSource", value);
				if (_siteEvent != null) {
					_siteEvent.Source = value;
				}
			}
		}

		private SiteEvent _siteEvent;
		/// <summary>
		/// Событие сайта.
		/// </summary>
		public SiteEvent SiteEvent {
			get {
				return _siteEvent ??
					(_siteEvent = LookupColumnEntities.GetEntity("SiteEvent") as SiteEvent);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AttributeInSiteEvent_SiteEventEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AttributeInSiteEvent_SiteEvent_BPMSoftDeleted", e);
			Saving += (s, e) => ThrowEvent("AttributeInSiteEvent_SiteEvent_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("AttributeInSiteEvent_SiteEvent_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AttributeInSiteEvent_SiteEvent_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEventEventsProcess

	/// <exclude/>
	public partial class AttributeInSiteEvent_SiteEventEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AttributeInSiteEvent_SiteEvent_BPMSoft
	{

		public AttributeInSiteEvent_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AttributeInSiteEvent_SiteEventEventsProcess";
			SchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _attributeInSiteEventSavingEventSubProcess;
		public ProcessFlowElement AttributeInSiteEventSavingEventSubProcess {
			get {
				return _attributeInSiteEventSavingEventSubProcess ?? (_attributeInSiteEventSavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "AttributeInSiteEventSavingEventSubProcess",
					SchemaElementUId = new Guid("fd75d034-bfcc-4cfd-b167-d0b4571ec8f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _attributeInSiteEventSaving;
		public ProcessFlowElement AttributeInSiteEventSaving {
			get {
				return _attributeInSiteEventSaving ?? (_attributeInSiteEventSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AttributeInSiteEventSaving",
					SchemaElementUId = new Guid("22021ce1-96a2-4e1a-880d-57ef0c34fba4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _attributeInSiteEventSavingScriptTask;
		public ProcessScriptTask AttributeInSiteEventSavingScriptTask {
			get {
				return _attributeInSiteEventSavingScriptTask ?? (_attributeInSiteEventSavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "AttributeInSiteEventSavingScriptTask",
					SchemaElementUId = new Guid("6803870e-dcee-4fbc-914d-dfcdf4a77a45"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = AttributeInSiteEventSavingScriptTaskExecute,
				});
			}
		}

		private LocalizableString _yes;
		public LocalizableString Yes {
			get {
				return _yes ?? (_yes = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.Yes.Value"));
			}
		}

		private LocalizableString _no;
		public LocalizableString No {
			get {
				return _no ?? (_no = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.No.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[AttributeInSiteEventSavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { AttributeInSiteEventSavingEventSubProcess };
			FlowElements[AttributeInSiteEventSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { AttributeInSiteEventSaving };
			FlowElements[AttributeInSiteEventSavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { AttributeInSiteEventSavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "AttributeInSiteEventSavingEventSubProcess":
						break;
					case "AttributeInSiteEventSaving":
						e.Context.QueueTasks.Enqueue("AttributeInSiteEventSavingScriptTask");
						break;
					case "AttributeInSiteEventSavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("AttributeInSiteEventSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "AttributeInSiteEventSavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "AttributeInSiteEventSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "AttributeInSiteEventSaving";
					result = AttributeInSiteEventSaving.Execute(context);
					break;
				case "AttributeInSiteEventSavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "AttributeInSiteEventSavingScriptTask";
					result = AttributeInSiteEventSavingScriptTask.Execute(context, AttributeInSiteEventSavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool AttributeInSiteEventSavingScriptTaskExecute(ProcessExecutingContext context) {
			FillStringValue();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "AttributeInSiteEvent_SiteEvent_BPMSoftSaving":
							if (ActivatedEventElements.Contains("AttributeInSiteEventSaving")) {
							context.QueueTasks.Enqueue("AttributeInSiteEventSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEventEventsProcess

	/// <exclude/>
	public class AttributeInSiteEvent_SiteEventEventsProcess : AttributeInSiteEvent_SiteEventEventsProcess<AttributeInSiteEvent_SiteEvent_BPMSoft>
	{

		public AttributeInSiteEvent_SiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEventEventsProcess

	public partial class AttributeInSiteEvent_SiteEventEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool FillStringValue() {
			// Convert attribute value to StringValue
			var attributeTypeId = string.Empty;
			var attributeValue = string.Empty;
			
			if (Entity.SiteEventAttributeId == Guid.Empty) {
				return true;
			};
			
			var esqResult = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SiteEventAttribute");
			esqResult.AddColumn("Type");
			var attributeEntity = esqResult.GetEntity(UserConnection, Entity.SiteEventAttributeId);
			attributeTypeId = attributeEntity.GetTypedColumnValue<string>("TypeId");
			
			// if not string value
			if (attributeTypeId != "e9da1be2-b0b9-478f-8290-b84a0091ec81") {
				Entity.SetColumnValue("StringValue", string.Empty);
			};
			
			switch(attributeTypeId) {
				// string type
				case ("e9da1be2-b0b9-478f-8290-b84a0091ec81"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					return true;
				// int type
				case ("30dc6786-9179-4e6c-9e09-3c00b98bd3ef"):
					attributeValue = Entity.GetTypedColumnValue<string>("IntValue");
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					break;
				// float type
				case ("21b7b386-0ce4-48d3-9b4d-6616407dedb0"):
					attributeValue = Entity.GetTypedColumnValue<string>("FloatValue");
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					break;
				// boolean type
				case ("5762dce0-54fd-4da5-859d-323003b8a9e2"):
					if (Entity.GetTypedColumnValue<bool>("BooleanValue")) {
						attributeValue = Yes.ToString();
					} else {
						attributeValue = No.ToString();
					}
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					break;
				// list item value
				case ("23332960-c76a-4c53-a4e6-f0447b8d0018"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ProductValueId", null);
					attributeValue = GetColumnDisplayValue("SiteEventAttrListItem", Entity.ListItemValueId);
					break;
				//product value
				case ("28979594-4b11-4bd8-86d2-f2252f508edd"):
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					attributeValue = GetColumnDisplayValue("Product", Entity.ProductValueId);
					break;
				default: return true;
			};
			Entity.SetColumnValue("StringValue", attributeValue);
			return true;
		}

		public virtual string GetColumnDisplayValue(string schemaName, Guid schemaPrimaryColumnId) {
			EntitySchema schema = UserConnection.EntitySchemaManager.GetInstanceByName(schemaName);
			Entity entity = schema.CreateEntity(UserConnection);
			var columnsToFetch = new[] {
				schema.PrimaryColumn,
				schema.PrimaryDisplayColumn
			};
			if (entity.FetchFromDB(schema.PrimaryColumn, schemaPrimaryColumnId, columnsToFetch))
			{
				return entity.PrimaryDisplayColumnValue;
			}
			return String.Empty;
		}

		#endregion

	}

	#endregion

}

