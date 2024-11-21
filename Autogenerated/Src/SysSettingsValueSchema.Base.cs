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

	#region Class: SysSettingsValueSchema

	/// <exclude/>
	public class SysSettingsValueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysSettingsValueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysSettingsValueSchema(SysSettingsValueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysSettingsValueSchema(SysSettingsValueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f");
			RealUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f");
			Name = "SysSettingsValue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0fde6f1e-22c5-48c7-9c89-6f0031e270de")) == null) {
				Columns.Add(CreateSysSettingsColumn());
			}
			if (Columns.FindByUId(new Guid("8f1984bb-7bef-4220-9b49-9a12d0ebcd68")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("55472376-a4dd-40da-86c6-975ce4b898fa")) == null) {
				Columns.Add(CreateIsDefColumn());
			}
			if (Columns.FindByUId(new Guid("af6013ce-7387-4619-b4f4-30c4276fcfac")) == null) {
				Columns.Add(CreateTextValueColumn());
			}
			if (Columns.FindByUId(new Guid("b36bfa07-34c7-45b1-a2ee-39e653034ba0")) == null) {
				Columns.Add(CreateIntegerValueColumn());
			}
			if (Columns.FindByUId(new Guid("b1ffd2d8-2bd3-4c46-b9c0-782afb0996c0")) == null) {
				Columns.Add(CreateFloatValueColumn());
			}
			if (Columns.FindByUId(new Guid("297f4697-d071-4be2-8509-9090c07dfe18")) == null) {
				Columns.Add(CreateBooleanValueColumn());
			}
			if (Columns.FindByUId(new Guid("34f73492-296e-4a73-95f7-e7de5a3b3509")) == null) {
				Columns.Add(CreateDateTimeValueColumn());
			}
			if (Columns.FindByUId(new Guid("23c7dde8-7cf5-4f18-9d76-0fa4179ee931")) == null) {
				Columns.Add(CreateGuidValueColumn());
			}
			if (Columns.FindByUId(new Guid("ffd545dd-d2de-40d7-8b07-20654613bb20")) == null) {
				Columns.Add(CreateBinaryValueColumn());
			}
			if (Columns.FindByUId(new Guid("f1bc0b27-2c46-4cae-ad23-3b8940587d4f")) == null) {
				Columns.Add(CreatePositionColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSysSettingsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0fde6f1e-22c5-48c7-9c89-6f0031e270de"),
				Name = @"SysSettings",
				ReferenceSchemaUId = new Guid("27aeadd6-d508-4572-8061-5b55b667c902"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8f1984bb-7bef-4220-9b49-9a12d0ebcd68"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsCascade = true,
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDefColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("55472376-a4dd-40da-86c6-975ce4b898fa"),
				Name = @"IsDef",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTextValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("af6013ce-7387-4619-b4f4-30c4276fcfac"),
				Name = @"TextValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateIntegerValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b36bfa07-34c7-45b1-a2ee-39e653034ba0"),
				Name = @"IntegerValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateFloatValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("b1ffd2d8-2bd3-4c46-b9c0-782afb0996c0"),
				Name = @"FloatValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBooleanValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("297f4697-d071-4be2-8509-9090c07dfe18"),
				Name = @"BooleanValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDateTimeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("34f73492-296e-4a73-95f7-e7de5a3b3509"),
				Name = @"DateTimeValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateGuidValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("23c7dde8-7cf5-4f18-9d76-0fa4179ee931"),
				Name = @"GuidValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBinaryValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Binary")) {
				UId = new Guid("ffd545dd-d2de-40d7-8b07-20654613bb20"),
				Name = @"BinaryValue",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePositionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f1bc0b27-2c46-4cae-ad23-3b8940587d4f"),
				Name = @"Position",
				CreatedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				ModifiedInSchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysSettingsValue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysSettingsValue_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysSettingsValueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysSettingsValueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f"));
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsValue

	/// <summary>
	/// System setting value.
	/// </summary>
	public class SysSettingsValue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysSettingsValue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysSettingsValue";
		}

		public SysSettingsValue(SysSettingsValue source)
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
		/// System administration object.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Default value.
		/// </summary>
		public bool IsDef {
			get {
				return GetTypedColumnValue<bool>("IsDef");
			}
			set {
				SetColumnValue("IsDef", value);
			}
		}

		/// <summary>
		/// Text value.
		/// </summary>
		public string TextValue {
			get {
				return GetTypedColumnValue<string>("TextValue");
			}
			set {
				SetColumnValue("TextValue", value);
			}
		}

		/// <summary>
		/// Integer.
		/// </summary>
		public int IntegerValue {
			get {
				return GetTypedColumnValue<int>("IntegerValue");
			}
			set {
				SetColumnValue("IntegerValue", value);
			}
		}

		/// <summary>
		/// Decimal value.
		/// </summary>
		public Decimal FloatValue {
			get {
				return GetTypedColumnValue<Decimal>("FloatValue");
			}
			set {
				SetColumnValue("FloatValue", value);
			}
		}

		/// <summary>
		/// Logic value.
		/// </summary>
		public bool BooleanValue {
			get {
				return GetTypedColumnValue<bool>("BooleanValue");
			}
			set {
				SetColumnValue("BooleanValue", value);
			}
		}

		/// <summary>
		/// Date and time value.
		/// </summary>
		public DateTime DateTimeValue {
			get {
				return GetTypedColumnValue<DateTime>("DateTimeValue");
			}
			set {
				SetColumnValue("DateTimeValue", value);
			}
		}

		/// <summary>
		/// Value of unique Id.
		/// </summary>
		public Guid GuidValue {
			get {
				return GetTypedColumnValue<Guid>("GuidValue");
			}
			set {
				SetColumnValue("GuidValue", value);
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
			var process = new SysSettingsValue_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysSettingsValueDeleted", e);
			Deleting += (s, e) => ThrowEvent("SysSettingsValueDeleting", e);
			Inserted += (s, e) => ThrowEvent("SysSettingsValueInserted", e);
			Inserting += (s, e) => ThrowEvent("SysSettingsValueInserting", e);
			Saved += (s, e) => ThrowEvent("SysSettingsValueSaved", e);
			Saving += (s, e) => ThrowEvent("SysSettingsValueSaving", e);
			Validating += (s, e) => ThrowEvent("SysSettingsValueValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysSettingsValue(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysSettingsValue_BaseEventsProcess

	/// <exclude/>
	public partial class SysSettingsValue_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysSettingsValue
	{

		public SysSettingsValue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysSettingsValue_BaseEventsProcess";
			SchemaUId = new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("951b2bbb-0ba3-4049-9a29-b5d4c0b6d50f");
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

	#region Class: SysSettingsValue_BaseEventsProcess

	/// <exclude/>
	public class SysSettingsValue_BaseEventsProcess : SysSettingsValue_BaseEventsProcess<SysSettingsValue>
	{

		public SysSettingsValue_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysSettingsValue_BaseEventsProcess

	public partial class SysSettingsValue_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysSettingsValueEventsProcess

	/// <exclude/>
	public class SysSettingsValueEventsProcess : SysSettingsValue_BaseEventsProcess
	{

		public SysSettingsValueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

