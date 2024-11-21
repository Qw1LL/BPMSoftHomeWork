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

	#region Class: SysModuleReportTableSchema

	/// <exclude/>
	public class SysModuleReportTableSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleReportTableSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleReportTableSchema(SysModuleReportTableSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleReportTableSchema(SysModuleReportTableSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677");
			RealUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677");
			Name = "SysModuleReportTable";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("154371d2-7624-4a1b-8019-e5c202c2260d")) == null) {
				Columns.Add(CreateMacrosListColumn());
			}
			if (Columns.FindByUId(new Guid("8501dbf4-1603-4e8b-b875-e1d9c8de5e8c")) == null) {
				Columns.Add(CreateSysModuleReportColumn());
			}
			if (Columns.FindByUId(new Guid("79a3fa68-aef2-4ed5-86d2-5fb4dc4a7ae3")) == null) {
				Columns.Add(CreateReferenceColumnColumn());
			}
			if (Columns.FindByUId(new Guid("2f560358-9c67-4ddb-8ae8-e9507c0faab9")) == null) {
				Columns.Add(CreateCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("8f7d36c2-dbbb-4185-865c-ae22c23409f5")) == null) {
				Columns.Add(CreateFilterColumn());
			}
			if (Columns.FindByUId(new Guid("2f929142-c949-4965-822b-718d744291fa")) == null) {
				Columns.Add(CreateObjectIdColumn());
			}
			if (Columns.FindByUId(new Guid("6e37e4a0-1c37-4475-83aa-dd218ff47173")) == null) {
				Columns.Add(CreateObjectColumnPathColumn());
			}
			if (Columns.FindByUId(new Guid("7ac8fc3b-9f5f-40d3-8918-3c18bc54cc23")) == null) {
				Columns.Add(CreateObjectColumnCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("1a6de7b4-2b63-4983-989c-e5f5ad91c559")) == null) {
				Columns.Add(CreateReferenceColumnCaptionColumn());
			}
			if (Columns.FindByUId(new Guid("b368f76c-1279-4700-8914-e821390edfdd")) == null) {
				Columns.Add(CreateIsEmptyTableHideColumn());
			}
			if (Columns.FindByUId(new Guid("1ec0aaa5-139f-e8c5-7269-e96044b51ae1")) == null) {
				Columns.Add(CreateFilterSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("b54b15ab-474f-117c-f6ae-616896984747")) == null) {
				Columns.Add(CreateMacrosSettingsColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("dcbcf570-397b-4c65-bc5c-ffc91e6cc60a"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateMacrosListColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("154371d2-7624-4a1b-8019-e5c202c2260d"),
				Name = @"MacrosList",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysModuleReportColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8501dbf4-1603-4e8b-b875-e1d9c8de5e8c"),
				Name = @"SysModuleReport",
				ReferenceSchemaUId = new Guid("0a62cd3d-6541-4c5c-903f-e5b0fc665297"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceColumnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("79a3fa68-aef2-4ed5-86d2-5fb4dc4a7ae3"),
				Name = @"ReferenceColumn",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2f560358-9c67-4ddb-8ae8-e9507c0faab9"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("8f7d36c2-dbbb-4185-865c-ae22c23409f5"),
				Name = @"Filter",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2f929142-c949-4965-822b-718d744291fa"),
				Name = @"ObjectId",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("e98ccaae-0bf0-40d8-a40d-46418c204c90")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectColumnPathColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6e37e4a0-1c37-4475-83aa-dd218ff47173"),
				Name = @"ObjectColumnPath",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc")
			};
		}

		protected virtual EntitySchemaColumn CreateObjectColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("7ac8fc3b-9f5f-40d3-8918-3c18bc54cc23"),
				Name = @"ObjectColumnCaption",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceColumnCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("1a6de7b4-2b63-4983-989c-e5f5ad91c559"),
				Name = @"ReferenceColumnCaption",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc")
			};
		}

		protected virtual EntitySchemaColumn CreateIsEmptyTableHideColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b368f76c-1279-4700-8914-e821390edfdd"),
				Name = @"IsEmptyTableHide",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("1ec0aaa5-139f-e8c5-7269-e96044b51ae1"),
				Name = @"FilterSettings",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateMacrosSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("b54b15ab-474f-117c-f6ae-616896984747"),
				Name = @"MacrosSettings",
				CreatedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				ModifiedInSchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleReportTable(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleReportTable_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleReportTableSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleReportTableSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportTable

	/// <summary>
	/// Tables of printable.
	/// </summary>
	public class SysModuleReportTable : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleReportTable(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleReportTable";
		}

		public SysModuleReportTable(SysModuleReportTable source)
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
		/// List of fields.
		/// </summary>
		public string MacrosList {
			get {
				return GetTypedColumnValue<string>("MacrosList");
			}
			set {
				SetColumnValue("MacrosList", value);
			}
		}

		/// <exclude/>
		public Guid SysModuleReportId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleReportId");
			}
			set {
				SetColumnValue("SysModuleReportId", value);
				_sysModuleReport = null;
			}
		}

		/// <exclude/>
		public string SysModuleReportCaption {
			get {
				return GetTypedColumnValue<string>("SysModuleReportCaption");
			}
			set {
				SetColumnValue("SysModuleReportCaption", value);
				if (_sysModuleReport != null) {
					_sysModuleReport.Caption = value;
				}
			}
		}

		private SysModuleReport _sysModuleReport;
		/// <summary>
		/// Printable.
		/// </summary>
		public SysModuleReport SysModuleReport {
			get {
				return _sysModuleReport ??
					(_sysModuleReport = LookupColumnEntities.GetEntity("SysModuleReport") as SysModuleReport);
			}
		}

		/// <summary>
		/// Path to relationship column.
		/// </summary>
		public string ReferenceColumn {
			get {
				return GetTypedColumnValue<string>("ReferenceColumn");
			}
			set {
				SetColumnValue("ReferenceColumn", value);
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
		/// Object.
		/// </summary>
		public Guid ObjectId {
			get {
				return GetTypedColumnValue<Guid>("ObjectId");
			}
			set {
				SetColumnValue("ObjectId", value);
			}
		}

		/// <summary>
		/// Path to parent object.
		/// </summary>
		public string ObjectColumnPath {
			get {
				return GetTypedColumnValue<string>("ObjectColumnPath");
			}
			set {
				SetColumnValue("ObjectColumnPath", value);
			}
		}

		/// <summary>
		/// Column of parent object.
		/// </summary>
		public string ObjectColumnCaption {
			get {
				return GetTypedColumnValue<string>("ObjectColumnCaption");
			}
			set {
				SetColumnValue("ObjectColumnCaption", value);
			}
		}

		/// <summary>
		/// Relationship column.
		/// </summary>
		public string ReferenceColumnCaption {
			get {
				return GetTypedColumnValue<string>("ReferenceColumnCaption");
			}
			set {
				SetColumnValue("ReferenceColumnCaption", value);
			}
		}

		/// <summary>
		/// Hide the table if it is empty.
		/// </summary>
		public bool IsEmptyTableHide {
			get {
				return GetTypedColumnValue<bool>("IsEmptyTableHide");
			}
			set {
				SetColumnValue("IsEmptyTableHide", value);
			}
		}

		/// <summary>
		/// Filter settings.
		/// </summary>
		public string FilterSettings {
			get {
				return GetTypedColumnValue<string>("FilterSettings");
			}
			set {
				SetColumnValue("FilterSettings", value);
			}
		}

		/// <summary>
		/// Macros settings.
		/// </summary>
		public string MacrosSettings {
			get {
				return GetTypedColumnValue<string>("MacrosSettings");
			}
			set {
				SetColumnValue("MacrosSettings", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleReportTable_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleReportTableDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysModuleReportTableInserting", e);
			Validating += (s, e) => ThrowEvent("SysModuleReportTableValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleReportTable(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleReportTable_BaseEventsProcess

	/// <exclude/>
	public partial class SysModuleReportTable_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleReportTable
	{

		public SysModuleReportTable_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleReportTable_BaseEventsProcess";
			SchemaUId = new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fa05df4e-0361-4496-8198-5aa5b2dbe677");
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

	#region Class: SysModuleReportTable_BaseEventsProcess

	/// <exclude/>
	public class SysModuleReportTable_BaseEventsProcess : SysModuleReportTable_BaseEventsProcess<SysModuleReportTable>
	{

		public SysModuleReportTable_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleReportTable_BaseEventsProcess

	public partial class SysModuleReportTable_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleReportTableEventsProcess

	/// <exclude/>
	public class SysModuleReportTableEventsProcess : SysModuleReportTable_BaseEventsProcess
	{

		public SysModuleReportTableEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

