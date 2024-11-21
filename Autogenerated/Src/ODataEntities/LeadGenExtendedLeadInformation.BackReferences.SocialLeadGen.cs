namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadGenExtendedLeadInformation

	/// <exclude/>
	public class LeadGenExtendedLeadInformation : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadGenExtendedLeadInformation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenExtendedLeadInformation";
		}

		public LeadGenExtendedLeadInformation(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadGenExtendedLeadInformation";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<Lead> LeadCollectionByLeadGenExtendedLeadInfo {
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
		/// Id из социальной сети.
		/// </summary>
		public string SocialLeadId {
			get {
				return GetTypedColumnValue<string>("SocialLeadId");
			}
			set {
				SetColumnValue("SocialLeadId", value);
			}
		}

		/// <summary>
		/// Органика.
		/// </summary>
		public bool IsOrganicFacebook {
			get {
				return GetTypedColumnValue<bool>("IsOrganicFacebook");
			}
			set {
				SetColumnValue("IsOrganicFacebook", value);
			}
		}

		/// <summary>
		/// Платформа.
		/// </summary>
		public string FacebookPlatform {
			get {
				return GetTypedColumnValue<string>("FacebookPlatform");
			}
			set {
				SetColumnValue("FacebookPlatform", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenLeadFormsId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenLeadFormsId");
			}
			set {
				SetColumnValue("LeadGenLeadFormsId", value);
				_leadGenLeadForms = null;
			}
		}

		/// <exclude/>
		public string LeadGenLeadFormsName {
			get {
				return GetTypedColumnValue<string>("LeadGenLeadFormsName");
			}
			set {
				SetColumnValue("LeadGenLeadFormsName", value);
				if (_leadGenLeadForms != null) {
					_leadGenLeadForms.Name = value;
				}
			}
		}

		private LeadGenLeadForms _leadGenLeadForms;
		/// <summary>
		/// Лид форма.
		/// </summary>
		public LeadGenLeadForms LeadGenLeadForms {
			get {
				return _leadGenLeadForms ??
					(_leadGenLeadForms = new LeadGenLeadForms(LookupColumnEntities.GetEntity("LeadGenLeadForms")));
			}
		}

		/// <exclude/>
		public Guid LeadGenCampaignGroupsId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenCampaignGroupsId");
			}
			set {
				SetColumnValue("LeadGenCampaignGroupsId", value);
				_leadGenCampaignGroups = null;
			}
		}

		/// <exclude/>
		public string LeadGenCampaignGroupsName {
			get {
				return GetTypedColumnValue<string>("LeadGenCampaignGroupsName");
			}
			set {
				SetColumnValue("LeadGenCampaignGroupsName", value);
				if (_leadGenCampaignGroups != null) {
					_leadGenCampaignGroups.Name = value;
				}
			}
		}

		private LeadGenCampaignGroups _leadGenCampaignGroups;
		/// <summary>
		/// Группа кампаний.
		/// </summary>
		public LeadGenCampaignGroups LeadGenCampaignGroups {
			get {
				return _leadGenCampaignGroups ??
					(_leadGenCampaignGroups = new LeadGenCampaignGroups(LookupColumnEntities.GetEntity("LeadGenCampaignGroups")));
			}
		}

		/// <exclude/>
		public Guid LeadGenCampaignsId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenCampaignsId");
			}
			set {
				SetColumnValue("LeadGenCampaignsId", value);
				_leadGenCampaigns = null;
			}
		}

		/// <exclude/>
		public string LeadGenCampaignsName {
			get {
				return GetTypedColumnValue<string>("LeadGenCampaignsName");
			}
			set {
				SetColumnValue("LeadGenCampaignsName", value);
				if (_leadGenCampaigns != null) {
					_leadGenCampaigns.Name = value;
				}
			}
		}

		private LeadGenCampaigns _leadGenCampaigns;
		/// <summary>
		/// Кампания.
		/// </summary>
		public LeadGenCampaigns LeadGenCampaigns {
			get {
				return _leadGenCampaigns ??
					(_leadGenCampaigns = new LeadGenCampaigns(LookupColumnEntities.GetEntity("LeadGenCampaigns")));
			}
		}

		/// <exclude/>
		public Guid LeadGenAdSetsId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenAdSetsId");
			}
			set {
				SetColumnValue("LeadGenAdSetsId", value);
				_leadGenAdSets = null;
			}
		}

		/// <exclude/>
		public string LeadGenAdSetsName {
			get {
				return GetTypedColumnValue<string>("LeadGenAdSetsName");
			}
			set {
				SetColumnValue("LeadGenAdSetsName", value);
				if (_leadGenAdSets != null) {
					_leadGenAdSets.Name = value;
				}
			}
		}

		private LeadGenAdSets _leadGenAdSets;
		/// <summary>
		/// Группа объявлений.
		/// </summary>
		public LeadGenAdSets LeadGenAdSets {
			get {
				return _leadGenAdSets ??
					(_leadGenAdSets = new LeadGenAdSets(LookupColumnEntities.GetEntity("LeadGenAdSets")));
			}
		}

		/// <exclude/>
		public Guid LeadGenAdsId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenAdsId");
			}
			set {
				SetColumnValue("LeadGenAdsId", value);
				_leadGenAds = null;
			}
		}

		/// <exclude/>
		public string LeadGenAdsName {
			get {
				return GetTypedColumnValue<string>("LeadGenAdsName");
			}
			set {
				SetColumnValue("LeadGenAdsName", value);
				if (_leadGenAds != null) {
					_leadGenAds.Name = value;
				}
			}
		}

		private LeadGenAds _leadGenAds;
		/// <summary>
		/// Объявление.
		/// </summary>
		public LeadGenAds LeadGenAds {
			get {
				return _leadGenAds ??
					(_leadGenAds = new LeadGenAds(LookupColumnEntities.GetEntity("LeadGenAds")));
			}
		}

		#endregion

	}

	#endregion

}

