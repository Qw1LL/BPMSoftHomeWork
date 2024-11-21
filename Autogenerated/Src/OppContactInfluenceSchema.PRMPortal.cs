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

	#region Class: OppContactInfluenceSchema

	/// <exclude/>
	public class OppContactInfluenceSchema : BPMSoft.Configuration.OppContactInfluence_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OppContactInfluenceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactInfluenceSchema(OppContactInfluenceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactInfluenceSchema(OppContactInfluenceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("7bb3fb30-f472-4c00-834c-9ceeecac930b");
			Name = "OppContactInfluence";
			ParentSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			ExtendParent = true;
			CreatedInPackageId = new Guid("02f719bb-5aa1-4d13-b1db-a18a9d8adf61");
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
			return new OppContactInfluence(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactInfluence_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactInfluenceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactInfluenceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7bb3fb30-f472-4c00-834c-9ceeecac930b"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactInfluence

	/// <summary>
	/// Степень влияния контакта в продаже.
	/// </summary>
	public class OppContactInfluence : BPMSoft.Configuration.OppContactInfluence_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OppContactInfluence(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactInfluence";
		}

		public OppContactInfluence(OppContactInfluence source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactInfluence_PRMPortalEventsProcess(UserConnection);
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
			return new OppContactInfluence(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactInfluence_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OppContactInfluence_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OppContactInfluence_OpportunityEventsProcess<TEntity> where TEntity : OppContactInfluence
	{

		public OppContactInfluence_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactInfluence_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7bb3fb30-f472-4c00-834c-9ceeecac930b");
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

	#region Class: OppContactInfluence_PRMPortalEventsProcess

	/// <exclude/>
	public class OppContactInfluence_PRMPortalEventsProcess : OppContactInfluence_PRMPortalEventsProcess<OppContactInfluence>
	{

		public OppContactInfluence_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactInfluence_PRMPortalEventsProcess

	public partial class OppContactInfluence_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppContactInfluenceEventsProcess

	/// <exclude/>
	public class OppContactInfluenceEventsProcess : OppContactInfluence_PRMPortalEventsProcess
	{

		public OppContactInfluenceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

