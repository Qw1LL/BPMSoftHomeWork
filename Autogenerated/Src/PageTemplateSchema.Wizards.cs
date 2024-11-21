namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
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

	#region Class: PageTemplateSchema

	/// <exclude/>
	public class PageTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public PageTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public PageTemplateSchema(PageTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public PageTemplateSchema(PageTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036");
			RealUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036");
			Name = "PageTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1a637eec-ed5e-4e5a-93be-edcf08166986");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreatePreviewImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("503afb33-4f6e-4d83-9048-a7b327d96a1a")) == null) {
				Columns.Add(CreatePageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("73e657ce-a998-489f-b95e-7729d95d397d")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("503afb33-4f6e-4d83-9048-a7b327d96a1a"),
				Name = @"PageSchemaUId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				ModifiedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236")
			};
		}

		protected virtual EntitySchemaColumn CreatePreviewImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("d33074f6-b61c-4722-bde5-87ad7ec52fd7"),
				Name = @"PreviewImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				ModifiedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("73e657ce-a998-489f-b95e-7729d95d397d"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				ModifiedInSchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new PageTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new PageTemplate_WizardsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new PageTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new PageTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036"));
		}

		#endregion

	}

	#endregion

	#region Class: PageTemplate

	/// <summary>
	/// Page template.
	/// </summary>
	public class PageTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public PageTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "PageTemplate";
		}

		public PageTemplate(PageTemplate source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// PageSchemaUId.
		/// </summary>
		public Guid PageSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("PageSchemaUId");
			}
			set {
				SetColumnValue("PageSchemaUId", value);
			}
		}

		/// <exclude/>
		public Guid PreviewImageId {
			get {
				return GetTypedColumnValue<Guid>("PreviewImageId");
			}
			set {
				SetColumnValue("PreviewImageId", value);
				_previewImage = null;
			}
		}

		/// <exclude/>
		public string PreviewImageName {
			get {
				return GetTypedColumnValue<string>("PreviewImageName");
			}
			set {
				SetColumnValue("PreviewImageName", value);
				if (_previewImage != null) {
					_previewImage.Name = value;
				}
			}
		}

		private SysImage _previewImage;
		/// <summary>
		/// Preview image.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = LookupColumnEntities.GetEntity("PreviewImage") as SysImage);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new PageTemplate_WizardsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("PageTemplateDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new PageTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: PageTemplate_WizardsEventsProcess

	/// <exclude/>
	public partial class PageTemplate_WizardsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : PageTemplate
	{

		public PageTemplate_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "PageTemplate_WizardsEventsProcess";
			SchemaUId = new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6180e4b4-b76c-49fb-b9b0-39094f261036");
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

	#region Class: PageTemplate_WizardsEventsProcess

	/// <exclude/>
	public class PageTemplate_WizardsEventsProcess : PageTemplate_WizardsEventsProcess<PageTemplate>
	{

		public PageTemplate_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: PageTemplate_WizardsEventsProcess

	public partial class PageTemplate_WizardsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: PageTemplateEventsProcess

	/// <exclude/>
	public class PageTemplateEventsProcess : PageTemplate_WizardsEventsProcess
	{

		public PageTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

