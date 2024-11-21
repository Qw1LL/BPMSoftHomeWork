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

	#region Class: OpportunityParticipantSchema

	/// <exclude/>
	public class OpportunityParticipantSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public OpportunityParticipantSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityParticipantSchema(OpportunityParticipantSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityParticipantSchema(OpportunityParticipantSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81");
			RealUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81");
			Name = "OpportunityParticipant";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5cfb28b6-50f2-4807-8c5f-5ce28e29c4df")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
			if (Columns.FindByUId(new Guid("22215ee9-9cd6-4129-96dc-38558b4777aa")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("7df619d3-6bfa-4182-91cd-3ac0ae6289da")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("59f592f7-8035-4156-be8e-faa72f26bf6d")) == null) {
				Columns.Add(CreateRoleColumn());
			}
			if (Columns.FindByUId(new Guid("3f914a8c-3edb-4123-8c93-e75b3831d6cc")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5cfb28b6-50f2-4807-8c5f-5ce28e29c4df"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				ModifiedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("22215ee9-9cd6-4129-96dc-38558b4777aa"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				CreatedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				ModifiedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7df619d3-6bfa-4182-91cd-3ac0ae6289da"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				ModifiedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("59f592f7-8035-4156-be8e-faa72f26bf6d"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("c98f005b-faa4-4279-818c-54c72ad9c161"),
				CreatedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				ModifiedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("3f914a8c-3edb-4123-8c93-e75b3831d6cc"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				ModifiedInSchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityParticipant(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityParticipant_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityParticipantSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityParticipantSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0695af13-f66f-4935-a911-4cedc20c5a81"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityParticipant

	/// <summary>
	/// Участник продажи.
	/// </summary>
	public class OpportunityParticipant : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public OpportunityParticipant(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityParticipant";
		}

		public OpportunityParticipant(OpportunityParticipant source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
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
		public Guid RoleId {
			get {
				return GetTypedColumnValue<Guid>("RoleId");
			}
			set {
				SetColumnValue("RoleId", value);
				_role = null;
			}
		}

		/// <exclude/>
		public string RoleName {
			get {
				return GetTypedColumnValue<string>("RoleName");
			}
			set {
				SetColumnValue("RoleName", value);
				if (_role != null) {
					_role.Name = value;
				}
			}
		}

		private OpportunityParticipantRole _role;
		/// <summary>
		/// Роль.
		/// </summary>
		public OpportunityParticipantRole Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as OpportunityParticipantRole);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityParticipant_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityParticipantDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityParticipantDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityParticipantInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityParticipantInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityParticipantSaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityParticipantSaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityParticipantValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityParticipant(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityParticipant_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityParticipant_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : OpportunityParticipant
	{

		public OpportunityParticipant_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityParticipant_OpportunityEventsProcess";
			SchemaUId = new Guid("0695af13-f66f-4935-a911-4cedc20c5a81");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0695af13-f66f-4935-a911-4cedc20c5a81");
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

	#region Class: OpportunityParticipant_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityParticipant_OpportunityEventsProcess : OpportunityParticipant_OpportunityEventsProcess<OpportunityParticipant>
	{

		public OpportunityParticipant_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityParticipant_OpportunityEventsProcess

	public partial class OpportunityParticipant_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityParticipantEventsProcess

	/// <exclude/>
	public class OpportunityParticipantEventsProcess : OpportunityParticipant_OpportunityEventsProcess
	{

		public OpportunityParticipantEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

