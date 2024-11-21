define("ProductDetailV2", ["BPMSoft", "ConfigurationEnums", "MaskHelper", "ConfigurationGrid",
		"ConfigurationGridGenerator", "ConfigurationGridUtilities"],
	function(BPMSoft, enums, MaskHelper) {
		return {
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
			attributes: {
				IsEditable: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			messages: {
				/**
				 * @message ProductSelectionInfo
				 * ########### ######### ###### ####### ########
				 * @return {Object}
				 */
				"ProductSelectionInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ProductSelectionSave
				 * ############ ####### ######## ###### ####### #########
				 */
				"ProductSelectionSave": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				/**
				 * Detail initialization
				 * @protected
				 * @overriden
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeOnProductSelectionInfo();
					this.set("MultiSelect", false);
					BPMSoft.SysSettings.querySysSettings(["BasePriceList", "DefaultTax", "PriceWithTaxes"], function(values) {
						if (values.DefaultTax) {
							this.set("DefaultTax", values.DefaultTax);
						}
						if (values.BasePriceList) {
							this.set("BasePriceList", values.BasePriceList);
						}
						if (values.PriceWithTaxes) {
							this.set("PriceWithTaxes", values.PriceWithTaxes);
						}
					}, this);
				},

				/**
				 * Subscribing for product selection module events
				 * @protected
				 */
				subscribeOnProductSelectionInfo: function() {
					this.sandbox.subscribe("ProductSelectionSave", this.onProductsSelected,
						this, [this.sandbox.id + "_ProductSelectionModule"]);
					this.sandbox.subscribe("ProductSelectionInfo", function() {
						return {
							masterRecordId: this.get("MasterRecordId"),
							masterEntitySchemaName: this.get("DetailColumnName"),
							masterProductEntitySchemaName: this.entitySchemaName,
							masterCurrency: this.get("Currency"),
							predefinedPriceList: this.getPredefinedPriceList()
						};
					}, this, [this.sandbox.id + "_ProductSelectionModule"]);
				},

				/**
				 * Calls on "ProductSelectionSave" event
				 * @protected
				 * @virtual
				 */
				onProductsSelected: function() {
					this.reloadGridData();
					this.fireDetailChanged();
				},

				/**
				 * Extracts predefined price list from card default values.
				 * @protected
				 * @virtual
				 * @returns {Object} Predefined price list.
				 */
				getPredefinedPriceList: function() {
					const cardValues = this.sandbox.publish("GetColumnsValues", ["PredefinedPriceList"], [this.sandbox.id]);
					return cardValues["PredefinedPriceList"];
				},

				/**
				 * Returns is card changed.
				 * @protected
				 * @return {boolean}
				 */
				isCardChanged: function() {
					return this.sandbox.publish("IsCardChanged", null, [this.sandbox.id]);
				},

				/**
				 * "Add product" button handler.
				 * Saves card if it changed and opens product selection page.
				 * @protected
				 */
				onProductSelectionButtonClick: function() {
					var isCardChanged = this.isCardChanged();
					if (isCardChanged) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.set("OpenProductSelectionModule", true);
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					} else {
						this.loadProductSelectionModule();
					}
				},

				/**
				 * ############ ######### # ########## ######
				 * @protected
				 */
				onCardSaved: function() {
					if (this.get("OpenProductSelectionModule")) {
						this.loadProductSelectionModule();
						this.set("OpenProductSelectionModule", false);
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * ######### ###### ####### #########
				 * @protected
				 * @virtual
				 */
				loadProductSelectionModule: function() {
					var openCardConfig = {
						moduleId: this.sandbox.id,
						OpenProductSelectionModule: true,
						operation: enums.CardStateV2.EDIT
					};
					this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
				},

				/**
				 * Sets default grid row view model configuration.
				 * @return {Object} Grid row view model configuration.
				 */
				getGridRowViewModelConfig: function() {
					var rowConfig = this.callParent(arguments);
					if (this.getIsEditable()) {
						var defaultTax = this.get("DefaultTax");
						if (defaultTax) {
							rowConfig.values.DefaultTax = defaultTax;
						}
						var basePriceList = this.get("BasePriceList");
						if (basePriceList) {
							rowConfig.values.BasePriceList = basePriceList;
						}
						var priceWithTaxes = this.get("PriceWithTaxes");
						if (priceWithTaxes) {
							rowConfig.values.PriceWithTaxes = priceWithTaxes;
						}
						rowConfig.methods = rowConfig.methods || {};
						var scope = this;
						rowConfig.methods.onSaved = function(response, config) {
							scope.onProductSaved.call(scope);
							if (config && config.isSilent) {
								this.onSilentSaved(response, config);
							}
						};
					}
					return rowConfig;
				},

				/**
				 * Sends message with information about detail changes to the page.
				 */
				onProductSaved: function() {
					this.fireDetailChanged({});
					MaskHelper.HideBodyMask();
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @override
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					const addRecordButton = this.getAddRecordOperationMenuItem();
					if (addRecordButton) {
						toolsButtonMenu.addItem(addRecordButton);
					}
					this.callParent(arguments);
				},

				/**
				 * Returns add record button menu item.
				 * @protected
				 * @virtual
				 * @returns {Object} Add record button menu item.
				 */
				getAddRecordOperationMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.AddButtonCaption"},
						Click: {"bindTo": "addRecord"},
						Enabled: {"bindTo": "getAddRecordButtonEnabled"}
					});
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#onDataChanged
				 * @override
				 */
				onDataChanged: function() {
					this.callParent(arguments);
					var gridData = this.getGridData();
					this.BPMSoft.each(gridData.getItems(), function(item) {
						item.setProductPriceEnabled();
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {bindTo: "generateActiveRowControlsConfig"},
						"multiSelect": {"bindTo": "MultiSelect"},
						"changeRow": {"bindTo": "changeRow"},
						"selectRow": {"bindTo": "createEditRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"activeRowActions": [
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "save",
								"markerValue": "save",
								"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "cancel",
								"markerValue": "cancel",
								"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "remove",
								"markerValue": "remove",
								"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
							}
						],
						"listedZebra": true,
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
						"activeRowAction": {"bindTo": "onActiveRowAction"}
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"values": {
						"click": {"bindTo": "onProductSelectionButtonClick"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
