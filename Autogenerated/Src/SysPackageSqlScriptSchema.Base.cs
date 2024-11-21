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

	#region Class: SysPackageSqlScriptSchema

	/// <exclude/>
	public class SysPackageSqlScriptSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageSqlScriptSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageSqlScriptSchema(SysPackageSqlScriptSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageSqlScriptSchema(SysPackageSqlScriptSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			RealUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			Name = "SysPackageSqlScript";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
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
			if (Columns.FindByUId(new Guid("7d4857de-cbed-4ddd-a667-394292529058")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("629b5fdc-9e58-49bf-8647-adda4b0d44cc")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("3acabdc6-b2e9-49e7-b50a-9fee95c706b5")) == null) {
				Columns.Add(CreateDBEngineTypeColumn());
			}
			if (Columns.FindByUId(new Guid("46a24aa0-3efe-46ae-a1d3-2495f38a6fd7")) == null) {
				Columns.Add(CreateInstallTypeColumn());
			}
			if (Columns.FindByUId(new Guid("39e6a2f7-791a-41ae-9d17-183ecc360045")) == null) {
				Columns.Add(CreateBodyColumn());
			}
			if (Columns.FindByUId(new Guid("c4850380-95eb-4bf6-b2e3-465fdbeb22ab")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("011e6a8e-071a-4fff-96d4-0951c077be75")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
			if (Columns.FindByUId(new Guid("5a44e9b0-3067-4ea3-880d-6c91c825967a")) == null) {
				Columns.Add(CreateNeedInstallColumn());
			}
			if (Columns.FindByUId(new Guid("4bed52f4-b74c-4a7d-a649-cda6b0fe44f7")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			column.CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7");
			return column;
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7d4857de-cbed-4ddd-a667-394292529058"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ff372130-4bff-48cb-ab37-6338f9b385f7"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("629b5fdc-9e58-49bf-8647-adda4b0d44cc"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateDBEngineTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3acabdc6-b2e9-49e7-b50a-9fee95c706b5"),
				Name = @"DBEngineType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("46a24aa0-3efe-46ae-a1d3-2495f38a6fd7"),
				Name = @"InstallType",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateBodyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("39e6a2f7-791a-41ae-9d17-183ecc360045"),
				Name = @"Body",
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("c4850380-95eb-4bf6-b2e3-465fdbeb22ab"),
				Name = @"IsChanged",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("011e6a8e-071a-4fff-96d4-0951c077be75"),
				Name = @"IsLocked",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateNeedInstallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("5a44e9b0-3067-4ea3-880d-6c91c825967a"),
				Name = @"NeedInstall",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("4bed52f4-b74c-4a7d-a649-cda6b0fe44f7"),
				Name = @"LastError",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				ModifiedInSchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"),
				CreatedInPackageId = new Guid("f795d9c2-dc6a-438b-8300-714f6c49b4e7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysPackageSqlScript(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageSqlScript_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageSqlScriptSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageSqlScriptSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d06ec721-ade7-4d80-b187-059f61168f9d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageSqlScript

	/// <summary>
	/// SQL script.
	/// </summary>
	public class SysPackageSqlScript : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageSqlScript(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageSqlScript";
		}

		public SysPackageSqlScript(SysPackageSqlScript source)
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
		/// DBMS type.
		/// </summary>
		public int DBEngineType {
			get {
				return GetTypedColumnValue<int>("DBEngineType");
			}
			set {
				SetColumnValue("DBEngineType", value);
			}
		}

		/// <summary>
		/// Installation type.
		/// </summary>
		public int InstallType {
			get {
				return GetTypedColumnValue<int>("InstallType");
			}
			set {
				SetColumnValue("InstallType", value);
			}
		}

		/// <summary>
		/// Modified.
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
		/// Needs to be installed in database.
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageSqlScript_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageSqlScriptDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysPackageSqlScriptInserting", e);
			Validating += (s, e) => ThrowEvent("SysPackageSqlScriptValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageSqlScript(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageSqlScript_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageSqlScript_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageSqlScript
	{

		public SysPackageSqlScript_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageSqlScript_BaseEventsProcess";
			SchemaUId = new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d06ec721-ade7-4d80-b187-059f61168f9d");
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

	#region Class: SysPackageSqlScript_BaseEventsProcess

	/// <exclude/>
	public class SysPackageSqlScript_BaseEventsProcess : SysPackageSqlScript_BaseEventsProcess<SysPackageSqlScript>
	{

		public SysPackageSqlScript_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageSqlScript_BaseEventsProcess

	public partial class SysPackageSqlScript_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageSqlScriptEventsProcess

	/// <exclude/>
	public class SysPackageSqlScriptEventsProcess : SysPackageSqlScript_BaseEventsProcess
	{

		public SysPackageSqlScriptEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

