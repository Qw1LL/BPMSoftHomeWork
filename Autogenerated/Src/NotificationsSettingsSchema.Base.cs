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

	#region Class: NotificationsSettingsSchema

	/// <exclude/>
	public class NotificationsSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public NotificationsSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public NotificationsSettingsSchema(NotificationsSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public NotificationsSettingsSchema(NotificationsSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323");
			RealUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323");
			Name = "NotificationsSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3baa7dcf-3db9-4542-acfe-9a50a538032a")) == null) {
				Columns.Add(CreateSysImageColumn());
			}
			if (Columns.FindByUId(new Guid("5ea1329f-117e-4f0c-87c0-5125f293f117")) == null) {
				Columns.Add(CreateNotificationTypeColumn());
			}
			if (Columns.FindByUId(new Guid("d44b61a5-0338-45f8-a890-0f1ea2190d90")) == null) {
				Columns.Add(CreateSysEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3baa7dcf-3db9-4542-acfe-9a50a538032a"),
				Name = @"SysImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				ModifiedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7")
			};
		}

		protected virtual EntitySchemaColumn CreateNotificationTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5ea1329f-117e-4f0c-87c0-5125f293f117"),
				Name = @"NotificationType",
				ReferenceSchemaUId = new Guid("ef45b183-3adb-4b37-a099-8d28e9ee9b3a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				ModifiedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateSysEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d44b61a5-0338-45f8-a890-0f1ea2190d90"),
				Name = @"SysEntitySchemaUId",
				CreatedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				ModifiedInSchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"),
				CreatedInPackageId = new Guid("271744d8-d0f2-48d8-a4d0-e376f30523b7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new NotificationsSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new NotificationsSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new NotificationsSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new NotificationsSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323"));
		}

		#endregion

	}

	#endregion

	#region Class: NotificationsSettings

	/// <summary>
	/// Settings of notifications.
	/// </summary>
	public class NotificationsSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public NotificationsSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "NotificationsSettings";
		}

		public NotificationsSettings(NotificationsSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
					(_sysImage = LookupColumnEntities.GetEntity("SysImage") as SysImage);
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
					(_notificationType = LookupColumnEntities.GetEntity("NotificationType") as NotificationType);
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

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new NotificationsSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("NotificationsSettingsDeleted", e);
			Validating += (s, e) => ThrowEvent("NotificationsSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new NotificationsSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: NotificationsSettings_BaseEventsProcess

	/// <exclude/>
	public partial class NotificationsSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : NotificationsSettings
	{

		public NotificationsSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "NotificationsSettings_BaseEventsProcess";
			SchemaUId = new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0c7a653b-33bc-471e-abca-aa4e330cc323");
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

	#region Class: NotificationsSettings_BaseEventsProcess

	/// <exclude/>
	public class NotificationsSettings_BaseEventsProcess : NotificationsSettings_BaseEventsProcess<NotificationsSettings>
	{

		public NotificationsSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: NotificationsSettings_BaseEventsProcess

	public partial class NotificationsSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: NotificationsSettingsEventsProcess

	/// <exclude/>
	public class NotificationsSettingsEventsProcess : NotificationsSettings_BaseEventsProcess
	{

		public NotificationsSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

