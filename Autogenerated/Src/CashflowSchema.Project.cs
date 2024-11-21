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

	#region Class: CashflowSchema

	/// <exclude/>
	public class CashflowSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CashflowSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CashflowSchema(CashflowSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CashflowSchema(CashflowSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			RealUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			Name = "Cashflow";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("860e109f-7bf8-41bb-850d-72a6fda9836a")) == null) {
				Columns.Add(CreateProjectColumn());
			}
			if (Columns.FindByUId(new Guid("0f14f613-0182-46cd-bb35-ea59f7db50b4")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("eac36361-c116-4747-9e46-65bb95a6d2d6")) == null) {
				Columns.Add(CreateDetailsColumn());
			}
			if (Columns.FindByUId(new Guid("114e09c8-70b0-46e9-a81e-27988e71316a")) == null) {
				Columns.Add(CreateCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("b0ae3cfe-6600-4747-8b05-683a5d93dd93")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("4703b016-cec8-4dc1-aa5d-174916a65adb")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("e4ada506-1bcf-4ce3-8a52-f94ee17faa7b")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("e2d8a9ca-9404-42fa-b6a1-6b3f00e8ab31")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
			if (Columns.FindByUId(new Guid("60d967e1-98f8-44b2-8770-1d6f3d620196")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("c58a5a82-67ab-43e0-b7c8-31380946a514")) == null) {
				Columns.Add(CreatePrimaryAmountColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			column.CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("860e109f-7bf8-41bb-850d-72a6fda9836a"),
				Name = @"Project",
				ReferenceSchemaUId = new Guid("a11d7fa4-9946-494c-ae41-2169844d29be"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("7fc005d5-e9ca-439d-aeb5-ecdeb6587781"),
				Name = @"Number",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0f14f613-0182-46cd-bb35-ea59f7db50b4"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("22a9cf97-97de-4d60-9d09-9922849cfeb0"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateDetailsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("eac36361-c116-4747-9e46-65bb95a6d2d6"),
				Name = @"Details",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("114e09c8-70b0-46e9-a81e-27988e71316a"),
				Name = @"Category",
				ReferenceSchemaUId = new Guid("31bad651-347e-4d44-90c6-70b79b83dbac"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b0ae3cfe-6600-4747-8b05-683a5d93dd93"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("7178b348-b19f-49dd-897b-104873aebc12"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"7526510f-dedb-42f0-bcdc-331955b0c91d"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("4703b016-cec8-4dc1-aa5d-174916a65adb"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e4ada506-1bcf-4ce3-8a52-f94ee17faa7b"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float4")) {
				UId = new Guid("e2d8a9ca-9404-42fa-b6a1-6b3f00e8ab31"),
				Name = @"CurrencyRate",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("60d967e1-98f8-44b2-8770-1d6f3d620196"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("c58a5a82-67ab-43e0-b7c8-31380946a514"),
				Name = @"PrimaryAmount",
				CreatedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				ModifiedInSchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"),
				CreatedInPackageId = new Guid("6ab05131-1cb5-4886-8c5e-4437f132bb8c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Cashflow(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Cashflow_ProjectEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CashflowSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CashflowSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435"));
		}

		#endregion

	}

	#endregion

	#region Class: Cashflow

	/// <summary>
	/// Операция.
	/// </summary>
	public class Cashflow : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Cashflow(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Cashflow";
		}

		public Cashflow(Cashflow source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProjectId {
			get {
				return GetTypedColumnValue<Guid>("ProjectId");
			}
			set {
				SetColumnValue("ProjectId", value);
				_project = null;
			}
		}

		/// <exclude/>
		public string ProjectName {
			get {
				return GetTypedColumnValue<string>("ProjectName");
			}
			set {
				SetColumnValue("ProjectName", value);
				if (_project != null) {
					_project.Name = value;
				}
			}
		}

		private Project _project;
		/// <summary>
		/// Проект.
		/// </summary>
		public Project Project {
			get {
				return _project ??
					(_project = LookupColumnEntities.GetEntity("Project") as Project);
			}
		}

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
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

		private CashflowType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public CashflowType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as CashflowType);
			}
		}

		/// <summary>
		/// Назначение.
		/// </summary>
		public string Details {
			get {
				return GetTypedColumnValue<string>("Details");
			}
			set {
				SetColumnValue("Details", value);
			}
		}

		/// <exclude/>
		public Guid CategoryId {
			get {
				return GetTypedColumnValue<Guid>("CategoryId");
			}
			set {
				SetColumnValue("CategoryId", value);
				_category = null;
			}
		}

		/// <exclude/>
		public string CategoryName {
			get {
				return GetTypedColumnValue<string>("CategoryName");
			}
			set {
				SetColumnValue("CategoryName", value);
				if (_category != null) {
					_category.Name = value;
				}
			}
		}

		private CashflowCategory _category;
		/// <summary>
		/// Категория.
		/// </summary>
		public CashflowCategory Category {
			get {
				return _category ??
					(_category = LookupColumnEntities.GetEntity("Category") as CashflowCategory);
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

		private CashflowStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CashflowStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CashflowStatus);
			}
		}

		/// <summary>
		/// Дата.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
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
		/// Сумма.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Сумма, б.в.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Cashflow_ProjectEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CashflowDeleted", e);
			Inserting += (s, e) => ThrowEvent("CashflowInserting", e);
			Saved += (s, e) => ThrowEvent("CashflowSaved", e);
			Validating += (s, e) => ThrowEvent("CashflowValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Cashflow(this);
		}

		#endregion

	}

	#endregion

	#region Class: Cashflow_ProjectEventsProcess

	/// <exclude/>
	public partial class Cashflow_ProjectEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Cashflow
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Cashflow_ProjectEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("6cf2afd6-e92e-46dc-9746-efa152a8304e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Cashflow_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Cashflow_ProjectEventsProcess";
			SchemaUId = new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8e2a77e-01df-4f4b-ae62-12e67d8b0435");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("6a91956c-f304-4c1b-aa4a-3eadcd22194e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _cashflowSaved;
		public ProcessFlowElement CashflowSaved {
			get {
				return _cashflowSaved ?? (_cashflowSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CashflowSaved",
					SchemaElementUId = new Guid("21887e77-b9c4-47ff-8c2a-204b055efd40"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setGenerateParamScript;
		public ProcessScriptTask SetGenerateParamScript {
			get {
				return _setGenerateParamScript ?? (_setGenerateParamScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGenerateParamScript",
					SchemaElementUId = new Guid("89160baa-9d0e-4f12-86b8-0e2939dd0620"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGenerateParamScriptExecute,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("1c976ec0-27c0-4103-ad83-77b73c6066cc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("156294f2-f76f-4fc8-8d88-5b4ce378d6fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _setGeneratedNumberScript;
		public ProcessScriptTask SetGeneratedNumberScript {
			get {
				return _setGeneratedNumberScript ?? (_setGeneratedNumberScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGeneratedNumberScript",
					SchemaElementUId = new Guid("ed95b7b8-319a-4496-8a53-a0c5d3c09824"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGeneratedNumberScriptExecute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("f1b930c9-8b79-4235-821e-7773bafea8c9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[CashflowSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { CashflowSaved };
			FlowElements[SetGenerateParamScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGenerateParamScript };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[SetGeneratedNumberScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGeneratedNumberScript };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "CashflowSaved":
						e.Context.QueueTasks.Enqueue("SetGenerateParamScript");
						break;
					case "SetGenerateParamScript":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "Terminate1":
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "SetGeneratedNumberScript":
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("SetGeneratedNumberScript");
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CashflowSaved");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "CashflowSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "CashflowSaved";
					result = CashflowSaved.Execute(context);
					break;
				case "SetGenerateParamScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGenerateParamScript";
					result = SetGenerateParamScript.Execute(context, SetGenerateParamScriptExecute);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "SetGeneratedNumberScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGeneratedNumberScript";
					result = SetGeneratedNumberScript.Execute(context, SetGeneratedNumberScriptExecute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SetGenerateParamScriptExecute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool SetGeneratedNumberScriptExecute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			var update = new Update(UserConnection, Entity.Schema.Name)
				.Set("Number", Column.Parameter(code))
				.Where("Id").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
			update.Execute();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CashflowSaved":
							if (ActivatedEventElements.Contains("CashflowSaved")) {
							context.QueueTasks.Enqueue("CashflowSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Cashflow_ProjectEventsProcess

	/// <exclude/>
	public class Cashflow_ProjectEventsProcess : Cashflow_ProjectEventsProcess<Cashflow>
	{

		public Cashflow_ProjectEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Cashflow_ProjectEventsProcess

	public partial class Cashflow_ProjectEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CashflowEventsProcess

	/// <exclude/>
	public class CashflowEventsProcess : Cashflow_ProjectEventsProcess
	{

		public CashflowEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

