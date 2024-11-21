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

	#region Class: CampaignParticipantOpInfoSchema

	/// <exclude/>
	public class CampaignParticipantOpInfoSchema : BPMSoft.Configuration.CampaignParticipantInfoSchema
	{

		#region Constructors: Public

		public CampaignParticipantOpInfoSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignParticipantOpInfoSchema(CampaignParticipantOpInfoSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignParticipantOpInfoSchema(CampaignParticipantOpInfoSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("637b24a4-0cea-4ac9-acbf-5d871f8a8409");
			RealUId = new Guid("637b24a4-0cea-4ac9-acbf-5d871f8a8409");
			Name = "CampaignParticipantOpInfo";
			ParentSchemaUId = new Guid("19aa0bd2-80bc-406b-8ada-9a8acea053e8");
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
			return new CampaignParticipantOpInfo(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignParticipantOpInfo_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignParticipantOpInfoSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignParticipantOpInfoSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("637b24a4-0cea-4ac9-acbf-5d871f8a8409"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipantOpInfo

	/// <summary>
	/// CampaignParticipantOpInfo (операционная таблица).
	/// </summary>
	public class CampaignParticipantOpInfo : BPMSoft.Configuration.CampaignParticipantInfo
	{

		#region Constructors: Public

		public CampaignParticipantOpInfo(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignParticipantOpInfo";
		}

		public CampaignParticipantOpInfo(CampaignParticipantOpInfo source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignParticipantOpInfo_CampaignsEventsProcess(UserConnection);
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
			return new CampaignParticipantOpInfo(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignParticipantOpInfo_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignParticipantOpInfo_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.CampaignParticipantInfo_CampaignsEventsProcess<TEntity> where TEntity : CampaignParticipantOpInfo
	{

		public CampaignParticipantOpInfo_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignParticipantOpInfo_CampaignsEventsProcess";
			SchemaUId = new Guid("637b24a4-0cea-4ac9-acbf-5d871f8a8409");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("637b24a4-0cea-4ac9-acbf-5d871f8a8409");
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

	#region Class: CampaignParticipantOpInfo_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignParticipantOpInfo_CampaignsEventsProcess : CampaignParticipantOpInfo_CampaignsEventsProcess<CampaignParticipantOpInfo>
	{

		public CampaignParticipantOpInfo_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignParticipantOpInfo_CampaignsEventsProcess

	public partial class CampaignParticipantOpInfo_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignParticipantOpInfoEventsProcess

	/// <exclude/>
	public class CampaignParticipantOpInfoEventsProcess : CampaignParticipantOpInfo_CampaignsEventsProcess
	{

		public CampaignParticipantOpInfoEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

