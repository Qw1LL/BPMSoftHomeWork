define("SysFuncRoleInOrgRolePageV2", ["ConfigurationConstants", "SysFuncRoleInOrgRole", "BusinessRuleModule"],
	function(ConfigurationConstants, SysFuncRoleInOrgRole, BusinessRuleModule) {
		return {
			entitySchemaName: "SysFuncRoleInOrgRole",
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
				},

				/**
				 * ######### #######, ###### ######### ########## ############ ####### # ######,
				 * # ########## ###### #### ############ #### (############## ### ###############)
				 * @private
				 * @param {String} columnName ######## #######, ####### ##### ##########.
				 * @return {BPMSoft.FilterGroup} ########## ###### ########.
				 */
				getRoleLookupFilter: function(columnName) {
					var filters = this.BPMSoft.createFilterGroup();
					if (!(columnName === "FuncRole" || columnName === "OrgRole"))
					{
						return filters;
					}
					var fixedColumnName = "";
					switch (columnName) {
						case "FuncRole":
							fixedColumnName = "OrgRole";
							break;
						case "OrgRole":
							fixedColumnName = "FuncRole";
							break;
						default:
							break;
					}
					var role = this.get(fixedColumnName);
					if (this.Ext.isEmpty(role)) {
						return filters;
					}
					var roleFilter =  this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						fixedColumnName,
						role.value);

					var sysAdminUnitTypes = [];
					switch (columnName) {
						case "FuncRole":
							sysAdminUnitTypes = [ConfigurationConstants.SysAdminUnit.Type.FuncRole];
							break;
						case "OrgRole":
							sysAdminUnitTypes = [
								ConfigurationConstants.SysAdminUnit.Type.Organisation,
								ConfigurationConstants.SysAdminUnit.Type.Department,
								ConfigurationConstants.SysAdminUnit.Type.Team
							];
							break;
						default:
							break;
					}
					var typeFilter = this.BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue",
						sysAdminUnitTypes);
					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
						"[SysFuncRoleInOrgRole:" + columnName + ":Id].Id");
					notExistsFilter.subFilters.addItem(roleFilter);
					filters.addItem(notExistsFilter);
					filters.addItem(typeFilter);
					return filters;
				},

				/**
				 * ######### ###### ### ####### FuncRole.
				 * @inheritDoc BPMSoft.BasePageV2#getLookupPageConfig
				 * @overridden
				 */
				getLookupPageConfig: function(args, columnName) {
					var entityColumn = this.entitySchema.getColumnByName(columnName);
					var filters = this.BPMSoft.createFilterGroup();
					filters.addItem(this.getLookupQueryFilters(columnName));
					filters.addItem(this.getRoleLookupFilter(columnName));
					var config = {
						entitySchemaName: args.schemaName || entityColumn.referenceSchemaName,
						multiSelect: false,
						columnName: columnName,
						columnValue: this.get(columnName),
						searchValue: args.searchValue,
						filters: filters,
						hideActions: true
					};
					this.Ext.apply(config, this.getLookupListConfig(columnName));
					return config;
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#getLookupQuery
				 * @overridden
				 */
				getLookupQuery: function(filterValue, columnName) {
					var esq = this.callParent(arguments);
					esq.filters.addItem(this.getRoleLookupFilter(columnName));
					return esq;
				}
			},
			rules: {
				"OrgRole": {
					"BindParameterEnabledOrgRole": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "FixedColumnName"
								},
								"comparisonType":  this.BPMSoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "FuncRole"
								}
							}
						]
					}
				},
				"FuncRole": {
					"BindParameterEnabledFuncRole": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "FixedColumnName"
								},
								"comparisonType":  this.BPMSoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": "OrgRole"
								}
							}
						]
					}
				}
			}
		};
	});
