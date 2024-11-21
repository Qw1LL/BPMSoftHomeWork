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

	#region Class: AccountAnniversarySchema

	/// <exclude/>
	public class AccountAnniversarySchema : BPMSoft.Configuration.BaseAnniversarySchema
	{

		#region Constructors: Public

		public AccountAnniversarySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountAnniversarySchema(AccountAnniversarySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountAnniversarySchema(AccountAnniversarySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			RealUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			Name = "AccountAnniversary";
			ParentSchemaUId = new Guid("c3d34c7a-3acf-4394-a9fe-50e48f92ca9f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a16dce5a-2cbe-4675-a7eb-5cfa6f36e958")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected override EntitySchemaColumn CreateDateColumn() {
			EntitySchemaColumn column = base.CreateDateColumn();
			column.ModifiedInSchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			return column;
		}

		protected override EntitySchemaColumn CreateAnniversaryTypeColumn() {
			EntitySchemaColumn column = base.CreateAnniversaryTypeColumn();
			column.ModifiedInSchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a16dce5a-2cbe-4675-a7eb-5cfa6f36e958"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8"),
				ModifiedInSchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8"),
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
			return new AccountAnniversary(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountAnniversary_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountAnniversarySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountAnniversarySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b2420b84-1c49-441b-b875-159f8089e3d8"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountAnniversary

	/// <summary>
	/// Noteworthy event of account.
	/// </summary>
	public class AccountAnniversary : BPMSoft.Configuration.BaseAnniversary
	{

		#region Constructors: Public

		public AccountAnniversary(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountAnniversary";
		}

		public AccountAnniversary(AccountAnniversary source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountAnniversary_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountAnniversaryDeleted", e);
			Deleting += (s, e) => ThrowEvent("AccountAnniversaryDeleting", e);
			Inserted += (s, e) => ThrowEvent("AccountAnniversaryInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountAnniversaryInserting", e);
			Saved += (s, e) => ThrowEvent("AccountAnniversarySaved", e);
			Saving += (s, e) => ThrowEvent("AccountAnniversarySaving", e);
			Validating += (s, e) => ThrowEvent("AccountAnniversaryValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountAnniversary(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAnniversary_BaseEventsProcess

	/// <exclude/>
	public partial class AccountAnniversary_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseAnniversary_BaseEventsProcess<TEntity> where TEntity : AccountAnniversary
	{

		public AccountAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountAnniversary_BaseEventsProcess";
			SchemaUId = new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b2420b84-1c49-441b-b875-159f8089e3d8");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool IsDateChanged {
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
					SchemaElementUId = new Guid("be4de872-76c4-4b87-86b0-4b64ec0806da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountAnniversarySaved;
		public ProcessFlowElement AccountAnniversarySaved {
			get {
				return _accountAnniversarySaved ?? (_accountAnniversarySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAnniversarySaved",
					SchemaElementUId = new Guid("f8ee61e9-4b10-4058-a0bb-0a4c685354f3"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
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
					SchemaElementUId = new Guid("0941540b-9c03-40da-9392-31348aa8fa4f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateRemindingsExecute,
				});
			}
		}

		private ProcessFlowElement _accountAnniversaryDeleted;
		public ProcessFlowElement AccountAnniversaryDeleted {
			get {
				return _accountAnniversaryDeleted ?? (_accountAnniversaryDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAnniversaryDeleted",
					SchemaElementUId = new Guid("a30caf29-bad5-49e4-b180-92799a2a577a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _deleted_InitDateChanged;
		public ProcessScriptTask Deleted_InitDateChanged {
			get {
				return _deleted_InitDateChanged ?? (_deleted_InitDateChanged = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "Deleted_InitDateChanged",
					SchemaElementUId = new Guid("46fb7038-ea21-4079-9436-29bc08c47ea1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = Deleted_InitDateChangedExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c;
		public ProcessFlowElement EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c {
			get {
				return _eventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c ?? (_eventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c",
					SchemaElementUId = new Guid("d7e07ada-ec9f-4dfb-8d14-fd55bcf57b4c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountAnniversarySaving_Base;
		public ProcessFlowElement AccountAnniversarySaving_Base {
			get {
				return _accountAnniversarySaving_Base ?? (_accountAnniversarySaving_Base = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAnniversarySaving_Base",
					SchemaElementUId = new Guid("c4c9869c-a113-4c3b-a706-6037458c9375"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _saving_InitDateChanged;
		public ProcessScriptTask Saving_InitDateChanged {
			get {
				return _saving_InitDateChanged ?? (_saving_InitDateChanged = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "Saving_InitDateChanged",
					SchemaElementUId = new Guid("a740381b-b76d-41bc-a03f-ba1afe0082de"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = Saving_InitDateChangedExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[AccountAnniversarySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAnniversarySaved };
			FlowElements[UpdateRemindings.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateRemindings };
			FlowElements[AccountAnniversaryDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAnniversaryDeleted };
			FlowElements[Deleted_InitDateChanged.SchemaElementUId] = new Collection<ProcessFlowElement> { Deleted_InitDateChanged };
			FlowElements[EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c };
			FlowElements[AccountAnniversarySaving_Base.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAnniversarySaving_Base };
			FlowElements[Saving_InitDateChanged.SchemaElementUId] = new Collection<ProcessFlowElement> { Saving_InitDateChanged };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "AccountAnniversarySaved":
						e.Context.QueueTasks.Enqueue("UpdateRemindings");
						break;
					case "UpdateRemindings":
						break;
					case "AccountAnniversaryDeleted":
						e.Context.QueueTasks.Enqueue("Deleted_InitDateChanged");
						break;
					case "Deleted_InitDateChanged":
						break;
					case "EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c":
						break;
					case "AccountAnniversarySaving_Base":
						e.Context.QueueTasks.Enqueue("Saving_InitDateChanged");
						break;
					case "Saving_InitDateChanged":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("AccountAnniversarySaved");
			ActivatedEventElements.Add("AccountAnniversaryDeleted");
			ActivatedEventElements.Add("AccountAnniversarySaving_Base");
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
				case "AccountAnniversarySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAnniversarySaved";
					result = AccountAnniversarySaved.Execute(context);
					break;
				case "UpdateRemindings":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateRemindings";
					result = UpdateRemindings.Execute(context, UpdateRemindingsExecute);
					break;
				case "AccountAnniversaryDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAnniversaryDeleted";
					result = AccountAnniversaryDeleted.Execute(context);
					break;
				case "Deleted_InitDateChanged":
					context.QueueTasks.Dequeue();
					context.SenderName = "Deleted_InitDateChanged";
					result = Deleted_InitDateChanged.Execute(context, Deleted_InitDateChangedExecute);
					break;
				case "EventSubProcess3_d7e07adaec9f4dfb8d14fd55bcf57b4c":
					context.QueueTasks.Dequeue();
					break;
				case "AccountAnniversarySaving_Base":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAnniversarySaving_Base";
					result = AccountAnniversarySaving_Base.Execute(context);
					break;
				case "Saving_InitDateChanged":
					context.QueueTasks.Dequeue();
					context.SenderName = "Saving_InitDateChanged";
					result = Saving_InitDateChanged.Execute(context, Saving_InitDateChangedExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool UpdateRemindingsExecute(ProcessExecutingContext context) {
			UpdateRemindingsExecute();
			return true;
		}

		public virtual bool Deleted_InitDateChangedExecute(ProcessExecutingContext context) {
			Guid id = Entity.GetTypedColumnValue<Guid>("AccountId");
			Guid schemaUId = Entity.Account.Schema.UId;
			AccountAnniversaryReminding remindingsGenerator = new AccountAnniversaryReminding(UserConnection, id);
			remindingsGenerator.DeleteRecordRemindings(schemaUId);
			return true;
		}

		public virtual bool Saving_InitDateChangedExecute(ProcessExecutingContext context) {
			IsDateChanged = Entity.GetChangedColumnValues().Any(col => col.Name == "Date");
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "AccountAnniversarySaved":
							if (ActivatedEventElements.Contains("AccountAnniversarySaved")) {
							context.QueueTasks.Enqueue("AccountAnniversarySaved");
						}
						break;
					case "AccountAnniversaryDeleted":
							if (ActivatedEventElements.Contains("AccountAnniversaryDeleted")) {
							context.QueueTasks.Enqueue("AccountAnniversaryDeleted");
						}
						break;
					case "AccountAnniversarySaving":
							if (ActivatedEventElements.Contains("AccountAnniversarySaving_Base")) {
							context.QueueTasks.Enqueue("AccountAnniversarySaving_Base");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAnniversary_BaseEventsProcess

	/// <exclude/>
	public class AccountAnniversary_BaseEventsProcess : AccountAnniversary_BaseEventsProcess<AccountAnniversary>
	{

		public AccountAnniversary_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AccountAnniversary_BaseEventsProcess

	public partial class AccountAnniversary_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateRemindingsExecute() {
			if (!IsDateChanged) {
				return;
			}
			Guid id = Entity.GetTypedColumnValue<Guid>("AccountId");
			AccountAnniversaryReminding remindingsGenerator = new AccountAnniversaryReminding(UserConnection, id);
			remindingsGenerator.Options = new [] { AccountAnniversaryReminding.AccountOption };
			remindingsGenerator.GenerateActualRemindings();
		}

		#endregion

	}

	#endregion


	#region Class: AccountAnniversaryEventsProcess

	/// <exclude/>
	public class AccountAnniversaryEventsProcess : AccountAnniversary_BaseEventsProcess
	{

		public AccountAnniversaryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

