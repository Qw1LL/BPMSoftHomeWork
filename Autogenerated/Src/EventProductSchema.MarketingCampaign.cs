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

	#region Class: EventProductSchema

	/// <exclude/>
	public class EventProductSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public EventProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public EventProductSchema(EventProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public EventProductSchema(EventProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			RealUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			Name = "EventProduct";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2e92ac84-f0c1-4ce8-8135-a50fbc930c6d")) == null) {
				Columns.Add(CreateEventColumn());
			}
			if (Columns.FindByUId(new Guid("ace8ca5c-f761-4dfa-a2ae-47cb8a56433e")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("4438ffa8-84a6-4db3-85cd-68cafd059247")) == null) {
				Columns.Add(CreateBrandColumn());
			}
			if (Columns.FindByUId(new Guid("f1d6e9b5-348f-4739-a6b5-c4d2e83fa708")) == null) {
				Columns.Add(CreateNoteColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			column.CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d");
			return column;
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2e92ac84-f0c1-4ce8-8135-a50fbc930c6d"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ace8ca5c-f761-4dfa-a2ae-47cb8a56433e"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateBrandColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4438ffa8-84a6-4db3-85cd-68cafd059247"),
				Name = @"Brand",
				ReferenceSchemaUId = new Guid("fddaa2c5-f6e7-4199-a5ea-8217948ce1bd"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected virtual EntitySchemaColumn CreateNoteColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("f1d6e9b5-348f-4739-a6b5-c4d2e83fa708"),
				Name = @"Note",
				CreatedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				ModifiedInSchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"),
				CreatedInPackageId = new Guid("b827f319-d8b8-41a8-9645-da32137f000d")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new EventProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new EventProduct_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new EventProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new EventProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53"));
		}

		#endregion

	}

	#endregion

	#region Class: EventProduct

	/// <summary>
	/// Продукт в мероприятии.
	/// </summary>
	public class EventProduct : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public EventProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "EventProduct";
		}

		public EventProduct(EventProduct source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid EventId {
			get {
				return GetTypedColumnValue<Guid>("EventId");
			}
			set {
				SetColumnValue("EventId", value);
				_event = null;
			}
		}

		/// <exclude/>
		public string EventName {
			get {
				return GetTypedColumnValue<string>("EventName");
			}
			set {
				SetColumnValue("EventName", value);
				if (_event != null) {
					_event.Name = value;
				}
			}
		}

		private Event _event;
		/// <summary>
		/// Мероприятие.
		/// </summary>
		public Event Event {
			get {
				return _event ??
					(_event = LookupColumnEntities.GetEntity("Event") as Event);
			}
		}

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private Product _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <exclude/>
		public Guid BrandId {
			get {
				return GetTypedColumnValue<Guid>("BrandId");
			}
			set {
				SetColumnValue("BrandId", value);
				_brand = null;
			}
		}

		/// <exclude/>
		public string BrandName {
			get {
				return GetTypedColumnValue<string>("BrandName");
			}
			set {
				SetColumnValue("BrandName", value);
				if (_brand != null) {
					_brand.Name = value;
				}
			}
		}

		private Brand _brand;
		/// <summary>
		/// Бренд.
		/// </summary>
		public Brand Brand {
			get {
				return _brand ??
					(_brand = LookupColumnEntities.GetEntity("Brand") as Brand);
			}
		}

		/// <summary>
		/// Описание.
		/// </summary>
		public string Note {
			get {
				return GetTypedColumnValue<string>("Note");
			}
			set {
				SetColumnValue("Note", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new EventProduct_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("EventProductDeleted", e);
			Inserting += (s, e) => ThrowEvent("EventProductInserting", e);
			Validating += (s, e) => ThrowEvent("EventProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new EventProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: EventProduct_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class EventProduct_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : EventProduct
	{

		public EventProduct_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "EventProduct_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a0f34628-c351-45bc-8eef-b933cfe9bb53");
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

	#region Class: EventProduct_MarketingCampaignEventsProcess

	/// <exclude/>
	public class EventProduct_MarketingCampaignEventsProcess : EventProduct_MarketingCampaignEventsProcess<EventProduct>
	{

		public EventProduct_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: EventProduct_MarketingCampaignEventsProcess

	public partial class EventProduct_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: EventProductEventsProcess

	/// <exclude/>
	public class EventProductEventsProcess : EventProduct_MarketingCampaignEventsProcess
	{

		public EventProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

