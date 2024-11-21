define("ConfItemCaseDetail", ["ConfItemCaseDetailResources"],
	function(resources) {
		return {
			entitySchemaName: "ConfItemInCase",
			attributes: {},
			messages: {
				/**
				 * @message UpdateConfItemOnPage
				 * Update current configuration item on page.
				 * @param {Object} config menu
				 */
				"UpdateConfItemOnPage": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseManyToManyGridDetail#initConfig
				 * @overridden
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "ConfItem";
					config.sectionEntitySchema = "Case";
					config.lookupConfig.multiselect = true;
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#init
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
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					toolsButtonMenu.addItem(this.getSetMajorMenuItem());
				},

				/**
				 * Returns item of tools button, which set major configuration item.
				 * @protected
				 * @virtual
				 * @return {BPMSoft.BaseViewModel} Item of tools button, which set major configuration item.
				 */
				getSetMajorMenuItem: function() {
					return this.getButtonMenuItem({
						Caption: {"bindTo": "getMajorButtonCaption"},
						Click: {"bindTo": "changeMajorProperty"},
						Enabled: {"bindTo": "getChangeMajorPropertyButtonEnabled"}
					});
				},

				/**
				 * Returns change major button caption.
				 * @return {String}
				 */
				getMajorButtonCaption: function() {
					return resources.localizableStrings.AddTagMajorCaption;
				},

				/**
				 * On click change major button handler.
				 * Changes main property in active row.
				 */
				changeMajorProperty: function() {
					var activeRow = this.getActiveRow();
					if (!activeRow) {
						return;
					}
					var major = activeRow.get("Major");
					activeRow.set("Major", !major);
					this.sandbox.publish("UpdateConfItemOnPage", major ? null : activeRow.get("ConfItem"));
				},

				/**
				 * Returns change major button enabled.
				 * @return {Boolean}
				 */
				getChangeMajorPropertyButtonEnabled: function() {
					var selectedItems = this.getSelectedItems();
					return selectedItems && (selectedItems.length === 1);
				}
			}
		};
	});
