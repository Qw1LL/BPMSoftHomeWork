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

	#region Class: OpportunityMoodSchema

	/// <exclude/>
	public class OpportunityMoodSchema : BPMSoft.Configuration.OpportunityMood_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunityMoodSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityMoodSchema(OpportunityMoodSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityMoodSchema(OpportunityMoodSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2a41278f-b43c-411f-8880-0faf4ff46b44");
			Name = "OpportunityMood";
			ParentSchemaUId = new Guid("c8b8800f-c6ca-4b8b-962b-e79307b5d95e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("5dec8cf0-d427-4401-87b1-204c8e96d1d4");
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
			return new OpportunityMood(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityMood_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityMoodSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityMoodSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2a41278f-b43c-411f-8880-0faf4ff46b44"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityMood

	/// <summary>
	/// Настроение менеджера в продаже.
	/// </summary>
	public class OpportunityMood : BPMSoft.Configuration.OpportunityMood_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OpportunityMood(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityMood";
		}

		public OpportunityMood(OpportunityMood source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityMood_PRMPortalEventsProcess(UserConnection);
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
			return new OpportunityMood(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityMood_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OpportunityMood_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OpportunityMood_OpportunityEventsProcess<TEntity> where TEntity : OpportunityMood
	{

		public OpportunityMood_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityMood_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2a41278f-b43c-411f-8880-0faf4ff46b44");
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

	#region Class: OpportunityMood_PRMPortalEventsProcess

	/// <exclude/>
	public class OpportunityMood_PRMPortalEventsProcess : OpportunityMood_PRMPortalEventsProcess<OpportunityMood>
	{

		public OpportunityMood_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityMood_PRMPortalEventsProcess

	public partial class OpportunityMood_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityMoodEventsProcess

	/// <exclude/>
	public class OpportunityMoodEventsProcess : OpportunityMood_PRMPortalEventsProcess
	{

		public OpportunityMoodEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

