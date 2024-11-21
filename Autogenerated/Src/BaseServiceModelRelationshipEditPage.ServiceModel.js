define("BaseServiceModelRelationshipEditPage", [],
	function() {
		return {
			attributes: {
				"DependencyType": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"dependencies": [
						{
							"columns": ["DependencyCategory"],
							"methodName": "onDependencyCategoryChanged"
						}
					]
				},
				"DependencyCategory": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"dependencies": [
						{
							"columns": ["DependencyType"],
							"methodName": "onDependencyTypeChanged"
						}
					]
				},
				"DependencyTypeFilterColumnName": {
					"dataValueType": BPMSoft.DataValueType.TEXT
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
						filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.NOT_EQUAL,
							"Id",
							sectionColumn.value));
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
					var dependencyCategory = this.get("DependencyCategory");
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
					var dependencyCategory = this.get("DependencyCategory");
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
							this.set("DependencyCategory", dependencyCategory);
						}
					}, this);
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
				 * @protected
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
						this.get("DependencyTypeFilterColumnName"),
						true,
						scope.BPMSoft.DataValueType.BOOLEAN));
					var dependencyCategory = scope.get("DependencyCategory");
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
				}
			}
		};
	});
