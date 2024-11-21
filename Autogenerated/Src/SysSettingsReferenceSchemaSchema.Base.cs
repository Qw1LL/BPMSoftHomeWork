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

	#region Class: SysSettingsReferenceSchemaSchema

	/// <exclude/>
	public class SysSettingsReferenceSchemaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSettingsReferenceSchemaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSettingsReferenceSchemaSchema(SysSettingsReferenceSchemaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSettingsReferenceSchemaSchema(SysSettingsReferenceSchemaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d");
			RealUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d");
			Name = "SysSettingsReferenceSchema";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0901eff5-fc17-4528-9291-9045fb1b832c")) == null) {
				Columns.Add(CreateSysSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("2fdb3bb1-7014-436f-ad78-48c23816d9d3")) == null) {
				Columns.Add(CreateReferenceSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0901eff5-fc17-4528-9291-9045fb1b832c"),
				Name = @"SysSettings",
				ReferenceSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d"),
				ModifiedInSchemaUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected virtual EntitySchemaColumn CreateReferenceSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("2fdb3bb1-7014-436f-ad78-48c23816d9d3"),
				Name = @"ReferenceSchemaUId",
				CreatedInSchemaUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d"),
				ModifiedInSchemaUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d"),
				CreatedInPackageId = new Guid("969515bc-541b-44a4-a988-eb0725df0b81")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSettingsReferenceSchema(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSettingsReferenceSchema_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSettingsReferenceSchemaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSettingsReferenceSchemaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsReferenceSchema

	/// <summary>
	/// System setting lookup.
	/// </summary>
	public class SysSettingsReferenceSchema : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSettingsReferenceSchema(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSettingsReferenceSchema";
		}

		public SysSettingsReferenceSchema(SysSettingsReferenceSchema source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SysSettingsId {
			get {
				return GetTypedColumnValue<Guid>("SysSettingsId");
			}
			set {
				SetColumnValue("SysSettingsId", value);
				_sysSettings = null;
			}
		}

		/// <exclude/>
		public string SysSettingsName {
			get {
				return GetTypedColumnValue<string>("SysSettingsName");
			}
			set {
				SetColumnValue("SysSettingsName", value);
				if (_sysSettings != null) {
					_sysSettings.Name = value;
				}
			}
		}

		private SysSettings _sysSettings;
		/// <summary>
		/// System setting.
		/// </summary>
		public SysSettings SysSettings {
			get {
				return _sysSettings ??
					(_sysSettings = LookupColumnEntities.GetEntity("SysSettings") as SysSettings);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysSettingsReferenceSchema_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSettingsReferenceSchemaDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSettingsReferenceSchemaDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSettingsReferenceSchemaInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSettingsReferenceSchemaInserting", e);
			Saved += (s, e) => ThrowEvent("SysSettingsReferenceSchemaSaved", e);
			Saving += (s, e) => ThrowEvent("SysSettingsReferenceSchemaSaving", e);
			Validating += (s, e) => ThrowEvent("SysSettingsReferenceSchemaValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSettingsReferenceSchema(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsReferenceSchema_BaseEventsProcess

	/// <exclude/>
	public partial class SysSettingsReferenceSchema_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSettingsReferenceSchema
	{

		public SysSettingsReferenceSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSettingsReferenceSchema_BaseEventsProcess";
			SchemaUId = new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cb9c80d1-1cd0-4f7a-989c-7e299d57244d");
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

	#region Class: SysSettingsReferenceSchema_BaseEventsProcess

	/// <exclude/>
	public class SysSettingsReferenceSchema_BaseEventsProcess : SysSettingsReferenceSchema_BaseEventsProcess<SysSettingsReferenceSchema>
	{

		public SysSettingsReferenceSchema_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSettingsReferenceSchema_BaseEventsProcess

	public partial class SysSettingsReferenceSchema_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSettingsReferenceSchemaEventsProcess

	/// <exclude/>
	public class SysSettingsReferenceSchemaEventsProcess : SysSettingsReferenceSchema_BaseEventsProcess
	{

		public SysSettingsReferenceSchemaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

