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

	#region Class: SysProcessElementLogSchema

	/// <exclude/>
	public class SysProcessElementLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public SysProcessElementLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SysProcessElementLogSchema(SysProcessElementLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SysProcessElementLogSchema(SysProcessElementLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151");
			RealUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151");
			Name = "SysProcessElementLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d02aa4b5-5f3f-474e-8592-fb7d134b97fe")) == null) {
				Columns.Add(CreateSchemaElementUIdColumn());
			}
			if (Columns.FindByUId(new Guid("87877e35-e3cf-4c0a-b765-f25ee289c48e")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("12e6627d-0eea-4aca-bea0-48ec642ac0e6")) == null) {
				Columns.Add(CreateCompleteDateColumn());
			}
			if (Columns.FindByUId(new Guid("f7d0bbeb-f7cf-4e9b-b1e8-b3e1e85b02f4")) == null) {
				Columns.Add(CreateSysProcessColumn());
			}
			if (Columns.FindByUId(new Guid("20ef8f7f-d262-41db-94ae-e4151f20f3e3")) == null) {
				Columns.Add(CreateStatusColumn());
			}
			if (Columns.FindByUId(new Guid("38e1d692-5953-438d-92bf-8a1f3115ac44")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7d3e42c3-9e10-4812-a2a6-0c2d45fee313")) == null) {
				Columns.Add(CreateErrorDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("5e6dde55-197b-4721-b435-993e53cbaddb")) == null) {
				Columns.Add(CreateDurationInMinutesColumn());
			}
			if (Columns.FindByUId(new Guid("a79003a2-1325-4d0a-a369-b624b1576d9f")) == null) {
				Columns.Add(CreateDurationInDaysColumn());
			}
			if (Columns.FindByUId(new Guid("c38f93e2-f875-4b50-86c5-aeac9aeeec88")) == null) {
				Columns.Add(CreateDurationInHoursColumn());
			}
			if (Columns.FindByUId(new Guid("3907d26d-560b-4f9d-9e8a-ee3c34f495ef")) == null) {
				Columns.Add(CreateDurationInMillisecondsColumn());
			}
			if (Columns.FindByUId(new Guid("0adf8286-cce9-4726-b533-29200b6f2c02")) == null) {
				Columns.Add(CreateNodeIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.SystemValue,
				ValueSource = SystemValueManager.GetInstanceByName(@"SequentialGuid")
			};
			column.ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151");
			return column;
		}

		protected virtual EntitySchemaColumn CreateSchemaElementUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d02aa4b5-5f3f-474e-8592-fb7d134b97fe"),
				Name = @"SchemaElementUId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("87877e35-e3cf-4c0a-b765-f25ee289c48e"),
				Name = @"StartDate",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCompleteDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("12e6627d-0eea-4aca-bea0-48ec642ac0e6"),
				Name = @"CompleteDate",
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSysProcessColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f7d0bbeb-f7cf-4e9b-b1e8-b3e1e85b02f4"),
				Name = @"SysProcess",
				ReferenceSchemaUId = new Guid("ac2d8e0f-a926-4f76-a1fa-604d5eaaa1d2"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("20ef8f7f-d262-41db-94ae-e4151f20f3e3"),
				Name = @"Status",
				ReferenceSchemaUId = new Guid("dc1e2217-9af0-4216-935b-ace805adc929"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("38e1d692-5953-438d-92bf-8a1f3115ac44"),
				Name = @"Type",
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("157e504e-ae6d-40d5-b01c-f24268af8df3"),
				Name = @"Caption",
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c9bb53e6-4500-4979-ab28-3832d348081e"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateErrorDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7d3e42c3-9e10-4812-a2a6-0c2d45fee313"),
				Name = @"ErrorDescription",
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("f92f6bea-5f0b-420e-8adc-843ed74daca8"),
				IsMultiLineText = true
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMinutesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("5e6dde55-197b-4721-b435-993e53cbaddb"),
				Name = @"DurationInMinutes",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInDaysColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("a79003a2-1325-4d0a-a369-b624b1576d9f"),
				Name = @"DurationInDays",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInHoursColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("c38f93e2-f875-4b50-86c5-aeac9aeeec88"),
				Name = @"DurationInHours",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("f0a07489-164a-4e1e-a7fc-87544c1af335")
			};
		}

		protected virtual EntitySchemaColumn CreateDurationInMillisecondsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float1")) {
				UId = new Guid("3907d26d-560b-4f9d-9e8a-ee3c34f495ef"),
				Name = @"DurationInMilliseconds",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected virtual EntitySchemaColumn CreateNodeIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("0adf8286-cce9-4726-b533-29200b6f2c02"),
				Name = @"NodeId",
				CreatedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				ModifiedInSchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SysProcessElementLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SysProcessElementLog_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SysProcessElementLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SysProcessElementLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151"));
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementLog

	/// <summary>
	/// Process items log (actual).
	/// </summary>
	public class SysProcessElementLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public SysProcessElementLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SysProcessElementLog";
		}

		public SysProcessElementLog(SysProcessElementLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Diagram item.
		/// </summary>
		public Guid SchemaElementUId {
			get {
				return GetTypedColumnValue<Guid>("SchemaElementUId");
			}
			set {
				SetColumnValue("SchemaElementUId", value);
			}
		}

		/// <summary>
		/// Start date.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// End date.
		/// </summary>
		public DateTime CompleteDate {
			get {
				return GetTypedColumnValue<DateTime>("CompleteDate");
			}
			set {
				SetColumnValue("CompleteDate", value);
			}
		}

		/// <exclude/>
		public Guid SysProcessId {
			get {
				return GetTypedColumnValue<Guid>("SysProcessId");
			}
			set {
				SetColumnValue("SysProcessId", value);
				_sysProcess = null;
			}
		}

		/// <exclude/>
		public string SysProcessName {
			get {
				return GetTypedColumnValue<string>("SysProcessName");
			}
			set {
				SetColumnValue("SysProcessName", value);
				if (_sysProcess != null) {
					_sysProcess.Name = value;
				}
			}
		}

		private SysProcessLog _sysProcess;
		/// <summary>
		/// Process instance.
		/// </summary>
		public SysProcessLog SysProcess {
			get {
				return _sysProcess ??
					(_sysProcess = LookupColumnEntities.GetEntity("SysProcess") as SysProcessLog);
			}
		}

		/// <exclude/>
		public Guid StatusId {
			get {
				return GetTypedColumnValue<Guid>("StatusId");
			}
			set {
				SetColumnValue("StatusId", value);
				_status = null;
			}
		}

		/// <exclude/>
		public string StatusName {
			get {
				return GetTypedColumnValue<string>("StatusName");
			}
			set {
				SetColumnValue("StatusName", value);
				if (_status != null) {
					_status.Name = value;
				}
			}
		}

		private SysProcessStatus _status;
		/// <summary>
		/// Status.
		/// </summary>
		public SysProcessStatus Status {
			get {
				return _status ??
					(_status = LookupColumnEntities.GetEntity("Status") as SysProcessStatus);
			}
		}

		/// <summary>
		/// Type.
		/// </summary>
		public string Type {
			get {
				return GetTypedColumnValue<string>("Type");
			}
			set {
				SetColumnValue("Type", value);
			}
		}

		/// <summary>
		/// Caption.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Error details.
		/// </summary>
		public string ErrorDescription {
			get {
				return GetTypedColumnValue<string>("ErrorDescription");
			}
			set {
				SetColumnValue("ErrorDescription", value);
			}
		}

		/// <summary>
		/// Duration, minutes.
		/// </summary>
		public Decimal DurationInMinutes {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMinutes");
			}
			set {
				SetColumnValue("DurationInMinutes", value);
			}
		}

		/// <summary>
		/// Duration, days.
		/// </summary>
		public Decimal DurationInDays {
			get {
				return GetTypedColumnValue<Decimal>("DurationInDays");
			}
			set {
				SetColumnValue("DurationInDays", value);
			}
		}

		/// <summary>
		/// Duration, hours.
		/// </summary>
		public Decimal DurationInHours {
			get {
				return GetTypedColumnValue<Decimal>("DurationInHours");
			}
			set {
				SetColumnValue("DurationInHours", value);
			}
		}

		/// <summary>
		/// Duration, milliseconds.
		/// </summary>
		public Decimal DurationInMilliseconds {
			get {
				return GetTypedColumnValue<Decimal>("DurationInMilliseconds");
			}
			set {
				SetColumnValue("DurationInMilliseconds", value);
			}
		}

		/// <summary>
		/// Node Identifier.
		/// </summary>
		/// <remarks>
		/// Identifies current execution node.
		/// </remarks>
		public string NodeId {
			get {
				return GetTypedColumnValue<string>("NodeId");
			}
			set {
				SetColumnValue("NodeId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SysProcessElementLog_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SysProcessElementLogDeleted", e);
			Inserting += (s, e) => ThrowEvent("SysProcessElementLogInserting", e);
			Validating += (s, e) => ThrowEvent("SysProcessElementLogValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SysProcessElementLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: SysProcessElementLog_BaseEventsProcess

	/// <exclude/>
	public partial class SysProcessElementLog_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : SysProcessElementLog
	{

		public SysProcessElementLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SysProcessElementLog_BaseEventsProcess";
			SchemaUId = new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ff6c1cb5-16bf-4f8c-adc8-64c0b7762151");
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

	#region Class: SysProcessElementLog_BaseEventsProcess

	/// <exclude/>
	public class SysProcessElementLog_BaseEventsProcess : SysProcessElementLog_BaseEventsProcess<SysProcessElementLog>
	{

		public SysProcessElementLog_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SysProcessElementLog_BaseEventsProcess

	public partial class SysProcessElementLog_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: SysProcessElementLogEventsProcess

	/// <exclude/>
	public class SysProcessElementLogEventsProcess : SysProcessElementLog_BaseEventsProcess
	{

		public SysProcessElementLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

