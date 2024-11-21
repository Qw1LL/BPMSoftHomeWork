using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.DB;
using BPMSoft.Core.Entities;
using BPMSoft.Core.Factories;
using BPMSoft.Core.Process;
using CoreConfiguration = BPMSoft.Core.Configuration;

namespace BPMSoft.Configuration.Passport
{
	#region Class: SupplyPaymentProductInfo

	public partial class SupplyPaymentProductInfo
	{
		private decimal? _newQuantity;

		#region Properties: Public

		public Guid SupplyPaymentProductId {
			get;
			set;
		}

		public Guid OrderProductId {
			get;
			set;
		}

		public Guid OrderId {
			get;
			set;
		}

		public decimal MaxQuantity {
			get;
			set;
		}

		public decimal UsedQuantity {
			get;
			set;
		}

		public decimal ProductTotalAmount {
			get;
			set;
		}

		public decimal ProductTotalQuantity {
			get;
			set;
		}

		public decimal ProductTotalBaseQuantity {
			get;
			set;
		}

		public Guid ElementTypeId {
			get;
			set;
		}

		public Guid InvoiceId {
			get;
			set;
		}

		public decimal NewQuantity {
			get {
				return _newQuantity ?? 0;
			}
		}

		public bool ToDelete {
			get {
				CheckNewQuantity();
				return NewQuantity == 0 && SupplyPaymentProductId != Guid.Empty;
			}
		}

		public bool ToCreate {
			get {
				CheckNewQuantity();
				return UsedQuantity == 0 && NewQuantity > 0;
			}
		}

		public bool NewQuantityError {
			get {
				CheckNewQuantity();
				return NewQuantity < 0 || NewQuantity > MaxQuantity;
			}
		}

		public bool SameQuantity {
			get {
				CheckNewQuantity();
				return NewQuantity == UsedQuantity;
			}
		}

		#endregion

		#region Methods: Private

		private void CheckNewQuantity() {
			if (_newQuantity == null) {
				throw new InvalidObjectStateException("NewQuantity is not initialized.");
			}
		}

		#endregion

		#region Methods: Public

		public void SetNewQuantity(decimal quantity) {
			_newQuantity = quantity;
		}

		#endregion
	}

	#endregion

	#region Class: OrderPassportHelper

	public class OrderPassportHelper
	{

		#region SupplyPaymentProductDeleteInfo

		protected class SupplyPaymentProductDeleteInfo
		{
			public Guid SupplyPaymentProductId {
				get;
				set;
			}
			public Guid OrderProductId {
				get;
				set;
			}
		}

		#endregion

		#region Class: PercentageData

		public class PercentageData
		{
			public decimal TotalPercentage {
				get;
				set;
			}

			public decimal CurrentPercentage {
				get;
				set;
			}

			public decimal EmptyPercentageCount {
				get;
				set;
			}

			public Guid EmptyPercentageElementId {
				get;
				set;
			}
		}

		#endregion

		#region Constants: Private

		const string SupplyPaymentElementSchemaName = "SupplyPaymentElement";
		const string OrderSchemaName = "Order";
		const string SupplyPaymentTemplateItemSchemaName = "SupplyPaymentTemplateItem";
		const string SupplyPaymentSchemaName = "SupplyPayment";
		const string DefTemplateSysSettingsCode = "OrderPassportTemplateDef";
		const string PreviousElementColumnName = "PreviousElement";
		const string PreviousElementColumnValueName = "PreviousElementId";
		const string CheckCircularDependencyStoredProcedureName = "tsp_IsItemInReverseHierarchy";
		const string PassportOraclePackageName = "tspkg_Passport";
		const string SessionDataKeyForDefaultPassportTemplateDisabling = "DefaultPassportTemplateOff_OrderId";
		const string InvoiceSchemaName = "Invoice";
		const string InvoiceProductSchemaName = "InvoiceProduct";

		#endregion

		#region Constructors: Public

		public OrderPassportHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get;
			private set;
		}

		public LocalizableString CascadeCycleMessage {
			get {
				var value = GetLocalizableString("CascadeCycleMessage");
				return value;
			}
		}

		public LocalizableString CannotSetProductCountMessage {
			get {
				var value = GetLocalizableString("CannotSetProductCountMessage");
				return value;
			}
		}

		public LocalizableString ValidateTotalPercentageErrorMessage {
			get {
				var value = GetLocalizableString("ValidateTotalPercentageErrorMessage");
				return value;
			}
		}

		public LocalizableString ValidateTotalAmountPlanErrorMessage {
			get {
				var value = GetLocalizableString("ValidateTotalAmountPlanErrorMessage");
				return value;
			}
		}

		public LocalizableString ValidateOrderProductQuantityErrorMessage {
			get {
				var value = GetLocalizableString("ValidateOrderProductQuantityErrorMessage");
				return value;
			}
		}

		private EntitySchema _supplyPaymentSchema;
		public EntitySchema SupplyPaymentProductSchema {
			get {
				if (_supplyPaymentSchema == null) {
					_supplyPaymentSchema = UserConnection.EntitySchemaManager.GetInstanceByName("SupplyPaymentProduct");
				}
				return _supplyPaymentSchema;
			}
		}

		private OrderAmountHelper _orderAmountHelper;
		public OrderAmountHelper OrderAmountHelper {
			get {
				if (_orderAmountHelper == null) {
					_orderAmountHelper = ClassFactory.Get<OrderAmountHelper>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _orderAmountHelper;
			}
		}

		#endregion

		#region Properties: Protected

		private EntitySchema _supplyPaymentElementSchema;
		protected EntitySchema SupplyPaymentElementSchema {
			get {
				if (_supplyPaymentElementSchema == null) {
					_supplyPaymentElementSchema = UserConnection.EntitySchemaManager
						.GetInstanceByName(SupplyPaymentElementSchemaName);
				}
				return _supplyPaymentElementSchema;
			}
		}

		#endregion

		#region Methods: Private

		private static bool GetIsNotUpdateLinkedElements(Entity supplyPaymentElement) {
			if (supplyPaymentElement.Process == null) {
				return false;
			}
			object result;
			supplyPaymentElement.Process.TryGetPropertyValue("DoNotUpdateLinkedElements", out result);
			return (bool)result;
		}

		private static void SetNotUpdateLinkedElements(Entity supplyPaymentElement, bool value) {
			if (supplyPaymentElement.Process == null) {
				return;
			}
			supplyPaymentElement.Process.TrySetPropertyValue("DoNotUpdateLinkedElements", value);
		}

		private static bool GetIsNotCheckCascadeCycle(Entity supplyPaymentElement) {
			if (supplyPaymentElement.Process == null) {
				return false;
			}
			object result;
			supplyPaymentElement.Process.TryGetPropertyValue("DoNotCheckCascadeCycle", out result);
			return (bool)result;
		}

		private static void SetNotCheckCascadeCycle(Entity supplyPaymentElement, bool value) {
			if (supplyPaymentElement.Process == null) {
				return;
			}
			supplyPaymentElement.Process.TrySetPropertyValue("DoNotCheckCascadeCycle", value);
		}

		private LocalizableString GetLocalizableString(string name) {
			var stringName = string.Format("LocalizableStrings.{0}.Value", name);
			return new LocalizableString(UserConnection.Workspace.ResourceStorage, "OrderPassportHelper", stringName);
		}

		private bool DeleteSupplyPaymentElements(Guid orderId) {
			var update = new Update(UserConnection, SupplyPaymentElementSchemaName).WithHints(new RowLockHint())
							.Set(PreviousElementColumnValueName, Column.Const(null));
			var delete = new Delete(UserConnection)
							.From(SupplyPaymentElementSchemaName).WithHints(new RowLockHint())
							.Where("OrderId").IsEqual(Column.Parameter(orderId));
			ExecuteQueries(update, delete);
			var isDeleteQuerySuccess = (Select)new Select(UserConnection)
											.Column(Func.Count("Id"))
											.From(SupplyPaymentElementSchemaName).WithHints(new NoLockHint())
											.Where("OrderId").IsEqual(Column.Parameter(orderId));
			return isDeleteQuerySuccess.ExecuteScalar<int>() == 0;
		}

		private EntityCollection GetTemplateItems(Guid templateId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, SupplyPaymentTemplateItemSchemaName);
			esq.AddAllSchemaColumns();
			var templateFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SupplyPaymentTemplate", templateId);
			esq.Filters.Add(templateFilter);
			return esq.GetEntityCollection(UserConnection);
		}

