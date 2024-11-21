namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: NotificationsSettings

	/// <exclude/>
	public class NotificationsSettings : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public NotificationsSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotificationsSettings";
		}

		public NotificationsSettings(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "NotificationsSettings";
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
		public Guid SysImageId {
			get {
				return GetTypedColumnValue<Guid>("SysImageId");
			}
			set {
				SetColumnValue("SysImageId", value);
				_sysImage = null;
			}
		}

		/// <exclude/>
		public string SysImageName {
			get {
				return GetTypedColumnValue<string>("SysImageName");
			}
			set {
				SetColumnValue("SysImageName", value);
				if (_sysImage != null) {
					_sysImage.Name = value;
				}
			}
		}

		private SysImage _sysImage;
		/// <summary>
		/// Image of notifications.
		/// </summary>
		public SysImage SysImage {
			get {
				return _sysImage ??
					(_sysImage = new SysImage(LookupColumnEntities.GetEntity("SysImage")));
			}
		}

		/// <exclude/>
		public Guid NotificationTypeId {
			get {
				return GetTypedColumnValue<Guid>("NotificationTypeId");
			}
			set {
				SetColumnValue("NotificationTypeId", value);
				_notificationType = null;
			}
		}

		/// <exclude/>
		public string NotificationTypeName {
			get {
				return GetTypedColumnValue<string>("NotificationTypeName");
			}
			set {
				SetColumnValue("NotificationTypeName", value);
				if (_notificationType != null) {
					_notificationType.Name = value;
				}
			}
		}

		private NotificationType _notificationType;
		/// <summary>
		/// Notification type.
		/// </summary>
		public NotificationType NotificationType {
			get {
				return _notificationType ??
					(_notificationType = new NotificationType(LookupColumnEntities.GetEntity("NotificationType")));
			}
		}

		/// <summary>
		/// Entity of notifications.
		/// </summary>
		public Guid SysEntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaUId");
			}
			set {
				SetColumnValue("SysEntitySchemaUId", value);
			}
		}

		#endregion

	}

	#endregion

}

