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

	#region Class: LeadGenAdSetsSchema

	/// <exclude/>
	public class LeadGenAdSetsSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public LeadGenAdSetsSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public LeadGenAdSetsSchema(LeadGenAdSetsSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public LeadGenAdSetsSchema(LeadGenAdSetsSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0");
			RealUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0");
			Name = "LeadGenAdSets";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("53776dcf-a79e-7531-9c77-8f3069a12f47")) == null) {
				Columns.Add(CreateSocialAdSetIdColumn());
			}
			if (Columns.FindByUId(new Guid("b8561a5e-d56e-8551-f0b8-f6782df50fe0")) == null) {
				Columns.Add(CreateLeadGenNetworkTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSocialAdSetIdColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("53776dcf-a79e-7531-9c77-8f3069a12f47"),
				Name = @"SocialAdSetId",
				CreatedInSchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"),
				ModifiedInSchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"),
				CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31")
			};
		}

		protected virtual EntitySchemaColumn CreateLeadGenNetworkTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b8561a5e-d56e-8551-f0b8-f6782df50fe0"),
				Name = @"LeadGenNetworkType",
				ReferenceSchemaUId = new Guid("2f219369-8c87-4a6f-bf14-b048b134ea66"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"),
				ModifiedInSchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"),
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
			return new LeadGenAdSets(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new LeadGenAdSets_SocialLeadGenEventsProcess(userConnection);
		}

		public override object Clone() {
			return new LeadGenAdSetsSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new LeadGenAdSetsSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0"));
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenAdSets

	/// <summary>
	/// Рекламные группы объявлений.
	/// </summary>
	public class LeadGenAdSets : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public LeadGenAdSets(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "LeadGenAdSets";
		}

		public LeadGenAdSets(LeadGenAdSets source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Social ad set id.
		/// </summary>
		public string SocialAdSetId {
			get {
				return GetTypedColumnValue<string>("SocialAdSetId");
			}
			set {
				SetColumnValue("SocialAdSetId", value);
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
			var process = new LeadGenAdSets_SocialLeadGenEventsProcess(UserConnection);
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
			return new LeadGenAdSets(this);
		}

		#endregion

	}

	#endregion

	#region Class: LeadGenAdSets_SocialLeadGenEventsProcess

	/// <exclude/>
	public partial class LeadGenAdSets_SocialLeadGenEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : LeadGenAdSets
	{

		public LeadGenAdSets_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "LeadGenAdSets_SocialLeadGenEventsProcess";
			SchemaUId = new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("564cdfad-498f-4afa-9035-87e3791ca5c0");
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

	#region Class: LeadGenAdSets_SocialLeadGenEventsProcess

	/// <exclude/>
	public class LeadGenAdSets_SocialLeadGenEventsProcess : LeadGenAdSets_SocialLeadGenEventsProcess<LeadGenAdSets>
	{

		public LeadGenAdSets_SocialLeadGenEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: LeadGenAdSets_SocialLeadGenEventsProcess

	public partial class LeadGenAdSets_SocialLeadGenEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: LeadGenAdSetsEventsProcess

	/// <exclude/>
	public class LeadGenAdSetsEventsProcess : LeadGenAdSets_SocialLeadGenEventsProcess
	{

		public LeadGenAdSetsEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

