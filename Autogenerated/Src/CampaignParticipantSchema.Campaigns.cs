namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Campaign;
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

	#region Class: CampaignParticipantSchema

	/// <exclude/>
	public class CampaignParticipantSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignParticipantSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignParticipantSchema(CampaignParticipantSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignParticipantSchema(CampaignParticipantSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650");
			RealUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650");
			Name = "CampaignParticipant";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e0a882f3-eac1-46cb-91c9-d678e0723090")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("68b7f207-bd39-4ed1-b85c-309af28a6329")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("5fd85758-dccd-4a3c-990d-d8d86a2d168d")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("10ce1ffe-4c46-4565-8ef2-14904fa77be9")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("12d696f8-d572-4651-a7c8-f6732aefd884")) == null) {
				Columns.Add(CreateStepModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("fcb47eb0-d278-4a17-939c-c6df557d9a04")) == null) {
				Columns.Add(CreateStepCompletedOnColumn());
			}
			if (Columns.FindByUId(new Guid("9ec2aa9e-da21-4ebb-87bc-da31089b8054")) == null) {
				Columns.Add(CreateStepCompletedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e0a882f3-eac1-46cb-91c9-d678e0723090"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("68b7f207-bd39-4ed1-b85c-309af28a6329"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5fd85758-dccd-4a3c-990d-d8d86a2d168d"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"58b91b66-256b-48cf-a56a-a5b7036825e6"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10ce1ffe-4c46-4565-8ef2-14904fa77be9"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateStepModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("12d696f8-d572-4651-a7c8-f6732aefd884"),
				Name = @"StepModifiedOn",
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateStepCompletedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("fcb47eb0-d278-4a17-939c-c6df557d9a04"),
				Name = @"StepCompletedOn",
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateStepCompletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9ec2aa9e-da21-4ebb-87bc-da31089b8054"),
				Name = @"StepCompleted",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				ModifiedInSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
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
			return new CampaignParticipant(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignParticipant_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignParticipantSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignParticipantSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipant

	/// <summary>
	/// Участник кампании.
	/// </summary>
	public class CampaignParticipant : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignParticipant(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignParticipant";
		}

		public CampaignParticipant(CampaignParticipant source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
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
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CmpgnParticipantStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public CmpgnParticipantStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CmpgnParticipantStatus);
			}
		}

		/// <exclude/>
		public Guid CampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("CampaignItemId");
			}
			set {
				SetColumnValue("CampaignItemId", value);
				_campaignItem = null;
			}
		}

		/// <exclude/>
		public string CampaignItemName {
			get {
				return GetTypedColumnValue<string>("CampaignItemName");
			}
			set {
				SetColumnValue("CampaignItemName", value);
				if (_campaignItem != null) {
					_campaignItem.Name = value;
				}
			}
		}

		private CampaignItem _campaignItem;
		/// <summary>
		/// Текущий шаг.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = LookupColumnEntities.GetEntity("CampaignItem") as CampaignItem);
			}
		}

		/// <summary>
		/// Дата изменения шага.
		/// </summary>
		public DateTime StepModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("StepModifiedOn");
			}
			set {
				SetColumnValue("StepModifiedOn", value);
			}
		}

		/// <summary>
		/// Дата изменения состояния шага.
		/// </summary>
		public DateTime StepCompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("StepCompletedOn");
			}
			set {
				SetColumnValue("StepCompletedOn", value);
			}
		}

		/// <summary>
		/// Шаг выполнен.
		/// </summary>
		public bool StepCompleted {
			get {
				return GetTypedColumnValue<bool>("StepCompleted");
			}
			set {
				SetColumnValue("StepCompleted", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignParticipant_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignParticipantDeleted", e);
			Inserted += (s, e) => ThrowEvent("CampaignParticipantInserted", e);
			Saving += (s, e) => ThrowEvent("CampaignParticipantSaving", e);
			Validating += (s, e) => ThrowEvent("CampaignParticipantValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignParticipant(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipant_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignParticipant_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignParticipant
	{

		public CampaignParticipant_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignParticipant_CampaignsEventsProcess";
			SchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d42c6b3f-5128-4a5f-9346-557b066db650");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _beforeSavingSubProcess;
		public ProcessFlowElement BeforeSavingSubProcess {
			get {
				return _beforeSavingSubProcess ?? (_beforeSavingSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BeforeSavingSubProcess",
					SchemaElementUId = new Guid("6fa0ffb2-9e88-4795-bc52-b23307b191ca"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignParticipantSaving;
		public ProcessFlowElement CampaignParticipantSaving {
			get {
				return _campaignParticipantSaving ?? (_campaignParticipantSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignParticipantSaving",
					SchemaElementUId = new Guid("d76632a8-a4e3-4eb3-b45d-0e4a089a9821"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _beforeSavingTask;
		public ProcessScriptTask BeforeSavingTask {
			get {
				return _beforeSavingTask ?? (_beforeSavingTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BeforeSavingTask",
					SchemaElementUId = new Guid("554749a0-778c-4a64-b04a-0e13c9a21067"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BeforeSavingTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_7892104b73a246dfa7102186820743b4;
		public ProcessFlowElement EventSubProcess3_7892104b73a246dfa7102186820743b4 {
			get {
				return _eventSubProcess3_7892104b73a246dfa7102186820743b4 ?? (_eventSubProcess3_7892104b73a246dfa7102186820743b4 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_7892104b73a246dfa7102186820743b4",
					SchemaElementUId = new Guid("7892104b-73a2-46df-a710-2186820743b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignParticipantInserted;
		public ProcessFlowElement CampaignParticipantInserted {
			get {
				return _campaignParticipantInserted ?? (_campaignParticipantInserted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignParticipantInserted",
					SchemaElementUId = new Guid("35395012-7e3e-4075-91cb-1b5221a51f76"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _campaignParticipantInsertedScriptTask;
		public ProcessScriptTask CampaignParticipantInsertedScriptTask {
			get {
				return _campaignParticipantInsertedScriptTask ?? (_campaignParticipantInsertedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignParticipantInsertedScriptTask",
					SchemaElementUId = new Guid("0c68692c-a146-4b1f-bc34-2871927f1aa2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CampaignParticipantInsertedScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d;
		public ProcessFlowElement EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d {
			get {
				return _eventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d ?? (_eventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d",
					SchemaElementUId = new Guid("5b90e69f-b268-496b-bfb5-fcb14cb8b50d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _campaignParticipantDeleted;
		public ProcessFlowElement CampaignParticipantDeleted {
			get {
				return _campaignParticipantDeleted ?? (_campaignParticipantDeleted = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "CampaignParticipantDeleted",
					SchemaElementUId = new Guid("8f9265a9-4e36-40bf-91e4-f1d827b69df9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _campaignParticipantDeletedScriptTask;
		public ProcessScriptTask CampaignParticipantDeletedScriptTask {
			get {
				return _campaignParticipantDeletedScriptTask ?? (_campaignParticipantDeletedScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CampaignParticipantDeletedScriptTask",
					SchemaElementUId = new Guid("6dc0c1bc-6fd6-4138-bd6b-8f29064c510f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CampaignParticipantDeletedScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BeforeSavingSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BeforeSavingSubProcess };
			FlowElements[CampaignParticipantSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignParticipantSaving };
			FlowElements[BeforeSavingTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BeforeSavingTask };
			FlowElements[EventSubProcess3_7892104b73a246dfa7102186820743b4.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_7892104b73a246dfa7102186820743b4 };
			FlowElements[CampaignParticipantInserted.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignParticipantInserted };
			FlowElements[CampaignParticipantInsertedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignParticipantInsertedScriptTask };
			FlowElements[EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d };
			FlowElements[CampaignParticipantDeleted.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignParticipantDeleted };
			FlowElements[CampaignParticipantDeletedScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CampaignParticipantDeletedScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BeforeSavingSubProcess":
						break;
					case "CampaignParticipantSaving":
						e.Context.QueueTasks.Enqueue("BeforeSavingTask");
						break;
					case "BeforeSavingTask":
						break;
					case "EventSubProcess3_7892104b73a246dfa7102186820743b4":
						break;
					case "CampaignParticipantInserted":
						e.Context.QueueTasks.Enqueue("CampaignParticipantInsertedScriptTask");
						break;
					case "CampaignParticipantInsertedScriptTask":
						break;
					case "EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d":
						break;
					case "CampaignParticipantDeleted":
						e.Context.QueueTasks.Enqueue("CampaignParticipantDeletedScriptTask");
						break;
					case "CampaignParticipantDeletedScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("CampaignParticipantSaving");
			ActivatedEventElements.Add("CampaignParticipantInserted");
			ActivatedEventElements.Add("CampaignParticipantDeleted");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BeforeSavingSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "CampaignParticipantSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignParticipantSaving";
					result = CampaignParticipantSaving.Execute(context);
					break;
				case "BeforeSavingTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BeforeSavingTask";
					result = BeforeSavingTask.Execute(context, BeforeSavingTaskExecute);
					break;
				case "EventSubProcess3_7892104b73a246dfa7102186820743b4":
					context.QueueTasks.Dequeue();
					break;
				case "CampaignParticipantInserted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignParticipantInserted";
					result = CampaignParticipantInserted.Execute(context);
					break;
				case "CampaignParticipantInsertedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignParticipantInsertedScriptTask";
					result = CampaignParticipantInsertedScriptTask.Execute(context, CampaignParticipantInsertedScriptTaskExecute);
					break;
				case "EventSubProcess4_5b90e69fb268496bbfb5fcb14cb8b50d":
					context.QueueTasks.Dequeue();
					break;
				case "CampaignParticipantDeleted":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignParticipantDeleted";
					result = CampaignParticipantDeleted.Execute(context);
					break;
				case "CampaignParticipantDeletedScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CampaignParticipantDeletedScriptTask";
					result = CampaignParticipantDeletedScriptTask.Execute(context, CampaignParticipantDeletedScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BeforeSavingTaskExecute(ProcessExecutingContext context) {
			BeforeSaving();
			return true;
		}

		public virtual bool CampaignParticipantInsertedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateParticipantsCount(1);
			return true;
		}

		public virtual bool CampaignParticipantDeletedScriptTaskExecute(ProcessExecutingContext context) {
			UpdateParticipantsCount(-1);
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "CampaignParticipantSaving":
							if (ActivatedEventElements.Contains("CampaignParticipantSaving")) {
							context.QueueTasks.Enqueue("CampaignParticipantSaving");
						}
						break;
					case "CampaignParticipantInserted":
							if (ActivatedEventElements.Contains("CampaignParticipantInserted")) {
							context.QueueTasks.Enqueue("CampaignParticipantInserted");
						}
						break;
					case "CampaignParticipantDeleted":
							if (ActivatedEventElements.Contains("CampaignParticipantDeleted")) {
							context.QueueTasks.Enqueue("CampaignParticipantDeleted");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipant_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignParticipant_CampaignsEventsProcess : CampaignParticipant_CampaignsEventsProcess<CampaignParticipant>
	{

		public CampaignParticipant_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignParticipant_CampaignsEventsProcess

	public partial class CampaignParticipant_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void BeforeSaving() {
			var changedValues = Entity.GetChangedColumnValues().ToArray();
			bool isStepCompleted = Entity.GetTypedColumnValue<bool>("StepCompleted");
			bool isStepCompletedChanged = changedValues.Any(x => x.Name == "StepCompleted");
			bool isCampaignItemChanged = changedValues.Any(x => x.Name == "CampaignItemId");
			if (isStepCompletedChanged) {
				if (isStepCompleted) {
					Entity.SetColumnValue("StepCompletedOn", DateTime.UtcNow);
				} else {
					Entity.SetColumnValue("StepCompletedOn", null);
				}
			}
			if (isCampaignItemChanged) {
				Entity.SetColumnValue("StepModifiedOn", DateTime.UtcNow);
			}
		}

		public virtual void UpdateParticipantsCount(int intCount) {
			Guid campaignId = Entity.GetTypedColumnValue<Guid>("CampaignId");
			if (campaignId == Guid.Empty) {
				return;
			}
			var update = new Update(UserConnection, "Campaign")
				.Set("ModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("ModifiedById", Column.Parameter(UserConnection.CurrentUser.ContactId))
				.Set("TargetTotal", QueryColumnExpression.Add(new QueryColumnExpression("TargetTotal"),
					Column.Parameter(intCount)))
				.Where("Id").IsEqual(Column.Parameter(campaignId)) as Update;
			update.WithHints(new RowLockHint());
			var participantStatusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			if (participantStatusId == CampaignConstants.CampaignParticipantReachedGoalStatusId) {
				update.Set("TargetAchieve", QueryColumnExpression.Add(new QueryColumnExpression("TargetAchieve"),
					Column.Parameter(intCount)));
			}
			
			update.Execute();
		}

		#endregion

	}

	#endregion


	#region Class: CampaignParticipantEventsProcess

	/// <exclude/>
	public class CampaignParticipantEventsProcess : CampaignParticipant_CampaignsEventsProcess
	{

		public CampaignParticipantEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

