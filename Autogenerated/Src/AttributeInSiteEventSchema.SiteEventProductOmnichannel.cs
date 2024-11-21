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

	#region Class: AttributeInSiteEventSchema

	/// <exclude/>
	public class AttributeInSiteEventSchema : BPMSoft.Configuration.AttributeInSiteEvent_SiteEvent_BPMSoftSchema
	{

		#region Constructors: Public

		public AttributeInSiteEventSchema(EntitySchemaManager entitySchemaManager)
			: base(entitySchemaManager) {
		}

		public AttributeInSiteEventSchema(AttributeInSiteEventSchema source, bool isShallowClone)
			: base(source, isShallowClone) {
		}

		public AttributeInSiteEventSchema(AttributeInSiteEventSchema source)
			: base(source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			RealUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			Name = "AttributeInSiteEvent";
			ParentSchemaUId = new Guid("6839c7b8-f847-4cef-81cd-6554e7502730");
			ExtendParent = true;
			CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			IsDBView = false;
			UseDenyRecordRights = false;
			UseRecordDeactivation = false;
		}

		protected override void InitializeColumns() {
			base.InitializeColumns();
			if (Columns.FindByUId(new Guid("be1d261c-c90a-4a78-b454-1f72cad994d5")) == null) {
				Columns.Add(CreateProductTypeValueColumn());
			}
			if (Columns.FindByUId(new Guid("be3e38da-56de-4be6-8e1c-b38fff609cc9")) == null) {
				Columns.Add(CreateProductCategoryValueColumn());
			}
			if (Columns.FindByUId(new Guid("1257872a-31e1-4602-8b78-671f31ae39be")) == null) {
				Columns.Add(CreateProductTradeMarkValueColumn());
			}
		}

		protected override EntitySchemaColumn CreateSiteEventAttributeColumn() {
			EntitySchemaColumn column = base.CreateSiteEventAttributeColumn();
			column.ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			column.CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			return column;
		}

		protected override EntitySchemaColumn CreateListItemValueColumn() {
			EntitySchemaColumn column = base.CreateListItemValueColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			column.CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			return column;
		}

		protected override EntitySchemaColumn CreateIntValueColumn() {
			EntitySchemaColumn column = base.CreateIntValueColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			column.CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			return column;
		}

		protected override EntitySchemaColumn CreateFloatValueColumn() {
			EntitySchemaColumn column = base.CreateFloatValueColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			column.CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			return column;
		}

		protected override EntitySchemaColumn CreateBooleanValueColumn() {
			EntitySchemaColumn column = base.CreateBooleanValueColumn();
			column.UsageType = EntitySchemaColumnUsageType.None;
			column.ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
			column.CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde");
			return column;
		}

		protected virtual EntitySchemaColumn CreateProductTypeValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be1d261c-c90a-4a78-b454-1f72cad994d5"),
				Name = @"ProductTypeValue",
				ReferenceSchemaUId = new Guid("41663f5e-affb-406e-b92d-4d72eea6f8a8"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde")
			};
		}

		protected virtual EntitySchemaColumn CreateProductCategoryValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("be3e38da-56de-4be6-8e1c-b38fff609cc9"),
				Name = @"ProductCategoryValue",
				ReferenceSchemaUId = new Guid("3e22e8d3-36f6-4c32-adbe-678155527541"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde")
			};
		}

		protected virtual EntitySchemaColumn CreateProductTradeMarkValueColumn() {
			return new EntitySchemaColumn(this, DataValueTypeManager.GetInstanceByName("Lookup")) {
				UId = new Guid("1257872a-31e1-4602-8b78-671f31ae39be"),
				Name = @"ProductTradeMarkValue",
				ReferenceSchemaUId = new Guid("d1084b21-51c3-4fb4-b8b8-158895fbdebc"),
				IsIndexed = true,
				IsCascade = true,
				CreatedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				ModifiedInSchemaUId = new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"),
				CreatedInPackageId = new Guid("57561044-f3ca-479f-8adf-c3fca7561cde")
			};
		}

		protected override void InitializeMethods() {
			base.InitializeMethods();
			SetMethodsDefInheritance();
		}

		#endregion

		#region Methods: Public

		public override Entity CreateEntity(UserConnection userConnection) {
			return new AttributeInSiteEvent(userConnection) {Schema = this};
		}

		public override EmbeddedProcess CreateEventsProcess(UserConnection userConnection) {
			return new AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess(userConnection);
		}

		public override object Clone() {
			return new AttributeInSiteEventSchema(this);
		}

		public override EntitySchema CloneShallow() {
			return new AttributeInSiteEventSchema(this, true);
		}

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027"));
		}

		#endregion

	}

	#endregion

	#region Class: AttributeInSiteEvent

	/// <summary>
	/// Атрибут в событии сайта.
	/// </summary>
	public class AttributeInSiteEvent : BPMSoft.Configuration.AttributeInSiteEvent_SiteEvent_BPMSoft
	{

		#region Constructors: Public

		public AttributeInSiteEvent(UserConnection userConnection)
			: base(userConnection) {
			SchemaName = "AttributeInSiteEvent";
		}

		public AttributeInSiteEvent(AttributeInSiteEvent source)
			: base(source) {
		}

		#endregion

		#region Properties: Public

		/// <exclude/>
		public Guid ProductTypeValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductTypeValueId");
			}
			set {
				SetColumnValue("ProductTypeValueId", value);
				_productTypeValue = null;
			}
		}

		/// <exclude/>
		public string ProductTypeValueName {
			get {
				return GetTypedColumnValue<string>("ProductTypeValueName");
			}
			set {
				SetColumnValue("ProductTypeValueName", value);
				if (_productTypeValue != null) {
					_productTypeValue.Name = value;
				}
			}
		}

		private ProductType _productTypeValue;
		/// <summary>
		/// Тип продукта.
		/// </summary>
		public ProductType ProductTypeValue {
			get {
				return _productTypeValue ??
					(_productTypeValue = LookupColumnEntities.GetEntity("ProductTypeValue") as ProductType);
			}
		}

		/// <exclude/>
		public Guid ProductCategoryValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductCategoryValueId");
			}
			set {
				SetColumnValue("ProductCategoryValueId", value);
				_productCategoryValue = null;
			}
		}

		/// <exclude/>
		public string ProductCategoryValueName {
			get {
				return GetTypedColumnValue<string>("ProductCategoryValueName");
			}
			set {
				SetColumnValue("ProductCategoryValueName", value);
				if (_productCategoryValue != null) {
					_productCategoryValue.Name = value;
				}
			}
		}

		private ProductCategory _productCategoryValue;
		/// <summary>
		/// Категория продукта.
		/// </summary>
		public ProductCategory ProductCategoryValue {
			get {
				return _productCategoryValue ??
					(_productCategoryValue = LookupColumnEntities.GetEntity("ProductCategoryValue") as ProductCategory);
			}
		}

		/// <exclude/>
		public Guid ProductTradeMarkValueId {
			get {
				return GetTypedColumnValue<Guid>("ProductTradeMarkValueId");
			}
			set {
				SetColumnValue("ProductTradeMarkValueId", value);
				_productTradeMarkValue = null;
			}
		}

		/// <exclude/>
		public string ProductTradeMarkValueName {
			get {
				return GetTypedColumnValue<string>("ProductTradeMarkValueName");
			}
			set {
				SetColumnValue("ProductTradeMarkValueName", value);
				if (_productTradeMarkValue != null) {
					_productTradeMarkValue.Name = value;
				}
			}
		}

		private TradeMark _productTradeMarkValue;
		/// <summary>
		/// Торговая марка.
		/// </summary>
		public TradeMark ProductTradeMarkValue {
			get {
				return _productTradeMarkValue ??
					(_productTradeMarkValue = LookupColumnEntities.GetEntity("ProductTradeMarkValue") as TradeMark);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Process InitializeEmbeddedProcess() {
			var process = new AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess(UserConnection);
			process.Entity = this;
			return process;
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeThrowEvents() {
			Deleted += (s, e) => ThrowEvent("AttributeInSiteEventDeleted", e);
			Validating += (s, e) => ThrowEvent("AttributeInSiteEventValidating", e);
			base.InitializeThrowEvents();
		}

		#endregion

		#region Methods: Public

		public override object Clone() {
			return new AttributeInSiteEvent(this);
		}

		#endregion

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess

	/// <exclude/>
	public partial class AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess<TEntity> : BPMSoft.Configuration.AttributeInSiteEvent_SiteEventEventsProcess<TEntity> where TEntity : AttributeInSiteEvent
	{

		public AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
			InitializeMetaPathParameterValues();
			UId = Guid.NewGuid();
			Name = "AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess";
			SchemaManagerName = "EntitySchemaManager";
			SerializeToDB = false;
			IsLogging = false;
			InitializeFlowElements();
		}

		#region Properties: Private

		private Guid InternalSchemaUId {
			get {
				return new Guid("a8b78ad0-d62f-4f36-ac6e-9201eb77f027");
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

	#region Class: AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess

	/// <exclude/>
	public class AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess : AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess<AttributeInSiteEvent>
	{

		public AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

	#region Class: AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess

	public partial class AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool FillStringValue() {
			var attributeTypeId = string.Empty;
			var attributeValue = string.Empty;
			if (Entity.SiteEventAttributeId == Guid.Empty) {
				return true;
			};
			var esqResult = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SiteEventAttribute");
			esqResult.AddColumn("Type");
			var attributeEntity = esqResult.GetEntity(UserConnection, Entity.SiteEventAttributeId);
			attributeTypeId = attributeEntity.GetTypedColumnValue<string>("TypeId");
			
			// if not string value
			if (attributeTypeId != "e9da1be2-b0b9-478f-8290-b84a0091ec81") {
				Entity.SetColumnValue("StringValue", string.Empty);
			};
			
			switch (attributeTypeId) {
				// string type
				case ("e9da1be2-b0b9-478f-8290-b84a0091ec81"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					return true;
				// int type
				case ("30dc6786-9179-4e6c-9e09-3c00b98bd3ef"):
					attributeValue = Entity.GetTypedColumnValue<string>("IntValue");
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					break;
				// float type
				case ("21b7b386-0ce4-48d3-9b4d-6616407dedb0"):
					attributeValue = Entity.GetTypedColumnValue<string>("FloatValue");
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					break;
				// boolean type
				case ("5762dce0-54fd-4da5-859d-323003b8a9e2"):
					if (Entity.GetTypedColumnValue<bool>("BooleanValue")) {
						attributeValue = Yes.ToString();
					} else {
						attributeValue = No.ToString();
					}
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					break;
				// list item value
				case ("23332960-c76a-4c53-a4e6-f0447b8d0018"):
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("ProductValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					attributeValue = GetColumnDisplayValue("SiteEventAttrListItem", Entity.ListItemValueId);
					break;
				// product item value
				case ("28979594-4b11-4bd8-86d2-f2252f508edd"):
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					attributeValue = GetColumnDisplayValue("Product", Entity.ProductValueId);
					break;
				// product trademark item value 
				case ("5262af16-0914-4f73-a1e9-20cbebd766f9"):
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					attributeValue = GetColumnDisplayValue("ProductCategory", Entity.ProductCategoryValueId);
					break;
				// product type item value 
				case ("e29b09bb-0f52-4eb4-847d-3b6235f5424a"):
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					Entity.SetColumnValue("ProductTradeMarkValueId", null);
					attributeValue = GetColumnDisplayValue("ProductType", Entity.ProductTypeValueId);
					break;
				// product trademark item value 
				case ("71fae7e0-2a9c-4aea-9a87-e23eee66b01d"):
					Entity.SetColumnValue("BooleanValue", false);
					Entity.SetColumnValue("FloatValue", 0.0);
					Entity.SetColumnValue("IntValue", 0);
					Entity.SetColumnValue("ListItemValueId", null);
					Entity.SetColumnValue("ProductTypeValueId", null);
					Entity.SetColumnValue("ProductCategoryValueId", null);
					attributeValue = GetColumnDisplayValue("TradeMark", Entity.ProductTradeMarkValueId);
					break;
				default: return true;
			};
			Entity.SetColumnValue("StringValue", attributeValue);
			return true;
		}

		#endregion

	}

	#endregion


	#region Class: AttributeInSiteEventEventsProcess

	/// <exclude/>
	public class AttributeInSiteEventEventsProcess : AttributeInSiteEvent_SiteEventProductOmnichannelEventsProcess
	{

		public AttributeInSiteEventEventsProcess(UserConnection userConnection)
			: base(userConnection) {
		}

	}

	#endregion

}

