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

	#region Class: ChartAggregationTypeSchema

	/// <exclude/>
	public class ChartAggregationTypeSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public ChartAggregationTypeSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public ChartAggregationTypeSchema(ChartAggregationTypeSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public ChartAggregationTypeSchema(ChartAggregationTypeSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			RealUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			Name = "ChartAggregationType";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("3def9774-d754-4655-9115-bf9c9a72c30b")) == null) {
				Columns.Add(CreateAggregationTypeCodeColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected override EntitySchemaColumn CreateProcessListenersColumn() {
			EntitySchemaColumn column = base.CreateProcessListenersColumn();
			column.ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			column.CreatedInPackageId = new Guid("b58d2c33-e1a2-4365-b7e9-3120dc2c01fc");
			return column;
		}

		protected virtual EntitySchemaColumn CreateAggregationTypeCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("3def9774-d754-4655-9115-bf9c9a72c30b"),
				Name = @"AggregationTypeCode",
				CreatedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df"),
				ModifiedInSchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df"),
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
			return new ChartAggregationType(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new ChartAggregationType_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new ChartAggregationTypeSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new ChartAggregationTypeSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df"));
		}

		#endregion

	}

	#endregion

	#region Class: ChartAggregationType

	/// <summary>
	/// Aggregate type of chart.
	/// </summary>
	public class ChartAggregationType : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public ChartAggregationType(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "ChartAggregationType";
		}

		public ChartAggregationType(ChartAggregationType source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Code of aggregate type.
		/// </summary>
		public string AggregationTypeCode {
			get {
				return GetTypedColumnValue<string>("AggregationTypeCode");
			}
			set {
				SetColumnValue("AggregationTypeCode", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new ChartAggregationType_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("ChartAggregationTypeDeleted", e);
			Deleting += (s, e) => ThrowEvent("ChartAggregationTypeDeleting", e);
			Inserted += (s, e) => ThrowEvent("ChartAggregationTypeInserted", e);
			Inserting += (s, e) => ThrowEvent("ChartAggregationTypeInserting", e);
			Saved += (s, e) => ThrowEvent("ChartAggregationTypeSaved", e);
			Saving += (s, e) => ThrowEvent("ChartAggregationTypeSaving", e);
			Validating += (s, e) => ThrowEvent("ChartAggregationTypeValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new ChartAggregationType(this);
		}

		#endregion

	}

	#endregion

	#region Class: ChartAggregationType_BaseEventsProcess

	/// <exclude/>
	public partial class ChartAggregationType_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : ChartAggregationType
	{

		public ChartAggregationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "ChartAggregationType_BaseEventsProcess";
			SchemaUId = new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("177c7c70-7dd4-486b-a4a5-25c9b36349df");
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

	#region Class: ChartAggregationType_BaseEventsProcess

	/// <exclude/>
	public class ChartAggregationType_BaseEventsProcess : ChartAggregationType_BaseEventsProcess<ChartAggregationType>
	{

		public ChartAggregationType_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: ChartAggregationType_BaseEventsProcess

	public partial class ChartAggregationType_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: ChartAggregationTypeEventsProcess

	/// <exclude/>
	public class ChartAggregationTypeEventsProcess : ChartAggregationType_BaseEventsProcess
	{

		public ChartAggregationTypeEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

