define("ProductPageV2", ["MoneyModule", "MultiCurrencyEdit", "MultiCurrencyEditUtilities",
		"css!ProductManagementBaseCss"],
	function(MoneyModule) {
		return {
			entitySchemaName: "Product",
			attributes: {
				/**
				 * Owner of the product.
				 */
				"Owner": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							return BPMSoft.createColumnIsNotNullFilter("[SysAdminUnit:Contact].Id");
						}
					}
				},
				/**
				 * Unit of the product.
				 */
				"Unit": {
					"isRequired": true
				},
				/**
				 * Price in base currency.
				 * @private
				 */
				"PrimaryPrice": {
					"dataValueType": BPMSoft.DataValueType.FLOAT,
					"dependencies": [
						{
							"columns": ["CurrencyRate", "Price"],
							"methodName": "recalculatePrimaryPrice"
						}
					]
				},
				/**
				 * Currency rate.
				 * @private
				 */
				"CurrencyRate": {
					"dataValueType": BPMSoft.DataValueType.FLOAT,
					"dependencies": [
						{
							"columns": ["Currency"],
							"methodName": "setCurrencyRate"
						}
					]
				},
				/**
				 * Currency rate list.
				 */
				"CurrencyRateList": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: this.Ext.create("BPMSoft.Collection")
				},
				/**
				 * Currency button menu list.
				 */
				"CurrencyButtonMenuList": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: this.Ext.create("BPMSoft.BaseViewModelCollection")
				}
			},
			properties: {
				moneyModule: null
			},
			details: /**SCHEMA_DETAILS*/{
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "ProductFile",
					filter: {
						masterColumn: "Id",
						detailColumn: "Product"
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				/**
				 * Mixin multi-currency management in the entity page.
				 */
				MultiCurrencyEditUtilities: "BPMSoft.MultiCurrencyEditUtilities"
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function() {
					this.moneyModule = MoneyModule;
					this.callParent(arguments);
				},
				
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.mixins.MultiCurrencyEditUtilities.init.call(this);
					this.recalculatePrimaryPrice();
					this.setCurrencyRate();
				},

				/**
				 * @inheritDoc BPMSoft.ContextHelpMixin#initContextHelp
				 * @override
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1056);
					this.callParent(arguments);
				},

				/**
				 * Handlers the file selection dialog.
				 * @return {Boolean}
				 */
				beforePhotoFileSelected: function() {
					return true;
				},

				/**
				 * Returns photo link.
				 * @protected
				 * @return {String}
				 */
				getPhotoSrcMethod: function() {
					var primaryImageColumnValue = this.get(this.primaryImageColumnName);
					if (primaryImageColumnValue) {
						return this.getSchemaImageUrl(primaryImageColumnValue);
					}
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.DefaultPhoto"));
				},

				/**
				 * Handlers changed and upload an image.
				 * @param {Object} photo
				 */
				onPhotoChange: function(photo) {
					if (!photo) {
						this.set(this.primaryImageColumnName, null);
						return;
					}
					this.BPMSoft.ImageApi.upload({
						file: photo,
						onComplete: this.onPhotoUploaded,
						onError: this.BPMSoft.emptyFn,
						scope: this
					});
				},

				/**
				 * Handlers uploaded an image.
				 * @param {String} imageId
				 */
				onPhotoUploaded: function(imageId) {
					var imageData = {
						value: imageId,
						displayValue: "Picture"
					};
					this.set(this.primaryImageColumnName, imageData);
				},

				/**
				 * Returns currency division.
				 * @protected
				 * @return {Number} Currency division.
				 */
				getCurrencyDivision: function() {
					var currency = this.get("Currency");
					return currency && currency.Division;
				},

				/**
				 * Recalculates price in base currency.
				 * @protected
				 */
				recalculatePrimaryPrice: function() {
					var price = this.get("Price");
					if (this.Ext.isEmpty(price)) {
						this.set("PrimaryPrice", null);
						return;
					}
					var division = this.getCurrencyDivision();
					this.moneyModule.RecalcBaseValue.call(this, "CurrencyRate", "Price", "PrimaryPrice", division);
				},

				/**
				 * Sets currency rate.
				 * @protected
				 */
				setCurrencyRate: function() {
					this.moneyModule.LoadCurrencyRate.call(this, "Currency", "CurrencyRate", new Date());
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"layout": {"column": 0, "row": 0, "rowSpan": 2, "colSpan": 2},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "Photo",
					"values": {
						"getSrcMethod": "getPhotoSrcMethod",
						"onPhotoChange": "onPhotoChange",
						"beforeFileSelected": "beforePhotoFileSelected",
						"readonly": false,
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "CommonControlGroup",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {"column": 3, "row": 1, "colSpan": 21, "rowSpan": 1},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ProductGeneralInfoBlock",
					"parentName": "CommonControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Type",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Type",
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"name": "Unit",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Unit",
						"layout": {"column": 13, "row": 0, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						// "labelWrapConfig": {"classes": {"wrapClassName": ["page-header-label-wrap"]}}
					}
				},
				{
					"operation": "insert",
					"name": "ProductCode",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Code",
						"layout": {"column": 0, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.CodeTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProductOwner",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Owner",
						"layout": {"column": 13, "row": 0, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProductURL",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "URL",
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.UrlTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProductIsArchive",
					"parentName": "ProductGeneralInfoBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "IsArchive",
						"layout": {"column": 0, "row": 2, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.IsArchiveTip"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProductGeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ProductFilesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.FilesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "PriceControlGroup",
					"parentName": "ProductGeneralInfoTab",
					"propertyName": "items",
					"index": 2,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.PriceGroupCaption"},
						"items": [],
						"controlConfig": {
							"collapsed": false
						},
						"markerValue": "GroupPrices"
					}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "ProductFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ProductPriceBlock",
					"parentName": "PriceControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
// Columns and details
				{
					"operation": "insert",
					"name": "Price",
					"parentName": "ProductPriceBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Price",
						"layout": {"column": 0, "row": 0, "colSpan": 11},
						"primaryAmount": "PrimaryPrice",
						"currency": "Currency",
						"rate": "CurrencyRate",
						"primaryAmountEnabled": false,
						"rateEnabled": false,
						"generator": "MultiCurrencyEditViewGenerator.generate"
					}
				},
				{
					"operation": "insert",
					"name": "Tax",
					"parentName": "ProductPriceBlock",
					"propertyName": "items",
					"values": {
						"bindTo": "Tax",
						"layout": {"column": 13, "row": 0, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "ProductFilesTab",
					"propertyName": "items",
					"index": 0,
					"name": "Files",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToNotes"
							},
							"images": {
								"bindTo": "NotesImagesCollection"
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
