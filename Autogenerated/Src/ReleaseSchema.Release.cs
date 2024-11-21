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

	#region Class: ReleaseSchema

	/// <exclude/>
	public class ReleaseSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public ReleaseSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ReleaseSchema(ReleaseSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ReleaseSchema(ReleaseSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			RealUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			Name = "Release";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("01b5fe20-d534-4f5b-a29c-68919cf82187")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("2ce63b1d-2436-4cf9-9fa2-1af60486e97c")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("6e6c9702-4579-44c9-b3e1-3292bcdd76a9")) == null) {
				Columns.Add(CreateScheduledReleaseDateColumn());
			}
			if (Columns.FindByUId(new Guid("848384a8-996a-43d0-8a7c-d4ac370d927d")) == null) {
				Columns.Add(CreatePlannedLaborColumn());
			}
			if (Columns.FindByUId(new Guid("ed1ac00a-35d0-49cf-a98b-c7727a743407")) == null) {
				Columns.Add(CreateReleasedOnColumn());
			}
			if (Columns.FindByUId(new Guid("1351f672-5491-4478-b989-c14ca07fc932")) == null) {
				Columns.Add(CreateDevelopmentFinishedOnColumn());
			}
			if (Columns.FindByUId(new Guid("676954b6-2543-40d6-a7c7-c66a16f30f20")) == null) {
				Columns.Add(CreateTestingFinishedOnColumn());
			}
			if (Columns.FindByUId(new Guid("2593ddf4-7121-451e-8ab3-c7930ae36a16")) == null) {
				Columns.Add(CreateDeploymentFinishedOnColumn());
			}
			if (Columns.FindByUId(new Guid("26913998-0c91-4ec2-8ea7-a5056e318c11")) == null) {
				Columns.Add(CreateActualLaborColumn());
			}
			if (Columns.FindByUId(new Guid("85a73cbf-9bfe-46fa-aeb1-ca38b8071b36")) == null) {
				Columns.Add(CreateActualDevelopmentLaborColumn());
			}
			if (Columns.FindByUId(new Guid("7c4c7e8d-fa44-477c-9f39-64161076afe8")) == null) {
				Columns.Add(CreateActualTestingLaborColumn());
			}
			if (Columns.FindByUId(new Guid("07f0e60b-e26b-492d-bdd3-38fc356a8e15")) == null) {
				Columns.Add(CreateActualDeploymentLaborColumn());
			}
			if (Columns.FindByUId(new Guid("b5bd8c19-aeea-4e9b-893e-a17447e80c13")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("2db0a991-0c65-4cde-b77e-de49aa699b69")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("6cc600e8-2a43-45a8-9d9e-8c99fbb066d5")) == null) {
				Columns.Add(CreatePriorityColumn());
			}
			if (Columns.FindByUId(new Guid("e2bab1e9-4524-466c-afe8-f154160fbe4f")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			column.CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("01b5fe20-d534-4f5b-a29c-68919cf82187"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("cde36d11-02ce-4432-b7f2-d47e6bdd4a5e"),
				Name = @"Number",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("2ce63b1d-2436-4cf9-9fa2-1af60486e97c"),
				Name = @"Description",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateScheduledReleaseDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("6e6c9702-4579-44c9-b3e1-3292bcdd76a9"),
				Name = @"ScheduledReleaseDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreatePlannedLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("848384a8-996a-43d0-8a7c-d4ac370d927d"),
				Name = @"PlannedLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateReleasedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("ed1ac00a-35d0-49cf-a98b-c7727a743407"),
				Name = @"ReleasedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateDevelopmentFinishedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("1351f672-5491-4478-b989-c14ca07fc932"),
				Name = @"DevelopmentFinishedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateTestingFinishedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("676954b6-2543-40d6-a7c7-c66a16f30f20"),
				Name = @"TestingFinishedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateDeploymentFinishedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("2593ddf4-7121-451e-8ab3-c7930ae36a16"),
				Name = @"DeploymentFinishedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateActualLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("26913998-0c91-4ec2-8ea7-a5056e318c11"),
				Name = @"ActualLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateActualDevelopmentLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("85a73cbf-9bfe-46fa-aeb1-ca38b8071b36"),
				Name = @"ActualDevelopmentLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateActualTestingLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("7c4c7e8d-fa44-477c-9f39-64161076afe8"),
				Name = @"ActualTestingLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateActualDeploymentLaborColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("07f0e60b-e26b-492d-bdd3-38fc356a8e15"),
				Name = @"ActualDeploymentLabor",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b5bd8c19-aeea-4e9b-893e-a17447e80c13"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("597097ce-243d-49d2-90de-14bdf30391fb"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ReleaseStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2db0a991-0c65-4cde-b77e-de49aa699b69"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("3ec95a26-9a7d-4c16-afcf-fbda028e75b5"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ReleaseTypeDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriorityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6cc600e8-2a43-45a8-9d9e-8c99fbb066d5"),
				Name = @"Priority",
				ReferenceSchemaUId = new Guid("392e4b61-5160-4e90-a66b-89d6bb814c25"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				CreatedInPackageId = new Guid("6364546f-7b12-440c-84c2-926c09002599"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"ReleasePriorityDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e2bab1e9-4524-466c-afe8-f154160fbe4f"),
				Name = @"Notes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
				ModifiedInSchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"),
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
			return new Release(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Release_ReleaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ReleaseSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ReleaseSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714"));
		}

		#endregion

	}

	#endregion

	#region Class: Release

	/// <summary>
	/// Релиз.
	/// </summary>
	public class Release : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Release(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Release";
		}

		public Release(Release source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
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
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
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
		/// План. дата релиза.
		/// </summary>
		public DateTime ScheduledReleaseDate {
			get {
				return GetTypedColumnValue<DateTime>("ScheduledReleaseDate");
			}
			set {
				SetColumnValue("ScheduledReleaseDate", value);
			}
		}

		/// <summary>
		/// План. трудозатраты (часов).
		/// </summary>
		public int PlannedLabor {
			get {
				return GetTypedColumnValue<int>("PlannedLabor");
			}
			set {
				SetColumnValue("PlannedLabor", value);
			}
		}

		/// <summary>
		/// Факт. дата релиза.
		/// </summary>
		public DateTime ReleasedOn {
			get {
				return GetTypedColumnValue<DateTime>("ReleasedOn");
			}
			set {
				SetColumnValue("ReleasedOn", value);
			}
		}

		/// <summary>
		/// Факт. завершение разработки.
		/// </summary>
		public DateTime DevelopmentFinishedOn {
			get {
				return GetTypedColumnValue<DateTime>("DevelopmentFinishedOn");
			}
			set {
				SetColumnValue("DevelopmentFinishedOn", value);
			}
		}

		/// <summary>
		/// Факт. завершение тестирования.
		/// </summary>
		public DateTime TestingFinishedOn {
			get {
				return GetTypedColumnValue<DateTime>("TestingFinishedOn");
			}
			set {
				SetColumnValue("TestingFinishedOn", value);
			}
		}

		/// <summary>
		/// Факт. завершение развертывания.
		/// </summary>
		public DateTime DeploymentFinishedOn {
			get {
				return GetTypedColumnValue<DateTime>("DeploymentFinishedOn");
			}
			set {
				SetColumnValue("DeploymentFinishedOn", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты.
		/// </summary>
		public int ActualLabor {
			get {
				return GetTypedColumnValue<int>("ActualLabor");
			}
			set {
				SetColumnValue("ActualLabor", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты на разработку.
		/// </summary>
		public int ActualDevelopmentLabor {
			get {
				return GetTypedColumnValue<int>("ActualDevelopmentLabor");
			}
			set {
				SetColumnValue("ActualDevelopmentLabor", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты на тестирование.
		/// </summary>
		public int ActualTestingLabor {
			get {
				return GetTypedColumnValue<int>("ActualTestingLabor");
			}
			set {
				SetColumnValue("ActualTestingLabor", value);
			}
		}

		/// <summary>
		/// Факт. трудозатраты на развертывание.
		/// </summary>
		public int ActualDeploymentLabor {
			get {
				return GetTypedColumnValue<int>("ActualDeploymentLabor");
			}
			set {
				SetColumnValue("ActualDeploymentLabor", value);
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

		private ReleaseStatus _status;
		/// <summary>
		/// Состояние.
		/// </summary>
		public ReleaseStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as ReleaseStatus);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ReleaseType _type;
		/// <summary>
		/// Тип.
		/// </summary>
		public ReleaseType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ReleaseType);
			}
		}

		/// <exclude/>
		public Guid PriorityId {
			get {
				return GetTypedColumnValue<Guid>("PriorityId");
			}
			set {
				SetColumnValue("PriorityId", value);
				_priority = null;
			}
		}

		/// <exclude/>
		public string PriorityName {
			get {
				return GetTypedColumnValue<string>("PriorityName");
			}
			set {
				SetColumnValue("PriorityName", value);
				if (_priority != null) {
					_priority.Name = value;
				}
			}
		}

		private ReleasePriority _priority;
		/// <summary>
		/// Приоритет.
		/// </summary>
		public ReleasePriority Priority {
			get {
				return _priority ??
					(_priority = LookupColumnEntities.GetEntity("Priority") as ReleasePriority);
			}
		}

		/// <summary>
		/// Примечание.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Release_ReleaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ReleaseDeleted", e);
			Validating += (s, e) => ThrowEvent("ReleaseValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Release(this);
		}

		#endregion

	}

	#endregion

	#region Class: Release_ReleaseEventsProcess

	/// <exclude/>
	public partial class Release_ReleaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Release
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Release_ReleaseEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("7964da2c-bc3f-4238-9e36-bfb4c8fd8676");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Release_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Release_ReleaseEventsProcess";
			SchemaUId = new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0bf3a274-e5da-4fc7-94c4-3ae233598714");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private ProcessFlowElement _startMessage1;
		public ProcessFlowElement StartMessage1 {
			get {
				return _startMessage1 ?? (_startMessage1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage1",
					SchemaElementUId = new Guid("256595bc-5fe1-4330-9a94-09c0ecc4fe03"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessTerminateEvent _terminate1;
		public ProcessTerminateEvent Terminate1 {
			get {
				return _terminate1 ?? (_terminate1 = new ProcessTerminateEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaTerminateEvent",
					Name = "Terminate1",
					SchemaElementUId = new Guid("570269de-ad70-4fdf-b900-76d687058e82"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("ea7d164d-078a-454f-8310-67d0ec11c85e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("72925bb0-b2b5-4a04-b81a-d0dd8f4d0fe0"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessScriptTask _scriptTask2;
		public ProcessScriptTask ScriptTask2 {
			get {
				return _scriptTask2 ?? (_scriptTask2 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask2",
					SchemaElementUId = new Guid("86b0c6ed-93f2-4470-b27e-d98d13295b43"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask2Execute,
				});
			}
		}

		private ProcessConditionalFlow _conditionalFlow1;
		public ProcessConditionalFlow ConditionalFlow1 {
			get {
				return _conditionalFlow1 ?? (_conditionalFlow1 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1",
					SchemaElementUId = new Guid("7f2f8e6d-5e7f-4749-a080-22c80c1405c6"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[StartMessage1.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage1 };
			FlowElements[Terminate1.SchemaElementUId] = new Collection<ProcessFlowElement> { Terminate1 };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[ScriptTask2.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask2 };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "StartMessage1":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "Terminate1":
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("ScriptTask1");
							break;
						}
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("ScriptTask2");
						break;
					case "ScriptTask2":
						e.Context.QueueTasks.Enqueue("Terminate1");
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
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
			switch (context.QueueTasks.Peek()) {
				case "StartMessage1":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage1";
					result = StartMessage1.Execute(context);
					break;
				case "Terminate1":
					context.QueueTasks.Dequeue();
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "ScriptTask2":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask2";
					result = ScriptTask2.Execute(context, ScriptTask2Execute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool ScriptTask2Execute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			if(!string.IsNullOrEmpty(code)) {
				Entity.SetColumnValue("Number", code);
				Entity.Save(false);
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Release_ReleaseEventsProcess

	/// <exclude/>
	public class Release_ReleaseEventsProcess : Release_ReleaseEventsProcess<Release>
	{

		public Release_ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Release_ReleaseEventsProcess

	public partial class Release_ReleaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void LocalMessageExecuting(EntityChangeType changeType) {
			var lmHelper = new BPMSoft.Configuration.LocalMessageHelper(this.Entity, UserConnection, changeType);
			lmHelper.CreateLocalMessage();
		}

		#endregion

	}

	#endregion


	#region Class: ReleaseEventsProcess

	/// <exclude/>
	public class ReleaseEventsProcess : Release_ReleaseEventsProcess
	{

		public ReleaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

