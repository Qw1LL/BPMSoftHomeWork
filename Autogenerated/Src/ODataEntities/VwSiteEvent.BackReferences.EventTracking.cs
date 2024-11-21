namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwSiteEvent

	/// <exclude/>
	public class VwSiteEvent : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSiteEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSiteEvent";
		}

		public VwSiteEvent(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwSiteEvent";
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
		/// Дата/время.
		/// </summary>
		public DateTime EventDate {
			get {
				return GetTypedColumnValue<DateTime>("EventDate");
			}
			set {
				SetColumnValue("EventDate", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <summary>
		/// Источник.
		/// </summary>
		public string Source {
			get {
				return GetTypedColumnValue<string>("Source");
			}
			set {
				SetColumnValue("Source", value);
			}
		}

		/// <summary>
		/// Тег.
		/// </summary>
		public string Tag {
			get {
				return GetTypedColumnValue<string>("Tag");
			}
			set {
				SetColumnValue("Tag", value);
			}
		}

		/// <exclude/>
		public Guid SiteEventTypeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventTypeId");
			}
			set {
				SetColumnValue("SiteEventTypeId", value);
				_siteEventType = null;
			}
		}

		/// <exclude/>
		public string SiteEventTypeName {
			get {
				return GetTypedColumnValue<string>("SiteEventTypeName");
			}
			set {
				SetColumnValue("SiteEventTypeName", value);
				if (_siteEventType != null) {
					_siteEventType.Name = value;
				}
			}
		}

		private SiteEventType _siteEventType;
		/// <summary>
		/// Событие сайта.
		/// </summary>
		public SiteEventType SiteEventType {
			get {
				return _siteEventType ??
					(_siteEventType = new SiteEventType(LookupColumnEntities.GetEntity("SiteEventType")));
			}
		}

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = new LeadType(LookupColumnEntities.GetEntity("LeadType")));
			}
		}

		/// <summary>
		/// BpmSessionID.
		/// </summary>
		public Guid BpmSessionId {
			get {
				return GetTypedColumnValue<Guid>("BpmSessionId");
			}
			set {
				SetColumnValue("BpmSessionId", value);
			}
		}

		/// <exclude/>
		public Guid LeadId {
			get {
				return GetTypedColumnValue<Guid>("LeadId");
			}
			set {
				SetColumnValue("LeadId", value);
				_lead = null;
			}
		}

		/// <exclude/>
		public string LeadLeadName {
			get {
				return GetTypedColumnValue<string>("LeadLeadName");
			}
			set {
				SetColumnValue("LeadLeadName", value);
				if (_lead != null) {
					_lead.LeadName = value;
				}
			}
		}

		private Lead _lead;
		/// <summary>
		/// Лид.
		/// </summary>
		public Lead Lead {
			get {
				return _lead ??
					(_lead = new Lead(LookupColumnEntities.GetEntity("Lead")));
			}
		}

		#endregion

	}

	#endregion

}

