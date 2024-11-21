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

	#region Class: ActivityFileSchema

	/// <exclude/>
	public class ActivityFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ActivityFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityFileSchema(ActivityFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityFileSchema(ActivityFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124");
			RealUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124");
			Name = "ActivityFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateActivityColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("abd11aa6-3deb-4fcb-ab6e-c4a6d024c9f7")) == null) {
				Columns.Add(CreateCreatedByInvCRMColumn());
			}
			if (Columns.FindByUId(new Guid("6118d0d6-aaf7-42d8-b8d1-e7cd83431798")) == null) {
				Columns.Add(CreateUploadedColumn());
			}
			if (Columns.FindByUId(new Guid("d9222c5f-fde3-4339-9b92-dd09a65a5dc3")) == null) {
				Columns.Add(CreateErrorOnUploadColumn());
			}
			if (Columns.FindByUId(new Guid("4e02d938-dfb6-40ca-afe9-acb7b135983c")) == null) {
				Columns.Add(CreateExternalStoragePropertiesColumn());
			}
			if (Columns.FindByUId(new Guid("f900065f-2607-472c-8010-2c2fa81d29e8")) == null) {
				Columns.Add(CreateInlineColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e579e0c7-e688-4dd2-8246-fdbebd280e60"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedByInvCRMColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("abd11aa6-3deb-4fcb-ab6e-c4a6d024c9f7"),
				Name = @"CreatedByInvCRM",
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUploadedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("6118d0d6-aaf7-42d8-b8d1-e7cd83431798"),
				Name = @"Uploaded",
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateErrorOnUploadColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("d9222c5f-fde3-4339-9b92-dd09a65a5dc3"),
				Name = @"ErrorOnUpload",
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("a99d7388-fb0e-4870-87fc-76975bec5847")
			};
		}

		protected virtual EntitySchemaColumn CreateExternalStoragePropertiesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4e02d938-dfb6-40ca-afe9-acb7b135983c"),
				Name = @"ExternalStorageProperties",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("79d5e1e4-18af-4001-8dc1-26f09fca92c2")
			};
		}

		protected virtual EntitySchemaColumn CreateInlineColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("f900065f-2607-472c-8010-2c2fa81d29e8"),
				Name = @"Inline",
				CreatedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				ModifiedInSchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
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
			return new ActivityFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityFile_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityFile

	/// <summary>
	/// Файл и ссылка активности.
	/// </summary>
	public class ActivityFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ActivityFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityFile";
		}

		public ActivityFile(ActivityFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Активность.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		/// <summary>
		/// Создан в InvisibleCRM.
		/// </summary>
		public bool CreatedByInvCRM {
			get {
				return GetTypedColumnValue<bool>("CreatedByInvCRM");
			}
			set {
				SetColumnValue("CreatedByInvCRM", value);
			}
		}

		/// <summary>
		/// Загружен.
		/// </summary>
		public bool Uploaded {
			get {
				return GetTypedColumnValue<bool>("Uploaded");
			}
			set {
				SetColumnValue("Uploaded", value);
			}
		}

		/// <summary>
		/// Ошибка при загрузке.
		/// </summary>
		public string ErrorOnUpload {
			get {
				return GetTypedColumnValue<string>("ErrorOnUpload");
			}
			set {
				SetColumnValue("ErrorOnUpload", value);
			}
		}

		/// <summary>
		/// ExternalStorageProperties.
		/// </summary>
		public string ExternalStorageProperties {
			get {
				return GetTypedColumnValue<string>("ExternalStorageProperties");
			}
			set {
				SetColumnValue("ExternalStorageProperties", value);
			}
		}

		/// <summary>
		/// Встроенное вложение.
		/// </summary>
		public bool Inline {
			get {
				return GetTypedColumnValue<bool>("Inline");
			}
			set {
				SetColumnValue("Inline", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityFile_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityFileDeleted", e);
			Inserting += (s, e) => ThrowEvent("ActivityFileInserting", e);
			Updated += (s, e) => ThrowEvent("ActivityFileUpdated", e);
			Validating += (s, e) => ThrowEvent("ActivityFileValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityFile_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityFile_BaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ActivityFile
	{

		public ActivityFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityFile_BaseEventsProcess";
			SchemaUId = new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("080c9917-7ec9-42e5-86ff-75a683d4f124");
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

	#region Class: ActivityFile_BaseEventsProcess

	/// <exclude/>
	public class ActivityFile_BaseEventsProcess : ActivityFile_BaseEventsProcess<ActivityFile>
	{

		public ActivityFile_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityFile_BaseEventsProcess

	public partial class ActivityFile_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ActivityFileEventsProcess

	/// <exclude/>
	public class ActivityFileEventsProcess : ActivityFile_BaseEventsProcess
	{

		public ActivityFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

