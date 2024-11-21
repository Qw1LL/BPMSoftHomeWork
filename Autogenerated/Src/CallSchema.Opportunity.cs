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

	#region Class: Call_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class Call_Opportunity_BPMSoftSchema : BPMSoft.Configuration.Call_CaseService_BPMSoftSchema
	{

		#region Constructors: Public

		public Call_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Call_Opportunity_BPMSoftSchema(Call_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Call_Opportunity_BPMSoftSchema(Call_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateICallCreatedOnIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("8f49136d-4605-4a5e-94bf-dec8cd6b8c60");
			index.Name = "ICallCreatedOn";
			index.CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			index.CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849");
			EntitySchemaIndexColumn createdOnIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("fbd9727b-1533-41f4-b11a-e3e7a77a63e9"),
				ColumnUId = new Guid("e80190a5-03b2-4095-90f7-a193a960adee"),
				CreatedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				ModifiedInSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad"),
				CreatedInPackageId = new Guid("c7325125-3da0-4051-8d8f-fcafc2a62849"),
				OrderDirection = OrderDirectionStrict.Descending
			};
			index.Columns.Add(createdOnIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("74b541e8-7d87-4296-9d62-a65ac5907a92");
			Name = "Call_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("2f81fa05-11ae-400d-8e07-5ef6a620d1ad");
			ExtendParent = true;
			CreatedInPackageId = new Guid("bd93380a-2ac0-4fec-8435-f14f5908016f");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("0efce1e2-796f-483f-84fc-172aab6ad68a")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0efce1e2-796f-483f-84fc-172aab6ad68a"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("74b541e8-7d87-4296-9d62-a65ac5907a92"),
				ModifiedInSchemaUId = new Guid("74b541e8-7d87-4296-9d62-a65ac5907a92"),
				CreatedInPackageId = new Guid("bd93380a-2ac0-4fec-8435-f14f5908016f")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateICallCreatedOnIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Call_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Call_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Call_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Call_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("74b541e8-7d87-4296-9d62-a65ac5907a92"));
		}

		#endregion

	}

	#endregion

	#region Class: Call_Opportunity_BPMSoft

	/// <summary>
	/// Звонок.
	/// </summary>
	public class Call_Opportunity_BPMSoft : BPMSoft.Configuration.Call_CaseService_BPMSoft
	{

		#region Constructors: Public

		public Call_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Call_Opportunity_BPMSoft";
		}

		public Call_Opportunity_BPMSoft(Call_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Call_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Call_Opportunity_BPMSoftDeleted", e);
			Validating += (s, e) => ThrowEvent("Call_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Call_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Call_OpportunityEventsProcess

	/// <exclude/>
	public partial class Call_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.Call_CaseServiceEventsProcess<TEntity> where TEntity : Call_Opportunity_BPMSoft
	{

		public Call_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Call_OpportunityEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("74b541e8-7d87-4296-9d62-a65ac5907a92");
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

	#region Class: Call_OpportunityEventsProcess

	/// <exclude/>
	public class Call_OpportunityEventsProcess : Call_OpportunityEventsProcess<Call_Opportunity_BPMSoft>
	{

		public Call_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Call_OpportunityEventsProcess

	public partial class Call_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

