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

	#region Class: BulkEmailHyperlinkSchema

	/// <exclude/>
	public class BulkEmailHyperlinkSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailHyperlinkSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailHyperlinkSchema(BulkEmailHyperlinkSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailHyperlinkSchema(BulkEmailHyperlinkSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			RealUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			Name = "BulkEmailHyperlink";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateCaptionColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0a29118e-e3f4-4166-a404-5ce7c2e85cb7")) == null) {
				Columns.Add(CreateUrlColumn());
			}
			if (Columns.FindByUId(new Guid("0c85986f-d3d7-4e8c-ae13-5a2a84ef2dcb")) == null) {
				Columns.Add(CreateClicksCountColumn());
			}
			if (Columns.FindByUId(new Guid("7124d307-8670-46a1-959f-fed2083963f1")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("7760e14d-7b50-4ae1-a60e-d8d67c139396")) == null) {
				Columns.Add(CreateHashColumn());
			}
			if (Columns.FindByUId(new Guid("ebf5edbc-34f6-4b04-b26a-43755cddd146")) == null) {
				Columns.Add(CreateBpmReplicaMaskColumn());
			}
			if (Columns.FindByUId(new Guid("1e56974d-e214-4443-ac1c-a6a116dd651d")) == null) {
				Columns.Add(CreateBpmTrackIdColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			column.CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266");
			return column;
		}

		protected virtual EntitySchemaColumn CreateCaptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("c2e34957-f4f8-428d-85c4-d1a467ec7e7e"),
				Name = @"Caption",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateUrlColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("0a29118e-e3f4-4166-a404-5ce7c2e85cb7"),
				Name = @"Url",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateClicksCountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("0c85986f-d3d7-4e8c-ae13-5a2a84ef2dcb"),
				Name = @"ClicksCount",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7124d307-8670-46a1-959f-fed2083963f1"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateHashColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("7760e14d-7b50-4ae1-a60e-d8d67c139396"),
				Name = @"Hash",
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("48513af2-42ae-4933-a664-64fbd4224266")
			};
		}

		protected virtual EntitySchemaColumn CreateBpmReplicaMaskColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("ebf5edbc-34f6-4b04-b26a-43755cddd146"),
				Name = @"BpmReplicaMask",
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("633119c1-eb92-42a3-a09d-15ece666869f")
			};
		}

		protected virtual EntitySchemaColumn CreateBpmTrackIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("1e56974d-e214-4443-ac1c-a6a116dd651d"),
				Name = @"BpmTrackId",
				CreatedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				ModifiedInSchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BulkEmailHyperlink(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailHyperlink_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailHyperlinkSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailHyperlinkSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("09f52257-173f-4cd7-a86b-473372c67bd5"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHyperlink

	/// <summary>
	/// Ссылка в Email.
	/// </summary>
	public class BulkEmailHyperlink : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailHyperlink(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailHyperlink";
		}

		public BulkEmailHyperlink(BulkEmailHyperlink source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Caption {
			get {
				return GetTypedColumnValue<string>("Caption");
			}
			set {
				SetColumnValue("Caption", value);
			}
		}

		/// <summary>
		/// Адрес ссылки.
		/// </summary>
		public string Url {
			get {
				return GetTypedColumnValue<string>("Url");
			}
			set {
				SetColumnValue("Url", value);
			}
		}

		/// <summary>
		/// Количество переходов.
		/// </summary>
		public int ClicksCount {
			get {
				return GetTypedColumnValue<int>("ClicksCount");
			}
			set {
				SetColumnValue("ClicksCount", value);
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
		/// Рассылка Email.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <summary>
		/// Хеш.
		/// </summary>
		public Guid Hash {
			get {
				return GetTypedColumnValue<Guid>("Hash");
			}
			set {
				SetColumnValue("Hash", value);
			}
		}

		/// <summary>
		/// Идентификатор реплики шаблона.
		/// </summary>
		public int BpmReplicaMask {
			get {
				return GetTypedColumnValue<int>("BpmReplicaMask");
			}
			set {
				SetColumnValue("BpmReplicaMask", value);
			}
		}

		/// <summary>
		/// Идентификатор ссылки.
		/// </summary>
		public int BpmTrackId {
			get {
				return GetTypedColumnValue<int>("BpmTrackId");
			}
			set {
				SetColumnValue("BpmTrackId", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailHyperlink_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BulkEmailHyperlinkDeleted", e);
			Inserting += (s, e) => ThrowEvent("BulkEmailHyperlinkInserting", e);
			Validating += (s, e) => ThrowEvent("BulkEmailHyperlinkValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BulkEmailHyperlink(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailHyperlink_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailHyperlink_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailHyperlink
	{

		public BulkEmailHyperlink_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailHyperlink_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("09f52257-173f-4cd7-a86b-473372c67bd5");
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

	#region Class: BulkEmailHyperlink_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailHyperlink_MarketingCampaignEventsProcess : BulkEmailHyperlink_MarketingCampaignEventsProcess<BulkEmailHyperlink>
	{

		public BulkEmailHyperlink_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailHyperlink_MarketingCampaignEventsProcess

	public partial class BulkEmailHyperlink_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailHyperlinkEventsProcess

	/// <exclude/>
	public class BulkEmailHyperlinkEventsProcess : BulkEmailHyperlink_MarketingCampaignEventsProcess
	{

		public BulkEmailHyperlinkEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

