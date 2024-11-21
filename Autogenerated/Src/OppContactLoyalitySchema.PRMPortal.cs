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

	#region Class: OppContactLoyalitySchema

	/// <exclude/>
	public class OppContactLoyalitySchema : BPMSoft.Configuration.OppContactLoyality_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OppContactLoyalitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactLoyalitySchema(OppContactLoyalitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactLoyalitySchema(OppContactLoyalitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("0703e0fb-d2d6-4f1b-a148-205fae87eba9");
			Name = "OppContactLoyality";
			ParentSchemaUId = new Guid("90a3e9f6-12d4-45b5-9122-7c4aadb41f28");
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
			return new OppContactLoyality(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactLoyality_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactLoyalitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactLoyalitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0703e0fb-d2d6-4f1b-a148-205fae87eba9"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactLoyality

	/// <summary>
	/// Лояльность контакта к нашей компании.
	/// </summary>
	public class OppContactLoyality : BPMSoft.Configuration.OppContactLoyality_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OppContactLoyality(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactLoyality";
		}

		public OppContactLoyality(OppContactLoyality source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactLoyality_PRMPortalEventsProcess(UserConnection);
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
			return new OppContactLoyality(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactLoyality_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OppContactLoyality_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OppContactLoyality_OpportunityEventsProcess<TEntity> where TEntity : OppContactLoyality
	{

		public OppContactLoyality_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactLoyality_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0703e0fb-d2d6-4f1b-a148-205fae87eba9");
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

	#region Class: OppContactLoyality_PRMPortalEventsProcess

	/// <exclude/>
	public class OppContactLoyality_PRMPortalEventsProcess : OppContactLoyality_PRMPortalEventsProcess<OppContactLoyality>
	{

		public OppContactLoyality_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactLoyality_PRMPortalEventsProcess

	public partial class OppContactLoyality_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppContactLoyalityEventsProcess

	/// <exclude/>
	public class OppContactLoyalityEventsProcess : OppContactLoyality_PRMPortalEventsProcess
	{

		public OppContactLoyalityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

