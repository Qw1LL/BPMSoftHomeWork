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

	#region Class: InvoiceFileSchema

	/// <exclude/>
	public class InvoiceFileSchema : BPMSoft.Configuration.FileSchema
	{

		#region Constructors: Public

		public InvoiceFileSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceFileSchema(InvoiceFileSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceFileSchema(InvoiceFileSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7d51836-a27a-4e52-979c-29d114414085");
			RealUId = new Guid("e7d51836-a27a-4e52-979c-29d114414085");
			Name = "InvoiceFile";
			ParentSchemaUId = new Guid("556c5867-60a7-4456-aae1-a57a122bef70");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8a6b5719-da97-4634-8f04-4375bc29ffcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("68b6e313-9f26-471f-9dcc-ca8200b57895")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("68b6e313-9f26-471f-9dcc-ca8200b57895"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e7d51836-a27a-4e52-979c-29d114414085"),
				ModifiedInSchemaUId = new Guid("e7d51836-a27a-4e52-979c-29d114414085"),
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
			return new InvoiceFile(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceFile_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceFileSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceFileSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7d51836-a27a-4e52-979c-29d114414085"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceFile

	/// <summary>
	/// Файл и ссылка счета.
	/// </summary>
	public class InvoiceFile : BPMSoft.Configuration.File
	{

		#region Constructors: Public

		public InvoiceFile(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceFile";
		}

		public InvoiceFile(InvoiceFile source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = LookupColumnEntities.GetEntity("Invoice") as Invoice);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceFile_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("InvoiceFileDeleted", e);
			Updated += (s, e) => ThrowEvent("InvoiceFileUpdated", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceFile(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceFile_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceFile_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.File_PRMPortalEventsProcess<TEntity> where TEntity : InvoiceFile
	{

		public InvoiceFile_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceFile_InvoiceEventsProcess";
			SchemaUId = new Guid("e7d51836-a27a-4e52-979c-29d114414085");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7d51836-a27a-4e52-979c-29d114414085");
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

	#region Class: InvoiceFile_InvoiceEventsProcess

	/// <exclude/>
	public class InvoiceFile_InvoiceEventsProcess : InvoiceFile_InvoiceEventsProcess<InvoiceFile>
	{

		public InvoiceFile_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceFile_InvoiceEventsProcess

	public partial class InvoiceFile_InvoiceEventsProcess<TEntity>
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


	#region Class: InvoiceFileEventsProcess

	/// <exclude/>
	public class InvoiceFileEventsProcess : InvoiceFile_InvoiceEventsProcess
	{

		public InvoiceFileEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

