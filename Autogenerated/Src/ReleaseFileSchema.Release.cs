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

	#region Class: ReleaseFileSchema

	/// <exclude/>
	public class ReleaseFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public ReleaseFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseFileSchema(ReleaseFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseFileSchema(ReleaseFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			RealUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			Name = "ReleaseFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("69aeaa38-2be0-489c-a46c-da2a5c6b4dd1")) == null) {
				Columns.Add(CreateReleaseColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateNotesColumn() {
			EntitySchemaColumn column = base.CreateNotesColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedByColumn() {
			EntitySchemaColumn column = base.CreateLockedByColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateLockedOnColumn() {
			EntitySchemaColumn column = base.CreateLockedOnColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateDataColumn() {
			EntitySchemaColumn column = base.CreateDataColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateVersionColumn() {
			EntitySchemaColumn column = base.CreateVersionColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateSizeColumn() {
			EntitySchemaColumn column = base.CreateSizeColumn();
			column.ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected virtual EntitySchemaColumn CreateReleaseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("69aeaa38-2be0-489c-a46c-da2a5c6b4dd1"),
				Name = @"Release",
				ReferenceSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655"),
				ModifiedInSchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ReleaseFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ReleaseFile_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655"));
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseFile

	/// <summary>
	/// Объект для детали файлы и ссылки объекта раздела "Релизы".
	/// </summary>
	public class ReleaseFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public ReleaseFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ReleaseFile";
		}

		public ReleaseFile(ReleaseFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ReleaseId {
			get {
				return GetTypedColumnValue<Guid>("ReleaseId");
			}
			set {
				SetColumnValue("ReleaseId", value);
				_release = null;
			}
		}

		/// <exclude/>
		public string ReleaseNumber {
			get {
				return GetTypedColumnValue<string>("ReleaseNumber");
			}
			set {
				SetColumnValue("ReleaseNumber", value);
				if (_release != null) {
					_release.Number = value;
				}
			}
		}

		private Release _release;
		/// <summary>
		/// Релизы .
		/// </summary>
		public Release Release {
			get {
				return _release ??
					(_release = LookupColumnEntities.GetEntity("Release") as Release);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ReleaseFile_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseFileDeleted", e);
			Updated += (s, e) => ThrowEvent("ReleaseFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ReleaseFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: ReleaseFile_ReleaseEventsProcess

	/// <exclude/>
	public partial class ReleaseFile_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : ReleaseFile
	{

		public ReleaseFile_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ReleaseFile_ReleaseEventsProcess";
			SchemaUId = new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("59949191-fd3c-407d-a73a-26b6bcb6f655");
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

	#region Class: ReleaseFile_ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseFile_ReleaseEventsProcess : ReleaseFile_ReleaseEventsProcess<ReleaseFile>
	{

		public ReleaseFile_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ReleaseFile_ReleaseEventsProcess

	public partial class ReleaseFile_ReleaseEventsProcess<TEntity>
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


	#region Class: ReleaseFileEventsProcess

	/// <exclude/>
	public class ReleaseFileEventsProcess : ReleaseFile_ReleaseEventsProcess
	{

		public ReleaseFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

