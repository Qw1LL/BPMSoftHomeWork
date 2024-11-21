define("DashboardDesignerV2", ["DashboardDesignerV2Resources", "css!DashboardDesignerV2CSS", "DashboardManager",
	"DashboardDesignerViewGenerator", "CommonCSSV2", "PreviewableGridLayoutEdit"],
function(resources) {
	return {
		messages: {
			"GetHistoryState": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			"PushHistoryState": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetDashboardInfo": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			"BackHistoryState": {
				mode: this.BPMSoft.MessageMode.BROADCAST,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
			"SetDesignerResult": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			"Id": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},
			"Caption": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"isRequired": true
			},
			"SelectedItems": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"Items": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			"Selection": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},
			"Widgets": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			"SectionId": {
				"dataValueType": BPMSoft.DataValueType.GUID
			}
		},
		methods: {

			//region Methods: Private

			////TODO: Move to TipHelper
			showTip: function(config) {
				if (this.tipInstance) {
					this.tipInstance.destroy();
					delete this.tipInstance;
				}
				this.tipInstance = this.Ext.create("BPMSoft.Tip", config);
				this.tipInstance.show();
			},

			/**
			 * Returns items's max row index.
			 * @private
			 * @return {Number} Max row index.
			 */
			getItemsMaxRow: function() {
				var result = 0, items = this.get("Items");
				items.each(function(item) {
					var itemRow = item.get("row");
					var itemRowSpan = item.get("rowSpan");
					result = (result < (itemRow + itemRowSpan)) ? (itemRow + itemRowSpan) : result;
				}, this);
				return result;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Returns dashboard init info.
			 * @protected
			 * @return {Object} Dashboard info.
			 */
			getDashboardInfo: function() {
				return this.sandbox.publish("GetDashboardInfo", null, [this.sandbox.id]);
			},

			/**
			 * Returns current section id.
			 * @protected
			 * @param {String} Section id.
			 */
			getSectionId: function() {
				var sectionInfo = this.getSectionInfo();
				var dashboardSectionModule = BPMSoft.configuration.ModuleStructure.Dashboard.sectionModule;
				return sectionInfo.sectionModule !== dashboardSectionModule && sectionInfo.moduleId;
			},

			/**
			 * Creates new dashboard.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @return {BPMSoft.DashboardManagerItem} New dashboard.
			 */
			createDashboard: function(callback, scope) {
				var createItemConfig = {
					sectionId: this.getSectionId()
				};
				this.BPMSoft.DashboardManager.createItem(createItemConfig, function(item) {
					callback.call(scope, item);
				}, this);
			},

			////TODO: Move to WidgetDesignerHelper
			getWidgetImageConfig: function(widgetType) {
				return this.get("Resources.Images." + widgetType + "WidgetImage");
			},

			/**
			 * Creates grid layout edit item view model.
			 * @protected
			 * @param {Object} viewConfigItem Widget layouting config.
			 * @param {Object} widgetConfig Widget config.
			 * @return {BPMSoft.BaseViewModel} Grid layout edit item view model.
			 */
			createWidgetGridLayoutEditItemViewModel: function(viewConfigItem, widgetConfig) {
				var itemConfig = this.Ext.apply({
					itemId: viewConfigItem.name,
					imageConfig: this.getWidgetImageConfig(widgetConfig.widgetType),
					widgetConfig: widgetConfig,
					itemType: viewConfigItem.itemType,
					content: widgetConfig.parameters && widgetConfig.parameters.caption
				}, viewConfigItem.layout);
				return this.Ext.create("BPMSoft.BaseViewModel", {
					values: itemConfig
				});
			},

			/**
			 * Inits dashboard widgets.
			 * @protected
			 * @param {BPMSoft.DashboardManagerItem} dashboardManagerItem Dashboard.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initItems: function(dashboardManagerItem, callback, scope) {
				var items = this.Ext.create("BPMSoft.BaseViewModelCollection");
				dashboardManagerItem.loadLazyPropertiesData(function() {
					var widgets = dashboardManagerItem.getItems();
					var viewConfig = dashboardManagerItem.getViewConfig();
					this.BPMSoft.each(viewConfig, function(viewConfigItem) {
						var itemName = viewConfigItem.name;
						var widgetConfig = widgets[itemName];
						var widget = this.createWidgetGridLayoutEditItemViewModel(viewConfigItem, widgetConfig);
						this.subscribeWidgetModuleConfigMessage(widget);
						items.add(itemName, widget);
					}, this);
					this.set("Items", items);
					callback.call(scope);
				}, this);
			},

			getWidgetModuleConfig: function(item) {
				var widgetConfig = item.get("widgetConfig");
				var widgetTypeConfig = BPMSoft.DashboardEnums.WidgetType[widgetConfig.widgetType];
				var config = Ext.apply({}, widgetTypeConfig.view, widgetConfig);
				config.moduleName = config.moduleName || (config.parameters && config.parameters.moduleName);
				return config;
			},

			registerWidgetModuleMessages: function(item) {
				var widgetModuleConfig = this.getWidgetModuleConfig(item);
				var messages = {};
				var configurationMessage = widgetModuleConfig.configurationMessage ||
					widgetModuleConfig.parameters.configurationMessage;
				messages[configurationMessage] = {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				};
				this.sandbox.registerMessages(messages);
			},

			getWidgetModuleConfigurationMessage: function(widget) {
				var config = this.getWidgetModuleConfig(widget);
				return config.configurationMessage || config.parameters.configurationMessage;
			},

			subscribeWidgetModuleConfigMessage: function(widget) {
				this.registerWidgetModuleMessages(widget);
				var configurationMessage = this.getWidgetModuleConfigurationMessage(widget);
				this.sandbox.subscribe(configurationMessage, function() {
					var config = widget.get("widgetConfig");
					var parameters = config.parameters.parameters || config.parameters;
					return parameters;
				}, [widget.get("itemId")]);
			},

			getSaveData: function() {
				var items = this.get("Items");
				var viewConfig = [];
				var widgets = {};
				items.each(function(item) {
					var itemId = item.get("itemId");
					var viewConfigItem = {
						"name": itemId,
						"itemType": item.get("itemType"),
						"layout": {
							"row": item.get("row"),
							"rowSpan": item.get("rowSpan"),
							"column": item.get("column"),
							"colSpan": item.get("colSpan")
						}
					};
					viewConfig.push(viewConfigItem);
					widgets[itemId] = item.get("widgetConfig");
				}, this);
				return {
					widgets: widgets,
					viewConfig: viewConfig
				};
			},

			getWidgets: function() {
				var result = [];
				var self = this;
				this.BPMSoft.each(this.BPMSoft.DashboardEnums.WidgetType, function(widgetConfig, widgetType) {
					result.push({
						className: "BPMSoft.Button",
						caption: widgetType,
						imageConfig: this.getWidgetImageConfig(widgetType),
						tag: widgetType,
						onClick: function() {
							self.openWidgetDesigner(widgetType);
						}
					});
				}, this);
				return result;
			},

			getSelectedItem: function() {
				var result;
				var selectedItems = this.get("SelectedItems");
				var selectedItemName = selectedItems && selectedItems[0];
				if (!this.Ext.isEmpty(selectedItemName)) {
					var items = this.get("Items");
					result = items.get(selectedItemName);
				}
				return result;
			},

			generageItemName: function() {
				return this.BPMSoft.generateGUID();
			},

			createNewWidget: function(config) {
				var itemName = this.generageItemName();
				var viewConfigItem = {
					name: itemName,
					layout: config.selection,
					itemType: BPMSoft.ViewItemType.MODULE
				};
				var widgetConfig = {
					parameters: config.widgetConfig,
					widgetType: config.widgetType
				};
				var widget = this.createWidgetGridLayoutEditItemViewModel(viewConfigItem, widgetConfig);
				this.subscribeWidgetModuleConfigMessage(widget);
				var items = this.get("Items");
				items.add(itemName, widget);
			},

			registerWidgetTypeMessages: function() {
				var messages = {};
				var ptpSubscribeConfig = {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				};
				BPMSoft.each(BPMSoft.DashboardEnums.WidgetType, function(typeConfig) {
					var deisgnTimeConfig = typeConfig.design;
					messages[deisgnTimeConfig.configurationMessage] = ptpSubscribeConfig;
					messages[deisgnTimeConfig.resultMessage] = ptpSubscribeConfig;
				}, this);
				this.sandbox.registerMessages(messages);
			},

			editWidget: function(widgetViewModel) {
				var widgetConfig = widgetViewModel.get("widgetConfig");
				this.openWidgetDesigner(widgetConfig.widgetType);
			},

			copyWidget: function(widgetViewModel) {
				var itemName = this.BPMSoft.generateGUID();
				var viewConfigItem = {
					name: itemName,
					layout: {
						row: this.getItemsMaxRow(),
						rowSpan: widgetViewModel.get("rowSpan"),
						column: 0,
						colSpan: widgetViewModel.get("colSpan")
					},
					itemType: BPMSoft.ViewItemType.MODULE
				};
				var widgetConfig = widgetViewModel.get("widgetConfig");
				var widget = this.createWidgetGridLayoutEditItemViewModel(viewConfigItem, widgetConfig);
				this.subscribeWidgetModuleConfigMessage(widget);
				var items = this.get("Items");
				items.add(itemName, widget);
			},

			onWidgetPreviewReady: function(previewId, itemId) {
				var items = this.get("Items");
				var item = items.get(itemId);
				var moduleConfig = item.get("widgetConfig");
				var moduleName = (moduleConfig.parameters && moduleConfig.parameters.moduleName) ||
					BPMSoft.DashboardEnums.WidgetType[moduleConfig.widgetType].view.moduleName;
				this.sandbox.loadModule(moduleName, {
					renderTo: previewId,
					id: itemId
				});
			},

			onWidgetActionClick: function(tag) {
				var selectedItem = this.getSelectedItem();
				switch (tag) {
					case "edit":
						this.editWidget(selectedItem);
						break;
					case "copy":
						this.copyWidget(selectedItem);
						break;
					case "remove":
						var items = this.get("Items");
						items.remove(selectedItem);
						break;
				}
			},

			onItemDblClick: function() {
				var selectedItem = this.getSelectedItem();
				this.editWidget(selectedItem);
			},

			onSaveButtonClick: function() {
				if (!this.validate()) {
					return;
				}
				this.showBodyMask();
				var dashboardManagerItem = this.get("DashboardManagerItem");
				var saveData = this.getSaveData();
				dashboardManagerItem.setCaption(this.get("Caption"));
				dashboardManagerItem.setViewConfig(saveData.viewConfig);
				dashboardManagerItem.setItems(saveData.widgets);
				dashboardManagerItem.save(function() {
					if (dashboardManagerItem.getIsNew()) {
						this.BPMSoft.DashboardManager.addItem(dashboardManagerItem);
					}
					this.sandbox.publish("SetDesignerResult", {
						dashboardId: dashboardManagerItem.getId()
					}, [this.sandbox.id]);
					this.sandbox.publish("BackHistoryState");
				}, this);
			},

			onCancelButtonClick: function() {
				this.showBodyMask();
				this.sandbox.publish("BackHistoryState");
			},

			onSelectionEnded: function(event) {
				this.showTip({
					displayMode: BPMSoft.controls.TipEnums.displayMode.WIDE,
					content: "Select Widget",
					alignToEl: this.Ext.get(event.target),
					items: this.getWidgets()
				});
			},

			onGetWidgetDesignerConfig: function() {
				var result = {sectionId: this.get("SectionId")};
				var selectedItem = this.getSelectedItem();
				if (selectedItem) {
					var widgetConfig = selectedItem.get("widgetConfig");
					this.Ext.apply(result, widgetConfig.parameters);
				}
				this.hideBodyMask();
				return result;
			},

			onSaveWidgetConfig: function(config) {
				var item = config.item;
				if (item) {
					var newWidgetConfig = config.widgetConfig;
					item.set("content", newWidgetConfig.caption);
					var widgetConfig = item.get("widgetConfig");
					widgetConfig.parameters = newWidgetConfig;
				} else {
					this.createNewWidget(config);
				}
			},

			//endregion

			//region Methods: Public

			openWidgetDesigner: function(widgetType) {
				this.showBodyMask();
				var selectedItem = this.getSelectedItem();
				var selection = this.get("Selection");
				var widgetTypeConfig = this.BPMSoft.DashboardEnums.WidgetType[widgetType];
				var widgetTypeDesignerConfig = widgetTypeConfig.design;
				var moduleId = this.sandbox.id + "_" + widgetTypeDesignerConfig.moduleName;
				this.sandbox.subscribe(widgetTypeDesignerConfig.configurationMessage, this.onGetWidgetDesignerConfig,
					this, [moduleId]);
				this.sandbox.subscribe(widgetTypeDesignerConfig.resultMessage, function(widgetConfig) {
					var config = {
						widgetConfig: widgetConfig,
						item: selectedItem,
						widgetType: widgetType,
						selection: selection
					};
					this.onSaveWidgetConfig(config);
				}, this, [moduleId]);
				var historyState = this.sandbox.publish("GetHistoryState");
				var moduleState = Ext.apply({hash: historyState.hash.historyState}, widgetTypeDesignerConfig.stateConfig);
				this.sandbox.publish("PushHistoryState", moduleState);
				this.sandbox.loadModule(widgetTypeDesignerConfig.moduleName, {
					"renderTo": this.renderTo,
					"id": moduleId,
					"keepAlive": true
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init.
			 * @protected
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.BPMSoft.chain(
						function(next) {
							this.registerWidgetTypeMessages();
							this.BPMSoft.DashboardManager.initialize("", next, this);
						},
						function(next) {
							var dashboardInfo = this.getDashboardInfo();
							var dashboardId = dashboardInfo && dashboardInfo.dashboardId;
							if (dashboardId) {
								var dashboardItem = this.BPMSoft.DashboardManager.getItem(dashboardId);
								next(dashboardItem);
							} else {
								this.createDashboard(next, this);
							}
						},
						function(next, dashboardItem) {
							this.initItems(dashboardItem, function() {
								this.set("DashboardManagerItem", dashboardItem);
								this.set("Caption", dashboardItem.getCaption());
								callback.call(scope || this);
							}, this);
						},
						this
					);
				}, this]);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DashboardDesignerContainer",
				"values": {
					"id": "DashboardDesignerContainer",
					"selectors": {"wrapEl": "#DashboardDesignerContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DashboardDesignerHeader",
				"parentName": "DashboardDesignerContainer",
				"propertyName": "items",
				"index": "0",
				"values": {
					"id": "DashboardDesignerHeader",
					"selectors": {"wrapEl": "#DashboardDesignerHeader"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DashboardDesignerHeaderButtons",
				"parentName": "DashboardDesignerHeader",
				"propertyName": "items",
				"index": "0",
				"values": {
					"id": "DashboardDesignerHeaderButtons",
					"selectors": {"wrapEl": "#DashboardDesignerHeaderButtons"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-header-buttons"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SaveButton",
				"parentName": "DashboardDesignerHeaderButtons",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"click": {"bindTo": "onSaveButtonClick"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE
				}
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "DashboardDesignerHeaderButtons",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"click": {"bindTo": "onCancelButtonClick"}
				}
			},
			{
				"operation": "insert",
				"name": "DashboardDesignerHeaderInputs",
				"parentName": "DashboardDesignerHeader",
				"propertyName": "items",
				"index": "1",
				"values": {
					"id": "DashboardDesignerHeaderInputs",
					"selectors": {"wrapEl": "#DashboardDesignerHeaderInputs"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-header-inputs"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "DashboardDesignerHeaderInputs",
				"propertyName": "items",
				"name": "DashboardCaption",
				"values": {
					"bindTo": "Caption",
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.DashboardCaption"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DashboardDesignerFooter",
				"parentName": "DashboardDesignerContainer",
				"propertyName": "items",
				"index": "1",
				"values": {
					"id": "DashboardDesignerFooter",
					"selectors": {"wrapEl": "#DashboardDesignerFooter"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-footer"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DashboardDesignerGrid",
				"parentName": "DashboardDesignerFooter",
				"propertyName": "items",
				"index": "1",
				"values": {
					"id": "DashboardDesignerGrid",
					"selectors": {"wrapEl": "#DashboardDesignerGrid"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["dashboard-designer-grid"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DashboardGrid",
				"propertyName": "items",
				"parentName": "DashboardDesignerGrid",
				"values": {
					"generator": "DashboardDesignerViewGenerator.generateGridLayout",
					"className": "BPMSoft.PreviewableGridLayouEdit",
					"id": "DashboardGrid",
					"itemClassName": "BPMSoft.PreviewableGridLayoutEditItem",
					"selectors": {"wrapEl": "#DashboardGrid"},
					"items": {"bindTo": "Items"},
					"selection": {"bindTo": "Selection"},
					"selectedItems": {"bindTo": "SelectedItems"},
					"tag": "DashboardGrid",
					"autoHeight": true,
					"maxRows": 250,
					"minRows": 100,
					"autoWidth": false,
					"multipleSelection": false,
					"allowItemsIntersection": false,
					"columns": 24,
					"markerValue": "DashboardGrid",
					"useManualSelection": true,
					"itemBindingConfig": {
						"itemId": {"bindTo": "itemId"},
						"markerValue": {"bindTo": "content"},
						"content": {"bindTo": "content"},
						"column": {"bindTo": "column"},
						"colSpan": {"bindTo": "colSpan"},
						"row": {"bindTo": "row"},
						"rowSpan": {"bindTo": "rowSpan"},
						"imageConfig": {"bindTo": "imageConfig"}
					},
					"selectionEnded": {"bindTo": "onSelectionEnded"},
					"previewReady": {
						"bindTo": "onWidgetPreviewReady"
					},
					"itemActions": [
						{
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "edit",
							////TODO: to Resources
							"hint": "Edit",
							"imageConfig": resources.localizableImages.ItemEditButtonImage
						},
						{
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "copy",
							////TODO: to Resources
							"hint": "Copy",
							"imageConfig": resources.localizableImages.ItemCopyButtonImage
						},
						{
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "remove",
							////TODO: to Resources
							"hint": "Remove",
							"imageConfig": resources.localizableImages.ItemRemoveButtonImage
						}
					],
					"itemActionClick": {"bindTo": "onWidgetActionClick"},
					"itemDblClick": {"bindTo": "onItemDblClick"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
