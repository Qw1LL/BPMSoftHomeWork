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

	#region Class: SysInstalledAppSchema

	/// <exclude/>
	public class SysInstalledAppSchema : BPMSoft.Configuration.SysInstalledApp_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysInstalledAppSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledAppSchema(SysInstalledAppSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledAppSchema(SysInstalledAppSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateSysInstalledApp_CodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("adbee7d0-8b5a-421c-9b2e-2cbc3a14f50e");
			index.Name = "SysInstalledApp_Code";
			index.CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("24b02828-3f5f-41e4-b49b-ac9d9454e18b"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				ModifiedInSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1");
			Name = "SysInstalledApp";
			ParentSchemaUId = new Guid("91d3eeb0-086c-4143-b671-dd2b77634d39");
			ExtendParent = true;
			CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ee796918-48d2-4b4d-a8b9-6e1466651b0a")) == null) {
				Columns.Add(CreateMkpPublishedVersionColumn());
			}
			if (Columns.FindByUId(new Guid("71f18332-3ea7-4e49-932c-d2748eb92f2a")) == null) {
				Columns.Add(CreateMkpReleaseNotesColumn());
			}
			if (Columns.FindByUId(new Guid("80bd0eb9-c8a7-4d47-bbe3-37f73a5bfac3")) == null) {
				Columns.Add(CreateMkpNotificationStatusColumn());
			}
			if (Columns.FindByUId(new Guid("d8554f08-6ff6-4cc1-8626-e326a5635f5f")) == null) {
				Columns.Add(CreateMkpChangedOnColumn());
			}
			if (Columns.FindByUId(new Guid("3c1fb77e-2c31-4e8f-b85c-d5eab83783af")) == null) {
				Columns.Add(CreateMkpIsUpdatedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateMkpPublishedVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ee796918-48d2-4b4d-a8b9-6e1466651b0a"),
				Name = @"MkpPublishedVersion",
				CreatedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				ModifiedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMkpReleaseNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("71f18332-3ea7-4e49-932c-d2748eb92f2a"),
				Name = @"MkpReleaseNotes",
				CreatedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				ModifiedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470")
			};
		}

		protected virtual EntitySchemaColumn CreateMkpNotificationStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("80bd0eb9-c8a7-4d47-bbe3-37f73a5bfac3"),
				Name = @"MkpNotificationStatus",
				CreatedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				ModifiedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateMkpChangedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d8554f08-6ff6-4cc1-8626-e326a5635f5f"),
				Name = @"MkpChangedOn",
				CreatedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				ModifiedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470")
			};
		}

		protected virtual EntitySchemaColumn CreateMkpIsUpdatedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3c1fb77e-2c31-4e8f-b85c-d5eab83783af"),
				Name = @"MkpIsUpdated",
				CreatedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				ModifiedInSchemaUId = new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"),
				CreatedInPackageId = new Guid("bb256bc6-568a-4852-935d-941e7ff05470"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateSysInstalledApp_CodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysInstalledApp(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledApp_MkpNotificationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledAppSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledAppSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp

	/// <summary>
	/// Installed application.
	/// </summary>
	public class SysInstalledApp : BPMSoft.Configuration.SysInstalledApp_Base_BPMSoft
	{

		#region Constructors: Public

		public SysInstalledApp(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledApp";
		}

		public SysInstalledApp(SysInstalledApp source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Published version.
		/// </summary>
		public string MkpPublishedVersion {
			get {
				return GetTypedColumnValue<string>("MkpPublishedVersion");
			}
			set {
				SetColumnValue("MkpPublishedVersion", value);
			}
		}

		/// <summary>
		/// Release notes.
		/// </summary>
		public string MkpReleaseNotes {
			get {
				return GetTypedColumnValue<string>("MkpReleaseNotes");
			}
			set {
				SetColumnValue("MkpReleaseNotes", value);
			}
		}

		/// <summary>
		/// Notification status.
		/// </summary>
		public bool MkpNotificationStatus {
			get {
				return GetTypedColumnValue<bool>("MkpNotificationStatus");
			}
			set {
				SetColumnValue("MkpNotificationStatus", value);
			}
		}

		/// <summary>
		/// Changed on.
		/// </summary>
		public DateTime MkpChangedOn {
			get {
				return GetTypedColumnValue<DateTime>("MkpChangedOn");
			}
			set {
				SetColumnValue("MkpChangedOn", value);
			}
		}

		/// <summary>
		/// IsUpdated.
		/// </summary>
		public bool MkpIsUpdated {
			get {
				return GetTypedColumnValue<bool>("MkpIsUpdated");
			}
			set {
				SetColumnValue("MkpIsUpdated", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledApp_MkpNotificationsEventsProcess(UserConnection);
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
			return new SysInstalledApp(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledApp_MkpNotificationsEventsProcess

	/// <exclude/>
	public partial class SysInstalledApp_MkpNotificationsEventsProcess<TEntity> : BPMSoft.Configuration.SysInstalledApp_BaseEventsProcess<TEntity> where TEntity : SysInstalledApp
	{

		public SysInstalledApp_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledApp_MkpNotificationsEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f8bb1c79-afcd-4760-94c6-dbcc493bcbf1");
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

	#region Class: SysInstalledApp_MkpNotificationsEventsProcess

	/// <exclude/>
	public class SysInstalledApp_MkpNotificationsEventsProcess : SysInstalledApp_MkpNotificationsEventsProcess<SysInstalledApp>
	{

		public SysInstalledApp_MkpNotificationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledApp_MkpNotificationsEventsProcess

	public partial class SysInstalledApp_MkpNotificationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInstalledAppEventsProcess

	/// <exclude/>
	public class SysInstalledAppEventsProcess : SysInstalledApp_MkpNotificationsEventsProcess
	{

		public SysInstalledAppEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

