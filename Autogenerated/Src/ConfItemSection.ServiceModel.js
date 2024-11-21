define("ConfItemSection", ["ItemSectionGridRowViewModel", "GridUtilitiesV2", "css!AdditionalCssModule"],
	function() {
		return {
			entitySchemaName: "ConfItem",
			contextHelpId: "1061",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "DataGridActiveRowOpenServiceModelModuleAction",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "getOpenServiceModelPageCaption"},
						"tag": "openServiceModelPage"
					}
				}
			]/**SCHEMA_DIFF*/,
			messages: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelClassName
				 * @overridden
				 */
				getGridRowViewModelClassName: function() {
					return "BPMSoft.ItemSectionGridRowViewModel";
				},
				/**
				 * ########## ####### ## ######## "########## ###########".
				 * ### ####### ## ###### "########## ###########" ########### ######## ########### ###.
				 */
				openServiceModelModule: function() {
					var activeRow = this.getActiveRow();
					var defaultValues = [{
						"id": activeRow.values.Id,
						"schemaName": activeRow.entitySchema.name,
						"name": activeRow.values.Name
					}];
					this.openCardInChain({
						"schemaName": "ServiceModelPage",
						"moduleId": this.sandbox.id + "_ServiceModelPage",
						"isSeparateMode": false,
						"defaultValues": defaultValues
					});
				},
				/**
				 * ########## ####### ###### # ####### #######.
				 * ### ####### ## ###### "########## ###########" ########### ######## ########### ###.
				 * @overridden
				 */
				onActiveRowAction: function(tag) {
					if (tag === "openServiceModelPage") {
						this.openServiceModelModule();
					} else {
						this.callParent(arguments);
					}
				}
			}
		};
	});
