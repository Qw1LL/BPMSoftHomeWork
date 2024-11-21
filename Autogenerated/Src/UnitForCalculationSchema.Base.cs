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

	#region Class: UnitForCalculationSchema

	/// <exclude/>
	public class UnitForCalculationSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public UnitForCalculationSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public UnitForCalculationSchema(UnitForCalculationSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public UnitForCalculationSchema(UnitForCalculationSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			RealUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			Name = "UnitForCalculation";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new UnitForCalculation(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new UnitForCalculation_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new UnitForCalculationSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new UnitForCalculationSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988"));
		}

		#endregion

	}

	#endregion

	#region Class: UnitForCalculation

	/// <summary>
	/// Unit of measure for rate.
	/// </summary>
	public class UnitForCalculation : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public UnitForCalculation(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "UnitForCalculation";
		}

		public UnitForCalculation(UnitForCalculation source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new UnitForCalculation_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("UnitForCalculationDeleted", e);
			Deleting += (s, e) => ThrowEvent("UnitForCalculationDeleting", e);
			Inserted += (s, e) => ThrowEvent("UnitForCalculationInserted", e);
			Inserting += (s, e) => ThrowEvent("UnitForCalculationInserting", e);
			Saved += (s, e) => ThrowEvent("UnitForCalculationSaved", e);
			Saving += (s, e) => ThrowEvent("UnitForCalculationSaving", e);
			Validating += (s, e) => ThrowEvent("UnitForCalculationValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new UnitForCalculation(this);
		}

		#endregion

	}

	#endregion

	#region Class: UnitForCalculation_BaseEventsProcess

	/// <exclude/>
	public partial class UnitForCalculation_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : UnitForCalculation
	{

		public UnitForCalculation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "UnitForCalculation_BaseEventsProcess";
			SchemaUId = new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("eecd2b4c-b41b-4da8-bcb7-5d793777d988");
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

	#region Class: UnitForCalculation_BaseEventsProcess

	/// <exclude/>
	public class UnitForCalculation_BaseEventsProcess : UnitForCalculation_BaseEventsProcess<UnitForCalculation>
	{

		public UnitForCalculation_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: UnitForCalculation_BaseEventsProcess

	public partial class UnitForCalculation_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: UnitForCalculationEventsProcess

	/// <exclude/>
	public class UnitForCalculationEventsProcess : UnitForCalculation_BaseEventsProcess
	{

		public UnitForCalculationEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

