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

	#region Class: TimeUnitSchema

	/// <exclude/>
	public class TimeUnitSchema : BPMSoft.Configuration.TimeUnit_Calendar_BPMSoftSchema
	{

		#region Constructors: Public

		public TimeUnitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public TimeUnitSchema(TimeUnitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public TimeUnitSchema(TimeUnitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("82fe6ae7-5156-4c75-bdfb-a8481ea30fb6");
			Name = "TimeUnit";
			ParentSchemaUId = new Guid("a9432d40-f95f-4d31-9f48-0444ebba77ab");
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
			return new TimeUnit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new TimeUnit_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new TimeUnitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new TimeUnitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82fe6ae7-5156-4c75-bdfb-a8481ea30fb6"));
		}

		#endregion

	}

	#endregion

	#region Class: TimeUnit

	/// <summary>
	/// Time unit.
	/// </summary>
	public class TimeUnit : BPMSoft.Configuration.TimeUnit_Calendar_BPMSoft
	{

		#region Constructors: Public

		public TimeUnit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "TimeUnit";
		}

		public TimeUnit(TimeUnit source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new TimeUnit_SSPEventsProcess(UserConnection);
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
			return new TimeUnit(this);
		}

		#endregion

	}

	#endregion

	#region Class: TimeUnit_SSPEventsProcess

	/// <exclude/>
	public partial class TimeUnit_SSPEventsProcess<TEntity> : BPMSoft.Configuration.TimeUnit_CalendarEventsProcess<TEntity> where TEntity : TimeUnit
	{

		public TimeUnit_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "TimeUnit_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("82fe6ae7-5156-4c75-bdfb-a8481ea30fb6");
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

	#region Class: TimeUnit_SSPEventsProcess

	/// <exclude/>
	public class TimeUnit_SSPEventsProcess : TimeUnit_SSPEventsProcess<TimeUnit>
	{

		public TimeUnit_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: TimeUnit_SSPEventsProcess

	public partial class TimeUnit_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: TimeUnitEventsProcess

	/// <exclude/>
	public class TimeUnitEventsProcess : TimeUnit_SSPEventsProcess
	{

		public TimeUnitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

