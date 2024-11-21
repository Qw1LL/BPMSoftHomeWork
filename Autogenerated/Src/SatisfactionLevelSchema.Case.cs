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

	#region Class: SatisfactionLevelSchema

	/// <exclude/>
	public class SatisfactionLevelSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public SatisfactionLevelSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SatisfactionLevelSchema(SatisfactionLevelSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SatisfactionLevelSchema(SatisfactionLevelSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			RealUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			Name = "SatisfactionLevel";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
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
			if (Columns.FindByUId(new Guid("ceda6e1a-cdf9-46b0-858b-32646d065136")) == null) {
				Columns.Add(CreatePointColumn());
			}
			if (Columns.FindByUId(new Guid("41c56be9-adf6-4ece-a539-4294ead150ad")) == null) {
				Columns.Add(CreateColourColumn());
			}
			if (Columns.FindByUId(new Guid("519e64ec-c30f-4bea-b0d7-6e193095640e")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("1c80b42f-5c2a-4802-8ac4-8bb011959db5")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			column.CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePointColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ceda6e1a-cdf9-46b0-858b-32646d065136"),
				Name = @"Point",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485")
			};
		}

		protected virtual EntitySchemaColumn CreateColourColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Color")) {
				UId = new Guid("41c56be9-adf6-4ece-a539-4294ead150ad"),
				Name = @"Colour",
				CreatedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"#FFFFFF"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("519e64ec-c30f-4bea-b0d7-6e193095640e"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("99f35013-6b7a-47d6-b440-e3f1a0ba991c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd")
			};
		}

		protected virtual EntitySchemaColumn CreateImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("4afc23aa-b8ec-4063-86ef-7fc3f19151fb"),
				Name = @"Image",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1c80b42f-5c2a-4802-8ac4-8bb011959db5"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				ModifiedInSchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"),
				CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
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
			return new SatisfactionLevel(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SatisfactionLevel_CaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SatisfactionLevelSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SatisfactionLevelSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da"));
		}

		#endregion

	}

	#endregion

	#region Class: SatisfactionLevel

	/// <summary>
	/// Уровень удовлетворенности.
	/// </summary>
	public class SatisfactionLevel : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public SatisfactionLevel(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SatisfactionLevel";
		}

		public SatisfactionLevel(SatisfactionLevel source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Балл.
		/// </summary>
		public int Point {
			get {
				return GetTypedColumnValue<int>("Point");
			}
			set {
				SetColumnValue("Point", value);
			}
		}

		/// <summary>
		/// Цвет.
		/// </summary>
		public Color Colour {
			get {
				return GetTypedColumnValue<Color>("Colour");
			}
			set {
				SetColumnValue("Colour", value);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private CaseStatus _status;
		/// <summary>
		/// Статус.
		/// </summary>
		public CaseStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as CaseStatus);
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
		/// Используется.
		/// </summary>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SatisfactionLevel_CaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SatisfactionLevelDeleted", e);
			Inserting += (s, e) => ThrowEvent("SatisfactionLevelInserting", e);
			Validating += (s, e) => ThrowEvent("SatisfactionLevelValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SatisfactionLevel(this);
		}

		#endregion

	}

	#endregion

	#region Class: SatisfactionLevel_CaseEventsProcess

	/// <exclude/>
	public partial class SatisfactionLevel_CaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : SatisfactionLevel
	{

		public SatisfactionLevel_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SatisfactionLevel_CaseEventsProcess";
			SchemaUId = new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("82b9bea0-0053-40fc-8232-85f47d8d17da");
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

	#region Class: SatisfactionLevel_CaseEventsProcess

	/// <exclude/>
	public class SatisfactionLevel_CaseEventsProcess : SatisfactionLevel_CaseEventsProcess<SatisfactionLevel>
	{

		public SatisfactionLevel_CaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SatisfactionLevel_CaseEventsProcess

	public partial class SatisfactionLevel_CaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SatisfactionLevelEventsProcess

	/// <exclude/>
	public class SatisfactionLevelEventsProcess : SatisfactionLevel_CaseEventsProcess
	{

		public SatisfactionLevelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

