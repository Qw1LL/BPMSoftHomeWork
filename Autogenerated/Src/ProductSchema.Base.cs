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

	#region Class: Product_Base_BPMSoftSchema

	/// <exclude/>
	public class Product_Base_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Product_Base_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Product_Base_BPMSoftSchema(Product_Base_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Product_Base_BPMSoftSchema(Product_Base_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			RealUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			Name = "Product_Base_BPMSoft";
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

		protected override void InitializeOwnerColumn() {
			base.InitializeOwnerColumn();
			OwnerColumn = CreateOwnerColumn();
			if (Columns.FindByUId(OwnerColumn.UId) == null) {
				Columns.Add(OwnerColumn);
			}
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("2e1f4643-a44a-415e-8c4c-79283dc3d1d9")) == null) {
				Columns.Add(CreateCodeColumn());
			}
			if (Columns.FindByUId(new Guid("e485abc9-4cc0-48ba-a8e6-76a6dd2ea222")) == null) {
				Columns.Add(CreateUnitColumn());
			}
			if (Columns.FindByUId(new Guid("e241007b-18ad-4411-a6fb-caf56fdaa941")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("ab19483e-bd98-4b76-9565-56f7e309758b")) == null) {
				Columns.Add(CreatePriceColumn());
			}
			if (Columns.FindByUId(new Guid("51a20224-e62d-4198-b3e5-354d46e68af8")) == null) {
				Columns.Add(CreateTaxColumn());
			}
			if (Columns.FindByUId(new Guid("6cd88fbf-2355-45f8-8c8a-8e6308a77b96")) == null) {
				Columns.Add(CreateURLColumn());
			}
			if (Columns.FindByUId(new Guid("ac574603-a4db-410c-877d-e383c0a6c51a")) == null) {
				Columns.Add(CreateTypeColumn());
			}
			if (Columns.FindByUId(new Guid("b4687e9c-060d-4f9b-8367-b8ed66af0ada")) == null) {
				Columns.Add(CreateActiveColumn());
			}
			if (Columns.FindByUId(new Guid("75b2a101-2a27-4911-a5c0-d4f7c724914d")) == null) {
				Columns.Add(CreateDescriptionColumn());
			}
			if (Columns.FindByUId(new Guid("ae5ef7d5-1044-477f-affb-83bce9e65bbd")) == null) {
				Columns.Add(CreateProductSourceColumn());
			}
			if (Columns.FindByUId(new Guid("4c9ed783-148c-41eb-92dd-5975dcfbdcd1")) == null) {
				Columns.Add(CreateNotesColumn());
			}
		}

		protected virtual EntitySchemaColumn CreateNameColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("e3040d2d-93ff-4528-a4b7-42603e08bdcf"),
				Name = @"Name",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateCodeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("ShortText")) {
				UId = new Guid("2e1f4643-a44a-415e-8c4c-79283dc3d1d9"),
				Name = @"Code",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateUnitColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e485abc9-4cc0-48ba-a8e6-76a6dd2ea222"),
				Name = @"Unit",
				ReferenceSchemaUId = new Guid("38f2220e-7085-494d-b4c9-396666b6327b"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("e241007b-18ad-4411-a6fb-caf56fdaa941"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePriceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("ab19483e-bd98-4b76-9565-56f7e309758b"),
				Name = @"Price",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTaxColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("51a20224-e62d-4198-b3e5-354d46e68af8"),
				Name = @"Tax",
				ReferenceSchemaUId = new Guid("a32b5f57-0ef1-4d3d-a6ef-a6de2113fbe0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateURLColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Text")) {
				UId = new Guid("6cd88fbf-2355-45f8-8c8a-8e6308a77b96"),
				Name = @"URL",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateTypeColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ac574603-a4db-410c-877d-e383c0a6c51a"),
				Name = @"Type",
				ReferenceSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateActiveColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("b4687e9c-060d-4f9b-8367-b8ed66af0ada"),
				Name = @"Active",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"True"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b2030ccd-1270-4bed-ac8b-4ebf4cfda0d1"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateDescriptionColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("75b2a101-2a27-4911-a5c0-d4f7c724914d"),
				Name = @"Description",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsLocalizable = true
			};
		}

		protected virtual EntitySchemaColumn CreateProductSourceColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("ae5ef7d5-1044-477f-affb-83bce9e65bbd"),
				Name = @"ProductSource",
				ReferenceSchemaUId = new Guid("a79d250f-fc72-4137-9bc2-4b7fe51429b0"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"5facb8b4-ed6a-41bb-b224-659c2bf1eb8a"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("4c9ed783-148c-41eb-92dd-5975dcfbdcd1"),
				Name = @"Notes",
				CreatedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				ModifiedInSchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				IsMultiLineText = true,
				IsLocalizable = true
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Product_Base_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Product_BaseEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Product_Base_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Product_Base_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed"));
		}

		#endregion

	}

	#endregion

	#region Class: Product_Base_BPMSoft

	/// <summary>
	/// Product.
	/// </summary>
	public class Product_Base_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Product_Base_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Product_Base_BPMSoft";
		}

		public Product_Base_BPMSoft(Product_Base_BPMSoft source)
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
		/// Code.
		/// </summary>
		public string Code {
			get {
				return GetTypedColumnValue<string>("Code");
			}
			set {
				SetColumnValue("Code", value);
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

		/// <exclude/>
		public Guid CurrencyId {
			get {
				return GetTypedColumnValue<Guid>("CurrencyId");
			}
			set {
				SetColumnValue("CurrencyId", value);
				_currency = null;
			}
		}

		/// <exclude/>
		public string CurrencyName {
			get {
				return GetTypedColumnValue<string>("CurrencyName");
			}
			set {
				SetColumnValue("CurrencyName", value);
				if (_currency != null) {
					_currency.Name = value;
				}
			}
		}

		private Currency _currency;
		/// <summary>
		/// Currency.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
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
		/// Link.
		/// </summary>
		public string URL {
			get {
				return GetTypedColumnValue<string>("URL");
			}
			set {
				SetColumnValue("URL", value);
			}
		}

		/// <exclude/>
		public Guid TypeId {
			get {
				return GetTypedColumnValue<Guid>("TypeId");
			}
			set {
				SetColumnValue("TypeId", value);
				_type = null;
			}
		}

		/// <exclude/>
		public string TypeName {
			get {
				return GetTypedColumnValue<string>("TypeName");
			}
			set {
				SetColumnValue("TypeName", value);
				if (_type != null) {
					_type.Name = value;
				}
			}
		}

		private ProductType _type;
		/// <summary>
		/// Type.
		/// </summary>
		public ProductType Type {
			get {
				return _type ??
					(_type = LookupColumnEntities.GetEntity("Type") as ProductType);
			}
		}

		/// <summary>
		/// Active.
		/// </summary>
		public bool Active {
			get {
				return GetTypedColumnValue<bool>("Active");
			}
			set {
				SetColumnValue("Active", value);
			}
		}

		/// <exclude/>
		public Guid OwnerId {
			get {
				return GetTypedColumnValue<Guid>("OwnerId");
			}
			set {
				SetColumnValue("OwnerId", value);
				_owner = null;
			}
		}

		/// <exclude/>
		public string OwnerName {
			get {
				return GetTypedColumnValue<string>("OwnerName");
			}
			set {
				SetColumnValue("OwnerName", value);
				if (_owner != null) {
					_owner.Name = value;
				}
			}
		}

		private Contact _owner;
		/// <summary>
		/// Owner.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <summary>
		/// Description.
		/// </summary>
		public string Description {
			get {
				return GetTypedColumnValue<string>("Description");
			}
			set {
				SetColumnValue("Description", value);
			}
		}

		/// <exclude/>
		public Guid ProductSourceId {
			get {
				return GetTypedColumnValue<Guid>("ProductSourceId");
			}
			set {
				SetColumnValue("ProductSourceId", value);
				_productSource = null;
			}
		}

		/// <exclude/>
		public string ProductSourceName {
			get {
				return GetTypedColumnValue<string>("ProductSourceName");
			}
			set {
				SetColumnValue("ProductSourceName", value);
				if (_productSource != null) {
					_productSource.Name = value;
				}
			}
		}

		private ProductSource _productSource;
		/// <summary>
		/// Product source.
		/// </summary>
		public ProductSource ProductSource {
			get {
				return _productSource ??
					(_productSource = LookupColumnEntities.GetEntity("ProductSource") as ProductSource);
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

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Product_BaseEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Product_Base_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Product_Base_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Product_Base_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Product_Base_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Product_Base_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Product_Base_BPMSoftSaving", e);
			Updating += (s, e) => ThrowEvent("Product_Base_BPMSoftUpdating", e);
			Validating += (s, e) => ThrowEvent("Product_Base_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Product_Base_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Product_BaseEventsProcess

	/// <exclude/>
	public partial class Product_BaseEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Product_Base_BPMSoft
	{

		public Product_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Product_BaseEventsProcess";
			SchemaUId = new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("4c7a6ead-4eb8-4fc0-863e-98a664569fed");
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

	#region Class: Product_BaseEventsProcess

	/// <exclude/>
	public class Product_BaseEventsProcess : Product_BaseEventsProcess<Product_Base_BPMSoft>
	{

		public Product_BaseEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Product_BaseEventsProcess

	public partial class Product_BaseEventsProcess<TEntity>
	{

		#region Methods: Public

		#endregion

	}

	#endregion

}

