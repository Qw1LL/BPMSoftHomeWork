namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwModuleEditInfoSchema

	/// <exclude/>
	public class VwModuleEditInfoSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwModuleEditInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwModuleEditInfoSchema(VwModuleEditInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwModuleEditInfoSchema(VwModuleEditInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4f23352c-e046-4fb8-b637-885559863856");
			RealUId = new Guid("4f23352c-e046-4fb8-b637-885559863856");
			Name = "VwModuleEditInfo";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8659b4a3-5d9e-4ada-b0e0-dccfc1651cc3")) == null) {
				Columns.Add(CreateModuleCodeColumn());
			}
			if (Columns.FindByUId(new Guid("6fa45ba1-8ee1-4ef4-ada3-1543e25bfaa4")) == null) {
				Columns.Add(CreateTypeColumnValueColumn());
			}
			if (Columns.FindByUId(new Guid("fb70c81c-8174-4b2e-96f3-8df1e8d77b15")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("b275afd8-5088-4ed6-9662-d1446c623918")) == null) {
				Columns.Add(CreateWorkspaceIdColumn());
			}
			if (Columns.FindByUId(new Guid("5895f30b-5a47-4f05-8f79-115c3ec02289")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("e1e9611c-2577-42c1-ada9-c0774b0870b0")) == null) {
				Columns.Add(CreateActionKindCaptionLczIdColumn());
			}
			if (Columns.FindByUId(new Guid("af4eea3a-6b29-4660-b210-5741aa0b432c")) == null) {
				Columns.Add(CreatePageCaptionLczIdColumn());
			}
			if (Columns.FindByUId(new Guid("0200b64c-bd50-430d-91c6-7d8b5d68812c")) == null) {
				Columns.Add(CreateCultureIdColumn());
			}
			if (Columns.FindByUId(new Guid("71f4df89-250e-4d61-a538-edf9301ef880")) == null) {
				Columns.Add(CreatePageCaptionLczColumn());
			}
			if (Columns.FindByUId(new Guid("98bc6c48-5298-493b-b45e-bcb328910139")) == null) {
				Columns.Add(CreatePageCaptionLczOldColumn());
			}
			if (Columns.FindByUId(new Guid("9b876e95-b332-45ff-8153-b3e41d8932e9")) == null) {
				Columns.Add(CreateDefaultPageCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("61e2b1cd-456e-4725-82d5-f074ef3912b4")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0882e7f4-1085-44ae-9965-de23bbdcfd2b"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateModuleCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8659b4a3-5d9e-4ada-b0e0-dccfc1651cc3"),
				Name = @"ModuleCode",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumnValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6fa45ba1-8ee1-4ef4-ada3-1543e25bfaa4"),
				Name = @"TypeColumnValue",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e9893dd0-1b12-472f-a376-d05b5819bbe8"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("fb70c81c-8174-4b2e-96f3-8df1e8d77b15"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("1963b82f-827a-45d5-9d45-b9c69a3e7506")
			};
		}

		protected virtual EntitySchemaColumn CreateWorkspaceIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b275afd8-5088-4ed6-9662-d1446c623918"),
				Name = @"WorkspaceId",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5895f30b-5a47-4f05-8f79-115c3ec02289"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("69e251dd-db32-44f2-a05d-77898f910c49")
			};
		}

		protected virtual EntitySchemaColumn CreateActionKindCaptionLczIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("e1e9611c-2577-42c1-ada9-c0774b0870b0"),
				Name = @"ActionKindCaptionLczId",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreatePageCaptionLczIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("af4eea3a-6b29-4660-b210-5741aa0b432c"),
				Name = @"PageCaptionLczId",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreateCultureIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("0200b64c-bd50-430d-91c6-7d8b5d68812c"),
				Name = @"CultureId",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("f49bb6bd-841c-4c63-ad99-02e5e16b44e0")
			};
		}

		protected virtual EntitySchemaColumn CreatePageCaptionLczColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("71f4df89-250e-4d61-a538-edf9301ef880"),
				Name = @"PageCaptionLcz",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("c53101b8-fc97-4884-80b5-073b8b9d9629")
			};
		}

		protected virtual EntitySchemaColumn CreatePageCaptionLczOldColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("98bc6c48-5298-493b-b45e-bcb328910139"),
				Name = @"PageCaptionLczOld",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultPageCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("9b876e95-b332-45ff-8153-b3e41d8932e9"),
				Name = @"DefaultPageCaption",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("e1c0b1c2-9464-4e77-9858-9f20ed2250ae")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("61e2b1cd-456e-4725-82d5-f074ef3912b4"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				ModifiedInSchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856"),
				CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwModuleEditInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwModuleEditInfo_PlatformEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwModuleEditInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwModuleEditInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4f23352c-e046-4fb8-b637-885559863856"));
		}

		#endregion

	}

	#endregion

	#region Class: VwModuleEditInfo

	/// <summary>
	/// Section card information (view).
	/// </summary>
	public class VwModuleEditInfo : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwModuleEditInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwModuleEditInfo";
		}

		public VwModuleEditInfo(VwModuleEditInfo source)
			: base(source) {
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
		/// ModuleCode.
		/// </summary>
		public string ModuleCode {
			get {
				return GetTypedColumnValue<string>("ModuleCode");
			}
			set {
				SetColumnValue("ModuleCode", value);
			}
		}

		/// <summary>
		/// TypeColumnValue.
		/// </summary>
		public Guid TypeColumnValue {
			get {
				return GetTypedColumnValue<Guid>("TypeColumnValue");
			}
			set {
				SetColumnValue("TypeColumnValue", value);
			}
		}

		/// <summary>
		/// Name.
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
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		/// <summary>
		/// WorkspaceId.
		/// </summary>
		public Guid WorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("WorkspaceId");
			}
			set {
				SetColumnValue("WorkspaceId", value);
			}
		}

		/// <summary>
		/// RecordId.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// ActionKindCaptionLczId.
		/// </summary>
		public Guid ActionKindCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("ActionKindCaptionLczId");
			}
			set {
				SetColumnValue("ActionKindCaptionLczId", value);
			}
		}

		/// <summary>
		/// PageCaptionLczId.
		/// </summary>
		public Guid PageCaptionLczId {
			get {
				return GetTypedColumnValue<Guid>("PageCaptionLczId");
			}
			set {
				SetColumnValue("PageCaptionLczId", value);
			}
		}

		/// <summary>
		/// CultureId.
		/// </summary>
		public Guid CultureId {
			get {
				return GetTypedColumnValue<Guid>("CultureId");
			}
			set {
				SetColumnValue("CultureId", value);
			}
		}

		/// <summary>
		/// PageCaptionLcz.
		/// </summary>
		public string PageCaptionLcz {
			get {
				return GetTypedColumnValue<string>("PageCaptionLcz");
			}
			set {
				SetColumnValue("PageCaptionLcz", value);
			}
		}

		/// <summary>
		/// PageCaptionLczOld.
		/// </summary>
		public string PageCaptionLczOld {
			get {
				return GetTypedColumnValue<string>("PageCaptionLczOld");
			}
			set {
				SetColumnValue("PageCaptionLczOld", value);
			}
		}

		/// <summary>
		/// Default page caption.
		/// </summary>
		public string DefaultPageCaption {
			get {
				return GetTypedColumnValue<string>("DefaultPageCaption");
			}
			set {
				SetColumnValue("DefaultPageCaption", value);
			}
		}

		/// <summary>
		/// ModifiedOn.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwModuleEditInfo_PlatformEventsProcess(UserConnection);
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
			return new VwModuleEditInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwModuleEditInfo_PlatformEventsProcess

	/// <exclude/>
	public partial class VwModuleEditInfo_PlatformEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwModuleEditInfo
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwModuleEditInfo_PlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwModuleEditInfo_PlatformEventsProcess";
			SchemaUId = new Guid("4f23352c-e046-4fb8-b637-885559863856");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4f23352c-e046-4fb8-b637-885559863856");
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

	#region Class: VwModuleEditInfo_PlatformEventsProcess

	/// <exclude/>
	public class VwModuleEditInfo_PlatformEventsProcess : VwModuleEditInfo_PlatformEventsProcess<VwModuleEditInfo>
	{

		public VwModuleEditInfo_PlatformEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwModuleEditInfo_PlatformEventsProcess

	public partial class VwModuleEditInfo_PlatformEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwModuleEditInfoEventsProcess

	/// <exclude/>
	public class VwModuleEditInfoEventsProcess : VwModuleEditInfo_PlatformEventsProcess
	{

		public VwModuleEditInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

