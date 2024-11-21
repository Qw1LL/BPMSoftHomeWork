namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;

	#region Class: VwRemindingsCountSchema

	/// <exclude/>
	public class VwRemindingsCountSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public VwRemindingsCountSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwRemindingsCountSchema(VwRemindingsCountSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwRemindingsCountSchema(VwRemindingsCountSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3");
			RealUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3");
			Name = "VwRemindingsCount";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3");
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
			if (Columns.FindByUId(new Guid("f1a3197e-feb0-48e9-8549-e462189c8176")) == null) {
				Columns.Add(CreateRemindingsCountColumn());
			}
			if (Columns.FindByUId(new Guid("9191d2ea-1c14-4336-b7f0-fc2887ea24c9")) == null) {
				Columns.Add(CreateEmailsCountColumn());
			}
			if (Columns.FindByUId(new Guid("04eac3b3-bdc6-4367-9cd1-bb6142eb63d3")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("0da83a47-56af-4ec6-b764-40c9991a1ce5")) == null) {
				Columns.Add(CreateSysAdminUnitColumn());
			}
			if (Columns.FindByUId(new Guid("76ff2948-f355-4b17-b70e-6b13a16c044d")) == null) {
				Columns.Add(CreateVisaCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateRemindingsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("f1a3197e-feb0-48e9-8549-e462189c8176"),
				Name = @"RemindingsCount",
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("9191d2ea-1c14-4336-b7f0-fc2887ea24c9"),
				Name = @"EmailsCount",
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("04eac3b3-bdc6-4367-9cd1-bb6142eb63d3"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateSysAdminUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0da83a47-56af-4ec6-b764-40c9991a1ce5"),
				Name = @"SysAdminUnit",
				ReferenceSchemaUId = new Guid("84f44b9a-4bc3-4cbf-a1a8-cec02c1c029c"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("cd322293-860d-4ac9-8e55-034f9e973ce3")
			};
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("aefeafec-74c2-49d4-9e22-49db62bed863"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateVisaCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("76ff2948-f355-4b17-b70e-6b13a16c044d"),
				Name = @"VisaCount",
				CreatedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				ModifiedInSchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"),
				CreatedInPackageId = new Guid("5fe850f8-633f-4f49-b171-3760bb47e9da")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwRemindingsCount(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwRemindingsCount_NUIEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwRemindingsCountSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwRemindingsCountSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3"));
		}

		#endregion

	}

	#endregion

	#region Class: VwRemindingsCount

	/// <summary>
	/// Number of notifications.
	/// </summary>
	public class VwRemindingsCount : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public VwRemindingsCount(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwRemindingsCount";
		}

		public VwRemindingsCount(VwRemindingsCount source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Number of emails.
		/// </summary>
		public int EmailsCount {
			get {
				return GetTypedColumnValue<int>("EmailsCount");
			}
			set {
				SetColumnValue("EmailsCount", value);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Contact.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
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
		/// Number of approvals.
		/// </summary>
		public int VisaCount {
			get {
				return GetTypedColumnValue<int>("VisaCount");
			}
			set {
				SetColumnValue("VisaCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwRemindingsCount_NUIEventsProcess(UserConnection);
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
			return new VwRemindingsCount(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwRemindingsCount_NUIEventsProcess

	/// <exclude/>
	public partial class VwRemindingsCount_NUIEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : VwRemindingsCount
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

		public VwRemindingsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwRemindingsCount_NUIEventsProcess";
			SchemaUId = new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("848d92a5-e651-4e16-ab35-e5678ac704c3");
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

	#region Class: VwRemindingsCount_NUIEventsProcess

	/// <exclude/>
	public class VwRemindingsCount_NUIEventsProcess : VwRemindingsCount_NUIEventsProcess<VwRemindingsCount>
	{

		public VwRemindingsCount_NUIEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwRemindingsCount_NUIEventsProcess

	public partial class VwRemindingsCount_NUIEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwRemindingsCountEventsProcess

	/// <exclude/>
	public class VwRemindingsCountEventsProcess : VwRemindingsCount_NUIEventsProcess
	{

		public VwRemindingsCountEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

