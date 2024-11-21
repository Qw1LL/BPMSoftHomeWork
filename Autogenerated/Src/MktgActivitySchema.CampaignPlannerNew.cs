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

	#region Class: MktgActivity_CampaignPlannerNew_BPMSoftSchema

	/// <exclude/>
	public class MktgActivity_CampaignPlannerNew_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public MktgActivity_CampaignPlannerNew_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivity_CampaignPlannerNew_BPMSoftSchema(MktgActivity_CampaignPlannerNew_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivity_CampaignPlannerNew_BPMSoftSchema(MktgActivity_CampaignPlannerNew_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
			RealUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
			Name = "MktgActivity_CampaignPlannerNew_BPMSoft";
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
			if (Columns.FindByUId(new Guid("e3be1f7b-d46f-4df0-ad6a-3806a42aea05")) == null) {
				Columns.Add(CreateChannelColumn());
			}
			if (Columns.FindByUId(new Guid("79607918-f89b-47fc-b976-5945e7a3de50")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("dfb98797-115a-4c77-91ad-39fc30dc6fc0")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("84eb6cc6-a7d7-49a2-a2e5-d724d819ee13")) == null) {
				Columns.Add(CreatePlannedBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("656b1c2a-96a5-4ddd-8a18-1c9d9fc7f109")) == null) {
				Columns.Add(CreateSpentBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("82aefd99-d6c7-4d4e-990f-5f18514e02e4")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("e79c9c22-c880-4469-9519-5cfc292e90bb")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("547c0a54-1685-4f57-b6df-f95463088d8e")) == null) {
				Columns.Add(CreatePrimaryPlannedBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("e535caa3-97f9-44e7-ba1b-690b04905a50")) == null) {
				Columns.Add(CreatePrimarySpentBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("fc99bbe2-6de4-4b31-8e0b-62a5a9f16c8b")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("a2e14184-4fbe-4ea8-a1c5-5374c153df02")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("da7fd106-7d41-4da2-9477-24e532ac4024")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
			if (Columns.FindByUId(new Guid("e11a7985-51da-44ac-ae01-3ada555bd809")) == null) {
				Columns.Add(CreateCampaignPlannerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fc472f51-c055-4f41-8e1a-816b6e253daa"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateChannelColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e3be1f7b-d46f-4df0-ad6a-3806a42aea05"),
				Name = @"Channel",
				ReferenceSchemaUId = new Guid("308ef8cd-4f4f-4898-9b3d-36ab9af01f5c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("79607918-f89b-47fc-b976-5945e7a3de50"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("80b0b33e-3dc6-4900-b7fe-844446c56a53"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"302e26bf-4a35-45bd-8675-48ed2cdf3f6b"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dfb98797-115a-4c77-91ad-39fc30dc6fc0"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePlannedBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("84eb6cc6-a7d7-49a2-a2e5-d724d819ee13"),
				Name = @"PlannedBudget",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateSpentBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("656b1c2a-96a5-4ddd-8a18-1c9d9fc7f109"),
				Name = @"SpentBudget",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("82aefd99-d6c7-4d4e-990f-5f18514e02e4"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("e79c9c22-c880-4469-9519-5cfc292e90bb"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPlannedBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("547c0a54-1685-4f57-b6df-f95463088d8e"),
				Name = @"PrimaryPlannedBudget",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimarySpentBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("e535caa3-97f9-44e7-ba1b-690b04905a50"),
				Name = @"PrimarySpentBudget",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("fc99bbe2-6de4-4b31-8e0b-62a5a9f16c8b"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a2e14184-4fbe-4ea8-a1c5-5374c153df02"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("da7fd106-7d41-4da2-9477-24e532ac4024"),
				Name = @"CurrencyRate",
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignPlannerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e11a7985-51da-44ac-ae01-3ada555bd809"),
				Name = @"CampaignPlanner",
				ReferenceSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				ModifiedInSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"),
				CreatedInPackageId = new Guid("7ec8a306-88cd-4c6d-a651-87154ce0f247")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MktgActivity_CampaignPlannerNew_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivity_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivity_CampaignPlannerNew_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivity_CampaignPlannerNew_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_CampaignPlannerNew_BPMSoft

	/// <summary>
	/// Маркетинговая активность.
	/// </summary>
	public class MktgActivity_CampaignPlannerNew_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public MktgActivity_CampaignPlannerNew_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivity_CampaignPlannerNew_BPMSoft";
		}

		public MktgActivity_CampaignPlannerNew_BPMSoft(MktgActivity_CampaignPlannerNew_BPMSoft source)
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
		public Guid ChannelId {
			get {
				return GetTypedColumnValue<Guid>("ChannelId");
			}
			set {
				SetColumnValue("ChannelId", value);
				_channel = null;
			}
		}

		/// <exclude/>
		public string ChannelName {
			get {
				return GetTypedColumnValue<string>("ChannelName");
			}
			set {
				SetColumnValue("ChannelName", value);
				if (_channel != null) {
					_channel.Name = value;
				}
			}
		}

		private LeadMedium _channel;
		/// <summary>
		/// Канал.
		/// </summary>
		public LeadMedium Channel {
			get {
				return _channel ??
					(_channel = LookupColumnEntities.GetEntity("Channel") as LeadMedium);
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

		private MktgActivityStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public MktgActivityStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as MktgActivityStatus);
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

		/// <summary>
		/// Плановый бюджет.
		/// </summary>
		public Decimal PlannedBudget {
			get {
				return GetTypedColumnValue<Decimal>("PlannedBudget");
			}
			set {
				SetColumnValue("PlannedBudget", value);
			}
		}

		/// <summary>
		/// Фактический бюджет.
		/// </summary>
		public Decimal SpentBudget {
			get {
				return GetTypedColumnValue<Decimal>("SpentBudget");
			}
			set {
				SetColumnValue("SpentBudget", value);
			}
		}

		/// <summary>
		/// Дата начала.
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
		/// Дата завершения.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Плановый бюджет, базовая валюта.
		/// </summary>
		public Decimal PrimaryPlannedBudget {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPlannedBudget");
			}
			set {
				SetColumnValue("PrimaryPlannedBudget", value);
			}
		}

		/// <summary>
		/// Фактический бюджет, базовая валюта.
		/// </summary>
		public Decimal PrimarySpentBudget {
			get {
				return GetTypedColumnValue<Decimal>("PrimarySpentBudget");
			}
			set {
				SetColumnValue("PrimarySpentBudget", value);
			}
		}

		/// <summary>
		/// Заметки.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		/// <exclude/>
		public Guid CampaignPlannerId {
			get {
				return GetTypedColumnValue<Guid>("CampaignPlannerId");
			}
			set {
				SetColumnValue("CampaignPlannerId", value);
				_campaignPlanner = null;
			}
		}

		/// <exclude/>
		public string CampaignPlannerName {
			get {
				return GetTypedColumnValue<string>("CampaignPlannerName");
			}
			set {
				SetColumnValue("CampaignPlannerName", value);
				if (_campaignPlanner != null) {
					_campaignPlanner.Name = value;
				}
			}
		}

		private CampaignPlanner _campaignPlanner;
		/// <summary>
		/// Маркетинговый план.
		/// </summary>
		public CampaignPlanner CampaignPlanner {
			get {
				return _campaignPlanner ??
					(_campaignPlanner = LookupColumnEntities.GetEntity("CampaignPlanner") as CampaignPlanner);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MktgActivity_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivity_CampaignPlannerNew_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("MktgActivity_CampaignPlannerNew_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivity_CampaignPlannerNew_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class MktgActivity_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : MktgActivity_CampaignPlannerNew_BPMSoft
	{

		public MktgActivity_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivity_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
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

	#region Class: MktgActivity_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class MktgActivity_CampaignPlannerNewEventsProcess : MktgActivity_CampaignPlannerNewEventsProcess<MktgActivity_CampaignPlannerNew_BPMSoft>
	{

		public MktgActivity_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivity_CampaignPlannerNewEventsProcess

	public partial class MktgActivity_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

