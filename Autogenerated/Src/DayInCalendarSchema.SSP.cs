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

	#region Class: DayInCalendarSchema

	/// <exclude/>
	public class DayInCalendarSchema : BPMSoft.Configuration.DayInCalendar_Calendar_BPMSoftSchema
	{

		#region Constructors: Public

		public DayInCalendarSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DayInCalendarSchema(DayInCalendarSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DayInCalendarSchema(DayInCalendarSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("94b5a2ba-163f-46df-a772-324cefe4a56c");
			Name = "DayInCalendar";
			ParentSchemaUId = new Guid("13665ad9-ac50-479b-b43c-765d03988626");
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
			return new DayInCalendar(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DayInCalendar_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DayInCalendarSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DayInCalendarSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("94b5a2ba-163f-46df-a772-324cefe4a56c"));
		}

		#endregion

	}

	#endregion

	#region Class: DayInCalendar

	/// <summary>
	/// Day in calendar.
	/// </summary>
	public class DayInCalendar : BPMSoft.Configuration.DayInCalendar_Calendar_BPMSoft
	{

		#region Constructors: Public

		public DayInCalendar(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayInCalendar";
		}

		public DayInCalendar(DayInCalendar source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DayInCalendar_SSPEventsProcess(UserConnection);
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
			return new DayInCalendar(this);
		}

		#endregion

	}

	#endregion

	#region Class: DayInCalendar_SSPEventsProcess

	/// <exclude/>
	public partial class DayInCalendar_SSPEventsProcess<TEntity> : BPMSoft.Configuration.DayInCalendar_CalendarEventsProcess<TEntity> where TEntity : DayInCalendar
	{

		public DayInCalendar_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DayInCalendar_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("94b5a2ba-163f-46df-a772-324cefe4a56c");
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

	#region Class: DayInCalendar_SSPEventsProcess

	/// <exclude/>
	public class DayInCalendar_SSPEventsProcess : DayInCalendar_SSPEventsProcess<DayInCalendar>
	{

		public DayInCalendar_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DayInCalendar_SSPEventsProcess

	public partial class DayInCalendar_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DayInCalendarEventsProcess

	/// <exclude/>
	public class DayInCalendarEventsProcess : DayInCalendar_SSPEventsProcess
	{

		public DayInCalendarEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

