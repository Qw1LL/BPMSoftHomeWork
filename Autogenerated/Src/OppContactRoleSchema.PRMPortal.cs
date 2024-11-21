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

	#region Class: OppContactRoleSchema

	/// <exclude/>
	public class OppContactRoleSchema : BPMSoft.Configuration.OppContactRole_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public OppContactRoleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactRoleSchema(OppContactRoleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactRoleSchema(OppContactRoleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("e7be2b39-f175-4b55-af9f-bec5775af20d");
			Name = "OppContactRole";
			ParentSchemaUId = new Guid("a85932a3-30a5-49d7-9627-7f749a055ab7");
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
			return new OppContactRole(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactRole_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactRoleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactRoleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7be2b39-f175-4b55-af9f-bec5775af20d"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactRole

	/// <summary>
	/// Роль контакта в продаже.
	/// </summary>
	public class OppContactRole : BPMSoft.Configuration.OppContactRole_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public OppContactRole(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactRole";
		}

		public OppContactRole(OppContactRole source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactRole_PRMPortalEventsProcess(UserConnection);
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
			return new OppContactRole(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactRole_PRMPortalEventsProcess

	/// <exclude/>
	public partial class OppContactRole_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.OppContactRole_OpportunityEventsProcess<TEntity> where TEntity : OppContactRole
	{

		public OppContactRole_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactRole_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7be2b39-f175-4b55-af9f-bec5775af20d");
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

	#region Class: OppContactRole_PRMPortalEventsProcess

	/// <exclude/>
	public class OppContactRole_PRMPortalEventsProcess : OppContactRole_PRMPortalEventsProcess<OppContactRole>
	{

		public OppContactRole_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactRole_PRMPortalEventsProcess

	public partial class OppContactRole_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OppContactRoleEventsProcess

	/// <exclude/>
	public class OppContactRoleEventsProcess : OppContactRole_PRMPortalEventsProcess
	{

		public OppContactRoleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

