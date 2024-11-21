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

	#region Class: BulkEmailTargetSchema

	/// <exclude/>
	public class BulkEmailTargetSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailTargetSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailTargetSchema(BulkEmailTargetSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailTargetSchema(BulkEmailTargetSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIXBETContactIdResponseIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("eb0d4871-38c9-4db9-995f-7a034207b9f3");
			index.Name = "IXBETContactIdResponseId";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			EntitySchemaIndexColumn contactIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("082a97bd-6875-3f7c-ff80-9f8049de0da2"),
				ColumnUId = new Guid("8b85ee02-7cd9-4f86-a938-d44f8fc1d41a"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(contactIdIndexColumn);
			EntitySchemaIndexColumn bulkEmailResponseIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("efc97fe8-19e8-ad2d-d395-3bc7ffebb9d0"),
				ColumnUId = new Guid("91b87361-603a-4602-b7dc-09b46423343e"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(bulkEmailResponseIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0");
			RealUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0");
			Name = "BulkEmailTarget";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c0c04f91-bec0-4c97-a3e3-341610a1ae2f")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("91b87361-603a-4602-b7dc-09b46423343e")) == null) {
				Columns.Add(CreateBulkEmailResponseColumn());
			}
			if (Columns.FindByUId(new Guid("d49bd700-f47a-4b08-9922-cd4f490b6489")) == null) {
				Columns.Add(CreateClicksColumn());
			}
			if (Columns.FindByUId(new Guid("8b85ee02-7cd9-4f86-a938-d44f8fc1d41a")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("b7bd7279-4f36-41f7-8b24-d0db933828ee")) == null) {
				Columns.Add(CreateEmailAddressColumn());
			}
			if (Columns.FindByUId(new Guid("87ba1b0a-c890-4a54-8e95-d2ffce5f0520")) == null) {
				Columns.Add(CreateLinkedEntityIdColumn());
			}
			if (Columns.FindByUId(new Guid("357bfa16-8ce0-4384-9903-8a654a337c88")) == null) {
				Columns.Add(CreateMandrillIdColumn());
			}
			if (Columns.FindByUId(new Guid("78e6abd9-ae00-45df-9a15-89e0319c58c8")) == null) {
				Columns.Add(CreateOpensColumn());
			}
			if (Columns.FindByUId(new Guid("685ad3c0-62ef-9f9b-2d9f-c56322916b58")) == null) {
				Columns.Add(CreateProviderNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c0c04f91-bec0-4c97-a3e3-341610a1ae2f"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("91b87361-603a-4602-b7dc-09b46423343e"),
				Name = @"BulkEmailResponse",
				ReferenceSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"14769602-ebda-40b1-91d5-ea9d623e2400"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateClicksColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("d49bd700-f47a-4b08-9922-cd4f490b6489"),
				Name = @"Clicks",
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8b85ee02-7cd9-4f86-a938-d44f8fc1d41a"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateEmailAddressColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("b7bd7279-4f36-41f7-8b24-d0db933828ee"),
				Name = @"EmailAddress",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateLinkedEntityIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("87ba1b0a-c890-4a54-8e95-d2ffce5f0520"),
				Name = @"LinkedEntityId",
				IsValueCloneable = false,
				IsWeakReference = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateMandrillIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("357bfa16-8ce0-4384-9903-8a654a337c88"),
				Name = @"MandrillId",
				IsValueCloneable = false,
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"AutoGuid")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOpensColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("78e6abd9-ae00-45df-9a15-89e0319c58c8"),
				Name = @"Opens",
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateProviderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("685ad3c0-62ef-9f9b-2d9f-c56322916b58"),
				Name = @"ProviderName",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				ModifiedInSchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIXBETContactIdResponseIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailTarget(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailTarget_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailTargetSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailTargetSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailTarget

	/// <summary>
	/// Отклик в Email.
	/// </summary>
	public class BulkEmailTarget : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailTarget(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailTarget";
		}

		public BulkEmailTarget(BulkEmailTarget source)
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

		/// <exclude/>
		public Guid BulkEmailResponseId {
			get {
				return GetTypedColumnValue<Guid>("BulkEmailResponseId");
			}
			set {
				SetColumnValue("BulkEmailResponseId", value);
				_bulkEmailResponse = null;
			}
		}

		/// <exclude/>
		public string BulkEmailResponseName {
			get {
				return GetTypedColumnValue<string>("BulkEmailResponseName");
			}
			set {
				SetColumnValue("BulkEmailResponseName", value);
				if (_bulkEmailResponse != null) {
					_bulkEmailResponse.Name = value;
				}
			}
		}

		private BulkEmailResponse _bulkEmailResponse;
		/// <summary>
		/// Отклик.
		/// </summary>
		public BulkEmailResponse BulkEmailResponse {
			get {
				return _bulkEmailResponse ??
					(_bulkEmailResponse = LookupColumnEntities.GetEntity("BulkEmailResponse") as BulkEmailResponse);
			}
		}

		/// <summary>
		/// Переходы.
		/// </summary>
		public int Clicks {
			get {
				return GetTypedColumnValue<int>("Clicks");
			}
			set {
				SetColumnValue("Clicks", value);
			}
		}

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

		/// <summary>
		/// Email адрес.
		/// </summary>
		public string EmailAddress {
			get {
				return GetTypedColumnValue<string>("EmailAddress");
			}
			set {
				SetColumnValue("EmailAddress", value);
			}
		}

		/// <summary>
		/// Extended entity.
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
		/// MandrillId.
		/// </summary>
		public Guid MandrillId {
			get {
				return GetTypedColumnValue<Guid>("MandrillId");
			}
			set {
				SetColumnValue("MandrillId", value);
			}
		}

		/// <summary>
		/// Открытия.
		/// </summary>
		public int Opens {
			get {
				return GetTypedColumnValue<int>("Opens");
			}
			set {
				SetColumnValue("Opens", value);
			}
		}

		/// <summary>
		/// Провайдер отправки.
		/// </summary>
		public string ProviderName {
			get {
				return GetTypedColumnValue<string>("ProviderName");
			}
			set {
				SetColumnValue("ProviderName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailTarget_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailTargetDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailTargetInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailTargetValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailTarget(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailTarget_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailTarget
	{

		public BulkEmailTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailTarget_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bcc8d07b-aed8-400b-9bee-a8415c9c81a0");
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

	#region Class: BulkEmailTarget_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailTarget_MarketingCampaignEventsProcess : BulkEmailTarget_MarketingCampaignEventsProcess<BulkEmailTarget>
	{

		public BulkEmailTarget_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailTarget_MarketingCampaignEventsProcess

	public partial class BulkEmailTarget_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailTargetEventsProcess

	/// <exclude/>
	public class BulkEmailTargetEventsProcess : BulkEmailTarget_MarketingCampaignEventsProcess
	{

		public BulkEmailTargetEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

