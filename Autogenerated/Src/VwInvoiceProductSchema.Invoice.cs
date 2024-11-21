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

	#region Class: VwInvoiceProductSchema

	/// <exclude/>
	public class VwInvoiceProductSchema : BPMSoft.Configuration.InvoiceProductSchema
	{

		#region Constructors: Public

		public VwInvoiceProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public VwInvoiceProductSchema(VwInvoiceProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public VwInvoiceProductSchema(VwInvoiceProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e048d6ec-0878-4123-a706-85d0326289a4");
			RealUId = new Guid("e048d6ec-0878-4123-a706-85d0326289a4");
			Name = "VwInvoiceProduct";
			ParentSchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = true;
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new VwInvoiceProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new VwInvoiceProduct_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new VwInvoiceProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new VwInvoiceProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e048d6ec-0878-4123-a706-85d0326289a4"));
		}

		#endregion

	}

	#endregion

	#region Class: VwInvoiceProduct

	/// <summary>
	/// Продукт в счете (представление).
	/// </summary>
	public class VwInvoiceProduct : BPMSoft.Configuration.InvoiceProduct
	{

		#region Constructors: Public

		public VwInvoiceProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "VwInvoiceProduct";
		}

		public VwInvoiceProduct(VwInvoiceProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new VwInvoiceProduct_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleting += (s, e) => ThrowEvent("VwInvoiceProductDeleting", e);
			Inserted += (s, e) => ThrowEvent("VwInvoiceProductInserted", e);
			Inserting += (s, e) => ThrowEvent("VwInvoiceProductInserting", e);
			Saving += (s, e) => ThrowEvent("VwInvoiceProductSaving", e);
			Validating += (s, e) => ThrowEvent("VwInvoiceProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new VwInvoiceProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: VwInvoiceProduct_InvoiceEventsProcess

	/// <exclude/>
	public partial class VwInvoiceProduct_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.InvoiceProduct_ProductCatalogueInInvoiceEventsProcess<TEntity> where TEntity : VwInvoiceProduct
	{

		public VwInvoiceProduct_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "VwInvoiceProduct_InvoiceEventsProcess";
			SchemaUId = new Guid("e048d6ec-0878-4123-a706-85d0326289a4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("e048d6ec-0878-4123-a706-85d0326289a4");
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

	#region Class: VwInvoiceProduct_InvoiceEventsProcess

	/// <exclude/>
	public class VwInvoiceProduct_InvoiceEventsProcess : VwInvoiceProduct_InvoiceEventsProcess<VwInvoiceProduct>
	{

		public VwInvoiceProduct_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: VwInvoiceProduct_InvoiceEventsProcess

	public partial class VwInvoiceProduct_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: VwInvoiceProductEventsProcess

	/// <exclude/>
	public class VwInvoiceProductEventsProcess : VwInvoiceProduct_InvoiceEventsProcess
	{

		public VwInvoiceProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

