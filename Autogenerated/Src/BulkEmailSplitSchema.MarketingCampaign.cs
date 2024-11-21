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

	#region Class: BulkEmailSplitSchema

	/// <exclude/>
	public class BulkEmailSplitSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailSplitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSplitSchema(BulkEmailSplitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSplitSchema(BulkEmailSplitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b");
			RealUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b");
			Name = "BulkEmailSplit";
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("70300a2a-9336-4ab4-b5b2-123e2fcdba48")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("b7de60f6-5855-4b2d-9f37-98cb233d172b")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("7b9b5074-5977-4828-af78-0e3f7d875b87")) == null) {
				Columns.Add(CreateRecipientPercentColumn());
			}
			if (Columns.FindByUId(new Guid("04fe72a0-74a7-4db5-8f79-f09f8c948b17")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("7401d97d-7cd1-444d-9fa3-8b9ef05158e0")) == null) {
				Columns.Add(CreateStartManualColumn());
			}
			if (Columns.FindByUId(new Guid("d5547418-fc48-4247-a834-6b32804729d3")) == null) {
				Columns.Add(CreateRecipientCountColumn());
			}
			if (Columns.FindByUId(new Guid("13707fcb-75aa-4331-82ce-3887cbc7e5b3")) == null) {
				Columns.Add(CreateSegmentsStatusColumn());
			}
			if (Columns.FindByUId(new Guid("6d87fe1f-9b88-42c3-bb8b-b363857d6343")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("972d17af-31c3-4843-8e5b-be8abad1b3af")) == null) {
				Columns.Add(CreateTransferTableNameColumn());
			}
			if (Columns.FindByUId(new Guid("92fa8c67-605e-4724-9e3e-0afe9ee9ed81")) == null) {
				Columns.Add(CreateTestRecipientCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("25d18b21-5fab-495b-9d87-ae1e77b0cf5d"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("70300a2a-9336-4ab4-b5b2-123e2fcdba48"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b7de60f6-5855-4b2d-9f37-98cb233d172b"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("f91bf1c9-a18d-4446-9a5d-ed7e90d37d98"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"cb26ed70-e6f7-4e48-bc7b-560b2676fcc6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientPercentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("7b9b5074-5977-4828-af78-0e3f7d875b87"),
				Name = @"RecipientPercent",
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"10"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("04fe72a0-74a7-4db5-8f79-f09f8c948b17"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected virtual EntitySchemaColumn CreateStartManualColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("7401d97d-7cd1-444d-9fa3-8b9ef05158e0"),
				Name = @"StartManual",
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d5547418-fc48-4247-a834-6b32804729d3"),
				Name = @"RecipientCount",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateSegmentsStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("13707fcb-75aa-4331-82ce-3887cbc7e5b3"),
				Name = @"SegmentsStatus",
				ReferenceSchemaUId = new Guid("80ea7f5b-3991-42c6-bc29-f101d9757c70"),
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"fa360d2c-1658-49ad-9152-22479fdc0c12"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6d87fe1f-9b88-42c3-bb8b-b363857d6343"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected virtual EntitySchemaColumn CreateTransferTableNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("972d17af-31c3-4843-8e5b-be8abad1b3af"),
				Name = @"TransferTableName",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected virtual EntitySchemaColumn CreateTestRecipientCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("92fa8c67-605e-4724-9e3e-0afe9ee9ed81"),
				Name = @"TestRecipientCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				ModifiedInSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				CreatedInPackageId = new Guid("a71cf908-541e-4deb-89f8-9de8aba93b8f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailSplit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSplit_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSplitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSplitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplit

	/// <summary>
	/// Сплит-тест.
	/// </summary>
	public class BulkEmailSplit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailSplit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplit";
		}

		public BulkEmailSplit(BulkEmailSplit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
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
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
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

		private BulkEmailSplitStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public BulkEmailSplitStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as BulkEmailSplitStatus);
			}
		}

		/// <summary>
		/// % получателей.
		/// </summary>
		public Decimal RecipientPercent {
			get {
				return GetTypedColumnValue<Decimal>("RecipientPercent");
			}
			set {
				SetColumnValue("RecipientPercent", value);
			}
		}

		/// <summary>
		/// Начало.
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
		/// Запустить тест вручную.
		/// </summary>
		public bool StartManual {
			get {
				return GetTypedColumnValue<bool>("StartManual");
			}
			set {
				SetColumnValue("StartManual", value);
			}
		}

		/// <summary>
		/// RecipientCount.
		/// </summary>
		public int RecipientCount {
			get {
				return GetTypedColumnValue<int>("RecipientCount");
			}
			set {
				SetColumnValue("RecipientCount", value);
			}
		}

		/// <exclude/>
		public Guid SegmentsStatusId {
			get {
				return GetTypedColumnValue<Guid>("SegmentsStatusId");
			}
			set {
				SetColumnValue("SegmentsStatusId", value);
				_segmentsStatus = null;
			}
		}

		/// <exclude/>
		public string SegmentsStatusName {
			get {
				return GetTypedColumnValue<string>("SegmentsStatusName");
			}
			set {
				SetColumnValue("SegmentsStatusName", value);
				if (_segmentsStatus != null) {
					_segmentsStatus.Name = value;
				}
			}
		}

		private SegmentStatus _segmentsStatus;
		/// <summary>
		/// Состояние актуализации сегментов.
		/// </summary>
		public SegmentStatus SegmentsStatus {
			get {
				return _segmentsStatus ??
					(_segmentsStatus = LookupColumnEntities.GetEntity("SegmentsStatus") as SegmentStatus);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <summary>
		/// TransferTableName.
		/// </summary>
		public string TransferTableName {
			get {
				return GetTypedColumnValue<string>("TransferTableName");
			}
			set {
				SetColumnValue("TransferTableName", value);
			}
		}

		/// <summary>
		/// Получателей.
		/// </summary>
		public int TestRecipientCount {
			get {
				return GetTypedColumnValue<int>("TestRecipientCount");
			}
			set {
				SetColumnValue("TestRecipientCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailSplit_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailSplitDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailSplitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailSplit(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplit_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSplit_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailSplit
	{

		public BulkEmailSplit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSplit_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9682719a-2ac0-47c8-af3a-f988a778988b");
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

	#region Class: BulkEmailSplit_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSplit_MarketingCampaignEventsProcess : BulkEmailSplit_MarketingCampaignEventsProcess<BulkEmailSplit>
	{

		public BulkEmailSplit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSplit_MarketingCampaignEventsProcess

	public partial class BulkEmailSplit_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailSplitEventsProcess

	/// <exclude/>
	public class BulkEmailSplitEventsProcess : BulkEmailSplit_MarketingCampaignEventsProcess
	{

		public BulkEmailSplitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

