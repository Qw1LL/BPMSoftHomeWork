define("MiniPageViewGenerator", ["ViewGeneratorV2", "ConfigurationEnumsV2"], function() {

	/**
	 * Mini Page controls generator class.
	 */
	Ext.define("BPMSoft.configuration.MiniPageViewGenerator", {
		extend: "BPMSoft.configuration.ViewGenerator",
		alternateClassName: "BPMSoft.MiniPageViewGenerator",

		/**
		 * Is mini-page layout.
		 * @type {Boolean}
		 */
		IsMiniPageLayout: false,

		/**
		 * Suffix for ExtendedMenu collection name.
		 * @type {String}
		 */
		suffixExtendedMenuCollectionName: "ExtendedMenu",

		/**
		 * Suffix for ExtendedMenu button visible property name.
		 */
		suffixExtendedMenuButtonVisibility: "ExtendedMenuButtonVisible",

		/**
		 * Default css class for ExtendedMenu button marker.
		 * @type {String}
		 */
		defaultExtendedMenuButtonMarkerClass: "extended-menu-button-marker",

		/**
		 * Default css class for ExtendedMenu button wrap.
		 * @type {String}
		 */
		defaultExtendedMenuButtonWrapClass: "extended-menu-button-wrap",

		/**
		 * Default css class for ExtendedMenu button image.
		 * @type {String}
		 */
		defaultExtendedMenuButtonImageClass: "extended-menu-image",

		/**
		 * Checks if wrap classes exists.
		 * @param {Object} config Items config
		 * @param {Object} config.classes
		 * @param {String} config.classes.wrapClassName
		 * @return {Boolean} Return true if grid has classes.
		 */
		checkWrapClasses: function(config) {
			return config.classes && config.classes.wrapClassName;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateGridLayout
		 * @override
		 */
		generateGridLayout: function(config) {
			this.IsMiniPageLayout = config.name === "MiniPage";
			var result = this.callParent(arguments);
			delete result.generator;
			if (!this.checkWrapClasses(result)) {
				return result;
			}
			var classes = result.classes.wrapClassName.slice(0);
			classes.push("grid-mini-wrap");
			result.classes.wrapClassName = classes;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateLookupEdit
		 * @override
		 */
		generateLookupEdit: function(config) {
			if (!config.contentType) {
				config.contentType = BPMSoft.ContentType.ENUM;
			}
			const lookupEdit = this.callParent(arguments);
			delete lookupEdit.showValueAsLink;
			return lookupEdit;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateEnumEdit
		 * @override
		 */
		generateEnumEdit: function() {
			var enumEdit = this.callParent(arguments);
			if (enumEdit && !enumEdit.filterComparisonType) {
				enumEdit.filterComparisonType = BPMSoft.StringFilterType.CONTAIN;
			}
			return enumEdit;
		},

		/**
		 * @private
		 */
		_getMiniPageModes: function() {
			var pages = this.viewModelClass.prototype.getEditPagesCollection();
			var page = pages.findByFn(function(page) {
				return page.get("MiniPage").schemaName != null;
			}, this);
			var miniPage = page && page.get("MiniPage");
			var modes = miniPage && miniPage.miniPageModes;
			if (BPMSoft.isEmpty(modes)) {
				var miniPageModes = this.viewModelClass.prototype.getColumnByName("MiniPageModes");
				modes = miniPageModes && miniPageModes.value;
			}
			return modes;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateModule
		 * @override
		 */
		generateModule: function(config) {
			let isMiniPageModelItem = false;
			if (config && config.isMiniPageModelItem) {
				isMiniPageModelItem = true;
				delete config.isMiniPageModelItem;
			}
			var result = this.callParent(arguments);
			if (isMiniPageModelItem) {
				if (Ext.isEmpty(config.visiblechanged)) {
					result.visiblechanged = {
						bindTo: "onModuleVisibleChanged"
					};
				}
			}
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateModelItem
		 * @override
		 */
		generateModelItem: function(config) {
			var miniPageModelItemWrap;
			if (config && config.isMiniPageModelItem) {
				delete config.isMiniPageModelItem;
				var modes = this._getMiniPageModes();
				if (BPMSoft.isEmpty(modes)) {
					miniPageModelItemWrap = this.generateMiniPageModelItem(config);
				} else {
					for (var i = 0; i < modes.length; i++) {
						var modelItemWrap;
						var mode = modes[i];
						switch (mode) {
							case BPMSoft.ConfigurationEnums.CardOperation.EDIT:
							case BPMSoft.ConfigurationEnums.CardOperation.ADD:
								modelItemWrap = this.callParent(arguments);
								this.decorateModelItemForEditMode(modelItemWrap);
								break;
							default:
								modelItemWrap = this.generateMiniPageModelItem(config);
								this.decorateModelItemForViewMode(modelItemWrap);
								break;
						}
						if (!miniPageModelItemWrap) {
							miniPageModelItemWrap = modelItemWrap;
						}
						miniPageModelItemWrap.items = miniPageModelItemWrap.items.concat(modelItemWrap.items);
					}
					if (Ext.isDefined(config.tag)) {
						miniPageModelItemWrap.tag = config.tag;
					}
				}
			} else {
				miniPageModelItemWrap = this.callParent(arguments);
			}
			return miniPageModelItemWrap;
		},

		/**
		 * Decorates model item for view mode.
		 * @protected
		 * @param {Object} modelItemWrap Model item wrap.
		 */
		decorateModelItemForViewMode: function(modelItemWrap) {
			modelItemWrap.items.forEach(function(item) {
				item.id += "MiniPage";
				if (!item.visible) {
					item.visible = {"bindTo": "isViewMode"};
				}
				if (item.classes && item.classes.wrapClassName) {
					item.classes.wrapClassName.push("minipage-view-mode");
				}
			}, this);
		},

		/**
		 * Decorates model item for edit mode.
		 * @protected
		 * @param {Object} modelItemWrap Model item wrap.
		 */
		decorateModelItemForEditMode: function(modelItemWrap) {
			modelItemWrap.items.forEach(function(item) {
				if (!item.visible) {
					item.visible = {"bindTo": "isNotViewMode"};
				}
				if (item.classes && item.classes.wrapClassName) {
					item.classes.wrapClassName.push("minipage-edit-mode");
				}
			});
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#getAutoBindings
		 * @override
		 */
		getAutoBindings: function(config) {
			var result = this.callParent(arguments);
			if (this.isItemLabelVisible(config)) {
				delete result.placeholder;
			} else {
				result.placeholder = this.getLabelCaption(config);
			}
			return result;
		},

		/**
		 * Generate model item view for MiniPage.
		 * @protected
		 * @param {Object} config Element schema config.
		 * @return {Object} Generated element view.
		 */
		generateMiniPageModelItem: function(config) {
			var clonedConfig = BPMSoft.deepClone(config);
			var modelItemWrap = this.createModelItemWrapContainer(clonedConfig);
			var modelItemLabel;
			if (this.isItemLabelVisible(clonedConfig)) {
				modelItemLabel = this.createModelItemLabel(clonedConfig);
				modelItemWrap.items.push(modelItemLabel);
			}
			delete clonedConfig.labelConfig;

			modelItemWrap.items.push(this.createModelItemControl(clonedConfig));
			return modelItemWrap;
		},
		/**
		 * @private
		 * @param {Object} config
		 * @returns {Object}
		 */
		createModelItemWrapContainer: function(config) {
			var modelItemWrapId = this.getControlId(config, "BPMSoft.Container");
			var modelItemWrap = this.getDefaultContainerConfig(modelItemWrapId, config);
			if (!Ext.isEmpty(config.visible)) {
				modelItemWrap.visible = config.visible;
			}
			var defaultClasses = this.getModelItemContainerClasses(config);
			this.addClasses(modelItemWrap, "wrapClassName", defaultClasses);
			return modelItemWrap;
		},
		/**
		 * private
		 * @param {Object} clonedConfig
		 * @returns {Object}
		 */
		createModelItemLabel: function(clonedConfig) {
			clonedConfig.generateMarker = false;
			const labelWrap = this.generateModelItemLabel(clonedConfig);
			const label = labelWrap.items[0];
			label.id = this.generateUniqueId(label.id);
			label.isRequired = false;
			return labelWrap;
		},

		/**
		 * @private
		 * @param id {String}
		 * @returns {String}
		 */
		generateUniqueId: function(id) {
			return Ext.String.format("{0}_{1}", id, BPMSoft.generateGUID());
		},

		/**
		 * @private
		 * @param {Object} clonedConfig
		 * @returns {Object}
		 */
		createModelItemControl: function(clonedConfig) {
			var controlWrap = this.generateEditControlWrap(clonedConfig);
			var control = {};
			if (this.getNeedGenerateHyperLink(clonedConfig)) {
				control = this.generateMiniPageHyperLink(clonedConfig);
			} else {
				if (!clonedConfig.caption && clonedConfig.name) {
					clonedConfig.caption = clonedConfig.name;
				}
				control = this.generateMiniPageLabel(clonedConfig);
				this.addVisibleRules(clonedConfig, control);
			}
			controlWrap.items.push(control);
			return controlWrap;
		},
		/**
		 * @private
		 * @param {Object} clonedConfig
		 * @returns {Boolean}
		 */
		getNeedGenerateHyperLink: function(clonedConfig) {
			var itemDataValueType = this.getItemDataValueType(clonedConfig);
			var viewModelColumn = this.findViewModelColumn(clonedConfig);
			var primaryDisplayColumnName = this.getPrimaryDisplayColumnName();
			var isEditable = this.isSchemaEditable(viewModelColumn);
			var isLookup = itemDataValueType === BPMSoft.DataValueType.LOOKUP;
			var isSimpleLookup = viewModelColumn && viewModelColumn.isSimpleLookup;
			var isPrimaryDisplayColumnName = primaryDisplayColumnName === viewModelColumn.name;
			return isPrimaryDisplayColumnName || (isLookup && isEditable && !isSimpleLookup);

		},
		/**
		 * @private
		 * @param {Object} clonedConfig
		 * @param {Object} control
		 */
		addVisibleRules: function(clonedConfig, control) {
			if (Ext.isEmpty(clonedConfig.controlConfig) ||
				Ext.isEmpty(clonedConfig.controlConfig.visible)) {
				return;
			}
			control.visible = clonedConfig.controlConfig.visible
		},

		/**
		 * Returns true if entity have edit page.
		 * @private
		 * @param  {Object} viewModelColumn ViewModel column.
		 * @return {Boolean} True if entity have edit page.
		 */
		isSchemaEditable: function(viewModelColumn) {
			if (viewModelColumn && viewModelColumn.referenceSchemaName &&
				BPMSoft.ModuleUtils.getEntityStructureByName(viewModelColumn.referenceSchemaName)) {
				return true;
			}
			return false;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#getMarkerValue
		 * @override
		 */
		getMarkerValue: function(config) {
			if (Ext.isBoolean(config.generateMarker) && !config.generateMarker) {
				delete config.generateMarker;
				return null;
			}
			return this.callParent(arguments);
		},

		/**
		 * Generate hyperlink view for MiniPage.
		 * @protected
		 * @param {Object} config Element schema config.
		 * @return {Object} Generated hyperlink view.
		 */
		generateMiniPageHyperLink: function(config) {
			var id = this.getControlId(config, "BPMSoft.Hyperlink");
			var hyperlink = {
				className: "BPMSoft.Hyperlink",
				caption: {
					bindTo: this.getItemBindTo(config),
					bindConfig: {
						converter: function(caption) {
							if (Ext.isObject(caption)) {
								return caption.displayValue ? caption.displayValue : "";
							}
							return caption ? caption : "";
						}
					}
				},
				target: BPMSoft.controls.HyperlinkEnums.target.SELF,
				href: {
					bindTo: "getHyperLinkHref"
				},
				click: {"bindTo": "close"},
				tag: config.tag || this.getItemBindTo(config),
				markerValue: this.getMarkerValue(config)
			};
			this.applyControlId(hyperlink, config, id);
			this.addLabelSizeClass(hyperlink, config);
			Ext.apply(hyperlink, this.getConfigWithoutServiceProperties(config, ["className"]));
			this.generateItemTips(config, hyperlink);
			return hyperlink;
		},

		/**
		 * Generate label view for MiniPage.
		 * @protected
		 * @param {Object} config Element schema config.
		 * @return {Object} Generated label view.
		 */
		generateMiniPageLabel: function(config) {
			var label = this.generateLabel(config);
			label.id = this.generateUniqueId(label.id);
			var defaultBindings = this.getMiniPageLabelBindings(config);
			Ext.apply(label, defaultBindings);
			return label;
		},

		/**
		 * Return mini page label bindings.
		 * @protected
		 * @param {Object} config Element schema config.
		 * @return {Object} Bindings.
		 */
		getMiniPageLabelBindings: function(config) {
			var column = this.findViewModelColumn(config);
			return {
				caption: {
					bindTo: this.getItemBindTo(config),
					bindConfig: {
						converter: function(caption, dataValueType) {
							var value;
							if (this.isViewMode()) {
								if (dataValueType) {
									value = BPMSoft.getTypedStringValue(caption, dataValueType);
								} else if (Ext.isObject(caption)) {
									value = caption.displayValue;
								} else {
									value = caption;
								}
							} else {
								value = column && column.caption;
							}
							return value || "";
						}
					}
				}
			};
		},

		/**
		 * Return primary display column name.
		 * @protected
		 * @return Element primary display column.
		 */
		getPrimaryDisplayColumnName: function() {
			return this.viewModelClass.prototype.entitySchema.primaryDisplayColumnName;
		},

		/**
		 * Generate round image control view.
		 * @protected
		 * @param {Object} config Element schema config.
		 * @return {Object} Generated image control.
		 */
		generateRoundImageControl: function(config) {
			var id = this.getControlId(config, "BPMSoft.ImageEdit");
			var controlConfig = {
				className: "BPMSoft.ImageEdit",
				imageSrc: {bindTo: config.getSrcMethod},
				imageElClasses: "ts-image-style-circle",
				defaultImageSrc: config.defaultImage
			};
			this.applyControlId(controlConfig, config, id);
			Ext.apply(controlConfig, this.getConfigWithoutServiceProperties(config,
				["generator", "getSrcMethod", "defaultImage"]));
			return controlConfig;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#getControlId
		 * @override
		 */
		getControlId: function(config, className) {
			if (className === "BPMSoft.ImageEdit") {
				return config.name + "ImageEdit";
			}
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateControlLabelWrap
		 * @override
		 */
		generateControlLabelWrap: function() {
			var labelWrap = this.callParent(arguments);
			if (!this.checkWrapClasses(labelWrap)) {
				return labelWrap;
			}
			var classes = labelWrap.classes.wrapClassName.slice(0);
			classes.push("label-mini-wrap");
			labelWrap.classes.wrapClassName = classes;
			return labelWrap;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateButton
		 * @override
		 */
		generateButton: function(config) {
			var extendedMenu = config.extendedMenu;
			if (extendedMenu && extendedMenu.Name && extendedMenu.PropertyName) {
				if (Ext.isEmpty(config.style)) {
					config.style = BPMSoft.controls.ButtonEnums.style.TRANSPARENT;
				}
				if (Ext.isEmpty(config.classes)) {
					config.classes = {};
				}
				config.classes.wrapperClass = this.addExtendedButtonClass(config.classes.wrapperClass,
					this.defaultExtendedMenuButtonWrapClass);
				if (!Ext.isEmpty(config.imageConfig)) {
					config.classes.imageClass = this.addExtendedButtonClass(config.classes.imageClass,
						this.defaultExtendedMenuButtonImageClass);
				}
				var name = extendedMenu.Name;
				var propertyName = extendedMenu.PropertyName;
				var collectionName = name + propertyName + this.suffixExtendedMenuCollectionName;
				var visiblePropertyName = name + propertyName + this.suffixExtendedMenuButtonVisibility;
				config.tag = propertyName;
				config.menu = {
					"id": this.suffixExtendedMenuCollectionName,
					"items": {"bindTo": collectionName}
				};
				config.visible = {"bindTo": visiblePropertyName};
				config.classes.markerClass = [this.defaultExtendedMenuButtonMarkerClass];
				if (extendedMenu.Click) {
					config.prepareMenu = extendedMenu.Click;
				}
			}
			var button = this.callParent(arguments);
			delete button.extendedMenu;
			delete button.generator;
			return button;
		},

		/**
		 * Add extended button class.
		 * @protected
		 * @param {Array} classes Button classes.
		 * @param {Object} extendedClass Extended class.
		 */
		addExtendedButtonClass: function(classes, extendedClass) {
			classes = Ext.isEmpty(classes) ? [] : classes;
			classes.push(extendedClass);
			return classes;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateEditControlWrap
		 * @override
		 */
		generateEditControlWrap: function() {
			var controlWrap = this.callParent(arguments);
			if (!this.checkWrapClasses(controlWrap)) {
				return controlWrap;
			}
			var classes = controlWrap.classes.wrapClassName.slice(0);
			classes.push("control-mini-wrap");
			controlWrap.classes.wrapClassName = classes;
			return controlWrap;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#getModelItemContainerClasses
		 * @override
		 */
		getModelItemContainerClasses: function() {
			var result = this.callParent(arguments);
			result.push("container-mini-wrap");
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.ViewGenerator#generateGridLayoutItem
		 * @override
		 */
		generateGridLayoutItem: function() {
			var gridLayoutItem = this.callParent(arguments);
			if (this.IsMiniPageLayout) {
				gridLayoutItem.forEach(function(gridItem) {
					var gridContainer = gridItem.item;
					if (gridContainer && gridContainer.className === "BPMSoft.Container") {
						var bindings = this.getContainerVisibilityBindTo(gridContainer);
						if (Ext.isArray(bindings) && !Ext.isEmpty(bindings)) {
							if (!Ext.isDefined(gridContainer.tag)) {
								gridContainer.tag = bindings;
							}
							if (!Ext.isDefined(gridContainer.visible)) {
								gridContainer.visible = {"bindTo": "getVisibility"};
							}
						}
					}
				}, this);
			}
			return gridLayoutItem;
		},

		/**
		 * Return entity column names, which display in current container.
		 * @param {Object} container Current container.
		 * @return {Array} Array of entity column names.
		 */
		getContainerVisibilityBindTo: function(container) {
			var containerBindings = [];
			if (container.items && container.items.length > 0) {
				container.items.forEach(function(containerItem) {
					if (containerItem.className === "BPMSoft.Container") {
						var bindings = this.getContainerVisibilityBindTo(containerItem);
						containerBindings = containerBindings.concat(bindings);
					} else if (containerItem.caption && containerItem.caption.bindTo) {
						var columnValue = this.viewModelClass.prototype.getColumnByName(containerItem.caption.bindTo);
						var isNotResourceColumn = columnValue &&
							(columnValue.type !== BPMSoft.ViewModelColumnType.RESOURCE_COLUMN);
						if (containerBindings.indexOf(containerItem.caption.bindTo) === -1 && isNotResourceColumn) {
							containerBindings = containerBindings.concat(containerItem.caption.bindTo);
						}
					}
				}, this);
			}
			return Ext.Array.unique(containerBindings);
		}

	});

	return Ext.create("BPMSoft.MiniPageViewGenerator");
});
