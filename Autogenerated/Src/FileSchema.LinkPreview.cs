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

	#region Class: File_LinkPreview_BPMSoftSchema

	/// <exclude/>
	public class File_LinkPreview_BPMSoftSchema : BPMSoft.Configuration.File_Base_BPMSoftSchema
	{

		#region Constructors: Public

		public File_LinkPreview_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public File_LinkPreview_BPMSoftSchema(File_LinkPreview_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public File_LinkPreview_BPMSoftSchema(File_LinkPreview_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("08733c65-57eb-48ac-8170-aef1c0d0bdfd");
			Name = "File_LinkPreview_BPMSoft";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = true;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
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
			return new File_LinkPreview_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new File_LinkPreviewEventsProcess(userConnection);
		}

		public override object Clone() {
			return new File_LinkPreview_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new File_LinkPreview_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("08733c65-57eb-48ac-8170-aef1c0d0bdfd"));
		}

		#endregion

	}

	#endregion

	#region Class: File_LinkPreview_BPMSoft

	/// <summary>
	/// File.
	/// </summary>
	public class File_LinkPreview_BPMSoft : BPMSoft.Configuration.File_Base_BPMSoft
	{

		#region Constructors: Public

		public File_LinkPreview_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "File_LinkPreview_BPMSoft";
		}

		public File_LinkPreview_BPMSoft(File_LinkPreview_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new File_LinkPreviewEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("File_LinkPreview_BPMSoftDeleted", e);
			Updated += (s, e) => ThrowEvent("File_LinkPreview_BPMSoftUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new File_LinkPreview_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: File_LinkPreviewEventsProcess

	/// <exclude/>
	public partial class File_LinkPreviewEventsProcess<TEntity> : BPMSoft.Configuration.File_BaseEventsProcess<TEntity> where TEntity : File_LinkPreview_BPMSoft
	{

		public File_LinkPreviewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "File_LinkPreviewEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("08733c65-57eb-48ac-8170-aef1c0d0bdfd");
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

	#region Class: File_LinkPreviewEventsProcess

	/// <exclude/>
	public class File_LinkPreviewEventsProcess : File_LinkPreviewEventsProcess<File_LinkPreview_BPMSoft>
	{

		public File_LinkPreviewEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: File_LinkPreviewEventsProcess

	public partial class File_LinkPreviewEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool IsURLValid(string url) {
			Uri uriResult;
			return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
		}

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

}

