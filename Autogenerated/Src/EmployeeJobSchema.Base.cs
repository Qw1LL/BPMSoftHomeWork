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

	#region Class: EmployeeJobSchema

	/// <exclude/>
	public class EmployeeJobSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public EmployeeJobSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EmployeeJobSchema(EmployeeJobSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EmployeeJobSchema(EmployeeJobSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59");
			RealUId = new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59");
			Name = "EmployeeJob";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
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
			return new EmployeeJob(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EmployeeJob_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EmployeeJobSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EmployeeJobSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59"));
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeJob

	/// <summary>
	/// Employee job.
	/// </summary>
	public class EmployeeJob : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public EmployeeJob(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EmployeeJob";
		}

		public EmployeeJob(EmployeeJob source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EmployeeJob_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EmployeeJobDeleted", e);
			Validating += (s, e) => ThrowEvent("EmployeeJobValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EmployeeJob(this);
		}

		#endregion

	}

	#endregion

	#region Class: EmployeeJob_BaseEventsProcess

	/// <exclude/>
	public partial class EmployeeJob_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : EmployeeJob
	{

		public EmployeeJob_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EmployeeJob_BaseEventsProcess";
			SchemaUId = new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c3a74d81-99ee-4c40-8434-0c6eb23edf59");
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

	#region Class: EmployeeJob_BaseEventsProcess

	/// <exclude/>
	public class EmployeeJob_BaseEventsProcess : EmployeeJob_BaseEventsProcess<EmployeeJob>
	{

		public EmployeeJob_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EmployeeJob_BaseEventsProcess

	public partial class EmployeeJob_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EmployeeJobEventsProcess

	/// <exclude/>
	public class EmployeeJobEventsProcess : EmployeeJob_BaseEventsProcess
	{

		public EmployeeJobEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

