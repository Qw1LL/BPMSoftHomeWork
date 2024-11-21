namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: VwPortalOpportunity

	/// <exclude/>
	public class VwPortalOpportunity : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwPortalOpportunity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwPortalOpportunity";
		}

		public VwPortalOpportunity(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "VwPortalOpportunity";
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
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = new Account(LookupColumnEntities.GetEntity("Account")));
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		/// <summary>
		/// Бюджет клиента.
		/// </summary>
		public Decimal Budget {
			get {
				return GetTypedColumnValue<Decimal>("Budget");
			}
			set {
				SetColumnValue("Budget", value);
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
		/// Дата закрытия.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private OpportunityType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public OpportunityType Type {
			get {
				return _type ??
					(_type = new OpportunityType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		/// <exclude/>
		public Guid StageId {
			get {
				return GetTypedColumnValue<Guid>("StageId");
			}
			set {
				SetColumnValue("StageId", value);
				_stage = null;
			}
		}

		/// <exclude/>
		public string StageName {
			get {
				return GetTypedColumnValue<string>("StageName");
			}
			set {
				SetColumnValue("StageName", value);
				if (_stage != null) {
					_stage.Name = value;
				}
			}
		}

		private OpportunityStage _stage;
		/// <summary>
		/// Стадия.
		/// </summary>
		public OpportunityStage Stage {
			get {
				return _stage ??
					(_stage = new OpportunityStage(LookupColumnEntities.GetEntity("Stage")));
			}
		}

		/// <summary>
		/// Вероятность, %.
		/// </summary>
		public int Probability {
			get {
				return GetTypedColumnValue<int>("Probability");
			}
			set {
				SetColumnValue("Probability", value);
			}
		}

		/// <summary>
		/// Роли партнера.
		/// </summary>
		public string PartnerRoles {
			get {
				return GetTypedColumnValue<string>("PartnerRoles");
			}
			set {
				SetColumnValue("PartnerRoles", value);
			}
		}

		/// <exclude/>
		public Guid PartnerId {
			get {
				return GetTypedColumnValue<Guid>("PartnerId");
			}
			set {
				SetColumnValue("PartnerId", value);
				_partner = null;
			}
		}

		/// <exclude/>
		public string PartnerName {
			get {
				return GetTypedColumnValue<string>("PartnerName");
			}
			set {
				SetColumnValue("PartnerName", value);
				if (_partner != null) {
					_partner.Name = value;
				}
			}
		}

		private Account _partner;
		/// <summary>
		/// Партнер.
		/// </summary>
		public Account Partner {
			get {
				return _partner ??
					(_partner = new Account(LookupColumnEntities.GetEntity("Partner")));
			}
		}

		#endregion

	}

	#endregion

}

