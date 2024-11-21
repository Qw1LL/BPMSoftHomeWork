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

	#region Class: OpportunitySchema

	/// <exclude/>
	public class OpportunitySchema : BPMSoft.Configuration.Opportunity_OpportunityManagement_BPMSoftSchema
	{

		#region Constructors: Public

		public OpportunitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunitySchema(OpportunitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunitySchema(OpportunitySchema source)
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
			RealUId = new Guid("fb3bb3a4-014f-45a9-b9ca-d9ee733d376f");
			Name = "Opportunity";
			ParentSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf");
			ExtendParent = true;
			CreatedInPackageId = new Guid("6e828642-ee6e-4ea6-9469-ffeca865fc72");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
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
			return new Opportunity(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Opportunity_SalesEnterpriseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fb3bb3a4-014f-45a9-b9ca-d9ee733d376f"));
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity

	/// <summary>
	/// Продажа.
	/// </summary>
	public class Opportunity : BPMSoft.Configuration.Opportunity_OpportunityManagement_BPMSoft
	{

		#region Constructors: Public

		public Opportunity(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Opportunity";
		}

		public Opportunity(Opportunity source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Opportunity_SalesEnterpriseEventsProcess(UserConnection);
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
			return new Opportunity(this);
		}

		#endregion

	}

	#endregion

	#region Class: Opportunity_SalesEnterpriseEventsProcess

	/// <exclude/>
	public partial class Opportunity_SalesEnterpriseEventsProcess<TEntity> : BPMSoft.Configuration.Opportunity_OpportunityManagementEventsProcess<TEntity> where TEntity : Opportunity
	{

		public Opportunity_SalesEnterpriseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Opportunity_SalesEnterpriseEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("fb3bb3a4-014f-45a9-b9ca-d9ee733d376f");
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

	#region Class: Opportunity_SalesEnterpriseEventsProcess

	/// <exclude/>
	public class Opportunity_SalesEnterpriseEventsProcess : Opportunity_SalesEnterpriseEventsProcess<Opportunity>
	{

		public Opportunity_SalesEnterpriseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Opportunity_SalesEnterpriseEventsProcess

	public partial class Opportunity_SalesEnterpriseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityEventsProcess : Opportunity_SalesEnterpriseEventsProcess
	{

		public OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

