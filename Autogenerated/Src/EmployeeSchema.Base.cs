namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.EntitySynchronization;
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

	#region Class: EmployeeSchema

	/// <exclude/>
	public class EmployeeSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EmployeeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeSchema(EmployeeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeSchema(EmployeeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			RealUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			Name = "Employee";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
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
			if (Columns.FindByUId(new Guid("9b5d9ac5-c444-49fc-9249-fb8c2e542256")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("50fc7e29-dbfa-461e-8d12-fb7c04e3de23")) == null) {
				Columns.Add(CreateOrgStructureUnitColumn());
			}
			if (Columns.FindByUId(new Guid("a074483e-df7c-46eb-85c3-64aa4e13384e")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("f0ed710c-9196-41dc-93a2-2fcff481f430")) == null) {
				Columns.Add(CreateJobColumn());
			}
			if (Columns.FindByUId(new Guid("8ddae296-75c2-4304-9e81-6cbb5304f410")) == null) {
				Columns.Add(CreateFullJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("b211cbf0-f482-48f8-a34e-45010daefb3b")) == null) {
				Columns.Add(CreateOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("b168bc60-e4bf-4b5d-bdf6-6866f9bfa495")) == null) {
				Columns.Add(CreateCareerStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("35a0ed43-aeb6-4348-8fa2-cfdeee78aa30")) == null) {
				Columns.Add(CreateCareerDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("c9a68a88-aeb9-4597-a7a1-f4540ff4a15e")) == null) {
				Columns.Add(CreateProbationDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("af4c903a-ecd9-48f1-b3ed-a58f51cc39df")) == null) {
				Columns.Add(CreateReasonForDismissalColumn());
			}
			if (Columns.FindByUId(new Guid("9ed825a5-7740-4313-8a8a-cae3a08ed417")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("a18466a9-f823-4cb9-bf9c-31d8a6d3c18b")) == null) {
				Columns.Add(CreateManagerColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			column.CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9b5d9ac5-c444-49fc-9249-fb8c2e542256"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d19b709f-9a3e-49b6-9fb7-1cdd5082876e"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("aa5bcb67-9cba-4df2-8ba6-da13bd4b56f0"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateOrgStructureUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("50fc7e29-dbfa-461e-8d12-fb7c04e3de23"),
				Name = @"OrgStructureUnit",
				ReferenceSchemaUId = new Guid("92ac6269-362a-4cd2-9574-28f12be3ab78"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("a074483e-df7c-46eb-85c3-64aa4e13384e"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f0ed710c-9196-41dc-93a2-2fcff481f430"),
				Name = @"Job",
				ReferenceSchemaUId = new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateFullJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("8ddae296-75c2-4304-9e81-6cbb5304f410"),
				Name = @"FullJobTitle",
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b211cbf0-f482-48f8-a34e-45010daefb3b"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCareerStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("b168bc60-e4bf-4b5d-bdf6-6866f9bfa495"),
				Name = @"CareerStartDate",
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCareerDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("35a0ed43-aeb6-4348-8fa2-cfdeee78aa30"),
				Name = @"CareerDueDate",
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateProbationDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("c9a68a88-aeb9-4597-a7a1-f4540ff4a15e"),
				Name = @"ProbationDueDate",
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateReasonForDismissalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("af4c903a-ecd9-48f1-b3ed-a58f51cc39df"),
				Name = @"ReasonForDismissal",
				ReferenceSchemaUId = new Guid("acc6f535-717d-4cda-81e1-c4a3df4bec79"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ed825a5-7740-4313-8a8a-cae3a08ed417"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateManagerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a18466a9-f823-4cb9-bf9c-31d8a6d3c18b"),
				Name = @"Manager",
				ReferenceSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				ModifiedInSchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Employee(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Employee_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008"));
		}

		#endregion

	}

	#endregion

	#region Class: Employee

	/// <summary>
	/// Employee.
	/// </summary>
	public class Employee : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Employee(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Employee";
		}

		public Employee(Employee source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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

		/// <exclude/>
		public Guid OrgStructureUnitId {
			get {
				return GetTypedColumnValue<Guid>("OrgStructureUnitId");
			}
			set {
				SetColumnValue("OrgStructureUnitId", value);
				_orgStructureUnit = null;
			}
		}

		/// <exclude/>
		public string OrgStructureUnitName {
			get {
				return GetTypedColumnValue<string>("OrgStructureUnitName");
			}
			set {
				SetColumnValue("OrgStructureUnitName", value);
				if (_orgStructureUnit != null) {
					_orgStructureUnit.Name = value;
				}
			}
		}

		private OrgStructureUnit _orgStructureUnit;
		/// <summary>
		/// Organizational unit.
		/// </summary>
		public OrgStructureUnit OrgStructureUnit {
			get {
				return _orgStructureUnit ??
					(_orgStructureUnit = LookupColumnEntities.GetEntity("OrgStructureUnit") as OrgStructureUnit);
			}
		}

		/// <summary>
		/// Notes.
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
		public Guid JobId {
			get {
				return GetTypedColumnValue<Guid>("JobId");
			}
			set {
				SetColumnValue("JobId", value);
				_job = null;
			}
		}

		/// <exclude/>
		public string JobName {
			get {
				return GetTypedColumnValue<string>("JobName");
			}
			set {
				SetColumnValue("JobName", value);
				if (_job != null) {
					_job.Name = value;
				}
			}
		}

		private EmployeeJob _job;
		/// <summary>
		/// Job.
		/// </summary>
		public EmployeeJob Job {
			get {
				return _job ??
					(_job = LookupColumnEntities.GetEntity("Job") as EmployeeJob);
			}
		}

		/// <summary>
		/// Full job title.
		/// </summary>
		public string FullJobTitle {
			get {
				return GetTypedColumnValue<string>("FullJobTitle");
			}
			set {
				SetColumnValue("FullJobTitle", value);
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

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime CareerStartDate {
			get {
				return GetTypedColumnValue<DateTime>("CareerStartDate");
			}
			set {
				SetColumnValue("CareerStartDate", value);
			}
		}

		/// <summary>
		/// Due date.
		/// </summary>
		public DateTime CareerDueDate {
			get {
				return GetTypedColumnValue<DateTime>("CareerDueDate");
			}
			set {
				SetColumnValue("CareerDueDate", value);
			}
		}

		/// <summary>
		/// Probation ends.
		/// </summary>
		public DateTime ProbationDueDate {
			get {
				return GetTypedColumnValue<DateTime>("ProbationDueDate");
			}
			set {
				SetColumnValue("ProbationDueDate", value);
			}
		}

		/// <exclude/>
		public Guid ReasonForDismissalId {
			get {
				return GetTypedColumnValue<Guid>("ReasonForDismissalId");
			}
			set {
				SetColumnValue("ReasonForDismissalId", value);
				_reasonForDismissal = null;
			}
		}

		/// <exclude/>
		public string ReasonForDismissalName {
			get {
				return GetTypedColumnValue<string>("ReasonForDismissalName");
			}
			set {
				SetColumnValue("ReasonForDismissalName", value);
				if (_reasonForDismissal != null) {
					_reasonForDismissal.Name = value;
				}
			}
		}

		private ReasonForLeaving _reasonForDismissal;
		/// <summary>
		/// Reason for job change.
		/// </summary>
		public ReasonForLeaving ReasonForDismissal {
			get {
				return _reasonForDismissal ??
					(_reasonForDismissal = LookupColumnEntities.GetEntity("ReasonForDismissal") as ReasonForLeaving);
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
		/// Account.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid ManagerId {
			get {
				return GetTypedColumnValue<Guid>("ManagerId");
			}
			set {
				SetColumnValue("ManagerId", value);
				_manager = null;
			}
		}

		/// <exclude/>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
				if (_manager != null) {
					_manager.Name = value;
				}
			}
		}

		private Employee _manager;
		/// <summary>
		/// Manager.
		/// </summary>
		public Employee Manager {
			get {
				return _manager ??
					(_manager = LookupColumnEntities.GetEntity("Manager") as Employee);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Employee_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeDeleted", e);
			Inserted += (s, e) => ThrowEvent("EmployeeInserted", e);
			Inserting += (s, e) => ThrowEvent("EmployeeInserting", e);
			Saved += (s, e) => ThrowEvent("EmployeeSaved", e);
			Saving += (s, e) => ThrowEvent("EmployeeSaving", e);
			Updated += (s, e) => ThrowEvent("EmployeeUpdated", e);
			Validating += (s, e) => ThrowEvent("EmployeeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Employee(this);
		}

		#endregion

	}

	#endregion

	#region Class: Employee_BaseEventsProcess

	/// <exclude/>
	public partial class Employee_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Employee
	{

		public Employee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Employee_BaseEventsProcess";
			SchemaUId = new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb1c2bed-91d4-4b06-a28c-621a3d187008");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsAccountChanged {
			get;
			set;
		}

		public virtual bool IsCareerDueDateChanged {
			get;
			set;
		}

		public virtual bool IsEmployeeNameChanged {
			get;
			set;
		}

		public virtual bool IsCareerStartDateChanged {
			get;
			set;
		}

		private ProcessFlowElement _employeeUpdatedSubProcess;
		public ProcessFlowElement EmployeeUpdatedSubProcess {
			get {
				return _employeeUpdatedSubProcess ?? (_employeeUpdatedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmployeeUpdatedSubProcess",
					SchemaElementUId = new Guid("24042ed9-1a98-4d41-9e72-8b47609b1dcf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _employeeUpdatedMessage;
		public ProcessFlowElement EmployeeUpdatedMessage {
			get {
				return _employeeUpdatedMessage ?? (_employeeUpdatedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EmployeeUpdatedMessage",
					SchemaElementUId = new Guid("b4db5728-ee6d-4c2b-9759-1736f738affe"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeUpdatedScriptTask;
		public ProcessScriptTask EmployeeUpdatedScriptTask {
			get {
				return _employeeUpdatedScriptTask ?? (_employeeUpdatedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeUpdatedScriptTask",
					SchemaElementUId = new Guid("59770401-a81c-41f6-9f11-1b72bfaec601"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeUpdatedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _employeeInsertedSubProcess;
		public ProcessFlowElement EmployeeInsertedSubProcess {
			get {
				return _employeeInsertedSubProcess ?? (_employeeInsertedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EmployeeInsertedSubProcess",
					SchemaElementUId = new Guid("77b58dff-b49d-492f-ada9-0db6964c7ce9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _insertedMessage;
		public ProcessFlowElement InsertedMessage {
			get {
				return _insertedMessage ?? (_insertedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InsertedMessage",
					SchemaElementUId = new Guid("86080eb7-fb0f-461f-b472-9ae97da2589e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeInsertedScriptTask;
		public ProcessScriptTask EmployeeInsertedScriptTask {
			get {
				return _employeeInsertedScriptTask ?? (_employeeInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeInsertedScriptTask",
					SchemaElementUId = new Guid("b8d81135-ee09-41a5-886d-48996bee9547"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeInsertedScriptTaskExecute,
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
					SchemaElementUId = new Guid("12f21f67-ecda-43eb-bd29-888121ec565f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _employeeSavedScriptTask;
		public ProcessScriptTask EmployeeSavedScriptTask {
			get {
				return _employeeSavedScriptTask ?? (_employeeSavedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "EmployeeSavedScriptTask",
					SchemaElementUId = new Guid("5d739ea1-5f61-4558-aabb-f74d4facd4bf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = EmployeeSavedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _savedMessage;
		public ProcessFlowElement SavedMessage {
			get {
				return _savedMessage ?? (_savedMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SavedMessage",
					SchemaElementUId = new Guid("e7fa5bf7-a717-4805-86bd-9b31b885c515"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("462b12fa-e94c-4a14-acc7-04473ebe21f5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _savingMessage;
		public ProcessFlowElement SavingMessage {
			get {
				return _savingMessage ?? (_savingMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SavingMessage",
					SchemaElementUId = new Guid("a4f9de50-1b04-4fc6-8cd9-c63717912a2f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _savingScriptTask;
		public ProcessScriptTask SavingScriptTask {
			get {
				return _savingScriptTask ?? (_savingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SavingScriptTask",
					SchemaElementUId = new Guid("4a800588-65bf-4f22-991f-5214ce4a27b7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EmployeeUpdatedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeUpdatedSubProcess };
			FlowElements[EmployeeUpdatedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeUpdatedMessage };
			FlowElements[EmployeeUpdatedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeUpdatedScriptTask };
			FlowElements[EmployeeInsertedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeInsertedSubProcess };
			FlowElements[InsertedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { InsertedMessage };
			FlowElements[EmployeeInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeInsertedScriptTask };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[EmployeeSavedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { EmployeeSavedScriptTask };
			FlowElements[SavedMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SavedMessage };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SavingMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SavingMessage };
			FlowElements[SavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { SavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EmployeeUpdatedSubProcess":
						break;
					case "EmployeeUpdatedMessage":
						e.Context.QueueTasks.Enqueue("EmployeeUpdatedScriptTask");
						break;
					case "EmployeeUpdatedScriptTask":
						break;
					case "EmployeeInsertedSubProcess":
						break;
					case "InsertedMessage":
						e.Context.QueueTasks.Enqueue("EmployeeInsertedScriptTask");
						break;
					case "EmployeeInsertedScriptTask":
						break;
					case "EventSubProcess1":
						break;
					case "EmployeeSavedScriptTask":
						break;
					case "SavedMessage":
						e.Context.QueueTasks.Enqueue("EmployeeSavedScriptTask");
						break;
					case "EventSubProcess2":
						break;
					case "SavingMessage":
						e.Context.QueueTasks.Enqueue("SavingScriptTask");
						break;
					case "SavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EmployeeUpdatedMessage");
			ActivatedEventElements.Add("InsertedMessage");
			ActivatedEventElements.Add("SavedMessage");
			ActivatedEventElements.Add("SavingMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EmployeeUpdatedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "EmployeeUpdatedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeUpdatedMessage";
					result = EmployeeUpdatedMessage.Execute(context);
					break;
				case "EmployeeUpdatedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeUpdatedScriptTask";
					result = EmployeeUpdatedScriptTask.Execute(context, EmployeeUpdatedScriptTaskExecute);
					break;
				case "EmployeeInsertedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "InsertedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "InsertedMessage";
					result = InsertedMessage.Execute(context);
					break;
				case "EmployeeInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeInsertedScriptTask";
					result = EmployeeInsertedScriptTask.Execute(context, EmployeeInsertedScriptTaskExecute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "EmployeeSavedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "EmployeeSavedScriptTask";
					result = EmployeeSavedScriptTask.Execute(context, EmployeeSavedScriptTaskExecute);
					break;
				case "SavedMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SavedMessage";
					result = SavedMessage.Execute(context);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SavingMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SavingMessage";
					result = SavingMessage.Execute(context);
					break;
				case "SavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "SavingScriptTask";
					result = SavingScriptTask.Execute(context, SavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool EmployeeUpdatedScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeUpdated();
			return true;
		}

		public virtual bool EmployeeInsertedScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeInserted();
			return true;
		}

		public virtual bool EmployeeSavedScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeSaved();
			return true;
		}

		public virtual bool SavingScriptTaskExecute(ProcessExecutingContext context) {
			OnEmployeeSaving();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "EmployeeUpdated":
							if (ActivatedEventElements.Contains("EmployeeUpdatedMessage")) {
							context.QueueTasks.Enqueue("EmployeeUpdatedMessage");
						}
						break;
					case "EmployeeInserted":
							if (ActivatedEventElements.Contains("InsertedMessage")) {
							context.QueueTasks.Enqueue("InsertedMessage");
						}
						break;
					case "EmployeeSaved":
							if (ActivatedEventElements.Contains("SavedMessage")) {
							context.QueueTasks.Enqueue("SavedMessage");
						}
						break;
					case "EmployeeSaving":
							if (ActivatedEventElements.Contains("SavingMessage")) {
							context.QueueTasks.Enqueue("SavingMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Employee_BaseEventsProcess

	/// <exclude/>
	public class Employee_BaseEventsProcess : Employee_BaseEventsProcess<Employee>
	{

		public Employee_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Employee_BaseEventsProcess

	public partial class Employee_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void OnEmployeeUpdated() {
			if (!GetIsCareerInformationEmpty()) {
				if (GetIsCareerColumnsChanged()) {
					SynchronizeEmployeeAndEmployeeCareer();
				}
			}
		}

		public virtual void OnEmployeeInserted() {
			if (!GetIsCareerInformationEmpty()) {
				IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
				Entity employeeCareer = provider.CreateEntity("EmployeeCareer");
				IColumnValuesSynchronizer synchronizer = CreateColumnValuesSynchronizer();
				ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
				synchronizer.FillDestinationEntity(Entity, employeeCareer, columnMappings);
				employeeCareer.SetColumnValue("IsCurrent", GetEmployeeIsCurrent());
				employeeCareer.SetColumnValue("EmployeeId", Entity.PrimaryColumnValue);
			        var isNeedToCheckRequiredFields = GetIsNeedToCheckRequiredFields();
				employeeCareer.Save(isNeedToCheckRequiredFields);
			}
		}

		public virtual IEntitySynchronizationProvider CreateEntitySynchronizationProvider() {
			return ClassFactory.Get<EntitySynchronizationProvider>(new ConstructorArgument("userConnection", UserConnection));
		}

		public virtual IColumnValuesSynchronizer CreateColumnValuesSynchronizer() {
			return ClassFactory.Get<ColumnValuesSynchronizer>();
		}

		public virtual ICollection<SynchronizationColumnMapping> GetSynchronizationColumnMappings() {
			IEqualComparatorProvider provider = CreateEqualComparatorProvider();
			SynchronizationColumnComparator dateEqualComparator = provider.GetDateEqualComparator();
			SynchronizationColumnComparator stringEqualComparator = provider.GetStringEqualComparator();
			return new List<SynchronizationColumnMapping> {
				new SynchronizationColumnMapping {
					SourceColumnName = "AccountId",
					DestinationColumnName = "AccountId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "OrgStructureUnitId",
					DestinationColumnName = "OrgStructureUnitId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "JobId",
					DestinationColumnName = "EmployeeJobId"
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "FullJobTitle",
					DestinationColumnName = "FullJobTitle",
					Comparator = stringEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "CareerStartDate",
					DestinationColumnName = "StartDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "CareerDueDate",
					DestinationColumnName = "DueDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "ProbationDueDate",
					DestinationColumnName = "ProbationDueDate",
					Comparator = dateEqualComparator
				},
				new SynchronizationColumnMapping {
					SourceColumnName = "ReasonForDismissalId",
					DestinationColumnName = "ReasonForDismissalId"
				}
			};
		}

		public virtual void SynchronizeEmployeeAndEmployeeCareer() {
			IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
			IColumnValuesSynchronizer synchronizer = CreateColumnValuesSynchronizer();
			ICollection<SynchronizationColumnMapping> columnMappings = GetSynchronizationColumnMappings();
			Entity employeeCareer = provider.FindEntity("EmployeeCareer", new Dictionary<string, object> {
				{"Employee", Entity.PrimaryColumnValue},
				{"IsCurrent", true}
			});
			if (employeeCareer == null) {
				employeeCareer = GetLastModifiedCareer();
				if (employeeCareer == null) {
					employeeCareer = provider.CreateEntity("EmployeeCareer");
					employeeCareer.SetColumnValue("EmployeeId", Entity.PrimaryColumnValue);
				}
				synchronizer.FillDestinationEntity(Entity, employeeCareer, columnMappings);
			} else {
				synchronizer.SynchronizeEntities(Entity, employeeCareer, columnMappings);
			}
			employeeCareer.SetColumnValue("IsCurrent", GetEmployeeIsCurrent());
			var isNeedToCheckRequiredFields = GetIsNeedToCheckRequiredFields();
			employeeCareer.Save(isNeedToCheckRequiredFields);
		}

		public virtual Entity GetLastModifiedCareer() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmployeeCareer");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddAllSchemaColumns(true);
			esq.AddColumn("ModifiedOn").OrderByDesc();
			IEntitySchemaQueryFilterItem employeeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Employee", Entity.PrimaryColumnValue);
			esq.Filters.Add(employeeFilter);
			EntityCollection careers = esq.GetEntityCollection(UserConnection);
			return careers.FirstOrDefault();
		}

		public virtual bool GetIsCareerInformationEmpty() {
			string[] observalColumns = GetSynchronizationColumnMappings().Select(cm => cm.SourceColumnName).ToArray();
			var nullable = observalColumns.Where(s => Entity.GetColumnValue(s) == null);
			return nullable.Count() == observalColumns.Length;
		}

		public virtual bool GetIsCareerColumnsChanged() {
			string[] observalColumns = GetSynchronizationColumnMappings().Select(cm => cm.SourceColumnName).ToArray();
			return Entity.GetChangedColumnValues().Select(c => c.Name).Intersect(observalColumns).Any();
		}

		public virtual bool GetIsCareerDueDateFilled() {
			return Entity.GetColumnValue("CareerDueDate") != null;
		}

		public virtual IEqualComparatorProvider CreateEqualComparatorProvider() {
			return ClassFactory.Get<EqualComparatorProvider>();
		}

		public virtual void OnEmployeeSaved() {
			SynchronizeContactAndEmployeeName();
			SynchronizeContactCareer();
		}

		public virtual bool GetIsAccountChanged() {
			return Entity.GetChangedColumnValues().Any(cv => cv.Name == "AccountId");
		}

		public virtual void OnEmployeeSaving() {
			IsAccountChanged = GetIsAccountChanged();
			IsCareerDueDateChanged = GetIsCareerDueDateChanged();
			IsEmployeeNameChanged = GetIsEmployeeNameChanged();
			IsCareerStartDateChanged = GetIsCareerStartDateChanged();
			var careerStartDate = Entity.GetColumnValue("CareerStartDate");
			if ((IsAccountChanged || IsCareerDueDateChanged) && careerStartDate == null && !IsCareerStartDateChanged) {
				Entity.SetColumnValue("CareerStartDate", UserConnection.CurrentUser.GetCurrentDateTime());
			}
		}

		public virtual bool GetIsCareerDueDateChanged() {
			return Entity.GetChangedColumnValues().Any(cv => cv.Name == "CareerDueDate");
		}

		public virtual void SynchronizeContactAndEmployeeName() {
			var contactId = Entity.GetColumnValue("ContactId");
			if (IsEmployeeNameChanged && contactId != null) {
				IColumnValuesSynchronizer synchronizer = CreateColumnValuesSynchronizer();
				ICollection<SynchronizationColumnMapping> columnMappings = new List<SynchronizationColumnMapping> {
					new SynchronizationColumnMapping {
						SourceColumnName = "Name",
						DestinationColumnName = "Name"
					}
				};
				IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
				Entity contact = provider.FindEntity("Contact", new Dictionary<string, object> {
					{"Id", contactId}
				});
				synchronizer.SynchronizeEntities(Entity, contact, columnMappings);
				contact.Save();
			}
		}

		public virtual bool GetIsEmployeeNameChanged() {
			return Entity.GetChangedColumnValues().Any(cv => cv.Name == "Name");
		}

		public virtual void SynchronizeContactCareer() {
			if (IsAccountChanged || IsCareerDueDateChanged) {
				var careerDueDate = Entity.GetColumnValue("CareerDueDate");
				var employeeAccountId = Entity.GetColumnValue("AccountId");
				Guid employeeAccountOldId = Entity.GetTypedOldColumnValue<Guid>("AccountId");
				IEntitySynchronizationProvider provider = CreateEntitySynchronizationProvider();
				Entity contact = provider.FindEntity("Contact", new Dictionary<string, object> {
					{"Id", Entity.GetColumnValue("ContactId")}
				});
				Guid contactAccountId = contact.GetTypedColumnValue<Guid>("AccountId");
				if (careerDueDate != null) {
					contact.SetColumnValue("AccountId", null);
					contact.Save();
				}
				if (!contactAccountId.Equals(employeeAccountId)) {
					contact.SetColumnValue("AccountId", employeeAccountId);
					contact.Save();
				}
				Guid contactCareerAccountId = (employeeAccountId != null)
					? (Guid)employeeAccountId
					: employeeAccountOldId;
				Entity contactCareer = provider.FindEntity("ContactCareer", new Dictionary<string, object> {
					{"Contact", contact.PrimaryColumnValue},
					{"Account", contactCareerAccountId}
				}, new Dictionary<string, OrderDirection> {
					{"ModifiedOn", OrderDirection.Descending}
				});
				if (contactCareer != null) {
					var careerStartDate = Entity.GetColumnValue("CareerStartDate");
					contactCareer.SetColumnValue("StartDate", careerStartDate);
					contactCareer.SetColumnValue("DueDate", careerDueDate);
					contactCareer.Save();
				}
			}
		}

		public virtual bool GetIsCareerStartDateChanged() {
			return Entity.GetChangedColumnValues().Any(cv => cv.Name == "CareerStartDate");
		}

		public virtual bool GetEmployeeIsCurrent() {
			return !GetIsCareerDueDateFilled();
		}

		public virtual bool GetIsNeedToCheckRequiredFields() {
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: EmployeeEventsProcess

	/// <exclude/>
	public class EmployeeEventsProcess : Employee_BaseEventsProcess
	{

		public EmployeeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

