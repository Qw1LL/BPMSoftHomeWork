namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Queue

	/// <exclude/>
	public class Queue : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Queue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Queue";
		}

		public Queue(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Queue";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<QueueFilteredItem> QueueFilteredItemCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<QueueInFolder> QueueInFolderCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<QueueInTag> QueueInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<QueueItem> QueueItemCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<QueueOperator> QueueOperatorCollectionByQueue {
			get;
			set;
		}

		public IEnumerable<VwQueueItem> VwQueueItemCollectionByQueue {
			get;
			set;
		}

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Дата создания.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Создал.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Изменил.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Активные процессы.
		/// </summary>
		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

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
					(_priority = new QueuePriority(LookupColumnEntities.GetEntity("Priority")));
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
					(_status = new QueueStatus(LookupColumnEntities.GetEntity("Status")));
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
					(_queueEntitySchema = new VwQueueSysSchema(LookupColumnEntities.GetEntity("QueueEntitySchema")));
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
					(_businessProcessSchema = new VwQueueSysProcess(LookupColumnEntities.GetEntity("BusinessProcessSchema")));
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
					(_queueUpdateFrequency = new QueueUpdateFrequency(LookupColumnEntities.GetEntity("QueueUpdateFrequency")));
			}
		}

		#endregion

	}

	#endregion

}