		private void UpdateItemsPreviousElement(Dictionary<Guid, Entity> supplyPaymentItems,
				Dictionary<Guid, Guid> previousItemsMap, string itemPrimaryColumnName) {
			foreach (KeyValuePair<Guid, Entity> supplyPaymentItem in supplyPaymentItems) {
				if (!previousItemsMap.ContainsKey(supplyPaymentItem.Key)) {
					continue;
				}
				Guid prevEntityId = previousItemsMap[supplyPaymentItem.Key];
				Entity prevEntity = supplyPaymentItems[prevEntityId];
				supplyPaymentItem.Value.SetColumnValue(PreviousElementColumnValueName,
					prevEntity.GetTypedColumnValue<Guid>(itemPrimaryColumnName));
			}
		}

		private void SaveItems(List<Entity> supplyPaymentItems) {
			var orderedList = new Dictionary<Guid, Entity>();
			var currentLevelItemsList = new Dictionary<Guid, Entity>();
			do {
				var oldLevelItemsList = new Dictionary<Guid, Entity>(currentLevelItemsList);
				Func<Entity, bool> currentLevelPredicate;
				if (currentLevelItemsList.Count == 0) {
					currentLevelPredicate = (item) => 
						item.GetTypedColumnValue<Guid>(PreviousElementColumnValueName) == Guid.Empty;
				} else {
					currentLevelPredicate =
						item => oldLevelItemsList
							.ContainsKey(item.GetTypedColumnValue<Guid>(PreviousElementColumnValueName));
				}
				currentLevelItemsList = supplyPaymentItems
											.Where(currentLevelPredicate)
											.ToDictionary(item => item.PrimaryColumnValue, item => item);
				foreach (KeyValuePair<Guid, Entity> item in currentLevelItemsList) {
					orderedList[item.Key] = item.Value;
				}
			} while (currentLevelItemsList.Count > 0);
			foreach (Entity entity in orderedList.Values) {
				SetNotCheckCascadeCycle(entity, true);
				SetNotUpdateLinkedElements(entity, true);
				entity.Save(false);
			}
		}

		private void UpdateItemsPlanDate(List<Entity> supplyPaymentItems, string itemPrimaryColumnName) {
			var newSupplyPaymentItemsMap = new Dictionary<Guid, Guid>();
			var newSupplyPaymentItems = new Dictionary<Guid, Entity>();
			var performedItems = new List<Guid>();
			foreach (Entity item in supplyPaymentItems) {
				var id = item.GetTypedColumnValue<Guid>(itemPrimaryColumnName);
				var prevItemId = item.GetTypedColumnValue<Guid>(PreviousElementColumnValueName);
				newSupplyPaymentItemsMap[id] = prevItemId;
				newSupplyPaymentItems[id] = item;
			}
			List<KeyValuePair<Guid, Guid>> notProceedItems;
			do {
				notProceedItems = newSupplyPaymentItemsMap.Where(kvp => !performedItems.Contains(kvp.Key)).ToList();
				foreach (KeyValuePair<Guid, Guid> item in notProceedItems) {
					if (item.Value == Guid.Empty) {
						performedItems.Add(item.Key);
					} else if (performedItems.Contains(item.Value)) {
						var prevItem = newSupplyPaymentItems[item.Value];
						var currentItem = newSupplyPaymentItems[item.Key];
						CalculateItemPlanDate(prevItem, currentItem);
						performedItems.Add(item.Key);
					}
				}
			} while (notProceedItems.Count > 0);
		}

		private void CalculateItemPlanDate(Entity prevItem, Entity currentItem) {
			var prevItemPlanDate = prevItem.GetTypedColumnValue<DateTime>("DatePlan");
			var prevItemFactDate = prevItem.GetTypedColumnValue<DateTime>("DateFact");
			var stateColumnValue = prevItem.GetTypedColumnValue<Guid>("StateId");
			CalcNewPlanFactDates(currentItem, stateColumnValue, prevItemPlanDate, prevItemFactDate);
		}

		private bool CheckCircularRefrence(Guid currentItemId, Guid checkItemId,
			string tableName, string prevElementColumnName) {
			var booleanDataValueType = (BooleanDataValueType)UserConnection
				.DataValueTypeManager.GetInstanceByName("Boolean");
			var sp = (StoredProcedure)new StoredProcedure(UserConnection, CheckCircularDependencyStoredProcedureName)
				.WithParameter("currentElementId", currentItemId)
				.WithParameter("checkElementId", checkItemId)
				.WithParameter("tableName", tableName)
				.WithParameter("prevElementColumnName", prevElementColumnName)
				.WithOutputParameter("isCircleFound", booleanDataValueType);
			sp.PackageName = PassportOraclePackageName;
			sp.Execute();
			object value = sp.Parameters.FindByName("isCircleFound").Value;
			bool isCircleFound = (bool)booleanDataValueType.GetValueForLoad(UserConnection, value);
			return isCircleFound;
		}

		private void UpdateElementsAmount(Guid orderId, List<Entity> supplyPaymentElementList) {
			OrderAmountHelper.UpdateSupplyPaymentElementsAmount(orderId, supplyPaymentElementList);
		}

		private bool GetIsDefaultPassportTemplateCreationEnabled(Guid orderId) {
			var disabledTemplateOrder = UserConnection.SessionData[SessionDataKeyForDefaultPassportTemplateDisabling];
			if (disabledTemplateOrder == null) {
				return true;
			}
			UserConnection.SessionData.Remove(SessionDataKeyForDefaultPassportTemplateDisabling);
			return ((Guid)disabledTemplateOrder) != orderId;
		}

		private int GetSupplyPaymentElementColumnPrecision(string columnName) {
			var dbValueType = SupplyPaymentElementSchema.Columns
				.GetByName(columnName).DataValueType as FloatDataValueType;
			return dbValueType != null ? dbValueType.Precision : 0;
		}

		#endregion

		#region Methods: Protected

		protected static bool IsColumnValueChanged<T>(Entity entity, string columnName) where T : IComparable<T> {
			List<EntityColumnValue> changedColumnValues = entity.GetChangedColumnValues().ToList();
			EntityColumnValue columnValue = changedColumnValues
				.FirstOrDefault(c => c.Column.ColumnValueName == columnName);
			if (columnValue == null) {
				return false;
			}
			var columnTypedValue = columnValue.Value == null ? default(T) : (T)columnValue.Value;
			var columnTypedOldValue = columnValue.OldValue == null ? default(T) : (T)columnValue.OldValue;
			if (typeof(T).IsValueType) {
				return columnTypedValue.CompareTo(columnTypedOldValue) != 0;
			}
			return !Equals(columnTypedValue, columnTypedOldValue);
		}

