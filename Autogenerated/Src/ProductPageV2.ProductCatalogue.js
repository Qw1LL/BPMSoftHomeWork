define("ProductPageV2", ["BusinessRuleModule"],
		function(BusinessRuleModule) {
			return {
				entitySchemaName: "Product",
				attributes: {
					/**
					 * Unit changed flag.
					 * @type {Boolean}
					 */
					"IsUnitChanged": {"dataValueType": BPMSoft.DataValueType.BOOLEAN},

					/**
					 * Unit of measure.
					 * @type {Object}
					 */
					"Unit": {
						"dependencies": [{
							"columns": ["Unit"],
							"methodName": "unitChanged"
						}]
					},

					/**
					 * Product base currency.
					 */
					"Currency": {
						"lookupListConfig": {
							"columns": ["Symbol"]
						}
					},

					/**
					 * Type.
					 * @type {Object}
					 */
					"Type": {
						"dependencies": [{
							"columns": ["Category"],
							"methodName": "categoryChanged"
						}]
					},

					/**
					 * Base price list.
					 * @type {Object}
					 */
					"BasePriceList": {
						"dataValueType": BPMSoft.DataValueType.LOOKUP,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Is product price sync enabled.
					 */
					"IsProductPriceSyncEnabled": {
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"value": !BPMSoft.Features.getIsEnabled("DisableProductPriceSync")
					},
				},
				details: /**SCHEMA_DETAILS*/{
					/**
					 * Stock balance detail.
					 */
					"ProductStockBalance": {
						"schemaName": "ProductStockBalanceDetailV2",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Product"
						}
					},

					/**
					 * Unit of measure detail.
					 */
					"ProductUnitDetail": {
						"schemaName": "ProductUnitDetailV2",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Product"
						},
						"subscriber": function(args) {
							args.detailName = "ProductUnitDetail";
							this.onDetailChange(args);
						}
					},

					/**
					 * Price detail.
					 */
					"ProductPriceDetail": {
						"schemaName": "ProductPriceDetailV2",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Product"
						},
						"subscriber": function(args) {
							args.detailName = "ProductPriceDetail";
							this.onDetailChange(args);
						}
					},

					/**
					 * Specification detail.
					 */

					"ProductSpecificationDetail": {
						"schemaName": "ProductSpecificationDetailV2",
						"filter": {
							masterColumn: "Id",
							detailColumn: "Product"
						}
					}

				}/**SCHEMA_DETAILS*/,
				rules: {
					/**
					 * Business rule filtering and autocomplete fields Type and Category.
					 */
					"Type": {
						"FiltrationCategoryByType": {
							"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
							"autocomplete": true,
							"autoClean": true,
							"baseAttributePatch": "Category",
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "Category"
						}
					}
				},
				methods: {
					
					//region Methods: Private
					
					/**
					 * @private
					 */
					_runPriceSynchronization: function(config, callback) {
						var basePriceList = this.get("BasePriceList");
						var batchQuery = this.formOnSavedQuery();
						batchQuery.execute(function(response) {
							if (response.success) {
								var resultUnitSync = response.queryResults[0];
								var resultUpdateBasePriceSync =
									(basePriceList) ? response.queryResults[1].rowsAffected : 0;
								if (resultUnitSync.rows.length) {
									this.reCalculateUnits(resultUnitSync.rows[0], function() {
										this.synchronizePrice(resultUpdateBasePriceSync, config, callback);
									});
								} else {
									this.updateUnit(function() {
										this.synchronizePrice(resultUpdateBasePriceSync, config, callback);
									});
								}
							}
							if (response.errorInfo) {
								this.showInformationDialog(response.errorInfo.message);
								this.Ext.callback(callback, this);
							}
						}, this);
					},

					/**
					 * Crated ProductUnit entity schema query.
					 * @private
					 * @return {BPMSoft.EntitySchemaQuery} ProductUnit entity schema query.
					 */
					createProductUnitEsq: function() {
						return this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ProductUnit"
						});
					},
					
					//endregion
					
					//region Methods: Protected

					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @overriden
					 */
					init: function() {
						this.BPMSoft.SysSettings.querySysSettingsItem("BasePriceList", function(value) {
							this.set("BasePriceList", value);
						}, this);
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#initTabs
					 * @override
					 */
					 initTabs: function() {
						this.removeSelectionInformationTab();
						this.callParent(arguments);
					},

					/**
					 * Removes SelectionInformationTab if feature 'UseNewProductSelection' is disabled.
					 * @protected
					 */
					removeSelectionInformationTab: function() {
						if (this.getIsFeatureEnabled("UseNewProductSelection")) {
							return;
						}
						this.removeTab("SelectionInformationTab");
					},

					/**
					 * Removes tab by name.
					 * @param {String} tabName Tab name.
					 * @protected
					 */
					removeTab: function(tabName) {
						var tabsCollection = this.get("TabsCollection");
						tabsCollection.removeByKey(tabName);
					},

					/**
					 * Updates ProductUnitDetail detail.
					 * @protected
					 */
					updateProductUnitDetail: function() {
						this.updateDetail({detail: "ProductUnitDetail", reloadAll: true});
					},

					/**
					 * Updates ProductPriceDetail detail.
					 * @protected
					 */
					updateProductPriceDetail: function() {
						this.updateDetail({detail: "ProductPriceDetail", reloadAll: true});
					},

					/**
					 * Updates product unit on detail changed.
					 * @protected
					 * @param {Guid} unitId Unit Id.
					 */
					updateProductUnit: function(unitId) {
						var esq = this.createProductUnitEsq();
						esq.addColumn("IsBase");
						esq.addColumn("Unit");
						esq.getEntity(unitId, function(response) {
							if (response.success) {
								var item = response.entity;
								if (item.get("IsBase")) {
									this.set("Unit", item.get("Unit"));
								}
							}
						}, this);
					},

					/**
					 * Adds columns to select query.
					 * @protected
					 * @param {BPMSoft.EntitySchemaQuery} esq Price of product query.
					 */
					addColumnsProductPrice: function(esq) {
						esq.addColumn("Price");
						esq.addColumn("Tax");
						esq.addColumn("PriceList");
						esq.addColumn("Currency");
					},

					/**
					 * Updates product price on detail changed.
					 * @protected
					 * @param {Guid} priceId Price Id.
					 */
					updateProductPrice: function(priceId) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ProductPrice"
						});
						this.addColumnsProductPrice(esq);
						esq.getEntity(priceId, function(response) {
							if (response.success) {
								this.updateProductPriceHandle(response);
							}
						}, this);
					},

					/**
					 * Updates product price.
					 * @protected
					 * @param {Object} response Server response.
					 */
					updateProductPriceHandle: function(response) {
						var item = response.entity;
						var basePriceList = this.get("BasePriceList");
						var priceList = item.get("PriceList");
						if (basePriceList && priceList &&
								(item.get("PriceList").value === basePriceList.value)) {
							if (item.get("Price")) {
								this.set("Price", item.get("Price"));
							}
							if (item.get("Tax")) {
								this.set("Tax", item.get("Tax"));
							}
							if (item.get("Currency")) {
								this.set("Currency", item.get("Currency"));
							}
						}
					},

					/**
					 * Handles detail change event.
					 * @protected
					 * @param {Object} args Arguments.
					 */
					onDetailChange: function(args) {
						if (args.action !== "edit") {
							return;
						}
						var handleUpdateAction = this.getDetailChangeHandleAction(args.detailName);
						this.BPMSoft.each(args.rows, function(itemKey) {
							if (!itemKey) {
								return;
							}
							handleUpdateAction(itemKey);
						}, this);
					},

					/**
					 * Returns detail change handle action.
					 * @protected
					 * @param {String} detailName Detail name.
					 * @return {Function} Handler function.
					 */
					getDetailChangeHandleAction: function(detailName) {
						var action = this.BPMSoft.emptyFn;
						if (detailName === "ProductUnitDetail") {
							action = this.updateProductUnit;
						} else if (detailName === "ProductPriceDetail") {
							action = this.updateProductPrice;
						}
						return action.bind(this);
					},

					/**
					 * Handles unit of measure changing.
					 * @protected
					 */
					unitChanged: function() {
						this.set("IsUnitChanged", true);
					},

					/**
					 * Handles category changing.
					 * @protected
					 */
					categoryChanged: function() {
						this.set("Type", null);
					},

					/**
					 * Returns unit of measure insert query with Base flag.
					 * @protected
					 * @return {BPMSoft.InsertQuery} Unit of measure insert query.
					 */
					getInsertNewUnit: function() {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ProductUnit"
						});
						insert.setParameterValue("Product", this.get("Id"), this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Unit", this.get("Unit").value, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("IsBase", true, this.BPMSoft.DataValueType.BOOLEAN);
						insert.setParameterValue("NumberOfBaseUnits", 1, this.BPMSoft.DataValueType.FLOAT);
						return insert;
					},

					/**
					 * Updates unit of measure.
					 * @protected
					 * @param {Object} callback Callback function.
					 */
					updateUnit: function(callback) {
						var unit = this.get("Unit");
						if (this.get("IsUnitChanged") && !this.Ext.isEmpty(unit) || this.isNewMode()) {
							var update = this.getUnitUpdateQuery(unit);
							update.execute(function(response) {
								this.set("IsUnitChanged", false);
								if (response.rowsAffected === 0) {
									this.getInsertNewUnit().execute(callback, this);
								} else {
									callback.call(this);
								}
							}, this);
						} else if (callback) {
							callback.call(this);
						}
					},

					/**
					 * Return unit of measure update query.
					 * @protected
					 * @virtual
					 * @param {Object} unit Unit of measure.
					 * @return {BPMSoft.UpdateQuery} Unit update query.
					 */
					getUnitUpdateQuery: function(unit) {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "ProductUnit"
						});
						var filters = update.filters;
						var idProduct = this.get("Id");
						var idFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Product", idProduct);
						filters.add("IdFilter", idFilter);
						var isBaseFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "IsBase", true);
						filters.add("isBaseFilter", isBaseFilter);
						update.setParameterValue("Unit", unit.value, this.BPMSoft.DataValueType.GUID);
						return update;
					},

					/**
					 * Returns unit of measure update query with base flag.
					 * @protected
					 * @virtual
					 * @param {Object} config Configuration object.
					 * @return {BPMSoft.UpdateQuery} Update query.
					 */
					getProductUnitUpdateQuery: function(config) {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "ProductUnit"
						});
						var oldNumberOfBaseUnits =
								(this.Ext.isEmpty(config.oldNumberOfBaseUnits) ||
								config.oldNumberOfBaseUnits === 0) ? 1 : config.oldNumberOfBaseUnits;
						var newNumberOfBaseUnits = config.numberOfBaseUnits / oldNumberOfBaseUnits;
						var filters = update.filters;
						filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Product", this.get("Id")));
						filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", config.id));
						update.setParameterValue("IsBase", config.isBase, this.BPMSoft.DataValueType.BOOLEAN);
						update.setParameterValue("NumberOfBaseUnits", newNumberOfBaseUnits,
								this.BPMSoft.DataValueType.FLOAT);
						return update;
					},

					/**
					 * Return unit of measure collection query.
					 * @protected
					 * @virtual
					 * @return {BPMSoft.EntitySchemaQuery} Units of measure query.
					 */
					getProductUnitCollectionEsq: function() {
						var esq = this.createProductUnitEsq();
						esq.addColumn("Id");
						esq.addColumn("Product");
						esq.addColumn("Unit");
						esq.addColumn("IsBase");
						esq.addColumn("NumberOfBaseUnits");
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Product.Id", this.get("Id")));
						return esq;
					},

					/**
					 * Returns unit of measure query.
					 * @protected
					 * @virtual
					 * @return {BPMSoft.EntitySchemaQuery} Unit of measure query.
					 */
					getProductUnitEsq: function() {
						var esq = this.getProductUnitCollectionEsq();
						var unit = this.get("Unit");
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Unit.Id", unit.value));
						return esq;
					},

					/**
					 * Recalculates product units of measure on "Unit" changed.
					 * @protected
					 * @param {Object} productUnit Product config.
					 * @param {Object} callback Callback function.
					 */
					reCalculateUnits: function(productUnit, callback) {
						var esq = this.getProductUnitEsq();
						esq.getEntityCollection(function(response) {
							if (response.success) {
								var batch = this.formProductUnitUpdateBatch(response.collection, productUnit);
								batch.execute(function() {
									callback.call(this);
								}, this);
							} else {
								callback.call(this);
							}
						}, this);
					},

					/**
					 * Forms product units update batch query.
					 * @param {BPMSoft.BaseViewModelCollection} productUnitCollection Units collection.
					 * @param {Object} oldUnit Old unit.
					 * @return {BPMSoft.BatchQuery} Product units update batch query.
					 */
					formProductUnitUpdateBatch: function(productUnitCollection, oldUnit) {
						var batch = this.Ext.create("BPMSoft.BatchQuery");
						productUnitCollection.each(function(item) {
							var update;
							if (this.get("Unit").value !== item.get("Unit").value) {
								update = this.getProductUnitUpdateQuery({
									id: item.get("Id"),
									numberOfBaseUnits: item.get("NumberOfBaseUnits"),
									oldNumberOfBaseUnits: oldUnit.NumberOfBaseUnits,
									isBase: false
								});
							} else {
								update = this.getProductUnitUpdateQuery({
									id: item.get("Id"),
									numberOfBaseUnits: 1,
									oldNumberOfBaseUnits: 1,
									isBase: true
								});
							}
							batch.add(update, function() {}, this);
						}, this);
						return batch;
					},

					/**
					 * Synchronizes Unit field with Unit detail.
					 * @protected
					 * @param {Object} response Service response.
					 */
					synchronizeUnit: function(response) {
						if (response.success && response.collection.getCount() > 0) {
							this.set("NeedRecalculateUnits", {
								resultCollection: response.collection.getItems()[0]
							});
						} else {
							this.set("NeedRecalculateUnits", false);
						}
					},

					/**
					 * Performs base price list record insert on new product save.
					 * @protected
					 * @param {Object} callback Callback function.
					 */
					insertBasePrice: function(callback) {
						var basePriceList = this.get("BasePriceList");
						if (basePriceList) {
							var insert = this.getProductPriceInsertQuery(basePriceList.value);
							insert.execute(callback, this);
						} else {
							callback.call(this);
						}
					},

					/**
					 * Returns product price insert query.
					 * @param {Guid} priceListId Price list Id.
					 * @return {BPMSoft.InsertQuery} Product price insert query.
					 */
					getProductPriceInsertQuery: function(priceListId) {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "ProductPrice"
						});
						insert.setParameterValue("Product", this.get("Id"), this.BPMSoft.DataValueType.GUID);
						var currency = this.get("Currency");
						if (this.Ext.isEmpty(currency)) {
							currency = {value: null};
						}
						insert.setParameterValue("Currency", currency.value, this.BPMSoft.DataValueType.GUID);
						var tax = this.get("Tax");
						if (this.Ext.isEmpty(tax)) {
							tax = {value: null};
						}
						insert.setParameterValue("Tax", tax.value, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("PriceList", priceListId, this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Price", this.get("Price"), this.BPMSoft.DataValueType.FLOAT);
						return insert;
					},

					/**
					 * Synchronizes fields with price detail record, that corresonds to base price list.
					 * @protected
					 * @param {Object} response Server response.
					 * @param {Object} config Configuration object.
					 * @param {Function} callback Success callback.
					 */
					synchronizePrice: function(response, config, callback) {
						if (!response) {
							this.insertBasePrice(function() {
								this.updateProductPriceDetail();
								this.updateProductUnitDetail();
							});
						} else {
							this.updateProductPriceDetail();
							this.updateProductUnitDetail();
						}
						this.Ext.callback(callback, this);
					},

					/**
					 * Returns base price update query.
					 * @protected
					 * @virtual
					 * @return {BPMSoft.UpdateQuery} Base price update query.
					 */
					getUpdateBasePrice: function() {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "ProductPrice"
						});
						var filters = update.filters;
						var idProduct = this.get("Id");
						var idFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Product", idProduct);
						filters.add("IdFilter", idFilter);
						var basePriceList = this.get("BasePriceList");
						var isBaseFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "PriceList", basePriceList.value);
						filters.add("isBaseFilter", isBaseFilter);
						update.setParameterValue("Price", this.get("Price"), this.BPMSoft.DataValueType.FLOAT);
						var currency = this.get("Currency");
						if (this.Ext.isEmpty(currency)) {
							currency = {value: null};
						}
						update.setParameterValue("Currency", currency.value, this.BPMSoft.DataValueType.GUID);
						var tax = this.get("Tax");
						if (this.Ext.isEmpty(tax)) {
							tax = {value: null};
						}
						update.setParameterValue("Tax", tax.value, this.BPMSoft.DataValueType.GUID);
						return update;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onSaved
					 * @override
					 */
					onSaved: function(response, config) {
						const parentMethod = this.getParentMethod(this, arguments);
						this.handleOnSavedEvent(config, parentMethod);
					},

					/**
					 * Handles onSaved event.
					 * @protected
					 * @virtual
					 * @param {Object} config Configuration object.
					 * @param {Function} callback Success callback.
					 */
					handleOnSavedEvent: function(config, callback) {
						if (this.$IsProductPriceSyncEnabled) {
							this._runPriceSynchronization(config, callback);
						} else {
							this.Ext.callback(callback, this);
						}
					},

					/**
					 * Forms onSaved event update query.
					 * @protected
					 * @virtual
					 * @return {BPMSoft.BatchQuery} Returns formed batch query.
					 */
					formOnSavedQuery: function() {
						var basePriceList = this.get("BasePriceList");
						var batchQuery = Ext.create("BPMSoft.BatchQuery");
						batchQuery.add(this.getProductUnitEsq());
						if (basePriceList) {
							batchQuery.add(this.getUpdateBasePrice());
						}
						return batchQuery;
					}
					
					//endregion
				},
				diff: /**SCHEMA_DIFF*/[
// Tabs and groups
					{
						"operation": "insert",
						"name": "SelectionInformationTab",
						"index": 2,
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.SelectionInformationTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ProductPricesTab",
						"index": 3,
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.PricesTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ProductSpecificationTab",
						"index": 4,
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.SpecificationTabCaption"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ProductCategoryControlGroup",
						"parentName": "ProductGeneralInfoTab",
						"propertyName": "items",
						"index": 0,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.CategoryGroupCaption"},
							"items": [],
							"controlConfig": {
								"collapsed": false
							}
						}
					},
					{
						"operation": "insert",
						"name": "ProductCategoryBlock",
						"parentName": "ProductCategoryControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "merge",
						"name": "PriceControlGroup",
						"parentName": "ProductGeneralInfoTab",
						"propertyName": "items",
						"index": 2,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.BasePriceGroupCaption"},
							"markerValue": {"bindTo": "Resources.Strings.BasePriceGroupCaption"}
						}
					},
					{
						"operation": "insert",
						"name": "SelectionInformationControlGroup",
						"parentName": "SelectionInformationTab",
						"propertyName": "items",
						"index": 0,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.ProductInformation"},
							"items": [],
							"controlConfig": {
								"collapsed": false
							}
						}
					},
					{
						"operation": "insert",
						"name": "SelectionInformationBlock",
						"parentName": "SelectionInformationControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
// Columns and details
					{
						"operation": "insert",
						"parentName": "ProductPricesTab",
						"propertyName": "items",
						"name": "ProductPriceDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ProductPricesTab",
						"propertyName": "items",
						"name": "ProductStockBalance",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ProductSpecificationTab",
						"propertyName": "items",
						"name": "ProductSpecificationDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ProductGeneralInfoTab",
						"propertyName": "items",
						"name": "ProductUnitDetail",
						"index": 3,
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "merge",
						"name": "Code",
						"parentName": "ProductGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Code",
							"layout": {"column": 0, "row": 0, "colSpan": 11}
						}
					},
					{
						"operation": "merge",
						"name": "Owner",
						"parentName": "ProductGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Owner",
							"layout": {"column": 13, "row": 0, "colSpan": 11}
						}
					},
					{
						"operation": "merge",
						"name": "URL",
						"parentName": "ProductGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "URL",
							"layout": {"column": 0, "row": 1, "colSpan": 11}
						}
					},
					{
						"operation": "merge",
						"name": "IsArchive",
						"parentName": "ProductGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "IsArchive",
							"layout": {"column": 13, "row": 1, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"name": "ShortDescription",
						"parentName": "SelectionInformationBlock",
						"propertyName": "items",
						"values": {
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"contentType": BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "insert",
						"name": "GeneralConditions",
						"parentName": "SelectionInformationBlock",
						"propertyName": "items",
						"values": {
							"layout": {"column": 0, "row": 2, "colSpan": 24},
							"contentType": BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "insert",
						"name": "Benefits",
						"parentName": "SelectionInformationBlock",
						"propertyName": "items",
						"values": {
							"layout": {"column": 0, "row": 4, "colSpan": 24},
							"contentType": BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "move",
						"name": "Unit",
						"parentName": "ProductPriceBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Unit",
							"layout": {"column": 0, "row": 1, "colSpan": 11},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "Category",
						"parentName": "ProductCategoryBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Category",
							"layout": {"column": 0, "row": 0, "colSpan": 11},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "move",
						"name": "Type",
						"parentName": "ProductCategoryBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Type",
							"layout": {"column": 0, "row": 1, "colSpan": 11},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "TradeMark",
						"parentName": "ProductCategoryBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "TradeMark",
							"layout": {"column": 13, "row": 0, "colSpan": 11}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
