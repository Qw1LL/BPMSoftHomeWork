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

	#region Class: LeadGenCampaignGroupsSchema

	/// <exclude/>
	public class LeadGenCampaignGroupsSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadGenCampaignGroupsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenCampaignGroupsSchema(LeadGenCampaignGroupsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenCampaignGroupsSchema(LeadGenCampaignGroupsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209");
			RealUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209");
			Name = "LeadGenCampaignGroups";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("71357db2-a134-27e5-2a33-0290e5c32392")) == null) {
				Columns.Add(CreateSocialCampaignGroupIdColumn());
			}
			if (Columns.FindByUId(new Guid("6cb3a6bf-a87d-7d82-7b5a-6e8c86f717b6")) == null) {
				Columns.Add(CreateLeadGenNetworkTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialCampaignGroupIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("71357db2-a134-27e5-2a33-0290e5c32392"),
				Name = @"SocialCampaignGroupId",
				CreatedInSchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"),
				ModifiedInSchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenNetworkTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6cb3a6bf-a87d-7d82-7b5a-6e8c86f717b6"),
				Name = @"LeadGenNetworkType",
				ReferenceSchemaUId = new Guid("2f219369-8c87-4a6f-bf14-b048b134ea66"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"),
				ModifiedInSchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new LeadGenCampaignGroups(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenCampaignGroups_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenCampaignGroupsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenCampaignGroupsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenCampaignGroups

	/// <summary>
	/// Группы рекламных кампаний.
	/// </summary>
	public class LeadGenCampaignGroups : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadGenCampaignGroups(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenCampaignGroups";
		}

		public LeadGenCampaignGroups(LeadGenCampaignGroups source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Social campaign group id.
		/// </summary>
		public string SocialCampaignGroupId {
			get {
				return GetTypedColumnValue<string>("SocialCampaignGroupId");
			}
			set {
				SetColumnValue("SocialCampaignGroupId", value);
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
		/// Network type.
		/// </summary>
		public LeadGenNetworkType LeadGenNetworkType {
			get {
				return _leadGenNetworkType ??
					(_leadGenNetworkType = LookupColumnEntities.GetEntity("LeadGenNetworkType") as LeadGenNetworkType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new LeadGenCampaignGroups_SocialLeadGenEventsProcess(UserConnection);
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
			return new LeadGenCampaignGroups(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenCampaignGroups_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenCampaignGroups_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadGenCampaignGroups
	{

		public LeadGenCampaignGroups_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenCampaignGroups_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e8f1a402-563a-4c40-888b-9ef2925f8209");
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

	#region Class: LeadGenCampaignGroups_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenCampaignGroups_SocialLeadGenEventsProcess : LeadGenCampaignGroups_SocialLeadGenEventsProcess<LeadGenCampaignGroups>
	{

		public LeadGenCampaignGroups_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenCampaignGroups_SocialLeadGenEventsProcess

	public partial class LeadGenCampaignGroups_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenCampaignGroupsEventsProcess

	/// <exclude/>
	public class LeadGenCampaignGroupsEventsProcess : LeadGenCampaignGroups_SocialLeadGenEventsProcess
	{

		public LeadGenCampaignGroupsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

