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

	#region Class: LeadGenWebhooksSchema

	/// <exclude/>
	public class LeadGenWebhooksSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public LeadGenWebhooksSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenWebhooksSchema(LeadGenWebhooksSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenWebhooksSchema(LeadGenWebhooksSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIdxFormIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("ef852667-aeef-4981-ae7a-419068c331be");
			index.Name = "IdxFormId";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			EntitySchemaIndexColumn formIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("ada8a8ef-d084-bc2a-eebe-3725a48bd288"),
				ColumnUId = new Guid("ea28661e-2833-dc25-e4f3-04f8add1b9f6"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(formIdIndexColumn);
			return index;
		}

		private EntitySchemaIndex CreateIdxSocialLeadIdIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("5fe9b1ea-d579-4146-8466-117ba8330bb1");
			index.Name = "IdxSocialLeadId";
			index.CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			index.CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			EntitySchemaIndexColumn socialLeadIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("60e472a1-4891-eb1c-84d5-c14e4296ec9e"),
				ColumnUId = new Guid("a6599a6b-4e0d-413c-466c-1ee153e14d5a"),
				CreatedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				ModifiedInSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(socialLeadIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5");
			RealUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5");
			Name = "LeadGenWebhooks";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("a0f9c4e9-d84e-ce2f-2d91-01983d5d32fa")) == null) {
				Columns.Add(CreateSocialCreatedOnColumn());
			}
			if (Columns.FindByUId(new Guid("956bb4e8-21c5-48ef-9d0e-db19341b9d8b")) == null) {
				Columns.Add(CreateWebhookStatusUpdateDateColumn());
			}
			if (Columns.FindByUId(new Guid("7799280e-3934-3498-e7ea-79d74b4b417c")) == null) {
				Columns.Add(CreateFormMetadataColumn());
			}
			if (Columns.FindByUId(new Guid("a6599a6b-4e0d-413c-466c-1ee153e14d5a")) == null) {
				Columns.Add(CreateSocialLeadIdColumn());
			}
			if (Columns.FindByUId(new Guid("5a685f86-1bc7-c480-3613-eca6d9ef570c")) == null) {
				Columns.Add(CreateLeadGenWebhookStatusColumn());
			}
			if (Columns.FindByUId(new Guid("99785712-013b-ff66-ee18-eb988dc41762")) == null) {
				Columns.Add(CreateLeadGenNetworkTypeColumn());
			}
			if (Columns.FindByUId(new Guid("4c8f7de9-19fc-331b-1ef1-b408efe00fcb")) == null) {
				Columns.Add(CreateIntegrationIdColumn());
			}
			if (Columns.FindByUId(new Guid("ea28661e-2833-dc25-e4f3-04f8add1b9f6")) == null) {
				Columns.Add(CreateFormIdColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialCreatedOnColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("a0f9c4e9-d84e-ce2f-2d91-01983d5d32fa"),
				Name = @"SocialCreatedOn",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateWebhookStatusUpdateDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("956bb4e8-21c5-48ef-9d0e-db19341b9d8b"),
				Name = @"WebhookStatusUpdateDate",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateFormMetadataColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7799280e-3934-3498-e7ea-79d74b4b417c"),
				Name = @"FormMetadata",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateSocialLeadIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("a6599a6b-4e0d-413c-466c-1ee153e14d5a"),
				Name = @"SocialLeadId",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenWebhookStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5a685f86-1bc7-c480-3613-eca6d9ef570c"),
				Name = @"LeadGenWebhookStatus",
				ReferenceSchemaUId = new Guid("1b63dd98-ab55-4b21-bd81-2419b32d2c09"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenNetworkTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("99785712-013b-ff66-ee18-eb988dc41762"),
				Name = @"LeadGenNetworkType",
				ReferenceSchemaUId = new Guid("2f219369-8c87-4a6f-bf14-b048b134ea66"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateIntegrationIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("4c8f7de9-19fc-331b-1ef1-b408efe00fcb"),
				Name = @"IntegrationId",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateFormIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("ea28661e-2833-dc25-e4f3-04f8add1b9f6"),
				Name = @"FormId",
				CreatedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				ModifiedInSchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIdxFormIdIndex());
			Indexes.Add(CreateIdxSocialLeadIdIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadGenWebhooks(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenWebhooks_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenWebhooksSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenWebhooksSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2c694123-ed64-4632-941f-fa80612ee1d5"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenWebhooks

	/// <summary>
	/// Метаданные вебхуков лидогенерации.
	/// </summary>
	public class LeadGenWebhooks : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public LeadGenWebhooks(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenWebhooks";
		}

		public LeadGenWebhooks(LeadGenWebhooks source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Date created on the social network.
		/// </summary>
		public DateTime SocialCreatedOn {
			get {
				return GetTypedColumnValue<DateTime>("SocialCreatedOn");
			}
			set {
				SetColumnValue("SocialCreatedOn", value);
			}
		}

		/// <summary>
		/// Webhook status update date.
		/// </summary>
		public DateTime WebhookStatusUpdateDate {
			get {
				return GetTypedColumnValue<DateTime>("WebhookStatusUpdateDate");
			}
			set {
				SetColumnValue("WebhookStatusUpdateDate", value);
			}
		}

		/// <summary>
		/// Metadata.
		/// </summary>
		public string FormMetadata {
			get {
				return GetTypedColumnValue<string>("FormMetadata");
			}
			set {
				SetColumnValue("FormMetadata", value);
			}
		}

		/// <summary>
		/// Social lead id.
		/// </summary>
		public string SocialLeadId {
			get {
				return GetTypedColumnValue<string>("SocialLeadId");
			}
			set {
				SetColumnValue("SocialLeadId", value);
			}
		}

		/// <exclude/>
		public Guid LeadGenWebhookStatusId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenWebhookStatusId");
			}
			set {
				SetColumnValue("LeadGenWebhookStatusId", value);
				_leadGenWebhookStatus = null;
			}
		}

		/// <exclude/>
		public string LeadGenWebhookStatusName {
			get {
				return GetTypedColumnValue<string>("LeadGenWebhookStatusName");
			}
			set {
				SetColumnValue("LeadGenWebhookStatusName", value);
				if (_leadGenWebhookStatus != null) {
					_leadGenWebhookStatus.Name = value;
				}
			}
		}

		private LeadGenWebhookStatus _leadGenWebhookStatus;
		/// <summary>
		/// Webhook status.
		/// </summary>
		public LeadGenWebhookStatus LeadGenWebhookStatus {
			get {
				return _leadGenWebhookStatus ??
					(_leadGenWebhookStatus = LookupColumnEntities.GetEntity("LeadGenWebhookStatus") as LeadGenWebhookStatus);
			}
		}

		/// <exclude/>
		public Guid LeadGenNetworkTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadGenNetworkTypeId");
			}
			set {
				SetColumnValue("LeadGenNetworkTypeId", value);
				_leadGenNetworkType = null;
			}
		}

		/// <exclude/>
		public string LeadGenNetworkTypeName {
			get {
				return GetTypedColumnValue<string>("LeadGenNetworkTypeName");
			}
			set {
				SetColumnValue("LeadGenNetworkTypeName", value);
				if (_leadGenNetworkType != null) {
					_leadGenNetworkType.Name = value;
				}
			}
		}

		private LeadGenNetworkType _leadGenNetworkType;
		/// <summary>
		/// Social network type.
		/// </summary>
		public LeadGenNetworkType LeadGenNetworkType {
			get {
				return _leadGenNetworkType ??
					(_leadGenNetworkType = LookupColumnEntities.GetEntity("LeadGenNetworkType") as LeadGenNetworkType);
			}
		}

		/// <summary>
		/// Integration id.
		/// </summary>
		public Guid IntegrationId {
			get {
				return GetTypedColumnValue<Guid>("IntegrationId");
			}
			set {
				SetColumnValue("IntegrationId", value);
			}
		}

		/// <summary>
		/// Form id.
		/// </summary>
		public string FormId {
			get {
				return GetTypedColumnValue<string>("FormId");
			}
			set {
				SetColumnValue("FormId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadGenWebhooks_SocialLeadGenEventsProcess(UserConnection);
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
			return new LeadGenWebhooks(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenWebhooks_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenWebhooks_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : LeadGenWebhooks
	{

		public LeadGenWebhooks_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenWebhooks_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("2c694123-ed64-4632-941f-fa80612ee1d5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("2c694123-ed64-4632-941f-fa80612ee1d5");
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

	#region Class: LeadGenWebhooks_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenWebhooks_SocialLeadGenEventsProcess : LeadGenWebhooks_SocialLeadGenEventsProcess<LeadGenWebhooks>
	{

		public LeadGenWebhooks_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenWebhooks_SocialLeadGenEventsProcess

	public partial class LeadGenWebhooks_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenWebhooksEventsProcess

	/// <exclude/>
	public class LeadGenWebhooksEventsProcess : LeadGenWebhooks_SocialLeadGenEventsProcess
	{

		public LeadGenWebhooksEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

