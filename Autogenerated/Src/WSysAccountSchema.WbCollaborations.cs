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

	#region Class: WSysAccountSchema

	/// <exclude/>
	public class WSysAccountSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public WSysAccountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSysAccountSchema(WSysAccountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSysAccountSchema(WSysAccountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			RealUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			Name = "WSysAccount";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateLoginColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("5a46f90b-3674-4bce-9082-6ce7149dc68d")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("40d78b2e-4f84-44ec-881b-65810e36828f")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("f51b1d57-00db-4894-b35d-a179c630589d")) == null) {
				Columns.Add(CreatePasswordColumn());
			}
			if (Columns.FindByUId(new Guid("9af38cca-2a03-413f-9a6f-a802cda16b73")) == null) {
				Columns.Add(CreateRoleColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			column.CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5a46f90b-3674-4bce-9082-6ce7149dc68d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40d78b2e-4f84-44ec-881b-65810e36828f"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98")
			};
		}

		protected virtual EntitySchemaColumn CreateLoginColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ffcce46c-8ef0-48ff-a470-383898b51f25"),
				Name = @"Login",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98")
			};
		}

		protected virtual EntitySchemaColumn CreatePasswordColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f51b1d57-00db-4894-b35d-a179c630589d"),
				Name = @"Password",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98")
			};
		}

		protected virtual EntitySchemaColumn CreateRoleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9af38cca-2a03-413f-9a6f-a802cda16b73"),
				Name = @"Role",
				ReferenceSchemaUId = new Guid("3367e5f9-0903-4702-8444-537f67ee2fc9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				ModifiedInSchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"),
				CreatedInPackageId = new Guid("1303b630-da63-4ee7-9918-95b9adb4dd98")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSysAccount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSysAccount_WbCollaborationsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSysAccountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSysAccountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f"));
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccount

	/// <summary>
	/// Wb users.
	/// </summary>
	public class WSysAccount : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public WSysAccount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSysAccount";
		}

		public WSysAccount(WSysAccount source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// User login.
		/// </summary>
		public string Login {
			get {
				return GetTypedColumnValue<string>("Login");
			}
			set {
				SetColumnValue("Login", value);
			}
		}

		/// <summary>
		/// Password.
		/// </summary>
		public string Password {
			get {
				return GetTypedColumnValue<string>("Password");
			}
			set {
				SetColumnValue("Password", value);
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

		private WSysAccountRole _role;
		/// <summary>
		/// Role.
		/// </summary>
		public WSysAccountRole Role {
			get {
				return _role ??
					(_role = LookupColumnEntities.GetEntity("Role") as WSysAccountRole);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSysAccount_WbCollaborationsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSysAccountDeleted", e);
			Inserting += (s, e) => ThrowEvent("WSysAccountInserting", e);
			Validating += (s, e) => ThrowEvent("WSysAccountValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSysAccount(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccount_WbCollaborationsEventsProcess

	/// <exclude/>
	public partial class WSysAccount_WbCollaborationsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : WSysAccount
	{

		public WSysAccount_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSysAccount_WbCollaborationsEventsProcess";
			SchemaUId = new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("38dbbdd4-9ab4-473a-bb99-9ca8f830163f");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool AllowSave {
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
					SchemaElementUId = new Guid("5ca1ba77-79ca-4eae-8d0d-affddad05d94"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _entitySavingStartMessage;
		public ProcessFlowElement EntitySavingStartMessage {
			get {
				return _entitySavingStartMessage ?? (_entitySavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "EntitySavingStartMessage",
					SchemaElementUId = new Guid("e3ba08f2-a1dd-4adc-b7d5-a87c3ed82662"),
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
					SchemaElementUId = new Guid("73275ff0-3f99-4174-8d40-fc1607417ccc"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessThrowMessageEvent _entitySaving;
		public ProcessThrowMessageEvent EntitySaving {
			get {
				return _entitySaving ?? (_entitySaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "EntitySaving",
					SchemaElementUId = new Guid("8d9a7781-8407-4cfb-bb41-08e47cc31023"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "BaseEntitySaving",
						ThrowToBase = true,
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
					SchemaElementUId = new Guid("034e9f2b-0708-4ccd-8565-01221fe4983f"),
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
					SchemaElementUId = new Guid("81cbae76-fcb4-40be-92b9-50d6fcde12b6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow2;
		public ProcessConditionalFlow ConditionalFlow2 {
			get {
				return _conditionalFlow2 ?? (_conditionalFlow2 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow2",
					SchemaElementUId = new Guid("fe898e09-11b3-492d-999f-de4c103987ac"),
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
			FlowElements[EntitySavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { EntitySavingStartMessage };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[EntitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EntitySaving };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "EntitySavingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						if (ConditionalFlow1ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("EntitySaving");
							break;
						}
						if (ConditionalFlow2ExpressionExecute()) {
						e.Context.QueueTasks.Enqueue("Terminate1");
							break;
						}
						break;
					case "EntitySaving":
						break;
					case "Terminate1":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(AllowSave);
		}

		private bool ConditionalFlow2ExpressionExecute() {
			return Convert.ToBoolean(!AllowSave);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("EntitySavingStartMessage");
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
				case "EntitySavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "EntitySavingStartMessage";
					result = EntitySavingStartMessage.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "EntitySaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "BaseEntitySaving");
					result = EntitySaving.Execute(context);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
				Guid ContactId = Entity.GetTypedColumnValue<Guid>("ContactId");
				Guid curentId = Entity.GetTypedColumnValue<Guid>("Id");
				string Login = Entity.GetTypedColumnValue<string>("Login");
				
			
				Select select = new Select(UserConnection)
					.Column(Func.Count(Column.Asterisk()))
					.From("WSysAccount").As("d")
					.Where("d", "Id").IsNotEqual(Column.Parameter(curentId))
					.And()
					.OpenBlock("d", "Login").IsEqual(Column.Parameter(Login))
					.Or("d", "ContactId").IsEqual(Column.Parameter(ContactId))
					.CloseBlock()
					as Select;
			AllowSave = (select.ExecuteScalar<int>() == 0);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseEntitySaving":
							if (ActivatedEventElements.Contains("EntitySavingStartMessage")) {
							context.QueueTasks.Enqueue("EntitySavingStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: WSysAccount_WbCollaborationsEventsProcess

	/// <exclude/>
	public class WSysAccount_WbCollaborationsEventsProcess : WSysAccount_WbCollaborationsEventsProcess<WSysAccount>
	{

		public WSysAccount_WbCollaborationsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSysAccount_WbCollaborationsEventsProcess

	public partial class WSysAccount_WbCollaborationsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSysAccountEventsProcess

	/// <exclude/>
	public class WSysAccountEventsProcess : WSysAccount_WbCollaborationsEventsProcess
	{

		public WSysAccountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

