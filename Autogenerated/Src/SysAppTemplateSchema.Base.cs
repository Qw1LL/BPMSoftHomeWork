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

	#region Class: SysAppTemplateSchema

	/// <exclude/>
	public class SysAppTemplateSchema : BPMSoft.Configuration.BaseCodeImageLookupSchema
	{

		#region Constructors: Public

		public SysAppTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysAppTemplateSchema(SysAppTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysAppTemplateSchema(SysAppTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			RealUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			Name = "SysAppTemplate";
			ParentSchemaUId = new Guid("c21771d2-01fa-4646-96b0-e4b69e582b44");
			ExtendParent = false;
			CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f0b79a2b-eb81-93ee-11bd-1bc40f3f2f47")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f0b79a2b-eb81-93ee-11bd-1bc40f3f2f47"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				ModifiedInSchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"),
				CreatedInPackageId = new Guid("a5664658-26d5-4600-862a-86467fd59244")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysAppTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysAppTemplate_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysAppTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysAppTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplate

	/// <summary>
	/// SysAppTemplate.
	/// </summary>
	public class SysAppTemplate : BPMSoft.Configuration.BaseCodeImageLookup
	{

		#region Constructors: Public

		public SysAppTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysAppTemplate";
		}

		public SysAppTemplate(SysAppTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysAppTemplate_BaseEventsProcess(UserConnection);
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
			return new SysAppTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysAppTemplate_BaseEventsProcess

	/// <exclude/>
	public partial class SysAppTemplate_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeImageLookup_BaseEventsProcess<TEntity> where TEntity : SysAppTemplate
	{

		public SysAppTemplate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysAppTemplate_BaseEventsProcess";
			SchemaUId = new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("97e71819-5bc7-45a7-b0d9-f22f154dd0e2");
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

	#region Class: SysAppTemplate_BaseEventsProcess

	/// <exclude/>
	public class SysAppTemplate_BaseEventsProcess : SysAppTemplate_BaseEventsProcess<SysAppTemplate>
	{

		public SysAppTemplate_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysAppTemplate_BaseEventsProcess

	public partial class SysAppTemplate_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysAppTemplateEventsProcess

	/// <exclude/>
	public class SysAppTemplateEventsProcess : SysAppTemplate_BaseEventsProcess
	{

		public SysAppTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

