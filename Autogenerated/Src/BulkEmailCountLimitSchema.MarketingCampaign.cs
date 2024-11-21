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

	#region Class: BulkEmailCountLimitSchema

	/// <exclude/>
	public class BulkEmailCountLimitSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailCountLimitSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailCountLimitSchema(BulkEmailCountLimitSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailCountLimitSchema(BulkEmailCountLimitSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			RealUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			Name = "BulkEmailCountLimit";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateTitleColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("165781e6-c772-469c-8dad-a597d5e734c9")) == null) {
				Columns.Add(CreateMailingLimitCountColumn());
			}
			if (Columns.FindByUId(new Guid("df3ef0f1-42e5-42cb-8002-7d00ac9d8e8c")) == null) {
				Columns.Add(CreateMailingLimitPeriodColumn());
			}
			if (Columns.FindByUId(new Guid("9c375abd-a5cd-494e-a611-a6088f8382f0")) == null) {
				Columns.Add(CreateOverlimitResponseColumn());
			}
			if (Columns.FindByUId(new Guid("f6372c2a-c23b-4fa4-a7b5-5abe231d7a2d")) == null) {
				Columns.Add(CreateEmailCategoryColumn());
			}
			if (Columns.FindByUId(new Guid("164d10a5-9311-4605-a32e-033555ebc741")) == null) {
				Columns.Add(CreateEmailTypeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			column.CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8");
			return column;
		}

		protected virtual EntitySchemaColumn CreateMailingLimitCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("165781e6-c772-469c-8dad-a597d5e734c9"),
				Name = @"MailingLimitCount",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8")
			};
		}

		protected virtual EntitySchemaColumn CreateMailingLimitPeriodColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("df3ef0f1-42e5-42cb-8002-7d00ac9d8e8c"),
				Name = @"MailingLimitPeriod",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8")
			};
		}

		protected virtual EntitySchemaColumn CreateOverlimitResponseColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("9c375abd-a5cd-494e-a611-a6088f8382f0"),
				Name = @"OverlimitResponse",
				ReferenceSchemaUId = new Guid("2ff5127a-ca8a-4515-aeb0-d2ded9168aed"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.Advanced,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"31aaed28-5789-43ff-9801-9ff6b5956b9b"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateTitleColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("276dfd4d-44fd-4ba3-b8ec-2445871ce373"),
				Name = @"Title",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("1b2ed76b-60ba-43f6-add0-9227ee7a78e8"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateEmailCategoryColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("f6372c2a-c23b-4fa4-a7b5-5abe231d7a2d"),
				Name = @"EmailCategory",
				ReferenceSchemaUId = new Guid("13cffa88-d296-4202-8bee-d023d51a8454"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true
			};
		}

		protected virtual EntitySchemaColumn CreateEmailTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("164d10a5-9311-4605-a32e-033555ebc741"),
				Name = @"EmailType",
				ReferenceSchemaUId = new Guid("708702c2-7d97-4702-879a-39aa5f6eef8f"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				ModifiedInSchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5"),
				IsSimpleLookup = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailCountLimit(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailCountLimit_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailCountLimitSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailCountLimitSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailCountLimit

	/// <summary>
	/// Ограничение отправки рассылок.
	/// </summary>
	public class BulkEmailCountLimit : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailCountLimit(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailCountLimit";
		}

		public BulkEmailCountLimit(BulkEmailCountLimit source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Максимальное количество отправок.
		/// </summary>
		public int MailingLimitCount {
			get {
				return GetTypedColumnValue<int>("MailingLimitCount");
			}
			set {
				SetColumnValue("MailingLimitCount", value);
			}
		}

		/// <summary>
		/// Период, дней.
		/// </summary>
		public int MailingLimitPeriod {
			get {
				return GetTypedColumnValue<int>("MailingLimitPeriod");
			}
			set {
				SetColumnValue("MailingLimitPeriod", value);
			}
		}

		/// <exclude/>
		public Guid OverlimitResponseId {
			get {
				return GetTypedColumnValue<Guid>("OverlimitResponseId");
			}
			set {
				SetColumnValue("OverlimitResponseId", value);
				_overlimitResponse = null;
			}
		}

		/// <exclude/>
		public string OverlimitResponseName {
			get {
				return GetTypedColumnValue<string>("OverlimitResponseName");
			}
			set {
				SetColumnValue("OverlimitResponseName", value);
				if (_overlimitResponse != null) {
					_overlimitResponse.Name = value;
				}
			}
		}

		private BulkEmailResponse _overlimitResponse;
		/// <summary>
		/// Отклик.
		/// </summary>
		public BulkEmailResponse OverlimitResponse {
			get {
				return _overlimitResponse ??
					(_overlimitResponse = LookupColumnEntities.GetEntity("OverlimitResponse") as BulkEmailResponse);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Title {
			get {
				return GetTypedColumnValue<string>("Title");
			}
			set {
				SetColumnValue("Title", value);
			}
		}

		/// <exclude/>
		public Guid EmailCategoryId {
			get {
				return GetTypedColumnValue<Guid>("EmailCategoryId");
			}
			set {
				SetColumnValue("EmailCategoryId", value);
				_emailCategory = null;
			}
		}

		/// <exclude/>
		public string EmailCategoryName {
			get {
				return GetTypedColumnValue<string>("EmailCategoryName");
			}
			set {
				SetColumnValue("EmailCategoryName", value);
				if (_emailCategory != null) {
					_emailCategory.Name = value;
				}
			}
		}

		private BulkEmailCategory _emailCategory;
		/// <summary>
		/// Категория рассылки.
		/// </summary>
		public BulkEmailCategory EmailCategory {
			get {
				return _emailCategory ??
					(_emailCategory = LookupColumnEntities.GetEntity("EmailCategory") as BulkEmailCategory);
			}
		}

		/// <exclude/>
		public Guid EmailTypeId {
			get {
				return GetTypedColumnValue<Guid>("EmailTypeId");
			}
			set {
				SetColumnValue("EmailTypeId", value);
				_emailType = null;
			}
		}

		/// <exclude/>
		public string EmailTypeName {
			get {
				return GetTypedColumnValue<string>("EmailTypeName");
			}
			set {
				SetColumnValue("EmailTypeName", value);
				if (_emailType != null) {
					_emailType.Name = value;
				}
			}
		}

		private BulkEmailType _emailType;
		/// <summary>
		/// Тип рассылки.
		/// </summary>
		public BulkEmailType EmailType {
			get {
				return _emailType ??
					(_emailType = LookupColumnEntities.GetEntity("EmailType") as BulkEmailType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailCountLimit_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailCountLimitDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailCountLimitInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailCountLimitValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailCountLimit(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailCountLimit_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailCountLimit_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailCountLimit
	{

		public BulkEmailCountLimit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailCountLimit_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("635902af-649c-4b18-a2d3-d6abdf0a5b29");
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

	#region Class: BulkEmailCountLimit_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailCountLimit_MarketingCampaignEventsProcess : BulkEmailCountLimit_MarketingCampaignEventsProcess<BulkEmailCountLimit>
	{

		public BulkEmailCountLimit_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailCountLimit_MarketingCampaignEventsProcess

	public partial class BulkEmailCountLimit_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailCountLimitEventsProcess

	/// <exclude/>
	public class BulkEmailCountLimitEventsProcess : BulkEmailCountLimit_MarketingCampaignEventsProcess
	{

		public BulkEmailCountLimitEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

