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

	#region Class: ServiceItemFileSchema

	/// <exclude/>
	public class ServiceItemFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ServiceItemFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ServiceItemFileSchema(ServiceItemFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ServiceItemFileSchema(ServiceItemFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			RealUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			Name = "ServiceItemFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fffadabb-50fa-481f-a739-a5d1bd523599")) == null) {
				Columns.Add(CreateServiceItemColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			column.CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862");
			return column;
		}

		protected virtual EntitySchemaColumn CreateServiceItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fffadabb-50fa-481f-a739-a5d1bd523599"),
				Name = @"ServiceItem",
				ReferenceSchemaUId = new Guid("c6c44f0a-193e-4b5c-b35e-220a60c06898"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6"),
				ModifiedInSchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6"),
				CreatedInPackageId = new Guid("ffa69c6a-c8bb-4a61-bc00-b0bcd40a9862")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ServiceItemFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ServiceItemFile_SLMEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ServiceItemFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ServiceItemFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6"));
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItemFile

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Сервисы".
	/// </summary>
	public class ServiceItemFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ServiceItemFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ServiceItemFile";
		}

		public ServiceItemFile(ServiceItemFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ServiceItemId {
			get {
				return GetTypedColumnValue<Guid>("ServiceItemId");
			}
			set {
				SetColumnValue("ServiceItemId", value);
				_serviceItem = null;
			}
		}

		/// <exclude/>
		public string ServiceItemName {
			get {
				return GetTypedColumnValue<string>("ServiceItemName");
			}
			set {
				SetColumnValue("ServiceItemName", value);
				if (_serviceItem != null) {
					_serviceItem.Name = value;
				}
			}
		}

		private ServiceItem _serviceItem;
		/// <summary>
		/// Сервисы.
		/// </summary>
		public ServiceItem ServiceItem {
			get {
				return _serviceItem ??
					(_serviceItem = LookupColumnEntities.GetEntity("ServiceItem") as ServiceItem);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ServiceItemFile_SLMEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ServiceItemFileDeleted", e);
			Updated += (s, e) => ThrowEvent("ServiceItemFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ServiceItemFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ServiceItemFile_SLMEventsProcess

	/// <exclude/>
	public partial class ServiceItemFile_SLMEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ServiceItemFile
	{

		public ServiceItemFile_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ServiceItemFile_SLMEventsProcess";
			SchemaUId = new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d8ef8005-3bbd-4907-9e7a-4aef9b915fd6");
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

	#region Class: ServiceItemFile_SLMEventsProcess

	/// <exclude/>
	public class ServiceItemFile_SLMEventsProcess : ServiceItemFile_SLMEventsProcess<ServiceItemFile>
	{

		public ServiceItemFile_SLMEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ServiceItemFile_SLMEventsProcess

	public partial class ServiceItemFile_SLMEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
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


	#region Class: ServiceItemFileEventsProcess

	/// <exclude/>
	public class ServiceItemFileEventsProcess : ServiceItemFile_SLMEventsProcess
	{

		public ServiceItemFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

