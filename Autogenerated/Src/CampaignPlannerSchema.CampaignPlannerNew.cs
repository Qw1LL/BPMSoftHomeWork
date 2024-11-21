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

	#region Class: CampaignPlannerSchema

	/// <exclude/>
	public class CampaignPlannerSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignPlannerSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerSchema(CampaignPlannerSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerSchema(CampaignPlannerSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a");
			RealUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a");
			Name = "CampaignPlanner";
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
			if (Columns.FindByUId(new Guid("686c7ad1-a2e5-4818-91b3-62a10485b039")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("58533759-0437-4aaf-810b-132c46959afb")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("7c063b51-5195-4093-a105-60cc671da79d")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("5c437791-3c1b-43b1-92f6-f835c9b4e2c2")) == null) {
				Columns.Add(CreatePlannedBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("dd1939e7-727c-4e41-8d47-30875b33933b")) == null) {
				Columns.Add(CreateSpentBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("7a5e12c1-2743-44d8-a6ef-129b5da78e17")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("8112e3dd-bcc3-4a3b-b0c9-efe44cb61478")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("38fe36ab-0d6b-4c9c-8d04-c4f74af75a1f")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("d9bab9f8-4bb8-499a-b523-3235eec0b919")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("54d4522c-2619-4b8f-a7fb-64a40bdbff84")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
			if (Columns.FindByUId(new Guid("a1537bb7-2c03-4d6a-99aa-761faacef067")) == null) {
				Columns.Add(CreatePrimaryPlannedBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("95701e2a-9512-4155-850d-101fd2a82092")) == null) {
				Columns.Add(CreatePrimarySpentBudgetColumn());
			}
			if (Columns.FindByUId(new Guid("1c1d864e-41a7-4647-a0b7-f08ff7f6e441")) == null) {
				Columns.Add(CreateBrandColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("620b2989-d467-427c-a032-1273098ee48d"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("686c7ad1-a2e5-4818-91b3-62a10485b039"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("802a5e28-c483-4ad1-98f2-70e9fe9dc18e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"f0bdfa16-e362-44da-86e5-a8eb5da6faed"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("58533759-0437-4aaf-810b-132c46959afb"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("60706b93-af92-4107-9718-01488109709e"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				IsSimpleLookup = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"84a02ae9-c11e-4011-8d5b-f87b6c3ce01d"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7c063b51-5195-4093-a105-60cc671da79d"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePlannedBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("5c437791-3c1b-43b1-92f6-f835c9b4e2c2"),
				Name = @"PlannedBudget",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateSpentBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("dd1939e7-727c-4e41-8d47-30875b33933b"),
				Name = @"SpentBudget",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("7a5e12c1-2743-44d8-a6ef-129b5da78e17"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("8112e3dd-bcc3-4a3b-b0c9-efe44cb61478"),
				Name = @"DueDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("38fe36ab-0d6b-4c9c-8d04-c4f74af75a1f"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d9bab9f8-4bb8-499a-b523-3235eec0b919"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("54d4522c-2619-4b8f-a7fb-64a40bdbff84"),
				Name = @"CurrencyRate",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPlannedBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("a1537bb7-2c03-4d6a-99aa-761faacef067"),
				Name = @"PrimaryPlannedBudget",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimarySpentBudgetColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("95701e2a-9512-4155-850d-101fd2a82092"),
				Name = @"PrimarySpentBudget",
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected virtual EntitySchemaColumn CreateBrandColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1c1d864e-41a7-4647-a0b7-f08ff7f6e441"),
				Name = @"Brand",
				ReferenceSchemaUId = new Guid("fddaa2c5-f6e7-4199-a5ea-8217948ce1bd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				ModifiedInSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
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
			return new CampaignPlanner(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlanner_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlanner

	/// <summary>
	/// Маркетинговый план.
	/// </summary>
	public class CampaignPlanner : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignPlanner(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlanner";
		}

		public CampaignPlanner(CampaignPlanner source)
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
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private CampaignPlannerType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CampaignPlannerType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as CampaignPlannerType);
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

		private CampaignPlannerStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CampaignPlannerStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CampaignPlannerStatus);
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

		/// <exclude/>
		public Guid BrandId {
			get {
				return GetTypedColumnValue<Guid>("BrandId");
			}
			set {
				SetColumnValue("BrandId", value);
				_brand = null;
			}
		}

		/// <exclude/>
		public string BrandName {
			get {
				return GetTypedColumnValue<string>("BrandName");
			}
			set {
				SetColumnValue("BrandName", value);
				if (_brand != null) {
					_brand.Name = value;
				}
			}
		}

		private Brand _brand;
		/// <summary>
		/// Бренд.
		/// </summary>
		public Brand Brand {
			get {
				return _brand ??
					(_brand = LookupColumnEntities.GetEntity("Brand") as Brand);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlanner_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignPlannerValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlanner(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlanner_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlanner_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignPlanner
	{

		public CampaignPlanner_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlanner_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f193aa9c-3e39-442f-8028-f666a64b262a");
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

	#region Class: CampaignPlanner_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlanner_CampaignPlannerNewEventsProcess : CampaignPlanner_CampaignPlannerNewEventsProcess<CampaignPlanner>
	{

		public CampaignPlanner_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlanner_CampaignPlannerNewEventsProcess

	public partial class CampaignPlanner_CampaignPlannerNewEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignPlannerEventsProcess

	/// <exclude/>
	public class CampaignPlannerEventsProcess : CampaignPlanner_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

