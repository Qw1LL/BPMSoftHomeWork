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

	#region Class: CampaignVersionSchema

	/// <exclude/>
	public class CampaignVersionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignVersionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignVersionSchema(CampaignVersionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignVersionSchema(CampaignVersionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7");
			RealUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7");
			Name = "CampaignVersion";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateDisplayNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6a67fa4c-91e9-47a7-8249-e7f2964678f4")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("1a704095-3157-4a43-bbc4-23cc28f4daa7")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("e73615bf-1ec6-3d07-5fcf-9d9ac0f89c70")) == null) {
				Columns.Add(CreatePreviewImageColumn());
			}
			if (Columns.FindByUId(new Guid("f9bae9b7-d969-49d1-0872-c174d01a693c")) == null) {
				Columns.Add(CreateLocalizableDataColumn());
			}
			if (Columns.FindByUId(new Guid("04da7a62-51e9-9346-16ce-fb92683afa3c")) == null) {
				Columns.Add(CreateDataFormatColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("6a67fa4c-91e9-47a7-8249-e7f2964678f4"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1a704095-3157-4a43-bbc4-23cc28f4daa7"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreatePreviewImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e73615bf-1ec6-3d07-5fcf-9d9ac0f89c70"),
				Name = @"PreviewImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateLocalizableDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f9bae9b7-d969-49d1-0872-c174d01a693c"),
				Name = @"LocalizableData",
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateDataFormatColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("04da7a62-51e9-9346-16ce-fb92683afa3c"),
				Name = @"DataFormat",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"0"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDisplayNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("0e2e1bbd-a6cd-e8af-87f1-3d038234b611"),
				Name = @"DisplayName",
				CreatedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				ModifiedInSchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignVersion(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignVersion_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignVersionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignVersionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1b58b188-a680-4370-b94d-000af0cd59f7"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignVersion

	/// <summary>
	/// Версия схемы кампании.
	/// </summary>
	public class CampaignVersion : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignVersion(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignVersion";
		}

		public CampaignVersion(CampaignVersion source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// JSON сериализированной cхемы кампании.
		/// </summary>
		public string Data {
			get {
				return GetTypedColumnValue<string>("Data");
			}
			set {
				SetColumnValue("Data", value);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
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
		/// PreviewImage.
		/// </summary>
		public SysImage PreviewImage {
			get {
				return _previewImage ??
					(_previewImage = LookupColumnEntities.GetEntity("PreviewImage") as SysImage);
			}
		}

		/// <summary>
		/// LocalizableData.
		/// </summary>
		/// <remarks>
		/// Serialized array of localizable data from SysLocalizableValue.
		/// </remarks>
		public string LocalizableData {
			get {
				return GetTypedColumnValue<string>("LocalizableData");
			}
			set {
				SetColumnValue("LocalizableData", value);
			}
		}

		/// <summary>
		/// DataFormat.
		/// </summary>
		public int DataFormat {
			get {
				return GetTypedColumnValue<int>("DataFormat");
			}
			set {
				SetColumnValue("DataFormat", value);
			}
		}

		/// <summary>
		/// DisplayName.
		/// </summary>
		public string DisplayName {
			get {
				return GetTypedColumnValue<string>("DisplayName");
			}
			set {
				SetColumnValue("DisplayName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignVersion_CampaignsEventsProcess(UserConnection);
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
			return new CampaignVersion(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignVersion_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignVersion_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignVersion
	{

		public CampaignVersion_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignVersion_CampaignsEventsProcess";
			SchemaUId = new Guid("1b58b188-a680-4370-b94d-000af0cd59f7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1b58b188-a680-4370-b94d-000af0cd59f7");
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

	#region Class: CampaignVersion_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignVersion_CampaignsEventsProcess : CampaignVersion_CampaignsEventsProcess<CampaignVersion>
	{

		public CampaignVersion_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignVersion_CampaignsEventsProcess

	public partial class CampaignVersion_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignVersionEventsProcess

	/// <exclude/>
	public class CampaignVersionEventsProcess : CampaignVersion_CampaignsEventsProcess
	{

		public CampaignVersionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

