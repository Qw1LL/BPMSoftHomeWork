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

	#region Class: VwSysSchemaInWorkspaceSchema

	/// <exclude/>
	public class VwSysSchemaInWorkspaceSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwSysSchemaInWorkspaceSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSchemaInWorkspaceSchema(VwSysSchemaInWorkspaceSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSchemaInWorkspaceSchema(VwSysSchemaInWorkspaceSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			RealUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			Name = "VwSysSchemaInWorkspace";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("461026e1-dfef-4930-8932-3abfec366e3a")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5480f92c-1fb9-4b5d-b746-bf7ebb287bd2")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("da117639-d176-4cc9-b5a9-d7e02d010d12")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("2af92d75-c620-4ba9-8e4e-1313822aa857")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("fa7aa79d-b5d3-4731-a0c8-e3297eb20044")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
			if (Columns.FindByUId(new Guid("3f3236b1-ee2b-4f7f-a1bb-8ae954cc9b89")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("9bd6738c-8e5c-4919-bc71-bc7ee7da7101")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
			if (Columns.FindByUId(new Guid("750fa50e-a1eb-4364-8543-75a84cd97d4c")) == null) {
				Columns.Add(CreateMetaDataColumn());
			}
			if (Columns.FindByUId(new Guid("214ef9e1-8cf7-4c8c-aedc-03fd21654fb2")) == null) {
				Columns.Add(CreateMetaDataModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("6780620a-8dd4-45f4-97c7-9bf42140ead7")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("ee673217-e64e-4049-91ff-d3d8e10cbf27")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("eba0017c-e0bb-4bb3-89e6-e71572081dd7")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("1ae1e084-b27a-4812-acd7-500e96a84786")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("bd21a4d8-389f-45dd-99cf-5607e1bba2b8")) == null) {
				Columns.Add(CreateNeedUpdateSourceCodeColumn());
			}
			if (Columns.FindByUId(new Guid("23f7d4b5-c8d9-4d64-9cf9-f4215ebbb511")) == null) {
				Columns.Add(CreateNeedUpdateStructureColumn());
			}
			if (Columns.FindByUId(new Guid("3d9641c0-06f6-4c10-8f30-8ccd9dce7fbe")) == null) {
				Columns.Add(CreateNeedInstallColumn());
			}
			if (Columns.FindByUId(new Guid("34b6d513-c87d-52fe-f277-530d38d06055")) == null) {
				Columns.Add(CreateNeedAngularCompileColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("461026e1-dfef-4930-8932-3abfec366e3a"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("5480f92c-1fb9-4b5d-b746-bf7ebb287bd2"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("c97f8e06-d4ec-418a-9a9e-819c86536812"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("da117639-d176-4cc9-b5a9-d7e02d010d12"),
				Name = @"ManagerName",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2af92d75-c620-4ba9-8e4e-1313822aa857"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fa7aa79d-b5d3-4731-a0c8-e3297eb20044"),
				Name = @"ExtendParent",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3f3236b1-ee2b-4f7f-a1bb-8ae954cc9b89"),
				Name = @"IsChanged",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9bd6738c-8e5c-4919-bc71-bc7ee7da7101"),
				Name = @"IsLocked",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("750fa50e-a1eb-4364-8543-75a84cd97d4c"),
				Name = @"MetaData",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("214ef9e1-8cf7-4c8c-aedc-03fd21654fb2"),
				Name = @"MetaDataModifiedOn",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6780620a-8dd4-45f4-97c7-9bf42140ead7"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ee673217-e64e-4049-91ff-d3d8e10cbf27"),
				Name = @"PackageUId",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("eba0017c-e0bb-4bb3-89e6-e71572081dd7"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("1ae1e084-b27a-4812-acd7-500e96a84786"),
				Name = @"Description",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedUpdateSourceCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("bd21a4d8-389f-45dd-99cf-5607e1bba2b8"),
				Name = @"NeedUpdateSourceCode",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedUpdateStructureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("23f7d4b5-c8d9-4d64-9cf9-f4215ebbb511"),
				Name = @"NeedUpdateStructure",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedInstallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3d9641c0-06f6-4c10-8f30-8ccd9dce7fbe"),
				Name = @"NeedInstall",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedAngularCompileColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("34b6d513-c87d-52fe-f277-530d38d06055"),
				Name = @"NeedAngularCompile",
				CreatedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				ModifiedInSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSchemaInWorkspace(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSchemaInWorkspace_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSchemaInWorkspaceSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSchemaInWorkspaceSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4fe60977-c711-48b2-8499-1cebbecf7868"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInWorkspace

	/// <summary>
	/// Элемент рабочего пространства (представление).
	/// </summary>
	public class VwSysSchemaInWorkspace : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwSysSchemaInWorkspace(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSchemaInWorkspace";
		}

		public VwSysSchemaInWorkspace(VwSysSchemaInWorkspace source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// UId.
		/// </summary>
		public Guid UId {
			get {
				return GetTypedColumnValue<Guid>("UId");
			}
			set {
				SetColumnValue("UId", value);
			}
		}

		/// <summary>
		/// Название.
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
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Имя менеджера.
		/// </summary>
		public string ManagerName {
			get {
				return GetTypedColumnValue<string>("ManagerName");
			}
			set {
				SetColumnValue("ManagerName", value);
			}
		}

		/// <exclude/>
		public Guid ParentId {
			get {
				return GetTypedColumnValue<Guid>("ParentId");
			}
			set {
				SetColumnValue("ParentId", value);
				_parent = null;
			}
		}

		/// <exclude/>
		public string ParentCaption {
			get {
				return GetTypedColumnValue<string>("ParentCaption");
			}
			set {
				SetColumnValue("ParentCaption", value);
				if (_parent != null) {
					_parent.Caption = value;
				}
			}
		}

		private SysSchema _parent;
		/// <summary>
		/// Родитель.
		/// </summary>
		public SysSchema Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysSchema);
			}
		}

		/// <summary>
		/// Расширяет родителя.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
			}
		}

		/// <summary>
		/// Изменен.
		/// </summary>
		public bool IsChanged {
			get {
				return GetTypedColumnValue<bool>("IsChanged");
			}
			set {
				SetColumnValue("IsChanged", value);
			}
		}

		/// <summary>
		/// Заблокирован.
		/// </summary>
		public bool IsLocked {
			get {
				return GetTypedColumnValue<bool>("IsLocked");
			}
			set {
				SetColumnValue("IsLocked", value);
			}
		}

		/// <summary>
		/// Метаданные изменено.
		/// </summary>
		public DateTime MetaDataModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("MetaDataModifiedOn");
			}
			set {
				SetColumnValue("MetaDataModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid SysPackageId {
			get {
				return GetTypedColumnValue<Guid>("SysPackageId");
			}
			set {
				SetColumnValue("SysPackageId", value);
				_sysPackage = null;
			}
		}

		/// <exclude/>
		public string SysPackageName {
			get {
				return GetTypedColumnValue<string>("SysPackageName");
			}
			set {
				SetColumnValue("SysPackageName", value);
				if (_sysPackage != null) {
					_sysPackage.Name = value;
				}
			}
		}

		private SysPackage _sysPackage;
		/// <summary>
		/// Пакет.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Идентификатор пакета.
		/// </summary>
		public Guid PackageUId {
			get {
				return GetTypedColumnValue<Guid>("PackageUId");
			}
			set {
				SetColumnValue("PackageUId", value);
			}
		}

		/// <exclude/>
		public Guid SysWorkspaceId {
			get {
				return GetTypedColumnValue<Guid>("SysWorkspaceId");
			}
			set {
				SetColumnValue("SysWorkspaceId", value);
				_sysWorkspace = null;
			}
		}

		/// <exclude/>
		public string SysWorkspaceName {
			get {
				return GetTypedColumnValue<string>("SysWorkspaceName");
			}
			set {
				SetColumnValue("SysWorkspaceName", value);
				if (_sysWorkspace != null) {
					_sysWorkspace.Name = value;
				}
			}
		}

		private SysWorkspace _sysWorkspace;
		/// <summary>
		/// Рабочее пространство.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
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
		/// Необходимо обновление исходных кодов.
		/// </summary>
		public bool NeedUpdateSourceCode {
			get {
				return GetTypedColumnValue<bool>("NeedUpdateSourceCode");
			}
			set {
				SetColumnValue("NeedUpdateSourceCode", value);
			}
		}

		/// <summary>
		/// Необходимо обновить таблицу в базе данных.
		/// </summary>
		public bool NeedUpdateStructure {
			get {
				return GetTypedColumnValue<bool>("NeedUpdateStructure");
			}
			set {
				SetColumnValue("NeedUpdateStructure", value);
			}
		}

		/// <summary>
		/// Требует инсталяции.
		/// </summary>
		public bool NeedInstall {
			get {
				return GetTypedColumnValue<bool>("NeedInstall");
			}
			set {
				SetColumnValue("NeedInstall", value);
			}
		}

		/// <summary>
		/// Требует компилировать Angular модуль.
		/// </summary>
		public bool NeedAngularCompile {
			get {
				return GetTypedColumnValue<bool>("NeedAngularCompile");
			}
			set {
				SetColumnValue("NeedAngularCompile", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysSchemaInWorkspace_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceDeleted", e);
			Deleting += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceInserted", e);
			Inserting += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceInserting", e);
			Saved += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceSaved", e);
			Saving += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceSaving", e);
			Validating += (s, e) => ThrowEvent("VwSysSchemaInWorkspaceValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwSysSchemaInWorkspace(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSchemaInWorkspace_BaseEventsProcess

	/// <exclude/>
	public partial class VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwSysSchemaInWorkspace
	{

		public VwSysSchemaInWorkspace_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSchemaInWorkspace_BaseEventsProcess";
			SchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
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

	#region Class: VwSysSchemaInWorkspace_BaseEventsProcess

	/// <exclude/>
	public class VwSysSchemaInWorkspace_BaseEventsProcess : VwSysSchemaInWorkspace_BaseEventsProcess<VwSysSchemaInWorkspace>
	{

		public VwSysSchemaInWorkspace_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSchemaInWorkspace_BaseEventsProcess

	public partial class VwSysSchemaInWorkspace_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSchemaInWorkspaceEventsProcess

	/// <exclude/>
	public class VwSysSchemaInWorkspaceEventsProcess : VwSysSchemaInWorkspace_BaseEventsProcess
	{

		public VwSysSchemaInWorkspaceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

