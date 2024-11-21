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

	#region Class: WSPatternInTagSchema

	/// <exclude/>
	public class WSPatternInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public WSPatternInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public WSPatternInTagSchema(WSPatternInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public WSPatternInTagSchema(WSPatternInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			RealUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			Name = "WSPatternInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8558220a-a5ba-430a-b2b1-ca168adf1057");
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
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("c631883b-cd96-43a6-b5b1-4b95903d5f95");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("9513a416-9e80-4269-8ed1-b1862fb1c226");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityWSName";
			column.ModifiedInSchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new WSPatternInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new WSPatternInTag_WSFieldsmanagementEventsProcess(userConnection);
		}

		public override object Clone() {
			return new WSPatternInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new WSPatternInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c"));
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternInTag

	/// <summary>
	/// Тег в записи раздела Правила ввода.
	/// </summary>
	public class WSPatternInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public WSPatternInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "WSPatternInTag";
		}

		public WSPatternInTag(WSPatternInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new WSPatternInTag_WSFieldsmanagementEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("WSPatternInTagDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new WSPatternInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: WSPatternInTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public partial class WSPatternInTag_WSFieldsmanagementEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : WSPatternInTag
	{

		public WSPatternInTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "WSPatternInTag_WSFieldsmanagementEventsProcess";
			SchemaUId = new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3ab31273-b29a-4900-8ba8-78447b530d3c");
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

	#region Class: WSPatternInTag_WSFieldsmanagementEventsProcess

	/// <exclude/>
	public class WSPatternInTag_WSFieldsmanagementEventsProcess : WSPatternInTag_WSFieldsmanagementEventsProcess<WSPatternInTag>
	{

		public WSPatternInTag_WSFieldsmanagementEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: WSPatternInTag_WSFieldsmanagementEventsProcess

	public partial class WSPatternInTag_WSFieldsmanagementEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: WSPatternInTagEventsProcess

	/// <exclude/>
	public class WSPatternInTagEventsProcess : WSPatternInTag_WSFieldsmanagementEventsProcess
	{

		public WSPatternInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

