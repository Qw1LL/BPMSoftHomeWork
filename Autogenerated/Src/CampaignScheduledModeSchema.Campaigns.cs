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

	#region Class: CampaignScheduledModeSchema

	/// <exclude/>
	public class CampaignScheduledModeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CampaignScheduledModeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignScheduledModeSchema(CampaignScheduledModeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignScheduledModeSchema(CampaignScheduledModeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5335288b-38c7-456e-902b-e5768c03b448");
			RealUId = new Guid("5335288b-38c7-456e-902b-e5768c03b448");
			Name = "CampaignScheduledMode";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
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
			return new CampaignScheduledMode(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignScheduledMode_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignScheduledModeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignScheduledModeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5335288b-38c7-456e-902b-e5768c03b448"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignScheduledMode

	/// <summary>
	/// Режим запуска и остановки кампании.
	/// </summary>
	public class CampaignScheduledMode : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CampaignScheduledMode(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignScheduledMode";
		}

		public CampaignScheduledMode(CampaignScheduledMode source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignScheduledMode_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignScheduledModeDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignScheduledMode(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignScheduledMode_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignScheduledMode_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CampaignScheduledMode
	{

		public CampaignScheduledMode_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignScheduledMode_CampaignsEventsProcess";
			SchemaUId = new Guid("5335288b-38c7-456e-902b-e5768c03b448");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5335288b-38c7-456e-902b-e5768c03b448");
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

	#region Class: CampaignScheduledMode_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignScheduledMode_CampaignsEventsProcess : CampaignScheduledMode_CampaignsEventsProcess<CampaignScheduledMode>
	{

		public CampaignScheduledMode_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignScheduledMode_CampaignsEventsProcess

	public partial class CampaignScheduledMode_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignScheduledModeEventsProcess

	/// <exclude/>
	public class CampaignScheduledModeEventsProcess : CampaignScheduledMode_CampaignsEventsProcess
	{

		public CampaignScheduledModeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

