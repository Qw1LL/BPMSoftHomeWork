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

	#region Class: Lead_CoreLeadOpportunity_BPMSoftSchema

	/// <exclude/>
	public class Lead_CoreLeadOpportunity_BPMSoftSchema : BPMSoft.Configuration.Lead_WebLeadForm_BPMSoftSchema
	{

		#region Constructors: Public

		public Lead_CoreLeadOpportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Lead_CoreLeadOpportunity_BPMSoftSchema(Lead_CoreLeadOpportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Lead_CoreLeadOpportunity_BPMSoftSchema(Lead_CoreLeadOpportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIDX_LeadNameIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = false,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("bf3f62f3-5d38-4031-a648-58b036f8f19d");
			index.Name = "IDX_LeadName";
			index.CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			index.CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			EntitySchemaIndexColumn leadNameIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("2c3ed9bd-ff44-447d-b4af-c6a4e4090a5a"),
				ColumnUId = new Guid("d06ba9af-faf5-4741-a672-e154ae561a94"),
				CreatedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				ModifiedInSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec"),
				CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(leadNameIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("601457d2-f86e-4ee0-bdf2-eeb9ef04a107");
			Name = "Lead_CoreLeadOpportunity_BPMSoft";
			ParentSchemaUId = new Guid("41af89e9-750b-4ebb-8cac-ff39b64841ec");
			ExtendParent = true;
			CreatedInPackageId = new Guid("b1a963da-a78f-4fae-8e9e-52d870dd0ef3");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7cfff438-9ee8-4272-816d-5deb7d0c9d36")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7cfff438-9ee8-4272-816d-5deb7d0c9d36"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("601457d2-f86e-4ee0-bdf2-eeb9ef04a107"),
				ModifiedInSchemaUId = new Guid("601457d2-f86e-4ee0-bdf2-eeb9ef04a107"),
				CreatedInPackageId = new Guid("b1a963da-a78f-4fae-8e9e-52d870dd0ef3")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIDX_LeadNameIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Lead_CoreLeadOpportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Lead_CoreLeadOpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Lead_CoreLeadOpportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Lead_CoreLeadOpportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("601457d2-f86e-4ee0-bdf2-eeb9ef04a107"));
		}

		#endregion

	}

	#endregion

	#region Class: Lead_CoreLeadOpportunity_BPMSoft

	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead_CoreLeadOpportunity_BPMSoft : BPMSoft.Configuration.Lead_WebLeadForm_BPMSoft
	{

		#region Constructors: Public

		public Lead_CoreLeadOpportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Lead_CoreLeadOpportunity_BPMSoft";
		}

		public Lead_CoreLeadOpportunity_BPMSoft(Lead_CoreLeadOpportunity_BPMSoft source)
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
			var process = new Lead_CoreLeadOpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Lead_CoreLeadOpportunity_BPMSoftDeleted", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Lead_CoreLeadOpportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Lead_CoreLeadOpportunityEventsProcess

	/// <exclude/>
	public partial class Lead_CoreLeadOpportunityEventsProcess<TEntity> : BPMSoft.Configuration.Lead_WebLeadFormEventsProcess<TEntity> where TEntity : Lead_CoreLeadOpportunity_BPMSoft
	{

		public Lead_CoreLeadOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Lead_CoreLeadOpportunityEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("601457d2-f86e-4ee0-bdf2-eeb9ef04a107");
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

	#region Class: Lead_CoreLeadOpportunityEventsProcess

	/// <exclude/>
	public class Lead_CoreLeadOpportunityEventsProcess : Lead_CoreLeadOpportunityEventsProcess<Lead_CoreLeadOpportunity_BPMSoft>
	{

		public Lead_CoreLeadOpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Lead_CoreLeadOpportunityEventsProcess

	public partial class Lead_CoreLeadOpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

