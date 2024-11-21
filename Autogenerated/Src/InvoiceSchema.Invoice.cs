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

	#region Class: Invoice_Invoice_BPMSoftSchema

	/// <exclude/>
	public class Invoice_Invoice_BPMSoftSchema : BPMSoft.Configuration.BaseEntitySchema
	{

		#region Constructors: Public

		public Invoice_Invoice_BPMSoftSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public Invoice_Invoice_BPMSoftSchema(Invoice_Invoice_BPMSoftSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public Invoice_Invoice_BPMSoftSchema(Invoice_Invoice_BPMSoftSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			RealUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			Name = "Invoice_Invoice_BPMSoft";
			ParentSchemaUId = new Guid("1bab9dcf-17d5-49f8-9536-8e0064f1dce0");
			ExtendParent = false;
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializePrimaryDisplayColumn() {
			base.InitializePrimaryDisplayColumn();
			PrimaryDisplayColumn = CreateNumberColumn();
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
			if (Columns.FindByUId(new Guid("60364b7c-e7c4-43e3-81bf-5899e49a01aa")) == null) {
				Columns.Add(CreateStartDateColumn());
			}
			if (Columns.FindByUId(new Guid("420f8d90-f6b1-4140-81b8-53e1f39d1379")) == null) {
				Columns.Add(CreatePrimaryAmountColumn());
			}
			if (Columns.FindByUId(new Guid("76ec81f5-b0ea-4a33-a4bc-eddd91d0dcca")) == null) {
				Columns.Add(CreatePrimaryPaymentAmountColumn());
			}
			if (Columns.FindByUId(new Guid("77ce961a-530c-49f1-a1f9-981cda246cb9")) == null) {
				Columns.Add(CreatePaymentStatusColumn());
			}
			if (Columns.FindByUId(new Guid("dcf334e9-8a73-430b-ab97-17d9b9de64a3")) == null) {
				Columns.Add(CreateSupplierBillingInfoColumn());
			}
			if (Columns.FindByUId(new Guid("2a25b353-2d85-4ce6-b26e-894b514369ff")) == null) {
				Columns.Add(CreateRemindToOwnerColumn());
			}
			if (Columns.FindByUId(new Guid("e96ea96f-dc5d-4164-b182-e227978ac6e2")) == null) {
				Columns.Add(CreateRemindToOwnerDateColumn());
			}
			if (Columns.FindByUId(new Guid("8c7dd99b-d5c2-4cb5-ab16-84e1d0332ed6")) == null) {
				Columns.Add(CreateCustomerBillingInfoColumn());
			}
			if (Columns.FindByUId(new Guid("d7d9c859-18ad-408d-96ef-5a9f3090c168")) == null) {
				Columns.Add(CreateCurrencyColumn());
			}
			if (Columns.FindByUId(new Guid("734583ef-459f-45f5-9e5e-a1808e435fcf")) == null) {
				Columns.Add(CreateCurrencyRateColumn());
			}
			if (Columns.FindByUId(new Guid("ec9d2333-9e2d-4f70-b831-5be130a4b4ac")) == null) {
				Columns.Add(CreateAmountColumn());
			}
			if (Columns.FindByUId(new Guid("0d587626-2ccb-45e2-b582-27815c74f835")) == null) {
				Columns.Add(CreateDueDateColumn());
			}
			if (Columns.FindByUId(new Guid("07547348-9989-4367-9325-b1fa3281bf78")) == null) {
				Columns.Add(CreatePaymentAmountColumn());
			}
			if (Columns.FindByUId(new Guid("7c5a1586-bac8-433c-adda-30e45d8a71a4")) == null) {
				Columns.Add(CreateNotesColumn());
			}
			if (Columns.FindByUId(new Guid("b52f52a0-c983-4477-a4c3-6127cb052db4")) == null) {
				Columns.Add(CreateAccountColumn());
			}
			if (Columns.FindByUId(new Guid("8cf3941e-8061-42b9-80fa-d7936b228e84")) == null) {
				Columns.Add(CreateContactColumn());
			}
			if (Columns.FindByUId(new Guid("2d36486c-1e97-434d-82f8-aed0e3162d8f")) == null) {
				Columns.Add(CreateSupplierColumn());
			}
		}

		protected override EntitySchemaColumn CreateIdColumn() {
			EntitySchemaColumn column = base.CreateIdColumn();
			column.ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedOnColumn() {
			EntitySchemaColumn column = base.CreateCreatedOnColumn();
			column.ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			return column;
		}

		protected override EntitySchemaColumn CreateCreatedByColumn() {
			EntitySchemaColumn column = base.CreateCreatedByColumn();
			column.ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedOnColumn() {
			EntitySchemaColumn column = base.CreateModifiedOnColumn();
			column.ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			return column;
		}

		protected override EntitySchemaColumn CreateModifiedByColumn() {
			EntitySchemaColumn column = base.CreateModifiedByColumn();
			column.ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			return column;
		}

		protected virtual EntitySchemaColumn CreateNumberColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MediumText")) {
				UId = new Guid("fdd77a82-fa25-4c0f-94d6-56cf0254521f"),
				Name = @"Number",
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateStartDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("60364b7c-e7c4-43e3-81bf-5899e49a01aa"),
				Name = @"StartDate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentDate")
				}
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("420f8d90-f6b1-4140-81b8-53e1f39d1379"),
				Name = @"PrimaryAmount",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePrimaryPaymentAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("76ec81f5-b0ea-4a33-a4bc-eddd91d0dcca"),
				Name = @"PrimaryPaymentAmount",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentStatusColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("77ce961a-530c-49f1-a1f9-981cda246cb9"),
				Name = @"PaymentStatus",
				ReferenceSchemaUId = new Guid("4a75f63d-e1b2-453b-a19d-fe614c158861"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsValueCloneable = false,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"InvoicePaymentStatusDef"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("c3d2e53a-5062-4930-adac-7cbcd9d3f58c"),
				Name = @"Owner",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.SystemValue,
					ValueSource = SystemValueManager.GetInstanceByName(@"CurrentUserContact")
				}
			};
		}

		protected virtual EntitySchemaColumn CreateSupplierBillingInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("dcf334e9-8a73-430b-ab97-17d9b9de64a3"),
				Name = @"SupplierBillingInfo",
				ReferenceSchemaUId = new Guid("4f0e44ce-343c-45b6-ae14-ff0533d4add9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToOwnerColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Boolean")) {
				UId = new Guid("2a25b353-2d85-4ce6-b26e-894b514369ff"),
				Name = @"RemindToOwner",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateRemindToOwnerDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("DateTime")) {
				UId = new Guid("e96ea96f-dc5d-4164-b182-e227978ac6e2"),
				Name = @"RemindToOwnerDate",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCustomerBillingInfoColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8c7dd99b-d5c2-4cb5-ab16-84e1d0332ed6"),
				Name = @"CustomerBillingInfo",
				ReferenceSchemaUId = new Guid("4f0e44ce-343c-45b6-ae14-ff0533d4add9"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("d7d9c859-18ad-408d-96ef-5a9f3090c168"),
				Name = @"Currency",
				ReferenceSchemaUId = new Guid("2d36aca6-5b8c-4122-9648-baf3b7f8256d"),
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Settings,
					ValueSource = @"PrimaryCurrency"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateCurrencyRateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Float8")) {
				UId = new Guid("734583ef-459f-45f5-9e5e-a1808e435fcf"),
				Name = @"CurrencyRate",
				RequirementType = EntitySchemaColumnRequirementType.ApplicationLevel,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"1"
				}
			};
		}

		protected virtual EntitySchemaColumn CreateAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("ec9d2333-9e2d-4f70-b831-5be130a4b4ac"),
				Name = @"Amount",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateDueDateColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Date")) {
				UId = new Guid("0d587626-2ccb-45e2-b582-27815c74f835"),
				Name = @"DueDate",
				IsValueCloneable = false,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreatePaymentAmountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Money")) {
				UId = new Guid("07547348-9989-4367-9325-b1fa3281bf78"),
				Name = @"PaymentAmount",
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateNotesColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("MaxSizeText")) {
				UId = new Guid("7c5a1586-bac8-433c-adda-30e45d8a71a4"),
				Name = @"Notes",
				UsageType = EntitySchemaColumnUsageType.None,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateAccountColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("b52f52a0-c983-4477-a4c3-6127cb052db4"),
				Name = @"Account",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateContactColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("8cf3941e-8061-42b9-80fa-d7936b228e84"),
				Name = @"Contact",
				ReferenceSchemaUId = new Guid("16be3651-8fe2-4159-8dd0-a803d4683dd3"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6")
			};
		}

		protected virtual EntitySchemaColumn CreateSupplierColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("2d36486c-1e97-434d-82f8-aed0e3162d8f"),
				Name = @"Supplier",
				ReferenceSchemaUId = new Guid("25d7c1ab-1de0-4501-b402-02e0e5a72d6e"),
				IsIndexed = true,
				CreatedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				ModifiedInSchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"),
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				DefValue = new EntitySchemaColumnDef() {
					Source = EntitySchemaColumnDefSource.Const,
					ValueSource = @"e308b781-3c5b-4ecb-89ef-5c1ed4da488e"
				}
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new Invoice_Invoice_BPMSoft(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new Invoice_InvoiceEventsProcess(userConnection);
		}

		public override object Clone() {
			return new Invoice_Invoice_BPMSoftSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new Invoice_Invoice_BPMSoftSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5"));
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_Invoice_BPMSoft

	/// <summary>
	/// Счет.
	/// </summary>
	public class Invoice_Invoice_BPMSoft : BPMSoft.Configuration.BaseEntity
	{

		#region Constructors: Public

		public Invoice_Invoice_BPMSoft(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "Invoice_Invoice_BPMSoft";
		}

		public Invoice_Invoice_BPMSoft(Invoice_Invoice_BPMSoft source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number {
			get {
				return GetTypedColumnValue<string>("Number");
			}
			set {
				SetColumnValue("Number", value);
			}
		}

		/// <summary>
		/// Дата выставления.
		/// </summary>
		public DateTime StartDate {
			get {
				return GetTypedColumnValue<DateTime>("StartDate");
			}
			set {
				SetColumnValue("StartDate", value);
			}
		}

		/// <summary>
		/// Сумма, б.в.
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
		/// Сумма оплаты, б.в.
		/// </summary>
		public Decimal PrimaryPaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PrimaryPaymentAmount");
			}
			set {
				SetColumnValue("PrimaryPaymentAmount", value);
			}
		}

		/// <exclude/>
		public Guid PaymentStatusId {
			get {
				return GetTypedColumnValue<Guid>("PaymentStatusId");
			}
			set {
				SetColumnValue("PaymentStatusId", value);
				_paymentStatus = null;
			}
		}

		/// <exclude/>
		public string PaymentStatusName {
			get {
				return GetTypedColumnValue<string>("PaymentStatusName");
			}
			set {
				SetColumnValue("PaymentStatusName", value);
				if (_paymentStatus != null) {
					_paymentStatus.Name = value;
				}
			}
		}

		private InvoicePaymentStatus _paymentStatus;
		/// <summary>
		/// Состояние оплаты.
		/// </summary>
		public InvoicePaymentStatus PaymentStatus {
			get {
				return _paymentStatus ??
					(_paymentStatus = LookupColumnEntities.GetEntity("PaymentStatus") as InvoicePaymentStatus);
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
		/// Ответственный.
		/// </summary>
		public Contact Owner {
			get {
				return _owner ??
					(_owner = LookupColumnEntities.GetEntity("Owner") as Contact);
			}
		}

		/// <exclude/>
		public Guid SupplierBillingInfoId {
			get {
				return GetTypedColumnValue<Guid>("SupplierBillingInfoId");
			}
			set {
				SetColumnValue("SupplierBillingInfoId", value);
				_supplierBillingInfo = null;
			}
		}

		/// <exclude/>
		public string SupplierBillingInfoName {
			get {
				return GetTypedColumnValue<string>("SupplierBillingInfoName");
			}
			set {
				SetColumnValue("SupplierBillingInfoName", value);
				if (_supplierBillingInfo != null) {
					_supplierBillingInfo.Name = value;
				}
			}
		}

		private AccountBillingInfo _supplierBillingInfo;
		/// <summary>
		/// Платежные реквизиты поставщика.
		/// </summary>
		public AccountBillingInfo SupplierBillingInfo {
			get {
				return _supplierBillingInfo ??
					(_supplierBillingInfo = LookupColumnEntities.GetEntity("SupplierBillingInfo") as AccountBillingInfo);
			}
		}

		/// <summary>
		/// Напоминать ответственному.
		/// </summary>
		public bool RemindToOwner {
			get {
				return GetTypedColumnValue<bool>("RemindToOwner");
			}
			set {
				SetColumnValue("RemindToOwner", value);
			}
		}

		/// <summary>
		/// Дата напоминания ответственному.
		/// </summary>
		public DateTime RemindToOwnerDate {
			get {
				return GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			}
			set {
				SetColumnValue("RemindToOwnerDate", value);
			}
		}

		/// <exclude/>
		public Guid CustomerBillingInfoId {
			get {
				return GetTypedColumnValue<Guid>("CustomerBillingInfoId");
			}
			set {
				SetColumnValue("CustomerBillingInfoId", value);
				_customerBillingInfo = null;
			}
		}

		/// <exclude/>
		public string CustomerBillingInfoName {
			get {
				return GetTypedColumnValue<string>("CustomerBillingInfoName");
			}
			set {
				SetColumnValue("CustomerBillingInfoName", value);
				if (_customerBillingInfo != null) {
					_customerBillingInfo.Name = value;
				}
			}
		}

		private AccountBillingInfo _customerBillingInfo;
		/// <summary>
		/// Платежные реквизиты клиента.
		/// </summary>
		public AccountBillingInfo CustomerBillingInfo {
			get {
				return _customerBillingInfo ??
					(_customerBillingInfo = LookupColumnEntities.GetEntity("CustomerBillingInfo") as AccountBillingInfo);
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
		/// Валюта.
		/// </summary>
		public Currency Currency {
			get {
				return _currency ??
					(_currency = LookupColumnEntities.GetEntity("Currency") as Currency);
			}
		}

		/// <summary>
		/// Курс.
		/// </summary>
		public Decimal CurrencyRate {
			get {
				return GetTypedColumnValue<Decimal>("CurrencyRate");
			}
			set {
				SetColumnValue("CurrencyRate", value);
			}
		}

		/// <summary>
		/// Сумма.
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
		/// Дата оплаты.
		/// </summary>
		public DateTime DueDate {
			get {
				return GetTypedColumnValue<DateTime>("DueDate");
			}
			set {
				SetColumnValue("DueDate", value);
			}
		}

		/// <summary>
		/// Сумма оплаты.
		/// </summary>
		public Decimal PaymentAmount {
			get {
				return GetTypedColumnValue<Decimal>("PaymentAmount");
			}
			set {
				SetColumnValue("PaymentAmount", value);
			}
		}

		/// <summary>
		/// Заметки.
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
		public Guid AccountId {
			get {
				return GetTypedColumnValue<Guid>("AccountId");
			}
			set {
				SetColumnValue("AccountId", value);
				_account = null;
			}
		}

		/// <exclude/>
		public string AccountName {
			get {
				return GetTypedColumnValue<string>("AccountName");
			}
			set {
				SetColumnValue("AccountName", value);
				if (_account != null) {
					_account.Name = value;
				}
			}
		}

		private Account _account;
		/// <summary>
		/// Контрагент.
		/// </summary>
		public Account Account {
			get {
				return _account ??
					(_account = LookupColumnEntities.GetEntity("Account") as Account);
			}
		}

		/// <exclude/>
		public Guid ContactId {
			get {
				return GetTypedColumnValue<Guid>("ContactId");
			}
			set {
				SetColumnValue("ContactId", value);
				_contact = null;
			}
		}

		/// <exclude/>
		public string ContactName {
			get {
				return GetTypedColumnValue<string>("ContactName");
			}
			set {
				SetColumnValue("ContactName", value);
				if (_contact != null) {
					_contact.Name = value;
				}
			}
		}

		private Contact _contact;
		/// <summary>
		/// Контакт.
		/// </summary>
		public Contact Contact {
			get {
				return _contact ??
					(_contact = LookupColumnEntities.GetEntity("Contact") as Contact);
			}
		}

		/// <exclude/>
		public Guid SupplierId {
			get {
				return GetTypedColumnValue<Guid>("SupplierId");
			}
			set {
				SetColumnValue("SupplierId", value);
				_supplier = null;
			}
		}

		/// <exclude/>
		public string SupplierName {
			get {
				return GetTypedColumnValue<string>("SupplierName");
			}
			set {
				SetColumnValue("SupplierName", value);
				if (_supplier != null) {
					_supplier.Name = value;
				}
			}
		}

		private Account _supplier;
		/// <summary>
		/// Поставщик.
		/// </summary>
		public Account Supplier {
			get {
				return _supplier ??
					(_supplier = LookupColumnEntities.GetEntity("Supplier") as Account);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new Invoice_InvoiceEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftDeleted", e);
			Deleting += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftDeleting", e);
			Inserted += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftInserted", e);
			Inserting += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftInserting", e);
			Saved += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftSaved", e);
			Saving += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftSaving", e);
			Validating += (s, e) => ThrowEvent("Invoice_Invoice_BPMSoftValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new Invoice_Invoice_BPMSoft(this);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_InvoiceEventsProcess

	/// <exclude/>
	public partial class Invoice_InvoiceEventsProcess<TEntity> : BPMSoft.Configuration.BaseEntity_LocalMessageEventsProcess<TEntity> where TEntity : Invoice_Invoice_BPMSoft
	{

		#region Class: GenerateNumberUserTaskFlowElement

		/// <exclude/>
		public class GenerateNumberUserTaskFlowElement : GenerateSequenseNumberUserTask
		{

			public GenerateNumberUserTaskFlowElement(UserConnection userConnection, Invoice_InvoiceEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "GenerateNumberUserTask";
				IsLogging = false;
				SchemaElementUId = new Guid("8dab3385-2701-4725-80fc-27c54030fbf6");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		#region Class: SynchronizeSubjectRemindingFlowElement

		/// <exclude/>
		public class SynchronizeSubjectRemindingFlowElement : SynchronizeSubjectRemindingUserTask
		{

			public SynchronizeSubjectRemindingFlowElement(UserConnection userConnection, Invoice_InvoiceEventsProcess<TEntity> process)
				: base(userConnection) {
				UId = Guid.NewGuid();
				Owner = process;
				Type = "ProcessSchemaUserTask";
				Name = "SynchronizeSubjectReminding";
				IsLogging = false;
				SchemaElementUId = new Guid("3c6005fd-a117-442c-8427-c203d746ed51");
				CreatedInSchemaUId = process.InternalSchemaUId;
			}

		}

		#endregion

		public Invoice_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "Invoice_InvoiceEventsProcess";
			SchemaUId = new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("bfb313dd-bb55-4e1b-8e42-3d346e0da7c5");
			}
		}

		#endregion

		#region Properties: Public

		public override string InstanceUId {
			get {
				return Entity.InstanceUId.ToString();
			}
		}

		public virtual bool NeedFinRecalc {
			get;
			set;
		}

		public virtual bool IsOwnerChanged {
			get;
			set;
		}

		private ProcessFlowElement _subProcess2;
		public ProcessFlowElement SubProcess2 {
			get {
				return _subProcess2 ?? (_subProcess2 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "SubProcess2",
					SchemaElementUId = new Guid("600f4891-58d2-4768-9e09-fb50e58f391b"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _invoiceSaved;
		public ProcessFlowElement InvoiceSaved {
			get {
				return _invoiceSaved ?? (_invoiceSaved = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceSaved",
					SchemaElementUId = new Guid("a681928e-edbd-45cb-a02d-2046ff936b42"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _setGenerateParamScript;
		public ProcessScriptTask SetGenerateParamScript {
			get {
				return _setGenerateParamScript ?? (_setGenerateParamScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGenerateParamScript",
					SchemaElementUId = new Guid("dc09bbd6-4778-42ac-a53e-a9ac7ab71b62"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGenerateParamScriptExecute,
				});
			}
		}

		private ProcessExclusiveGateway _exclusiveGateway1;
		public ProcessExclusiveGateway ExclusiveGateway1 {
			get {
				return _exclusiveGateway1 ?? (_exclusiveGateway1 = new ProcessExclusiveGateway() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaExclusiveGateway",
					Name = "ExclusiveGateway1",
					SchemaElementUId = new Guid("e946380f-a4ba-41cd-8a57-555d70783d02"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Question = new LocalizableString(Storage, Schema.GetResourceManagerName(),
					"EventsProcessSchema.BaseElements.ExclusiveGateway1.Question"),
						IsDecisionRequired = false,
						BranchingMode = GatewayBranchingMode.Auto,
						DecisionMode = GetewayDecisionSelectionMode.Single,
						ShowUserDecisionDialog = (processId, gatewayName) => {},
				});
			}
		}

		private ProcessScriptTask _setGeneratedNumberScript;
		public ProcessScriptTask SetGeneratedNumberScript {
			get {
				return _setGeneratedNumberScript ?? (_setGeneratedNumberScript = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "SetGeneratedNumberScript",
					SchemaElementUId = new Guid("8d23462f-1f9e-4374-8130-2c354ef753d5"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = SetGeneratedNumberScriptExecute,
				});
			}
		}

		private GenerateNumberUserTaskFlowElement _generateNumberUserTask;
		public GenerateNumberUserTaskFlowElement GenerateNumberUserTask {
			get {
				return _generateNumberUserTask ?? (_generateNumberUserTask = new GenerateNumberUserTaskFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessEndEvent _end1;
		public ProcessEndEvent End1 {
			get {
				return _end1 ?? (_end1 = new ProcessEndEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEndEvent",
					Name = "End1",
					SchemaElementUId = new Guid("fbc67e68-18cc-4551-959c-98606e98c15f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessThrowMessageEvent _synchronizeRemindingsIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SynchronizeRemindingsIntermediateThrowMessageEvent {
			get {
				return _synchronizeRemindingsIntermediateThrowMessageEvent ?? (_synchronizeRemindingsIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SynchronizeRemindingsIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("d6c244f3-6c71-4628-b201-9d316e0e8a49"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessFlowElement _invoiceDeletingStartMessage;
		public ProcessFlowElement InvoiceDeletingStartMessage {
			get {
				return _invoiceDeletingStartMessage ?? (_invoiceDeletingStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceDeletingStartMessage",
					SchemaElementUId = new Guid("24d8d007-ed4b-428c-b143-a6419ac70a1e"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _invoiceDeletingScriptTask;
		public ProcessScriptTask InvoiceDeletingScriptTask {
			get {
				return _invoiceDeletingScriptTask ?? (_invoiceDeletingScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "InvoiceDeletingScriptTask",
					SchemaElementUId = new Guid("4035ee82-8704-4bdb-86f7-d6343ca90aea"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = InvoiceDeletingScriptTaskExecute,
				});
			}
		}

		private ProcessThrowMessageEvent _synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent;
		public ProcessThrowMessageEvent SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent {
			get {
				return _synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent ?? (_synchronizeRemindingsOnDeleteIntermediateThrowMessageEvent = new ProcessThrowMessageEvent() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaIntermediateThrowMessageEvent",
					Name = "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent",
					SchemaElementUId = new Guid("e9fbc8ee-59a6-4cb2-9082-a1d2c0c2a761"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Message = "SynchronizeRemindings",
				});
			}
		}

		private ProcessScriptTask _financeRecalculationScriptTask;
		public ProcessScriptTask FinanceRecalculationScriptTask {
			get {
				return _financeRecalculationScriptTask ?? (_financeRecalculationScriptTask = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "FinanceRecalculationScriptTask",
					SchemaElementUId = new Guid("8a7fb915-f0b7-41c0-a267-c16e4e43a453"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = FinanceRecalculationScriptTaskExecute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcessInvoiceSaving;
		public ProcessFlowElement EventSubProcessInvoiceSaving {
			get {
				return _eventSubProcessInvoiceSaving ?? (_eventSubProcessInvoiceSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcessInvoiceSaving",
					SchemaElementUId = new Guid("24930fed-85ce-4bac-b106-80b153e77f60"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _invoiceSaving;
		public ProcessFlowElement InvoiceSaving {
			get {
				return _invoiceSaving ?? (_invoiceSaving = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "InvoiceSaving",
					SchemaElementUId = new Guid("25ec6644-43bc-41f6-a035-41533607406f"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptInvoiceSaving;
		public ProcessScriptTask ScriptInvoiceSaving {
			get {
				return _scriptInvoiceSaving ?? (_scriptInvoiceSaving = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptInvoiceSaving",
					SchemaElementUId = new Guid("d62bc1f1-6877-47dd-9867-08a945bf15f9"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptInvoiceSavingExecute,
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
					SchemaElementUId = new Guid("3918b5f8-efc0-4125-9866-2873e64f7def"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptTask1Execute,
				});
			}
		}

		private ProcessFlowElement _eventSubProcess1;
		public ProcessFlowElement EventSubProcess1 {
			get {
				return _eventSubProcess1 ?? (_eventSubProcess1 = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaEventSubProcess",
					Name = "EventSubProcess1",
					SchemaElementUId = new Guid("b08ae33b-1834-4fec-baba-6243dd7f9bd8"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessFlowElement _synchronizeRemindingsStartMessage;
		public ProcessFlowElement SynchronizeRemindingsStartMessage {
			get {
				return _synchronizeRemindingsStartMessage ?? (_synchronizeRemindingsStartMessage = new ProcessFlowElement() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaStartMessageEvent",
					Name = "SynchronizeRemindingsStartMessage",
					SchemaElementUId = new Guid("c759c244-a35b-4ccd-bf1c-4828672c1207"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
				});
			}
		}

		private ProcessScriptTask _scriptInvoiceSaved;
		public ProcessScriptTask ScriptInvoiceSaved {
			get {
				return _scriptInvoiceSaved ?? (_scriptInvoiceSaved = new ProcessScriptTask() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaScriptTask",
					Name = "ScriptInvoiceSaved",
					SchemaElementUId = new Guid("4c57ec31-3ad8-4db2-ab54-cb1e6e947b63"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						Script = ScriptInvoiceSavedExecute,
				});
			}
		}

		private SynchronizeSubjectRemindingFlowElement _synchronizeSubjectReminding;
		public SynchronizeSubjectRemindingFlowElement SynchronizeSubjectReminding {
			get {
				return _synchronizeSubjectReminding ?? (_synchronizeSubjectReminding = new SynchronizeSubjectRemindingFlowElement(UserConnection, this) { ExecutedEventHandler = OnExecuted });
			}
		}

		private ProcessConditionalFlow _conditionalFlow1232;
		public ProcessConditionalFlow ConditionalFlow1232 {
			get {
				return _conditionalFlow1232 ?? (_conditionalFlow1232 = new ProcessConditionalFlow() {
					UId = Guid.NewGuid(),
					Owner = this,
					Type = "ProcessSchemaConditionalFlow",
					Name = "ConditionalFlow1232",
					SchemaElementUId = new Guid("ce0e476f-1e81-402c-ba88-17acc054f388"),
					CreatedInSchemaUId = InternalSchemaUId,
					ExecutedEventHandler = OnExecuted,
						MatchBranchingDecisions = new BranchingDecisionCollection() {
				},
				});
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeFlowElements() {
			FlowElements[SubProcess2.SchemaElementUId] = new Collection<ProcessFlowElement> { SubProcess2 };
			FlowElements[InvoiceSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceSaved };
			FlowElements[SetGenerateParamScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGenerateParamScript };
			FlowElements[ExclusiveGateway1.SchemaElementUId] = new Collection<ProcessFlowElement> { ExclusiveGateway1 };
			FlowElements[SetGeneratedNumberScript.SchemaElementUId] = new Collection<ProcessFlowElement> { SetGeneratedNumberScript };
			FlowElements[GenerateNumberUserTask.SchemaElementUId] = new Collection<ProcessFlowElement> { GenerateNumberUserTask };
			FlowElements[End1.SchemaElementUId] = new Collection<ProcessFlowElement> { End1 };
			FlowElements[SynchronizeRemindingsIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsIntermediateThrowMessageEvent };
			FlowElements[InvoiceDeletingStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceDeletingStartMessage };
			FlowElements[InvoiceDeletingScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceDeletingScriptTask };
			FlowElements[SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent };
			FlowElements[FinanceRecalculationScriptTask.SchemaElementUId] = new Collection<ProcessFlowElement> { FinanceRecalculationScriptTask };
			FlowElements[EventSubProcessInvoiceSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcessInvoiceSaving };
			FlowElements[InvoiceSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { InvoiceSaving };
			FlowElements[ScriptInvoiceSaving.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptInvoiceSaving };
			FlowElements[ScriptTask1.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptTask1 };
			FlowElements[EventSubProcess1.SchemaElementUId] = new Collection<ProcessFlowElement> { EventSubProcess1 };
			FlowElements[SynchronizeRemindingsStartMessage.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeRemindingsStartMessage };
			FlowElements[ScriptInvoiceSaved.SchemaElementUId] = new Collection<ProcessFlowElement> { ScriptInvoiceSaved };
			FlowElements[SynchronizeSubjectReminding.SchemaElementUId] = new Collection<ProcessFlowElement> { SynchronizeSubjectReminding };
		}

		private void OnExecuted(object sender, ProcessActivityAfterEventArgs e) {
			switch (e.Context.SenderName) {
					case "SubProcess2":
						break;
					case "InvoiceSaved":
						e.Context.QueueTasks.Enqueue("SetGenerateParamScript");
						e.Context.QueueTasks.Enqueue("SynchronizeRemindingsIntermediateThrowMessageEvent");
						e.Context.QueueTasks.Enqueue("FinanceRecalculationScriptTask");
						break;
					case "SetGenerateParamScript":
						e.Context.QueueTasks.Enqueue("ExclusiveGateway1");
						break;
					case "ExclusiveGateway1":
						if (ConditionalFlow1232ExpressionExecute()) {
							e.Context.QueueTasks.Enqueue("GenerateNumberUserTask");
							break;
						}
						e.Context.QueueTasks.Enqueue("End1");
						break;
					case "SetGeneratedNumberScript":
						break;
					case "GenerateNumberUserTask":
							e.Context.QueueTasks.Enqueue("SetGeneratedNumberScript");
						break;
					case "End1":
						break;
					case "SynchronizeRemindingsIntermediateThrowMessageEvent":
						break;
					case "InvoiceDeletingStartMessage":
						e.Context.QueueTasks.Enqueue("InvoiceDeletingScriptTask");
						break;
					case "InvoiceDeletingScriptTask":
						e.Context.QueueTasks.Enqueue("SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent");
						break;
					case "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent":
						break;
					case "FinanceRecalculationScriptTask":
						break;
					case "EventSubProcessInvoiceSaving":
						break;
					case "InvoiceSaving":
						e.Context.QueueTasks.Enqueue("ScriptTask1");
						break;
					case "ScriptInvoiceSaving":
						break;
					case "ScriptTask1":
						e.Context.QueueTasks.Enqueue("ScriptInvoiceSaving");
						break;
					case "EventSubProcess1":
						break;
					case "SynchronizeRemindingsStartMessage":
						e.Context.QueueTasks.Enqueue("ScriptInvoiceSaved");
						break;
					case "ScriptInvoiceSaved":
						e.Context.QueueTasks.Enqueue("SynchronizeSubjectReminding");
						break;
					case "SynchronizeSubjectReminding":
						break;
			}
			ProcessQueue(e.Context);
		}

		private bool ConditionalFlow1232ExpressionExecute() {
			return Convert.ToBoolean(string.IsNullOrEmpty(Entity.GetTypedColumnValue<string>("Number")));
		}

		#endregion

		#region Methods: Protected

		protected override void PrepareStart(ProcessExecutingContext context) {
			base.PrepareStart(context);
			context.Process = this;
			ActivatedEventElements.Add("InvoiceSaved");
			ActivatedEventElements.Add("InvoiceDeletingStartMessage");
			ActivatedEventElements.Add("InvoiceSaving");
			ActivatedEventElements.Add("SynchronizeRemindingsStartMessage");
		}

		protected override bool ProcessQueue(ProcessExecutingContext context) {
			bool result = base.ProcessQueue(context);
			if (context.QueueTasks.Count == 0) {
				return result;
			}
			switch (context.QueueTasks.Peek()) {
				case "SubProcess2":
					context.QueueTasks.Dequeue();
					break;
				case "InvoiceSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceSaved";
					result = InvoiceSaved.Execute(context);
					break;
				case "SetGenerateParamScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGenerateParamScript";
					result = SetGenerateParamScript.Execute(context, SetGenerateParamScriptExecute);
					break;
				case "ExclusiveGateway1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ExclusiveGateway1";
					result = ExclusiveGateway1.Execute(context);
					break;
				case "SetGeneratedNumberScript":
					context.QueueTasks.Dequeue();
					context.SenderName = "SetGeneratedNumberScript";
					result = SetGeneratedNumberScript.Execute(context, SetGeneratedNumberScriptExecute);
					break;
				case "GenerateNumberUserTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "GenerateNumberUserTask";
					result = GenerateNumberUserTask.Execute(context);
					break;
				case "End1":
					context.QueueTasks.Dequeue();
					break;
				case "SynchronizeRemindingsIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					result = SynchronizeRemindingsIntermediateThrowMessageEvent.Execute(context);
					break;
				case "InvoiceDeletingStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceDeletingStartMessage";
					result = InvoiceDeletingStartMessage.Execute(context);
					break;
				case "InvoiceDeletingScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceDeletingScriptTask";
					result = InvoiceDeletingScriptTask.Execute(context, InvoiceDeletingScriptTaskExecute);
					break;
				case "SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent":
					context.QueueTasks.Dequeue();
					result = SynchronizeRemindingsOnDeleteIntermediateThrowMessageEvent.Execute(context);
					break;
				case "FinanceRecalculationScriptTask":
					context.QueueTasks.Dequeue();
					context.SenderName = "FinanceRecalculationScriptTask";
					result = FinanceRecalculationScriptTask.Execute(context, FinanceRecalculationScriptTaskExecute);
					break;
				case "EventSubProcessInvoiceSaving":
					context.QueueTasks.Dequeue();
					break;
				case "InvoiceSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "InvoiceSaving";
					result = InvoiceSaving.Execute(context);
					break;
				case "ScriptInvoiceSaving":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptInvoiceSaving";
					result = ScriptInvoiceSaving.Execute(context, ScriptInvoiceSavingExecute);
					break;
				case "ScriptTask1":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptTask1";
					result = ScriptTask1.Execute(context, ScriptTask1Execute);
					break;
				case "EventSubProcess1":
					context.QueueTasks.Dequeue();
					break;
				case "SynchronizeRemindingsStartMessage":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeRemindingsStartMessage";
					result = SynchronizeRemindingsStartMessage.Execute(context);
					break;
				case "ScriptInvoiceSaved":
					context.QueueTasks.Dequeue();
					context.SenderName = "ScriptInvoiceSaved";
					result = ScriptInvoiceSaved.Execute(context, ScriptInvoiceSavedExecute);
					break;
				case "SynchronizeSubjectReminding":
					context.QueueTasks.Dequeue();
					context.SenderName = "SynchronizeSubjectReminding";
					result = SynchronizeSubjectReminding.Execute(context);
					break;
			}
			if (!result && context.QueueTasks.Count > 0) {
				ProcessQueue(context);
			}
			return result;
		}

		#endregion

		#region Methods: Public

		public virtual bool SetGenerateParamScriptExecute(ProcessExecutingContext context) {
			GenerateNumberUserTask.EntitySchema = Entity.Schema;
			return true;
		}

		public virtual bool SetGeneratedNumberScriptExecute(ProcessExecutingContext context) {
			string code = GenerateNumberUserTask.ResultCode;
			var update = new Update(UserConnection, Entity.Schema.Name)
				.Set("Number", Column.Parameter(code))
				.Where("Id").IsEqual(Column.Parameter(Entity.PrimaryColumnValue));
			update.Execute();
			return true;
		}

		public virtual bool InvoiceDeletingScriptTaskExecute(ProcessExecutingContext context) {
			return true;
		}

		public virtual bool FinanceRecalculationScriptTaskExecute(ProcessExecutingContext context) {
			OnSaved();
			return true;
		}

		public virtual bool ScriptInvoiceSavingExecute(ProcessExecutingContext context) {
			OnSaving();
			return true;
		}

		public virtual bool ScriptTask1Execute(ProcessExecutingContext context) {
			return UpdatePrimaryAmount();
		}

		public virtual bool ScriptInvoiceSavedExecute(ProcessExecutingContext context) {
			var active = !Entity.IsInDeleting && !IsFinalStatus() && Entity.GetTypedColumnValue<bool>("RemindToOwner");
			var ownerRemindingSourceTypeId = "a76d08e1-2e2d-e011-ac0a-00155d043205";
			SynchronizeSubjectReminding.Active = active;
			SynchronizeSubjectReminding.SubjectPrimaryColumnValue = Entity.GetTypedColumnValue<Guid>("Id");
			SynchronizeSubjectReminding.Contact = Entity.GetTypedColumnValue<Guid>("OwnerId");
			SynchronizeSubjectReminding.Source = new Guid(ownerRemindingSourceTypeId);
			SynchronizeSubjectReminding.RemindTime = Entity.GetTypedColumnValue<DateTime>("RemindToOwnerDate");
			SynchronizeSubjectReminding.SysEntitySchema = Entity.Schema.UId;
			SynchronizeSubjectReminding.NotificationType = RemindingConsts.NotificationTypeRemindingId;
			if (UserConnection.GetIsFeatureEnabled("NotificationV2") && active) {
				IRemindingTextFormer textFormer = ClassFactory.Get<InvoiceRemindingTextFormer>(
					new ConstructorArgument("userConnection", UserConnection));
				string invoiceNumber = Entity.GetTypedColumnValue<string>("Number");
				DateTime startDate = Entity.GetTypedColumnValue<DateTime>("StartDate");
				string accountName = GetLookupDisplayColumnValue(Entity, "Account");
				string contactName = GetLookupDisplayColumnValue(Entity, "Contact");
				SynchronizeSubjectReminding.SubjectCaption =  textFormer.GetBody(new Dictionary<string, object> {
					{"Number", invoiceNumber},
					{"StartDate", startDate},
					{"AccountName", accountName},
					{"ContactName", contactName}
				});
				SynchronizeSubjectReminding.Description = invoiceNumber;
				SynchronizeSubjectReminding.PopupTitle = textFormer.GetTitle(null);
				SynchronizeSubjectReminding.IsSingleReminder = IsOwnerChanged;
			}
			return true;
		}

		public override void ThrowEvent(ProcessExecutingContext context, string message) {
			switch(message) {
					case "Invoice_Invoice_BPMSoftSaved":
							if (ActivatedEventElements.Contains("InvoiceSaved")) {
							context.QueueTasks.Enqueue("InvoiceSaved");
						}
						break;
					case "Invoice_Invoice_BPMSoftDeleting":
							if (ActivatedEventElements.Contains("InvoiceDeletingStartMessage")) {
							context.QueueTasks.Enqueue("InvoiceDeletingStartMessage");
						}
						break;
					case "Invoice_Invoice_BPMSoftSaving":
							if (ActivatedEventElements.Contains("InvoiceSaving")) {
							context.QueueTasks.Enqueue("InvoiceSaving");
						}
						break;
					case "SynchronizeRemindings":
							if (ActivatedEventElements.Contains("SynchronizeRemindingsStartMessage")) {
							context.QueueTasks.Enqueue("SynchronizeRemindingsStartMessage");
						}
						break;
			}
			base.ThrowEvent(context, message);
			ProcessQueue(context);
		}

		#endregion

	}

	#endregion

	#region Class: Invoice_InvoiceEventsProcess

	/// <exclude/>
	public class Invoice_InvoiceEventsProcess : Invoice_InvoiceEventsProcess<Invoice_Invoice_BPMSoft>
	{

		public Invoice_InvoiceEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: Invoice_InvoiceEventsProcess

	public partial class Invoice_InvoiceEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual decimal Multiply(decimal arg1, decimal arg2) {
			return Math.Round(arg1 * arg2,2);
		}

		public virtual decimal Division(decimal arg1, decimal arg2) {
			decimal result = 0;
			if(arg2 > 0){
				result = Math.Round(arg1 / arg2, 2);
			}
			return result;
		}

		public virtual bool IsFinalStatus() {
			var statusId = Entity.GetTypedColumnValue<Guid>("PaymentStatusId");
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "InvoicePaymentStatus");
			var finalColumnName = entitySchemaQuery.AddColumn("FinalStatus").Name;
			var entity = entitySchemaQuery.GetEntity(UserConnection, statusId);
			if (entity != null) {
				return entity.GetTypedColumnValue<bool>(finalColumnName);
			}
			return false;
		}

		public virtual void OnSaving() {
			if (Entity.StoringState == StoringObjectState.New) {
				return;
			}
			NeedFinRecalc = false;
			var oldCurrencyRate = Entity.GetTypedOldColumnValue<decimal>("CurrencyRate");
			var newCurrencyRate = Entity.GetTypedColumnValue<decimal>("CurrencyRate");
			var oldCurrency = Entity.GetTypedOldColumnValue<Guid>("CurrencyId");
			var newCurrency = Entity.GetTypedColumnValue<Guid>("CurrencyId");
			NeedFinRecalc = (oldCurrencyRate != newCurrencyRate) || (oldCurrency != newCurrency);
			
			var oldOwnerId = Entity.GetTypedOldColumnValue<Guid>("OwnerId");
			var newOwnerId = Entity.GetTypedColumnValue<Guid>("OwnerId");
			if (!oldOwnerId.Equals(newOwnerId)) {
				IsOwnerChanged = true;
			}
		}

		public virtual void OnSaved() {
			if (NeedFinRecalc) {
				ProductEntryUtils utils = Core.Factories.ClassFactory.Get<ProductEntryUtils>(new Core.Factories.ConstructorArgument("userConnection", UserConnection));
				utils.UpdateRecordProductAmounts(Entity);
			}
		}

		public virtual bool UpdatePrimaryAmount() {
			var amount = Entity.GetTypedColumnValue<decimal>("Amount");
			var primaryAmount = Entity.GetTypedColumnValue<decimal>("PrimaryAmount");
			if (primaryAmount != 0 || amount == 0) {
				return true;
			}
			Guid currencyId = Entity.GetTypedColumnValue<Guid>("CurrencyId");
			DateTime startDate = Entity.GetTypedColumnValue<DateTime>("StartDate");
			var currencyRateStorage = BPMSoft.Core.Factories.ClassFactory.Get<BPMSoft.Configuration.CurrencyRateStorage>(
				new BPMSoft.Core.Factories.ConstructorArgument("userConnection", UserConnection));
			var currencyInfo = currencyRateStorage.GetActualCurrencyRates(currencyId).FirstOrDefault();
			if (currencyInfo != null) {
				decimal currencyRate = BPMSoft.Configuration.CurrencyRateHelper.SetMantissaToRate(currencyInfo.Rate, currencyInfo.RateMantissa);
				int currencyDivision = currencyInfo.Division;
				if (currencyDivision != 0) {
					primaryAmount = amount * currencyDivision / currencyRate;
					Entity.SetColumnValue("PrimaryAmount", primaryAmount);
					Entity.SetColumnValue("CurrencyRate", currencyRate);
				}
			}
			return true;
		}

		public virtual string GetLookupDisplayColumnValue(Entity entity, string lookupName) {
			var rootEntitySchema = entity.Schema;
			var result = string.Empty;
			try {
				var rootEntityColumn = rootEntitySchema.Columns.GetByName(lookupName);
				var recordId = entity.GetTypedColumnValue<Guid>(rootEntityColumn.ColumnValueName);
				result = recordId.IsNotEmpty() 
					? GetFetchedDisplayColumnValue(entity, lookupName, recordId)
					: string.Empty;
			} catch (Exception ex) {
				result = string.Empty;
			}
			return result;
		}

		public virtual string GetFetchedDisplayColumnValue(Entity entity, string lookupName, Guid recordId) {
			var userConnection = entity.UserConnection;
			var lookupEntitySchema = userConnection.EntitySchemaManager.FindInstanceByName(lookupName);
			var lookupEntity = lookupEntitySchema.CreateEntity(userConnection);
			lookupEntity.FetchPrimaryInfoFromDB(lookupEntitySchema.GetPrimaryColumnName(), recordId);
			return lookupEntity.PrimaryDisplayColumnValue;
		}

		#endregion

	}

	#endregion

}

