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

	#region Class: LeadGenAdsSchema

	/// <exclude/>
	public class LeadGenAdsSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadGenAdsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenAdsSchema(LeadGenAdsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenAdsSchema(LeadGenAdsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef");
			RealUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef");
			Name = "LeadGenAds";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("32ecf35e-e76b-556c-b9e5-712cf2fce3f0")) == null) {
				Columns.Add(CreateSocialAdIdColumn());
			}
			if (Columns.FindByUId(new Guid("fe2ab68b-d194-5cf1-a4ed-8448857356ee")) == null) {
				Columns.Add(CreateLeadGenNetworkTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialAdIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("32ecf35e-e76b-556c-b9e5-712cf2fce3f0"),
				Name = @"SocialAdId",
				CreatedInSchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"),
				ModifiedInSchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenNetworkTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("fe2ab68b-d194-5cf1-a4ed-8448857356ee"),
				Name = @"LeadGenNetworkType",
				ReferenceSchemaUId = new Guid("2f219369-8c87-4a6f-bf14-b048b134ea66"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"),
				ModifiedInSchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"),
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
			return new LeadGenAds(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenAds_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenAdsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenAdsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenAds

	/// <summary>
	/// Рекламные объявления.
	/// </summary>
	public class LeadGenAds : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadGenAds(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenAds";
		}

		public LeadGenAds(LeadGenAds source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Social ad id.
		/// </summary>
		public string SocialAdId {
			get {
				return GetTypedColumnValue<string>("SocialAdId");
			}
			set {
				SetColumnValue("SocialAdId", value);
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
			var process = new LeadGenAds_SocialLeadGenEventsProcess(UserConnection);
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
			return new LeadGenAds(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenAds_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenAds_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadGenAds
	{

		public LeadGenAds_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenAds_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("0ae787d0-c4bd-4372-8122-4ac3c3bfc5ef");
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

	#region Class: LeadGenAds_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenAds_SocialLeadGenEventsProcess : LeadGenAds_SocialLeadGenEventsProcess<LeadGenAds>
	{

		public LeadGenAds_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenAds_SocialLeadGenEventsProcess

	public partial class LeadGenAds_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenAdsEventsProcess

	/// <exclude/>
	public class LeadGenAdsEventsProcess : LeadGenAds_SocialLeadGenEventsProcess
	{

		public LeadGenAdsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

