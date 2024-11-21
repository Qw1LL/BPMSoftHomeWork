define("ConfItemCaseDetail", ["ConfItemCaseDetailResources"],
	function(resourses) {
		return {
			entitySchemaName: "ConfItemInCase",
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					toolsButtonMenu.addItem(this.getOpenServiceModelMenuItem());
				},

				/**
				 * ########## ####### ########### ###### ############## ######, ########## ## ######## ###.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.BaseViewModel} ####### ########### ###### ############## ######, ## ######## ###.
				 */
				getOpenServiceModelMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: resourses.localizableStrings.OpenServiceModelModuleCaption,
						Click: {"bindTo": "openServiceModelModule"},
						Enabled: {"bindTo": "getOpenServiceModelButtonEnabled"}
					});
				},

				/**
				 * ########## ########### ###### "########## ###########".
				 * @return {Boolean}
				 */
				getOpenServiceModelButtonEnabled: function() {
					var selectedItems = this.getSelectedItems();
					return selectedItems && (selectedItems.length === 1);
				},

				/**
				 * ########## ####### ## ######## "########## ###########".
				 * ### ####### ## ###### "########## ###########" ########### ######## ########### ###.
				 */
				openServiceModelModule: function() {
					var activeRow = this.getActiveRow();
					if (!activeRow) {
						return;
					}
					var defaultValues = [{
						"id": activeRow.get("ConfItem").value,
						"schemaName": "ConfItem",
						"name": activeRow.get("ConfItem").displayValue
					}];
					var openCardConfig = {
						moduleId: this.sandbox.id + "_CardModule",
						schemaName: "ServiceModelPage",
						operation: "edit",
						isSeparateMode: false,
						defaultValues: defaultValues,
						id: activeRow.get("ConfItem").value
					};
					this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
				}
			}
		};
	});
