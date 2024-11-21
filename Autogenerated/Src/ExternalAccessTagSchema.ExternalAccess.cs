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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: ExternalAccessTagSchema

	/// <exclude/>
	public class ExternalAccessTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public ExternalAccessTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ExternalAccessTagSchema(ExternalAccessTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ExternalAccessTagSchema(ExternalAccessTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			RealUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			Name = "ExternalAccessTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
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
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.UsageType = EntitySchemaColumnUsageType.General;
			column.ModifiedInSchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ExternalAccessTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ExternalAccessTag_ExternalAccessEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ExternalAccessTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ExternalAccessTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412"));
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessTag

	/// <summary>
	/// External access section tag.
	/// </summary>
	public class ExternalAccessTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public ExternalAccessTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ExternalAccessTag";
		}

		public ExternalAccessTag(ExternalAccessTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ExternalAccessTag_ExternalAccessEventsProcess(UserConnection);
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
			return new ExternalAccessTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: ExternalAccessTag_ExternalAccessEventsProcess

	/// <exclude/>
	public partial class ExternalAccessTag_ExternalAccessEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : ExternalAccessTag
	{

		public ExternalAccessTag_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ExternalAccessTag_ExternalAccessEventsProcess";
			SchemaUId = new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("18053fe1-4ec0-4798-8bdf-64c48c4e1412");
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

	#region Class: ExternalAccessTag_ExternalAccessEventsProcess

	/// <exclude/>
	public class ExternalAccessTag_ExternalAccessEventsProcess : ExternalAccessTag_ExternalAccessEventsProcess<ExternalAccessTag>
	{

		public ExternalAccessTag_ExternalAccessEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ExternalAccessTag_ExternalAccessEventsProcess

	public partial class ExternalAccessTag_ExternalAccessEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ExternalAccessTagEventsProcess

	/// <exclude/>
	public class ExternalAccessTagEventsProcess : ExternalAccessTag_ExternalAccessEventsProcess
	{

		public ExternalAccessTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

