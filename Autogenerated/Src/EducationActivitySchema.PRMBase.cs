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

	#region Class: EducationActivitySchema

	/// <exclude/>
	public class EducationActivitySchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EducationActivitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EducationActivitySchema(EducationActivitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EducationActivitySchema(EducationActivitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c");
			RealUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c");
			Name = "EducationActivity";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
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

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateContactColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3189b16f-1429-4a35-8cf0-f2d84b8d46ff")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("61441dc1-db2b-4cdb-9665-7313f5d9c6f6")) == null) {
				Columns.Add(CreateEducationActivityTypeColumn());
			}
			if (Columns.FindByUId(new Guid("b7a51817-1fc4-47e4-9303-07c70afe220f")) == null) {
				Columns.Add(CreateCostColumn());
			}
			if (Columns.FindByUId(new Guid("fe2ad4a5-3093-4f6e-98b0-634df92a38de")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("d68d57dc-6b91-43e2-a7d5-2dd80c9728b7")) == null) {
				Columns.Add(CreateEducationActivityResultColumn());
			}
			if (Columns.FindByUId(new Guid("f77e86cb-765a-46c3-a948-a2117e503315")) == null) {
				Columns.Add(CreateStatusOfActivityColumn());
			}
			if (Columns.FindByUId(new Guid("26775669-f3bb-4436-839c-b4bb0c815a35")) == null) {
				Columns.Add(CreatePaymentMethodColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d3088fdf-038f-4113-9cd3-dfd76e66deb5"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3189b16f-1429-4a35-8cf0-f2d84b8d46ff"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateEducationActivityTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("61441dc1-db2b-4cdb-9665-7313f5d9c6f6"),
				Name = @"EducationActivityType",
				ReferenceSchemaUId = new Guid("ca986710-7248-4a41-bd3d-5dbd5936ad5c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bda7ea8d-b646-474f-b55b-1f1c051a7c36"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateCostColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("b7a51817-1fc4-47e4-9303-07c70afe220f"),
				Name = @"Cost",
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("fe2ad4a5-3093-4f6e-98b0-634df92a38de"),
				Name = @"Date",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateEducationActivityResultColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d68d57dc-6b91-43e2-a7d5-2dd80c9728b7"),
				Name = @"EducationActivityResult",
				ReferenceSchemaUId = new Guid("1df945e2-2a19-463e-bb71-c589093d3ff0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusOfActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f77e86cb-765a-46c3-a948-a2117e503315"),
				Name = @"StatusOfActivity",
				ReferenceSchemaUId = new Guid("5c102754-283e-43e1-8529-fb0c1a7facbb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentMethodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("26775669-f3bb-4436-839c-b4bb0c815a35"),
				Name = @"PaymentMethod",
				ReferenceSchemaUId = new Guid("5da543c5-8aae-4ce0-9116-972d27a7307a"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				ModifiedInSchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"),
				CreatedInPackageId = new Guid("e6694e82-2be4-4388-8c1e-f340344f5039")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EducationActivity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EducationActivity_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EducationActivitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EducationActivitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c"));
		}

		#endregion

	}

	#endregion

	#region Class: EducationActivity

	/// <summary>
	/// Образовательная активность.
	/// </summary>
	public class EducationActivity : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EducationActivity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EducationActivity";
		}

		public EducationActivity(EducationActivity source)
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

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid EducationActivityTypeId {
			get {
				return GetTypedColumnValue<Guid>("EducationActivityTypeId");
			}
			set {
				SetColumnValue("EducationActivityTypeId", value);
				_educationActivityType = null;
			}
		}

		/// <exclude/>
		public string EducationActivityTypeName {
			get {
				return GetTypedColumnValue<string>("EducationActivityTypeName");
			}
			set {
				SetColumnValue("EducationActivityTypeName", value);
				if (_educationActivityType != null) {
					_educationActivityType.Name = value;
				}
			}
		}

		private EduActivityType _educationActivityType;
		/// <summary>
		/// Тип .
		/// </summary>
		public EduActivityType EducationActivityType {
			get {
				return _educationActivityType ??
					(_educationActivityType = LookupColumnEntities.GetEntity("EducationActivityType") as EduActivityType);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <summary>
		/// Цена.
		/// </summary>
		public Decimal Cost {
			get {
				return GetTypedColumnValue<Decimal>("Cost");
			}
			set {
				SetColumnValue("Cost", value);
			}
		}

		/// <summary>
		/// Дата проведения.
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
		public Guid EducationActivityResultId {
			get {
				return GetTypedColumnValue<Guid>("EducationActivityResultId");
			}
			set {
				SetColumnValue("EducationActivityResultId", value);
				_educationActivityResult = null;
			}
		}

		/// <exclude/>
		public string EducationActivityResultName {
			get {
				return GetTypedColumnValue<string>("EducationActivityResultName");
			}
			set {
				SetColumnValue("EducationActivityResultName", value);
				if (_educationActivityResult != null) {
					_educationActivityResult.Name = value;
				}
			}
		}

		private EduActivityResult _educationActivityResult;
		/// <summary>
		/// Результат.
		/// </summary>
		public EduActivityResult EducationActivityResult {
			get {
				return _educationActivityResult ??
					(_educationActivityResult = LookupColumnEntities.GetEntity("EducationActivityResult") as EduActivityResult);
			}
		}

		/// <exclude/>
		public Guid StatusOfActivityId {
			get {
				return GetTypedColumnValue<Guid>("StatusOfActivityId");
			}
			set {
				SetColumnValue("StatusOfActivityId", value);
				_statusOfActivity = null;
			}
		}

		/// <exclude/>
		public string StatusOfActivityName {
			get {
				return GetTypedColumnValue<string>("StatusOfActivityName");
			}
			set {
				SetColumnValue("StatusOfActivityName", value);
				if (_statusOfActivity != null) {
					_statusOfActivity.Name = value;
				}
			}
		}

		private EduActivityStatus _statusOfActivity;
		/// <summary>
		/// Состояние.
		/// </summary>
		public EduActivityStatus StatusOfActivity {
			get {
				return _statusOfActivity ??
					(_statusOfActivity = LookupColumnEntities.GetEntity("StatusOfActivity") as EduActivityStatus);
			}
		}

		/// <exclude/>
		public Guid PaymentMethodId {
			get {
				return GetTypedColumnValue<Guid>("PaymentMethodId");
			}
			set {
				SetColumnValue("PaymentMethodId", value);
				_paymentMethod = null;
			}
		}

		/// <exclude/>
		public string PaymentMethodName {
			get {
				return GetTypedColumnValue<string>("PaymentMethodName");
			}
			set {
				SetColumnValue("PaymentMethodName", value);
				if (_paymentMethod != null) {
					_paymentMethod.Name = value;
				}
			}
		}

		private PaymentMethod _paymentMethod;
		/// <summary>
		/// Способ оплаты.
		/// </summary>
		public PaymentMethod PaymentMethod {
			get {
				return _paymentMethod ??
					(_paymentMethod = LookupColumnEntities.GetEntity("PaymentMethod") as PaymentMethod);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EducationActivity_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EducationActivityDeleted", e);
			Inserted += (s, e) => ThrowEvent("EducationActivityInserted", e);
			Saved += (s, e) => ThrowEvent("EducationActivitySaved", e);
			Updated += (s, e) => ThrowEvent("EducationActivityUpdated", e);
			Validating += (s, e) => ThrowEvent("EducationActivityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EducationActivity(this);
		}

		#endregion

	}

	#endregion

	#region Class: EducationActivity_PRMBaseEventsProcess

	/// <exclude/>
	public partial class EducationActivity_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EducationActivity
	{

		public EducationActivity_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EducationActivity_PRMBaseEventsProcess";
			SchemaUId = new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("48a0ddfd-a99e-4bf5-8b5a-e56dfec31e0c");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _onEducationActivityAddedSubProcess;
		public ProcessFlowElement OnEducationActivityAddedSubProcess {
			get {
				return _onEducationActivityAddedSubProcess ?? (_onEducationActivityAddedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OnEducationActivityAddedSubProcess",
					SchemaElementUId = new Guid("5d1c8f20-a24f-4a6a-9619-3b8c52e3bded"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _educationActivityInserted;
		public ProcessFlowElement EducationActivityInserted {
			get {
				return _educationActivityInserted ?? (_educationActivityInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EducationActivityInserted",
					SchemaElementUId = new Guid("f2f7dc3c-732a-4bf7-b7d2-fdf8f73d444b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEducationActivityAddedScriptTask;
		public ProcessScriptTask OnEducationActivityAddedScriptTask {
			get {
				return _onEducationActivityAddedScriptTask ?? (_onEducationActivityAddedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEducationActivityAddedScriptTask",
					SchemaElementUId = new Guid("0d850dcf-d2fd-4839-9368-7ccc7d0b43db"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEducationActivityAddedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _onEducationActivityUpdatedSubProcess;
		public ProcessFlowElement onEducationActivityUpdatedSubProcess {
			get {
				return _onEducationActivityUpdatedSubProcess ?? (_onEducationActivityUpdatedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "onEducationActivityUpdatedSubProcess",
					SchemaElementUId = new Guid("6d01459d-3798-4741-8b67-3881d23620f1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _educationActivityUpdated;
		public ProcessFlowElement EducationActivityUpdated {
			get {
				return _educationActivityUpdated ?? (_educationActivityUpdated = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EducationActivityUpdated",
					SchemaElementUId = new Guid("342057e1-b6da-46bc-a9b1-02cbdf627115"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEducationActivityUpdatedScriptTask;
		public ProcessScriptTask OnEducationActivityUpdatedScriptTask {
			get {
				return _onEducationActivityUpdatedScriptTask ?? (_onEducationActivityUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEducationActivityUpdatedScriptTask",
					SchemaElementUId = new Guid("1d775339-305e-4d30-9d64-59c1d99518e4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEducationActivityUpdatedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _onEducationActivityDeletedSubProcess;
		public ProcessFlowElement OnEducationActivityDeletedSubProcess {
			get {
				return _onEducationActivityDeletedSubProcess ?? (_onEducationActivityDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OnEducationActivityDeletedSubProcess",
					SchemaElementUId = new Guid("ed700a2a-bb1b-4fbf-ab4f-4b3636126ff7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _educationActivityDeleted;
		public ProcessFlowElement EducationActivityDeleted {
			get {
				return _educationActivityDeleted ?? (_educationActivityDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EducationActivityDeleted",
					SchemaElementUId = new Guid("fbc75d42-cf3b-4285-b287-002e5db6b910"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEducationActivityDeletedScriptTask;
		public ProcessScriptTask OnEducationActivityDeletedScriptTask {
			get {
				return _onEducationActivityDeletedScriptTask ?? (_onEducationActivityDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEducationActivityDeletedScriptTask",
					SchemaElementUId = new Guid("36fab8e4-6e61-48d4-a958-adbee64032aa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEducationActivityDeletedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _onSavedSubProcess;
		public ProcessFlowElement OnSavedSubProcess {
			get {
				return _onSavedSubProcess ?? (_onSavedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "OnSavedSubProcess",
					SchemaElementUId = new Guid("698b52dc-9d95-45f9-9bf9-945421844b2d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _onSaved;
		public ProcessFlowElement OnSaved {
			get {
				return _onSaved ?? (_onSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "OnSaved",
					SchemaElementUId = new Guid("63acfcdc-3234-4f13-8644-11a1a0e73e6a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onEducationActivitySavedScriptTask;
		public ProcessScriptTask OnEducationActivitySavedScriptTask {
			get {
				return _onEducationActivitySavedScriptTask ?? (_onEducationActivitySavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnEducationActivitySavedScriptTask",
					SchemaElementUId = new Guid("4f06721a-8536-4ee1-9194-4a110ac09abf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnEducationActivitySavedScriptTaskExecute,
				});
			}
		}

		private LocalizableString _transactionMessageTemplate;
		public LocalizableString TransactionMessageTemplate {
			get {
				return _transactionMessageTemplate ?? (_transactionMessageTemplate = new LocalizableString(Storage, Schema.GetResourceManagerName(), "EventsProcessSchema.LocalizableStrings.TransactionMessageTemplate.Value"));
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[OnEducationActivityAddedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivityAddedSubProcess };
			FlowElements[EducationActivityInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { EducationActivityInserted };
			FlowElements[OnEducationActivityAddedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivityAddedScriptTask };
			FlowElements[onEducationActivityUpdatedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { onEducationActivityUpdatedSubProcess };
			FlowElements[EducationActivityUpdated.SchemaElementUId] = new Collection<ProcessFlowElement> { EducationActivityUpdated };
			FlowElements[OnEducationActivityUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivityUpdatedScriptTask };
			FlowElements[OnEducationActivityDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivityDeletedSubProcess };
			FlowElements[EducationActivityDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { EducationActivityDeleted };
			FlowElements[OnEducationActivityDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivityDeletedScriptTask };
			FlowElements[OnSavedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { OnSavedSubProcess };
			FlowElements[OnSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { OnSaved };
			FlowElements[OnEducationActivitySavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnEducationActivitySavedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "OnEducationActivityAddedSubProcess":
						break;
					case "EducationActivityInserted":
						e.Context.QueueTasks.Enqueue("OnEducationActivityAddedScriptTask");
						break;
					case "OnEducationActivityAddedScriptTask":
						break;
					case "onEducationActivityUpdatedSubProcess":
						break;
					case "EducationActivityUpdated":
						e.Context.QueueTasks.Enqueue("OnEducationActivityUpdatedScriptTask");
						break;
					case "OnEducationActivityUpdatedScriptTask":
						break;
					case "OnEducationActivityDeletedSubProcess":
						break;
					case "EducationActivityDeleted":
						e.Context.QueueTasks.Enqueue("OnEducationActivityDeletedScriptTask");
						break;
					case "OnEducationActivityDeletedScriptTask":
						break;
					case "OnSavedSubProcess":
						break;
					case "OnSaved":
						e.Context.QueueTasks.Enqueue("OnEducationActivitySavedScriptTask");
						break;
					case "OnEducationActivitySavedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EducationActivityInserted");
			ActivatedEventElements.Add("EducationActivityUpdated");
			ActivatedEventElements.Add("EducationActivityDeleted");
			ActivatedEventElements.Add("OnSaved");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "OnEducationActivityAddedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EducationActivityInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "EducationActivityInserted";
					result = EducationActivityInserted.Execute(context);
					break;
				case "OnEducationActivityAddedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEducationActivityAddedScriptTask";
					result = OnEducationActivityAddedScriptTask.Execute(context, OnEducationActivityAddedScriptTaskExecute);
					break;
				case "onEducationActivityUpdatedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EducationActivityUpdated":
					context.QueueTasks.Dequeue();
					context.SenderName = "EducationActivityUpdated";
					result = EducationActivityUpdated.Execute(context);
					break;
				case "OnEducationActivityUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEducationActivityUpdatedScriptTask";
					result = OnEducationActivityUpdatedScriptTask.Execute(context, OnEducationActivityUpdatedScriptTaskExecute);
					break;
				case "OnEducationActivityDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EducationActivityDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "EducationActivityDeleted";
					result = EducationActivityDeleted.Execute(context);
					break;
				case "OnEducationActivityDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEducationActivityDeletedScriptTask";
					result = OnEducationActivityDeletedScriptTask.Execute(context, OnEducationActivityDeletedScriptTaskExecute);
					break;
				case "OnSavedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "OnSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnSaved";
					result = OnSaved.Execute(context);
					break;
				case "OnEducationActivitySavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnEducationActivitySavedScriptTask";
					result = OnEducationActivitySavedScriptTask.Execute(context, OnEducationActivitySavedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool OnEducationActivityAddedScriptTaskExecute(ProcessExecutingContext context) {
			OnEducationActivityAdded();
			return true;
		}

		public virtual bool OnEducationActivityUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			OnEducationActivityUpdated();
			return true;
		}

		public virtual bool OnEducationActivityDeletedScriptTaskExecute(ProcessExecutingContext context) {
			OnEducationActivityDeleted();
			return true;
		}

		public virtual bool OnEducationActivitySavedScriptTaskExecute(ProcessExecutingContext context) {
			/*var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
			if (contactId == null) {
				return true;
			}
			var storedProcedure = new StoredProcedure(UserConnection, "tsp_ActualizePartnerCertificatesCount");
			storedProcedure.WithParameter(new QueryParameter("ActualizationDate", DateTime.UtcNow, "DateTime"));
			storedProcedure.WithParameter(Column.Parameter(contactId));
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(System.Data.IsolationLevel.ReadUncommitted);
				storedProcedure.Execute(dbExecutor);
				dbExecutor.CommitTransaction();
			}*/
			ActualizePartnerCertificatesCount();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EducationActivityInserted":
							if (ActivatedEventElements.Contains("EducationActivityInserted")) {
							context.QueueTasks.Enqueue("EducationActivityInserted");
						}
						break;
					case "EducationActivityUpdated":
							if (ActivatedEventElements.Contains("EducationActivityUpdated")) {
							context.QueueTasks.Enqueue("EducationActivityUpdated");
						}
						break;
					case "EducationActivityDeleted":
							if (ActivatedEventElements.Contains("EducationActivityDeleted")) {
							context.QueueTasks.Enqueue("EducationActivityDeleted");
						}
						break;
					case "EducationActivitySaved":
							if (ActivatedEventElements.Contains("OnSaved")) {
							context.QueueTasks.Enqueue("OnSaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: EducationActivity_PRMBaseEventsProcess

	/// <exclude/>
	public class EducationActivity_PRMBaseEventsProcess : EducationActivity_PRMBaseEventsProcess<EducationActivity>
	{

		public EducationActivity_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EducationActivity_PRMBaseEventsProcess

	public partial class EducationActivity_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void AddTransaction() {
			Entity contact = FindContact(Entity.GetTypedColumnValue<Guid>("ContactId"));
			if (contact == null || contact.GetColumnValue("AccountId") == null) {
				return;
			}
			Entity partnership = FindActivePartnership(contact.GetTypedColumnValue<Guid>("AccountId"));
			if (partnership == null) {
				return;
			}
			Entity certificationFund = GetFund(partnership, PRMBaseConstants.CertificationFundType);
			Entity prmTransaction = GetPRMTransactionEntity();
			prmTransaction.SetDefColumnValues();
			prmTransaction.SetColumnValue("TransactionTypeId", PRMBaseConstants.DebitTransactionType);
			prmTransaction.SetColumnValue("FundId", certificationFund.PrimaryColumnValue);
			prmTransaction.SetColumnValue("Amount", 1);
			prmTransaction.SetColumnValue("EntityId", PRMBaseConstants.EducationActivitySchemaUId);
			prmTransaction.SetColumnValue("RecordId", Entity.PrimaryColumnValue);
			string description = string.Format(TransactionMessageTemplate, contact.PrimaryDisplayColumnValue);
			prmTransaction.SetColumnValue("Description", description);
			prmTransaction.Save();
		}

		public virtual Entity FindActivePartnership(Guid accountId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Partnership");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Account", accountId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsActive", true));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			return collection.FirstOrDefault();
		}

		public virtual Entity FindFund(Entity partnership, Guid fundTypeId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Fund");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilterWithParameters(
				FilterComparisonType.Equal,"Partnership", partnership.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "FundType", fundTypeId));
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			return collection.FirstOrDefault();
		}

		public virtual Entity FindContact(Guid contactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Name");
			esq.AddColumn("Account");
			return esq.GetEntity(UserConnection, contactId);
		}

		public virtual void OnEducationActivityAdded() {
			if (IsTransactionNeeded()) {
				AddTransaction();
			}
		}

		public virtual void OnEducationActivityUpdated() {
			if (IsTransactionNeeded()) {
				AddTransaction();
			} else if (Entity.GetColumnOldValue("EducationActivityResultId") != null
					&& Entity.GetColumnValue("EducationActivityResultId") == null) {
				DeleteTransaction();
			}
		}

		public virtual Entity CreateCertificationFund(Entity partnership) {
			EntitySchema fundSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Fund");
			Entity fund = fundSchema.CreateEntity(UserConnection);
			fund.SetDefColumnValues();
			fund.SetColumnValue("PartnershipId", partnership.PrimaryColumnValue);
			fund.SetColumnValue("FundTypeId", PRMBaseConstants.CertificationFundType);
			fund.SetColumnValue("Amount", 0);
			fund.Save();
			return fund;
		}

		public virtual bool IsTransactionNeeded() {
			return (Entity.GetColumnOldValue("EducationActivityResultId") == null
					&& Entity.GetColumnValue("EducationActivityResultId") != null &&
					Entity.GetTypedColumnValue<Guid>("PaymentMethodId") == PRMBaseConstants.NotPaidPaymentMethod);
		}

		public virtual Entity GetFund(Entity partnership, Guid fundTypeId) {
			Entity certificationFund = FindFund(partnership, PRMBaseConstants.CertificationFundType);
			if (certificationFund == null) {
				certificationFund = CreateCertificationFund(partnership);
			}
			return certificationFund;
		}

		public virtual void OnEducationActivityDeleted() {
			DeleteTransaction();
		}

		public virtual void DeleteTransaction() {
			Entity prmTransaction = GetPRMTransactionEntity();
			var fetchConditions = new Dictionary<string, object> {
				{"RecordId", Entity.PrimaryColumnValue}
			};
			if (prmTransaction.FetchFromDB(fetchConditions)) {
				prmTransaction.Delete();
			}
		}

		public virtual Entity GetPRMTransactionEntity() {
			EntitySchema prmTransactionSchema = UserConnection.EntitySchemaManager.GetInstanceByName("PRMTransaction");
			return prmTransactionSchema.CreateEntity(UserConnection);
		}

		public virtual void ActualizePartnerCertificatesCount() {
			Entity contact = FindContact(Entity.GetTypedColumnValue<Guid>("ContactId"));
			var accountId = contact.GetTypedColumnValue<Guid>("AccountId");
			if (accountId == null) {
				return;
			}
			var activePartnership = FindActivePartnership(accountId);
			if (activePartnership == null) {
				return;
			}
			
			CertificateUtils.Actualize(UserConnection, activePartnership.GetTypedColumnValue<Guid>("Id"));
		}

		public virtual EntityCollection GetCertificationPartnershipParameters(Guid PartnershipId) {
			var certificationPartnershipParameterEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager,
				"PartnershipParameter");
			certificationPartnershipParameterEsq.AddAllSchemaColumns();
			certificationPartnershipParameterEsq.Filters.Add(
				certificationPartnershipParameterEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Partnership",
				PartnershipId));
				
			certificationPartnershipParameterEsq.Filters.Add(
				certificationPartnershipParameterEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "ParameterType",
				PRMBaseConstants.ObligationParameterTypeId));
				
			certificationPartnershipParameterEsq.Filters.Add(
				certificationPartnershipParameterEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"PartnershipParameterType",	PRMBaseConstants.CurrentPartnershipParamTypeId));
				
			certificationPartnershipParameterEsq.Filters.Add(
				certificationPartnershipParameterEsq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"PartnerParamCategory",	PRMBaseConstants.NumberOfCertifiedExpertsCategory));
			return certificationPartnershipParameterEsq.GetEntityCollection(UserConnection);
		}

		public virtual int GetCertifiedContactsCount(Guid AccountId) {
			Select countSelect = new Select(UserConnection).Column(Func.Count(Column.Const(1)))
					.From("Contact").As("C")
					.Where("AccountId").IsEqual(Column.Parameter(AccountId))
					.And().Exists(
						new Select(UserConnection).Column(Column.Const(1)).From("Certificate").Where("ContactId").IsEqual("C", "Id")
						.And("IssueDate").IsLessOrEqual(Column.Parameter(DateTime.UtcNow))
						.And("ExpireDate").IsGreaterOrEqual(Column.Parameter(DateTime.UtcNow)) as Select
					) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				return countSelect.ExecuteScalar<int>();
			}
		}

		#endregion

	}

	#endregion


	#region Class: EducationActivityEventsProcess

	/// <exclude/>
	public class EducationActivityEventsProcess : EducationActivity_PRMBaseEventsProcess
	{

		public EducationActivityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

