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

	#region Class: ContactInFolderSchema

	/// <exclude/>
	public class ContactInFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public ContactInFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContactInFolderSchema(ContactInFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContactInFolderSchema(ContactInFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e");
			RealUId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e");
			Name = "ContactInFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c7266bdc-08dc-413a-b9e5-e674307f1d5a")) == null) {
				Columns.Add(CreateContactColumn());
			}
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7266bdc-08dc-413a-b9e5-e674307f1d5a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e"),
				ModifiedInSchemaUId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e"),
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
			return new ContactInFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContactInFolder_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContactInFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContactInFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e"));
		}

		#endregion

	}

	#endregion

	#region Class: ContactInFolder

	/// <summary>
	/// Contact in folder.
	/// </summary>
	public class ContactInFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public ContactInFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContactInFolder";
		}

		public ContactInFolder(ContactInFolder source)
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
			var process = new ContactInFolder_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ContactInFolderDeleted", e);
			Deleting += (s, e) => ThrowEvent("ContactInFolderDeleting", e);
			Inserted += (s, e) => ThrowEvent("ContactInFolderInserted", e);
			Inserting += (s, e) => ThrowEvent("ContactInFolderInserting", e);
			Saved += (s, e) => ThrowEvent("ContactInFolderSaved", e);
			Saving += (s, e) => ThrowEvent("ContactInFolderSaving", e);
			Validating += (s, e) => ThrowEvent("ContactInFolderValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContactInFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContactInFolder_BaseEventsProcess

	/// <exclude/>
	public partial class ContactInFolder_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : ContactInFolder
	{

		public ContactInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContactInFolder_BaseEventsProcess";
			SchemaUId = new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dacc1d3e-67f8-4286-bbef-8aa80ce6ec2e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
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
					SchemaElementUId = new Guid("f2a1230d-73cd-4128-9874-280614729729"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _contactInFolderDeletedStartMessage;
		public ProcessFlowElement ContactInFolderDeletedStartMessage {
			get {
				return _contactInFolderDeletedStartMessage ?? (_contactInFolderDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ContactInFolderDeletedStartMessage",
					SchemaElementUId = new Guid("3420d2a9-ad4a-41a0-9684-11e9a185fa82"),
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
					SchemaElementUId = new Guid("97b4f198-596d-44e1-b3ce-af44f149fa70"),
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
			FlowElements[ContactInFolderDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ContactInFolderDeletedStartMessage };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "ContactInFolderDeletedStartMessage":
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
			ActivatedEventElements.Add("ContactInFolderDeletedStartMessage");
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
				case "ContactInFolderDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ContactInFolderDeletedStartMessage";
					result = ContactInFolderDeletedStartMessage.Execute(context);
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

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			new Update(UserConnection, "Contact")
				.Set("ModifiedOn", Column.Parameter(UserConnection.CurrentUser.GetCurrentDateTime()))
				.Where("Id").IsEqual(Column.Parameter(Entity.ContactId)).Execute();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ContactInFolderDeleted":
							if (ActivatedEventElements.Contains("ContactInFolderDeletedStartMessage")) {
							context.QueueTasks.Enqueue("ContactInFolderDeletedStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: ContactInFolder_BaseEventsProcess

	/// <exclude/>
	public class ContactInFolder_BaseEventsProcess : ContactInFolder_BaseEventsProcess<ContactInFolder>
	{

		public ContactInFolder_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContactInFolder_BaseEventsProcess

	public partial class ContactInFolder_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContactInFolderEventsProcess

	/// <exclude/>
	public class ContactInFolderEventsProcess : ContactInFolder_BaseEventsProcess
	{

		public ContactInFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

