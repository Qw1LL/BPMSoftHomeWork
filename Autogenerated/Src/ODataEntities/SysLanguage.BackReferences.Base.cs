namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: SysLanguage

	/// <exclude/>
	public class SysLanguage : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLanguage(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLanguage";
		}

		public SysLanguage(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "SysLanguage";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Channel> ChannelCollectionByLanguage {
			get;
			set;
		}

		public IEnumerable<Contact> ContactCollectionByLanguage {
			get;
			set;
		}

		public IEnumerable<EmailTemplateLang> EmailTemplateLangCollectionByLanguage {
			get;
			set;
		}

		public IEnumerable<MailboxForIncidentRegistration> MailboxForIncidentRegistrationCollectionByMessageLanguage {
			get;
			set;
		}

		public IEnumerable<MailboxSyncSettings> MailboxSyncSettingsCollectionByMessageLanguage {
			get;
			set;
		}

		public IEnumerable<Playbook> PlaybookCollectionByCulture {
			get;
			set;
		}

		public IEnumerable<SysAdminUnit> SysAdminUnitCollectionByDateTimeFormat {
			get;
			set;
		}

		public IEnumerable<SysCulture> SysCultureCollectionByLanguage {
			get;
			set;
		}

		public IEnumerable<Touch> TouchCollectionByLanguage {
			get;
			set;
		}

		public IEnumerable<VwGroupSysAdminUnit> VwGroupSysAdminUnitCollectionByDateTimeFormat {
			get;
			set;
		}

		public IEnumerable<VwSysAdminUnit> VwSysAdminUnitCollectionByDateTimeFormat {
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
		/// Код.
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
		/// Используется.
		/// </summary>
		public bool IsUsed {
			get {
				return GetTypedColumnValue<bool>("IsUsed");
			}
			set {
				SetColumnValue("IsUsed", value);
			}
		}

		#endregion

	}

	#endregion

}

