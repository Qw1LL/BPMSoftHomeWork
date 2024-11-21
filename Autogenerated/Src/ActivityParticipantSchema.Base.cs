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

	#region Class: ActivityParticipant_Base_BPMSoftSchema

	/// <exclude/>
	public class ActivityParticipant_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ActivityParticipant_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ActivityParticipant_Base_BPMSoftSchema(ActivityParticipant_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ActivityParticipant_Base_BPMSoftSchema(ActivityParticipant_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae");
			RealUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae");
			Name = "ActivityParticipant_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("74669aba-cc69-485d-a68e-956cb30f523a")) == null) {
				Columns.Add(CreateActivityColumn());
			}
			if (Columns.FindByUId(new Guid("80b6623f-f6a9-434b-96e1-c43ba92816ae")) == null) {
				Columns.Add(CreateParticipantColumn());
			}
			if (Columns.FindByUId(new Guid("8dc2dce0-b4d8-4f4e-80a7-b8e5df0c9cc1")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("cf09a744-e539-4bc3-8dde-f63cb772fd58")) == null) {
				Columns.Add(CreateRoleColumn());
			}
			if (Columns.FindByUId(new Guid("ee18b0df-7b71-48c7-b921-ab71a2b276f9")) == null) {
				Columns.Add(CreateReadMarkColumn());
			}
			if (Columns.FindByUId(new Guid("46cf0917-a49e-4e93-8018-14c1846a1c24")) == null) {
				Columns.Add(CreateInviteParticipantColumn());
			}
			if (Columns.FindByUId(new Guid("be4b957d-083d-4660-bf53-83019be16b4e")) == null) {
				Columns.Add(CreateInviteResponseColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateActivityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74669aba-cc69-485d-a68e-956cb30f523a"),
				Name = @"Activity",
				ReferenceSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParticipantColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80b6623f-f6a9-434b-96e1-c43ba92816ae"),
				Name = @"Participant",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("8dc2dce0-b4d8-4f4e-80a7-b8e5df0c9cc1"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf09a744-e539-4bc3-8dde-f63cb772fd58"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("01e72783-64d7-4fac-9d9a-1648eacd51c9"),
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1a8324e8-a6e1-df11-971b-001d60e938c6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateReadMarkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ee18b0df-7b71-48c7-b921-ab71a2b276f9"),
				Name = @"ReadMark",
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateInviteParticipantColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("46cf0917-a49e-4e93-8018-14c1846a1c24"),
				Name = @"InviteParticipant",
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("9dae2167-8d3b-4948-9812-c7a970f9490e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateInviteResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be4b957d-083d-4660-bf53-83019be16b4e"),
				Name = @"InviteResponse",
				ReferenceSchemaUId = new Guid("55767d4d-fb71-40c3-8140-2bfeb8dff693"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				ModifiedInSchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"),
				CreatedInPackageId = new Guid("9dae2167-8d3b-4948-9812-c7a970f9490e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"50e89724-522d-446e-be91-12548b8c834d"
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
			return new ActivityParticipant_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ActivityParticipant_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ActivityParticipant_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ActivityParticipant_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae"));
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipant_Base_BPMSoft

	/// <summary>
	/// Activity participant.
	/// </summary>
	public class ActivityParticipant_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ActivityParticipant_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ActivityParticipant_Base_BPMSoft";
		}

		public ActivityParticipant_Base_BPMSoft(ActivityParticipant_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ActivityId {
			get {
				return GetTypedColumnValue<Guid>("ActivityId");
			}
			set {
				SetColumnValue("ActivityId", value);
				_activity = null;
			}
		}

		/// <exclude/>
		public string ActivityTitle {
			get {
				return GetTypedColumnValue<string>("ActivityTitle");
			}
			set {
				SetColumnValue("ActivityTitle", value);
				if (_activity != null) {
					_activity.Title = value;
				}
			}
		}

		private Activity _activity;
		/// <summary>
		/// Activity.
		/// </summary>
		public Activity Activity {
			get {
				return _activity ??
					(_activity = LookupColumnEntities.GetEntity("Activity") as Activity);
			}
		}

		/// <exclude/>
		public Guid ParticipantId {
			get {
				return GetTypedColumnValue<Guid>("ParticipantId");
			}
			set {
				SetColumnValue("ParticipantId", value);
				_participant = null;
			}
		}

		/// <exclude/>
		public string ParticipantName {
			get {
				return GetTypedColumnValue<string>("ParticipantName");
			}
			set {
				SetColumnValue("ParticipantName", value);
				if (_participant != null) {
					_participant.Name = value;
				}
			}
		}

		private Contact _participant;
		/// <summary>
		/// Participant.
		/// </summary>
		public Contact Participant {
			get {
				return _participant ??
					(_participant = LookupColumnEntities.GetEntity("Participant") as Contact);
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

		private ActivityParticipantRole _role;
		/// <summary>
		/// Role.
		/// </summary>
		public ActivityParticipantRole Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as ActivityParticipantRole);
			}
		}

		/// <summary>
		/// Email opened mark.
		/// </summary>
		public bool ReadMark {
			get {
				return GetTypedColumnValue<bool>("ReadMark");
			}
			set {
				SetColumnValue("ReadMark", value);
			}
		}

		/// <summary>
		/// Send invite to participant.
		/// </summary>
		public bool InviteParticipant {
			get {
				return GetTypedColumnValue<bool>("InviteParticipant");
			}
			set {
				SetColumnValue("InviteParticipant", value);
			}
		}

		/// <exclude/>
		public Guid InviteResponseId {
			get {
				return GetTypedColumnValue<Guid>("InviteResponseId");
			}
			set {
				SetColumnValue("InviteResponseId", value);
				_inviteResponse = null;
			}
		}

		/// <exclude/>
		public string InviteResponseName {
			get {
				return GetTypedColumnValue<string>("InviteResponseName");
			}
			set {
				SetColumnValue("InviteResponseName", value);
				if (_inviteResponse != null) {
					_inviteResponse.Name = value;
				}
			}
		}

		private ParticipantResponse _inviteResponse;
		/// <summary>
		/// Invite response.
		/// </summary>
		public ParticipantResponse InviteResponse {
			get {
				return _inviteResponse ??
					(_inviteResponse = LookupColumnEntities.GetEntity("InviteResponse") as ParticipantResponse);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ActivityParticipant_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("ActivityParticipant_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ActivityParticipant_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipant_BaseEventsProcess

	/// <exclude/>
	public partial class ActivityParticipant_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ActivityParticipant_Base_BPMSoft
	{

		public ActivityParticipant_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ActivityParticipant_BaseEventsProcess";
			SchemaUId = new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1aa6373c-1122-403d-9e75-9bffdf6bdcae");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsUnique {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("41206455-654f-4020-92ba-15993c2cb63d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityParticipantDeleting;
		public ProcessFlowElement ActivityParticipantDeleting {
			get {
				return _activityParticipantDeleting ?? (_activityParticipantDeleting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityParticipantDeleting",
					SchemaElementUId = new Guid("6415c5e7-8d19-4c9a-a9b5-d8077d566f73"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptActivityParticipantDeleting;
		public ProcessScriptTask ScriptActivityParticipantDeleting {
			get {
				return _scriptActivityParticipantDeleting ?? (_scriptActivityParticipantDeleting = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptActivityParticipantDeleting",
					SchemaElementUId = new Guid("367b83fd-66ef-4b10-8ed5-c9100a5b2867"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptActivityParticipantDeletingExecute,
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
					SchemaElementUId = new Guid("cd3b457b-ec1a-4131-b9bf-bc3965891699"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityParticipantSavedStartMessage1;
		public ProcessFlowElement ActivityParticipantSavedStartMessage1 {
			get {
				return _activityParticipantSavedStartMessage1 ?? (_activityParticipantSavedStartMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityParticipantSavedStartMessage1",
					SchemaElementUId = new Guid("4227fc1c-1165-42e3-955a-946024866c83"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _activityParticipantSavedIntermediateThrowMessageEvent1;
		public ProcessThrowMessageEvent ActivityParticipantSavedIntermediateThrowMessageEvent1 {
			get {
				return _activityParticipantSavedIntermediateThrowMessageEvent1 ?? (_activityParticipantSavedIntermediateThrowMessageEvent1 = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "ActivityParticipantSavedIntermediateThrowMessageEvent1",
					SchemaElementUId = new Guid("845fe4a4-b849-4dd0-a4af-475fd14cf44c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "ActivityParticipantSaved",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _activityParticipantSavedScript;
		public ProcessScriptTask ActivityParticipantSavedScript {
			get {
				return _activityParticipantSavedScript ?? (_activityParticipantSavedScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityParticipantSavedScript",
					SchemaElementUId = new Guid("b68f9ef9-4763-43b7-9a77-ba34343eed6a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityParticipantSavedScriptExecute,
				});
			}
		}

		private ProcessScriptTask _updateRemindings;
		public ProcessScriptTask UpdateRemindings {
			get {
				return _updateRemindings ?? (_updateRemindings = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateRemindings",
					SchemaElementUId = new Guid("4b878d1c-e104-4b22-8452-971894f77e45"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3;
		public ProcessFlowElement EventSubProcess3 {
			get {
				return _eventSubProcess3 ?? (_eventSubProcess3 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3",
					SchemaElementUId = new Guid("e5e7da00-1777-45ce-8e0f-24fc45c17f4d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityParticipantInserting;
		public ProcessFlowElement ActivityParticipantInserting {
			get {
				return _activityParticipantInserting ?? (_activityParticipantInserting = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityParticipantInserting",
					SchemaElementUId = new Guid("92b7c794-e410-4dbf-b026-590e45861403"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("458e6b8a-1a46-47af-b4dc-72ad6d48be87"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[ActivityParticipantDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantDeleting };
			FlowElements[ScriptActivityParticipantDeleting.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptActivityParticipantDeleting };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[ActivityParticipantSavedStartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantSavedStartMessage1 };
			FlowElements[ActivityParticipantSavedIntermediateThrowMessageEvent1.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantSavedIntermediateThrowMessageEvent1 };
			FlowElements[ActivityParticipantSavedScript.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantSavedScript };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[EventSubProcess3.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3 };
			FlowElements[ActivityParticipantInserting.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityParticipantInserting };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ActivityParticipantDeleting":
						e.Context.QueueTasks.Enqueue("ScriptActivityParticipantDeleting");
						break;
					case "ScriptActivityParticipantDeleting":
						break;
					case "EventSubProcess2":
						break;
					case "ActivityParticipantSavedStartMessage1":
						e.Context.QueueTasks.Enqueue("ActivityParticipantSavedIntermediateThrowMessageEvent1");
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						break;
					case "ActivityParticipantSavedIntermediateThrowMessageEvent1":
						e.Context.QueueTasks.Enqueue("ActivityParticipantSavedScript");
						break;
					case "ActivityParticipantSavedScript":
						break;
					case "UpdateRemindings":
						break;
					case "EventSubProcess3":
						break;
					case "ActivityParticipantInserting":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivityParticipantDeleting");
			ActivatedEventElements.Add("ActivityParticipantSavedStartMessage1");
			ActivatedEventElements.Add("ActivityParticipantInserting");
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
				case "ActivityParticipantDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantDeleting";
					result = ActivityParticipantDeleting.Execute(context);
					break;
				case "ScriptActivityParticipantDeleting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptActivityParticipantDeleting";
					result = ScriptActivityParticipantDeleting.Execute(context, ScriptActivityParticipantDeletingExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityParticipantSavedStartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantSavedStartMessage1";
					result = ActivityParticipantSavedStartMessage1.Execute(context);
					break;
				case "ActivityParticipantSavedIntermediateThrowMessageEvent1":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "ActivityParticipantSaved");
					result = ActivityParticipantSavedIntermediateThrowMessageEvent1.Execute(context);
					break;
				case "ActivityParticipantSavedScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantSavedScript";
					result = ActivityParticipantSavedScript.Execute(context, ActivityParticipantSavedScriptExecute);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "EventSubProcess3":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityParticipantInserting":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityParticipantInserting";
					result = ActivityParticipantInserting.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptActivityParticipantDeletingExecute(ProcessExecutingContext context) {
			Select select = new Select(UserConnection)
				.Column(Func.Count("Id"))
				.From("ActivityCorrespondence")
				.Where("ActivityId").IsEqual(Column.Parameter(Entity.ActivityId)) as Select;
			int activityCorrespondenceCount = select.ExecuteScalar<int>();
			if (activityCorrespondenceCount > 0) {
				var activityId = FindPartisipantActivity();
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					new Update(UserConnection, "ActivityCorrespondence")
						.Set("ActivityId", Column.Const(null))
						.Where("ActivityId").IsEqual(Column.Parameter(activityId))
					.Execute(dbExecutor);
				}
			}
			Update update = new Update(UserConnection, "Activity")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("ActivityId"))) as Update;
			update.Execute();
			return true;
		}

		public virtual bool ActivityParticipantSavedScriptExecute(ProcessExecutingContext context) {
			var dbSecurityEngine = UserConnection.DBSecurityEngine;
			var sysAdminUnitESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAdminUnit");
			var primaryColumn = sysAdminUnitESQ.AddColumn(sysAdminUnitESQ.RootSchema.GetPrimaryColumnName()); 
			sysAdminUnitESQ.Filters.Add(sysAdminUnitESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", Entity.ParticipantId));
			var sysAdminUnits = sysAdminUnitESQ.GetEntityCollection(UserConnection);
			if (sysAdminUnits.Count > 0) {
				var adminUnitId = Guid.Empty;
				foreach (var sysAdminUnit in sysAdminUnits) {
					adminUnitId = sysAdminUnit.GetTypedColumnValue<Guid>(primaryColumn.Name);
					var rightLevel = dbSecurityEngine.GetEntitySchemaRecordRightLevel("Activity", Entity.ActivityId);
					if (!rightLevel.HasFlag(SchemaRecordRightLevels.CanRead) &&
						rightLevel.HasFlag(SchemaRecordRightLevels.CanChangeReadRight)) {
						dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminUnitId, "Activity", Entity.ActivityId, EntitySchemaRecordRightOperation.Read, EntitySchemaRecordRightLevel.Allow);
						if (Entity.RoleId.Equals(Guid.Parse("53FC4A92-B0EA-E111-96C4-00165D094C12"))) {
							dbSecurityEngine.SetEntitySchemaRecordOperationRightLevel(adminUnitId, "Activity", Entity.ActivityId, EntitySchemaRecordRightOperation.Edit, EntitySchemaRecordRightLevel.Allow);
						}
					}
				}
			}
			ActualizeInviteActivityParticipant();
			return true;
		}

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			UpdateRemindingsExecute();
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			if (IsEntityEmail()) {
				return true;
			}
			if (!IsUnique) {
				var activityId = this.Entity.ActivityId;
				var participantId = this.Entity.ParticipantId;
				var delete = new Delete(UserConnection).From("ActivityParticipant").Where("ActivityId")
					.IsEqual(Column.Parameter(activityId)).And("ParticipantId")
					.IsEqual(Column.Parameter(participantId));
				using (var dbExecutor = UserConnection.EnsureDBConnection()) {
					delete.Execute(dbExecutor);
				}
			}
			SetInviteActivityParticipant();
			Update update = new Update(UserConnection, "Activity")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Where("Id").IsEqual(Column.Parameter(Entity.GetTypedColumnValue<Guid>("ActivityId"))) as Update;
			update.Execute();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivityParticipant_Base_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("ActivityParticipantDeleting")) {
							context.QueueTasks.Enqueue("ActivityParticipantDeleting");
						}
						break;
					case "ActivityParticipant_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ActivityParticipantSavedStartMessage1")) {
							context.QueueTasks.Enqueue("ActivityParticipantSavedStartMessage1");
						}
						break;
					case "ActivityParticipant_Base_BPMSoftInserting":
							if (ActivatedEventElements.Contains("ActivityParticipantInserting")) {
							context.QueueTasks.Enqueue("ActivityParticipantInserting");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ActivityParticipant_BaseEventsProcess

	/// <exclude/>
	public class ActivityParticipant_BaseEventsProcess : ActivityParticipant_BaseEventsProcess<ActivityParticipant_Base_BPMSoft>
	{

		public ActivityParticipant_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ActivityParticipant_BaseEventsProcess

	public partial class ActivityParticipant_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Guid FindPartisipantActivity() {
			var @ParticipantId = Column.Parameter(Entity.ParticipantId);
			return (new Select(UserConnection).Top(1)
					.Column("ActivityId")
				.From("ActivityParticipant")
				.Where("ParticipantId").IsEqual(@ParticipantId)
				.And().Exists(new Select(UserConnection).Column("Id").From("Activity")
								.Where("OwnerId").IsEqual(@ParticipantId).And("Activity", "Id").IsEqual("ActivityParticipant", "ActivityId"))
				.And().Exists(new Select(UserConnection).Column("Id").From("ActivityCorrespondence")
								.Where("ActivityCorrespondence", "ActivityId").IsEqual("ActivityParticipant", "ActivityId")
								.And("SourceActivityId").IsEqual(new Select(UserConnection).Top(1).Column("SourceActivityId").From("ActivityCorrespondence")
																	.Where("ActivityId").IsEqual(Column.Parameter(Entity.ActivityId)))) as Select).ExecuteScalar<Guid>();
		}

		public virtual void SetInviteActivityParticipant() {
		}

		public virtual void ActualizeInviteActivityParticipant() {
		}

		public virtual Select GetActivitySelect() {
			var activityId = Column.Parameter(Entity.ActivityId);
			return new Select(UserConnection).Top(1)
						.Column("OwnerId")
						.Column("OrganizerId")
					.From("Activity")
					.Where("Id").IsEqual(activityId) as Select;
		}

		public virtual bool IsEntityEmail() {
			var select = new Select(UserConnection).Top(1)
					.Column("TypeId")
				.From("Activity").WithHints(new NoLockHint())
				.Where("Id").IsEqual(Column.Parameter(Entity.ActivityId)) as Select;
			var typeId = select.ExecuteScalar<Guid>();
			return typeId.Equals(ActivityConsts.EmailTypeUId);
		}

		public virtual void UpdateRemindingsExecute() {
			if (Entity.ParticipantId == UserConnection.CurrentUser.ContactId) {
				return;
			}
			Guid id = Entity.GetTypedColumnValue<Guid>("ActivityId");
			if (!IsEntityEmail()) {
				ActivityAnniversaryReminding remindingsGenerator = new ActivityAnniversaryReminding(UserConnection, id);
				remindingsGenerator.Options = new [] { ActivityAnniversaryReminding.ParticipantOption };
				remindingsGenerator.GenerateActualRemindings();
			}
		}

		#endregion

	}

	#endregion

}

