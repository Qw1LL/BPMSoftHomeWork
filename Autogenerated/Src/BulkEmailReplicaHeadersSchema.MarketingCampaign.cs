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

	#region Class: BulkEmailReplicaHeadersSchema

	/// <exclude/>
	public class BulkEmailReplicaHeadersSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailReplicaHeadersSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailReplicaHeadersSchema(BulkEmailReplicaHeadersSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailReplicaHeadersSchema(BulkEmailReplicaHeadersSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0");
			RealUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0");
			Name = "BulkEmailReplicaHeaders";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("4c46774e-0dac-4834-821a-dc4f7d744e5a")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("5fe02878-a6be-4460-8e3e-7ae2020b06e9")) == null) {
				Columns.Add(CreateDCReplicaColumn());
			}
			if (Columns.FindByUId(new Guid("2011af4c-928e-4578-8a98-fa3a8ec0599a")) == null) {
				Columns.Add(CreateSubjectColumn());
			}
			if (Columns.FindByUId(new Guid("f4c8f534-56c5-4267-aca9-c688e42080ee")) == null) {
				Columns.Add(CreatePreheaderColumn());
			}
			if (Columns.FindByUId(new Guid("d632964d-2f46-48c3-9f64-e3fecf112e0d")) == null) {
				Columns.Add(CreateSenderEmailColumn());
			}
			if (Columns.FindByUId(new Guid("f6755166-5eef-4b9d-9895-f9ddd61b7b71")) == null) {
				Columns.Add(CreateSenderNameColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4c46774e-0dac-4834-821a-dc4f7d744e5a"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateDCReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5fe02878-a6be-4460-8e3e-7ae2020b06e9"),
				Name = @"DCReplica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateSubjectColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("2011af4c-928e-4578-8a98-fa3a8ec0599a"),
				Name = @"Subject",
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreatePreheaderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f4c8f534-56c5-4267-aca9-c688e42080ee"),
				Name = @"Preheader",
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("d632964d-2f46-48c3-9f64-e3fecf112e0d"),
				Name = @"SenderEmail",
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateSenderNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("f6755166-5eef-4b9d-9895-f9ddd61b7b71"),
				Name = @"SenderName",
				CreatedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
				ModifiedInSchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"),
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
			return new BulkEmailReplicaHeaders(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailReplicaHeaders_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailReplicaHeadersSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailReplicaHeadersSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailReplicaHeaders

	/// <summary>
	/// Заголовки реплик рассылки.
	/// </summary>
	public class BulkEmailReplicaHeaders : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailReplicaHeaders(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailReplicaHeaders";
		}

		public BulkEmailReplicaHeaders(BulkEmailReplicaHeaders source)
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
		/// BulkEmail.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		/// <exclude/>
		public Guid DCReplicaId {
			get {
				return GetTypedColumnValue<Guid>("DCReplicaId");
			}
			set {
				SetColumnValue("DCReplicaId", value);
				_dCReplica = null;
			}
		}

		/// <exclude/>
		public string DCReplicaCaption {
			get {
				return GetTypedColumnValue<string>("DCReplicaCaption");
			}
			set {
				SetColumnValue("DCReplicaCaption", value);
				if (_dCReplica != null) {
					_dCReplica.Caption = value;
				}
			}
		}

		private DCReplica _dCReplica;
		/// <summary>
		/// Реплика.
		/// </summary>
		public DCReplica DCReplica {
			get {
				return _dCReplica ??
					(_dCReplica = LookupColumnEntities.GetEntity("DCReplica") as DCReplica);
			}
		}

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Subject {
			get {
				return GetTypedColumnValue<string>("Subject");
			}
			set {
				SetColumnValue("Subject", value);
			}
		}

		/// <summary>
		/// Pre-header.
		/// </summary>
		public string Preheader {
			get {
				return GetTypedColumnValue<string>("Preheader");
			}
			set {
				SetColumnValue("Preheader", value);
			}
		}

		/// <summary>
		/// Email отправителя.
		/// </summary>
		public string SenderEmail {
			get {
				return GetTypedColumnValue<string>("SenderEmail");
			}
			set {
				SetColumnValue("SenderEmail", value);
			}
		}

		/// <summary>
		/// Имя отправителя.
		/// </summary>
		public string SenderName {
			get {
				return GetTypedColumnValue<string>("SenderName");
			}
			set {
				SetColumnValue("SenderName", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailReplicaHeaders_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailReplicaHeaders(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailReplicaHeaders_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailReplicaHeaders_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailReplicaHeaders
	{

		public BulkEmailReplicaHeaders_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailReplicaHeaders_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("80729758-eeb1-4869-9e51-0a50ce8a1db0");
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

	#region Class: BulkEmailReplicaHeaders_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailReplicaHeaders_MarketingCampaignEventsProcess : BulkEmailReplicaHeaders_MarketingCampaignEventsProcess<BulkEmailReplicaHeaders>
	{

		public BulkEmailReplicaHeaders_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailReplicaHeaders_MarketingCampaignEventsProcess

	public partial class BulkEmailReplicaHeaders_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailReplicaHeadersEventsProcess

	/// <exclude/>
	public class BulkEmailReplicaHeadersEventsProcess : BulkEmailReplicaHeaders_MarketingCampaignEventsProcess
	{

		public BulkEmailReplicaHeadersEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

