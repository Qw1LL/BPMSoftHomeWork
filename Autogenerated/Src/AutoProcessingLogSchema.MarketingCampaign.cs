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

	#region Class: AutoProcessingLogSchema

	/// <exclude/>
	public class AutoProcessingLogSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public AutoProcessingLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AutoProcessingLogSchema(AutoProcessingLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AutoProcessingLogSchema(AutoProcessingLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05");
			RealUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05");
			Name = "AutoProcessingLog";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c36736b0-e428-47fb-a133-6141cdc76597")) == null) {
				Columns.Add(CreateMessageColumn());
			}
			if (Columns.FindByUId(new Guid("9fa7c216-b224-46b2-ad51-82f2c204da8f")) == null) {
				Columns.Add(CreateProcessingTypeColumn());
			}
			if (Columns.FindByUId(new Guid("cdb4b4fa-cba8-48fa-9050-05ee3d5beef0")) == null) {
				Columns.Add(CreateProcessingDateColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("fd12fdff-1572-4128-b363-96157ec268fd"),
				Name = @"Id",
				CreatedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				ModifiedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateMessageColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("c36736b0-e428-47fb-a133-6141cdc76597"),
				Name = @"Message",
				CreatedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				ModifiedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessingTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("9fa7c216-b224-46b2-ad51-82f2c204da8f"),
				Name = @"ProcessingType",
				CreatedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				ModifiedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateProcessingDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("cdb4b4fa-cba8-48fa-9050-05ee3d5beef0"),
				Name = @"ProcessingDate",
				CreatedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				ModifiedInSchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AutoProcessingLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AutoProcessingLog_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AutoProcessingLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AutoProcessingLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05"));
		}

		#endregion

	}

	#endregion

	#region Class: AutoProcessingLog

	/// <summary>
	/// Журнал автоматической обработки.
	/// </summary>
	public class AutoProcessingLog : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public AutoProcessingLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AutoProcessingLog";
		}

		public AutoProcessingLog(AutoProcessingLog source)
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
		/// Сообщение.
		/// </summary>
		public string Message {
			get {
				return GetTypedColumnValue<string>("Message");
			}
			set {
				SetColumnValue("Message", value);
			}
		}

		/// <summary>
		/// ProcessingType.
		/// </summary>
		public string ProcessingType {
			get {
				return GetTypedColumnValue<string>("ProcessingType");
			}
			set {
				SetColumnValue("ProcessingType", value);
			}
		}

		/// <summary>
		/// Дата события.
		/// </summary>
		public DateTime ProcessingDate {
			get {
				return GetTypedColumnValue<DateTime>("ProcessingDate");
			}
			set {
				SetColumnValue("ProcessingDate", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AutoProcessingLog_MarketingCampaignEventsProcess(UserConnection);
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
			return new AutoProcessingLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: AutoProcessingLog_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class AutoProcessingLog_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : AutoProcessingLog
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

		public AutoProcessingLog_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AutoProcessingLog_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("43f3ceca-feda-43a9-8f80-35f5bbad1c05");
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

	#region Class: AutoProcessingLog_MarketingCampaignEventsProcess

	/// <exclude/>
	public class AutoProcessingLog_MarketingCampaignEventsProcess : AutoProcessingLog_MarketingCampaignEventsProcess<AutoProcessingLog>
	{

		public AutoProcessingLog_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AutoProcessingLog_MarketingCampaignEventsProcess

	public partial class AutoProcessingLog_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: AutoProcessingLogEventsProcess

	/// <exclude/>
	public class AutoProcessingLogEventsProcess : AutoProcessingLog_MarketingCampaignEventsProcess
	{

		public AutoProcessingLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

