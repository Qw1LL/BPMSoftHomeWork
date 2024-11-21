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

	#region Class: Activity_EmailMessage_BPMSoftSchema

	/// <exclude/>
	public class Activity_EmailMessage_BPMSoftSchema : BPMSoft.Configuration.Activity_SSP_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_EmailMessage_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_EmailMessage_BPMSoftSchema(Activity_EmailMessage_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_EmailMessage_BPMSoftSchema(Activity_EmailMessage_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("94072efc-e85f-459f-82c6-2ede4736277b");
			Name = "Activity_EmailMessage_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a499c25e-aefb-46a1-8fe8-e468e50cfed2");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_EmailMessage_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_EmailMessageEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_EmailMessage_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_EmailMessage_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("94072efc-e85f-459f-82c6-2ede4736277b"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_EmailMessage_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_EmailMessage_BPMSoft : BPMSoft.Configuration.Activity_SSP_BPMSoft
	{

		#region Constructors: Public

		public Activity_EmailMessage_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_EmailMessage_BPMSoft";
		}

		public Activity_EmailMessage_BPMSoft(Activity_EmailMessage_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_EmailMessageEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_EmailMessage_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_EmailMessage_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_EmailMessageEventsProcess

	/// <exclude/>
	public partial class Activity_EmailMessageEventsProcess<TEntity> : BPMSoft.Configuration.Activity_SSPEventsProcess<TEntity> where TEntity : Activity_EmailMessage_BPMSoft
	{

		public Activity_EmailMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_EmailMessageEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("94072efc-e85f-459f-82c6-2ede4736277b");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_EmailMessageEventsProcess

	/// <exclude/>
	public class Activity_EmailMessageEventsProcess : Activity_EmailMessageEventsProcess<Activity_EmailMessage_BPMSoft>
	{

		public Activity_EmailMessageEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_EmailMessageEventsProcess

	public partial class Activity_EmailMessageEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void PrepereSynchronizeSubjectRemindingUserTask(SynchronizeSubjectRemindingUserTask userTask, Guid contact, DateTime remindTime, bool active, Guid source) {
			base.PrepereSynchronizeSubjectRemindingUserTask(userTask, contact, remindTime, active, source);
			bool isFeatureEnabled = FeatureUtilities.GetIsFeatureEnabled(UserConnection, "NotificationV2");
			if (isFeatureEnabled && active) {
				IRemindingTextFormer textFormer = ClassFactory.Get<ActivityRemindingTextFormer>(
					new ConstructorArgument("userConnection", UserConnection));
				string accountName = GetLookupDisplayColumnValue(Entity, "Account");
				string contactName = GetLookupDisplayColumnValue(Entity, "Contact");
				string title = Entity.GetTypedColumnValue<string>("Title");
				userTask.SubjectCaption = textFormer.GetBody(new Dictionary<string, object> {
					{"AccountName", accountName},
					{"ContactName", contactName},
					{"Title", title}
				});
				userTask.PopupTitle = textFormer.GetTitle(new Dictionary<string, object>());
			}
		}

		public override bool OnActivityInserted(ProcessExecutingContext context) {
			NotifyListeners();
			return base.OnActivityInserted(context);
		}

		public virtual void NotifyListeners() {
			if(Entity.GetTypedColumnValue<Guid>("TypeId") == ActivityConsts.EmailTypeUId) {
				var notifier = new EmailMessageNotifier(this.Entity, UserConnection);
				var manager = new MessageHistoryManager(UserConnection, notifier);
				manager.Notify();
			}
		}

		#endregion

	}

	#endregion

}

