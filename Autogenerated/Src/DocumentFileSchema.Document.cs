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

	#region Class: DocumentFileSchema

	/// <exclude/>
	public class DocumentFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public DocumentFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DocumentFileSchema(DocumentFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DocumentFileSchema(DocumentFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b332db9-3993-4136-ac32-09353333cc7a");
			RealUId = new Guid("7b332db9-3993-4136-ac32-09353333cc7a");
			Name = "DocumentFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("80dc2230-291b-4ff1-8555-4380678337cb")) == null) {
				Columns.Add(CreateDocumentColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDocumentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80dc2230-291b-4ff1-8555-4380678337cb"),
				Name = @"Document",
				ReferenceSchemaUId = new Guid("8b33b6b2-19f7-4222-9161-b4054b3fbb09"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7b332db9-3993-4136-ac32-09353333cc7a"),
				ModifiedInSchemaUId = new Guid("7b332db9-3993-4136-ac32-09353333cc7a"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DocumentFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DocumentFile_DocumentEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DocumentFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DocumentFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b332db9-3993-4136-ac32-09353333cc7a"));
		}

		#endregion

	}

	#endregion

	#region Class: DocumentFile

	/// <summary>
	/// Файл и ссылка документа.
	/// </summary>
	public class DocumentFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public DocumentFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DocumentFile";
		}

		public DocumentFile(DocumentFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid DocumentId {
			get {
				return GetTypedColumnValue<Guid>("DocumentId");
			}
			set {
				SetColumnValue("DocumentId", value);
				_document = null;
			}
		}

		/// <exclude/>
		public string DocumentNumber {
			get {
				return GetTypedColumnValue<string>("DocumentNumber");
			}
			set {
				SetColumnValue("DocumentNumber", value);
				if (_document != null) {
					_document.Number = value;
				}
			}
		}

		private Document _document;
		/// <summary>
		/// Документ.
		/// </summary>
		public Document Document {
			get {
				return _document ??
					(_document = LookupColumnEntities.GetEntity("Document") as Document);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DocumentFile_DocumentEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("DocumentFileDeleted", e);
			Updated += (s, e) => ThrowEvent("DocumentFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new DocumentFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: DocumentFile_DocumentEventsProcess

	/// <exclude/>
	public partial class DocumentFile_DocumentEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : DocumentFile
	{

		public DocumentFile_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DocumentFile_DocumentEventsProcess";
			SchemaUId = new Guid("7b332db9-3993-4136-ac32-09353333cc7a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b332db9-3993-4136-ac32-09353333cc7a");
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

	#region Class: DocumentFile_DocumentEventsProcess

	/// <exclude/>
	public class DocumentFile_DocumentEventsProcess : DocumentFile_DocumentEventsProcess<DocumentFile>
	{

		public DocumentFile_DocumentEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DocumentFile_DocumentEventsProcess

	public partial class DocumentFile_DocumentEventsProcess<TEntity>
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


	#region Class: DocumentFileEventsProcess

	/// <exclude/>
	public class DocumentFileEventsProcess : DocumentFile_DocumentEventsProcess
	{

		public DocumentFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

