namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwSysDcmLib_DcmDesigner_BPMSoftSchema

	/// <exclude/>
	public class VwSysDcmLib_DcmDesigner_BPMSoftSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysDcmLib_DcmDesigner_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysDcmLib_DcmDesigner_BPMSoftSchema(VwSysDcmLib_DcmDesigner_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysDcmLib_DcmDesigner_BPMSoftSchema(VwSysDcmLib_DcmDesigner_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a");
			RealUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a");
			Name = "VwSysDcmLib_DcmDesigner_BPMSoft";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeCreatedOnColumn() {
			base.InitializeCreatedOnColumn();
			CreatedOnColumn = CreateCreatedOnColumn();
			if (Columns.FindByUId(CreatedOnColumn.UId) == null) {
				Columns.Add(CreatedOnColumn);
			}
		}

		protected override void InitializeCreatedByColumn() {
			base.InitializeCreatedByColumn();
			CreatedByColumn = CreateCreatedByColumn();
			if (Columns.FindByUId(CreatedByColumn.UId) == null) {
				Columns.Add(CreatedByColumn);
			}
		}

		protected override void InitializeModifiedOnColumn() {
			base.InitializeModifiedOnColumn();
			ModifiedOnColumn = CreateModifiedOnColumn();
			if (Columns.FindByUId(ModifiedOnColumn.UId) == null) {
				Columns.Add(ModifiedOnColumn);
			}
		}

		protected override void InitializeModifiedByColumn() {
			base.InitializeModifiedByColumn();
			ModifiedByColumn = CreateModifiedByColumn();
			if (Columns.FindByUId(ModifiedByColumn.UId) == null) {
				Columns.Add(ModifiedByColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2eab78fa-7ebd-4ac7-9b2d-e96d92503851")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("938c231c-de1c-447c-95bf-5c135976a55b")) == null) {
				Columns.Add(CreatePackageUIdColumn());
			}
			if (Columns.FindByUId(new Guid("e2292273-d7a1-4e76-8afb-46467e8942d1")) == null) {
				Columns.Add(CreateSysWorkspaceColumn());
			}
			if (Columns.FindByUId(new Guid("b52da5b4-8de9-442c-b55b-9db6504c0ade")) == null) {
				Columns.Add(CreateStageColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("c613316d-3d42-4f0d-b7d8-719da3b6f92b")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("5d7148b1-326c-4b54-bda3-f287d6ce2b23")) == null) {
				Columns.Add(CreateIsActiveColumn());
			}
			if (Columns.FindByUId(new Guid("f0a960e9-6853-4e63-b137-40afbc665f2c")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("482fd914-b97f-4310-9a19-fb81d82fd581")) == null) {
				Columns.Add(CreateFiltersColumn());
			}
			if (Columns.FindByUId(new Guid("40084b18-2ec4-4192-8f7c-d79c8cc2f07e")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("fe987912-1849-4c69-b2ab-0333c8af8524")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
			if (Columns.FindByUId(new Guid("47ae9c04-c735-4cb0-bb3b-e6bb66b46163")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
			if (Columns.FindByUId(new Guid("20534757-35e6-4d40-9974-279ffe36668f")) == null) {
				Columns.Add(CreatePackageColumn());
			}
			if (Columns.FindByUId(new Guid("1040039c-3245-452b-9cf4-506cca94274f")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("9010f7be-0416-401d-8ae9-bd0acee13978")) == null) {
				Columns.Add(CreateVersionParentIdColumn());
			}
			if (Columns.FindByUId(new Guid("d2f888cd-95ff-46aa-a384-3ca0fc753c8a")) == null) {
				Columns.Add(CreateVersionParentUIdColumn());
			}
			if (Columns.FindByUId(new Guid("25cf31c8-5e36-408f-ba5f-c3efa4cae289")) == null) {
				Columns.Add(CreateIsActiveVersionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f24251f7-35a6-420b-9b87-5a17bb96ba31"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("89505988-362b-49bd-9952-526a02ad2157"),
				Name = @"CreatedOn",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5240a6f9-3c2b-4c9d-8d8d-50689743d3ab"),
				Name = @"CreatedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("465e6579-2f28-4741-a3d6-8d8161f63c7d"),
				Name = @"ModifiedOn",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74a3f96e-a94e-4149-87aa-73273168bc02"),
				Name = @"ModifiedBy",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2eab78fa-7ebd-4ac7-9b2d-e96d92503851"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e8054d3e-0a4c-47e8-bf03-b42abc17088b"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreatePackageUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("938c231c-de1c-447c-95bf-5c135976a55b"),
				Name = @"PackageUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateSysWorkspaceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e2292273-d7a1-4e76-8afb-46467e8942d1"),
				Name = @"SysWorkspace",
				ReferenceSchemaUId = new Guid("7f9653ec-2e91-4aaa-a065-7b1d46edd292"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b52da5b4-8de9-442c-b55b-9db6504c0ade"),
				Name = @"StageColumnUId",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c613316d-3d42-4f0d-b7d8-719da3b6f92b"),
				Name = @"EntitySchemaUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5d7148b1-326c-4b54-bda3-f287d6ce2b23"),
				Name = @"IsActive",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f0a960e9-6853-4e63-b137-40afbc665f2c"),
				Name = @"UId",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateFiltersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("482fd914-b97f-4310-9a19-fb81d82fd581"),
				Name = @"Filters",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("40084b18-2ec4-4192-8f7c-d79c8cc2f07e"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("fe987912-1849-4c69-b2ab-0333c8af8524"),
				Name = @"IsLocked",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("47ae9c04-c735-4cb0-bb3b-e6bb66b46163"),
				Name = @"ExtendParent",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("60220118-8883-44e1-afa4-8845f944d697")
			};
		}

		protected virtual EntitySchemaColumn CreatePackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("20534757-35e6-4d40-9974-279ffe36668f"),
				Name = @"Package",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("7533f56f-3117-4576-81a1-adfb1d3a9acf")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1040039c-3245-452b-9cf4-506cca94274f"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("8845a742-fc2f-4257-9e85-1e20cf35a908")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionParentIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("9010f7be-0416-401d-8ae9-bd0acee13978"),
				Name = @"VersionParentId",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("8845a742-fc2f-4257-9e85-1e20cf35a908")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionParentUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d2f888cd-95ff-46aa-a384-3ca0fc753c8a"),
				Name = @"VersionParentUId",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("8845a742-fc2f-4257-9e85-1e20cf35a908")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("25cf31c8-5e36-408f-ba5f-c3efa4cae289"),
				Name = @"IsActiveVersion",
				CreatedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				ModifiedInSchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"),
				CreatedInPackageId = new Guid("e75317a1-ca8b-4560-8d14-e93026bb777b")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysDcmLib_DcmDesigner_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysDcmLib_DcmDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysDcmLib_DcmDesigner_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysDcmLib_DcmDesigner_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLib_DcmDesigner_BPMSoft

	/// <summary>
	/// Dcm library (view).
	/// </summary>
	public class VwSysDcmLib_DcmDesigner_BPMSoft : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysDcmLib_DcmDesigner_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysDcmLib_DcmDesigner_BPMSoft";
		}

		public VwSysDcmLib_DcmDesigner_BPMSoft(VwSysDcmLib_DcmDesigner_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id {
			get {
				return GetTypedColumnValue<Guid>("Id");
			}
			set {
				SetColumnValue("Id", value);
			}
		}

		/// <summary>
		/// Created on.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <exclude/>
		public Guid CreatedById {
			get {
				return GetTypedColumnValue<Guid>("CreatedById");
			}
			set {
				SetColumnValue("CreatedById", value);
				_createdBy = null;
			}
		}

		/// <exclude/>
		public string CreatedByName {
			get {
				return GetTypedColumnValue<string>("CreatedByName");
			}
			set {
				SetColumnValue("CreatedByName", value);
				if (_createdBy != null) {
					_createdBy.Name = value;
				}
			}
		}

		private Contact _createdBy;
		/// <summary>
		/// Created by.
		/// </summary>
		public Contact CreatedBy {
			get {
				return _createdBy ??
					(_createdBy = LookupColumnEntities.GetEntity("CreatedBy") as Contact);
			}
		}

		/// <summary>
		/// Modified on.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <exclude/>
		public Guid ModifiedById {
			get {
				return GetTypedColumnValue<Guid>("ModifiedById");
			}
			set {
				SetColumnValue("ModifiedById", value);
				_modifiedBy = null;
			}
		}

		/// <exclude/>
		public string ModifiedByName {
			get {
				return GetTypedColumnValue<string>("ModifiedByName");
			}
			set {
				SetColumnValue("ModifiedByName", value);
				if (_modifiedBy != null) {
					_modifiedBy.Name = value;
				}
			}
		}

		private Contact _modifiedBy;
		/// <summary>
		/// Modified by.
		/// </summary>
		public Contact ModifiedBy {
			get {
				return _modifiedBy ??
					(_modifiedBy = LookupColumnEntities.GetEntity("ModifiedBy") as Contact);
			}
		}

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
		/// Title.
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
		/// Package identifier.
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
		/// Workspace.
		/// </summary>
		public SysWorkspace SysWorkspace {
			get {
				return _sysWorkspace ??
					(_sysWorkspace = LookupColumnEntities.GetEntity("SysWorkspace") as SysWorkspace);
			}
		}

		/// <summary>
		/// Stage column.
		/// </summary>
		public Guid StageColumnUId {
			get {
				return GetTypedColumnValue<Guid>("StageColumnUId");
			}
			set {
				SetColumnValue("StageColumnUId", value);
			}
		}

		/// <summary>
		/// Entity schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		/// <remarks>
		/// Is Case Active.
		/// </remarks>
		public bool IsActive {
			get {
				return GetTypedColumnValue<bool>("IsActive");
			}
			set {
				SetColumnValue("IsActive", value);
			}
		}

		/// <summary>
		/// Dcm schema unique identifier.
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
		/// Filters.
		/// </summary>
		public string Filters {
			get {
				return GetTypedColumnValue<string>("Filters");
			}
			set {
				SetColumnValue("Filters", value);
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
		/// Parent.
		/// </summary>
		public SysSchema Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysSchema);
			}
		}

		/// <summary>
		/// Locked.
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
		/// Extends parent.
		/// </summary>
		public bool ExtendParent {
			get {
				return GetTypedColumnValue<bool>("ExtendParent");
			}
			set {
				SetColumnValue("ExtendParent", value);
			}
		}

		/// <exclude/>
		public Guid PackageId {
			get {
				return GetTypedColumnValue<Guid>("PackageId");
			}
			set {
				SetColumnValue("PackageId", value);
				_package = null;
			}
		}

		/// <exclude/>
		public string PackageName {
			get {
				return GetTypedColumnValue<string>("PackageName");
			}
			set {
				SetColumnValue("PackageName", value);
				if (_package != null) {
					_package.Name = value;
				}
			}
		}

		private SysPackage _package;
		/// <summary>
		/// Package.
		/// </summary>
		public SysPackage Package {
			get {
				return _package ??
					(_package = LookupColumnEntities.GetEntity("Package") as SysPackage);
			}
		}

		/// <summary>
		/// Version.
		/// </summary>
		public int Version {
			get {
				return GetTypedColumnValue<int>("Version");
			}
			set {
				SetColumnValue("Version", value);
			}
		}

		/// <summary>
		/// VersionParentId.
		/// </summary>
		public Guid VersionParentId {
			get {
				return GetTypedColumnValue<Guid>("VersionParentId");
			}
			set {
				SetColumnValue("VersionParentId", value);
			}
		}

		/// <summary>
		/// VersionParentUId.
		/// </summary>
		public Guid VersionParentUId {
			get {
				return GetTypedColumnValue<Guid>("VersionParentUId");
			}
			set {
				SetColumnValue("VersionParentUId", value);
			}
		}

		/// <summary>
		/// Actual version.
		/// </summary>
		public bool IsActiveVersion {
			get {
				return GetTypedColumnValue<bool>("IsActiveVersion");
			}
			set {
				SetColumnValue("IsActiveVersion", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwSysDcmLib_DcmDesignerEventsProcess(UserConnection);
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
			return new VwSysDcmLib_DcmDesigner_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysDcmLib_DcmDesignerEventsProcess

	/// <exclude/>
	public partial class VwSysDcmLib_DcmDesignerEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwSysDcmLib_DcmDesigner_BPMSoft
	{

		private TEntity _entity;
		public TEntity Entity {
			get {
				return _entity;
			}
			set {
				_entity = value;
			}
		}

		public VwSysDcmLib_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysDcmLib_DcmDesignerEventsProcess";
			SchemaUId = new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab972a77-ca14-4dd4-9d90-eaaae8b1197a");
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

	#region Class: VwSysDcmLib_DcmDesignerEventsProcess

	/// <exclude/>
	public class VwSysDcmLib_DcmDesignerEventsProcess : VwSysDcmLib_DcmDesignerEventsProcess<VwSysDcmLib_DcmDesigner_BPMSoft>
	{

		public VwSysDcmLib_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysDcmLib_DcmDesignerEventsProcess

	public partial class VwSysDcmLib_DcmDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

