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

	#region Class: LeadTypeStatusSchema

	/// <exclude/>
	public class LeadTypeStatusSchema : BPMSoft.Configuration.LeadTypeStatus_TouchPoints_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadTypeStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadTypeStatusSchema(LeadTypeStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadTypeStatusSchema(LeadTypeStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d3c5e93a-3c5b-4805-9804-36c4a23cf92c");
			Name = "LeadTypeStatus";
			ParentSchemaUId = new Guid("2df1cc86-627c-4d7c-ad1f-0de8eebab40c");
			ExtendParent = true;
			CreatedInPackageId = new Guid("10676561-1f93-46bf-90be-fe5cd67025e0");
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
			return new LeadTypeStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadTypeStatus_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadTypeStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadTypeStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3c5e93a-3c5b-4805-9804-36c4a23cf92c"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeStatus

	/// <summary>
	/// Зрелость потребности.
	/// </summary>
	public class LeadTypeStatus : BPMSoft.Configuration.LeadTypeStatus_TouchPoints_BPMSoft
	{

		#region Constructors: Public

		public LeadTypeStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadTypeStatus";
		}

		public LeadTypeStatus(LeadTypeStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadTypeStatus_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadTypeStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadTypeStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadTypeStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadTypeStatus_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadTypeStatus_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadTypeStatus_TouchPointsEventsProcess<TEntity> where TEntity : LeadTypeStatus
	{

		public LeadTypeStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadTypeStatus_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d3c5e93a-3c5b-4805-9804-36c4a23cf92c");
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

	#region Class: LeadTypeStatus_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadTypeStatus_PRMPortalEventsProcess : LeadTypeStatus_PRMPortalEventsProcess<LeadTypeStatus>
	{

		public LeadTypeStatus_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadTypeStatus_PRMPortalEventsProcess

	public partial class LeadTypeStatus_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadTypeStatusEventsProcess

	/// <exclude/>
	public class LeadTypeStatusEventsProcess : LeadTypeStatus_PRMPortalEventsProcess
	{

		public LeadTypeStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

