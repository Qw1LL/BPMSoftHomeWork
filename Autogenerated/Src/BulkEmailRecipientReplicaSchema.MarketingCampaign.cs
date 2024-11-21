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

	#region Class: BulkEmailRecipientReplicaSchema

	/// <exclude/>
	public class BulkEmailRecipientReplicaSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BulkEmailRecipientReplicaSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BulkEmailRecipientReplicaSchema(BulkEmailRecipientReplicaSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BulkEmailRecipientReplicaSchema(BulkEmailRecipientReplicaSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3");
			RealUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3");
			Name = "BulkEmailRecipientReplica";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("80e92fb6-37f7-4532-84a6-8ffe3d445cc5")) == null) {
				Columns.Add(CreateDCReplicaColumn());
			}
			if (Columns.FindByUId(new Guid("cb7ca679-90ed-45a4-9573-e4fe99c3d169")) == null) {
				Columns.Add(CreateRecipientIdColumn());
			}
			if (Columns.FindByUId(new Guid("ee4dc8fc-f3fa-4f43-b46d-58bf87f5a6a7")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateDCReplicaColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("80e92fb6-37f7-4532-84a6-8ffe3d445cc5"),
				Name = @"DCReplica",
				ReferenceSchemaUId = new Guid("dcb6b7a6-c21f-45d1-a442-dda902ef64c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
				ModifiedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateRecipientIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Guid")) {
				UId = new Guid("cb7ca679-90ed-45a4-9573-e4fe99c3d169"),
				Name = @"RecipientId",
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
				ModifiedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ee4dc8fc-f3fa-4f43-b46d-58bf87f5a6a7"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
				ModifiedInSchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"),
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
			return new BulkEmailRecipientReplica(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BulkEmailRecipientReplica_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BulkEmailRecipientReplicaSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BulkEmailRecipientReplicaSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3"));
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailRecipientReplica

	/// <summary>
	/// Вариант шаблона для получателя рассылки.
	/// </summary>
	public class BulkEmailRecipientReplica : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BulkEmailRecipientReplica(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BulkEmailRecipientReplica";
		}

		public BulkEmailRecipientReplica(BulkEmailRecipientReplica source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

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
		/// Реплика шаблона рассылки.
		/// </summary>
		public DCReplica DCReplica {
			get {
				return _dCReplica ??
					(_dCReplica = LookupColumnEntities.GetEntity("DCReplica") as DCReplica);
			}
		}

		/// <summary>
		/// Уникальный идентификатор получателя.
		/// </summary>
		public Guid RecipientId {
			get {
				return GetTypedColumnValue<Guid>("RecipientId");
			}
			set {
				SetColumnValue("RecipientId", value);
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
		/// Уникальный идентификатор рассылки.
		/// </summary>
		public BulkEmail BulkEmail {
			get {
				return _bulkEmail ??
					(_bulkEmail = LookupColumnEntities.GetEntity("BulkEmail") as BulkEmail);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BulkEmailRecipientReplica_MarketingCampaignEventsProcess(UserConnection);
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
			return new BulkEmailRecipientReplica(this);
		}

		#endregion

	}

	#endregion

	#region Class: BulkEmailRecipientReplica_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class BulkEmailRecipientReplica_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BulkEmailRecipientReplica
	{

		public BulkEmailRecipientReplica_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BulkEmailRecipientReplica_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("71dbd47d-eda7-4f91-bd02-ab75732cd2f3");
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

	#region Class: BulkEmailRecipientReplica_MarketingCampaignEventsProcess

	/// <exclude/>
	public class BulkEmailRecipientReplica_MarketingCampaignEventsProcess : BulkEmailRecipientReplica_MarketingCampaignEventsProcess<BulkEmailRecipientReplica>
	{

		public BulkEmailRecipientReplica_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BulkEmailRecipientReplica_MarketingCampaignEventsProcess

	public partial class BulkEmailRecipientReplica_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: BulkEmailRecipientReplicaEventsProcess

	/// <exclude/>
	public class BulkEmailRecipientReplicaEventsProcess : BulkEmailRecipientReplica_MarketingCampaignEventsProcess
	{

		public BulkEmailRecipientReplicaEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

