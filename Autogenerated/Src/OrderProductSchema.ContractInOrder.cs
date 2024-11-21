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

	#region Class: OrderProductSchema

	/// <exclude/>
	public class OrderProductSchema : BPMSoft.Configuration.OrderProduct_PRMOrder_BPMSoftSchema
	{

		#region Constructors: Public

		public OrderProductSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public OrderProductSchema(OrderProductSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public OrderProductSchema(OrderProductSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("5fe3bdb7-97af-44cd-ab08-2a88e9f9c99e");
			Name = "OrderProduct";
			ParentSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e");
			ExtendParent = true;
			CreatedInPackageId = new Guid("2a36bdd9-0ef6-48f3-957f-b7efa409d0a7");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("c2c346e2-db9e-4468-8d3a-552348536dbe")) == null) {
				Columns.Add(CreateContractColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateContractColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c2c346e2-db9e-4468-8d3a-552348536dbe"),
				Name = @"Contract",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("5fe3bdb7-97af-44cd-ab08-2a88e9f9c99e"),
				ModifiedInSchemaUId = new Guid("5fe3bdb7-97af-44cd-ab08-2a88e9f9c99e"),
				CreatedInPackageId = new Guid("2a36bdd9-0ef6-48f3-957f-b7efa409d0a7")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new OrderProduct(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new OrderProduct_ContractInOrderEventsProcess(userConnection);
		}

		public override object Clone() {
			return new OrderProductSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new OrderProductSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fe3bdb7-97af-44cd-ab08-2a88e9f9c99e"));
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct

	/// <summary>
	/// Продукт в заказе.
	/// </summary>
	public class OrderProduct : BPMSoft.Configuration.OrderProduct_PRMOrder_BPMSoft
	{

		#region Constructors: Public

		public OrderProduct(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "OrderProduct";
		}

		public OrderProduct(OrderProduct source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ContractId {
			get {
				return GetTypedColumnValue<Guid>("ContractId");
			}
			set {
				SetColumnValue("ContractId", value);
				_contract = null;
			}
		}

		/// <exclude/>
		public string ContractNumber {
			get {
				return GetTypedColumnValue<string>("ContractNumber");
			}
			set {
				SetColumnValue("ContractNumber", value);
				if (_contract != null) {
					_contract.Number = value;
				}
			}
		}

		private Contract _contract;
		/// <summary>
		/// Договор.
		/// </summary>
		public Contract Contract {
			get {
				return _contract ??
					(_contract = LookupColumnEntities.GetEntity("Contract") as Contract);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new OrderProduct_ContractInOrderEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Validating += (s, e) => ThrowEvent("OrderProductValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new OrderProduct(this);
		}

		#endregion

	}

	#endregion

	#region Class: OrderProduct_ContractInOrderEventsProcess

	/// <exclude/>
	public partial class OrderProduct_ContractInOrderEventsProcess<TEntity> : BPMSoft.Configuration.OrderProduct_PRMOrderEventsProcess<TEntity> where TEntity : OrderProduct
	{

		public OrderProduct_ContractInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "OrderProduct_ContractInOrderEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("5fe3bdb7-97af-44cd-ab08-2a88e9f9c99e");
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

	#region Class: OrderProduct_ContractInOrderEventsProcess

	/// <exclude/>
	public class OrderProduct_ContractInOrderEventsProcess : OrderProduct_ContractInOrderEventsProcess<OrderProduct>
	{

		public OrderProduct_ContractInOrderEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: OrderProduct_ContractInOrderEventsProcess

	public partial class OrderProduct_ContractInOrderEventsProcess<TEntity>
	{

		#region Methods: Public

		public override void UpdatePrimaryAmounts() {
			if (NeedRecalcPrimaryValues){
				base.UpdatePrimaryAmounts();
			}
		}

		#endregion

	}

	#endregion


	#region Class: OrderProductEventsProcess

	/// <exclude/>
	public class OrderProductEventsProcess : OrderProduct_ContractInOrderEventsProcess
	{

		public OrderProductEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

