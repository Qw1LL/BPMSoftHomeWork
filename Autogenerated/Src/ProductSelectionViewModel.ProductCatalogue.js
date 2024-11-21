define("ProductSelectionViewModel", ["ProductSelectionViewModelResources", "MoneyModule", "MaskHelper",
		"ProductManagementDistributionConstants", "ProductUtilitiesV2", "MoneyUtilsMixin"],
	function(resources, MoneyModule, MaskHelper, DistributionConstants) {

		/**
		 * ########## ############ ###### ############# ###### ###### #########
		 * @param {Object} sandbox
		 * @param {Object} BPMSoft
		 * @param {Object} Ext
		 * @return {Object}
		 */
		function generate(sandbox, BPMSoft, Ext) {
			var viewModelConfig = {
				properties: {
					/**
					 * Defines folder manager view model class name
					 */
					folderManagerViewModelClassName: "BPMSoft.ProductCatalogueFolderManagerViewModel",
					/**
					 * Defines folder manager view config generator module name
					 */
					folderManagerViewConfigGenerator: "ProductCatalogueFolderManagerViewConfigGenerator",
					/**
					 * Defines folder manager view model config generator module name
					 */
					folderManagerViewModelConfigGenerator: "ProductCatalogueFolderManagerViewModelConfigGenerator",
					/**
					 * Defines folder manager module name
					 */
					folderManagerModuleName: "ProductCatalogueFolderManager"
				},
				columns: {
					/**
					 * ############ ########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					Name: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "Name"
					},

					/**
					 * #### ########
					 * @type {BPMSoft.dataValueType.FLOAT}
					 */
					Price: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "Price"
					},

					/**
					 * ########### ######## ## #######
					 * @type {BPMSoft.dataValueType.FLOAT}
					 */
					Available: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "Available"
					},

					/**
					 * ########## #########
					 * @type {BPMSoft.dataValueType.FLOAT}
					 */
					Count: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "Count"
					},

					/**
					 * ####### #########
					 * @type {BPMSoft.dataValueType.LOOKUP}
					 */
					Unit: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "Unit"
					},

					/**
					 * ######### # ######### # ######### #########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					AvailableIn: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "AvailableIn"
					},

					/**
					 * ########## ######### # ######### #########
					 * @type {BPMSoft.dataValueType.FLOAT}
					 */
					AvailableInCount: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "AvailableInCount"
					}
				},
				mixins: {
					MoneyUtilities: "BPMSoft.MoneyUtilsMixin"
				},
				values: {
					/**
					 * ######## #####
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					EntitySchemaName: "Product",

					/**
					 * #####
					 * @type {Object}
					 */
					EntitySchema: null,

					/**
					 * ######## ##### ######
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					ProductDetailEntitySchemaName: null,

					/**
					 * ##### ######
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					MasterEntitySchemaName: null,

					/**
					 * ############# ###### ######
					 * @type {BPMSoft.dataValueType.GUID}
					 */
					MasterRecordId: null,

					/**
					 * ###### ######
					 * @type {Object}
					 */
					MasterEntity: null,

					/**
					 * ####### #############
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					CurrentDataView: "GridDataView",

					/**
					 * ######### ############# ######
					 * @type {BPMSoft.Collection}
					 */
					DataViews: null,

					/**
					 * ######### ####### #######
					 * @type {BPMSoft.Collection}
					 */
					GridData: new BPMSoft.Collection(),

					/**
					 * ######### ####### ####### #############
					 * @type {BPMSoft.Collection}
					 */
					DataViewGridCollection: new BPMSoft.Collection(),

					/**
					 * ######### ####### ####### ############# #######
					 * @type {BPMSoft.Collection}
					 */
					BasketViewGridCollection: new BPMSoft.Collection(),

					/**
					 * ######### ######## ########
					 * @type {Object}
					 */
					CatalogueFilters: null,

					/**
					 * ######## ######### ######### "####### #####-####"
					 * @type {Object}
					 */
					BasePriceList: null,

					/**
					 * ######### ####### ###
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					CodeLabel: resources.localizableStrings.CodeCaption,

					/**
					 * ######### ####### ########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					NameLabel: resources.localizableStrings.NameCaption,

					/**
					 * ######### ####### ####
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					PriceLabel: resources.localizableStrings.PriceCaption,

					/**
					 * ######### ####### ########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					AvailableLabel: resources.localizableStrings.AvailableCaption,

					/**
					 * ######### ####### ##########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					CountLabel: resources.localizableStrings.CountCaption,

					/**
					 * ######### ####### ####### #########
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					UnitLabel: resources.localizableStrings.UnitCaption,

					/**
					 * ######## ######
					 * @type {BPMSoft.dataValueType.TEXT}
					 */
					ModuleName: "ProductSelectionModule",

					/**
					 * ####### ####, ### ##### ########### #######.
					 * @type {Boolean}
					 */
					NeedRecalc: false,

					/**
					 * ####### ####, ### ##### ######### ##### ##### #########.
					 * @type {Boolean}
					 */
					NeedSave: false
				},
				methods: {
					/**
					 *
					 */
					onGetItemConfig: function() {
						//console.log(arguments);
					},

					/**
					 * ######### ######### ######### ####### ####### #########.
					 * @protected
					 * @param {BPMSoft.Collection} filter ######.
					 * @param {BPMSoft.Collection} list ######### ######### #######.
					 */
					fillUnitItems: function(filter, list) {
						if (list === null) {
							return;
						}
						list.clear();
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Unit"
						});
						select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						var column = select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
						column.orderDirection = BPMSoft.OrderDirection.ASC;
						column.orderPosition = 0;
						select.addColumn("[ProductUnit:Unit:Id].NumberOfBaseUnits", "NumberOfBaseUnits");
						select.addColumn("[ProductUnit:Unit:Id].IsBase", "IsBase");
						select.rowCount = -1;
						var productKey = this.get("RealRecordId") || this.get("Id");
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"[ProductUnit:Unit:Id].Product.Id", productKey));
						select.getEntityCollection(function(result) {
							var collection = result.collection;
							var columns = {};
							if (collection && collection.collection.length > 0) {
								BPMSoft.each(collection.collection.items, function(item) {
									var id = item.get("Id");
									var it = {
										displayValue: item.get("Name"),
										value: id,
										NumberOfBaseUnits: item.get("NumberOfBaseUnits"),
										IsBase: item.get("IsBase")
									};
									if (!list.contains(id)) {
										columns[id] = it;
									}
								}, this);
								list.loadAll(columns);
							}
						}, this);
					},
