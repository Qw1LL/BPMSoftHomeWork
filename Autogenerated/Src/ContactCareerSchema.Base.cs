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

	#region Class: ContactCareer_Base_BPMSoftSchema

	/// <exclude/>
	public class ContactCareer_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContactCareer_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactCareer_Base_BPMSoftSchema(ContactCareer_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactCareer_Base_BPMSoftSchema(ContactCareer_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateI74adXnmFiCFKGusIbN0Dbj6qLecIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("17cb5432-9f78-4115-a8c8-643ca03dac9c");
			index.Name = "I74adXnmFiCFKGusIbN0Dbj6qLec";
			index.CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			index.ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn contactIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("05f34390-f7ed-41ff-87b8-8ebf2e779d42"),
				ColumnUId = new Guid("d6628cf3-ba29-472e-b0f2-9b51f693ef2a"),
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(contactIdIndexColumn);
			EntitySchemaIndexColumn accountIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("a9d46f67-ad38-46bc-b369-368490bc8e24"),
				ColumnUId = new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854"),
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(accountIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			RealUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			Name = "ContactCareer_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d6628cf3-ba29-472e-b0f2-9b51f693ef2a")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("96d86ec7-b8fd-4288-8cc4-c5d6ca4fe46d")) == null) {
				Columns.Add(CreateDepartmentColumn());
			}
			if (Columns.FindByUId(new Guid("bf823e82-f89d-4345-b839-c429dcb2baac")) == null) {
				Columns.Add(CreateJobColumn());
			}
			if (Columns.FindByUId(new Guid("5439cefd-5021-4446-957b-f35eebe76b40")) == null) {
				Columns.Add(CreateJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("131fa275-a32c-4af9-92f0-cfedcad3679c")) == null) {
				Columns.Add(CreatePrimaryColumn());
			}
			if (Columns.FindByUId(new Guid("e370b11e-e44a-4ccb-90ed-9f0f2a455adb")) == null) {
				Columns.Add(CreateCurrentColumn());
			}
			if (Columns.FindByUId(new Guid("9e1f23da-a77e-4798-99a1-413a7a4b8aa6")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("84b66f84-08ea-4059-b18f-d5132df7df06")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("655e9fb9-fb88-42b7-b437-ef7bf7ef4766")) == null) {
				Columns.Add(CreateJobChangeReasonColumn());
			}
			if (Columns.FindByUId(new Guid("4e537940-3c92-48ee-a935-570176f0abde")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("6324d7f3-fd46-4046-b9c3-76844a3e88a6")) == null) {
				Columns.Add(CreateDecisionRoleColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d6628cf3-ba29-472e-b0f2-9b51f693ef2a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateDepartmentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("96d86ec7-b8fd-4288-8cc4-c5d6ca4fe46d"),
				Name = @"Department",
				ReferenceSchemaUId = new Guid("7a269220-a657-4b5f-bfb4-ebe596e419d8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateJobColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bf823e82-f89d-4345-b839-c429dcb2baac"),
				Name = @"Job",
				ReferenceSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5439cefd-5021-4446-957b-f35eebe76b40"),
				Name = @"JobTitle",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("131fa275-a32c-4af9-92f0-cfedcad3679c"),
				Name = @"Primary",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("e370b11e-e44a-4ccb-90ed-9f0f2a455adb"),
				Name = @"Current",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("9e1f23da-a77e-4798-99a1-413a7a4b8aa6"),
				Name = @"StartDate",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("84b66f84-08ea-4059-b18f-d5132df7df06"),
				Name = @"DueDate",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateJobChangeReasonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("655e9fb9-fb88-42b7-b437-ef7bf7ef4766"),
				Name = @"JobChangeReason",
				ReferenceSchemaUId = new Guid("91d12da5-4a3b-4a57-ac8c-17abda1d115e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4e537940-3c92-48ee-a935-570176f0abde"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected virtual EntitySchemaColumn CreateDecisionRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6324d7f3-fd46-4046-b9c3-76844a3e88a6"),
				Name = @"DecisionRole",
				ReferenceSchemaUId = new Guid("54aa771f-fba6-4d76-9239-bff3f00ee3e5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				ModifiedInSchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"),
				CreatedInPackageId = new Guid("ec420ba8-5f6d-485d-8dc2-eb22e0b326a8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateI74adXnmFiCFKGusIbN0Dbj6qLecIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContactCareer_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactCareer_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactCareer_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactCareer_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactCareer_Base_BPMSoft

	/// <summary>
	/// Job experience of contact.
	/// </summary>
	public class ContactCareer_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContactCareer_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactCareer_Base_BPMSoft";
		}

		public ContactCareer_Base_BPMSoft(ContactCareer_Base_BPMSoft source)
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
		public Guid DepartmentId {
			get {
				return GetTypedColumnValue<Guid>("DepartmentId");
			}
			set {
				SetColumnValue("DepartmentId", value);
				_department = null;
			}
		}

		/// <exclude/>
		public string DepartmentName {
			get {
				return GetTypedColumnValue<string>("DepartmentName");
			}
			set {
				SetColumnValue("DepartmentName", value);
				if (_department != null) {
					_department.Name = value;
				}
			}
		}

		private Department _department;
		/// <summary>
		/// Department.
		/// </summary>
		public Department Department {
			get {
				return _department ??
					(_department = LookupColumnEntities.GetEntity("Department") as Department);
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

		private Job _job;
		/// <summary>
		/// Job title.
		/// </summary>
		public Job Job {
			get {
				return _job ??
					(_job = LookupColumnEntities.GetEntity("Job") as Job);
			}
		}

		/// <summary>
		/// Full job title.
		/// </summary>
		public string JobTitle {
			get {
				return GetTypedColumnValue<string>("JobTitle");
			}
			set {
				SetColumnValue("JobTitle", value);
			}
		}

		/// <summary>
		/// Primary.
		/// </summary>
		public bool Primary {
			get {
				return GetTypedColumnValue<bool>("Primary");
			}
			set {
				SetColumnValue("Primary", value);
			}
		}

		/// <summary>
		/// Current.
		/// </summary>
		public bool Current {
			get {
				return GetTypedColumnValue<bool>("Current");
			}
			set {
				SetColumnValue("Current", value);
			}
		}

		/// <summary>
		/// Start.
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
		/// End.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <exclude/>
		public Guid JobChangeReasonId {
			get {
				return GetTypedColumnValue<Guid>("JobChangeReasonId");
			}
			set {
				SetColumnValue("JobChangeReasonId", value);
				_jobChangeReason = null;
			}
		}

		/// <exclude/>
		public string JobChangeReasonName {
			get {
				return GetTypedColumnValue<string>("JobChangeReasonName");
			}
			set {
				SetColumnValue("JobChangeReasonName", value);
				if (_jobChangeReason != null) {
					_jobChangeReason.Name = value;
				}
			}
		}

		private JobChangeReason _jobChangeReason;
		/// <summary>
		/// Reason for job change.
		/// </summary>
		public JobChangeReason JobChangeReason {
			get {
				return _jobChangeReason ??
					(_jobChangeReason = LookupColumnEntities.GetEntity("JobChangeReason") as JobChangeReason);
			}
		}

		/// <summary>
		/// Description.
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
		public Guid DecisionRoleId {
			get {
				return GetTypedColumnValue<Guid>("DecisionRoleId");
			}
			set {
				SetColumnValue("DecisionRoleId", value);
				_decisionRole = null;
			}
		}

		/// <exclude/>
		public string DecisionRoleName {
			get {
				return GetTypedColumnValue<string>("DecisionRoleName");
			}
			set {
				SetColumnValue("DecisionRoleName", value);
				if (_decisionRole != null) {
					_decisionRole.Name = value;
				}
			}
		}

		private ContactDecisionRole _decisionRole;
		/// <summary>
		/// Role.
		/// </summary>
		public ContactDecisionRole DecisionRole {
			get {
				return _decisionRole ??
					(_decisionRole = LookupColumnEntities.GetEntity("DecisionRole") as ContactDecisionRole);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactCareer_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("ContactCareer_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactCareer_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCareer_BaseEventsProcess

	/// <exclude/>
	public partial class ContactCareer_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContactCareer_Base_BPMSoft
	{

		#region Class: SynchronizeContactDataFlowElement

		/// <exclude/>
		public class SynchronizeContactDataFlowElement : SynchronizeParentEntityData
		{

			public SynchronizeContactDataFlowElement(UserConnection userConnection, ContactCareer_BaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeContactData";
				IsLogging = false;
				SchemaElementUId = new Guid("a935bfc0-7d92-4b95-8a47-d894250b4598");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public ContactCareer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactCareer_BaseEventsProcess";
			SchemaUId = new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a0a1d0c3-6267-4584-acbd-fd53660798ce");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _eventSubProcessContactCareerSaving;
		public ProcessFlowElement EventSubProcessContactCareerSaving {
			get {
				return _eventSubProcessContactCareerSaving ?? (_eventSubProcessContactCareerSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessContactCareerSaving",
					SchemaElementUId = new Guid("e24dec1b-8de7-4b53-a9a5-2ebfdf164d2d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessageContactCareerSaving;
		public ProcessFlowElement StartMessageContactCareerSaving {
			get {
				return _startMessageContactCareerSaving ?? (_startMessageContactCareerSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessageContactCareerSaving",
					SchemaElementUId = new Guid("87f5f51d-038f-464f-9f17-7e144c04ede6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCareerSaving;
		public ProcessScriptTask ScriptContactCareerSaving {
			get {
				return _scriptContactCareerSaving ?? (_scriptContactCareerSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCareerSaving",
					SchemaElementUId = new Guid("f078ad86-fbef-46f2-b198-278c92af6e41"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCareerSavingExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess1;
		public ProcessFlowElement SubProcess1 {
			get {
				return _subProcess1 ?? (_subProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess1",
					SchemaElementUId = new Guid("2d0defc1-0e17-42c6-acb8-057ae0ab5774"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCareerSaved;
		public ProcessFlowElement ContactCareerSaved {
			get {
				return _contactCareerSaved ?? (_contactCareerSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCareerSaved",
					SchemaElementUId = new Guid("b5183f56-5771-4c53-b315-803b1645eda8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptCheckPrimary;
		public ProcessScriptTask ScriptCheckPrimary {
			get {
				return _scriptCheckPrimary ?? (_scriptCheckPrimary = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptCheckPrimary",
					SchemaElementUId = new Guid("7e64b40e-8db8-4a07-ace1-4ed900f000c0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptCheckPrimaryExecute,
				});
			}
		}

		private ProcessScriptTask _updateContactEntityScriptTask;
		public ProcessScriptTask UpdateContactEntityScriptTask {
			get {
				return _updateContactEntityScriptTask ?? (_updateContactEntityScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateContactEntityScriptTask",
					SchemaElementUId = new Guid("6c21bc07-c7bc-463c-96cb-d08c7a8eebae"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateContactEntityScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("d8295abf-dbd6-421a-b908-2c3caec95c07"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactCareerDeleted;
		public ProcessFlowElement ContactCareerDeleted {
			get {
				return _contactCareerDeleted ?? (_contactCareerDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactCareerDeleted",
					SchemaElementUId = new Guid("722c3d50-bb5a-42bd-9b93-540d050f81da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _deprecatedProcessSaved;
		public ProcessFlowElement DeprecatedProcessSaved {
			get {
				return _deprecatedProcessSaved ?? (_deprecatedProcessSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DeprecatedProcessSaved",
					SchemaElementUId = new Guid("4a666b7d-46f7-419c-bfa8-69b85a812bda"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _fakeContactCareerSaved;
		public ProcessFlowElement FakeContactCareerSaved {
			get {
				return _fakeContactCareerSaved ?? (_fakeContactCareerSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "FakeContactCareerSaved",
					SchemaElementUId = new Guid("f2536460-9fad-4756-b799-edbaaf62d8f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCareerSaved;
		public ProcessScriptTask ScriptContactCareerSaved {
			get {
				return _scriptContactCareerSaved ?? (_scriptContactCareerSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCareerSaved",
					SchemaElementUId = new Guid("bf2561cc-4239-42b0-bba0-ce5b94eb95ff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCareerSavedExecute,
				});
			}
		}

		private SynchronizeContactDataFlowElement _synchronizeContactData;
		public SynchronizeContactDataFlowElement SynchronizeContactData {
			get {
				return _synchronizeContactData ?? (_synchronizeContactData = new SynchronizeContactDataFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessFlowElement _deprecatedProcessDeleted;
		public ProcessFlowElement DeprecatedProcessDeleted {
			get {
				return _deprecatedProcessDeleted ?? (_deprecatedProcessDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "DeprecatedProcessDeleted",
					SchemaElementUId = new Guid("1d8ffbda-d43a-428a-af12-28994c07d8f0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _fakeContactCareerDeleted;
		public ProcessFlowElement FakeContactCareerDeleted {
			get {
				return _fakeContactCareerDeleted ?? (_fakeContactCareerDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "FakeContactCareerDeleted",
					SchemaElementUId = new Guid("94a628f6-1514-47cc-a31f-3d50236922fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptContactCareerDeleted;
		public ProcessScriptTask ScriptContactCareerDeleted {
			get {
				return _scriptContactCareerDeleted ?? (_scriptContactCareerDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptContactCareerDeleted",
					SchemaElementUId = new Guid("9e24e4ea-7a4f-4f26-85e2-fe863c20c81f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptContactCareerDeletedExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcessContactCareerSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessContactCareerSaving };
			FlowElements[StartMessageContactCareerSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessageContactCareerSaving };
			FlowElements[ScriptContactCareerSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCareerSaving };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[ContactCareerSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCareerSaved };
			FlowElements[ScriptCheckPrimary.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptCheckPrimary };
			FlowElements[UpdateContactEntityScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateContactEntityScriptTask };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[ContactCareerDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactCareerDeleted };
			FlowElements[DeprecatedProcessSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { DeprecatedProcessSaved };
			FlowElements[FakeContactCareerSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { FakeContactCareerSaved };
			FlowElements[ScriptContactCareerSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCareerSaved };
			FlowElements[SynchronizeContactData.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeContactData };
			FlowElements[DeprecatedProcessDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { DeprecatedProcessDeleted };
			FlowElements[FakeContactCareerDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { FakeContactCareerDeleted };
			FlowElements[ScriptContactCareerDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptContactCareerDeleted };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcessContactCareerSaving":
						break;
					case "StartMessageContactCareerSaving":
						e.Context.QueueTasks.Enqueue("ScriptContactCareerSaving");
						break;
					case "ScriptContactCareerSaving":
						break;
					case "SubProcess1":
						break;
					case "ContactCareerSaved":
						e.Context.QueueTasks.Enqueue("ScriptCheckPrimary");
						break;
					case "ScriptCheckPrimary":
						e.Context.QueueTasks.Enqueue("UpdateContactEntityScriptTask");
						break;
					case "UpdateContactEntityScriptTask":
						break;
					case "SubProcess2":
						break;
					case "ContactCareerDeleted":
						e.Context.QueueTasks.Enqueue("UpdateContactEntityScriptTask");
						break;
					case "DeprecatedProcessSaved":
						break;
					case "FakeContactCareerSaved":
						e.Context.QueueTasks.Enqueue("ScriptContactCareerSaved");
						break;
					case "ScriptContactCareerSaved":
						e.Context.QueueTasks.Enqueue("SynchronizeContactData");
						break;
					case "SynchronizeContactData":
						break;
					case "DeprecatedProcessDeleted":
						break;
					case "FakeContactCareerDeleted":
						e.Context.QueueTasks.Enqueue("ScriptContactCareerDeleted");
						break;
					case "ScriptContactCareerDeleted":
						e.Context.QueueTasks.Enqueue("SynchronizeContactData");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("StartMessageContactCareerSaving");
			ActivatedEventElements.Add("ContactCareerSaved");
			ActivatedEventElements.Add("ContactCareerDeleted");
			ActivatedEventElements.Add("FakeContactCareerSaved");
			ActivatedEventElements.Add("FakeContactCareerDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcessContactCareerSaving":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessageContactCareerSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessageContactCareerSaving";
					result = StartMessageContactCareerSaving.Execute(context);
					break;
				case "ScriptContactCareerSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCareerSaving";
					result = ScriptContactCareerSaving.Execute(context, ScriptContactCareerSavingExecute);
					break;
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ContactCareerSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCareerSaved";
					result = ContactCareerSaved.Execute(context);
					break;
				case "ScriptCheckPrimary":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptCheckPrimary";
					result = ScriptCheckPrimary.Execute(context, ScriptCheckPrimaryExecute);
					break;
				case "UpdateContactEntityScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateContactEntityScriptTask";
					result = UpdateContactEntityScriptTask.Execute(context, UpdateContactEntityScriptTaskExecute);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ContactCareerDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactCareerDeleted";
					result = ContactCareerDeleted.Execute(context);
					break;
				case "DeprecatedProcessSaved":
					context.QueueTasks.Dequeue();
					break;
				case "FakeContactCareerSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "FakeContactCareerSaved";
					result = FakeContactCareerSaved.Execute(context);
					break;
				case "ScriptContactCareerSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCareerSaved";
					result = ScriptContactCareerSaved.Execute(context, ScriptContactCareerSavedExecute);
					break;
				case "SynchronizeContactData":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeContactData";
					result = SynchronizeContactData.Execute(context);
					break;
				case "DeprecatedProcessDeleted":
					context.QueueTasks.Dequeue();
					break;
				case "FakeContactCareerDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "FakeContactCareerDeleted";
					result = FakeContactCareerDeleted.Execute(context);
					break;
				case "ScriptContactCareerDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptContactCareerDeleted";
					result = ScriptContactCareerDeleted.Execute(context, ScriptContactCareerDeletedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptContactCareerSavingExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool ScriptCheckPrimaryExecute(ProcessExecutingContext context) {
			CheckPrimary(context);
			return true;
		}

		public virtual bool UpdateContactEntityScriptTaskExecute(ProcessExecutingContext context) {
			UpdateContactEntity(context);
			return true;
		}

		public virtual bool ScriptContactCareerSavedExecute(ProcessExecutingContext context) {
			OnContactCareerSaved(context);
			return true;
		}

		public virtual bool ScriptContactCareerDeletedExecute(ProcessExecutingContext context) {
			OnContactCareerDeleted(context);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContactCareer_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("StartMessageContactCareerSaving")) {
							context.QueueTasks.Enqueue("StartMessageContactCareerSaving");
						}
						break;
					case "ContactCareer_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ContactCareerSaved")) {
							context.QueueTasks.Enqueue("ContactCareerSaved");
						}
						break;
					case "ContactCareer_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("ContactCareerDeleted")) {
							context.QueueTasks.Enqueue("ContactCareerDeleted");
						}
						break;
					case "FakeContactCareerSaved":
							if (ActivatedEventElements.Contains("FakeContactCareerSaved")) {
							context.QueueTasks.Enqueue("FakeContactCareerSaved");
						}
						break;
					case "FakeContactCareerDeleted":
							if (ActivatedEventElements.Contains("FakeContactCareerDeleted")) {
							context.QueueTasks.Enqueue("FakeContactCareerDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactCareer_BaseEventsProcess

	/// <exclude/>
	public class ContactCareer_BaseEventsProcess : ContactCareer_BaseEventsProcess<ContactCareer_Base_BPMSoft>
	{

		public ContactCareer_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactCareer_BaseEventsProcess

	public partial class ContactCareer_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void CheckPrimary(ProcessExecutingContext context) {
			if (Entity.Primary) {
				var update = new Update(UserConnection, "ContactCareer")
					.Set("Primary", Column.Parameter(false))
					.Where("ContactId").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("ContactId")))
					.And("Id").IsNotEqual(Column.Parameter(Entity.PrimaryColumnValue)) as Update;
				update.Execute();
			}
			if (Entity.Primary && Entity.Current) {
				return;
			}
			var entitySchemaManager = UserConnection.EntitySchemaManager;
			var entitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, "ContactCareer");
			var contactPrimaryColumnValueName = entitySchemaQuery.AddColumn("Contact.Id").Name;
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact",
				Entity.GetTypedColumnValue<Guid>("ContactId")));
			entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal, "Primary", true));
			var entities = entitySchemaQuery.GetEntityCollection(UserConnection);
			if (entities.Count == 0) {
				var contactSchema = entitySchemaManager.GetInstanceByName("Contact");
				var contactEntity = contactSchema.CreateEntity(UserConnection);
				if (contactEntity.FetchFromDB(Entity.GetTypedColumnValue<Guid>("ContactId"))){
					contactEntity.SetColumnValue("AccountId", null);
					contactEntity.SetColumnValue("DepartmentId", null);
					contactEntity.SetColumnValue("JobId", null);
					contactEntity.SetColumnValue("JobTitle", String.Empty);
					contactEntity.SetColumnValue("DecisionRoleId", null);
					contactEntity.Save();
				}
			}
			return;
		}

		public virtual void OnContactCareerSaved(ProcessExecutingContext context) {
			var conditionMappingColumns = new System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>();
			var mappingColumns = new System.Collections.Generic.Dictionary<
			Guid, Guid>();
			var defaultValues = new System.Collections.Generic.Dictionary<
			Guid, object>();
			
			//--------------- Entity Schema Columns UId -------------------------------
			var contactCareerJobColumnUId = new Guid("bf823e82-f89d-4345-b839-c429dcb2baac");
			var contactCareerJobTitleColumnUId = new Guid("5439cefd-5021-4446-957b-f35eebe76b40");
			var contactCareerDepartmentColumnUId = new Guid("96d86ec7-b8fd-4288-8cc4-c5d6ca4fe46d");
			var contactCareerAccountColumnUId = new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854");
			var contactCareerPrimaryColumnUId = new Guid("131fa275-a32c-4af9-92f0-cfedcad3679c");
			var contactCareerCurrentColumnUId = new Guid("e370b11e-e44a-4ccb-90ed-9f0f2a455adb");
			var contactCareerDecisionRoleColumnUId = new Guid("6324d7f3-fd46-4046-b9c3-76844a3e88a6");
			
			var contactJobColumnUId = new Guid("344436e4-9d6b-4a30-936f-f8ea45f2adb4");
			var contactJobTitleColumnUId = new Guid("8b680ac7-e46c-466c-b630-e5cb4da13a55");
			var contactDepartmentColumnUId = new Guid("94cb8750-ad6f-4e80-b553-7d9e194a856e");
			var contactAccountColumnUId = new Guid("5c6ca10e-1180-4c1e-8a50-55a72ff9bdd4");
			var contactDecisionRoleColumnUId = new Guid("f70c762a-1038-49a7-a3e8-f24fb8cfdeef");
			
			//--------------- Condition Mapping Columns ----------------
			var primaryJobCondition = new System.Collections.Generic.Dictionary<
			Guid, object>();
			primaryJobCondition.Add(contactCareerPrimaryColumnUId, true);
			primaryJobCondition.Add(contactCareerCurrentColumnUId, true);
			conditionMappingColumns.Add(contactJobColumnUId, primaryJobCondition);
			conditionMappingColumns.Add(contactJobTitleColumnUId, primaryJobCondition);
			conditionMappingColumns.Add(contactDepartmentColumnUId, primaryJobCondition);
			conditionMappingColumns.Add(contactAccountColumnUId, primaryJobCondition);
			conditionMappingColumns.Add(contactDecisionRoleColumnUId, primaryJobCondition);
			
			//--------------- Mapping Columns ----------------
			mappingColumns.Add(contactJobColumnUId, contactCareerJobColumnUId);
			mappingColumns.Add(contactJobTitleColumnUId, contactCareerJobTitleColumnUId);
			mappingColumns.Add(contactDepartmentColumnUId, contactCareerDepartmentColumnUId);
			mappingColumns.Add(contactAccountColumnUId, contactCareerAccountColumnUId);
			mappingColumns.Add(contactDecisionRoleColumnUId, contactCareerDecisionRoleColumnUId);
			
			var entity = context.Process.GetPropertyValue("Entity") as BPMSoft.Core.Entities.Entity;
			var entitySchema = entity.Schema;
			SynchronizeContactData.ParentEntityColumnUId = entitySchema.Columns.GetByName("Contact").UId;
			SynchronizeContactData.ConditionMappingColumns = conditionMappingColumns;
			SynchronizeContactData.MappingColumns = mappingColumns;
			SynchronizeContactData.DefaultValues = defaultValues;
			SynchronizeContactData.DeleteChild = false;
			
			return;
		}

		public virtual void OnContactCareerDeleted(ProcessExecutingContext context) {
			var conditionMappingColumns = new System.Collections.Generic.Dictionary<
			Guid, System.Collections.Generic.Dictionary<
			Guid, object>>();
			var mappingColumns = new System.Collections.Generic.Dictionary<
			Guid, Guid>();
			var defaultValues = new System.Collections.Generic.Dictionary<
			Guid, object>();
			
			//--------------- Entity Schema Columns UId -------------------------------
			var contactCareerJobColumnUId = new Guid("bf823e82-f89d-4345-b839-c429dcb2baac");
			var contactCareerJobTitleColumnUId = new Guid("5439cefd-5021-4446-957b-f35eebe76b40");
			var contactCareerDepartmentColumnUId = new Guid("96d86ec7-b8fd-4288-8cc4-c5d6ca4fe46d");
			var contactCareerAccountColumnUId = new Guid("8996b0d8-c0d9-4da7-b130-7917fa48b854");
			var contactCareerPrimaryColumnUId = new Guid("131fa275-a32c-4af9-92f0-cfedcad3679c");
			var contactCareerCurrentColumnUId = new Guid("e370b11e-e44a-4ccb-90ed-9f0f2a455adb");
			
			var contactJobColumnUId = new Guid("344436e4-9d6b-4a30-936f-f8ea45f2adb4");
			var contactJobTitleColumnUId = new Guid("8b680ac7-e46c-466c-b630-e5cb4da13a55");
			var contactDepartmentColumnUId = new Guid("94cb8750-ad6f-4e80-b553-7d9e194a856e");
			var contactAccountColumnUId = new Guid("5c6ca10e-1180-4c1e-8a50-55a72ff9bdd4");
			var decisionRoleColumnUId = new Guid("f70c762a-1038-49a7-a3e8-f24fb8cfdeef");
			
			//--------------- Condition Mapping Columns ----------------
			var primaryAddressCondition = new System.Collections.Generic.Dictionary<
			Guid, object>();
			primaryAddressCondition.Add(contactCareerPrimaryColumnUId, true);
			primaryAddressCondition.Add(contactCareerCurrentColumnUId, true);
			conditionMappingColumns.Add(contactJobColumnUId, primaryAddressCondition);
			conditionMappingColumns.Add(contactJobTitleColumnUId, primaryAddressCondition);
			conditionMappingColumns.Add(contactDepartmentColumnUId, primaryAddressCondition);
			conditionMappingColumns.Add(contactAccountColumnUId, primaryAddressCondition);
			conditionMappingColumns.Add(decisionRoleColumnUId, primaryAddressCondition);
			
			//--------------- Mapping Columns ----------------
			mappingColumns.Add(contactJobColumnUId, contactCareerJobColumnUId);
			mappingColumns.Add(contactJobTitleColumnUId, contactCareerJobTitleColumnUId);
			mappingColumns.Add(contactDepartmentColumnUId, contactCareerDepartmentColumnUId);
			mappingColumns.Add(contactAccountColumnUId, contactCareerAccountColumnUId);
			mappingColumns.Add(decisionRoleColumnUId, Guid.Empty);
			
			var entity = context.Process.GetPropertyValue("Entity") as BPMSoft.Core.Entities.Entity;
			var entitySchema = entity.Schema;
			SynchronizeContactData.ParentEntityColumnUId = new Guid("d6628cf3-ba29-472e-b0f2-9b51f693ef2a");
			SynchronizeContactData.ConditionMappingColumns = conditionMappingColumns;
			SynchronizeContactData.MappingColumns = mappingColumns;
			SynchronizeContactData.DefaultValues = defaultValues;
			SynchronizeContactData.DeleteChild = true;
			
			return;
		}

		public virtual void UpdateContactEntity(ProcessExecutingContext context) {
			var isPrimary = Entity.GetTypedColumnValue<bool>("Primary");
			if (isPrimary) {
				var contactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
				var contactEntity = contactSchema.CreateEntity(UserConnection);
				if (contactEntity.FetchFromDB(contactId)) {
					var jobId = Entity.GetTypedColumnValue<Guid>("JobId");
					var jobTitle = Entity.GetTypedColumnValue<string>("JobTitle");
					var departmentId = Entity.GetTypedColumnValue<Guid>("DepartmentId");
					var accountId = Entity.GetTypedColumnValue<Guid>("AccountId");
					var decisionRoleId = Entity.GetTypedColumnValue<Guid>("DecisionRoleId");
					var contactJobId = contactEntity.GetTypedColumnValue<Guid>("JobId");
					var contactJobTitle = contactEntity.GetTypedColumnValue<string>("JobTitle");
					var contactDepartmentId = contactEntity.GetTypedColumnValue<Guid>("DepartmentId");
					var contactAccountId = contactEntity.GetTypedColumnValue<Guid>("AccountId");
					var contactDecisionRoleId = contactEntity.GetTypedColumnValue<Guid>("DecisionRoleId");
					if (!Entity.IsInDeleted && jobId == contactJobId && jobTitle == contactJobTitle && 
						departmentId == contactDepartmentId && accountId == contactAccountId &&
						decisionRoleId == contactDecisionRoleId ) {
						return;
					}
					if (jobId.IsEmpty() || Entity.IsInDeleted) {
						contactEntity.SetColumnValue("JobId", null);
					} else {
						contactEntity.SetColumnValue("JobId", jobId);
					}
					if (Entity.IsInDeleted) {
						contactEntity.SetColumnValue("JobTitle", string.Empty);
					} else {
						contactEntity.SetColumnValue("JobTitle", jobTitle);
					}
					if (departmentId.IsEmpty() || Entity.IsInDeleted) {
						contactEntity.SetColumnValue("DepartmentId", null);
					} else {
						contactEntity.SetColumnValue("DepartmentId", departmentId);
					}
					if (accountId.IsEmpty() || Entity.IsInDeleted) {
						contactEntity.SetColumnValue("AccountId", null);
					} else {
						contactEntity.SetColumnValue("AccountId", accountId);
					}
					if (decisionRoleId.IsEmpty() || Entity.IsInDeleted) {
						contactEntity.SetColumnValue("DecisionRoleId", null);
					} else {
						contactEntity.SetColumnValue("DecisionRoleId", decisionRoleId);
					}
					contactEntity.Save();
				}
			}
		}

		#endregion

	}

	#endregion

}

