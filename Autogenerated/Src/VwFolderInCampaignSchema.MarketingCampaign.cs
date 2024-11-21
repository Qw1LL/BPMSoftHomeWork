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

	#region Class: VwFolderInCampaignSchema

	/// <exclude/>
	public class VwFolderInCampaignSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwFolderInCampaignSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwFolderInCampaignSchema(VwFolderInCampaignSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwFolderInCampaignSchema(VwFolderInCampaignSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7");
			RealUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7");
			Name = "VwFolderInCampaign";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("52b7a37d-28ac-407b-85ab-bfb77d29c02b")) == null) {
				Columns.Add(CreateContactFolderColumn());
			}
			if (Columns.FindByUId(new Guid("694bde74-6250-41d3-b341-e70c2b5c018e")) == null) {
				Columns.Add(CreateFolderTypeColumn());
			}
			if (Columns.FindByUId(new Guid("7ac97c59-9455-4275-822a-6c3bf73a1405")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("1c25d01b-9616-414b-8401-09ccab9b315e")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContactFolderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("52b7a37d-28ac-407b-85ab-bfb77d29c02b"),
				Name = @"ContactFolder",
				ReferenceSchemaUId = new Guid("8b5c01a2-59e9-40dc-855b-6e3bebddc6ee"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				ModifiedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateFolderTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("694bde74-6250-41d3-b341-e70c2b5c018e"),
				Name = @"FolderType",
				ReferenceSchemaUId = new Guid("6fce7412-b527-4e0d-94f1-4b4c02d8e69f"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				ModifiedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7ac97c59-9455-4275-822a-6c3bf73a1405"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				ModifiedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1c25d01b-9616-414b-8401-09ccab9b315e"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
				ModifiedInSchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"),
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
			return new VwFolderInCampaign(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwFolderInCampaign_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwFolderInCampaignSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwFolderInCampaignSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7"));
		}

		#endregion

	}

	#endregion

	#region Class: VwFolderInCampaign

	/// <summary>
	/// ContactFolder in campaign view.
	/// </summary>
	public class VwFolderInCampaign : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwFolderInCampaign(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwFolderInCampaign";
		}

		public VwFolderInCampaign(VwFolderInCampaign source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContactFolderId {
			get {
				return GetTypedColumnValue<Guid>("ContactFolderId");
			}
			set {
				SetColumnValue("ContactFolderId", value);
				_contactFolder = null;
			}
		}

		/// <exclude/>
		public string ContactFolderName {
			get {
				return GetTypedColumnValue<string>("ContactFolderName");
			}
			set {
				SetColumnValue("ContactFolderName", value);
				if (_contactFolder != null) {
					_contactFolder.Name = value;
				}
			}
		}

		private ContactFolder _contactFolder;
		/// <summary>
		/// Группа.
		/// </summary>
		public ContactFolder ContactFolder {
			get {
				return _contactFolder ??
					(_contactFolder = LookupColumnEntities.GetEntity("ContactFolder") as ContactFolder);
			}
		}

		/// <exclude/>
		public Guid FolderTypeId {
			get {
				return GetTypedColumnValue<Guid>("FolderTypeId");
			}
			set {
				SetColumnValue("FolderTypeId", value);
				_folderType = null;
			}
		}

		/// <exclude/>
		public string FolderTypeName {
			get {
				return GetTypedColumnValue<string>("FolderTypeName");
			}
			set {
				SetColumnValue("FolderTypeName", value);
				if (_folderType != null) {
					_folderType.Name = value;
				}
			}
		}

		private FolderType _folderType;
		/// <summary>
		/// Тип группы.
		/// </summary>
		public FolderType FolderType {
			get {
				return _folderType ??
					(_folderType = LookupColumnEntities.GetEntity("FolderType") as FolderType);
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
			var process = new VwFolderInCampaign_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwFolderInCampaignDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwFolderInCampaign(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwFolderInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwFolderInCampaign_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwFolderInCampaign
	{

		public VwFolderInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwFolderInCampaign_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("cf1bb7b1-f81b-477a-a068-03dc393a06c7");
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

	#region Class: VwFolderInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwFolderInCampaign_MarketingCampaignEventsProcess : VwFolderInCampaign_MarketingCampaignEventsProcess<VwFolderInCampaign>
	{

		public VwFolderInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwFolderInCampaign_MarketingCampaignEventsProcess

	public partial class VwFolderInCampaign_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwFolderInCampaignEventsProcess

	/// <exclude/>
	public class VwFolderInCampaignEventsProcess : VwFolderInCampaign_MarketingCampaignEventsProcess
	{

		public VwFolderInCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

