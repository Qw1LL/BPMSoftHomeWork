define("BaseOpportunityContactPage", [], function() {
	return {
		entitySchemaName: "OpportunityContact",
		attributes: {
			"ContactLoyality": {
				lookupListConfig: {
					orders: [{columnPath: "Position"}]
				}
			},
			"Opportunity": {
				lookupListConfig: {
					columns: ["Account"]
				}
			},
			"Contact": {
				lookupListConfig: {
					filter: function() {
						var opportunity = this.get("Opportunity");
						if (opportunity && opportunity.Account) {
							return this.getFilterByRelationColumn(opportunity.Account);
						}
					}
				}
			}
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#getUpdateDetailOnSavedConfig
			 * @overridden
			 */
			getUpdateDetailOnSavedConfig: function() {
				var updateConfig = {};
				if (this.get("IsMainContact")) {
					updateConfig.reloadAll = true;
				} else {
					updateConfig.primaryColumnValue = this.get(this.primaryColumnName);
				}
				return updateConfig;
			},

			/**
			 * Gets filter by relation column.
			 * @private
			 * @param {Object} column Column-lookup.
			 * @return {Object}
			 */
			getFilterByRelationColumn: function(column) {
				if (column) {
					return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL, "Account",
						column.value);
				}
				return null;
			}
		},
		details: /**SCHEMA_DETAILS*/{
			OppContactMotivator: {
				schemaName: "OppContactMotivatorsDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "OpportunityContact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Opportunity",
				"values": {
					"bindTo": "Opportunity",
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"enabled": false,
					"controlConfig": {
						"enableRightIcon": false
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Contact",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 11}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "IsMainContact",
				"values": {
					"layout": {"column": 0, "row": 4, "colSpan": 6}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Role",
				"values": {
					"layout": {"column": 13, "row": 1, "colSpan": 11},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Influence",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 11},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "ContactLoyality",
				"values": {
					"layout": {"column": 13, "row": 2, "colSpan": 11},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Description",
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 24},
					"contentType": BPMSoft.ContentType.LONG_TEXT
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"name": "OppContactMotivator",
				"values": {
					itemType: BPMSoft.ViewItemType.DETAIL,
					"layout": {"column": 0, "row": 6, "colSpan": 24}
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
		]/**SCHEMA_DIFF*/
	};
});
