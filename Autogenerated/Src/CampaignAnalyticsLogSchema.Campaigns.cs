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

	#region Class: CampaignAnalyticsLogSchema

	/// <exclude/>
	public class CampaignAnalyticsLogSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignAnalyticsLogSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignAnalyticsLogSchema(CampaignAnalyticsLogSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignAnalyticsLogSchema(CampaignAnalyticsLogSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee");
			RealUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee");
			Name = "CampaignAnalyticsLog";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("b5c39ce8-d842-57f3-59a1-cc4af765ccc9")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("2ddf6015-495c-c1fd-9060-10992dbd9908")) == null) {
				Columns.Add(CreateDateColumn());
			}
			if (Columns.FindByUId(new Guid("63fec8ff-0ca9-aabe-50db-e789d7e9d2a7")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("8c0bd6a2-b839-4291-8d9b-b96c7a560862")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("b5c39ce8-d842-57f3-59a1-cc4af765ccc9"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				ModifiedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("2ddf6015-495c-c1fd-9060-10992dbd9908"),
				Name = @"Date",
				CreatedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				ModifiedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("63fec8ff-0ca9-aabe-50db-e789d7e9d2a7"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				ModifiedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c0bd6a2-b839-4291-8d9b-b96c7a560862"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				ModifiedInSchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new CampaignAnalyticsLog(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignAnalyticsLog_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignAnalyticsLogSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignAnalyticsLogSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignAnalyticsLog

	/// <summary>
	/// Журнал аналитики по кампании.
	/// </summary>
	public class CampaignAnalyticsLog : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignAnalyticsLog(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignAnalyticsLog";
		}

		public CampaignAnalyticsLog(CampaignAnalyticsLog source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Количество.
		/// </summary>
		public int Amount {
			get {
				return GetTypedColumnValue<int>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Дата.
		/// </summary>
		public DateTime Date {
			get {
				return GetTypedColumnValue<DateTime>("Date");
			}
			set {
				SetColumnValue("Date", value);
			}
		}

		/// <exclude/>
		public Guid CampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("CampaignItemId");
			}
			set {
				SetColumnValue("CampaignItemId", value);
				_campaignItem = null;
			}
		}

		/// <exclude/>
		public string CampaignItemName {
			get {
				return GetTypedColumnValue<string>("CampaignItemName");
			}
			set {
				SetColumnValue("CampaignItemName", value);
				if (_campaignItem != null) {
					_campaignItem.Name = value;
				}
			}
		}

		private CampaignItem _campaignItem;
		/// <summary>
		/// Шаг кампании.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = LookupColumnEntities.GetEntity("CampaignItem") as CampaignItem);
			}
		}

		/// <exclude/>
		public Guid CampaignId {
			get {
				return GetTypedColumnValue<Guid>("CampaignId");
			}
			set {
				SetColumnValue("CampaignId", value);
				_campaign = null;
			}
		}

		/// <exclude/>
		public string CampaignName {
			get {
				return GetTypedColumnValue<string>("CampaignName");
			}
			set {
				SetColumnValue("CampaignName", value);
				if (_campaign != null) {
					_campaign.Name = value;
				}
			}
		}

		private Campaign _campaign;
		/// <summary>
		/// Кампания.
		/// </summary>
		public Campaign Campaign {
			get {
				return _campaign ??
					(_campaign = LookupColumnEntities.GetEntity("Campaign") as Campaign);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignAnalyticsLog_CampaignsEventsProcess(UserConnection);
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
			return new CampaignAnalyticsLog(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignAnalyticsLog_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignAnalyticsLog_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignAnalyticsLog
	{

		public CampaignAnalyticsLog_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignAnalyticsLog_CampaignsEventsProcess";
			SchemaUId = new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5b5259cd-ddbe-4267-8e41-1f2bbe2c89ee");
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

	#region Class: CampaignAnalyticsLog_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignAnalyticsLog_CampaignsEventsProcess : CampaignAnalyticsLog_CampaignsEventsProcess<CampaignAnalyticsLog>
	{

		public CampaignAnalyticsLog_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignAnalyticsLog_CampaignsEventsProcess

	public partial class CampaignAnalyticsLog_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignAnalyticsLogEventsProcess

	/// <exclude/>
	public class CampaignAnalyticsLogEventsProcess : CampaignAnalyticsLog_CampaignsEventsProcess
	{

		public CampaignAnalyticsLogEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

