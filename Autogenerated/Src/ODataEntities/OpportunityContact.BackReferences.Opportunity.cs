namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OpportunityContact

	/// <exclude/>
	public class OpportunityContact : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OpportunityContact(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityContact";
		}

		public OpportunityContact(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OpportunityContact";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<OppContactMotivator> OppContactMotivatorCollectionByOpportunityContact {
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

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = new Opportunity(LookupColumnEntities.GetEntity("Opportunity")));
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
		/// Основной контакт.
		/// </summary>
		public bool IsMainContact {
			get {
				return GetTypedColumnValue<bool>("IsMainContact");
			}
			set {
				SetColumnValue("IsMainContact", value);
			}
		}

		/// <exclude/>
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private OppContactRole _role;
		/// <summary>
		/// Роль.
		/// </summary>
		public OppContactRole Role {
			get {
				return _role ??
					(_role = new OppContactRole(LookupColumnEntities.GetEntity("Role")));
			}
		}

		/// <exclude/>
		public Guid InfluenceId {
			get {
				return GetTypedColumnValue<Guid>("InfluenceId");
			}
			set {
				SetColumnValue("InfluenceId", value);
				_influence = null;
			}
		}

		/// <exclude/>
		public string InfluenceName {
			get {
				return GetTypedColumnValue<string>("InfluenceName");
			}
			set {
				SetColumnValue("InfluenceName", value);
				if (_influence != null) {
					_influence.Name = value;
				}
			}
		}

		private OppContactInfluence _influence;
		/// <summary>
		/// Степень влияния.
		/// </summary>
		public OppContactInfluence Influence {
			get {
				return _influence ??
					(_influence = new OppContactInfluence(LookupColumnEntities.GetEntity("Influence")));
			}
		}

		/// <summary>
		/// Мотиваторы.
		/// </summary>
		public string ContactMotivator {
			get {
				return GetTypedColumnValue<string>("ContactMotivator");
			}
			set {
				SetColumnValue("ContactMotivator", value);
			}
		}

		/// <exclude/>
		public Guid ContactLoyalityId {
			get {
				return GetTypedColumnValue<Guid>("ContactLoyalityId");
			}
			set {
				SetColumnValue("ContactLoyalityId", value);
				_contactLoyality = null;
			}
		}

		/// <exclude/>
		public string ContactLoyalityName {
			get {
				return GetTypedColumnValue<string>("ContactLoyalityName");
			}
			set {
				SetColumnValue("ContactLoyalityName", value);
				if (_contactLoyality != null) {
					_contactLoyality.Name = value;
				}
			}
		}

		private OppContactLoyality _contactLoyality;
		/// <summary>
		/// Лояльность.
		/// </summary>
		public OppContactLoyality ContactLoyality {
			get {
				return _contactLoyality ??
					(_contactLoyality = new OppContactLoyality(LookupColumnEntities.GetEntity("ContactLoyality")));
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

		#endregion

	}

	#endregion

}