		protected void ExecuteQueries(params Query[] queries) {
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				try {
					dbExecutor.StartTransaction();
					foreach (Query query in queries) {
						query.Execute(dbExecutor);
					}
					dbExecutor.CommitTransaction();
				} catch (DbException dbException) {
					dbExecutor.RollbackTransaction();
					string errorMessage = UserConnection.DBEngine.FormatException(dbException);
					throw new DbOperationException(errorMessage, dbException);
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		protected virtual void CreateSupplyPaymentItems(EntityCollection templateItems, Guid orderId) {
			var supplyPaymentItemSchema = UserConnection.EntitySchemaManager
				.GetInstanceByName(SupplyPaymentElementSchemaName);
			var supplyPaymentItems = new Dictionary<Guid, Entity>();
			var previousItemsMap = new Dictionary<Guid, Guid>();
			List<EntitySchemaColumn> templateColumnList = GetTemplateColumnList();
			var templatePrimaryColumnName = templateItems.Schema.GetPrimaryColumnName();
			foreach (Entity templateItem in templateItems) {
				Entity row = 
					CreateSupplyPaymentElementRow(orderId, supplyPaymentItemSchema, templateItem, templateColumnList);
				var templateItemId = templateItem.GetTypedColumnValue<Guid>(templatePrimaryColumnName);
				var previousElementId = templateItem.GetTypedColumnValue<Guid>(PreviousElementColumnValueName);
				if (previousElementId != Guid.Empty) {
					previousItemsMap[templateItemId] = previousElementId;
				}
				supplyPaymentItems.Add(templateItemId, row);
			}
			List<Entity> items = supplyPaymentItems.Values.ToList();
			UpdateItemsPreviousElement(supplyPaymentItems, previousItemsMap, templatePrimaryColumnName);
			UpdateItemsPlanDate(items, supplyPaymentItemSchema.GetPrimaryColumnName());
			UpdateElementsAmount(orderId, items);
			SaveItems(items);
		}

		protected virtual Guid GetTemplateIdFromSysSettings() {
			var templateId = CoreConfiguration.SysSettings
				.GetValue<Guid?>(UserConnection, DefTemplateSysSettingsCode, Guid.Empty);
			return templateId ?? Guid.Empty;
		}

		protected virtual void CheckSupplyPaymentElementRights(Guid orderId) {
			DBSecurityEngine securityEngine = UserConnection.DBSecurityEngine;
			if (!securityEngine.GetIsEntitySchemaDeletingAllowed(SupplyPaymentElementSchemaName)) {
				throw new SecurityException(
					string.Format(new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Delete"),
						SupplyPaymentElementSchemaName));
			}
			if (securityEngine.GetIsEntitySchemaAdministratedByRecords(OrderSchemaName)) {
				if (securityEngine.GetIsEntitySchemaEditingAllowed(OrderSchemaName)) {
					SchemaRecordRightLevels recordRightlevel = 
						securityEngine.GetEntitySchemaRecordRightLevel(OrderSchemaName, orderId);
					if ((recordRightlevel & SchemaRecordRightLevels.CanEdit) == SchemaRecordRightLevels.CanEdit) {
						return;
					}
				}
				throw new SecurityException(
					  string.Format(new LocalizableString("BPMSoft.Core", "Entity.Exception.NoRightFor.Update"),
						  UserConnection.EntitySchemaManager.GetInstanceByName(OrderSchemaName).Caption));
			}
		}

		protected virtual List<EntitySchemaColumn> GetTemplateColumnList() {
			EntitySchema supplyPaymentTemplateItemSchema =
				UserConnection.EntitySchemaManager.FindInstanceByName(SupplyPaymentTemplateItemSchemaName);
			if (supplyPaymentTemplateItemSchema == null) {
				throw new Exception(string.Format("Schema \"{0}\" must inherit from \"{1}\"",
					SupplyPaymentTemplateItemSchemaName, SupplyPaymentSchemaName));
			}
			var baseEntityColumns =
				UserConnection.EntitySchemaManager.GetInstanceByName("BaseEntity")
					.Columns.ToList()
					.ConvertAll(c => c.UId);
			var columns = new List<EntitySchemaColumn>();
			foreach (EntitySchemaColumn column in supplyPaymentTemplateItemSchema.Columns) {
				if (!column.IsSystem && column.IsInherited && !baseEntityColumns.Contains(column.UId)) {
					columns.Add(column);
				}
			}
			return columns;
		}

		protected virtual Entity CreateSupplyPaymentElementRow(Guid orderId, EntitySchema supplyPaymentItemSchema,
				Entity templateItem, List<EntitySchemaColumn> templateColumnList) {
			var row = supplyPaymentItemSchema.CreateEntity(UserConnection);
			row.SetDefColumnValues();
			row.SetColumnValue("OrderId", orderId);
			var typeColumn = templateItem.Schema.Columns.GetByName("Type");
			var name = templateItem.PrimaryDisplayColumnValue;
			var typeName = templateItem.GetColumnDisplayValue(typeColumn);
			var elementName = string.IsNullOrWhiteSpace(name) ? typeName : name;
			row.SetColumnValue(row.Schema.PrimaryDisplayColumn, elementName);
			EntitySchemaColumnCollection rowColumns = row.Schema.Columns;
			foreach (EntitySchemaColumn column in templateColumnList) {
				if (rowColumns.FindByName(column.Name) == null) {
					continue;
				}
				var columnName = column.IsLookupType ? column.ColumnValueName : column.Name;
				row.SetColumnValue(columnName, templateItem.GetColumnValue(columnName));
			}
			return row;
		}

		protected virtual Dictionary<Guid, SupplyPaymentProductInfo> GetSupplyPaymentProductInfo(Guid supplyPaymentElementId) {
			var infoEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "VwSupplyPaymentProduct");
			var elementIdFilter = infoEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "SupplyPaymentElement",
				supplyPaymentElementId);
			infoEsq.Filters.Add(elementIdFilter);
			var supplyPaymentProductIdColumn = infoEsq.AddColumn("SupplyPaymentProduct.Id");
			var orderProductIdColumn = infoEsq.AddColumn("OrderProduct.Id");
			var orderIdColumn = infoEsq.AddColumn("OrderProduct.Order.Id");
			var productTotalAmountColumn = infoEsq.AddColumn("OrderProduct.TotalAmount");
			var productTotalQuantityColumn = infoEsq.AddColumn("OrderProduct.Quantity");
			var productTotalBaseQuantityColumn = infoEsq.AddColumn("OrderProduct.BaseQuantity");
			var maxQuantityColumn = infoEsq.AddColumn("MaxQuantity");
			var usedQuantityColumn = infoEsq.AddColumn("UsedQuantity");
			var elementTypeIdColumn = infoEsq.AddColumn("SupplyPaymentElement.Type.Id");
			var invoiceIdColumn = infoEsq.AddColumn("SupplyPaymentElement.Invoice.Id");
			var infoRows = infoEsq.GetEntityCollection(UserConnection);
			var supplyPaymentInfo = new Dictionary<Guid, SupplyPaymentProductInfo>();
			foreach (Entity row in infoRows) {
				var info = new SupplyPaymentProductInfo {
					SupplyPaymentProductId = row.GetTypedColumnValue<Guid>(supplyPaymentProductIdColumn.Name),
					OrderProductId = row.GetTypedColumnValue<Guid>(orderProductIdColumn.Name),
					OrderId = row.GetTypedColumnValue<Guid>(orderIdColumn.Name),
					MaxQuantity = row.GetTypedColumnValue<decimal>(maxQuantityColumn.ValueQueryAlias),
					UsedQuantity = row.GetTypedColumnValue<decimal>(usedQuantityColumn.ValueQueryAlias),
					ProductTotalAmount = row.GetTypedColumnValue<decimal>(productTotalAmountColumn.Name),
					ProductTotalQuantity = row.GetTypedColumnValue<decimal>(productTotalQuantityColumn.Name),
					ProductTotalBaseQuantity = row.GetTypedColumnValue<decimal>(productTotalBaseQuantityColumn.Name),
					ElementTypeId = row.GetTypedColumnValue<Guid>(elementTypeIdColumn.Name),
					InvoiceId = row.GetTypedColumnValue<Guid>(invoiceIdColumn.Name)
				};
				supplyPaymentInfo[info.OrderProductId] = info;
			}
			return supplyPaymentInfo;
		}

