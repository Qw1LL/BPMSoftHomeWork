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

	#region Class: DeduplicateExecLogSchema

	/// <exclude/>
	public class DeduplicateExecLogSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public DeduplicateExecLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public DeduplicateExecLogSchema(DeduplicateExecLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public DeduplicateExecLogSchema(DeduplicateExecLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045");
			RealUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045");
			Name = "DeduplicateExecLog";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			IsDBView = false;
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
			PrimaryDisplayColumn = CreateProcedureNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeCreatedOnColumn() {
			base.InitializeCreatedOnColumn();
			CreatedOnColumn = CreateCreatedOnColumn();
			if (Columns.FindByUId(CreatedOnColumn.UId) == null) {
				Columns.Add(CreatedOnColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("d8fac40e-5368-41c7-bb8b-3ff3813e2da5")) == null) {
				Columns.Add(CreateExecutedOnColumn());
			}
			if (Columns.FindByUId(new Guid("83a6d26b-3551-4639-b2de-e991c61c029b")) == null) {
				Columns.Add(CreateCompletedOnColumn());
			}
			if (Columns.FindByUId(new Guid("97ee3e20-54c9-4ab2-8fcf-20f179e167e4")) == null) {
				Columns.Add(CreateSqlErrorCodeColumn());
			}
			if (Columns.FindByUId(new Guid("da2f3240-7555-4e7f-9b5c-c2a3068c71d4")) == null) {
				Columns.Add(CreateSqlErrorMessageColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6af4c558-3b8a-4a49-bafe-67b502c693f9"),
				Name = @"Id",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateProcedureNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("dafe4c64-9854-4ebd-a4af-03688f8f8ff6"),
				Name = @"ProcedureName",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @" "
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("6b8d804d-d8f8-4c10-9526-5e8cefe89ef5"),
				Name = @"CreatedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateExecutedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("d8fac40e-5368-41c7-bb8b-3ff3813e2da5"),
				Name = @"ExecutedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateCompletedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("83a6d26b-3551-4639-b2de-e991c61c029b"),
				Name = @"CompletedOn",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSqlErrorCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("97ee3e20-54c9-4ab2-8fcf-20f179e167e4"),
				Name = @"SqlErrorCode",
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7")
			};
		}

		protected virtual EntitySchemaColumn CreateSqlErrorMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("da2f3240-7555-4e7f-9b5c-c2a3068c71d4"),
				Name = @"SqlErrorMessage",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				ModifiedInSchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"),
				CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @" "
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new DeduplicateExecLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new DeduplicateExecLog_DeduplicationEventsProcess(userConnection);
		}

		public override object Clone() {
			return new DeduplicateExecLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new DeduplicateExecLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045"));
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateExecLog

	/// <summary>
	/// Deduplication log.
	/// </summary>
	public class DeduplicateExecLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public DeduplicateExecLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "DeduplicateExecLog";
		}

		public DeduplicateExecLog(DeduplicateExecLog source)
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
		/// ProcedureName.
		/// </summary>
		public string ProcedureName {
			get {
				return GetTypedColumnValue<string>("ProcedureName");
			}
			set {
				SetColumnValue("ProcedureName", value);
			}
		}

		/// <summary>
		/// CreatedOn.
		/// </summary>
		public DateTime CreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("CreatedOn");
			}
			set {
				SetColumnValue("CreatedOn", value);
			}
		}

		/// <summary>
		/// ExecutedOn.
		/// </summary>
		public DateTime ExecutedOn {
			get {
				return GetTypedColumnValue<DateTime>("ExecutedOn");
			}
			set {
				SetColumnValue("ExecutedOn", value);
			}
		}

		/// <summary>
		/// CompletedOn.
		/// </summary>
		public DateTime CompletedOn {
			get {
				return GetTypedColumnValue<DateTime>("CompletedOn");
			}
			set {
				SetColumnValue("CompletedOn", value);
			}
		}

		/// <summary>
		/// SqlErrorCode.
		/// </summary>
		public int SqlErrorCode {
			get {
				return GetTypedColumnValue<int>("SqlErrorCode");
			}
			set {
				SetColumnValue("SqlErrorCode", value);
			}
		}

		/// <summary>
		/// SqlErrorMessage.
		/// </summary>
		public string SqlErrorMessage {
			get {
				return GetTypedColumnValue<string>("SqlErrorMessage");
			}
			set {
				SetColumnValue("SqlErrorMessage", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new DeduplicateExecLog_DeduplicationEventsProcess(UserConnection);
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
			return new DeduplicateExecLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: DeduplicateExecLog_DeduplicationEventsProcess

	/// <exclude/>
	public partial class DeduplicateExecLog_DeduplicationEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : DeduplicateExecLog
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

		public DeduplicateExecLog_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "DeduplicateExecLog_DeduplicationEventsProcess";
			SchemaUId = new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("16ffbae1-539a-45e3-96d5-a65dd1f6e045");
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

	#region Class: DeduplicateExecLog_DeduplicationEventsProcess

	/// <exclude/>
	public class DeduplicateExecLog_DeduplicationEventsProcess : DeduplicateExecLog_DeduplicationEventsProcess<DeduplicateExecLog>
	{

		public DeduplicateExecLog_DeduplicationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: DeduplicateExecLog_DeduplicationEventsProcess

	public partial class DeduplicateExecLog_DeduplicationEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: DeduplicateExecLogEventsProcess

	/// <exclude/>
	public class DeduplicateExecLogEventsProcess : DeduplicateExecLog_DeduplicationEventsProcess
	{

		public DeduplicateExecLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

