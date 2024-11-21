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

	#region Class: VwProcessLibSchema

	/// <exclude/>
	public class VwProcessLibSchema : BPMSoft.Configuration.VwSysSchemaInWorkspaceSchema
	{

		#region Constructors: Public

		public VwProcessLibSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwProcessLibSchema(VwProcessLibSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwProcessLibSchema(VwProcessLibSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			RealUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			Name = "VwProcessLib";
			ParentSchemaUId = new Guid("4fe60977-c711-48b2-8499-1cebbecf7868");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryImageColumn() {
			base.InitializePrimaryImageColumn();
			PrimaryImageColumn = CreateStartOptionsImageColumn();
			if (Columns.FindByUId(PrimaryImageColumn.UId) == null) {
				Columns.Add(PrimaryImageColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("aa39f4a2-89f4-4fe5-9a93-34ca63594986")) == null) {
				Columns.Add(CreateIsMaxVersionColumn());
			}
			if (Columns.FindByUId(new Guid("933c568b-9be3-4f9a-b432-58bb827cb866")) == null) {
				Columns.Add(CreateTagPropertyColumn());
			}
			if (Columns.FindByUId(new Guid("33b69b02-abd8-4e5e-897d-f44eae93144b")) == null) {
				Columns.Add(CreateEnabledColumn());
			}
			if (Columns.FindByUId(new Guid("dc026ddc-b2c5-4078-a4b0-a73007ade51b")) == null) {
				Columns.Add(CreateVersionColumn());
			}
			if (Columns.FindByUId(new Guid("ac63ff57-c186-4a21-95f2-669953549c65")) == null) {
				Columns.Add(CreateProcessSchemaTypeColumn());
			}
			if (Columns.FindByUId(new Guid("f2c5391b-d8f4-4974-92cb-3802ae67c7a3")) == null) {
				Columns.Add(CreateSysSchemaIdColumn());
			}
			if (Columns.FindByUId(new Guid("81b88400-4e0e-4530-8f6f-67fcb721878a")) == null) {
				Columns.Add(CreateAddToRunButtonColumn());
			}
			if (Columns.FindByUId(new Guid("d49ae0f5-e9fd-40c4-b919-47ab597125bd")) == null) {
				Columns.Add(CreateIsActiveVersionColumn());
			}
			if (Columns.FindByUId(new Guid("1de3b2f1-3a47-4041-a535-0efa77fe51f2")) == null) {
				Columns.Add(CreateVersionParentIdColumn());
			}
			if (Columns.FindByUId(new Guid("9e279d32-36c3-4eed-ad11-2b23d7ab8bc5")) == null) {
				Columns.Add(CreateHasStartEventColumn());
			}
			if (Columns.FindByUId(new Guid("a4fa3c3e-bec2-4d8e-a821-26495d1c0163")) == null) {
				Columns.Add(CreateVersionParentUIdColumn());
			}
			if (Columns.FindByUId(new Guid("99d80984-5fbb-4cf2-8584-8213d093659f")) == null) {
				Columns.Add(CreateIsProcessTracingColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateUIdColumn() {
			EntitySchemaColumn column = base.CreateUIdColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateCaptionColumn() {
			EntitySchemaColumn column = base.CreateCaptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MediumText");
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateManagerNameColumn() {
			EntitySchemaColumn column = base.CreateManagerNameColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateParentColumn() {
			EntitySchemaColumn column = base.CreateParentColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateExtendParentColumn() {
			EntitySchemaColumn column = base.CreateExtendParentColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateIsChangedColumn() {
			EntitySchemaColumn column = base.CreateIsChangedColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateIsLockedColumn() {
			EntitySchemaColumn column = base.CreateIsLockedColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateMetaDataColumn() {
			EntitySchemaColumn column = base.CreateMetaDataColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateMetaDataModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateMetaDataModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateSysPackageColumn() {
			EntitySchemaColumn column = base.CreateSysPackageColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreatePackageUIdColumn() {
			EntitySchemaColumn column = base.CreatePackageUIdColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateSysWorkspaceColumn() {
			EntitySchemaColumn column = base.CreateSysWorkspaceColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNeedUpdateSourceCodeColumn() {
			EntitySchemaColumn column = base.CreateNeedUpdateSourceCodeColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNeedUpdateStructureColumn() {
			EntitySchemaColumn column = base.CreateNeedUpdateStructureColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected override EntitySchemaColumn CreateNeedInstallColumn() {
			EntitySchemaColumn column = base.CreateNeedInstallColumn();
			column.ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			column.CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae");
			return column;
		}

		protected virtual EntitySchemaColumn CreateIsMaxVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("aa39f4a2-89f4-4fe5-9a93-34ca63594986"),
				Name = @"IsMaxVersion",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae")
			};
		}

		protected virtual EntitySchemaColumn CreateTagPropertyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("933c568b-9be3-4f9a-b432-58bb827cb866"),
				Name = @"TagProperty",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae")
			};
		}

		protected virtual EntitySchemaColumn CreateEnabledColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("33b69b02-abd8-4e5e-897d-f44eae93144b"),
				Name = @"Enabled",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("0eb5b1d6-fd83-46d8-a1cb-e9910b6e64ae")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("dc026ddc-b2c5-4078-a4b0-a73007ade51b"),
				Name = @"Version",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessSchemaTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac63ff57-c186-4a21-95f2-669953549c65"),
				Name = @"ProcessSchemaType",
				ReferenceSchemaUId = new Guid("cd5b7045-5f50-4fff-9b87-a4036df2355a"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f2c5391b-d8f4-4974-92cb-3802ae67c7a3"),
				Name = @"SysSchemaId",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("42153226-7fbf-4ddd-9a0b-5c3f0ef85ffa")
			};
		}

		protected virtual EntitySchemaColumn CreateAddToRunButtonColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("81b88400-4e0e-4530-8f6f-67fcb721878a"),
				Name = @"AddToRunButton",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateIsActiveVersionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("d49ae0f5-e9fd-40c4-b919-47ab597125bd"),
				Name = @"IsActiveVersion",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("ce17b21e-a999-447b-99ee-1eaa7fe0fd36")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionParentIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("1de3b2f1-3a47-4041-a535-0efa77fe51f2"),
				Name = @"VersionParentId",
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("ce17b21e-a999-447b-99ee-1eaa7fe0fd36")
			};
		}

		protected virtual EntitySchemaColumn CreateHasStartEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9e279d32-36c3-4eed-ad11-2b23d7ab8bc5"),
				Name = @"HasStartEvent",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateVersionParentUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("a4fa3c3e-bec2-4d8e-a821-26495d1c0163"),
				Name = @"VersionParentUId",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateStartOptionsImageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ImageLookup")) {
				UId = new Guid("5df842bd-a53f-45f0-818f-34c114280de0"),
				Name = @"StartOptionsImage",
				ReferenceSchemaUId = new Guid("93986bfe-2dbd-46bc-9bf9-d03dfefbf3b8"),
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected virtual EntitySchemaColumn CreateIsProcessTracingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("99d80984-5fbb-4cf2-8584-8213d093659f"),
				Name = @"IsProcessTracing",
				CreatedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				ModifiedInSchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"),
				CreatedInPackageId = new Guid("cf6dd8ea-641b-43ea-a946-34fe63d8f0dd")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwProcessLib(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwProcessLib_ProcessLibraryEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwProcessLibSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwProcessLibSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849"));
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLib

	/// <summary>
	/// Process library (view).
	/// </summary>
	public class VwProcessLib : BPMSoft.Configuration.VwSysSchemaInWorkspace
	{

		#region Constructors: Public

		public VwProcessLib(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwProcessLib";
		}

		public VwProcessLib(VwProcessLib source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Maximum version.
		/// </summary>
		public bool IsMaxVersion {
			get {
				return GetTypedColumnValue<bool>("IsMaxVersion");
			}
			set {
				SetColumnValue("IsMaxVersion", value);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string TagProperty {
			get {
				return GetTypedColumnValue<string>("TagProperty");
			}
			set {
				SetColumnValue("TagProperty", value);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Enabled {
			get {
				return GetTypedColumnValue<bool>("Enabled");
			}
			set {
				SetColumnValue("Enabled", value);
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

		/// <exclude/>
		public Guid ProcessSchemaTypeId {
			get {
				return GetTypedColumnValue<Guid>("ProcessSchemaTypeId");
			}
			set {
				SetColumnValue("ProcessSchemaTypeId", value);
				_processSchemaType = null;
			}
		}

		/// <exclude/>
		public string ProcessSchemaTypeName {
			get {
				return GetTypedColumnValue<string>("ProcessSchemaTypeName");
			}
			set {
				SetColumnValue("ProcessSchemaTypeName", value);
				if (_processSchemaType != null) {
					_processSchemaType.Name = value;
				}
			}
		}

		private ProcessSchemaType _processSchemaType;
		/// <summary>
		/// Process schema type.
		/// </summary>
		public ProcessSchemaType ProcessSchemaType {
			get {
				return _processSchemaType ??
					(_processSchemaType = LookupColumnEntities.GetEntity("ProcessSchemaType") as ProcessSchemaType);
			}
		}

		/// <summary>
		/// Unique identifier of workspace schema.
		/// </summary>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
			}
		}

		/// <summary>
		/// Display in run process button list.
		/// </summary>
		public bool AddToRunButton {
			get {
				return GetTypedColumnValue<bool>("AddToRunButton");
			}
			set {
				SetColumnValue("AddToRunButton", value);
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

		/// <summary>
		/// Parent version Id.
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
		/// HasStartEvent.
		/// </summary>
		public bool HasStartEvent {
			get {
				return GetTypedColumnValue<bool>("HasStartEvent");
			}
			set {
				SetColumnValue("HasStartEvent", value);
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

		/// <exclude/>
		public Guid StartOptionsImageId {
			get {
				return GetTypedColumnValue<Guid>("StartOptionsImageId");
			}
			set {
				SetColumnValue("StartOptionsImageId", value);
				_startOptionsImage = null;
			}
		}

		/// <exclude/>
		public string StartOptionsImageName {
			get {
				return GetTypedColumnValue<string>("StartOptionsImageName");
			}
			set {
				SetColumnValue("StartOptionsImageName", value);
				if (_startOptionsImage != null) {
					_startOptionsImage.Name = value;
				}
			}
		}

		private SysImage _startOptionsImage;
		/// <summary>
		/// Start options image.
		/// </summary>
		public SysImage StartOptionsImage {
			get {
				return _startOptionsImage ??
					(_startOptionsImage = LookupColumnEntities.GetEntity("StartOptionsImage") as SysImage);
			}
		}

		/// <summary>
		/// Trace enabled.
		/// </summary>
		public bool IsProcessTracing {
			get {
				return GetTypedColumnValue<bool>("IsProcessTracing");
			}
			set {
				SetColumnValue("IsProcessTracing", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwProcessLib_ProcessLibraryEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwProcessLibDeleted", e);
			Inserting += (s, e) => ThrowEvent("VwProcessLibInserting", e);
			Validating += (s, e) => ThrowEvent("VwProcessLibValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwProcessLib(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwProcessLib_ProcessLibraryEventsProcess

	/// <exclude/>
	public partial class VwProcessLib_ProcessLibraryEventsProcess<TEntity> : BPMSoft.Configuration.VwSysSchemaInWorkspace_BaseEventsProcess<TEntity> where TEntity : VwProcessLib
	{

		public VwProcessLib_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwProcessLib_ProcessLibraryEventsProcess";
			SchemaUId = new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e6e68ac1-495d-4727-a7a7-9b531ab9f849");
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

	#region Class: VwProcessLib_ProcessLibraryEventsProcess

	/// <exclude/>
	public class VwProcessLib_ProcessLibraryEventsProcess : VwProcessLib_ProcessLibraryEventsProcess<VwProcessLib>
	{

		public VwProcessLib_ProcessLibraryEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwProcessLib_ProcessLibraryEventsProcess

	public partial class VwProcessLib_ProcessLibraryEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwProcessLibEventsProcess

	/// <exclude/>
	public class VwProcessLibEventsProcess : VwProcessLib_ProcessLibraryEventsProcess
	{

		public VwProcessLibEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

