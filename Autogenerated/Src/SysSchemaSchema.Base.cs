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

	#region Class: SysSchema_Base_BPMSoftSchema

	/// <exclude/>
	public class SysSchema_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSchema_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSchema_Base_BPMSoftSchema(SysSchema_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSchema_Base_BPMSoftSchema(SysSchema_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysSchemaManagerPackageIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5b31c27f-b99e-4fae-8520-333e0b3dbd58");
			index.Name = "ISysSchemaManagerPackage";
			index.CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			index.ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			index.CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf");
			EntitySchemaIndexColumn managerNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("1a65e761-41f2-4800-8609-2d3ce058fbd5"),
				ColumnUId = new Guid("b16558a9-019e-4fc5-b341-2f17fffcfa1e"),
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(managerNameIndexColumn);
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("5d07ff36-556e-4ff9-ab61-eee7d7897e46"),
				ColumnUId = new Guid("dd68d792-9b3e-40f0-98b8-74b536fa3767"),
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("6ff020f5-e34d-4da9-8c0d-3678e6f20dbf"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			RealUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			Name = "SysSchema_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
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
			if (Columns.FindByUId(new Guid("b16558a9-019e-4fc5-b341-2f17fffcfa1e")) == null) {
				Columns.Add(CreateManagerNameColumn());
			}
			if (Columns.FindByUId(new Guid("1896c092-3291-47b9-a513-eb7d1451f4a4")) == null) {
				Columns.Add(CreateLockedByColumn());
			}
			if (Columns.FindByUId(new Guid("ed98cf3e-1642-4755-acb2-a61181429306")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("6956d3c9-b4dc-4b45-9c37-ad32fb7c93ce")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("209903f5-b0b7-4bd4-b5ac-3e459358be7b")) == null) {
				Columns.Add(CreateParentColumn());
			}
			if (Columns.FindByUId(new Guid("d3d6287a-347d-460e-ac59-42a6bb4962de")) == null) {
				Columns.Add(CreateMetaDataColumn());
			}
			if (Columns.FindByUId(new Guid("dd68d792-9b3e-40f0-98b8-74b536fa3767")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("c0c36254-4754-47d4-95dd-90f54636538f")) == null) {
				Columns.Add(CreateMetaDataModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("ff4129ad-c6e6-43cd-85fa-d9c2562fc783")) == null) {
				Columns.Add(CreateExtendParentColumn());
			}
			if (Columns.FindByUId(new Guid("68bce10a-5ab0-4087-b36c-6501df9161c5")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("cbde3279-c50c-436b-8182-aec00f9bc8b7")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("8acd1b9c-b41c-476a-9a09-b2ba6d6812af")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
			if (Columns.FindByUId(new Guid("a4328242-f637-44e3-9dc7-41a1780679e5")) == null) {
				Columns.Add(CreateClientContentModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("99fbe553-a792-4897-8f94-78a700591260")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
			if (Columns.FindByUId(new Guid("556c11e6-431e-4f34-b340-a154d8a16c20")) == null) {
				Columns.Add(CreateDescriptorColumn());
			}
			if (Columns.FindByUId(new Guid("cf537e5b-3df1-4483-88b8-c35c0ba20b5a")) == null) {
				Columns.Add(CreateDenyExtendingColumn());
			}
			if (Columns.FindByUId(new Guid("0aff5e02-7ffd-48ad-9903-217c7ba491a0")) == null) {
				Columns.Add(CreateIncludeDependenciesSourceColumn());
			}
			if (Columns.FindByUId(new Guid("ea4514e1-5a54-402d-bd2f-264213b204fa")) == null) {
				Columns.Add(CreateChecksumColumn());
			}
			if (Columns.FindByUId(new Guid("9e848173-c4cd-40a1-b12b-80a8f6731fe8")) == null) {
				Columns.Add(CreateStructureModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("1a67f0c0-a30b-439e-bc27-68e274196603")) == null) {
				Columns.Add(CreateIsNetStandardColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateManagerNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b16558a9-019e-4fc5-b341-2f17fffcfa1e"),
				Name = @"ManagerName",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateLockedByColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1896c092-3291-47b9-a513-eb7d1451f4a4"),
				Name = @"LockedBy",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("ed98cf3e-1642-4755-acb2-a61181429306"),
				Name = @"UId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("6956d3c9-b4dc-4b45-9c37-ad32fb7c93ce"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a6a36da5-b401-4192-8369-5acd607142df"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("209903f5-b0b7-4bd4-b5ac-3e459358be7b"),
				Name = @"Parent",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("d3d6287a-347d-460e-ac59-42a6bb4962de"),
				Name = @"MetaData",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dd68d792-9b3e-40f0-98b8-74b536fa3767"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMetaDataModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c0c36254-4754-47d4-95dd-90f54636538f"),
				Name = @"MetaDataModifiedOn",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateExtendParentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ff4129ad-c6e6-43cd-85fa-d9c2562fc783"),
				Name = @"ExtendParent",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("68bce10a-5ab0-4087-b36c-6501df9161c5"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cbde3279-c50c-436b-8182-aec00f9bc8b7"),
				Name = @"IsChanged",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8acd1b9c-b41c-476a-9a09-b2ba6d6812af"),
				Name = @"IsLocked",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"False"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateClientContentModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a4328242-f637-44e3-9dc7-41a1780679e5"),
				Name = @"ClientContentModifiedOn",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("ae30d032-d762-4543-9b23-f4ddeb135bae"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("99fbe553-a792-4897-8f94-78a700591260"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866")
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("556c11e6-431e-4f34-b340-a154d8a16c20"),
				Name = @"Descriptor",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("b40b5a4a-23e9-4656-9186-2b322b13e540")
			};
		}

		protected virtual EntitySchemaColumn CreateDenyExtendingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cf537e5b-3df1-4483-88b8-c35c0ba20b5a"),
				Name = @"DenyExtending",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("7982ba2e-e00c-4ba0-b47d-79bd8bb1a62a")
			};
		}

		protected virtual EntitySchemaColumn CreateIncludeDependenciesSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0aff5e02-7ffd-48ad-9903-217c7ba491a0"),
				Name = @"IncludeDependenciesSource",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("9b196c84-89cf-4b9e-9120-deecdf5c1c93")
			};
		}

		protected virtual EntitySchemaColumn CreateChecksumColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("ea4514e1-5a54-402d-bd2f-264213b204fa"),
				Name = @"Checksum",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateStructureModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("9e848173-c4cd-40a1-b12b-80a8f6731fe8"),
				Name = @"StructureModifiedOn",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateIsNetStandardColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("1a67f0c0-a30b-439e-bc27-68e274196603"),
				Name = @"IsNetStandard",
				CreatedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				ModifiedInSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				CreatedInPackageId = new Guid("448b4c22-2f53-45d3-8026-9d68c6400262"),
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

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysSchemaManagerPackageIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSchema_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSchema_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSchema_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSchema_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSchema_Base_BPMSoft

	/// <summary>
	/// Schema.
	/// </summary>
	public class SysSchema_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSchema_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSchema_Base_BPMSoft";
		}

		public SysSchema_Base_BPMSoft(SysSchema_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Manager.
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
		public Guid LockedById {
			get {
				return GetTypedColumnValue<Guid>("LockedById");
			}
			set {
				SetColumnValue("LockedById", value);
				_lockedBy = null;
			}
		}

		/// <exclude/>
		public string LockedByName {
			get {
				return GetTypedColumnValue<string>("LockedByName");
			}
			set {
				SetColumnValue("LockedByName", value);
				if (_lockedBy != null) {
					_lockedBy.Name = value;
				}
			}
		}

		private SysAdminUnit _lockedBy;
		/// <summary>
		/// Locked by.
		/// </summary>
		public SysAdminUnit LockedBy {
			get {
				return _lockedBy ??
					(_lockedBy = LookupColumnEntities.GetEntity("LockedBy") as SysAdminUnit);
			}
		}

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
		/// Parent schema.
		/// </summary>
		public SysSchema Parent {
			get {
				return _parent ??
					(_parent = LookupColumnEntities.GetEntity("Parent") as SysSchema);
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
		/// Package.
		/// </summary>
		public SysPackage SysPackage {
			get {
				return _sysPackage ??
					(_sysPackage = LookupColumnEntities.GetEntity("SysPackage") as SysPackage);
			}
		}

		/// <summary>
		/// Metadata changed.
		/// </summary>
		public DateTime MetaDataModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("MetaDataModifiedOn");
			}
			set {
				SetColumnValue("MetaDataModifiedOn", value);
			}
		}

		/// <summary>
		/// Replace parent.
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

		/// <summary>
		/// Schema is modified.
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
		/// Schema is locked.
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
		/// Client module updated on.
		/// </summary>
		public DateTime ClientContentModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ClientContentModifiedOn");
			}
			set {
				SetColumnValue("ClientContentModifiedOn", value);
			}
		}

		/// <summary>
		/// Last error message text.
		/// </summary>
		public string LastError {
			get {
				return GetTypedColumnValue<string>("LastError");
			}
			set {
				SetColumnValue("LastError", value);
			}
		}

		/// <summary>
		/// Forbid substitution.
		/// </summary>
		public bool DenyExtending {
			get {
				return GetTypedColumnValue<bool>("DenyExtending");
			}
			set {
				SetColumnValue("DenyExtending", value);
			}
		}

		/// <summary>
		/// Enable dependent client schemas code.
		/// </summary>
		public bool IncludeDependenciesSource {
			get {
				return GetTypedColumnValue<bool>("IncludeDependenciesSource");
			}
			set {
				SetColumnValue("IncludeDependenciesSource", value);
			}
		}

		/// <summary>
		/// Checksum.
		/// </summary>
		public string Checksum {
			get {
				return GetTypedColumnValue<string>("Checksum");
			}
			set {
				SetColumnValue("Checksum", value);
			}
		}

		/// <summary>
		/// Database Structure Modified On.
		/// </summary>
		public DateTime StructureModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("StructureModifiedOn");
			}
			set {
				SetColumnValue("StructureModifiedOn", value);
			}
		}

		/// <summary>
		/// .Net Standard Compatible.
		/// </summary>
		public bool IsNetStandard {
			get {
				return GetTypedColumnValue<bool>("IsNetStandard");
			}
			set {
				SetColumnValue("IsNetStandard", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSchema_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("SysSchema_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSchema_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSchema_BaseEventsProcess

	/// <exclude/>
	public partial class SysSchema_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSchema_Base_BPMSoft
	{

		public SysSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSchema_BaseEventsProcess";
			SchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("6c7394db-06ff-4050-91ef-8278e21dce15");
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

	#region Class: SysSchema_BaseEventsProcess

	/// <exclude/>
	public class SysSchema_BaseEventsProcess : SysSchema_BaseEventsProcess<SysSchema_Base_BPMSoft>
	{

		public SysSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSchema_BaseEventsProcess

	public partial class SysSchema_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

