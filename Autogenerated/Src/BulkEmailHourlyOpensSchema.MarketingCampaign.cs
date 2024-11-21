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

	#region Class: BulkEmailHourlyOpensSchema

	/// <exclude/>
	public class BulkEmailHourlyOpensSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public BulkEmailHourlyOpensSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailHourlyOpensSchema(BulkEmailHourlyOpensSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailHourlyOpensSchema(BulkEmailHourlyOpensSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5");
			RealUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5");
			Name = "BulkEmailHourlyOpens";
			ParentSchemaUId = new Guid("1b56b061-4e91-4974-9038-df8340e534f2");
			ExtendParent = false;
			CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryColumn() {
			base.InitializePrimaryColumn();
			PrimaryColumn = CreateBulkEmailIdColumn();
			if (Columns.FindByUId(PrimaryColumn.UId) == null) {
				Columns.Add(PrimaryColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("fee14750-bc54-431b-9953-906fa1b6681d")) == null) {
				Columns.Add(CreateDateMarkColumn());
			}
			if (Columns.FindByUId(new Guid("66124707-7e24-41ff-95a5-e25bb2a950b4")) == null) {
				Columns.Add(CreateEventsCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("790bce2d-3665-4c0a-b730-584a306bf11b"),
				Name = @"BulkEmailId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
				ModifiedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateDateMarkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("fee14750-bc54-431b-9953-906fa1b6681d"),
				Name = @"DateMark",
				CreatedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
				ModifiedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateEventsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("66124707-7e24-41ff-95a5-e25bb2a950b4"),
				Name = @"EventsCount",
				CreatedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
				ModifiedInSchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"),
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
			return new BulkEmailHourlyOpens(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailHourlyOpens_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailHourlyOpensSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailHourlyOpensSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHourlyOpens

	/// <summary>
	/// История открытий ссылок Email.
	/// </summary>
	public class BulkEmailHourlyOpens : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailHourlyOpens(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailHourlyOpens";
		}

		public BulkEmailHourlyOpens(BulkEmailHourlyOpens source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// BulkEmailId.
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
		/// DateMark.
		/// </summary>
		public DateTime DateMark {
			get {
				return GetTypedColumnValue<DateTime>("DateMark");
			}
			set {
				SetColumnValue("DateMark", value);
			}
		}

		/// <summary>
		/// EventsCount.
		/// </summary>
		public int EventsCount {
			get {
				return GetTypedColumnValue<int>("EventsCount");
			}
			set {
				SetColumnValue("EventsCount", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailHourlyOpens_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailHourlyOpens(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHourlyOpens_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailHourlyOpens_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : BulkEmailHourlyOpens
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

		public BulkEmailHourlyOpens_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailHourlyOpens_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c6966308-17ab-4579-95fd-7db936d0e6c5");
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

	#region Class: BulkEmailHourlyOpens_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailHourlyOpens_MarketingCampaignEventsProcess : BulkEmailHourlyOpens_MarketingCampaignEventsProcess<BulkEmailHourlyOpens>
	{

		public BulkEmailHourlyOpens_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailHourlyOpens_MarketingCampaignEventsProcess

	public partial class BulkEmailHourlyOpens_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailHourlyOpensEventsProcess

	/// <exclude/>
	public class BulkEmailHourlyOpensEventsProcess : BulkEmailHourlyOpens_MarketingCampaignEventsProcess
	{

		public BulkEmailHourlyOpensEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

