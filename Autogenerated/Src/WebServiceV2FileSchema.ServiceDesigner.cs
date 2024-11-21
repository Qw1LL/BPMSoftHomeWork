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

	#region Class: WebServiceV2FileSchema

	/// <exclude/>
	public class WebServiceV2FileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public WebServiceV2FileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceV2FileSchema(WebServiceV2FileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceV2FileSchema(WebServiceV2FileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			RealUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			Name = "WebServiceV2File";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9a41e39e-51c2-4a16-b81f-aa6773013744");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d8ccf516-dd47-46ae-b782-c63265455c6d")) == null) {
				Columns.Add(CreateWebServiceV2Column());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.IsIndexed = true;
			column.ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWebServiceV2Column() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d8ccf516-dd47-46ae-b782-c63265455c6d"),
				Name = @"WebServiceV2",
				ReferenceSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab"),
				ModifiedInSchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab"),
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
			return new WebServiceV2File(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceV2File_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceV2FileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceV2FileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2File

	/// <summary>
	/// Web Services attachment.
	/// </summary>
	public class WebServiceV2File : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public WebServiceV2File(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2File";
		}

		public WebServiceV2File(WebServiceV2File source)
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
			var process = new WebServiceV2File_ServiceDesignerEventsProcess(UserConnection);
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
			return new WebServiceV2File(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2File_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceV2File_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : WebServiceV2File
	{

		public WebServiceV2File_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceV2File_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c13bf9f0-e1a7-4cb5-bd58-378770f615ab");
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

	#region Class: WebServiceV2File_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceV2File_ServiceDesignerEventsProcess : WebServiceV2File_ServiceDesignerEventsProcess<WebServiceV2File>
	{

		public WebServiceV2File_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceV2File_ServiceDesignerEventsProcess

	public partial class WebServiceV2File_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceV2FileEventsProcess

	/// <exclude/>
	public class WebServiceV2FileEventsProcess : WebServiceV2File_ServiceDesignerEventsProcess
	{

		public WebServiceV2FileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

