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

	#region Class: SpecificationInObjectSchema

	/// <exclude/>
	public class SpecificationInObjectSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SpecificationInObjectSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SpecificationInObjectSchema(SpecificationInObjectSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SpecificationInObjectSchema(SpecificationInObjectSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			RealUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			Name = "SpecificationInObject";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8d363901-e536-4e02-82ef-7921ad3ad215")) == null) {
				Columns.Add(CreateStringValueColumn());
			}
			if (Columns.FindByUId(new Guid("985cfb03-dc38-4589-97e8-1663035e12cb")) == null) {
				Columns.Add(CreateIntValueColumn());
			}
			if (Columns.FindByUId(new Guid("1492aef9-5567-4ce2-b308-5b7d581aebb7")) == null) {
				Columns.Add(CreateFloatValueColumn());
			}
			if (Columns.FindByUId(new Guid("43656d13-5970-40fa-a6cc-b9d34b1d3636")) == null) {
				Columns.Add(CreateBooleanValueColumn());
			}
			if (Columns.FindByUId(new Guid("6adaf528-b0c1-4e74-a20f-70933fc06ddd")) == null) {
				Columns.Add(CreateSpecificationColumn());
			}
			if (Columns.FindByUId(new Guid("e81eee9a-1b68-4318-9a9f-20dadd47c823")) == null) {
				Columns.Add(CreateListItemValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			column.CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateStringValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8d363901-e536-4e02-82ef-7921ad3ad215"),
				Name = @"StringValue",
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateIntValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("985cfb03-dc38-4589-97e8-1663035e12cb"),
				Name = @"IntValue",
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateFloatValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("1492aef9-5567-4ce2-b308-5b7d581aebb7"),
				Name = @"FloatValue",
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateBooleanValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("43656d13-5970-40fa-a6cc-b9d34b1d3636"),
				Name = @"BooleanValue",
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateSpecificationColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6adaf528-b0c1-4e74-a20f-70933fc06ddd"),
				Name = @"Specification",
				ReferenceSchemaUId = new Guid("ec3cebc4-ea18-40ea-9b0f-e348570481ef"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected virtual EntitySchemaColumn CreateListItemValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e81eee9a-1b68-4318-9a9f-20dadd47c823"),
				Name = @"ListItemValue",
				ReferenceSchemaUId = new Guid("99bb0a66-4041-4261-a6f2-f37806ba3f65"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				ModifiedInSchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"),
				CreatedInPackageId = new Guid("caa0a55b-ca92-4b47-9a26-59cfe4fac97e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SpecificationInObject(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SpecificationInObject_SpecificationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SpecificationInObjectSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SpecificationInObjectSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6"));
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInObject

	/// <summary>
	/// Характеристика в объекте.
	/// </summary>
	public class SpecificationInObject : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SpecificationInObject(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationInObject";
		}

		public SpecificationInObject(SpecificationInObject source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Значение (целочисленное).
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
		/// Значение (дробное).
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
		/// Значение (логическое).
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
		public Guid SpecificationId {
			get {
				return GetTypedColumnValue<Guid>("SpecificationId");
			}
			set {
				SetColumnValue("SpecificationId", value);
				_specification = null;
			}
		}

		/// <exclude/>
		public string SpecificationName {
			get {
				return GetTypedColumnValue<string>("SpecificationName");
			}
			set {
				SetColumnValue("SpecificationName", value);
				if (_specification != null) {
					_specification.Name = value;
				}
			}
		}

		private Specification _specification;
		/// <summary>
		/// Характеристика.
		/// </summary>
		public Specification Specification {
			get {
				return _specification ??
					(_specification = LookupColumnEntities.GetEntity("Specification") as Specification);
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

		private SpecificationListItem _listItemValue;
		/// <summary>
		/// Значение (выбор из списка).
		/// </summary>
		public SpecificationListItem ListItemValue {
			get {
				return _listItemValue ??
					(_listItemValue = LookupColumnEntities.GetEntity("ListItemValue") as SpecificationListItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SpecificationInObject_SpecificationEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SpecificationInObjectDeleted", e);
			Inserting += (s, e) => ThrowEvent("SpecificationInObjectInserting", e);
			Saving += (s, e) => ThrowEvent("SpecificationInObjectSaving", e);
			Validating += (s, e) => ThrowEvent("SpecificationInObjectValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SpecificationInObject(this);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInObject_SpecificationEventsProcess

	/// <exclude/>
	public partial class SpecificationInObject_SpecificationEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SpecificationInObject
	{

		public SpecificationInObject_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SpecificationInObject_SpecificationEventsProcess";
			SchemaUId = new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1777f489-6dbf-40c7-8d45-7be4d658d8e6");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _savingEventSubProcess;
		public ProcessFlowElement SavingEventSubProcess {
			get {
				return _savingEventSubProcess ?? (_savingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SavingEventSubProcess",
					SchemaElementUId = new Guid("6e056378-b8f9-44bd-acc1-750e07f572be"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateStringValueScriptTask;
		public ProcessScriptTask UpdateStringValueScriptTask {
			get {
				return _updateStringValueScriptTask ?? (_updateStringValueScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateStringValueScriptTask",
					SchemaElementUId = new Guid("8de824ce-68cc-4ccb-89dc-5e28f6ca65c2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateStringValueScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _specificationInObjectSaving;
		public ProcessFlowElement SpecificationInObjectSaving {
			get {
				return _specificationInObjectSaving ?? (_specificationInObjectSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SpecificationInObjectSaving",
					SchemaElementUId = new Guid("25a044df-358d-4a85-917e-b23df6b34944"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
			FlowElements[SavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SavingEventSubProcess };
			FlowElements[UpdateStringValueScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateStringValueScriptTask };
			FlowElements[SpecificationInObjectSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { SpecificationInObjectSaving };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SavingEventSubProcess":
						break;
					case "UpdateStringValueScriptTask":
						break;
					case "SpecificationInObjectSaving":
						e.Context.QueueTasks.Enqueue("UpdateStringValueScriptTask");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SpecificationInObjectSaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "UpdateStringValueScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateStringValueScriptTask";
					result = UpdateStringValueScriptTask.Execute(context, UpdateStringValueScriptTaskExecute);
					break;
				case "SpecificationInObjectSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "SpecificationInObjectSaving";
					result = SpecificationInObjectSaving.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateStringValueScriptTaskExecute(ProcessExecutingContext context) {
			return UpdateStringValueMethod();
			/*
			// Convert specification value to StringValue
			
			var specificationTypeId = string.Empty;
			var specificationValue = string.Empty;
			
			if (Entity.SpecificationId == Guid.Empty) {
				return true;
			};
			
			var esqResult = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Specification");
			esqResult.AddColumn("Type");
			var specEntity = esqResult.GetEntity(UserConnection, Entity.SpecificationId);
			specificationTypeId = specEntity.GetTypedColumnValue<string>("TypeId");
			
			// if not string value
			if (specificationTypeId != "7aad419a-9e7a-4785-8d13-c7ff1402e13d") {
				Entity.SetColumnValue("StringValue", string.Empty);
			};
			
			switch(specificationTypeId) {
				// string type
				case ("7aad419a-9e7a-4785-8d13-c7ff1402e13d"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValue", null);
					return true;
				// int type
				case ("2212241a-71eb-468b-a3d5-c0f39dfe51c9"):
					specificationValue = Entity.GetTypedColumnValue<string>("IntValue");
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValue", null);
					break;
				// float type
				case ("beb46531-4f29-452c-be18-1ed5f1aa8b80"):
					specificationValue = Entity.GetTypedColumnValue<string>("FloatValue");
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValue", null);
					break;
				// boolean type
				case ("359e0e35-bb39-4f07-9b9f-aec6ad076828"):
					if (Entity.GetTypedColumnValue<bool>("BooleanValue")) {
						specificationValue = Yes.ToString();
					} else {
						specificationValue = No.ToString();
					}
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValue", null);
					break;
				// list item value
				case ("ecf578a0-4b4d-40e6-909c-39af2a798d32"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					if (Entity.ListItemValueId != Guid.Empty ) {
						specificationValue = Entity.ListItemValueName;
					} 
					break;
				default: return true;
			};
			
			Entity.SetColumnValue("StringValue", specificationValue);
			
			return true;
			*/
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SpecificationInObjectSaving":
							if (ActivatedEventElements.Contains("SpecificationInObjectSaving")) {
							context.QueueTasks.Enqueue("SpecificationInObjectSaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInObject_SpecificationEventsProcess

	/// <exclude/>
	public class SpecificationInObject_SpecificationEventsProcess : SpecificationInObject_SpecificationEventsProcess<SpecificationInObject>
	{

		public SpecificationInObject_SpecificationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SpecificationInObject_SpecificationEventsProcess

	public partial class SpecificationInObject_SpecificationEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool UpdateStringValueMethod() {
			// Convert specification value to StringValue
			
			var specificationTypeId = string.Empty;
			var specificationValue = string.Empty;
			
			if (Entity.SpecificationId == Guid.Empty) {
				return true;
			};
			
			var esqResult = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Specification");
			esqResult.AddColumn("Type");
			var specEntity = esqResult.GetEntity(UserConnection, Entity.SpecificationId);
			specificationTypeId = specEntity.GetTypedColumnValue<string>("TypeId");
			
			// if not string value
			if (specificationTypeId != "7aad419a-9e7a-4785-8d13-c7ff1402e13d") {
				Entity.SetColumnValue("StringValue", string.Empty);
			};
			
			switch(specificationTypeId) {
				// string type
				case ("7aad419a-9e7a-4785-8d13-c7ff1402e13d"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					return true;
				// int type
				case ("2212241a-71eb-468b-a3d5-c0f39dfe51c9"):
					specificationValue = Entity.GetTypedColumnValue<string>("IntValue");
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					break;
				// float type
				case ("beb46531-4f29-452c-be18-1ed5f1aa8b80"):
					specificationValue = Entity.GetTypedColumnValue<string>("FloatValue");
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					break;
				// boolean type
				case ("359e0e35-bb39-4f07-9b9f-aec6ad076828"):
					if (Entity.GetTypedColumnValue<bool>("BooleanValue")) {
						specificationValue = Yes.ToString();
					} else {
						specificationValue = No.ToString();
					}
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					break;
				// list item value
				case ("ecf578a0-4b4d-40e6-909c-39af2a798d32"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					if (Entity.ListItemValueId != Guid.Empty ) {
						var listItemResult = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SpecificationListItem");
						listItemResult.AddColumn("Name");
						var listItem = listItemResult.GetEntity(UserConnection, Entity.ListItemValueId);
						specificationValue = listItem.GetTypedColumnValue<string>("Name");
					} 
					break;
				default: return true;
			};
			
			Entity.SetColumnValue("StringValue", specificationValue);
			
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: SpecificationInObjectEventsProcess

	/// <exclude/>
	public class SpecificationInObjectEventsProcess : SpecificationInObject_SpecificationEventsProcess
	{

		public SpecificationInObjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

