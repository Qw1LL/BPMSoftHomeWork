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

	#region Class: CmpgnParticipantStatusSchema

	/// <exclude/>
	public class CmpgnParticipantStatusSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public CmpgnParticipantStatusSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CmpgnParticipantStatusSchema(CmpgnParticipantStatusSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CmpgnParticipantStatusSchema(CmpgnParticipantStatusSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932");
			RealUId = new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932");
			Name = "CmpgnParticipantStatus";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190");
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
			return new CmpgnParticipantStatus(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CmpgnParticipantStatus_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CmpgnParticipantStatusSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CmpgnParticipantStatusSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932"));
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnParticipantStatus

	/// <summary>
	/// Состояние участника кампании.
	/// </summary>
	public class CmpgnParticipantStatus : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public CmpgnParticipantStatus(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CmpgnParticipantStatus";
		}

		public CmpgnParticipantStatus(CmpgnParticipantStatus source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CmpgnParticipantStatus_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CmpgnParticipantStatusDeleted", e);
			Validating += (s, e) => ThrowEvent("CmpgnParticipantStatusValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CmpgnParticipantStatus(this);
		}

		#endregion

	}

	#endregion

	#region Class: CmpgnParticipantStatus_CampaignsEventsProcess

	/// <exclude/>
	public partial class CmpgnParticipantStatus_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : CmpgnParticipantStatus
	{

		public CmpgnParticipantStatus_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CmpgnParticipantStatus_CampaignsEventsProcess";
			SchemaUId = new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cd0b4a6c-bf4d-4dee-a383-cf7f0fe65932");
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

	#region Class: CmpgnParticipantStatus_CampaignsEventsProcess

	/// <exclude/>
	public class CmpgnParticipantStatus_CampaignsEventsProcess : CmpgnParticipantStatus_CampaignsEventsProcess<CmpgnParticipantStatus>
	{

		public CmpgnParticipantStatus_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CmpgnParticipantStatus_CampaignsEventsProcess

	public partial class CmpgnParticipantStatus_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CmpgnParticipantStatusEventsProcess

	/// <exclude/>
	public class CmpgnParticipantStatusEventsProcess : CmpgnParticipantStatus_CampaignsEventsProcess
	{

		public CmpgnParticipantStatusEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

