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

	#region Class: ContentUserBlockSchema

	/// <exclude/>
	public class ContentUserBlockSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ContentUserBlockSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ContentUserBlockSchema(ContentUserBlockSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ContentUserBlockSchema(ContentUserBlockSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa");
			RealUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa");
			Name = "ContentUserBlock";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f6660d7a-60d9-414e-87c8-33b24e731d85")) == null) {
				Columns.Add(CreateConfigColumn());
			}
			if (Columns.FindByUId(new Guid("b6734e11-ac10-484e-8f5d-0678cd09eb4f")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("50140655-638b-43a4-8272-4aa5a808affd"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				ModifiedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateConfigColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f6660d7a-60d9-414e-87c8-33b24e731d85"),
				Name = @"Config",
				CreatedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				ModifiedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("deaa90c2-13fe-4a95-bc56-93490492c440"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				ModifiedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("b6734e11-ac10-484e-8f5d-0678cd09eb4f"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				ModifiedInSchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"),
				CreatedInPackageId = new Guid("9e185556-f0c6-4928-aead-bdfe387399b8"),
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new ContentUserBlock(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ContentUserBlock_ContentBuilderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ContentUserBlockSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ContentUserBlockSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa"));
		}

		#endregion

	}

	#endregion

	#region Class: ContentUserBlock

	/// <summary>
	/// MJML User Block Library.
	/// </summary>
	/// <remarks>
	/// Contains сustom MJML blocks, that are used in email content builder. Applies to all templates.
	/// </remarks>
	public class ContentUserBlock : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public ContentUserBlock(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ContentUserBlock";
		}

		public ContentUserBlock(ContentUserBlock source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Content block setup.
		/// </summary>
		public string Config {
			get {
				return GetTypedColumnValue<string>("Config");
			}
			set {
				SetColumnValue("Config", value);
			}
		}

		/// <exclude/>
		public Guid ImageId {
			get {
				return GetTypedColumnValue<Guid>("ImageId");
			}
			set {
				SetColumnValue("ImageId", value);
				_image = null;
			}
		}

		/// <exclude/>
		public string ImageName {
			get {
				return GetTypedColumnValue<string>("ImageName");
			}
			set {
				SetColumnValue("ImageName", value);
				if (_image != null) {
					_image.Name = value;
				}
			}
		}

		private SysImage _image;
		/// <summary>
		/// Image.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ContentUserBlock_ContentBuilderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ContentUserBlock(this);
		}

		#endregion

	}

	#endregion

	#region Class: ContentUserBlock_ContentBuilderEventsProcess

	/// <exclude/>
	public partial class ContentUserBlock_ContentBuilderEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : ContentUserBlock
	{

		public ContentUserBlock_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ContentUserBlock_ContentBuilderEventsProcess";
			SchemaUId = new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("18519ee5-eebd-4204-baa2-263b20dd14fa");
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

	#region Class: ContentUserBlock_ContentBuilderEventsProcess

	/// <exclude/>
	public class ContentUserBlock_ContentBuilderEventsProcess : ContentUserBlock_ContentBuilderEventsProcess<ContentUserBlock>
	{

		public ContentUserBlock_ContentBuilderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ContentUserBlock_ContentBuilderEventsProcess

	public partial class ContentUserBlock_ContentBuilderEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ContentUserBlockEventsProcess

	/// <exclude/>
	public class ContentUserBlockEventsProcess : ContentUserBlock_ContentBuilderEventsProcess
	{

		public ContentUserBlockEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

