define("ClientAddressAddPageV2", ["ConfigurationConstants", "BusinessRuleModule", "css!OrderPageV2Styles",
		"LookupQuickAddMixin"], function(ConfigurationConstants, BusinessRuleModule) {
	return {
		entitySchemaName: "VwClientAddress",
		mixins: {
			LookupQuickAddMixin: "BPMSoft.LookupQuickAddMixin"
		},
		messages: {
			/**
			 * @message GetClientInfo
			 * Used for get information abount client.
			 * @param {Object} Information abount client.
			 */
			"GetClientInfo": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CloseAddressPage
			 * Used for closing current page.
			 */
			"CloseAddressPage": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			/**
			 * Closes current page.
			 */
			close: function() {
				this.sandbox.publish("CloseAddressPage", null, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#showBodyMask
			 * @overridden
			 */
			showBodyMask: function() {
				this.set("PageMaskVisible", true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#hideBodyMask
			 * @overridden
			 */
			hideBodyMask: function() {
				this.set("PageMaskVisible", false);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				var orderInfo = this.sandbox.publish("GetClientInfo", null, [this.sandbox.id]);
				this.set("ClientInfo", orderInfo || {});
				this.set("Id", this.BPMSoft.generateGUID());
			},

			/**
			 * Returns true if save button need to be active otherwise false.
			 * @return {Boolean}
			 */
			getIsSaveButtonEnabled: function() {
				var isAnyValueSet = false;
				var columnsToCheck = ["Country", "Region", "City", "Zip", "Address"];
				this.BPMSoft.each(columnsToCheck, function(columnName) {
					var value = this.get(columnName);
					if (value) {
						if (value.value) {
							value = value.value;
						}
						value = String.prototype.trim.call(value);
					}
					isAnyValueSet = !this.Ext.isEmpty(value);
					if (isAnyValueSet) {
						return false;
					}
				}, this);
				return isAnyValueSet;
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getSaveQuery
			 * @overridden
			 */
			getSaveQuery: function() {
				var orderInfo = this.get("ClientInfo");
				var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
				var deliveryAddressType = ConfigurationConstants.AddressTypes.Delivery;
				var savedAddresses = [];
				if (orderInfo.ContactId) {
					savedAddresses.push(this.get("Id"));
					var contactInsert = this.callParent(arguments);
					contactInsert.rootSchema = null;
					contactInsert.rootSchemaName = "ContactAddress";
					contactInsert.columnValues.setParameterValue("Contact", {value: orderInfo.ContactId},
						this.BPMSoft.DataValueType.LOOKUP);
					contactInsert.columnValues.setParameterValue("AddressType",
						deliveryAddressType,
						this.BPMSoft.DataValueType.LOOKUP);
					batchQuery.add(contactInsert);
				}
				if (orderInfo.AccountId) {
					var accountAddressId = this.BPMSoft.generateGUID();
					this.set("Id", accountAddressId);
					savedAddresses.push(accountAddressId);
					this.insertQuery = null;//this.insertQuery was cashed in base class in getInsertQuery method.
					var accountInsert = this.callParent(arguments);
					accountInsert.rootSchema = null;
					accountInsert.rootSchemaName = "AccountAddress";
					accountInsert.columnValues.setParameterValue("Account", {value: orderInfo.AccountId},
						this.BPMSoft.DataValueType.LOOKUP);
					accountInsert.columnValues.setParameterValue("AddressType",
						deliveryAddressType,
						this.BPMSoft.DataValueType.LOOKUP);
					batchQuery.add(accountInsert);
				}
				this.set("SavedAddresses", savedAddresses);
				return batchQuery;
			},

			/**
			 * Saves address.
			 * @protected
			 * @param {Object} [config] Parameters.
			 * @param {Function} [config.callback] Callback function.
			 * @param {Object} [config.scope] Callback scope.
			 */
			save: function(config) {
				this.showBodyMask();
				this.saveEntity(function() {
					this.hideBodyMask();
					config = config || {};
					this.sandbox.publish("CloseAddressPage", {addressIds: this.get("SavedAddresses")}, [this.sandbox.id]);
					this.Ext.callback(config.callback, config.scope || this);
				}, this);
			},

			/**
			 * Used by businness rules applier.
			 * @deprecated
			 * @private
			 * @return {Boolean}
			 */
			isCopyMode: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#getLookupQuery
			 * @overridden
			 */
			getLookupQuery: function(filterValue, columnName) {
				var esq = this.callParent(arguments);
				var filterGroup = this.getLookupQueryFilters(columnName);
				esq.filters.addItem(filterGroup);
				return esq;
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "PopUpCardContentWrapper",
				"values": {
					"id": "PopUpCardContentWrapper",
					"selectors": {"wrapEl": "#PopUpCardContentWrapper"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["card-content-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PopUpCardContentContainer",
				"parentName": "PopUpCardContentWrapper",
				"propertyName": "items",
				"values": {
					"id": "PopUpCardContentContainer",
					"selectors": {"wrapEl": "#PopUpCardContentContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["center-main-container"],
					"items": [],
					"markerValue": "CenterMainContainer"
				}
			},
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"parentName": "PopUpCardContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-container-margin-bottom"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Header",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Country",
				"values": {
					"bindTo": "Country",
					"layout": {"column": 0, "row": 0, "colSpan": 23},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"autocomplete": "no-address"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Region",
				"values": {
					"bindTo": "Region",
					"layout": {"column": 0, "row": 1, "colSpan": 23},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"autocomplete": "no-address"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "City",
				"values": {
					"bindTo": "City",
					"layout": {"column": 0, "row": 2, "colSpan": 23},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"autocomplete": "no-address"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Zip",
				"values": {
					"bindTo": "Zip",
					"layout": {"column": 0, "row": 3, "colSpan": 23},
					"controlConfig": {
						"autocomplete": "no-address"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Address",
				"values": {
					"bindTo": "Address",
					"layout": {"column": 0, "row": 4, "colSpan": 23},
					"controlConfig": {
						"autocomplete": "no-address"
					}
				}
			},
			{
				"operation": "insert",
				"name": "ButtonsContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"wrapClass": ["buttons-container"],
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PopupSaveButton",
				"parentName": "ButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "save"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"enabled": {"bindTo": "getIsSaveButtonEnabled"},
					"tag": "save",
					"markerValue": "SaveButton"
				}
			},
			{
				"operation": "insert",
				"name": "PopupCloseButton",
				"parentName": "ButtonsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "close"},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"tag": "close",
					"markerValue": "CloseButton"
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {
			"Region": {
				"FiltrationRegionByCountry": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Country",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Country"
				}
			},
			"City": {
				"FiltrationCityByCountry": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Country",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Country"
				},
				"FiltrationCityByRegion": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Region",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Region"
				}
			}
		}
	};
});
