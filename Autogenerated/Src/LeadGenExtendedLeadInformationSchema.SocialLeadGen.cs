namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;

	#region Class: LeadGenExtendedLeadInformationSchema

	/// <exclude/>
	public class LeadGenExtendedLeadInformationSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadGenExtendedLeadInformationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenExtendedLeadInformationSchema(LeadGenExtendedLeadInformationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenExtendedLeadInformationSchema(LeadGenExtendedLeadInformationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47");
			RealUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47");
			Name = "LeadGenExtendedLeadInformation";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSocialLeadIdColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ba26b1f3-b339-e2ee-fa52-65b22a6b93c0")) == null) {
				Columns.Add(CreateIsOrganicFacebookColumn());
			}
			if (Columns.FindByUId(new Guid("4b8bc7e0-dcea-23da-065e-523ce4738301")) == null) {
				Columns.Add(CreateFacebookPlatformColumn());
			}
			if (Columns.FindByUId(new Guid("d59d1aa7-627b-3954-4447-1ae2696fc310")) == null) {
				Columns.Add(CreateLeadGenLeadFormsColumn());
			}
			if (Columns.FindByUId(new Guid("6d2d6a5e-dd3f-9af0-2713-715be88ffcd4")) == null) {
				Columns.Add(CreateLeadGenCampaignGroupsColumn());
			}
			if (Columns.FindByUId(new Guid("7edb001a-e906-2b7a-86a3-71da50a7cc76")) == null) {
				Columns.Add(CreateLeadGenCampaignsColumn());
			}
			if (Columns.FindByUId(new Guid("9c2e2412-d3a2-def6-fb2b-c50e3266a314")) == null) {
				Columns.Add(CreateLeadGenAdSetsColumn());
			}
			if (Columns.FindByUId(new Guid("b2e17ef9-574c-717f-c007-cb7d60bcb862")) == null) {
				Columns.Add(CreateLeadGenAdsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialLeadIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bee02e43-6239-1101-2ecc-ead727478133"),
				Name = @"SocialLeadId",
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateIsOrganicFacebookColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ba26b1f3-b339-e2ee-fa52-65b22a6b93c0"),
				Name = @"IsOrganicFacebook",
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateFacebookPlatformColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4b8bc7e0-dcea-23da-065e-523ce4738301"),
				Name = @"FacebookPlatform",
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenLeadFormsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d59d1aa7-627b-3954-4447-1ae2696fc310"),
				Name = @"LeadGenLeadForms",
				ReferenceSchemaUId = new Guid("c9382158-e397-4551-aee4-8712908d08cb"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenCampaignGroupsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6d2d6a5e-dd3f-9af0-2713-715be88ffcd4"),
				Name = @"LeadGenCampaignGroups",
				ReferenceSchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenCampaignsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7edb001a-e906-2b7a-86a3-71da50a7cc76"),
				Name = @"LeadGenCampaigns",
				ReferenceSchemaUId = new Guid("ef54d5f4-63e2-4f5f-b222-f12f6b9aa6c0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenAdSetsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c2e2412-d3a2-def6-fb2b-c50e3266a314"),
				Name = @"LeadGenAdSets",
				ReferenceSchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenAdsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b2e17ef9-574c-717f-c007-cb7d60bcb862"),
				Name = @"LeadGenAds",
				ReferenceSchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				ModifiedInSchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadGenExtendedLeadInformation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenExtendedLeadInformationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenExtendedLeadInformationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenExtendedLeadInformation

	/// <summary>
	/// Расширенная информация о лиде.
	/// </summary>
	public class LeadGenExtendedLeadInformation : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadGenExtendedLeadInformation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenExtendedLeadInformation";
		}

		public LeadGenExtendedLeadInformation(LeadGenExtendedLeadInformation source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_leadGenLeadForms = LookupColumnEntities.GetEntity("LeadGenLeadForms") as LeadGenLeadForms);
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
					(_leadGenCampaignGroups = LookupColumnEntities.GetEntity("LeadGenCampaignGroups") as LeadGenCampaignGroups);
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
					(_leadGenCampaigns = LookupColumnEntities.GetEntity("LeadGenCampaigns") as LeadGenCampaigns);
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
					(_leadGenAdSets = LookupColumnEntities.GetEntity("LeadGenAdSets") as LeadGenAdSets);
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
					(_leadGenAds = LookupColumnEntities.GetEntity("LeadGenAds") as LeadGenAds);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadGenExtendedLeadInformation(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadGenExtendedLeadInformation
	{

		public LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a94aecd6-9df6-48fa-90ec-fbb726b26d47");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess : LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess<LeadGenExtendedLeadInformation>
	{

		public LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess

	public partial class LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenExtendedLeadInformationEventsProcess

	/// <exclude/>
	public class LeadGenExtendedLeadInformationEventsProcess : LeadGenExtendedLeadInformation_SocialLeadGenEventsProcess
	{

		public LeadGenExtendedLeadInformationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

