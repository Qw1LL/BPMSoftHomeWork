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

	#region Class: VwUserRemindingsCountSchema

	/// <exclude/>
	public class VwUserRemindingsCountSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwUserRemindingsCountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwUserRemindingsCountSchema(VwUserRemindingsCountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwUserRemindingsCountSchema(VwUserRemindingsCountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52");
			RealUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52");
			Name = "VwUserRemindingsCount";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d322fdf6-3f7f-4594-ab55-d668184340ed")) == null) {
				Columns.Add(CreateRemindingsCountColumn());
			}
			if (Columns.FindByUId(new Guid("911467ad-c977-417b-b5b0-4b93afad1fda")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("6e105fbb-1592-4cef-8ee4-3b9627d876a7")) == null) {
				Columns.Add(CreateRemindTimeColumn());
			}
			if (Columns.FindByUId(new Guid("fdcfa94c-ed63-439b-a7ca-74dcd32d11d1")) == null) {
				Columns.Add(CreateTimeZoneIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6a544324-59f5-4a7b-bb7f-1437b4a08acb"),
				Name = @"Id",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				ModifiedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateRemindingsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d322fdf6-3f7f-4594-ab55-d668184340ed"),
				Name = @"RemindingsCount",
				CreatedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				ModifiedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("911467ad-c977-417b-b5b0-4b93afad1fda"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				ModifiedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("6e105fbb-1592-4cef-8ee4-3b9627d876a7"),
				Name = @"RemindTime",
				CreatedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				ModifiedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529")
			};
		}

		protected virtual EntitySchemaColumn CreateTimeZoneIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("fdcfa94c-ed63-439b-a7ca-74dcd32d11d1"),
				Name = @"TimeZoneId",
				CreatedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				ModifiedInSchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwUserRemindingsCount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwUserRemindingsCount_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwUserRemindingsCountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwUserRemindingsCountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52"));
		}

		#endregion

	}

	#endregion

	#region Class: VwUserRemindingsCount

	/// <summary>
	/// Number of user's notifications (view).
	/// </summary>
	public class VwUserRemindingsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwUserRemindingsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwUserRemindingsCount";
		}

		public VwUserRemindingsCount(VwUserRemindingsCount source)
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
		/// Number of notifications.
		/// </summary>
		public int RemindingsCount {
			get {
				return GetTypedColumnValue<int>("RemindingsCount");
			}
			set {
				SetColumnValue("RemindingsCount", value);
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
		/// SysAdminUnit.
		/// </summary>
		public SysAdminUnit SysAdminUnit {
			get {
				return _sysAdminUnit ??
					(_sysAdminUnit = LookupColumnEntities.GetEntity("SysAdminUnit") as SysAdminUnit);
			}
		}

		/// <summary>
		/// Time of reminder.
		/// </summary>
		public DateTime RemindTime {
			get {
				return GetTypedColumnValue<DateTime>("RemindTime");
			}
			set {
				SetColumnValue("RemindTime", value);
			}
		}

		/// <summary>
		/// Time zone.
		/// </summary>
		public string TimeZoneId {
			get {
				return GetTypedColumnValue<string>("TimeZoneId");
			}
			set {
				SetColumnValue("TimeZoneId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwUserRemindingsCount_NUIEventsProcess(UserConnection);
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
			return new VwUserRemindingsCount(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwUserRemindingsCount_NUIEventsProcess

	/// <exclude/>
	public partial class VwUserRemindingsCount_NUIEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwUserRemindingsCount
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

		public VwUserRemindingsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwUserRemindingsCount_NUIEventsProcess";
			SchemaUId = new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9a61795f-29dd-4f13-b3cd-5f4fa181df52");
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

	#region Class: VwUserRemindingsCount_NUIEventsProcess

	/// <exclude/>
	public class VwUserRemindingsCount_NUIEventsProcess : VwUserRemindingsCount_NUIEventsProcess<VwUserRemindingsCount>
	{

		public VwUserRemindingsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwUserRemindingsCount_NUIEventsProcess

	public partial class VwUserRemindingsCount_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwUserRemindingsCountEventsProcess

	/// <exclude/>
	public class VwUserRemindingsCountEventsProcess : VwUserRemindingsCount_NUIEventsProcess
	{

		public VwUserRemindingsCountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

