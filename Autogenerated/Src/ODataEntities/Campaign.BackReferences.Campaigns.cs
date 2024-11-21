namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Campaign

	/// <exclude/>
	public class Campaign : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Campaign(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Campaign";
		}

		public Campaign(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Campaign";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<BulkEmail> BulkEmailCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignAnalyticsLog> CampaignAnalyticsLogCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignFile> CampaignFileCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignInFolder> CampaignInFolderCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignInTag> CampaignInTagCollectionByEntity {
			get;
			set;
		}

		public IEnumerable<CampaignItem> CampaignItemCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignLog> CampaignLogCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignParticipant> CampaignParticipantCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignParticipantOp> CampaignParticipantOpCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignSegment> CampaignSegmentCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignStep> CampaignStepCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignTarget> CampaignTargetCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<CampaignVersion> CampaignVersionCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<ContactFolder> ContactFolderCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<Event> EventCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<FormSubmit> FormSubmitCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<Lead> LeadCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<VwBulkEmailInCampaign> VwBulkEmailInCampaignCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<VwCampaignLog> VwCampaignLogCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<VwEventInCampaign> VwEventInCampaignCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<VwFolderInCampaign> VwFolderInCampaignCollectionByCampaign {
			get;
			set;
		}

		public IEnumerable<VwLandingInCampaign> VwLandingInCampaignCollectionByCampaign {
			get;
			set;
		}

		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

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
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

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
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		public int ProcessListeners {
			get {
				return GetTypedColumnValue<int>("ProcessListeners");
			}
			set {
				SetColumnValue("ProcessListeners", value);
			}
		}

		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid CampaignStatusId {
			get {
				return GetTypedColumnValue<Guid>("CampaignStatusId");
			}
			set {
				SetColumnValue("CampaignStatusId", value);
				_campaignStatus = null;
			}
		}

		/// <exclude/>
		public string CampaignStatusName {
			get {
				return GetTypedColumnValue<string>("CampaignStatusName");
			}
			set {
				SetColumnValue("CampaignStatusName", value);
				if (_campaignStatus != null) {
					_campaignStatus.Name = value;
				}
			}
		}

		private CampaignStatus _campaignStatus;
		public CampaignStatus CampaignStatus {
			get {
				return _campaignStatus ??
					(_campaignStatus = new CampaignStatus(LookupColumnEntities.GetEntity("CampaignStatus")));
			}
		}

		/// <exclude/>
		public Guid SegmentsStatusId {
			get {
				return GetTypedColumnValue<Guid>("SegmentsStatusId");
			}
			set {
				SetColumnValue("SegmentsStatusId", value);
				_segmentsStatus = null;
			}
		}

		/// <exclude/>
		public string SegmentsStatusName {
			get {
				return GetTypedColumnValue<string>("SegmentsStatusName");
			}
			set {
				SetColumnValue("SegmentsStatusName", value);
				if (_segmentsStatus != null) {
					_segmentsStatus.Name = value;
				}
			}
		}

		private SegmentStatus _segmentsStatus;
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = new SegmentStatus(LookupColumnEntities.GetEntity("SegmentsStatus")));
			}
		}

		public string SchemaData {
			get {
				return GetTypedColumnValue<string>("SchemaData");
			}
			set {
				SetColumnValue("SchemaData", value);
			}
		}

		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		public string TargetDescription {
			get {
				return GetTypedColumnValue<string>("TargetDescription");
			}
			set {
				SetColumnValue("TargetDescription", value);
			}
		}

		public Decimal TargetPercent {
			get {
				return GetTypedColumnValue<Decimal>("TargetPercent");
			}
			set {
				SetColumnValue("TargetPercent", value);
			}
		}

		public int TargetTotal {
			get {
				return GetTypedColumnValue<int>("TargetTotal");
			}
			set {
				SetColumnValue("TargetTotal", value);
			}
		}

		public int TargetAchieve {
			get {
				return GetTypedColumnValue<int>("TargetAchieve");
			}
			set {
				SetColumnValue("TargetAchieve", value);
			}
		}

		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		public DateTime EndDate {
			get {
				return GetTypedColumnValue<DateTime>("EndDate");
			}
			set {
				SetColumnValue("EndDate", value);
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
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
			}
		}

		public string UtmCampaign {
			get {
				return GetTypedColumnValue<string>("UtmCampaign");
			}
			set {
				SetColumnValue("UtmCampaign", value);
			}
		}

		public DateTime NextFireTime {
			get {
				return GetTypedColumnValue<DateTime>("NextFireTime");
			}
			set {
				SetColumnValue("NextFireTime", value);
			}
		}

		public int FirePeriod {
			get {
				return GetTypedColumnValue<int>("FirePeriod");
			}
			set {
				SetColumnValue("FirePeriod", value);
			}
		}

		public Guid CampaignSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("CampaignSchemaUId");
			}
			set {
				SetColumnValue("CampaignSchemaUId", value);
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

		private CampaignType _type;
		public CampaignType Type {
			get {
				return _type ??
					(_type = new CampaignType(LookupColumnEntities.GetEntity("Type")));
			}
		}

		public bool InProgress {
			get {
				return GetTypedColumnValue<bool>("InProgress");
			}
			set {
				SetColumnValue("InProgress", value);
			}
		}

		/// <exclude/>
		public Guid ScheduledStartModeId {
			get {
				return GetTypedColumnValue<Guid>("ScheduledStartModeId");
			}
			set {
				SetColumnValue("ScheduledStartModeId", value);
				_scheduledStartMode = null;
			}
		}

		/// <exclude/>
		public string ScheduledStartModeName {
			get {
				return GetTypedColumnValue<string>("ScheduledStartModeName");
			}
			set {
				SetColumnValue("ScheduledStartModeName", value);
				if (_scheduledStartMode != null) {
					_scheduledStartMode.Name = value;
				}
			}
		}

		private CampaignScheduledMode _scheduledStartMode;
		public CampaignScheduledMode ScheduledStartMode {
			get {
				return _scheduledStartMode ??
					(_scheduledStartMode = new CampaignScheduledMode(LookupColumnEntities.GetEntity("ScheduledStartMode")));
			}
		}

		/// <exclude/>
		public Guid ScheduledStopModeId {
			get {
				return GetTypedColumnValue<Guid>("ScheduledStopModeId");
			}
			set {
				SetColumnValue("ScheduledStopModeId", value);
				_scheduledStopMode = null;
			}
		}

		/// <exclude/>
		public string ScheduledStopModeName {
			get {
				return GetTypedColumnValue<string>("ScheduledStopModeName");
			}
			set {
				SetColumnValue("ScheduledStopModeName", value);
				if (_scheduledStopMode != null) {
					_scheduledStopMode.Name = value;
				}
			}
		}

		private CampaignScheduledMode _scheduledStopMode;
		public CampaignScheduledMode ScheduledStopMode {
			get {
				return _scheduledStopMode ??
					(_scheduledStopMode = new CampaignScheduledMode(LookupColumnEntities.GetEntity("ScheduledStopMode")));
			}
		}

		public DateTime ScheduledStartDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledStartDate");
			}
			set {
				SetColumnValue("ScheduledStartDate", value);
			}
		}

		public DateTime ScheduledStopDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledStopDate");
			}
			set {
				SetColumnValue("ScheduledStopDate", value);
			}
		}

		public DateTime PrevExecutedOn {
			get {
				return GetTypedColumnValue<DateTime>("PrevExecutedOn");
			}
			set {
				SetColumnValue("PrevExecutedOn", value);
			}
		}

		#endregion

	}

	#endregion

}

