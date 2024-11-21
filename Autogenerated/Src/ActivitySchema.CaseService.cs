namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Packages.Case;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.Core.Store;
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
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Web;
	using SystemSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: Activity_CaseService_BPMSoftSchema

	/// <exclude/>
	public class Activity_CaseService_BPMSoftSchema : BPMSoft.Configuration.Activity_Case_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_CaseService_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_CaseService_BPMSoftSchema(Activity_CaseService_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_CaseService_BPMSoftSchema(Activity_CaseService_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIX_Activity_SendDateIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("1e60c588-1264-4219-9f83-2a3e68bc54b6");
			index.Name = "IX_Activity_SendDate";
			index.CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			index.CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed");
			EntitySchemaIndexColumn sendDateIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("b8f4292f-5ae6-43ca-9685-1301b31eba68"),
				ColumnUId = new Guid("6689a019-c904-4b25-a89d-d17f3f3767cc"),
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("d931fb95-07c0-4237-ab9a-64ecf34e5aed"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(sendDateIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("940f5ed1-3e44-4f78-8d2a-896cdff50f60");
			Name = "Activity_CaseService_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a8b8271f-5617-41e0-bbb4-0ac43169bb55");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fe3732e9-7b58-4e30-afc3-b121bba13a8c")) == null) {
				Columns.Add(CreateIsNotPublishedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIsNotPublishedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fe3732e9-7b58-4e30-afc3-b121bba13a8c"),
				Name = @"IsNotPublished",
				CreatedInSchemaUId = new Guid("940f5ed1-3e44-4f78-8d2a-896cdff50f60"),
				ModifiedInSchemaUId = new Guid("940f5ed1-3e44-4f78-8d2a-896cdff50f60"),
				CreatedInPackageId = new Guid("3f3b9f1f-d04f-4426-ad64-9acca96812fe")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIX_Activity_SendDateIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_CaseService_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_CaseServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_CaseService_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_CaseService_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("940f5ed1-3e44-4f78-8d2a-896cdff50f60"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CaseService_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_CaseService_BPMSoft : BPMSoft.Configuration.Activity_Case_BPMSoft
	{

		#region Constructors: Public

		public Activity_CaseService_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_CaseService_BPMSoft";
		}

		public Activity_CaseService_BPMSoft(Activity_CaseService_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Не опубликовано.
		/// </summary>
		public bool IsNotPublished {
			get {
				return GetTypedColumnValue<bool>("IsNotPublished");
			}
			set {
				SetColumnValue("IsNotPublished", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_CaseServiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_CaseService_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_CaseServiceEventsProcess

	/// <exclude/>
	public partial class Activity_CaseServiceEventsProcess<TEntity> : BPMSoft.Configuration.Activity_CaseEventsProcess<TEntity> where TEntity : Activity_CaseService_BPMSoft
	{

		public Activity_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_CaseServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("940f5ed1-3e44-4f78-8d2a-896cdff50f60");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _activityUpdatingEventSubProcess1;
		public ProcessFlowElement ActivityUpdatingEventSubProcess1 {
			get {
				return _activityUpdatingEventSubProcess1 ?? (_activityUpdatingEventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "ActivityUpdatingEventSubProcess1",
					SchemaElementUId = new Guid("2b1fe841-bea6-459c-8253-c4a4d0048ec1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityUpdatingStartMessage;
		public ProcessFlowElement ActivityUpdatingStartMessage {
			get {
				return _activityUpdatingStartMessage ?? (_activityUpdatingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityUpdatingStartMessage",
					SchemaElementUId = new Guid("5ec3f798-cf6f-4f34-b4f5-49252580c277"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _activityUpdatingScriptTask;
		public ProcessScriptTask ActivityUpdatingScriptTask {
			get {
				return _activityUpdatingScriptTask ?? (_activityUpdatingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityUpdatingScriptTask",
					SchemaElementUId = new Guid("8f3c45b6-4b5d-4023-88a1-0dc734deb856"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityUpdatingScriptTaskExecute,
				});
			}
		}

		private ProcessScriptTask _activityInsertedStartMessageScriptTask;
		public ProcessScriptTask ActivityInsertedStartMessageScriptTask {
			get {
				return _activityInsertedStartMessageScriptTask ?? (_activityInsertedStartMessageScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ActivityInsertedStartMessageScriptTask",
					SchemaElementUId = new Guid("6d01caa4-acfe-44fc-8a73-fffb39bc00b4"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ActivityInsertedStartMessageScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _activityInsertedStartMessage;
		public ProcessFlowElement ActivityInsertedStartMessage {
			get {
				return _activityInsertedStartMessage ?? (_activityInsertedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityInsertedStartMessage",
					SchemaElementUId = new Guid("b80714b7-fff6-48b5-9b95-4e88352fc1be"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _activityUpdatedStartMessage;
		public ProcessFlowElement ActivityUpdatedStartMessage {
			get {
				return _activityUpdatedStartMessage ?? (_activityUpdatedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "ActivityUpdatedStartMessage",
					SchemaElementUId = new Guid("1f92bc7d-79dd-463b-abef-9632333ab2fa"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask3_27f6989e78934513b0eb72559cae0133;
		public ProcessScriptTask ScriptTask3_27f6989e78934513b0eb72559cae0133 {
			get {
				return _scriptTask3_27f6989e78934513b0eb72559cae0133 ?? (_scriptTask3_27f6989e78934513b0eb72559cae0133 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask3_27f6989e78934513b0eb72559cae0133",
					SchemaElementUId = new Guid("27f6989e-7893-4513-b0eb-72559cae0133"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask3_27f6989e78934513b0eb72559cae0133Execute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[ActivityUpdatingEventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUpdatingEventSubProcess1 };
			FlowElements[ActivityUpdatingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUpdatingStartMessage };
			FlowElements[ActivityUpdatingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUpdatingScriptTask };
			FlowElements[ActivityInsertedStartMessageScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInsertedStartMessageScriptTask };
			FlowElements[ActivityInsertedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityInsertedStartMessage };
			FlowElements[ActivityUpdatedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { ActivityUpdatedStartMessage };
			FlowElements[ScriptTask3_27f6989e78934513b0eb72559cae0133.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask3_27f6989e78934513b0eb72559cae0133 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "ActivityUpdatingEventSubProcess1":
						break;
					case "ActivityUpdatingStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityUpdatingScriptTask");
						break;
					case "ActivityUpdatingScriptTask":
						break;
					case "ActivityInsertedStartMessageScriptTask":
						break;
					case "ActivityInsertedStartMessage":
						e.Context.QueueTasks.Enqueue("ActivityInsertedStartMessageScriptTask");
						break;
					case "ActivityUpdatedStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptTask3_27f6989e78934513b0eb72559cae0133");
						break;
					case "ScriptTask3_27f6989e78934513b0eb72559cae0133":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("ActivityUpdatingStartMessage");
			ActivatedEventElements.Add("ActivityInsertedStartMessage");
			ActivatedEventElements.Add("ActivityUpdatedStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "ActivityUpdatingEventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "ActivityUpdatingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityUpdatingStartMessage";
					result = ActivityUpdatingStartMessage.Execute(context);
					break;
				case "ActivityUpdatingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityUpdatingScriptTask";
					result = ActivityUpdatingScriptTask.Execute(context, ActivityUpdatingScriptTaskExecute);
					break;
				case "ActivityInsertedStartMessageScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityInsertedStartMessageScriptTask";
					result = ActivityInsertedStartMessageScriptTask.Execute(context, ActivityInsertedStartMessageScriptTaskExecute);
					break;
				case "ActivityInsertedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityInsertedStartMessage";
					result = ActivityInsertedStartMessage.Execute(context);
					break;
				case "ActivityUpdatedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "ActivityUpdatedStartMessage";
					result = ActivityUpdatedStartMessage.Execute(context);
					break;
				case "ScriptTask3_27f6989e78934513b0eb72559cae0133":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask3_27f6989e78934513b0eb72559cae0133";
					result = ScriptTask3_27f6989e78934513b0eb72559cae0133.Execute(context, ScriptTask3_27f6989e78934513b0eb72559cae0133Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ActivityUpdatingScriptTaskExecute(ProcessExecutingContext context) {
			var caseId = Entity.GetTypedColumnValue<Guid>("CaseId");
			var activityId = Entity.PrimaryColumnValue;
			if (caseId != Guid.Empty){
				if (UseCategoryFilter()){
					var caseOldId = Entity.GetTypedOldColumnValue<Guid>("CaseId");
					if (caseOldId == Guid.Empty){
						if (IsRequiredFieldsValid(caseId)) {
							SetCaseCategory(caseId, activityId);
						}
					}
				}
				if(Entity.GetTypedColumnValue<bool>("IsNotPublished")){
					Entity.SetColumnValue("IsNotPublished", false);
					var copyUtilityDetail = new CaseEntityFileCopier(UserConnection);
					copyUtilityDetail.CopyAll("Activity", activityId, caseId);
				}
			}
			return true;
		}

		public virtual bool ActivityInsertedStartMessageScriptTaskExecute(ProcessExecutingContext context) {
			var caseId = Entity.GetTypedColumnValue<Guid>("CaseId");
			if(caseId != Guid.Empty){
				NotifyListeners();
			}
			return true;
		}

		public virtual bool ScriptTask3_27f6989e78934513b0eb72559cae0133Execute(ProcessExecutingContext context) {
			var caseId = Entity.GetTypedColumnValue<Guid>("CaseId");
			if(caseId != Guid.Empty && UserConnection.GetIsFeatureEnabled("CanUpdateHistoryMessage")){
				NotifyListeners();
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "ActivityUpdating":
							if (ActivatedEventElements.Contains("ActivityUpdatingStartMessage")) {
							context.QueueTasks.Enqueue("ActivityUpdatingStartMessage");
						}
						break;
					case "ActivityInserted":
							if (ActivatedEventElements.Contains("ActivityInsertedStartMessage")) {
							context.QueueTasks.Enqueue("ActivityInsertedStartMessage");
							ProcessQueue(context);
							return;
						}
						break;
					case "ActivityUpdated":
							if (ActivatedEventElements.Contains("ActivityUpdatedStartMessage")) {
							context.QueueTasks.Enqueue("ActivityUpdatedStartMessage");
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

	#region Class: Activity_CaseServiceEventsProcess

	/// <exclude/>
	public class Activity_CaseServiceEventsProcess : Activity_CaseServiceEventsProcess<Activity_CaseService_BPMSoft>
	{

		public Activity_CaseServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_CaseServiceEventsProcess

	public partial class Activity_CaseServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool OnActivitySaving(ProcessExecutingContext context) {
			var isBaseSavingSuccess = base.OnActivitySaving(context);
			if(isBaseSavingSuccess && Entity.GetTypedColumnValue<Guid>("TypeId") == ActivityConsts.EmailTypeUId) {
				Guid caseValue = Entity.GetTypedColumnValue<Guid>("CaseId");
				Guid caseOldValue = Entity.GetTypedOldColumnValue<Guid>("CaseId");
				if(caseValue != Guid.Empty && caseValue != caseOldValue) {
					var notifier = new EmailMessageNotifier(this.Entity, UserConnection);
					var listener = new CaseMessageListener(UserConnection);
					listener.Update(notifier);
				}
			}
			return isBaseSavingSuccess;
		}

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		public virtual bool UseCategoryFilter() {
			bool getCategoryFromEmail = SystemSettings.GetValue(UserConnection, "DefineCaseCategoryFromMailBox", false);
			return getCategoryFromEmail && UserConnection.GetIsFeatureEnabled("CategoryFromMailBox");
		}

		public virtual bool IsRequiredFieldsValid(Guid caseId) {
			Select selectQuery = new Select(UserConnection)
											.Column("c", "CategoryId")
											.Column("c", "ParentActivityId")
										.From("Case").As("c")
										.Where("c", "Id").IsEqual(Column.Parameter(caseId)) as Select;
			using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExec)) {
					while (reader.Read()) {
						Guid categoryId = reader.GetColumnValue<Guid>("CategoryId");
						Guid parentActivityId = reader.GetColumnValue<Guid>("ParentActivityId");
						if (categoryId == Guid.Empty && parentActivityId == Guid.Empty){
							return true;
						}
					}
				}
			}
			return false;
		}

		public virtual string JoinRecipients(string recipients, string recipient) {
			if (!string.IsNullOrEmpty(recipient)) {
				recipients = string.Join(";", recipients, recipient);
			}
			return recipients;
		}

		public virtual string GetRecipients(Guid activityId) {
			string recipients = string.Empty;
			Select selectQuery = new Select(UserConnection)
									.Column("a", "Recepient")
									.Column("a", "CopyRecepient")
									.Column("a", "BlindCopyRecepient")
									.From("Activity").As("a")
								.Where("a", "Id").IsEqual(Column.Const(activityId)) as Select;
			using (DBExecutor dbExec = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExec)) {
					while (reader.Read()) {
						string recipient = reader.GetColumnValue<string>("Recepient");
						recipients = JoinRecipients(recipients, recipient);
						string copyRecipient = reader.GetColumnValue<string>("CopyRecepient");
						recipients = JoinRecipients(recipients, copyRecipient);
						string blindCopyRecipient = reader.GetColumnValue<string>("BlindCopyRecepient");
						recipients = JoinRecipients(recipients, blindCopyRecipient);
					}
				}
			}
			return recipients;
		}

		public virtual void SetCaseCategory(Guid caseId, Guid activityId) {
			var caseEntity = UserConnection.EntitySchemaManager.GetInstanceByName("Case").CreateEntity(UserConnection);
			caseEntity.FetchFromDB(caseId);
			caseEntity.SetColumnValue("ParentActivityId", activityId);
			string recipients = GetRecipients(activityId);
			CategoryFromSupportMailBox supportMailBoxStore = new CategoryFromSupportMailBox(UserConnection);
			CategoryProvider categoryProvider = new CategoryProvider(supportMailBoxStore);
			CategoryProviderWrapper categoryWrapper = new CategoryProviderWrapper(UserConnection);
			categoryWrapper.CategoryProvider = categoryProvider;
			Guid categoryId = categoryWrapper.GetCategoryFromSupportMailBox(recipients);
			if (categoryId == Guid.Empty){
				categoryId = SystemSettings.GetValue(UserConnection, CaseConsts.DefaultCaseCategory, Guid.Empty);
			}
			if (categoryId != Guid.Empty){
				caseEntity.SetColumnValue("CategoryId", categoryId);
			}
			caseEntity.Save(false);
		}

		#endregion

	}

	#endregion

}

