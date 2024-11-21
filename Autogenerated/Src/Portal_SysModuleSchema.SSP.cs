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

	#region Class: Portal_SysModuleSchema

	/// <exclude/>
	public class Portal_SysModuleSchema : BPMSoft.Configuration.SysModuleSchema
	{

		#region Constructors: Public

		public Portal_SysModuleSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Portal_SysModuleSchema(Portal_SysModuleSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Portal_SysModuleSchema(Portal_SysModuleSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0f41b8e1-ab86-4833-b11f-9df7cbb0a686");
			RealUId = new Guid("0f41b8e1-ab86-4833-b11f-9df7cbb0a686");
			Name = "Portal_SysModule";
			ParentSchemaUId = new Guid("2b2ed767-0b4b-4a7b-9de2-d48e14a2c0c5");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8fdab641-7d3e-411e-a4b6-d58b2f68cb48");
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
			return new Portal_SysModule(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Portal_SysModule_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Portal_SysModuleSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Portal_SysModuleSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0f41b8e1-ab86-4833-b11f-9df7cbb0a686"));
		}

		#endregion

	}

	#endregion

	#region Class: Portal_SysModule

	/// <summary>
	/// (Obsolete)SSP SysModule.
	/// </summary>
	public class Portal_SysModule : BPMSoft.Configuration.SysModule
	{

		#region Constructors: Public

		public Portal_SysModule(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Portal_SysModule";
		}

		public Portal_SysModule(Portal_SysModule source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Portal_SysModule_SSPEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Portal_SysModuleDeleted", e);
			Validating += (s, e) => ThrowEvent("Portal_SysModuleValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Portal_SysModule(this);
		}

		#endregion

	}

	#endregion

	#region Class: Portal_SysModule_SSPEventsProcess

	/// <exclude/>
	public partial class Portal_SysModule_SSPEventsProcess<TEntity> : BPMSoft.Configuration.SysModule_BaseEventsProcess<TEntity> where TEntity : Portal_SysModule
	{

		public Portal_SysModule_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Portal_SysModule_SSPEventsProcess";
			SchemaUId = new Guid("0f41b8e1-ab86-4833-b11f-9df7cbb0a686");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0f41b8e1-ab86-4833-b11f-9df7cbb0a686");
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

	#region Class: Portal_SysModule_SSPEventsProcess

	/// <exclude/>
	public class Portal_SysModule_SSPEventsProcess : Portal_SysModule_SSPEventsProcess<Portal_SysModule>
	{

		public Portal_SysModule_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Portal_SysModule_SSPEventsProcess

	public partial class Portal_SysModule_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: Portal_SysModuleEventsProcess

	/// <exclude/>
	public class Portal_SysModuleEventsProcess : Portal_SysModule_SSPEventsProcess
	{

		public Portal_SysModuleEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

