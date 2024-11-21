define("EventProductPageV2",
		function() {
			return {
				entitySchemaName: "EventProduct",
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				methods: {
					/**
					 * Handler for save event product button click event.
					 * @protected
					 */
					saveEventProduct: function() {
						var initialArgs = arguments;
						this.asyncValidate(function(resultObject) {
							if (!resultObject.success) {
								this.showInformationDialog(resultObject.message);
							} else {
								var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
									rootSchemaName: "EventProduct"
								});
								select.addColumn("Id");
								select.filters.add("EventIdFilter", select.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL, "Event", this.get("Event").value));
								select.filters.add("ProductIdFilter", select.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL, "Product", this.get("Product").value));
								select.getEntityCollection(function(result) {
									var collection = result.collection;
									if (collection && collection.collection.length > 0 && this.isNew) {
										//TODO: add localizable string
										this.showInformationDialog(this.get("Resources.Strings.WarningWrongProduct"));
									} else {
										this.save(initialArgs);
									}
								}, this);
							}
						}, this);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "Tabs",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.TAB_PANEL,
							"activeTabChange": {"bindTo": "activeTabChange"},
							"activeTabName": {"bindTo": "ActiveTabName"},
							"classes": {"wrapClass": ["tab-panel-margin-bottom"]},
							"tabs": [],
							"visible": false
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Event",
						"values": {
							"bindTo": "Event",
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"controlConfig": {
								"enabled": false
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Product",
						"values": {
							"bindTo": "Product",
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
						"name": "Note",
						"values": {
							"contentType": BPMSoft.ContentType.LONG_TEXT,
							"bindTo": "Note",
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24,
								"rowSpan": 2
							}
						}
					},
					{
						"operation": "merge",
						"name": "SaveButton",
						"values": {
							"click": "$saveEventProduct"
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
