define("EmployeeSection", ["css!EmployeeSectionCSS"], function() {
	return {
		entitySchemaName: "Employee",
		attributes: {

			/**
			 * If true shows only working employees. If false shows all employees.
			 */
			"IsActive": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#UseStaticFolders
			 * @overridden
			 */
			"UseStaticFolders": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#ContextHelpId
			 * @overridden
			 */
			"ContextHelpId": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"value": 1692
			},

			/**
			 * Primary image column name.
			 */
			"primaryImageColumnName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"value": "Contact.Photo"
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var sectionFilters = this.callParent(arguments);
				this.setIsActiveFilter(sectionFilters);
				return sectionFilters;
			},

			/**
			 * Adds or removes IsActiveFilter to filter collection.
			 * @protected
			 * @param {BPMSoft.Collection} filterCollection Filter collection.
			 */
			setIsActiveFilter: function(filterCollection) {
				var isActive = this.get("IsActive");
				if (isActive) {
					if (!filterCollection.contains("IsActiveFilter")) {
						filterCollection.add("IsActiveFilter", this.BPMSoft.createColumnIsNullFilter("CareerDueDate"));
					}
				} else {
					filterCollection.removeByKey("IsActiveFilter");
				}
			},

			/**
			 * Handles IsActiveCheckbox checked.
			 * @param {Boolean} value True if checked.
			 */
			onIsActiveCheckboxChecked: function(value) {
				if (!this.get("IsSectionVisible")) {
					return;
				}
				this.set("IsActive", value);
				this.sandbox.publish("FiltersChanged", null, [this.sandbox.id]);
				this.deselectRows();
				this.reloadGridData();
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "IsActiveFiltersContainer",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["isActive-filter-container-wrapClass"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "IsActiveFiltersContainer",
				"propertyName": "items",
				"name": "IsActiveCheckbox",
				"values": {
					"bindTo": "IsActive",
					"caption": {
						"bindTo": "Resources.Strings.IsActiveCheckboxCaption"
					},
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit",
						"checkedchanged": {
							"bindTo": "onIsActiveCheckboxChecked"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name":"DataGrid",
				"values": {
					"defaultImageColumnName" :"Contact.Photo"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
