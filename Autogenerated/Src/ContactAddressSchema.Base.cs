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

	#region Class: ContactAddress_Base_BPMSoftSchema

	/// <exclude/>
	public class ContactAddress_Base_BPMSoftSchema : BPMSoft.Configuration.BaseAddressSchema
	{

		#region Constructors: Public

		public ContactAddress_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactAddress_Base_BPMSoftSchema(ContactAddress_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactAddress_Base_BPMSoftSchema(ContactAddress_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			RealUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			Name = "ContactAddress_Base_BPMSoft";
			ParentSchemaUId = new Guid("400e8687-9616-480d-9d81-61de0235cc86");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeMasterRecordColumn() {
			base.InitializeMasterRecordColumn();
			MasterRecordColumn = CreateContactColumn();
			if (Columns.FindByUId(MasterRecordColumn.UId) == null) {
				Columns.Add(MasterRecordColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateAddressTypeColumn() {
			EntitySchemaColumn column = base.CreateAddressTypeColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateCountryColumn() {
			EntitySchemaColumn column = base.CreateCountryColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateRegionColumn() {
			EntitySchemaColumn column = base.CreateRegionColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateCityColumn() {
			EntitySchemaColumn column = base.CreateCityColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateAddressColumn() {
			EntitySchemaColumn column = base.CreateAddressColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreateZipColumn() {
			EntitySchemaColumn column = base.CreateZipColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimaryColumn() {
			EntitySchemaColumn column = base.CreatePrimaryColumn();
			column.ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("16093858-afb1-4336-b8bc-52159ff08af5"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56"),
				ModifiedInSchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56"),
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
			return new ContactAddress_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactAddress_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactAddress_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactAddress_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactAddress_Base_BPMSoft

	/// <summary>
	/// Contact address.
	/// </summary>
	public class ContactAddress_Base_BPMSoft : BPMSoft.Configuration.BaseAddress
	{

		#region Constructors: Public

		public ContactAddress_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactAddress_Base_BPMSoft";
		}

		public ContactAddress_Base_BPMSoft(ContactAddress_Base_BPMSoft source)
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContactAddress_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftDeleted", e);
			Inserted += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("ContactAddress_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactAddress_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactAddress_BaseEventsProcess

	/// <exclude/>
	public partial class ContactAddress_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseAddress_BaseEventsProcess<TEntity> where TEntity : ContactAddress_Base_BPMSoft
	{

		public ContactAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactAddress_BaseEventsProcess";
			SchemaUId = new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d54d2218-61c8-413a-a1b7-5748c7e25f56");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool ClearPrimaryAddress {
			get;
			set;
		}

		public virtual Object AddressSynchronizer {
			get;
			set;
		}

		private ProcessFlowElement _handleContactAddressSavedSubProcess;
		public ProcessFlowElement HandleContactAddressSavedSubProcess {
			get {
				return _handleContactAddressSavedSubProcess ?? (_handleContactAddressSavedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "HandleContactAddressSavedSubProcess",
					SchemaElementUId = new Guid("442c3f31-e1a0-4ebd-a8b7-6c9b7cddcb6e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAddressSaved;
		public ProcessFlowElement ContactAddressSaved {
			get {
				return _contactAddressSaved ?? (_contactAddressSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAddressSaved",
					SchemaElementUId = new Guid("bd27a1e6-bdf8-43cf-bae0-e4b67698ccde"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptSynchronizeContact;
		public ProcessScriptTask ScriptSynchronizeContact {
			get {
				return _scriptSynchronizeContact ?? (_scriptSynchronizeContact = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptSynchronizeContact",
					SchemaElementUId = new Guid("0e66c772-dfd1-4c6b-8467-79cc6e1cab48"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptSynchronizeContactExecute,
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
					SchemaElementUId = new Guid("edd13844-fbc8-4d33-88fe-17d5925925f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactAddressDeleted;
		public ProcessFlowElement ContactAddressDeleted {
			get {
				return _contactAddressDeleted ?? (_contactAddressDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAddressDeleted",
					SchemaElementUId = new Guid("05da27de-2069-425b-9552-a44b939d671b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _contactAddressDeletedScriptTask;
		public ProcessScriptTask ContactAddressDeletedScriptTask {
			get {
				return _contactAddressDeletedScriptTask ?? (_contactAddressDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ContactAddressDeletedScriptTask",
					SchemaElementUId = new Guid("8ceb2f63-12d2-4363-b8ff-c0c183ef46fb"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ContactAddressDeletedScriptTaskExecute,
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
					SchemaElementUId = new Guid("43f473b4-92df-49af-8392-6edf4f81bcea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTaskClearPrimaryAccount;
		public ProcessScriptTask ScriptTaskClearPrimaryAccount {
			get {
				return _scriptTaskClearPrimaryAccount ?? (_scriptTaskClearPrimaryAccount = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTaskClearPrimaryAccount",
					SchemaElementUId = new Guid("26715bd0-560d-42a0-9cfa-89d84ca900a6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTaskClearPrimaryAccountExecute,
				});
			}
		}

		private ProcessFlowElement _contactAddressSavingStartMessage;
		public ProcessFlowElement ContactAddressSavingStartMessage {
			get {
				return _contactAddressSavingStartMessage ?? (_contactAddressSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactAddressSavingStartMessage",
					SchemaElementUId = new Guid("35d5d675-8fe3-44fd-8cfc-092e6719c52d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[HandleContactAddressSavedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { HandleContactAddressSavedSubProcess };
			FlowElements[ContactAddressSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAddressSaved };
			FlowElements[ScriptSynchronizeContact.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptSynchronizeContact };
			FlowElements[SubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess1 };
			FlowElements[ContactAddressDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAddressDeleted };
			FlowElements[ContactAddressDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAddressDeletedScriptTask };
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[ScriptTaskClearPrimaryAccount.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTaskClearPrimaryAccount };
			FlowElements[ContactAddressSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactAddressSavingStartMessage };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "HandleContactAddressSavedSubProcess":
						break;
					case "ContactAddressSaved":
						e.Context.QueueTasks.Enqueue("ScriptSynchronizeContact");
						break;
					case "ScriptSynchronizeContact":
						break;
					case "SubProcess1":
						break;
					case "ContactAddressDeleted":
						e.Context.QueueTasks.Enqueue("ContactAddressDeletedScriptTask");
						break;
					case "ContactAddressDeletedScriptTask":
						break;
					case "SubProcess2":
						break;
					case "ScriptTaskClearPrimaryAccount":
						break;
					case "ContactAddressSavingStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTaskClearPrimaryAccount");
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ContactAddressSaved");
			ActivatedEventElements.Add("ContactAddressDeleted");
			ActivatedEventElements.Add("ContactAddressSavingStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "HandleContactAddressSavedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAddressSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAddressSaved";
					result = ContactAddressSaved.Execute(context);
					break;
				case "ScriptSynchronizeContact":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptSynchronizeContact";
					result = ScriptSynchronizeContact.Execute(context, ScriptSynchronizeContactExecute);
					break;
				case "SubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ContactAddressDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAddressDeleted";
					result = ContactAddressDeleted.Execute(context);
					break;
				case "ContactAddressDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAddressDeletedScriptTask";
					result = ContactAddressDeletedScriptTask.Execute(context, ContactAddressDeletedScriptTaskExecute);
					break;
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "ScriptTaskClearPrimaryAccount":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTaskClearPrimaryAccount";
					result = ScriptTaskClearPrimaryAccount.Execute(context, ScriptTaskClearPrimaryAccountExecute);
					break;
				case "ContactAddressSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactAddressSavingStartMessage";
					result = ContactAddressSavingStartMessage.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptSynchronizeContactExecute(ProcessExecutingContext context) {
			SynchronizeContact();
			return true;
		}

		public virtual bool ContactAddressDeletedScriptTaskExecute(ProcessExecutingContext context) {
			OnContactAddressDeleted();
			return true;
		}

		public virtual bool ScriptTaskClearPrimaryAccountExecute(ProcessExecutingContext context) {
			var oldPrimaryValue = Entity.GetTypedOldColumnValue<bool>("Primary");
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (oldPrimaryValue && !isPrimaryAddress) {
				ClearContactAddress();
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
					case "ContactAddress_Base_BPMSoftSaved":
							if (ActivatedEventElements.Contains("ContactAddressSaved")) {
							context.QueueTasks.Enqueue("ContactAddressSaved");
						}
						break;
					case "ContactAddress_Base_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("ContactAddressDeleted")) {
							context.QueueTasks.Enqueue("ContactAddressDeleted");
						}
						break;
					case "ContactAddress_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("ContactAddressSavingStartMessage")) {
							context.QueueTasks.Enqueue("ContactAddressSavingStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactAddress_BaseEventsProcess

	/// <exclude/>
	public class ContactAddress_BaseEventsProcess : ContactAddress_BaseEventsProcess<ContactAddress_Base_BPMSoft>
	{

		public ContactAddress_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactAddress_BaseEventsProcess

	public partial class ContactAddress_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void ClearContactAddress() {
			var synchronizer = GetAddressSynchronizer();
			synchronizer.ClearMasterEntityAddress();
		}

		public virtual void SynchronizeContact() {
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (isPrimaryAddress) {
				var synchronizer = GetAddressSynchronizer();
				synchronizer.ResetPrimaryColumn();
				synchronizer.SyncAddressWithMasterEntity();
			}
		}

		public virtual void OnContactAddressDeleted() {
			var isPrimaryAddress = Entity.GetTypedColumnValue<bool>("Primary");
			if (isPrimaryAddress) {
				ClearContactAddress();
				var synchronizer = GetAddressSynchronizer();
				synchronizer.SetPrimaryAddress();
			}
		}

		public virtual BaseAddressSynchronizer GetAddressSynchronizer() {
			AddressSynchronizer = AddressSynchronizer ?? 
				ClassFactory.Get<BaseAddressSynchronizer>(
					new ConstructorArgument("userConnection", UserConnection), new ConstructorArgument("addressEntity", Entity),
					new ConstructorArgument("masterEntityName", "Contact"));
			return (BaseAddressSynchronizer) AddressSynchronizer;
		}

		#endregion

	}

	#endregion

}

