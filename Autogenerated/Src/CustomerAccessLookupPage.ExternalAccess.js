define("CustomerAccessLookupPage", ["CustomerAccessLookupPageResources", "ControlGridModule",
		"css!CustomerAccessLookupPageCSS", "css!LookupPageCSS", "css!BaseFontsCSS"],
	function(resources) {
		return {
			messages: {
				/**
				 * Hides module container and returns selected value.
				 * @message HideCustomerAccessLookupPageModule
				 */
				"HideCustomerAccessLookupPageModule": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * Gets customer access list.
				 * @message GetCustomerAccessLookupPageConfig
				 */
				"GetCustomerAccessLookupPageConfig": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Current selected value.
				 * @type {String}
				 */
				"SelectedValue": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					value: null
				},
				/**
				 * Id of the loading mask.
				 * @type {String}
				 */
				"MaskId": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				/**
				 * Collection of customer accesses.
				 * @type {BPMSoft.BaseViewModelCollection}
				 */
				"CustomerAccessCollection": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: null
				},
				/**
				 * Flag indicates that collection of customer accesses is empty.
				 * @type {Boolean}
				 */
				"IsCustomerAccessCollectionEmpty": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {
				/**
				 * @param {Object} values View model column values.
				 * @private
				 */
				_createCustomerAccessItemViewModel: function(values) {
					return this.Ext.create("BPMSoft.BaseViewModel", {
						columns: {
							"Id": {
								dataValueType: BPMSoft.DataValueType.GUID,
								type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
							},
							"Url": {
								dataValueType: BPMSoft.DataValueType.TEXT,
								type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
							},
							"Description": {
								dataValueType: BPMSoft.DataValueType.TEXT,
								type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
							},
							"ExpirationDate": {
								dataValueType: BPMSoft.DataValueType.TEXT,
								type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
							},
							"CustomerId": {
								dataValueType: BPMSoft.DataValueType.TEXT,
								type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
							}
						},
						values: values
					});
				},

				/**
				 * @param {Object} itemConfig Service response with customer access items array.
				 * @return {BPMSoft.BaseViewModel} view model item for list data grid.
				 * @private
				 */
				_createCustomerAccessItem: function(itemConfig) {
					const cultureName = BPMSoft.Resources.CultureSettings.currentCultureName;
					return this._createCustomerAccessItemViewModel({
						Id: itemConfig.accessId,
						Url: itemConfig.url,
						Description: itemConfig.description,
						ExpirationDate: BPMSoft.toLocaleDate(new Date(itemConfig.expirationDate), cultureName),
						CustomerId: itemConfig.customerId
					});
				},

				/**
				 * @private
				 */
				_getCustomerConfig: function() {
					const config = this.sandbox.publish("GetCustomerAccessLookupPageConfig", null, [this.sandbox.id]);
					const customerConfig = config.customerConfig || {};
					if (config.customerIds) {
						customerConfig.customerIds = config.customerIds;
					}
					return customerConfig;
				},

				/**
				 * @private
				 */
				_checkClientRegistration: function() {
					const customerConfig = this._getCustomerConfig();
					this.callService({
						serviceName: "TempAccessService",
						methodName: "IsAnyClientRegistered",
						data: {
							customerIds: customerConfig.customerIds,
							clientId: customerConfig.clientId
						}
					},
					this._processClientRegistrationCheckResponse, this);
				},

				/**
				 * @param {Object} responseObject Response of service.
				 * @param {Object} response Http response provided by ajax provider.
				 * @private
				 */
				_processClientRegistrationCheckResponse: function(responseObject, response) {
					if (this.$MaskId) {
						BPMSoft.Mask.hide(this.$MaskId);
					}
					if (BPMSoft.isEmpty(responseObject) || BPMSoft.isEmpty(responseObject.result)) {
						this.error(Ext.String.format("[{0}] {1}",
							response.status, response.responseText || response.statusText));
						BPMSoft.showErrorMessage(this.get("Resources.Strings.ClientsCheckErrorMessage"), function() {
							this.hideModule();
						}, this);
						return;
					}
					const responseResult = responseObject.result;
					if (responseResult === false) {
						BPMSoft.showInformation(this.get("Resources.Strings.NoClientsRegisteredMessage"),
								function() {
							this.hideModule();
						}, this);
						return;
					}
					this.$IsCustomerAccessCollectionEmpty = true;
				},

				/**
				 * @param {Array} customerAccesses Customer access list array.
				 * @private
				 */
				_fillCustomerAccessCollection: function(customerAccesses) {
					if (BPMSoft.isEmpty(customerAccesses)) {
						this._checkClientRegistration();
						return;
					}
					if (this.$MaskId) {
						BPMSoft.Mask.hide(this.$MaskId);
					}
					const collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(customerAccesses, function(elem) {
						const item = this._createCustomerAccessItem(elem);
						collection.add(item.$Id, item);
					}, this);
					this.$CustomerAccessCollection.loadAll(collection);
					if (!this.$SelectedValue) {
						this.$SelectedValue = customerAccesses[0].accessId;
					}
				},

				/**
				 * @param {Object} responseObject Response of service that provides customer access list.
				 * @param {Object} response Http response provided by ajax provider.
				 * @private
				 */
				_loadListServiceResponse: function(responseObject, response) {
					if (BPMSoft.isEmpty(responseObject) || !responseObject.result) {
						this.error(Ext.String.format("[{0}] {1}",
							response.status, response.responseText || response.statusText));
						BPMSoft.showErrorMessage(this.get("Resources.Strings.ServiceErrorMessage"), function() {
							this.hideModule();
						}, this);
						return;
					}
					const responseResult = responseObject.result || {};
					this._fillCustomerAccessCollection(responseResult);
				},

				/**
				 * Initializes list collection.
				 * @private
				 */
				_initCollection: function() {
					const collection = this.get("CustomerAccessCollection");
					if (this.isEmpty(collection)) {
						this.set("CustomerAccessCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					}
				},

				/**
				 * Requests actual config and refreshes customer access list.
				 * @private
				 */
				_refreshModuleInfo: function() {
					const config = this.sandbox.publish("GetCustomerAccessLookupPageConfig", null, [this.sandbox.id]);
					if (!config) {
						return;
					}
					if (config.operation === "refresh") {
						this._loadData(config);
					} else {
						throw new BPMSoft.NotImplementedException();
					}
				},

				/**
				 * @param {Object} config Config for querying customer access list.
				 * @private
				 */
				_loadData: function(config) {
					const customerConfig = config.customerConfig || {};
					if (config.customerIds) {
						customerConfig.customerIds = config.customerIds;
					}
					this.callService({
							serviceName: "TempAccessService",
							methodName: "GetTempAccessList",
							data: {
								customerIds: customerConfig.customerIds,
								clientId: customerConfig.clientId
							}
						},
						this._loadListServiceResponse, this);
				},

				/**
				 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this._initCollection();
					this._refreshModuleInfo();
					this.callParent(arguments);
				},

				/**
				 * Hides module container.
				 * @protected
				 */
				hideModule: function(arg1, arg2, arg3, tag) {
					if (this.$MaskId) {
						BPMSoft.Mask.hide(this.$MaskId);
					}
					const selectedValue = (tag === "select") ? this.$SelectedValue : null;
					const selectedAccessConfig =
						(selectedValue) ? this.$CustomerAccessCollection.get(selectedValue).values : null;
					if (selectedAccessConfig && !selectedAccessConfig.Url) {
						BPMSoft.showErrorMessage(this.get("Resources.Strings.ClientUriEmptyErrorMessage"));
						return;
					}
					this.sandbox.publish("HideCustomerAccessLookupPageModule", selectedAccessConfig, [this.sandbox.id]);
				},

				/**
				 * Handles double click on the grid.
				 * @protected
				 */
				onGridDoubleClick: function() {
					this.hideModule(null, null, null, "select");
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "CustomerAccessContainerWrapper",
					"values": {
						"id": "CustomerAccessContainerWrapper",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["customer-access-container-wrapper", "containerLookupPage",
							"container-lookup-page-fixed"],
						"markerValue": "customer-access-container",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CustomerAccessHeadContainer",
					"parentName": "CustomerAccessContainerWrapper",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CustomerAccessHeaderNameContainer",
					"parentName": "CustomerAccessHeadContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["header-name-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CustomerAccessCloseIconContainer",
					"parentName": "CustomerAccessHeadContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["close-icon-container", "header-name-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Title",
					"parentName": "CustomerAccessHeaderNameContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.Title"},
						"labelConfig": {
							"classes": ["customer-access-title"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CloseButton",
					"parentName": "CustomerAccessCloseIconContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": resources.localizableImages.CloseIcon,
						"classes": {"wrapperClass": ["close-btn-user-class"]},
						"selectors": {"wrapEl": "#headContainer"},
						"click": "$hideModule"
					}
				},
				{
					"operation": "insert",
					"name": "CustomerAccessButtonsContainer",
					"parentName": "CustomerAccessContainerWrapper",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["controlsContainerLookupPage"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SelectButton",
					"parentName": "CustomerAccessButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": resources.localizableStrings.SelectButtonCaption,
						"click": "$hideModule",
						"tag": "select",
						"enabled": "$SelectedValue",
						"classes": {"textClass": ["main-buttons"]},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "CustomerAccessButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": resources.localizableStrings.CancelButtonCaption,
						"click": "$hideModule",
						"classes": {"textClass": ["main-buttons"]}
					}
				},
				{
					"operation": "insert",
					"name": "CustomerAccessGridContainer",
					"parentName": "CustomerAccessContainerWrapper",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["customer-access-container", "containerLookupPage"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DataGrid",
					"parentName": "CustomerAccessGridContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID,
						"className": "BPMSoft.ControlGrid",
						"type": "listed",
						"columnsConfig": [
							{
								"cols": 8,
								"key": [
									{"name": {"bindTo": "Url"}}
								],
								"classes": ["col-url"]
							},
							{
								"cols": 12,
								"key": [
									{"name": {"bindTo": "Description"}}
								],
								"classes": ["col-description"]
							},
							{
								"cols": 4,
								"key": [
									{"name": {"bindTo": "ExpirationDate"}}
								],
								"classes": ["col-expiration-date"]
							}
						],
						"captionsConfig": [
							{
								"cols": 8,
								"name": resources.localizableStrings.ColumnCaptionUrl
							},
							{
								"cols": 12,
								"name": resources.localizableStrings.ColumnCaptionDescription
							},
							{
								"cols": 4,
								"name": resources.localizableStrings.ColumnCaptionExpirationDate
							}
						],
						"listedZebra": true,
						"collection": "$CustomerAccessCollection",
						"primaryColumnName": "Id",
						"activeRow": "$SelectedValue",
						"multiSelect": false,
						"openRecord": {"bindTo": "onGridDoubleClick"},
						"isEmpty": {"bindTo": "IsCustomerAccessCollectionEmpty"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
