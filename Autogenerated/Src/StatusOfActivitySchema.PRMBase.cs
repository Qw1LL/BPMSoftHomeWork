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

	#region Class: StatusOfActivitySchema

	/// <exclude/>
	public class StatusOfActivitySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public StatusOfActivitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public StatusOfActivitySchema(StatusOfActivitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public StatusOfActivitySchema(StatusOfActivitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2761884d-6e52-4cff-b44b-bec24fe8654e");
			RealUId = new Guid("2761884d-6e52-4cff-b44b-bec24fe8654e");
			Name = "StatusOfActivity";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("867b9a25-86bf-4a3e-8ecd-b6e40f57be82");
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
			return new StatusOfActivity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new StatusOfActivity_PRMBaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new StatusOfActivitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new StatusOfActivitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2761884d-6e52-4cff-b44b-bec24fe8654e"));
		}

		#endregion

	}

	#endregion

	#region Class: StatusOfActivity

	/// <summary>
	/// Статус активности.
	/// </summary>
	public class StatusOfActivity : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public StatusOfActivity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "StatusOfActivity";
		}

		public StatusOfActivity(StatusOfActivity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new StatusOfActivity_PRMBaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("StatusOfActivityDeleted", e);
			Validating += (s, e) => ThrowEvent("StatusOfActivityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new StatusOfActivity(this);
		}

		#endregion

	}

	#endregion

	#region Class: StatusOfActivity_PRMBaseEventsProcess

	/// <exclude/>
	public partial class StatusOfActivity_PRMBaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : StatusOfActivity
	{

		public StatusOfActivity_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "StatusOfActivity_PRMBaseEventsProcess";
			SchemaUId = new Guid("2761884d-6e52-4cff-b44b-bec24fe8654e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2761884d-6e52-4cff-b44b-bec24fe8654e");
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

	#region Class: StatusOfActivity_PRMBaseEventsProcess

	/// <exclude/>
	public class StatusOfActivity_PRMBaseEventsProcess : StatusOfActivity_PRMBaseEventsProcess<StatusOfActivity>
	{

		public StatusOfActivity_PRMBaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: StatusOfActivity_PRMBaseEventsProcess

	public partial class StatusOfActivity_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: StatusOfActivityEventsProcess

	/// <exclude/>
	public class StatusOfActivityEventsProcess : StatusOfActivity_PRMBaseEventsProcess
	{

		public StatusOfActivityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

