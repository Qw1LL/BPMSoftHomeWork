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

	#region Class: VwUserEmailsCountSchema

	/// <exclude/>
	public class VwUserEmailsCountSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwUserEmailsCountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwUserEmailsCountSchema(VwUserEmailsCountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwUserEmailsCountSchema(VwUserEmailsCountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59");
			RealUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59");
			Name = "VwUserEmailsCount";
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
			if (Columns.FindByUId(new Guid("af7c853b-8b91-44e3-9098-cb79c9b64b56")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e219f4d0-68b9-4ce3-bc4a-5c489af9f036")) == null) {
				Columns.Add(CreateEmailsCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("5fd002bc-3832-4dd5-814f-28cd338eeb18"),
				Name = @"Id",
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
				ModifiedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("af7c853b-8b91-44e3-9098-cb79c9b64b56"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
				ModifiedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
				CreatedInPackageId = new Guid("9ad95375-5845-4ea4-b0ef-1ad3d23bf529")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e219f4d0-68b9-4ce3-bc4a-5c489af9f036"),
				Name = @"EmailsCount",
				CreatedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
				ModifiedInSchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"),
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
			return new VwUserEmailsCount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwUserEmailsCount_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwUserEmailsCountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwUserEmailsCountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59"));
		}

		#endregion

	}

	#endregion

	#region Class: VwUserEmailsCount

	/// <summary>
	/// Number of user's messages (view).
	/// </summary>
	public class VwUserEmailsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwUserEmailsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwUserEmailsCount";
		}

		public VwUserEmailsCount(VwUserEmailsCount source)
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
		/// Number of messages.
		/// </summary>
		public int EmailsCount {
			get {
				return GetTypedColumnValue<int>("EmailsCount");
			}
			set {
				SetColumnValue("EmailsCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwUserEmailsCount_NUIEventsProcess(UserConnection);
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
			return new VwUserEmailsCount(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwUserEmailsCount_NUIEventsProcess

	/// <exclude/>
	public partial class VwUserEmailsCount_NUIEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwUserEmailsCount
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

		public VwUserEmailsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwUserEmailsCount_NUIEventsProcess";
			SchemaUId = new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5e07723e-b353-4e59-b9d4-bed6e7674c59");
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

	#region Class: VwUserEmailsCount_NUIEventsProcess

	/// <exclude/>
	public class VwUserEmailsCount_NUIEventsProcess : VwUserEmailsCount_NUIEventsProcess<VwUserEmailsCount>
	{

		public VwUserEmailsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwUserEmailsCount_NUIEventsProcess

	public partial class VwUserEmailsCount_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwUserEmailsCountEventsProcess

	/// <exclude/>
	public class VwUserEmailsCountEventsProcess : VwUserEmailsCount_NUIEventsProcess
	{

		public VwUserEmailsCountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

