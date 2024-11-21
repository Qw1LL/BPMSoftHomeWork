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

	#region Class: VwSysSettingSchema

	/// <exclude/>
	public class VwSysSettingSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwSysSettingSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwSysSettingSchema(VwSysSettingSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwSysSettingSchema(VwSysSettingSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd");
			RealUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd");
			Name = "VwSysSetting";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1");
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
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("723eed02-d25b-445e-8d1b-b10fbfef4e42")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("863bf97f-375b-43cc-a1a0-294cf1fb762f")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("f12f0733-d707-47d9-8dce-af20acf7186d")) == null) {
				Columns.Add(CreateValueTypeNameColumn());
			}
			if (Columns.FindByUId(new Guid("13a9aa83-6d7e-4578-b8f9-92dd771f87ee")) == null) {
				Columns.Add(CreateReferenceSchemaUIdColumn());
			}
			if (Columns.FindByUId(new Guid("3fe15c05-fa45-4a4f-9b34-1da9a0372d8a")) == null) {
				Columns.Add(CreateIsPersonalColumn());
			}
			if (Columns.FindByUId(new Guid("606e3428-786f-4fc3-8a70-796c5489e966")) == null) {
				Columns.Add(CreateIsCacheableColumn());
			}
			if (Columns.FindByUId(new Guid("0f5e5f27-1146-48e5-8d2d-31021482c008")) == null) {
				Columns.Add(CreateIsSSPAvailableColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3463ca37-7483-49e2-a526-c574581fa7f6"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("84247f72-6888-41a8-9eeb-5077d36f0b48"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("723eed02-d25b-445e-8d1b-b10fbfef4e42"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1"),
				IsMultiLineText = true,
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("863bf97f-375b-43cc-a1a0-294cf1fb762f"),
				Name = @"Code",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected virtual EntitySchemaColumn CreateValueTypeNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f12f0733-d707-47d9-8dce-af20acf7186d"),
				Name = @"ValueTypeName",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("13a9aa83-6d7e-4578-b8f9-92dd771f87ee"),
				Name = @"ReferenceSchemaUId",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected virtual EntitySchemaColumn CreateIsPersonalColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("3fe15c05-fa45-4a4f-9b34-1da9a0372d8a"),
				Name = @"IsPersonal",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected virtual EntitySchemaColumn CreateIsCacheableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("606e3428-786f-4fc3-8a70-796c5489e966"),
				Name = @"IsCacheable",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateIsSSPAvailableColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("0f5e5f27-1146-48e5-8d2d-31021482c008"),
				Name = @"IsSSPAvailable",
				CreatedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				ModifiedInSchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"),
				CreatedInPackageId = new Guid("fc707408-e226-4f6e-ba83-43c0cf93ebc1")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwSysSetting(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwSysSetting_UIv2EventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwSysSettingSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwSysSettingSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd"));
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSetting

	/// <summary>
	/// System setting (view).
	/// </summary>
	public class VwSysSetting : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwSysSetting(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwSysSetting";
		}

		public VwSysSetting(VwSysSetting source)
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
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
			}
		}

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
			var process = new VwSysSetting_UIv2EventsProcess(UserConnection);
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
			return new VwSysSetting(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwSysSetting_UIv2EventsProcess

	/// <exclude/>
	public partial class VwSysSetting_UIv2EventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwSysSetting
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

		public VwSysSetting_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwSysSetting_UIv2EventsProcess";
			SchemaUId = new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f884326b-abd5-47d6-8ade-59bbf1dfeccd");
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

	#region Class: VwSysSetting_UIv2EventsProcess

	/// <exclude/>
	public class VwSysSetting_UIv2EventsProcess : VwSysSetting_UIv2EventsProcess<VwSysSetting>
	{

		public VwSysSetting_UIv2EventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwSysSetting_UIv2EventsProcess

	public partial class VwSysSetting_UIv2EventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwSysSettingEventsProcess

	/// <exclude/>
	public class VwSysSettingEventsProcess : VwSysSetting_UIv2EventsProcess
	{

		public VwSysSettingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

