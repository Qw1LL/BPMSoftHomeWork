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

	#region Class: SysPackageSchemaDataSchema

	/// <exclude/>
	public class SysPackageSchemaDataSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysPackageSchemaDataSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysPackageSchemaDataSchema(SysPackageSchemaDataSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysPackageSchemaDataSchema(SysPackageSchemaDataSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167");
			RealUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167");
			Name = "SysPackageSchemaData";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fca145f2-e37d-4b48-a430-12a1df950704")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("04e67c6d-5edc-4da2-8bdb-15d4e004eeb2")) == null) {
				Columns.Add(CreateFilterDataColumn());
			}
			if (Columns.FindByUId(new Guid("f48cc952-f3cb-4ff6-9a1b-907b23bb8e75")) == null) {
				Columns.Add(CreateDataColumn());
			}
			if (Columns.FindByUId(new Guid("c7757822-3840-474a-a2af-be519e9732d6")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("33cff200-4e0a-40d9-b8f1-a1d18c9a0045")) == null) {
				Columns.Add(CreateInstallTypeColumn());
			}
			if (Columns.FindByUId(new Guid("440c72ce-05e3-46de-937d-4b67c74f9de7")) == null) {
				Columns.Add(CreateUIdColumn());
			}
			if (Columns.FindByUId(new Guid("9c345988-f7e0-4584-b1df-a9bf816d3ccb")) == null) {
				Columns.Add(CreateNeedInstallColumn());
			}
			if (Columns.FindByUId(new Guid("dcb1020e-f88b-4bda-a227-13962ceb19e5")) == null) {
				Columns.Add(CreateLastErrorColumn());
			}
			if (Columns.FindByUId(new Guid("2360bf98-dcab-41e1-95ac-714a1d623b1a")) == null) {
				Columns.Add(CreateNameColumn());
			}
			if (Columns.FindByUId(new Guid("cbde3279-c50c-436b-8182-aec00f9bc8b7")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("8acd1b9c-b41c-476a-9a09-b2ba6d6812af")) == null) {
				Columns.Add(CreateIsLockedColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fca145f2-e37d-4b48-a430-12a1df950704"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFilterDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("04e67c6d-5edc-4da2-8bdb-15d4e004eeb2"),
				Name = @"FilterData",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("f48cc952-f3cb-4ff6-9a1b-907b23bb8e75"),
				Name = @"Data",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c7757822-3840-474a-a2af-be519e9732d6"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateInstallTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ValueList")) {
				UId = new Guid("33cff200-4e0a-40d9-b8f1-a1d18c9a0045"),
				Name = @"InstallType",
				ReferenceValueListSchemaUId = new Guid("8598c861-bf61-4e11-a7d8-4f8b030ea0f6"),
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("440c72ce-05e3-46de-937d-4b67c74f9de7"),
				Name = @"UId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNeedInstallColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("9c345988-f7e0-4584-b1df-a9bf816d3ccb"),
				Name = @"NeedInstall",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateLastErrorColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("dcb1020e-f88b-4bda-a227-13962ceb19e5"),
				Name = @"LastError",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("18101200-c6ba-4ebd-a649-786a47318866")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2360bf98-dcab-41e1-95ac-714a1d623b1a"),
				Name = @"Name",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("cbde3279-c50c-436b-8182-aec00f9bc8b7"),
				Name = @"IsChanged",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				CreatedInPackageId = new Guid("3c624d29-361c-47f2-ac8f-7824eb3cde6f")
			};
		}

		protected virtual EntitySchemaColumn CreateIsLockedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("8acd1b9c-b41c-476a-9a09-b2ba6d6812af"),
				Name = @"IsLocked",
				CreatedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
				ModifiedInSchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"),
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
			return new SysPackageSchemaData(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysPackageSchemaData_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysPackageSchemaDataSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysPackageSchemaDataSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4cec7385-4a1c-47df-89f4-97cde394e167"));
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageSchemaData

	/// <summary>
	/// Package schema data.
	/// </summary>
	public class SysPackageSchemaData : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysPackageSchemaData(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysPackageSchemaData";
		}

		public SysPackageSchemaData(SysPackageSchemaData source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSchemaId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaId");
			}
			set {
				SetColumnValue("SysSchemaId", value);
				_sysSchema = null;
			}
		}

		/// <exclude/>
		public string SysSchemaCaption {
			get {
				return GetTypedColumnValue<string>("SysSchemaCaption");
			}
			set {
				SetColumnValue("SysSchemaCaption", value);
				if (_sysSchema != null) {
					_sysSchema.Caption = value;
				}
			}
		}

		private SysSchema _sysSchema;
		/// <summary>
		/// Schema.
		/// </summary>
		public SysSchema SysSchema {
			get {
				return _sysSchema ??
					(_sysSchema = LookupColumnEntities.GetEntity("SysSchema") as SysSchema);
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
		/// Data installation type.
		/// </summary>
		public SysPackageSchemaDataInstallType? InstallType {
			get {
				return GetTypedColumnValue<SysPackageSchemaDataInstallType>("InstallType");
			}
			set {
				SetColumnValue("InstallType", value);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysPackageSchemaData_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysPackageSchemaDataDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysPackageSchemaDataInserting", e);
			Validating += (s, e) => ThrowEvent("SysPackageSchemaDataValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysPackageSchemaData(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysPackageSchemaData_BaseEventsProcess

	/// <exclude/>
	public partial class SysPackageSchemaData_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysPackageSchemaData
	{

		public SysPackageSchemaData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysPackageSchemaData_BaseEventsProcess";
			SchemaUId = new Guid("4cec7385-4a1c-47df-89f4-97cde394e167");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4cec7385-4a1c-47df-89f4-97cde394e167");
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

	#region Class: SysPackageSchemaData_BaseEventsProcess

	/// <exclude/>
	public class SysPackageSchemaData_BaseEventsProcess : SysPackageSchemaData_BaseEventsProcess<SysPackageSchemaData>
	{

		public SysPackageSchemaData_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysPackageSchemaData_BaseEventsProcess

	public partial class SysPackageSchemaData_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysPackageSchemaDataEventsProcess

	/// <exclude/>
	public class SysPackageSchemaDataEventsProcess : SysPackageSchemaData_BaseEventsProcess
	{

		public SysPackageSchemaDataEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

