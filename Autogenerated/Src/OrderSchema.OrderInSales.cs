namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
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

	#region Class: Order_OrderInSales_BPMSoftSchema

	/// <exclude/>
	public class Order_OrderInSales_BPMSoftSchema : BPMSoft.Configuration.Order_Passport_BPMSoftSchema
	{

		#region Constructors: Public

		public Order_OrderInSales_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Order_OrderInSales_BPMSoftSchema(Order_OrderInSales_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Order_OrderInSales_BPMSoftSchema(Order_OrderInSales_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("243f55eb-0a8f-4508-a570-c3c2606c3403");
			Name = "Order_OrderInSales_BPMSoft";
			ParentSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71");
			ExtendParent = true;
			CreatedInPackageId = new Guid("11b832b1-75bb-4c0d-bb5d-5aa5088efe52");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("7fe04af6-f7c7-4bb2-8413-b65da9e4f33c")) == null) {
				Columns.Add(CreateOpportunityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateOpportunityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("7fe04af6-f7c7-4bb2-8413-b65da9e4f33c"),
				Name = @"Opportunity",
				ReferenceSchemaUId = new Guid("ae46fb87-c02c-4ae8-ad31-a923cdd994cf"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("243f55eb-0a8f-4508-a570-c3c2606c3403"),
				ModifiedInSchemaUId = new Guid("243f55eb-0a8f-4508-a570-c3c2606c3403"),
				CreatedInPackageId = new Guid("8aa371b9-719f-4904-b382-2e02c0a6ba74")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Order_OrderInSales_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Order_OrderInSalesEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Order_OrderInSales_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Order_OrderInSales_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("243f55eb-0a8f-4508-a570-c3c2606c3403"));
		}

		#endregion

	}

	#endregion

	#region Class: Order_OrderInSales_BPMSoft

	/// <summary>
	/// Заказ.
	/// </summary>
	public class Order_OrderInSales_BPMSoft : BPMSoft.Configuration.Order_Passport_BPMSoft
	{

		#region Constructors: Public

		public Order_OrderInSales_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Order_OrderInSales_BPMSoft";
		}

		public Order_OrderInSales_BPMSoft(Order_OrderInSales_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid OpportunityId {
			get {
				return GetTypedColumnValue<Guid>("OpportunityId");
			}
			set {
				SetColumnValue("OpportunityId", value);
				_opportunity = null;
			}
		}

		/// <exclude/>
		public string OpportunityTitle {
			get {
				return GetTypedColumnValue<string>("OpportunityTitle");
			}
			set {
				SetColumnValue("OpportunityTitle", value);
				if (_opportunity != null) {
					_opportunity.Title = value;
				}
			}
		}

		private Opportunity _opportunity;
		/// <summary>
		/// Продажа.
		/// </summary>
		public Opportunity Opportunity {
			get {
				return _opportunity ??
					(_opportunity = LookupColumnEntities.GetEntity("Opportunity") as Opportunity);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Order_OrderInSalesEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Order_OrderInSales_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("Order_OrderInSales_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Order_OrderInSales_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Order_OrderInSales_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Order_OrderInSales_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Order_OrderInSales_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Order_OrderInSalesEventsProcess

	/// <exclude/>
	public partial class Order_OrderInSalesEventsProcess<TEntity> : BPMSoft.Configuration.Order_PassportEventsProcess<TEntity> where TEntity : Order_OrderInSales_BPMSoft
	{

		public Order_OrderInSalesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Order_OrderInSalesEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("243f55eb-0a8f-4508-a570-c3c2606c3403");
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

	#region Class: Order_OrderInSalesEventsProcess

	/// <exclude/>
	public class Order_OrderInSalesEventsProcess : Order_OrderInSalesEventsProcess<Order_OrderInSales_BPMSoft>
	{

		public Order_OrderInSalesEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Order_OrderInSalesEventsProcess

	public partial class Order_OrderInSalesEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

