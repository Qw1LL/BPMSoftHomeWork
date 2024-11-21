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

	#region Class: CampaignItemSchema

	/// <exclude/>
	public class CampaignItemSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public CampaignItemSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public CampaignItemSchema(CampaignItemSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public CampaignItemSchema(CampaignItemSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650");
			RealUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650");
			Name = "CampaignItem";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("480d78fb-8f77-47bc-8b95-33315d9e4ed2")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
			if (Columns.FindByUId(new Guid("922e9524-5901-4f6a-aabb-843c93f246d7")) == null) {
				Columns.Add(CreateIsDeletedColumn());
			}
			if (Columns.FindByUId(new Guid("a2dac92f-5717-4288-ad0b-aaf3cf9245a8")) == null) {
				Columns.Add(CreateCampaignElementTypeColumn());
			}
			if (Columns.FindByUId(new Guid("df7702b9-5729-4905-b5bd-723d56247626")) == null) {
				Columns.Add(CreateRecordIdColumn());
			}
			if (Columns.FindByUId(new Guid("d1f6c6aa-32b4-49d6-87b0-868d2e54a74e")) == null) {
				Columns.Add(CreateSysSchemaUIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("480d78fb-8f77-47bc-8b95-33315d9e4ed2"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("bee66590-c0f5-47ef-8767-1f55e74bc486"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateIsDeletedColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("922e9524-5901-4f6a-aabb-843c93f246d7"),
				Name = @"IsDeleted",
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				CreatedInPackageId = new Guid("0fa99f9a-3eca-422f-9a3c-3294c39b5190")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignElementTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("a2dac92f-5717-4288-ad0b-aaf3cf9245a8"),
				Name = @"CampaignElementType",
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateRecordIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("df7702b9-5729-4905-b5bd-723d56247626"),
				Name = @"RecordId",
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef")
			};
		}

		protected virtual EntitySchemaColumn CreateSysSchemaUIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("d1f6c6aa-32b4-49d6-87b0-868d2e54a74e"),
				Name = @"SysSchemaUId",
				CreatedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				ModifiedInSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
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
			return new CampaignItem(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new CampaignItem_CampaignsEventsProcess(userConnection);
		}

		public override object Clone() {
			return new CampaignItemSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new CampaignItemSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"));
		}

		#endregion

	}

	#endregion

	#region Class: CampaignItem

	/// <summary>
	/// Шаги кампании.
	/// </summary>
	public class CampaignItem : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public CampaignItem(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "CampaignItem";
		}

		public CampaignItem(CampaignItem source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Удален.
		/// </summary>
		public bool IsDeleted {
			get {
				return GetTypedColumnValue<bool>("IsDeleted");
			}
			set {
				SetColumnValue("IsDeleted", value);
			}
		}

		/// <summary>
		/// Тип элемента кампании.
		/// </summary>
		public string CampaignElementType {
			get {
				return GetTypedColumnValue<string>("CampaignElementType");
			}
			set {
				SetColumnValue("CampaignElementType", value);
			}
		}

		/// <summary>
		/// Id связанной сущности.
		/// </summary>
		public Guid RecordId {
			get {
				return GetTypedColumnValue<Guid>("RecordId");
			}
			set {
				SetColumnValue("RecordId", value);
			}
		}

		/// <summary>
		/// SysSchemaUId.
		/// </summary>
		public Guid SysSchemaUId {
			get {
				return GetTypedColumnValue<Guid>("SysSchemaUId");
			}
			set {
				SetColumnValue("SysSchemaUId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new CampaignItem_CampaignsEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("CampaignItemDeleted", e);
			Validating += (s, e) => ThrowEvent("CampaignItemValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new CampaignItem(this);
		}

		#endregion

	}

	#endregion

	#region Class: CampaignItem_CampaignsEventsProcess

	/// <exclude/>
	public partial class CampaignItem_CampaignsEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : CampaignItem
	{

		public CampaignItem_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "CampaignItem_CampaignsEventsProcess";
			SchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650");
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

	#region Class: CampaignItem_CampaignsEventsProcess

	/// <exclude/>
	public class CampaignItem_CampaignsEventsProcess : CampaignItem_CampaignsEventsProcess<CampaignItem>
	{

		public CampaignItem_CampaignsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: CampaignItem_CampaignsEventsProcess

	public partial class CampaignItem_CampaignsEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: CampaignItemEventsProcess

	/// <exclude/>
	public class CampaignItemEventsProcess : CampaignItem_CampaignsEventsProcess
	{

		public CampaignItemEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

