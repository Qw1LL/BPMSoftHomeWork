namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: CampaignFileSchema

	/// <exclude/>
	public class CampaignFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CampaignFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignFileSchema(CampaignFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignFileSchema(CampaignFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd");
			RealUId = new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd");
			Name = "CampaignFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e227a778-e6ff-4907-a339-34c97d8016be")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e227a778-e6ff-4907-a339-34c97d8016be"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd"),
				ModifiedInSchemaUId = new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd"),
				CreatedInPackageId = new Guid("c130e4bc-accb-4cd0-8b02-dd2e4506d5d1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignFile_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFile

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Кампании".
	/// </summary>
	public class CampaignFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public CampaignFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignFile";
		}

		public CampaignFile(CampaignFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампании.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignFile_CampaignsEventsProcess(UserConnection);
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
			return new CampaignFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignFile_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignFile_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : CampaignFile
	{

		public CampaignFile_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignFile_CampaignsEventsProcess";
			SchemaUId = new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("37747baf-e32b-43d5-9c04-33b2f05338fd");
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

	#region Class: CampaignFile_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignFile_CampaignsEventsProcess : CampaignFile_CampaignsEventsProcess<CampaignFile>
	{

		public CampaignFile_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignFile_CampaignsEventsProcess

	public partial class CampaignFile_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void OnFileSaved() {
			base.OnFileSaved();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				var url = Entity.GetTypedColumnValue<string>("Name").Trim();
				if (IsURLValid(url)) {
					LinkPreview linkPreview = new LinkPreview();
					LinkPreviewInfo linkPreviewInfo = linkPreview.GetWebPageLinkPreview(url);
					if (linkPreviewInfo != null) {
						LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
						linkPreviewProvider.SaveLinkPreviewInfo(linkPreviewInfo, Entity.PrimaryColumnValue);
					}
				}
			}
		}

		public override void OnFileDeleted() {
			base.OnFileDeleted();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		public override void OnFileUpdated() {
			base.OnFileUpdated();
			
			if (!UserConnection.GetIsFeatureEnabled("LinkPreview")) {
				return;
			}
			
			var fileType = Entity.GetTypedColumnValue<Guid>("TypeId");
			string oldUrl = (string)Entity.GetColumnOldValue("Name");
			if (fileType == BPMSoft.WebApp.FileConsts.LinkTypeUId && IsURLValid(oldUrl)) {
				LinkPreviewProvider linkPreviewProvider = new LinkPreviewProvider(UserConnection);
				linkPreviewProvider.DeleteLinkPreviewInfo(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion


	#region Class: CampaignFileEventsProcess

	/// <exclude/>
	public class CampaignFileEventsProcess : CampaignFile_CampaignsEventsProcess
	{

		public CampaignFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

