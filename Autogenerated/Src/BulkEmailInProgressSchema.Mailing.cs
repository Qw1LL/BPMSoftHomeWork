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

	#region Class: BulkEmailInProgressSchema

	/// <exclude/>
	public class BulkEmailInProgressSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public BulkEmailInProgressSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailInProgressSchema(BulkEmailInProgressSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailInProgressSchema(BulkEmailInProgressSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257");
			RealUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257");
			Name = "BulkEmailInProgress";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("d6cb3076-08d5-49e6-ac18-d8f418ab1e90");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateSessionIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c812ddcd-8e0e-4db3-ac44-94f97402eb9d")) == null) {
				Columns.Add(CreateBulkEmailIdColumn());
			}
			if (Columns.FindByUId(new Guid("c4499e57-3833-472c-b6ea-9b481dc68a75")) == null) {
				Columns.Add(CreateCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("70a5b2fe-5dc4-938c-20a7-8aaf68fafc85")) == null) {
				Columns.Add(CreatePreparedToSendCountColumn());
			}
			if (Columns.FindByUId(new Guid("4cd24c82-7db4-175c-40a1-55536e08fe8a")) == null) {
				Columns.Add(CreateModifiedOnColumn());
			}
			if (Columns.FindByUId(new Guid("b69a3932-a839-bb4f-01ad-d01348b0635d")) == null) {
				Columns.Add(CreateSendCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSessionIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f1f3a9b2-666b-4cb3-8331-d163079c0b62"),
				Name = @"SessionId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("d6cb3076-08d5-49e6-ac18-d8f418ab1e90")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("c812ddcd-8e0e-4db3-ac44-94f97402eb9d"),
				Name = @"BulkEmailId",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("d6cb3076-08d5-49e6-ac18-d8f418ab1e90")
			};
		}

		protected virtual EntitySchemaColumn CreateCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("c4499e57-3833-472c-b6ea-9b481dc68a75"),
				Name = @"CreatedOn",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("d6cb3076-08d5-49e6-ac18-d8f418ab1e90"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDateTime")
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePreparedToSendCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("70a5b2fe-5dc4-938c-20a7-8aaf68fafc85"),
				Name = @"PreparedToSendCount",
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("c3e4ee87-43fa-403d-acda-7e0e57f41b53")
			};
		}

		protected virtual EntitySchemaColumn CreateModifiedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("4cd24c82-7db4-175c-40a1-55536e08fe8a"),
				Name = @"ModifiedOn",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("c3e4ee87-43fa-403d-acda-7e0e57f41b53")
			};
		}

		protected virtual EntitySchemaColumn CreateSendCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b69a3932-a839-bb4f-01ad-d01348b0635d"),
				Name = @"SendCount",
				CreatedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				ModifiedInSchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"),
				CreatedInPackageId = new Guid("c3e4ee87-43fa-403d-acda-7e0e57f41b53")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailInProgress(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailInProgress_MailingEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailInProgressSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailInProgressSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInProgress

	/// <summary>
	/// BulkEmailInProgress.
	/// </summary>
	public class BulkEmailInProgress : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailInProgress(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailInProgress";
		}

		public BulkEmailInProgress(BulkEmailInProgress source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Сессия.
		/// </summary>
		public Guid SessionId {
			get {
				return GetTypedColumnValue<Guid>("SessionId");
			}
			set {
				SetColumnValue("SessionId", value);
			}
		}

		/// <summary>
		/// Рассылка.
		/// </summary>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
			}
		}

		/// <summary>
		/// Дата создания.
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
		/// Подготовлено.
		/// </summary>
		public int PreparedToSendCount {
			get {
				return GetTypedColumnValue<int>("PreparedToSendCount");
			}
			set {
				SetColumnValue("PreparedToSendCount", value);
			}
		}

		/// <summary>
		/// Изменено.
		/// </summary>
		public DateTime ModifiedOn {
			get {
				return GetTypedColumnValue<DateTime>("ModifiedOn");
			}
			set {
				SetColumnValue("ModifiedOn", value);
			}
		}

		/// <summary>
		/// Отправлено.
		/// </summary>
		public int SendCount {
			get {
				return GetTypedColumnValue<int>("SendCount");
			}
			set {
				SetColumnValue("SendCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailInProgress_MailingEventsProcess(UserConnection);
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
			return new BulkEmailInProgress(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailInProgress_MailingEventsProcess

	/// <exclude/>
	public partial class BulkEmailInProgress_MailingEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : BulkEmailInProgress
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

		public BulkEmailInProgress_MailingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailInProgress_MailingEventsProcess";
			SchemaUId = new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ab8ddf21-3930-472b-8724-d2b2bf8f8257");
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

	#region Class: BulkEmailInProgress_MailingEventsProcess

	/// <exclude/>
	public class BulkEmailInProgress_MailingEventsProcess : BulkEmailInProgress_MailingEventsProcess<BulkEmailInProgress>
	{

		public BulkEmailInProgress_MailingEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailInProgress_MailingEventsProcess

	public partial class BulkEmailInProgress_MailingEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailInProgressEventsProcess

	/// <exclude/>
	public class BulkEmailInProgressEventsProcess : BulkEmailInProgress_MailingEventsProcess
	{

		public BulkEmailInProgressEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

