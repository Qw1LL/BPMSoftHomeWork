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

	#region Class: BulkEmailQueueSchema

	/// <exclude/>
	public class BulkEmailQueueSchema : BPMSoft.Configuration.BaseTaskQueueSchema
	{

		#region Constructors: Public

		public BulkEmailQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailQueueSchema(BulkEmailQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailQueueSchema(BulkEmailQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b585999-843e-4553-8674-74bba330a056");
			RealUId = new Guid("7b585999-843e-4553-8674-74bba330a056");
			Name = "BulkEmailQueue";
			ParentSchemaUId = new Guid("de97f161-117b-49b0-b08a-38ae2a77cdd1");
			ExtendParent = false;
			CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("e4fed44d-8142-4f6a-8d12-f3bbfb97d403")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("c55cc1a2-8748-4b9f-87dd-b8e1211c95c0")) == null) {
				Columns.Add(CreateEstimatedRowsCountColumn());
			}
			if (Columns.FindByUId(new Guid("3ca64954-3823-49e6-8c81-ec0c9540dd1c")) == null) {
				Columns.Add(CreateEstimatedTimeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e4fed44d-8142-4f6a-8d12-f3bbfb97d403"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				ModifiedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateEstimatedRowsCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("c55cc1a2-8748-4b9f-87dd-b8e1211c95c0"),
				Name = @"EstimatedRowsCount",
				CreatedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				ModifiedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateEstimatedTimeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("3ca64954-3823-49e6-8c81-ec0c9540dd1c"),
				Name = @"EstimatedTime",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				ModifiedInSchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
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
			return new BulkEmailQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailQueue_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b585999-843e-4553-8674-74bba330a056"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailQueue

	/// <summary>
	/// BulkEmailQueue.
	/// </summary>
	public class BulkEmailQueue : BPMSoft.Configuration.BaseTaskQueue
	{

		#region Constructors: Public

		public BulkEmailQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailQueue";
		}

		public BulkEmailQueue(BulkEmailQueue source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid BulkEmailId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailId");
			}
			set {
				SetColumnValue("BulkEmailId", value);
				_bulkEmail = null;
			}
		}

		/// <exclude/>
		public string BulkEmailName {
			get {
				return GetTypedColumnValue<string>("BulkEmailName");
			}
			set {
				SetColumnValue("BulkEmailName", value);
				if (_bulkEmail != null) {
					_bulkEmail.Name = value;
				}
			}
		}

		private BulkEmail _bulkEmail;
		/// <summary>
		/// Рассылка.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <summary>
		/// Расчетное количество записей.
		/// </summary>
		public int EstimatedRowsCount {
			get {
				return GetTypedColumnValue<int>("EstimatedRowsCount");
			}
			set {
				SetColumnValue("EstimatedRowsCount", value);
			}
		}

		/// <summary>
		/// ETA (секунды).
		/// </summary>
		public int EstimatedTime {
			get {
				return GetTypedColumnValue<int>("EstimatedTime");
			}
			set {
				SetColumnValue("EstimatedTime", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailQueue_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailQueue_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailQueue_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseTaskQueue_TasksQueueEventsProcess<TEntity> where TEntity : BulkEmailQueue
	{

		public BulkEmailQueue_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailQueue_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("7b585999-843e-4553-8674-74bba330a056");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b585999-843e-4553-8674-74bba330a056");
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

	#region Class: BulkEmailQueue_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailQueue_MarketingCampaignEventsProcess : BulkEmailQueue_MarketingCampaignEventsProcess<BulkEmailQueue>
	{

		public BulkEmailQueue_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailQueue_MarketingCampaignEventsProcess

	public partial class BulkEmailQueue_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailQueueEventsProcess

	/// <exclude/>
	public class BulkEmailQueueEventsProcess : BulkEmailQueue_MarketingCampaignEventsProcess
	{

		public BulkEmailQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

