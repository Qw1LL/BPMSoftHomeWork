/**
 * Edit page schema of process element "ChangeAdminRightsUserTask".
 * Parent: ProcessFlowElementPropertiesPage
 */
define("ChangeAdminRightsUserTaskPropertiesPage", ["ProcessUserTaskConstants",
	"ChangeAdminRightsUserTaskPropertiesPageResources", "EntitySchemaSelectMixin",
	"FilterModuleMixin", "ConfigurationItemGenerator", "ChangeAdminRightsUserTaskDeleteRightsViewModel",
	"ChangeAdminRightsUserTaskAddRightsViewModel", "ConfigurationItemGenerator",
	"ChangeAdminRightsUserTaskMiniEditPage", "ImageCustomGeneratorV2"
], function(processUserTaskConstants, resources) {
	var changeAdminRightsUserTaskGrantee = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee;
	return {
		mixins: {
			filterModuleMixin: "BPMSoft.FilterModuleMixin",
			entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin"
		},
		attributes: {
			/**
			 * Entity schema identifier.
			 * @type {BPMSoft.DataValueType.TEXT}
			 */
			"EntitySchemaUId": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"initMethod": "initProperty",
				"doAutoSave": true
			},
			/**
			 * Entity of element.
			 * @type {BPMSoft.DataValueType.LOOKUP}
			 */
			"EntitySchemaSelect": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true
			},

			/**
			 * Collection of delete rights.
			 * @type {BPMSoft.DataValueType.COLLECTION}
			 */
			"DeleteRights": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * The sign that the collection of empty delete rights.
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"IsDeleteRightsEmpty": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Collection of add element menu button.
			 * @type {BPMSoft.DataValueType.COLLECTION}
			 */
			"DeleteRightsAddItemsButtonMenu": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Delete rights all users item menu visible.
			 * protected
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"DeleteRightsAllUsersItemMenuVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Collection of add rights.
			 * @type {BPMSoft.DataValueType.COLLECTION}
			 */
			"AddRights": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * The sign that the collection of empty add rights.
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"IsAddRightsEmpty": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Collection of add element menu button.
			 * @type {BPMSoft.DataValueType.COLLECTION}
			 */
			"AddRightsAddItemsButtonMenu": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Add rights all users item menu visible.
			 * @type {BPMSoft.DataValueType.BOOLEAN}
			 */
			"AddRightsAllUsersItemMenuVisible": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Active view model item ID.
			 */
			"ActiveItemId": {
				"dataValueType": BPMSoft.DataValueType.TEXT
			},

			/**
			 * Flag that indicates whether AddRightsToolsButton is enabled or not.
			 */
			"IsAddRightsToolsButtonEnabled": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Flag that indicates whether DeleteRightsToolsButton is enabled or not.
			 */
			"IsDeleteRightsToolsButtonEnabled": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Returns read image url.
			 * @private
			 * @return {String}
			 */
			getReadImageUrl: function() {
				var imageSource = this.get("Resources.Images.ReadImage");
				return BPMSoft.ImageUrlBuilder.getUrl(imageSource);
			},

			/**
			 * Returns edit image url.
			 * @private
			 * @return {String}
			 */
			getEditImageUrl: function() {
				var imageSource = this.get("Resources.Images.EditImage");
				return BPMSoft.ImageUrlBuilder.getUrl(imageSource);
			},

			/**
			 * Returns delete image url.
			 * @private
			 * @return {String}
			 */
			getDeleteImageUrl: function() {
				var imageSource = this.get("Resources.Images.DeleteImage");
				return BPMSoft.ImageUrlBuilder.getUrl(imageSource);
			},

			/**
			 * Gets menu list for selected item.
			 * @private
			 * @param {String} itemId Item identifier.
			 * @return {BPMSoft.Collection}
			 */
			getToolButtonMenuList: function(itemId) {
				var toolsButtonMenu = Ext.create("BPMSoft.BaseViewModelCollection");
				toolsButtonMenu.add(
					"MoveUpMenuItem",
					this.getButtonMenuItem({
						"id": "MoveUpMenuItem",
						"tag": itemId,
						"caption": this.get("Resources.Strings.MoveUpMenuItemCaption"),
						"click": {
							"bindTo": "onMoveUpClick"
						},
						"Enabled": {
							"bindTo": "MoveUpEnabled"
						}
					})
				);
				toolsButtonMenu.add(
					"MoveDownMenuItem",
					this.getButtonMenuItem({
						"id": "MoveDownMenuItem",
						"tag": itemId,
						"caption": this.get("Resources.Strings.MoveDownMenuItemCaption"),
						"click": {
							"bindTo": "onMoveDownClick"
						},
						"Enabled": {
							"bindTo": "MoveDownEnabled"
						}
					})
				);
				toolsButtonMenu.add(
					"EditMenuItem",
					this.getButtonMenuItem({
						"id": "EditMenuItem",
						"tag": itemId,
						"caption": this.get("Resources.Strings.EditMenuItemCaption"),
						"click": {
							"bindTo": "onLoadMinEditPageClick"
						},
						"Visible": {
							"bindTo": "getEditMenuItemVisible"
						}
					})
				);
				toolsButtonMenu.add(
					"DeleteMenuItem",
					this.getButtonMenuItem({
						"id": "DeleteMenuItem",
						"tag": itemId,
						"caption": this.get("Resources.Strings.DeleteMenuItemCaption"),
						"click": {
							"bindTo": "onItemDeleteClick"
						}
					})
				);
				return toolsButtonMenu;
			},

			/**
			 * Returns the value of visibility for change admin rights parameters controls group.
			 * @private
			 * @return {Boolean}
			 */
			getChangeAdminRightsParametersControlGroupVisible: function() {
				var entitySchemaUId = this.get("EntitySchemaUId");
				return !Ext.isEmpty(entitySchemaUId) && !BPMSoft.isEmptyGUID(entitySchemaUId);
			},

			/**
			 * Clears page data.
			 * @private
			 */
			clearPageData: function() {
				var entity = this.get("EntitySchemaSelect");
				var entitySchemaUId = Ext.isObject(entity) ? entity.value : entity;
				this.set("FilterEditData", null);
				this.set("DataSourceFilters", null);
				this.set("EntitySchemaUId", entitySchemaUId);
				const filterModuleId = this.getFilterUnitModuleId();
				if (this.filterModulesLoaded[filterModuleId]) {
					this.updateFilterModule();
				}
				var addRights = this.get("AddRights");
				addRights.clear();
				var deleteRights = this.get("DeleteRights");
				deleteRights.clear();
			},

			/**
			 * Prepares empty message config.
			 * @private
			 * @param  {Object} config Empty message config.
			 */
			prepareEmptyRightsMessageConfig: function(config) {
				config.className = "BPMSoft.Label";
				config.caption = this.get("Resources.Strings.EmptyRightsMessage");
				config.classes = {
					"labelClass": ["rights-empty-message"]
				};
			},

			/**
			 * Initializes add items button menu.
			 * @private
			 */
			initAddItemsButtonMenu: function() {
				var deleteRightsAddItemsButtonMenu = this.createAddItemsButtonMenu("DeleteRights");
				this.set("DeleteRightsAddItemsButtonMenu", deleteRightsAddItemsButtonMenu);
				var allRolesGrantee = changeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS;
				var addRightsAddItemsButtonMenu = this.createAddItemsButtonMenu("AddRights", [allRolesGrantee]);
				this.set("AddRightsAddItemsButtonMenu", addRightsAddItemsButtonMenu);
			},

			/**
			 * Returns operation config.
			 * @private
			 * @param {String} operationName Operation name.
			 * @return {Object} Operation config.
			 */
			getOperationConfig: function(operationName) {
				return {
					oppositeCollectionName: operationName === "AddRights" ? "DeleteRights" : "AddRights"
				};
			},

			/**
			 * Initializes rights model operation.
			 * @private
			 */
			initRightsModelOperation: function() {
				var operations = processUserTaskConstants.ChangeAdminRightsUserTaskOperation;
				var addRightsCollection = this.getRightsCollection(operations.ADD);
				var deleteRightsCollection = this.getRightsCollection(operations.DELETE);
				addRightsCollection.each(function(item) {
					item.set("Operation", operations.ADD);
					item.set("OppositeRightsCollection", deleteRightsCollection);
				}, this);
				deleteRightsCollection.each(function(item) {
					item.set("Operation", operations.DELETE);
					item.set("OppositeRightsCollection", addRightsCollection);
				}, this);
			},

			/**
			 * Returns new rights collection.
			 * @private
			 * @param {String} operationName Operation name.
			 * @return {BPMSoft.ObjectCollection} New rights collection.
			 */
			getRightsCollection: function(operationName) {
				var collection = this.get(operationName);
				if (!collection) {
					collection = Ext.create("BPMSoft.ObjectCollection");
					collection.on("add", this.setAllUsersItemMenuVisible, this, operationName);
					collection.on("remove", this.setAllUsersItemMenuVisible, this, operationName);
				}
				return collection;
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this.destroyFilterModuleMixin();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#customValidator
			 * @override
			 */
			customValidator: function() {
				var filterEditData = this.get("FilterEditData");
				var isValid = !Ext.isEmpty(filterEditData) && !filterEditData.isEmpty();
				var message = this.get("Resources.Strings.FilterInvalidMessage");
				var validationInfo = {
					isValid: isValid,
					invalidMessage: isValid ? "" : message
				};
				this.addCustomValidationResult(validationInfo);
				return validationInfo;
			},

			/**
			 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
			 * @override
			 */
			onElementDataLoad: function(element, callback, scope) {
				this.callParent([element, function() {
					this.initChangeAdminRightsCollection(element, "DeleteRights",
						"BPMSoft.ChangeAdminRightsUserTaskDeleteRightsViewModel");
					this.initChangeAdminRightsCollection(element, "AddRights",
						"BPMSoft.ChangeAdminRightsUserTaskAddRightsViewModel");
					this.initRightsModelOperation();
					this.initAddItemsButtonMenu();
					this.mixins.entitySchemaSelectMixin.initEntitySchemaSelectMixin.call(this);
					this.set("EntitySchemaSelect", this.get("EntitySchemaUId"));
					BPMSoft.chain(
						this.initEntitySchemaSelect,
						function(next) {
							var filterConfig = {
								referenceSchemaParameterName: "EntitySchemaUId",
								element: element
							};
							this.mixins.filterModuleMixin.initFilterModuleMixin.call(this, filterConfig, next, this);
						},
						function() {
							this.setValidationInfo("EntitySchemaSelect", true, null);
							callback.call(scope);
						}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
			 * @override
			 */
			saveValues: function() {
				var element = this.get("ProcessElement");
				this.saveDataSourceFilters(element);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
			 * @override
			 */
			saveParameters: function(element) {
				this.saveComplexParameter(element, "DeleteRights");
				this.saveComplexParameter(element, "AddRights");
				this.callParent(arguments);
			},

			/**
			 * Save complex parameter.
			 * @protected
			 * @param {BPMSoft.ProcessElement} element Process element.
			 * @param {String} parameterName Parameter name.
			 */
			saveComplexParameter: function(element, parameterName) {
				this.saveCollectionParameter(element, parameterName);
				this.saveItemsParameter(element, parameterName);
			},

			/**
			 * Save collection of item view models to parameter.
			 * @protected
			 * @param {BPMSoft.ProcessElement} element Process element.
			 * @param {String} parameterName Parameter name.
			 */
			saveCollectionParameter: function(element, parameterName) {
				var stringValue = this.serializeItemsCollection(parameterName);
				var parameter = element.findParameterByName(parameterName);
				var parameterValue = parameter.getMappingValue();
				parameterValue.value = stringValue;
				parameterValue.displayValue = stringValue;
				parameterValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
				parameter.setMappingValue(parameterValue);
			},

			/**
			 * Updates items parameter value.
			 * @protected
			 * @param {BPMSoft.ProcessElement} element Process element.
			 * @param {String} collectionName Items collection name.
			 */
			saveItemsParameter: function(element, collectionName) {
				var items = this.get(collectionName);
				if (items) {
					items.each(function(item) {
						var elementParameter = element.findParameterByUId(item.get("Id"));
						var value = item.get("Value");
						if (elementParameter && value) {
							elementParameter.setMappingValue(value);
						}
					}, this);
				}
			},

			/**
			 * Serialize item view models collection to string.
			 * @protected
			 * @param {String} collectionName Collection attribute name.
			 * @return {String} Serialized collection.
			 */
			serializeItemsCollection: function(collectionName) {
				var items = this.get(collectionName);
				var serverObject = [];
				if (items) {
					items.each(function(item) {
						var serverItem = item.convertViewModelAttributesToServerObject();
						serverObject.push(serverItem);
					}, this);
				}
				return Ext.global.JSON5.stringify(serverObject);
			},

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#initReferenceSchemaUId
			 * @override
			 */
			initReferenceSchemaUId: Ext.emptyFn,

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterReferenceSchemaAttributeName
			 * @override
			 */
			getFilterReferenceSchemaAttributeName: function() {
				return "EntitySchemaUId";
			},

			/**
			 * @inheritdoc BPMSoft.FilterModuleMixin#onFiltersChanged
			 * @override
			 */
			onFiltersChanged: function() {
				this.mixins.filterModuleMixin.onFiltersChanged.apply(this, arguments);
				this.setFilterInfoButtonVisible();
			},

			/**
			 * The event handler for change of the EntitySchemaSelect attribute.
			 * @override
			 * @param {BPMSoft.BaseViewModel} model View model.
			 * @param {String} newEntitySchemaSelect New value of EntitySchemaSelect attribute.
			 * @param {Object} options Additional settings.
			 */
			onEntitySchemaSelectChanged: function(model, newEntitySchemaSelect, options) {
				if (options.showConfirmation === false) {
					return;
				}
				var oldEntitySchemaSelectValue = this.get("EntitySchemaUId");
				var newEntitySchemaSelectValue = newEntitySchemaSelect ? newEntitySchemaSelect.value : "";
				if (!newEntitySchemaSelectValue) {
					return;
				}
				if (!oldEntitySchemaSelectValue) {
					this.mixins.entitySchemaSelectMixin.onEntitySchemaSelectChanged.call(this);
					this.clearPageData();
					return;
				}
				if (oldEntitySchemaSelectValue === newEntitySchemaSelectValue) {
					return;
				}
				var changeCode = "change";
				var changeButton = {
					className: "BPMSoft.Button",
					returnCode: changeCode,
					caption: this.get("Resources.Strings.ChangeEntitySchemaSelectButtonCaption")
				};
				var message = this.get("Resources.Strings.ChangeEntitySchemaSelectWarningMessage");
				this.showConfirmationDialog(message, function(returnCode) {
					if (returnCode !== changeCode) {
						this.getEntitySchemaInfo(oldEntitySchemaSelectValue, function(item) {
							this.set("EntitySchemaSelect", item);
						}, this);
					} else {
						this.mixins.entitySchemaSelectMixin.onEntitySchemaSelectChanged.call(this);
						this.clearPageData();
					}
				}, [changeButton, BPMSoft.MessageBoxButtons.CANCEL.returnCode], {
					defaultButton: 0
				});
			},

			/**
			 * Initializes the attribute of the process element.
			 * @protected
			 * @param {ProcessElement} element Process element.
			 * @param {String} parameterName Process element parameter name.
			 * @param {String} className View model class name.
			 */
			initChangeAdminRightsCollection: function(element, parameterName, className) {
				var items = this.getRightsCollection(parameterName);
				this.set(parameterName, items);
				var parameter = element.findParameterByName(parameterName);
				var parameterValue = parameter.getValue();
				if (parameterValue) {
					var serverItems = Ext.global.JSON5.parse(parameterValue);
					BPMSoft.each(serverItems, function(item) {
						var id = item.Id;
						if (!items.contains(id)) {
							var viewModel = this.createViewModel(className, id);
							viewModel.convertServerObjectToViewModelAttributes(item);
							items.add(id, viewModel);
						}
					}, this);
				}
				var isEmpty = items.isEmpty();
				this.set("Is" + parameterName + "Empty", isEmpty);
			},

			/**
			 * Returns instance of class name.
			 * @protected
			 * @param {String} className View model class name.
			 * @param {String} id Element identifier.
			 * @param {Object} config Initial config.
			 * @return {Object}
			 */
			createViewModel: function(className, id, config) {
				var initialValues = {
					Id: id,
					ParameterEditToolsButtonMenu: this.getToolButtonMenuList(id),
					packageUId: this.get("packageUId"),
					ProcessElement: this.get("ProcessElement"),
					EntitySchemaUId: this.get("EntitySchemaUId"),
					ParentModule: this,
					uId: this.get("uId"),
				};
				Ext.apply(initialValues, config);
				var viewModel = Ext.create(className, {
					Ext: Ext,
					BPMSoft: BPMSoft,
					values: initialValues,
					sandbox: this.sandbox
				});
				viewModel.on("change", this.onChildViewModelChange, this);
				return viewModel;
			},

			/**
			 * Creates page elements add button menu.
			 * @protected
			 * @param {Object} prefix Initial config.
			 * @param {Array} ignored Ignored items.
			 */
			createAddItemsButtonMenu: function(prefix, ignored) {
				var addItemsButtonMenu = Ext.create("BPMSoft.BaseViewModelCollection");
				ignored = ignored || [];
				BPMSoft.each(changeAdminRightsUserTaskGrantee, function(grantee) {
					if (ignored.indexOf(grantee) > -1) {
						return;
					}
					var initialConfig = {
						tag: grantee,
						click: {
							bindTo: "onAdd" + prefix + "ButtonClick"
						}
					};
					switch (grantee) {
						case changeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS:
							initialConfig.caption = this.get("Resources.Strings.AllUsersItemMenuCaption");
							initialConfig.Visible = {
								bindTo: prefix + "AllUsersItemMenuVisible"
							};
							break;
						case changeAdminRightsUserTaskGrantee.ROLE:
							initialConfig.caption = this.get("Resources.Strings.RoleItemMenuCaption");
							break;
						case changeAdminRightsUserTaskGrantee.EMPLOYEE:
							initialConfig.caption = this.get("Resources.Strings.EmployeeItemMenuCaption");
							break;
						case changeAdminRightsUserTaskGrantee.DATA_SOURCE_FILTER:
							initialConfig.caption = this.get("Resources.Strings.DataSourceFilterItemMenuCaption");
							break;
						default:
							return;
					}
					var menuItem = this.getButtonMenuItem(initialConfig);
					addItemsButtonMenu.add(menuItem.get("Id"), menuItem);
				}, this);
				return addItemsButtonMenu;
			},

			/**
			 * Returns generates a page element representation element.
			 * @private
			 * @param {Object} viewConfig Link to the configuration element in the Container List.
			 * @param {Object} item Element in the Container List.
			 */
			getChangeAdminRightsItemConfig: function(viewConfig, item) {
				var configName = "ChangeAdminRightsItemViewConfig" + this.getChangeAdminRightsItemLabelClass(item);
				var elementViewConfig = this.get(configName);
				if (elementViewConfig) {
					viewConfig.config = elementViewConfig;
					return;
				}
				viewConfig.config = this.generateChangeAdminRightsItemViewConfig(item);
				this.set(configName, viewConfig.config);
			},

			/**
			 * Generates a page element representation element.
			 * @protected
			 * @param {Object} item Element in the Container List.
			 * @return {Object} configuration element in the Container List.
			 */
			generateChangeAdminRightsItemViewConfig: function(item) {
				var itemConfig = this.getContainerConfig("item", ["item-wrap"]);
				var itemViewConfig = this.getContainerConfig("item-view", ["item-view-wrap"], [], {
					bindTo: "Visible"
				});
				var itemEditConfig = this.getContainerConfig("item-edit", ["page-edit-wrap"], [], {
					bindTo: "Visible",
					bindConfig: {
						converter: this.invertBooleanValue
					}
				});
				itemConfig.items.push(itemViewConfig, itemEditConfig);
				var labelAndToolConfig = this.getContainerConfig("item-label-tool-view", ["item-label-tool-view-wrap"]);
				var labelClass = this.getChangeAdminRightsItemLabelClass(item);
				var labelConfig = this.getContainerConfig("label-container", ["item-label-wrap"], [{
					id: "label",
					className: "BPMSoft.Label",
					caption: {
						bindTo: "Name"
					},
					click: {
						bindTo: "onLoadMinEditPageClick"
					},
					classes: {
						labelClass: [labelClass]
					},
					markerValue: {
						bindTo: "getLabelMarkerValue"
					}
				}]);
				var toolsButtonContainerConfig = this.getContainerConfig("tools-button", ["tools-button-wrap"], [{
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: this.get("Resources.Images.ParameterEditToolsButtonImage"),
					classes: {
						imageClass: ["button-background-no-repeat"],
						wrapperClass: ["detail-tools-button-wrapper"],
						menuClass: ["detail-tools-button-menu"]
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
						bindTo: "getToolButtonMarkerValue"
					}
				}]);
				var rightLevelConfig = this.getContainerConfig("rightLevel", ["right-level-wrap"], [{
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					imageConfig: {
						bindTo: "getRightLevelImageConfig"
					},
					classes: {
						imageClass: ["button-background-no-repeat"],
						wrapperClass: ["right-level-tools-button-wrapper"],
						menuClass: ["detail-tools-button-menu"]
					},
					menu: {
						items: {
							bindTo: "getRightLevelMenuItems"
						}
					},
					markerValue: {
						bindTo: "getRightLevelButtonMarkerValue"
					}
				}]);
				var operationsContainerConfig = this.getContainerConfig("operations", ["operations-wrap"], [{
					className: "BPMSoft.CheckBoxEdit",
					checked: {
						bindTo: "CanRead"
					},
					markerValue: {
						bindTo: "getReadCheckBoxMarkerValue"
					}
				}, {
					className: "BPMSoft.CheckBoxEdit",
					checked: {
						bindTo: "CanEdit"
					},
					markerValue: {
						bindTo: "getEditCheckBoxMarkerValue"
					}
				}, {
					className: "BPMSoft.CheckBoxEdit",
					checked: {
						bindTo: "CanDelete"
					},
					markerValue: {
						bindTo: "getDeleteCheckBoxMarkerValue"
					}
				}]);
				labelAndToolConfig.items.push(labelConfig, toolsButtonContainerConfig);
				itemViewConfig.items.push(labelAndToolConfig, rightLevelConfig, operationsContainerConfig);
				return itemConfig;
			},

			/**
			 * Returns change  admin rights item label class.
			 * @protected
			 * @param {Object} item Element in the Container List.
			 * @return {Array}
			 */
			getChangeAdminRightsItemLabelClass: function(item) {
				var grantee = item.get("Grantee");
				var classes = "";
				if (grantee !== changeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS) {
					classes = "label-link";
				}
				return classes;
			},

			/**
			 * Delete rights add button click handler.
			 * @protected
			 * @param {Object} tag Button tag.
			 */
			onAddDeleteRightsButtonClick: function(tag) {
				this.addViewModel(tag, "BPMSoft.ChangeAdminRightsUserTaskDeleteRightsViewModel", "DeleteRights");
			},

			/**
			 * Add rights add button click handler.
			 * @protected
			 * @param {Object} tag Button tag.
			 */
			onAddAddRightsButtonClick: function(tag) {
				this.addViewModel(tag, "BPMSoft.ChangeAdminRightsUserTaskAddRightsViewModel", "AddRights");
			},

			/**
			 * Adds new delete rights item to collection.
			 * @protected
			 * @param {Object} tag Button tag.
			 * @param {String} className View model class name.
			 * @param {String} collectionName Collection name.
			 */
			addViewModel: function(tag, className, collectionName) {
				if (!tag) {
					return;
				}
				var id = BPMSoft.generateGUID();
				var operationConfig = this.getOperationConfig(collectionName);
				var newItem = this.createViewModel(className, id, {
					Name: tag.displayValue,
					Grantee: tag,
					IsNew: true,
					Operation: collectionName,
					OppositeRightsCollection: this.get(operationConfig.oppositeCollectionName)
				});
				var collection = this.get(collectionName);
				collection.add(id, newItem);
				if (tag === changeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS) {
					return;
				}
				newItem.onLoadMinEditPageClick();
			},

			/**
			 * Sets visible value for all users item menu.
			 * @protected
			 * @param {Object} item Item.
			 * @param {Number} index Item index.
			 * @param {String} key Item collection key.
			 * @param {String} collectionName Collection name.
			 */
			setAllUsersItemMenuVisible: function(item, index, key, collectionName) {
				collectionName = collectionName || key;
				this.set(collectionName + "AllUsersItemMenuVisible", !this.isAllUsersGranteeExists(collectionName));
			},

			/**
			 * Returns true if ALL_ROLES_AND_USERS grantee exists.
			 * @param  {String} collectionName Collection name.
			 * @return {Boolean}
			 */
			isAllUsersGranteeExists: function(collectionName) {
				var result = false;
				var collection = this.get(collectionName);
				if (!collection) {
					return result;
				}
				collection.each(function(item) {
					result = item.get("Grantee") === changeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS;
					return !result;
				}, this);
				return result;
			},

			/**
			 * Returns the value of visibility for filter info button.
			 * @protected
			 * @return {Boolean}
			 */
			setFilterInfoButtonVisible: function() {
				var filterEditData = this.get("FilterEditData");
				var visible = Ext.isEmpty(filterEditData) || filterEditData.isEmpty();
				this.set("FilterInfoButtonVisible", visible);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/ [

			// region MainControlContainer

			{
				"operation": "insert",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"name": "MainControlContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["change-admin-rights-properties"]
				}
			}, {
				"operation": "insert",
				"parentName": "MainControlContainer",
				"propertyName": "items",
				"name": "MainControlGroup",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "MainControlGroup",
				"propertyName": "items",
				"name": "RecommendationLabel",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.RecommendationCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "MainControlGroup",
				"propertyName": "items",
				"name": "EntitySchemaSelect",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"contentType": BPMSoft.ContentType.ENUM,
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "prepareEntityList"
						},
						"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
					},
					"wrapClass": ["no-caption-control"]
				}
			},

			// endregion

			{
				"operation": "insert",
				"parentName": "MainControlGroup",
				"propertyName": "items",
				"name": "ChangeAdminRightsParametersControlGroup",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"visible": {
						"bindTo": "getChangeAdminRightsParametersControlGroupVisible"
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},

			// region FiltersControlGroup

			{
				"operation": "insert",
				"parentName": "ChangeAdminRightsParametersControlGroup",
				"propertyName": "items",
				"name": "FiltersControlGroup",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "FiltersControlGroup",
				"propertyName": "items",
				"name": "FilterLabel",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 23
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.FilterLabelCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "FiltersControlGroup",
				"propertyName": "items",
				"name": "FilterInfoButtonContainer",
				"values": {
					"layout": {
						"column": 23,
						"row": 0,
						"colSpan": 1
					},
					"visible": {
						"bindTo": "FilterInfoButtonVisible"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "FilterInfoButtonContainer",
					"wrapClass": ["filter-info-button-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "FilterInfoButtonContainer",
				"propertyName": "items",
				"name": "FilterInfoButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {
						"bindTo": "Resources.Strings.FilterInformationText"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "FiltersControlGroup",
				"propertyName": "items",
				"name": "ExtendedFiltersContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"id": "ExtendedFiltersContainer",
					"selectors": {
						"wrapEl": "#ExtendedFiltersContainer"
					},
					"beforererender": {
						bindTo: "unloadFilterUnitModule"
					},
					"afterrender": {
						"bindTo": "updateFilterModule"
					},
					"afterrerender": {
						"bindTo": "updateFilterModule"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "ExtendedFiltersContainer",
					"wrapClass": ["extended-filters-container"]
				}
			},

			// endregion

			// region AddRightsControlGroup

			{
				"operation": "insert",
				"parentName": "ChangeAdminRightsParametersControlGroup",
				"propertyName": "items",
				"name": "AddRightsControlGroup",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsContainer",
					"wrapClass": ["container-list-header"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsContainer",
				"propertyName": "items",
				"name": "AddRightsLabel",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.AddRightsLabelCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsContainer",
				"propertyName": "items",
				"name": "AddRightsToolsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"menu": {
						"items": {"bindTo": "AddRightsAddItemsButtonMenu"}
					},
					"classes": {
						"imageClass": ["button-background-no-repeat"],
						"menuClass": ["detail-tools-button-menu"]
					},
					"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"enabled": {"bindTo": "IsAddRightsToolsButtonEnabled"}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsItemsHeaderContainer",
					"wrapClass": ["rights-items-header-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsHeaderLabel",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.RightsHeaderLabelCaption"
					},
					"classes": {
						"labelClass": ["rights-items-header-label"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderImagesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "AddRightsItemsHeaderImagesContainer",
					"wrapClass": ["rights-items-header-images-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "AddRightsReadImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getReadImageUrl",
					"imageTitle": resources.localizableStrings.ReadImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "AddRightsEditImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getEditImageUrl",
					"imageTitle": resources.localizableStrings.EditImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "AddRightsDeleteImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getDeleteImageUrl",
					"imageTitle": resources.localizableStrings.DeleteImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "AddRightsItemsHeaderButtomContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["rights-items-header-buttom-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "AddRightsControlGroup",
				"propertyName": "items",
				"name": "AddRightsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"dataItemIdPrefix": "add-rights-item",
					"collection": "AddRights",
					"onGetItemConfig": "getChangeAdminRightsItemConfig",
					"rowCssSelector": ".adminRightsContainer",
					"isEmpty": {
						"bindTo": "IsAddRightsEmpty"
					},
					"getEmptyMessageConfig": {
						"bindTo": "prepareEmptyRightsMessageConfig"
					},
					"classes": {
						"wrapClassName": ["page-container-list-items"]
					}
				}
			},

			// endregion

			// region DeleteRightsControlGroup

			{
				"operation": "insert",
				"parentName": "ChangeAdminRightsParametersControlGroup",
				"propertyName": "items",
				"name": "DeleteRightsControlGroup",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsControlGroup",
				"propertyName": "items",
				"name": "DeleteRightsContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "DeleteRightsContainer",
					"wrapClass": ["container-list-header"]
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsContainer",
				"propertyName": "items",
				"name": "DeleteRightsLabel",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.DeleteRightsLabelCaption"
					},
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsContainer",
				"propertyName": "items",
				"name": "DeleteRightsToolsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"menu": {
						"items": {"bindTo": "DeleteRightsAddItemsButtonMenu"}
					},
					"classes": {
						"imageClass": ["button-background-no-repeat"],
						"menuClass": ["detail-tools-button-menu"]
					},
					"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"enabled": {"bindTo": "IsDeleteRightsToolsButtonEnabled"}
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsControlGroup",
				"propertyName": "items",
				"name": "DeleteRightsItemsHeaderContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "DeleteRightsItemsHeaderContainer",
					"wrapClass": ["rights-items-header-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "DeleteRightsHeaderLabel",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.RightsHeaderLabelCaption"
					},
					"classes": {
						"labelClass": ["rights-items-header-label"]
					}
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "DeleteRightsItemsHeaderImagesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": "DeleteRightsItemsHeaderImagesContainer",
					"wrapClass": ["rights-items-header-images-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "DeleteRightsReadImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getReadImageUrl",
					"imageTitle": resources.localizableStrings.ReadImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "DeleteRightsEditImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getEditImageUrl",
					"imageTitle": resources.localizableStrings.EditImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderImagesContainer",
				"propertyName": "items",
				"name": "DeleteRightsDeleteImage",
				"values": {
					"classes": {
						"wrapClass": ["rights-header-image"]
					},
					"getSrcMethod": "getDeleteImageUrl",
					"imageTitle": resources.localizableStrings.DeleteImageTitle,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsItemsHeaderContainer",
				"propertyName": "items",
				"name": "DeleteRightsItemsHeaderButtomContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["rights-items-header-buttom-container"]
				}
			}, {
				"operation": "insert",
				"parentName": "DeleteRightsControlGroup",
				"propertyName": "items",
				"name": "DeleteRightsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"dataItemIdPrefix": "delete-rights-item",
					"collection": "DeleteRights",
					"onGetItemConfig": "getChangeAdminRightsItemConfig",
					"rowCssSelector": ".adminRightsContainer",
					"isEmpty": {
						"bindTo": "IsDeleteRightsEmpty"
					},
					"getEmptyMessageConfig": {
						"bindTo": "prepareEmptyRightsMessageConfig"
					},
					"classes": {
						"wrapClassName": ["page-container-list-items", "delete-rights-container-list-items"]
					}
				}
			}

			// endregion

		] /**SCHEMA_DIFF*/
	};
});
