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

	#region Class: DeadlineCalcSchemasSchema

	/// <exclude/>
	public class DeadlineCalcSchemasSchema : BPMSoft.Configuration.DeadlineCalcSchemas_Calendar_BPMSoftSchema
	{

		#region Constructors: Public

		public DeadlineCalcSchemasSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeadlineCalcSchemasSchema(DeadlineCalcSchemasSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeadlineCalcSchemasSchema(DeadlineCalcSchemasSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("89c9d5e1-c58f-4d3b-8524-d57bb4540b1a");
			Name = "DeadlineCalcSchemas";
			ParentSchemaUId = new Guid("109e54de-6e5b-4164-98d6-ca1c4e8a87d0");
			ExtendParent = true;
			CreatedInPackageId = new Guid("d7352345-17a4-46e8-b32e-306ac0453d7a");
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
			return new DeadlineCalcSchemas(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeadlineCalcSchemas_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeadlineCalcSchemasSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeadlineCalcSchemasSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("89c9d5e1-c58f-4d3b-8524-d57bb4540b1a"));
		}

		#endregion

	}

	#endregion

	#region Class: DeadlineCalcSchemas

	/// <summary>
	/// Case deadline calculation schemas.
	/// </summary>
	public class DeadlineCalcSchemas : BPMSoft.Configuration.DeadlineCalcSchemas_Calendar_BPMSoft
	{

		#region Constructors: Public

		public DeadlineCalcSchemas(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeadlineCalcSchemas";
		}

		public DeadlineCalcSchemas(DeadlineCalcSchemas source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeadlineCalcSchemas_SSPEventsProcess(UserConnection);
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
			return new DeadlineCalcSchemas(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeadlineCalcSchemas_SSPEventsProcess

	/// <exclude/>
	public partial class DeadlineCalcSchemas_SSPEventsProcess<TEntity> : BPMSoft.Configuration.DeadlineCalcSchemas_CalendarEventsProcess<TEntity> where TEntity : DeadlineCalcSchemas
	{

		public DeadlineCalcSchemas_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeadlineCalcSchemas_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("89c9d5e1-c58f-4d3b-8524-d57bb4540b1a");
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

	#region Class: DeadlineCalcSchemas_SSPEventsProcess

	/// <exclude/>
	public class DeadlineCalcSchemas_SSPEventsProcess : DeadlineCalcSchemas_SSPEventsProcess<DeadlineCalcSchemas>
	{

		public DeadlineCalcSchemas_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeadlineCalcSchemas_SSPEventsProcess

	public partial class DeadlineCalcSchemas_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeadlineCalcSchemasEventsProcess

	/// <exclude/>
	public class DeadlineCalcSchemasEventsProcess : DeadlineCalcSchemas_SSPEventsProcess
	{

		public DeadlineCalcSchemasEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

