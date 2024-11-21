/**
 * Page schema for process properties.
 * Parent: BaseProcessSchemaPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("ProcessSchemaPropertiesPage", ["BPMSoft", "ProcessSchemaPropertiesPageResources",
	"SourceCodeEditEnums", "ProcessSchemaUsingViewModel", "ProcessMiniEditPageMixin", "ProcessModuleUtilities"],
	function(BPMSoft, resources, sourceCodeEditEnums) {
		return {
			messages: {
				/**
				 * @message GetValue
				 * Receive source code edit value.
				 */
				"GetValue": {
					"direction": BPMSoft.MessageDirectionType.PUBLISH,
					"mode": BPMSoft.MessageMode.PTP
				},

				/**
				 * @message GetSourceCodeData
				 * Returns source code edit data. Such as source code value, caption, language etc. For more
				 * information see GetSourceCodeData message in SourceCodeEditPage schema.
				 */
				"GetSourceCodeData": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SourceCodeChanged
				 * Receive current source code edit value.
				 */
				"SourceCodeChanged": {
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
					"mode": BPMSoft.MessageMode.PTP
				},

				/**
				 * @message SaveItem
				 * Save minipage item.
				 */
				"SaveItem": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message DiscardItem
				 * Discard minipage item.
				 */
				"DiscardItem": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Can user change 'useForceCompile' property..
				 */
				"CanChangeUseForceCompile": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},
				/**
				 * Flag that indicates when to use force compile.
				 */
				"useForceCompile": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.UseForceCompileCaption,
					onChange: "_onUseForceCompileChanged"
				},
				/**
				 * Tag.
				 */
				"tag": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.TagCaption
				},
				/**
				 * AddButton menu items collection.
				 */
				"AddButtonMenu": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					value: Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Flag that indicates when enable Add parameter button.
				 */
				"AddParameterButtonEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Using view models.
				 */
				"UsingViewModels": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: this.Ext.create("BPMSoft.ObjectCollection")
				},

				/**
				 * Process schema methods.
				 */
				"methodsBody": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Compiled process schema methods.
				 */
				"compiledMethodsBody": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Flag that indicates whether compiled process methods is visible. Compiled process methods shows
				 * if it is defined before.
				 */
				"IsCompiledMethodsVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * Indicates whether add using button is enabled.
				 */
				"IsAddUsingsButtonEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},

				/**
				 * Caption of the process notification.
				 */
				"NotificationCaption": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption:  BPMSoft.Resources.ProcessSchemaDesigner.Parameters.NotificationCaption
				},

				/**
				 * Current active using item id.
				 */
				"ActiveUsingItemId": {
					dataValueType: BPMSoft.DataValueType.GUID
				},

				/**
				 * Flag that indicates that the nested parameter edit page is opened or not.
				 */
				"IsNestedParameterEditPageOpened": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false,
					onChange: "_onIsNestedParameterEditPageOpenedChange"
				},

				/**
				 * Add nested parameters button menu items.
				 */
				"AddNestedParameterButtonMenuItems": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: this.Ext.create("BPMSoft.BaseViewModelCollection")
				}
			},
			modules: {
				"ProcessSchemaMethods": {
					"config": {
						"schemaName": "SourceCodeEditPage",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"showMask": true,
						"autoGeneratedContainerSuffix": "-process-schema-methods",
						"parameters": {
							"viewModelConfig": {
								"Tag": "methodsBody"
							}
						}
					}
				},
				"CompiledProcessSchemaMethods": {
					"config": {
						"schemaName": "SourceCodeEditPage",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"showMask": true,
						"autoGeneratedContainerSuffix": "-compile-process-schema-methods",
						"parameters": {
							"viewModelConfig": {
								"Tag": "compiledMethodsBody"
							}
						}
					}
				}
			},
			methods: {

				/**
				 * @private
				 */
				_onUseForceCompileChanged: function() {
					const processSchema = this.get("ProcessSchema");
					if (processSchema) {
						processSchema.setPropertyValue("useForceCompile", this.get("useForceCompile"));
						const shouldBeCompiled = processSchema.shouldBeCompiled();
						const isNoCompilation = this.isNoCompilationFeatureEnableConverter(shouldBeCompiled);
						this.set("CanChangeUseForceCompile", isNoCompilation);
					}
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getIsEditPageDefault.
				 * @overridden
				 */
				getIsEditPageDefault: function() {
					return true;
				},

				/**
				 * @protected
				 */
				loadProcessProperties: function(process) {
					this.set("ProcessSchema", process);
					this.set("AllowCompileMode", process.shouldBeCompiled());
					this.set("version", process.version);
					this.set("useForceCompile", process.useForceCompile);
					this.set("tag", process.tag);
					this.set("methodsBody", process.methodsBody);
					this.initPropertySilent(process.notificationCaption);
					const compiledProcessMethodsSource = process.compiledMethodsBody;
					this.set("compiledMethodsBody", compiledProcessMethodsSource);
					if (compiledProcessMethodsSource !== "") {
						this.set("IsCompiledMethodsVisible", true);
					}
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad.
				 * @overridden
				 */
				onElementDataLoad: function(process, callback, scope) {
					const defaultTabName = "ParametersTab";
					this.set("DefaultTabName", defaultTabName);
					this.setActiveTab(defaultTabName);
					this.set(defaultTabName, true);
					this.set("IsExtendedMode", true);
					this.callParent([process, function() {
						this.loadProcessProperties(process);
						this.initMethods();
						this.initUsings(process);
						this.initAddButtonMenu();
						callback.call(scope);
					}, this]);
				},

				/**
				 * Subscribes for source code edit page module events.
				 * @protected
				 */
				initMethods: function() {
					BPMSoft.each(this.modules, this.subscribeModuleEvents, this);
				},

				/**
				 * Subscribes for module events.
				 * @protected
				 * @param {Object} moduleConfig Module configuration.
				 * @param {String} moduleName Module name.
				 */
				subscribeModuleEvents: function(moduleConfig, moduleName) {
					const moduleId = this.getModuleId(moduleName);
					this.sandbox.subscribe("GetSourceCodeData", this.onGetSourceCodeData, this, [moduleId]);
					this.sandbox.subscribe("SourceCodeChanged", this.onSourceCodeChanged, this, [moduleId]);
				},

				/**
				 * GetSourceCodeData message handler. Returns source code data.
				 * @param {String} tag Source code edit page tag.
				 * @protected
				 * @virtual
				 * @return {Object} Source code edit data.
				 * @return {String} return.sourceCode Source code value.
				 * @return {String} return.dataItemMarker Source code edit marker value.
				 * @return {String} return.name Source code edit name.
				 * @return {String} return.caption Source code edit caption to display in expand mode.
				 * @return {Boolean} return.showCaptionInCollapsedMode Flag to show caption.
				 * @return {String} return.language Source code edit language.
				 */
				onGetSourceCodeData: function(tag) {
					const processSchema = this.get("ProcessElement");
					let caption = "";
					if (tag === "methodsBody") {
						caption = this.get("Resources.Strings.ProcessMethodsCaption");
					} else {
						caption = this.get("Resources.Strings.CompiledProcessMethodsCaption");
					}
					return {
						sourceCode: this.get(tag),
						dataItemMarker: tag,
						name: processSchema.name,
						showCaptionInCollapsedMode: true,
						caption: caption,
						language: sourceCodeEditEnums.Language.CSHARP
					};
				},

				/**
				 * SourceCodeChanged message handler. Sets methods source value by tag.
				 * @param {Object} data Current source code value.
				 * @param {String} data.tag Source code edit page tag.
				 * @param {String} data.sourceCode Source code value.
				 */
				onSourceCodeChanged: function(data) {
					this.set(data.tag, data.sourceCode);
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#createParameterViewModel
				 * @overridden
				 */
				createParameterViewModel: function(parameter) {
					const viewModel = this.callParent(arguments);
					const toolsButtonMenu = viewModel.get("ParameterEditToolsButtonMenu");
					const deleteMenuItem = this.getParameterEditToolsButtonDeleteMenuItem(parameter.name);
					toolsButtonMenu.add(deleteMenuItem);
					viewModel.set("Enabled", true);
					viewModel.onParameterDeleteClick = this.onParameterDeleteClick.bind(this);
					const canManageCollectionParameters = this.getCanManageCollectionParameters();
					const canAddNestedItems = canManageCollectionParameters &&
						BPMSoft.ProcessSchemaDesignerUtilities.getValueTypeSupportsNestedParameters(parameter.dataValueType);
					viewModel.set("CanAddNestedItems", canAddNestedItems);
					if (canManageCollectionParameters) {
						const menu = this.get("AddNestedParameterButtonMenuItems");
						viewModel.set("AddButtonMenu", menu);
					}
					viewModel.on("onAddNestedParameter", this.addNestedParameterButtonClick, this);
					return viewModel;
				},

				/**
				 * Restores process name value if name is not valid
				 * @private
				 */
				restoreNameValueIfNameNotValid: function() {
					if (this.getIsNewProcess()) {
						return;
					}
					const process = this.get("ProcessElement");
					const attributes = this.validationInfo.attributes;
					if (!attributes.name.isValid) {
						this.set("name", process.name);
					}
				},

				/**
				 * @protected
				 */
				getProcessProperties: function() {
					return ["version", "useForceCompile", "tag", "methodsBody", "compiledMethodsBody"];
				},

				/**
				 * @protected
				 */
				saveProcessProperties: function() {
					const process = this.get("ProcessElement");
					const properties = this.getProcessProperties();
					BPMSoft.each(properties, function(property) {
						process.setPropertyValue(property, this.get(property));
					}, this);
				},

				/**
				 * @protected
				 */
				getProcessParameters: function() {
					return ["notificationCaption"];
				},

				/**
				 * @protected
				 */
				saveProcessParameters: function() {
					const process = this.get("ProcessElement");
					const parameters = this.getProcessParameters();
					BPMSoft.each(parameters, function(parameterName) {
						this.saveParameter(process[parameterName]);
					}, this);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues.
				 * @overridden
				 */
				saveValues: function() {
					this.restoreNameValueIfNameNotValid();
					this.callParent(arguments);
					const process = this.get("ProcessElement");
					this.saveProcessProperties();
					this.saveProcessParameters();
					BPMSoft.each(this.modules, function(moduleConfig, moduleName) {
						const moduleId = this.getModuleId(moduleName);
						const sandbox = this.sandbox;
						const sourceCodeData = sandbox.publish("GetValue", null, [moduleId]);
						if (sourceCodeData) {
							this.set(sourceCodeData.tag, sourceCodeData.value);
						}
					}, this);
					this.saveOpenEditPages();
					this.saveUsings(process);
				},

				/**
				 * Returns type menu item.
				 * @param {Object} type Type config.
				 * @param {BPMSoft.DataValueType} type.value Data type.
				 * @param {String} type.displayValue Data type caption.
				 * @param {String} clickHandlerName Click handler function name. Optional.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getTypeMenuItem: function(type, clickHandlerName) {
					return this.getButtonMenuItem({
						caption: type.displayValue,
						tag: Ext.encode(type.value),
						click: { "bindTo": clickHandlerName },
						imageConfig: this.getTypeImageConfig(type.value)
					});
				},

				/**
				 * Returns other type menu item.
				 * @param {BPMSoft.BaseViewModelCollection} items Sub menu items.
				 * @return {BPMSoft.BaseViewModel}
				 */
				getOtherTypeMenuItem: function(items) {
					return this.getButtonMenuItem({
						caption: resources.localizableStrings.OtherMenuItemCaption,
						imageConfig: this.getTypeImageConfig(),
						items: items
					});
				},

				/**
				 * Returns type image config.
				 * @param {BPMSoft.DataValueType} [dataValueType] Data type.
				 * @return {Object}
				 */
				getTypeImageConfig: function(dataValueType) {
					const url = BPMSoft.ProcessSchemaDesignerUtilities.getDataValueTypeImageUrl(dataValueType);
					return {
						source: BPMSoft.ImageSources.URL,
						url: url
					};
				},

				/**
				 * Returns supported parameter types for the add button.
				 * @protected
				 * @returns {Object}
				 */
				getSupportedParameterTypes: function() {
					const types = BPMSoft.data.constants.DataValueTypeConfig;
					return {
						primary: [{
							value: types.LONG_TEXT.value,
							displayValue: BPMSoft.Resources.DataValueType.TEXT
						}, {
							value: types.FLOAT2.value,
							displayValue: BPMSoft.Resources.DataValueType.FLOAT
						},
							types.INTEGER,
							types.BOOLEAN,
							types.LOOKUP,
							types.DATE_TIME
						],
						secondary: [
							types.MONEY,
							types.DATE,
							types.TIME,
							types.FILE_LOCATOR,
							types.COMPOSITE_OBJECT_LIST,
							types.GUID
						]
					};
				},

				/**
				 * Adds buttons menu items to supplied collection.
				 * @private
				 */
				_fillAddButtonMenuCollection: function(menuItemsCollection, clickHandlerName) {
					menuItemsCollection.clear();
					const supportedTypes = this.getSupportedParameterTypes();
					const addMenuItem = function(collection, type) {
						collection.add(this.getTypeMenuItem(type, clickHandlerName));
					}.bind(this);
					BPMSoft.each(supportedTypes.primary, function(type) {
						addMenuItem(menuItemsCollection, type);
					}, this);
					const otherSubMenu = Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(supportedTypes.secondary, function(type) {
						addMenuItem(otherSubMenu, type);
					}, this);
					menuItemsCollection.add(this.getOtherTypeMenuItem(otherSubMenu));
				},

				/**
				 * Initializes AddButton menu.
				 * @private
				 */
				initAddButtonMenu: function() {
					const menu = this.get("AddButtonMenu");
					this._fillAddButtonMenuCollection(menu, "addParameterButtonClick");
					const addNestedParametersMenu = this.get("AddNestedParameterButtonMenuItems");
					this._fillAddButtonMenuCollection(addNestedParametersMenu, "onAddNestedItemButtonClick");
				},

				/**
				 * Hides previous parameter before add new parameter.
				 * @private
				 */
				hidePreviousParameterBeforeAddNewParameter: function() {
					const previousParameterEditUId = this.get("ActiveParameterEditUId");
					if (previousParameterEditUId) {
						const parameter = this.findParameterViewModel(previousParameterEditUId);
						parameter.set("Visible", true);
					}
					this.set("ActiveParameterEditUId", null);
				},

				/**
				 * Opens parameter edit page for new parameter.
				 * @private
				 * @param {BPMSoft.DataValueType} dataValueType Data type.
				 */
				addParameterButtonClick: function(dataValueType) {
					this.set("AddParameterButtonEnabled", false);
					this.set("IsEmptyParameters", false);
					this.hidePreviousParameterBeforeAddNewParameter();
					const sandbox = this.sandbox;
					const pageId = this.getParameterEditPageId();
					const parameterEditInfo = this.getNewParameterEditInfo(dataValueType);
					this.set("ActiveParameterEditUId", parameterEditInfo.parameters.UId);
					const tags = [pageId];
					sandbox.subscribe("GetParameterEditInfo", function() {
						return parameterEditInfo;
					}, this, tags);
					sandbox.subscribe("SaveParameterInfo", this.saveNewParameterInfo, this, tags);
					sandbox.subscribe("DiscardParameterInfoChanges", this.discardNewParameterInfoChanges, this, tags);
					this._loadParameterEditModule("AddParameterContainer", pageId);
				},

				/**
				 * Opens parameter edit page for the new nested parameter.
				 * @private
				 * @param {object} eventData Config.
				 */
				addNestedParameterButtonClick: function(eventData) {
					this.set("AddParameterButtonEnabled", false);
					this.set("IsNestedParameterEditPageOpened", true);
					const parentParameterUId = eventData.parameterUId;
					this.hidePreviousParameterBeforeAddNewParameter();
					const sandbox = this.sandbox;
					const pageId = this.getParameterEditPageId();
					const parameterEditInfo =
						this.getNewParameterEditInfo(eventData.dataValueType, parentParameterUId);
					this.set("ActiveParameterEditUId", parameterEditInfo.parameters.UId);
					const tags = [pageId];
					sandbox.subscribe("GetParameterEditInfo", function() {
						return parameterEditInfo;
					}, this, tags);
					sandbox.subscribe("SaveParameterInfo", this.saveNewNestedParameterInfo, this, tags);
					sandbox.subscribe("DiscardParameterInfoChanges", this.discardNewParameterInfoChanges, this, tags);
					const parentParameterViewModel = this.findParameterViewModel(parentParameterUId);
					const renderTo = "nested-parameters-" + parentParameterViewModel.getParameterEditKey() +
						"-" + sandbox.id;
					this._loadParameterEditModule(renderTo, pageId);
				},

				/**
				 * @private
				 */
				_loadParameterEditModule: function(renderTo, pageId) {
					const maskId = BPMSoft.Mask.show({
						selector: "#" + renderTo,
						timeout: 100,
						clearMasks: true
					});
					const config = {
						renderTo: renderTo,
						id: pageId,
						instanceConfig: {
							maskId: maskId
						}
					};
					this.sandbox.loadModule("ProcessSchemaParameterEditModule", config);
				},

				/**
				 * Discards new parameter info changes.
				 * @private
				 */
				discardNewParameterInfoChanges: function() {
					this.set("IsEmptyParameters", !this.getHasParameters());
					this.set("ActiveParameterEditUId", null);
					this.set("AddParameterButtonEnabled", true);
					this.set("IsNestedParameterEditPageOpened", false);
					const pageId = this.getParameterEditPageId();
					this.sandbox.unloadModule(pageId);
				},

				/**
				 * Determines whether the functionality of the process reminders is enabled.
				 * @private
				 * @return {Boolean} True, if functionality is enabled; otherwise - False.
				 */
				_getCanUseProcessRemindings: function() {
					return BPMSoft.Features.getIsEnabled("UseProcessRemindings");
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveActiveParameterEdit.
				 * @overridden
				 */
				saveActiveParameterEdit: function() {
					if (this.get("ActiveParameterEditUId")) {
						const pageId = this.getParameterEditPageId();
						const parameterSaved = this.sandbox.publish("SaveParameter", this, [pageId]);
						if (!parameterSaved) {
							this.discardNewParameterInfoChanges();
						}
					}
				},

				/**
				 * Generates unique parameter name or caption by prefix.
				 * @param {String} property Property name.
				 * @param {String} prefix Prefix name.
				 * @param {BPMSoft.core.collections.Collection} items Parameters collection.
				 * @return {String}
				 */
				generateParameterUniqueNameOrCaption: function(property, prefix, items) {
					let name = prefix + "1";
					let counter = 1;
					const filterFn = function(item) {
						const itemProperties = item.$ItemProperties;
						const nestedFilteredItems = itemProperties.filterByFn(filterFn, this);
						return item.get(property) === name || nestedFilteredItems.getCount() !== 0;
					};
					do {
						const filteredItems = items.filterByFn(filterFn, this);
						if (filteredItems.getCount() === 0) {
							return name;
						}
						counter++;
						name = prefix + counter;
					} while (true);
				},

				/**
				 * Returns new parameter info into edit page.
				 * @param {BPMSoft.DataValueType} dataValueType Data type.
				 * @param {String} parentParameterUId Parent parameter unique identifier.
				 * @return {Object}
				 */
				getNewParameterEditInfo: function(dataValueType, parentParameterUId) {
					dataValueType = Ext.decode(dataValueType);
					const parameters = this.get("Parameters");
					const namePrefix = BPMSoft.ProcessSchemaParameter.prototype.name;
					const name = this.generateParameterUniqueNameOrCaption("Name", namePrefix, parameters);
					const captionPrefix = BPMSoft.Resources.ProcessSchemaDesigner.Elements.ParameterCaption + " ";
					const caption = this.generateParameterUniqueNameOrCaption("Caption", captionPrefix, parameters);
					return {
						parameters: {
							UId: BPMSoft.generateGUID(),
							Name: name,
							Caption: caption,
							ParameterDataValueTypeConfig: { value: dataValueType },
							DirectionConfig: {
								value: BPMSoft.process.constants.ParameterDirectionConfig.VARIABLE.value
							},
							ShowSaveButton: true,
							IsEnabled: true,
							Parameters: parameters,
							packageUId: this.get("packageUId"),
							ProcessElement: this.getProcessElement(),
							ParentUId: parentParameterUId,
							CanAssignSourceValue: true,
							Value: {
								value: "",
								displayValue: "",
								source: BPMSoft.ProcessSchemaParameterValueSource.None,
								dataValueType: dataValueType
							}
						}
					};
				},

				/**
				 * Saves new parameter info.
				 * @param {Object} parameterInfo Parameter info.
				 */
				saveNewParameterInfo: function(parameterInfo) {
					const process = this.get("ProcessElement");
					const parameter = this.createParameter(parameterInfo);
					const parentParameterUId = parameterInfo.ParentUId;
					if (parentParameterUId) {
						const processParentParameter = process.parameters.get(parentParameterUId);
						processParentParameter.itemProperties.add(parameter.uId, parameter);
						const viewModel = this.createParameterViewModel(parameter);
						const parentParameter = this.findParameterViewModel(parentParameterUId);
						const itemProperties = parentParameter.$ItemProperties;
						itemProperties.add(parameter.uId, viewModel);
					} else {
						const viewModel = this.createParameterViewModel(parameter);
						process.parameters.add(parameter.uId, parameter);
						const parameters = this.get("Parameters");
						parameters.add(parameter.uId, viewModel);
					}
					this.set("ActiveParameterEditUId", null);
					this.set("AddParameterButtonEnabled", true);
					const pageId = this.getParameterEditPageId();
					this.sandbox.unloadModule(pageId);
				},

				/**
				 * Saves new nested parameter info.
				 * @param {Object} parameterInfo Parameter info.
				 */
				saveNewNestedParameterInfo: function(parameterInfo) {
					this.saveNewParameterInfo(parameterInfo);
					this.set("IsNestedParameterEditPageOpened", false);
				},

				/**
				 * Deletes selected parameter.
				 * @private
				 */
				onParameterDeleteClick: function(parameterName) {
					const utils = BPMSoft.ProcessSchemaDesignerUtilities;
					const process = this.get("ProcessElement");
					const parameter = process.parameters.findByFn(function(item) {
						return item.name === parameterName;
					});
					const uId = parameter.uId;
					const parameters = this.get("Parameters");
					utils.validateAllLazyPropertiesAreLoaded(process, function(areLoaded) {
						if (areLoaded) {
							utils.validateParameterRemoval(process, parameter, function(canRemove) {
								if (canRemove) {
									this._removeParameterRecursive(parameters, uId);
									process.removeParameterByUId(uId);
									this.fireEvent("change", {
										parameterName: "IsEmptyParameters",
										parameterValue: (process.parameters.getCount() === 0)
									});
								}
							}, this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_removeParameterRecursive: function(parameters, parameterUId) {
					const filterFn = function(item) {
						return item.$UId === parameterUId;
					};
					const foundParameter = parameters.findByFn(filterFn, this);
					if (foundParameter) {
						parameters.remove(foundParameter);
					} else {
						parameters.each(function(parameter) {
							this._removeParameterRecursive(parameter.$ItemProperties, parameterUId);
						}, this);
					}
				},

				/**
				 * Init 'Usings'.
				 * @protected
				 * @param {BPMSoft.manager.ProcessSchema} schema to init usings from.
				 */
				initUsings: function(schema) {
					const viewModels = Ext.create("BPMSoft.Collection");
					BPMSoft.each(schema.usings, function(using) {
						const usingViewModel = this.createUsingViewModel({
							id: using.uId,
							name: using.name,
							alias: using.alias
						});
						viewModels.add(using.uId, usingViewModel);
					}, this);
					const usingViewModels = this.get("UsingViewModels");
					usingViewModels.clear();
					usingViewModels.loadAll(viewModels);
				},

				/**
				 * Creates 'Using' ViewModel.
				 * @protected
				 * @param {Object} config Config for create view model.
				 * @param {String} config.id Unique identifier.
				 * @param {String} config.name Name.
				 * @param {String} [config.alias] Alias.
				 * @param {Boolean} [config.isNew] Flag of new element.
				 * @return {BPMSoft.ProcessSchemaUsingViewModel}
				 */
				createUsingViewModel: function(config) {
					const id = config.id;
					let alias = config.alias;
					if (alias === "null") {
						alias = "";
					}
					const name = config.name || "";
					const viewModel = Ext.create("BPMSoft.ProcessSchemaUsingViewModel", {
						values: {
							Id: id,
							Name: name,
							Alias: alias || "",
							IsNew: config.isNew,
							MarkerValue: name,
							ParameterEditToolsButtonMenu: this.getToolUsingButtonMenuList(id),
							ProcessElement: "ProcessElement",
							ParentModule: this
						}
					});
					viewModel.sandbox = this.sandbox;
					viewModel.on("change", this.onChildViewModelChange, this);
					return viewModel;
				},

				/**
				 * Generates a configuration 'using' representation element.
				 * @private
				 * @param {Object} viewConfig Link to the configuration element in the Container List.
				 */
				getUsingViewConfig: function(viewConfig) {
					const usingViewConfig = this.get("UsingViewConfig");
					if (usingViewConfig) {
						viewConfig.config = usingViewConfig;
						return;
					}
					viewConfig.config = this.generateUsingViewConfig();
					this.set("UsingViewConfig", viewConfig.config);
				},

				/**
				 * Generates a button representation element.
				 * @protected
				 * @return {Object} configuration element in the Container List.
				 */
				generateUsingViewConfig: function() {
					const parameterToolsButtonConfig = this.getParameterToolsButtonConfig("UsingsEditToolsButton");
					parameterToolsButtonConfig.markerValue = {
						bindTo: "MarkerValue"
					};
					return this.getContainerConfig("item", [], [
						this.getContainerConfig("item-view", ["parameter-ct", "t-button-container-proc"], [
							this.getContainerConfig("ParameterValueContainer", ["t-button-name-container-proc",
								"placeholderOpacity"
							], [
								this.getContainerConfig("ToolsContainer",
									["parameter-value-ct", "tools-container-wrapClass"], [
										this.getContainerConfig("LabelWrap", ["label-container-wrapClass"], [{
											id: "Caption",
											className: "BPMSoft.Label",
											caption: {
												bindTo: "Name"
											},
											classes: {
												labelClass: ["t-label-proc", "t-label-proc-param", "label-link"]
											},
											click: {
												bindTo: "onLoadMinEditPageClick"
											}
										}]),
										this.getContainerConfig("ToolsButtonWrap", ["tools-button-container-wrapClass"],
											[parameterToolsButtonConfig])
									])
							])
						], {
							bindTo: "Visible"
						}), this.getContainerConfig("item-edit", ["parameter-edit-ct"], [], {
							bindTo: "Visible",
							bindConfig: {
								converter: this.invertBooleanValue
							}
						})
					]);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getTabs
				 * @overridden
				 */
				getTabs: function() {
					const tabs = this.callParent();
					tabs.push(
						{
							Name: "MethodsTab",
							Caption: this.get("Resources.Strings.MethodsTabCaption"),
							MarkerValue: "MethodsTab"
						}
					);
					return tabs;
				},

				/**
				 * Event handler Add Using button click.
				 * @protected
				 */
				onAddUsingButtonClick: function() {
					const usingViewModels = this.get("UsingViewModels");
					const id = BPMSoft.generateGUID();
					const usingViewModel = this.createUsingViewModel({
						id: id,
						isNew: true
					});
					usingViewModels.add(id, usingViewModel);
					usingViewModel.onLoadMinEditPageClick();
				},

				/**
				 * @protected
				 */
				getEditButtonMenuItem: function(itemId) {
					return this.getButtonMenuItem({
						"id": "EditMenu",
						"tag": itemId,
						"caption": this.get("Resources.Strings.EditMenuItemCaption"),
						"click": {"bindTo": "onLoadMinEditPageClick"}
					});
				},

				/**
				 * @protected
				 */
				getDeleteButtonMenuItem: function(itemId) {
					return this.getButtonMenuItem({
						"id": "DeleteMenu",
						"tag": itemId,
						"caption": this.get("Resources.Strings.DeleteMenuItemCaption"),
						"click": {"bindTo": "onItemDeleteClick"}
					});
				},

				/**
				 * Gets menu list for selected item.
				 * @protected
				 * @param {String} itemId Item identifier.
				 * @return {BPMSoft.Collection}
				 */
				getToolUsingButtonMenuList: function(itemId) {
					const toolsButtonMenu = Ext.create("BPMSoft.Collection");
					toolsButtonMenu.add(this.getEditButtonMenuItem(itemId));
					toolsButtonMenu.add(this.getDeleteButtonMenuItem(itemId));
					return toolsButtonMenu;
				},

				/**
				 * Saves using edit page if it is still visible.
				 * @private
				 * @param {BPMSoft.model.ProcessSchemaUsingViewModel} usingViewModel Using view model.
				 * @param {Boolean} force Send DiscardItem message if not saved successfully.
				 */
				saveUsingEditPage: function(usingViewModel, force) {
					const isEditPageVisible = !usingViewModel.get("Visible");
					if (isEditPageVisible) {
						const pageId = usingViewModel.getProcessMiniEditPageId();
						const success = this.sandbox.publish("SaveItem", this, [pageId]);
						if (!success && force) {
							this.sandbox.publish("DiscardItem", this, [pageId]);
						}
						return success;
					}
					return true;
				},

				/**
				 * Processes tab change event.
				 * @override
				 * @param {BPMSoft.BaseViewModel} activeTab Selected tab.
				 */
				onActiveTabChange: function(activeTab) {
					this.callParent(arguments);
					this.saveOpenEditPages();
				},

				/**
				 * Saves opened edit pages: Usings and LocalizableStrings.
				 */
				saveOpenEditPages: function() {
					const schema = this.get("ProcessElement");
					this._saveOpenEditPage(schema, "Using");
				},

				/**
				 * Saves opened edit page.
				 * @private
				 * @param name {string} name of the page view model.
				 */
				_saveOpenEditPage: function(schema, subject) {
					const activeItemId = this.get("Active" + subject + "ItemId");
					if (activeItemId) {
						const viewModels = this.get(subject + "ViewModels");
						const activeViewModel = viewModels.get(activeItemId);
						const result = this["save" + subject + "EditPage"](activeViewModel, true);
						if (result) {
							this["update" + subject + "ByViewModel"](activeViewModel, schema);
						}
					}
				},

				/**
				 * Updates schema using by view model.
				 * @private
				 * @param {BPMSoft.model.ProcessSchemaUsingViewModel} usingViewModel Using view model.
				 * @param {BPMSoft.manager.ProcessSchema} schema Process schema.
				 * @return {Boolean} Returns true if schema using was changed, false otherwise.
				 */
				updateUsingByViewModel: function(usingViewModel, schema) {
					const name = usingViewModel.get("Name");
					if (!usingViewModel.changedValues || Ext.isEmpty(name)) {
						return false;
					}
					const usings = schema.usings;
					const id = usingViewModel.get("Id");
					const config = {
						name: name,
						alias: usingViewModel.get("Alias")
					};
					if (usings.contains(id)) {
						const using = usings.get(id);
						config.modifiedInSchemaUId = schema.uId;
						using.setValue(config);
					} else {
						config.uId = id;
						schema.addUsing(config);
					}
					return true;
				},

				/**
				 * Updates schema usings.
				 * @private
				 * @param {BPMSoft.manager.ProcessSchema} schema Process schema.
				 * @return {Boolean} Returns true if at least one schema usings was changed, false otherwise.
				 */
				updateUsings: function(schema) {
					const usingViewModels = this.get("UsingViewModels");
					let isChanged = false;
					BPMSoft.each(usingViewModels, function(usingViewModel) {
						if (this.saveUsingEditPage(usingViewModel, false) &&
								this.updateUsingByViewModel(usingViewModel, schema)) {
							isChanged = true;
						}
					}, this);
					return isChanged;
				},

				/**
				 * Removes 'Using' from collection Usings.
				 * @private
				 * @param {BPMSoft.manager.ProcessSchema} schema Process schema.
				 * @return {Boolean} Returns true if at least one schema usings was removed, false otherwise.
				 */
				removeUsings: function(schema) {
					let isRemoved = false;
					const usingViewModels = this.get("UsingViewModels");
					const usings = schema.usings;
					BPMSoft.each(usings, function(using) {
						const key = using.uId;
						if (!usingViewModels.contains(key)) {
							usings.removeByKey(key);
							isRemoved = true;
						}
					}, this);
					return isRemoved;
				},

				/**
				 * Saves schema usings.
				 * @private
				 * @param {BPMSoft.manager.ProcessSchema} schema Process schema.
				 */
				saveUsings: function(schema) {
					const isUsingsRemoved = this.removeUsings(schema);
					const isUsingsChanged = this.updateUsings(schema);
					if (isUsingsChanged || isUsingsRemoved) {
						schema.fireEvent("changed", {
							usings: schema.usings
						}, this);
					}
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getCanManageCollectionParameters.
				 * @overridden
				 */
				getCanManageCollectionParameters: function() {
					return BPMSoft.Features.getIsEnabled("ManageProcessCollectionParameters");
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getShouldShowAddParameterContainer.
				 * @overridden
				 */
				getShouldShowAddParameterContainer: function() {
					return this.callParent(arguments) && !this.$IsNestedParameterEditPageOpened;
				},

				/**
				 * @private
				 */
				_onIsNestedParameterEditPageOpenedChange: function(model, value) {
					const parameters = this.get("Parameters");
					parameters.each(function(parameter) {
						parameter.setIsNestedParameterEditPageOpened(value);
					}, this);
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getCanManageCollectionParameters.
				 * @overridden
				 */
				closeParameterEditPage: function(sender, value) {
					this.set("IsNestedParameterEditPageOpened", false);
					this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "ParameterEdit",
					"values": {
						"visible": true
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "version",
					"values": {
						"wrapClass": ["top-caption-control"],
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "tag",
					"values": {
						"wrapClass": ["top-caption-control"],
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "description",
					"values": {
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"wrapClass": ["top-caption-control"],
						"caption": {"bindTo": "Resources.Strings.DescriptionCaption"},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "SysPackage",
					"values": {
						"enabled": {"bindTo": "IsSysPackageEnabled"},
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareSysPackageList"
							}
						},
						"wrapClass": ["top-caption-control"],
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "maxLoopCount",
					"values": {
						"wrapClass": ["top-caption-control"],
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "NotificationCaption",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24,
							"rowSpan": 1
						},
						"wrapClass": ["top-caption-control"],
						visible: {
							bindTo: "_getCanUseProcessRemindings"
						}
					}
				},
				{
					"operation": "remove",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "StudioFreeProcessUrl",
					"values": {
						"wrapClass": ["top-caption-control"],
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 22,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "remove",
					"name": "OpenStudioFreeButton",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"hint": {"bindTo": "Resources.Strings.StudioFreeProcessUrlHint"},
						"imageConfig": {"bindTo": "Resources.Images.OpenButtonImage"},
						"classes": {
							"wrapperClass": ["open-schema-designer-tool-button", "open-studio-free-button"]
						},
						"click": {"bindTo": "onOpenStudioFreeButtonClick"},
						"layout": {
							"column": 22,
							"row": 7,
							"colSpan": 2
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "enabled",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24,
							"rowSpan": 1
						},
						"enabled": false
					}
				},
				{
					"operation": "merge",
					"name": "isLogging",
					"values": {
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "merge",
					"name": "serializeToDB",
					"values": {
						"layout": {
							"column": 0,
							"row": 10,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "useForceCompileContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 11,
							"colSpan": 24,
							"rowSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"classes": {
							"wrapClassName": ["not-compile", "checkbox-container"]
						},
						"visible": {
							"bindTo": "AllowCompileMode",
							"bindConfig": {
								"converter": "isNoCompilationFeatureEnableConverter"
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "useForceCompileContainer",
					"propertyName": "items",
					"name": "useForceCompile",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"enabled": {
							"bindTo": "CanChangeUseForceCompile"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "useForceCompileContainer",
					"propertyName": "items",
					"name": "useForceCompileInfoButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": BPMSoft.Resources.ProcessSchemaDesigner.Messages.DenyMakeProcessCompile,
						"controlConfig": {
							"visible": {
								"bindTo": "CanChangeUseForceCompile",
								"bindConfig": {
									"converter": "invertBooleanValue"
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "isActualVersion",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"layout": {
							"column": 0,
							"row": 12,
							"colSpan": 24,
							"rowSpan": 1
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "ControlGroup",
					"propertyName": "items",
					"name": "useSystemSecurityContext",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"layout": {
							"column": 0,
							"row": 13,
							"colSpan": 24,
							"rowSpan": 1
						},
						"visible": {"bindTo": "FeatureDisableAdminRightsInScriptTaskEnabled"}
					}
				},
				{
					"operation": "insert",
					"name": "MethodsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"wrapClass": ["tabs", "methods-tab"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "MethodsTab",
					"propertyName": "items",
					"name": "UsingsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["using-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AddUsingButtonContainer",
					"parentName": "UsingsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["container-list-header"]
					}
				},
				{
					"operation": "insert",
					"name": "UsingsButton",
					"parentName": "AddUsingButtonContainer",
					"propertyName": "items",
					"values": {
						"id": "AddPropertiesUsingsButton",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"imageClass": ["button-background-no-repeat t-btn-image-right"],
							"wrapperClass": ["detail-tools-button-wrapper t-addbutton-proc"]
						},
						"caption": {"bindTo": "Resources.Strings.UsingsGroupCaption"},
						"iconAlign": BPMSoft.controls.ButtonEnums.iconAlign.RIGHT,
						"imageConfig": {"bindTo": "Resources.Images.AddButtonOrangeImage"},
						"click": {"bindTo": "onAddUsingButtonClick"},
						"enabled": {"bindTo": "IsAddUsingsButtonEnabled"},
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
				{
					"operation": "insert",
					"name": "UsingContainerList",
					"parentName": "UsingsContainer",
					"propertyName": "items",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"onItemClick": {
							"bindTo": "onItemClick"
						},
						"collection": "UsingViewModels",
						"onGetItemConfig": "getUsingViewConfig",
						"rowCssSelector": ".usingContainer",
						"classes": {
							"wrapClassName": ["t-items-list-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MethodsTab",
					"propertyName": "items",
					"name": "ProcessSchemaMethods",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"classes": {
							"wrapClassName": "process-methods process-methods-container"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "MethodsTab",
					"propertyName": "items",
					"name": "CompiledProcessSchemaMethods",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE,
						"visible": {
							"bindTo": "IsCompiledMethodsVisible"
						},
						"classes": {
							"wrapClassName": "process-methods compiled-process-methods-container"
						},
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "EditorsContainer"
				},
				{
					"operation": "merge",
					"name": "ParametersContainer",
					"values": {
						"handleAddItems": true,
						"nestedContainerIdAttributeName": "UId"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});

