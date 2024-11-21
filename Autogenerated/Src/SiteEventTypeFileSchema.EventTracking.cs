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

	#region Class: SiteEventTypeFileSchema

	/// <exclude/>
	public class SiteEventTypeFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public SiteEventTypeFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SiteEventTypeFileSchema(SiteEventTypeFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SiteEventTypeFileSchema(SiteEventTypeFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("457636b4-e006-43da-9958-77de3a6b0a60");
			RealUId = new Guid("457636b4-e006-43da-9958-77de3a6b0a60");
			Name = "SiteEventTypeFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("10c7a69e-4556-4aab-b286-28b1a9d4b578")) == null) {
				Columns.Add(CreateSiteEventTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSiteEventTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("10c7a69e-4556-4aab-b286-28b1a9d4b578"),
				Name = @"SiteEventType",
				ReferenceSchemaUId = new Guid("e7274000-f0ef-4995-991a-37f0ace69fe3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("457636b4-e006-43da-9958-77de3a6b0a60"),
				ModifiedInSchemaUId = new Guid("457636b4-e006-43da-9958-77de3a6b0a60"),
				CreatedInPackageId = new Guid("2a529963-f0d0-492d-98de-b7a4c61033e2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SiteEventTypeFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SiteEventTypeFile_EventTrackingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SiteEventTypeFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SiteEventTypeFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("457636b4-e006-43da-9958-77de3a6b0a60"));
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeFile

	/// <summary>
	/// Файл события сайта.
	/// </summary>
	public class SiteEventTypeFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public SiteEventTypeFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SiteEventTypeFile";
		}

		public SiteEventTypeFile(SiteEventTypeFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SiteEventTypeId {
			get {
				return GetTypedColumnValue<Guid>("SiteEventTypeId");
			}
			set {
				SetColumnValue("SiteEventTypeId", value);
				_siteEventType = null;
			}
		}

		/// <exclude/>
		public string SiteEventTypeName {
			get {
				return GetTypedColumnValue<string>("SiteEventTypeName");
			}
			set {
				SetColumnValue("SiteEventTypeName", value);
				if (_siteEventType != null) {
					_siteEventType.Name = value;
				}
			}
		}

		private SiteEventType _siteEventType;
		/// <summary>
		/// Тип события сайта.
		/// </summary>
		public SiteEventType SiteEventType {
			get {
				return _siteEventType ??
					(_siteEventType = LookupColumnEntities.GetEntity("SiteEventType") as SiteEventType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SiteEventTypeFile_EventTrackingEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SiteEventTypeFileDeleted", e);
			Updated += (s, e) => ThrowEvent("SiteEventTypeFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SiteEventTypeFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: SiteEventTypeFile_EventTrackingEventsProcess

	/// <exclude/>
	public partial class SiteEventTypeFile_EventTrackingEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : SiteEventTypeFile
	{

		public SiteEventTypeFile_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SiteEventTypeFile_EventTrackingEventsProcess";
			SchemaUId = new Guid("457636b4-e006-43da-9958-77de3a6b0a60");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("457636b4-e006-43da-9958-77de3a6b0a60");
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

	#region Class: SiteEventTypeFile_EventTrackingEventsProcess

	/// <exclude/>
	public class SiteEventTypeFile_EventTrackingEventsProcess : SiteEventTypeFile_EventTrackingEventsProcess<SiteEventTypeFile>
	{

		public SiteEventTypeFile_EventTrackingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SiteEventTypeFile_EventTrackingEventsProcess

	public partial class SiteEventTypeFile_EventTrackingEventsProcess<TEntity>
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


	#region Class: SiteEventTypeFileEventsProcess

	/// <exclude/>
	public class SiteEventTypeFileEventsProcess : SiteEventTypeFile_EventTrackingEventsProcess
	{

		public SiteEventTypeFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

