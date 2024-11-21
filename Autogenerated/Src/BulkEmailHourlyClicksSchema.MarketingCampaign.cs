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

	#region Class: BulkEmailHourlyClicksSchema

	/// <exclude/>
	public class BulkEmailHourlyClicksSchema : BPMSoft.Core.Entities.EntitySchema
	{

		#region Constructors: Public

		public BulkEmailHourlyClicksSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailHourlyClicksSchema(BulkEmailHourlyClicksSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailHourlyClicksSchema(BulkEmailHourlyClicksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327");
			RealUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327");
			Name = "BulkEmailHourlyClicks";
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
			if (Columns.FindByUId(new Guid("773b2a1c-fa2f-44ce-9439-c35a27e9e18c")) == null) {
				Columns.Add(CreateDateMarkColumn());
			}
			if (Columns.FindByUId(new Guid("e46f46e2-0bc1-43f6-8151-b02ff1e3da51")) == null) {
				Columns.Add(CreateEventsCountColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("21816c6d-9251-4843-91da-e84464ba552c"),
				Name = @"BulkEmailId",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
				ModifiedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateDateMarkColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("773b2a1c-fa2f-44ce-9439-c35a27e9e18c"),
				Name = @"DateMark",
				CreatedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
				ModifiedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
				CreatedInPackageId = new Guid("ad2d5243-f3e1-4196-99cf-d5d7d1dcc487")
			};
		}

		protected virtual EntitySchemaColumn CreateEventsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("e46f46e2-0bc1-43f6-8151-b02ff1e3da51"),
				Name = @"EventsCount",
				CreatedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
				ModifiedInSchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"),
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
			return new BulkEmailHourlyClicks(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailHourlyClicks_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailHourlyClicksSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailHourlyClicksSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHourlyClicks

	/// <summary>
	/// История переходов по ссылке Email.
	/// </summary>
	public class BulkEmailHourlyClicks : BPMSoft.Core.Entities.Entity
	{

		#region Constructors: Public

		public BulkEmailHourlyClicks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailHourlyClicks";
		}

		public BulkEmailHourlyClicks(BulkEmailHourlyClicks source)
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
			var process = new BulkEmailHourlyClicks_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailHourlyClicks(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHourlyClicks_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailHourlyClicks_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Core.Process.EmbeddedProcess where TEntity : BulkEmailHourlyClicks
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

		public BulkEmailHourlyClicks_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailHourlyClicks_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cba8f5af-c2cb-40e7-8ba0-024ab1a4d327");
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

	#region Class: BulkEmailHourlyClicks_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailHourlyClicks_MarketingCampaignEventsProcess : BulkEmailHourlyClicks_MarketingCampaignEventsProcess<BulkEmailHourlyClicks>
	{

		public BulkEmailHourlyClicks_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailHourlyClicks_MarketingCampaignEventsProcess

	public partial class BulkEmailHourlyClicks_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailHourlyClicksEventsProcess

	/// <exclude/>
	public class BulkEmailHourlyClicksEventsProcess : BulkEmailHourlyClicks_MarketingCampaignEventsProcess
	{

		public BulkEmailHourlyClicksEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

