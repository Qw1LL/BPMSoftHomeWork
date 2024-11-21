define("AccountBillingInfoPageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "AccountBillingInfo",
			attributes: {
				"Country": {
					lookupListConfig: {
						columns: ["Name", "BillingInfo"]
					}
				},
				"BillingInfo": {
					name: "BillingInfo",
					dataValueType: BPMSoft.DataValueType.TEXT,
					dependencies: [
						{
							columns: ["Country"],
							methodName: "CountryOnChange"
						}
					]
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * ### ######## ########## ############# ######### "########### ####".
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.isNewMode()) {
						var account = this.get("Account");
						this.set("LegalUnit", account && account.displayValue);
					}
				},

				/*
				* ### ######### ###### ########## ########## #### # ######## # ######### ##########
				* #### #### "######### #########" ## ######, ##### ######### #########.
				* */
				CountryOnChange: function() {
					var buttonsConfig = {
						buttons: [this.BPMSoft.MessageBoxButtons.YES.returnCode,
							this.BPMSoft.MessageBoxButtons.NO.returnCode],
						defaultButton: 0
					};
					var billingInfo = this.get("BillingInfo");
					var country = this.get("Country");
					if (!this.Ext.isEmpty(country)) {
						if (billingInfo) {
							this.showInformationDialog(this.get("Resources.Strings.CountryIsChange"),
								this.CountryIsChangeDialogCallback, buttonsConfig);
						} else {
							this.set("BillingInfo", country.BillingInfo);
						}
					}
				},

				/*
				* ############# ######### # ###### ############### ###### # ########## ####
				* */
				CountryIsChangeDialogCallback: function(returnCode) {
					if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
						var country = this.get("Country");
						this.set("BillingInfo", country.BillingInfo);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "Account",
						"bindTo": "Account",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						},
						enabled: false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "BillingInfo",
						"bindTo": "BillingInfo",
						"layout": {
							"column": 13,
							"colSpan": 11,
							"row": 0,
							"rowSpan": 5
						},
						controlConfig: {
							"height": "160px"
						},
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "Name",
						"bindTo": "Name",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "AccountManager",
						"bindTo": "AccountManager",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "ChiefAccountant",
						"bindTo": "ChiefAccountant",
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "Country",
						"bindTo": "Country",
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "LegalUnit",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 5, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"name": "Description",
						"bindTo": "Description",
						"layout": {"column": 0, "row": 6, "colSpan": 24},
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "merge",
					"name": "Tabs",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						"visible": false
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"AccountManager": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "[ContactCareer:Contact].Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				},
				"ChiefAccountant": {
					"FiltrationContactByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "[ContactCareer:Contact].Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			},
			userCode: {}
		};
	}
);
