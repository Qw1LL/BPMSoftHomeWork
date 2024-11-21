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

	#region Class: MandrillWebhookSchema

	/// <exclude/>
	public class MandrillWebhookSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public MandrillWebhookSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public MandrillWebhookSchema(MandrillWebhookSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public MandrillWebhookSchema(MandrillWebhookSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			RealUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			Name = "MandrillWebhook";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("07e2d2ff-105d-4a42-a1dd-1c472823f30a")) == null) {
				Columns.Add(CreateWebhookIdColumn());
			}
			if (Columns.FindByUId(new Guid("f1c1b7d7-cf8e-425f-be50-88d991c8bc17")) == null) {
				Columns.Add(CreateAuthKeyColumn());
			}
			if (Columns.FindByUId(new Guid("6c4b0318-9dba-4b9b-a8fe-149d65a049d3")) == null) {
				Columns.Add(CreateWebhookURLColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			column.CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0");
			return column;
		}

		protected virtual EntitySchemaColumn CreateWebhookIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("07e2d2ff-105d-4a42-a1dd-1c472823f30a"),
				Name = @"WebhookId",
				CreatedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected virtual EntitySchemaColumn CreateAuthKeyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("f1c1b7d7-cf8e-425f-be50-88d991c8bc17"),
				Name = @"AuthKey",
				CreatedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected virtual EntitySchemaColumn CreateWebhookURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("LongText")) {
				UId = new Guid("6c4b0318-9dba-4b9b-a8fe-149d65a049d3"),
				Name = @"WebhookURL",
				CreatedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				ModifiedInSchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"),
				CreatedInPackageId = new Guid("b477c174-1d53-4a21-b489-a41e481a96a0")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new MandrillWebhook(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new MandrillWebhook_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new MandrillWebhookSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new MandrillWebhookSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9cb40145-6516-4748-9f9c-905cd3aac514"));
		}

		#endregion

	}

	#endregion

	#region Class: MandrillWebhook

	/// <summary>
	/// Событие обновления рассылки от Mandrill.
	/// </summary>
	public class MandrillWebhook : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public MandrillWebhook(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "MandrillWebhook";
		}

		public MandrillWebhook(MandrillWebhook source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Порядковый номер.
		/// </summary>
		public int WebhookId {
			get {
				return GetTypedColumnValue<int>("WebhookId");
			}
			set {
				SetColumnValue("WebhookId", value);
			}
		}

		/// <summary>
		/// Ключ аутентификации.
		/// </summary>
		public string AuthKey {
			get {
				return GetTypedColumnValue<string>("AuthKey");
			}
			set {
				SetColumnValue("AuthKey", value);
			}
		}

		/// <summary>
		/// Адрес webhook на клиенте.
		/// </summary>
		public string WebhookURL {
			get {
				return GetTypedColumnValue<string>("WebhookURL");
			}
			set {
				SetColumnValue("WebhookURL", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new MandrillWebhook_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("MandrillWebhookDeleted", e);
			Inserting += (s, e) => ThrowEvent("MandrillWebhookInserting", e);
			Validating += (s, e) => ThrowEvent("MandrillWebhookValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new MandrillWebhook(this);
		}

		#endregion

	}

	#endregion

	#region Class: MandrillWebhook_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class MandrillWebhook_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : MandrillWebhook
	{

		public MandrillWebhook_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "MandrillWebhook_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("9cb40145-6516-4748-9f9c-905cd3aac514");
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

	#region Class: MandrillWebhook_MarketingCampaignEventsProcess

	/// <exclude/>
	public class MandrillWebhook_MarketingCampaignEventsProcess : MandrillWebhook_MarketingCampaignEventsProcess<MandrillWebhook>
	{

		public MandrillWebhook_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: MandrillWebhook_MarketingCampaignEventsProcess

	public partial class MandrillWebhook_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: MandrillWebhookEventsProcess

	/// <exclude/>
	public class MandrillWebhookEventsProcess : MandrillWebhook_MarketingCampaignEventsProcess
	{

		public MandrillWebhookEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

