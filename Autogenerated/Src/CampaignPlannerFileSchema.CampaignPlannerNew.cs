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

	#region Class: CampaignPlannerFileSchema

	/// <exclude/>
	public class CampaignPlannerFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public CampaignPlannerFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignPlannerFileSchema(CampaignPlannerFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignPlannerFileSchema(CampaignPlannerFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33");
			RealUId = new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33");
			Name = "CampaignPlannerFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f4f17a08-ea9d-4678-8180-efe99467cefe")) == null) {
				Columns.Add(CreateCampaignPlannerColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignPlannerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f4f17a08-ea9d-4678-8180-efe99467cefe"),
				Name = @"CampaignPlanner",
				ReferenceSchemaUId = new Guid("f193aa9c-3e39-442f-8028-f666a64b262a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33"),
				ModifiedInSchemaUId = new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33"),
				CreatedInPackageId = new Guid("9b5a87df-8af2-4dd9-9224-84934acee8ef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignPlannerFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignPlannerFile_CampaignPlannerNewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignPlannerFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignPlannerFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerFile

	/// <summary>
	/// Файл и ссылка маркетингового плана.
	/// </summary>
	public class CampaignPlannerFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public CampaignPlannerFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignPlannerFile";
		}

		public CampaignPlannerFile(CampaignPlannerFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid CampaignPlannerId {
			get {
				return GetTypedColumnValue<Guid>("CampaignPlannerId");
			}
			set {
				SetColumnValue("CampaignPlannerId", value);
				_campaignPlanner = null;
			}
		}

		/// <exclude/>
		public string CampaignPlannerName {
			get {
				return GetTypedColumnValue<string>("CampaignPlannerName");
			}
			set {
				SetColumnValue("CampaignPlannerName", value);
				if (_campaignPlanner != null) {
					_campaignPlanner.Name = value;
				}
			}
		}

		private CampaignPlanner _campaignPlanner;
		/// <summary>
		/// Campaigns.
		/// </summary>
		public CampaignPlanner CampaignPlanner {
			get {
				return _campaignPlanner ??
					(_campaignPlanner = LookupColumnEntities.GetEntity("CampaignPlanner") as CampaignPlanner);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignPlannerFile_CampaignPlannerNewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignPlannerFileDeleted", e);
			Updated += (s, e) => ThrowEvent("CampaignPlannerFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignPlannerFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignPlannerFile_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public partial class CampaignPlannerFile_CampaignPlannerNewEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : CampaignPlannerFile
	{

		public CampaignPlannerFile_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignPlannerFile_CampaignPlannerNewEventsProcess";
			SchemaUId = new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("8367bc89-7c3c-4dad-b104-d4f16c806d33");
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

	#region Class: CampaignPlannerFile_CampaignPlannerNewEventsProcess

	/// <exclude/>
	public class CampaignPlannerFile_CampaignPlannerNewEventsProcess : CampaignPlannerFile_CampaignPlannerNewEventsProcess<CampaignPlannerFile>
	{

		public CampaignPlannerFile_CampaignPlannerNewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignPlannerFile_CampaignPlannerNewEventsProcess

	public partial class CampaignPlannerFile_CampaignPlannerNewEventsProcess<TEntity>
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


	#region Class: CampaignPlannerFileEventsProcess

	/// <exclude/>
	public class CampaignPlannerFileEventsProcess : CampaignPlannerFile_CampaignPlannerNewEventsProcess
	{

		public CampaignPlannerFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

