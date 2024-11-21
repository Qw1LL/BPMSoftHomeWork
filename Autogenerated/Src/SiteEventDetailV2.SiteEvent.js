define("SiteEventDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "SiteEvent",
			attributes: {},
			methods: {
				/**
				 * Initialize page detail.
				 * @protected
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.set("MultiSelect", false);
				},

				/**
				 * Initialize detail property. Set detail collapsed by default.
				 * @protected
				 * @overridden
				 */
				initDetailOptions: function() {
					this.callParent();
					this.set("IsDetailCollapsed", true);
				},

				/**
				 * Open site event card.
				 * @protected
				 * @overridden
				 */
				openSiteEventCard: function() {
					var activeRow = this.getActiveRow();
					if (activeRow) {
						var primaryColumnValue = activeRow.get(activeRow.primaryColumnName);
						var typeColumnValue = this.getTypeColumnValue(activeRow);
						var editPages = this.get("EditPages");
						var editPage = editPages.get(typeColumnValue);
						var schemaName = editPage.get("SchemaName");
						var token = "CardModuleV2/" + schemaName + "/edit/" + primaryColumnValue;
						this.sandbox.publish("PushHistoryState", {hash: token});
					}
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "OpenButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.OpenButtonCaption"},
						"click": {"bindTo": "openSiteEventCard"},
						"visible": {"bindTo": "getEditRecordButtonEnabled"},
						"enabled": {"bindTo": "getEditRecordButtonEnabled"}
					},
					"index": 0
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "ToolsButton",
					"parentName": "Detail",
					"propertyName": "menu",
					"values": {
						"visible": false
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
