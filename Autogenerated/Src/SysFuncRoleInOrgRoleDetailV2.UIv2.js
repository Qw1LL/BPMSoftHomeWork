define("SysFuncRoleInOrgRoleDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonEnabled
				 * @overridden
				 */
				getAddRecordButtonEnabled: function() {
					return true;
				},

				/**
				 * ######### ###### # ###### ######. ####### ####### ######.
				 * @inheritdoc SysFuncRoleChiefInOrgRoleDetailV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					this.beforeLoadGridData();
					var esq = this.getGridDataESQ();
					this.initQueryColumns(esq);
					this.initQuerySorting(esq);
					this.initQueryFilters(esq);
					this.initQueryOptions(esq);
					this.initQueryEvents(esq);
					esq.getEntityCollection(function(response) {
						this.destroyQueryEvents(esq);
						this.onGridDataLoaded(response);
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.SysFuncRoleChiefInOrgRoleDetailV2#getRoleLookupFilter
				 * @overridden
				 */
				getRoleLookupFilter: function() {
					var filters = BPMSoft.createFilterGroup();
					var typeFilter = this.BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue",
						this.getFilterRoleType());
					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
						"[SysFuncRoleInOrgRole:FuncRole:Id].Id");
					var subFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"OrgRole",
						this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(typeFilter);
					return filters;
				},

				/**
				 * @inheritdoc BPMSoft.SysFuncRoleChiefInOrgRoleDetailV2#addCallback
				 * @overridden
				 */
				addCallback: function(args) {
					var config = {};
					if (this.isOrgRolesDetail()) {
						config = {
							serviceName: "AdministrationService",
							methodName: "AddFuncRoleInOrgRoles",
							data: {
								orgRoleIds: this.Ext.encode(args.selectedRows.getKeys()),
								funcRoleId: this.get("MasterRecordId")
							}
						};
					} else {
						config = {
							serviceName: "AdministrationService",
							methodName: "AddFuncRolesInOrgRole",
							data: {
								orgRoleId: this.get("MasterRecordId"),
								funcRoleIds: this.Ext.encode(args.selectedRows.getKeys())
							}
						};
					}
					this.showBodyMask();
					this.callService(config, function(response) {
						if (this.isOrgRolesDetail()) {
							response.message = response.AddFuncRoleInOrgRolesResult;
						} else {
							response.message = response.AddFuncRolesInOrgRoleResult;
						}
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.hideBodyMask();
							this.reloadGridData();
						}
					}, this);
				},

                /**
                 * @overridden
                 * @return {String} ### #######.
                 */
                getFilterDefaultColumnName: function() {
					if (this.isOrgRolesDetail()) {
						return "OrgRole";
					} else {
						return "FuncRole";
					}
                },

				/**
				 * @protected
				 * @inheritdoc SysFuncRoleChiefInOrgRoleDetailV2#getFilters
				 * @overridden
				 * @return {BPMSoft.FilterGroup}
				 **/
				getFilters: function() {
					var filters = this.get("DetailFilters");
					var serializationInfo = filters.getDefSerializationInfo();
					serializationInfo.serializeFilterManagerInfo = true;
					var deserializedFilters = BPMSoft.deserialize(filters.serialize(serializationInfo));
					deserializedFilters.add("Filter", this.get("Filter"));
					return deserializedFilters;
				}
			}
		};
	});
