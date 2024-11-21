define("BaseSysUserInRoleDetailV2", [
		"BPMSoft", "ConfigurationConstants", "ConfigurationEnums",
		"PortalRoleFilterUtilities"
	],
	function(BPMSoft, ConfigurationConstants, enums, PortalRoleFilterUtilities) {
		return {
			entitySchemaName: "SysUserInRole",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"rowDataItemMarkerColumnName": "SysRole"
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * Validates service response.
				 * @protected
				 * @virtual
				 * @param {Object} AdministrationService response.
				 */
				validateResponse: function(response) {
					var isSuccess = response && response.success;
					if (!isSuccess) {
						this.hideBodyMask();
						var errorMessage = response.message;
						if (errorMessage) {
							this.showInformationDialog(errorMessage);
						}
					}
					return isSuccess;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.Ext.create("BPMSoft.FilterGroup");
					filters = this.callParent(arguments);
					return filters;
				},

				/**
				 * Returns lookupPage config.
				 * @private
				 * @return {Object} config ### lookupPage.
				 */
				getLookupPageConfig: function() {
					var filters = this.BPMSoft.createFilterGroup();
					filters.addItem(this.getRoleLookupFilter());
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						columns: ["Name"],
						filters: filters,
						hideActions: true
					};
					return config;
				},

				/**
				 * Returns roles type list.
				 * @private
				 * @return {Array} Roles type list.
				 */
				getSysAdminUnitTypeList: function() {
					return [];
				},

				/**
				 * Forms roles view filters.
				 * @private
				 * @return {BPMSoft.data.filters.FilterGroup} Returns filters group.
				 */
				getRoleLookupFilter: function() {
					var filters = this.BPMSoft.createFilterGroup();
					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
						"[SysUserInRole:SysRole:Id].Id");
					var subFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"SysUser",
						this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					var roles = this.getSysAdminUnitTypeList();
					filters.addItem(PortalRoleFilterUtilities.getSysAdminUnitFilterGroup(roles));
					return filters;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecord
				 * @overridden
				 */
				addRecord: function() {
					var cardState = this.sandbox.publish("GetCardState", null, [this.sandbox.id]);
					var isNew = (cardState.state === enums.CardStateV2.ADD ||
						cardState.state === enums.CardStateV2.COPY);
					if (isNew) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					var config = this.getLookupPageConfig();
					this.openLookup(config, this.addCallback, this);
				},

				/**
				 * @inheritDoc GridUtilitiesV2#onDeleteAccept
				 * @overridden
				 */
				onDeleteAccept: function() {
					this.showBodyMask();
					this.callService({
						serviceName: "AdministrationService",
						methodName: this.getOnDeleteAcceptMethodName(),
						data: {
							roleIds: "",
							userIds: "",
							recordIds: this.Ext.encode(this.getSelectedItems())
						}
					}, function(response) {
						var result = this.Ext.decode(response[this.getOnDeleteAcceptMethodName() + "Result"]);
						var success = result.Success;
						var deletedItems = result.DeletedItems;
						this.removeGridRecords(deletedItems);
						this.hideBodyMask();
						if (!success) {
							this.showDeleteExceptionMessage(result);
						}
						this.onDeleted(result);
					}, this);
				},

				/**
				 * Returns delete user in role method name
				 * @protected
				 * @return {String} Method name.
				 */
				getOnDeleteAcceptMethodName: function() {
					return "RemoveUsersInRoles";
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#onCardSaved
				 * @overridden
				 */
				onCardSaved: function() {
					var config = this.getLookupPageConfig();
					this.openLookup(config, this.addCallback, this);
				},

				/**
				 * After users lookup windows closed callback function.
				 * @virtual
				 * @param {Object} args Object which contains selected records.
				 */
				addCallback: function(args) {
					var dataSend = {
						roleIds: this.Ext.encode(args.selectedRows.getKeys()),
						userId: this.get("MasterRecordId")
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getAddCallbackMethodName(),
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, function(response) {
						response.message = response[this.getAddCallbackMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.hideBodyMask();
							this.reloadGridData();
						}
					}, this);
				},

				/**
				 * Returns add user in role method name
				 * @protected
				 * @return {String} Method name.
				 */
				getAddCallbackMethodName: function() {
					return "AddUserRoles";
				}
			}
		};
	});
