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

	#region Class: ConfigItemStatusSchema

	/// <exclude/>
	public class ConfigItemStatusSchema : BPMSoft.Configuration.ConfigItemStatus_CMDB_BPMSoftSchema
	{

		#region Constructors: Public

		public ConfigItemStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ConfigItemStatusSchema(ConfigItemStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ConfigItemStatusSchema(ConfigItemStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("bfb4f4f7-a6e6-4e86-80be-5aec8ebc71e6");
			Name = "ConfigItemStatus";
			ParentSchemaUId = new Guid("0f634f04-a6ca-42b3-abe9-3d780c7e9b34");
			ExtendParent = true;
			CreatedInPackageId = new Guid("9cf950ff-f679-4a1b-b1ab-42af74687802");
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
			return new ConfigItemStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ConfigItemStatus_PortalITILServiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ConfigItemStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ConfigItemStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfb4f4f7-a6e6-4e86-80be-5aec8ebc71e6"));
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemStatus

	/// <summary>
	/// Состояние конфигурационной единицы.
	/// </summary>
	public class ConfigItemStatus : BPMSoft.Configuration.ConfigItemStatus_CMDB_BPMSoft
	{

		#region Constructors: Public

		public ConfigItemStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ConfigItemStatus";
		}

		public ConfigItemStatus(ConfigItemStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ConfigItemStatus_PortalITILServiceEventsProcess(UserConnection);
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
			return new ConfigItemStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: ConfigItemStatus_PortalITILServiceEventsProcess

	/// <exclude/>
	public partial class ConfigItemStatus_PortalITILServiceEventsProcess<TEntity> : BPMSoft.Configuration.ConfigItemStatus_CMDBEventsProcess<TEntity> where TEntity : ConfigItemStatus
	{

		public ConfigItemStatus_PortalITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ConfigItemStatus_PortalITILServiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bfb4f4f7-a6e6-4e86-80be-5aec8ebc71e6");
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

	#region Class: ConfigItemStatus_PortalITILServiceEventsProcess

	/// <exclude/>
	public class ConfigItemStatus_PortalITILServiceEventsProcess : ConfigItemStatus_PortalITILServiceEventsProcess<ConfigItemStatus>
	{

		public ConfigItemStatus_PortalITILServiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ConfigItemStatus_PortalITILServiceEventsProcess

	public partial class ConfigItemStatus_PortalITILServiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ConfigItemStatusEventsProcess

	/// <exclude/>
	public class ConfigItemStatusEventsProcess : ConfigItemStatus_PortalITILServiceEventsProcess
	{

		public ConfigItemStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

