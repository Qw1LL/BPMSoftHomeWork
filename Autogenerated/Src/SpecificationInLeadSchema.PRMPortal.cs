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

	#region Class: SpecificationInLeadSchema

	/// <exclude/>
	public class SpecificationInLeadSchema : BPMSoft.Configuration.SpecificationInLead_CoreLead_BPMSoftSchema
	{

		#region Constructors: Public

		public SpecificationInLeadSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SpecificationInLeadSchema(SpecificationInLeadSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SpecificationInLeadSchema(SpecificationInLeadSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b1d7d6e3-a94d-4de0-bf21-d48ca0fa75d0");
			Name = "SpecificationInLead";
			ParentSchemaUId = new Guid("7d33f0c2-09c8-458d-8de4-0bc823f28260");
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
			return new SpecificationInLead(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SpecificationInLead_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SpecificationInLeadSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SpecificationInLeadSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b1d7d6e3-a94d-4de0-bf21-d48ca0fa75d0"));
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInLead

	/// <summary>
	/// Характеристика потребности.
	/// </summary>
	public class SpecificationInLead : BPMSoft.Configuration.SpecificationInLead_CoreLead_BPMSoft
	{

		#region Constructors: Public

		public SpecificationInLead(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SpecificationInLead";
		}

		public SpecificationInLead(SpecificationInLead source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SpecificationInLead_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SpecificationInLeadDeleted", e);
			Validating += (s, e) => ThrowEvent("SpecificationInLeadValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SpecificationInLead(this);
		}

		#endregion

	}

	#endregion

	#region Class: SpecificationInLead_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SpecificationInLead_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SpecificationInLead_CoreLeadEventsProcess<TEntity> where TEntity : SpecificationInLead
	{

		public SpecificationInLead_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SpecificationInLead_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b1d7d6e3-a94d-4de0-bf21-d48ca0fa75d0");
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

	#region Class: SpecificationInLead_PRMPortalEventsProcess

	/// <exclude/>
	public class SpecificationInLead_PRMPortalEventsProcess : SpecificationInLead_PRMPortalEventsProcess<SpecificationInLead>
	{

		public SpecificationInLead_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SpecificationInLead_PRMPortalEventsProcess

	public partial class SpecificationInLead_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SpecificationInLeadEventsProcess

	/// <exclude/>
	public class SpecificationInLeadEventsProcess : SpecificationInLead_PRMPortalEventsProcess
	{

		public SpecificationInLeadEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

