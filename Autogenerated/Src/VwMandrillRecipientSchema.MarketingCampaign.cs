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

	#region Class: VwMandrillRecipientSchema

	/// <exclude/>
	public class VwMandrillRecipientSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwMandrillRecipientSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwMandrillRecipientSchema(VwMandrillRecipientSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwMandrillRecipientSchema(VwMandrillRecipientSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125");
			RealUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125");
			Name = "VwMandrillRecipient";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("45262819-64d3-4adf-bb0f-9b94e1486e18");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("8cf566c0-7efe-40ce-835b-da7e6175d994")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("9ef336de-da1b-483e-88d0-e158e079f598")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("f431b046-38d1-4b4f-9f90-666249b56a86")) == null) {
				Columns.Add(CreateEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("786a9785-b47f-4336-b539-88ee8cec2463")) == null) {
				Columns.Add(CreateRIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8cf566c0-7efe-40ce-835b-da7e6175d994"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				ModifiedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				CreatedInPackageId = new Guid("bf106969-ca59-4591-8fd8-1964385773cf")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ef336de-da1b-483e-88d0-e158e079f598"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				ModifiedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				CreatedInPackageId = new Guid("bf106969-ca59-4591-8fd8-1964385773cf")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f431b046-38d1-4b4f-9f90-666249b56a86"),
				Name = @"EmailAddress",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				ModifiedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				CreatedInPackageId = new Guid("bf106969-ca59-4591-8fd8-1964385773cf")
			};
		}

		protected virtual EntitySchemaColumn CreateRIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("786a9785-b47f-4336-b539-88ee8cec2463"),
				Name = @"RId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				ModifiedInSchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"),
				CreatedInPackageId = new Guid("196dac4c-8195-4488-a569-0010bfda9cdc")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwMandrillRecipient(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwMandrillRecipient_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwMandrillRecipientSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwMandrillRecipientSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125"));
		}

		#endregion

	}

	#endregion

	#region Class: VwMandrillRecipient

	/// <summary>
	/// Контакт в аудитории рассылки.
	/// </summary>
	public class VwMandrillRecipient : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwMandrillRecipient(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwMandrillRecipient";
		}

		public VwMandrillRecipient(VwMandrillRecipient source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
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
		/// Email.
		/// </summary>
		public string EmailAddress {
			get {
				return GetTypedColumnValue<string>("EmailAddress");
			}
			set {
				SetColumnValue("EmailAddress", value);
			}
		}

		/// <summary>
		/// RId.
		/// </summary>
		public int RId {
			get {
				return GetTypedColumnValue<int>("RId");
			}
			set {
				SetColumnValue("RId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwMandrillRecipient_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwMandrillRecipientDeleted", e);
			Inserted += (s, e) => ThrowEvent("VwMandrillRecipientInserted", e);
			Validating += (s, e) => ThrowEvent("VwMandrillRecipientValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwMandrillRecipient(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwMandrillRecipient_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwMandrillRecipient_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwMandrillRecipient
	{

		public VwMandrillRecipient_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwMandrillRecipient_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7a0ca7dc-65b1-4c35-b2c6-9ebfd8bce125");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _mandrillRecipientInsertedSubProcess;
		public ProcessFlowElement MandrillRecipientInsertedSubProcess {
			get {
				return _mandrillRecipientInsertedSubProcess ?? (_mandrillRecipientInsertedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "MandrillRecipientInsertedSubProcess",
					SchemaElementUId = new Guid("751b6163-5422-4bb1-b423-87f50f8b4403"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mandrillRecipientInsertedScriptTask;
		public ProcessScriptTask MandrillRecipientInsertedScriptTask {
			get {
				return _mandrillRecipientInsertedScriptTask ?? (_mandrillRecipientInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MandrillRecipientInsertedScriptTask",
					SchemaElementUId = new Guid("4c07b882-147a-448b-9667-05dbd5877d6b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MandrillRecipientInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _mandrillRecipientInserted;
		public ProcessFlowElement MandrillRecipientInserted {
			get {
				return _mandrillRecipientInserted ?? (_mandrillRecipientInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MandrillRecipientInserted",
					SchemaElementUId = new Guid("2d0bf5e8-b830-4c4a-be44-3d4d9547a945"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mandrillRecipientDeletedSubProcess;
		public ProcessFlowElement MandrillRecipientDeletedSubProcess {
			get {
				return _mandrillRecipientDeletedSubProcess ?? (_mandrillRecipientDeletedSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "MandrillRecipientDeletedSubProcess",
					SchemaElementUId = new Guid("c652f158-16c3-4cb0-af96-672811bc48c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mandrillRecipientDeleted;
		public ProcessFlowElement MandrillRecipientDeleted {
			get {
				return _mandrillRecipientDeleted ?? (_mandrillRecipientDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MandrillRecipientDeleted",
					SchemaElementUId = new Guid("8bae41ab-7130-42f6-99c4-5d8329c34551"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _mandrillRecipientDeletedScriptTask;
		public ProcessScriptTask MandrillRecipientDeletedScriptTask {
			get {
				return _mandrillRecipientDeletedScriptTask ?? (_mandrillRecipientDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "MandrillRecipientDeletedScriptTask",
					SchemaElementUId = new Guid("014fda5c-b5e2-47ce-ae47-9914377f505f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = MandrillRecipientDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[MandrillRecipientInsertedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientInsertedSubProcess };
			FlowElements[MandrillRecipientInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientInsertedScriptTask };
			FlowElements[MandrillRecipientInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientInserted };
			FlowElements[MandrillRecipientDeletedSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientDeletedSubProcess };
			FlowElements[MandrillRecipientDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientDeleted };
			FlowElements[MandrillRecipientDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { MandrillRecipientDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "MandrillRecipientInsertedSubProcess":
						break;
					case "MandrillRecipientInsertedScriptTask":
						break;
					case "MandrillRecipientInserted":
						e.Context.QueueTasks.Enqueue("MandrillRecipientInsertedScriptTask");
						break;
					case "MandrillRecipientDeletedSubProcess":
						break;
					case "MandrillRecipientDeleted":
						e.Context.QueueTasks.Enqueue("MandrillRecipientDeletedScriptTask");
						break;
					case "MandrillRecipientDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MandrillRecipientInserted");
			ActivatedEventElements.Add("MandrillRecipientDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "MandrillRecipientInsertedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "MandrillRecipientInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MandrillRecipientInsertedScriptTask";
					result = MandrillRecipientInsertedScriptTask.Execute(context, MandrillRecipientInsertedScriptTaskExecute);
					break;
				case "MandrillRecipientInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MandrillRecipientInserted";
					result = MandrillRecipientInserted.Execute(context);
					break;
				case "MandrillRecipientDeletedSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "MandrillRecipientDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "MandrillRecipientDeleted";
					result = MandrillRecipientDeleted.Execute(context);
					break;
				case "MandrillRecipientDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "MandrillRecipientDeletedScriptTask";
					result = MandrillRecipientDeletedScriptTask.Execute(context, MandrillRecipientDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool MandrillRecipientInsertedScriptTaskExecute(ProcessExecutingContext context) {
			
						UpdateBulkEmailRecipientCount(1);
						return true;
		}

		public virtual bool MandrillRecipientDeletedScriptTaskExecute(ProcessExecutingContext context) {
			
						UpdateBulkEmailRecipientCount(-1);
						return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "VwMandrillRecipientInserted":
							if (ActivatedEventElements.Contains("MandrillRecipientInserted")) {
							context.QueueTasks.Enqueue("MandrillRecipientInserted");
						}
						break;
					case "VwMandrillRecipientDeleted":
							if (ActivatedEventElements.Contains("MandrillRecipientDeleted")) {
							context.QueueTasks.Enqueue("MandrillRecipientDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: VwMandrillRecipient_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwMandrillRecipient_MarketingCampaignEventsProcess : VwMandrillRecipient_MarketingCampaignEventsProcess<VwMandrillRecipient>
	{

		public VwMandrillRecipient_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwMandrillRecipient_MarketingCampaignEventsProcess

	public partial class VwMandrillRecipient_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateBulkEmailRecipientCount(int incCount) {
			
						var bulkEmailId = Entity.GetTypedColumnValue<Guid>("BulkEmailId");
						if (bulkEmailId == Guid.Empty) {
							return;
						}
						var update = new Update(UserConnection, "BulkEmail")
							.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
							.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
							.Set("RecipientCount", QueryColumnExpression.Add(new QueryColumnExpression("RecipientCount"),
								Column.Parameter(incCount)))
							.Where("Id").IsEqual(Column.Parameter(bulkEmailId));
						update.Execute();
		}

		#endregion

	}

	#endregion


	#region Class: VwMandrillRecipientEventsProcess

	/// <exclude/>
	public class VwMandrillRecipientEventsProcess : VwMandrillRecipient_MarketingCampaignEventsProcess
	{

		public VwMandrillRecipientEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

