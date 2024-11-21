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

	#region Class: LeadTypeSchema

	/// <exclude/>
	public class LeadTypeSchema : BPMSoft.Configuration.LeadType_TouchPoints_BPMSoftSchema
	{

		#region Constructors: Public

		public LeadTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadTypeSchema(LeadTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadTypeSchema(LeadTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("2977e204-ae9f-41d0-97ff-9f1569355818");
			Name = "LeadType";
			ParentSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888");
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
			return new LeadType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadType_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2977e204-ae9f-41d0-97ff-9f1569355818"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadType

	/// <summary>
	/// Тип потребности.
	/// </summary>
	public class LeadType : BPMSoft.Configuration.LeadType_TouchPoints_BPMSoft
	{

		#region Constructors: Public

		public LeadType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadType";
		}

		public LeadType(LeadType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadType_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("LeadTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("LeadTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new LeadType(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadType_PRMPortalEventsProcess

	/// <exclude/>
	public partial class LeadType_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.LeadType_TouchPointsEventsProcess<TEntity> where TEntity : LeadType
	{

		public LeadType_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadType_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2977e204-ae9f-41d0-97ff-9f1569355818");
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

	#region Class: LeadType_PRMPortalEventsProcess

	/// <exclude/>
	public class LeadType_PRMPortalEventsProcess : LeadType_PRMPortalEventsProcess<LeadType>
	{

		public LeadType_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadType_PRMPortalEventsProcess

	public partial class LeadType_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadTypeEventsProcess

	/// <exclude/>
	public class LeadTypeEventsProcess : LeadType_PRMPortalEventsProcess
	{

		public LeadTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

