define("AttributeListItemPageV2", [],
	function() {
		return {
			entitySchemaName: "SiteEventAttrListItem",
			methods: {
				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######.
				 *  ####### ##### ######## # ####### ######!
				 * @returns {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########.
				 */
				getActions: function() {
					var parentActions = this.callParent(arguments);
					if (parentActions && !this.getSchemaAdministratedByRecords()) {
						parentActions.clear();
					}
					return parentActions;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "SiteEventAttribute",
					"values": {
						"bindTo": "SiteEventAttribute",
						"layout": {"column": 0, "row": 0, "colSpan": 18},
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
					"name": "Name",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NameCaption"},
						"layout": {"column": 0, "row": 1, "colSpan": 18},
						"bindTo": "Name"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
