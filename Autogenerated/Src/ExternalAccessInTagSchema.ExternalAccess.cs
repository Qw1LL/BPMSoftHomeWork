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

	#region Class: ExternalAccessInTagSchema

	/// <exclude/>
	public class ExternalAccessInTagSchema : BPMSoft.Configuration.BaseEntityInTagSchema
	{

		#region Constructors: Public

		public ExternalAccessInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessInTagSchema(ExternalAccessInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessInTagSchema(ExternalAccessInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			RealUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			Name = "ExternalAccessInTag";
			ParentSchemaUId = new Guid("5894a2b0-51d5-419a-82bb-238674634270");
			ExtendParent = false;
			CreatedInPackageId = new Guid("386ac9f6-07c1-4d11-8d16-e4e9424ba4e8");
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
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateTagColumn() {
			EntitySchemaColumn column = base.CreateTagColumn();
			column.ReferenceSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			column.ColumnValueName = @"TagId";
			column.DisplayColumnValueName = @"TagName";
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override EntitySchemaColumn CreateEntityColumn() {
			EntitySchemaColumn column = base.CreateEntityColumn();
			column.ReferenceSchemaUId = new Guid("f3858e46-ea38-412e-af4a-2011f08718ae");
			column.ColumnValueName = @"EntityId";
			column.DisplayColumnValueName = @"EntityAccessReason";
			column.ModifiedInSchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessInTag_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessInTag

	/// <summary>
	/// External access section record tag.
	/// </summary>
	public class ExternalAccessInTag : BPMSoft.Configuration.BaseEntityInTag
	{

		#region Constructors: Public

		public ExternalAccessInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessInTag";
		}

		public ExternalAccessInTag(ExternalAccessInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessInTag_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessInTag_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessInTag_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntityInTag_BaseEventsProcess<TEntity> where TEntity : ExternalAccessInTag
	{

		public ExternalAccessInTag_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessInTag_ExternalAccessEventsProcess";
			SchemaUId = new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8394a55e-768a-46b9-b4ed-bcbc90069f5a");
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

	#region Class: ExternalAccessInTag_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessInTag_ExternalAccessEventsProcess : ExternalAccessInTag_ExternalAccessEventsProcess<ExternalAccessInTag>
	{

		public ExternalAccessInTag_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessInTag_ExternalAccessEventsProcess

	public partial class ExternalAccessInTag_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessInTagEventsProcess

	/// <exclude/>
	public class ExternalAccessInTagEventsProcess : ExternalAccessInTag_ExternalAccessEventsProcess
	{

		public ExternalAccessInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

