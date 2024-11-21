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

	#region Class: Tax_Base_BPMSoftSchema

	/// <exclude/>
	public class Tax_Base_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public Tax_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Tax_Base_BPMSoftSchema(Tax_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Tax_Base_BPMSoftSchema(Tax_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			RealUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			Name = "Tax_Base_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("09de73af-3a4c-43d2-94ff-536f40a98048")) == null) {
				Columns.Add(CreatePercentColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreatePercentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("09de73af-3a4c-43d2-94ff-536f40a98048"),
				Name = @"Percent",
				CreatedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				ModifiedInSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Tax_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Tax_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Tax_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Tax_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"));
		}

		#endregion

	}

	#endregion

	#region Class: Tax_Base_BPMSoft

	/// <summary>
	/// Tax.
	/// </summary>
	public class Tax_Base_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public Tax_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Tax_Base_BPMSoft";
		}

		public Tax_Base_BPMSoft(Tax_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Rate, %.
		/// </summary>
		public Decimal Percent {
			get {
				return GetTypedColumnValue<Decimal>("Percent");
			}
			set {
				SetColumnValue("Percent", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Tax_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Tax_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Tax_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Tax_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Tax_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Tax_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Tax_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Tax_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Tax_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Tax_BaseEventsProcess

	/// <exclude/>
	public partial class Tax_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : Tax_Base_BPMSoft
	{

		public Tax_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Tax_BaseEventsProcess";
			SchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0");
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

	#region Class: Tax_BaseEventsProcess

	/// <exclude/>
	public class Tax_BaseEventsProcess : Tax_BaseEventsProcess<Tax_Base_BPMSoft>
	{

		public Tax_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Tax_BaseEventsProcess

	public partial class Tax_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

