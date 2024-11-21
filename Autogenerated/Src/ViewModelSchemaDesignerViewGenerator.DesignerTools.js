define("ViewModelSchemaDesignerViewGenerator", ["ext-base", "BPMSoft",
	"ViewModelSchemaDesignerViewGeneratorResources", "ViewGeneratorV2", "DesignTimeTabPanel",
	"ViewModelSchemaDesignerTabContainer", "ViewModelSchemaDesignerTabItem", "ViewModelSchemaDesignerControlGroup",
	"DesignTimeReorderableContainer", "DesignTimeReorderableItem", "DesignTimeReorderableItemModel",
	"css!ViewModelSchemaDesignerViewGenerator", "ImageView"
], function(Ext, BPMSoft, resources) {

	/**
	 * Class, which generate view of client schema into the design mode.
	 */
	Ext.define("BPMSoft.configuration.ViewModelSchemaDesignerViewGenerator", {
		extend: "BPMSoft.configuration.ViewGenerator",
		alternateClassName: "BPMSoft.ViewModelSchemaDesignerViewGenerator",

		// region Properties: Private

		/**
		 * Collection which keeps parents of generated items.
		 * @private
		 * @type {Object}
		 */
		parentCollection: null,

		// endregion

		// region Methods: Private

		/**
		 * Adds content to parent collection.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.name Parent name.
		 * @param {Object} config.items Child items.
		 */
		addToParentCollection: function(config) {
			if (Ext.isEmpty(this.parentCollection)) {
				this.parentCollection = {};
			}
			if (!Ext.isEmpty(config.items)) {
				BPMSoft.each(config.items, function(item) {
					var itemName = item.name;
					if (!Ext.isEmpty(itemName)) {
						this.parentCollection[itemName] = config.name;
					}
				}, this);
			}
		},

		/**
		 * Generate Image view control for action dashboard.
		 * @private
		 * @return {Object} ImageView control;
		 */
		generateActionDashboardImageView: function() {
			var imageViewConfig = {
				className: "BPMSoft.ImageView",
				imageSrc: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.ActionDashboardImage),
				classes: {wrapClass: ["img-action-dashboard"]},
				id: this.getControlId({name: "ActionDashboardImageView"}, "BPMSoft.ImageView")
			};
			return imageViewConfig;
		},

		/**
		 * Changes view config for Tabs container.
		 * @private
		 * @param {Object} config Tabs container config.
		 */
		changeTabsContainerClassName: function(config) {
			Ext.apply(config, {className: "BPMSoft.Container"});
		},

		/**
		 * Generate Image view control for related profile.
		 * @private
		 * @return {Object} ImageView control.
		 */
		generateRelatedProfileImageView: function() {
			var id = this.getControlId({
				name: "RelatedProfileImageView",
				schemaName: "ImageView"
			}, "BPMSoft.ImageView");
			var imageViewConfig = {
				className: "BPMSoft.ImageView",
				imageSrc: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.RelatedModuleImage),
				classes: {
					wrapClass: ["related-profile-img"]
				},
				id: id
			};
			return imageViewConfig;
		},

		/**
		 * Returns extend detail object.
		 * @private
		 * @param config
		 * @return {Object} hint for detail.
		 */
		getExtendedDetailConfig: function(config) {
			var detail = {};
			var tip = this.getHintConfig({
				className: BPMSoft.TipStyle.WHITE,
				hint: config.caption,
				content: resources.localizableStrings.InheritedVisibilityDetailMessage,
				alignEl: "captionEl"
			});
			detail.tips = [tip];
			detail.classes = {
				wrapClass: ["inherited-visibility"]
			};
			return detail;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateItem
		 * @override
		 */
		generateItem: function() {
			var config = arguments[0];
			this.addToParentCollection(config);
			var result = this.callParent(arguments);
			result.safeBind = true;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateEditControl
		 * @override
		 */
		generateEditControl: function() {
			var result = this.callParent(arguments);
			result.safeBind = true;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateTabPanelControl
		 * @override
		 */
		generateTabPanelControl: function(config) {
			config.className = "BPMSoft.DesignTimeTabPanel";
			var tabPanel = this.callParent(arguments);
			Ext.apply(tabPanel, {
				"onorderchange": {
					bindTo: "onTabOrderedChange"
				},
				"scrollIndex": {
					bindTo: "TabScrollIndex"
				},
				"items": this.generateTabPanelTools(config)
			});
			return tabPanel;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateModule
		 * @override
		 */
		generateModule: function(config) {
			config.caption = {
				bindTo: config.name + "_page_designer_module_caption"
			};
			var result = this.getConfigWithoutServiceProperties(config,
				["afterrender", "afterrerender", "moduleName"]
			);
			result = this.generateControlGroup(result);
			result.collapsed = true;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateContainer
		 * @override
		 */
		generateContainer: function(config) {
			
			var name = config.name;
			var result;
			if (name === "LeftModulesContainer") {
				
				config.excludeItemTypes = [BPMSoft.ViewItemType.MODULE];
				result = this.callParent(arguments);
				result.items.push(this.generateRelatedProfileContainer(config));
			} else if (name === "ActionDashboardContainer" || name === "DcmActionsDashboardContainer") {
				result = this.generateActionDashboardContainer(config);
				
			} else if (name === "TabsContainer") {
				this.changeTabsContainerClassName(config);
			} else {
				result = null;
			}
			return result || this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#requireCustomGenerators
		 * @override
		 */
		requireCustomGenerators: function(viewConfig, callback, scope) {
			callback.call(scope);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateCustomItem
		 * @override
		 */
		generateCustomItem: function(config) {
			if (BPMSoft.Features.getIsEnabled("PageDesignerCustomGeneratorFix")) {
				if (config) {
					delete config.generator;
				}
				return this.generateStandardItem(config);
			} else {
				return this.generateLabel({
					caption: config.name
				});
			}
		},

		/**
		 * @private
		 */
		_generateProfileContainer: function(result) {
			Ext.apply(result, {"columns": 1});
			Ext.apply(result.itemBindingConfig, {colSpan: 1, column: 0});
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateGridLayout
		 * @override
		 */
		generateGridLayout: function(config) {
			var controlId = config.name;
			var result = {
				className: config.className || "BPMSoft.GridLayoutEdit",
				id: controlId,
				selectors: {wrapEl: "#" + controlId},
				items: {bindTo: controlId + "Collection"},
				selection: {bindTo: controlId + "Selection"},
				selectedItems: {bindTo: controlId + "SelectedItems"},
				tag: controlId,
				autoHeight: true,
				autoWidth: false,
				multipleSelection: false,
				allowItemsIntersection: false,
				columns: 24,
				markerValue: controlId,
				itemActions: this.getModelItemTools(config),
				itemActionClick: {bindTo: "onItemActionClick"},
				itemDblClick: {bindTo: "onItemDblClick"},
				useManualSelection: false,
				itemBindingConfig: {
					itemId: {bindTo: "itemId"},
					markerValue: {bindTo: "content"},
					content: {bindTo: "content"},
					column: {bindTo: "column"},
					colSpan: {bindTo: "colSpan"},
					row: {bindTo: "row"},
					rowSpan: {bindTo: "rowSpan"},
					imageConfig: {bindTo: "getImageConfig"},
					dragActionsCode: {bindTo: "DragActionsCode"},
					domAttributes: {bindTo: "getDomAttributes"}
				}
			};
			if (controlId === "ProfileContainer") {
				this._generateProfileContainer(result);
			}
			Ext.apply(result, this.getConfigWithoutServiceProperties(config, ["collapseEmptyRow", "allowOverlap"]));
			if (config.controlConfig) {
				delete config.controlConfig.collapseEmptyRow;
				delete config.controlConfig.allowOverlap;
			}
			this.applyControlConfig(result, config);
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateDetail
		 * @override
		 */
		generateDetail: function(config) {
			config.caption = {
				bindTo: config.name + "DetailCaption"
			};
			delete config.detail;
			var container = this.generateControlGroup(config);
			var detail = container.items[0];
			detail.collapsed = true;
			detail.tools = this.generateDetailTools(config);
			if (!Ext.isEmpty(config.visible)) {
				delete detail.visible;
				Ext.apply(detail, this.getExtendedDetailConfig(config));
			}
			return container;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateControlGroup
		 * @override
		 */
		generateControlGroup: function(config) {
			var controlGroup = this.callParent(arguments);
			controlGroup.className = "BPMSoft.ViewModelSchemaDesignerControlGroup";
			controlGroup.caption = controlGroup.caption || " ";
			controlGroup.tools = controlGroup.tools.concat(this.generateGroupTools(config));
			if (Ext.isEmpty(config.name)) {
				return controlGroup;
			}
			var containerConfig = {
				name: config.name,
				items: [controlGroup],
				markerValue: config.caption
			};
			return this.getDraggableContainer(containerConfig);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewGenerator#generateTabContent
		 * @override
		 */
		generateTabContent: function(config) {
			this.addToParentCollection(config);
			var result = this.callParent(arguments);
			var tabTools = this.generateTabTools(config);
			return Ext.apply(result, {
				items: result.items.concat(tabTools),
				className: "BPMSoft.ViewModelSchemaDesignerTabContainer",
				reorderableIndex: {bindTo: config.name + "ReorderableIndex"},
				groupName: config.name + "ReorderableContainer"
			});
		},

		/**
		 * Generates tools elements for tabs.
		 * @protected
		 * @param {Object} config Configuration of group of elements.
		 * @return {Object[]} Generated view of tools elements.
		 */
		generateTabPanelTools: function(config) {
			var configurationButton = this.generateButton({
				name: config.name + "ConfigurationButton",
				caption: "",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Edit)
				},
				classes: {wrapperClass: ["btn-tabPanel-tools-wrapp"]},
				tag: config.name,
				click: {bindTo: "editTab"}
			});
			var removeButton = this.generateButton({
				name: config.name + "removeButton",
				caption: "",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Delete)
				},
				classes: {wrapperClass: ["btn-tabPanel-tools-wrapp"]},
				tag: config.name,
				click: {bindTo: "removeTab"},
				visible: {bindTo: "getTabRemoveButtonVisible"}
			});
			var addButton = this.generateButton({
				name: config.name + "addButton",
				caption: "",
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Add)
				},
				classes: {wrapperClass: ["btn-tabPanel-tools-wrapp"]},
				tag: config.name,
				click: {bindTo: "addTab"}
			});
			return [addButton, configurationButton, removeButton];
		},

		/**
		 * Generates view config for Action Dashboard container
		 * @protected
		 * @param {Object} config Action Dashboard container config.
		 * @return {Object} Configuration of Action Dashboard container.
		 */
		generateActionDashboardContainer: function(config) {
			var id = this.getControlId(config, "BPMSoft.Container");
			var container = this.getDefaultContainerConfig(id, config);
			Ext.apply(container, this.getConfigWithoutServiceProperties(config, ["wrapClass", "styles"]));
			this.generateItemTips(config, container);
			this.applyControlConfig(container, config);
			container.className = "BPMSoft.DesignTimeReorderableContainer";
			if (config.items.length > 0) {
				container.items = container.items.concat(this.generateActionDashboardImageView());
				container.classes.wrapClassName.push("bg-image");
			}
			return container;
		},

		/**
		 * Generates view config for Related Profile container
		 * @protected
		 * @param {Object} config Related Profile container config.
		 * @return {Object} Configuration of Related Profile container.
		 */
		generateRelatedProfileContainer: function(config) {
			var controlId = config.name + "RelatedProfileContainer";
			var viewGenerator = this;
			var result = {
				className: "BPMSoft.DesignTimeReorderableContainer",
				id: controlId,
				viewModelItems: {bindTo: "RelatedProfileItems"},
				reorderableIndex: {bindTo: "RelatedProfileReorderableIndex"},
				classes: {wrapClassName: "leftModulesReordableContainer"},
				getGroupName: function() {
					return controlId;
				},
				getItemConfig: function(viewModelItem) {
					var relatedProfileContainer = this;
					var id = viewModelItem.get("Id");
					var items = viewGenerator.generateRelatedProfileItemConfig(id);
					return {
						className: "BPMSoft.DesignTimeReorderableItem",
						id: id,
						items: items,
						classes: {wrapClassName: ["relatedProfileContainer", "module-bg-img"]},
						ondragenter: {bindTo: "onDragEnter"},
						ondragdrop: {bindTo: "onDragDrop"},
						ondragout: {bindTo: "onDragOut"},
						getGroupName: function() {
							return relatedProfileContainer.getGroupName();
						}
					};
				}
			};
			return result;
		},

		/**
		 * Generates view config for Related Profile Item container.
		 * @protected
		 * @param {String} id Related Profile Item id.
		 * @return {Object} Configuration of Related Profile Item container.
		 */
		generateRelatedProfileItemConfig: function(id) {
			var configItems = [{
				"id": Ext.String.format("EntitySchemaName{0}Caption", id),
				"itemType": BPMSoft.ViewItemType.LABEL,
				"caption": {"bindTo": "entitySchemaName"},
				"labelConfig": {"classes": ["relatedProfileCaption"]}
			}, {
				"id": Ext.String.format("{0}ToolsContainer", id),
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {"wrapClassName": ["relatedProfileTools"]},
				"items": [{
					"id": Ext.String.format("{0}EditButton", id),
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": "edit",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"visible": {"bindTo": "canEdit"},
					"click": {"bindTo": "edit"}
				}, {
					"id": Ext.String.format("{0}RemoveButton", id),
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.DesignerRemoveButtonCaption"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"visible": {"bindTo": "canRemove"},
					"imageConfig": {
						"source": BPMSoft.ImageSources.URL,
						"url": BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Delete)
					},
					"classes": {"wrapperClass": ["related-profile-remove-wrapp"]},
					"click": {"bindTo": "remove"}
				}]
			}];
			var items = [];
			BPMSoft.each(configItems, function(configItem) {
				var item = this.generateItem(configItem);
				items.push(item);
			}, this);
			items.push(this.generateRelatedProfileImageView());
			return items;
		},

		/**
		 * Generates configuration of tools elements of current element is not the grid.
		 * @protected
		 * @param {Object} config Configuration of group of elements.
		 * @return {Object[]} Generated view of tools elements.
		 */
		getModelItemTools: function(config) {
			var configurationButton = this.generateButton({
				name: config.name + "ConfigurationButton",
				imageConfig: {bindTo: "Resources.Images.SettingsImage"},
				visible: {bindTo: "getConfigurationButtonVisible"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				tag: "openModelItemSettingWindow"
			});
			var removeButton = this.generateButton({
				name: config.name + "removeButton",
				imageConfig: {bindTo: "Resources.Images.RemoveImage"},
				visible: {bindTo: "getRemoveButtonVisible"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				tag: "removeModelItem"
			});
			var result = [configurationButton, removeButton];
			return result;
		},

		/**
		 * Generates a configuration setting elements for a group of elements.
		 * @protected
		 * @param {Object} config Configuration of group of elements.
		 * @return {Object[]} Generated view of elements of settings.
		 */
		generateGroupTools: function(config) {
			var configurationButton = this.generateButton({
				name: config.name + "ConfigurationButton",
				caption: {bindTo: "Resources.Strings.DesignerSettingsButtonCaption"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Edit)
				},
				classes: {
					wrapperClass: ["btn-details-tools-wrapp"]
				},
				tag: config.name,
				click: {bindTo: "openGroupSettingWindow"},
				visible: {bindTo: "getGroupConfigurationButtonVisible"}
			});
			var removeButton = this.generateButton({
				name: config.name + "removeButton",
				caption: {bindTo: "Resources.Strings.DesignerRemoveButtonCaption"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Delete)
				},
				classes: {
					wrapperClass: ["btn-details-tools-wrapp"]
				},
				tag: config.name,
				click: {bindTo: "removeGroup"},
				visible: {bindTo: "getGroupRemoveButtonVisible"}
			});
			var result = [configurationButton, removeButton];
			return result;
		},

		/**
		 * Generates a configuration setting items for details.
		 * @protected
		 * @param {Object} config Configuration of group of elements.
		 * @return {Object[]} Generated view of elements of settings.
		 */
		generateDetailTools: function(config) {
			var configurationButton = this.generateButton({
				name: config.name + "ConfigurationButton",
				caption: {bindTo: "Resources.Strings.DesignerSettingsButtonCaption"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Edit)
				},
				classes: {
					wrapperClass: ["btn-details-tools-wrapp"]
				},
				tag: config.name,
				visible: {bindTo: "canEditDetail"},
				click: {bindTo: "openDetailSettingWindow"}
			});
			var removeButton = this.generateButton({
				name: config.name + "removeButton",
				caption: {bindTo: "Resources.Strings.DesignerRemoveButtonCaption"},
				style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
				imageConfig: {
					source: BPMSoft.ImageSources.URL,
					url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.Delete)
				},
				classes: {
					wrapperClass: ["btn-details-tools-wrapp"]
				},
				tag: config.name,
				click: {bindTo: "removeDetail"}
			});
			var result = [configurationButton, removeButton];
			return result;
		},

		/**
		 * Generates configuration of tools elements for one tab.
		 * @protected
		 * @param {Object} config Configuration of tab.
		 * @return {Object[]} Generated view of tools elements.
		 */
		generateTabTools: function(config) {
			var addGroupButton = this.generateButton({
				"name": config.name + "AddGroupButton",
				"caption": {"bindTo": "Resources.Strings.DesignerAddGroupItemCaption"},
				"click": {"bindTo": "openGroupSettingWindow"},
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"classes": {
					"wrapperClass": ["add-group-button"],
					"textClass": ["add-group-button"]
				}
			});
			var addDetailButton = this.generateButton({
				"name": config.name + "AddDetailButton",
				"caption": {"bindTo": "Resources.Strings.DesignerAddDetailItemCaption"},
				"click": {"bindTo": "openDetailSettingWindow"},
				"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
				"classes": {
					"wrapperClass": ["add-detail-button"],
					"textClass": ["add-detail-button"]
				}
			});
			var result = [addGroupButton, addDetailButton];
			return result;
		},

		/**
		 * Returns draggable container.
		 * @protected
		 * @param {Object} config Configuration object.
		 * @param {String} config.name Container name.
		 * @param {Object} config.items Container items.
		 * @param {Object} config.markerValue Container marker value.
		 * @return {String} Draggable container.
		 */
		getDraggableContainer: function(config) {
			var containerId = this.getControlId(config, "BPMSoft.DraggableContainer");
			var container = this.getDefaultContainerConfig(containerId, config);
			return Ext.apply(container, {
				className: "BPMSoft.ViewModelSchemaDesignerTabItem",
				items: config.items,
				ondragenter: {bindTo: "onTabContainerItemDragEnter"},
				ondragout: {bindTo: "onTabContainerItemDragOut"},
				ondragdrop: {bindTo: "onTabContainerItemDragDrop"},
				groupName: this.parentCollection[config.name] + "ReorderableContainer",
				markerValue: config.markerValue
			});
		}

		// endregion

	});

	return Ext.create("BPMSoft.ViewModelSchemaDesignerViewGenerator");
});
