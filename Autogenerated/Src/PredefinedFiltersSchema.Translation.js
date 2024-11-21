define("PredefinedFiltersSchema", ["BPMSoft", "PredefinedFiltersSchemaResources", "PredefinedFilterViewModel"],
		function(BPMSoft, resources) {
	return {
		messages: {
			LoadedFiltersFromStorage: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			UpdateFilter: {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			GetPredefinedFilters: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			GetSectionFiltersInfo: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Initializes filters collection.
			 * @private
			 */
			initFiltersCollection: function() {
				var predefinedFilters = this.sandbox.publish("GetPredefinedFilters", null, [this.sandbox.id]);
				var filters = this.Ext.create(BPMSoft.BaseViewModelCollection);
				this.BPMSoft.each(predefinedFilters, function(filterConfig) {
					var filterViewModel = this.getFilterViewModel(filterConfig);
					filters.add(filterConfig.key, filterViewModel);
				}, this);
				this.set("Filters", filters);
			},

			/**
			 * Processes getting filters from storage.
			 * @private
			 */
			onLoadedFiltersFromStorage: function() {
				var filters = this.get("Filters");
				var sectionFilters = this.sandbox.publish("GetSectionFiltersInfo", null, [this.sandbox.id]);
				if (!sectionFilters) {
					return;
				}
				sectionFilters.eachKey(function(key, value) {
					var filter = filters.find(key);
					if (filter) {
						filter.setValue(value);
					}
				}, this);
			},

			/**
			 * Gets filter view model.
			 * @private
			 * @param {Object} filterConfig Filter configuration.
			 * @param {String} filterConfig.className Filter class name.
			 * @return {BPMSoft.PredefinedFilter}
			 */
			getFilterViewModel: function(filterConfig) {
				var className = filterConfig.className || "BPMSoft.PredefinedFilter";
				delete filterConfig.className;
				return this.Ext.create(className, this.Ext.apply({}, filterConfig, {
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					sandbox: this.sandbox
				}));
			},

			/**
			 * Gets filter items list configuration.
			 * @private
			 * @return {Object}
			 */
			getFilterItemsListConfig: function() {
				var filterItemConfig = this.getFilterItemConfig();
				var listConfig = {
					className: "BPMSoft.ContainerList",
					idProperty: "ColumnPath",
					collection: {bindTo: "FilterItemsList"},
					defaultItemConfig: filterItemConfig,
					classes: {
						wrapClassName: ["filter-items-container-list"]
					}
				};
				return listConfig;
			},

			/**
			 * Gets filter item view configuration.
			 * @private
			 * @return {Object}
			 */
			getFilterItemConfig: function() {
				var labelConfig = {
					className: "BPMSoft.Label",
					caption: {bindTo: "Caption"},
					markerValue: {bindTo: "ColumnPath"}
				};
				var deleteImageConfig = this.getDeleteImageConfig();
				var deleteImageButtonConfig = {
					className: "BPMSoft.Button",
					style: this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: {
						source: this.BPMSoft.ImageSources.URL,
						url: this.BPMSoft.ImageUrlBuilder.getUrl(deleteImageConfig)
					},
					click: {bindTo: "onDeleteButtonClick"},
					classes: {
						wrapperClass: ["delete-button-wrapper"]
					},
					markerValue: "DeleteButton"
				};
				return {
					id: this.BPMSoft.generateGUID(),
					className: "BPMSoft.Container",
					items: [
						labelConfig,
						deleteImageButtonConfig
					],
					classes: {
						wrapClassName: ["filter-item"]
					}
				};
			},

			/**
			 * Returns DeleteImage configuration.
			 * @private
			 * @return {Object}
			 */
			getDeleteImageConfig: function() {
				return resources.localizableImages.DeleteImage;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.sandbox.subscribe("LoadedFiltersFromStorage", this.onLoadedFiltersFromStorage, this,
							[this.sandbox.id]);
					this.initFiltersCollection();
					callback.call(scope);
				}, this]);
			},

			/**
			 * Gets columns list button configuration.
			 * @param {Object} filter Filter.
			 * @return {Object}
			 */
			getColumnsListButtonConfig: function(filter) {
				var buttonConfig = {
					className: "BPMSoft.Button",
					caption: {
						bindTo: "getColumnsListButtonCaption"
					},
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					menu: {
						items: {
							bindTo: "ColumnsList"
						}
					},
					markerValue: filter ? filter.caption : ""
				};
				var imageConfig = filter && filter.imageConfig;
				if (imageConfig) {
					buttonConfig.imageConfig = imageConfig;
				}
				return buttonConfig;
			},

			/**
			 * Prepares filter view configuration.
			 * @param  {Object} view View.
			 * @param {Object} filter Filter.
			 * @return {Object}
			 */
			prepareFilterViewConfig: function(view, filter) {
				var columnsListButtonConfig = this.getColumnsListButtonConfig(filter);
				var filterItemsListConfig = this.getFilterItemsListConfig();
				view.config = {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["filter-container"]
					},
					items: [
						columnsListButtonConfig,
						filterItemsListConfig
					]
				};
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "PredefinedFiltersContainer",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["predefined-filters-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Filters",
				"parentName": "PredefinedFiltersContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "Filters",
					"onGetItemConfig": "prepareFilterViewConfig"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
