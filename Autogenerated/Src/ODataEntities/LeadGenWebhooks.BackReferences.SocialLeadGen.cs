namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: LeadGenWebhooks

	/// <exclude/>
	public class LeadGenWebhooks : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public LeadGenWebhooks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenWebhooks";
		}

		public LeadGenWebhooks(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "LeadGenWebhooks";
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
		/// Date created on the social network.
		/// </summary>
		public DateTime SocialCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("SocialCreatedOn");
			}
			set {
				SetColumnValue("SocialCreatedOn", value);
			}
		}

		/// <summary>
		/// Webhook status update date.
		/// </summary>
		public DateTime WebhookStatusUpdateDate {
			get {
				return GetTypedColumnValue<DateTime>("WebhookStatusUpdateDate");
			}
			set {
				SetColumnValue("WebhookStatusUpdateDate", value);
			}
		}

		/// <summary>
		/// Metadata.
		/// </summary>
		public string FormMetadata {
			get {
				return GetTypedColumnValue<string>("FormMetadata");
			}
			set {
				SetColumnValue("FormMetadata", value);
			}
		}

		/// <summary>
		/// Social lead id.
		/// </summary>
		public string SocialLeadId {
			get {
				return GetTypedColumnValue<string>("SocialLeadId");
			}
			set {
				SetColumnValue("SocialLeadId", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenWebhookStatusId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenWebhookStatusId");
			}
			set {
				SetColumnValue("LeadGenWebhookStatusId", value);
				_leadGenWebhookStatus = null;
			}
		}

		/// <exclude/>
		public string LeadGenWebhookStatusName {
			get {
				return GetTypedColumnValue<string>("LeadGenWebhookStatusName");
			}
			set {
				SetColumnValue("LeadGenWebhookStatusName", value);
				if (_leadGenWebhookStatus != null) {
					_leadGenWebhookStatus.Name = value;
				}
			}
		}

		private LeadGenWebhookStatus _leadGenWebhookStatus;
		/// <summary>
		/// Webhook status.
		/// </summary>
		public LeadGenWebhookStatus LeadGenWebhookStatus {
			get {
				return _leadGenWebhookStatus ??
					(_leadGenWebhookStatus = new LeadGenWebhookStatus(LookupColumnEntities.GetEntity("LeadGenWebhookStatus")));
			}
		}

		/// <exclude/>
		public Guid LeadGenNetworkTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenNetworkTypeId");
			}
			set {
				SetColumnValue("LeadGenNetworkTypeId", value);
				_leadGenNetworkType = null;
			}
		}

		/// <exclude/>
		public string LeadGenNetworkTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenNetworkTypeName");
			}
			set {
				SetColumnValue("LeadGenNetworkTypeName", value);
				if (_leadGenNetworkType != null) {
					_leadGenNetworkType.Name = value;
				}
			}
		}

		private LeadGenNetworkType _leadGenNetworkType;
		/// <summary>
		/// Social network type.
		/// </summary>
		public LeadGenNetworkType LeadGenNetworkType {
			get {
				return _leadGenNetworkType ??
					(_leadGenNetworkType = new LeadGenNetworkType(LookupColumnEntities.GetEntity("LeadGenNetworkType")));
			}
		}

		/// <summary>
		/// Integration id.
		/// </summary>
		public Guid IntegrationId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <summary>
		/// Form id.
		/// </summary>
		public string FormId {
			get {
				return GetTypedColumnValue<string>("FormId");
			}
			set {
				SetColumnValue("FormId", value);
			}
		}

		#endregion

	}

	#endregion

}

