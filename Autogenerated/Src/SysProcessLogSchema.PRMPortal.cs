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

	#region Class: SysProcessLogSchema

	/// <exclude/>
	public class SysProcessLogSchema : BPMSoft.Configuration.SysProcessLog_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysProcessLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessLogSchema(SysProcessLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessLogSchema(SysProcessLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5c0707a4-85ef-46d7-85c2-f75d93c8b825");
			Name = "SysProcessLog";
			ParentSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2");
			ExtendParent = true;
			CreatedInPackageId = new Guid("667fe825-207f-46da-8fb7-a082f81fd079");
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
			return new SysProcessLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessLog_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5c0707a4-85ef-46d7-85c2-f75d93c8b825"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLog

	/// <summary>
	/// Журнал процессов (актуальные даные).
	/// </summary>
	public class SysProcessLog : BPMSoft.Configuration.SysProcessLog_Base_BPMSoft
	{

		#region Constructors: Public

		public SysProcessLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessLog";
		}

		public SysProcessLog(SysProcessLog source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessLog_PRMPortalEventsProcess(UserConnection);
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
			return new SysProcessLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessLog_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SysProcessLog_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SysProcessLog_BaseEventsProcess<TEntity> where TEntity : SysProcessLog
	{

		public SysProcessLog_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessLog_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5c0707a4-85ef-46d7-85c2-f75d93c8b825");
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

	#region Class: SysProcessLog_PRMPortalEventsProcess

	/// <exclude/>
	public class SysProcessLog_PRMPortalEventsProcess : SysProcessLog_PRMPortalEventsProcess<SysProcessLog>
	{

		public SysProcessLog_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessLog_PRMPortalEventsProcess

	public partial class SysProcessLog_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessLogEventsProcess

	/// <exclude/>
	public class SysProcessLogEventsProcess : SysProcessLog_PRMPortalEventsProcess
	{

		public SysProcessLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

