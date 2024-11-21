namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration.Passport;
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

	#region Class: SupplyPaymentElement_Passport_BPMSoftSchema

	/// <exclude/>
	public class SupplyPaymentElement_Passport_BPMSoftSchema : BPMSoft.Configuration.SupplyPaymentSchema
	{

		#region Constructors: Public

		public SupplyPaymentElement_Passport_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public SupplyPaymentElement_Passport_BPMSoftSchema(SupplyPaymentElement_Passport_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public SupplyPaymentElement_Passport_BPMSoftSchema(SupplyPaymentElement_Passport_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaIndex CreateIeY97HvuWyT8xw8jpwkpEpPnhiUsIndex() {
			EntitySchemaIndex index = new EntitySchemaIndex() {
				IsAutoName = true,
				IsClustered = false,
				IsUnique = false
			};
			index.UId = new Guid("3bd175a6-d977-41b0-9091-566ad73135f7");
			index.Name = "IeY97HvuWyT8xw8jpwkpEpPnhiUs";
			index.CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			index.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			index.CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a");
			EntitySchemaIndexColumn idIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("4f208c25-99a7-4192-a03e-fcb48d4a9abc"),
				ColumnUId = new Guid("ae0e45ca-c495-4fe7-a39d-3ab7278e1617"),
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(idIndexColumn);
			EntitySchemaIndexColumn typeIdIndexColumn = new EntitySchemaIndexColumn() {
				UId = new Guid("6ff85e23-059a-44f7-b128-f5e452ca9c05"),
				ColumnUId = new Guid("dd703360-9b62-47fe-abb5-2f3ff6a57911"),
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a"),
				OrderDirection = OrderDirectionStrict.Ascending
			};
			index.Columns.Add(typeIdIndexColumn);
			return index;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			RealUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			Name = "SupplyPaymentElement_Passport_BPMSoft";
			ParentSchemaUId = new Guid("980a8f16-f64b-4446-8894-4637063d3818");
			ExtendParent = false;
			CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNameColumn();
			if (Columns.FindByUId(PrimaryDisplayColumn.UId) == null) {
				Columns.Add(PrimaryDisplayColumn);
			}
		}

		protected override void InitializePrimaryOrderColumn() {
			base.InitializePrimaryOrderColumn();
			PrimaryOrderColumn = CreateDatePlanColumn();
			if (Columns.FindByUId(PrimaryOrderColumn.UId) == null) {
				Columns.Add(PrimaryOrderColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("eba7d360-42b7-462d-a77a-9a88bc0341eb")) == null) {
				Columns.Add(CreateDateFactColumn());
			}
			if (Columns.FindByUId(new Guid("0a3324bb-55c8-4791-b51f-409cfedc6fe2")) == null) {
				Columns.Add(CreateStateColumn());
			}
			if (Columns.FindByUId(new Guid("8db4ebad-d676-40ac-8794-e7595b45a380")) == null) {
				Columns.Add(CreateAmountPlanColumn());
			}
			if (Columns.FindByUId(new Guid("17e30b16-182b-49de-b2eb-f3e22b748da4")) == null) {
				Columns.Add(CreateAmountFactColumn());
			}
			if (Columns.FindByUId(new Guid("bffa49c8-f12c-4d40-b2d0-872ff5affd26")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("b96f2cd9-fee2-4165-85da-7941232abaa8")) == null) {
				Columns.Add(CreateOrderColumn());
			}
			if (Columns.FindByUId(new Guid("0466d76c-ac6c-4404-ab86-769840c37023")) == null) {
				Columns.Add(CreatePreviousElementColumn());
			}
			if (Columns.FindByUId(new Guid("e220d88e-6cd0-40c1-9b5a-4a2f460c48d2")) == null) {
				Columns.Add(CreateInvoiceColumn());
			}
			if (Columns.FindByUId(new Guid("66261c3c-a0a6-4a54-8e50-39752634604e")) == null) {
				Columns.Add(CreateContractColumn());
			}
			if (Columns.FindByUId(new Guid("d72b2f87-802a-4608-b41c-9d271ba1fd0b")) == null) {
				Columns.Add(CreatePrimaryAmountPlanColumn());
			}
			if (Columns.FindByUId(new Guid("9f4daaf1-654c-4f57-9200-73d27570bde0")) == null) {
				Columns.Add(CreatePrimaryAmountFactColumn());
			}
			if (Columns.FindByUId(new Guid("d0235de8-8f51-44ff-98f3-a8f701a34931")) == null) {
				Columns.Add(CreateProductsColumn());
			}
		}

		protected override EntitySchemaColumn CreatePositionColumn() {
			EntitySchemaColumn column = base.CreatePositionColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			return column;
		}

		protected override EntitySchemaColumn CreateTypeColumn() {
			EntitySchemaColumn column = base.CreateTypeColumn();
			column.RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel;
			column.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			return column;
		}

		protected override EntitySchemaColumn CreateDelayTypeColumn() {
			EntitySchemaColumn column = base.CreateDelayTypeColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"6fc58059-9c4a-4481-8775-bbadf4a4ad51"
			};
			column.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			return column;
		}

		protected override EntitySchemaColumn CreateDelayColumn() {
			EntitySchemaColumn column = base.CreateDelayColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"0"
			};
			column.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			return column;
		}

		protected override EntitySchemaColumn CreatePercentageColumn() {
			EntitySchemaColumn column = base.CreatePercentageColumn();
			column.DefValue = new EntitySchemaColumnDef() {
				Source = EntitySchemaColumnDefSource.Const,
				ValueSource = @"0"
			};
			column.ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			return column;
		}

		protected virtual EntitySchemaColumn CreateDatePlanColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("72478c19-2ca7-4043-849a-98b8a98379b8"),
				Name = @"DatePlan",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDateFactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("eba7d360-42b7-462d-a77a-9a88bc0341eb"),
				Name = @"DateFact",
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateStateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0a3324bb-55c8-4791-b51f-409cfedc6fe2"),
				Name = @"State",
				ReferenceSchemaUId = new Guid("270f817e-6b26-499c-8a5a-61d02846ee36"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"b801edd0-33f8-45ed-aee8-2e26307b0456"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAmountPlanColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("8db4ebad-d676-40ac-8794-e7595b45a380"),
				Name = @"AmountPlan",
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountFactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("17e30b16-182b-49de-b2eb-f3e22b748da4"),
				Name = @"AmountFact",
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("bffa49c8-f12c-4d40-b2d0-872ff5affd26"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("a31247aa-b718-40ed-982e-5b569d7d7b0e"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateOrderColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b96f2cd9-fee2-4165-85da-7941232abaa8"),
				Name = @"Order",
				ReferenceSchemaUId = new Guid("80294582-06b5-4faa-a85f-3323e5536b71"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("34a51039-9d1e-4b9d-bbef-f6018add0691"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreatePreviousElementColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("0466d76c-ac6c-4404-ab86-769840c37023"),
				Name = @"PreviousElement",
				ReferenceSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				IsIndexed = true,
				IsWeakReference = true,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("f50b1877-37f3-4844-90b8-f493542cdd8d")
			};
		}

		protected virtual EntitySchemaColumn CreateInvoiceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e220d88e-6cd0-40c1-9b5a-4a2f460c48d2"),
				Name = @"Invoice",
				ReferenceSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("d9ceb238-704d-4d40-8dc8-6e1f79ab2ddb")
			};
		}

		protected virtual EntitySchemaColumn CreateContractColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("66261c3c-a0a6-4a54-8e50-39752634604e"),
				Name = @"Contract",
				ReferenceSchemaUId = new Guid("897be3e4-0333-467d-88e2-b7a945c0d810"),
				IsIndexed = true,
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("d9ceb238-704d-4d40-8dc8-6e1f79ab2ddb")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountPlanColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("d72b2f87-802a-4608-b41c-9d271ba1fd0b"),
				Name = @"PrimaryAmountPlan",
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("d9ceb238-704d-4d40-8dc8-6e1f79ab2ddb")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountFactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("9f4daaf1-654c-4f57-9200-73d27570bde0"),
				Name = @"PrimaryAmountFact",
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("d9ceb238-704d-4d40-8dc8-6e1f79ab2ddb")
			};
		}

		protected virtual EntitySchemaColumn CreateProductsColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("d0235de8-8f51-44ff-98f3-a8f701a34931"),
				Name = @"Products",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				ModifiedInSchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"),
				CreatedInPackageId = new Guid("a0538e5b-8885-491e-bb6b-658d0c2fee8a")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		protected override void InitializeIndexes() {
			base.InitializeIndexes();
			Indexes.Add(CreateIeY97HvuWyT8xw8jpwkpEpPnhiUsIndex());
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new SupplyPaymentElement_Passport_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new SupplyPaymentElement_PassportEventsProcess(userConnection);
		}

		public override object Clone() {
			return new SupplyPaymentElement_Passport_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new SupplyPaymentElement_Passport_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e"));
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentElement_Passport_BPMSoft

	/// <summary>
	/// Шаг графика поставок и оплат.
	/// </summary>
	public class SupplyPaymentElement_Passport_BPMSoft : BPMSoft.Configuration.SupplyPayment
	{

		#region Constructors: Public

		public SupplyPaymentElement_Passport_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "SupplyPaymentElement_Passport_BPMSoft";
		}

		public SupplyPaymentElement_Passport_BPMSoft(SupplyPaymentElement_Passport_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Дата, план.
		/// </summary>
		public DateTime DatePlan {
			get {
				return GetTypedColumnValue<DateTime>("DatePlan");
			}
			set {
				SetColumnValue("DatePlan", value);
			}
		}

		/// <summary>
		/// Дата, факт.
		/// </summary>
		public DateTime DateFact {
			get {
				return GetTypedColumnValue<DateTime>("DateFact");
			}
			set {
				SetColumnValue("DateFact", value);
			}
		}

		/// <exclude/>
		public Guid StateId {
			get {
				return GetTypedColumnValue<Guid>("StateId");
			}
			set {
				SetColumnValue("StateId", value);
				_state = null;
			}
		}

		/// <exclude/>
		public string StateName {
			get {
				return GetTypedColumnValue<string>("StateName");
			}
			set {
				SetColumnValue("StateName", value);
				if (_state != null) {
					_state.Name = value;
				}
			}
		}

		private SupplyPaymentState _state;
		/// <summary>
		/// Состояние.
		/// </summary>
		public SupplyPaymentState State {
			get {
				return _state ??
					(_state = LookupColumnEntities.GetEntity("State") as SupplyPaymentState);
			}
		}

		/// <summary>
		/// Сумма, план.
		/// </summary>
		public Decimal AmountPlan {
			get {
				return GetTypedColumnValue<Decimal>("AmountPlan");
			}
			set {
				SetColumnValue("AmountPlan", value);
			}
		}

		/// <summary>
		/// Сумма, факт.
		/// </summary>
		public Decimal AmountFact {
			get {
				return GetTypedColumnValue<Decimal>("AmountFact");
			}
			set {
				SetColumnValue("AmountFact", value);
			}
		}

		/// <exclude/>
		public Guid ProductId {
			get {
				return GetTypedColumnValue<Guid>("ProductId");
			}
			set {
				SetColumnValue("ProductId", value);
				_product = null;
			}
		}

		/// <exclude/>
		public string ProductName {
			get {
				return GetTypedColumnValue<string>("ProductName");
			}
			set {
				SetColumnValue("ProductName", value);
				if (_product != null) {
					_product.Name = value;
				}
			}
		}

		private OrderProduct _product;
		/// <summary>
		/// Продукт.
		/// </summary>
		/// <remarks>
		/// Deprecated.
		/// </remarks>
		public OrderProduct Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as OrderProduct);
			}
		}

		/// <exclude/>
		public Guid OrderId {
			get {
				return GetTypedColumnValue<Guid>("OrderId");
			}
			set {
				SetColumnValue("OrderId", value);
				_order = null;
			}
		}

		/// <exclude/>
		public string OrderNumber {
			get {
				return GetTypedColumnValue<string>("OrderNumber");
			}
			set {
				SetColumnValue("OrderNumber", value);
				if (_order != null) {
					_order.Number = value;
				}
			}
		}

		private Order _order;
		/// <summary>
		/// Заказ.
		/// </summary>
		public Order Order {
			get {
				return _order ??
					(_order = LookupColumnEntities.GetEntity("Order") as Order);
			}
		}

		/// <summary>
		/// Название.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <exclude/>
		public Guid PreviousElementId {
			get {
				return GetTypedColumnValue<Guid>("PreviousElementId");
			}
			set {
				SetColumnValue("PreviousElementId", value);
				_previousElement = null;
			}
		}

		/// <exclude/>
		public string PreviousElementName {
			get {
				return GetTypedColumnValue<string>("PreviousElementName");
			}
			set {
				SetColumnValue("PreviousElementName", value);
				if (_previousElement != null) {
					_previousElement.Name = value;
				}
			}
		}

		private SupplyPaymentElement _previousElement;
		/// <summary>
		/// Предыдущий шаг.
		/// </summary>
		public SupplyPaymentElement PreviousElement {
			get {
				return _previousElement ??
					(_previousElement = LookupColumnEntities.GetEntity("PreviousElement") as SupplyPaymentElement);
			}
		}

		/// <exclude/>
		public Guid InvoiceId {
			get {
				return GetTypedColumnValue<Guid>("InvoiceId");
			}
			set {
				SetColumnValue("InvoiceId", value);
				_invoice = null;
			}
		}

		/// <exclude/>
		public string InvoiceNumber {
			get {
				return GetTypedColumnValue<string>("InvoiceNumber");
			}
			set {
				SetColumnValue("InvoiceNumber", value);
				if (_invoice != null) {
					_invoice.Number = value;
				}
			}
		}

		private Invoice _invoice;
		/// <summary>
		/// Счет.
		/// </summary>
		public Invoice Invoice {
			get {
				return _invoice ??
					(_invoice = LookupColumnEntities.GetEntity("Invoice") as Invoice);
			}
		}

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

		/// <summary>
		/// Сумма, план, б.в.
		/// </summary>
		public Decimal PrimaryAmountPlan {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmountPlan");
			}
			set {
				SetColumnValue("PrimaryAmountPlan", value);
			}
		}

		/// <summary>
		/// Сумма, факт, б.в.
		/// </summary>
		public Decimal PrimaryAmountFact {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmountFact");
			}
			set {
				SetColumnValue("PrimaryAmountFact", value);
			}
		}

		/// <summary>
		/// Продукты.
		/// </summary>
		public string Products {
			get {
				return GetTypedColumnValue<string>("Products");
			}
			set {
				SetColumnValue("Products", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new SupplyPaymentElement_PassportEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftDeleted", e);
			Inserting += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftSaving", e);
			Updated += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftUpdated", e);
			Validating += (s, e) => ThrowEvent("SupplyPaymentElement_Passport_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new SupplyPaymentElement_Passport_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentElement_PassportEventsProcess

	/// <exclude/>
	public partial class SupplyPaymentElement_PassportEventsProcess<TEntity> : BPMSoft.Configuration.SupplyPayment_PassportEventsProcess<TEntity> where TEntity : SupplyPaymentElement_Passport_BPMSoft
	{

		public SupplyPaymentElement_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "SupplyPaymentElement_PassportEventsProcess";
			SchemaUId = new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("28cc5afa-2b40-49e9-b516-ed35cbc4203e");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool DoNotUpdateLinkedElements {
			get;
			set;
		}

		public virtual bool NeedToUpdateInvoice {
			get;
			set;
		}

		public virtual bool NeedToUpdateOrderPaymentAmount {
			get;
			set;
		}

		public virtual bool IsInvoiceExists {
			get;
			set;
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("88d39c80-d385-4069-9ec4-30b36e97c5a9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _supplyPaymentElementSaved;
		public ProcessFlowElement SupplyPaymentElementSaved {
			get {
				return _supplyPaymentElementSaved ?? (_supplyPaymentElementSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SupplyPaymentElementSaved",
					SchemaElementUId = new Guid("55194912-0cee-4f96-9da6-fe041197c3f7"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptTask1;
		public ProcessScriptTask ScriptTask1 {
			get {
				return _scriptTask1 ?? (_scriptTask1 = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptTask1",
					SchemaElementUId = new Guid("5b1db116-ccdf-45eb-81f5-1506f4680f1c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess2;
		public ProcessFlowElement EventSubProcess2 {
			get {
				return _eventSubProcess2 ?? (_eventSubProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess2",
					SchemaElementUId = new Guid("a216c70e-29ed-4f63-84b3-7d65596d9a8b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _supplyPaymentElementSavingStartMessage;
		public ProcessFlowElement SupplyPaymentElementSavingStartMessage {
			get {
				return _supplyPaymentElementSavingStartMessage ?? (_supplyPaymentElementSavingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SupplyPaymentElementSavingStartMessage",
					SchemaElementUId = new Guid("56a05eca-743e-4d54-93d6-cca831c2cf98"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _checkInvoiceNeedUpdateScriptTask;
		public ProcessScriptTask CheckInvoiceNeedUpdateScriptTask {
			get {
				return _checkInvoiceNeedUpdateScriptTask ?? (_checkInvoiceNeedUpdateScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "CheckInvoiceNeedUpdateScriptTask",
					SchemaElementUId = new Guid("0ea07475-f856-4e3d-9b58-b6b745da3991"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = CheckInvoiceNeedUpdateScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _supplyPaymentElementDeletedEventSubProcess;
		public ProcessFlowElement SupplyPaymentElementDeletedEventSubProcess {
			get {
				return _supplyPaymentElementDeletedEventSubProcess ?? (_supplyPaymentElementDeletedEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SupplyPaymentElementDeletedEventSubProcess",
					SchemaElementUId = new Guid("e4bee66c-0ff7-42e7-9824-f214e0d3fb5e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _supplyPaymentElementDeletedStartMessage;
		public ProcessFlowElement SupplyPaymentElementDeletedStartMessage {
			get {
				return _supplyPaymentElementDeletedStartMessage ?? (_supplyPaymentElementDeletedStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SupplyPaymentElementDeletedStartMessage",
					SchemaElementUId = new Guid("1792cffb-b8de-44c5-b48e-1b23db8f8b95"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _onDeleteScriptTask;
		public ProcessScriptTask OnDeleteScriptTask {
			get {
				return _onDeleteScriptTask ?? (_onDeleteScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "OnDeleteScriptTask",
					SchemaElementUId = new Guid("1a4223a7-90ba-442c-9b5b-01688c42ef3c"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = OnDeleteScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess3_d7a18bd282c54b13836036d86a86368d;
		public ProcessFlowElement EventSubProcess3_d7a18bd282c54b13836036d86a86368d {
			get {
				return _eventSubProcess3_d7a18bd282c54b13836036d86a86368d ?? (_eventSubProcess3_d7a18bd282c54b13836036d86a86368d = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess3_d7a18bd282c54b13836036d86a86368d",
					SchemaElementUId = new Guid("d7a18bd2-82c5-4b13-8360-36d86a86368d"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _startMessage3_53d7f47c41274e0fb1ee96cc0619f7d2;
		public ProcessFlowElement StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2 {
			get {
				return _startMessage3_53d7f47c41274e0fb1ee96cc0619f7d2 ?? (_startMessage3_53d7f47c41274e0fb1ee96cc0619f7d2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2",
					SchemaElementUId = new Guid("53d7f47c-4127-4e0f-b1ee-96cc0619f7d2"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _updateSupplyPaymentInvoiceScriptTask;
		public ProcessScriptTask UpdateSupplyPaymentInvoiceScriptTask {
			get {
				return _updateSupplyPaymentInvoiceScriptTask ?? (_updateSupplyPaymentInvoiceScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "UpdateSupplyPaymentInvoiceScriptTask",
					SchemaElementUId = new Guid("09f2781c-5316-43ab-a946-23280be5e4c1"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = UpdateSupplyPaymentInvoiceScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SupplyPaymentElementSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentElementSaved };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[EventSubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess2 };
			FlowElements[SupplyPaymentElementSavingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentElementSavingStartMessage };
			FlowElements[CheckInvoiceNeedUpdateScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { CheckInvoiceNeedUpdateScriptTask };
			FlowElements[SupplyPaymentElementDeletedEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentElementDeletedEventSubProcess };
			FlowElements[SupplyPaymentElementDeletedStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SupplyPaymentElementDeletedStartMessage };
			FlowElements[OnDeleteScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { OnDeleteScriptTask };
			FlowElements[EventSubProcess3_d7a18bd282c54b13836036d86a86368d.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess3_d7a18bd282c54b13836036d86a86368d };
			FlowElements[StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2.SchemaElementUId] = new Collection<ProcessFlowElement> { StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2 };
			FlowElements[UpdateSupplyPaymentInvoiceScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { UpdateSupplyPaymentInvoiceScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "EventSubProcess1":
						break;
					case "SupplyPaymentElementSaved":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptTask1":
						break;
					case "EventSubProcess2":
						break;
					case "SupplyPaymentElementSavingStartMessage":
						e.Context.QueueTasks.Enqueue("CheckInvoiceNeedUpdateScriptTask");
						break;
					case "CheckInvoiceNeedUpdateScriptTask":
						break;
					case "SupplyPaymentElementDeletedEventSubProcess":
						break;
					case "SupplyPaymentElementDeletedStartMessage":
						e.Context.QueueTasks.Enqueue("OnDeleteScriptTask");
						break;
					case "OnDeleteScriptTask":
						break;
					case "EventSubProcess3_d7a18bd282c54b13836036d86a86368d":
						break;
					case "StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2":
						e.Context.QueueTasks.Enqueue("UpdateSupplyPaymentInvoiceScriptTask");
						break;
					case "UpdateSupplyPaymentInvoiceScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("SupplyPaymentElementSaved");
			ActivatedEventElements.Add("SupplyPaymentElementSavingStartMessage");
			ActivatedEventElements.Add("SupplyPaymentElementDeletedStartMessage");
			ActivatedEventElements.Add("StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SupplyPaymentElementSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "SupplyPaymentElementSaved";
					result = SupplyPaymentElementSaved.Execute(context);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "EventSubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "SupplyPaymentElementSavingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SupplyPaymentElementSavingStartMessage";
					result = SupplyPaymentElementSavingStartMessage.Execute(context);
					break;
				case "CheckInvoiceNeedUpdateScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "CheckInvoiceNeedUpdateScriptTask";
					result = CheckInvoiceNeedUpdateScriptTask.Execute(context, CheckInvoiceNeedUpdateScriptTaskExecute);
					break;
				case "SupplyPaymentElementDeletedEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "SupplyPaymentElementDeletedStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SupplyPaymentElementDeletedStartMessage";
					result = SupplyPaymentElementDeletedStartMessage.Execute(context);
					break;
				case "OnDeleteScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "OnDeleteScriptTask";
					result = OnDeleteScriptTask.Execute(context, OnDeleteScriptTaskExecute);
					break;
				case "EventSubProcess3_d7a18bd282c54b13836036d86a86368d":
					context.QueueTasks.Dequeue();
					break;
				case "StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2":
					context.QueueTasks.Dequeue();
					context.SenderName = "StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2";
					result = StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2.Execute(context);
					break;
				case "UpdateSupplyPaymentInvoiceScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "UpdateSupplyPaymentInvoiceScriptTask";
					result = UpdateSupplyPaymentInvoiceScriptTask.Execute(context, UpdateSupplyPaymentInvoiceScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			UpdateLinkedElements();
			OnSaved();
			return true;
		}

		public virtual bool CheckInvoiceNeedUpdateScriptTaskExecute(ProcessExecutingContext context) {
			CheckNeedToUpdateInvoice();
			return true;
		}

		public virtual bool OnDeleteScriptTaskExecute(ProcessExecutingContext context) {
			OnDeleted();
			return true;
		}

		public virtual bool UpdateSupplyPaymentInvoiceScriptTaskExecute(ProcessExecutingContext context) {
			Guid invoiceId = Entity.GetTypedColumnValue<Guid>("InvoiceId");
			Guid invoiceOldId = Entity.GetTypedOldColumnValue<Guid>("InvoiceId");
			if (invoiceId != invoiceOldId) {
				var orderPassportHelper = ClassFactory.Get<OrderPassportHelper>(new ConstructorArgument("userConnection", UserConnection));
				var orderAmountHelper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
				var supplyPaymentElementId = Entity.GetTypedColumnValue<Guid>("Id");
				if (IsInvoiceExists) {
					invoiceId = Entity.GetTypedColumnValue<Guid>("InvoiceId");
					orderPassportHelper.BindSupplyPaymentElementInvoice(supplyPaymentElementId, invoiceId);
				}
				else {
					invoiceId = Entity.GetTypedOldColumnValue<Guid>("InvoiceId");
					orderPassportHelper.UnbindSupplyPaymentElementInvoice(supplyPaymentElementId, invoiceOldId);
					orderAmountHelper.UpdateOrderPaymentAmountOnSPEChanged(Entity.PrimaryColumnValue);
				}
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "SupplyPaymentElement_Passport_BPMSoftSaved":
							if (ActivatedEventElements.Contains("SupplyPaymentElementSaved")) {
							context.QueueTasks.Enqueue("SupplyPaymentElementSaved");
						}
						break;
					case "SupplyPaymentElement_Passport_BPMSoftSaving":
							if (ActivatedEventElements.Contains("SupplyPaymentElementSavingStartMessage")) {
							context.QueueTasks.Enqueue("SupplyPaymentElementSavingStartMessage");
						}
						break;
					case "SupplyPaymentElement_Passport_BPMSoftDeleted":
							if (ActivatedEventElements.Contains("SupplyPaymentElementDeletedStartMessage")) {
							context.QueueTasks.Enqueue("SupplyPaymentElementDeletedStartMessage");
						}
						break;
					case "SupplyPaymentElement_Passport_BPMSoftUpdated":
							if (ActivatedEventElements.Contains("StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2")) {
							context.QueueTasks.Enqueue("StartMessage3_53d7f47c41274e0fb1ee96cc0619f7d2");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: SupplyPaymentElement_PassportEventsProcess

	/// <exclude/>
	public class SupplyPaymentElement_PassportEventsProcess : SupplyPaymentElement_PassportEventsProcess<SupplyPaymentElement_Passport_BPMSoft>
	{

		public SupplyPaymentElement_PassportEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: SupplyPaymentElement_PassportEventsProcess

	public partial class SupplyPaymentElement_PassportEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual void UpdateLinkedElements() {
			var passportHelper = ClassFactory.Get<OrderPassportHelper>(new ConstructorArgument("userConnection", UserConnection));
			passportHelper.UpdateLinkedElements(Entity);
		}

		public virtual void CheckNeedToUpdateInvoice() {
			List<string> changedColumnNames = Entity.GetChangedColumnValues().ToList().ConvertAll(cv => cv.Column.Name);
			IsInvoiceExists = Entity.GetTypedColumnValue<Guid>("InvoiceId") != Guid.Empty;
			NeedToUpdateInvoice = IsInvoiceExists && changedColumnNames.Any(c => c == "PrimaryAmountPlan");
			NeedToUpdateOrderPaymentAmount = changedColumnNames.Any(c => c == "PrimaryAmountFact");
		}

		public virtual void OnDeleted() {
			var orderAmountHelper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
			orderAmountHelper.UpdateOrderPaymentAmountOnSupplyPaymentElementDeleted(Entity.GetTypedColumnValue<Guid>("OrderId"));
		}

		public virtual void OnSaved() {
			var orderAmountHelper = ClassFactory.Get<OrderAmountHelper>(new ConstructorArgument("userConnection", UserConnection));
			if (NeedToUpdateInvoice) {
				EntitySchemaColumn invoiceColumn = Entity.Schema.Columns.GetByName("Invoice");
				if (!Entity.GetIsColumnValueLoaded(invoiceColumn) || Entity.GetTypedColumnValue<Guid>(invoiceColumn) != Guid.Empty) {
					orderAmountHelper.UpdateInvoiceBySupplyPaymentElementId(Entity.PrimaryColumnValue);
				}
			}
			if (NeedToUpdateOrderPaymentAmount) {
				orderAmountHelper.UpdateOrderPaymentAmountOnSPEChanged(Entity.PrimaryColumnValue);
			}
		}

		#endregion

	}

	#endregion

}

