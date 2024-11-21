define("SysAdminUnitGrantedRightDetailV2", [],
	function() {
		return {
			entitySchemaName: "SysAdminUnitGrantedRight",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "GranteeSysAdminUnit"
					}
				},
				{
					"operation": "merge",
					"name": "AddRecordButton",				
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddButtonCaption"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"imageConfig": {"bindTo": "Resources.Images.AddButtonPlusImage"},
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "GetRightsButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "getRights"},
						"visible": {"bindTo": "getAddRecordButtonVisible"},
						"enabled": {"bindTo": "getAddRecordButtonEnabled"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.GetRightsButtonCaption"}
					},
					"index": 1
				},
				{
					"operation": "merge",
					"name": "ToolsButton",
					"index": 2,
					"values": {
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#onDeleted
				 * @overridden
				 */
				onDeleted: function() {
					this.callParent(arguments);
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * ######### ########## ######## #################.
				 * @protected
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 */
				openUsersLookup: function(isDelegate) {
					var config = this.prepareLookupConfig(isDelegate);
					this.openLookup(config, this.addCallback.bind(this, isDelegate), this);
				},

				/**
				 * ######## onInsertSysAdminUnitGrantedRightComplete.
				 * @virtual
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				addCallback: function(isDelegate, args) {
					this.onInsertSysAdminUnitGrantedRight(isDelegate, args, this.get("MasterRecordId"));
				},

				/**
				 * Callback-#######, ####### ########## ##### ########## ############.
				 * @protected
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				onInsertSysAdminUnitGrantedRight: function(isDelegate, args) {
					var selectedIds = args.selectedRows.getKeys();
					var dataSend = {
						masterRecordId: this.get("MasterRecordId"),
						selectedRecords: this.Ext.JSON.encode(selectedIds)
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: isDelegate
							? "AddSysAdminUnitGrantedRights"
							: "AddSysAdminUnitGrantedRightsFromSelectedRecords",
						data: dataSend
					};
					this.callService(config, function(response) {
						const errorMessage = Ext.isEmpty(response) ? "" : response[config.methodName + "Result"];
						if (!Ext.isEmpty(errorMessage)) {
							this.showInformationDialog(errorMessage);
							return;
						}
						this.onInsertCompleted();
					});
				},

				/**
				 * ######### #######, ###### ######### ########## ############ ####### # ######.
				 * @private
				 * @param {Boolean} isDelegate ####, ########### ########### ############# ####. #### true, ## #######
				 * ############ ########## ##### ########## ######### ## ###########. #### false, ## ########
				 * ############ ############ ##### ## ########## #########.
				 * @return {BPMSoft.FilterGroup} ########## ###### ########.
				 */
				getLookupFilter: function(isDelegate) {
					var filters = this.BPMSoft.createFilterGroup();
					var parentFilter =  this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						isDelegate ? "GrantorSysAdminUnit.Id" : "GranteeSysAdminUnit.Id",
						this.get("MasterRecordId"));
					var sameIdFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL,
						"Id",
						this.get("MasterRecordId"));

					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
						this.Ext.String.format("[SysAdminUnitGrantedRight:{0}:Id].Id", isDelegate
							? "GranteeSysAdminUnit"
							: "GrantorSysAdminUnit"));
					notExistsFilter.subFilters.addItem(parentFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(sameIdFilter);
					return filters;
				},

				/**
				 * ########## ########## ### ######## #### ###### ## #############.
				 * @return {Object} Config ######## #### ###### ## ###########.
				 */
				prepareLookupConfig: function() {
					var filters = this.getLookupFilter();
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						columns: ["Contact", "Name"],
						hideActions: true,
						filters: filters
					};
					return config;
				},

				/**
				 * ########## ####### ## ###### ############ #####.
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					this.openUsersLookup(true);
				},

				/**
				 * ########## ####### ## ###### ######## #####.
				 * @protected
				 */
				getRights: function() {
					this.openUsersLookup(false);
				},

				/**
				 * @inheritdoc BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return true;
				},

				/**
				 * ######## ########### ############# # ######.
				 * @private
				 */
				onInsertCompleted: function() {
					this.hideBodyMask();
					this.reloadGridData();
				},

                /**
                 * @overridden
                 * @return {String} ### #######.
                 */
                getFilterDefaultColumnName: function() {
                    return "GranteeSysAdminUnit";
                }
			}
		};
	});
