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

	#region Class: OpportunityProbabilitySchema

	/// <exclude/>
	public class OpportunityProbabilitySchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public OpportunityProbabilitySchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OpportunityProbabilitySchema(OpportunityProbabilitySchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OpportunityProbabilitySchema(OpportunityProbabilitySchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
			RealUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
			Name = "OpportunityProbability";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateValueColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
			column.CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			return column;
		}

		protected virtual EntitySchemaColumn CreateValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Integer")) {
				UId = new Guid("94d7ee6d-c521-4213-8ae0-592c9f391a74"),
				Name = @"Value",
				CreatedInSchemaUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f"),
				ModifiedInSchemaUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OpportunityProbability(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OpportunityProbability_OpportunityEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OpportunityProbabilitySchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OpportunityProbabilitySchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f"));
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProbability

	/// <summary>
	/// Вероятность продажи.
	/// </summary>
	public class OpportunityProbability : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public OpportunityProbability(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OpportunityProbability";
		}

		public OpportunityProbability(OpportunityProbability source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Вероятность, %.
		/// </summary>
		public int Value {
			get {
				return GetTypedColumnValue<int>("Value");
			}
			set {
				SetColumnValue("Value", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OpportunityProbability_OpportunityEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("OpportunityProbabilityDeleted", e);
			Deleting += (s, e) => ThrowEvent("OpportunityProbabilityDeleting", e);
			Inserted += (s, e) => ThrowEvent("OpportunityProbabilityInserted", e);
			Inserting += (s, e) => ThrowEvent("OpportunityProbabilityInserting", e);
			Saved += (s, e) => ThrowEvent("OpportunityProbabilitySaved", e);
			Saving += (s, e) => ThrowEvent("OpportunityProbabilitySaving", e);
			Validating += (s, e) => ThrowEvent("OpportunityProbabilityValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OpportunityProbability(this);
		}

		#endregion

	}

	#endregion

	#region Class: OpportunityProbability_OpportunityEventsProcess

	/// <exclude/>
	public partial class OpportunityProbability_OpportunityEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : OpportunityProbability
	{

		public OpportunityProbability_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OpportunityProbability_OpportunityEventsProcess";
			SchemaUId = new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("7b621c2d-9f2a-46aa-9563-eabfdc4c720f");
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

	#region Class: OpportunityProbability_OpportunityEventsProcess

	/// <exclude/>
	public class OpportunityProbability_OpportunityEventsProcess : OpportunityProbability_OpportunityEventsProcess<OpportunityProbability>
	{

		public OpportunityProbability_OpportunityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OpportunityProbability_OpportunityEventsProcess

	public partial class OpportunityProbability_OpportunityEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: OpportunityProbabilityEventsProcess

	/// <exclude/>
	public class OpportunityProbabilityEventsProcess : OpportunityProbability_OpportunityEventsProcess
	{

		public OpportunityProbabilityEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

