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

	#region Class: VwBulkEmailInCampaignSchema

	/// <exclude/>
	public class VwBulkEmailInCampaignSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwBulkEmailInCampaignSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwBulkEmailInCampaignSchema(VwBulkEmailInCampaignSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwBulkEmailInCampaignSchema(VwBulkEmailInCampaignSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3e6a4565-ce33-490c-b442-4986af115928");
			RealUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928");
			Name = "VwBulkEmailInCampaign";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("03319e71-31db-4b4f-87a4-a1719ebfcf20")) == null) {
				Columns.Add(CreateBulkEmailColumn());
			}
			if (Columns.FindByUId(new Guid("4caa969d-2227-4e5d-99d0-ae1211713a50")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("74e3c5ac-27a3-49d5-9aa0-56000d1bde8a")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateBulkEmailColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("03319e71-31db-4b4f-87a4-a1719ebfcf20"),
				Name = @"BulkEmail",
				ReferenceSchemaUId = new Guid("95fbcf9c-e36d-4acd-8b5a-d657de6e30a8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
				ModifiedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("4caa969d-2227-4e5d-99d0-ae1211713a50"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
				ModifiedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
				CreatedInPackageId = new Guid("c92d8fca-4a0d-4385-86d2-4f5717aa816e")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("74e3c5ac-27a3-49d5-9aa0-56000d1bde8a"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
				ModifiedInSchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928"),
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
			return new VwBulkEmailInCampaign(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwBulkEmailInCampaign_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwBulkEmailInCampaignSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwBulkEmailInCampaignSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3e6a4565-ce33-490c-b442-4986af115928"));
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailInCampaign

	/// <summary>
	/// BulkEmail in campaign view.
	/// </summary>
	public class VwBulkEmailInCampaign : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwBulkEmailInCampaign(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwBulkEmailInCampaign";
		}

		public VwBulkEmailInCampaign(VwBulkEmailInCampaign source)
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
		public Guid CampaignItemId {
			get {
				return GetTypedColumnValue<Guid>("CampaignItemId");
			}
			set {
				SetColumnValue("CampaignItemId", value);
				_campaignItem = null;
			}
		}

		/// <exclude/>
		public string CampaignItemName {
			get {
				return GetTypedColumnValue<string>("CampaignItemName");
			}
			set {
				SetColumnValue("CampaignItemName", value);
				if (_campaignItem != null) {
					_campaignItem.Name = value;
				}
			}
		}

		private CampaignItem _campaignItem;
		/// <summary>
		/// Шаг кампании.
		/// </summary>
		public CampaignItem CampaignItem {
			get {
				return _campaignItem ??
					(_campaignItem = LookupColumnEntities.GetEntity("CampaignItem") as CampaignItem);
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
			var process = new VwBulkEmailInCampaign_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwBulkEmailInCampaignDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwBulkEmailInCampaign(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwBulkEmailInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwBulkEmailInCampaign_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwBulkEmailInCampaign
	{

		public VwBulkEmailInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwBulkEmailInCampaign_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("3e6a4565-ce33-490c-b442-4986af115928");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("3e6a4565-ce33-490c-b442-4986af115928");
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

	#region Class: VwBulkEmailInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwBulkEmailInCampaign_MarketingCampaignEventsProcess : VwBulkEmailInCampaign_MarketingCampaignEventsProcess<VwBulkEmailInCampaign>
	{

		public VwBulkEmailInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwBulkEmailInCampaign_MarketingCampaignEventsProcess

	public partial class VwBulkEmailInCampaign_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwBulkEmailInCampaignEventsProcess

	/// <exclude/>
	public class VwBulkEmailInCampaignEventsProcess : VwBulkEmailInCampaign_MarketingCampaignEventsProcess
	{

		public VwBulkEmailInCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

