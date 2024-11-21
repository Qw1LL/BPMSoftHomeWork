define("SysFuncRoleChiefInOrgRoleDetailV2", ["BPMSoft", "SysFuncRoleChiefInOrgRoleDetailV2Resources",
		"ConfigurationConstants", "ConfigurationEnums"],
	function(BPMSoft, resources, ConfigurationConstants, enums) {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/,
			methods: {
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * ########### ########## ###### ####### ## ####### ###. #### ############ ### ####### ####.
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#onDeleted
				 * @overridden
				 */
				onDeleted: function() {
					this.callParent(arguments);
				},

				getAddRecordButtonEnabled: function() {
					return this.get("IsChiefRoleExists");
				},

				/**
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 * @return {Object} ########## ###### ########-############ #######.
				 */
				getGridDataColumns: function() {
					var config = this.callParent(arguments);
					config["OrgRole.Id"] = {path: "OrgRole.Id"};
					config["OrgRole.Name"] = {path: "OrgRole.Name"};
					config["FuncRole.Name"] = {path: "FuncRole.Name"};
					return config;
				},

				/**
				 * @protected
				 * @inheritdoc GridUtilitiesV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					if (this.get("ChiefOrgRoleIdLoaded")) {
						this.callParent(arguments);
						this.set("ChiefOrgRoleIdLoaded", false);
						return;
					}
					this.getChiefOrgRoleId(this.loadGridData);
				},

				/**
				 * @protected
				 * @inheritdoc BaseGridDetailV2#getFilters
				 * @overridden
				 * @return {BPMSoft.FilterGroup} ###### ######## filters.
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = BPMSoft.deserialize(filters.serialize(serializationInfo));
					deserializedFilters.addItem(this.BPMSoft.createColumnInFilterWithParameters(
						"OrgRole.Id", [this.get("ChiefOrgRoleId")]));
					return deserializedFilters;
				},

				/**
				 * ######### ######, ####### ########## ############# ############### #### #############
				 * ### ######### ############### ####.
				 * @protected
				 * @param {Function} callback ####### ######### ######, ####### ########## ##### ####, ### ####### #############.
				 */
				getChiefOrgRoleId: function(callback) {
					var parentId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysAdminUnit"
					});
					esq.addColumn("Id");
					esq.filters.addItem(this.BPMSoft.createColumnInFilterWithParameters(
						"ParentRole.Id", [parentId]));
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue",
						ConfigurationConstants.SysAdminUnit.Type.Manager));

					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() > 0) {
								var chiefOrgRoleId = collection.getByIndex(0).get("Id");
								var defaultValue = {
									name: "OrgRole",
									value: chiefOrgRoleId
								};
								this.set("DefaultValues", [defaultValue]);
								this.set("ChiefOrgRoleId", chiefOrgRoleId);
								this.set("ChiefOrgRoleIdLoaded", true);
								if (this.Ext.isFunction(callback)) {
									callback.call(this);
								}
								this.set("IsChiefRoleExists", true);
							} else {
								this.set("IsChiefRoleExists", false);
								var gridData = this.getGridData();
								if (gridData.getCount() > 0) {
									gridData.clear();
								}
								this.set("LastRecord", null);
								this.set("IsGridEmpty", true);
							}
						}
					}, this);
				},

				/**
				 * @inheritdoc GridUtilitiesV2#createViewModel
				 * @overridden
				 */
				createViewModel: function(config) {
					this.callParent(arguments);
					var dataMarkerColumnName = "FuncRole";
					if (this.isOrgRolesDetail()) {
						dataMarkerColumnName = "OrgRole";
					}
					config.viewModel.primaryDisplayColumnName = dataMarkerColumnName;
				},

				/**
				 * ########## config ### lookupPage.
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
				 * ######### #######, ### ########### #####.
				 * @private
				 * @return {BPMSoft.data.filters.FilterGroup} ########## ###### ########.
				 */
				getRoleLookupFilter: function() {
					var filters = this.BPMSoft.createFilterGroup();
					var typeFilter = this.BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue",
							this.getFilterRoleType());
					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
						"[SysFuncRoleInOrgRole:FuncRole:Id].Id");
					var subFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"OrgRole",
						this.get("ChiefOrgRoleId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(typeFilter);
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
				 * ########## ####### ########### ###### "############### ####".
				 * @private
				 * @return {Boolean} ########## ####### ########### ###### "############### ####".
				 */
				isOrgRolesDetail: function() {
					var detailColumnName = this.get("DetailColumnName");
					return (detailColumnName && detailColumnName === "FuncRole");
				},

				/**
				 * ########## ###### ##### ### ####### ######.
				 * @private
				 * @return {Array} ###### #####.
				 */
				getFilterRoleType: function() {
					if (this.isOrgRolesDetail()) {
						return [
							ConfigurationConstants.SysAdminUnit.Type.Organisation,
							ConfigurationConstants.SysAdminUnit.Type.Department,
							ConfigurationConstants.SysAdminUnit.Type.Manager,
							ConfigurationConstants.SysAdminUnit.Type.Team
						];
					}
					return [ConfigurationConstants.SysAdminUnit.Type.FuncRole];
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
				 * ######### ######## ###### #######.
				 * @protected
				 * @virtual
				 * @param {Object} response ##### ####### AdministrationService.
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
				 * Callback-#######, ####### ########## ##### ######## #### ###### ## ########### #############.
				 * @virtual
				 * @param {Object} args ######, ########## ######### ######### #######.
				 */
				addCallback: function(args) {
					var dataSend = {
						orgRoleId: this.get("ChiefOrgRoleId"),
						funcRoleIds: this.Ext.encode(args.selectedRows.getKeys())
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "AddFuncRolesInOrgRole",
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, function(response) {
						response.message = response.AddFuncRolesInOrgRoleResult;
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.hideBodyMask();
							this.reloadGridData();
						}
					}, this);
				},

				/**
				* @overridden
				* @return {String}
				*/
				getFilterDefaultColumnName: function() {
					return "FuncRole";
				}
			}
		};
	});
