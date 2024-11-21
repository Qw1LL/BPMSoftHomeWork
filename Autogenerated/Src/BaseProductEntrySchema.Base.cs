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

	#region Class: BaseProductEntry_Base_BPMSoftSchema

	/// <exclude/>
	[IsVirtual]
	public class BaseProductEntry_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public BaseProductEntry_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public BaseProductEntry_Base_BPMSoftSchema(BaseProductEntry_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public BaseProductEntry_Base_BPMSoftSchema(BaseProductEntry_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			RealUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			Name = "BaseProductEntry_Base_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
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

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("369b4363-6804-473b-92a5-4ee233772082")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("a977122d-8f0c-49be-a0ce-bb9faf81bdc6")) == null) {
				Columns.Add(CreateProductColumn());
			}
			if (Columns.FindByUId(new Guid("237ca70c-b45e-46e8-a8eb-67e30584af32")) == null) {
				Columns.Add(CreateCustomProductColumn());
			}
			if (Columns.FindByUId(new Guid("5db18b1c-a7b8-4bd2-bb00-60e6f3663da3")) == null) {
				Columns.Add(CreateDeliveryDateColumn());
			}
			if (Columns.FindByUId(new Guid("c4e45448-ad41-4fc8-9c8b-904790d003ff")) == null) {
				Columns.Add(CreateQuantityColumn());
			}
			if (Columns.FindByUId(new Guid("d7fe119a-a831-4c2a-ba74-bdab58857363")) == null) {
				Columns.Add(CreateUnitColumn());
			}
			if (Columns.FindByUId(new Guid("39182ce0-41eb-4f71-bf55-1deb88489688")) == null) {
				Columns.Add(CreatePrimaryPriceColumn());
			}
			if (Columns.FindByUId(new Guid("1835d8c5-7687-4bad-a4a7-b6a4fbf45948")) == null) {
				Columns.Add(CreatePriceColumn());
			}
			if (Columns.FindByUId(new Guid("7ad56546-758e-4f32-bfe4-b96ac8b48d1f")) == null) {
				Columns.Add(CreatePrimaryAmountColumn());
			}
			if (Columns.FindByUId(new Guid("fcc86ad4-073f-4450-baab-abfa226b9e0a")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("08d936ff-1b7e-4a67-af92-2a870180ac9d")) == null) {
				Columns.Add(CreatePrimaryDiscountAmountColumn());
			}
			if (Columns.FindByUId(new Guid("68ea19d8-502b-4732-83a6-a959bcf3eea7")) == null) {
				Columns.Add(CreateDiscountAmountColumn());
			}
			if (Columns.FindByUId(new Guid("17e259cd-0063-46df-8cee-20bb4e2aad8b")) == null) {
				Columns.Add(CreateDiscountPercentColumn());
			}
			if (Columns.FindByUId(new Guid("d833bc97-8f18-416f-aef1-f7218abb2e0d")) == null) {
				Columns.Add(CreateTaxColumn());
			}
			if (Columns.FindByUId(new Guid("04a9e624-8638-48b3-ad41-100a8fd583f9")) == null) {
				Columns.Add(CreatePrimaryTaxAmountColumn());
			}
			if (Columns.FindByUId(new Guid("adb28cb7-3d76-4c93-a54f-97a4c6089946")) == null) {
				Columns.Add(CreateTaxAmountColumn());
			}
			if (Columns.FindByUId(new Guid("16c14cc8-459b-408d-bcc1-8b6c29efb26f")) == null) {
				Columns.Add(CreatePrimaryTotalAmountColumn());
			}
			if (Columns.FindByUId(new Guid("c97c6457-a800-472d-908b-991e63b65b05")) == null) {
				Columns.Add(CreateTotalAmountColumn());
			}
			if (Columns.FindByUId(new Guid("9db15d13-6c10-4818-8e1f-fcb55974c83e")) == null) {
				Columns.Add(CreateDiscountTaxColumn());
			}
			if (Columns.FindByUId(new Guid("f6e0a8f0-6eb4-4496-a092-b229cf31a6d6")) == null) {
				Columns.Add(CreateBaseQuantityColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("037591ee-fc21-4788-9b2e-a005dd21882d"),
				Name = @"Name",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("369b4363-6804-473b-92a5-4ee233772082"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("a977122d-8f0c-49be-a0ce-bb9faf81bdc6"),
				Name = @"Product",
				ReferenceSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCustomProductColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("237ca70c-b45e-46e8-a8eb-67e30584af32"),
				Name = @"CustomProduct",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDeliveryDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("5db18b1c-a7b8-4bd2-bb00-60e6f3663da3"),
				Name = @"DeliveryDate",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("c4e45448-ad41-4fc8-9c8b-904790d003ff"),
				Name = @"Quantity",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d7fe119a-a831-4c2a-ba74-bdab58857363"),
				Name = @"Unit",
				ReferenceSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("39182ce0-41eb-4f71-bf55-1deb88489688"),
				Name = @"PrimaryPrice",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("1835d8c5-7687-4bad-a4a7-b6a4fbf45948"),
				Name = @"Price",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("7ad56546-758e-4f32-bfe4-b96ac8b48d1f"),
				Name = @"PrimaryAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("fcc86ad4-073f-4450-baab-abfa226b9e0a"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryDiscountAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("08d936ff-1b7e-4a67-af92-2a870180ac9d"),
				Name = @"PrimaryDiscountAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscountAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("68ea19d8-502b-4732-83a6-a959bcf3eea7"),
				Name = @"DiscountAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscountPercentColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("17e259cd-0063-46df-8cee-20bb4e2aad8b"),
				Name = @"DiscountPercent",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d833bc97-8f18-416f-aef1-f7218abb2e0d"),
				Name = @"Tax",
				ReferenceSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryTaxAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("04a9e624-8638-48b3-ad41-100a8fd583f9"),
				Name = @"PrimaryTaxAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTaxAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("adb28cb7-3d76-4c93-a54f-97a4c6089946"),
				Name = @"TaxAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryTotalAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("16c14cc8-459b-408d-bcc1-8b6c29efb26f"),
				Name = @"PrimaryTotalAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTotalAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("c97c6457-a800-472d-908b-991e63b65b05"),
				Name = @"TotalAmount",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDiscountTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float2")) {
				UId = new Guid("9db15d13-6c10-4818-8e1f-fcb55974c83e"),
				Name = @"DiscountTax",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateBaseQuantityColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float3")) {
				UId = new Guid("f6e0a8f0-6eb4-4496-a092-b229cf31a6d6"),
				Name = @"BaseQuantity",
				CreatedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				ModifiedInSchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"),
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new BaseProductEntry_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new BaseProductEntry_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new BaseProductEntry_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new BaseProductEntry_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04802832-e447-4188-a324-f2d1ca6efcc4"));
		}

		#endregion

	}

	#endregion

	#region Class: BaseProductEntry_Base_BPMSoft

	/// <summary>
	/// Base product in item.
	/// </summary>
	public class BaseProductEntry_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public BaseProductEntry_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "BaseProductEntry_Base_BPMSoft";
		}

		public BaseProductEntry_Base_BPMSoft(BaseProductEntry_Base_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Name.
		/// </summary>
		public string Name {
			get {
				return GetTypedColumnValue<string>("Name");
			}
			set {
				SetColumnValue("Name", value);
			}
		}

		/// <summary>
		/// Notes.
		/// </summary>
		public string Notes {
			get {
				return GetTypedColumnValue<string>("Notes");
			}
			set {
				SetColumnValue("Notes", value);
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

		private Product _product;
		/// <summary>
		/// Product.
		/// </summary>
		public Product Product {
			get {
				return _product ??
					(_product = LookupColumnEntities.GetEntity("Product") as Product);
			}
		}

		/// <summary>
		/// Custom product.
		/// </summary>
		public string CustomProduct {
			get {
				return GetTypedColumnValue<string>("CustomProduct");
			}
			set {
				SetColumnValue("CustomProduct", value);
			}
		}

		/// <summary>
		/// Delivered on.
		/// </summary>
		public DateTime DeliveryDate {
			get {
				return GetTypedColumnValue<DateTime>("DeliveryDate");
			}
			set {
				SetColumnValue("DeliveryDate", value);
			}
		}

		/// <summary>
		/// Quantity.
		/// </summary>
		public Decimal Quantity {
			get {
				return GetTypedColumnValue<Decimal>("Quantity");
			}
			set {
				SetColumnValue("Quantity", value);
			}
		}

		/// <exclude/>
		public Guid UnitId {
			get {
				return GetTypedColumnValue<Guid>("UnitId");
			}
			set {
				SetColumnValue("UnitId", value);
				_unit = null;
			}
		}

		/// <exclude/>
		public string UnitName {
			get {
				return GetTypedColumnValue<string>("UnitName");
			}
			set {
				SetColumnValue("UnitName", value);
				if (_unit != null) {
					_unit.Name = value;
				}
			}
		}

		private Unit _unit;
		/// <summary>
		/// Unit of measure.
		/// </summary>
		public Unit Unit {
			get {
				return _unit ??
					(_unit = LookupColumnEntities.GetEntity("Unit") as Unit);
			}
		}

		/// <summary>
		/// Price, base currency.
		/// </summary>
		public Decimal PrimaryPrice {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPrice");
			}
			set {
				SetColumnValue("PrimaryPrice", value);
			}
		}

		/// <summary>
		/// Price.
		/// </summary>
		public Decimal Price {
			get {
				return GetTypedColumnValue<Decimal>("Price");
			}
			set {
				SetColumnValue("Price", value);
			}
		}

		/// <summary>
		/// Amount, base currency.
		/// </summary>
		public Decimal PrimaryAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryAmount");
			}
			set {
				SetColumnValue("PrimaryAmount", value);
			}
		}

		/// <summary>
		/// Amount.
		/// </summary>
		public Decimal Amount {
			get {
				return GetTypedColumnValue<Decimal>("Amount");
			}
			set {
				SetColumnValue("Amount", value);
			}
		}

		/// <summary>
		/// Discount amount, base currency.
		/// </summary>
		public Decimal PrimaryDiscountAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryDiscountAmount");
			}
			set {
				SetColumnValue("PrimaryDiscountAmount", value);
			}
		}

		/// <summary>
		/// Discount amount.
		/// </summary>
		public Decimal DiscountAmount {
			get {
				return GetTypedColumnValue<Decimal>("DiscountAmount");
			}
			set {
				SetColumnValue("DiscountAmount", value);
			}
		}

		/// <summary>
		/// Discount, %.
		/// </summary>
		public Decimal DiscountPercent {
			get {
				return GetTypedColumnValue<Decimal>("DiscountPercent");
			}
			set {
				SetColumnValue("DiscountPercent", value);
			}
		}

		/// <exclude/>
		public Guid TaxId {
			get {
				return GetTypedColumnValue<Guid>("TaxId");
			}
			set {
				SetColumnValue("TaxId", value);
				_tax = null;
			}
		}

		/// <exclude/>
		public string TaxName {
			get {
				return GetTypedColumnValue<string>("TaxName");
			}
			set {
				SetColumnValue("TaxName", value);
				if (_tax != null) {
					_tax.Name = value;
				}
			}
		}

		private Tax _tax;
		/// <summary>
		/// Tax.
		/// </summary>
		public Tax Tax {
			get {
				return _tax ??
					(_tax = LookupColumnEntities.GetEntity("Tax") as Tax);
			}
		}

		/// <summary>
		/// Tax amount, base currency.
		/// </summary>
		public Decimal PrimaryTaxAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryTaxAmount");
			}
			set {
				SetColumnValue("PrimaryTaxAmount", value);
			}
		}

		/// <summary>
		/// Tax amount.
		/// </summary>
		public Decimal TaxAmount {
			get {
				return GetTypedColumnValue<Decimal>("TaxAmount");
			}
			set {
				SetColumnValue("TaxAmount", value);
			}
		}

		/// <summary>
		/// Total, base currency.
		/// </summary>
		public Decimal PrimaryTotalAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryTotalAmount");
			}
			set {
				SetColumnValue("PrimaryTotalAmount", value);
			}
		}

		/// <summary>
		/// Total.
		/// </summary>
		public Decimal TotalAmount {
			get {
				return GetTypedColumnValue<Decimal>("TotalAmount");
			}
			set {
				SetColumnValue("TotalAmount", value);
			}
		}

		/// <summary>
		/// Tax %.
		/// </summary>
		public Decimal DiscountTax {
			get {
				return GetTypedColumnValue<Decimal>("DiscountTax");
			}
			set {
				SetColumnValue("DiscountTax", value);
			}
		}

		/// <summary>
		/// Quantity, base units.
		/// </summary>
		public Decimal BaseQuantity {
			get {
				return GetTypedColumnValue<Decimal>("BaseQuantity");
			}
			set {
				SetColumnValue("BaseQuantity", value);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new BaseProductEntry_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("BaseProductEntry_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new BaseProductEntry_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: BaseProductEntry_BaseEventsProcess

	/// <exclude/>
	public partial class BaseProductEntry_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : BaseProductEntry_Base_BPMSoft
	{

		public BaseProductEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "BaseProductEntry_BaseEventsProcess";
			SchemaUId = new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("04802832-e447-4188-a324-f2d1ca6efcc4");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		private Decimal _currencyRate = 1m;
		public Decimal CurrencyRate {
			get {
				return _currencyRate;
			}
			set {
				_currencyRate = value;
			}
		}

		private ProcessFlowElement _baseProductEntrySavingEventSubProcess;
		public ProcessFlowElement BaseProductEntrySavingEventSubProcess {
			get {
				return _baseProductEntrySavingEventSubProcess ?? (_baseProductEntrySavingEventSubProcess = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "BaseProductEntrySavingEventSubProcess",
					SchemaElementUId = new Guid("384d7162-c2b6-4f45-aab6-de156c5af932"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _baseProductEntrySaving;
		public ProcessFlowElement BaseProductEntrySaving {
			get {
				return _baseProductEntrySaving ?? (_baseProductEntrySaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "BaseProductEntrySaving",
					SchemaElementUId = new Guid("f54d58ea-ff7d-4003-9066-cb008f56be3a"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _baseProductEntrySavingScriptTask;
		public ProcessScriptTask BaseProductEntrySavingScriptTask {
			get {
				return _baseProductEntrySavingScriptTask ?? (_baseProductEntrySavingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "BaseProductEntrySavingScriptTask",
					SchemaElementUId = new Guid("2f934caf-eb61-4f6f-993c-80a28f7161ed"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = BaseProductEntrySavingScriptTaskExecute,
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[BaseProductEntrySavingEventSubProcess.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseProductEntrySavingEventSubProcess };
			FlowElements[BaseProductEntrySaving.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseProductEntrySaving };
			FlowElements[BaseProductEntrySavingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { BaseProductEntrySavingScriptTask };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "BaseProductEntrySavingEventSubProcess":
						break;
					case "BaseProductEntrySaving":
						e.Context.QueueTasks.Enqueue("BaseProductEntrySavingScriptTask");
						break;
					case "BaseProductEntrySavingScriptTask":
						break;
			}
			ProcessQueue(e.Context);
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("BaseProductEntrySaving");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "BaseProductEntrySavingEventSubProcess":
					context.QueueTasks.Dequeue();
					break;
				case "BaseProductEntrySaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseProductEntrySaving";
					result = BaseProductEntrySaving.Execute(context);
					break;
				case "BaseProductEntrySavingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "BaseProductEntrySavingScriptTask";
					result = BaseProductEntrySavingScriptTask.Execute(context, BaseProductEntrySavingScriptTaskExecute);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool BaseProductEntrySavingScriptTaskExecute(ProcessExecutingContext context) {
			UpdatePrimaryAmounts();
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "BaseProductEntry_Base_BPMSoftSaving":
							if (ActivatedEventElements.Contains("BaseProductEntrySaving")) {
							context.QueueTasks.Enqueue("BaseProductEntrySaving");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: BaseProductEntry_BaseEventsProcess

	/// <exclude/>
	public class BaseProductEntry_BaseEventsProcess : BaseProductEntry_BaseEventsProcess<BaseProductEntry_Base_BPMSoft>
	{

		public BaseProductEntry_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: BaseProductEntry_BaseEventsProcess

	public partial class BaseProductEntry_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual decimal Division(decimal arg1, decimal arg2) {
			decimal result = 0;
			if (arg2 > 0) {
				result = arg1 / arg2;
			}
			return result;
		}

		public virtual decimal Multiply(decimal arg1, decimal arg2) {
			var result = arg1* arg2;
			return result;
		}

		public virtual void UpdatePrimaryAmounts() {
			decimal price = this.Entity.GetTypedColumnValue<decimal>("Price");
			decimal amount = this.Entity.GetTypedColumnValue<decimal>("Amount");
			decimal discountAmount = this.Entity.GetTypedColumnValue<decimal>("DiscountAmount");
			decimal taxAmount  = this.Entity.GetTypedColumnValue<decimal>("TaxAmount");
			decimal totalAmount  = this.Entity.GetTypedColumnValue<decimal>("TotalAmount");
			this.Entity.SetColumnValue("PrimaryPrice", Division(price, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryAmount", Division(amount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryDiscountAmount", Division(discountAmount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryTaxAmount", Division(taxAmount, CurrencyRate));
			this.Entity.SetColumnValue("PrimaryTotalAmount", Division(totalAmount, CurrencyRate));
		}

		#endregion

	}

	#endregion

}

