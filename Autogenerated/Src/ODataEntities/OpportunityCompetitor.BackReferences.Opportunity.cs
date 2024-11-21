namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: OpportunityCompetitor

	/// <exclude/>
	public class OpportunityCompetitor : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public OpportunityCompetitor(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityCompetitor";
		}

		public OpportunityCompetitor(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "OpportunityCompetitor";
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
		public Guid CompetitorId {
			get {
				return GetTypedColumnValue<Guid>("CompetitorId");
			}
			set {
				SetColumnValue("CompetitorId", value);
				_competitor = null;
			}
		}

		/// <exclude/>
		public string CompetitorName {
			get {
				return GetTypedColumnValue<string>("CompetitorName");
			}
			set {
				SetColumnValue("CompetitorName", value);
				if (_competitor != null) {
					_competitor.Name = value;
				}
			}
		}

		private Account _competitor;
		/// <summary>
		/// Производитель.
		/// </summary>
		public Account Competitor {
			get {
				return _competitor ??
					(_competitor = new Account(LookupColumnEntities.GetEntity("Competitor")));
			}
		}

		/// <summary>
		/// Слабые стороны.
		/// </summary>
		public string Weakness {
			get {
				return GetTypedColumnValue<string>("Weakness");
			}
			set {
				SetColumnValue("Weakness", value);
			}
		}

		/// <summary>
		/// Сильные стороны.
		/// </summary>
		public string Strengths {
			get {
				return GetTypedColumnValue<string>("Strengths");
			}
			set {
				SetColumnValue("Strengths", value);
			}
		}

		/// <exclude/>
		public Guid CompetitorProductId {
			get {
				return GetTypedColumnValue<Guid>("CompetitorProductId");
			}
			set {
				SetColumnValue("CompetitorProductId", value);
				_competitorProduct = null;
			}
		}

		/// <exclude/>
		public string CompetitorProductName {
			get {
				return GetTypedColumnValue<string>("CompetitorProductName");
			}
			set {
				SetColumnValue("CompetitorProductName", value);
				if (_competitorProduct != null) {
					_competitorProduct.Name = value;
				}
			}
		}

		private CompetitorProduct _competitorProduct;
		/// <summary>
		/// Продукт конкурента.
		/// </summary>
		public CompetitorProduct CompetitorProduct {
			get {
				return _competitorProduct ??
					(_competitorProduct = new CompetitorProduct(LookupColumnEntities.GetEntity("CompetitorProduct")));
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
		/// Сумма предложения.
		/// </summary>
		public Decimal CompetitorAmount {
			get {
				return GetTypedColumnValue<Decimal>("CompetitorAmount");
			}
			set {
				SetColumnValue("CompetitorAmount", value);
			}
		}

		/// <summary>
		/// Победитель.
		/// </summary>
		public bool IsWinner {
			get {
				return GetTypedColumnValue<bool>("IsWinner");
			}
			set {
				SetColumnValue("IsWinner", value);
			}
		}

		/// <exclude/>
		public Guid SupplierId {
			get {
				return GetTypedColumnValue<Guid>("SupplierId");
			}
			set {
				SetColumnValue("SupplierId", value);
				_supplier = null;
			}
		}

		/// <exclude/>
		public string SupplierName {
			get {
				return GetTypedColumnValue<string>("SupplierName");
			}
			set {
				SetColumnValue("SupplierName", value);
				if (_supplier != null) {
					_supplier.Name = value;
				}
			}
		}

		private Account _supplier;
		/// <summary>
		/// Поставщик.
		/// </summary>
		public Account Supplier {
			get {
				return _supplier ??
					(_supplier = new Account(LookupColumnEntities.GetEntity("Supplier")));
			}
		}

		#endregion

	}

	#endregion

}

