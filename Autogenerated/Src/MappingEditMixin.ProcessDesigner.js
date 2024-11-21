define("MappingEditMixin", ["ext-base", "BPMSoft", "ModalBox", "MappingEditMixinResources",
		"EntitySchemaSelectMixin", "MenuItemsMappingMixin", "ProcessSchemaParameterViewConfig"],
	function(Ext, BPMSoft, ModalBox, resources) {
		Ext.define("BPMSoft.configuration.mixins.MappingEditMixin", {
			alternateClassName: "BPMSoft.MappingEditMixin",

			modalBoxConfigExceptions:[
				{
					moduleName: "ProcessMappingModule",
					widthPixels: 820,
					heightPixels: 560,
					boxClasses: ["process-modal-box"]
				}
			],
			
			mixins: {
				entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin",
				menuItemsMappingMixin: "BPMSoft.MenuItemsMappingMixin"
			},
			attributes: {
				/**
				 * Type of current designer.
				 * @type {BPMSoft.MappingEnums.DesignerType}
				 */
				DesignerType: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Opens parameter edit page by parameter label click.
			 * @param {Object} config Configuration object.
			 * @param {String} [config.containerId] Container ID.
			 * @protected
			 */
			onParameterLabelClick: function(config) {
				const id = this.getParameterEditKey();
				this.hideParameterView();
				const sandbox = this.sandbox;
				const pageId = this.getParameterEditPageId();
				sandbox.unloadModule(pageId);
				sandbox.subscribe("GetParameterEditInfo", this.getParameterEditInfo, this, [pageId]);
				sandbox.subscribe("SaveParameterInfo", this.saveParameterInfo, this, [pageId]);
				sandbox.subscribe("DiscardParameterInfoChanges", this.discardParameterInfoChanges, this, [pageId]);
				const containerId = config && config.containerId || "item-edit";
				const renderTo = containerId + "-" + id + "-" + sandbox.id;
				const maskId = BPMSoft.Mask.show({
					selector: "#" + renderTo,
					timeout: 100,
					clearMasks: true
				});
				sandbox.loadModule("ProcessSchemaParameterEditModule", {
					renderTo: renderTo,
					id: pageId,
					instanceConfig: {
						maskId: maskId
					}
				});
			},

			/**
			 * Initializes designer type.
			 * @protected
			 */
			initDesignerType: function() {
				const processSchema = this.getProcessSchema();
				if (processSchema) {
					this.set("DesignerType", this.getDesignerTypeBySchemaTypeName(processSchema.typeName));
				}
			},

			/**
			 * Returns type of current designer.
			 * @private
			 * @param {String} schemaTypeName Schema type name.
			 * @return {BPMSoft.MappingEnums.DesignerType|String}
			 */
			getDesignerTypeBySchemaTypeName: function(schemaTypeName) {
				if (schemaTypeName === "BPMSoft.Core.Process.ProcessSchema" ||
						schemaTypeName === "BPMSoft.Core.Process.EmbeddedProcessSchema") {
					return BPMSoft.MappingEnums.DesignerType.PROCESS_DESIGNER;
				}
				return BPMSoft.MappingEnums.DesignerType.DCM_DESIGNER;
			},

			/**
			 * Hides parameter view.
			 * @private
			 */
			hideParameterView: function() {
				this.set("Visible", false);
			},

			/**
			 * Returns parameter info.
			 * @private
			 * @return {Object}
			 */
			getParameterEditInfo: function() {
				return {
					parameters: {
						UId: this.get("UId"),
						Name: this.get("Name"),
						Caption: this.get("Caption"),
						ParameterDataValueTypeConfig: { value: this.get("DataValueType") },
						Value: BPMSoft.deepClone(this.get("Value")),
						ReferenceSchema: { value: this.get("ReferenceSchemaUId") },
						DirectionConfig: { value: this.get("Direction") },
						Parameters: this.get("Parameters"),
						IsEnabled: this.get("Enabled"),
						packageUId: this.getPackageUId(),
						ProcessElement: this.$ProcessElement,
						MappingParentHierarchicalUIds: this.getMappingParentHierarchicalUIds(),
						ItemProperties: this.$ItemProperties,
						ParentUId: this.$ParentUId,
						InvokerUId: this.getInvokerUId(),
						CanAssignSourceValue: this.$CanAssignSourceValue
					}
				};
			},

			/**
			 * Discards parameter info changes.
			 * @private
			 */
			discardParameterInfoChanges: function() {
				const pageId = this.getParameterEditPageId();
				this.set("Visible", true);
				this.sandbox.unloadModule(pageId);
			},

			/**
			 * Saves parameter info.
			 * @private
			 * @param {Object} parameterInfo Parameter info.
			 */
			saveParameterInfo: function(parameterInfo) {
				this.set("Name", parameterInfo.Name);
				this.set("Caption", parameterInfo.Caption);
				const dataValueType = parameterInfo.DataValueType.value;
				this.set("DataValueType", dataValueType);
				const direction = parameterInfo.Direction
					? parameterInfo.Direction.value
					: BPMSoft.process.enums.ProcessSchemaParameterDirection.VARIABLE;
				this.set("Direction", direction);
				if (this.changedValues) {
					const designerUtilities = BPMSoft.ProcessSchemaDesignerUtilities;
					if (!Ext.isEmpty(this.changedValues.DataValueType)) {
						const supportsNestedItems = designerUtilities.getValueTypeSupportsNestedParameters(
							this.changedValues.DataValueType);
						if (!supportsNestedItems) {
							this._removeParameterItemProperties();
							this.set("HasNestedParameters", false);
						}
						this.set("CanAddNestedItems", supportsNestedItems);
						const imageDataValueType = designerUtilities.getDataValueTypeImageUrl(dataValueType);
						this.set("DataValueTypeImage", imageDataValueType);
					}
					if (!Ext.isEmpty(this.changedValues.Direction)) {
						const imageDirection = designerUtilities.getDirectionImageUrl(direction);
						this.set("DirectionImage", imageDirection);
					}
				}
				const referenceSchemaUId = parameterInfo.ReferenceSchema.value;
				this.set("ReferenceSchemaUId", referenceSchemaUId);
				this.setMappingEditValue("Value", parameterInfo.Value);
				this.set("Visible", true);
				if (!parameterInfo.Value || !parameterInfo.Value.value) {
					this._actualizeCollectionMapping();
				}
				this.set("CanAssignSourceValue", parameterInfo.CanAssignSourceValue);
				const pageId = this.getParameterEditPageId();
				this.sandbox.unloadModule(pageId);
			},

			/**
			 * @private
			 */
			_removeParameterItemProperties: function() {
				const processElement = this.$ProcessElement;
				this.$ItemProperties.each(function(nestedItem) {
					processElement.removeParameterByUId(nestedItem.$UId);
				}, this);
				this.$ItemProperties.clear();
			},

			/**
			 * Returns page identifier.
			 * @return {String}
			 */
			getParameterEditPageId: function() {
				return this.sandbox.id + "parameteredit";
			},

			/**
			 * Handles prepareMenu event.
			 * @param {Object} [config] Configuration object.
			 * @param {String} [config.attributeName] Attribute name.
			 * @param {String} [config typeMappingMenu] Type mapping menu.
			 */
			onPrepareMenu: function(config) {
				var menuItems = this.getMenuItemsCollection(config);
				this.set("MenuItems", menuItems);
			},

			/**
			 * Returns true if Process Designer is opened, otherwise - false.
			 * @return {Boolean}
			 */
			getIsProcessDesigner: function() {
				this.initDesignerType();
				var designerType = this.get("DesignerType");
				return !designerType || designerType === BPMSoft.MappingEnums.DesignerType.PROCESS_DESIGNER;
			},

			/**
			 * Returns mapping type value for parameter mapping page.
			 * @return {BPMSoft.MappingEnums.MappingType
			 * | BPMSoft.MappingEnums.MappingUnion} Menu item mapping type.
			 */
			getParameterMappingType: function() {
				return this.getIsProcessDesigner()
					? BPMSoft.MappingEnums.MappingUnion.PROCESS_AND_ELEMENT_PARAMETERS
					: BPMSoft.MappingEnums.MappingType.PROCESS_ELEMENT_PARAMETERS;
			},

			/**
			 * Returns mapping module name.
			 * @return {String}
			 */
			getParameterMappingModuleName: function() {
				return this.getIsProcessDesigner() ? "ProcessParameterSelectionModule" : "DcmMappingModule";
			},

			/**
			 * Control value changed handler.
			 * @param {Object} parameterValue Parameter value.
			 * @param {String} parameterName Parameter name.
			 */
			onValueChanged: function(parameterValue, parameterName) {
				var currentValue = this.get(parameterName);
				if (!currentValue || (currentValue.value === parameterValue.value)) {
					return;
				}
				this.set(parameterName, parameterValue);
			},

			/**
			 * Opens mapping window from extended card mode.
			 * @protected
			 */
			openExtendedMappingEditWindow: function() {
				var parameterInfo = this.getParameterInfo();
				var mappingConfig = {
					mappingType: BPMSoft.MappingEnums.MappingType.ALL,
					moduleName: "ProcessMappingModule"
				};
				this.openMappingEditWindow(parameterInfo.parameterName, parameterInfo.parameterValue, mappingConfig);
			},

			/**
			 * Returns parameter name and parameter value.
			 * @return {{parameterName: (*|string), parameterValue: *}} Parameter info object.
			 */
			getParameterInfo: function() {
				var parameterValue = this.get("Value");
				if (parameterValue &&
						(parameterValue.source === BPMSoft.ProcessSchemaParameterValueSource.EntityMapping)) {
					parameterValue = null;
				}
				var parameterName = this.get("Name") || "Value";
				return {
					parameterName: parameterName,
					parameterValue: parameterValue
				};
			},

			/**
			 * Opens mapping window.
			 * @protected
			 * @param {String} parameterName Edited parameter name.
			 * @param {Object} parameterValue Edited parameter value.
			 * @param {Object} mappingConfig .The mapping type and module name in one object;
			 * @param {BPMSoft.MappingType|number} mappingConfig.mappingType Mapping type.
			 * @param {String} mappingConfig.moduleName Name off module.
			 */
			openMappingEditWindow: function(parameterName, parameterValue, mappingConfig) {
				parameterValue = parameterValue || {};
				if (this.validateMappingConfig(mappingConfig)) {
					mappingConfig = {
						mappingType: BPMSoft.MappingEnums.MappingType.ALL,
						moduleName: "ProcessMappingModule"
					};
				}
				var referenceSchemaUId = parameterValue.referenceSchemaUId;
				this.initializeLookupSchema(referenceSchemaUId, function(lookupSchema) {
					var pageId = this.sandbox.id + "ProcessMappingPage";
					this.sandbox.subscribe("SetParametersInfo", function(sourceValue) {
						this.setParametersInfoCallback(parameterName, sourceValue);
					}, this, [pageId]);
					var config = {
						parameterValue: parameterValue,
						parameterName: parameterName,
						mappingConfig: mappingConfig,
						lookupSchema: lookupSchema,
						referenceSchemaUId: referenceSchemaUId
					};
					var viewModelConfig = this.getViewModelConfig(config);
					var preparedViewModuleConfig = this.prepareViewModuleConfig(viewModelConfig);
					this.loadMappingModule(pageId, preparedViewModuleConfig, mappingConfig.moduleName);
				}, this);
			},

			/**
			 * Returns lookup filter.
			 * @private
			 * @param {String} attributeName Attribute name.
			 * @return {BPMSoft.FilterGroup|null}
			 */
			_getLookupFilter: function(attributeName) {
				var column = this.columns[attributeName];
				var mappingWindowConfig = column && column.mappingWindowConfig;
				var filterMethod = mappingWindowConfig && mappingWindowConfig.filterMethod;
				return filterMethod && this[filterMethod]();
			},

			/**
			 * Opens process parameters mapping window for email content builder.
			 * @protected
			 * @param {Function} callback Callback for modal box result handler.
			 * @param {Object} scope Scope for modal box callback.
			 */
			openEmailMappingWindow: function(callback, scope) {
				var pageId = this.sandbox.id + "ProcessMappingPage";
				var mappingType = this.getParameterMappingType();
				var allowedDataValueTypes = this.getEmailMappingWindowDataValueTypes();
				var mappingConfig = {
					mappingType: mappingType,
					moduleName: this.getParameterMappingModuleName(),
					filterConfig: {
						allowedDataValueTypes: allowedDataValueTypes
					}
				};
				var config = {
					parameterValue: {},
					mappingConfig: mappingConfig
				};
				this.sandbox.subscribe("SetParametersInfo", function(sourceValue) {
					ModalBox.close();
					callback.call(scope, sourceValue);
				}, this, [pageId]);
				var viewModelConfig = this.getViewModelConfig(config);
				var preparedViewModuleConfig = this.prepareViewModuleConfig(viewModelConfig);
				this.loadMappingModule(pageId, preparedViewModuleConfig, mappingConfig.moduleName);
			},

			/**
			 * Returns array of allowed for email content builder data value types.
			 * @protected
			 * @return {*[]} Array of allowed data value types.
			 */
			getEmailMappingWindowDataValueTypes: function() {
				return [
					BPMSoft.DataValueType.TEXT,
					BPMSoft.DataValueType.INTEGER,
					BPMSoft.DataValueType.FLOAT,
					BPMSoft.DataValueType.DATE_TIME,
					BPMSoft.DataValueType.DATE,
					BPMSoft.DataValueType.TIME,
					BPMSoft.DataValueType.BOOLEAN,
					BPMSoft.DataValueType.SHORT_TEXT,
					BPMSoft.DataValueType.MEDIUM_TEXT,
					BPMSoft.DataValueType.MAXSIZE_TEXT,
					BPMSoft.DataValueType.LONG_TEXT,
					BPMSoft.DataValueType.LOCALIZABLE_STRING,
					BPMSoft.DataValueType.FLOAT1,
					BPMSoft.DataValueType.FLOAT2,
					BPMSoft.DataValueType.FLOAT3,
					BPMSoft.DataValueType.FLOAT4
				];
			},

			/**
			 * Returns mappingConfig validation result.
			 * @private
			 * @param {Object} mappingConfig .The mapping type and module name in one object;
			 * @return {Boolean} validation result.
			 */
			validateMappingConfig: function(mappingConfig) {
				return !mappingConfig || Ext.isString(mappingConfig);
			},

			/**
			 * Returns viewModel config.
			 * @private
			 * @param {Object} config configuration object.
			 * @return {Object} viewModel config by sandbox.loadModule.
			 */
			getViewModelConfig: function(config) {
				var mappingConfig = config.mappingConfig;
				var parameterValue = config.parameterValue;
				var parameterName = config.parameterName;
				var isLookupEnabled = this.getIsLookupEnabled(config.referenceSchemaUId, parameterValue);
				var mappingType = mappingConfig.mappingType;
				var source = parameterValue.source || BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
				var filter = this._getLookupFilter(parameterName);
				var serializationInfo = {serializeFilterManagerInfo: true};
				var lookupSerializableFilter = filter && filter.serialize(serializationInfo);
				var pageConfig = this.getPageConfig(parameterValue, mappingConfig);
				return {
					packageUId: this.getPackageUId(),
					FormulaValue: parameterValue.value,
					LookupSchema: config.lookupSchema,
					LookupSerializableFilter: lookupSerializableFilter,
					Source: source,
					DataValueType: parameterValue.dataValueType,
					ParameterName: config.parameterName,
					ElementName: this.get("name"),
					ElementUId: this.get("uId"),
					IsLookupEnabled: isLookupEnabled,
					MappingType: mappingType,
					PageConfig: pageConfig,
					InvokerItemTag: mappingConfig.invokerItemTag
				};
			},

			/**
			 * Returns IsLookupEnabled value.
			 * @private
			 * @param {Object} referenceSchemaUId UId by reference schema.
			 * @param {Object} parameterValue Edited parameter value.
			 * @return {Boolean} IsLookupEnabled value.
			 */
			getIsLookupEnabled: function(referenceSchemaUId, parameterValue) {
				return referenceSchemaUId && parameterValue.hasOwnProperty("isLookupEnabled")
						? parameterValue.isLookupEnabled
						: true;
			},

			/**
			 * Returns config by children page(tabs).
			 * @private
			 * @param {Object} parameterValue Edited parameter value.
			 * @param {Object} mappingConfig Configuration object.
			 * @param {BPMSoft.MappingType|number} mappingConfig.mappingType Mapping type.
			 * @return {Object} config by children page(tabs).
			 */
			getPageConfig: function(parameterValue, mappingConfig) {
				var invokerUId = this.getInvokerUId();
				var mappingType = mappingConfig.mappingType;
				var pageConfig = {
					InvokerUId: invokerUId,
					itemDataValueType: mappingConfig.itemDataValueType,
					presentDisplayValue: mappingConfig.presentDisplayValue,
					FilterConfig: mappingConfig.filterConfig,
					FormulaConfig: mappingConfig.formulaConfig,
					MappingParentHierarchicalUIds: this.getMappingParentHierarchicalUIds(),
					HasParent: Boolean(this.$ParentUId),
					AllowedCollectionItemNestingLevel: this.$AllowedCollectionItemNestingLevel
				};
				if (parameterValue.dataValueType !== null && mappingType > BPMSoft.MappingEnums.MappingType.ALL) {
					pageConfig.DataValueType = parameterValue.dataValueType;
					if (BPMSoft.isLookupValidator(parameterValue.dataValueType) &&
							parameterValue.referenceSchemaUId) {
						pageConfig.referenceSchemaUId = parameterValue.referenceSchemaUId;
					}
				}
				return pageConfig;
			},

			/**
			 * Prepare config for sandbox loadModule.
			 * @private
			 * @param {Object} config any js object.
			 * @return {Object} prepared config
			 */
			prepareViewModuleConfig: function(config) {
				for (var property in config) {
					if (Ext.isEmpty(config[property])) {
						delete config[property];
					}
					if (Ext.isObject(config[property])) {
						this.prepareViewModuleConfig(config[property]);
					}
				}
				return config;
			},

			/**
			 * @private
			 */
			_getDisplayValue: function(parameter, element) {
				const displayValueMacros = element === this.$ProcessSchema
					? parameter.getDisplayValue()
					: BPMSoft.FormulaMacros.prepareProcessElementParameterDisplayValue(element.getDisplayValue(),
						parameter.getFullCaption()).getBody();
				return BPMSoft.ProcessSchemaDesignerUtilities.addParameterMask(displayValueMacros);
			},

			/**
			 * @private
			 */
			_getElementOrProcessSchema: function() {
				const processElement = this.$ProcessElement;
				return processElement.parentSchema || processElement;
			},

			/**
			 * @private
			 */
			_getProcessSchemaElement: function(parameterInfo) {
				const processSchema = this._getElementOrProcessSchema();
				const schemaElementUId = parameterInfo && parameterInfo.schemaElementUId;
				return schemaElementUId ? processSchema.findItemByUId(schemaElementUId) : processSchema;
			},

			/**
			 * @private
			 */
			_getPreparedFormulaResult: function(displayValue, dataValueType, value) {
				var result = {
					value: value,
					isValid: true,
					displayValue: displayValue,
					source: Ext.isEmpty(value)
						? BPMSoft.ProcessSchemaParameterValueSource.None
						: BPMSoft.ProcessSchemaParameterValueSource.Script,
					dataValueType: dataValueType
				};
				return result;
			},

			/**
			 * @private
			 */
			_findParameterInHierarchicalCollection: function (collection, uId) {
				var parameter = null;
				if (BPMSoft.isInstanceOfClass(collection, "BPMSoft.Collection")) {
					collection.each(function (item) {
						if (!parameter) {
							if (item.$UId === uId) {
								parameter = item;
							} else {
								parameter = this._findParameterInHierarchicalCollection(item.$ItemProperties, uId);
							}
						}
					}, this);
				}
				return parameter;
			},

			/**
			 * @private
			 */
			_getEmptyValue: function () {
				return {
					value: null,
					displayValue: null,
					source: BPMSoft.ProcessSchemaParameterValueSource.None
				};
			},

			/**
			 * @private
			 * @param {Guid} collectionParameterUId Unique identifier of the process parameter collection.
			 */
			_actualizeCollectionMapping: function() {
				this.tryClearParentValue();
				this.clearNestedValues();
			},

			/**
			 * Sets parameter value from formula page.
			 * @private
			 * @param {String} parameterName Parameter name.
			 * @param {Object} sourceValue Parameter value.
			 * @param {Object} [options] Options object.
			 */
			_setMappingEditValue: function(parameterName, sourceValue, options) {
				var currentValue = this.get(parameterName);
				var newValue = Ext.isObject(currentValue) ? Ext.applyIf(sourceValue, currentValue) : sourceValue;
				newValue.dataValueType = newValue.dataValueType || this.get("DataValueType");
				if (!this.getIsFormulaUserTask()) {
					this.convertStringLiteralSourceValueToConst(newValue);
				}
				this.set(parameterName, newValue, options);
				if (parameterName !== "Value") {
					this.set("Value", newValue, options);
				}
			},

			/**
			 * Loads module for mapping.
			 * @param {String} pageId Id page for sandbox.
			 * @param {Object} viewModelConfig viewModelConfig configuration Object.
			 * @param {String} moduleName Name off module.
			 */
			loadMappingModule: function(pageId, viewModelConfig, moduleName) {
				var modalBoxConfig = this.getMappingPageModalBoxConfig(moduleName);
				for(var i=0; i<this.modalBoxConfigExceptions.length; i++){
					if(this.modalBoxConfigExceptions[i].moduleName===moduleName){
						modalBoxConfig.widthPixels=this.modalBoxConfigExceptions[i].widthPixels;
						modalBoxConfig.heightPixels=this.modalBoxConfigExceptions[i].heightPixels;
					}
				}
				var windowRenderTo = this.showModuleModalBox(pageId, modalBoxConfig);
				this.sandbox.loadModule(moduleName, {
					renderTo: windowRenderTo,
					id: pageId,
					instanceConfig: {
						parameters: {
							viewModelConfig: viewModelConfig
						}
					}
				});
			},

			/**
			 * Callback for 'SetParametersInfo' message subscription.
			 * @protected
			 * @param parameterName
			 * @param sourceValue
			 */
			setParametersInfoCallback: function(parameterName, sourceValue) {
				this.setMappingEditValue(parameterName, sourceValue);
				if (!sourceValue || !sourceValue.value) {
					this._actualizeCollectionMapping(this.$UId);
				}
				this.closeModalBox();
			},

			/**
			 * Returns mixin invoker uId.
			 * @returns {BPMSoft.utils.guid} UId of the invoker.
			 * @virtual
			 */
			getInvokerUId: function() {
				return "";
			},

			/**
			 * Returns process schema.
			 * @returns {BPMSoft.ProcessSchema} Process schema.
			 * @private
			 */
			getProcessSchema: function() {
				return this.sandbox.publish("GetProcessSchema");
			},

			/**
			 * Determines if the value is a single C# string literal and returns it without quotes.
			 * @private
			 * @param {String} value The value.
			 * @return {String|null} If the value is a string literal then returns it without quotes.
			 * Otherwise - returns null.
			 */
			getStringLiteral: function(value) {
				if (!value) {
					return null;
				}
				var stringLiteralRegExp = /^\s*"((?:\\.|[^\\"])*)"\s*$/;
				var matches = value.match(stringLiteralRegExp);
				if (!matches || matches.length < 2) {
					return null;
				}
				return matches[1];
			},

			/**
			 * Converts the source value to constant if the value is a single string literal (except FormulaUserTask).
			 * @private
			 * @param {Object} sourceValue The source value.
			 */
			convertStringLiteralSourceValueToConst: function(sourceValue) {
				if (!sourceValue) {
					return;
				}
				var valueSources = BPMSoft.process.enums.ProcessSchemaParameterValueSource;
				var isTextDataValueType = BPMSoft.isTextDataValueType(sourceValue.dataValueType);
				var isScript = (sourceValue.source === valueSources.Script);
				if (!isTextDataValueType || !isScript) {
					return;
				}
				var value = sourceValue.value;
				var valueWithoutQuotes = this.getStringLiteral(value);
				if (valueWithoutQuotes === null) {
					return;
				}
				sourceValue.value = valueWithoutQuotes;
				sourceValue.displayValue = valueWithoutQuotes;
				sourceValue.source = valueSources.ConstValue;
			},

			/**
			 * Determines if the current element is FormulaUserTask.
			 * @private
			 * @return {Boolean}
			 */
			getIsFormulaUserTask: function() {
				var processElement = this.get("ProcessElement");
				return processElement instanceof BPMSoft.manager.ProcessFormulaTaskSchema;
			},

			/**
			 * Returns tools button configuration for parameter.
			 * @protected
			 * @param {String} [id] Control identifier.
			 */
			getParameterToolsButtonConfig: function(id) {
				var config = {
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {
						"source": 3,
						"params": {
							"schemaName": "ProcessFlowElementPropertiesPage",
							"resourceItemName": "ParameterEditToolsButtonImage",
							"hash": "df03c3177a972b7f3b6987430f988ca3"
						}
					},
					menu: {
						items: {
							bindTo: "ParameterEditToolsButtonMenu"
						}
					},
					classes: {
						imageClass: ["button-background-no-repeat"],
						wrapperClass: ["detail-tools-button-wrapper"],
						menuClass: ["detail-tools-button-menu"]
					}
				};
				if (id) {
					config.id = id;
				}
				return config;
			},

			/**
			 * Returns mapping edit configuration for parameter.
			 * @protected
			 */
			getParameterMappingEditConfig: function() {
				const config = BPMSoft.ProcessSchemaParameterViewConfig.getParameterMappingEditBaseConfig();
				Ext.apply(config, this.getDefaultMappingEditConfig("Value"));
				return config;
			},

			/**
			 * Returns default mapping edit config.
			 * @protected
			 * @return {Object}
			 */
			getDefaultMappingEditConfig: function(valueColumnName) {
				return {
					id: "Value",
					className: "BPMSoft.MappingEdit",
					value: {
						bindTo: valueColumnName
					},
					openEditWindow: {
						bindTo: "openExtendedMappingEditWindow"
					},
					prepareMenu: {
						bindTo: "onPrepareMenu"
					},
					menu: {
						items: {bindTo: "MenuItems"}
					},
					tag: "Value"
				};
			},

			/**
			 * On clear icon click handler.
			 * @public
			 */
			onClearIconClick: function() {
				this.$HasCollectionMapping = false;
				this.tryClearParentValue();
			},

			/**
			 * Clear nested parameter value.
			 * @public
			 */
			clearNestedValues: function() {
				if (this.hasNestedParameters()) {
					this.$ItemProperties.each(function(item) {
						if (item.hasCollectionValue()) {
							item.setMappingEditValue("Value", this._getEmptyValue());
							item.$HasCollectionMapping = false;
						}
						item.clearNestedValues();
					}, this);
				}
			},

			/**
			 * Clear parent parameter value.
			 * @public
			 */
			tryClearParentValue: function() {
				const excludeUIds = [];
				excludeUIds.push(this.$UId);
				const parent = this._findParameterInHierarchicalCollection(this.$Parameters, this.$ParentUId);
				const result = parent && parent.hasValue() && !parent.hasCollectionInNestedParameterValues(excludeUIds);
				if (result) {
					parent.setMappingEditValue("Value", this._getEmptyValue());
					parent.tryClearParentValue();
					this._tryConvertToSingleInstance(parent.$UId, function() {
						this.fireEvent("collectionMappingReset");
					});
				}
				return result;
			},

			/**
			 * Returns all uid for all parents parameters.
			 * @return {Array}.
			 */
			getMappingParentHierarchicalUIds: function() {
				let uIds = [];
				if (!this.$Parameters || !this._checkOtherParametersHasCollectionMapping(this.$Parameters, this.$UId)) {
					return uIds;
				}
				const parameterInfo = this.getMappingParentParameterInfo();
				if (parameterInfo && parameterInfo.parameterUId) {
					const parentMappingParameter = this.getMappingParameter(parameterInfo);
					uIds =_.union([parameterInfo.parameterUId], uIds,
						parentMappingParameter.getHierarchicalParentsUIds());
				}
				return uIds;
			},

			/**
			 * @private
			 */
			_checkOtherParametersHasCollectionMapping: function(parameters, uidToSkip) {
				let result = false;
				parameters.each(function(parameter) {
					result = (parameter.$UId !== uidToSkip && parameter.$HasCollectionMapping) ||
						this._checkOtherParametersHasCollectionMapping(parameter.$ItemProperties, uidToSkip);
					if (result) {
						return false;
					}
				}, this);
				return result;
			},

			/**
			 * Sets mapping values.
			 * @public
			 * @param parameterName {String} Parameter name.
			 * @param sourceValue {String} Source value.
			 * @param {Object} [options] Options object.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			setMappingEditValue: function(parameterName, sourceValue, options, callback, scope) {
				this._setMappingEditValue(parameterName, sourceValue, options);
				const mappingToNestedParameterAllowed = this.$ParentUId ||
					(!BPMSoft.isEmpty(this.$AllowedCollectionItemNestingLevel) &&
						this.$AllowedCollectionItemNestingLevel > 0);
				if (mappingToNestedParameterAllowed) {
					this.setParentMappingEditValue(sourceValue, callback, scope);
				} else {
					Ext.callback(callback, scope);
				}
			},

			/**
			 * Applies config to parameter in both class and process element parameter.
			 * @param {String} parameterName Parameter name.
			 * @param {Object} sourceValue Parameter value.
			 * @param {Object} [options] Options object.
			 */
			applyParameterMappingEditValue: function(parameterName, config, options) {
				var newValue = Ext.apply({}, config, this.get(parameterName));
				this.setMappingEditValue(parameterName, newValue, options);
				var processElement = this.get("ProcessElement");
				var parameter = processElement.findParameterByName(parameterName);
				parameter.setMappingValue(newValue);
			},

			/**
			 * Closes modal box.
			 * @protected
			 */
			closeModalBox: function() {
				ModalBox.close();
				this.onItemFocused();
			},

			/**
			 * Event of focusing editing element.
			 * @protected
			 */
			onItemFocused: BPMSoft.emptyFn,

			/**
			 * @deprecated
			 */
			getMappingWindowRenderTo: function(modalBoxConfig) {
				var innerBoxContainer = ModalBox.show(modalBoxConfig, Ext.emptyFn, this);
				return innerBoxContainer.id;
			},

			/**
			 * @private
			 */
			_processParentFormulaParameter: function(formulaParameter, iterationsOptions, callback, scope) {
				const parameterInfo = BPMSoft.FormulaParserUtils.getParameterMappingInfo(formulaParameter);
				const parameter = this.getMappingParameter(parameterInfo);
				const parentParameter = parameter && parameter.getParent();
				if (parentParameter) {
					iterationsOptions.break();
					const element = this._getProcessSchemaElement(parameterInfo);
					this.$HasCollectionMapping = true;
					this._processMappingToCollectionItem({
						sourceElement: element,
						sourceCollectionParameter: parentParameter
					}, callback, scope);
				} else {
					this.$HasCollectionMapping = false;
					this._processMappingToItem(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_getCanChangeElement: function() {
				const validationResult = { isValid: true };
				const element = this.$ProcessElement;
				const process = element.parentSchema;
				const checkResult = process.canRemoveElements([element.name]);
				validationResult.isValid = checkResult.canRemove;
				validationResult.validationInfo = checkResult.validationInfo;
				return validationResult;
			},

			/**
			 * @private
			 */
			_processMappingToCollectionItem: function(config, callback, scope) {
				if (this.$ParentUId) {
					const parentParameter =
						this._findParameterInHierarchicalCollection(this.$Parameters, this.$ParentUId);
					if (parentParameter) {
						this._createMappingToParameter(config.sourceElement, config.sourceCollectionParameter,
							function(mapping) {
								parentParameter.setMappingEditValue("Value", mapping, null, callback, scope);
							}, this);
					} else {
						Ext.callback(callback, scope);
					}
				} else {
					this._tryConvertToMultiInstance(config, callback, scope);
				}
			},

			/**
			 * @private
			 */
			_tryConvertToSingleInstance: function(parameterUId, method, callback, scope) {
				this._elementConvertValidationHandler(
					this._getCanConvertToSingleInstance(this.$ProcessElement, parameterUId),
					function() {
						method.apply(this);
						Ext.callback(callback, scope);
					},
					function() {
						this.setMappingEditValue("Value", this.$PreviousValue, null, callback, scope);
					},
					this
				);
			},

			/**
			 * @private
			 */
			_getCanConvertToSingleInstance: function(elementSchema, parameterUId) {
				if (!(elementSchema instanceof BPMSoft.manager.ProcessFlowElementSchema)) {
					return false;
				}
				const enabled = elementSchema.getIsMultiInstanceModeEnabled();
				const isMappedToCollection = elementSchema.multiInstanceOptions &&
						elementSchema.multiInstanceOptions.inputCollectionParameterUId === parameterUId;
				return enabled && isMappedToCollection &&	!this._checkOtherParametersHasCollectionMapping(this.$Parameters);
			},

			/**
			 * @private
			 */
			_tryConvertToMultiInstance: function(config, callback, scope) {
				this._elementConvertValidationHandler(
					true,
					function() {
						this.fireEvent("collectionMappingSet", config);
						const parentParameter = config.parent;
						if (parentParameter && !parentParameter.hasValue()) {
							this._createMappingToParameter(config.sourceElement, config.sourceCollectionParameter,
								function(mapping) {
									parentParameter.setMappingEditValue("Value", mapping, null, callback, scope);
								}, this);
						} else {
							Ext.callback(callback, scope);
						}
					},
					function() {
						this.setMappingEditValue("Value", this.$PreviousValue, null, callback, scope);
					},
					this
				);
			},

			/**
			 * @private
			 */
			_elementConvertValidationHandler: function(isCanConvert, validHandler, invalidHandler, scope) {
				if (!isCanConvert) {
					return;
				}
				const validationResult = this._getCanChangeElement();
				if (validationResult.isValid) {
					validHandler.call(scope);
				} else {
					BPMSoft.ProcessSchemaDesignerUtilities.showProcessMessageBox({
						caption: resources.localizableStrings.InvalidProcessElementChange,
						message: validationResult.validationInfo
					});
					invalidHandler.call(scope);
				}
			},

			/**
			 * @private
			 */
			_processMappingToItem: function(callback, scope) {
				if (this.$ProcessElement.multiInstanceOptions) {
					if (this.$ParentUId) {
						this._tryConvertToSingleInstance(this.$ParentUId, function() {
							this.fireEvent("collectionMappingReset");
						}, callback, scope);
					} else {
						const parentParameter =
							this._findParameterInHierarchicalCollection(this.$Parameters, this.$ParentUId);
						if (parentParameter && parentParameter.hasValue()) {
							this._tryConvertToSingleInstance(this.$ParentUId, function() {
								this.fireEvent("collectionMappingReset");
							}, callback, scope);
						}
					}
				} else {
					if (this.$ParentUId) {
						this.fireEvent("collectionMappingReset");
					}
					Ext.callback(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_createMappingToParameter: function(sourceElement, sourceParameter, callback, scope) {
				const displayValue = this._getDisplayValue(sourceParameter, sourceElement);
				const processSchema = this._getElementOrProcessSchema();
				BPMSoft.FormulaParserUtils.parseFormulaValue({
					displayValue: displayValue,
					schema: processSchema,
					dataValueType: sourceParameter.dataValueType,
					parameterName: sourceParameter.name,
					elementName: sourceElement.name
				}, function(result) {
					const mappingValue = this._getPreparedFormulaResult(displayValue, sourceParameter.dataValueType,
						result.value);
					Ext.callback(callback, scope, [mappingValue]);
				}, this);
			},

			/**
			 * Sets parent mapping values.
			 * @protected
			 * @param {String} sourceValue Source value to be set up.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			setParentMappingEditValue: function(sourceValue, callback, scope) {
				BPMSoft.FormulaParserUtils.getFormulaParameters(sourceValue.value, this.$ProcessSchema,
						function(formulaParameters) {
					if (BPMSoft.isEmpty(formulaParameters)) {
						this.$HasCollectionMapping = false;
						this._processMappingToItem(callback, scope);
					} else {
						BPMSoft.eachAsync(
							formulaParameters,
							function(formulaParameter, next, options) {
								this._processParentFormulaParameter(formulaParameter, options, next, this);
							},
							function() {
								Ext.callback(callback, scope);
							},
							this
						);
					}
				}, this);
			},

			/**
			 * Shows modal box for module.
			 * @protected
			 * @param {String} moduleId Module identifier.
			 * @param {Object} modalBoxConfig  Modal box config.
			 * @return {String} Container element id for renderTo.
			 */
			showModuleModalBox: function(moduleId, modalBoxConfig) {
				var renderTo = ModalBox.show(modalBoxConfig, function() {
					this.sandbox.unloadModule(moduleId, renderTo);
				}, this);
				return renderTo.id;
			},

			/**
			 * Returns modal box settings.
			 * @private
			 * @param {String} moduleName Name off module.
			 * @return {Object} Modal box settings.
			*/
			getMappingPageModalBoxConfig: function(moduleName) {
				var getModalBoxConfig = moduleName === "DateTimeMappingModule"
					? BPMSoft.ProcessSchemaDesignerUtilities.getDateTimeModalBoxConfig
					: BPMSoft.ProcessSchemaDesignerUtilities.getModalBoxConfig;
				return getModalBoxConfig();
			},

			/**
			 * Returns mapping parameter by parameterInfo
			 */
			getMappingParameter: function(parameterInfo) {
				const processSchema = this._getElementOrProcessSchema();
				return BPMSoft.FormulaParserUtils.findMappingParameter(parameterInfo, processSchema);
			},

			/**
			 * Initializes a reference schema parameter for the mapping window.
			 * @param {GUID} referenceSchemaUId Schema identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initializeLookupSchema: function(referenceSchemaUId, callback, scope) {
				if (!referenceSchemaUId || BPMSoft.isEmptyGUID(referenceSchemaUId)) {
					callback.call(scope);
					return;
				}
				this.getEntitySchemaInfo(referenceSchemaUId, function(info) {
					callback.call(scope, info);
				}, this);
			},

			/**
			 * Returns parameter info for first actual parent.
			 * @public
			 * @return {Object}.
			 */
			getMappingParentParameterInfo: function() {
				var parent = this._findParameterInHierarchicalCollection(this.$Parameters, this.$ParentUId);
				var parameterInfo = null;
				if (parent) {
					parameterInfo = parent.hasValue()
						? BPMSoft.FormulaParserUtils.getParameterMappingInfo(parent.$Value.value)
						: parent.getMappingParentParameterInfo();
				}
				return parameterInfo;
			},

			/**
			 * Returns has value indicator.
			 * @public
			 * @return {Boolean}.
			 */
			hasValue: function() {
				return Boolean(this.$Value && this.$Value.value);
			},

			/**
			 * Returns has nested parameters indicator.
			 * @public
			 * @return {Boolean}.
			 */
			hasNestedParameters: function() {
				var itemProperties = this.$ItemProperties;
				return BPMSoft.isInstanceOfClass(itemProperties, "BPMSoft.Collection") && !itemProperties.isEmpty();
			},

			/**
			 * Returns has collection value indicator.
			 * @public
			 * @return {Boolean}.
			 */
			hasCollectionValue: function() {
				let result = false;
				if (this.hasValue()) {
					BPMSoft.FormulaParserUtils.getFormulaParameters(this.$Value.value, this.$ProcessSchema,
							function(formulaParameters) {
						formulaParameters.some(function(formulaParameter) {
							const parameterInfo =
									BPMSoft.FormulaParserUtils.getParameterMappingInfo(formulaParameter);
							const parameter = this.getMappingParameter(parameterInfo);
							result = parameter ? parameter.hasParent() : false;
							return result;
						}, this);
					}, this);
				}
				return result;
			},

			/**
			 * Returns has nested parameter value indicator.
			 * @public
			 * @param {Array} excludeUIds UIds exclude items.
			 * @return {Boolean}.
			 */
			hasCollectionInNestedParameterValues: function(excludeUIds) {
				excludeUIds = excludeUIds || [];
				var hasNestedParameterValue = false;
				if (this.hasNestedParameters()) {
					this.$ItemProperties.each(function (item) {
						if (!Ext.Array.contains(excludeUIds, item.$UId)) {
							hasNestedParameterValue = hasNestedParameterValue || item.hasCollectionValue();
						}
					});
				}
				return hasNestedParameterValue;
			},

			/**
			 * Clears parameter value.
			 */
			clearParameterValue: function() {
				var parameterValue = this.get("Value");
				parameterValue.value = "";
				parameterValue.displayValue = "";
				parameterValue.source = BPMSoft.ProcessSchemaParameterValueSource.None;
			},

			/**
			 * Returns a parameter edit key. Also used as a DOM identifier.
			 */
			getParameterEditKey: BPMSoft.abstractFn
		});
	});
