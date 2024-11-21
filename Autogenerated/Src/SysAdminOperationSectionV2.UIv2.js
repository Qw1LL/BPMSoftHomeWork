define("SysAdminOperationSectionV2",
	["SysAdminOperationSectionV2Resources"],
	function() {
		return {
			entitySchemaName: "SysAdminOperation",
			attributes: {
				/**
				* ######## ########, ###### ## ####### ###### #### # ############ ### ############# ########
				*/
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanManageAdministration"
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "SeparateModeActionsButton"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.set("UseTagModule", false);
					this.set("UseStaticFolders", true);
					this.set("TagButtonVisible", false);
				},

				/**
				 * @inheritdoc BaseSectionV2#addSectionDesignerViewOptions
				 * @overridden
				 */
				addSectionDesignerViewOptions: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseSectionV2#getViewOptions
				 * @overridden
				 */
				getViewOptions: function() {
					var viewOptions = this.callParent(arguments);
					var openGridSettingIndex;
					viewOptions.each(function(item, index) {
						if (item.values.Click && item.values.Click.bindTo === "openGridSettings") {
							openGridSettingIndex = index;
						}
					});
					if (openGridSettingIndex) {
						viewOptions.removeByIndex(openGridSettingIndex);
					}
					return viewOptions;
				},

				/**
				 * ########## ### ######## ####### "###### # #########".
				 * @inheritDoc BPMSoft.BaseSectionV2#getEditPageSchemaName
				 * @overridden
				 */
				getEditPageSchemaName: function() {
					return "SysAdminOperationPageV2";
				},

				/**
				 * ########## ##### ######### ####### "###### # #########".
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultGridDataViewCaption
				 * @overridden
				 */
				getDefaultGridDataViewCaption: function() {
					return this.get("Resources.Strings.OperationSectionHeader");
				},

				/**
				 * ########## ############# #######,
				 * ### ###### ## ############# #########.
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var view = this.callParent(arguments);
					delete view.AnalyticsDataView;
					return view;
				},

				/**
				 * ######### ######## ########## ######
				 * @inheritdoc BaseSectionV2#addRecord
				 * @overridden
				 */
				addRecord: function(typeColumnValue) {
					this.checkCanChangeGrantee(this.callParent(typeColumnValue), null);
				},

				/**
				 * ######## #######.
				 * @inheritdoc GridUtilitiesV2#deleteRecords
				 * @overridden
				 */
				deleteRecords: function() {
					var items = this.getSelectedItems();
					if (items && items.length > 0) {
						this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
							function(result) {
								if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.showBodyMask();
									this.deleteOperations(items);
								}
							}, [this.BPMSoft.MessageBoxButtons.YES.returnCode,
								this.BPMSoft.MessageBoxButtons.NO.returnCode], null);
					}
				},

				/**
				 * ####### ######## # ##.
				 * @param {Array} itemIds ###### ############### ########.
				 * @private
				 */
				deleteOperations: function(itemIds) {
					var config = {
						"serviceName": "RightsService",
						"methodName": "DeleteAdminOperation",
						"data": {
							"recordIds": itemIds
						}
					};
					this.callService(config, function(response) {
						if (response && response.DeleteAdminOperationResult) {
							var result = this.Ext.decode(response.DeleteAdminOperationResult);
							if (result && !this.Ext.isEmpty(result)) {
								this.hideBodyMask();
								if (result.Success) {
									this.onDeleteComplete(itemIds);
								} else {
									this.showInformationDialog(result.ExMessage);
								}
							}
						}
					}, this);
				},

				/**
				* ####### ###### ## #######.
				* ########### ##### ######## ####### ## ##.
				* @param {Array} itemIds ###### ############### ########.
				* @private
				*/
				onDeleteComplete: function(itemIds) {
					var gridData = this.getGridData();
					BPMSoft.each(itemIds, function(itemIds) {
						gridData.removeByKey(itemIds);
					});
				},

				/**
				 * #########, ### ######## ############,
				 * ########### ######### #### ####### # ########.
				 * @param {Function} callbackAllow ####### ######### ######.
				 * ###########, #### ########### ######### #### #########.
				 * @param {Function} callbackDenied ####### ######### ######.
				 * ###########, #### ########### ######### #### #########.
				 * @private
				 */
				checkCanChangeGrantee: function(callbackAllow, callbackDenied) {
					var config = {
						"serviceName": "RightsService",
						"methodName": "CheckCanChangeAdminOperationGrantee"
					};
					this.callService(config, function(response) {
						if (response && response.CheckCanChangeAdminOperationGranteeResult) {
							var result = this.Ext.decode(response.CheckCanChangeAdminOperationGranteeResult);
							if (result && !this.Ext.isEmpty(result)) {
								if (result.Success) {
									if (this.Ext.isFunction(callbackAllow)) {
										callbackAllow.call(this);
									}
								} else {
									this.showInformationDialog(result.ExMessage, function() {
										if (this.Ext.isFunction(callbackDenied)) {
											callbackDenied.call(this);
										}
									});
								}
							}
						}
					}, this);
				}
			}
		};
	});
