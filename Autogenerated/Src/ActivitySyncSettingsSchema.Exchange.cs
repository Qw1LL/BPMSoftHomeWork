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

	#region Class: ActivitySyncSettingsSchema

	/// <exclude/>
	public class ActivitySyncSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActivitySyncSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivitySyncSettingsSchema(ActivitySyncSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivitySyncSettingsSchema(ActivitySyncSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			RealUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			Name = "ActivitySyncSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7a995281-a224-4a68-b3cd-ec98b2e53471")) == null) {
				Columns.Add(CreateMailboxSyncSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("aa62b4a9-7302-44a2-ad1d-e51bd30ae100")) == null) {
				Columns.Add(CreateAppointmentLastSyncDateColumn());
			}
			if (Columns.FindByUId(new Guid("f5701335-549a-4f29-9669-a4546636a0a2")) == null) {
				Columns.Add(CreateTaskLastSyncDateColumn());
			}
			if (Columns.FindByUId(new Guid("1685ee06-d8b8-45e1-ac5a-728bf9757096")) == null) {
				Columns.Add(CreateImportTasksColumn());
			}
			if (Columns.FindByUId(new Guid("8048efc0-43e0-419d-b81a-e19f7124ba1b")) == null) {
				Columns.Add(CreateImportTasksAllColumn());
			}
			if (Columns.FindByUId(new Guid("61c7bbc1-dbd5-491b-a95c-e8314c0b6902")) == null) {
				Columns.Add(CreateImportTasksFoldersColumn());
			}
			if (Columns.FindByUId(new Guid("29fbab6f-a1e7-4359-bac8-a2d05351afec")) == null) {
				Columns.Add(CreateImportTasksFromFoldersColumn());
			}
			if (Columns.FindByUId(new Guid("d243da1c-c3ab-4a4e-a04e-55fb436cf955")) == null) {
				Columns.Add(CreateImportActivitiesFromColumn());
			}
			if (Columns.FindByUId(new Guid("d78cd932-b262-4db5-9e73-010c3894b458")) == null) {
				Columns.Add(CreateImportAppointmentsColumn());
			}
			if (Columns.FindByUId(new Guid("d5025910-712e-4275-bb72-1300117571ec")) == null) {
				Columns.Add(CreateImportAppointmentsAllColumn());
			}
			if (Columns.FindByUId(new Guid("b6bfc8a2-4a10-4cd4-bcfd-a5a0d7dcc5d5")) == null) {
				Columns.Add(CreateImpAppointmentsFromCalendarsColumn());
			}
			if (Columns.FindByUId(new Guid("20806819-3f4e-4db3-9de6-6a8c64d0ddd0")) == null) {
				Columns.Add(CreateImportAppointmentsCalendarsColumn());
			}
			if (Columns.FindByUId(new Guid("d3299773-9e38-4034-ac93-457fe2da6b78")) == null) {
				Columns.Add(CreateExportActivitiesColumn());
			}
			if (Columns.FindByUId(new Guid("9f1d8963-4a4a-480e-a7bf-e7723c9526a5")) == null) {
				Columns.Add(CreateExportActivitiesAllColumn());
			}
			if (Columns.FindByUId(new Guid("3fc55106-7296-44ae-984f-c1ddef99f5b3")) == null) {
				Columns.Add(CreateExportActivitiesSelectedColumn());
			}
			if (Columns.FindByUId(new Guid("18016e10-8202-4189-bbbf-fe5286a5568e")) == null) {
				Columns.Add(CreateExportAppointmentsColumn());
			}
			if (Columns.FindByUId(new Guid("cd0071f2-a5ee-4d8a-bec4-d4e918a1fcf1")) == null) {
				Columns.Add(CreateExportTasksColumn());
			}
			if (Columns.FindByUId(new Guid("c6db6e3c-3388-4192-bfba-d6ac57b622b4")) == null) {
				Columns.Add(CreateExportActivitiesFromSchedulerColumn());
			}
			if (Columns.FindByUId(new Guid("4ceee3a7-2de8-4270-a608-cf2912395bc6")) == null) {
				Columns.Add(CreateExportActivitiesFromGroupsColumn());
			}
			if (Columns.FindByUId(new Guid("f060e414-53d7-4d1a-9185-8a46ac2b8a15")) == null) {
				Columns.Add(CreateExportActivitiesGroupsColumn());
			}
			if (Columns.FindByUId(new Guid("ccdcca74-5560-493f-82ce-7c9892bfe7d5")) == null) {
				Columns.Add(CreateActivitySyncPeriodColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			column.CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMailboxSyncSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7a995281-a224-4a68-b3cd-ec98b2e53471"),
				Name = @"MailboxSyncSettings",
				ReferenceSchemaUId = new Guid("5e487721-02e2-48ee-b755-dfa5160f5315"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateAppointmentLastSyncDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("aa62b4a9-7302-44a2-ad1d-e51bd30ae100"),
				Name = @"AppointmentLastSyncDate",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateTaskLastSyncDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("f5701335-549a-4f29-9669-a4546636a0a2"),
				Name = @"TaskLastSyncDate",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportTasksColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1685ee06-d8b8-45e1-ac5a-728bf9757096"),
				Name = @"ImportTasks",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportTasksAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8048efc0-43e0-419d-b81a-e19f7124ba1b"),
				Name = @"ImportTasksAll",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportTasksFoldersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("61c7bbc1-dbd5-491b-a95c-e8314c0b6902"),
				Name = @"ImportTasksFolders",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportTasksFromFoldersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("29fbab6f-a1e7-4359-bac8-a2d05351afec"),
				Name = @"ImportTasksFromFolders",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportActivitiesFromColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("d243da1c-c3ab-4a4e-a04e-55fb436cf955"),
				Name = @"ImportActivitiesFrom",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportAppointmentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d78cd932-b262-4db5-9e73-010c3894b458"),
				Name = @"ImportAppointments",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportAppointmentsAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d5025910-712e-4275-bb72-1300117571ec"),
				Name = @"ImportAppointmentsAll",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImpAppointmentsFromCalendarsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b6bfc8a2-4a10-4cd4-bcfd-a5a0d7dcc5d5"),
				Name = @"ImpAppointmentsFromCalendars",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateImportAppointmentsCalendarsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("20806819-3f4e-4db3-9de6-6a8c64d0ddd0"),
				Name = @"ImportAppointmentsCalendars",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d3299773-9e38-4034-ac93-457fe2da6b78"),
				Name = @"ExportActivities",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesAllColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9f1d8963-4a4a-480e-a7bf-e7723c9526a5"),
				Name = @"ExportActivitiesAll",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesSelectedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3fc55106-7296-44ae-984f-c1ddef99f5b3"),
				Name = @"ExportActivitiesSelected",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportAppointmentsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("18016e10-8202-4189-bbbf-fe5286a5568e"),
				Name = @"ExportAppointments",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportTasksColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cd0071f2-a5ee-4d8a-bec4-d4e918a1fcf1"),
				Name = @"ExportTasks",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesFromSchedulerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c6db6e3c-3388-4192-bfba-d6ac57b622b4"),
				Name = @"ExportActivitiesFromScheduler",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesFromGroupsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("4ceee3a7-2de8-4270-a608-cf2912395bc6"),
				Name = @"ExportActivitiesFromGroups",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateExportActivitiesGroupsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f060e414-53d7-4d1a-9185-8a46ac2b8a15"),
				Name = @"ExportActivitiesGroups",
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("3033db6d-23fb-435c-94e5-8f4806c46ba3")
			};
		}

		protected virtual EntitySchemaColumn CreateActivitySyncPeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ccdcca74-5560-493f-82ce-7c9892bfe7d5"),
				Name = @"ActivitySyncPeriod",
				ReferenceSchemaUId = new Guid("53c6a358-61c6-4679-a4c3-04d002f423e5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				ModifiedInSchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"),
				CreatedInPackageId = new Guid("2137d3bc-8953-4060-9df8-39c52dc22e74"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2d480351-94b7-4cad-b02f-885730c7eb3e"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ActivitySyncSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivitySyncSettings_ExchangeEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivitySyncSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivitySyncSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d21cff28-c251-48db-879f-ddc28b6f971d"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivitySyncSettings

	/// <summary>
	/// Activities synchronization settings.
	/// </summary>
	public class ActivitySyncSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActivitySyncSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivitySyncSettings";
		}

		public ActivitySyncSettings(ActivitySyncSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid MailboxSyncSettingsId {
			get {
				return GetTypedColumnValue<Guid>("MailboxSyncSettingsId");
			}
			set {
				SetColumnValue("MailboxSyncSettingsId", value);
				_mailboxSyncSettings = null;
			}
		}

		/// <exclude/>
		public string MailboxSyncSettingsUserName {
			get {
				return GetTypedColumnValue<string>("MailboxSyncSettingsUserName");
			}
			set {
				SetColumnValue("MailboxSyncSettingsUserName", value);
				if (_mailboxSyncSettings != null) {
					_mailboxSyncSettings.UserName = value;
				}
			}
		}

		private MailboxSyncSettings _mailboxSyncSettings;
		/// <summary>
		/// Mailbox synchronization settings.
		/// </summary>
		public MailboxSyncSettings MailboxSyncSettings {
			get {
				return _mailboxSyncSettings ??
					(_mailboxSyncSettings = LookupColumnEntities.GetEntity("MailboxSyncSettings") as MailboxSyncSettings);
			}
		}

		/// <summary>
		/// AppointmentLastSyncDate.
		/// </summary>
		public DateTime AppointmentLastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("AppointmentLastSyncDate");
			}
			set {
				SetColumnValue("AppointmentLastSyncDate", value);
			}
		}

		/// <summary>
		/// TaskLastSyncDate.
		/// </summary>
		public DateTime TaskLastSyncDate {
			get {
				return GetTypedColumnValue<DateTime>("TaskLastSyncDate");
			}
			set {
				SetColumnValue("TaskLastSyncDate", value);
			}
		}

		/// <summary>
		/// Import tasks.
		/// </summary>
		public bool ImportTasks {
			get {
				return GetTypedColumnValue<bool>("ImportTasks");
			}
			set {
				SetColumnValue("ImportTasks", value);
			}
		}

		/// <summary>
		/// All tasks.
		/// </summary>
		public bool ImportTasksAll {
			get {
				return GetTypedColumnValue<bool>("ImportTasksAll");
			}
			set {
				SetColumnValue("ImportTasksAll", value);
			}
		}

		/// <summary>
		/// ImportTasksFolders.
		/// </summary>
		public string ImportTasksFolders {
			get {
				return GetTypedColumnValue<string>("ImportTasksFolders");
			}
			set {
				SetColumnValue("ImportTasksFolders", value);
			}
		}

		/// <summary>
		/// Import tasks from folders.
		/// </summary>
		public bool ImportTasksFromFolders {
			get {
				return GetTypedColumnValue<bool>("ImportTasksFromFolders");
			}
			set {
				SetColumnValue("ImportTasksFromFolders", value);
			}
		}

		/// <summary>
		/// Import activities starting from.
		/// </summary>
		public DateTime ImportActivitiesFrom {
			get {
				return GetTypedColumnValue<DateTime>("ImportActivitiesFrom");
			}
			set {
				SetColumnValue("ImportActivitiesFrom", value);
			}
		}

		/// <summary>
		/// Import meetings.
		/// </summary>
		public bool ImportAppointments {
			get {
				return GetTypedColumnValue<bool>("ImportAppointments");
			}
			set {
				SetColumnValue("ImportAppointments", value);
			}
		}

		/// <summary>
		/// All meetings.
		/// </summary>
		public bool ImportAppointmentsAll {
			get {
				return GetTypedColumnValue<bool>("ImportAppointmentsAll");
			}
			set {
				SetColumnValue("ImportAppointmentsAll", value);
			}
		}

		/// <summary>
		/// Import meetings from calendars.
		/// </summary>
		public bool ImpAppointmentsFromCalendars {
			get {
				return GetTypedColumnValue<bool>("ImpAppointmentsFromCalendars");
			}
			set {
				SetColumnValue("ImpAppointmentsFromCalendars", value);
			}
		}

		/// <summary>
		/// ImportAppointmentsCalendars.
		/// </summary>
		public string ImportAppointmentsCalendars {
			get {
				return GetTypedColumnValue<string>("ImportAppointmentsCalendars");
			}
			set {
				SetColumnValue("ImportAppointmentsCalendars", value);
			}
		}

		/// <summary>
		/// Export activities.
		/// </summary>
		public bool ExportActivities {
			get {
				return GetTypedColumnValue<bool>("ExportActivities");
			}
			set {
				SetColumnValue("ExportActivities", value);
			}
		}

		/// <summary>
		/// All activities.
		/// </summary>
		public bool ExportActivitiesAll {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesAll");
			}
			set {
				SetColumnValue("ExportActivitiesAll", value);
			}
		}

		/// <summary>
		/// Export selected activities.
		/// </summary>
		public bool ExportActivitiesSelected {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesSelected");
			}
			set {
				SetColumnValue("ExportActivitiesSelected", value);
			}
		}

		/// <summary>
		/// Meetings.
		/// </summary>
		public bool ExportAppointments {
			get {
				return GetTypedColumnValue<bool>("ExportAppointments");
			}
			set {
				SetColumnValue("ExportAppointments", value);
			}
		}

		/// <summary>
		/// Tasks.
		/// </summary>
		public bool ExportTasks {
			get {
				return GetTypedColumnValue<bool>("ExportTasks");
			}
			set {
				SetColumnValue("ExportTasks", value);
			}
		}

		/// <summary>
		/// From calendar.
		/// </summary>
		public bool ExportActivitiesFromScheduler {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesFromScheduler");
			}
			set {
				SetColumnValue("ExportActivitiesFromScheduler", value);
			}
		}

		/// <summary>
		/// From folders.
		/// </summary>
		public bool ExportActivitiesFromGroups {
			get {
				return GetTypedColumnValue<bool>("ExportActivitiesFromGroups");
			}
			set {
				SetColumnValue("ExportActivitiesFromGroups", value);
			}
		}

		/// <summary>
		/// ExportActivitiesGroups.
		/// </summary>
		public string ExportActivitiesGroups {
			get {
				return GetTypedColumnValue<string>("ExportActivitiesGroups");
			}
			set {
				SetColumnValue("ExportActivitiesGroups", value);
			}
		}

		/// <exclude/>
		public Guid ActivitySyncPeriodId {
			get {
				return GetTypedColumnValue<Guid>("ActivitySyncPeriodId");
			}
			set {
				SetColumnValue("ActivitySyncPeriodId", value);
				_activitySyncPeriod = null;
			}
		}

		/// <exclude/>
		public string ActivitySyncPeriodName {
			get {
				return GetTypedColumnValue<string>("ActivitySyncPeriodName");
			}
			set {
				SetColumnValue("ActivitySyncPeriodName", value);
				if (_activitySyncPeriod != null) {
					_activitySyncPeriod.Name = value;
				}
			}
		}

		private MailSyncPeriod _activitySyncPeriod;
		/// <summary>
		/// Synchronization period.
		/// </summary>
		public MailSyncPeriod ActivitySyncPeriod {
			get {
				return _activitySyncPeriod ??
					(_activitySyncPeriod = LookupColumnEntities.GetEntity("ActivitySyncPeriod") as MailSyncPeriod);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivitySyncSettings_ExchangeEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivitySyncSettingsDeleted", e);
			Inserting += (s, e) => ThrowEvent("ActivitySyncSettingsInserting", e);
			Validating += (s, e) => ThrowEvent("ActivitySyncSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivitySyncSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivitySyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public partial class ActivitySyncSettings_ExchangeEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ActivitySyncSettings
	{

		public ActivitySyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivitySyncSettings_ExchangeEventsProcess";
			SchemaUId = new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d21cff28-c251-48db-879f-ddc28b6f971d");
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

	#region Class: ActivitySyncSettings_ExchangeEventsProcess

	/// <exclude/>
	public class ActivitySyncSettings_ExchangeEventsProcess : ActivitySyncSettings_ExchangeEventsProcess<ActivitySyncSettings>
	{

		public ActivitySyncSettings_ExchangeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivitySyncSettings_ExchangeEventsProcess

	public partial class ActivitySyncSettings_ExchangeEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivitySyncSettingsEventsProcess

	/// <exclude/>
	public class ActivitySyncSettingsEventsProcess : ActivitySyncSettings_ExchangeEventsProcess
	{

		public ActivitySyncSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

