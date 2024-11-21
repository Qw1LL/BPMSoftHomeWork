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

	#region Class: SysSettingsSchema

	/// <exclude/>
	public class SysSettingsSchema : BPMSoft.Configuration.BaseCodeLookupSchema
	{

		#region Constructors: Public

		public SysSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSettingsSchema(SysSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSettingsSchema(SysSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIUSysSettingsCodeIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = true
			};
			index.UId = new Guid("9443913c-9cfe-4dc1-84b1-0399907e4383");
			index.Name = "IUSysSettingsCode";
			index.CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			index.ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			index.CreatedInPackageId = new Guid("85c6fcb4-595c-4ae2-b184-f851878bfee6");
			EntitySchemaIndexColumn codeIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fdbec968-ea8f-43a8-90d8-08cdc53b2af5"),
				ColumnUId = new Guid("13aad544-ec30-4e76-a373-f0cff3202e24"),
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("85c6fcb4-595c-4ae2-b184-f851878bfee6"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(codeIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			RealUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			Name = "SysSettings";
			ParentSchemaUId = new Guid("2681062b-df59-4e52-89ed-f9b7dc909ab2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f7960a8a-1fd4-41d2-997a-fd78ea60075f")) == null) {
				Columns.Add(CreateValueTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("3fd9f15d-37f4-4f91-a6cf-f222d54e342d")) == null) {
				Columns.Add(CreateSysFolderColumn());
			}
			if (Columns.FindByUId(new Guid("764cd95a-59b3-4060-b17f-2797d5c76aaa")) == null) {
				Columns.Add(CreateIsPersonalColumn());
			}
			if (Columns.FindByUId(new Guid("eb971f1a-dd41-4668-99aa-1f2a6b61a1b9")) == null) {
				Columns.Add(CreateIsCacheableColumn());
			}
			if (Columns.FindByUId(new Guid("b2280617-35f9-4006-8634-c557a2e121c2")) == null) {
				Columns.Add(CreateReferenceSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("64fadca1-ab7c-4471-9d25-68599acc729b")) == null) {
				Columns.Add(CreateIsSSPAvailableColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.DataValueType = DataValueTypeManager.GetInstanceByName("MaxSizeText");
			column.ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateCodeColumn() {
			EntitySchemaColumn column = base.CreateCodeColumn();
			column.ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateValueTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f7960a8a-1fd4-41d2-997a-fd78ea60075f"),
				Name = @"ValueTypeName",
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3fd9f15d-37f4-4f91-a6cf-f222d54e342d"),
				Name = @"SysFolder",
				ReferenceSchemaUId = new Guid("81996156-45e6-40de-931e-6ddc6f75cd7e"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsPersonalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("764cd95a-59b3-4060-b17f-2797d5c76aaa"),
				Name = @"IsPersonal",
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCacheableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("eb971f1a-dd41-4668-99aa-1f2a6b61a1b9"),
				Name = @"IsCacheable",
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("b2280617-35f9-4006-8634-c557a2e121c2"),
				Name = @"ReferenceSchemaUId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateIsSSPAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("64fadca1-ab7c-4471-9d25-68599acc729b"),
				Name = @"IsSSPAvailable",
				CreatedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				ModifiedInSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				CreatedInPackageId = new Guid("0667b054-b9ee-4378-bf1e-7304a34292b5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIUSysSettingsCodeIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSettings_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("27aeadd6-d508-4572-8061-5b55b667c902"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSettings

	/// <summary>
	/// System setting.
	/// </summary>
	public class SysSettings : BPMSoft.Configuration.BaseCodeLookup
	{

		#region Constructors: Public

		public SysSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSettings";
		}

		public SysSettings(SysSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Type.
		/// </summary>
		public string ValueTypeName {
			get {
				return GetTypedColumnValue<string>("ValueTypeName");
			}
			set {
				SetColumnValue("ValueTypeName", value);
			}
		}

		/// <exclude/>
		public Guid SysFolderId {
			get {
				return GetTypedColumnValue<Guid>("SysFolderId");
			}
			set {
				SetColumnValue("SysFolderId", value);
				_sysFolder = null;
			}
		}

		/// <exclude/>
		public string SysFolderName {
			get {
				return GetTypedColumnValue<string>("SysFolderName");
			}
			set {
				SetColumnValue("SysFolderName", value);
				if (_sysFolder != null) {
					_sysFolder.Name = value;
				}
			}
		}

		private SysSettingsFolder _sysFolder;
		/// <summary>
		/// Folder.
		/// </summary>
		public SysSettingsFolder SysFolder {
			get {
				return _sysFolder ??
					(_sysFolder = LookupColumnEntities.GetEntity("SysFolder") as SysSettingsFolder);
			}
		}

		/// <summary>
		/// Personal.
		/// </summary>
		public bool IsPersonal {
			get {
				return GetTypedColumnValue<bool>("IsPersonal");
			}
			set {
				SetColumnValue("IsPersonal", value);
			}
		}

		/// <summary>
		/// Cached.
		/// </summary>
		public bool IsCacheable {
			get {
				return GetTypedColumnValue<bool>("IsCacheable");
			}
			set {
				SetColumnValue("IsCacheable", value);
			}
		}

		/// <summary>
		/// Identifier of system setting lookup.
		/// </summary>
		public Guid ReferenceSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("ReferenceSchemaUId");
			}
			set {
				SetColumnValue("ReferenceSchemaUId", value);
			}
		}

		/// <summary>
		/// Allow for portal users.
		/// </summary>
		public bool IsSSPAvailable {
			get {
				return GetTypedColumnValue<bool>("IsSSPAvailable");
			}
			set {
				SetColumnValue("IsSSPAvailable", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSettings_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSettingsDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSettingsDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSettingsInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSettingsInserting", e);
			Saved += (s, e) => ThrowEvent("SysSettingsSaved", e);
			Saving += (s, e) => ThrowEvent("SysSettingsSaving", e);
			Validating += (s, e) => ThrowEvent("SysSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSettings_BaseEventsProcess

	/// <exclude/>
	public partial class SysSettings_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseCodeLookup_BaseEventsProcess<TEntity> where TEntity : SysSettings
	{

		public SysSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSettings_BaseEventsProcess";
			SchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("27aeadd6-d508-4572-8061-5b55b667c902");
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

	#region Class: SysSettings_BaseEventsProcess

	/// <exclude/>
	public class SysSettings_BaseEventsProcess : SysSettings_BaseEventsProcess<SysSettings>
	{

		public SysSettings_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSettings_BaseEventsProcess

	public partial class SysSettings_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion


	#region Class: SysSettingsEventsProcess

	/// <exclude/>
	public class SysSettingsEventsProcess : SysSettings_BaseEventsProcess
	{

		public SysSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

