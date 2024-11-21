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

	#region Class: WebServiceV2InTagSchema

	/// <exclude/>
	public class WebServiceV2InTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public WebServiceV2InTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WebServiceV2InTagSchema(WebServiceV2InTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WebServiceV2InTagSchema(WebServiceV2InTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			RealUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			Name = "WebServiceV2InTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
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
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("fdeed432-0ea7-4bbf-bcdd-02bdeca6b644");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("057b56c2-d524-4be3-9668-904d92602fca");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityCaption";
			column.IsWeakReference = true;
			column.IsCascade = false;
			column.ModifiedInSchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WebServiceV2InTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WebServiceV2InTag_ServiceDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WebServiceV2InTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WebServiceV2InTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b"));
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2InTag

	/// <summary>
	/// Web Services section record tag.
	/// </summary>
	public class WebServiceV2InTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public WebServiceV2InTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WebServiceV2InTag";
		}

		public WebServiceV2InTag(WebServiceV2InTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WebServiceV2InTag_ServiceDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WebServiceV2InTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WebServiceV2InTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WebServiceV2InTag_ServiceDesignerEventsProcess

	/// <exclude/>
	public partial class WebServiceV2InTag_ServiceDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : WebServiceV2InTag
	{

		public WebServiceV2InTag_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WebServiceV2InTag_ServiceDesignerEventsProcess";
			SchemaUId = new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1f50793a-938c-411e-a03c-6ffdb268de7b");
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

	#region Class: WebServiceV2InTag_ServiceDesignerEventsProcess

	/// <exclude/>
	public class WebServiceV2InTag_ServiceDesignerEventsProcess : WebServiceV2InTag_ServiceDesignerEventsProcess<WebServiceV2InTag>
	{

		public WebServiceV2InTag_ServiceDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WebServiceV2InTag_ServiceDesignerEventsProcess

	public partial class WebServiceV2InTag_ServiceDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WebServiceV2InTagEventsProcess

	/// <exclude/>
	public class WebServiceV2InTagEventsProcess : WebServiceV2InTag_ServiceDesignerEventsProcess
	{

		public WebServiceV2InTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

