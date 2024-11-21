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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: LeadTagSchema

	/// <exclude/>
	public class LeadTagSchema : BPMSoft.Configuration.LeadTag_Lead_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadTagSchema(LeadTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadTagSchema(LeadTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("949de0f7-765f-409d-8c06-001b85440014");
			Name = "LeadTag";
			ParentSchemaUId = new Guid("be1059c6-63ff-4c7a-805a-697b2358b245");
			ExtendParent = true;
			CreatedInPackageId = new Guid("0fffc5a3-cd85-4e12-bfdb-f47322f14e3d");
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
			return new LeadTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadTag_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("949de0f7-765f-409d-8c06-001b85440014"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadTag

	/// <summary>
	/// Тег раздела лиды.
	/// </summary>
	public class LeadTag : BPMSoft.Configuration.LeadTag_Lead_BPMSoft
	{

		#region Constructors: Public

		public LeadTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadTag";
		}

		public LeadTag(LeadTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadTag_PRMPortalEventsProcess(UserConnection);
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
			return new LeadTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadTag_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadTag_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadTag_LeadEventsProcess<TEntity> where TEntity : LeadTag
	{

		public LeadTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadTag_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("949de0f7-765f-409d-8c06-001b85440014");
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

	#region Class: LeadTag_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadTag_PRMPortalEventsProcess : LeadTag_PRMPortalEventsProcess<LeadTag>
	{

		public LeadTag_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadTag_PRMPortalEventsProcess

	public partial class LeadTag_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadTagEventsProcess

	/// <exclude/>
	public class LeadTagEventsProcess : LeadTag_PRMPortalEventsProcess
	{

		public LeadTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