// Initialization
					/**
					 * ############## ###### ####### #########.
					 * @protected
					 * @param {Object} config ######.
					 */
					init: function(config) {
						MaskHelper.ShowBodyMask();
						this.registerMessages();
						if (config) {
							this.set("EntitySchema", config.EntitySchema);
							this.set("ProductDetailEntitySchemaName", config.productDetailEntitySchemaName || null);
							this.set("MasterEntitySchemaName", config.masterEntitySchemaName || null);
							this.set("MasterRecordId", config.masterRecordId || null);
							this.set("BasePriceList", config.BasePriceList);

							this.requestMasterEntityData(this.initCallback);
						} else {
							this.initCallback();
						}
					},

					/**
					 * ############# ############# ######
					 * Callback #######
					 * @protected
					 */
					initCallback: function() {
						this.initProductUtilities(function() {
							BPMSoft.SysSettings.querySysSettings(["PriceWithTaxes", "PrimaryCurrency",
								"BasePriceList", "DefaultTax"], function(values) {
								this.set("CurrentDataView", "GridDataView");
								this.set("PrimaryCurrency", values.PrimaryCurrency);
								var productUtilities = this.getProductUtilities();
								productUtilities.PriceWithTaxes = values.PriceWithTaxes;
								MoneyModule.LoadCurrencyRate.call(this, "PrimaryCurrency", "PrimaryCurrencyRate", new Date(Date.now()));
								this.subscribeMessages();
								this.loadGridData();
							}, this);
						}, this);
					},

					/**
					 * ########### ###### ## ###### ######.
					 * @protected
					 * @param {Function} callback #######.
					 */
					requestMasterEntityData: function(callback) {
						if (this.get("MasterRecordId")) {
							var select = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: this.get("MasterEntitySchemaName")
							});
							select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
							select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
							select.addColumn("Currency");
							select.addColumn("Currency.Symbol");
							select.addColumn("Currency.ShortName");
							select.addColumn("CurrencyRate");
							select.addColumn("Currency.Division");
							select.getEntity(this.get("MasterRecordId"), function(result) {
								if (result.success) {
									this.set("MasterEntity", result.entity);
									var currencySymbol = (!Ext.isEmpty(result.entity.get("Currency.Symbol")) ?
											result.entity.get("Currency.Symbol") :
											result.entity.get("Currency.ShortName")) || "";
									this.setPriceCaption(currencySymbol);
									this.setSummaryCurrencySymbol(currencySymbol);
									callback.call(this);
								}
							}, this);
						}
					},

					/**
					 * ######### ######### ###### ####### # ######
					 * @protected
					 */
					onLoadNext: function() {
						if (this.get("CurrentDataView") === "GridDataView") {
							this.loadGridData();
						}
					},

					/**
					 * ########### #######
					 * @protected
					 */
					registerMessages: function() {
						var messages = {
							/**
							 * @message CardSaved
							 * ######### ##########, # ###, ### ############ ######## ###########
							 */
							"CardSaved": {
								mode: BPMSoft.MessageMode.BROADCAST,
								direction: BPMSoft.MessageDirectionType.PUBLISH
							}

						};
						sandbox.registerMessages(messages);
					},

					/**
					 * ######## ########### #######
					 * @protected
					 */
					unRegisterMessages: function() {
						sandbox.unRegisterMessages(["ChangeDataView"]);
					},

					/**
					 * ######## ## #######
					 * @protected
					 */
					subscribeMessages: function() {
						sandbox.subscribe("ChangeDataView", this.changeDataView, this,
							["ViewModule_MainHeaderModule_" + this.get("ModuleName")]);
						this.initDataViews(false);
						sandbox.subscribe("NeedHeaderCaption", function() {
							this.initDataViews();
						}, this);
					},

					/**
					 * ############## ####### ######.
					 * @protected
					 * @param {Boolean} isCommandLineVisible
					 */
					initDataViews: function(isCommandLineVisible) {
						sandbox.publish("InitDataViews", {
							caption: this.getModuleCaption(),
							dataViews: this.getDataViews(),
							isCommandLineVisible: isCommandLineVisible,
							moduleName: this.get("ModuleName"),
							hidePageCaption: true
						});
					},

					/**
					 * ######## ####### #############.
					 * @protected
					 * @param {Object} viewConfig ###### #############.
					 */
					changeDataView: function(viewConfig) {
						if (viewConfig.moduleName === this.get("ModuleName")) {
							if (this.get("CurrentDataView") === viewConfig.tag) {
								return;
							}
							var wAC = Ext.get("workingAreaContainer");
							if (viewConfig.tag === "BasketDataView") {
								this.set("CurrentDataView", viewConfig.tag);
								if (!wAC.hasCls("no-folders")) {
									wAC.addCls("no-folders");
								}
								this.saveDataViewGridCollection();
								this.loadBasketGridData();
								sandbox.publish("UpdateQuickSearchFilterString", {
									newSearchStringValue: "",
									autoApply: false
								});
							} else {
								this.set("CurrentDataView", viewConfig.tag);
								wAC.removeCls("no-folders");
								sandbox.publish("UpdateQuickSearchFilterString", {
									newSearchStringValue: this.get("QuickSearchFilterString"),
									autoApply: false
								});
								this.reloadDataViewGridCollection();
							}
						}
					},

					/**
					 * ######### ########## ######### ############# ######
					 * @protected
					 */
					saveDataViewGridCollection: function() {
						var gridData = this.getGridData();
						var dataCollection = new BPMSoft.Collection();
						gridData.each(function(item) {
							dataCollection.add(item.get("Id"), item);
						}, this);
						this.set("DataViewGridCollection", dataCollection);
					},

					/**
					 * ######### ############ ############# ######
					 * @protected
					 */
					reloadDataViewGridCollection: function() {
						var collection = this.get("DataViewGridCollection");
						var basket = this.getBasketData();
						basket.each(function(basketItem) {
							var basketItemCount = basketItem.get("Count");
							var basketItemUnit = basketItem.get("Unit");
							var basketItemPrice = basketItem.get("Price");
							var item = collection.find(basketItem.get("Id"));
							if (item) {
								var count = item.get("Count");
								if (basketItemCount !== count) {
									item.set("Count", basketItemCount);
								}
								var unit = item.get("Unit");
								if (unit !== basketItemUnit) {
									item.set("Unit", basketItemUnit);
								}
								var price = item.get("Price");
								if (price !== basketItemPrice) {
									item.set("Price", basketItemPrice);
								}
							}
						}, this);
						var gridData = this.getGridData();
						gridData.clear();
						gridData.loadAll(collection);
					},

					/**
					 * ######### ######## ############# #######
					 * @protected
					 * @virtual
					 */
					loadBasketGridData: function() {
						var dataCollection = new BPMSoft.Collection();
						var basket = this.getBasketData();
						basket.each(function(item) {
							if (item.get("Count") > 0) {
								var cloneItem = this.cloneProduct(item);
								this.prepareItem(cloneItem);
								cloneItem.on("change", this.onDataGridItemChanged, this);
								cloneItem.on("change:Unit", this.onUnitChanged, this);
								cloneItem.on("change:Count", this.onCountChanged, this);
								cloneItem.on("change:Price", this.onPriceChanged, this);
								dataCollection.add(cloneItem.get("Id"), cloneItem);
							}
						}, this);
						var gridData = this.getGridData();
						gridData.clear();
						gridData.loadAll(dataCollection);
						this.set("BasketViewGridCollection", dataCollection);
					},

					/**
					 * ######### ###### ########.
					 * @param {Object} product #######.
					 * @return {BaseViewModel} ########## ##### ###### ########.
					 */
					cloneProduct: function(product) {
						var values = Ext.apply(product.values, product.changedValues);
						return this.getGridRecordByItemValues(values, this.get("EntitySchema"));
					},
					
					/**
					 * Get ESQ for main product data.
					 * @protected
					 * @return {BPMSoft.EntitySchemaQuery} main products data ESQ.
					 */
					getMainDataEsq: function() {
						var sortColumnLastValue = this.get("sortColumnLastValue");
						var esq = this.getGridDataESQ();
						esq.rowCount = 30;
						this.initQueryColumns(esq);
						this.initQueryFilters(esq);
						this.initializePageableOptions(esq, sortColumnLastValue);
						this.initMainDataEsqFilters(esq);
						return esq;
					},
					
					/**
					 * Init filters for main products data ESQ.
					 * @protected
					 */
					initMainDataEsqFilters: function(esq) {
						esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"IsArchive", false));
					},

					/**
					 * Get ESQ for connected to master entity products.
					 * @protected
					 * @return {BPMSoft.EntitySchemaQuery} connected to master entity products ESQ.
					 */
					getProductInMasterEntityEsq: function(masterEntity) {
						var esqEntitySchemaName = this.get("MasterEntitySchemaName") + this.get("EntitySchemaName");
						var partColumnName = "[" + esqEntitySchemaName + ":Product:Id].";
						var sumCountColumnName = partColumnName + "Quantity";
						var productInCountEsq = this.getGridDataESQ();
						productInCountEsq.addColumn(partColumnName + "Id", esqEntitySchemaName + "Id");
						productInCountEsq.addColumn(partColumnName + "Product.Code", "Code");
						productInCountEsq.addColumn(partColumnName + "Product.IsArchive", "IsArchive");
						productInCountEsq.addColumn(partColumnName + "Unit", "Unit");
						productInCountEsq.addColumn(partColumnName + "Unit", "UnitIn");
						productInCountEsq.addColumn(partColumnName + "Price", "Price");
						productInCountEsq.addColumn(partColumnName + "Quantity", "Quantity");
						productInCountEsq.addColumn(partColumnName + "PrimaryPrice", "PrimaryPrice");
						productInCountEsq.addColumn(partColumnName + "PrimaryAmount", "PrimaryAmount");
						productInCountEsq.addColumn(partColumnName + "Amount", "Amount");
						productInCountEsq.addColumn(partColumnName + "PrimaryDiscountAmount", "PrimaryDiscountAmount");
						productInCountEsq.addColumn(partColumnName + "DiscountAmount", "DiscountAmount");
						productInCountEsq.addColumn(partColumnName + "DiscountPercent", "DiscountPercent");
						productInCountEsq.addColumn(partColumnName + "Tax", "Tax");
						productInCountEsq.addColumn(partColumnName + "Tax.Percent", "TaxPercent");
						productInCountEsq.addColumn(partColumnName + "PrimaryTaxAmount", "PrimaryTaxAmount");
						productInCountEsq.addColumn(partColumnName + "TaxAmount", "TaxAmount");
						productInCountEsq.addColumn(partColumnName + "PrimaryTotalAmount", "PrimaryTotalAmount");
						productInCountEsq.addColumn(partColumnName + "TotalAmount", "TotalAmount");
						productInCountEsq.addColumn(partColumnName + "DiscountTax", "DiscountTax");
						productInCountEsq.addColumn(partColumnName + "BaseQuantity", "BaseQuantity");
						productInCountEsq.addColumn(partColumnName + "PriceList", "PriceList");
						productInCountEsq.addAggregationSchemaColumn("[ProductStockBalance:Product:Id].AvailableQuantity",
							BPMSoft.AggregationType.SUM, "Available");
						productInCountEsq.addColumn(sumCountColumnName, "AvailableIn");
						productInCountEsq.filters.addItem(
							BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								Ext.String.format("{0}{1}.Id", partColumnName, this.get("MasterEntitySchemaName")),
								masterEntity.get("Id")));
						productInCountEsq.filters.addItem(BPMSoft.createColumnIsNotNullFilter(sumCountColumnName));
						this.initQueryFilters(productInCountEsq);
						return productInCountEsq;
					},
					
					/**
					 * Get ESQ for products in base price list.
					 * @protected
					 * @return {BPMSoft.EntitySchemaQuery} products in base price list ESQ.
					 */
					getProductInBasePriceListEsq: function(basePriceList) {
						var basePriceListProductEsq = this.getGridDataESQ();
						var sortColumnLastValue = this.get("sortColumnLastValue");
						basePriceListProductEsq.rowCount = 40;
						basePriceListProductEsq.addColumn("Price", "ProductPrice");
						basePriceListProductEsq.addColumn("[ProductPrice:Product:Id].Price", "Price");
						basePriceListProductEsq.addColumn("[ProductPrice:Product:Id].Currency", "Currency");
						basePriceListProductEsq.addColumn("[ProductPrice:Product:Id].Tax", "Tax");
						basePriceListProductEsq.addColumn("[ProductPrice:Product:Id].Tax.Percent", "DiscountTax");
						basePriceListProductEsq.filters.addItem(BPMSoft.createFilter(BPMSoft.ComparisonType.EQUAL,
							"[ProductPrice:Product:Id].Product.Id", "Id"));
						basePriceListProductEsq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "[ProductPrice:Product:Id].PriceList.Id",
							basePriceList.value));
						basePriceListProductEsq.filters.addItem(
							BPMSoft.createColumnIsNotNullFilter("[ProductPrice:Product:Id].Price"));
						this.initQueryFilters(basePriceListProductEsq);
						this.initializePageableOptions(basePriceListProductEsq, sortColumnLastValue);
						basePriceListProductEsq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"IsArchive", false));
						return basePriceListProductEsq;
					},
					
					/**
					 * Loads product selection grid data.
					 * @protected
					 * @virtual
					 */
					loadGridData: function() {
						MaskHelper.ShowBodyMask();
						var batchQuery = Ext.create("BPMSoft.BatchQuery");
						var mainEsq = this.getMainDataEsq();
						batchQuery.add(mainEsq);
						
						var basePriceList = this.get("BasePriceList");
						if (basePriceList) {
							var basePriceListProductEsq = this.getProductInBasePriceListEsq(basePriceList);
							batchQuery.add(basePriceListProductEsq);
						}
						
						var masterEntity = this.get("MasterEntity");
						if (masterEntity) {
							var masterEntityEsq = this.getProductInMasterEntityEsq(masterEntity);
							batchQuery.add(masterEntityEsq);
						}
						
						this.set("sortColumnLastValue", null);
						batchQuery.execute(this.onGridDataLoaded, this);
					},

