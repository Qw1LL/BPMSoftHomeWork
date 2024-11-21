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

	#region Class: Opportunity_CoreLeadOpportunity_BPMSoftSchema

	/// <exclude/>
	public class Opportunity_CoreLeadOpportunity_BPMSoftSchema : BPMSoft.Configuration.Opportunity_Opportunity_BPMSoftSchema
	{

		#region Constructors: Public

		public Opportunity_CoreLeadOpportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Opportunity_CoreLeadOpportunity_BPMSoftSchema(Opportunity_CoreLeadOpportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Opportunity_CoreLeadOpportunity_BPMSoftSchema(Opportunity_CoreLeadOpportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_OpportunityTitleIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("538d5288-c406-4b69-8f00-7b42c02cbdf3");
			index.Name = "IDX_OpportunityTitle";
			index.CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			index.ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			index.CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13");
			EntitySchemaIndexColumn titleIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("7a45b5d6-7ce5-4417-8995-a0f6d21a272b"),
				ColumnUId = new Guid("790563cf-fd14-4d5d-a5fd-b6eddb10d6d3"),
				CreatedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				ModifiedInSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				CreatedInPackageId = new Guid("5ef32b22-5119-483b-953d-678c3fffad13"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(titleIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("53447e9d-4dbc-4c4d-8a9f-9eecd0939a1e");
			Name = "Opportunity_CoreLeadOpportunity_BPMSoft";
			ParentSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			ExtendParent = true;
			CreatedInPackageId = new Guid("b1a963da-a78f-4fae-8e9e-52d870dd0ef3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("6b0dc85d-37b8-41c8-809a-6e30ddaf1f32")) == null) {
				Columns.Add(CreateLeadTypeColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateLeadTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("6b0dc85d-37b8-41c8-809a-6e30ddaf1f32"),
				Name = @"LeadType",
				ReferenceSchemaUId = new Guid("e0dbeb22-4932-4eee-a8f2-a247a5fce888"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("53447e9d-4dbc-4c4d-8a9f-9eecd0939a1e"),
				ModifiedInSchemaUId = new Guid("53447e9d-4dbc-4c4d-8a9f-9eecd0939a1e"),
				CreatedInPackageId = new Guid("b1a963da-a78f-4fae-8e9e-52d870dd0ef3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_OpportunityTitleIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Opportunity_CoreLeadOpportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Opportunity_CoreLeadOpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Opportunity_CoreLeadOpportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Opportunity_CoreLeadOpportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("53447e9d-4dbc-4c4d-8a9f-9eecd0939a1e"));
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_CoreLeadOpportunity_BPMSoft

	/// <summary>
	/// Продажа.
	/// </summary>
	public class Opportunity_CoreLeadOpportunity_BPMSoft : BPMSoft.Configuration.Opportunity_Opportunity_BPMSoft
	{

		#region Constructors: Public

		public Opportunity_CoreLeadOpportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Opportunity_CoreLeadOpportunity_BPMSoft";
		}

		public Opportunity_CoreLeadOpportunity_BPMSoft(Opportunity_CoreLeadOpportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid LeadTypeId {
			get {
				return GetTypedColumnValue<Guid>("LeadTypeId");
			}
			set {
				SetColumnValue("LeadTypeId", value);
				_leadType = null;
			}
		}

		/// <exclude/>
		public string LeadTypeName {
			get {
				return GetTypedColumnValue<string>("LeadTypeName");
			}
			set {
				SetColumnValue("LeadTypeName", value);
				if (_leadType != null) {
					_leadType.Name = value;
				}
			}
		}

		private LeadType _leadType;
		/// <summary>
		/// Тип потребности.
		/// </summary>
		public LeadType LeadType {
			get {
				return _leadType ??
					(_leadType = LookupColumnEntities.GetEntity("LeadType") as LeadType);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Opportunity_CoreLeadOpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Inserting += (s, e) => ThrowEvent("Opportunity_CoreLeadOpportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("Opportunity_CoreLeadOpportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Opportunity_CoreLeadOpportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_CoreLeadOpportunityEventsProcess

	/// <exclude/>
	public partial class Opportunity_CoreLeadOpportunityEventsProcess<TEntity> : BPMSoft.Configuration.Opportunity_OpportunityEventsProcess<TEntity> where TEntity : Opportunity_CoreLeadOpportunity_BPMSoft
	{

		public Opportunity_CoreLeadOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Opportunity_CoreLeadOpportunityEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("53447e9d-4dbc-4c4d-8a9f-9eecd0939a1e");
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

	#region Class: Opportunity_CoreLeadOpportunityEventsProcess

	/// <exclude/>
	public class Opportunity_CoreLeadOpportunityEventsProcess : Opportunity_CoreLeadOpportunityEventsProcess<Opportunity_CoreLeadOpportunity_BPMSoft>
	{

		public Opportunity_CoreLeadOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Opportunity_CoreLeadOpportunityEventsProcess

	public partial class Opportunity_CoreLeadOpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

