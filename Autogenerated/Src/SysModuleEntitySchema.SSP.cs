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

	#region Class: SysModuleEntitySchema

	/// <exclude/>
	public class SysModuleEntitySchema : BPMSoft.Configuration.SysModuleEntity_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysModuleEntitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleEntitySchema(SysModuleEntitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleEntitySchema(SysModuleEntitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("032f5e0c-ab33-4300-a8fc-ec522e1d03e9");
			Name = "SysModuleEntity";
			ParentSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
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
			return new SysModuleEntity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleEntity_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleEntitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleEntitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("032f5e0c-ab33-4300-a8fc-ec522e1d03e9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntity

	/// <summary>
	/// Section object.
	/// </summary>
	public class SysModuleEntity : BPMSoft.Configuration.SysModuleEntity_Base_BPMSoft
	{

		#region Constructors: Public

		public SysModuleEntity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleEntity";
		}

		public SysModuleEntity(SysModuleEntity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleEntity_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleEntityDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleEntity(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleEntity_SSPEventsProcess

	/// <exclude/>
	public partial class SysModuleEntity_SSPEventsProcess<TEntity> : BPMSoft.Configuration.SysModuleEntity_BaseEventsProcess<TEntity> where TEntity : SysModuleEntity
	{

		public SysModuleEntity_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleEntity_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("032f5e0c-ab33-4300-a8fc-ec522e1d03e9");
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

	#region Class: SysModuleEntity_SSPEventsProcess

	/// <exclude/>
	public class SysModuleEntity_SSPEventsProcess : SysModuleEntity_SSPEventsProcess<SysModuleEntity>
	{

		public SysModuleEntity_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleEntity_SSPEventsProcess

	public partial class SysModuleEntity_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleEntityEventsProcess

	/// <exclude/>
	public class SysModuleEntityEventsProcess : SysModuleEntity_SSPEventsProcess
	{

		public SysModuleEntityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

