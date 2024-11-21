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

	#region Class: InvoiceProductSchema

	/// <exclude/>
	public class InvoiceProductSchema : BPMSoft.Configuration.InvoiceProduct_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public InvoiceProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceProductSchema(InvoiceProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceProductSchema(InvoiceProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("d47664c3-91ea-4cab-aa3f-d7932591e1dc");
			Name = "InvoiceProduct";
			ParentSchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("4a4ef5d1-f987-4ea2-a7d3-caa8317588e4");
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

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceProduct_ProductCatalogueInInvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d47664c3-91ea-4cab-aa3f-d7932591e1dc"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct

	/// <summary>
	/// Продукт в счете.
	/// </summary>
	public class InvoiceProduct : BPMSoft.Configuration.InvoiceProduct_Passport_BPMSoft
	{

		#region Constructors: Public

		public InvoiceProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceProduct";
		}

		public InvoiceProduct(InvoiceProduct source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceProduct_ProductCatalogueInInvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("InvoiceProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_ProductCatalogueInInvoiceEventsProcess

	/// <exclude/>
	public partial class InvoiceProduct_ProductCatalogueInInvoiceEventsProcess<TEntity> : BPMSoft.Configuration.InvoiceProduct_PassportEventsProcess<TEntity> where TEntity : InvoiceProduct
	{

		public InvoiceProduct_ProductCatalogueInInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceProduct_ProductCatalogueInInvoiceEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("d47664c3-91ea-4cab-aa3f-d7932591e1dc");
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

	#region Class: InvoiceProduct_ProductCatalogueInInvoiceEventsProcess

	/// <exclude/>
	public class InvoiceProduct_ProductCatalogueInInvoiceEventsProcess : InvoiceProduct_ProductCatalogueInInvoiceEventsProcess<InvoiceProduct>
	{

		public InvoiceProduct_ProductCatalogueInInvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceProduct_ProductCatalogueInInvoiceEventsProcess

	public partial class InvoiceProduct_ProductCatalogueInInvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion


	#region Class: InvoiceProductEventsProcess

	/// <exclude/>
	public class InvoiceProductEventsProcess : InvoiceProduct_ProductCatalogueInInvoiceEventsProcess
	{

		public InvoiceProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

