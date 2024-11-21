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

	#region Class: BulkEmailSplitFileSchema

	/// <exclude/>
	public class BulkEmailSplitFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public BulkEmailSplitFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSplitFileSchema(BulkEmailSplitFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSplitFileSchema(BulkEmailSplitFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74");
			RealUId = new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74");
			Name = "BulkEmailSplitFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("1c24c8e1-1101-425d-8209-c58bcd1137cc")) == null) {
				Columns.Add(CreateBulkEmailSplitColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailSplitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1c24c8e1-1101-425d-8209-c58bcd1137cc"),
				Name = @"BulkEmailSplit",
				ReferenceSchemaUId = new Guid("9682719a-2ac0-47c8-af3a-f988a778988b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74"),
				ModifiedInSchemaUId = new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74"),
				CreatedInPackageId = new Guid("b7874c9a-6e65-41ca-b21f-5fb1f6a22855")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailSplitFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSplitFile_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSplitFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSplitFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitFile

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Email: Сплит-тесты".
	/// </summary>
	public class BulkEmailSplitFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public BulkEmailSplitFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSplitFile";
		}

		public BulkEmailSplitFile(BulkEmailSplitFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BulkEmailSplitId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailSplitId");
			}
			set {
				SetColumnValue("BulkEmailSplitId", value);
				_bulkEmailSplit = null;
			}
		}

		/// <exclude/>
		public string BulkEmailSplitName {
			get {
				return GetTypedColumnValue<string>("BulkEmailSplitName");
			}
			set {
				SetColumnValue("BulkEmailSplitName", value);
				if (_bulkEmailSplit != null) {
					_bulkEmailSplit.Name = value;
				}
			}
		}

		private BulkEmailSplit _bulkEmailSplit;
		/// <summary>
		/// Email: Сплит-тесты.
		/// </summary>
		public BulkEmailSplit BulkEmailSplit {
			get {
				return _bulkEmailSplit ??
					(_bulkEmailSplit = LookupColumnEntities.GetEntity("BulkEmailSplit") as BulkEmailSplit);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailSplitFile_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailSplitFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSplitFile_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSplitFile_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : BulkEmailSplitFile
	{

		public BulkEmailSplitFile_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSplitFile_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("18ff8448-3fde-4a32-b5ec-9e5b9f8ecc74");
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

	#region Class: BulkEmailSplitFile_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSplitFile_MarketingCampaignEventsProcess : BulkEmailSplitFile_MarketingCampaignEventsProcess<BulkEmailSplitFile>
	{

		public BulkEmailSplitFile_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSplitFile_MarketingCampaignEventsProcess

	public partial class BulkEmailSplitFile_MarketingCampaignEventsProcess<TEntity>
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


	#region Class: BulkEmailSplitFileEventsProcess

	/// <exclude/>
	public class BulkEmailSplitFileEventsProcess : BulkEmailSplitFile_MarketingCampaignEventsProcess
	{

		public BulkEmailSplitFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

