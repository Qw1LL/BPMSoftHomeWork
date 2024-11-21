namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: EmailMessageData

	/// <exclude/>
	public class EmailMessageData : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public EmailMessageData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmailMessageData";
		}

		public EmailMessageData(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "EmailMessageData";
			this.CopyEntityLookupProperties(source);
		}

		#endregion

		#region Properties: Public

		public IEnumerable<EmailMessageData> EmailMessageDataCollectionByParentMessage {
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
		/// Created on.
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
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = new Contact(LookupColumnEntities.GetEntity("CreatedBy")));
			}
		}

		/// <summary>
		/// Modified on.
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
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = new Contact(LookupColumnEntities.GetEntity("ModifiedBy")));
			}
		}

		/// <summary>
		/// Active processes.
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
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = new Activity(LookupColumnEntities.GetEntity("Activity")));
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
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = new Contact(LookupColumnEntities.GetEntity("Owner")));
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

		private ActivityParticipantRole _role;
		/// <summary>
		/// Role.
		/// </summary>
		public ActivityParticipantRole Role {
			get {
				return _role ??
					(_role = new ActivityParticipantRole(LookupColumnEntities.GetEntity("Role")));
			}
		}

		/// <summary>
		/// Headers.
		/// </summary>
		public string Headers {
			get {
				return GetTypedColumnValue<string>("Headers");
			}
			set {
				SetColumnValue("Headers", value);
			}
		}

		/// <summary>
		/// IsNeedProcess.
		/// </summary>
		public bool IsNeedProcess {
			get {
				return GetTypedColumnValue<bool>("IsNeedProcess");
			}
			set {
				SetColumnValue("IsNeedProcess", value);
			}
		}

		/// <summary>
		/// MailboxSyncSettings.
		/// </summary>
		public Guid MailboxSyncSettings {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettings");
			}
			set {
				SetColumnValue("MailboxSyncSettings", value);
			}
		}

		/// <summary>
		/// MessageId.
		/// </summary>
		public string MessageId {
			get {
				return GetTypedColumnValue<string>("MessageId");
			}
			set {
				SetColumnValue("MessageId", value);
			}
		}

		/// <summary>
		/// InReplyTo.
		/// </summary>
		public string InReplyTo {
			get {
				return GetTypedColumnValue<string>("InReplyTo");
			}
			set {
				SetColumnValue("InReplyTo", value);
			}
		}

		/// <exclude/>
		public Guid ParentMessageId {
			get {
				return GetTypedColumnValue<Guid>("ParentMessageId");
			}
			set {
				SetColumnValue("ParentMessageId", value);
				_parentMessage = null;
			}
		}

		/// <exclude/>
		public string ParentMessageMessageId {
			get {
				return GetTypedColumnValue<string>("ParentMessageMessageId");
			}
			set {
				SetColumnValue("ParentMessageMessageId", value);
				if (_parentMessage != null) {
					_parentMessage.MessageId = value;
				}
			}
		}

		private EmailMessageData _parentMessage;
		/// <summary>
		/// ParentMessage.
		/// </summary>
		public EmailMessageData ParentMessage {
			get {
				return _parentMessage ??
					(_parentMessage = new EmailMessageData(LookupColumnEntities.GetEntity("ParentMessage")));
			}
		}

		/// <summary>
		/// SyncSessionId.
		/// </summary>
		public string SyncSessionId {
			get {
				return GetTypedColumnValue<string>("SyncSessionId");
			}
			set {
				SetColumnValue("SyncSessionId", value);
			}
		}

		/// <summary>
		/// ExchangeThreadId.
		/// </summary>
		public Guid ExchangeThreadId {
			get {
				return GetTypedColumnValue<Guid>("ExchangeThreadId");
			}
			set {
				SetColumnValue("ExchangeThreadId", value);
			}
		}

		/// <summary>
		/// ExchangeThreadPosition.
		/// </summary>
		public int ExchangeThreadPosition {
			get {
				return GetTypedColumnValue<int>("ExchangeThreadPosition");
			}
			set {
				SetColumnValue("ExchangeThreadPosition", value);
			}
		}

		/// <summary>
		/// References.
		/// </summary>
		public string References {
			get {
				return GetTypedColumnValue<string>("References");
			}
			set {
				SetColumnValue("References", value);
			}
		}

		/// <summary>
		/// ConversationId.
		/// </summary>
		public Guid ConversationId {
			get {
				return GetTypedColumnValue<Guid>("ConversationId");
			}
			set {
				SetColumnValue("ConversationId", value);
			}
		}

		/// <summary>
		/// SendDate.
		/// </summary>
		public DateTime SendDate {
			get {
				return GetTypedColumnValue<DateTime>("SendDate");
			}
			set {
				SetColumnValue("SendDate", value);
			}
		}

		#endregion

	}

	#endregion

}

