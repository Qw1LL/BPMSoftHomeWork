namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysProcessElementToDo

	/// <exclude/>
	public class SysProcessElementToDo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysProcessElementToDo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessElementToDo";
		}

		public SysProcessElementToDo(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysProcessElementToDo";
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
		/// Дата/Время начала.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Тема.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Ответственный.
		/// </summary>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
			}
		}

		/// <summary>
		/// Идентификатор процесса.
		/// </summary>
		public Guid SysProcessDataId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessDataId");
			}
			set {
				SetColumnValue("SysProcessDataId", value);
			}
		}

		/// <summary>
		/// Имя менеджера схемы процесса.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
			}
		}

		/// <summary>
		/// Идентификатор схемы процесса.
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
		/// Идентификатор схемы элемента.
		/// </summary>
		public Guid ElementSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ElementSchemaUId");
			}
			set {
				SetColumnValue("ElementSchemaUId", value);
			}
		}

		/// <summary>
		/// Group type.
		/// </summary>
		public int GroupType {
			get {
				return GetTypedColumnValue<int>("GroupType");
			}
			set {
				SetColumnValue("GroupType", value);
			}
		}

		/// <summary>
		/// Group identifier.
		/// </summary>
		public Guid GroupId {
			get {
				return GetTypedColumnValue<Guid>("GroupId");
			}
			set {
				SetColumnValue("GroupId", value);
			}
		}

		#endregion

	}

	#endregion

}

