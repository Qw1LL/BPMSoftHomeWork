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

	#region Class: SysLocalizableValueSchema

	/// <exclude/>
	public class SysLocalizableValueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysLocalizableValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysLocalizableValueSchema(SysLocalizableValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysLocalizableValueSchema(SysLocalizableValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateISysSchemaIdSysPackageIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5e4032c1-d228-46f0-8bd6-c0e1df78d79c");
			index.Name = "ISysSchemaIdSysPackageId";
			index.CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
			index.ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
			index.CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			EntitySchemaIndexColumn sysSchemaIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("aa6f6776-d634-4ad2-8fc3-55cdf364b228"),
				ColumnUId = new Guid("1975e7c1-d48c-4174-b094-0a8bf653dcd7"),
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysSchemaIdIndexColumn);
			EntitySchemaIndexColumn sysPackageIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("187adda7-7d46-4955-97e8-44c4744a90f9"),
				ColumnUId = new Guid("7f93a46f-d8fd-481b-8507-e30aa8a97f52"),
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(sysPackageIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
			RealUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
			Name = "SysLocalizableValue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7f93a46f-d8fd-481b-8507-e30aa8a97f52")) == null) {
				Columns.Add(CreateSysPackageColumn());
			}
			if (Columns.FindByUId(new Guid("1975e7c1-d48c-4174-b094-0a8bf653dcd7")) == null) {
				Columns.Add(CreateSysSchemaColumn());
			}
			if (Columns.FindByUId(new Guid("df5ea6f9-e46e-4637-8b7b-df44928f68bd")) == null) {
				Columns.Add(CreateResourceManagerColumn());
			}
			if (Columns.FindByUId(new Guid("151065af-346b-48f8-ba9a-79f7945f0c95")) == null) {
				Columns.Add(CreateSysCultureColumn());
			}
			if (Columns.FindByUId(new Guid("8eb33964-b2f0-4ce4-8fcb-8459c6c32bb4")) == null) {
				Columns.Add(CreateResourceTypeColumn());
			}
			if (Columns.FindByUId(new Guid("76e351b3-3e47-47ba-b50f-9cfe34311a2b")) == null) {
				Columns.Add(CreateIsChangedColumn());
			}
			if (Columns.FindByUId(new Guid("74da2cd2-5de8-45dc-8e2c-b72a642b4a18")) == null) {
				Columns.Add(CreateKeyColumn());
			}
			if (Columns.FindByUId(new Guid("e7fb78f4-7d15-4447-b6cb-312dabc7a61c")) == null) {
				Columns.Add(CreateValueColumn());
			}
			if (Columns.FindByUId(new Guid("c154643b-3607-4452-9ebb-dcd7324a48a2")) == null) {
				Columns.Add(CreateImageDataColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysPackageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7f93a46f-d8fd-481b-8507-e30aa8a97f52"),
				Name = @"SysPackage",
				ReferenceSchemaUId = new Guid("ca400a85-ec48-4b42-8e50-271929d27871"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1975e7c1-d48c-4174-b094-0a8bf653dcd7"),
				Name = @"SysSchema",
				ReferenceSchemaUId = new Guid("6c7394db-06ff-4050-91ef-8278e21dce15"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateResourceManagerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("df5ea6f9-e46e-4637-8b7b-df44928f68bd"),
				Name = @"ResourceManager",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateSysCultureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("151065af-346b-48f8-ba9a-79f7945f0c95"),
				Name = @"SysCulture",
				ReferenceSchemaUId = new Guid("ffc193e1-04bc-472b-bdc0-3333d1df84e4"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateResourceTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("8eb33964-b2f0-4ce4-8fcb-8459c6c32bb4"),
				Name = @"ResourceType",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("9ab2229f-be25-4b60-ada4-e93fae454420")
			};
		}

		protected virtual EntitySchemaColumn CreateIsChangedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("76e351b3-3e47-47ba-b50f-9cfe34311a2b"),
				Name = @"IsChanged",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("74da2cd2-5de8-45dc-8e2c-b72a642b4a18"),
				Name = @"Key",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("e7fb78f4-7d15-4447-b6cb-312dabc7a61c"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected virtual EntitySchemaColumn CreateImageDataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("c154643b-3607-4452-9ebb-dcd7324a48a2"),
				Name = @"ImageData",
				CreatedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				ModifiedInSchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"),
				CreatedInPackageId = new Guid("bf38ed25-b430-4e67-8e26-e793c8cb214d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateISysSchemaIdSysPackageIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysLocalizableValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysLocalizableValue_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysLocalizableValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysLocalizableValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2"));
		}

		#endregion

	}

	#endregion

	#region Class: SysLocalizableValue

	/// <summary>
	/// Localizable values.
	/// </summary>
	public class SysLocalizableValue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysLocalizableValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysLocalizableValue";
		}

		public SysLocalizableValue(SysLocalizableValue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Resource manager name.
		/// </summary>
		public string ResourceManager {
			get {
				return GetTypedColumnValue<string>("ResourceManager");
			}
			set {
				SetColumnValue("ResourceManager", value);
			}
		}

		/// <exclude/>
		public Guid SysCultureId {
			get {
				return GetTypedColumnValue<Guid>("SysCultureId");
			}
			set {
				SetColumnValue("SysCultureId", value);
				_sysCulture = null;
			}
		}

		/// <exclude/>
		public string SysCultureName {
			get {
				return GetTypedColumnValue<string>("SysCultureName");
			}
			set {
				SetColumnValue("SysCultureName", value);
				if (_sysCulture != null) {
					_sysCulture.Name = value;
				}
			}
		}

		private SysCulture _sysCulture;
		/// <summary>
		/// Culture.
		/// </summary>
		public SysCulture SysCulture {
			get {
				return _sysCulture ??
					(_sysCulture = LookupColumnEntities.GetEntity("SysCulture") as SysCulture);
			}
		}

		/// <summary>
		/// Type of resource.
		/// </summary>
		public int ResourceType {
			get {
				return GetTypedColumnValue<int>("ResourceType");
			}
			set {
				SetColumnValue("ResourceType", value);
			}
		}

		/// <summary>
		/// Is changed.
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
		/// Key.
		/// </summary>
		public string Key {
			get {
				return GetTypedColumnValue<string>("Key");
			}
			set {
				SetColumnValue("Key", value);
			}
		}

		/// <summary>
		/// Value.
		/// </summary>
		public string Value {
			get {
				return GetTypedColumnValue<string>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysLocalizableValue_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysLocalizableValueDeleted", e);
			Validating += (s, e) => ThrowEvent("SysLocalizableValueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysLocalizableValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysLocalizableValue_BaseEventsProcess

	/// <exclude/>
	public partial class SysLocalizableValue_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysLocalizableValue
	{

		public SysLocalizableValue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysLocalizableValue_BaseEventsProcess";
			SchemaUId = new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f20585be-79d4-4608-9c61-b5b8c4b703e2");
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

	#region Class: SysLocalizableValue_BaseEventsProcess

	/// <exclude/>
	public class SysLocalizableValue_BaseEventsProcess : SysLocalizableValue_BaseEventsProcess<SysLocalizableValue>
	{

		public SysLocalizableValue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysLocalizableValue_BaseEventsProcess

	public partial class SysLocalizableValue_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysLocalizableValueEventsProcess

	/// <exclude/>
	public class SysLocalizableValueEventsProcess : SysLocalizableValue_BaseEventsProcess
	{

		public SysLocalizableValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

