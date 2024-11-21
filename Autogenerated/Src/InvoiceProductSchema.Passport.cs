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

	#region Class: InvoiceProduct_Passport_BPMSoftSchema

	/// <exclude/>
	public class InvoiceProduct_Passport_BPMSoftSchema : BPMSoft.Configuration.InvoiceProduct_Invoice_BPMSoftSchema
	{

		#region Constructors: Public

		public InvoiceProduct_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public InvoiceProduct_Passport_BPMSoftSchema(InvoiceProduct_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public InvoiceProduct_Passport_BPMSoftSchema(InvoiceProduct_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("c9772d92-257a-4e85-b21d-d892bb114e8d");
			Name = "InvoiceProduct_Passport_BPMSoft";
			ParentSchemaUId = new Guid("732baa21-890b-4894-a457-623630e33a6f");
			ExtendParent = true;
			CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("be3d1171-3682-44ed-b358-9047a1b13301")) == null) {
				Columns.Add(CreateSupplyPaymentProductColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateSupplyPaymentProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be3d1171-3682-44ed-b358-9047a1b13301"),
				Name = @"SupplyPaymentProduct",
				ReferenceSchemaUId = new Guid("5e50c5fa-41cc-4c91-a04f-9d7888236c1c"),
				IsValueCloneable = false,
				IsIndexed = true,
				IsCascade = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("c9772d92-257a-4e85-b21d-d892bb114e8d"),
				ModifiedInSchemaUId = new Guid("c9772d92-257a-4e85-b21d-d892bb114e8d"),
				CreatedInPackageId = new Guid("a002bd5f-14f1-4196-ac19-0a0feddeb334")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new InvoiceProduct_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new InvoiceProduct_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new InvoiceProduct_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new InvoiceProduct_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c9772d92-257a-4e85-b21d-d892bb114e8d"));
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_Passport_BPMSoft

	/// <summary>
	/// Продукт в счете.
	/// </summary>
	public class InvoiceProduct_Passport_BPMSoft : BPMSoft.Configuration.InvoiceProduct_Invoice_BPMSoft
	{

		#region Constructors: Public

		public InvoiceProduct_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "InvoiceProduct_Passport_BPMSoft";
		}

		public InvoiceProduct_Passport_BPMSoft(InvoiceProduct_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid SupplyPaymentProductId {
			get {
				return GetTypedColumnValue<Guid>("SupplyPaymentProductId");
			}
			set {
				SetColumnValue("SupplyPaymentProductId", value);
				_supplyPaymentProduct = null;
			}
		}

		private SupplyPaymentProduct _supplyPaymentProduct;
		/// <summary>
		/// Продукт в шаге.
		/// </summary>
		public SupplyPaymentProduct SupplyPaymentProduct {
			get {
				return _supplyPaymentProduct ??
					(_supplyPaymentProduct = LookupColumnEntities.GetEntity("SupplyPaymentProduct") as SupplyPaymentProduct);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new InvoiceProduct_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("InvoiceProduct_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new InvoiceProduct_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: InvoiceProduct_PassportEventsProcess

	/// <exclude/>
	public partial class InvoiceProduct_PassportEventsProcess<TEntity> : BPMSoft.Configuration.InvoiceProduct_InvoiceEventsProcess<TEntity> where TEntity : InvoiceProduct_Passport_BPMSoft
	{

		public InvoiceProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "InvoiceProduct_PassportEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("c9772d92-257a-4e85-b21d-d892bb114e8d");
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

	#region Class: InvoiceProduct_PassportEventsProcess

	/// <exclude/>
	public class InvoiceProduct_PassportEventsProcess : InvoiceProduct_PassportEventsProcess<InvoiceProduct_Passport_BPMSoft>
	{

		public InvoiceProduct_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: InvoiceProduct_PassportEventsProcess

	public partial class InvoiceProduct_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

