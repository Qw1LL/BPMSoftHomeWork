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

	#region Class: SysDcmSettingsSchema

	/// <exclude/>
	public class SysDcmSettingsSchema : BPMSoft.Configuration.SysDcmSettings_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public SysDcmSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysDcmSettingsSchema(SysDcmSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysDcmSettingsSchema(SysDcmSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b464ff82-397b-440c-b0be-579c57a79e93");
			Name = "SysDcmSettings";
			ParentSchemaUId = new Guid("ee9f7e0e-eab3-45ba-ae0d-67ab41858d5c");
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
			return new SysDcmSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysDcmSettings_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysDcmSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysDcmSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b464ff82-397b-440c-b0be-579c57a79e93"));
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSettings

	/// <summary>
	/// SysDcmSettings.
	/// </summary>
	public class SysDcmSettings : BPMSoft.Configuration.SysDcmSettings_Base_BPMSoft
	{

		#region Constructors: Public

		public SysDcmSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysDcmSettings";
		}

		public SysDcmSettings(SysDcmSettings source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysDcmSettings_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysDcmSettingsDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysDcmSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysDcmSettings_PRMPortalEventsProcess

	/// <exclude/>
	public partial class SysDcmSettings_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.SysDcmSettings_BaseEventsProcess<TEntity> where TEntity : SysDcmSettings
	{

		public SysDcmSettings_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysDcmSettings_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b464ff82-397b-440c-b0be-579c57a79e93");
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

	#region Class: SysDcmSettings_PRMPortalEventsProcess

	/// <exclude/>
	public class SysDcmSettings_PRMPortalEventsProcess : SysDcmSettings_PRMPortalEventsProcess<SysDcmSettings>
	{

		public SysDcmSettings_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysDcmSettings_PRMPortalEventsProcess

	public partial class SysDcmSettings_PRMPortalEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysDcmSettingsEventsProcess

	/// <exclude/>
	public class SysDcmSettingsEventsProcess : SysDcmSettings_PRMPortalEventsProcess
	{

		public SysDcmSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

