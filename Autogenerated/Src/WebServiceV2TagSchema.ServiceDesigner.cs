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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: WebServiceV2TagSchema

	/// <exclude/>
	public class WebServiceV2TagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public WebServiceV2TagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceV2TagSchema(WebServiceV2TagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceV2TagSchema(WebServiceV2TagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			RealUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			Name = "WebServiceV2Tag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
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
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"8d7f6d6c-4ca5-4b43-bdd9-a5e01a582260"
			};
			column.ModifiedInSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceV2Tag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceV2Tag_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceV2TagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceV2TagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2Tag

	/// <summary>
	/// Web Services section tag.
	/// </summary>
	public class WebServiceV2Tag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public WebServiceV2Tag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2Tag";
		}

		public WebServiceV2Tag(WebServiceV2Tag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceV2Tag_ServiceDesignerEventsProcess(UserConnection);
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
			return new WebServiceV2Tag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2Tag_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceV2Tag_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : WebServiceV2Tag
	{

		public WebServiceV2Tag_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceV2Tag_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
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

	#region Class: WebServiceV2Tag_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceV2Tag_ServiceDesignerEventsProcess : WebServiceV2Tag_ServiceDesignerEventsProcess<WebServiceV2Tag>
	{

		public WebServiceV2Tag_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceV2Tag_ServiceDesignerEventsProcess

	public partial class WebServiceV2Tag_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceV2TagEventsProcess

	/// <exclude/>
	public class WebServiceV2TagEventsProcess : WebServiceV2Tag_ServiceDesignerEventsProcess
	{

		public WebServiceV2TagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

