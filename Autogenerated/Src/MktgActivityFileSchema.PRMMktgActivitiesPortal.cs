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

	#region Class: MktgActivityFileSchema

	/// <exclude/>
	public class MktgActivityFileSchema : BPMSoft.Configuration.MktgActivityFile_CampaignPlannerNew_BPMSoftSchema
	{

		#region Constructors: Public

		public MktgActivityFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MktgActivityFileSchema(MktgActivityFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MktgActivityFileSchema(MktgActivityFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("b4d2f533-a4e8-4fdc-b0e4-39eea4dddf8d");
			Name = "MktgActivityFile";
			ParentSchemaUId = new Guid("ba59209a-538e-48a3-b031-7b77800155b9");
			ExtendParent = true;
			CreatedInPackageId = new Guid("fbb56bb7-b831-4179-8d02-c2002c783bfe");
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
			return new MktgActivityFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MktgActivityFile_PRMMktgActivitiesPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MktgActivityFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MktgActivityFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b4d2f533-a4e8-4fdc-b0e4-39eea4dddf8d"));
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityFile

	/// <summary>
	/// Файл и ссылка маркетинговой активности.
	/// </summary>
	public class MktgActivityFile : BPMSoft.Configuration.MktgActivityFile_CampaignPlannerNew_BPMSoft
	{

		#region Constructors: Public

		public MktgActivityFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MktgActivityFile";
		}

		public MktgActivityFile(MktgActivityFile source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MktgActivityFile_PRMMktgActivitiesPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MktgActivityFileDeleted", e);
			Updated += (s, e) => ThrowEvent("MktgActivityFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MktgActivityFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: MktgActivityFile_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public partial class MktgActivityFile_PRMMktgActivitiesPortalEventsProcess<TEntity> : BPMSoft.Configuration.MktgActivityFile_CampaignPlannerNewEventsProcess<TEntity> where TEntity : MktgActivityFile
	{

		public MktgActivityFile_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MktgActivityFile_PRMMktgActivitiesPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("b4d2f533-a4e8-4fdc-b0e4-39eea4dddf8d");
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

	#region Class: MktgActivityFile_PRMMktgActivitiesPortalEventsProcess

	/// <exclude/>
	public class MktgActivityFile_PRMMktgActivitiesPortalEventsProcess : MktgActivityFile_PRMMktgActivitiesPortalEventsProcess<MktgActivityFile>
	{

		public MktgActivityFile_PRMMktgActivitiesPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MktgActivityFile_PRMMktgActivitiesPortalEventsProcess

	public partial class MktgActivityFile_PRMMktgActivitiesPortalEventsProcess<TEntity>
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


	#region Class: MktgActivityFileEventsProcess

	/// <exclude/>
	public class MktgActivityFileEventsProcess : MktgActivityFile_PRMMktgActivitiesPortalEventsProcess
	{

		public MktgActivityFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