// Grid
					/**
					 * ####### ######### ###### BPMSoft.EntitySchemaQuery.
					 * ############## ### ########## rootSchema.
					 * @protected
					 * @return {BPMSoft.EntitySchemaQuery} ########## ######### ###### BPMSoft.EntitySchemaQuery.
					 */
					getGridDataESQ: function() {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.get("EntitySchemaName")
						});
						esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						var column = esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
						column.orderPosition = 0;
						column.orderDirection = BPMSoft.OrderDirection.ASC;
						return esq;
					},

					/**
					 * ############## ####### #######
					 * @protected
					 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
					 */
					initQueryColumns: function(esq) {
						esq.addAggregationSchemaColumn("[ProductStockBalance:Product:Id].AvailableQuantity",
							BPMSoft.AggregationType.SUM, "Available");
						esq.addColumn("Unit");
						esq.addColumn("Price");
						esq.addColumn("Currency");
						esq.addColumn("Tax");
						esq.addColumn("Code");
						esq.addColumn("IsArchive");
					},

					/**
					 * Initializes query filters.
					 * @protected
					 * @param {BPMSoft.EntitySchemaQuery} esq
					 */
					initQueryFilters: function(esq) {
						var catalogueFilters = this.get("CatalogueFilters");
						var quickSearchFilters = this.get("QuickSearchFilters");
						if (catalogueFilters) {
							esq.filters.add("CatalogueFilters", catalogueFilters);
						}
						if (quickSearchFilters) {
							esq.filters.add("QuickSearchFilters", quickSearchFilters);
						}
					},

					/**
					 * ############ ##### ####### ######## ###### ### #######.
					 * @protected
					 * @param {Object} response ##### #######.
					 */
					onGridDataLoaded: function(response) {
						if (!response.success) {
							return;
						}
						var dataCollection = new BPMSoft.Collection();
						this.prepareResponseCollection(dataCollection, response);
						var lastValue = null;
						var gridData = this.getGridData();
						var canLoadData = false;
						if (dataCollection.getCount()) {
							var lastItemIndex = dataCollection.getCount() - 1;
							var lastItem = dataCollection.getByIndex(lastItemIndex);
							var products = gridData.collection.filterBy(
								function(res) {
									var resId = res.get("RealRecordId");
									return resId === lastItem.get("RealRecordId");
								}
							);
							if ((products.length <= 0)) {
								lastValue = lastItem.get("Name");
								canLoadData = true;
							}
						}
						this.set("sortColumnLastValue", lastValue);
						if (canLoadData) {
							gridData.loadAll(dataCollection);
						}
						MaskHelper.HideBodyMask();
					},

					/**
					 * ########## ### ###### #######
					 * @protected
					 * @param {Object} record ####### ######### ###
					 * @param {String} columnName ######## #######
					 * @returns {Object} ### ###### #######
					 */
					getDataValueType: function(record, columnName) {
						var recordColumn = record.columns[columnName] ?
							record.columns[columnName] :
							record.entitySchema.columns[columnName];
						return recordColumn ? recordColumn.dataValueType : null;
					},

					/**
					 * ############## ######## ############## EntitySchemaQuery
					 * @protected
					 * @param {BPMSoft.EntitySchemaQuery} select ######
					 * @param {String} sortColumnLastValue ######### ######## # #######
					 * @private
					 */
					initializePageableOptions: function(select, sortColumnLastValue) {
						if (sortColumnLastValue && this.get("GridData").getCount()) {
							select.filters.add("LastValueFilter", BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.GREATER,
								"Name", sortColumnLastValue));
						}
					},

					/**
					 * ########## ############ ####### ###### # #######
					 * @returns {Object}
					 */
					getProductRowConfig: function() {
						var rowConfig = {
							Amount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Available: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							AvailableIn: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							BaseQuantity: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Count: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Code: {
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							DiscountAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							DiscountPercent: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							DiscountTax: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Id: {
								dataValueType: BPMSoft.DataValueType.GUID
							},
							InvoiceProductId: {
								dataValueType: BPMSoft.DataValueType.GUID
							},
							IsArchive: {
								dataValueType: BPMSoft.DataValueType.BOOLEAN
							},
							Name: {
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							Price: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							PriceList: {
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "Pricelist"
							},
							PrimaryAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							PrimaryDiscountAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							PrimaryPrice: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							PrimaryTaxAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							PrimaryTotalAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Quantity: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Tax: {
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "Tax"
							},
							TaxAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							TaxPercent: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							TotalAmount: {
								dataValueType: BPMSoft.DataValueType.FLOAT
							},
							Unit: {
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "Unit"
							},
							UnitIn: {
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								isLookup: true,
								referenceSchemaName: "Unit"
							}
						};
						return rowConfig;
					},

					/**
					 * ########## ########### ############ ###### #######.
					 * @protected
					 * @param {BPMSoft.Collection} rowValues ######## ######.
					 * @param {BPMSoft.EntitySchema} entitySchema ##### ######.
					 * @return {BaseViewModel}
					 */
					getGridRecordByItemValues: function(rowValues, entitySchema) {
						var gridRecord = Ext.create("BPMSoft.BaseViewModel", {
							entitySchema: entitySchema,
							rowConfig: this.getProductRowConfig(),
							values: rowValues,
							isNew: false,
							isDeleted: false,
							methods: {}
						});
						return gridRecord;
					},

					/**
					 * ############ ######### ###### ##### ######### # ######.
					 * @protected
					 * @param {BPMSoft.Collection} collection ######### ######### #######.
					 * @param {Object} response ##### #######.
					 */
					prepareResponseCollection: function(collection, response) {
						var esqEntitySchemaName = this.get("MasterEntitySchemaName") + this.get("EntitySchemaName") + "Id";
						var productSelectResponse = response.queryResults[0];
						var productInEntityResponse = response.queryResults[response.queryResults.length - 1];
						var basket = this.getBasketData();
						BPMSoft.each(productInEntityResponse.rows, function(row) {
							var item = this.getGridRecordByItemValues(row, this.get("EntitySchema"));
							var itemId = item.get("Id");
							item.set("RealRecordId", itemId);
							var customKey = itemId + "_" + item.get(esqEntitySchemaName);
							item.set("Id", customKey);
							var availableIn = row.AvailableIn;
							item.set("Count", availableIn);
							item.set("AvailableInCount", availableIn);
							var masterEntity = this.get("MasterEntity");
							var unitIn = row.UnitIn;
							var entityCaption = BPMSoft.configuration.ModuleStructure[this.get("MasterEntitySchemaName")];
							entityCaption = entityCaption.moduleCaption.substr(0, entityCaption.moduleCaption.length - 1);
							var captionMasterEntity = entityCaption + " " + masterEntity.get("Name");
							var unit = unitIn ? unitIn.displayValue : "";
							item.set("AvailableIn", Ext.String.format(
								resources.localizableStrings.AvailableInFormatString,
								captionMasterEntity, availableIn.toString(), unit.toString()));
							if (!basket.contains(customKey)) {
								basket.add(customKey, item);
							}
						}, this);
						basket.each(function(item) {
							var products = productSelectResponse.rows.filter(
								function(res) {
									var resId = res.RealRecordId || res.Id;
									return resId === item.get("RealRecordId");
								}
							);
							if (products.length) {
								var detailRecordId = item.get(esqEntitySchemaName);
								BPMSoft.each(products, function(pr) {
									var product = BPMSoft.deepClone(pr);
									var productId = product.RealRecordId || product.Id;
									var customKey = detailRecordId ? productId + "_" + detailRecordId : productId;
									product.RealRecordId = productId;
									product.Id = customKey;
									product.Price = item.get("Price");
									product.Unit = item.get("Unit");
									product.UnitIn = item.get("UnitIn");
									product.Amount = item.get("Amount");
									product.BaseQuantity = item.get("BaseQuantity");
									product.Code = item.get("Code");
									product.DiscountAmount = item.get("DiscountAmount");
									product.DiscountPercent = item.get("DiscountPercent");
									product.DiscountPercent = item.get("DiscountPercent");
									product[esqEntitySchemaName] = item.get(esqEntitySchemaName);
									product.IsArchive = item.get("IsArchive");
									product.Name = item.get("Name");
									product.PriceList = item.get("PriceList");
									product.PrimaryAmount = item.get("PrimaryAmount");
									product.PrimaryDiscountAmount = item.get("PrimaryDiscountAmount");
									product.PrimaryPrice = item.get("PrimaryPrice");
									product.PrimaryTaxAmount = item.get("PrimaryTaxAmount");
									product.PrimaryTotalAmount = item.get("PrimaryTotalAmount");
									product.Quantity = item.get("Quantity");
									product.Tax = item.get("Tax");
									product.TaxAmount = item.get("TaxAmount");
									product.TaxPercent = item.get("TaxPercent");
									product.TotalAmount = item.get("TotalAmount");
									var masterEntity = this.get("MasterEntity");
									product.Currency = masterEntity.get("Currency");
									var availableInCount = item.get("AvailableInCount");
									product.AvailableIn = item.get("AvailableIn");
									product.Count = availableInCount;
									product.AvailableInCount = availableInCount;
									Ext.Array.insert(productSelectResponse.rows,
										Ext.Array.indexOf(productSelectResponse.rows, pr, 0), [product]);
									if (productId === pr.Id) {
										Ext.Array.remove(productSelectResponse.rows, pr);
									}
								}, this);
							}
						}, this);
						BPMSoft.each(productSelectResponse.rows, function(row) {
							var item = this.getGridRecordByItemValues(row, this.get("EntitySchema"));
							this.prepareItem(item);
							var price = item.get("Price");
							var masterEntity = this.get("MasterEntity");
							var masterCurrencyId = (masterEntity && masterEntity.get("Currency")) ?
								masterEntity.get("Currency").value : null;
							var currencyId = item.get("Currency") ? item.get("Currency").value : null;
							if (currencyId && (masterCurrencyId !== currencyId)) {
								MoneyModule.onLoadCurrencyRate.call(
									this, item.get("Currency").value, null,
									function(result) {
										this.setPrice(item, price, result.Division, result.Rate);
									},
									function() {
										this.setPrice(item, price, 1, 1);
									}
								);
							}
							var basePriceListProduct = response.queryResults[1].rows.filter(function(res) {
								return res.Id === item.get("Id");
							});
							if (basePriceListProduct && basePriceListProduct.length > 0) {
								var tax = basePriceListProduct[0].Tax;
								var taxPercent = basePriceListProduct[0].DiscountTax;
								if (tax) {
									item.set("Tax", tax);
									item.set("DiscountTax", taxPercent);
								}
							}
							var itemId = item.get("Id");
							var existingItem = basket.find(itemId);
							if (!existingItem && item.get("Count") > 0) {
								basket.add(itemId, item);
							} else if (!Ext.isEmpty(existingItem)) {
								var priceItem = existingItem.get("Price");
								if (!priceItem) {
									priceItem = 0;
								}
								item.set("Price", this.roundMoney(priceItem));
								item.set("Unit", existingItem.get("Unit"));
								item.set("Count", existingItem.get("Count"));
							}
							item.on("change", this.onDataGridItemChanged, this);
							item.on("change:Unit", this.onUnitChanged, this);
							item.on("change:Count", this.onCountChanged, this);
							item.on("change:Price", this.onPriceChanged, this);
							var gridData = this.getGridData();
							if (!collection.contains(row.Id) && !gridData.contains(row.Id)) {
								collection.add(row.Id, item);
							}
						}, this);
						this.calcSummary();
					},

					/**
					 * ############ ###### ######## ##### ######### # ######
					 * @protected
					 * @param {Object} item ###### ########.
					 */
					prepareItem: function(item) {
						item.sandbox = sandbox;
						if (!item.get("RealRecordId")) {
							item.set("RealRecordId", item.get("Id"));
						}
						item.set("MasterEntitySchemaName", this.get("MasterEntitySchemaName"));
						item.set("MasterRecordId", this.get("MasterRecordId"));

						item.set("UnitEnumList", new BPMSoft.Collection());
						item.fillUnitItems = this.fillUnitItems;

						var price = item.get("Price");
						if (!price) {
							price = 0;
						}
						item.set("Price", this.roundMoney(price));
						var productUtilities = this.getProductUtilities();
						item.set("PriceDisplayValue", productUtilities.getFormattedNumberValue(price));
						item.showImage = function() {
							return !Ext.isEmpty(this.get("AvailableIn"));
						};
						item.getImageURL = function() {
							return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Warning);
						};
						item.onAvailableClick = this.onAvailableClick;
					},

					/**
					 * ############ ######### ####### #########.
					 * @protected
					 * @param {BaseViewModel} model ######.
					 * @param {Object} item ########## #######.
					 */
					onUnitChanged: function(model, item) {
						this.set("NeedRecalc", true);
						var count = model.get("Count");
						model.validate = this.validate;
						if (Ext.isEmpty(count) || (count < 0 && count === item)) {
							count = 0;
						}
						model.set("Quantity", parseFloat(count));
						if (!Ext.isEmpty(item) && item.NumberOfBaseUnits) {
							model.set("BaseQuantity", count * item.NumberOfBaseUnits);
							this.set("NeedRecalc", false);
						} else {
							var productUtilities = this.getProductUtilities();
							productUtilities.setNumberOfBaseUnitsAndBaseQuantity(model, function() {
								this.set("NeedRecalc", false);
								if (this.get("NeedSave") === true) {
									this.saveSelectedProducts();
								}
							}, this);
						}
					},

					/**
					 * ############ ######### ##########.
					 * @protected
					 * @param {BaseViewModel} model ######.
					 * @param {Object} item ########## #######.
					 * @param {Object} options ############## #########.
					 */
					onCountChanged: function(model, item, options) {
						this.onUnitChanged(model, item, options);
					},

					/**
					 * Handles price value changed.
					 * @param {BaseViewModel} model Model of product in entity.
					 * @param {Object} item Changed value.
					 * @param {Object} options Additional settings.
					 */
					onPriceChanged: function(model, item, options) {
						this.onUnitChanged(model, item, options);
					},

					/**
					 * ######## # ######## ########## ########, ##### ##### #########.
					 * @protected
					 * @param {BaseViewModel} item #######.
					 */
					onDataGridItemChanged: function(item) {
						var basket = this.getBasketData();
						var itemId = item.get("Id");
						var itemCount = item.get("Count") || 0;
						var itemPrice = item.get("Price") || 0;
						if (itemCount < 0) {
							itemCount = 0;
							item.set("Count", 0);
						}
						var itemAvailableInCount = item.get("AvailableInCount");
						var existingItem = basket.find(itemId);
						if (itemCount > 0) {
							if (!existingItem) {
								basket.add(itemId, item);
								existingItem = basket.find(itemId);
							} else {
								existingItem.set("Count", itemCount);
							}
						} else if (existingItem && Ext.isEmpty(itemAvailableInCount)) {
							basket.removeByKey(itemId);
						}
						if (existingItem && item) {
							existingItem.set("Price", this.roundMoney(itemPrice));
							existingItem.set("Count", parseFloat(itemCount));
							existingItem.set("Quantity", parseFloat(itemCount));
							existingItem.set("BaseQuantity", item.get("BaseQuantity"));
							existingItem.set("Unit", item.get("Unit"));
							const productUtilities = this.getProductUtilities();
							productUtilities.calculateProductValues(existingItem);
							this.calcSummary();
						}
					},

					/**
					 * Calculates and sets product price.
					 * @protected
					 * @param {BPMSoft.BaseModel} item Product.
					 * @param {Number} productPrice Product price.
					 * @param {Number} division Currency division.
					 * @param {Number} rate Currency rate.
					 */
					setPrice: function(item, productPrice, division, rate) {
						var entity = this.get("MasterEntity");
						var currencyRate = (entity && entity.get("CurrencyRate")) ? entity.get("CurrencyRate") : 1;
						var divisionResult = (division === 0) ? 1 : division;
						var rateResult = (rate === 0) ? 1 : rate;
						var moneyCalculator = this.getMoneyCalculator();
						var price = moneyCalculator.evaluate({
							divide: [
								{
									multiply: [
										productPrice,
										currencyRate,
										divisionResult
									]
								},
								{
									multiply: [
										rateResult,
										entity.get("Currency.Division")
									]
								}
							]
						});
						price = this.roundValue(price, {
							"decimalPlaces": 2
						});
						item.set("Price", price);
						var productUtilities = this.getProductUtilities();
						item.set("PriceDisplayValue", productUtilities.getFormattedNumberValue(price));
					},

					/**
					 * ######## ######### ######### ######### #######.
					 * @protected
					 * @returns {Object} ########## ######### ###### #######
					 */
					getBasketData: function() {
						var baskedData = this.get("BasketData");
						if (!baskedData) {
							baskedData = new BPMSoft.Collection();
							this.set("BasketData", baskedData);
						}
						return baskedData;
					},

					/**
					 * ######## ######### ######### #######.
					 * @protected
					 * @returns {Object} ########## ######### ######
					 */
					getGridData: function() {
						var gridData = this.get("GridData");
						if (!gridData) {
							gridData = new BPMSoft.Collection();
							this.set("GridData", gridData);
						}
						return gridData;
					},

					/**
					 * ############# ######### ####### #### # ##### #######.
					 * @protected
					 * @param {String} symbol ###### ######.
					 */
					setPriceCaption: function(symbol) {
						this.set("PriceLabel", Ext.String.format(resources.localizableStrings.PriceCaption, ", " + symbol));
					},

					/**
					 * ######## ######### ############# ######.
					 * @protected
					 * @returns {Collection}
					 */
					getDataViews: function() {
						var moduleCaption = this.getModuleCaption();
						var gridDataView = {
							name: "GridDataView",
							active: true,
							caption: moduleCaption,
							hint: resources.localizableStrings.ProductsListDataViewHint,
							icon: resources.localizableImages.GridDataViewIcon
						};
						var basketDataView = {
							name: "BasketDataView",
							caption: moduleCaption,
							hint: resources.localizableStrings.CartDataViewHint,
							icon: resources.localizableImages.BasketDataViewIcon
						};
						var dataViews = Ext.create("BPMSoft.Collection");
						dataViews.add(gridDataView.name, gridDataView, 0);
						dataViews.add(basketDataView.name, basketDataView, 1);
						this.set("DataViews", dataViews);
						return dataViews;
					},

					/**
					 * ######## ######### ######.
					 * @protected
					 * @returns {string}
					 */
					getModuleCaption: function() {
						var entity = this.get("MasterEntity");
						var entityCaption = this.getEntityCaption();
						return Ext.String.format(
							resources.localizableStrings.ModuleCaption, entityCaption + " №" + entity.get("Name")
						);
					},

					/**
					 * ######## ######### ########.
					 * @protected
					 * @returns {string}
					 */
					getEntityCaption: function() {
						var entityCaption = BPMSoft.configuration.ModuleStructure[this.get("MasterEntitySchemaName")];
						return entityCaption.moduleCaption.substr(0, entityCaption.moduleCaption.length - 1);
					},

					/**
					 * ############ ####### ## ####### ######## # #######
					 * @protected
					 */
					onAvailableClick: function() {
						//console.log(arguments);
					},

// Summary
					/**
					 * Calculates total amount for selected products.
					 * @protected
					 */
					calcSummary: function() {
						var totalAmount = 0;
						var lineItemsCount = 0;
						var basket = this.getBasketData();
						var calculator = this.getMoneyCalculator();
						basket.each(function(item) {
							totalAmount = calculator.add(totalAmount, item.get("TotalAmount") || 0);
							var quantity = item.get("Quantity") || 0;
							lineItemsCount += quantity;
						}, this);
						this.set("TotalAmount", totalAmount);
						this.set("LineItemsCount", lineItemsCount);
					},

					/**
					 * ############# ###### ######.
					 * @protected
					 * @param {String} symbol ###### ######.
					 */
					setSummaryCurrencySymbol: function(symbol) {
						this.set("CurrencySymbol", symbol);
					},

					/**
					 * Calculates and sets amount.
					 * @protected
					 */
					calcAmount: function() {
						var price = this.get("Price");
						var quantity = this.get("BaseQuantity");
						if (!Ext.isEmpty(price) && !Ext.isEmpty(quantity)) {
							var moneyCalculator = this.getMoneyCalculator();
							var amount = moneyCalculator.multiply(price, quantity);
							this.set("Amount", amount);
						}
					},

					/**
					 * ProductUtilities getter.
					 * @protected
					 * @return {BPMSoft.ProductUtilities}
					 */
					getProductUtilities: function() {
						return this.productUtils;
					},

					/**
					 * Defines ProductUtilities.
					 * @param {BPMSoft.EntitySchema} schema Entity Schema.
					 * @private
					 */
					defineProductUtilities: function(schema) {
						this.productUtils = Ext.create("BPMSoft.configuration.ProductUtilities", {
							columns: schema.columns
						});
					},

					/**
					 * Initializes ProductUtilities.
					 * @param callback Calls when ProductUtilities was initialized.
					 * @private
					 * @param scope Callback's scope.
					 */
					initProductUtilities: function(callback, scope) {
						var entitySchemaName = this.getProductEntitySchemaName();
						BPMSoft.require([entitySchemaName], function(schema) {
							this.defineProductUtilities(schema);
							Ext.callback(callback, scope);
						}, this);
					},

					/**
					 * Returns product EntitySchema name.
					 * @protected
					 * @returns {String}
					 */
					getProductEntitySchemaName: function() {
						return this.get("MasterEntitySchemaName") + this.get("EntitySchemaName");
					},

					/**
					 * ######## ########## ######### ######### # ########## ############.
					 * @protected
					 */
					saveSelectedProducts: function() {
						if (this.get("NeedRecalc") === true) {
							this.set("NeedSave", true);
							return;
						}
						MaskHelper.ShowBodyMask();
						var currentDataView = this.get("CurrentDataView");
						var selectedProducts = this.getBasketData();
						if (Ext.isEmpty(this.get("MasterEntitySchemaName")) ||
							Ext.isEmpty(this.get("MasterRecordId")) ||
							(selectedProducts.getCount() < 1)) {
							this.afterSave();
							return;
						}
						var batchQuery = Ext.create("BPMSoft.BatchQuery");
						var rootSchemaName = this.getProductEntitySchemaName();
						selectedProducts.each(function(item) {
							const productUtilities = this.getProductUtilities();
							productUtilities.calculateProductValues(item);
							if (item.get("AvailableInCount") > 0) {
								var quantity = (currentDataView === "GridDataView") ?
									item.get("Quantity") :
								item.get("Count") || 0;
								if (parseFloat(quantity) === 0) {
									//delete
									var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
										rootSchemaName: rootSchemaName
									});
									var entityIdFilter = BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.EQUAL, "Id", item.get(rootSchemaName + "Id"));
									deleteQuery.filters.add("entityIdFilter", entityIdFilter);
									batchQuery.add(deleteQuery);
								} else {
									var update = Ext.create("BPMSoft.UpdateQuery", {
										rootSchemaName: rootSchemaName
									});
									var filters = update.filters;
									filters.add("IdFilter", BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id",
										item.get(rootSchemaName + "Id")));
									update.setParameterValue("Quantity",
										quantity, BPMSoft.DataValueType.FLOAT);
									update.setParameterValue("BaseQuantity",
										item.get("BaseQuantity"), BPMSoft.DataValueType.FLOAT);
									if (item.get("Unit")) {
										update.setParameterValue("Unit",
											item.get("Unit").value, BPMSoft.DataValueType.GUID);
									}
									if (item.get("PriceList")) {
										update.setParameterValue("PriceList",
											item.get("PriceList").value, BPMSoft.DataValueType.GUID);
									}
									if (item.get("Price")) {
										update.setParameterValue("Price",
											item.get("Price"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("PrimaryPrice")) {
										update.setParameterValue("PrimaryPrice",
											item.get("PrimaryPrice"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("Amount")) {
										update.setParameterValue("Amount",
											item.get("Amount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("PrimaryAmount")) {
										update.setParameterValue("PrimaryAmount",
											item.get("PrimaryAmount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("TaxAmount")) {
										update.setParameterValue("TaxAmount",
											item.get("TaxAmount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("PrimaryTaxAmount")) {
										update.setParameterValue("PrimaryTaxAmount",
											item.get("PrimaryTaxAmount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("TotalAmount")) {
										update.setParameterValue("TotalAmount",
											item.get("TotalAmount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("PrimaryTotalAmount")) {
										update.setParameterValue("PrimaryTotalAmount",
											item.get("PrimaryTotalAmount"), BPMSoft.DataValueType.FLOAT);
									}
									if (item.get("DiscountTax")) {
										update.setParameterValue("DiscountTax",
											item.get("DiscountTax"), BPMSoft.DataValueType.FLOAT);
									}
									batchQuery.add(update);
								}
							} else {
								//insert
								var insert = Ext.create("BPMSoft.InsertQuery", {
									rootSchemaName: rootSchemaName
								});

								if (this.get("MasterRecordId")) {
									insert.setParameterValue(this.get("MasterEntitySchemaName"),
										this.get("MasterRecordId"), BPMSoft.DataValueType.GUID);
								}
								if (item.get("Id")) {
									insert.setParameterValue("Product",
										item.get("Id"), BPMSoft.DataValueType.GUID);
								}
								if (item.get("Name")) {
									insert.setParameterValue("Name",
										item.get("Name"), BPMSoft.DataValueType.TEXT);
								}
								if (item.get("Quantity")) {
									insert.setParameterValue("Quantity",
										parseFloat(item.get("Quantity")), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("BaseQuantity")) {
									insert.setParameterValue("BaseQuantity",
										parseFloat(item.get("BaseQuantity")), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("Unit")) {
									insert.setParameterValue("Unit",
										item.get("Unit").value, BPMSoft.DataValueType.GUID);
								}
								if (item.get("Tax")) {
									insert.setParameterValue("Tax",
										item.get("Tax").value, BPMSoft.DataValueType.GUID);
								}
								if (item.get("PriceList")) {
									insert.setParameterValue("PriceList",
										item.get("PriceList").value, BPMSoft.DataValueType.GUID);
								} else if (this.get("BasePriceList")) {
									insert.setParameterValue("PriceList",
										this.get("BasePriceList").value, BPMSoft.DataValueType.GUID);
								}
								if (item.get("Price")) {
									insert.setParameterValue("Price",
										item.get("Price"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("PrimaryPrice")) {
									insert.setParameterValue("PrimaryPrice",
										item.get("PrimaryPrice"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("Amount")) {
									insert.setParameterValue("Amount",
										item.get("Amount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("PrimaryAmount")) {
									insert.setParameterValue("PrimaryAmount",
										item.get("PrimaryAmount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("TaxAmount")) {
									insert.setParameterValue("TaxAmount",
										item.get("TaxAmount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("PrimaryTaxAmount")) {
									insert.setParameterValue("PrimaryTaxAmount",
										item.get("PrimaryTaxAmount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("TotalAmount")) {
									insert.setParameterValue("TotalAmount",
										item.get("TotalAmount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("PrimaryTotalAmount")) {
									insert.setParameterValue("PrimaryTotalAmount",
										item.get("PrimaryTotalAmount"), BPMSoft.DataValueType.FLOAT);
								}
								if (item.get("DiscountTax")) {
									insert.setParameterValue("DiscountTax",
										item.get("DiscountTax"), BPMSoft.DataValueType.FLOAT);
								}
								batchQuery.add(insert);
							}
						}, this);
						batchQuery.execute(this.afterSave, this);
					},

					/**
					 * ######### ######### ########.
					 * @protected
					 */
					saveBasketData: function() {
						this.saveSelectedProducts();
					},

					/**
					 * #### ######### ########.
					 * @protected
					 * @returns {Collection} ########## ######### ######### #########.
					 */
					findSelectedProducts: function() {
						var grid = this.getGridData();
						var resultCollection = grid.filterByFn(function(item) {
							var count = parseFloat(item.get("Count"));
							var availableInCount = parseFloat(item.get("AvailableInCount"));
							return ((count > 0 && availableInCount !== count) || (availableInCount > 0 && count === 0));
						});
						return resultCollection;
					},
// Button handlers

					/**
					 * ############## ######### ##### ##########.
					 * @protected
					 */
					afterSave: function() {
						this.initDataViews(true);
						sandbox.publish("ProductSelectionSave", this.findSelectedProducts(), [sandbox.id]);
						sandbox.publish("BackHistoryState");
						MaskHelper.HideBodyMask();
					},

					/**
					 * ############ ####### ###### #########.
					 * @protected
					 */
					onSaveButtonClick: function() {
						this.saveBasketData();
					},

					/**
					 * ############ ####### ###### ######.
					 * @protected
					 */
					onCancelButtonClick: function() {
						this.afterSave();
					},

// Quick Search Module
					/**
					 * ######### ###### ###### ######.
					 * @protected
					 * @param {Object} renderTo ######### ### ###########.
					 */
					loadQuickSearchModule: function(renderTo) {
						var quickSearchModuleId = sandbox.id + "_QuickSearchModule";
						sandbox.subscribe("QuickSearchFilterInfo", function() {
							return this.getQuickSearchFilterConfig();
						}, this);
						sandbox.subscribe("UpdateQuickSearchFilter", function(filterItem) {
							this.onQuickSearchFilterUpdate(filterItem.key, filterItem.filters, filterItem.filtersValue);
						}, this);
						sandbox.loadModule("QuickSearchModule", {
							renderTo: renderTo,
							id: quickSearchModuleId
						});
					},

					/**
					 * ######## ############ ###### ###### ######.
					 * @protected
					 * @returns {Object}
					 */
					getQuickSearchFilterConfig: function() {
						return {
							InitSearchString: "",
							SearchStringPlaceHolder: resources.localizableStrings.SearchStringPlaceHolder,
							FilterColumns: [
								{
									Column: "Name",
									ComparisonType: BPMSoft.ComparisonType.START_WITH
								},
								{
									Column: "Code",
									ComparisonType: BPMSoft.ComparisonType.START_WITH
								}
							]
						};
					},

					/**
					 * ############ ######### ######## ######.
					 * @protected
					 * @param {String} filterKey #### #######.
					 * @param {BPMSoft.data.filters.FilterGroup} filterItem ###### ########.
					 * @param {BPMSoft.Collection} filtersValue ######## #######.
					 */
					onQuickSearchFilterUpdate: function(filterKey, filterItem, filtersValue) {
						MaskHelper.ShowBodyMask();
						var currentDataView = this.get("CurrentDataView");
						if (currentDataView === "GridDataView") {
							this.set("QuickSearchFilterString", filtersValue);
							this.set("QuickSearchFilters", filterItem);
							var grid = this.getGridData();
							grid.clear();
							this.loadGridData();
						} else if (currentDataView === "BasketDataView") {
							var collection = this.get("BasketViewGridCollection");
							var filteredCollection = Ext.isEmpty(filtersValue) ?
								collection :
								collection.filterByFn(
									function(item) {
										return (item.get("Name").indexOf(filtersValue) === 0 ||
										item.get("Code").indexOf(filtersValue) === 0);
									}
								);
							var gridData = this.getGridData();
							gridData.clear();
							gridData.loadAll(filteredCollection);
							MaskHelper.HideBodyMask();
						}
					},

// Folders Manager
					/**
					 * ######### ###### ######### #####.
					 * @protected
					 * @param {Object} renderTo ######### ### ###########.
					 */
					loadFolderManager: function(renderTo) {
						this.set("FoldresModuleRenderTo", renderTo);
						var folderManagerModuleId = this.getFolderManagerModuleId();
						sandbox.subscribe("FolderInfo", function() {
							return this.getFolderManagerConfig(this.get("EntitySchema"));
						}, this, [folderManagerModuleId]);
						sandbox.subscribe("UpdateCatalogueFilter", function(filterItem) {
							this.onFilterUpdate(filterItem.key, filterItem.filters, filterItem.filtersValue);
						}, this);
						var folderManagerName = BPMSoft.Features.getIsEnabled("NewProductCatalogueFolderManager")
							? this.folderManagerModuleName
							: "FolderManager";
						sandbox.loadModule(folderManagerName, {
							renderTo: renderTo,
							id: folderManagerModuleId
						});
					},

					/**
					 * Generates folder manager module identifier.
					 * @protected
					 * @return {String} Module identifier.
					 */
					getFolderManagerModuleId: function() {
						return Ext.String.format("{0}_{1}Module", sandbox.id, this.folderManagerModuleName);
					},

					/**
					 * Gets section folder manager settings.
					 * @return {Object}
					 */
					getFolderManagerConfig: function(schema) {
						if (BPMSoft.Features.getIsEnabled("NewProductCatalogueFolderManager")) {
							return {
								entitySchemaName: this.getFolderEntityName(),
								inFolderEntitySchemaName: this.getInFolderEntityName(),
								entityColumnNameInFolderEntity: this.getEntityColumnNameInFolderEntity(),
								sectionEntitySchema: schema,
								activeFolderId: null,
								useStaticFolders: false,
								folderManagerViewModelClassName: this.folderManagerViewModelClassName,
								folderFilterViewId: this.folderManagerViewConfigGenerator,
								folderFilterViewModelId: this.folderManagerViewModelConfigGenerator
							};
						} else {
							var filterValues = [{
								columnPath: "IsArchive",
								value: false
							}];
							var config = {
								entitySchemaName: "ProductFolder",
								sectionEntitySchema: schema,
								activeFolderId: null,
								catalogueRootRecordItem: {
									value: DistributionConstants.ProductFolder.RootCatalogueFolder.RootId,
									displayValue: resources.localizableStrings.ProductCatalogueRootCaption
								},
								catalogAdditionalFiltersValues: filterValues,
								isProductSelectMode: true,
								closeVisible: false
							};
							return config;
						}
					},

					/**
					 * Gets entity-if-folder schema name.
					 * @return {String} entity-in-folder schema name.
					 */
					getInFolderEntityName: function() {
						return "ProductInFolder";
					},

					/**
					 * Gets main entity column name from entity-in-folder.
					 * @return {String} main entity column name.
					 */
					getEntityColumnNameInFolderEntity: function() {
						return "Product";
					},

					/**
					 * Gets folder entity schema name.
					 * @return {String} folder entity schema name.
					 */
					getFolderEntityName: function() {
						return "ProductFolder";
					},

					/**
					 * ############ ######### ########.
					 * @protected
					 * @param {String} filterKey #### #######.
					 * @param {BPMSoft.data.filters.FilterGroup} filterItem ######.
					 */
					onFilterUpdate: function(filterKey, filterItem) {
						if (this.get("CurrentDataView") === "GridDataView") {
							this.set("CatalogueFilters", filterItem);
							var grid = this.getGridData();
							grid.clear();
							this.loadGridData();
						}
					}
				}
			};
			return viewModelConfig;
		}

		return {
			generate: generate
		};
	}
);
