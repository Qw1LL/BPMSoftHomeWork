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
	using System.Security;
	using TSConfiguration = BPMSoft.Configuration;

	#region Class: BulkEmailTagSchema

	/// <exclude/>
	public class BulkEmailTagSchema : BPMSoft.Configuration.BaseTagSchema
	{

		#region Constructors: Public

		public BulkEmailTagSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailTagSchema(BulkEmailTagSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailTagSchema(BulkEmailTagSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a");
			RealUId = new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a");
			Name = "BulkEmailTag";
			ParentSchemaUId = new Guid("9e3f203c-e905-4de5-9468-335b193f2439");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855");
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
			return new BulkEmailTag(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailTag_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailTagSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailTagSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailTag

	/// <summary>
	/// Тег раздела email.
	/// </summary>
	public class BulkEmailTag : BPMSoft.Configuration.BaseTag
	{

		#region Constructors: Public

		public BulkEmailTag(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailTag";
		}

		public BulkEmailTag(BulkEmailTag source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailTag_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailTagDeleted", e);
			Validating += (s, e) => ThrowEvent("BulkEmailTagValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailTag(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailTag_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailTag_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseTag_SSPEventsProcess<TEntity> where TEntity : BulkEmailTag
	{

		public BulkEmailTag_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailTag_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4d2bfa15-fdd6-4749-8f7c-ecf89f21af3a");
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

	#region Class: BulkEmailTag_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailTag_MarketingCampaignEventsProcess : BulkEmailTag_MarketingCampaignEventsProcess<BulkEmailTag>
	{

		public BulkEmailTag_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailTag_MarketingCampaignEventsProcess

	public partial class BulkEmailTag_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckTagTypeAndGrantAdditionalRights() {
			base.CheckTagTypeAndGrantAdditionalRights();
			Guid typeId = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (typeId == TSConfiguration.TagConsts.PublicTagTypeUId) {
				UserConnection.DBSecurityEngine.SetEntitySchemaRecordRightLevel(TSConfiguration.BaseConsts.PortalUsersSysAdminUnitUId, 
						Entity.Schema, Entity.PrimaryColumnValue, SchemaRecordRightLevels.All); 
			}
		}

		#endregion

	}

	#endregion


	#region Class: BulkEmailTagEventsProcess

	/// <exclude/>
	public class BulkEmailTagEventsProcess : BulkEmailTag_MarketingCampaignEventsProcess
	{

		public BulkEmailTagEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

