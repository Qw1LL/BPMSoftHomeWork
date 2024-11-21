namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EmailTemplateMacros

	/// <exclude/>
	public class EmailTemplateMacros : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmailTemplateMacros(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailTemplateMacros";
		}

		public EmailTemplateMacros(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmailTemplateMacros";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<EmailTemplateMacros> EmailTemplateMacrosCollectionByParent {
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
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
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

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private EmailTemplateMacros _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public EmailTemplateMacros Parent {
			get {
				return _parent ??
					(_parent = new EmailTemplateMacros(LookupColumnEntities.GetEntity("Parent")));
			}
		}

		/// <summary>
		/// Путь колонки.
		/// </summary>
		public string ColumnPath {
			get {
				return GetTypedColumnValue<string>("ColumnPath");
			}
			set {
				SetColumnValue("ColumnPath", value);
			}
		}

		/// <exclude/>
		public Guid AccountCommunicationTypeId {
			get {
				return GetTypedColumnValue<Guid>("AccountCommunicationTypeId");
			}
			set {
				SetColumnValue("AccountCommunicationTypeId", value);
				_accountCommunicationType = null;
			}
		}

		/// <exclude/>
		public string AccountCommunicationTypeName {
			get {
				return GetTypedColumnValue<string>("AccountCommunicationTypeName");
			}
			set {
				SetColumnValue("AccountCommunicationTypeName", value);
				if (_accountCommunicationType != null) {
					_accountCommunicationType.Name = value;
				}
			}
		}

		private CommunicationType _accountCommunicationType;
		/// <summary>
		/// Тип cредства связи Контрагента.
		/// </summary>
		public CommunicationType AccountCommunicationType {
			get {
				return _accountCommunicationType ??
					(_accountCommunicationType = new CommunicationType(LookupColumnEntities.GetEntity("AccountCommunicationType")));
			}
		}

		/// <summary>
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

		/// <summary>
		/// Шаблон.
		/// </summary>
		public string Template {
			get {
				return GetTypedColumnValue<string>("Template");
			}
			set {
				SetColumnValue("Template", value);
			}
		}

		/// <summary>
		/// Не активен.
		/// </summary>
		public bool IsInactive {
			get {
				return GetTypedColumnValue<bool>("IsInactive");
			}
			set {
				SetColumnValue("IsInactive", value);
			}
		}

		#endregion

	}

	#endregion

}

