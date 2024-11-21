namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: QueueObjectColumn

	/// <exclude/>
	public class QueueObjectColumn : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public QueueObjectColumn(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QueueObjectColumn";
		}

		public QueueObjectColumn(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "QueueObjectColumn";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

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
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid OrderDirectionId {
			get {
				return GetTypedColumnValue<Guid>("OrderDirectionId");
			}
			set {
				SetColumnValue("OrderDirectionId", value);
				_orderDirection = null;
			}
		}

		/// <exclude/>
		public string OrderDirectionName {
			get {
				return GetTypedColumnValue<string>("OrderDirectionName");
			}
			set {
				SetColumnValue("OrderDirectionName", value);
				if (_orderDirection != null) {
					_orderDirection.Name = value;
				}
			}
		}

		private SysOrderDirection _orderDirection;
		/// <summary>
		/// Направление сортировки.
		/// </summary>
		public SysOrderDirection OrderDirection {
			get {
				return _orderDirection ??
					(_orderDirection = new SysOrderDirection(LookupColumnEntities.GetEntity("OrderDirection")));
			}
		}

		/// <exclude/>
		public Guid QueueObjectId {
			get {
				return GetTypedColumnValue<Guid>("QueueObjectId");
			}
			set {
				SetColumnValue("QueueObjectId", value);
				_queueObject = null;
			}
		}

		/// <exclude/>
		public string QueueObjectEntitySchemaCaption {
			get {
				return GetTypedColumnValue<string>("QueueObjectEntitySchemaCaption");
			}
			set {
				SetColumnValue("QueueObjectEntitySchemaCaption", value);
				if (_queueObject != null) {
					_queueObject.EntitySchemaCaption = value;
				}
			}
		}

		private QueueObject _queueObject;
		/// <summary>
		/// Объект очереди.
		/// </summary>
		public QueueObject QueueObject {
			get {
				return _queueObject ??
					(_queueObject = new QueueObject(LookupColumnEntities.GetEntity("QueueObject")));
			}
		}

		/// <summary>
		/// Позиция.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

	}

	#endregion

}

