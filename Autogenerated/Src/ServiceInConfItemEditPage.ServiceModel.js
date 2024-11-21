define("ServiceInConfItemEditPage", ["StorageUtilities", "ServiceInConfItemEditPageResources"],
	function(StorageUtilities, resources) {
		return {
			entitySchemaName: "VwServiceInConfItem",
			attributes: {
				"ServiceItem": {
					"lookupListConfig": {
						"filter": function() {
							return this.getLookupFilter("ServiceItem", "ConfItem");
						}
					}
				},
				"ConfItem": {
					"lookupListConfig": {
						"filter": function() {
							return this.getLookupFilter("ConfItem", "ServiceItem");
						}
					}
				},
				"DependencyType": {
					"dependencies": [
						{
							columns: ["DependencyCategory", "DependencyCategoryReverse"],
							methodName: "onDependencyCategoryChanged"
						}
					]
				},
				"DependencyCategory": {
					"dependencies": [
						{
							columns: ["DependencyType"],
							methodName: "onDependencyTypeChanged"
						}
					]
				},
				"DependencyCategoryReverse": {
					"dependencies": [
						{
							columns: ["DependencyType"],
							methodName: "onDependencyTypeChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * ######## ###### ### ########### #### # #######
				 * @param {String} detailColumnName ### #### ########### #### ###### # ####### ########
				 * @param {String} sectionColumnName ### #### ########### #### ####### # ####### ########
				 * @return {BPMSoft.createFilterGroup}
				 */
				getLookupFilter: function(detailColumnName, sectionColumnName) {
					var filters = this.BPMSoft.createFilterGroup();
					var sectionColumn = this.get(sectionColumnName);
					if (sectionColumn && sectionColumn.value !== BPMSoft.GUID_EMPTY) {
						var typeFilter = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							sectionColumnName,
							sectionColumn.value);
						var notExistsFilter = this.BPMSoft.createNotExistsFilter(
							"[" + this.entitySchemaName + ":" + detailColumnName + ":Id].Id");
						notExistsFilter.subFilters.addItem(typeFilter);
						filters.addItem(notExistsFilter);
					}
					return filters;
				},

				/**
				 * ####### #### "### ###########", ### ######### #### "######### ###########".
				 */
				onDependencyCategoryChanged: function() {
					var dependencyType = this.get("DependencyType");
					if (dependencyType == null) {
						return;
					}
					var dependencyCategoryColumnName = this.getCategoryColumnName();
					var dependencyCategory = this.get(dependencyCategoryColumnName);
					if (dependencyCategory == null) {
						this.set("DependencyType", null);
						return;
					}
					var dependencyTypeCategory = this.get("DependencyTypeCategory");
					if (dependencyCategory.value === dependencyTypeCategory.value) {
						return;
					}
					this.set("DependencyType", null);
				},

				/**
				 * ######### #### "######### ###########, ### ######### #### "### ###########".
				 */
				onDependencyTypeChanged: function() {
					var dependencyType = this.get("DependencyType");
					if (dependencyType == null) {
						return;
					}
					var dependencyCategoryColumnName = this.getCategoryColumnName();
					var dependencyCategory = this.get(dependencyCategoryColumnName);
					if (dependencyCategory != null) {
						return;
					}
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "DependencyType"
					});
					esq.addColumn("DependencyCategory");
					esq.getEntity(dependencyType.value, function(result) {
						if (result.success) {
							var dependencyCategory = result.entity.get("DependencyCategory");
							this.set("DependencyTypeCategory", dependencyCategory);
							this.set(dependencyCategoryColumnName, dependencyCategory);
						}
					}, this);
				},

				/**
				 * ######## ### ####### "######### ########### ########"
				 */
				getCategoryColumnName: function() {
					var currentSectionName = StorageUtilities.getItem("ServiceModelCurrentSectionName");
					return currentSectionName === "ServiceItemSection"
						? "DependencyCategory"
						: "DependencyCategoryReverse";
				},

				/**
				 * ########## ####### ########### ######## "######### ########### ########".
				 * @return {BPMSoft.DataValueType.BOOLEAN} ####### ########### ########
				 */
				getDependencyCategoryEnabled: function() {
					return this.isNew;
				},

				/**
				 * ########## ###### ##### ########### ########.
				 * @return {BPMSoft.DataValueType.COLLECTION} ###### ##### ########### ########
				 */
				getDependencyTypeList: function() {
					this.getDependencyTypeEsq(function(esq, dependencyCategory, scope) {
						esq.getEntityCollection(function(result) {
							scope.fillDependencyTypeList(result, dependencyCategory);
						}, scope);
					}, this);
				},

				/**
				 * ######### ######### EntitySchemaQuery "### ########### ########" ### ###### ########## #####
				 * @protected
				 * @param {Function} callback ####### ############ ######### "##### ############ ########"
				 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
				 */
				getDependencyTypeEsq: function(callback, scope) {
					var dependencyTypeSelect = Ext.create("BPMSoft.EntitySchemaQuery",
						{rootSchemaName: "DependencyType"});
					dependencyTypeSelect.addColumn("Id");
					dependencyTypeSelect.addColumn("Name");
					dependencyTypeSelect.addColumn("ReverseTypeName");
					dependencyTypeSelect.addColumn("DependencyCategory");
					dependencyTypeSelect.filters.add(scope.BPMSoft.createColumnFilterWithParameter(
						scope.BPMSoft.ComparisonType.EQUAL,
						"ForServiceConfItem",
						true,
						scope.BPMSoft.DataValueType.BOOLEAN));
					var dependencyCategoryColumnName = this.getCategoryColumnName();
					var dependencyCategory = this.get(dependencyCategoryColumnName);
					callback(dependencyTypeSelect, dependencyCategory, scope);
				},

				/**
				 * ######### ###### ##### ########### ########.
				 * @protected
				 * @param {Object} response ##### ## ###### ##### ########### ########.
				 * @param {BPMSoft.ENTITY_COLUMN} dependencyCategory ####### "######### ########### #######"
				 */
				fillDependencyTypeList: function(response, dependencyCategory) {
					var list = this.get("DependencyTypeList");
					if (response.success) {
						var responseItems = response.collection.getItems();
						var columnList = {};
						this.BPMSoft.each(responseItems, function(item) {
							var id = item.get("Id");
							var name = item.get("Name");
							var reverseTypeName = item.get("ReverseTypeName");
							if (dependencyCategory == null) {
								columnList[name + id] = {
									value: item.get("Id"),
									displayValue: item.get("Name")
								};
								columnList[reverseTypeName + id] = {
									value: item.get("Id"),
									displayValue: item.get("ReverseTypeName")
								};
							} else {
								var dependencyTypeCategory = item.get("DependencyCategory");
								if (dependencyCategory.value === dependencyTypeCategory.value) {
									columnList[name + id] = {
										value: item.get("Id"),
										displayValue: item.get("Name")
									};
								} else {
									columnList[reverseTypeName + id] = {
										value: item.get("Id"),
										displayValue: item.get("ReverseTypeName")
									};
								}
							}
						});
						list.clear();
						list.loadAll(columnList);
					}
				},
				/**
				 * @inheritDoc BPMSoft.BasePageV2#validateColumn
				 * @overridden
				 */
				validateColumn: function(columnName) {
					var result = {
						isValid: this.callParent(arguments)
					};
					var dependencyCategoryColumnName = this.getCategoryColumnName();
					if (dependencyCategoryColumnName !== columnName) {
						return result.isValid;
					}
					var dependencyCategory = this.get(dependencyCategoryColumnName);
					var isValid = !this.Ext.isEmpty(dependencyCategory);
					if (!isValid) {
						result.invalidMessage = resources.localizableStrings.DependencyCategoryErrorMessage;
						result.isValid = false;
					}
					this.validationInfo.set(columnName, result);
					return result.isValid;
				}
			}
		};
	});
