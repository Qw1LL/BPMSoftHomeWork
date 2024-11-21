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

	#region Class: FileSchema

	/// <exclude/>
	public class FileSchema : BPMSoft.Configuration.File_LinkPreview_BPMSoftSchema
	{

		#region Constructors: Public

		public FileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FileSchema(FileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FileSchema(FileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("9cad15c8-ebc8-4c7c-9e99-aa1354561e7d");
			Name = "File";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = true;
			CreatedInPackageId = new Guid("1bc37faf-30bf-4d4a-b067-5fd52b4ccffd");
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
			return new File(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new File_PRMPortalEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9cad15c8-ebc8-4c7c-9e99-aa1354561e7d"));
		}

		#endregion

	}

	#endregion

	#region Class: File

	/// <summary>
	/// Файл.
	/// </summary>
	public class File : BPMSoft.Configuration.File_LinkPreview_BPMSoft
	{

		#region Constructors: Public

		public File(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "File";
		}

		public File(File source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new File_PRMPortalEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("FileDeleted", e);
			Updated += (s, e) => ThrowEvent("FileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new File(this);
		}

		#endregion

	}

	#endregion

	#region Class: File_PRMPortalEventsProcess

	/// <exclude/>
	public partial class File_PRMPortalEventsProcess<TEntity> : BPMSoft.Configuration.File_LinkPreviewEventsProcess<TEntity> where TEntity : File
	{

		public File_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "File_PRMPortalEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9cad15c8-ebc8-4c7c-9e99-aa1354561e7d");
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

	#region Class: File_PRMPortalEventsProcess

	/// <exclude/>
	public class File_PRMPortalEventsProcess : File_PRMPortalEventsProcess<File>
	{

		public File_PRMPortalEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: File_PRMPortalEventsProcess

	public partial class File_PRMPortalEventsProcess<TEntity>
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


	#region Class: FileEventsProcess

	/// <exclude/>
	public class FileEventsProcess : File_PRMPortalEventsProcess
	{

		public FileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