		protected List<SupplyPaymentProductInfo> PrepareProductsInfo(Dictionary<Guid, SupplyPaymentProductInfo> supplyPaymentInfo,
				Dictionary<Guid, decimal> productsData, out bool isAnyQuantityError) {
			isAnyQuantityError = false;
			var result = new List<SupplyPaymentProductInfo>();
			foreach (Guid orderProductId in productsData.Keys) {
				if (!supplyPaymentInfo.ContainsKey(orderProductId)) {
					continue;
				}
				var info = supplyPaymentInfo[orderProductId];
				var newQuantity = productsData[orderProductId];
				info.SetNewQuantity(newQuantity);
				if (info.SameQuantity || info.NewQuantityError) {
					if (info.NewQuantityError) {
						isAnyQuantityError = true;
					}
					continue;
				}
				result.Add(info);
			}
			return result;
		}

		protected virtual List<SupplyPaymentProductInfo> PrepareProductsInfo(Dictionary<Guid, SupplyPaymentProductInfo> supplyPaymentInfo,
				IEnumerable<ProductInfo> productsData, out bool isAnyQuantityError) {
			isAnyQuantityError = false;
			var result = new List<SupplyPaymentProductInfo>();
			foreach (ProductInfo productInfo in productsData) {
				Guid productInOrderId = productInfo.ProductInOrderId;
				if (!supplyPaymentInfo.ContainsKey(productInOrderId)) {
					continue;
				}
				SupplyPaymentProductInfo info = supplyPaymentInfo[productInOrderId];
				decimal newQuantity = productInfo.Quantity;
				info.SetNewQuantity(newQuantity);
				if (info.SameQuantity || info.NewQuantityError) {
					if (info.NewQuantityError) {
						isAnyQuantityError = true;
					}
					continue;
				}
				result.Add(info);
			}
			return result;
		}

		protected virtual bool UpdateSupplyPaymentProducts(List<SupplyPaymentProductInfo> supplyPaymentInfo, 
				Guid supplyPaymentElementId) {
			bool isDeletedProductsExists = false;
			bool isAnyProductModified = false;
			Guid orderId = Guid.Empty;
			foreach (SupplyPaymentProductInfo info in supplyPaymentInfo) {
				if (orderId == Guid.Empty) {
					orderId = info.OrderId;
				}
				if (info.ToDelete) {
					DeleteSupplyPaymentProduct(info.SupplyPaymentProductId);
					isDeletedProductsExists = true;
				} else {
					Entity product;
					Entity invoiceProduct = null;
					if (info.ToCreate) {
						product = CreateSupplyPaymentProduct(supplyPaymentElementId, info.OrderProductId,
							info.InvoiceId, out invoiceProduct);
					} else {
						product = FetchSupplyPaymentProduct(info.SupplyPaymentProductId);
					}
					UpdateSupplyPaymentProduct(product, info);
					product.Save(false);
					if (invoiceProduct != null) {
						invoiceProduct.Save(false);
					}
				}
				isAnyProductModified = true;
			}
			if (isAnyProductModified) {
				OnSupplyPaymentProductsChange(supplyPaymentInfo, supplyPaymentElementId);
				Guid typeId = supplyPaymentInfo.First().ElementTypeId;
				OrderAmountHelper.ClearPercentageInElementsWithoutProducts(orderId, typeId);
			}
			return isDeletedProductsExists || !isAnyProductModified;
		}

		protected virtual void UpdateSupplyPaymentProduct(Entity supplyPaymentProduct, SupplyPaymentProductInfo info) {
			decimal quantity = info.NewQuantity;
			decimal totalBaseQuantity = info.ProductTotalBaseQuantity;
			decimal totalQuantity = info.ProductTotalQuantity;
			decimal numberOfUnit = totalBaseQuantity / totalQuantity;
			decimal baseQuantity = quantity * numberOfUnit;
			decimal productTotalAmount = info.ProductTotalAmount;
			decimal calculateAmount = quantity * (productTotalAmount / totalQuantity);
			decimal newAmount = (totalQuantity == 0 || productTotalAmount == 0) ? 0 : calculateAmount;
			supplyPaymentProduct.SetColumnValue("Quantity", quantity);
			supplyPaymentProduct.SetColumnValue("BaseQuantity", baseQuantity);
			supplyPaymentProduct.SetColumnValue("Amount", newAmount);
		}

		protected virtual void UpdateSupplyPaymentProduct(Entity supplyPaymentProduct, decimal quantity, 
				decimal productTotalAmount, decimal productTotalQuantity, decimal productTotalBaseQuantity) {
			var info = new SupplyPaymentProductInfo {
				ProductTotalAmount = productTotalAmount,
				ProductTotalQuantity = productTotalQuantity,
				ProductTotalBaseQuantity = productTotalBaseQuantity
			};
			info.SetNewQuantity(quantity);
			UpdateSupplyPaymentProduct(supplyPaymentProduct, info);
		}

		protected virtual Entity CreateSupplyPaymentProduct(Guid supplyPaymentElementId, Guid orderProductId, Guid invoiceId,
				out Entity invoiceProduct) {
			Entity item = SupplyPaymentProductSchema.CreateEntity(UserConnection);
			item.SetDefColumnValues();
			item.SetColumnValue("SupplyPaymentElementId", supplyPaymentElementId);
			item.SetColumnValue("ProductId", orderProductId);
			if (invoiceId != Guid.Empty) {
				invoiceProduct = UserConnection.EntitySchemaManager.GetInstanceByName("InvoiceProduct")
					.CreateEntity(UserConnection);
				invoiceProduct.SetDefColumnValues();
				invoiceProduct.SetColumnValue("InvoiceId", invoiceId);
				invoiceProduct.SetColumnValue("SupplyPaymentProductId", item.PrimaryColumnValue);
			} else {
				invoiceProduct = null;
			}
			return item;
		}

		protected Entity FetchSupplyPaymentProduct(Guid supplyPaymentProductId) {
			Entity item = SupplyPaymentProductSchema.CreateEntity(UserConnection);
			if (!item.FetchFromDB(supplyPaymentProductId)) {
				throw new ArgumentException(string.Empty, "supplyPaymentProductId");
			}
			return item;
		}

		protected void DeleteSupplyPaymentProduct(Guid supplyPaymentProductId) {
			Entity item = SupplyPaymentProductSchema.CreateEntity(UserConnection);
			item.SetColumnValue(SupplyPaymentProductSchema.GetPrimaryColumnName(), supplyPaymentProductId);
			item.Delete(supplyPaymentProductId);
		}

