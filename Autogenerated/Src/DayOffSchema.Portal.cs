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

	#region Class: DayOffSchema

	/// <exclude/>
	public class DayOffSchema : BPMSoft.Configuration.DayOff_Calendar_BPMSoftSchema
	{

		#region Constructors: Public

		public DayOffSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DayOffSchema(DayOffSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DayOffSchema(DayOffSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("61f638f3-1797-429c-ae7d-0b6633c35f4b");
			Name = "DayOff";
			ParentSchemaUId = new Guid("77bd6a64-4931-4aeb-b124-5cdee0325c8a");
			ExtendParent = true;
			CreatedInPackageId = new Guid("954528c0-fb67-4d4c-88f7-007a094e70cf");
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
			return new DayOff(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DayOff_PortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DayOffSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DayOffSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("61f638f3-1797-429c-ae7d-0b6633c35f4b"));
		}

		#endregion

	}

	#endregion

	#region Class: DayOff

	/// <summary>
	/// Праздничные и сокращенные дни.
	/// </summary>
	public class DayOff : BPMSoft.Configuration.DayOff_Calendar_BPMSoft
	{

		#region Constructors: Public

		public DayOff(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DayOff";
		}

		public DayOff(DayOff source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DayOff_PortalEventsProcess(UserConnection);
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
			return new DayOff(this);
		}

		#endregion

	}

	#endregion

	#region Class: DayOff_PortalEventsProcess

	/// <exclude/>
	public partial class DayOff_PortalEventsProcess<TEntity> : BPMSoft.Configuration.DayOff_CalendarEventsProcess<TEntity> where TEntity : DayOff
	{

		public DayOff_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DayOff_PortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("61f638f3-1797-429c-ae7d-0b6633c35f4b");
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

	#region Class: DayOff_PortalEventsProcess

	/// <exclude/>
	public class DayOff_PortalEventsProcess : DayOff_PortalEventsProcess<DayOff>
	{

		public DayOff_PortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DayOff_PortalEventsProcess

	public partial class DayOff_PortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DayOffEventsProcess

	/// <exclude/>
	public class DayOffEventsProcess : DayOff_PortalEventsProcess
	{

		public DayOffEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

