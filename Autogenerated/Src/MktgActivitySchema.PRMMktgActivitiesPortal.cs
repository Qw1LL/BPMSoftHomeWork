namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: MktgActivitySchema

	/// <exclude/>
	public class MktgActivitySchema : BPMSoft.Configuration.MktgActivity_MktgActivitiesPortal_BPMSoftSchema
	{

		#region Constructors: Public

		public MktgActivitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivitySchema(MktgActivitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivitySchema(MktgActivitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f");
			Name = "MktgActivity";
			ParentSchemaUId = new Guid("8cd7510b-6e4b-487a-8c2b-d0289eaed375");
			ExtendParent = true;
			CreatedInPackageId = new Guid("953f0566-aec2-4fe6-ac9c-5286e561cdf9");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("cf6f0088-cc8d-4ae0-b517-addc004002e2")) == null) {
				Columns.Add(CreateFundColumn());
			}
			if (Columns.FindByUId(new Guid("48a97155-5010-41e8-b3cb-b2e366981c92")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("5d0b3a58-4023-440b-b768-1086b6e9f3c2")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("522ac49d-b3c7-4af2-ba8b-cc13b08806d6")) == null) {
				Columns.Add(CreatePartnershipColumn());
			}
			if (Columns.FindByUId(new Guid("075afd76-e166-4ea3-a4e6-7babe79a78d6")) == null) {
				Columns.Add(CreateAccountColumn());
			}
		}

		protected override EntitySchemaColumn CreateSpentBudgetColumn() {
			EntitySchemaColumn column = base.CreateSpentBudgetColumn();
			column.IsValueCloneable = false;
			column.ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f");
			return column;
		}

		protected override EntitySchemaColumn CreatePrimarySpentBudgetColumn() {
			EntitySchemaColumn column = base.CreatePrimarySpentBudgetColumn();
			column.IsValueCloneable = false;
			column.ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFundColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("cf6f0088-cc8d-4ae0-b517-addc004002e2"),
				Name = @"Fund",
				ReferenceSchemaUId = new Guid("9a734110-378e-4108-9383-726930984f2e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				CreatedInPackageId = new Guid("953f0566-aec2-4fe6-ac9c-5286e561cdf9")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("48a97155-5010-41e8-b3cb-b2e366981c92"),
				Name = @"Url",
				CreatedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				CreatedInPackageId = new Guid("953f0566-aec2-4fe6-ac9c-5286e561cdf9")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("5d0b3a58-4023-440b-b768-1086b6e9f3c2"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				CreatedInPackageId = new Guid("be128478-78b2-4e0c-970c-9dfa8eab194e")
			};
		}

		protected virtual EntitySchemaColumn CreatePartnershipColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("522ac49d-b3c7-4af2-ba8b-cc13b08806d6"),
				Name = @"Partnership",
				ReferenceSchemaUId = new Guid("f247949a-7c07-4fc7-9a6a-31940b457e5d"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				CreatedInPackageId = new Guid("be128478-78b2-4e0c-970c-9dfa8eab194e")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("075afd76-e166-4ea3-a4e6-7babe79a78d6"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				ModifiedInSchemaUId = new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"),
				CreatedInPackageId = new Guid("be128478-78b2-4e0c-970c-9dfa8eab194e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MktgActivity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivity_PRMMktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity

	/// <summary>
	/// PRM портальная маркетинговая активность.
	/// </summary>
	public class MktgActivity : BPMSoft.Configuration.MktgActivity_MktgActivitiesPortal_BPMSoft
	{

		#region Constructors: Public

		public MktgActivity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivity";
		}

		public MktgActivity(MktgActivity source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid FundId {
			get {
				return GetTypedColumnValue<Guid>("FundId");
			}
			set {
				SetColumnValue("FundId", value);
				_fund = null;
			}
		}

		/// <exclude/>
		public string FundName {
			get {
				return GetTypedColumnValue<string>("FundName");
			}
			set {
				SetColumnValue("FundName", value);
				if (_fund != null) {
					_fund.Name = value;
				}
			}
		}

		private Fund _fund;
		/// <summary>
		/// Фонд.
		/// </summary>
		public Fund Fund {
			get {
				return _fund ??
					(_fund = LookupColumnEntities.GetEntity("Fund") as Fund);
			}
		}

		/// <summary>
		/// Ссылка на мероприятие.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// Описание.
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
		public Guid PartnershipId {
			get {
				return GetTypedColumnValue<Guid>("PartnershipId");
			}
			set {
				SetColumnValue("PartnershipId", value);
				_partnership = null;
			}
		}

		/// <exclude/>
		public string PartnershipName {
			get {
				return GetTypedColumnValue<string>("PartnershipName");
			}
			set {
				SetColumnValue("PartnershipName", value);
				if (_partnership != null) {
					_partnership.Name = value;
				}
			}
		}

		private Partnership _partnership;
		/// <summary>
		/// Партнерство.
		/// </summary>
		public Partnership Partnership {
			get {
				return _partnership ??
					(_partnership = LookupColumnEntities.GetEntity("Partnership") as Partnership);
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
		/// Партнер.
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
			var process = new MktgActivity_PRMMktgActivitiesPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivityDeleted", e);
			Saved += (s, e) => ThrowEvent("MktgActivitySaved", e);
			Saving += (s, e) => ThrowEvent("MktgActivitySaving", e);
			Validating += (s, e) => ThrowEvent("MktgActivityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivity(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class MktgActivity_PRMMktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.MktgActivity_MktgActivitiesPortalEventsProcess<TEntity> where TEntity : MktgActivity
	{

		public MktgActivity_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivity_PRMMktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("866e74f2-9ede-4e80-8e8b-1f648e77759f");
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
					SchemaElementUId = new Guid("c02d20ae-acfc-49c4-97e0-38d4cbfe333e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mktgActivitySaving;
		public ProcessFlowElement MktgActivitySaving {
			get {
				return _mktgActivitySaving ?? (_mktgActivitySaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MktgActivitySaving",
					SchemaElementUId = new Guid("cf4be27e-ee73-4471-be88-66f6d9e870e0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediate_MktgActivitySaving;
		public ProcessThrowMessageEvent Intermediate_MktgActivitySaving {
			get {
				return _intermediate_MktgActivitySaving ?? (_intermediate_MktgActivitySaving = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "Intermediate_MktgActivitySaving",
					SchemaElementUId = new Guid("cfd73624-234a-427a-a138-77589a1495c8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "MktgActivitySaving",
						ThrowToBase = true,
				});
			}
		}

		private ProcessScriptTask _fillPartnershipsScriptTask;
		public ProcessScriptTask FillPartnershipsScriptTask {
			get {
				return _fillPartnershipsScriptTask ?? (_fillPartnershipsScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FillPartnershipsScriptTask",
					SchemaElementUId = new Guid("0d985c65-ec93-4df2-a528-d28978135c39"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = FillPartnershipsScriptTaskExecute,
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
					SchemaElementUId = new Guid("0f47ebea-a462-4d1f-afbf-48a1339da4a7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _mktgActivitySaved;
		public ProcessFlowElement MktgActivitySaved {
			get {
				return _mktgActivitySaved ?? (_mktgActivitySaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "MktgActivitySaved",
					SchemaElementUId = new Guid("4b852caf-1e50-405e-aeb4-cbc0b91fe489"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateMarketingActivities;
		public ProcessScriptTask UpdateMarketingActivities {
			get {
				return _updateMarketingActivities ?? (_updateMarketingActivities = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateMarketingActivities",
					SchemaElementUId = new Guid("ac6747b1-421d-47f1-ac62-d2ae6f2661c2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateMarketingActivitiesExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _intermediate_MktgActivitySaved;
		public ProcessThrowMessageEvent Intermediate_MktgActivitySaved {
			get {
				return _intermediate_MktgActivitySaved ?? (_intermediate_MktgActivitySaved = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "Intermediate_MktgActivitySaved",
					SchemaElementUId = new Guid("8f344669-6eaa-48de-b720-a98c53234297"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "MktgActivitySaved",
						ThrowToBase = true,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[MktgActivitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { MktgActivitySaving };
			FlowElements[Intermediate_MktgActivitySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { Intermediate_MktgActivitySaving };
			FlowElements[FillPartnershipsScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FillPartnershipsScriptTask };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[MktgActivitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { MktgActivitySaved };
			FlowElements[UpdateMarketingActivities.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateMarketingActivities };
			FlowElements[Intermediate_MktgActivitySaved.SchemaElementUId] = new Collection<ProcessFlowElement> { Intermediate_MktgActivitySaved };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "MktgActivitySaving":
						e.Context.QueueTasks.Enqueue("FillPartnershipsScriptTask");
						break;
					case "Intermediate_MktgActivitySaving":
						break;
					case "FillPartnershipsScriptTask":
						e.Context.QueueTasks.Enqueue("Intermediate_MktgActivitySaving");
						break;
					case "EventSubProcess2":
						break;
					case "MktgActivitySaved":
						e.Context.QueueTasks.Enqueue("UpdateMarketingActivities");
						break;
					case "UpdateMarketingActivities":
						e.Context.QueueTasks.Enqueue("Intermediate_MktgActivitySaved");
						break;
					case "Intermediate_MktgActivitySaved":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("MktgActivitySaving");
			ActivatedEventElements.Add("MktgActivitySaved");
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
				case "MktgActivitySaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "MktgActivitySaving";
					result = MktgActivitySaving.Execute(context);
					break;
				case "Intermediate_MktgActivitySaving":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "MktgActivitySaving");
					result = Intermediate_MktgActivitySaving.Execute(context);
					break;
				case "FillPartnershipsScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "FillPartnershipsScriptTask";
					result = FillPartnershipsScriptTask.Execute(context, FillPartnershipsScriptTaskExecute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "MktgActivitySaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "MktgActivitySaved";
					result = MktgActivitySaved.Execute(context);
					break;
				case "UpdateMarketingActivities":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateMarketingActivities";
					result = UpdateMarketingActivities.Execute(context, UpdateMarketingActivitiesExecute);
					break;
				case "Intermediate_MktgActivitySaved":
					context.QueueTasks.Dequeue();
					base.ThrowEvent(context, "MktgActivitySaved");
					result = Intermediate_MktgActivitySaved.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool FillPartnershipsScriptTaskExecute(ProcessExecutingContext context) {
			bool isSSPConnection = UserConnection is SSPUserConnection;
			Guid partnershipId = Entity.GetTypedColumnValue<Guid>("PartnershipId");
			if(isSSPConnection && (Guid.Empty.Equals(partnershipId) || partnershipId == null)) {
				Guid newPartnershipId = GetPartnershipId();
				if(!Guid.Empty.Equals(newPartnershipId)) {
					Entity.SetColumnValue("PartnershipId", newPartnershipId);
				}	
			}
			return true;
		}

		public virtual bool UpdateMarketingActivitiesExecute(ProcessExecutingContext context) {
			bool isSSPConnection = UserConnection is SSPUserConnection;
			Guid partnershipId = Entity.GetTypedColumnValue<Guid>("PartnershipId");
			Guid currentStatusId = Entity.GetTypedColumnValue<Guid>("StatusId");
			if (!isSSPConnection && currentStatusId.Equals(PRMBaseConstants.ApprovedStatusId)){
				var marketingActivitiesCountSelect = GetMarketingActivityCountSelect(partnershipId, PRMBaseConstants.ApprovedStatusId);
				Dictionary<string, object> partnershipParameterConditions = new Dictionary<string, object> {
					{ "PartnershipParameterType", PRMBaseConstants.CurrentPartnershipParameterTypeId},
					{ "PartnerParamCategory", PRMBaseConstants.MktgActivityPartnerParamCategoryId},
					{ "Partnership", partnershipId }
				};
				var partnershipParamSchema = UserConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
				var currentPartnershipParamEntity = partnershipParamSchema.CreateEntity(UserConnection);
				if (currentPartnershipParamEntity.FetchFromDB(partnershipParameterConditions)) {
					currentPartnershipParamEntity.SetColumnValue("IntValue", marketingActivitiesCountSelect.ExecuteScalar<int>());
					currentPartnershipParamEntity.Save();
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "MktgActivitySaving":
							if (ActivatedEventElements.Contains("MktgActivitySaving")) {
							context.QueueTasks.Enqueue("MktgActivitySaving");
						}
						break;
					case "MktgActivitySaved":
							if (ActivatedEventElements.Contains("MktgActivitySaved")) {
							context.QueueTasks.Enqueue("MktgActivitySaved");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivity_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class MktgActivity_PRMMktgActivitiesPortalEventsProcess : MktgActivity_PRMMktgActivitiesPortalEventsProcess<MktgActivity>
	{

		public MktgActivity_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivity_PRMMktgActivitiesPortalEventsProcess

	public partial class MktgActivity_PRMMktgActivitiesPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual Guid GetPartnershipId() {
			var partnershipESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Partnership");
			var primaryColumn = partnershipESQ.AddColumn("Id");
			partnershipESQ.Filters.Add(partnershipESQ.CreateFilterWithParameters(FilterComparisonType.Equal, "IsActive", true));
			var entity = partnershipESQ.GetEntityCollection(UserConnection);
			if (entity.Count > 0) {
				return entity[0].GetTypedColumnValue<Guid>(primaryColumn.Name);
			}
			return Guid.Empty;
		}

		public virtual Select GetMarketingActivityCountSelect(Guid partnershipId, Guid approvedStatusId) {
			var marketingActivitiesCountSelect = new Select(UserConnection)
				.Column(Func.Count(Column.Const(1)))
				.From("MktgActivity")
				.Where("PartnershipId")
					.IsEqual(Column.Parameter(partnershipId))
				.And("StatusId")
					.IsEqual(Column.Parameter(approvedStatusId)) as Select;
			return marketingActivitiesCountSelect;
		}

		#endregion

	}

	#endregion


	#region Class: MktgActivityEventsProcess

	/// <exclude/>
	public class MktgActivityEventsProcess : MktgActivity_PRMMktgActivitiesPortalEventsProcess
	{

		public MktgActivityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

