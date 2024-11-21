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

	#region Class: BulkEmailSubscriptionSchema

	/// <exclude/>
	public class BulkEmailSubscriptionSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailSubscriptionSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailSubscriptionSchema(BulkEmailSubscriptionSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailSubscriptionSchema(BulkEmailSubscriptionSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			RealUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			Name = "BulkEmailSubscription";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f9439025-deb8-44e9-8820-eccf85451f48")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("062ba997-5cf3-4ab7-befb-ba292e02f28f")) == null) {
				Columns.Add(CreateBulkEmailTypeColumn());
			}
			if (Columns.FindByUId(new Guid("3943ceae-c85f-4ab0-8cd2-d4f5cba8b2da")) == null) {
				Columns.Add(CreateBulkEmailSubsStatusColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			column.CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95");
			return column;
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f9439025-deb8-44e9-8820-eccf85451f48"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("062ba997-5cf3-4ab7-befb-ba292e02f28f"),
				Name = @"BulkEmailType",
				ReferenceSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailSubsStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("3943ceae-c85f-4ab0-8cd2-d4f5cba8b2da"),
				Name = @"BulkEmailSubsStatus",
				ReferenceSchemaUId = new Guid("40516046-e9f2-4922-8e85-01c5251329f7"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				ModifiedInSchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"),
				CreatedInPackageId = new Guid("036273dd-d44c-45e1-8c98-d51acfaf8b95")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailSubscription(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailSubscription_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailSubscriptionSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailSubscriptionSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSubscription

	/// <summary>
	/// Подписка на рассылки Email.
	/// </summary>
	public class BulkEmailSubscription : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailSubscription(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailSubscription";
		}

		public BulkEmailSubscription(BulkEmailSubscription source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid BulkEmailTypeId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailTypeId");
			}
			set {
				SetColumnValue("BulkEmailTypeId", value);
				_bulkEmailType = null;
			}
		}

		/// <exclude/>
		public string BulkEmailTypeName {
			get {
				return GetTypedColumnValue<string>("BulkEmailTypeName");
			}
			set {
				SetColumnValue("BulkEmailTypeName", value);
				if (_bulkEmailType != null) {
					_bulkEmailType.Name = value;
				}
			}
		}

		private BulkEmailType _bulkEmailType;
		/// <summary>
		/// Тип рассылки.
		/// </summary>
		public BulkEmailType BulkEmailType {
			get {
				return _bulkEmailType ??
					(_bulkEmailType = LookupColumnEntities.GetEntity("BulkEmailType") as BulkEmailType);
			}
		}

		/// <exclude/>
		public Guid BulkEmailSubsStatusId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailSubsStatusId");
			}
			set {
				SetColumnValue("BulkEmailSubsStatusId", value);
				_bulkEmailSubsStatus = null;
			}
		}

		/// <exclude/>
		public string BulkEmailSubsStatusName {
			get {
				return GetTypedColumnValue<string>("BulkEmailSubsStatusName");
			}
			set {
				SetColumnValue("BulkEmailSubsStatusName", value);
				if (_bulkEmailSubsStatus != null) {
					_bulkEmailSubsStatus.Name = value;
				}
			}
		}

		private BulkEmailSubsStatus _bulkEmailSubsStatus;
		/// <summary>
		/// Статус подписки.
		/// </summary>
		public BulkEmailSubsStatus BulkEmailSubsStatus {
			get {
				return _bulkEmailSubsStatus ??
					(_bulkEmailSubsStatus = LookupColumnEntities.GetEntity("BulkEmailSubsStatus") as BulkEmailSubsStatus);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailSubscription_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailSubscriptionDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailSubscriptionInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailSubscriptionValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailSubscription(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailSubscription_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailSubscription_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailSubscription
	{

		public BulkEmailSubscription_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailSubscription_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("f97c7fd3-c52c-4a76-9cbd-c749e4fda8de");
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

	#region Class: BulkEmailSubscription_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailSubscription_MarketingCampaignEventsProcess : BulkEmailSubscription_MarketingCampaignEventsProcess<BulkEmailSubscription>
	{

		public BulkEmailSubscription_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailSubscription_MarketingCampaignEventsProcess

	public partial class BulkEmailSubscription_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailSubscriptionEventsProcess

	/// <exclude/>
	public class BulkEmailSubscriptionEventsProcess : BulkEmailSubscription_MarketingCampaignEventsProcess
	{

		public BulkEmailSubscriptionEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

