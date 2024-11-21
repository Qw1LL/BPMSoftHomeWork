/**
 * Parent: ViewModelSchemaDesignerSchema
 */
define("PageDesignerSchema", ["ModalBox", "PageDesignerButtonItemModel", "css!ElementPropertiesModule"
], function(ModalBox) {
	return {
		messages: {
			"GetDesignSchema": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SaveButtonConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * Page header caption.
			 * @type {String}
			 */
			"PageHeaderCaption": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			/**
			 * Collection of process action buttons.
			 */
			"ProcessActionButtons": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Current editing designed schema element.
			 */
			"ActionLayoutItem": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Flag that indicates whether current editing button is new or not.
			 */
			"IsNewButton": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Button reorderable index.
			 */
			"ButtonReorderableIndex": {
				dataValueType: BPMSoft.DataValueType.INTEGER
			},
			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#createEntityDataModel
			 * @override
			 */
			"SupportParametersDataModel": {
				value: true
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_updateHeader: function() {
				var schema = this.$PageSchema;
				if (schema) {
					this.$PageHeaderCaption = schema.caption && schema.caption.getValue() || schema.name;
				}
			},

			/**
			 * @private
			 */
			_subscribeSchemaChanged: function() {
				this.$PageSchema.on("changed", this._updateHeader, this);
			},

			/**
			 * @private
			 */
			_initProcessActionButtons: function(callback, scope) {
				var container = this.getSchemaViewItem("ProcessActionButtons");
				var items = this.$ProcessActionButtons = new BPMSoft.BaseViewModelCollection();
				if (!container) {
					Ext.callback(callback, scope);
					return;
				}
				var buttons = BPMSoft.filter(container.items, {itemType: BPMSoft.ViewItemType.BUTTON});
				BPMSoft.each(buttons, function(config) {
					var visible = this._getButtonConfigVisible(config);
					if (visible) {
						var modelValues = this._getButtonModelValues(config);
						var model = this._createButtonModel(modelValues);
						items.add(config.name, model);
					}
				}, this);
				items.on("move", this.onMoveButton, this);
				var parameter = this.$PageSchema.findParameterByName("Buttons");
				if (parameter) {
					const instanceConfig = {schemaUId: this.$PageSchema.uId, packageUId: this.$PageSchema.packageUId};
					BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(instanceConfig, (item) => {
						this._applyButtonsParameterInfo(parameter, item);
						Ext.callback(callback, scope);
					});
				} else {
					Ext.callback(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_applyButtonsParameterInfo: function(parameter, schema) {
				var value = BPMSoft.decode(parameter.getValue() || "{}");
				var parameterButtons = value && value.$values || [];
				parameterButtons.forEach(function(info) {
					var button = this.$ProcessActionButtons.findByFn(function(item) {
						return item.$Tag === info.Tag.value;
					}, this);
					if (button) {
						const buttonResourceKey = this._generateButtonCaptionResourcesName(button.$Tag);
						const captionLcz = schema.localizableStrings.find(buttonResourceKey);
						if (captionLcz) {
							button.$Caption = captionLcz.getValue();
							button.$CaptionLcz = captionLcz;
						} else {
							button.$Caption = info.Caption ? info.Caption.value : "";
						}
						button.$PerformClosePage = !!info.PerformClosePage && info.PerformClosePage.value === "True";
						button.$PerformSaveData = !!info.PerformSaveData && info.PerformSaveData.value === "True";
						button.$GenerateSignal = info.GenerateSignal ? info.GenerateSignal.value : "";
					}
				}, this);
			},

			/**
			 * @private
			 */
			_createButtonModel: function(modelValues) {
				var model = new BPMSoft.PageDesignerButtonItemModel({
					designSchema: this,
					values: modelValues,
					methods: {
						"onEditClick": this._onEditPageDesignerButtonItemModel,
						"onRemoveClick": this._onRemovePageDesignerButtonItemModel,
						"onSelect": this._onSelectPageDesignerButtonItemModel
					}
				});
				return model;
			},

			/**
			 * @private
			 */
			_getButtonModelValues: function(config) {
				var values = {};
				var properties = ["Id", "Name", "Tag", "Caption", "Style", "Enabled"];
				properties.forEach(function(property) {
					values[property] = this._getButtonConfigProperty(config, property);
				}, this);
				return values;
			},

			/**
			 * @private
			 */
			_getButtonConfigCaption: function(config) {
				var captionResourcesName = this.getCaptionResourcesName(config.name);
				var noCaptionResourceName = "Resources.Strings.NoCaptionButtonCaption";
				return this.get(captionResourcesName) || config.caption || this.get(noCaptionResourceName);
			},

			/**
			 * @private
			 */
			_getButtonConfigEnabled: function(config) {
				var isEnabledBoolean = Ext.isDefined(config.enabled) && Ext.isBoolean(config.enabled);
				return isEnabledBoolean ? config.enabled : true;
			},

			/**
			 * @private
			 */
			_getButtonConfigVisible: function(config) {
				var isVisibleBoolean = Ext.isDefined(config.visible) && Ext.isBoolean(config.visible);
				return isVisibleBoolean ? config.visible : true;
			},

			/**
			 * @private
			 */
			_getButtonConfigStyle: function(config) {
				return config.style || BPMSoft.controls.ButtonEnums.style.DEFAULT;
			},

			/**
			 * @private
			 */
			_getButtonConfigProperty: function(config, property) {
				var result;
				switch (property) {
					case "Id":
						result = config.id || BPMSoft.generateGUID();
						break;
					case "Name":
						result = config.name;
						break;
					case "Tag":
						result = config.tag || config.name;
						break;
					case "Caption":
						result = this._getButtonConfigCaption(config);
						break;
					case "Style":
						result = this._getButtonConfigStyle(config);
						break;
					case "Enabled":
						result = this._getButtonConfigEnabled(config);
						break;
					default:
						throw new BPMSoft.UnsupportedTypeException();
				}
				return result;
			},

			/**
			 * @private
			 */
			_onEditPageDesignerButtonItemModel: function() {
				this.designSchema.$ActionLayoutItem = this;
				this.designSchema.$IsNewButton = false;
				this.designSchema._loadButtonPropertiesPage();
			},

			/**
			 * @private
			 */
			_onRemovePageDesignerButtonItemModel: function() {
				var diff = [{
					"operation": "remove",
					"name": this.$Name
				}];
				var designSchema = this.designSchema;
				var actionButtons = designSchema.$ProcessActionButtons;
				actionButtons.remove(this);
				designSchema.onSchemaChanged(diff);
			},

			/**
			 * @private
			 */
			_insertButtonModel: function(item) {
				var autoBindColumns = BPMSoft.filterObject(item.columns, {"autoBind": true});
				var values = _.mapObject(autoBindColumns, function(column, columnName) {
					return item.get(columnName);
				}, this);
				var model = this._createButtonModel(values);
				this.$ProcessActionButtons.add(item.$Name, model);
				model.onSelect();
			},

			/**
			 * @private
			 */
			_generateButtonCaptionResourcesName: function(buttonTag) {
				return buttonTag + "ButtonCaption";
			},

			/**
			 * @private
			 */
			_insertButton: function(captionBindConfig) {
				var item = this.$ActionLayoutItem;
				this._insertButtonModel(item);
				const clickBindTo = this._getButtonClickBindTo();
				var diff = {
					"operation": "insert",
					"parentName": "ProcessActionButtons",
					"propertyName": "items",
					"name": item.$Name,
					"index": this.$ProcessActionButtons.getCount(),
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"id": item.$Id,
						"style": item.$Style,
						"tag": item.$Tag,
						"caption": captionBindConfig,
						"click": {"bindTo": clickBindTo},
						"enabled": item.$Enabled
					}
				};
				this.onSchemaChanged([diff]);
			},

			/**
			 * 
			 * @private
			 */
			_getButtonClickBindTo: function() {
				if (BPMSoft.Features.getIsEnabled("DisablePreconfiguredPageValidateAndSave")) {
					return "onProcessActionButtonClick";
				}
				const item = this.$ActionLayoutItem;
				if (item.$PerformClosePage) {
					if (item.$PerformSaveData) {
						return "onSaveButtonClick";
					} else {
						return "onCancelProcessElementClick";
					}
				} else {
					return "onCloseClick";
				}
			},

			/**
			 * @private
			 */
			_mergeButton: function(captionBindConfig) {
				const item = this.$ActionLayoutItem;
				const clickBindTo = this._getButtonClickBindTo(); 
				const diff = {
					"operation": "merge",
					"name": item.$Name,
					"values": {
						"id": item.$Id,
						"style": item.$Style,
						"tag": item.$Tag,
						"caption": captionBindConfig,
						"click": {"bindTo": clickBindTo},
						"enabled": item.$Enabled
					}
				};
				this.onSchemaChanged([diff]);
			},

			/**
			 * @private
			 */
			_onSelectPageDesignerButtonItemModel: function() {
				BPMSoft.each(this.designSchema.$ProcessActionButtons, function(button) {
					button.$Selected = button.$Name === this.$Name;
				}, this);
			},

			/**
			 * @private
			 */
			_openButtonSetting: function () {
				const moduleId = this.getButtonModuleId();
				const renderTo = ModalBox.show({
					widthPixels: 550,
					heightPixels: 610,
				}, function() {
					this.sandbox.unloadModule(moduleId);
				}, this);
				this.sandbox.loadModule("ButtonPropertiesPageModule", {
					id: moduleId,
					renderTo: renderTo
				});
			},

			/**
			 * @private
			 */
			_loadButtonPropertiesPage: function() {
				if (BPMSoft.Features.getIsDisabled("DisableButtonPropertiesPage")) {
					this._openButtonSetting();
				} else {
					var sandbox = this.sandbox;
					var moduleId = this.getButtonModuleId();
					var modalBoxClass = "button-properties-page";
					var modalBoxConfig = {
						widthPixels: 356,
						heightPixels: 550,
						boxClasses: ["base-element-properties-page", modalBoxClass]
					};
					var maskId = BPMSoft.Mask.show();
					var modalBox = this.getModalBox();
					var renderTo = modalBox.show(modalBoxConfig, function() {
						this.sandbox.unloadModule(moduleId);
					}, this);
					BPMSoft.Mask.hide(maskId);
					maskId = BPMSoft.Mask.show({selector: "#" + renderTo.id});
					var config = {
						id: moduleId,
						renderTo: renderTo.id,
						instanceConfig: {
							schemaName: "ButtonPropertiesPage",
							maskId: maskId
						}
					};
					sandbox.loadModule("ElementPropertiesModule", config);
				}
			},

			/**
			 * @private
			 */
			_createButtonDraggableItem: function() {
				return new BPMSoft.SchemaButtonDesignToolItem({
					designItemClassName: "BPMSoft.PageDesignerButtonItemModel",
					caption: this.get("Resources.Strings.NewElementButtonCaption"),
					values: {
						Name: "Button",
						draggableGroupNames: ["ProcessActionButtons_ReorderableContainer"]
					},
					sandbox: {id: this.sandbox.id}
				});
			},

			/**
			 * @private
			 */
			_addButtonToDesignSchema: function(item) {
				this.$ActionLayoutItem = item.createDesignItem(this);
				this.$IsNewButton = true;
				this._loadButtonPropertiesPage();
			},

			/**
			 * @private
			 */
			_createButtonsParameter: function() {
				var parameter = new BPMSoft.ClientUnitSchemaParameter({
					name: "Buttons",
					caption: new BPMSoft.LocalizableString(this.get("Resources.Strings.ButtonsParameterCaption")),
					dataValueType: BPMSoft.DataValueType.LOCALIZABLE_PARAMETER_VALUES_LIST
				});
				this.$PageSchema.parameters.add(parameter.uId, parameter);
				return parameter;
			},

			/**
			 * @private
			 */
			_saveButtonsParameter: function() {
				var parameter = this.$PageSchema.findParameterByName("Buttons");
				if (!parameter) {
					parameter = this._createButtonsParameter();
				}
				var values = this.$ProcessActionButtons.mapArray(function(item) {
					return {
						ItemUId: item.$Id,
						Id: {
							value: item.$Id
						},
						Name: {
							value: item.$Name
						},
						Tag: {
							value: item.$Tag
						},
						Caption: {
							isLczValue: true,
							value: item.$Caption
						},
						PerformClosePage: {
							value: item.$PerformClosePage ? "True" : "False"
						},
						PerformSaveData: {
							value: item.$PerformSaveData ? "True" : "False"
						},
						GenerateSignal: {
							value: item.$GenerateSignal || ""
						}
					};
				}, this);
				parameter.setLocalizableParameterValues(values);
			},

			/**
			 * @private
			 */
			_saveButtonCaption: function(item) {
				let captionBindConfig = {"bindTo": "getProcessActionButtonCaption"};
				if (item.$CaptionLcz) {
					const utils = BPMSoft.ViewModelSchemaDesignerUtils;
					const resourceName = this._generateButtonCaptionResourcesName(item.$Tag);
					const modelStringResourceName = utils.getModelStringResourceName(resourceName);
					this.updateItemLabelCaptionResource(resourceName, item.$CaptionLcz);
					captionBindConfig = {"bindTo": modelStringResourceName};
				}
				return captionBindConfig;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					if (!this.canDesignSchema()) {
						Ext.callback(callback, scope);
						return;
					}
					this.sandbox.subscribe("GetDesignSchema", function() {
						return this;
					}, this);
					this._updateHeader();
					this.$IsSeparateMode = true;
					this._subscribeSchemaChanged();
					this.initNewElementDraggableItems();
					this.initElements(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#createEntityDataModel
			 * @override
			 */
			createEntityDataModel: function() {
				var viewModel = this.callParent(arguments);
				viewModel.set("IsDataModelMenuVisible", true);
				return viewModel;
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#canDesignSchema
			 * @override
			 */
			canDesignSchema: function() {
				return this.callParent(arguments) || this.isReadOnly;
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#canRemoveTab
			 * @override
			 */
			canRemoveTab: function(tabName) {
				return Boolean(tabName) && this.$TabsCollection.getCount() > 0;
			},

			/**
			 * Returns module identifier for button properties page.
			 * @protected
			 * @return {String}
			 */
			getButtonModuleId: function() {
				return this.sandbox.id + "_button";
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("SaveButtonConfig", this.onSaveButtonConfig, this, [this.getButtonModuleId()]);
			},

			/**
			 * @inheritdoc BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				var schema = this.$PageSchema;
				if (schema) {
					schema.un("changed", this._updateHeader, this);
				}
				var buttons = this.$ProcessActionButtons;
				if (buttons) {
					buttons.un("move", this.onMoveButton, this);
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#saveDesignData
			 * @override
			 */
			saveDesignData: function() {
				this._saveButtonsParameter();
				this.callParent(arguments);
			},

			/**
			 * Handler for SaveButtonConfig message.
			 * @protected
			 */
			onSaveButtonConfig: function() {
				var item = this.$ActionLayoutItem;
				const captionBindConfig = this._saveButtonCaption(item);
				if (this.$IsNewButton) {
					this._insertButton(captionBindConfig);
				} else {
					this._mergeButton(captionBindConfig);
				}
			},

			/**
			 * Handler for move button of ProcessActionButtons collection.
			 * @protected
			 * @param {Number} positionFrom Position move from.
			 * @param {Number} positionTo Position move to.
			 * @param {String} key Item key.
			 */
			onMoveButton: function(positionFrom, positionTo, key) {
				if (positionFrom === positionTo) {
					return;
				}
				var diff = {
					"operation": "move",
					"name": key,
					"parentName": "ProcessActionButtons",
					"propertyName": "items",
					"index": positionTo
				};
				this.onSchemaChanged([diff]);
			},

			/**
			 * Init collection of new elements for drag and drop.
			 * @protected
			 */
			initNewElementDraggableItems: function() {
				var collection = new BPMSoft.BaseViewModelCollection();
				var buttonItem = this._createButtonDraggableItem();
				collection.add(BPMSoft.generateGUID(), buttonItem);
				collection.on("itemChanged", this.onElementDraggableItemChanged, this);
				var dataModel = this.$DataModels.get("Elements");
				dataModel.set("NewElementDraggableItems", collection);
			},

			/**
			 * Draggable item change event handler.
			 * @protected
			 * @param {BPMSoft.SchemaDesignToolItem} item Draggable item.
			 * @param {Object} config Event config.
			 */
			onElementDraggableItemChanged: function(item, config) {
				if (config.operation === "DragDrop") {
					this._addButtonToDesignSchema(item);
				}
			},

			/**
			 * Init designed schema view elements.
			 * @protected
			 */
			initElements: function(callback, scope) {
				this._initProcessActionButtons(callback, scope);
			},

			/**
			 * Handler for ProcessActionButtons mouse down event. Clears buttons selection.
			 * @protected
			 */
			onProcessActionButtonsMouseDown: function() {
				this.$ProcessActionButtons.each(function(button) {
					button.$Selected = false;
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.ViewModelSchemaDesignerSchema#getDetailEntitySchema
			 * @override
			 */
			getDetailEntitySchema: function() {
				return this.get("PageSchema");
			},

			// endregion

			// region Methods: Public

			/**
			 * Handler change header.
			 * @param {String} caption Caption
			 */
			onHeaderChange: function(caption) {
				this.$PageSchema.setLocalizableStringPropertyValue("caption", caption);
				var stepCaption = this.get("Resources.Strings.PageDesignerStepCaption");
				document.title = Ext.String.format("{0}: {1}", caption, stepCaption);
			},

			/**
			 * Return ModalBox instance.
			 * @return {BPMSoft.ModalBox}
			 */
			getModalBox: function() {
				return ModalBox;
			}

			// endregion

		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		infoDiff: [],
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "DesignContainer",
				"name": "MainHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "mainHeaderContainer",
					"selectors": {"wrapEl": "#mainHeaderContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-header", "fixed"],
					"items": [],
					"tips": []
				}
			},
			{
				"operation": "insert",
				"name": "RightHeaderContainer",
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "right-header-container",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["right-header-container-class"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PageHeaderContainer",
				"parentName": "RightHeaderContainer",
				"propertyName": "items",
				"values": {
					"id": "PageHeaderContainer",
					"selectors": {"wrapEl": "#PageHeaderContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["page-header-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PageHeaderCaption",
				"parentName": "PageHeaderContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"itemType": BPMSoft.ViewItemType.TEXT,
					"markerValue": "PageHeaderCaption",
					"change": {"bindTo": "onHeaderChange"},
					"controlConfig": {"className": "BPMSoft.TextEdit"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
