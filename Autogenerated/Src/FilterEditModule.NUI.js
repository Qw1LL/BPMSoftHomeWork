define("FilterEditModule", ["FilterEditModuleResources", "BaseModule"],
	function(resources) {

		/**
		 * @class BPMSoft.configuration.FilterEditModuleViewModel
		 * This class used for creating ViewModel of filters module
		 */
		Ext.define("BPMSoft.configuration.FilterEditModuleViewModel", {
			extend: "BPMSoft.BaseModel",
			alternateClassName: "BPMSoft.FilterEditModuleViewModel",
			Ext: null,
			BPMSoft: null,
			sandbox: null,

			/**
			 * Class name of the filter provider by default.
			 */
			defaultFilterProviderClassName: "BPMSoft.EntitySchemaFilterProvider",

			/**
			 * Subscriptions.
			 * @protected
			 * @virtual
			 */
			subscribeForMessages: function() {
				var sandboxId = this.sandbox.id;
				this.sandbox.subscribe("SetFilterModuleConfig", this.setFilterModuleConfig, this, [sandboxId]);
				this.sandbox.subscribe("GetFilters", this.getFiltersManagerFilter, this, [sandboxId]);
				this.sandbox.subscribe("FilterActionFired", this.onFilterActionFired, this, [sandboxId]);
				this._subscribeSelectFilterChanged();
			},

			/**
			 * Setting up filter properties object.
			 * @protected
			 * @virtual
			 * @param {Object} filterModuleConfig Filter model configuration object.
			 * @param {String} filterModuleConfig.rootSchemaName Schema name.
			 * @param {String} filterModuleConfig.filters Serialized filter data.
			 * @param {Boolean} filterModuleConfig.actionsVisible Actions buttons visibility indicator.
			 * @param {Boolean} filterModuleConfig.useDcmMainRecord Main record usage indicator.
			 */
			setFilterModuleConfig: function(filterModuleConfig) {
				if (!filterModuleConfig) {
					return;
				}
				var oldRootSchemaName = this.get("rootSchemaName");
				var rootSchemaName = filterModuleConfig.rootSchemaName;
				if (Ext.isDefined(rootSchemaName) && rootSchemaName !== oldRootSchemaName) {
					this.destroyFilterManager();
					this.destroyFilterProvider();
					if (rootSchemaName) {
						this.createFilterManager(filterModuleConfig);
					}
					this.set("rootSchemaName", rootSchemaName);
				}
				this.set("rightExpressionMenuAligned", filterModuleConfig.rightExpressionMenuAligned);
				this.set("filterEditConfig", filterModuleConfig.filterEditConfig);
				var filters = filterModuleConfig.filters;
				if (!Ext.isEmpty(filters) && Ext.isString(filters)) {
					filters = BPMSoft.deserialize(filters);
				} else if (!(filters instanceof BPMSoft.FilterGroup)) {
					filters = null;
				}
				this.setFilters(filters);
				var actionsVisible = filterModuleConfig.actionsVisible;
				if (Ext.isDefined(actionsVisible)) {
					this.set("actionsVisible", actionsVisible);
				}
			},

			/**
			 * Setting filters.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.FilterGroup} filters Filter group.
			 */
			setFilters: function(filters) {
				var filterManager = this.get("filterManager");
				if (filterManager) {
					filterManager.setFilters(filters || Ext.create("BPMSoft.FilterGroup"));
				}
			},

			/**
			 * Creates entity schema filter manager.
			 * @protected
			 * @virtual
			 * @param {Object} filterModuleConfig The filter module settings.
			 */
			createFilterManager: function(filterModuleConfig) {
				var rootSchemaName = filterModuleConfig.rootSchemaName;
				var filterProviderDefaultConfig = filterModuleConfig.entitySchemaFilterProviderConfig;
				var filterProviderClassName = filterModuleConfig.filterProviderClassName;
				var filterProviderConfig = this.getFilterProviderConfig(rootSchemaName, filterProviderDefaultConfig);
				var provider = this.createFilterProvider(filterProviderClassName, filterProviderConfig);
				var filterManager = Ext.create("BPMSoft.FilterManager", {
					provider: provider,
					rootSchemaName: rootSchemaName
				});
				filterManager.on("addFilter", this.onFiltersChanged, this);
				filterManager.on("removeFilter", this.onFiltersChanged, this);
				filterManager.on("changeFilter", this.onFiltersChanged, this);
				filterManager.on("rootFiltersChanged", this.onFiltersChanged, this);
				this.set("filterManager", filterManager);
				this.set("filterProvider", provider);
			},

			/**
			 * @private
			 */
			_subscribeSelectFilterChanged: function() {
				this.on("change:selectedFilters", this.onSelectedFilterChange, this);
			},

			/**
			 *  @private
			 */
			_unsubscribeSelectFilterChanged: function() {
				this.un("change:selectedFilters", this.onSelectedFilterChange, this);
			},

			/**
			 * @private
			 */
			_getUseFilterUngroupVisibilitySettingsEnabled: function () {
				return BPMSoft.Features.getIsEnabled("UseFilterUngroupVisibilitySettings");
			},

			/**
			 * Returns config for the filter provider.
			 * @privte
			 * @param {String} rootSchemaName Name of the entity schema of provider.
			 * @param {Object} config Extended config.
			 * @returns {Object} Config.
			 */
			getFilterProviderConfig: function(rootSchemaName, config) {
				var filterProviderConfig = {
					rootSchemaName: rootSchemaName,
					canDisplayId: true,
					sandbox: this.sandbox
				};
				this.Ext.apply(filterProviderConfig, config);
				return filterProviderConfig;
			},

			/**
			 * Creates filter provider.
			 * @privte
			 * @param {String} filterProviderClassName Class name of the filter provider.
			 * @param {Object} config Config.
			 * @returns {Object} Filter provider.
			 */
			createFilterProvider: function(filterProviderClassName, config) {
				filterProviderClassName = filterProviderClassName || this.defaultFilterProviderClassName;
				return this.Ext.create(filterProviderClassName, config);
			},

			/**
			 * Destroys filter manager.
			 * @protected
			 * @virtual
			 */
			destroyFilterManager: function() {
				var filterManager = this.get("filterManager");
				if (!filterManager) {
					return;
				}
				filterManager.un("addFilter", this.onFiltersChanged, this);
				filterManager.un("removeFilter", this.onFiltersChanged, this);
				filterManager.un("changeFilter", this.onFiltersChanged, this);
				filterManager.un("rootFiltersChanged", this.onFiltersChanged, this);
				filterManager.destroy();
				this.set("filterManager", null);
			},

			/**
			 * Destroys filter provider.
			 * @protected
			 * @virtual
			 */
			destroyFilterProvider: function() {
				var filterProvider = this.get("filterProvider");
				if (filterProvider) {
					filterProvider.destroy();
					this.set("filterProvider", null);
				}
			},

			/**
			 * Handling buttons press.
			 * @protected
			 * @virtual
			 * @param {String} key.
			 */
			onFilterActionFired: function(key) {
				switch (key) {
					case "group":
						this.groupItems();
						break;
					case "ungroup":
						this.unGroupItems();
						break;
					case "up":
						this.moveUp();
						break;
					case "down":
						this.moveDown();
						break;
				}
			},

			/**
			 * Group elements.
			 * @protected
			 * @virtual
			 */
			groupItems: function() {
				var filterManager = this.get("filterManager");
				filterManager.groupFilters(this.getFiltersArray());
				this.onSelectedFilterChange();
			},

			/**
			 * Ungroup elements.
			 * @protected
			 * @virtual
			 */
			unGroupItems: function() {
				var filterManager = this.get("filterManager");
				filterManager.unGroupFilters(this.getSelectedFilter());
				this.onSelectedFilterChange();
			},

			/**
			 * Moves element up.
			 * @protected
			 * @virtual
			 */
			moveUp: function() {
				var filterManager = this.get("filterManager");
				filterManager.moveUp(this.getSelectedFilter());
				this.onSelectedFilterChange();
			},

			/**
			 * Moves element down.
			 * @protected
			 * @virtual
			 */
			moveDown: function() {
				var filterManager = this.get("filterManager");
				filterManager.moveDown(this.getSelectedFilter());
				this.onSelectedFilterChange();
			},

			/**
			 * Change element handler.
			 * @protected
			 * @virtual
			 */
			onSelectedFilterChange: function(selectedFilters) {
				var filter = Ext.isEmpty(selectedFilters) ? this.getSelectedFilter() : selectedFilters;;
				if(this._getUseFilterUngroupVisibilitySettingsEnabled()) {
					filter = this.getSelectedFilter();
				}
				var buttonVisibilityConfig = this._getButtonVisibilityConfig(filter);
				this._setButtonVisibility(buttonVisibilityConfig);
				this.fireEnableChanged();
			},

			_getButtonVisibilityConfig: function(filter) {
				var rootFilter = this.get("filterManager").filters;
				var notRootFilter = !Ext.isEmpty(filter) && (filter !== rootFilter);
				var notFirstFilter = rootFilter.indexOf(filter) !== 0;
				var notLastFilter = rootFilter.indexOf(filter) !== (rootFilter.getCount() - 1);
				var filters = this.getFiltersArray();
				var isAllFiltersSelected = filters.length === rootFilter.getCount();
				var isFilterInstanceOfFilterGroup = filter instanceof BPMSoft.data.filters.FilterGroup;
				var unGroupButtonVisibility = isAllFiltersSelected || (notRootFilter && isFilterInstanceOfFilterGroup);
				var moveUpButtonVisibility = notRootFilter && notFirstFilter;
				var moveDownButtonVisibility = notRootFilter && notLastFilter;
				return {
					notRootFilter: notRootFilter,
					unGroupButtonVisibility: unGroupButtonVisibility,
					moveUpButtonVisibility: moveUpButtonVisibility,
					moveDownButtonVisibility: moveDownButtonVisibility
				};
			},

			_setButtonVisibility: function(config) {
				this.set("groupButtonVisible", config.notRootFilter);
				this.set("unGroupButtonVisible", config.unGroupButtonVisibility);
				this.set("moveUpButtonVisible", config.moveUpButtonVisibility);
				this.set("moveDownButtonVisible", config.moveDownButtonVisibility);
			},

			/**
			 * Handler for process parameter select.
			 * @protected
			 * @virtual
			 */
			onPrepareMappingParametersList: function(config, callback) {
				config = config || {};
				config.callback = callback;
				this.sandbox.publish("OpenMappingEditWindow", config, [this.sandbox.id]);
			},

			/**
			 * Handler for main record value select.
			 * @public
			 * @virtual
			 */
			onPrepareMainRecordModalBox: function(config, callback) {
				this.sandbox.publish("OpenMacrosPage", callback, [this.sandbox.id]);
			},

			/**
			 * Sets buttons states.
			 * @protected
			 * @virtual
			 */
			fireEnableChanged: function() {
				var enableConfig = {
					groupBtnState: this.get("groupButtonVisible"),
					unGroupBtnState: this.get("unGroupButtonVisible"),
					moveUpBtnState: this.get("moveUpButtonVisible"),
					moveDownBtnState: this.get("moveDownButtonVisible")
				};
				this.sandbox.publish("FilterActionsEnabledChanged", enableConfig);
			},

			/**
			 * Filters filter array.
			 * @protected
			 * @virtual
			 * @return filtersArray Filters array.
			 */
			getFiltersArray: function() {
				const selectedItems = this.get("selectedFilters");
				if(this._getUseFilterUngroupVisibilitySettingsEnabled()) {
					const filtersArray = [];
					BPMSoft.each(selectedItems, function(item) {
						filtersArray.push(item);
					});
					return filtersArray;
				}
				return Ext.Object.getValues(selectedItems);
			},

			/**
			 * Gets selected filter.
			 * @protected
			 * @virtual
			 * @return {Object} Selected filter.
			 */
			getSelectedFilter: function() {
				var filtersArray = this.getFiltersArray() || [];
				return (filtersArray.length > 0) ? filtersArray[0] : null;
			},

			/**
			 * Filter change handler.
			 * @protected
			 * @virtual
			 */
			onFiltersChanged: function() {
				var changed = this.getFiltersManagerFilter();
				this.sandbox.publish("OnFiltersChanged", changed, [this.sandbox.id]);
			},

			/**
			 * Returns filter object.
			 * @protected
			 * @virtual
			 * @return {Object} filters.
			 */
			getFiltersManagerFilter: function() {
				var filterManager = this.get("filterManager");
				return {
					filter: filterManager.filters,
					serializedFilter: filterManager.serializeFilters()
				};
			},

			/**
			 * Destroys filter manager and filter provider.
			 * @protected
			 * @virtual
			 */
			destroy: function() {
				this.destroyFilterManager();
				this._unsubscribeSelectFilterChanged();
				this.destroyFilterProvider();
				this.callParent(arguments);
			}

		});

		/**
		 * @class BPMSoft.configuration.FilterEditModule
		 * Filter module class.
		 */
		var filterEditModule = Ext.define("BPMSoft.configuration.FilterEditModule", {

			extend: "BPMSoft.BaseModule",

			alternateClassName: "BPMSoft.FilterEditModule",

			isAsync: true,

			EntitySchemaFilterProviderModule: null,

			viewModel: null,

			Ext: null,

			BPMSoft: null,

			sandbox: null,

			/**
			 * Creates view model.
			 * @protected
			 * @virtual
			 * @return {Object} returns view model object.
			 */
			createViewModel: function() {
				return this.Ext.create("BPMSoft.FilterEditModuleViewModel", {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft,
					values: {
						/**
						 * Schema name.
						 * @private
						 * @type {String}
						 */
						rootSchemaName: null,
						/**
						 * Action buttons visibility token.
						 * @private
						 * @type {Boolean}
						 */
						actionsVisible: true,
						/**
						 * ####### ########## ###### ###########.
						 * @private
						 * @type {Boolean}
						 */
						groupButtonVisible: false,
						/**
						 * ####### ########## ###### ##############.
						 * @private
						 * @type {Boolean}
						 */
						unGroupButtonVisible: false,
						/**
						 * ####### ########## ###### #####.
						 * @private
						 * @type {Boolean}
						 */
						moveUpButtonVisible: false,
						/**
						 * ####### ########## ###### ####.
						 * @private
						 * @type {Boolean}
						 */
						moveDownButtonVisible: false,
						/**
						 * ######## #######
						 * @private
						 * @type {Object}
						 */
						filterManager: null,
						/**
						 * ######### ######.
						 * @private
						 * @type {Object}
						 */
						selectedFilters: null,
						/**
						 * ######### #######.
						 * @private
						 * @type {Object}
						 */
						filterProvider: null,
						rightExpressionMenuAligned: false
					}
				});
			},

			/**
			 * ######### ############# ###### #############.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ####### ######### ######.
			 */
			init: function(callback, scope) {
				if (!this.EntitySchemaFilterProviderModule) {
					var map = {};
					map.EntitySchemaFilterProviderModule = {
						sandbox: "sandbox_" + this.sandbox.id,
						"ext-base": "ext_" + Ext.id
					};
					requirejs.config({
						map: map
					});
					this.BPMSoft.require(["EntitySchemaFilterProviderModule"], function(providerModule) {
						if (this.destroyed) {
							return;
						}
						this.EntitySchemaFilterProviderModule = providerModule;
						callback.call(scope);
					}, this);
				} else {
					callback.call(scope);
				}
			},

			/**
			 * ######### ########## ###### # #########.
			 * @param {Ext.Element} renderTo.
			 */
			render: function(renderTo) {
				var viewModel;
				if (!this.viewModel) {
					var filterModuleConfig = this.sandbox.publish("GetFilterModuleConfig", null, [this.sandbox.id]);
					viewModel = this.viewModel = this.createViewModel();
					if (filterModuleConfig) {
						viewModel.setFilterModuleConfig(filterModuleConfig);
					}
					viewModel.subscribeForMessages();
				} else {
					viewModel = this.viewModel;
				}
				var renderToName = renderTo.id;
				var view = this.getView(renderToName);
				view.render(renderTo);
				view.bind(viewModel);
			},

			/**
			 * ####### ######### #############
			 * @protected
			 * @virtual
			 * @return {BPMSoft.Container} ########## ######### #############
			 */
			getView: function(parentContainerName) {
				return this.Ext.create("BPMSoft.Container", {
					id: parentContainerName + "FilterContainer",
					selectors: {
						wrapEl: "#" + parentContainerName + "FilterContainer"
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: parentContainerName + "FilterContainerToolbar",
							selectors: {
								wrapEl: "#" + parentContainerName + "FilterContainerToolbar"
							},
							items: [
								{
									className: "BPMSoft.Button",
									caption: resources.localizableStrings.ActionsButtonCaption,
									style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
									visible: {bindTo: "actionsVisible"},
									menu: {
										items: [
											{
												className: "BPMSoft.MenuItem",
												caption: resources.localizableStrings.GroupMenuItemCaption,
												click: {
													bindTo: "groupItems"
												},
												enabled: {
													bindTo: "groupButtonVisible"
												}
											},
											{
												className: "BPMSoft.MenuItem",
												caption: resources.localizableStrings.UnGroupMenuItemCaption,
												click: {
													bindTo: "unGroupItems"
												},
												enabled: {
													bindTo: "unGroupButtonVisible"
												}
											},
											{
												className: "BPMSoft.MenuItem",
												caption: resources.localizableStrings.MoveUpMenuItemCaption,
												click: {
													bindTo: "moveUp"
												},
												enabled: {
													bindTo: "moveUpButtonVisible"
												}
											},
											{
												className: "BPMSoft.MenuItem",
												caption: resources.localizableStrings.MoveDownMenuItemCaption,
												click: {
													bindTo: "moveDown"
												},
												enabled: {
													bindTo: "moveDownButtonVisible"
												}
											}
										]
									}
								}
							]
						},
						{
							className: "BPMSoft.FilterEdit",
							filterManager: {
								bindTo: "filterManager"
							},
							selectedItems: {
								bindTo: "selectedFilters"
							},
							prepareMappingParametersList: {
								bindTo: "onPrepareMappingParametersList"
							},
							prepareMainRecordModalBox: {
								bindTo: "onPrepareMainRecordModalBox"
							},
							rightExpressionMenuAligned: {
								bindTo: "rightExpressionMenuAligned"
							},
							filterEditConfig: { "bindTo": "filterEditConfig" }
						}
					],
					visible: {
						bindTo: "rootSchemaName",
						bindConfig: {
							converter: function(value) {
								return Boolean(value);
							}
						}
					}
				});
			},

			/**
			 * ########## ######.
			 * @protected
			 * @virtual
			 */
			destroy: function(config) {
				if (config.keepAlive) {
					return;
				}
				if (this.viewModel) {
					this.viewModel.destroy();
				}
				this.EntitySchemaFilterProviderModule = null;
				requirejs.undef("EntitySchemaFilterProviderModule");
			}
		});

		return filterEditModule;
	});
