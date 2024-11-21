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

	#region Class: CampaignQueueSchema

	/// <exclude/>
	public class CampaignQueueSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignQueueSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignQueueSchema(CampaignQueueSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignQueueSchema(CampaignQueueSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5");
			RealUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5");
			Name = "CampaignQueue";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ace61347-bfb2-4db2-b703-d987b095b2c8")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("76a454f1-26bf-498f-bc4b-39c9bdfac3e3")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("26873941-cc84-4092-b60b-daa2cb3629a3")) == null) {
				Columns.Add(CreateExpirationPeriodColumn());
			}
			if (Columns.FindByUId(new Guid("79de20f8-c6c4-4ffd-b4c5-5fee48a5d204")) == null) {
				Columns.Add(CreateCampaignParticipantColumn());
			}
			if (Columns.FindByUId(new Guid("f43c7264-3eac-4ef8-82c9-5b0ca5fd9d38")) == null) {
				Columns.Add(CreateLinkedEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("6bb63e9b-03f7-b59d-bc96-f7f200b84eb3")) == null) {
				Columns.Add(CreateEntitySchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ace61347-bfb2-4db2-b703-d987b095b2c8"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("76a454f1-26bf-498f-bc4b-39c9bdfac3e3"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateExpirationPeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("26873941-cc84-4092-b60b-daa2cb3629a3"),
				Name = @"ExpirationPeriod",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignParticipantColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("79de20f8-c6c4-4ffd-b4c5-5fee48a5d204"),
				Name = @"CampaignParticipant",
				ReferenceSchemaUId = new Guid("d42c6b3f-5128-4a5f-9346-557b066db650"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkedEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("f43c7264-3eac-4ef8-82c9-5b0ca5fd9d38"),
				Name = @"LinkedEntityId",
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateEntitySchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("6bb63e9b-03f7-b59d-bc96-f7f200b84eb3"),
				Name = @"EntitySchemaUId",
				CreatedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
				ModifiedInSchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"),
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
			return new CampaignQueue(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignQueue_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignQueueSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignQueueSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("90076ad1-6c95-424c-b841-d7b2051709f5"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignQueue

	/// <summary>
	/// Очередь для отложенного выполнения фрагментов кампаний.
	/// </summary>
	public class CampaignQueue : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignQueue(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignQueue";
		}

		public CampaignQueue(CampaignQueue source)
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

		/// <summary>
		/// Время жизни записи в очереди.
		/// </summary>
		public int ExpirationPeriod {
			get {
				return GetTypedColumnValue<int>("ExpirationPeriod");
			}
			set {
				SetColumnValue("ExpirationPeriod", value);
			}
		}

		/// <exclude/>
		public Guid CampaignParticipantId {
			get {
				return GetTypedColumnValue<Guid>("CampaignParticipantId");
			}
			set {
				SetColumnValue("CampaignParticipantId", value);
				_campaignParticipant = null;
			}
		}

		private CampaignParticipant _campaignParticipant;
		/// <summary>
		/// Участник кампании.
		/// </summary>
		public CampaignParticipant CampaignParticipant {
			get {
				return _campaignParticipant ??
					(_campaignParticipant = LookupColumnEntities.GetEntity("CampaignParticipant") as CampaignParticipant);
			}
		}

		/// <summary>
		/// Идентификатор связанного объекта.
		/// </summary>
		public Guid LinkedEntityId {
			get {
				return GetTypedColumnValue<Guid>("LinkedEntityId");
			}
			set {
				SetColumnValue("LinkedEntityId", value);
			}
		}

		/// <summary>
		/// Unique identifier of linked entity schema.
		/// </summary>
		public Guid EntitySchemaUId {
			get {
				return GetTypedColumnValue<Guid>("EntitySchemaUId");
			}
			set {
				SetColumnValue("EntitySchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignQueue_CampaignsEventsProcess(UserConnection);
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
			return new CampaignQueue(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignQueue_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignQueue_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignQueue
	{

		public CampaignQueue_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignQueue_CampaignsEventsProcess";
			SchemaUId = new Guid("90076ad1-6c95-424c-b841-d7b2051709f5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("90076ad1-6c95-424c-b841-d7b2051709f5");
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

	#region Class: CampaignQueue_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignQueue_CampaignsEventsProcess : CampaignQueue_CampaignsEventsProcess<CampaignQueue>
	{

		public CampaignQueue_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignQueue_CampaignsEventsProcess

	public partial class CampaignQueue_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignQueueEventsProcess

	/// <exclude/>
	public class CampaignQueueEventsProcess : CampaignQueue_CampaignsEventsProcess
	{

		public CampaignQueueEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

