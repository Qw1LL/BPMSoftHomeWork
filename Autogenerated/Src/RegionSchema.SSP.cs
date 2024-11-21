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

	#region Class: RegionSchema

	/// <exclude/>
	public class RegionSchema : BPMSoft.Configuration.Region_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public RegionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public RegionSchema(RegionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public RegionSchema(RegionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("fc8a7be7-d187-4198-8c01-a0c8a7d985fa");
			Name = "Region";
			ParentSchemaUId = new Guid("fa4eb497-e6a3-4f8c-8568-5df4bd2a8b91");
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
			return new Region(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Region_SSPEventsProcess(userConnection);
		}

		public override object Clone() {
			return new RegionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new RegionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc8a7be7-d187-4198-8c01-a0c8a7d985fa"));
		}

		#endregion

	}

	#endregion

	#region Class: Region

	/// <summary>
	/// Области.
	/// </summary>
	public class Region : BPMSoft.Configuration.Region_Base_BPMSoft
	{

		#region Constructors: Public

		public Region(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Region";
		}

		public Region(Region source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Region_SSPEventsProcess(UserConnection);
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
			return new Region(this);
		}

		#endregion

	}

	#endregion

	#region Class: Region_SSPEventsProcess

	/// <exclude/>
	public partial class Region_SSPEventsProcess<TEntity> : BPMSoft.Configuration.Region_BaseEventsProcess<TEntity> where TEntity : Region
	{

		public Region_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Region_SSPEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fc8a7be7-d187-4198-8c01-a0c8a7d985fa");
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

	#region Class: Region_SSPEventsProcess

	/// <exclude/>
	public class Region_SSPEventsProcess : Region_SSPEventsProcess<Region>
	{

		public Region_SSPEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Region_SSPEventsProcess

	public partial class Region_SSPEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: RegionEventsProcess

	/// <exclude/>
	public class RegionEventsProcess : Region_SSPEventsProcess
	{

		public RegionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

