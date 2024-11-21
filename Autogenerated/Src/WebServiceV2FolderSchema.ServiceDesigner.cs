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

	#region Class: WebServiceV2FolderSchema

	/// <exclude/>
	public class WebServiceV2FolderSchema : BPMSoft.Configuration.BaseFolderSchema
	{

		#region Constructors: Public

		public WebServiceV2FolderSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceV2FolderSchema(WebServiceV2FolderSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceV2FolderSchema(WebServiceV2FolderSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			RealUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			Name = "WebServiceV2Folder";
			ParentSchemaUId = new Guid("d602bf96-d029-4b07-9755-63c8f5cb5ed5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a41e39e-51c2-4a16-b81f-aa6773013744");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ReferenceSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			column.ColumnValueName = @"ParentId";
			column.DisplayColumnValueName = @"ParentName";
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateFolderTypeColumn() {
			EntitySchemaColumn column = base.CreateFolderTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"9dc5f6e6-2a61-4de8-a059-de30f4e74f24"
			};
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceV2Folder(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceV2Folder_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceV2FolderSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceV2FolderSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2Folder

	/// <summary>
	/// Web Services folder.
	/// </summary>
	public class WebServiceV2Folder : BPMSoft.Configuration.BaseFolder
	{

		#region Constructors: Public

		public WebServiceV2Folder(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2Folder";
		}

		public WebServiceV2Folder(WebServiceV2Folder source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentName {
			get {
				return GetTypedColumnValue<string>("ParentName");
			}
			set {
				SetColumnValue("ParentName", value);
				if (_parent != null) {
					_parent.Name = value;
				}
			}
		}

		private WebServiceV2Folder _parent;
		/// <summary>
		/// Parent.
		/// </summary>
		public WebServiceV2Folder Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as WebServiceV2Folder);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceV2Folder_ServiceDesignerEventsProcess(UserConnection);
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
			return new WebServiceV2Folder(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2Folder_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceV2Folder_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseFolder_BaseEventsProcess<TEntity> where TEntity : WebServiceV2Folder
	{

		public WebServiceV2Folder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceV2Folder_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ffe2b42c-41bd-4eb7-93a1-23c3be93b4f4");
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

	#region Class: WebServiceV2Folder_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceV2Folder_ServiceDesignerEventsProcess : WebServiceV2Folder_ServiceDesignerEventsProcess<WebServiceV2Folder>
	{

		public WebServiceV2Folder_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceV2Folder_ServiceDesignerEventsProcess

	public partial class WebServiceV2Folder_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceV2FolderEventsProcess

	/// <exclude/>
	public class WebServiceV2FolderEventsProcess : WebServiceV2Folder_ServiceDesignerEventsProcess
	{

		public WebServiceV2FolderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

