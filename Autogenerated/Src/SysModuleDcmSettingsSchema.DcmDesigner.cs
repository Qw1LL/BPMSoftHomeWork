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

	#region Class: SysModuleDcmSettingsSchema

	/// <exclude/>
	public class SysModuleDcmSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysModuleDcmSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysModuleDcmSettingsSchema(SysModuleDcmSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysModuleDcmSettingsSchema(SysModuleDcmSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1");
			RealUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1");
			Name = "SysModuleDcmSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7bd56c69-3f63-4b48-9094-bd19cbee24a0")) == null) {
				Columns.Add(CreateSysModuleEntityColumn());
			}
			if (Columns.FindByUId(new Guid("3c345fec-06be-405e-a9e0-0bf07efced2c")) == null) {
				Columns.Add(CreateStageColumnUIdColumn());
			}
			if (Columns.FindByUId(new Guid("27861e84-8d8a-4fff-85b3-e86a7aa9df9b")) == null) {
				Columns.Add(CreateFiltersColumn());
			}
			if (Columns.FindByUId(new Guid("767e8fe3-1c68-4763-bd49-0f91139bbb91")) == null) {
				Columns.Add(CreateDefaultSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysModuleEntityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7bd56c69-3f63-4b48-9094-bd19cbee24a0"),
				Name = @"SysModuleEntity",
				ReferenceSchemaUId = new Guid("9c762665-90ad-497b-ac4b-45bb729630a1"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				ModifiedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateStageColumnUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("3c345fec-06be-405e-a9e0-0bf07efced2c"),
				Name = @"StageColumnUId",
				CreatedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				ModifiedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateFiltersColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("27861e84-8d8a-4fff-85b3-e86a7aa9df9b"),
				Name = @"Filters",
				CreatedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				ModifiedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected virtual EntitySchemaColumn CreateDefaultSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("767e8fe3-1c68-4763-bd49-0f91139bbb91"),
				Name = @"DefaultSchemaUId",
				CreatedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				ModifiedInSchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"),
				CreatedInPackageId = new Guid("ef448226-2103-49b1-9f99-b8b1a4265794")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysModuleDcmSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysModuleDcmSettings_DcmDesignerEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysModuleDcmSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysModuleDcmSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1"));
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDcmSettings

	/// <summary>
	/// Section DCM settings.
	/// </summary>
	public class SysModuleDcmSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysModuleDcmSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysModuleDcmSettings";
		}

		public SysModuleDcmSettings(SysModuleDcmSettings source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysModuleEntityId {
			get {
				return GetTypedColumnValue<Guid>("SysModuleEntityId");
			}
			set {
				SetColumnValue("SysModuleEntityId", value);
				_sysModuleEntity = null;
			}
		}

		private SysModuleEntity _sysModuleEntity;
		/// <summary>
		/// SysModuleEntity.
		/// </summary>
		public SysModuleEntity SysModuleEntity {
			get {
				return _sysModuleEntity ??
					(_sysModuleEntity = LookupColumnEntities.GetEntity("SysModuleEntity") as SysModuleEntity);
			}
		}

		/// <summary>
		/// StageColumnUId.
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

		/// <summary>
		/// DefaultSchemaUId.
		/// </summary>
		public Guid DefaultSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("DefaultSchemaUId");
			}
			set {
				SetColumnValue("DefaultSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysModuleDcmSettings_DcmDesignerEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysModuleDcmSettingsDeleted", e);
			Validating += (s, e) => ThrowEvent("SysModuleDcmSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysModuleDcmSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysModuleDcmSettings_DcmDesignerEventsProcess

	/// <exclude/>
	public partial class SysModuleDcmSettings_DcmDesignerEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysModuleDcmSettings
	{

		public SysModuleDcmSettings_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysModuleDcmSettings_DcmDesignerEventsProcess";
			SchemaUId = new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f33ec54a-14e6-424f-80fb-4d548f0f22d1");
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

	#region Class: SysModuleDcmSettings_DcmDesignerEventsProcess

	/// <exclude/>
	public class SysModuleDcmSettings_DcmDesignerEventsProcess : SysModuleDcmSettings_DcmDesignerEventsProcess<SysModuleDcmSettings>
	{

		public SysModuleDcmSettings_DcmDesignerEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysModuleDcmSettings_DcmDesignerEventsProcess

	public partial class SysModuleDcmSettings_DcmDesignerEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysModuleDcmSettingsEventsProcess

	/// <exclude/>
	public class SysModuleDcmSettingsEventsProcess : SysModuleDcmSettings_DcmDesignerEventsProcess
	{

		public SysModuleDcmSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

