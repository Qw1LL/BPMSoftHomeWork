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

	#region Class: OppContactMotivatorsSchema

	/// <exclude/>
	public class OppContactMotivatorsSchema : BPMSoft.Configuration.OppContactMotivators_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OppContactMotivatorsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactMotivatorsSchema(OppContactMotivatorsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactMotivatorsSchema(OppContactMotivatorsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("59e354f4-eec3-4838-89c1-ff30786c9763");
			Name = "OppContactMotivators";
			ParentSchemaUId = new Guid("16ab0b58-3f64-418d-849c-bf9ccd3b3bb6");
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
			return new OppContactMotivators(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactMotivators_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactMotivatorsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactMotivatorsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59e354f4-eec3-4838-89c1-ff30786c9763"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivators

	/// <summary>
	/// Мотиваторы контакта в продаже.
	/// </summary>
	public class OppContactMotivators : BPMSoft.Configuration.OppContactMotivators_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OppContactMotivators(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactMotivators";
		}

		public OppContactMotivators(OppContactMotivators source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactMotivators_PRMPortalEventsProcess(UserConnection);
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
			return new OppContactMotivators(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactMotivators_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OppContactMotivators_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OppContactMotivators_OpportunityEventsProcess<TEntity> where TEntity : OppContactMotivators
	{

		public OppContactMotivators_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactMotivators_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59e354f4-eec3-4838-89c1-ff30786c9763");
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

	#region Class: OppContactMotivators_PRMPortalEventsProcess

	/// <exclude/>
	public class OppContactMotivators_PRMPortalEventsProcess : OppContactMotivators_PRMPortalEventsProcess<OppContactMotivators>
	{

		public OppContactMotivators_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactMotivators_PRMPortalEventsProcess

	public partial class OppContactMotivators_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppContactMotivatorsEventsProcess

	/// <exclude/>
	public class OppContactMotivatorsEventsProcess : OppContactMotivators_PRMPortalEventsProcess
	{

		public OppContactMotivatorsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

