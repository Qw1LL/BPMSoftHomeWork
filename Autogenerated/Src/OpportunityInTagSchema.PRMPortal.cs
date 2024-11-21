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

	#region Class: OpportunityInTagSchema

	/// <exclude/>
	public class OpportunityInTagSchema : BPMSoft.Configuration.OpportunityInTag_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityInTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityInTagSchema(OpportunityInTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityInTagSchema(OpportunityInTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bfe91cf5-7f89-476b-8ecd-43b1ae13618e");
			Name = "OpportunityInTag";
			ParentSchemaUId = new Guid("ff25bc2c-cc51-4654-932d-c89bc4d90db4");
			ExtendParent = true;
			CreatedInPackageId = new Guid("580620fc-064a-4cdc-95d9-80175a4d3b0d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityInTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityInTag_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityInTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityInTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfe91cf5-7f89-476b-8ecd-43b1ae13618e"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInTag

	/// <summary>
	/// Тег в записи раздела продажи.
	/// </summary>
	public class OpportunityInTag : BPMSoft.Configuration.OpportunityInTag_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityInTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityInTag";
		}

		public OpportunityInTag(OpportunityInTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityInTag_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityInTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityInTag_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityInTag_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityInTag_OpportunityEventsProcess<TEntity> where TEntity : OpportunityInTag
	{

		public OpportunityInTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityInTag_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bfe91cf5-7f89-476b-8ecd-43b1ae13618e");
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

	#region Class: OpportunityInTag_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityInTag_PRMPortalEventsProcess : OpportunityInTag_PRMPortalEventsProcess<OpportunityInTag>
	{

		public OpportunityInTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityInTag_PRMPortalEventsProcess

	public partial class OpportunityInTag_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityInTagEventsProcess

	/// <exclude/>
	public class OpportunityInTagEventsProcess : OpportunityInTag_PRMPortalEventsProcess
	{

		public OpportunityInTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

