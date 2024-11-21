define("DaDataSuggestionsSettingsSection", ["css!DaDataSuggestionsSettingsSectionCSS"],
	function() {
		return {
			entitySchemaName: "DaDataSuggestionsSettings",
			attributes: {
				/**
				 * Если true - показывает только используемые настройки, иначе показывает все.
				 */
				"IsActive": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			messages: {},
			mixins: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getFilters
				 * @override
				 */
				getFilters: function() {
					let sectionFilters = this.callParent(arguments);
					this.setIsActiveFilter(sectionFilters);
					return sectionFilters;
				},
				
				/**
				 * Добавляет или удаляет IsActiveFilter из коллекции фильтров.
				 * @protected
				 * @param {BPMSoft.Collection} filterCollection Коллекция фильтров.
				 */
				setIsActiveFilter: function(filterCollection) {
					let isActive = this.get("IsActive");
					if (isActive) {
						if (!filterCollection.contains("IsActiveFilter")) {
							filterCollection.add("IsActiveFilter", this.BPMSoft.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "IsActive", true));
						}
					} else {
						filterCollection.removeByKey("IsActiveFilter");
					}
				},
				
				/**
				 * Срабатывает на изменене значения в чекбоксе IsActiveCheckbox.
				 * @param {Boolean} value Значение чекбокса.
				 */
				onIsActiveCheckboxChecked: function(value) {
					if (!this.get("IsSectionVisible")) {
						return;
					}
					this.set("IsActive", value);
					this.sandbox.publish("FiltersChanged", null, [this.sandbox.id]);
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
				}
			]/**SCHEMA_DIFF*/
		};
	});
