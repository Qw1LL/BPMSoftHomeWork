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

	#region Class: FormSubmitSchema

	/// <exclude/>
	public class FormSubmitSchema : BPMSoft.Configuration.FormSubmit_TouchPoints_BPMSoftSchema
	{

		#region Constructors: Public

		public FormSubmitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public FormSubmitSchema(FormSubmitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public FormSubmitSchema(FormSubmitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79");
			Name = "FormSubmit";
			ParentSchemaUId = new Guid("5e2c524a-666f-491c-ba9f-ce03e82bb015");
			ExtendParent = true;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("f425f43d-1d35-319c-eded-6f6cb3e777b7")) == null) {
				Columns.Add(CreateEventColumn());
			}
			if (Columns.FindByUId(new Guid("12dc1549-0c87-fc56-ec37-5edc8257f6a4")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("804e26fc-d32a-3e93-5459-8586ac8d9015")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateEventColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f425f43d-1d35-319c-eded-6f6cb3e777b7"),
				Name = @"Event",
				ReferenceSchemaUId = new Guid("5b4fdfc7-12b6-4b4f-a9bd-b6f1b6e4447f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				ModifiedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("12dc1549-0c87-fc56-ec37-5edc8257f6a4"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				ModifiedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("804e26fc-d32a-3e93-5459-8586ac8d9015"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				ModifiedInSchemaUId = new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new FormSubmit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new FormSubmit_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new FormSubmitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new FormSubmitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79"));
		}

		#endregion

	}

	#endregion

	#region Class: FormSubmit

	/// <summary>
	/// Заполненная веб-форма.
	/// </summary>
	public class FormSubmit : BPMSoft.Configuration.FormSubmit_TouchPoints_BPMSoft
	{

		#region Constructors: Public

		public FormSubmit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "FormSubmit";
		}

		public FormSubmit(FormSubmit source)
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
			var process = new FormSubmit_MarketingCampaignEventsProcess(UserConnection);
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
			return new FormSubmit(this);
		}

		#endregion

	}

	#endregion

	#region Class: FormSubmit_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class FormSubmit_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.FormSubmit_TouchPointsEventsProcess<TEntity> where TEntity : FormSubmit
	{

		public FormSubmit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "FormSubmit_MarketingCampaignEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("ce4ab5fc-623a-4bfd-a513-0b7d41834b79");
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

	#region Class: FormSubmit_MarketingCampaignEventsProcess

	/// <exclude/>
	public class FormSubmit_MarketingCampaignEventsProcess : FormSubmit_MarketingCampaignEventsProcess<FormSubmit>
	{

		public FormSubmit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: FormSubmit_MarketingCampaignEventsProcess

	public partial class FormSubmit_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: FormSubmitEventsProcess

	/// <exclude/>
	public class FormSubmitEventsProcess : FormSubmit_MarketingCampaignEventsProcess
	{

		public FormSubmitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

