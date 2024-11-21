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

	#region Class: WebServiceV2InFolderSchema

	/// <exclude/>
	public class WebServiceV2InFolderSchema : BPMSoft.Configuration.BaseItemInFolderSchema
	{

		#region Constructors: Public

		public WebServiceV2InFolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceV2InFolderSchema(WebServiceV2InFolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceV2InFolderSchema(WebServiceV2InFolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			RealUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			Name = "WebServiceV2InFolder";
			ParentSchemaUId = new Guid("4f63bafb-e9e7-4082-b92e-66b97c14017c");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a41e39e-51c2-4a16-b81f-aa6773013744");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3e756ac0-7b3c-40af-b87f-4b5a706e6eda")) == null) {
				Columns.Add(CreateWebServiceV2Column());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderColumn() {
			EntitySchemaColumn column = base.CreateFolderColumn();
			column.ReferenceSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			column.ColumnValueName = @"FolderId";
			column.DisplayColumnValueName = @"FolderName";
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWebServiceV2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3e756ac0-7b3c-40af-b87f-4b5a706e6eda"),
				Name = @"WebServiceV2",
				ReferenceSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48"),
				ModifiedInSchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48"),
				CreatedInPackageId = new Guid("9a41e39e-51c2-4a16-b81f-aa6773013744")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceV2InFolder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceV2InFolder_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceV2InFolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceV2InFolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2InFolder

	/// <summary>
	/// Web Services in Folder.
	/// </summary>
	public class WebServiceV2InFolder : BPMSoft.Configuration.BaseItemInFolder
	{

		#region Constructors: Public

		public WebServiceV2InFolder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2InFolder";
		}

		public WebServiceV2InFolder(WebServiceV2InFolder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid WebServiceV2Id {
			get {
				return GetTypedColumnValue<Guid>("WebServiceV2Id");
			}
			set {
				SetColumnValue("WebServiceV2Id", value);
				_webServiceV2 = null;
			}
		}

		/// <exclude/>
		public string WebServiceV2Caption {
			get {
				return GetTypedColumnValue<string>("WebServiceV2Caption");
			}
			set {
				SetColumnValue("WebServiceV2Caption", value);
				if (_webServiceV2 != null) {
					_webServiceV2.Caption = value;
				}
			}
		}

		private VwWebServiceV2 _webServiceV2;
		/// <summary>
		/// Web Services.
		/// </summary>
		public VwWebServiceV2 WebServiceV2 {
			get {
				return _webServiceV2 ??
					(_webServiceV2 = LookupColumnEntities.GetEntity("WebServiceV2") as VwWebServiceV2);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceV2InFolder_ServiceDesignerEventsProcess(UserConnection);
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
			return new WebServiceV2InFolder(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2InFolder_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceV2InFolder_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseItemInFolder_BaseEventsProcess<TEntity> where TEntity : WebServiceV2InFolder
	{

		public WebServiceV2InFolder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceV2InFolder_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab5bda14-940a-49fe-966d-5eb2ac012e48");
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

	#region Class: WebServiceV2InFolder_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceV2InFolder_ServiceDesignerEventsProcess : WebServiceV2InFolder_ServiceDesignerEventsProcess<WebServiceV2InFolder>
	{

		public WebServiceV2InFolder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceV2InFolder_ServiceDesignerEventsProcess

	public partial class WebServiceV2InFolder_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceV2InFolderEventsProcess

	/// <exclude/>
	public class WebServiceV2InFolderEventsProcess : WebServiceV2InFolder_ServiceDesignerEventsProcess
	{

		public WebServiceV2InFolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

