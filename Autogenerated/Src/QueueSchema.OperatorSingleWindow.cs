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

	#region Class: QueueSchema

	/// <exclude/>
	public class QueueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QueueSchema(QueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QueueSchema(QueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab");
			RealUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab");
			Name = "Queue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3f9570b5-7586-4d30-8fd9-270b48f119e5")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("221254af-1f3e-4307-afae-07b0b4ea6fa8")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("0ed6afd7-e32c-4c37-b56b-b7ad5fac5ab6")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("cc67082f-423a-4ba1-9725-697be295287c")) == null) {
				Columns.Add(CreateProcessSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("a61a55d4-1145-40f6-bf9b-cd8782490b70")) == null) {
				Columns.Add(CreateEntitySchemaCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("20947e38-8e7c-4aec-b9eb-2423f68a902c")) == null) {
				Columns.Add(CreateProcessSchemaCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("b4d49d9d-6e66-4713-bf29-50636fc8a992")) == null) {
				Columns.Add(CreateFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("d3081b72-5be4-42aa-8416-d3b9a39b7395")) == null) {
				Columns.Add(CreateFilterEditDataColumn());
			}
			if (Columns.FindByUId(new Guid("942e7c5a-29da-4ea8-ad7c-17ebb1222459")) == null) {
				Columns.Add(CreateIsManuallyFillingColumn());
			}
			if (Columns.FindByUId(new Guid("c303a54e-e7fc-4836-854f-82757798e1d5")) == null) {
				Columns.Add(CreateQueueEntitySchemaColumn());
			}
			if (Columns.FindByUId(new Guid("786afe14-f0ad-425b-990a-a4dda251099f")) == null) {
				Columns.Add(CreateBusinessProcessSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("621442f1-3fb1-4ea0-ba1d-7f00029c93b2")) == null) {
				Columns.Add(CreateQueueUpdateFrequencyColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6cae06b4-b7bc-4c70-a5b3-f3d43c046206"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("468cfeb3-dd71-4fe5-8b71-41582036f904")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3f9570b5-7586-4d30-8fd9-270b48f119e5"),
				Name = @"EntitySchemaUId",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4")
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("221254af-1f3e-4307-afae-07b0b4ea6fa8"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("eb2bc9f1-e40b-45f2-a8c2-4b8b9b6b6f65"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"6ed24ab2-aa6a-4cee-b205-1bab01c6719f"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0ed6afd7-e32c-4c37-b56b-b7ad5fac5ab6"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("749b84e0-9db9-4883-9303-ffc09ea14ecc"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"34bd9093-d0ff-422c-9c15-9c0668e31bcb"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cc67082f-423a-4ba1-9725-697be295287c"),
				Name = @"ProcessSchemaUId",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("f218b7b3-8c78-4ff0-aa0a-44d361bf4ae4")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a61a55d4-1145-40f6-bf9b-cd8782490b70"),
				Name = @"EntitySchemaCaption",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("20947e38-8e7c-4aec-b9eb-2423f68a902c"),
				Name = @"ProcessSchemaCaption",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("7be0af39-38cd-442a-b589-d8f3ef3f4d19")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b4d49d9d-6e66-4713-bf29-50636fc8a992"),
				Name = @"FilterData",
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("cbb457cb-1ef4-428e-937c-db6aedb72e75")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterEditDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("d3081b72-5be4-42aa-8416-d3b9a39b7395"),
				Name = @"FilterEditData",
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("cbb457cb-1ef4-428e-937c-db6aedb72e75")
			};
		}

		protected virtual EntitySchemaColumn CreateIsManuallyFillingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("942e7c5a-29da-4ea8-ad7c-17ebb1222459"),
				Name = @"IsManuallyFilling",
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("b37272aa-ca79-4db2-9717-1c02e42cc793"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateQueueEntitySchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c303a54e-e7fc-4836-854f-82757798e1d5"),
				Name = @"QueueEntitySchema",
				ReferenceSchemaUId = new Guid("c5cc8540-b4cf-483e-a440-3e3347de8a42"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d")
			};
		}

		protected virtual EntitySchemaColumn CreateBusinessProcessSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("786afe14-f0ad-425b-990a-a4dda251099f"),
				Name = @"BusinessProcessSchema",
				ReferenceSchemaUId = new Guid("93b95b14-135f-4692-94f3-4d974fe74054"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("36ba612f-971e-4193-8230-081e5d9f826d")
			};
		}

		protected virtual EntitySchemaColumn CreateQueueUpdateFrequencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("621442f1-3fb1-4ea0-ba1d-7f00029c93b2"),
				Name = @"QueueUpdateFrequency",
				ReferenceSchemaUId = new Guid("658c1af2-df48-464c-9257-0245f5460090"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				ModifiedInSchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"),
				CreatedInPackageId = new Guid("96ba3f81-7af1-43c9-9a5b-ab40bf0d009a"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"b5f98e01-f990-4226-a012-13d5586d4fe6"
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
			return new Queue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Queue_OperatorSingleWindowEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab"));
		}

		#endregion

	}

	#endregion

	#region Class: Queue

	/// <summary>
	/// Очередь.
	/// </summary>
	public class Queue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Queue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Queue";
		}

		public Queue(Queue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Тип очереди deprecated.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private QueuePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public QueuePriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as QueuePriority);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private QueueStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public QueueStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as QueueStatus);
			}
		}

		/// <summary>
		/// Процесс deprecated.
		/// </summary>
		public Guid ProcessSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaUId");
			}
			set {
				SetColumnValue("ProcessSchemaUId", value);
			}
		}

		/// <summary>
		/// Заголовок типа очереди deprecated.
		/// </summary>
		public string EntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("EntitySchemaCaption");
			}
			set {
				SetColumnValue("EntitySchemaCaption", value);
			}
		}

		/// <summary>
		/// Заголовок процесса deprecated.
		/// </summary>
		public string ProcessSchemaCaption {
			get {
				return GetTypedColumnValue<string>("ProcessSchemaCaption");
			}
			set {
				SetColumnValue("ProcessSchemaCaption", value);
			}
		}

		/// <summary>
		/// Фильтр объекта очереди.
		/// </summary>
		public string FilterData {
			get {
				return GetTypedColumnValue<string>("FilterData");
			}
			set {
				SetColumnValue("FilterData", value);
			}
		}

		/// <summary>
		/// Объект фильтрации объекта очереди.
		/// </summary>
		public string FilterEditData {
			get {
				return GetTypedColumnValue<string>("FilterEditData");
			}
			set {
				SetColumnValue("FilterEditData", value);
			}
		}

		/// <summary>
		/// Заполнение вручную.
		/// </summary>
		public bool IsManuallyFilling {
			get {
				return GetTypedColumnValue<bool>("IsManuallyFilling");
			}
			set {
				SetColumnValue("IsManuallyFilling", value);
			}
		}

		/// <exclude/>
		public Guid QueueEntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("QueueEntitySchemaId");
			}
			set {
				SetColumnValue("QueueEntitySchemaId", value);
				_queueEntitySchema = null;
			}
		}

		/// <exclude/>
		public string QueueEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("QueueEntitySchemaCaption");
			}
			set {
				SetColumnValue("QueueEntitySchemaCaption", value);
				if (_queueEntitySchema != null) {
					_queueEntitySchema.Caption = value;
				}
			}
		}

		private VwQueueSysSchema _queueEntitySchema;
		/// <summary>
		/// Тип очереди.
		/// </summary>
		public VwQueueSysSchema QueueEntitySchema {
			get {
				return _queueEntitySchema ??
					(_queueEntitySchema = LookupColumnEntities.GetEntity("QueueEntitySchema") as VwQueueSysSchema);
			}
		}

		/// <exclude/>
		public Guid BusinessProcessSchemaId {
			get {
				return GetTypedColumnValue<Guid>("BusinessProcessSchemaId");
			}
			set {
				SetColumnValue("BusinessProcessSchemaId", value);
				_businessProcessSchema = null;
			}
		}

		/// <exclude/>
		public string BusinessProcessSchemaCaption {
			get {
				return GetTypedColumnValue<string>("BusinessProcessSchemaCaption");
			}
			set {
				SetColumnValue("BusinessProcessSchemaCaption", value);
				if (_businessProcessSchema != null) {
					_businessProcessSchema.Caption = value;
				}
			}
		}

		private VwQueueSysProcess _businessProcessSchema;
		/// <summary>
		/// Процесс обработки.
		/// </summary>
		public VwQueueSysProcess BusinessProcessSchema {
			get {
				return _businessProcessSchema ??
					(_businessProcessSchema = LookupColumnEntities.GetEntity("BusinessProcessSchema") as VwQueueSysProcess);
			}
		}

		/// <exclude/>
		public Guid QueueUpdateFrequencyId {
			get {
				return GetTypedColumnValue<Guid>("QueueUpdateFrequencyId");
			}
			set {
				SetColumnValue("QueueUpdateFrequencyId", value);
				_queueUpdateFrequency = null;
			}
		}

		/// <exclude/>
		public string QueueUpdateFrequencyName {
			get {
				return GetTypedColumnValue<string>("QueueUpdateFrequencyName");
			}
			set {
				SetColumnValue("QueueUpdateFrequencyName", value);
				if (_queueUpdateFrequency != null) {
					_queueUpdateFrequency.Name = value;
				}
			}
		}

		private QueueUpdateFrequency _queueUpdateFrequency;
		/// <summary>
		/// Частота обновления.
		/// </summary>
		public QueueUpdateFrequency QueueUpdateFrequency {
			get {
				return _queueUpdateFrequency ??
					(_queueUpdateFrequency = LookupColumnEntities.GetEntity("QueueUpdateFrequency") as QueueUpdateFrequency);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Queue_OperatorSingleWindowEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QueueDeleted", e);
			Saved += (s, e) => ThrowEvent("QueueSaved", e);
			Validating += (s, e) => ThrowEvent("QueueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Queue(this);
		}

		#endregion

	}

	#endregion

	#region Class: Queue_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public partial class Queue_OperatorSingleWindowEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Queue
	{

		public Queue_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Queue_OperatorSingleWindowEventsProcess";
			SchemaUId = new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			_detailKeyTemplate = () => {{ return "QueueDetail_"; }};
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c434cf4e-85f5-48e3-b545-bd3fe9c882ab");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Func<string> _detailKeyTemplate;
		public virtual string DetailKeyTemplate {
			get {
				return (_detailKeyTemplate ?? (_detailKeyTemplate = () => null)).Invoke();
			}
			set {
				_detailKeyTemplate = () => { return value; };
			}
		}

		private ProcessFlowElement _deletedEventSubProcess;
		public ProcessFlowElement DeletedEventSubProcess {
			get {
				return _deletedEventSubProcess ?? (_deletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DeletedEventSubProcess",
					SchemaElementUId = new Guid("ee266ef9-274d-4e97-97e3-4df4f5b6e0e0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _queueDeletedMessage;
		public ProcessFlowElement QueueDeletedMessage {
			get {
				return _queueDeletedMessage ?? (_queueDeletedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "QueueDeletedMessage",
					SchemaElementUId = new Guid("2aad1228-4b1a-4f8b-9516-34609add7e55"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _clearProfileScriptTask;
		public ProcessScriptTask ClearProfileScriptTask {
			get {
				return _clearProfileScriptTask ?? (_clearProfileScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ClearProfileScriptTask",
					SchemaElementUId = new Guid("5eda0b61-311e-46cf-acc2-b9867aa345c7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ClearProfileScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_47e8fdb1426143a5a74c1d1c29370234;
		public ProcessFlowElement EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234 {
			get {
				return _eventSubProcess3_47e8fdb1426143a5a74c1d1c29370234 ?? (_eventSubProcess3_47e8fdb1426143a5a74c1d1c29370234 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234",
					SchemaElementUId = new Guid("47e8fdb1-4261-43a5-a74c-1d1c29370234"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _queueSavedMessage;
		public ProcessFlowElement QueueSavedMessage {
			get {
				return _queueSavedMessage ?? (_queueSavedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "QueueSavedMessage",
					SchemaElementUId = new Guid("1e6c093a-28ab-438c-bca7-4d0215e3162d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask_QueueSaved;
		public ProcessScriptTask ScriptTask_QueueSaved {
			get {
				return _scriptTask_QueueSaved ?? (_scriptTask_QueueSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask_QueueSaved",
					SchemaElementUId = new Guid("a12c62b6-7764-4fb3-b8ab-c8c98b039393"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask_QueueSavedExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[DeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { DeletedEventSubProcess };
			FlowElements[QueueDeletedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { QueueDeletedMessage };
			FlowElements[ClearProfileScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ClearProfileScriptTask };
			FlowElements[EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234 };
			FlowElements[QueueSavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { QueueSavedMessage };
			FlowElements[ScriptTask_QueueSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask_QueueSaved };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "DeletedEventSubProcess":
						break;
					case "QueueDeletedMessage":
						e.Context.QueueTasks.Enqueue("ClearProfileScriptTask");
						break;
					case "ClearProfileScriptTask":
						break;
					case "EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234":
						break;
					case "QueueSavedMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask_QueueSaved");
						break;
					case "ScriptTask_QueueSaved":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("QueueDeletedMessage");
			ActivatedEventElements.Add("QueueSavedMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "DeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "QueueDeletedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "QueueDeletedMessage";
					result = QueueDeletedMessage.Execute(context);
					break;
				case "ClearProfileScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ClearProfileScriptTask";
					result = ClearProfileScriptTask.Execute(context, ClearProfileScriptTaskExecute);
					break;
				case "EventSubProcess3_47e8fdb1426143a5a74c1d1c29370234":
					context.QueueTasks.Dequeue();
					break;
				case "QueueSavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "QueueSavedMessage";
					result = QueueSavedMessage.Execute(context);
					break;
				case "ScriptTask_QueueSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask_QueueSaved";
					result = ScriptTask_QueueSaved.Execute(context, ScriptTask_QueueSavedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ClearProfileScriptTaskExecute(ProcessExecutingContext context) {
			ClearProfile();
			return true;
		}

		public virtual bool ScriptTask_QueueSavedExecute(ProcessExecutingContext context) {
			QueueCacheHelper.ClearCache();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "QueueDeleted":
							if (ActivatedEventElements.Contains("QueueDeletedMessage")) {
							context.QueueTasks.Enqueue("QueueDeletedMessage");
						}
						break;
					case "QueueSaved":
							if (ActivatedEventElements.Contains("QueueSavedMessage")) {
							context.QueueTasks.Enqueue("QueueSavedMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Queue_OperatorSingleWindowEventsProcess

	/// <exclude/>
	public class Queue_OperatorSingleWindowEventsProcess : Queue_OperatorSingleWindowEventsProcess<Queue>
	{

		public Queue_OperatorSingleWindowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Queue_OperatorSingleWindowEventsProcess

	public partial class Queue_OperatorSingleWindowEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearProfile() {
			var dataValueTypeManager = 
				(DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			var textDataValueType = (TextDataValueType)dataValueTypeManager.GetInstanceByName("ShortText");
			textDataValueType.IsUnicode = true;
			var delete = new Delete(this.UserConnection)
				.From("SysProfileData")
				.Where("Key").ConsistsWith(new QueryParameter("DetailKeyTemplate", DetailKeyTemplate))
				.And().Not().Exists(
					new Select(UserConnection)
					.Column("Queue", "Id")
					.From("Queue")
					.Where("SysProfileData", "Key").EndsWith(Func.Cast("Id", textDataValueType))
				) as Delete;
			delete.Execute();
		}

		#endregion

	}

	#endregion


	#region Class: QueueEventsProcess

	/// <exclude/>
	public class QueueEventsProcess : Queue_OperatorSingleWindowEventsProcess
	{

		public QueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

