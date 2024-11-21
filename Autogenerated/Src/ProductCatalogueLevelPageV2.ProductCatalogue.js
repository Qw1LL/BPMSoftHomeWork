// D9 Team
define("ProductCatalogueLevelPageV2", ["StructureExplorerUtilities", "css!ProductManagementDistributionConstants"],
	function(StructureExplorerUtilities) {
		return {
			entitySchemaName: "ProductCatalogueLevel",
			messages: {
				/**
				 * @message StructureExplorerInfo
				 * ########## ### ###### StructureExplorerUtilities
				 */
				"StructureExplorerInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ColumnSelected
				 * ########## ### ###### StructureExplorerUtilities
				 */
				"ColumnSelected": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				/**
				 * ######## #### StructureExplorer.
				 * @private
				 */
				openStructureExplorer: function() {
					var config = {
						useBackwards: false,
						firstColumnsOnly: true,
						summaryColumnsOnly: false,
						lookupsColumnsOnly: true,
						schemaName: "Product"
					};
					var handler = this.structureExplorerHandler;
					StructureExplorerUtilities.Open(this.sandbox,
						config, handler, this.renderTo, this);
				},

				/**
				 * ########## ###### StructureExplorer.
				 * ######### ######## viewModel ######## ###### # #### StructureExplorer.
				 * @param {Object} args ######## ######### ###### ############.
				 */
				structureExplorerHandler: function(args) {
					var columnCaption = args.leftExpressionCaption;
					var columnPath = args.leftExpressionColumnPath;
					var referenceSchemaName = args.referenceSchemaName;
					var oldColumnPath = this.get("ColumnPath");
					var oldColumnCaption = this.get("ColumnCaption");
					var oldName = this.get("Name");
					this.set("ColumnCaption", columnCaption);
					this.set("ColumnPath", columnPath);
					this.set("ReferenceSchemaName", referenceSchemaName);
					if ((oldName === oldColumnCaption || this.Ext.isEmpty(oldName)) &&
						columnPath !== oldColumnPath)
					{
						this.set("Name", columnCaption);
					}
				},

				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######.
				 *  ####### ##### ######## # ####### ######
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
// Tabs
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},
// Header
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ColumnCaption",
					"values": {
						"bindTo": "ColumnCaption",
						"layout": {"column": 0, "row": 1, "colSpan": 24},
						"classes": {"wrapClass": ["columnCaption-readonly-class"]},
						"controlConfig": {
							"className": "BPMSoft.TextEdit",
							"readonly": true,
							"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
							"rightIconClick": {"bindTo": "openStructureExplorer"}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
