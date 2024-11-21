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

	#region Class: SysLDAPSynchUserSchema

	/// <exclude/>
	public class SysLDAPSynchUserSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public SysLDAPSynchUserSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLDAPSynchUserSchema(SysLDAPSynchUserSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLDAPSynchUserSchema(SysLDAPSynchUserSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f");
			RealUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f");
			Name = "SysLDAPSynchUser";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateRecordIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d452da23-d99c-4b68-9665-e5110c5566b7")) == null) {
				Columns.Add(CreateIdColumn());
			}
			if (Columns.FindByUId(new Guid("776a4b48-99de-474f-aff2-1e9ac7b9d1fa")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("3fefe25d-e666-4f24-963f-be76dd042fb1")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("4a17fe84-8964-4bd9-b300-9c20681d2a22")) == null) {
				Columns.Add(CreateCompanyColumn());
			}
			if (Columns.FindByUId(new Guid("c538cf71-3e9d-4fbe-aa8f-4da219ee8cae")) == null) {
				Columns.Add(CreateEmailColumn());
			}
			if (Columns.FindByUId(new Guid("16e756fe-bee6-466d-b1d8-09763b798d39")) == null) {
				Columns.Add(CreatePhoneColumn());
			}
			if (Columns.FindByUId(new Guid("1e239dd8-2950-4be2-bcc7-3d76999ed2ee")) == null) {
				Columns.Add(CreateJobTitleColumn());
			}
			if (Columns.FindByUId(new Guid("fb3288a1-a46c-4d8b-874b-719e7c3375ec")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("7f46ee1a-e732-4ee3-be2a-3076ae2319a0")) == null) {
				Columns.Add(CreateFullNameColumn());
			}
			if (Columns.FindByUId(new Guid("eab52745-becb-4233-b9d5-254bbd7d2aac")) == null) {
				Columns.Add(CreateDnColumn());
			}
			if (Columns.FindByUId(new Guid("9c96ad55-9dd3-4c08-7b79-c26bc6abda1d")) == null) {
				Columns.Add(CreateLdapSyncIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f5d2acb3-b39a-49d8-9a5d-79c06c7f8fda"),
				Name = @"RecordId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d452da23-d99c-4b68-9665-e5110c5566b7"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("776a4b48-99de-474f-aff2-1e9ac7b9d1fa"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("3fefe25d-e666-4f24-963f-be76dd042fb1"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateCompanyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("4a17fe84-8964-4bd9-b300-9c20681d2a22"),
				Name = @"Company",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("c538cf71-3e9d-4fbe-aa8f-4da219ee8cae"),
				Name = @"Email",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreatePhoneColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("16e756fe-bee6-466d-b1d8-09763b798d39"),
				Name = @"Phone",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateJobTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1e239dd8-2950-4be2-bcc7-3d76999ed2ee"),
				Name = @"JobTitle",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fb3288a1-a46c-4d8b-874b-719e7c3375ec"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateFullNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("7f46ee1a-e732-4ee3-be2a-3076ae2319a0"),
				Name = @"FullName",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateDnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("eab52745-becb-4233-b9d5-254bbd7d2aac"),
				Name = @"Dn",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("69e4f6ff-abe4-4817-965a-3167843360f4")
			};
		}

		protected virtual EntitySchemaColumn CreateLdapSyncIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9c96ad55-9dd3-4c08-7b79-c26bc6abda1d"),
				Name = @"LdapSyncId",
				CreatedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				ModifiedInSchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"),
				CreatedInPackageId = new Guid("7c904ad4-e292-4453-b17c-60a3882c9384")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLDAPSynchUser(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLDAPSynchUser_LDAPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLDAPSynchUserSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLDAPSynchUserSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLDAPSynchUser

	/// <summary>
	/// Temporary table for LDAP users.
	/// </summary>
	public class SysLDAPSynchUser : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public SysLDAPSynchUser(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLDAPSynchUser";
		}

		public SysLDAPSynchUser(SysLDAPSynchUser source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Record Id.
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
		/// Id.
		/// </summary>
		public string Id {
			get {
				return GetTypedColumnValue<string>("Id");
			}
			set {
				SetColumnValue("Id", value);
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
		/// Modification date.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Company.
		/// </summary>
		public string Company {
			get {
				return GetTypedColumnValue<string>("Company");
			}
			set {
				SetColumnValue("Company", value);
			}
		}

		/// <summary>
		/// Email.
		/// </summary>
		public string Email {
			get {
				return GetTypedColumnValue<string>("Email");
			}
			set {
				SetColumnValue("Email", value);
			}
		}

		/// <summary>
		/// Phone.
		/// </summary>
		public string Phone {
			get {
				return GetTypedColumnValue<string>("Phone");
			}
			set {
				SetColumnValue("Phone", value);
			}
		}

		/// <summary>
		/// Job title.
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
		/// Active.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Full name.
		/// </summary>
		public string FullName {
			get {
				return GetTypedColumnValue<string>("FullName");
			}
			set {
				SetColumnValue("FullName", value);
			}
		}

		/// <summary>
		/// Dn.
		/// </summary>
		public string Dn {
			get {
				return GetTypedColumnValue<string>("Dn");
			}
			set {
				SetColumnValue("Dn", value);
			}
		}

		/// <summary>
		/// Synchronization identifier.
		/// </summary>
		public Guid LdapSyncId {
			get {
				return GetTypedColumnValue<Guid>("LdapSyncId");
			}
			set {
				SetColumnValue("LdapSyncId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLDAPSynchUser_LDAPEventsProcess(UserConnection);
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
			return new SysLDAPSynchUser(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLDAPSynchUser_LDAPEventsProcess

	/// <exclude/>
	public partial class SysLDAPSynchUser_LDAPEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : SysLDAPSynchUser
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

		public SysLDAPSynchUser_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLDAPSynchUser_LDAPEventsProcess";
			SchemaUId = new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("886c0437-cad4-4960-823c-d8ffee96ae3f");
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

	#region Class: SysLDAPSynchUser_LDAPEventsProcess

	/// <exclude/>
	public class SysLDAPSynchUser_LDAPEventsProcess : SysLDAPSynchUser_LDAPEventsProcess<SysLDAPSynchUser>
	{

		public SysLDAPSynchUser_LDAPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLDAPSynchUser_LDAPEventsProcess

	public partial class SysLDAPSynchUser_LDAPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLDAPSynchUserEventsProcess

	/// <exclude/>
	public class SysLDAPSynchUserEventsProcess : SysLDAPSynchUser_LDAPEventsProcess
	{

		public SysLDAPSynchUserEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

