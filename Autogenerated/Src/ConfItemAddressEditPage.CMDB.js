define("ConfItemAddressEditPage", ["BusinessRuleModule", "ConfItemAddressEditPageResources"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "ConfItemAddress",
			attributes: {
				"Address": {
					dependencies: [
						{
							columns: [
								"Country", "Region", "City", "Street"
							],
							methodName: "fillAddress"
						}
					]
				}
			},
			rules: {
				"Region": {
					"FilteringRegionByCountry": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						autocomplete: true,
						baseAttributePatch: "Country",
						comparisonType: this.BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: "Country",
						attributePath: "",
						value: ""
					}
				},
				"City": {
					"FilteringCityByCountry": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						autocomplete: true,
						"autoClean": true,
						baseAttributePatch: "Country",
						comparisonType: this.BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: "Country",
						attributePath: "",
						value: ""
					},
					"FiltrationCityByRegion": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Region",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Region"
					}
				}
			},
			messages: {
				/**
				 * @message UpdateConfItemPage
				 * ######### ######## ##.
				 */
				"UpdateConfItemPage": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				_getFormattedValue: function(value, prefix) {
					return this.Ext.String.format(this.get("Resources.Strings.AddressFormat"), value, prefix);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.set("Current", true);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					if (this.get("CallParentOnSaved")) {
						this.set("CallParentOnSaved", false);
						this.callParent(arguments);
						return;
					}

					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "ConfItemAddress"
					});
					var confItem = this.get("ConfItem");
					var masterRecordId = this.get("Id");
					update.filters.add("IdFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "ConfItem", confItem.value));
					update.filters.add("CurrentRecord", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", masterRecordId));
					update.setParameterValue("Current", 0, this.BPMSoft.DataValueType.BOOLEAN);
					this.set("ParentOnSavedArguments", arguments);
					update.execute(function() {
						this.updateConfItemAddress();
					}, this);
				},

				/**
				 * ######### #### ###### ## ######## ##.
				 * @protected
				 */
				updateConfItemAddress: function() {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "ConfItem"
					});
					var confItem = this.get("ConfItem");
					update.filters.add("IdFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", confItem.value));

					var country = this.get("Country") ? this.get("Country").value : null;
					var region = this.get("Region") ? this.get("Region").value : null;
					var city = this.get("City") ? this.get("City").value : null;

					var street = this.get("Street") ? this.get("Street") : "";
					var address = this.get("Address") ? this.get("Address") : "";

					update.setParameterValue("Country", country, this.BPMSoft.DataValueType.GUID);
					update.setParameterValue("Region", region, this.BPMSoft.DataValueType.GUID);
					update.setParameterValue("City", city, this.BPMSoft.DataValueType.GUID);
					update.setParameterValue("Street", street, this.BPMSoft.DataValueType.TEXT);
					update.setParameterValue("Address", address, this.BPMSoft.DataValueType.TEXT);
					update.execute(function() {
						this.sandbox.publish("UpdateConfItemPage");
						this.set("CallParentOnSaved", true);
						this.onSaved.apply(this, this.get("ParentOnSavedArguments"));
					}, this);
				},

				/**
				 * ######## ###### #####.
				 * @protected
				 */
				fillAddress: function() {
					var country = this.get("Country") ? this.get("Country").displayValue : "";
					var region = this.get("Region") ? (", " + this.get("Region").displayValue) : "";
					var city = this.get("City") ? this._getFormattedValue(this.get("City").displayValue,
						this.get("Resources.Strings.ShortCityCaption")) : "";
					var street = this.get("Street") ? this._getFormattedValue(this.get("Street"),
						this.get("Resources.Strings.ShortStreetCaption")) : "";

					var result = country + region + city + street;
					if (result.startsWith(", ")) {
						result = result.substr(2);
					}
					this.set("Address", result);
				}
			},
			diff: [
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "insert",
					"name": "Country",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Country"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "StartDate"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Region",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Region"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "EndDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "EndDate"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "City",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "City"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Street",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Street"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Address",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Address"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				}
			]
		};
	});
