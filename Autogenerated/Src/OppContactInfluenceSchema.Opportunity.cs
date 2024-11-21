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

	#region Class: OppContactInfluence_Opportunity_BPMSoftSchema

	/// <exclude/>
	public class OppContactInfluence_Opportunity_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OppContactInfluence_Opportunity_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OppContactInfluence_Opportunity_BPMSoftSchema(OppContactInfluence_Opportunity_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OppContactInfluence_Opportunity_BPMSoftSchema(OppContactInfluence_Opportunity_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			RealUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			Name = "OppContactInfluence_Opportunity_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			column.CreatedInPackageId = new Guid("5d4440f3-755f-4128-9701-bb9585b17c33");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OppContactInfluence_Opportunity_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OppContactInfluence_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OppContactInfluence_Opportunity_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OppContactInfluence_Opportunity_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4"));
		}

		#endregion

	}

	#endregion

	#region Class: OppContactInfluence_Opportunity_BPMSoft

	/// <summary>
	/// Степень влияния контакта в продаже.
	/// </summary>
	public class OppContactInfluence_Opportunity_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OppContactInfluence_Opportunity_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OppContactInfluence_Opportunity_BPMSoft";
		}

		public OppContactInfluence_Opportunity_BPMSoft(OppContactInfluence_Opportunity_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OppContactInfluence_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OppContactInfluence_Opportunity_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("OppContactInfluence_Opportunity_BPMSoftInserting", e);
			Validating += (s, e) => ThrowEvent("OppContactInfluence_Opportunity_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OppContactInfluence_Opportunity_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: OppContactInfluence_OpportunityEventsProcess

	/// <exclude/>
	public partial class OppContactInfluence_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OppContactInfluence_Opportunity_BPMSoft
	{

		public OppContactInfluence_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OppContactInfluence_OpportunityEventsProcess";
			SchemaUId = new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e0aa5fa2-0910-478d-943b-e9c2579ad7b4");
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

	#region Class: OppContactInfluence_OpportunityEventsProcess

	/// <exclude/>
	public class OppContactInfluence_OpportunityEventsProcess : OppContactInfluence_OpportunityEventsProcess<OppContactInfluence_Opportunity_BPMSoft>
	{

		public OppContactInfluence_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OppContactInfluence_OpportunityEventsProcess

	public partial class OppContactInfluence_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

