define("SupplyPaymentDetailV2", ["ConfigurationConstants", "OrderConfigurationConstants", "ConfigurationEnums",
			"SupplyPaymentGridButtonsUtility", "Order", "SupplyPaymentDetailV2Resources", "InvoiceProduct",
			"ProductUtilitiesV2", "ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities",
			"css!SupplyPaymentGridButtonsUtility", "OrderUtilities", "MoneyUtilsMixin"],
		function(ConfigurationConstants, OrderConfigurationConstants, enums, GridButtonsUtil, Order, resources,
				InvoiceProductSchema, ProductUtilities) {
			/**
			 * Result type.
			 * @enum
			 */
			var result = {
				NoError: 0,
				NoItems: 1,
				TypeNotMatch: 2,
				ExistInvoice: 3
			};
			/**
			 * Object name for generation.
			 * @enum
			 */
			var entityName = {
				Invoice: "Invoice",
				Contract: "Contract"
			};
			return {
				entitySchemaName: "SupplyPaymentElement",
				attributes: {
					"IsEditable": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: true
					},
					"ActiveRow": {
						dataValueType: BPMSoft.DataValueType.GUID,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"State": {
						dataValueType: BPMSoft.DataValueType.LOOKUP
					},
					"NeedReloadGridData": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: false
					}
				},
				messages: {

					/**
					 * @message ReloadSupplyPaymentGridData
					 * Reload supply payment data.
					 */
					"ReloadSupplyPaymentGridData": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message CreateSupplyPaymentInvoice
					 * Create invoice for supply payment.
					 */
					"CreateSupplyPaymentInvoice": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.BIDIRECTIONAL
					},

					/**
					 * @message GetModuleInfo
					 * Returns module information.
					 */
					"GetModuleInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetOrderAmount
					 * Returns order amount.
					 */
					"GetOrderAmount": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},

				/**
				 * ######-#######, ########### ################ ####### #####.
				 */
				mixins: {
					ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities",
					OrderUtilities: "BPMSoft.OrderUtilities",
					MoneyUtilities: "BPMSoft.MoneyUtilsMixin"
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
					 */
					subscribeSandboxEvents: function() {
						this.callParent(arguments);
						this.sandbox.subscribe("ReloadSupplyPaymentGridData", function() {
							this.set("ActiveRow", null);
							this.set("OldActiveRow", null);
							this.reloadGridData();
						}, this);
						this.sandbox.subscribe("GetModuleInfo", this.getModuleInfoResponse,
							this, [this.getModalBoxProductDetailId()]);
						this.sandbox.subscribe("RerenderDetail", function(config) {
							if (this.viewModel) {
								var renderTo = this.Ext.get(config.renderTo);
								if (renderTo) {
									if (this.view) {
										this.view.destroyed = true;
									}
									this.render(renderTo);
									return true;
								}
							}
						}, this, [this.sandbox.id]);
						if (this.getIsFeatureEnabled("UseLookupInvoiceForSupplyPaymentDetail")) {
							this.sandbox.subscribe("CreateSupplyPaymentInvoice", function() {
								var row = this.getActiveRow();
								this.asyncGenerateInvoices([row]);
							}, this, [this.sandbox.id]);
						}
					},

					/**
					 * Returns config for publisher "GetModuleInfo".
					 * @protected
					 * @virtual
					 * @return {Object} Config.
					 */
					getModuleInfoResponse: function() {
						const activeRowId = this.get("CurrentRowId");
						if (activeRowId) {
							return {
								schemaName: "SupplyPaymentProductDetailModalBox",
								supplyPaymentElementId: activeRowId
							};
						}
					},

					/**
					 * ########## ############# sandbox ### ###### "########" ######## # ######### ####.
					 * @return {String}
					 */
					getModalBoxProductDetailId: function() {
						return this.sandbox.id + "_SupplyPaymentProductDetailModalBox";
					},

					/**
					 * ######### # ###### #######, ####### ########## ######### ### ########### ## #######.
					 * @protected
					 * @param {BPMSoft.EntitySchemaQuery} esq ###### ## ######## ###### #######.
					 */
					addRequiredColumns: function(esq) {
						esq.addColumn("State");
						esq.addColumn("Order");
						var orderColumns = Order.columns;
						var requiredOrderColumns = ["Contract", "Contact", "Account", "Currency", "CurrencyRate",
							"Opportunity"];
						this.BPMSoft.each(requiredOrderColumns, function(columnName) {
							if (orderColumns[columnName]) {
								esq.addColumn("Order." + columnName);
								if (columnName === "Currency") {
									esq.addColumn("Order.Currency.Division");
								}
							}
						}, this);
						esq.addColumn("AmountPlan");
						esq.addColumn("Contract");
						esq.addColumn("Invoice");
						esq.addColumn("Invoice.PaymentStatus");
						esq.addColumn("Order.Amount", "OrderAmount");
						esq.addColumn("PreviousElement.DatePlan", "PreviousElement.DatePlan");
						esq.addColumn("PreviousElement.DateFact", "PreviousElement.DateFact");
						esq.addColumn("PreviousElement.State", "PreviousElement.State");
					},

					/**
					 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#getGridDataColumns
					 * @protected
					 * @overridden
					 */
					getGridDataColumns: function() {
						var baseGridDataColumns = this.callParent(arguments);
						var gridDataColumns = {
							"DatePlan": {
								path: "DatePlan",
								orderPosition: 0,
								orderDirection: this.BPMSoft.OrderDirection.ASC
							},
							"DateFact": {
								path: "DateFact",
								orderPosition: 1,
								orderDirection: this.BPMSoft.OrderDirection.ASC
							},
							"CreatedOn": {
								path: "CreatedOn",
								orderPosition: 2,
								orderDirection: this.BPMSoft.OrderDirection.ASC
							}
						};
						return Ext.apply(baseGridDataColumns, gridDataColumns);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#addGridDataColumns
					 * @overridden
					 */
					addGridDataColumns: function(esq) {
						this.callParent(arguments);
						this.addRequiredColumns(esq);
						GridButtonsUtil.instance.addGridDataColumns(esq);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollectionItem
					 * @overridden
					 */
					prepareResponseCollectionItem: function(item) {
						this.mixins.GridUtilities.prepareResponseCollectionItem.apply(this, arguments);
						GridButtonsUtil.instance.prepareResponseCollectionItem(item, this);
						if (item.isNewMode()) {
							var amount = this.sandbox.publish("GetOrderAmount", null, [this.sandbox.id]);
							item.set("OrderAmount", amount);
						}
						item.initSupplyPaymentData();
					},

					/**
					 * @inheritdoc BPMSoft.ConfigurationGridUtilites#getCellControlsConfig
					 * @overridden
					 */
					getCellControlsConfig: function(entitySchemaColumn) {
						var controlsConfig = GridButtonsUtil.instance.getCellControlsConfig(entitySchemaColumn);
						if (!controlsConfig) {
							controlsConfig =
									this.mixins.ConfigurationGridUtilites.getCellControlsConfig.apply(this, arguments);
							if (entitySchemaColumn.name === "Percentage") {
								controlsConfig.controlConfig = {
									tips: [{
										tip: {
											content: {"bindTo": "getPercentageHint"},
											displayMode: this.BPMSoft.TipDisplayMode.NARROW,
											markerValue: {"bindTo": "getPercentageHint"}
										},
										settings: {
											alignEl: "disabledElIconEl"
										}
									}]
								};
							}
						}
						return controlsConfig;
					},

					/**
					 * @inheritdoc BPMSoft.ConfigurationGridUtilites#onGridClick
					 * @overridden
					 */
					onGridClick: function() {
						if (this.get("IsButtonClicked")) {
							this.set("IsButtonClicked", false);
						} else {
							this.mixins.ConfigurationGridUtilites.onGridClick.apply(this, arguments);
						}
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#linkClicked
					 * @overridden
					 */
					linkClicked: function(recordId, columnName) {
						var eventResult = false;
						try {
							this.set("CurrentRowId", recordId);
							if (columnName === "Products") {
								this.openProductsWindow();
							} else if (columnName === "Invoice") {
								var data = this.getGridData();
								var row = data.get(recordId);
								this.onInvoiceButtonClick(row);
							}
						} catch (exception) {
							this.log(exception, this.BPMSoft.LogMessageType.ERROR);
						}
						this.set("IsButtonClicked", true);
						return eventResult;
					},

					/**
					 * ############ #### ## ###### ####### "########" # ####### ###### (# ###### ############## ######).
					 * @protected
					 * @param {BPMSoft.BasePageV2ViewModel} item ###### ############# ######## ###### #######.
					 */
					onProductsButtonClick: function(item) {
						this.set("CurrentRowId", this.get("ActiveRow"));
						this.saveIfNeedAndProceed(item, this.openProductsWindow, this);
					},

					/**
					 * ############ ####### ## ###### #######.
					 * @param {BPMSoft.BasePageV2ViewModel} item ###### ############# ######## ###### #######.
					 */
					onClearProductsButtonClick: function(item) {
						this.saveIfNeedAndProceed(item, this.clearSupplyPaymentElementProducts, this);
					},

					/**
					 * #########, ### #############, ########## ######  # ######## ##### ######### ######.
					 * @param {BPMSoft.BasePageV2ViewModel} item ###### ############# ######## ###### #######.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ##########.
					 */
					saveIfNeedAndProceed: function(item, callback, scope) {
						if (!item) {
							return;
						}
						if (item.isChanged()) {
							item.save({
								isSilent: true,
								scope: this,
								callback: function() {
									callback.call(scope, item);
								}
							});
						} else {
							callback.call(scope, item);
						}
					},

					/**
					 * ####### ######## #### ####### ######## # #####.
					 * @param {BPMSoft.BaseModel} row  ###### ############# ###### #######.
					 */
					clearSupplyPaymentElementProducts: function(row) {
						var rowId = row.get("Id");
						this.callService({
							serviceName: "OrderPassportService",
							methodName: "ClearSupplyPaymentProducts",
							data: {
								"supplyPaymentElementId": rowId
							}
						}, function(response) {
							var result = response.ClearSupplyPaymentProductsResult || {};
							if (!result.success) {
								if (result.errorInfo) {
									this.showInformationDialog(result.errorInfo.message);
								} else {
									throw new BPMSoft.UnknownException();
								}
							}
							this.reloadGridData();
						}, this);
					},

					/**
					 * ############ #### ## ###### ####### "####" # ####### ###### (# ###### ############## ######).
					 * @protected
					 * param {Object} row ###### ############# ###### #######.
					 */
					onInvoiceButtonClick: function(row) {
						var invoice = row.get("Invoice");
						if (invoice && this.BPMSoft.isGUID(invoice.value)) {
							this.openInvoicePage(invoice.value);
							return;
						}
						if (!this.getIsFeatureEnabled("UseLookupInvoiceForSupplyPaymentDetail")) {
							if (row.isChanged()) {
								row.save({
									isSilent: true,
									scope: this,
									callback: this.asyncGenerateInvoices.bind(this, [row])
								});
							} else {
								this.asyncGenerateInvoices([row]);
							}
						}
					},

					/**
					 * ######### ######## ############## #####.
					 * @param {Guid} invoiceId Id #####.
					 */
					openInvoicePage: function(invoiceId) {
						var config = {
							schemaName: "InvoicePageV2",
							operation: enums.CardStateV2.EDIT,
							id: invoiceId,
							moduleId: this.getInviocePageSandboxId()
						};
						this.sandbox.publish("OpenCard", config, [this.sandbox.id]);
					},

					/**
					 * ########## ### ######## #####.
					 * @return {String}
					 */
					getInviocePageSandboxId: function() {
						return this.sandbox.id + "_InvoicePageV2";
					},

					/**
					 * ######### #### ############## ######### ####.
					 * @protected
					 */
					openProductsWindow: function() {
						this.sandbox.loadModule("ModalBoxSchemaModule", {id: this.getModalBoxProductDetailId()});
					},

					/**
					 * @inheritdoc BPMSoft.BaseDetailV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						GridButtonsUtil.init({
							Ext: this.Ext,
							BPMSoft: this.BPMSoft
						});
						this.callParent([
							function() {
								this.initProductUtilities(callback, scope);
							}, this
						]);
						this.set("isCollapsed", false);
						this.BPMSoft.chain(this.initDefTemplate, this.initItemTemplates, this);
						this.initValidateActions();
					},

					/**
					 * ############# #######.
					 * @protected
					 */
					initValidateActions: function() {
						var config = {
							getId: function() {
								return this.get("ActiveRow");
							},
							name: "Id"
						};
						this.deleteRecords = this.needToChangeInvoice(config, this.deleteRecords, this);
						this.editRecord = this.needToChangeInvoice(config, this.editRecord, this);
						this.addRecord = this.needToChangeInvoice(config, this.addRecord, this);
						this.copyRecord = this.needToChangeInvoice(config, this.copyRecord, this);
						this.openProductsWindow = this.needToChangeInvoice({
							getId: function() {
								return this.get("CurrentRowId");
							},
							name: "Id"
						}, this.openProductsWindow, this);
					},

					/**
					 * inheritdoc BPMSoft.GridUtilitiesV2#createViewModel
					 * @overridden
					 */
					createViewModel: function(config) {
						this.callParent(arguments);
						this.updateViewModel(config.viewModel);
					},

					/**
					 * ########### ###### ############# ### ############## #######.
					 * @param {Object} viewModel ##### ###### #############.
					 */
					updateViewModel: function(viewModel) {
						viewModel.save = this.needToChangeInvoice({
							getId: function() {
								return this.get("Id");
							},
							name: "Id",
							validateColumns: ["AmountPlan"]
						}, viewModel.save.bind(viewModel), this);
					},

					/**
					 * ####### ######### ####### ### ######## ######## #######.
					 * @protected
					 * @return {BPMSoft.EntitySchemaQuery} ######### ####### ### ######## ######## #######.
					 */
					getTemplateNamesEsq: function() {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SupplyPaymentTemplate"
						});
						esq.addMacrosColumn(this.BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
						var nameColumn = esq.addMacrosColumn(this.BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
						nameColumn.orderDirection = BPMSoft.core.enums.OrderDirection.ASC;
						nameColumn.orderPosition = 1;
						return esq;
					},

					/**
					 * Returns new record menu item.
					 * @private
					 * @return {BPMSoft.BaseViewModel}
					 */
					getNewRecordMenuItem: function() {
						var newRecordMenuItem = this.getButtonMenuItem({
							Caption: this.get("Resources.Strings.NewStageButtonCaption"),
							Click: {"bindTo": "addTemplateItemRecord"}
						});
						return newRecordMenuItem;
					},

					/**
					 * ############## ######### ######### #### ###### ######### ## #######.
					 * @protected
					 */
					initItemTemplates: function() {
						var templateCollection = Ext.create("BPMSoft.BaseViewModelCollection");
						templateCollection.add(this.getNewRecordMenuItem());
						templateCollection.add(this.getButtonMenuSeparator({
							Caption: this.get("Resources.Strings.SetTemplateButtonCaption")
						}));
						var esq = this.getTemplateNamesEsq();
						esq.getEntityCollection(function(response) {
							if (response.success) {
								response.collection.each(function(template) {
									var id = template.get("Id");
									templateCollection.add(id, this.getButtonMenuItem({
										Id: id,
										Caption: template.get("Name"),
										Click: {bindTo: "setTemplate"},
										Tag: id
									}));
								}, this);
								this.set("TemplatesExists", response.collection.getCount() > 0);
							}
							this.set("ItemTemplates", templateCollection);
						}, this);
					},

					/**
					 * ############## ######## ######### ######### "###### ######## ###### ## #########".
					 * @param {Function} next ####### ######### ######.
					 */
					initDefTemplate: function(next) {
						this.BPMSoft.SysSettings.querySysSettingsItem("OrderPassportTemplateDef", function(value) {
									this.set("OrderPassportTemplateDef", value);
									next();
								},
								this);
					},

					/**
					 * ######### ### ############# ##### # ######### ######### ###### #######.
					 * @protected
					 * @param {String} tag Id #######.
					 */
					setTemplate: function(tag) {
						var isNewRecord = this.getIsNewMasterRecord();
						if (!isNewRecord) {
							this.setTemplateWithCheck(tag);
						} else {
							this.set("SetTemplateRecordId", tag);
							var args = {
								isSilent: true,
								messageTags: [this.sandbox.id]
							};
							this.turnDefPassportTemplateOff(function() {
								this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
							}.bind(this));
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseDetailV2#onCardSaved
					 * @overridden
					 */
					onCardSaved: function() {
						var setTemplateRecordId = this.get("SetTemplateRecordId");
						if (setTemplateRecordId) {
							this.set("SetTemplateRecordId", null);
							this.setTemplateWithCheck(setTemplateRecordId);
						} else {
							var needRefresh = this.get("NeedRefreshAfterPageSaved");
							if (needRefresh) {
								this.set("NeedRefreshAfterPageSaved", false);
								this.set("AddRowOnDataChangedConfig", {callback: this.onCardSaved, scope: this});
								this.reloadGridData();
							} else {
								this.callParent(arguments);
							}
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseDetailV2#onGridDataLoaded
					 * @overridden
					 */
					onGridDataLoaded: function() {
						this.callParent(arguments);
						var addRowConfig = this.get("AddRowOnDataChangedConfig");
						if (addRowConfig) {
							this.set("AddRowOnDataChangedConfig", null);
							if (this.Ext.isFunction(addRowConfig.callback)) {
								addRowConfig.callback.call(addRowConfig.scope || this);
							}
						}
					},

					/**
					 * ######## ##### ######### ####### ####### ### ####### OrderPassportService.
					 * @protected
					 * @param {String} tag Id #######.
					 */
					setTemplateWithCheck: function(tag) {
						var orderId = this.get("MasterRecordId");
						this.BPMSoft.chain(
								function(next) {
									var data = this.getGridData();
									if (data.getCount() === 0) {
										next();
									} else {
										this.showConfirmationDialog(this.get("Resources.Strings.SetTemplateActionWarning"),
												function(returnCode) {
													if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
														this.set("IsGridLoading", true);
														next();
													}
												},
												[this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode],
												null);
									}
								},
								function() {
									this.callService({
										serviceName: "OrderPassportService",
										methodName: "ChangeTemplate",
										data: {
											"orderId": orderId,
											"templateId": tag
										}
									}, this.onTemplateChanged, this);
								},
								this);
					},

					/**
					 * ########## ####### ####, ### ######, ######## # ######## ##############, ### ## #### #########.
					 * @protected
					 * @returns {Boolean} ####### ####, ### ######, ######## # ######## ##############, ### ## #### #########.
					 */
					getIsNewMasterRecord: function() {
						var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
						var isNew = (cardState.state === enums.CardStateV2.ADD || cardState.state === enums.CardStateV2.COPY);
						return isNew;
					},

					/**
					 * ######### ###### ## ######. #### ######, # ####### ######### ###### ## #########, #########
					 * ##########.
					 * @protected
					 */
					addTemplateItemRecord: function() {
						var args = arguments;
						var isNew = this.getIsNewMasterRecord();
						var isDefTemplateExists = Boolean(this.get("OrderPassportTemplateDef"));
						if (!isNew || !isDefTemplateExists) {
							this.addRecord(args);
						} else {
							this.BPMSoft.chain(
									function(next) {
										this.showConfirmationDialog(this.get("Resources.Strings.ThereIsDefTemplateWarning"),
												function(returnCode) {
													if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
														this.turnDefPassportTemplateOff(next);
													} else {
														this.set("NeedRefreshAfterPageSaved", true);
														next();
													}
												}, [this.BPMSoft.MessageBoxButtons.YES.returnCode,
													this.BPMSoft.MessageBoxButtons.NO.returnCode],
												null);
									},
									function() {
										this.addRecord(args);
									},
									this
							);
						}
					},

					/**
					 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getAddItemsToGridDataOptions
					 * @overridden
					 */
					getAddItemsToGridDataOptions: function() {
						return {
							mode: "bottom"
						};
					},

					/**
					 * ######### ######## ######### ####### ######## # ##### ## ####### ## ######### #########.
					 * @param {Function} next ####### ######### ######.
					 */
					turnDefPassportTemplateOff: function(next) {
						var orderId = this.get("MasterRecordId");
						this.callService({
							serviceName: "OrderPassportService",
							methodName: "TurnDefPassportTemplateOff",
							data: {
								"orderId": orderId
							}
						}, function() {
							next();
						}, this);
					},

					/**
					 * ############ ##### ## ####### ## ######### #######.
					 * ######### ###### ## ###### # ###### ######, #### ####### ######### # #######.
					 * @protected
					 * @param {Object} response ##### ## #######.
					 */
					onTemplateChanged: function(response) {
						this.set("IsGridLoading", false);
						if (response && response.ChangeTemplateResult) {
							var result = response.ChangeTemplateResult;
							if (result.success) {
								this.set("ActiveRow", null);
								this.fireDetailChanged(null);
								this.reloadGridData();
							} else if (result.errorInfo) {
								var errorData = {
									IsDbOperationException: result.errorInfo.errorCode === "DbOperationException",
									ExceptionMessage: result.errorInfo.message
								};
								this.showDeleteExceptionMessage(errorData);
							}
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetail#fireDetailChanged
					 * @override
					 */
					fireDetailChanged: function() {
						if (this.get("SaveOnClosePage") !== true) {
							this.callParent(arguments);
						}
					},

					/**
					 * Returns availability sign for the tools button menu items.
					 * @protected
					 * @return {Boolean} Availability sign.
					 */
					getEnableMenuActions: function() {
						if (this.getEditRecordButtonEnabled()) {
							var notAllowed = ConfigurationConstants.SupplyPayment.StateFinished;
							var record = this.getActiveRow();
							var status = record.get("State");
							return (status.value !== notAllowed);
						}
						return false;
					},

					/**
					 * @inheritDoc BPMSoft.Configuration.BaseDetailV2#updateDetail
					 * @overridden
					 */
					updateDetail: function(config) {
						if (!config.reloadAll) {
							this.fireDetailChanged(null);
							config.reloadAll = true;
						}
						this.callParent([config]);
					},

					/**
					 * ######## ######### ###### #### ### ######### #####, # ########### ## ######## #### #######.
					 * @protected
					 * @return {Boolean}
					 */
					getGenerateButtonsVisible: function() {
						return !this.get("MultiSelect");
					},

					/**
					 * Generate button handler.
					 * @private
					 */
					generateButtonClick: function() {
						var entity = arguments[arguments.length - 1]; // ### ########## ######### ##########
						this.showConfirmationDialog(this.get("Resources.Strings.Create" + entity),
								function(dialogResult) {
									if (dialogResult === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
										var collection = this.getGridData();
										var selectedRows;
										if (this.get("MultiSelect")) {
											selectedRows = this.get("SelectedRows") ? this.get("SelectedRows") : [];
										} else {
											selectedRows = this.get("ActiveRow") ? [this.get("ActiveRow")] : [];
										}

										if (!selectedRows.length) {
											this.validateResult({error: result.NoItems});
											return;
										}

										var filteredCollection = [];
										BPMSoft.each(selectedRows, function(row) {
											var item = collection.get(row);
											if (this.checkSupplyPaymentType(item, entity)) {
												filteredCollection.push(item);
											}
										}, this);

										if (!filteredCollection.length) {
											this.validateResult({error: result.TypeNotMatch, entity: entity});
											return;
										}

										this.asyncGenerateInvoices(filteredCollection);
									}
								},
								["yes", "no"]
						);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#sortColumn
					 * @overridden
					 */
					sortColumn: this.BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
					 * @overridden
					 */
					getGridSortMenuItem: this.BPMSoft.emptyFn,

					/**
					 * Async invoice generation.
					 * @private
					 * @param {Array} collection Supply payment elements.
					 */
					asyncGenerateInvoices: function(collection) {
						collection = collection || [];
						this.index = 0;
						this.existInvoiceCount = 0;
						collection.forEach(function(item) {
							var methods = [];
							methods.push(function(next) {
								this.generateInvoice(next, item);
							});
							methods.push(this.hideBodyMask);
							methods.push(this);
							this.showBodyMask();
							BPMSoft.chain.apply(this, methods);
						}, this);
					},

					/**
					 * Generates invoice.
					 * @protected
					 * @virtual
					 * @param {Function} next Next chain f-n.
					 * @param {BPMSoft.BaseViewModel} item Row item.
					 */
					generateInvoice: function(next, item) {
						var invoice = item.get("Invoice");
						if ((invoice === null && this.getIsFeatureEnabled("UseLookupInvoiceForSupplyPaymentDetail")) ||
							(invoice && this.BPMSoft.isGUID(invoice.value))) {
							this.existInvoiceCount++;
							this.validateResult({
								error: result.ExistInvoice,
								existInvoiceCount: this.existInvoiceCount
							});
							next();
						} else {
							this.setAdditionAttributes(next, item);
						}
					},

					/**
					 * Sets additional attributes to row item.
					 * @protected
					 * @virtual
					 * @param {Function} next Next chain f-n.
					 * @param {BPMSoft.BaseViewModel} item Row item.
					 */
					setAdditionAttributes: function(next, item) {
						this.getIncrementCode(function(result) {
							item.set("Number", result);
							item.set("StartDate", new Date());
							var esq = this.getSupplyPaymentProductEntitySchemaQuery(item.get("Id"));
							esq.getEntityCollection(function(response) {
								if (response.success) {
									const products = response.collection;
									this.processProducts(products);
									item.set("ProductCollection", products);
									this.insertInvoice(next, item);
								}
							}, this);
						}, this);
					},

					/**
					 * Processes products collection.
					 * @protected
					 * @virtual
					 * @param {BPMSoft.Collection} products Products collection.
					 */
					processProducts: function(products) {
						products.each(function(product) {
							const discountAmount = product.get("DiscountAmount") * product.get("Quantity") / product.get("MaxQuantity");
							product.set("DiscountAmount", discountAmount);
						}, this);
					},

					/**
					 * Inserts invoice products.
					 * @protected
					 * @virtual
					 * @param {Function} nextParrent Next chain f-n.
					 * @param {Object} config Row item config.
					 */
					insertInvoiceProducts: function(nextParrent, config) {
						var productsMethods = [];
						BPMSoft.each(config.products.getItems(), function() {
							productsMethods.push(function(next, i) {
								if (!i) {
									i = 0;
								}
								var insert = this.getInvoiceProductInsertQuery(config, i);
								insert.execute(function(response) {
									if (response.success) {
										i++;
										next(i);
									}
								}, this);
							});
						}, this);
						productsMethods.push(function() {
							this.updateSupplyPaymentElement(nextParrent, config);
						});
						productsMethods.push(this);
						BPMSoft.chain.apply(this, productsMethods);
					},

					/**
					 * Updates supply payment row element.
					 * @protected
					 * @virtual
					 * @param {Function} next Next chain f-n.
					 * @param {Object} config Row item config.
					 */
					updateSupplyPaymentElement: function(next, config) {
						var update = this.getSupplyPaymentElementUpdateQuery(config);
						update.execute(function(response) {
							if (response.success) {
								this.updateDetail({primaryColumnValue: config.id});
								this.openInvoicePage(config.invoiceId);
								next();
							}
						}, this);
					},

					/**
					 * Inserts invoice.
					 * @protected
					 * @virtual
					 * @param {Function} next Next chain f-n.
					 * @param {BPMSoft.BaseViewModel} item Row item.
					 */
					insertInvoice: function(next, item) {
						var insert = this.getInvoiceInsertQuery(item);
						insert.execute(function(response) {
							if (response.success) {
								var config = {
									invoiceId: response.id,
									id: item.get("Id"),
									amount: item.get("AmountPlan"),
									number: item.get("Number"),
									startDate: item.get("StartDate"),
									products: item.get("ProductCollection")
								};
								var invoice = {
									displayValue: item.get("Number"),
									value: response.id
								};
								item.set("Invoice", invoice);
								if (config.products.getCount() === 0) {
									this.updateSupplyPaymentElement(next, config);
								} else {
									this.insertInvoiceProducts(next, config);
								}
							} else {
								var message = this.generateInvoiceErrorMessage(response);
								this.showErrorMessage(message);
							}
						}, this);
					},

					/**
					 * Generates invoice creation error message.
					 * @param response
					 * @param callback
					 * @param scope
					 */
					generateInvoiceErrorMessage: function(response) {
						var message = response.errorInfo && response.errorInfo.message;
						message = this.Ext.String.format(this.get("Resources.Strings.InvoiceInsertError"),
								message, this.getInvoiceErrorUrl());
						return message;
					},

					/**
					 * Returns invoice error article url.
					 * @return {String} Academy article url.
					 */
					getInvoiceErrorUrl: function() {
						return resources.localizableStrings.InvoiceErrorArticleUrl;
					},

					/**
					 * Show error message in dialog window.
					 * @protected
					 * @param {String} message Error message.
					 */
					showErrorMessage: function(message) {
						var messageConfig = {
							caption: message,
							buttons: ["ok"],
							defaultButton: 0,
							style: BPMSoft.MessageBoxStyles.ORANGE,
							useHtmlContent: true
						};
						this.BPMSoft.utils.showMessage(messageConfig);
						this.hideBodyMask();
					},

					/**
					 * ######### # ######### ####### #######.
					 * @private
					 * @param {Guid} id ############# #### ####### ######## # #####.
					 * @return {BPMSoft.EntitySchemaQuery} esq ###### ######### ######### ## #### ######.
					 */
					getSupplyPaymentProductEntitySchemaQuery: function(id) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "SupplyPaymentProduct"
						});
						esq.addColumn("Product.Product", "Product");
						esq.addColumn("Product.Name", "Name");
						esq.addColumn("Product.Price", "Price");
						esq.addColumn("Product.DiscountPercent", "DiscountPercent");
						esq.addColumn("Product.Tax", "Tax");
						esq.addColumn("Product.DiscountTax", "DiscountTax");
						esq.addColumn("Product.Amount", "Amount");
						esq.addColumn("Product.DiscountAmount", "DiscountAmount");
						esq.addColumn("Product.TaxAmount", "TaxAmount");
						esq.addColumn("Product.Unit", "Unit");
						esq.addColumn("Quantity");
						esq.addColumn("BaseQuantity");
						esq.addColumn("Product.Quantity", "MaxQuantity");
						esq.addColumn("Amount", "TotalAmount");
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "SupplyPaymentElement", id));
						return esq;
					},

					/**
					 * ######### # ######### ####### #######.
					 * @private
					 * @param {Object} config.
					 * @return {BPMSoft.UpdateQuery} update ###### ######### #### ######.
					 */
					getSupplyPaymentElementUpdateQuery: function(config) {
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "SupplyPaymentElement"
						});
						update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", config.id));
						update.setParameterValue("Invoice", config.invoiceId, this.BPMSoft.DataValueType.GUID);
						return update;
					},

					/**
					 * @inheritDoc BPMSoft.GridUtilitiesV2#onDeleted
					 * @overridden
					 */
					onDeleted: function() {
						this.updateDetail({});
						this.mixins.GridUtilities.onDeleted.apply(this, arguments);
					},

					/**
					 * @inheritDoc BPMSoft.BaseGridDetailV2#getUpdateDetailSandboxTags
					 * @overridden
					 */
					getUpdateDetailSandboxTags: function() {
						var tags = this.callParent(arguments);
						return tags.concat(this.getInviocePageSandboxId());
					},

					/**
					 * @inheritDoc BPMSoft.ConfigurationGridUtilities#activeRowSaved
					 * @overridden
					 */
					activeRowSaved: function(activeRow, callback, scope) {
						callback = callback || this.Ext.emptyFn;
						scope = scope || this;
						var newArguments = [activeRow, this.checkAndDivideProducts.bind(this, activeRow, callback, scope), this];
						this.mixins.ConfigurationGridUtilites.activeRowSaved.apply(this, newArguments);
					},

					/**
					 * ######### ############# ########## #########.
					 * @param {Object} row ###### #######.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ##########.
					 */
					checkAndDivideProducts: function(row, callback, scope) {
						var contract;
						if (row) {
							contract = row.get("Contract");
						}
						if (!row || !contract || !contract.value) {
							callback.call(scope);
							return;
						}
						var divideProductData = {
							supplyPaymentProductId: row.get("Id"),
							contractId: contract.value
						};
						var config = {
							serviceName: "SupplyPaymentService",
							methodName: "NeedDivideProduct",
							data: divideProductData
						};
						this.callService(config, function(response) {
							if (response && response.NeedDivideProductResult) {
								this.onDivideProductNecessary(divideProductData, callback, scope);
							} else {
								callback.call(scope);
							}
						}, this);
					},

					/**
					 * ###### ############# ############ ## ########## ######### ## ###### #########.
					 * @param {Object} divideProductData ######### ######## ####.
					 * @param {Guid} divideProductData.supplyPaymentProductId Id ######## ####.
					 * @param {Guid} divideProductData.contractId Id ######## ######## ####.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ##########.
					 */
					onDivideProductNecessary: function(divideProductData, callback, scope) {
						this.showConfirmation(
								this.get("Resources.Strings.DivideProduct"),
								function(buttonCode) {
									if (buttonCode === "ok") {
										this.onDivideProductsAccepted(divideProductData, callback, scope);
									} else {
										callback.call(scope);
									}
								},
								["ok", "cancel"],
								this
						);
					},

					/**
					 * ######### ######## ## #########.
					 * @param {Object} divideProductData ######### ######## ####.
					 * @param {Guid} divideProductData.supplyPaymentProductId Id ######## ####.
					 * @param {Guid} divideProductData.contractId Id ######## ######## ####.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ##########.
					 */
					onDivideProductsAccepted: function(divideProductData, callback, scope) {
						var config = {
							serviceName: "SupplyPaymentService",
							methodName: "DivideProduct",
							data: divideProductData
						};
						this.callService(config, function() {
							this.fireDetailChanged(null);
							callback.call(scope);
						}, this);
					},

					/**
					 * ############# ###########.
					 * @private
					 * @param {Object} config ###### ### #########.
					 */
					validateResult: function(config) {
						var resultText = "";
						switch (config.error) {
							case result.NoError:
								resultText = Ext.String.format(this.get("Resources.Strings.InvoicesCreated"),
										"\n\t", config.invoicesCount);
								if (config.existInvoiceCount) {
									resultText += this.get("Resources.Strings.ExistInvoice");
								}
								break;
							case result.NoItems:
								resultText = this.get("Resources.Strings.NoItems");
								break;
							case result.TypeNotMatch:
								resultText = Ext.String.format(this.get("Resources.Strings.TypeNotMatch"),
										this.get("Resources.Strings." + config.entity),
										config.entity === entityName.Invoice
												? this.get("Resources.Strings.Payment")
												: this.get("Resources.Strings.Delivery"));
								break;
							case result.ExistInvoice:
								resultText = this.get("Resources.Strings.ExistInvoice");
								break;
						}
						if (resultText) {
							this.showInformationDialog(resultText);
						}
					},

					/**
					 * ######## #### ######.
					 * @private
					 * @param {Object} item #######, # ######## ########## ######### ###.
					 * @param {Enum} entity ### #######.
					 * @return {Boolean}
					 */
					checkSupplyPaymentType: function(item, entity) {
						var result = GridButtonsUtil.instance.getIsPayment(item);
						return (entity === entityName.Invoice) ? result : !result;
					},

					/**
					 * ########## ######## #### # ####### ########## # ######## #### # ######.
					 * @private
					 * @param {String} table ### #######.
					 * @param {String} column ### #######.
					 * @param {Object} scope ########.
					 * @return {Object} ########## ####### ######.
					 */
					getColumnData: function(table, column, scope) {
						scope = scope || this;
						var path = this.Ext.String.format("{0}.{1}", table, column);
						var tableValue = scope.get(table);
						if (tableValue && tableValue[column]) {
							scope.set(path, tableValue[column]);
						}
						return scope.get(path);
					},

					/**
					 * Creates Invoice insert request.
					 * @private
					 * @param {BPMSoft.BaseViewModel} item ViewModel with Invoice request generation properties.
					 * @return {BPMSoft.InsertQuery}
					 */
					getInvoiceInsertQuery: function(item) {
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "Invoice"
						});
						insert.setParameterValue("Number", item.get("Number"), this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("Order", item.get("Order").value, this.BPMSoft.DataValueType.GUID);
						var opportunity = this.getColumnData("Order", "Opportunity", item);
						if (opportunity) {
							insert.setParameterValue("Opportunity", opportunity.value,
									this.BPMSoft.DataValueType.GUID);
						}
						var contact = this.getColumnData("Order", "Contact", item);
						if (contact) {
							insert.setParameterValue("Contact", contact.value,
									this.BPMSoft.DataValueType.GUID);
						}
						var account = this.getColumnData("Order", "Account", item);
						if (account) {
							insert.setParameterValue("Account", account.value,
									this.BPMSoft.DataValueType.GUID);
						}
						var currency = this.getColumnData("Order", "Currency", item);
						if (currency) {
							insert.setParameterValue("Currency", currency.value,
									this.BPMSoft.DataValueType.GUID);
						}
						var currencyRate = this.getColumnData("Order", "CurrencyRate", item);
						if (currency) {
							insert.setParameterValue("CurrencyRate", currencyRate,
									this.BPMSoft.DataValueType.FLOAT);
						}
						insert.setParameterValue("Owner", BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
								this.BPMSoft.DataValueType.GUID);
						var supplier = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value;
						if (!this.BPMSoft.isEmptyGUID(supplier)) {
							insert.setParameterValue("Supplier", supplier,
									this.BPMSoft.DataValueType.GUID);
						}
						insert.setParameterValue("StartDate", item.get("StartDate"), this.BPMSoft.DataValueType.DATE);
						if (item.get("ProductCollection").getCount() === 0) {
							this.recalculatePrimaryValue("AmountPlan", {
								modelInstance: item,
								primaryValueAttribute: "PrimaryAmount"
							});
							var primaryAmount = item.get("PrimaryAmount");
							insert.setParameterValue("PrimaryAmount", primaryAmount,
									this.BPMSoft.DataValueType.FLOAT);
							insert.setParameterValue("Amount", item.get("AmountPlan"),
									this.BPMSoft.DataValueType.FLOAT);
						}
						return insert;
					},

					/**
					 * ######### ###### #####.
					 * @private
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ####### ######### ######.
					 */
					getIncrementCode: function(callback, scope) {
						var config = {
							serviceName: "SysSettingsService",
							methodName: "GetIncrementValueVsMask",
							data: {
								sysSettingName: "InvoiceLastNumber",
								sysSettingMaskName: "InvoiceCodeMask"
							}
						};
						this.callService(config, function(response) {
							callback.call(this, response.GetIncrementValueVsMaskResult);
						}, scope || this);
					},

					/**
					 * Initialize product utilities.
					 * @param {Function} callback Callback function.
					 * @param {Object} [scope] Execution context.
					 * @protected
					 */
					initProductUtilities: function(callback, scope) {
						this.BPMSoft.SysSettings.querySysSettingsItem("PriceWithTaxes",
								function(signOfPriceWithTaxes) {
									this._defineProductUtilities(InvoiceProductSchema, signOfPriceWithTaxes);
									this.Ext.callback(callback, scope || this);
								}, this);
					},

					/**
					 * Returns ProductUtilities.
					 * @protected
					 * @return {BPMSoft.ProductUtilities} ProductUtilities.
					 */
					getProductUtilities: function() {
						return this.productUtils;
					},

					/**
					 * Defines ProductUtilities.
					 * @param {BPMSoft.EntitySchema} schema Entity Schema.
					 * @param {Boolean} signOfPriceWithTaxes Sing of includes taxes in price.
					 * @private
					 */
					_defineProductUtilities: function(schema, signOfPriceWithTaxes) {
						this.productUtils = ProductUtilities;
						this.productUtils.columns = schema.columns;
						this.productUtils.PriceWithTaxes = signOfPriceWithTaxes;
					},

					/**
					 * Creates InvoiceProduct insert request.
					 * @private
					 * @param {Object} config Request config object.
					 * @param {int} i product index in step.
					 * @return {BPMSoft.InsertQuery}
					 */
					getInvoiceProductInsertQuery: function(config, i) {
						var product = config.products.getByIndex(i);
						var productUtilities = this.getProductUtilities();
						productUtilities.calculateProductValues(product);
						var insert = this.Ext.create("BPMSoft.InsertQuery", {
							rootSchemaName: "InvoiceProduct"
						});
						insert.setParameterValue("SupplyPaymentProduct", product.get("Id"),
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Name", product.get("Name"), this.BPMSoft.DataValueType.TEXT);
						insert.setParameterValue("Product", product.get("Product").value,
								this.BPMSoft.DataValueType.GUID);
						var price = product.get("Price");
						insert.setParameterValue("Price", price, this.BPMSoft.DataValueType.FLOAT);
						var discountPercent = product.get("DiscountPercent");
						insert.setParameterValue("DiscountPercent", discountPercent, this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("Tax", product.get("Tax").value,
								this.BPMSoft.DataValueType.GUID);
						var discountTax = product.get("DiscountTax");
						insert.setParameterValue("DiscountTax", discountTax, this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("TotalAmount", product.get("TotalAmount"),
								this.BPMSoft.DataValueType.FLOAT);
						var quantity = product.get("Quantity");
						insert.setParameterValue("Quantity", quantity, this.BPMSoft.DataValueType.FLOAT);
						var baseQuantity = product.get("BaseQuantity");
						insert.setParameterValue("BaseQuantity", baseQuantity, this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("Amount", product.get("Amount"), this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("DiscountAmount", product.get("DiscountAmount"), this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("TaxAmount", product.get("TaxAmount"), this.BPMSoft.DataValueType.FLOAT);
						insert.setParameterValue("Unit", product.get("Unit").value,
								this.BPMSoft.DataValueType.GUID);
						insert.setParameterValue("Invoice", config.invoiceId, this.BPMSoft.DataValueType.GUID);
						return insert;
					},

					/**
					 * @inheritDoc BPMSoft.mixins.ConfigurationGridUtilites#saveRowChanges
					 * @overridden
					 */
					saveRowChanges: function(row, callback, scope) {
						this.mixins.ConfigurationGridUtilites.saveRowChanges.call(this, row, function() {
							if (this.get("NeedReloadGridData")) {
								this.set("NeedReloadGridData", false);
								this.set("AddRowOnDataChangedConfig", {callback: callback, scope: scope});
								this.fireDetailChanged(null);
								this.reloadGridData();
							} else if (callback) {
								callback.call(scope || this);
							}
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#editRecord
					 * @overridden
					 **/
					editRecord: function() {
						var activeRow = this.getActiveRow();
						var typeColumnValue = this.getTypeColumnValue(activeRow);
						this.saveIfNeedAndProceed(activeRow, function() {
							this.openCard(enums.CardStateV2.EDIT, typeColumnValue, activeRow.get("Id"));
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
					 * @overridden
					 */
					getFilterDefaultColumnName: function() {
						return "Type";
					},

					/**
					 * Event handler New button click.
					 * @private
					 * @return {Boolean}
					 */
					onAddButtonClick: function() {
						var templateExist = this.get("TemplatesExists");
						if (!templateExist) {
							this.addRecord();
						} else {
							return false;
						}
					},
					
					/**
					 * @inheritdoc BPMSoft.BaseGridDetail#getAddTypedRecordButtonVisible
					 */
					getAddTypedRecordButtonVisible: function() {
						return this.get("IsEnabled");
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DeleteRecordMenu",
						"parentName": "ActionsButton",
						"propertyName": "menu",
						"index": 1,
						"values": {"enabled": {"bindTo": "getEnableMenuActions"}}
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowOpenAction"
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowCopyAction"
					},
					{
						"operation": "remove",
						"name": "DataGridActiveRowDeleteAction"
					},
					{
						"operation": "insert",
						"name": "activeRowActionSave",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "save",
							"markerValue": "save",
							"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
						}
					},
					{
						"operation": "insert",
						"name": "activeRowActionOpenCard",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "card",
							"markerValue": "card",
							"imageConfig": {"bindTo": "Resources.Images.CardIcon"}
						}
					},
					{
						"operation": "insert",
						"name": "activeRowActionCancel",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "cancel",
							"markerValue": "cancel",
							"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
						}
					},
					{
						"operation": "insert",
						"name": "activeRowActionRemove",
						"parentName": "DataGrid",
						"propertyName": "activeRowActions",
						"values": {
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "remove",
							"markerValue": "remove",
							"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
						}
					},
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"className": "BPMSoft.ConfigurationGrid",
							"generator": "ConfigurationGridGenerator.generatePartial",
							"type": "listed",
							"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
							"changeRow": {"bindTo": "changeRow"},
							"unSelectRow": {"bindTo": "unSelectRow"},
							"onGridClick": {"bindTo": "onGridClick"},
							"sortColumnIndex": null,
							"listedZebra": true,
							"useLinks": true,
							"collection": {"bindTo": "Collection"},
							"activeRow": {"bindTo": "ActiveRow"},
							"selectedRows": {"bindTo": "SelectedRows"},
							"primaryColumnName": "Id",
							"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
							"activeRowAction": {"bindTo": "onActiveRowAction"},
							"activeRowActions": []
						}
					},
					{
						"operation": "remove",
						"name": "AddRecordButton"
					},
					{
						"operation": "merge",
						"name": "AddTypedRecordButton",
						"values": {
							"caption": "",
							"click": {"bindTo": "onAddButtonClick"},
							"controlConfig": {"menu": {"items": {"bindTo": "ItemTemplates"}}}
						}
					},
					{
						"operation": "merge",
						"name": "ToolsButton",
						"values": {
							"generateId": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
