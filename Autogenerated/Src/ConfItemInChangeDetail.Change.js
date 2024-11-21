define("ConfItemInChangeDetail", ["ConfItemInChangeDetailResources"],
	function(resourses) {
		return {
			entitySchemaName: "ChangeConfItem",
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
				 * Returns an element of combobox list of functional button which is responsible for SRM.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.BaseViewModel} An element of combobox list of functional button.
				 */
				getOpenServiceModelMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: resourses.localizableStrings.OpenServiceModelModuleCaption,
						Click: {"bindTo": "openServiceModelModule"},
						Enabled: {"bindTo": "getOpenServiceModelButtonEnabled"}
					});
				},

				/**
				 * Returns the availability of "Show dependencies" button.
				 * @return {Boolean}
				 */
				getOpenServiceModelButtonEnabled: function() {
					var selectedItems = this.getSelectedItems();
					return selectedItems && (selectedItems.length === 1);
				},

				/**
				 * "Show dependencies" action event handler.
				 * Open page of SRM by pressing the button "Show dependencies".
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
				},
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * Initialize detail config.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "ConfItem";
					config.lookupConfig.hideActions = true;
					config.sectionEntitySchema = "Change";
				},
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "ConfItem";
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
