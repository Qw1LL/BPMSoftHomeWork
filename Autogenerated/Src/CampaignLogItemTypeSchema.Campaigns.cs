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

	#region Class: CampaignLogItemTypeSchema

	/// <exclude/>
	public class CampaignLogItemTypeSchema : BPMSoft.Configuration.LookupSchema
	{

		#region Constructors: Public

		public CampaignLogItemTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignLogItemTypeSchema(CampaignLogItemTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignLogItemTypeSchema(CampaignLogItemTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("41879c50-004a-4a40-9080-fe06a2f6b1c3");
			RealUId = new Guid("41879c50-004a-4a40-9080-fe06a2f6b1c3");
			Name = "CampaignLogItemType";
			ParentSchemaUId = new Guid("2aecdb97-990e-4c17-96f4-240ca6531c84");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bac310da-8f6a-4932-87be-74eb3d9d7067");
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
			return new CampaignLogItemType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignLogItemType_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignLogItemTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignLogItemTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("41879c50-004a-4a40-9080-fe06a2f6b1c3"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignLogItemType

	/// <summary>
	/// Тип действия кампании.
	/// </summary>
	public class CampaignLogItemType : BPMSoft.Configuration.Lookup
	{

		#region Constructors: Public

		public CampaignLogItemType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignLogItemType";
		}

		public CampaignLogItemType(CampaignLogItemType source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignLogItemType_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignLogItemTypeDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignLogItemTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignLogItemType(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignLogItemType_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignLogItemType_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.Lookup_BaseEventsProcess<TEntity> where TEntity : CampaignLogItemType
	{

		public CampaignLogItemType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignLogItemType_CampaignsEventsProcess";
			SchemaUId = new Guid("41879c50-004a-4a40-9080-fe06a2f6b1c3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("41879c50-004a-4a40-9080-fe06a2f6b1c3");
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

	#region Class: CampaignLogItemType_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignLogItemType_CampaignsEventsProcess : CampaignLogItemType_CampaignsEventsProcess<CampaignLogItemType>
	{

		public CampaignLogItemType_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignLogItemType_CampaignsEventsProcess

	public partial class CampaignLogItemType_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignLogItemTypeEventsProcess

	/// <exclude/>
	public class CampaignLogItemTypeEventsProcess : CampaignLogItemType_CampaignsEventsProcess
	{

		public CampaignLogItemTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

