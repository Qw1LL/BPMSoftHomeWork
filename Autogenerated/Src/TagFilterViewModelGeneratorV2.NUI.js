define("TagFilterViewModelGeneratorV2", ["TagFilterViewModelGeneratorV2Resources","ModuleUtils",
			"TagModuleSchemaHelper", "BaseFilterViewModel", "css!TagModuleSchemaStyles"],
	function(resources, ModuleUtils) {
		/**
		 * @class BPMSoft.configuration.TagFilterViewModel
		 * Tag filter ViewModel class.
		 */
		Ext.define("BPMSoft.configuration.TagFilterViewModel", {
			alternateClassName: "BPMSoft.TagFilterViewModel",
			extend: "BPMSoft.BaseFilterViewModel",

			mixins: {
				/**
				 * @class TagModuleSchemaHelper #####, ########### ######### ###### ### ###### # ######.
				 */
				TagModuleSchemaHelper: "BPMSoft.TagModuleSchemaHelper"
			},

			columns: {
				/**
				 * ######### ###### ########## ####### ## ####.
				 * @Type {String}
				 */
				TagButtonCaption: {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					name: "TagButtonCaption"
				},
				/**
				 * ####### ######## ### ############## ####### ## ####.
				 * @Type {Object}
				 */
				TagFilterValue: {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					name: "TagFilterValue"
				},
				/**
				 * ###### ######### ######## ### ############## ####### ## ####.
				 * @Type {BPMSoft.Collection}
				 */
				TagsList: {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					name: "TagsList"
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @virtual
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.Ext = this.get("Ext");
				this.BPMSoft = BPMSoft;
				this.initProperties();
				this.addEvents(
					"filterChanged"
				);
				var updateSuspended = this.suspendUpdate;
				this.suspendUpdate = true;
				this.initializeTags();
				this.suspendUpdate = updateSuspended;
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Initializes tags.
			 * @protected
			 */
			initializeTags: function() {
				var filters = this.get("Filters");
				var tags = filters && filters[0] && filters[0].tags;
				BPMSoft.each(tags, function(tag) {
					this.addToFilterCollection(tag);
				}, this);
				this.fireEvent("filterChanged", "TagFilters", this.suspendUpdate);
			},

			/**
			 * Sets default attribute values.
			 */
			initProperties: function() {
				var editViewConfig = this.getTagEditViewConfig();
				var tagViewConfig = this.getTagViewConfig();
				this.set("TagFilters", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.set("EditViewConfig", editViewConfig);
				this.set("TagViewConfig", tagViewConfig);
				this.set("TagsRowCount", 50);
				this.set("IsSeparateMode", true);
			},

			/**
			 * Returns tag filters configuration.
			 * @return {Array} Tag filters configuration.
			 */
			getFilters: function() {
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				var inTagSchemaName = this.get("InTagEntitySchemaName");
				var collection = this.get("TagFilters");
				collection.each(function(tag) {
					var tagId = tag.get("Id");
					filters.add("TagFilters_" + tagId, this.createTagFilter(inTagSchemaName, tagId));
				}, this);
				return filters;
			},

			/**
			 * Creates tag filters.
			 * @param {String} inTagSchemaName In tag entity schema name.
			 * @param {String[]} tags Tag ids.
			 * @return {BPMSoft.ExistsFilter[]} Tag filter.
			 */
			createTagFilters: function(inTagSchemaName, tags) {
				return tags.map(function(tagId) {
					return this.createTagFilter(inTagSchemaName, tagId);
				}, this);
			},

			/**
			 * Creates tag filter.
			 * @param {String} inTagSchemaName In tag entity schema name.
			 * @param {String} tagId Tag id.
			 * @return {BPMSoft.ExistsFilter} Tag filter.
			 */
			createTagFilter: function(inTagSchemaName, tagId) {
				var columnPath = this.Ext.String.format("[{0}:Entity:Id].Tag", inTagSchemaName);
				var existsFilter = this.BPMSoft.createExistsFilter(columnPath);
				existsFilter.subFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Tag", tagId));
				return existsFilter;
			},

			/**
			 * ##### ######## ### ######## #############.
			 * ######### ###### # ###### ####### ######## ############ ########,
			 * ################ ### ########## ######## ########.
			 */
			getFilterValue: function() {
				var tagFilters = this.get("TagFilters");
				var filterValue = [];
				tagFilters.each(function(tag) {
					var tagType = tag.get("Type");
					if (tagType) {
						filterValue.push({
							displayValue: tag.get("DisplayValue"),
							value: tag.get("Id"),
							type: tagType
						});
					}
				});
				return filterValue;
			},

			/**
			 * Removes tag from filter collection.
			 * @private
			 * @param {BPMSoft.BaseViewModel} tag Tag view model.
			 */
			removeTag: function(tag) {
				var collection = this.get("TagFilters");
				collection.remove(tag);
				this.fireEvent("filterChanged", "TagFilters");
				this.updateButtonCaption();
				this.removeTagFromStorage(tag);
			},

			/**
			 * Removes tag from storage.
			 * @private
			 * @param {BPMSoft.BaseViewModel} tag Tag view model.
			 */
			removeTagFromStorage: function(tag) {
				var storage = BPMSoft.configuration.Storage.Filters;
				var entityName = this.get("TagEntitySchemaName").replace("Tag", "");
				var sectionSchema = ModuleUtils.getModuleStructureByName(entityName).sectionSchema;
				if (storage && storage[sectionSchema] && storage[sectionSchema].TagFilters) {
					var tags = storage[sectionSchema].TagFilters[0].tags;
					var tagToRemove = BPMSoft.findWhere(tags, {
						value: tag.get("Id")
					});
					if (Ext.isDefined(tagToRemove)) {
						tags.splice(tags.indexOf(tagToRemove), 1);
					}
				}
			},

			/**
			 * ############# ######### ###### ########## ####### ## ####.
			 */
			updateButtonCaption: function() {
				var collection = this.get("TagFilters");
				var isSeparateMode = this.get("IsSeparateMode");
				var caption = resources.localizableStrings.TagButtonCaption;
				if (!collection.isEmpty() && isSeparateMode) {
					caption = "";
				}
				this.set("TagButtonCaption", caption);
			},

			/**
			 * ######### ####### ###### ############# ######### ######## ## #### # ######### ########.
			 * ##### ####### ###########, ######### ## ######## ######## ######## ## ####, ### ###.
			 * @private
			 * @return {Boolean} ######### ######### ######## ## ####.
			 */
			isTagFilterEditVisible: function() {
				var collection = this.get("TagFilters");
				var editModel = collection.find("EditModel");
				return !this.Ext.isEmpty(editModel);
			},

			/**
			 * ########## ######## ######## ## ####.
			 */
			showTagFilterEdit: function() {
				if (!this.isTagFilterEditVisible()) {
					this.set("TagsList", null);
					this.set("TagFilterValue", null);
					this.set("IsFilterEditFocused", false);
					var collection = this.get("TagFilters");
					collection.add("EditModel", this);
				}
			},

			/**
			 * ######## ######## ######## ## ####.
			 */
			removeTagFilterEdit: function() {
				if (this.isTagFilterEditVisible()) {
					var collection = this.get("TagFilters");
					collection.remove(this);
				}
			},

			/**
			 * ########### ###### ######## ## #### ## ####### ###### ####.
			 * @param {BPMSoft.BaseViewModel} filterModel ###### ####.
			 */
			subscribeFilterModelEvents: function(filterModel) {
				filterModel.on("remove", this.removeFilter, this);
			},

			/**
			 * ########## ###### ######## ## #### ## ####### ###### ####.
			 * @param {BPMSoft.BaseViewModel} filterModel ###### ####.
			 */
			unsubscribeFilterModelEvents: function(filterModel) {
				filterModel.un("remove", this.removeFilter, this);
			},

			/**
			 * It creates a filter model for the tag, and adds it to the collection of filters.
			 * @private
			 * @param {Object} tagConfig Options to create a filter.
			 * @param {Object} tagConfig.type Object with the value of the reference type column.
			 * ######## ######## value # displayValue Tag type.
			 * @param {String} tagConfig.displayValue Tag name.
			 * @param {Guid} tagConfig.value Unique identifier tag.
			 */
			addToFilterCollection: function(tagConfig) {
				var filterModel = this.getTagFilterModel(tagConfig);
				this.subscribeFilterModelEvents(filterModel);
				var collection = this.get("TagFilters");
				collection.add(filterModel);
			},

			/**
			 * It creates a filter model for the tag, and adds it to the collection of filters.
			 * It raises an event filter change.
			 * @protected
			 * @param {Object} tagConfig Options to create a filter.
			 * @param {Object} tagConfig.type Object with the value of the reference type column.
			 * ######## ######## value # displayValue Tag type.
			 * @param {String} tagConfig.displayValue Tag name.
			 * @param {Guid} tagConfig.value Unique identifier tag.
			 */
			addFilter: function(tagConfig) {
				this.addToFilterCollection(tagConfig);
				this.fireEvent("filterChanged", "TagFilters");
				this.updateButtonCaption();
			},


			/**
			 * ########## ####### ######## #######. ####### ###### ####### ## ######### ####### ########.
			 * @param {BPMSoft.BaseViewModel} filterModel ###### ####.
			 */
			removeFilter: function(filterModel) {
				this.unsubscribeFilterModelEvents(filterModel);
				this.removeTag(filterModel);
			},

			/**
			 * ########## ###### "######" ######### ######## ## ####.
			 */
			onCancelEditClick: function() {
				this.removeTagFilterEdit();
			},

			/**
			 * ########## ####### ######### ######## # ######### ######## ## ####.
			 * #### ##### ######## ####### ## ######, ## ##### ######### ##### ###### ## ####.
			 * @param {Object|*} newValue ######### ########.
			 */
			onTagFilterValueChange: function(newValue) {
				if (!this.Ext.isEmpty(newValue))  {
					this.addFilter(newValue);
					this.removeTagFilterEdit();
				}
				this.set("TagFilterValue", newValue);
			},

			/**
			 * ######### ######### ######### ##### ## ########## ########.
			 * @param {String} searchValue ######## ### ##########.
			 */
			getTagsList: function(searchValue) {
				var tagEntitySchemaName = this.get("TagEntitySchemaName");
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: tagEntitySchemaName
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
				esq.addColumn("Type");
				esq.rowCount = this.get("TagsRowCount");
				this.addTagSelectFilters(esq, searchValue);
				esq.getEntityCollection(function(result) {
					var collection = this.Ext.create("BPMSoft.Collection");
					if (result.success) {
						var selectedTags = result.collection;
						selectedTags.each(function(tag) {
							var tagId = tag.get("Id");
							var menuItemConfig = this.getTagMenuItemConfig(tag);
							collection.add(tagId, menuItemConfig);
						}, this);
					}
					this.set("TagsList", collection);
				}, this);
			},

			/**
			 * ######### # ###### ####### ## ########## ######## # ########## ##### ######### #####.
			 * @param {BPMSoft.EntitySchemaQuery} esq ###### ## ####### ######.
			 * @param {String} searchValue ######### ########.
			 */
			addTagSelectFilters: function(esq, searchValue) {
				var filters = esq.filters;
				var tagTypesFilter = this.getTagTypesFilter();
				this.addPublicTagFilter(tagTypesFilter);
				var notSelectedTagFilter = this.getNotSelectedTagsFilter();
				filters.add("TagTypesFilter", tagTypesFilter);
				filters.add("NameFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.START_WITH, "Name", searchValue));
				if (!this.Ext.isEmpty(notSelectedTagFilter)) {
					filters.add("NotSelectedTagFilter", notSelectedTagFilter);
				}
			},

			/**
			 * ######### ###### ### ###### ###### #####, ####### ## #### ####### #####.
			 * @return {BPMSoft.InFilter} ###### ### ###### ###### #####, ####### ## #### ####### #####.
			 */
			getNotSelectedTagsFilter: function() {
				var collection = this.get("TagFilters");
				return this.getFilterByExistsTag(collection, "Id");
			},

			/**
			 * ######### ######### ### ###### #### # ######### ######## ## ####.
			 * @param {BPMSoft.BaseViewModel} tag ###### ####.
			 * @return {Object} ######### ### ###### #### # ######### ######## ## ####.
			 */
			getTagMenuItemConfig: function(tag) {
				var tagId = tag.get("Id");
				var tagName = tag.get("Name");
				var tagType = tag.get("Type");
				var imageConfig = this.getImageConfigForExistsRecord(tagType.value);
				var config = {
					displayValue: tagName,
					value: tagId,
					type: tagType
				};
				if (!this.Ext.isEmpty(imageConfig)) {
					config.imageConfig = imageConfig;
				}
				return config;
			},

			/**
			 * ######### ######### ###### ### #### ##### # ######### ######## ## ####.
			 * @return {Object|*} ######### ###### ### ###### #### # ######### ######## ## ####.
			 */
			getFilterEditLeftIcon: function() {
				var filter = this.get("TagFilterValue");
				if (!this.Ext.isEmpty(filter)) {
					var type = filter.type;
					return this.getTagMenuImageConfig(type);
				}
				return null;
			},

			/**
			 * ########## ####### ######### ########## ############# ####### ## ####.
			 * @param {Object} itemConfig ######### ### ####### ## ####.
			 * @param {BPMSoft.BaseViewModel} item ###### ############# ####### ## ####.
			 */
			onGetTagItemConfig: function(itemConfig, item) {
				if (item === this) {
					var editViewConfig = this.get("EditViewConfig");
					itemConfig.config = BPMSoft.deepClone(editViewConfig);
				} else {
					var tagViewConfig = this.getTagItemViewConfig(item);
					itemConfig.config = tagViewConfig;
				}
			},

			/**
			 * ############# ##### ##### # #### ############## #######.
			 */
			setFilterEditFocused: function() {
				this.set("IsFilterEditFocused", true);
			},

			/**
			 * ######### ######### ############# ####### ####.
			 * @param {BPMSoft.BaseViewModel} tag ###### ####### ####.
			 * @return {Object} ######### ############# ####### ####.
			 */
			getTagItemViewConfig: function(tag) {
				var config = this.get("TagViewConfig");
				var tagViewConfig = BPMSoft.deepClone(config);
				var classes = tagViewConfig.classes || {};
				var wrapperClass = classes.wrapperClass || [];
				var type = tag.get("Type");
				var typeClass = this.getTagItemContainerBorderStyle(type.value);
				wrapperClass.push(typeClass);
				var itemId = "TagItem";
				return {
					id: itemId,
					selectors: {wrapEl: "#" + itemId},
					classes: {
						wrapClassName: ["tag-filter-item-container"]
					},
					markerValue: {"bindTo": "DisplayValue"},
					items: [tagViewConfig]
				};
			},

			/**
			 * ######### ######### ############# ######### ######## ## ####.
			 * @protected
			 * @return {Object} ######### ############# ######### ######## ## ####.
			 */
			getTagEditViewConfig: function() {
				var tagEditViewId = "TagItem";
				return {
					className: "BPMSoft.Container",
					id: tagEditViewId,
					selectors: {wrapEl: "#" + tagEditViewId},
					classes: {
						wrapClassName: ["filter-inner-container", "tag-filter-edit-container"]
					},
					items: [
						{
							className: "BPMSoft.ComboBoxEdit",
							markerValue: "TagFilterEdit",
							classes: {wrapClass: "filter-simple-filter-edit"},
							value: {bindTo: "TagFilterValue"},
							list: {bindTo: "TagsList"},
							prepareList: {bindTo: "getTagsList"},
							change: {bindTo: "onTagFilterValueChange"},
							leftIconConfig: {"bindTo": "getFilterEditLeftIcon"},
							focused: {"bindTo": "IsFilterEditFocused"},
							afterrender: {"bindTo": "setFilterEditFocused"}
						},
						{
							className: "BPMSoft.Button",
							markerValue: "cancelButton",
							imageConfig: resources.localizableImages.CancelButtonImage,
							click: {bindTo: "onCancelEditClick"}
						}
					]
				};
			},

			/**
			 * ######### ######### ############# ####### ## ####.
			 * @protected
			 * @return {Object} ######### ############# ####### ## ####.
			 */
			getTagViewConfig: function() {
				return {
					className: "BPMSoft.Button",
					imageConfig: resources.localizableImages.RemoveTagImage,
					classes: {
						"wrapperClass": ["tag-button", "tag-filter-item"],
						"imageClass": ["filter-remove-button"],
						"textClass": ["tag-filter-item-label"]
					},
					caption: {"bindTo": "DisplayValue"},
					iconAlign: BPMSoft.controls.ButtonEnums.iconAlign.RIGHT,
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageClick: {bindTo: "onRemove"},
					hint: {"bindTo": "DisplayValue"}
				};
			},

			/**
			 * ######### ###### ############# ####### ## ####.
			 * @protected
			 * @param {Object} tagConfig ######### ### ######## ###### #######.
			 * @param {Object} tagConfig.type ###### # ######### ########## ####### ####.
			 * ######## ######## value # displayValue #### ####.
			 * @param {String} tagConfig.displayValue ######## ####.
			 * @param {Guid} tagConfig.value ########## ############# ####.
			 * @return {BPMSoft.BaseVewModel} ###### ############# ####### ## ####.
			 */
			getTagFilterModel: function(tagConfig) {
				var tagFilterModel = this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						"Type": tagConfig.type,
						"DisplayValue": tagConfig.displayValue,
						"Id": tagConfig.value
					},
					methods: {
						onRemove: function() {
							this.fireEvent("remove", this);
						}
					}
				});
				tagFilterModel.addEvents(
					/**
					 * @event
					 * ####### ######## .
					 * @param {Object} viewModel ###### ############# .
					 */
					"remove"
				);
				return tagFilterModel;
			}
		});

		/**
		 * @class BPMSoft.configuration.TagFilterViewModelGenerator
		 * ##### TagFilterViewModelGenerator ######### ######### ###### ############# ######## ## ####.
		 */
		return Ext.define("BPMSoft.configuration.TagFilterViewModelGenerator", {
			alternateClassName: "BPMSoft.TagFilterViewModelGenerator",

			/**
			 * ######### ######### ###### ############# ######## ## ####.
			 * @param {Object} config ######### ### #########.
			 * @return {Object} ######### ### ###### ############# ######## ## #####.
			 */
			generate: function(config) {
				var values = this.getValuesConfig(config);
				return {
					className: "BPMSoft.TagFilterViewModel",
					values: values
				};
			},

			/**
			 * ######### ######### ######## ######### ###### #############.
			 * @param {Object} config ######### ### #########.
			 * @return {Object} ######### ######## ######### ###### #############.
			 */
			getValuesConfig: function(config) {
				var values = {
					TagButtonCaption: resources.localizableStrings.TagButtonCaption,
					TagFilters: null,
					Ext: config.Ext
				};
				if (!Ext.isEmpty(config.values)) {
					Ext.apply(values, config.values);
				}
				return values;
			}
		});
	});
