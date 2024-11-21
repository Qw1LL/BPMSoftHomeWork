namespace BPMSoft.Configuration.OData
{

	using BPMSoft.Core;
	using BPMSoft.Core.Entities.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Drawing;

	#region Class: Reminding

	/// <exclude/>
	public class Reminding : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public Reminding(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Reminding";
		}

		public Reminding(BPMSoft.Core.Entities.Entity source)
			: base(source) {
			SchemaName = "Reminding";
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

		/// <exclude/>
		public Guid AuthorId {
			get {
				return GetTypedColumnValue<Guid>("AuthorId");
			}
			set {
				SetColumnValue("AuthorId", value);
				_author = null;
			}
		}

		/// <exclude/>
		public string AuthorName {
			get {
				return GetTypedColumnValue<string>("AuthorName");
			}
			set {
				SetColumnValue("AuthorName", value);
				if (_author != null) {
					_author.Name = value;
				}
			}
		}

		private Contact _author;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact Author {
			get {
				return _author ??
					(_author = new Contact(LookupColumnEntities.GetEntity("Author")));
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
		/// To.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = new Contact(LookupColumnEntities.GetEntity("Contact")));
			}
		}

		/// <exclude/>
		public Guid SourceId {
			get {
				return GetTypedColumnValue<Guid>("SourceId");
			}
			set {
				SetColumnValue("SourceId", value);
				_source = null;
			}
		}

		/// <exclude/>
		public string SourceName {
			get {
				return GetTypedColumnValue<string>("SourceName");
			}
			set {
				SetColumnValue("SourceName", value);
				if (_source != null) {
					_source.Name = value;
				}
			}
		}

		private RemindingSource _source;
		/// <summary>
		/// Source.
		/// </summary>
		public RemindingSource Source {
			get {
				return _source ??
					(_source = new RemindingSource(LookupColumnEntities.GetEntity("Source")));
			}
		}

		/// <summary>
		/// Time.
		/// </summary>
		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Unique caption Id.
		/// </summary>
		public Guid SubjectId {
			get {
				return GetTypedColumnValue<Guid>("SubjectId");
			}
			set {
				SetColumnValue("SubjectId", value);
			}
		}

		/// <exclude/>
		public Guid SysEntitySchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysEntitySchemaId");
			}
			set {
				SetColumnValue("SysEntitySchemaId", value);
				_sysEntitySchema = null;
			}
		}

		/// <exclude/>
		public string SysEntitySchemaName {
			get {
				return GetTypedColumnValue<string>("SysEntitySchemaName");
			}
			set {
				SetColumnValue("SysEntitySchemaName", value);
				if (_sysEntitySchema != null) {
					_sysEntitySchema.Name = value;
				}
			}
		}

		private VwSysModuleEntity _sysEntitySchema;
		/// <summary>
		/// Object.
		/// </summary>
		public VwSysModuleEntity SysEntitySchema {
			get {
				return _sysEntitySchema ??
					(_sysEntitySchema = new VwSysModuleEntity(LookupColumnEntities.GetEntity("SysEntitySchema")));
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

		/// <summary>
		/// Title.
		/// </summary>
		public string SubjectCaption {
			get {
				return GetTypedColumnValue<string>("SubjectCaption");
			}
			set {
				SetColumnValue("SubjectCaption", value);
			}
		}

		/// <summary>
		/// Type name.
		/// </summary>
		public string TypeCaption {
			get {
				return GetTypedColumnValue<string>("TypeCaption");
			}
			set {
				SetColumnValue("TypeCaption", value);
			}
		}

		/// <summary>
		/// Popup title.
		/// </summary>
		public string PopupTitle {
			get {
				return GetTypedColumnValue<string>("PopupTitle");
			}
			set {
				SetColumnValue("PopupTitle", value);
			}
		}

		/// <summary>
		/// Hash code.
		/// </summary>
		public string Hash {
			get {
				return GetTypedColumnValue<string>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <summary>
		/// IsRead.
		/// </summary>
		public bool IsRead {
			get {
				return GetTypedColumnValue<bool>("IsRead");
			}
			set {
				SetColumnValue("IsRead", value);
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
		/// NotificationType.
		/// </summary>
		public NotificationType NotificationType {
			get {
				return _notificationType ??
					(_notificationType = new NotificationType(LookupColumnEntities.GetEntity("NotificationType")));
			}
		}

		/// <exclude/>
		public Guid LoaderId {
			get {
				return GetTypedColumnValue<Guid>("LoaderId");
			}
			set {
				SetColumnValue("LoaderId", value);
				_loader = null;
			}
		}

		/// <exclude/>
		public string LoaderName {
			get {
				return GetTypedColumnValue<string>("LoaderName");
			}
			set {
				SetColumnValue("LoaderName", value);
				if (_loader != null) {
					_loader.Name = value;
				}
			}
		}

		private VwSysModuleEntity _loader;
		/// <summary>
		/// Notification loader.
		/// </summary>
		public VwSysModuleEntity Loader {
			get {
				return _loader ??
					(_loader = new VwSysModuleEntity(LookupColumnEntities.GetEntity("Loader")));
			}
		}

		/// <summary>
		/// Parent entity ID.
		/// </summary>
		public Guid SenderId {
			get {
				return GetTypedColumnValue<Guid>("SenderId");
			}
			set {
				SetColumnValue("SenderId", value);
			}
		}

		/// <summary>
		/// Message is need to send.
		/// </summary>
		public bool IsNeedToSend {
			get {
				return GetTypedColumnValue<bool>("IsNeedToSend");
			}
			set {
				SetColumnValue("IsNeedToSend", value);
			}
		}

		/// <summary>
		/// Date of anninersary.
		/// </summary>
		public DateTime AnniversaryDate {
			get {
				return GetTypedColumnValue<DateTime>("AnniversaryDate");
			}
			set {
				SetColumnValue("AnniversaryDate", value);
			}
		}

		/// <summary>
		/// Config.
		/// </summary>
		public string Config {
			get {
				return GetTypedColumnValue<string>("Config");
			}
			set {
				SetColumnValue("Config", value);
			}
		}

		#endregion

	}

	#endregion

}

