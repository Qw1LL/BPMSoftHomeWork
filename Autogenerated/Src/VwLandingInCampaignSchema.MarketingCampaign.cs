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

	#region Class: VwLandingInCampaignSchema

	/// <exclude/>
	public class VwLandingInCampaignSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public VwLandingInCampaignSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwLandingInCampaignSchema(VwLandingInCampaignSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwLandingInCampaignSchema(VwLandingInCampaignSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640");
			RealUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640");
			Name = "VwLandingInCampaign";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("7b5cce97-2e1e-4b17-90ca-f9813022e3eb");
			IsDBView = true;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2f090548-af74-426d-8359-8804e1210aa5")) == null) {
				Columns.Add(CreateLandingColumn());
			}
			if (Columns.FindByUId(new Guid("b6f3f404-6e16-4080-abd2-a6c9c1ee3fd0")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("5f7631fb-d62d-4bf9-9bfa-64f0995846df")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("0dc2e1c3-cdfd-49fc-b2b1-8030416878e1")) == null) {
				Columns.Add(CreateCampaignItemColumn());
			}
			if (Columns.FindByUId(new Guid("c304f4a6-06e9-4240-b70b-d7ad67513a5d")) == null) {
				Columns.Add(CreateCampaignColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLandingColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2f090548-af74-426d-8359-8804e1210aa5"),
				Name = @"Landing",
				ReferenceSchemaUId = new Guid("41ae7d8d-bec3-41df-a6f0-2ab0d08b3967"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				ModifiedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b6f3f404-6e16-4080-abd2-a6c9c1ee3fd0"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("967d4133-7d63-492f-a8f3-e406d06c6bbd"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				ModifiedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("5f7631fb-d62d-4bf9-9bfa-64f0995846df"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("e14fd334-ae5c-4fa5-970c-56c2f8ef33c2"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				ModifiedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignItemColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0dc2e1c3-cdfd-49fc-b2b1-8030416878e1"),
				Name = @"CampaignItem",
				ReferenceSchemaUId = new Guid("28045fad-1d04-4bb5-8600-ed4ca87b5650"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				ModifiedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				CreatedInPackageId = new Guid("9892593b-d041-45d0-95a7-d3a6e875d1a5")
			};
		}

		protected virtual EntitySchemaColumn CreateCampaignColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c304f4a6-06e9-4240-b70b-d7ad67513a5d"),
				Name = @"Campaign",
				ReferenceSchemaUId = new Guid("1f9bb71a-eb9c-4220-a40e-9b623eacfec8"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
				ModifiedInSchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"),
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
			return new VwLandingInCampaign(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwLandingInCampaign_MarketingCampaignEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwLandingInCampaignSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwLandingInCampaignSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640"));
		}

		#endregion

	}

	#endregion

	#region Class: VwLandingInCampaign

	/// <summary>
	/// Landing in campaign view.
	/// </summary>
	public class VwLandingInCampaign : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public VwLandingInCampaign(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwLandingInCampaign";
		}

		public VwLandingInCampaign(VwLandingInCampaign source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LandingId {
			get {
				return GetTypedColumnValue<Guid>("LandingId");
			}
			set {
				SetColumnValue("LandingId", value);
				_landing = null;
			}
		}

		/// <exclude/>
		public string LandingName {
			get {
				return GetTypedColumnValue<string>("LandingName");
			}
			set {
				SetColumnValue("LandingName", value);
				if (_landing != null) {
					_landing.Name = value;
				}
			}
		}

		private GeneratedWebForm _landing;
		/// <summary>
		/// Лендинг.
		/// </summary>
		public GeneratedWebForm Landing {
			get {
				return _landing ??
					(_landing = LookupColumnEntities.GetEntity("Landing") as GeneratedWebForm);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private LendingState _state;
		/// <summary>
		/// Состояние лендинга.
		/// </summary>
		public LendingState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as LendingState);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private LandingType _type;
		/// <summary>
		/// Тип лендинга.
		/// </summary>
		public LandingType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as LandingType);
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
			var process = new VwLandingInCampaign_MarketingCampaignEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("VwLandingInCampaignDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwLandingInCampaign(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwLandingInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public partial class VwLandingInCampaign_MarketingCampaignEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : VwLandingInCampaign
	{

		public VwLandingInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwLandingInCampaign_MarketingCampaignEventsProcess";
			SchemaUId = new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("1e93621c-46a0-4124-aa0f-4d2ed05f5640");
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

	#region Class: VwLandingInCampaign_MarketingCampaignEventsProcess

	/// <exclude/>
	public class VwLandingInCampaign_MarketingCampaignEventsProcess : VwLandingInCampaign_MarketingCampaignEventsProcess<VwLandingInCampaign>
	{

		public VwLandingInCampaign_MarketingCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwLandingInCampaign_MarketingCampaignEventsProcess

	public partial class VwLandingInCampaign_MarketingCampaignEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwLandingInCampaignEventsProcess

	/// <exclude/>
	public class VwLandingInCampaignEventsProcess : VwLandingInCampaign_MarketingCampaignEventsProcess
	{

		public VwLandingInCampaignEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

