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

	#region Class: SocialChannelSchema

	/// <exclude/>
	public class SocialChannelSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SocialChannelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SocialChannelSchema(SocialChannelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SocialChannelSchema(SocialChannelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			RealUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			Name = "SocialChannel";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
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
			if (Columns.FindByUId(new Guid("fa7c1b64-b9da-4412-99e9-7499fa1a8d42")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("a473b93d-7cd2-4b61-be4b-a8709564a419")) == null) {
				Columns.Add(CreatePublisherRightKindColumn());
			}
			if (Columns.FindByUId(new Guid("6a902493-b0fd-45a5-b9a4-9dda13f4c7cb")) == null) {
				Columns.Add(CreateColorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			column.CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("923c8f7a-145d-4263-aaeb-a2e18ffcfc34"),
				Name = @"Title",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("6814ee90-a16b-488a-a129-b84918bf8e64"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("fa7c1b64-b9da-4412-99e9-7499fa1a8d42"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				CreatedInPackageId = new Guid("201fea27-b50a-40ad-a9a0-a08e92938ca6"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreatePublisherRightKindColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("a473b93d-7cd2-4b61-be4b-a8709564a419"),
				Name = @"PublisherRightKind",
				CreatedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				CreatedInPackageId = new Guid("45651080-8a86-4041-b656-96c6d9b69016"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateColorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("6a902493-b0fd-45a5-b9a4-9dda13f4c7cb"),
				Name = @"Color",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				ModifiedInSchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"),
				CreatedInPackageId = new Guid("b10173a0-4adf-4651-a9e1-20bf0a2df33d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"#7299F8"
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
			return new SocialChannel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SocialChannel_ESNEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SocialChannelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SocialChannelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483"));
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannel

	/// <summary>
	/// Канал.
	/// </summary>
	public class SocialChannel : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SocialChannel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SocialChannel";
		}

		public SocialChannel(SocialChannel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Название.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
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
		/// Изображение.
		/// </summary>
		public SysImage Image {
			get {
				return _image ??
					(_image = LookupColumnEntities.GetEntity("Image") as SysImage);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <summary>
		/// Тип прав издателя.
		/// </summary>
		public bool PublisherRightKind {
			get {
				return GetTypedColumnValue<bool>("PublisherRightKind");
			}
			set {
				SetColumnValue("PublisherRightKind", value);
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		public Color Color {
			get {
				return GetTypedColumnValue<Color>("Color");
			}
			set {
				SetColumnValue("Color", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SocialChannel_ESNEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SocialChannelDeleted", e);
			Inserting += (s, e) => ThrowEvent("SocialChannelInserting", e);
			Validating += (s, e) => ThrowEvent("SocialChannelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SocialChannel(this);
		}

		#endregion

	}

	#endregion

	#region Class: SocialChannel_ESNEventsProcess

	/// <exclude/>
	public partial class SocialChannel_ESNEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SocialChannel
	{

		public SocialChannel_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SocialChannel_ESNEventsProcess";
			SchemaUId = new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("dd74c060-eb4b-4f15-b381-db91ca5ac483");
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

	#region Class: SocialChannel_ESNEventsProcess

	/// <exclude/>
	public class SocialChannel_ESNEventsProcess : SocialChannel_ESNEventsProcess<SocialChannel>
	{

		public SocialChannel_ESNEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SocialChannel_ESNEventsProcess

	public partial class SocialChannel_ESNEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SocialChannelEventsProcess

	/// <exclude/>
	public class SocialChannelEventsProcess : SocialChannel_ESNEventsProcess
	{

		public SocialChannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

