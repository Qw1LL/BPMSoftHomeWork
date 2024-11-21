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

	#region Class: InvoicePaymentStatus_Invoice_BPMSoftSchema

	/// <exclude/>
	public class InvoicePaymentStatus_Invoice_BPMSoftSchema : BPMSoft.Configuration.BaseLookupSchema
	{

		#region Constructors: Public

		public InvoicePaymentStatus_Invoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoicePaymentStatus_Invoice_BPMSoftSchema(InvoicePaymentStatus_Invoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoicePaymentStatus_Invoice_BPMSoftSchema(InvoicePaymentStatus_Invoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
			RealUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
			Name = "InvoicePaymentStatus_Invoice_BPMSoft";
			ParentSchemaUId = new Guid("11ab4bcb-9b23-4b6d-9c86-520fae925d75");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("ca97d08a-da88-4e75-a732-6501bc043dcb")) == null) {
				Columns.Add(CreateFinalStatusColumn());
			}
		}

		protected override EntitySchemaColumn CreateNameColumn() {
			EntitySchemaColumn column = base.CreateNameColumn();
			column.ModifiedInSchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected override EntitySchemaColumn CreateDescriptionColumn() {
			EntitySchemaColumn column = base.CreateDescriptionColumn();
			column.ModifiedInSchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
			column.CreatedInPackageId = new Guid("c692daa9-de5e-4e96-afd3-e992ed86681c");
			return column;
		}

		protected virtual EntitySchemaColumn CreateFinalStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("ca97d08a-da88-4e75-a732-6501bc043dcb"),
				Name = @"FinalStatus",
				CreatedInSchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861"),
				ModifiedInSchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861"),
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
			return new InvoicePaymentStatus_Invoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoicePaymentStatus_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoicePaymentStatus_Invoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoicePaymentStatus_Invoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoicePaymentStatus_Invoice_BPMSoft

	/// <summary>
	/// Состояние оплаты счета.
	/// </summary>
	public class InvoicePaymentStatus_Invoice_BPMSoft : BPMSoft.Configuration.BaseLookup
	{

		#region Constructors: Public

		public InvoicePaymentStatus_Invoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoicePaymentStatus_Invoice_BPMSoft";
		}

		public InvoicePaymentStatus_Invoice_BPMSoft(InvoicePaymentStatus_Invoice_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Конечное состояние.
		/// </summary>
		public bool FinalStatus {
			get {
				return GetTypedColumnValue<bool>("FinalStatus");
			}
			set {
				SetColumnValue("FinalStatus", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoicePaymentStatus_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("InvoicePaymentStatus_Invoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoicePaymentStatus_Invoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoicePaymentStatus_InvoiceEventsProcess

	/// <exclude/>
	public partial class InvoicePaymentStatus_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseLookup_BaseEventsProcess<TEntity> where TEntity : InvoicePaymentStatus_Invoice_BPMSoft
	{

		public InvoicePaymentStatus_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoicePaymentStatus_InvoiceEventsProcess";
			SchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861");
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

	#region Class: InvoicePaymentStatus_InvoiceEventsProcess

	/// <exclude/>
	public class InvoicePaymentStatus_InvoiceEventsProcess : InvoicePaymentStatus_InvoiceEventsProcess<InvoicePaymentStatus_Invoice_BPMSoft>
	{

		public InvoicePaymentStatus_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoicePaymentStatus_InvoiceEventsProcess

	public partial class InvoicePaymentStatus_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