		protected void OnSupplyPaymentProductsChange(List<SupplyPaymentProductInfo> productInfos, Guid supplyPaymentElementId) {
			OrderAmountHelper.OnSupplyPaymentProductsChange(productInfos, supplyPaymentElementId);
		}

		protected Dictionary<Guid, List<Guid>> GetSupplyPaymentElementWithoutProducts(Guid orderId) {
			var elementsEsq = (Select)new Select(UserConnection)
				.Column("vspp", "SupplyPaymentElementId")
				.Column("spe", "TypeId")
				.From("VwSupplyPaymentProduct").As("vspp").WithHints(new NoLockHint())
				.InnerJoin("SupplyPaymentElement").As("spe").WithHints(new NoLockHint())
					.On("vspp", "SupplyPaymentElementId").IsEqual("spe", "Id")
				.Where("spe", "OrderId").IsEqual(Column.Parameter(orderId))
				.GroupBy("vspp", "SupplyPaymentElementId")
				.GroupBy("spe", "OrderId")
				.GroupBy("spe", "TypeId")
				.Having(Func.Count("vspp", "SupplyPaymentProductId")).IsEqual(Column.Const(0));
			var data = new Dictionary<Guid, List<Guid>>();
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = elementsEsq.ExecuteReader(executor)) {
					while (reader.Read()) {
						if (reader.IsDBNull(0) || reader.IsDBNull(1)) {
							continue;
						}
						Guid typeId = reader.GetGuid(1);
						Guid speId = reader.GetGuid(0);
						if (data.ContainsKey(typeId)) {
							data[typeId].Add(speId);
						} else {
							data[typeId] = new List<Guid> { speId };
						}
					}
				}
			}
			return data;
		}

		protected void AddAllProductsToSupplyPaymentElement(Guid supplyPaymentElementId,
				Dictionary<Guid, SupplyPaymentProductInfo> productsInfo) {
			foreach (SupplyPaymentProductInfo productInfo in productsInfo.Values) {
				if (productInfo.MaxQuantity == 0) {
					continue;
				}
				Entity invoiceProduct;
				Entity product = CreateSupplyPaymentProduct(supplyPaymentElementId, productInfo.OrderProductId,
					productInfo.InvoiceId, out invoiceProduct);
				UpdateSupplyPaymentProduct(product, productInfo);
				product.Save(false);
				if (invoiceProduct != null) {
					invoiceProduct.Save(false);
				}
			}
			OnSupplyPaymentProductsChange(productsInfo.Values.ToList(), supplyPaymentElementId);
		}

		protected void UpdateElementPercentage(Guid supplyPaymentElementId, decimal percentageValue) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, SupplyPaymentElementSchemaName);
			esq.AddAllSchemaColumns();
			EntitySchemaQueryColumn orderAmountColumn = esq.AddColumn("Order.Amount");
			Entity supplyPaymentElement = esq.GetEntity(UserConnection, supplyPaymentElementId);
			supplyPaymentElement.SetColumnValue("Percentage", percentageValue);
			decimal orderAmountValue = supplyPaymentElement.GetTypedColumnValue<decimal>(orderAmountColumn.Name);
			supplyPaymentElement.SetColumnValue("AmountPlan", Math.Round(orderAmountValue * percentageValue / 100, 4));
			supplyPaymentElement.Save(false);
		}

		protected PercentageData GetSupplyPaymentPercentageData(Guid orderId, Guid currentElementId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, SupplyPaymentElementSchemaName);
			var idColumn = esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			esq.AddColumn("Percentage");
			var orderFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Order", orderId);
			var typeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type",
				PassportConstants.SupplyPaymentTypePayment);
			esq.Filters.Add(orderFilter);
			esq.Filters.Add(typeFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			Guid emptyPercentageElementId = Guid.Empty;
			decimal totalPercentage = 0;
			decimal currentPercentageValue = 0;
			decimal emptyPercentageCount = 0;
			foreach (Entity supplyPaymentElement in entityCollection) {
				decimal percentageValue = supplyPaymentElement.GetTypedColumnValue<decimal>("Percentage");
				Guid entityCollectionItemId = supplyPaymentElement.GetTypedColumnValue<Guid>(idColumn.Name);
				if (entityCollectionItemId == currentElementId) {
					currentPercentageValue = percentageValue;
				} else if (percentageValue == 0) {
					emptyPercentageElementId = entityCollectionItemId;
					emptyPercentageCount++;
				}
				totalPercentage += percentageValue;
			}
			PercentageData percentageData = new PercentageData {
				TotalPercentage = totalPercentage,
				CurrentPercentage = currentPercentageValue,
				EmptyPercentageCount = emptyPercentageCount,
				EmptyPercentageElementId = emptyPercentageElementId
			};
			return percentageData;
		}

		protected decimal GetOrderTotalAmount(Guid orderId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, OrderSchemaName);
			esq.AddColumn("Amount");
			Entity entity = esq.GetEntity(UserConnection, orderId);
			decimal totalAmount = entity.GetTypedColumnValue<decimal>("Amount");
			return totalAmount;
		}

		protected decimal GetSupplyPaymentTotalAmountPlan(Guid orderId, Guid currentElementId) {
			var query = (Select)new Select(UserConnection)
				.Column(Func.Sum("AmountPlan")).As("TotalAmountPlan")
				.From("SupplyPaymentElement").As("spe").WithHints(new NoLockHint())
				.Where("spe", "OrderId").IsEqual(Column.Parameter(orderId))
				.And("spe", "TypeId").IsEqual(Column.Parameter(PassportConstants.SupplyPaymentTypePayment))
				.And("spe", "Id").IsNotEqual(Column.Parameter(currentElementId));
			decimal totalAmountPlan = 0;
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				totalAmountPlan = query.ExecuteScalar<decimal>(executor);
			}
			return totalAmountPlan;
		}

		protected void AllocateSupplyPaymentRestPercentage(PercentageData percentageData, Guid currentElementId, decimal newPercentageValue) {
			decimal summaryPercentage = percentageData.TotalPercentage -
				percentageData.CurrentPercentage + newPercentageValue;
			if ((summaryPercentage > 100m) || (percentageData.CurrentPercentage == newPercentageValue)) {
				return;
			}
			if ((percentageData.EmptyPercentageCount == 1) &&
					(percentageData.EmptyPercentageElementId != currentElementId)) {
				UpdateElementPercentage(percentageData.EmptyPercentageElementId, 100m - summaryPercentage);
			}
		}

		protected List<SupplyPaymentProductDeleteInfo> GetSupplyPaymentProductIds(Guid supplyPaymentElementId) {
			var result = new List<SupplyPaymentProductDeleteInfo>();
			var productIdSelect = (Select)new Select(UserConnection)
				.Column("spp", "Id")
				.Column("spp", "ProductId")
				.From("SupplyPaymentProduct").As("spp").WithHints(new NoLockHint())
				.Where("spp", "SupplyPaymentElementId").IsEqual(Column.Parameter(supplyPaymentElementId));
			using (DBExecutor executor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = productIdSelect.ExecuteReader(executor)) {
					while (reader.Read()) {
						if (reader.IsDBNull(0)) {
							continue;
						}
						result.Add(new SupplyPaymentProductDeleteInfo {
							SupplyPaymentProductId = reader.GetGuid(0),
							OrderProductId = reader.GetGuid(1)
						});
					}
				}
			}
			return result;
		}

		protected void DeleteSupplyPaymentProducts(Guid supplyPaymentElementId) {
			List<SupplyPaymentProductDeleteInfo> productsToDelete = GetSupplyPaymentProductIds(supplyPaymentElementId);
			foreach (SupplyPaymentProductDeleteInfo product in productsToDelete) {
				DeleteSupplyPaymentProduct(product.SupplyPaymentProductId);
			}
		}

		/// <summary>
		/// Получить максимальное количество продуктов в заказе
		/// </summary>
		/// <param name="orderProductId">Id продукта</param>
		/// <param name="elementTypeName">Название элемента</param>
		/// <returns></returns>
		protected decimal GetMaxOrderProductSpeQuantity(Guid orderProductId, out string elementTypeName)
		{

            var quantityReport = new Select(UserConnection)
				.Column("spe", "TypeId").As("TypeId")
				.Column(Func.Sum("Quantity")).As("TotalQuantity")
				.From("SupplyPaymentProduct").As("spp").WithHints(new NoLockHint())
				.InnerJoin("SupplyPaymentElement").As("spe").WithHints(new NoLockHint())
					.On("spp", "SupplyPaymentElementId").IsEqual("spe", "Id")
				.Where("spp", "ProductId").IsEqual(Column.Parameter(orderProductId))
				.GroupBy("spe", "TypeId");
		
			var maxQuantity = 0m;
			elementTypeName = string.Empty;
			using (var executor = UserConnection.EnsureDBConnection()) 
			{
				using (var reader = ((Select)GetQuantityReportSelect(quantityReport, UserConnection.CurrentUser.SysCultureId))
					.ExecuteReader(executor)) {
					if (reader.Read() && !reader.IsDBNull(0)) {
						var quantity = reader.GetDecimal(0);
						if (quantity > maxQuantity) {
							maxQuantity = quantity;
							elementTypeName = reader.GetString(1);
						}
					}
				}
			}
			return maxQuantity;
		}

        /// <summary>
        /// Получить из таблицы QuantityReport в зависимости от Id культуры
        /// </summary>
        /// <param name="quantityReport">Объект <see cref="Query"/> из таблицы SupplyPaymentProduct</param>
        /// <param name="currentCultureId">Id текущей культуры</param>
        /// <returns></returns>
        private Query GetQuantityReportSelect(Query quantityReport, Guid currentCultureId) 
		{

            Guid cultureEnglishId = new Guid(new LocalizableString("BPMSoft.Core", "EntitySchemaQuery.IdEnglishCulture"));

            if (cultureEnglishId.Equals(currentCultureId))
            {
                return new Select(UserConnection)
                .Top(1)
                .Column("QuantityReport", "TotalQuantity")
                .Column("spt", "Name")
                .From(quantityReport).As("QuantityReport").WithHints(new NoLockHint())
                .InnerJoin("SupplyPaymentType").As("spt").WithHints(new NoLockHint())
                    .On("spt", "Id").IsEqual("QuantityReport", "TypeId")
                .OrderByDesc("QuantityReport", "TotalQuantity");
            }

            return new Select(UserConnection)
                .Top(1)
                .Column("QuantityReport", "TotalQuantity")
                .Column("spt", "Name")
                .From(quantityReport).As("QuantityReport").WithHints(new NoLockHint())
                .InnerJoin("SysSupplyPaymentTypeLcz").As("spt").WithHints(new NoLockHint())
                    .On("spt", "RecordId").IsEqual("QuantityReport", "TypeId")
                    .Where("spt", "SysCultureId").IsEqual(Column.Parameter(currentCultureId))
                .OrderByDesc("QuantityReport", "TotalQuantity");
        }
		

		/// <summary>
		/// Returns supply payment element esq.
		/// </summary>
		/// <param name="supplyPaymentElement">Supply payment element.</param>
		/// <returns><see cref="EntitySchemaQuery"/></returns>
		protected virtual EntitySchemaQuery GetSupplyPaymentElementByOrderESQ(Entity supplyPaymentElement) {
			var orderId = supplyPaymentElement.GetTypedColumnValue<Guid>("OrderId");
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, SupplyPaymentElementSchemaName);
			esq.AddAllSchemaColumns();
			var id = supplyPaymentElement.GetTypedColumnValue<Guid>("Id");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Order", orderId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, PreviousElementColumnName, id));
			return esq;
		}

		/// <summary>
		/// Calculates dates of plan and fact.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="stateColumnValue">Supply payment state.</param>
		/// <param name="datePlanValue">Date plan.</param>
		/// <param name="dateFactValue">Date fact.</param>
		protected virtual void CalcNewPlanFactDates(Entity entity, Guid stateColumnValue, DateTime datePlanValue,
			DateTime dateFactValue) {
			DateTime datePlan = entity.GetTypedColumnValue<DateTime>("DatePlan");
			DateTime dateFact = entity.GetTypedColumnValue<DateTime>("DateFact");
			int delay = entity.GetTypedColumnValue<int>("Delay");
			Guid delayType = entity.GetTypedColumnValue<Guid>("DelayTypeId");
			if (dateFactValue == default(DateTime)) {
				dateFactValue = datePlanValue;
			}
			if (delayType == PassportConstants.SupplyPaymentDelayFromPlan) {
				datePlan = datePlanValue.AddDays(delay);
			} else if (delayType == PassportConstants.SupplyPaymentDelayFromFact) {
				datePlan = stateColumnValue == PassportConstants.SupplyPaymentStateFinished
					? dateFactValue.AddDays(delay)
					: datePlanValue.AddDays(delay);
			}
			if (dateFact != default(DateTime)) {
				if (dateFact > datePlan) {
					dateFact = datePlan;
				}
				entity.SetColumnValue("DatePlan", datePlan);
				entity.SetColumnValue("DateFact", dateFact);
			} else {
				entity.SetColumnValue("DatePlan", datePlan);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######### ######## ######## ###### ## ####### ## ######### #########
		/// </summary>
		/// <param name="orderId"></param>
		public virtual void TurnDefPassportTemplateOff(Guid orderId) {
			UserConnection.SessionData[SessionDataKeyForDefaultPassportTemplateDisabling] = orderId;
		}

		/// <summary>
		/// ####### ###### ######## ####### ######## # ##### ######, # ####### ##### ## #######
		/// ######### <see cref="SetTemplate(Guid, Guid?)"/>.
		/// </summary>
		/// <param name="orderId">Id ######</param>
		/// <param name="templateId">Id #######</param>
		public void ChangeTemplate(Guid orderId, Guid templateId) {
			CheckSupplyPaymentElementRights(orderId);
			var deleteSuccess = DeleteSupplyPaymentElements(orderId);
			if (deleteSuccess) {
				SetTemplate(orderId, templateId);
				AllocateSupplyPaymentRestProducts(orderId);
			}
			UpdateOrderPaymentAmountOnSupplyPaymentElementDeleted(orderId);
		}

		/// <summary>
		/// ####### ###### ######### ####### ######## # ##### ######.
		/// </summary>
		/// <param name="orderId">Id ######</param>
		/// <param name="templateId">Id #######, #### ## ###### ##### #### ## ######### #########,
		///  ##. #####. <see cref="DefTemplateSysSettingsCode"/></param>
		public void SetTemplate(Guid orderId, Guid? templateId = null) {
			var isTemplateEnabled = GetIsDefaultPassportTemplateCreationEnabled(orderId);
			if (!isTemplateEnabled) {
				return;
			}
			var passportTemplate = templateId ?? GetTemplateIdFromSysSettings();
			if (passportTemplate == Guid.Empty) {
				return;
			}
			EntityCollection templateItems = GetTemplateItems(passportTemplate);
			CreateSupplyPaymentItems(templateItems, orderId);
		}

		/// <summary>
		/// ########## ##########, #### ### ######## ######## ####### <see cref="PreviousElementColumnValueName"/>,
		/// ########## ########### ########### #######.
		/// </summary>
		/// <param name="entity">####### ####### ########/#####</param>
		/// <param name="previousElementColumnValueName">######## ####### ## ####### ## ########## #######,
		/// #### ## #######, ##### ##### ## <see cref="PreviousElementColumnValueName"/></param>
		public void ThrowIfFindCascadeCycle(Entity entity, string previousElementColumnValueName = null) {
			var isNotCheckCascadeCycle = GetIsNotCheckCascadeCycle(entity);
			if (isNotCheckCascadeCycle) {
				return;
			}
			var prevColumnName = previousElementColumnValueName ?? PreviousElementColumnValueName;
			if (!IsColumnValueChanged<Guid>(entity, prevColumnName)) {
				return;
			}
			Guid id = entity.PrimaryColumnValue;
			var previousElementId = entity.GetTypedColumnValue<Guid>(PreviousElementColumnValueName);
			var circularRefrenceFound = CheckCircularRefrence(id, previousElementId, entity.Schema.Name, PreviousElementColumnValueName);
			if (circularRefrenceFound) {
				throw new InvalidOperationException(CascadeCycleMessage);
			}
		}

		/// <summary>
		/// ######### ######## ######## #### # ######## ######### #######.
		/// </summary>
		/// <param name="supplyPaymentElement">####### ####### #######</param>
		public void UpdateLinkedElements(Entity supplyPaymentElement) {
			bool isNotUpdateLinkedElements = GetIsNotUpdateLinkedElements(supplyPaymentElement);
			if (isNotUpdateLinkedElements) {
				return;
			}
			var datePlanValue = supplyPaymentElement.GetTypedColumnValue<DateTime>("DatePlan");
			var dateFactValue = supplyPaymentElement.GetTypedColumnValue<DateTime>("DateFact");
			var stateColumnValue = supplyPaymentElement.GetTypedColumnValue<Guid>("StateId");
			EntitySchemaQuery esq = GetSupplyPaymentElementByOrderESQ(supplyPaymentElement);
			var entityCollection = esq.GetEntityCollection(UserConnection);
			if (entityCollection.Count > 0) {
				foreach (Entity entity in entityCollection) {
					CalcNewPlanFactDates(entity, stateColumnValue, datePlanValue, dateFactValue);
					entity.Save(false);
				}
			}
		}

		/// <summary>
		/// ######### ####### ######## ##### ###### ## ##### #####
		/// </summary>
		/// <param name="orderId">Id ######</param>
		public void UpdateOrderPaymentAmountOnSupplyPaymentElementDeleted(Guid orderId) {
			OrderAmountHelper.UpdateOrderPaymentAmountOnSupplyPaymentElementDeleted(orderId);
		}

		/// <summary>
		/// Updates the number of products in the supply payment element.
		/// </summary>
		/// <param name="supplyPaymentElementId">supply payment element identificator.</param>
		/// <param name="productsData">Information of quantity: Key - Id product in order, Value - quantity.</param>
		public void UpdateSupplyPaymentProducts(Guid supplyPaymentElementId, Dictionary<Guid, decimal> productsData) {
			if (supplyPaymentElementId == Guid.Empty) {
				throw new ArgumentException(string.Empty, "supplyPaymentElementId");
			}
			if (productsData.Count == 0) {
				return;
			}
			var productsInfo = new List<ProductInfo>();
			IEnumerable<Guid> productsInOrderId = productsData.Keys;
			foreach (Guid productInOrderId in productsInOrderId) {
				decimal quantity = productsData[productInOrderId];
				productsInfo.Add(new ProductInfo {
					ProductInOrderId =  productInOrderId,
					Quantity = quantity
				});
			}
			UpdateSupplyPaymentProducts(supplyPaymentElementId, productsInfo);
		}

		/// <summary>
		/// Updates the number of products in the supply payment element.
		/// </summary>
		/// <param name="supplyPaymentElementId">supply payment element identificator.</param>
		/// <param name="productsData">Information of product.</param>
		public void UpdateSupplyPaymentProducts(Guid supplyPaymentElementId, IEnumerable<ProductInfo> productsData) {
			if (supplyPaymentElementId.IsEmpty()) {
				throw new ArgumentException(string.Empty, "supplyPaymentElementId");
			}
			if (!productsData.Any()) {
				return;
			}
			Dictionary<Guid, SupplyPaymentProductInfo> supplyPaymentInfo = GetSupplyPaymentProductInfo(supplyPaymentElementId);
			bool isAnyCountError;
			if (supplyPaymentInfo.Count == 0) {
				isAnyCountError = true;
			} else {
				List<SupplyPaymentProductInfo> preparedProductsInfo = PrepareProductsInfo(supplyPaymentInfo, productsData,
					out isAnyCountError);
				bool isAnyProductDeleted = UpdateSupplyPaymentProducts(preparedProductsInfo, supplyPaymentElementId);
				var orderId = supplyPaymentInfo.Values.First().OrderId;
				Guid? doNotAllocateProductsOnElementId = null;
				if (isAnyProductDeleted) {
					doNotAllocateProductsOnElementId = supplyPaymentElementId;
				}
				AllocateSupplyPaymentRestProducts(orderId, doNotAllocateProductsOnElementId);
			}
			if (isAnyCountError) {
				throw new Exception(CannotSetProductCountMessage);
			}
		}

		/// <summary>
		/// Clears the supply payment products.
		/// </summary>
		/// <param name="supplyPaymentElementId">The supply payment element identifier.</param>
		/// <exception cref="System.ArgumentException">
		/// if supplyPaymentElementId is empty or supply payment element does not exist.
		/// </exception>
		public virtual void ClearSupplyPaymentProducts(Guid supplyPaymentElementId) {
			if (supplyPaymentElementId == Guid.Empty) {
				throw new ArgumentException(string.Empty, "supplyPaymentElementId");
			}
			var currentElement = UserConnection.EntitySchemaManager.GetInstanceByName(SupplyPaymentElementSchemaName)
				.CreateEntity(UserConnection);
			if (!currentElement.FetchFromDB(SupplyPaymentProductSchema.GetPrimaryColumnName(), supplyPaymentElementId)) {
				throw new ArgumentException(string.Empty, "supplyPaymentElementId");
			}
			DeleteSupplyPaymentProducts(supplyPaymentElementId);
			OrderAmountHelper.ClearPercentageInElement(currentElement);
		}

		/// <summary>
		/// ############ ######## ## #####, #### # ###### ########## ######## # ### ######## ############ 
		/// ##### ####### #### ### #########
		/// </summary>
		/// <param name="orderId">Id ######</param>
		/// <param name="doNotAllocateOnElementId">Id #### #######, #### ###### ######## ############# ## #####</param>
		public virtual void AllocateSupplyPaymentRestProducts(Guid orderId, Guid? doNotAllocateOnElementId = null) {
			Dictionary<Guid, List<Guid>> allEmptyElements = GetSupplyPaymentElementWithoutProducts(orderId);
			var supplyPaymentElementIds = allEmptyElements.Values.Where(v => v.Count == 1).Select(v => v.First()).ToList();
			if (supplyPaymentElementIds.Count == 0) {
				return;
			}
			foreach (Guid supplyPaymentElementId in supplyPaymentElementIds) {
				if (supplyPaymentElementId == doNotAllocateOnElementId) {
					continue;
				}
				Dictionary<Guid, SupplyPaymentProductInfo> productsInfo = GetSupplyPaymentProductInfo(supplyPaymentElementId);
				productsInfo.Values.ForEach(pi => pi.SetNewQuantity(pi.MaxQuantity));
				AddAllProductsToSupplyPaymentElement(supplyPaymentElementId, productsInfo);
			}
		}

		/// <summary>
		/// Updates supply payment and invoice when bind invoice.
		/// </summary>
		/// <param name="supplyPaymentElementId">The supply payment identifier.</param>
		/// <param name="invoiceId">The invoice identifier.</param>
		public void BindSupplyPaymentElementInvoice(Guid supplyPaymentElementId, Guid invoiceId) {
			supplyPaymentElementId.CheckArgumentEmpty("supplyPaymentElementId");
			invoiceId.CheckArgumentEmpty("invoiceId");
			var selectInvoiceProductWithoutSupplyPaymentProductId = (Select)new Select(UserConnection)
				.Column("ip", "Id").As("InvoiceProductId")
				.Column("spp", "Id").As("SupplyPaymentProductId")			
				.From("InvoiceProduct").As("ip").WithHints(new NoLockHint())
				.InnerJoin("OrderProduct").As("op").WithHints(new NoLockHint())
					.On("ip", "ProductId").IsEqual("op", "ProductId")
				.InnerJoin("SupplyPaymentProduct").As("spp").WithHints(new NoLockHint())
					.On("op", "Id").IsEqual("spp", "ProductId")
				.Where("spp", "SupplyPaymentElementId").IsEqual(Column.Parameter(supplyPaymentElementId))
				.And("ip", "InvoiceId").IsEqual(Column.Parameter(invoiceId))
				.And("ip", "SupplyPaymentProductId").IsNull();
			var values = new Dictionary<Guid, Guid>();
			selectInvoiceProductWithoutSupplyPaymentProductId.ExecuteReader(reader => values.Add(reader.GetGuid(0), reader.GetGuid(1)));
			var queries = new List<Query>(values.Count);
			foreach (var invoiceProductId in values.Keys) {
				var updateInvoiceProduct = new Update(UserConnection, InvoiceProductSchemaName)
					.Set("SupplyPaymentProductId", Column.Parameter(values[invoiceProductId]))
					.Where("Id").IsEqual(Column.Parameter(invoiceProductId));
				queries.Add(updateInvoiceProduct);
			}
			if (queries.Any()) {
				ExecuteQueries(queries.ToArray());
			}	
			OrderAmountHelper.UpdateInvoiceBySupplyPaymentElementId(supplyPaymentElementId);
		}

		/// <summary>
		/// Updates supply payment and invoice when unbind invoice.
		/// </summary>
		/// <param name="supplyPaymentElementId">The supply payment identifier.</param>
		/// <param name="invoiceId">The invoice identifier.</param>
		public void UnbindSupplyPaymentElementInvoice(Guid supplyPaymentElementId, Guid invoiceId) {
			supplyPaymentElementId.CheckArgumentEmpty("supplyPaymentElementId");
			invoiceId.CheckArgumentEmpty("invoiceId");
			var updateSupplyPaymentElement = new Update(UserConnection, SupplyPaymentElementSchemaName)
				.WithHints(new RowLockHint())
				.Set("AmountFact", Column.Parameter(0))
				.Set("PrimaryAmountFact", Column.Parameter(0))
				.Set("DateFact", Column.Const(null))
				.Where("Id").IsEqual(Column.Parameter(supplyPaymentElementId));
			var updateInvoiceStatus = new Update(UserConnection, InvoiceSchemaName)
				.Set("PaymentStatusId", Column.Parameter(PassportConstants.InvoicePaymentStatusCanceled))
				.Where("Id").IsEqual(Column.Parameter(invoiceId));
			var updateInvoiceProduct = new Update(UserConnection, InvoiceProductSchemaName)
				.Set("SupplyPaymentProductId", Column.Const(null))
				.Where("InvoiceId").IsEqual(Column.Parameter(invoiceId));
			ExecuteQueries(new[] { updateSupplyPaymentElement, updateInvoiceStatus, updateInvoiceProduct });
		}

		/// <summary>
		/// Checks total percentage of supply payment items.
		/// Automatically fills left percentage items if ones are not defined.
		/// </summary>
		/// <param name="orderId">The order identifier.</param>
		/// <param name="currentElementId">The current element identifier.</param>
		/// <param name="newPercentageValue">The new percentage value.</param>
		/// <exception cref="System.Exception">
		/// if total percentage is greater than 100%.
		///</exception>
		public void ValidateSupplyPaymentPercentage(Guid orderId, Guid currentElementId, decimal newPercentageValue) {
			PercentageData percentageData = GetSupplyPaymentPercentageData(orderId, currentElementId);
			int percentageColumnPrecision = GetSupplyPaymentElementColumnPrecision("Percentage");
			decimal summaryPercentageValue = percentageData.TotalPercentage - percentageData.CurrentPercentage + newPercentageValue;
			if (Math.Round(summaryPercentageValue, percentageColumnPrecision - 1, MidpointRounding.AwayFromZero) > 100m) {
				decimal percentageRest = newPercentageValue - summaryPercentageValue + 100m;
				string formattedPercentage = percentageRest.ToString("F" + percentageColumnPrecision, 
					UserConnection.CurrentUser.Culture);
				string validationMessage = string.Format(ValidateTotalPercentageErrorMessage, formattedPercentage);
				throw new Exception(validationMessage);
			}
			AllocateSupplyPaymentRestPercentage(percentageData, currentElementId, newPercentageValue);
		}

		/// <summary>
		/// Checks total amount plan of supply payment items.
		/// </summary>
		/// <param name="orderId">The order identifier.</param>
		/// <param name="currentElementId">The current element identifier.</param>
		/// <param name="newAmountPlanValue">The new percentage value.</param>
		/// <exception cref="System.Exception">
		/// if total amount plan is greater than order amount.
		///</exception>
		public void ValidateSupplyPaymentAmountPlan(Guid orderId, Guid currentElementId, decimal newAmountPlanValue) {
			decimal orderTotalAmount = GetOrderTotalAmount(orderId);
			decimal supplyPaymentTotalAmountPlan = GetSupplyPaymentTotalAmountPlan(orderId, currentElementId);
			if (orderTotalAmount - supplyPaymentTotalAmountPlan < newAmountPlanValue) {
				decimal orderAmountRest = orderTotalAmount - supplyPaymentTotalAmountPlan;
				string validationMessage = string.Format(ValidateTotalAmountPlanErrorMessage, orderAmountRest);
				throw new Exception(validationMessage);
			}
		}

		/// <summary>
		/// Validates the order product quantity.
		/// </summary>
		/// <param name="orderProductId">The order product identifier.</param>
		/// <param name="newQuantity">The new quantity.</param>
		/// <exception cref="System.Exception">
		/// if new quantity is greater than total product quantity.
		///</exception>
		public void ValidateOrderProductQuantity(Guid orderProductId, decimal newQuantity) {
			string typeName;
			var maxUsedQuantity = GetMaxOrderProductSpeQuantity(orderProductId, out typeName);
			if (newQuantity < maxUsedQuantity) {
				maxUsedQuantity = Math.Round(maxUsedQuantity, 3);
				string validationMessage = string.Format(ValidateOrderProductQuantityErrorMessage, maxUsedQuantity, typeName);
				throw new Exception(validationMessage);
			}
		}

		#endregion
	}

	#endregion
}



