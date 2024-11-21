namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: CampaignStep

	/// <exclude/>
	public class CampaignStep : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public CampaignStep(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignStep";
		}

		public CampaignStep(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "CampaignStep";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<CampaignStepRoute> CampaignStepRouteCollectionBySourceStep {
			get;
			set;
		}

		public IEnumerable<CampaignStepRoute> CampaignStepRouteCollectionByTargetStep {
			get;
			set;
		}

		public IEnumerable<CampaignTarget> CampaignTargetCollectionByCurrentStep {
			get;
			set;
		}

		public IEnumerable<CampaignTarget> CampaignTargetCollectionByNextStep {
			get;
			set;
		}

		public IEnumerable<CampaignTarget> CampaignTargetCollectionByPassedStep {
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
		/// JSON.
		/// </summary>
		public string JSON {
			get {
				return GetTypedColumnValue<string>("JSON");
			}
			set {
				SetColumnValue("JSON", value);
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
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = new Campaign(LookupColumnEntities.GetEntity("Campaign")));
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

		private CampaignStepType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CampaignStepType Type {
			get {
				return _type ??
					(_type = new CampaignStepType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		#endregion

	}

	#endregion

}

