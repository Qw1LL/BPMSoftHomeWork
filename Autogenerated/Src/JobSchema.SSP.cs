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

	#region Class: JobSchema

	/// <exclude/>
	public class JobSchema : BPMSoft.Configuration.Job_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public JobSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public JobSchema(JobSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public JobSchema(JobSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ba515c4a-4b80-476c-a6c4-d36957604463");
			Name = "Job";
			ParentSchemaUId = new Guid("c82ab6f0-0e36-4376-9ab3-c583d714b7b6");
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
			return new Job(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Job_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new JobSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new JobSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba515c4a-4b80-476c-a6c4-d36957604463"));
		}

		#endregion

	}

	#endregion

	#region Class: Job

	/// <summary>
	/// Job title.
	/// </summary>
	public class Job : BPMSoft.Configuration.Job_Base_BPMSoft
	{

		#region Constructors: Public

		public Job(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Job";
		}

		public Job(Job source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Job_SSPEventsProcess(UserConnection);
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
			return new Job(this);
		}

		#endregion

	}

	#endregion

	#region Class: Job_SSPEventsProcess

	/// <exclude/>
	public partial class Job_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Job_BaseEventsProcess<TEntity> where TEntity : Job
	{

		public Job_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Job_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ba515c4a-4b80-476c-a6c4-d36957604463");
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

	#region Class: Job_SSPEventsProcess

	/// <exclude/>
	public class Job_SSPEventsProcess : Job_SSPEventsProcess<Job>
	{

		public Job_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Job_SSPEventsProcess

	public partial class Job_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: JobEventsProcess

	/// <exclude/>
	public class JobEventsProcess : Job_SSPEventsProcess
	{

		public JobEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

