define("CaseNextStatusLookupEditPage", ["ConfigurationGrid", "ConfigurationGridGenerator",
		"ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "CaseNextStatus",
			details: /**SCHEMA_DETAILS*/{
				"CaseRuleInStageInsert": {
					"schemaName": "CaseRuleInStageDetail",
					"entitySchemaName": "CaseRuleInStage",
					"filter": {
						"detailColumn": "CaseNextStatus",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			attributes: {
				"ChangeStatusColumns": {
					dependencies: [{
						columns: ["Status", "NextStatus"],
						methodName: "onColumnsChange"
					}]
				},
				"Status": {
					lookupListConfig: {
						hideActions: true
					}
				},
				"NextStatus": {
					lookupListConfig: {
						hideActions: true
					}
				}
			},
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
			methods: {
				/**
				 * Handles the change event of Default column.
				 * @private
				 */
				onColumnsChange: function() {
					var separator = this.get("Resources.Strings.Separator");
					var oldCaptionValue = this.get("Name");
					var oldStatusColumn = this.getPrevious("Status") ?
							this.getPrevious("Status").displayValue : "";
					var oldNextStatusColumnValue = this.getPrevious("NextStatus") ?
							this.getPrevious("NextStatus").displayValue : "";
					var oldColumnsValue = oldStatusColumn + separator + oldNextStatusColumnValue;
					var statusColumnValue = this.get("Status") ? this.get("Status").displayValue : "";
					var nextStatusColumnValue = this.get("NextStatus") ? this.get("NextStatus").displayValue : "";
					var captionValue = statusColumnValue + separator + nextStatusColumnValue;
					if (!oldCaptionValue || oldCaptionValue === oldColumnsValue) {
						this.set("Name", captionValue);
					}
				},
				/**
				 * @inheritdoc ConfigurationGridUtilitiesV2#validate
				 * @overriden
				 */
				validate: function() {
					var statusColumnValue = this.get("Status") ? this.get("Status").displayValue : "";
					var nextStatusColumnValue = this.get("NextStatus") ? this.get("NextStatus").displayValue : "";
					var result = statusColumnValue !== nextStatusColumnValue;
					if (!result) {
						this.BPMSoft.utils.showInformation(this.get("Resources.Strings.DuplicateMessage"));
					}
					return result;
				},

				/**
				 * Returns empty collection action cards.
				 * @override
				 * @return {BPMSoft.BaseViewModelCollection} Returns empty collection action cards.
				 */
				getActions: function() {
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					return actionMenuItems;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "CaseRuleInStageDetailTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CaseRuleInStageDetailCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "CaseRuleInStageDetailTab",
					"propertyName": "items",
					"name": "CaseRuleInStageInsert",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Name"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Status"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "NextStatus",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "NextStatus"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				}
			]/**SCHEMA_DIFF*/
		};
	});


