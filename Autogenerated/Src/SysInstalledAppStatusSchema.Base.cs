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

	#region Class: SysInstalledAppStatusSchema

	/// <exclude/>
	public class SysInstalledAppStatusSchema : BPMSoft.Configuration.SysCodeLookupSchema
	{

		#region Constructors: Public

		public SysInstalledAppStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysInstalledAppStatusSchema(SysInstalledAppStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysInstalledAppStatusSchema(SysInstalledAppStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			RealUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			Name = "SysInstalledAppStatus";
			ParentSchemaUId = new Guid("28699730-9cf0-4702-87a9-c64d612e4b14");
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
			return new SysInstalledAppStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysInstalledAppStatus_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysInstalledAppStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysInstalledAppStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9"));
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppStatus

	/// <summary>
	/// Application status.
	/// </summary>
	public class SysInstalledAppStatus : BPMSoft.Configuration.SysCodeLookup
	{

		#region Constructors: Public

		public SysInstalledAppStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysInstalledAppStatus";
		}

		public SysInstalledAppStatus(SysInstalledAppStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysInstalledAppStatus_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysInstalledAppStatusDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysInstalledAppStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysInstalledAppStatus_BaseEventsProcess

	/// <exclude/>
	public partial class SysInstalledAppStatus_BaseEventsProcess<TEntity> : BPMSoft.Configuration.SysCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysInstalledAppStatus
	{

		public SysInstalledAppStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysInstalledAppStatus_BaseEventsProcess";
			SchemaUId = new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7f5115ca-22b4-42ee-b01d-c8846c1a6fa9");
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

	#region Class: SysInstalledAppStatus_BaseEventsProcess

	/// <exclude/>
	public class SysInstalledAppStatus_BaseEventsProcess : SysInstalledAppStatus_BaseEventsProcess<SysInstalledAppStatus>
	{

		public SysInstalledAppStatus_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysInstalledAppStatus_BaseEventsProcess

	public partial class SysInstalledAppStatus_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysInstalledAppStatusEventsProcess

	/// <exclude/>
	public class SysInstalledAppStatusEventsProcess : SysInstalledAppStatus_BaseEventsProcess
	{

		public SysInstalledAppStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

