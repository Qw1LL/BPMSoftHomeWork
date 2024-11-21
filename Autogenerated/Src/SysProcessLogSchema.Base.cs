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

	#region Class: SysProcessLog_Base_BPMSoftSchema

	/// <exclude/>
	public class SysProcessLog_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessLog_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessLog_Base_BPMSoftSchema(SysProcessLog_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessLog_Base_BPMSoftSchema(SysProcessLog_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			RealUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			Name = "SysProcessLog_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeHierarchyColumn() {
			base.InitializeHierarchyColumn();
			HierarchyColumn = CreateParentColumn();
			if (Columns.FindByUId(HierarchyColumn.UId) == null) {
				Columns.Add(HierarchyColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("03e35775-3e19-4a17-b038-5b927c2f14f3")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("453bcbc6-eae2-481f-b808-b7cfea46304b")) == null) {
				Columns.Add(CreateCompleteDateColumn());
			}
			if (Columns.FindByUId(new Guid("7be578a4-bc9a-4e7e-9d00-087de2a606bd")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("be00ec0f-14af-4063-ab36-ac4953e639a9")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("b35c48a0-6ab5-4e12-b151-e108bb20f1ea")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("05b79db3-54fc-4e67-8fd6-41f59a38e33c")) == null) {
				Columns.Add(CreateDurationInMinutesColumn());
			}
			if (Columns.FindByUId(new Guid("44717a77-27dc-44c2-8a25-e70a0d21cf66")) == null) {
				Columns.Add(CreateDurationInDaysColumn());
			}
			if (Columns.FindByUId(new Guid("e1f5dc62-8b1c-49c8-91e8-a05e448bc23e")) == null) {
				Columns.Add(CreateDurationInHoursColumn());
			}
			if (Columns.FindByUId(new Guid("b7eece49-2efb-4f58-8beb-b1608f7756c8")) == null) {
				Columns.Add(CreatePackageNameColumn());
			}
			if (Columns.FindByUId(new Guid("18ff1712-3b16-487a-83c4-2195e7ba6c69")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("50ab25cc-d7e6-41f6-ab49-b3d46ceb53e2")) == null) {
				Columns.Add(CreateDurationInMillisecondsColumn());
			}
			if (Columns.FindByUId(new Guid("ed6a1546-fda3-48ca-bb6b-3a01d3529c0d")) == null) {
				Columns.Add(CreateErrorDescriptionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
			};
			column.ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c9f2d733-fb0a-4f8e-ad91-1eb06891d2e6"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("03e35775-3e19-4a17-b038-5b927c2f14f3"),
				Name = @"StartDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCompleteDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("453bcbc6-eae2-481f-b808-b7cfea46304b"),
				Name = @"CompleteDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7be578a4-bc9a-4e7e-9d00-087de2a606bd"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1f85a957-c2b6-4aa1-afff-575ad9bd443e"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be00ec0f-14af-4063-ab36-ac4953e639a9"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f4364fd0-8a42-425f-9771-9be6c83d8394"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b35c48a0-6ab5-4e12-b151-e108bb20f1ea"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMinutesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("05b79db3-54fc-4e67-8fd6-41f59a38e33c"),
				Name = @"DurationInMinutes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInDaysColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("44717a77-27dc-44c2-8a25-e70a0d21cf66"),
				Name = @"DurationInDays",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInHoursColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("e1f5dc62-8b1c-49c8-91e8-a05e448bc23e"),
				Name = @"DurationInHours",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b7eece49-2efb-4f58-8beb-b1608f7756c8"),
				Name = @"PackageName",
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("3e5bd282-4d8c-413e-b456-f52e075a6aaa")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("18ff1712-3b16-487a-83c4-2195e7ba6c69"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("3e5bd282-4d8c-413e-b456-f52e075a6aaa")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMillisecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("50ab25cc-d7e6-41f6-ab49-b3d46ceb53e2"),
				Name = @"DurationInMilliseconds",
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ed6a1546-fda3-48ca-bb6b-3a01d3529c0d"),
				Name = @"ErrorDescription",
				CreatedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				ModifiedInSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsMultiLineText = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessLog_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessLog_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessLog_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLog_Base_BPMSoft

	/// <summary>
	/// Process log (actual).
	/// </summary>
	public class SysProcessLog_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessLog_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessLog_Base_BPMSoft";
		}

		public SysProcessLog_Base_BPMSoft(SysProcessLog_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Title.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime CompleteDate {
			get {
				return GetTypedColumnValue<DateTime>("CompleteDate");
			}
			set {
				SetColumnValue("CompleteDate", value);
			}
		}

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Process.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private SysProcessLog _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public SysProcessLog Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysProcessLog);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private SysProcessStatus _status;
		/// <summary>
		/// Process status.
		/// </summary>
		public SysProcessStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as SysProcessStatus);
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
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// Workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		/// <summary>
		/// Duration, minutes.
		/// </summary>
		public Decimal DurationInMinutes {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Duration, days.
		/// </summary>
		public Decimal DurationInDays {
			get {
				return GetTypedColumnValue<Decimal>("DurationInDays");
			}
			set {
				SetColumnValue("DurationInDays", value);
			}
		}

		/// <summary>
		/// Duration, hours.
		/// </summary>
		public Decimal DurationInHours {
			get {
				return GetTypedColumnValue<Decimal>("DurationInHours");
			}
			set {
				SetColumnValue("DurationInHours", value);
			}
		}

		/// <summary>
		/// Package.
		/// </summary>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// Duration, milliseconds.
		/// </summary>
		public Decimal DurationInMilliseconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMilliseconds");
			}
			set {
				SetColumnValue("DurationInMilliseconds", value);
			}
		}

		/// <summary>
		/// Error description.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessLog_Base_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessLog_Base_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("SysProcessLog_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessLog_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLog_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessLog_Base_BPMSoft
	{

		public SysProcessLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessLog_BaseEventsProcess";
			SchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
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

	#region Class: SysProcessLog_BaseEventsProcess

	/// <exclude/>
	public class SysProcessLog_BaseEventsProcess : SysProcessLog_BaseEventsProcess<SysProcessLog_Base_BPMSoft>
	{

		public SysProcessLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessLog_BaseEventsProcess

	public partial class SysProcessLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

