define("EventTeamPageV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "EventTeam",
			// TODO: ###### #### ###### # ########## ######## isRequired, ####### # ######### ##### ### #########
			attributes: {
				"Campaign": {dataValueType: BPMSoft.DataValueType.LOOKUP, isRequired: false}
			},
			// TODO: #### ## ########## # ####### ###### ########## ##### userCode, ##### ########## ####### ######
			userCode: {
				viewModel: function(viewModel) {
					delete viewModel.columns.Campaign;
				}
			},
			methods: {
				setContact: function() {
					if (this.get("Contact")) {
						this.set("Contact", undefined);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Tabs",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						itemType: BPMSoft.ViewItemType.TAB_PANEL,
						activeTabChange: {bindTo: "activeTabChange"},
						activeTabName: {bindTo: "ActiveTabName"},
						classes: {wrapClass: ["tab-panel-margin-bottom"]},
						tabs: [],
						visible: false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "TeamParticipant",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						},
						"bindTo": "Event",
						controlConfig: {
							enabled: false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"bindTo": "Contact",
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Account",
					"values": {
						"bindTo": "Account",
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
					"name": "Role",
					"values": {
						"bindTo": "Role",
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11
						},
						"contentType": "BPMSoft.ContentType.ENUM"
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Notes",
					"values": {
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"bindTo": "Notes",
						"layout": {
							"column": 0,
							"row": 5,
							"rowSpan": 1,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "merge",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"name": "actions",
					"values": {
						itemType: BPMSoft.ViewItemType.BUTTON,
						visible: false
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Contact": {
					"FiltrationContactByAccount": {
						"ruleType": 1,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": 3,
						"type": 1,
						"attribute": "Account"
					}
				}
			}
		};
	});
