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

	#region Class: EventTeamSchema

	/// <exclude/>
	public class EventTeamSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EventTeamSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventTeamSchema(EventTeamSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventTeamSchema(EventTeamSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			RealUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			Name = "EventTeam";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0857f02b-cdaa-47e1-bd90-a1a050f299ec")) == null) {
				Columns.Add(CreateEventColumn());
			}
			if (Columns.FindByUId(new Guid("8dc7157e-20a2-412e-8f8d-7be1361f97c6")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("d55844da-8571-4f60-8556-9db3a9dfa606")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("8d942145-6816-452f-8fcb-3fbe47bd5bad")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("c5c73740-f228-448d-af0f-7a248a85d9cc")) == null) {
				Columns.Add(CreateRoleColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0857f02b-cdaa-47e1-bd90-a1a050f299ec"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8dc7157e-20a2-412e-8f8d-7be1361f97c6"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d55844da-8571-4f60-8556-9db3a9dfa606"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("8d942145-6816-452f-8fcb-3fbe47bd5bad"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c5c73740-f228-448d-af0f-7a248a85d9cc"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("811dc373-54d6-4402-9b1e-0f32c7b2a3a9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				ModifiedInSchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventTeam(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventTeam_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventTeamSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventTeamSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f"));
		}

		#endregion

	}

	#endregion

	#region Class: EventTeam

	/// <summary>
	/// Участник команды мероприятия.
	/// </summary>
	public class EventTeam : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EventTeam(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventTeam";
		}

		public EventTeam(EventTeam source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
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

		private EventTeamRoles _role;
		/// <summary>
		/// Роль.
		/// </summary>
		public EventTeamRoles Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as EventTeamRoles);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventTeam_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventTeamDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventTeamInserting", e);
			Validating += (s, e) => ThrowEvent("EventTeamValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventTeam(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventTeam_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventTeam_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EventTeam
	{

		public EventTeam_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventTeam_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a5a0dbe7-3622-4dba-bc06-154ebbfd330f");
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

	#region Class: EventTeam_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventTeam_MarketingCampaignEventsProcess : EventTeam_MarketingCampaignEventsProcess<EventTeam>
	{

		public EventTeam_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventTeam_MarketingCampaignEventsProcess

	public partial class EventTeam_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventTeamEventsProcess

	/// <exclude/>
	public class EventTeamEventsProcess : EventTeam_MarketingCampaignEventsProcess
	{

		public EventTeamEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

