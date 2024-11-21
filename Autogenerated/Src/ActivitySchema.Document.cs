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

	#region Class: Activity_Document_BPMSoftSchema

	/// <exclude/>
	public class Activity_Document_BPMSoftSchema : BPMSoft.Configuration.Activity_Order_BPMSoftSchema
	{

		#region Constructors: Public

		public Activity_Document_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Activity_Document_BPMSoftSchema(Activity_Document_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Activity_Document_BPMSoftSchema(Activity_Document_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("9def317f-f0bd-43bd-ba68-e0f32f7d6fcd");
			Name = "Activity_Document_BPMSoft";
			ParentSchemaUId = new Guid("c449d832-a4cc-4b01-b9d5-8a12c42a9f89");
			ExtendParent = true;
			CreatedInPackageId = new Guid("ecb9183e-8414-48fe-a3b3-73f360e276c8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f6137557-741e-42f8-8bf6-69b2524a83f7")) == null) {
				Columns.Add(CreateDocumentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDocumentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f6137557-741e-42f8-8bf6-69b2524a83f7"),
				Name = @"Document",
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9def317f-f0bd-43bd-ba68-e0f32f7d6fcd"),
				ModifiedInSchemaUId = new Guid("9def317f-f0bd-43bd-ba68-e0f32f7d6fcd"),
				CreatedInPackageId = new Guid("ecb9183e-8414-48fe-a3b3-73f360e276c8")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Activity_Document_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Activity_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Activity_Document_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Activity_Document_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9def317f-f0bd-43bd-ba68-e0f32f7d6fcd"));
		}

		#endregion

	}

	#endregion

	#region Class: Activity_Document_BPMSoft

	/// <summary>
	/// Активность.
	/// </summary>
	public class Activity_Document_BPMSoft : BPMSoft.Configuration.Activity_Order_BPMSoft
	{

		#region Constructors: Public

		public Activity_Document_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Activity_Document_BPMSoft";
		}

		public Activity_Document_BPMSoft(Activity_Document_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DocumentId {
			get {
				return GetTypedColumnValue<Guid>("DocumentId");
			}
			set {
				SetColumnValue("DocumentId", value);
				_document = null;
			}
		}

		/// <exclude/>
		public string DocumentNumber {
			get {
				return GetTypedColumnValue<string>("DocumentNumber");
			}
			set {
				SetColumnValue("DocumentNumber", value);
				if (_document != null) {
					_document.Number = value;
				}
			}
		}

		private Document _document;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document Document {
			get {
				return _document ??
					(_document = LookupColumnEntities.GetEntity("Document") as Document);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Activity_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Activity_Document_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Activity_Document_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Activity_DocumentEventsProcess

	/// <exclude/>
	public partial class Activity_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.Activity_OrderEventsProcess<TEntity> where TEntity : Activity_Document_BPMSoft
	{

		public Activity_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Activity_DocumentEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9def317f-f0bd-43bd-ba68-e0f32f7d6fcd");
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

	#region Class: Activity_DocumentEventsProcess

	/// <exclude/>
	public class Activity_DocumentEventsProcess : Activity_DocumentEventsProcess<Activity_Document_BPMSoft>
	{

		public Activity_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Activity_DocumentEventsProcess

	public partial class Activity_DocumentEventsProcess<TEntity>
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

