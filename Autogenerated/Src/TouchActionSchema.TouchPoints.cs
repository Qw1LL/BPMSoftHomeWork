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

	#region Class: TouchActionSchema

	/// <exclude/>
	public class TouchActionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public TouchActionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TouchActionSchema(TouchActionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TouchActionSchema(TouchActionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001");
			RealUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001");
			Name = "TouchAction";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("34389d8a-4b75-1453-2495-054c21e98ccb")) == null) {
				Columns.Add(CreateTouchColumn());
			}
			if (Columns.FindByUId(new Guid("05f7c1d5-8882-0a3c-430a-f3104b547410")) == null) {
				Columns.Add(CreateActionDateColumn());
			}
			if (Columns.FindByUId(new Guid("846fe615-a52c-b1a0-073c-43091088440b")) == null) {
				Columns.Add(CreateTitleColumn());
			}
			if (Columns.FindByUId(new Guid("ee7d6ccc-bbb0-f3cc-00a3-08c88a47702a")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("daeca7b7-4683-940f-13a0-9f04027a4452")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("2e0922e7-c9f0-b2e4-6710-8b1aac320c3a")) == null) {
				Columns.Add(CreateActionIdColumn());
			}
			if (Columns.FindByUId(new Guid("34e5ede1-dbba-8144-08af-f058dc057890")) == null) {
				Columns.Add(CreateTypeStrColumn());
			}
			if (Columns.FindByUId(new Guid("6b6c27d1-4a18-f273-5fcb-f1dedbb365bb")) == null) {
				Columns.Add(CreateWebPageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateTouchColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("34389d8a-4b75-1453-2495-054c21e98ccb"),
				Name = @"Touch",
				ReferenceSchemaUId = new Guid("6895c8a8-7407-460a-90ec-5e5bfbda0fda"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateActionDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("05f7c1d5-8882-0a3c-430a-f3104b547410"),
				Name = @"ActionDate",
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("846fe615-a52c-b1a0-073c-43091088440b"),
				Name = @"Title",
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("ee7d6ccc-bbb0-f3cc-00a3-08c88a47702a"),
				Name = @"Url",
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("daeca7b7-4683-940f-13a0-9f04027a4452"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("480fa5f1-106f-4df5-9e1a-987204c8e9e9"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("02115f37-84dc-464a-87f1-bcad70c08759")
			};
		}

		protected virtual EntitySchemaColumn CreateActionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2e0922e7-c9f0-b2e4-6710-8b1aac320c3a"),
				Name = @"ActionId",
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("b36411dc-e625-47bc-a04c-4ecbee23a96d")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeStrColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("34e5ede1-dbba-8144-08af-f058dc057890"),
				Name = @"TypeStr",
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a")
			};
		}

		protected virtual EntitySchemaColumn CreateWebPageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b6c27d1-4a18-f273-5fcb-f1dedbb365bb"),
				Name = @"WebPage",
				ReferenceSchemaUId = new Guid("7f41275e-3fa6-46ab-98cb-ad5172ed5eb7"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				ModifiedInSchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"),
				CreatedInPackageId = new Guid("adeef8c7-14f0-4c40-90a0-5eb424823b07")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new TouchAction(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TouchAction_TouchPointsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TouchActionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TouchActionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001"));
		}

		#endregion

	}

	#endregion

	#region Class: TouchAction

	/// <summary>
	/// Web actions.
	/// </summary>
	public class TouchAction : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public TouchAction(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TouchAction";
		}

		public TouchAction(TouchAction source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid TouchId {
			get {
				return GetTypedColumnValue<Guid>("TouchId");
			}
			set {
				SetColumnValue("TouchId", value);
				_touch = null;
			}
		}

		/// <exclude/>
		public string TouchSessionId {
			get {
				return GetTypedColumnValue<string>("TouchSessionId");
			}
			set {
				SetColumnValue("TouchSessionId", value);
				if (_touch != null) {
					_touch.SessionId = value;
				}
			}
		}

		private Touch _touch;
		/// <summary>
		/// Web session.
		/// </summary>
		public Touch Touch {
			get {
				return _touch ??
					(_touch = LookupColumnEntities.GetEntity("Touch") as Touch);
			}
		}

		/// <summary>
		/// Action start date.
		/// </summary>
		public DateTime ActionDate {
			get {
				return GetTypedColumnValue<DateTime>("ActionDate");
			}
			set {
				SetColumnValue("ActionDate", value);
			}
		}

		/// <summary>
		/// Title.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <summary>
		/// Page URL.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private TouchActionType _type;
		/// <summary>
		/// Action type.
		/// </summary>
		public TouchActionType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as TouchActionType);
			}
		}

		/// <summary>
		/// User action identifier.
		/// </summary>
		public string ActionId {
			get {
				return GetTypedColumnValue<string>("ActionId");
			}
			set {
				SetColumnValue("ActionId", value);
			}
		}

		/// <summary>
		/// Type (string).
		/// </summary>
		public string TypeStr {
			get {
				return GetTypedColumnValue<string>("TypeStr");
			}
			set {
				SetColumnValue("TypeStr", value);
			}
		}

		/// <exclude/>
		public Guid WebPageId {
			get {
				return GetTypedColumnValue<Guid>("WebPageId");
			}
			set {
				SetColumnValue("WebPageId", value);
				_webPage = null;
			}
		}

		/// <exclude/>
		public string WebPageName {
			get {
				return GetTypedColumnValue<string>("WebPageName");
			}
			set {
				SetColumnValue("WebPageName", value);
				if (_webPage != null) {
					_webPage.Name = value;
				}
			}
		}

		private WebPage _webPage;
		/// <summary>
		/// Web page.
		/// </summary>
		public WebPage WebPage {
			get {
				return _webPage ??
					(_webPage = LookupColumnEntities.GetEntity("WebPage") as WebPage);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TouchAction_TouchPointsEventsProcess(UserConnection);
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
			return new TouchAction(this);
		}

		#endregion

	}

	#endregion

	#region Class: TouchAction_TouchPointsEventsProcess

	/// <exclude/>
	public partial class TouchAction_TouchPointsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : TouchAction
	{

		public TouchAction_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TouchAction_TouchPointsEventsProcess";
			SchemaUId = new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c6ab21fb-e1e1-442c-879b-33eafc715001");
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

	#region Class: TouchAction_TouchPointsEventsProcess

	/// <exclude/>
	public class TouchAction_TouchPointsEventsProcess : TouchAction_TouchPointsEventsProcess<TouchAction>
	{

		public TouchAction_TouchPointsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TouchAction_TouchPointsEventsProcess

	public partial class TouchAction_TouchPointsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TouchActionEventsProcess

	/// <exclude/>
	public class TouchActionEventsProcess : TouchAction_TouchPointsEventsProcess
	{

		public TouchActionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

