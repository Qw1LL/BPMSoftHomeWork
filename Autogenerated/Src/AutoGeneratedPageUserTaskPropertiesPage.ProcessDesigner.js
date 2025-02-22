﻿/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("AutoGeneratedPageUserTaskPropertiesPage", ["AutoGeneratedPageUserTaskPropertiesPageResources",
		"ProcessUserTaskConstants", "ProcessSchemaUserTaskUtilities", "BPMSoft", "ConfigurationItemGenerator",
		"MappingEditMixin", "ProcessSchemaParameterEditModule", "FilterModuleMixin", "ProcessMiniEditPageMixin",
		"AutoGeneratedPageUserTaskElementViewModel", "AutoGeneratedPageUserTaskButtonViewModel",
		"ProcessEntryPointPropertiesPageMixin"
	],
	function(resources, processUserTaskConstants, processSchemaUserTaskUtilities) {
		return {
			mixins: {
				mappingEdit: "BPMSoft.MappingEditMixin",
				processEntryPointPropertiesPageMixin: "BPMSoft.ProcessEntryPointPropertiesPageMixin"
			},
			attributes: {
				/**
				 * Title property.
				 */
				"Title": {
					"dataValueType": BPMSoft.DataValueType.MAPPING,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"doAutoSave": true
				},
				/**
				 * Recommendation property.
				 */
				"Recommendation": {
					"isRequired": false,
					"initMethod": "initProperty"
				},
				/**
				 * Process element buttons.
				 */
				"Buttons": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isCollection": true
				},
				/**
				 * Is new flag.
				 */
				"IsNew": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},
				/**
				 * Process element page elements.
				 */
				"Elements": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isCollection": true
				},
				/**
				 * Entity schema identifier.
				 */
				"EntitySchemaUId": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"referenceSchemaName": "SysSchema",
					"doAutoSave": true
				},
				/**
				 * Entity property.
				 */
				"EntityId": {
					"dataValueType": BPMSoft.DataValueType.MAPPING,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"doAutoSave": true,
					"initMethod": "initProperty"
				},
				/**
				 * Collection of add element menu button.
				 */
				"AddElementButtonMenu": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},
				/**
				 * Indicates whether buttons tool button is enabled.
				 */
				"IsButtonToolsButtonEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				},
				/**
				 * Indicates whether add element button is enabled.
				 */
				"IsAddElementButtonEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": true
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseUserTaskPropertiesPage#getSupportsTechnicalActivity
				 * @override
				 */
				getSupportsTechnicalActivity: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
				 * @override
				 */
				getParameterReferenceSchemaUId: function(elementParameter) {
					return this.mixins.processEntryPointPropertiesPageMixin
						.getParameterReferenceSchemaUId.call(this, elementParameter);
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
				 * @protected
				 * @overridden
				 */
				initParameters: function(processElement) {
					this.callParent(arguments);
					this.initTitle(processElement);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						this.initButtons(element);
						this.initElements(element, function() {
							var addButtonMenu = this.createPageElementAddButtonMenu();
							this.set("AddElementButtonMenu", addButtonMenu);
							this.initEntitySchemas(function() {
								this.initEntitySchema(element, callback, scope);
							}, this);
						}, this);
					}, this]);
				},

				/**
				 * Sets "Title" attribute.
				 * @private
				 * @param {BPMSoft.ProcessUserTaskSchema} processElement Process element.
				 */
				initTitle: function(processElement) {
					var parameter = processElement.findParameterByName("Title");
					var mappingValue = parameter.getMappingValue();
					if (!mappingValue.value) {
						var caption = processElement.caption.getValue();
						mappingValue.value = caption;
						mappingValue.displayValue = caption;
						mappingValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
						var sourceValue = {
							value: caption,
							displayValue: caption,
							source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
						};
						parameter.setMappingValue(sourceValue);
					}
					this.set("Title", mappingValue);
					this.setValidationInfo("Title", true, null);
				},

				/**
				 * Creates page elements add button menu.
				 * @protected
				 * @return {BPMSoft.Collection} Collection of menu items.
				 */
				createPageElementAddButtonMenu: function() {
					var addElementButtonMenu = Ext.create("BPMSoft.Collection");
					var fieldTypes = processUserTaskConstants.AutoGeneratedPageElementFieldType;
					BPMSoft.each(fieldTypes, function(fieldType) {
						var menuItem = this.getAddElementToolsButtonEditMenuItem(fieldType);
						addElementButtonMenu.add(menuItem.get("Id"), menuItem);
					}, this);
					return addElementButtonMenu;
				},

				/**
				 * Returns menu item.
				 * @protected
				 * @param {Object} fieldType Field type.
				 * @return {BPMSoft.BaseViewModel} Returns instance of menu item buttons drop-down menu.
				 */
				getAddElementToolsButtonEditMenuItem: function(fieldType) {
					var caption = this.get("Resources.Strings." + fieldType.name + "MenuItemCaption");
					var imageUrl = this.getControlEditTypeImageUrl(fieldType);
					var imageConfig = {
						source: BPMSoft.ImageSources.URL,
						url: imageUrl
					};
					var config = {
						caption: caption,
						tag: fieldType.id,
						imageConfig: imageConfig,
						click: {
							bindTo: "onAddElementMenuButtonClick"
						},
						IsValid: false
					};
					return this.getButtonMenuItem(config);
				},

				/**
				 * Adds element menu item click handler.
				 * @protected
				 * @param {String} tag Tag.
				 */
				onAddElementMenuButtonClick: function(tag) {
					var elements = this.get("Elements");
					var id = BPMSoft.generateGUID();
					var name = this.getItemName(elements, "PageItem");
					var config = {
						Id: id,
						IsNew: true,
						ControlEditType: tag,
						Name: name,
						Visible: false,
						IsValid: false,
						packageUId: this.get("packageUId")
					};
					var viewModel = this.createElementViewModel(id, config);
					this.initControlEditTypeImage(viewModel);
					this.initControlValue(viewModel);
					elements.add(id, viewModel);
					viewModel.validate();
					viewModel.onLoadMinEditPageClick();
				},

				/**
				 * Returns resource image url.
				 * @private
				 * @param {String} resourceName Resource name.
				 * @return {String}
				 */
				getElementTypeImageUrl: function(resourceName) {
					var image = this.get("Resources.Images." + resourceName);
					return BPMSoft.ImageUrlBuilder.getUrl(image);
				},

				/**
				 * Returns control edit type image resource URL.
				 * @private
				 * @param {Object} fieldType Field type.
				 * @return {Object}
				 */
				getControlEditTypeImageUrl: function(fieldType) {
					switch (fieldType) {
						case processUserTaskConstants.AutoGeneratedPageElementFieldType.ITEMFOLDER:
							return this.getElementTypeImageUrl("FieldsGroupTypeImage");
						case processUserTaskConstants.AutoGeneratedPageElementFieldType.NOTES:
							return this.getElementTypeImageUrl("CommentTypeImage");
						default:
							return BPMSoft.ProcessSchemaDesignerUtilities.getDataValueTypeImageUrl(fieldType.type);
					}
				},

				/**
				 * Initialization ControlEditTypeImage by ControlEditType.
				 * @private
				 * @param {Object} viewModel Element view model.
				 */
				initControlEditTypeImage: function(viewModel) {
					var fieldType = viewModel.getParameterType();
					var imageUrl = this.getControlEditTypeImageUrl(fieldType);
					viewModel.set("DataValueType", fieldType.type);
					viewModel.set("ControlEditTypeImage", imageUrl);
				},

				/**
				 * Initialization Value by ControlEditType.
				 * @private
				 * @param {Object} viewModel Element view model.
				 */
				initControlValue: function(viewModel) {
					var controlType = viewModel.getParameterType();
					var dataValueType = controlType.type;
					var value = {
						value: "",
						displayValue: "",
						source: BPMSoft.ProcessSchemaParameterValueSource.None,
						dataValueType: dataValueType
					};
					viewModel.set("DataValueType", dataValueType);
					viewModel.set("Value", value);
				},

				/**
				 * Initializes the buttons of the process element.
				 * @protected
				 * @param {ProcessElement} element Process element.
				 */
				initButtons: function(element) {
					var buttons = Ext.create("BPMSoft.ObjectCollection");
					var parameter = element.findParameterByName("Buttons");
					var parameterValue = parameter.getValue();
					if (parameterValue) {
						var buttonsArray = BPMSoft.decode(parameterValue).$values;
						BPMSoft.each(buttonsArray, function(item) {
							var id = item.Id;
							if (!buttons.contains(id)) {
								var viewModel = this.createButtonViewModel(id, {
									IsValid: true
								});
								viewModel.convertServerObjectToViewModelAttributes(item);
								buttons.add(id, viewModel);
							}
						}, this);
					}
					this.set("Buttons", buttons);
				},

				/**
				 * Returns instance of button view model.
				 * @protected
				 * @param {String} id Button identifier.
				 * @param {Object} config Initial config.
				 * @return {BPMSoft.AutoGeneratedPageUserTaskButtonViewModel} Instance of button view model.
				 */
				createButtonViewModel: function(id, config) {
					return this.createViewModel("BPMSoft.AutoGeneratedPageUserTaskButtonViewModel", id, config);
				},

				/**
				 * Initializes the page elements of the process element.
				 * @protected
				 * @param {ProcessElement} element Process element.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				initElements: function(element, callback, scope) {
					var elements = Ext.create("BPMSoft.ObjectCollection");
					var parameter = element.findParameterByName("Elements");
					var parameterValue = parameter.getValue();
					if (parameterValue) {
						var packageUId = this.get("packageUId");
						var elementsArray = BPMSoft.decode(parameterValue).$values;
						BPMSoft.eachAsync(elementsArray, function(item, next) {
							var id = item.Id;
							if (!elements.contains(id)) {
								var viewModel = this.createElementViewModel(id, {
									IsValid: true
								});
								viewModel.set("DataValueType", parseInt(item.controlDataValueType, 10));
								viewModel.set("packageUId", packageUId);
								viewModel.convertServerObjectToViewModelAttributes(item, function () {
									this.initControlEditTypeImage(viewModel);
									viewModel.validate();
									elements.add(id, viewModel);
									next();
								}, this);
							}
						}, function () {
							this.set("Elements", elements);
							Ext.callback(callback, scope || this);
						}, this);
					} else {
						this.set("Elements", elements);
						Ext.callback(callback, scope || this);
					}
				},

				/**
				 * Returns instance of page element view model.
				 * @protected
				 * @param {String} id Element identifier.
				 * @param {Object} config Initial config.
				 * @return {BPMSoft.AutoGeneratedPageUserTaskElementViewModel} Instance of page element view model.
				 */
				createElementViewModel: function(id, config) {
					return this.createViewModel("BPMSoft.AutoGeneratedPageUserTaskElementViewModel", id, config);
				},

				/**
				 * Returns instance of class name.
				 * @protected
				 * @param {String} className View mode class name.
				 * @param {String} id Element identifier.
				 * @param {Object} config Initial config.
				 * @return {Object}
				 */
				createViewModel: function(className, id, config) {
					var initialValues = {
						ParameterEditToolsButtonMenu: this.getToolButtonMenuList(id),
						ProcessElement: this.get("ProcessElement"),
						InvokerUId: this.get("InvokerUId"),
						ParentModule: this
					};
					Ext.apply(initialValues, config);
					var viewModel = Ext.create(className, {
						Ext: Ext,
						BPMSoft: BPMSoft,
						values: initialValues
					});
					viewModel.sandbox = this.sandbox;
					viewModel.on("change", this.onChildViewModelChange, this);
					return viewModel;
				},

				/**
				 * Gets menu list for selected item.
				 * @protected
				 * @param {String} itemId Item identifier.
				 * @return {BPMSoft.Collection}
				 */
				getToolButtonMenuList: function(itemId) {
					var toolsButtonMenu = Ext.create("BPMSoft.Collection");
					toolsButtonMenu.add(
						"MoveUpMenuItem",
						this.getButtonMenuItem({
							"id": "MoveUpMenuItem",
							"tag": itemId,
							"caption": this.get("Resources.Strings.MoveUpMenuItemCaption"),
							"click": {"bindTo": "onMoveUpClick"},
							"Enabled": {"bindTo": "MoveUpEnabled"}
						})
					);
					toolsButtonMenu.add(
						"MoveDownMenuItem",
						this.getButtonMenuItem({
							"id": "MoveDownMenuItem",
							"tag": itemId,
							"caption": this.get("Resources.Strings.MoveDownMenuItemCaption"),
							"click": {"bindTo": "onMoveDownClick"},
							"Enabled": {"bindTo": "MoveDownEnabled"}
						})
					);
					toolsButtonMenu.add(
						"EditMenu",
						this.getButtonMenuItem({
							"id": "EditMenu",
							"tag": itemId,
							"caption": this.get("Resources.Strings.EditMenuItemCaption"),
							"click": {"bindTo": "onLoadMinEditPageClick"}
						})
					);
					toolsButtonMenu.add(
						"DeleteMenu",
						this.getButtonMenuItem({
							"id": "DeleteMenu",
							"tag": itemId,
							"caption": this.get("Resources.Strings.DeleteMenuItemCaption"),
							"click": {"bindTo": "onItemDeleteClick"}
						})
					);
					return toolsButtonMenu;
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveParameters: function(element) {
					this.serializeButtons(element);
					this.serializeElements(element);
					this.callParent(arguments);
				},

				/**
				 * Serialize buttons.
				 * @protected
				 * @param {ProcessElement} element Process element.
				 */
				serializeButtons: function(element) {
					var serverObject = {
						$type: processUserTaskConstants.SERVER_GENERIC_LIST_TYPE,
						$values: []
					};
					var buttons = this.get("Buttons");
					buttons.each(function(button) {
						if (button.get("IsValid") !== true) {
							return;
						}
						var item = button.convertViewModelAttributesToServerObject();
						serverObject.$values.push(item);
					}, this);
					var stringValue = BPMSoft.encode(serverObject);
					var parameter = element.findParameterByName("Buttons");
					var parameterValue = parameter.getMappingValue();
					parameterValue.value = stringValue;
					parameterValue.displayValue = stringValue;
					parameterValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
					parameter.setMappingValue(parameterValue);
				},

				/**
				 * Serialize elements.
				 * @protected
				 * @param {ProcessElement} element Process element.
				 */
				serializeElements: function(element) {
					var serverObject = {
						$type: processUserTaskConstants.SERVER_GENERIC_LIST_TYPE,
						$values: []
					};
					var elements = this.get("Elements");
					elements.each(function(item) {
						if (item.get("IsValid") !== true) {
							return;
						}
						serverObject.$values.push(item.convertViewModelAttributesToServerObject());
						var name = item.get("Name");
						var value = item.getValue();
						var caption = item.get("Caption");
						var elementParameter = element.getParameterByName(name);
						if (value) {
							elementParameter.setMappingValue(value);
						}
						elementParameter.caption.setValue(caption);
					}, this);
					var stringValue = BPMSoft.encode(serverObject);
					var parameter = element.findParameterByName("Elements");
					var parameterValue = parameter.getMappingValue();
					parameterValue.value = stringValue;
					parameterValue.displayValue = stringValue;
					parameterValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
					parameter.setMappingValue(parameterValue);
				},

				/**
				 * Returns a button representation element.
				 * @protected
				 * @param {Object} viewConfig Link to the configuration element in the Container List.
				 */
				getButtonViewConfig: function(viewConfig) {
					var buttonViewConfig = this.get("ButtonViewConfig");
					if (buttonViewConfig) {
						viewConfig.config = buttonViewConfig;
						return;
					}
					viewConfig.config = this.generateButtonViewConfig();
					this.set("ButtonViewConfig", viewConfig.config);
				},

				/**
				 * Generates a button representation element.
				 * @protected
				 * @return {Object} Configuration element in the Container List.
				 */
				generateButtonViewConfig: function() {
					var itemConfig = this.getContainerConfig("item", ["item-wrap"]);
					var itemViewConfig = this.getContainerConfig("item-view", ["item-view-wrap"], [], {
						bindTo: "Visible"
					});
					var itemEditConfig = this.getContainerConfig("item-edit", ["item-edit-wrap"], [], {
						bindTo: "Visible",
						bindConfig: {converter: this.invertBooleanValue}
					});
					itemConfig.items.push(itemViewConfig, itemEditConfig);
					var buttonConfig = {
						id: "Button",
						className: "BPMSoft.Button",
						caption: {
							bindTo: "Caption"
						},
						style: {
							bindTo: "Style",
							bindConfig: {
								converter: function(style) {
									return style.value;
								}
							}
						},
						classes: {
							wrapperClass: ["autogenerated-button"],
							imageClass: ["autogenerated-button-background"]
						},
						// imageConfig: this.getParameterEditToolsButtonImageConfig(),
						click: {
							bindTo: "onLoadMinEditPageClick"
						},
						menu: {
							items: {
								bindTo: "ParameterEditToolsButtonMenu"
							}
						},
						prepareMenu: {
							bindTo: "prepareToolsButtonMenu"
						},
						markerValue: {
							bindTo: "getMarkerValue"
						}
					};
					itemViewConfig.items.push(buttonConfig);
					return itemConfig;
				},

				/**
				 * Generates a page element representation element.
				 * @private
				 * @param {Object} viewConfig Link to the configuration element in the Container List.
				 * @param {Object} item Element in the Container List.
				 */
				getElementViewConfig: function(viewConfig, item) {
					var controlEditType = item.get("ControlEditType");
					var configName = "ElementViewConfig_" + controlEditType;
					var elementViewConfig = this.get(configName);
					if (elementViewConfig) {
						viewConfig.config = elementViewConfig;
						return;
					}
					viewConfig.config = this.generatePageElementViewConfig(item);
					this.set(configName, viewConfig.config);
				},

				/**
				 * Generates a page element representation element.
				 * @protected
				 * @param {Object} item Element in the Container List.
				 * @return {Object} configuration element in the Container List.
				 */
				generatePageElementViewConfig: function(item) {
					var itemConfig = this.getContainerConfig("item", ["item-wrap"]);
					var itemViewConfig = this.getContainerConfig("item-view", ["item-view-wrap"], [], {
						bindTo: "Visible"
					});
					var itemEditConfig = this.getContainerConfig("item-edit", ["page-edit-wrap"], [], {
						bindTo: "Visible",
						bindConfig: {converter: this.invertBooleanValue}
					});
					itemConfig.items.push(itemViewConfig, itemEditConfig);
					var typeImageConfig = this.getContainerConfig("type-image-container", ["type-image-wrap"], [
						{
							id: "type-image",
							className: "BPMSoft.ImageEdit",
							readonly: true,
							imageSrc: {
								bindTo: "ControlEditTypeImage"
							}
						}
					]);
					var labelConfig = this.getContainerConfig("label-container", ["item-label-wrap"], [
						{
							id: "label",
							className: "BPMSoft.Label",
							caption: {
								bindTo: "getLabelCaption"
							},
							click: {
								bindTo: "onLoadMinEditPageClick"
							},
							classes: {
								labelClass: ["label-link"]
							},
							markerValue: {
								bindTo: "getMarkerValue"
							}
						}
					]);
					var toolsButtonContainerConfig = this.getContainerConfig("tools-button", ["tools-button-wrap"], [
						{
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							imageConfig: this.getParameterEditToolsButtonImageConfig(),
							menu: {
								items: {
									bindTo: "ParameterEditToolsButtonMenu"
								}
							},
							prepareMenu: {
								bindTo: "prepareToolsButtonMenu"
							},
							classes: {
								imageClass: ["button-background-no-repeat"],
								wrapperClass: ["detail-tools-button-wrapper"],
								menuClass: ["detail-tools-button-menu"]
							},
							markerValue: {
								bindTo: "getToolButtonMarkerValue"
							}
						}
					]);
					var editConfig = this.getPageElementMappingEditConfig(item);
					itemViewConfig.items.push(typeImageConfig, labelConfig, toolsButtonContainerConfig, editConfig);
					return itemConfig;
				},

				/**
				 * Returns parameter edit tools button image config.
				 * @private
				 * @return {Object}
				 */
				getParameterEditToolsButtonImageConfig: function() {
					return this.get("Resources.Images.ParameterEditToolsButtonImage");
				},

				/**
				 * Returns generated a page element representation element.
				 * @private
				 * @param {Object} item Element in the Container List.
				 */
				getPageElementMappingEditConfig: function(item) {
					var useMapping = item.isMappingEdit();
					var valueColumnName = item.getValueColumnName();
					var config = {
						classes: {wrapperClass: "top-caption-control"},
						markerValue: {bindTo: "Name"}
					};
					if (useMapping) {
						Ext.apply(config, this.getDefaultMappingEditConfig(valueColumnName));
					} else {
						Ext.apply(config, {
							id: "Value",
							value: {bindTo: valueColumnName},
							className: "BPMSoft.TextEdit"
						});
					}
					return config;
				},

				/**
				 * Add button click handler.
				 * @protected
				 */
				onAddButtonClick: function() {
					var buttons = this.get("Buttons");
					var id = BPMSoft.generateGUID();
					var name = this.getItemName(buttons, "Button");
					var viewModel = this.createButtonViewModel(id, {
						Id: id,
						IsNew: true,
						Name: name,
						Visible: false,
						PerformValidation: true
					});
					buttons.add(id, viewModel);
					viewModel.onLoadMinEditPageClick();
				},

				/**
				 * Generates name for new adds item.
				 * @protected
				 * @param {BPMSoft.Collection} collection page items.
				 * @param {String} prefix Prefix of new item name.
				 * @return {String} Name of new item.
				 */
				getItemName: function(collection, prefix) {
					var filterFn = function(item, name) {
						var accept = item.get("Name") === name;
						return accept;
					};
					var itemName = processSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection, filterFn);
					return itemName;
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
				 * @overridden
				 */
				getResultParameterAllValues: function(callback, scope) {
					var resultParameterValues = {};
					var collection = this.get("Buttons");
					collection.each(function(item) {
						var caption = item.get("Caption");
						var id = item.get("Id");
						resultParameterValues[id] = caption;
					});
					callback.call(scope, resultParameterValues);
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "remove",
					"name": "RecommendationLabel"
				},
				{
					"operation": "insert",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"name": "TitleLabel",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.TitleCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"name": "Title",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 24 },
						"labelConfig": { "visible": false },
						"markerValue": "TitleValue",
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "ButtonsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["container-list-header"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"name": "ButtonsLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ButtonsCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc t-title-button-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ButtonsContainer",
					"propertyName": "items",
					"name": "ButtonToolsButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"imageClass": ["button-background-no-repeat"],
							"wrapperClass": ["detail-tools-button-wrapper t-addbutton-proc"]
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"click": {
							"bindTo": "onAddButtonClick"
						},
						"enabled": {
							"bindTo": "IsButtonToolsButtonEnabled"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "ButtonContainerList",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"dataItemIdPrefix": "button-item",
						"onItemClick": {
							"bindTo": "onItemClick"
						},
						"collection": "Buttons",
						"onGetItemConfig": "getButtonViewConfig",
						"rowCssSelector": ".buttonContainer",
						"classes": {
							"wrapClassName": ["button-container-list-items"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "ButtonEditContainer",
					"values": {
						"id": "ButtonEditContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "PageItemsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["container-list-header"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PageItemsContainer",
					"propertyName": "items",
					"name": "PageItemsLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ItemsCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc t-title-button-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "PageItemsContainer",
					"propertyName": "items",
					"name": "PageItemsToolsButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"imageClass": ["button-background-no-repeat"],
							"wrapperClass": ["detail-tools-button-wrapper t-addbutton-proc"],
							"menuClass": ["detail-tools-button-menu"]
						},
						"menu": {
							"items": {
								"bindTo": "AddElementButtonMenu"
							}
						},
						"enabled": {
							"bindTo": "IsAddElementButtonEnabled"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				},
				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "PageItemsContainerList",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"dataItemIdPrefix": "element-item",
						"onItemClick": {
							"bindTo": "onItemElementClick"
						},
						"collection": "Elements",
						"onGetItemConfig": "getElementViewConfig",
						"rowCssSelector": ".buttonContainer",
						"classes": {
							"wrapClassName": ["page-container-list-items"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "EntityConnectionContainer",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Recommendation",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.RecommendationCaption" },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"name": "InformationOnStep",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.InformationOnStepCaption" },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"name": "EntitySchemaUIdLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.EntitySchemaContainerUIdCaption" },
						"layout": { "column": 0, "row": 2, "colSpan": 24 },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"name": "EntitySchemaUId",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"caption": { "bindTo": "Resources.Strings.EntitySchemaUIdCaption" },
						"controlConfig": {
							"prepareList": { "bindTo": "onPrepareEntitySchemaList" },
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
						},
						"layout": { "column": 0, "row": 3, "colSpan": 24 },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"name": "EntityId",
					"values": {
						"caption": { "bindTo": "Resources.Strings.EntityIdCaption" },
						"layout": { "column": 0, "row": 4, "colSpan": 24 },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "useBackgroundMode",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 5, "colSpan": 24 },
						"visible": { "bindTo": "canUseBackgroundProcessMode" },
						"wrapClass": ["t-checkbox-control"]
					}
				},
				{
					"operation": "move",
					"name": "ActivityControlsContainer",
					"parentName": "EntityConnectionContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "ActivityControlsContainer",
					"parentName": "EntityConnectionContainer",
					"values": {
						"layout": { "column": 0, "row": 6, "colSpan": 24 },
					}
				}
			] /**SCHEMA_DIFF*/
		};
	}
);
