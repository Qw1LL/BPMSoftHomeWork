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

	#region Class: Document_Document_BPMSoftSchema

	/// <exclude/>
	public class Document_Document_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Document_Document_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Document_Document_BPMSoftSchema(Document_Document_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Document_Document_BPMSoftSchema(Document_Document_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			RealUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			Name = "Document_Document_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("964aedc1-7673-4d96-8b3f-8bc8f2829fff")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("923d55f5-b690-46ae-9337-0400d63814d1")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6f97a26f-a592-40f0-a233-d4363a35f471")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("cf24fdae-dd9e-43d8-a5d6-47b6fd9e4daa")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("3a5ca495-43bc-4b03-af8a-c297f9166fd0")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("e2596e4a-8da7-47f5-9898-e6cce28fc2f8")) == null) {
				Columns.Add(CreatePaymentAmountColumn());
			}
			if (Columns.FindByUId(new Guid("570b8a4d-9d3e-49b6-8e71-a77e27b2dad3")) == null) {
				Columns.Add(CreatePrimaryPaymentAmountColumn());
			}
			if (Columns.FindByUId(new Guid("03791254-7218-4176-8e38-7c053da06e40")) == null) {
				Columns.Add(CreatePaymentDateColumn());
			}
			if (Columns.FindByUId(new Guid("b02642bd-8ec6-45af-9998-ea803ca5c9c3")) == null) {
				Columns.Add(CreateStateColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.IsTrackChangesInDB = true;
			column.ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("927e4338-f861-42c1-8b0b-7bbb78ffff4b"),
				Name = @"Number",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("964aedc1-7673-4d96-8b3f-8bc8f2829fff"),
				Name = @"Date",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true,
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("923d55f5-b690-46ae-9337-0400d63814d1"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("fe5e6306-c1ae-454f-87fb-108461dd71f5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6f97a26f-a592-40f0-a233-d4363a35f471"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf24fdae-dd9e-43d8-a5d6-47b6fd9e4daa"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsTrackChangesInDB = true
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f214196-e457-4163-90b3-3b397961215c"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3a5ca495-43bc-4b03-af8a-c297f9166fd0"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("e2596e4a-8da7-47f5-9898-e6cce28fc2f8"),
				Name = @"PaymentAmount",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("648f05a8-9401-440d-98ee-c77984ac3b4b")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPaymentAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("570b8a4d-9d3e-49b6-8e71-a77e27b2dad3"),
				Name = @"PrimaryPaymentAmount",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("648f05a8-9401-440d-98ee-c77984ac3b4b")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("03791254-7218-4176-8e38-7c053da06e40"),
				Name = @"PaymentDate",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("648f05a8-9401-440d-98ee-c77984ac3b4b")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b02642bd-8ec6-45af-9998-ea803ca5c9c3"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("3fa49baa-57d4-40d7-9293-1e6742b1b0dd"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				ModifiedInSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				CreatedInPackageId = new Guid("93f2b0e4-b421-42dc-86e5-35e5b932239c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"2144d9a6-b446-4afd-a52d-41f1b1910546"
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
			return new Document_Document_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Document_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Document_Document_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Document_Document_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"));
		}

		#endregion

	}

	#endregion

	#region Class: Document_Document_BPMSoft

	/// <summary>
	/// Документ.
	/// </summary>
	public class Document_Document_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Document_Document_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Document_Document_BPMSoft";
		}

		public Document_Document_BPMSoft(Document_Document_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		private DocumentType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public DocumentType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as DocumentType);
			}
		}

		/// <exclude/>
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
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

		/// <summary>
		/// Сумма оплаты.
		/// </summary>
		public Decimal PaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PaymentAmount");
			}
			set {
				SetColumnValue("PaymentAmount", value);
			}
		}

		/// <summary>
		/// Сумма оплаты, б.в.
		/// </summary>
		public Decimal PrimaryPaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPaymentAmount");
			}
			set {
				SetColumnValue("PrimaryPaymentAmount", value);
			}
		}

		/// <summary>
		/// Дата оплаты.
		/// </summary>
		public DateTime PaymentDate {
			get {
				return GetTypedColumnValue<DateTime>("PaymentDate");
			}
			set {
				SetColumnValue("PaymentDate", value);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private DocumentState _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public DocumentState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as DocumentState);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Document_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Document_Document_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Document_Document_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Document_Document_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Document_Document_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Document_Document_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Document_Document_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Document_Document_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Document_Document_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentEventsProcess

	/// <exclude/>
	public partial class Document_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Document_Document_BPMSoft
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Document_DocumentEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("bb924708-fdf2-4864-a070-ef328b4eba6e");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Document_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Document_DocumentEventsProcess";
			SchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsNew {
			get;
			set;
		}

		public virtual bool NeedFinRecalc {
			get;
			set;
		}

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("29ab6612-b1bd-4d61-953e-a377f6471c01"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _documentSaved;
		public ProcessFlowElement DocumentSaved {
			get {
				return _documentSaved ?? (_documentSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentSaved",
					SchemaElementUId = new Guid("5e4fc7be-dce7-4805-9a0c-ccb83a6b422f"),
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
					SchemaElementUId = new Guid("959d55af-d85a-46d3-83e5-d7f54cfbffcc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGenerateParamScriptExecute,
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
					SchemaElementUId = new Guid("09ecf56e-5ce5-4794-895e-e95971f31de6"),
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

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
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
					SchemaElementUId = new Guid("a4b2d458-95cb-48fd-998f-2386b064b78f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGeneratedNumberScriptExecute,
				});
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("fd6d7db4-299c-4fdf-9124-9108834f34bf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _changeRightsScriptTask;
		public ProcessScriptTask ChangeRightsScriptTask {
			get {
				return _changeRightsScriptTask ?? (_changeRightsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ChangeRightsScriptTask",
					SchemaElementUId = new Guid("bd556e16-5646-48ab-af01-3f6e4efbacd7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ChangeRightsScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _financeRecalculationScriptTask;
		public ProcessScriptTask FinanceRecalculationScriptTask {
			get {
				return _financeRecalculationScriptTask ?? (_financeRecalculationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FinanceRecalculationScriptTask",
					SchemaElementUId = new Guid("faf5856b-ebb1-473d-a2ef-bf0805288e6e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = FinanceRecalculationScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcessDocumentSaving;
		public ProcessFlowElement EventSubProcessDocumentSaving {
			get {
				return _eventSubProcessDocumentSaving ?? (_eventSubProcessDocumentSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessDocumentSaving",
					SchemaElementUId = new Guid("95eea31a-db9c-433a-b136-7c5b5dc41f46"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _documentSaving;
		public ProcessFlowElement DocumentSaving {
			get {
				return _documentSaving ?? (_documentSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentSaving",
					SchemaElementUId = new Guid("532a7731-ee3a-456f-a96f-d01f310467ba"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptDocumentSaving;
		public ProcessScriptTask ScriptDocumentSaving {
			get {
				return _scriptDocumentSaving ?? (_scriptDocumentSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptDocumentSaving",
					SchemaElementUId = new Guid("303ec553-1575-4a73-86c2-67e615c148f4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptDocumentSavingExecute,
				});
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
					SchemaElementUId = new Guid("65d38b9c-13f0-42ac-af9b-b0f7a714c9ed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage1DocumentDeleting;
		public ProcessFlowElement StartMessage1DocumentDeleting {
			get {
				return _startMessage1DocumentDeleting ?? (_startMessage1DocumentDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1DocumentDeleting",
					SchemaElementUId = new Guid("af09f93a-a018-47a2-a34b-057237316bc2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _documentDeletingScriptTask;
		public ProcessScriptTask DocumentDeletingScriptTask {
			get {
				return _documentDeletingScriptTask ?? (_documentDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DocumentDeletingScriptTask",
					SchemaElementUId = new Guid("178bd67b-1f83-44df-ad20-ce8d70425680"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DocumentDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("945c922f-6ce6-4766-8fc7-c20e7120b611"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _documentInsertedScriptTask;
		public ProcessScriptTask DocumentInsertedScriptTask {
			get {
				return _documentInsertedScriptTask ?? (_documentInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "DocumentInsertedScriptTask",
					SchemaElementUId = new Guid("880ea32c-dd15-4516-8be3-d8464b1caa25"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = DocumentInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _documentInsertedStartMessage;
		public ProcessFlowElement DocumentInsertedStartMessage {
			get {
				return _documentInsertedStartMessage ?? (_documentInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "DocumentInsertedStartMessage",
					SchemaElementUId = new Guid("970007fc-ed3e-48fc-9837-5a0812a2eb2d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
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
					SchemaElementUId = new Guid("c0b177ac-b0fa-4fba-ac7d-b5ed41db73c1"),
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
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[DocumentSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentSaved };
			FlowElements[SetGenerateParamScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGenerateParamScript };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[SetGeneratedNumberScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGeneratedNumberScript };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[ChangeRightsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ChangeRightsScriptTask };
			FlowElements[FinanceRecalculationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FinanceRecalculationScriptTask };
			FlowElements[EventSubProcessDocumentSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessDocumentSaving };
			FlowElements[DocumentSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentSaving };
			FlowElements[ScriptDocumentSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptDocumentSaving };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[StartMessage1DocumentDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1DocumentDeleting };
			FlowElements[DocumentDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentDeletingScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[DocumentInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentInsertedScriptTask };
			FlowElements[DocumentInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { DocumentInsertedStartMessage };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcess1":
						break;
					case "DocumentSaved":
						e.Context.QueueTasks.Enqueue("SetGenerateParamScript");
						e.Context.QueueTasks.Enqueue("ChangeRightsScriptTask");
						e.Context.QueueTasks.Enqueue("FinanceRecalculationScriptTask");
						break;
					case "SetGenerateParamScript":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("End1");
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("SetGeneratedNumberScript");
						break;
					case "SetGeneratedNumberScript":
						break;
					case "End1":
						break;
					case "ChangeRightsScriptTask":
						break;
					case "FinanceRecalculationScriptTask":
						break;
					case "EventSubProcessDocumentSaving":
						break;
					case "DocumentSaving":
						e.Context.QueueTasks.Enqueue("ScriptDocumentSaving");
						break;
					case "ScriptDocumentSaving":
						break;
					case "EventSubProcess1":
						break;
					case "StartMessage1DocumentDeleting":
						e.Context.QueueTasks.Enqueue("DocumentDeletingScriptTask");
						break;
					case "DocumentDeletingScriptTask":
						break;
					case "EventSubProcess2":
						break;
					case "DocumentInsertedScriptTask":
						break;
					case "DocumentInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("DocumentInsertedScriptTask");
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
			ActivatedEventElements.Add("DocumentSaved");
			ActivatedEventElements.Add("DocumentSaving");
			ActivatedEventElements.Add("StartMessage1DocumentDeleting");
			ActivatedEventElements.Add("DocumentInsertedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "DocumentSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentSaved";
					result = DocumentSaved.Execute(context);
					break;
				case "SetGenerateParamScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGenerateParamScript";
					result = SetGenerateParamScript.Execute(context, SetGenerateParamScriptExecute);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "SetGeneratedNumberScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGeneratedNumberScript";
					result = SetGeneratedNumberScript.Execute(context, SetGeneratedNumberScriptExecute);
					break;
				case "End1":
					context.QueueTasks.Dequeue();
					break;
				case "ChangeRightsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ChangeRightsScriptTask";
					result = ChangeRightsScriptTask.Execute(context, ChangeRightsScriptTaskExecute);
					break;
				case "FinanceRecalculationScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "FinanceRecalculationScriptTask";
					result = FinanceRecalculationScriptTask.Execute(context, FinanceRecalculationScriptTaskExecute);
					break;
				case "EventSubProcessDocumentSaving":
					context.QueueTasks.Dequeue();
					break;
				case "DocumentSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentSaving";
					result = DocumentSaving.Execute(context);
					break;
				case "ScriptDocumentSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptDocumentSaving";
					result = ScriptDocumentSaving.Execute(context, ScriptDocumentSavingExecute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage1DocumentDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1DocumentDeleting";
					result = StartMessage1DocumentDeleting.Execute(context);
					break;
				case "DocumentDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentDeletingScriptTask";
					result = DocumentDeletingScriptTask.Execute(context, DocumentDeletingScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "DocumentInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentInsertedScriptTask";
					result = DocumentInsertedScriptTask.Execute(context, DocumentInsertedScriptTaskExecute);
					break;
				case "DocumentInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "DocumentInsertedStartMessage";
					result = DocumentInsertedStartMessage.Execute(context);
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

		public virtual bool ChangeRightsScriptTaskExecute(ProcessExecutingContext context) {
			var ownerId = Entity.GetTypedColumnValue<Guid>("OwnerId");
			var oldOwnerId = Entity.GetTypedOldColumnValue<Guid>("OwnerId");
			if (ownerId != oldOwnerId) {
				if (ownerId != Guid.Empty && ownerId != UserConnection.CurrentUser.ContactId) {
					//AddWrightRights(ownerId);
				}
				if (oldOwnerId != Guid.Empty && oldOwnerId != UserConnection.CurrentUser.ContactId) {
					//RemoveWrightRights(oldOwnerId);
				}
			}
			return true;
		}

		public virtual bool FinanceRecalculationScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool ScriptDocumentSavingExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool DocumentDeletingScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool DocumentInsertedScriptTaskExecute(ProcessExecutingContext context) {
			IsNew = true;
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Document_Document_BPMSoftSaved":
							if (ActivatedEventElements.Contains("DocumentSaved")) {
							context.QueueTasks.Enqueue("DocumentSaved");
						}
						break;
					case "Document_Document_BPMSoftSaving":
							if (ActivatedEventElements.Contains("DocumentSaving")) {
							context.QueueTasks.Enqueue("DocumentSaving");
						}
						break;
					case "Document_Document_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("StartMessage1DocumentDeleting")) {
							context.QueueTasks.Enqueue("StartMessage1DocumentDeleting");
						}
						break;
					case "Document_Document_BPMSoftInserted":
							if (ActivatedEventElements.Contains("DocumentInsertedStartMessage")) {
							context.QueueTasks.Enqueue("DocumentInsertedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Document_DocumentEventsProcess

	/// <exclude/>
	public class Document_DocumentEventsProcess : Document_DocumentEventsProcess<Document_Document_BPMSoft>
	{

		public Document_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Document_DocumentEventsProcess

	public partial class Document_DocumentEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual decimal Multiply(decimal arg1, decimal arg2) {
			return Math.Round(arg1 * arg2,2);
		}

		public virtual decimal Division(decimal arg1, decimal arg2) {
			decimal result = 0;
			if(arg2 > 0){
				result = Math.Round(arg1 / arg2, 2);
			}
			return result;
		}

		public virtual void AddWrightRights(Guid documentOwnerId) {
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			var sysAdminUnitESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var primaryColumn = sysAdminUnitESQ.AddColumn(sysAdminUnitESQ.RootSchema.GetPrimaryColumnName()); 
			sysAdminUnitESQ.Filters.Add(sysAdminUnitESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", documentOwnerId));
			var sysAdminUnits = sysAdminUnitESQ.GetEntityCollection(UserConnection);
			if (sysAdminUnits.Count > 0) {
				var adminUnitId = Guid.Empty;
				foreach (var sysAdminUnit in sysAdminUnits) {
					adminUnitId = sysAdminUnit.GetTypedColumnValue<Guid>(primaryColumn.Name);
					if (dbSecurityEngine.GetIsEntitySchemaAdministratedByRecords("Document")) {
						dbSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name, Entity.PrimaryColumnValue,
								EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightLevel.AllowAndGrant, Guid.Empty, true);
						dbSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name, Entity.PrimaryColumnValue,
								EntitySchemaRecordRightOperation.Edit, EntitySchemaRecordRightLevel.AllowAndGrant, Guid.Empty, true);
					}
				}
			}
			
		}

		public virtual void RemoveWrightRights(Guid documentOwnerId) {
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			var sysAdminUnitESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var primaryColumn = sysAdminUnitESQ.AddColumn(sysAdminUnitESQ.RootSchema.GetPrimaryColumnName()); 
			sysAdminUnitESQ.Filters.Add(sysAdminUnitESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", documentOwnerId));
			var sysAdminUnits = sysAdminUnitESQ.GetEntityCollection(UserConnection);
			if (sysAdminUnits.Count > 0) {
				var adminUnitId = Guid.Empty;
				foreach (var sysAdminUnit in sysAdminUnits) {
					adminUnitId = sysAdminUnit.GetTypedColumnValue<Guid>(primaryColumn.Name);
					if (UserConnection.DBSecurityEngine.GetIsEntitySchemaAdministratedByRecords("Document")) {
						UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(adminUnitId, Entity.Schema.Name, Entity.PrimaryColumnValue,
										EntitySchemaRecordRightOperation.Edit, EntitySchemaRecordRightLevel.Deny, Guid.Empty, true);
					}
				}
			}
		}

		#endregion

	}

	#endregion

}

