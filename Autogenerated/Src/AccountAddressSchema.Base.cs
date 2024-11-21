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

	#region Class: AccountAddressSchema

	/// <exclude/>
	public class AccountAddressSchema : BPMSoft.Configuration.BaseAddressSchema
	{

		#region Constructors: Public

		public AccountAddressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AccountAddressSchema(AccountAddressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AccountAddressSchema(AccountAddressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da");
			RealUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da");
			Name = "AccountAddress";
			ParentSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateAccountColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8465542c-0dec-454b-87b2-4454adbe2a93")) == null) {
				Columns.Add(CreateGPSNColumn());
			}
			if (Columns.FindByUId(new Guid("4642e9b3-c514-4e94-b146-d19985e8e23a")) == null) {
				Columns.Add(CreateGPSEColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ad9016a8-9510-48da-b065-8d2e1701d0e9"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				ModifiedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSNColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("8465542c-0dec-454b-87b2-4454adbe2a93"),
				Name = @"GPSN",
				CreatedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				ModifiedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				CreatedInPackageId = new Guid("4e5d5de2-9756-4189-8eb7-b9c0d14b74c2")
			};
		}

		protected virtual EntitySchemaColumn CreateGPSEColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("4642e9b3-c514-4e94-b146-d19985e8e23a"),
				Name = @"GPSE",
				CreatedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				ModifiedInSchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"),
				CreatedInPackageId = new Guid("4e5d5de2-9756-4189-8eb7-b9c0d14b74c2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AccountAddress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AccountAddress_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AccountAddressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AccountAddressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da"));
		}

		#endregion

	}

	#endregion

	#region Class: AccountAddress

	/// <summary>
	/// Account address.
	/// </summary>
	public class AccountAddress : BPMSoft.Configuration.BaseAddress
	{

		#region Constructors: Public

		public AccountAddress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AccountAddress";
		}

		public AccountAddress(AccountAddress source)
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

		/// <summary>
		/// GPS N.
		/// </summary>
		public string GPSN {
			get {
				return GetTypedColumnValue<string>("GPSN");
			}
			set {
				SetColumnValue("GPSN", value);
			}
		}

		/// <summary>
		/// GPS E.
		/// </summary>
		public string GPSE {
			get {
				return GetTypedColumnValue<string>("GPSE");
			}
			set {
				SetColumnValue("GPSE", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AccountAddress_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AccountAddressDeleted", e);
			Inserted += (s, e) => ThrowEvent("AccountAddressInserted", e);
			Inserting += (s, e) => ThrowEvent("AccountAddressInserting", e);
			Saved += (s, e) => ThrowEvent("AccountAddressSaved", e);
			Saving += (s, e) => ThrowEvent("AccountAddressSaving", e);
			Validating += (s, e) => ThrowEvent("AccountAddressValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AccountAddress(this);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAddress_BaseEventsProcess

	/// <exclude/>
	public partial class AccountAddress_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseAddress_BaseEventsProcess<TEntity> where TEntity : AccountAddress
	{

		public AccountAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AccountAddress_BaseEventsProcess";
			SchemaUId = new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8ab0fe8a-0340-41ac-8b09-b11f65dd83da");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual Guid DeleteAccountId {
			get;
			set;
		}

		public virtual bool ClearPrimaryAddress {
			get;
			set;
		}

		public virtual Object AddressSynchronizer {
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
					SchemaElementUId = new Guid("7e58b355-af7a-4fd4-88dd-7b7e922910ff"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountAddressSaved;
		public ProcessFlowElement AccountAddressSaved {
			get {
				return _accountAddressSaved ?? (_accountAddressSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAddressSaved",
					SchemaElementUId = new Guid("b6d4a672-5f08-41e2-bb93-959affdb2cea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _synchronizeAccountScript;
		public ProcessScriptTask SynchronizeAccountScript {
			get {
				return _synchronizeAccountScript ?? (_synchronizeAccountScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SynchronizeAccountScript",
					SchemaElementUId = new Guid("6d3df735-15b5-4a36-80e6-d1ba51215caf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SynchronizeAccountScriptExecute,
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
					SchemaElementUId = new Guid("137d37d3-0ca9-4beb-b64b-899a7979bb0a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountAddressDeleted;
		public ProcessFlowElement AccountAddressDeleted {
			get {
				return _accountAddressDeleted ?? (_accountAddressDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAddressDeleted",
					SchemaElementUId = new Guid("6ebb6a7a-e512-46c0-a56f-6709c6d1431e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptAccountAddressDeleted;
		public ProcessScriptTask ScriptAccountAddressDeleted {
			get {
				return _scriptAccountAddressDeleted ?? (_scriptAccountAddressDeleted = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptAccountAddressDeleted",
					SchemaElementUId = new Guid("e1ebe14f-d153-44a3-b934-fd70d25280da"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptAccountAddressDeletedExecute,
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
					SchemaElementUId = new Guid("19c0109c-ae58-4785-abb6-bb64173505bf"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _accountAddressSavingStartMessage;
		public ProcessFlowElement AccountAddressSavingStartMessage {
			get {
				return _accountAddressSavingStartMessage ?? (_accountAddressSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "AccountAddressSavingStartMessage",
					SchemaElementUId = new Guid("55a21698-24e0-4c0b-829e-4ccc55841834"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskAccountAddressSaving;
		public ProcessScriptTask ScriptTaskAccountAddressSaving {
			get {
				return _scriptTaskAccountAddressSaving ?? (_scriptTaskAccountAddressSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskAccountAddressSaving",
					SchemaElementUId = new Guid("e52bbc5c-3f9d-4d7d-ac9f-6b4f614a4ef5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskAccountAddressSavingExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[AccountAddressSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAddressSaved };
			FlowElements[SynchronizeAccountScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeAccountScript };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[AccountAddressDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAddressDeleted };
			FlowElements[ScriptAccountAddressDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptAccountAddressDeleted };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[AccountAddressSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { AccountAddressSavingStartMessage };
			FlowElements[ScriptTaskAccountAddressSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskAccountAddressSaving };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "AccountAddressSaved":
						e.Context.QueueTasks.Enqueue("SynchronizeAccountScript");
						break;
					case "SynchronizeAccountScript":
						break;
					case "SubProcess1":
						break;
					case "AccountAddressDeleted":
						e.Context.QueueTasks.Enqueue("ScriptAccountAddressDeleted");
						break;
					case "ScriptAccountAddressDeleted":
						break;
					case "SubProcess2":
						break;
					case "AccountAddressSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTaskAccountAddressSaving");
						break;
					case "ScriptTaskAccountAddressSaving":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("AccountAddressSaved");
			ActivatedEventElements.Add("AccountAddressDeleted");
			ActivatedEventElements.Add("AccountAddressSavingStartMessage");
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
				case "AccountAddressSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAddressSaved";
					result = AccountAddressSaved.Execute(context);
					break;
				case "SynchronizeAccountScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeAccountScript";
					result = SynchronizeAccountScript.Execute(context, SynchronizeAccountScriptExecute);
					break;
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "AccountAddressDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAddressDeleted";
					result = AccountAddressDeleted.Execute(context);
					break;
				case "ScriptAccountAddressDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptAccountAddressDeleted";
					result = ScriptAccountAddressDeleted.Execute(context, ScriptAccountAddressDeletedExecute);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "AccountAddressSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "AccountAddressSavingStartMessage";
					result = AccountAddressSavingStartMessage.Execute(context);
					break;
				case "ScriptTaskAccountAddressSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskAccountAddressSaving";
					result = ScriptTaskAccountAddressSaving.Execute(context, ScriptTaskAccountAddressSavingExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SynchronizeAccountScriptExecute(ProcessExecutingContext context) {
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (isPrimaryAddress) {
				var synchronizer = GetAddressSynchronizer();
				synchronizer.ResetPrimaryColumn();
				synchronizer.SyncAddressWithMasterEntity();
			}
			return true;
		}

		public virtual bool ScriptAccountAddressDeletedExecute(ProcessExecutingContext context) {
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (isPrimaryAddress) {
				ClearAccountAddress();
				var synchronizer = GetAddressSynchronizer();
				synchronizer.SetPrimaryAddress();
			}
			return true;
		}

		public virtual bool ScriptTaskAccountAddressSavingExecute(ProcessExecutingContext context) {
			var oldPrimaryValue = Entity.GetTypedOldColumnValue<bool>("Primary");
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (oldPrimaryValue && !isPrimaryAddress) {
				ClearAccountAddress();
				return true;
			}
			if (isPrimaryAddress) {
				return true;
			}
			var synchronizer = GetAddressSynchronizer();
			var primaryCount = synchronizer.GetAddressesCount();
			if (primaryCount == 0) {
				Entity.SetColumnValue("Primary", true);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "AccountAddressSaved":
							if (ActivatedEventElements.Contains("AccountAddressSaved")) {
							context.QueueTasks.Enqueue("AccountAddressSaved");
						}
						break;
					case "AccountAddressDeleted":
							if (ActivatedEventElements.Contains("AccountAddressDeleted")) {
							context.QueueTasks.Enqueue("AccountAddressDeleted");
						}
						break;
					case "AccountAddressSaving":
							if (ActivatedEventElements.Contains("AccountAddressSavingStartMessage")) {
							context.QueueTasks.Enqueue("AccountAddressSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: AccountAddress_BaseEventsProcess

	/// <exclude/>
	public class AccountAddress_BaseEventsProcess : AccountAddress_BaseEventsProcess<AccountAddress>
	{

		public AccountAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion


	#region Class: AccountAddressEventsProcess

	/// <exclude/>
	public class AccountAddressEventsProcess : AccountAddress_BaseEventsProcess
	{

		public AccountAddressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

