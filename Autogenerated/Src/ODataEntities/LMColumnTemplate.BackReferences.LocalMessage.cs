namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LMColumnTemplate

	/// <exclude/>
	public class LMColumnTemplate : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LMColumnTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LMColumnTemplate";
		}

		public LMColumnTemplate(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LMColumnTemplate";
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
		/// Название колонки.
		/// </summary>
		public string ColumnName {
			get {
				return GetTypedColumnValue<string>("ColumnName");
			}
			set {
				SetColumnValue("ColumnName", value);
			}
		}

		/// <summary>
		/// Ссылка?.
		/// </summary>
		public bool IsLink {
			get {
				return GetTypedColumnValue<bool>("IsLink");
			}
			set {
				SetColumnValue("IsLink", value);
			}
		}

		/// <summary>
		/// На изменение?.
		/// </summary>
		public bool IsOnChange {
			get {
				return GetTypedColumnValue<bool>("IsOnChange");
			}
			set {
				SetColumnValue("IsOnChange", value);
			}
		}

		/// <exclude/>
		public Guid LMStartEventId {
			get {
				return GetTypedColumnValue<Guid>("LMStartEventId");
			}
			set {
				SetColumnValue("LMStartEventId", value);
				_lMStartEvent = null;
			}
		}

		/// <exclude/>
		public string LMStartEventMessageTemplate {
			get {
				return GetTypedColumnValue<string>("LMStartEventMessageTemplate");
			}
			set {
				SetColumnValue("LMStartEventMessageTemplate", value);
				if (_lMStartEvent != null) {
					_lMStartEvent.MessageTemplate = value;
				}
			}
		}

		private LMStartEvent _lMStartEvent;
		/// <summary>
		/// Стартовые события системных сообщений.
		/// </summary>
		public LMStartEvent LMStartEvent {
			get {
				return _lMStartEvent ??
					(_lMStartEvent = new LMStartEvent(LookupColumnEntities.GetEntity("LMStartEvent")));
			}
		}

		/// <summary>
		/// Порядковый номер.
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

