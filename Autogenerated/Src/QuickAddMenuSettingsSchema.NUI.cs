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

	#region Class: QuickAddMenuSettingsSchema

	/// <exclude/>
	public class QuickAddMenuSettingsSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public QuickAddMenuSettingsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public QuickAddMenuSettingsSchema(QuickAddMenuSettingsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public QuickAddMenuSettingsSchema(QuickAddMenuSettingsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			RealUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			Name = "QuickAddMenuSettings";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
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
			if (Columns.FindByUId(new Guid("5f7ab108-e282-4ce1-9191-fa921423b59f")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("9c5ae550-ef98-471c-b03c-1c2aedb70381")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			column.CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("8c43e182-f864-47b7-b369-70f0950aa521"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5f7ab108-e282-4ce1-9191-fa921423b59f"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9c5ae550-ef98-471c-b03c-1c2aedb70381"),
				Name = @"Position",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				ModifiedInSchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"),
				CreatedInPackageId = new Guid("8c3dfc4f-625c-4884-8962-32e1cb97064e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new QuickAddMenuSettings(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new QuickAddMenuSettings_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new QuickAddMenuSettingsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new QuickAddMenuSettingsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561"));
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuSettings

	/// <summary>
	/// Quick add menu setup.
	/// </summary>
	public class QuickAddMenuSettings : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public QuickAddMenuSettings(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "QuickAddMenuSettings";
		}

		public QuickAddMenuSettings(QuickAddMenuSettings source)
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
		/// Object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Position.
		/// </summary>
		public int Position {
			get {
				return GetTypedColumnValue<int>("Position");
			}
			set {
				SetColumnValue("Position", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new QuickAddMenuSettings_NUIEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("QuickAddMenuSettingsDeleted", e);
			Inserting += (s, e) => ThrowEvent("QuickAddMenuSettingsInserting", e);
			Validating += (s, e) => ThrowEvent("QuickAddMenuSettingsValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new QuickAddMenuSettings(this);
		}

		#endregion

	}

	#endregion

	#region Class: QuickAddMenuSettings_NUIEventsProcess

	/// <exclude/>
	public partial class QuickAddMenuSettings_NUIEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : QuickAddMenuSettings
	{

		public QuickAddMenuSettings_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "QuickAddMenuSettings_NUIEventsProcess";
			SchemaUId = new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4aa8a1e1-77b5-421c-9e74-303810fbc561");
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

	#region Class: QuickAddMenuSettings_NUIEventsProcess

	/// <exclude/>
	public class QuickAddMenuSettings_NUIEventsProcess : QuickAddMenuSettings_NUIEventsProcess<QuickAddMenuSettings>
	{

		public QuickAddMenuSettings_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: QuickAddMenuSettings_NUIEventsProcess

	public partial class QuickAddMenuSettings_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: QuickAddMenuSettingsEventsProcess

	/// <exclude/>
	public class QuickAddMenuSettingsEventsProcess : QuickAddMenuSettings_NUIEventsProcess
	{

		public QuickAddMenuSettingsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

