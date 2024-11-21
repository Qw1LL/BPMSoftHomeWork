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

	#region Class: Activity_EmailMining_BPMSoftSchema

	/// <exclude/>
	public class Activity_EmailMining_BPMSoftSchema : BPMSoft.Configuration.Activity_OmnichannelMessaging_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_EmailMining_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_EmailMining_BPMSoftSchema(Activity_EmailMining_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_EmailMining_BPMSoftSchema(Activity_EmailMining_BPMSoftSchema source)
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
			RealUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
			Name = "Activity_EmailMining_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ace5b35d-0166-48ca-b2d4-20add837dbbd")) == null) {
				Columns.Add(CreateEnrchEmailDataColumn());
			}
			if (Columns.FindByUId(new Guid("1c44eeca-97e9-4a02-a9a7-fff0eb8a4afb")) == null) {
				Columns.Add(CreateEnrichStatusColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEnrchEmailDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ace5b35d-0166-48ca-b2d4-20add837dbbd"),
				Name = @"EnrchEmailData",
				ReferenceSchemaUId = new Guid("26d5f6ad-8525-4ceb-b3e5-af8fdf2964f6"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("c1529436-dee9-4290-84f1-87386440a2b1")
			};
		}

		protected virtual EntitySchemaColumn CreateEnrichStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("1c44eeca-97e9-4a02-a9a7-fff0eb8a4afb"),
				Name = @"EnrichStatus",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				ModifiedInSchemaUId = new Guid("8a8f2187-7621-4d4b-904d-af660770442d"),
				CreatedInPackageId = new Guid("bae6174e-6d8e-4782-b180-300a95031ded")
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
			return new Activity_EmailMining_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_EmailMiningEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_EmailMining_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_EmailMining_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8a8f2187-7621-4d4b-904d-af660770442d"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_EmailMining_BPMSoft

	/// <summary>
	/// Activity.
	/// </summary>
	public class Activity_EmailMining_BPMSoft : BPMSoft.Configuration.Activity_OmnichannelMessaging_BPMSoft
	{

		#region Constructors: Public

		public Activity_EmailMining_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_EmailMining_BPMSoft";
		}

		public Activity_EmailMining_BPMSoft(Activity_EmailMining_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EnrchEmailDataId {
			get {
				return GetTypedColumnValue<Guid>("EnrchEmailDataId");
			}
			set {
				SetColumnValue("EnrchEmailDataId", value);
				_enrchEmailData = null;
			}
		}

		/// <exclude/>
		public string EnrchEmailDataHash {
			get {
				return GetTypedColumnValue<string>("EnrchEmailDataHash");
			}
			set {
				SetColumnValue("EnrchEmailDataHash", value);
				if (_enrchEmailData != null) {
					_enrchEmailData.Hash = value;
				}
			}
		}

		private EnrchEmailData _enrchEmailData;
		/// <summary>
		/// Parsed e-mail.
		/// </summary>
		public EnrchEmailData EnrchEmailData {
			get {
				return _enrchEmailData ??
					(_enrchEmailData = LookupColumnEntities.GetEntity("EnrchEmailData") as EnrchEmailData);
			}
		}

		/// <summary>
		/// Enrichment status.
		/// </summary>
		public string EnrichStatus {
			get {
				return GetTypedColumnValue<string>("EnrichStatus");
			}
			set {
				SetColumnValue("EnrichStatus", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_EmailMiningEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_EmailMining_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_EmailMining_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_EmailMiningEventsProcess

	/// <exclude/>
	public partial class Activity_EmailMiningEventsProcess<TEntity> : BPMSoft.Configuration.Activity_OmnichannelMessagingEventsProcess<TEntity> where TEntity : Activity_EmailMining_BPMSoft
	{

		public Activity_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_EmailMiningEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8a8f2187-7621-4d4b-904d-af660770442d");
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

	#region Class: Activity_EmailMiningEventsProcess

	/// <exclude/>
	public class Activity_EmailMiningEventsProcess : Activity_EmailMiningEventsProcess<Activity_EmailMining_BPMSoft>
	{

		public Activity_EmailMiningEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_EmailMiningEventsProcess

	public partial class Activity_EmailMiningEventsProcess<TEntity>
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

		#endregion

	}

	#endregion

}

