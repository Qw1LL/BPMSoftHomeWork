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

	#region Class: VwPageTemplateSchema

	/// <exclude/>
	public class VwPageTemplateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwPageTemplateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwPageTemplateSchema(VwPageTemplateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwPageTemplateSchema(VwPageTemplateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373");
			RealUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373");
			Name = "VwPageTemplate";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateSchemaCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
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
			if (Columns.FindByUId(new Guid("7972f6ee-21e8-41bf-b1f6-1ca5f4a9983a")) == null) {
				Columns.Add(CreatePageSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("0eb8f654-d324-4e87-9268-9eab4d9bbc21")) == null) {
				Columns.Add(CreatePositionColumn());
			}
			if (Columns.FindByUId(new Guid("5f4aaeb3-79db-426a-b1d5-d66ee7117661")) == null) {
				Columns.Add(CreatePageSchemaNameColumn());
			}
			if (Columns.FindByUId(new Guid("9cc7ee54-1daa-4527-9d3b-f2f4ddba4ac3")) == null) {
				Columns.Add(CreateSchemaDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("2ed304b0-a137-45c2-965a-46c5c94930de")) == null) {
				Columns.Add(CreateSysSchemaIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreatePageSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7972f6ee-21e8-41bf-b1f6-1ca5f4a9983a"),
				Name = @"PageSchemaUId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18")
			};
		}

		protected virtual EntitySchemaColumn CreatePreviewImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("2ae605a5-e78b-40d6-9012-7edca1fbbcb6"),
				Name = @"PreviewImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0eb8f654-d324-4e87-9268-9eab4d9bbc21"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("d9c4378b-4458-41ff-9d84-e4b071fcce18"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePageSchemaNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("5f4aaeb3-79db-426a-b1d5-d66ee7117661"),
				Name = @"PageSchemaName",
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236")
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("ae552c49-b2b0-4636-9977-cf1a096c01bb"),
				Name = @"SchemaCaption",
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSchemaDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("9cc7ee54-1daa-4527-9d3b-f2f4ddba4ac3"),
				Name = @"SchemaDescription",
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("35c77563-f7ec-4c0b-91e3-f2665bae1236")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2ed304b0-a137-45c2-965a-46c5c94930de"),
				Name = @"SysSchemaId",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				ModifiedInSchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"),
				CreatedInPackageId = new Guid("74e52e89-9f33-4c12-a993-b0f067e33756")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwPageTemplate(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwPageTemplate_WizardsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwPageTemplateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwPageTemplateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373"));
		}

		#endregion

	}

	#endregion

	#region Class: VwPageTemplate

	/// <summary>
	/// VwPageTemplate (view).
	/// </summary>
	public class VwPageTemplate : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwPageTemplate(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwPageTemplate";
		}

		public VwPageTemplate(VwPageTemplate source)
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

		/// <summary>
		/// Schema name.
		/// </summary>
		public string PageSchemaName {
			get {
				return GetTypedColumnValue<string>("PageSchemaName");
			}
			set {
				SetColumnValue("PageSchemaName", value);
			}
		}

		/// <summary>
		/// Schema caption.
		/// </summary>
		public string SchemaCaption {
			get {
				return GetTypedColumnValue<string>("SchemaCaption");
			}
			set {
				SetColumnValue("SchemaCaption", value);
			}
		}

		/// <summary>
		/// Schema description.
		/// </summary>
		public string SchemaDescription {
			get {
				return GetTypedColumnValue<string>("SchemaDescription");
			}
			set {
				SetColumnValue("SchemaDescription", value);
			}
		}

		/// <summary>
		/// SysSchemaId.
		/// </summary>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwPageTemplate_WizardsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwPageTemplateDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwPageTemplate(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwPageTemplate_WizardsEventsProcess

	/// <exclude/>
	public partial class VwPageTemplate_WizardsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwPageTemplate
	{

		public VwPageTemplate_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwPageTemplate_WizardsEventsProcess";
			SchemaUId = new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("72bb9229-bf9b-410f-bf4b-8d4ea6902373");
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

	#region Class: VwPageTemplate_WizardsEventsProcess

	/// <exclude/>
	public class VwPageTemplate_WizardsEventsProcess : VwPageTemplate_WizardsEventsProcess<VwPageTemplate>
	{

		public VwPageTemplate_WizardsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwPageTemplate_WizardsEventsProcess

	public partial class VwPageTemplate_WizardsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwPageTemplateEventsProcess

	/// <exclude/>
	public class VwPageTemplateEventsProcess : VwPageTemplate_WizardsEventsProcess
	{

		public VwPageTemplateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

