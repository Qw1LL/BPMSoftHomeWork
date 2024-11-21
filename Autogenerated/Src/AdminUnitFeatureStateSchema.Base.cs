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

	#region Class: AdminUnitFeatureStateSchema

	/// <exclude/>
	public class AdminUnitFeatureStateSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public AdminUnitFeatureStateSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AdminUnitFeatureStateSchema(AdminUnitFeatureStateSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AdminUnitFeatureStateSchema(AdminUnitFeatureStateSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205");
			RealUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205");
			Name = "AdminUnitFeatureState";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("9ba728be-e5cd-451d-a74a-c4a047c374b3")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("82b72e0d-42a3-4857-8445-0279b66e7e2c")) == null) {
				Columns.Add(CreateFeatureStateColumn());
			}
			if (Columns.FindByUId(new Guid("631177f9-f983-4787-a7aa-ced1b24ba918")) == null) {
				Columns.Add(CreateFeatureColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9ba728be-e5cd-451d-a74a-c4a047c374b3"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				ModifiedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			};
		}

		protected virtual EntitySchemaColumn CreateFeatureStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("82b72e0d-42a3-4857-8445-0279b66e7e2c"),
				Name = @"FeatureState",
				CreatedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				ModifiedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			};
		}

		protected virtual EntitySchemaColumn CreateFeatureColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("631177f9-f983-4787-a7aa-ced1b24ba918"),
				Name = @"Feature",
				ReferenceSchemaUId = new Guid("28f8de6e-0c1e-4100-a868-11c6b934575f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				ModifiedInSchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"),
				CreatedInPackageId = new Guid("2e3e95a4-2024-4552-b820-30e9633c8933")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AdminUnitFeatureState(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AdminUnitFeatureState_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AdminUnitFeatureStateSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AdminUnitFeatureStateSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205"));
		}

		#endregion

	}

	#endregion

	#region Class: AdminUnitFeatureState

	/// <summary>
	/// State of feature.
	/// </summary>
	public class AdminUnitFeatureState : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public AdminUnitFeatureState(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AdminUnitFeatureState";
		}

		public AdminUnitFeatureState(AdminUnitFeatureState source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysAdminUnitId {
			get {
				return GetTypedColumnValue<Guid>("SysAdminUnitId");
			}
			set {
				SetColumnValue("SysAdminUnitId", value);
				_sysAdminUnit = null;
			}
		}

		/// <exclude/>
		public string SysAdminUnitName {
			get {
				return GetTypedColumnValue<string>("SysAdminUnitName");
			}
			set {
				SetColumnValue("SysAdminUnitName", value);
				if (_sysAdminUnit != null) {
					_sysAdminUnit.Name = value;
				}
			}
		}

		private SysAdminUnit _sysAdminUnit;
		/// <summary>
		/// User.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// State of feature.
		/// </summary>
		public int FeatureState {
			get {
				return GetTypedColumnValue<int>("FeatureState");
			}
			set {
				SetColumnValue("FeatureState", value);
			}
		}

		/// <exclude/>
		public Guid FeatureId {
			get {
				return GetTypedColumnValue<Guid>("FeatureId");
			}
			set {
				SetColumnValue("FeatureId", value);
				_feature = null;
			}
		}

		/// <exclude/>
		public string FeatureName {
			get {
				return GetTypedColumnValue<string>("FeatureName");
			}
			set {
				SetColumnValue("FeatureName", value);
				if (_feature != null) {
					_feature.Name = value;
				}
			}
		}

		private Feature _feature;
		/// <summary>
		/// Feature.
		/// </summary>
		public Feature Feature {
			get {
				return _feature ??
					(_feature = LookupColumnEntities.GetEntity("Feature") as Feature);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AdminUnitFeatureState_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AdminUnitFeatureStateDeleted", e);
			Validating += (s, e) => ThrowEvent("AdminUnitFeatureStateValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AdminUnitFeatureState(this);
		}

		#endregion

	}

	#endregion

	#region Class: AdminUnitFeatureState_BaseEventsProcess

	/// <exclude/>
	public partial class AdminUnitFeatureState_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : AdminUnitFeatureState
	{

		public AdminUnitFeatureState_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AdminUnitFeatureState_BaseEventsProcess";
			SchemaUId = new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e7bf0241-29e5-48e6-a09a-8102ae016205");
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

	#region Class: AdminUnitFeatureState_BaseEventsProcess

	/// <exclude/>
	public class AdminUnitFeatureState_BaseEventsProcess : AdminUnitFeatureState_BaseEventsProcess<AdminUnitFeatureState>
	{

		public AdminUnitFeatureState_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AdminUnitFeatureState_BaseEventsProcess

	public partial class AdminUnitFeatureState_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AdminUnitFeatureStateEventsProcess

	/// <exclude/>
	public class AdminUnitFeatureStateEventsProcess : AdminUnitFeatureState_BaseEventsProcess
	{

		public AdminUnitFeatureStateEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

