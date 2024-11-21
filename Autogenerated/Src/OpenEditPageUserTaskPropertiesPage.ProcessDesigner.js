/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("OpenEditPageUserTaskPropertiesPage", ["BPMSoft", "OpenEditPageUserTaskPropertiesPageResources",
		"BusinessRuleModule", "Contact", "Activity", "ConfigurationItemGenerator", "FilterModuleMixin",
		"EntityColumnMappingMixin", "SectionEntitySelectMixin"],
	function(BPMSoft, resources, BusinessRuleModule, Contact, Activity) {
		return {
			messages: {},

			mixins: {
				filterModuleMixin: "BPMSoft.FilterModuleMixin",
				entityColumnMappingMixin: "BPMSoft.EntityColumnMappingMixin",
				sectionEntitySelectMixin: "BPMSoft.SectionEntitySelectMixin"
			},

			attributes: {
				/**
				 * Selected page schema identifier.
				 */
				"PageSchemaId": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Open edit page mode.
				 */
				"EditMode": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * Record identifier.
				 */
				"RecordId": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true
				},
				/**
				 * Generate decisions from column.
				 */
				"GenerateDecisionsFromColumn": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					doAutoSave: true
				},
				/**
				 * Decisional column meta path.
				 */
				"DecisionalColumn": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Page schema list.
				 */
				"PageSchemaList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},
				/**
				 * Index value for AddNewRecord container.
				 */
				"AddNewRecordIndex": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 0
				},
				/**
				 * Index value for EditExistingRecord container.
				 */
				"EditExistingRecordIndex": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 1
				},
				/**
				 * Consider element executed.
				 */
				"ConsiderElementExecuted": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Index value for ExecutedAfterRecordSaved.
				 */
				"ExecutedAfterRecordSavedIndex": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 0
				},
				/**
				 * Index value for ExecutedIfMatchConditions.
				 */
				"ExecutedIfMatchConditionsIndex": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 1
				},
				/**
				 * Page type identifier.
				 */
				"PageTypeUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"Recommendation": {
					isRequired: false
				},
				"StartInPeriod": {
					isRequired: false
				},
				"DurationPeriod": {
					isRequired: false
				},
				"RemindBeforePeriod": {
					isRequired: false
				}
			},

			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.destroyFilterModuleMixin();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#onFiltersChanged
				 * @overridden
				 */
				onFiltersChanged: function() {
					this.mixins.filterModuleMixin.onFiltersChanged.apply(this, arguments);
					this.setFilterInfoButtonVisible();
				},

				/**
				 * Sets the value of visibility for filter info button.
				 * @protected
				 */
				setFilterInfoButtonVisible: function() {
					var filterEditData = this.get("FilterEditData");
					var considerElementExecuted = this.get("ConsiderElementExecuted");
					var considerElementExecutedValue = Ext.isObject(considerElementExecuted) ? considerElementExecuted.value
						: null;
					var isMatchConditions = considerElementExecutedValue === this.get("ExecutedIfMatchConditionsIndex");
					var visible = (Ext.isEmpty(filterEditData) || filterEditData.isEmpty()) && isMatchConditions;
					this.set("FilterInfoButtonVisible", visible);
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#onRender
				 * Calls for loading of the filter unit module.
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					var isFilterVisible = this.getIsFilterModuleVisible();
					if (isFilterVisible) {
						this.updateFilterModule();
					}
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					BPMSoft.chain(
						function(next) {
							parentMethod.call(this, element, next, this);
						},
						function(next) {
							this.initPageSchemaId(element, next, this);
						},
						function(next) {
							this.initEditMode(element);
							this.initRecordId(element);
							this.initEntityColumnMappingMixin(element, next, this);
						},
						function(next, entityColumns) {
							this.initConsiderElementExecuted(element);
							this.initGenerateDecisionsFromColumn(element);
							this.initDecisionalColumn(element, entityColumns);
							var filterConfig = {
								element: element,
								referenceSchemaParameterName: "ObjectSchemaId"
							};
							this.initFilterModuleMixin(filterConfig, next, this);
						},
						function() {
							callback.call(scope);
						}, this);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveParameters: function(element) {
					this.callParent(arguments);
					this.savePageSchemaId(element);
					this.savePageTypeUId(element);
					this.saveEditMode(element);
					this.saveEntityColumnMappings(element);
					this.saveReferenceSchemaUId(element, "ObjectSchemaId");
					this.saveDataSourceFilters(element);
					this.saveDecisionalColumn(element);
					this.saveConsiderElementExecuted(element);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#customValidator
				 * @overridden
				 */
				customValidator: function() {
					this.validateFilterData();
					this.validateRecordId();
					return {
						invalidMessage: ""
					};
				},

				/**
				 * Validates FilterData attribute.
				 * @protected
				 * @return {Object} Validation info
				 * @return {Object} return.isValid Validation result.
				 * @return {Object} return.invalidMessage Validation message.
				 */
				validateFilterData: function() {
					var isValid = true;
					var message = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					var considerElementExecuted = this.get("ConsiderElementExecuted");
					var considerElementExecutedValue = Ext.isObject(considerElementExecuted)
						? considerElementExecuted.value
						: null;
					if (considerElementExecutedValue === this.get("ExecutedIfMatchConditionsIndex")) {
						var filterEditData = this.get("FilterEditData");
						isValid = !Ext.isEmpty(filterEditData) && !filterEditData.isEmpty();
					}
					var invalidMessage = isValid ? "" : message;
					var validationInfo = {
						isValid: isValid,
						invalidMessage: invalidMessage
					};
					this.setValidationInfo("FilterEditData", isValid, invalidMessage);
					return validationInfo;
				},

				/**
				 * Validates RecordId attribute.
				 * @protected
				 * @return {Object} Validation info
				 * @return {Object} return.isValid Validation result.
				 * @return {Object} return.invalidMessage Validation message.
				 */
				validateRecordId: function() {
					var isValid = true;
					var message = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					var editMode = this.get("EditMode");
					var editModeValue = Ext.isObject(editMode) ? editMode.value : null;
					if (editModeValue === this.get("EditExistingRecordIndex")) {
						var recordId = this.get("RecordId");
						isValid = !BPMSoft.isEmptyObject(recordId) && !Ext.isEmpty(recordId.value);
					}
					var invalidMessage = isValid ? "" : message;
					var validationInfo = {
						isValid: isValid,
						invalidMessage: invalidMessage
					};
					this.setValidationInfo("RecordId", isValid, invalidMessage);
					return validationInfo;
				},

				/**
				 * Returns lookup entity schema query.
				 * @param  {String} schemaName Entity schema name.
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getLookupSchemaEsq: function(schemaName) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: schemaName
					});
					esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
					esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "Name");
					return esq;
				},

				/**
				 * @inheritdoc ProcessFlowElementPropertiesPage#getResultParameterAllValues
				 * @overridden
				 */
				getResultParameterAllValues: function(callback, scope) {
					var generateDecisionsFromColumn = this.get("GenerateDecisionsFromColumn");
					var decisionalColumn = this.get("DecisionalColumn");
					var entitySchemaUId = Ext.isObject(decisionalColumn)
						? decisionalColumn.referenceSchemaUId
						: null;
					if (!generateDecisionsFromColumn || !entitySchemaUId) {
						callback.call(scope);
						return;
					}
					BPMSoft.EntitySchemaManager.getItemByUId(entitySchemaUId, function(entitySchemaItem) {
						var esq = this.getLookupSchemaEsq(entitySchemaItem.name);
						esq.getEntityCollection(function(response) {
							var resultParameterValues = {};
							if (response.success) {
								response.collection.each(function(item) {
									var id = item.get("Id");
									var name = item.get("Name");
									resultParameterValues[id] = name;
								}, this);
							}
							callback.call(scope, resultParameterValues);
						}, this);
					}, this);
				},

				/**
				 * @inheritdoc BaseUserTaskPropertiesPage#getIsOptionalActivitySupported
				 * @overridden
				 */
				getIsOptionalActivitySupported: function() {
					const referenceSchemaUId = this.get("ReferenceSchemaUId");
					return this.callParent(arguments) && Activity.uId !== referenceSchemaUId;
				},

				//region PageSchemaId

				/**
				 * Sets attribute "PageSchemaId".
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				initPageSchemaId: function(element, callback, scope) {
					this.initPageSchemaList(function() {
						var pageSchema = this.findPageSchema(element);
						if (pageSchema) {
							this.set("PageSchemaId", pageSchema);
							this.set("ReferenceSchemaUId", pageSchema.entitySchemaUId);
							this.set("PageTypeUId", pageSchema.typeColumnUId);
						}
						this.on("change:PageSchemaId", this.onPageSchemaChange, this);
						callback.call(scope);
					}, this);
				},

				/**
				 * Returns page schema info.
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @return {Object|null}
				 */
				findPageSchema: function(element) {
					var parameter = element.findParameterByName("PageSchemaId");
					var pageSchemaId = parameter.getValue();
					if (!pageSchemaId) {
						return null;
					}
					var pageSchemaList = this.get("PageSchemaList");
					var pageSchema = pageSchemaList.find(pageSchemaId);
					if (pageSchema == null) {
						pageSchema = this.findPageSchemaByOldPageSchemaUId(pageSchemaId);
					}
					return pageSchema;
				},

				/**
				 * Search pageSchema by obsolete CardSchemaUId field in SysModule entity.
				 * @param {String} pageSchemaId Edit page schema id.
				 * @return {Object|null}
				 */
				findPageSchemaByOldPageSchemaUId: function(pageSchemaId) {
					var pageSchemaList = this.get("PageSchemaList");
					var filteredPageSchemaList = pageSchemaList.filter("obsoleteCardSchemaUId", pageSchemaId);
					return filteredPageSchemaList.first();
				},

				/**
				 * Returns query for select page schema list.
				 * @private
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				getPageSchemaListEsq: function() {
					var esq = new BPMSoft.EntitySchemaQuery({
						rootSchemaName: "SysModule",
						isDistinct: true
					});
					var entitySchemaPath = "[SysModuleEntity:Id:SysModuleEntity].SysEntitySchemaUId";
					esq.addColumn("Caption", "caption");
					esq.addColumn("CardSchemaUId", "obsoleteCardSchemaUId");
					esq.addColumn("[SysModuleEdit:SysModuleEntity:SysModuleEntity].TypeColumnValue", "typeColumnUId");
					esq.addColumn("[SysModuleEdit:SysModuleEntity:SysModuleEntity].CardSchemaUId", "pageSchemaUId");
					esq.addColumn(entitySchemaPath, "entitySchemaUId");
					var positionColumn = esq.addColumn("[SysModuleEdit:SysModuleEntity:SysModuleEntity].Position",
						"Position");
					positionColumn.orderDirection = BPMSoft.OrderDirection.ASC;
					positionColumn.orderPosition = 0;
					esq.addColumn("[SysModuleEntityInPortal:SysModuleEntity:SysModuleEntity].Id", "portalId");
					var filters = new BPMSoft.FilterGroup();
					var pageSchemaLeftExpression = new BPMSoft.ColumnExpression({
						columnPath: "[SysModuleEdit:SysModuleEntity:SysModuleEntity].CardSchemaUId"
					});
					var entitySchemaLeftExpression = new BPMSoft.ColumnExpression({
						columnPath: entitySchemaPath
					});
					filters.addItem(BPMSoft.createIsNotNullFilter(pageSchemaLeftExpression));
					filters.addItem(BPMSoft.createIsNotNullFilter(entitySchemaLeftExpression));
					filters.addItem(BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.NOT_EQUAL,
						"IsSystem", true));
					esq.filters.addItem(filters);
					return esq;
				},

				/**
				 * Returns display value for page by entity schema and type column.
				 * @param {BPMSoft.EntitySchemaManagerItem} schemaItem Entity schema.
				 * @param {String} typeColumnUId Page type column unique identifier.
				 * @param {String} pageSchemaUId Page schema unique identifier.
				 * @return {String}
				 */
				getPageDisplayValue: function(schemaItem, typeColumnUId, pageSchemaUId) {
					let caption = schemaItem.getCaption();
					const entityItem = BPMSoft.configuration.EntityStructure[schemaItem.getName()];
					if (typeColumnUId) {
						const page = entityItem && BPMSoft.findWhere(entityItem.pages, {UId: typeColumnUId});
						const typeCaption = page ? " (" + page.captionLcz + ")" : "";
						caption += typeCaption;
					} else if (entityItem && entityItem.pages.length > 1) {
						const item = BPMSoft.ClientUnitSchemaManager.findItem(pageSchemaUId);
						caption += item ? ` (${item.getCaption()})` : "";
					}
					return caption;
				},

				/**
				 * @private
				 */
				_uniquePageSchemaListDisplayValues: function() {
					var pageSchemaList = this.get("PageSchemaList");
					pageSchemaList.each(function(pageSchema) {
						var sameCaptionItems = pageSchemaList.filterByPath("displayValue", pageSchema.displayValue);
						if (sameCaptionItems.getCount() > 1) {
							sameCaptionItems.each(function(item) {
								const moduleCaption = item.pageInfo.caption;
								if (moduleCaption) {
									item.displayValue += " (" + moduleCaption + ")";
								}
							}, this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_sortPageSchemaList: function() {
					var pageSchemaList = this.get("PageSchemaList");
					pageSchemaList.sort("displayValue", BPMSoft.OrderDirection.ASC);
				},

				/**
				 * Fills page schema list by response collection.
				 * @private
				 * @param {Array} pageSchemaItems Items of query response collection.
				 * @param {BPMSoft.Collection} entitySchemaItems Section entity schema list.
				 */
				fillPageSchemaList: function(pageSchemaItems, entitySchemaItems) {
					var pageSchemaList = this.get("PageSchemaList");
					BPMSoft.each(pageSchemaItems, function(pageSchemaItem) {
						var pageInfo = pageSchemaItem.values;
						var item = pageSchemaList.find(pageInfo.pageSchemaUId);
						if (item) {
							item.obsoleteCardSchemaUId = item.obsoleteCardSchemaUId || pageInfo.obsoleteCardSchemaUId;
						} else {
							var entitySchema = entitySchemaItems.find(pageInfo.entitySchemaUId);
							if (entitySchema) {
								const entityName = entitySchema.getName();
								let pageDisplayValue = this.getPageDisplayValue(entitySchema, pageInfo.typeColumnUId,
									pageInfo.pageSchemaUId);
								if (pageInfo.portalId) {
									pageDisplayValue += Ext.String.format(" ({0})", resources.localizableStrings.PortalPageMarkerCaption);
								}
								pageSchemaList.add(pageInfo.pageSchemaUId, {
									value: pageInfo.pageSchemaUId,
									name: entityName,
									displayValue: pageDisplayValue,
									entitySchemaUId: pageInfo.entitySchemaUId,
									typeColumnUId: pageInfo.typeColumnUId,
									obsoleteCardSchemaUId: pageInfo.obsoleteCardSchemaUId,
									pageInfo: pageInfo
								});
							}
						}
					}, this);
					this._uniquePageSchemaListDisplayValues();
					this._sortPageSchemaList();
				},

				/**
				 * Sets attribute "PageSchemaList".
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				initPageSchemaList: function(callback, scope) {
					this.set("PageSchemaList", Ext.create("BPMSoft.Collection"));
					var pageSchemaItems;
					BPMSoft.chain(
						function(next) {
							var pageSchemaListQuery = this.getPageSchemaListEsq();
							pageSchemaListQuery.getEntityCollection(next, this);
						},
						function(next, response) {
							if (!response.success || response.collection.isEmpty()) {
								callback.call(scope);
								return;
							}
							pageSchemaItems = response.collection.getItems();
							this.getEntitySchemaList(next, this);
						},
						function(next, entitySchemaItems) {
							this.fillPageSchemaList(pageSchemaItems, entitySchemaItems);
							callback.call(scope);
						}, this
					);
				},

				/**
				 * The event handler for preparing of the data drop-down PageSchema.
				 * @private
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				preparePageSchemaList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					var pageSchemaList = this.get("PageSchemaList");
					list.loadAll(pageSchemaList);
				},

				/**
				 * The event handler for change of the PageSchema attribute.
				 * @private
				 * @param {BPMSoft.BaseViewModel} model View model.
				 * @param {Object} newPageSchemaId New value of PageSchemaId attribute.
				 * @param {Object} options Additional settings.
				 */
				onPageSchemaChange: function(model, newPageSchemaId, options) {
					if (options.showConfirmation === false) {
						return;
					}
					var newPageSchemaIdValue = newPageSchemaId ? newPageSchemaId.value : "";
					if (!newPageSchemaIdValue) {
						return;
					}
					var element = this.get("ProcessElement");
					var oldPageSchema = this.findPageSchema(element);
					var oldPageSchemaValue = oldPageSchema ? oldPageSchema.value : "";
					if (oldPageSchemaValue && (oldPageSchemaValue !== newPageSchemaIdValue)) {
						var message = this.get("Resources.Strings.ChangePageSchemaWarningMessage");
						var buttonCaption = this.get("Resources.Strings.ChangePageSchemaButtonCaption");
						var changeButton = BPMSoft.getButtonConfig("change", buttonCaption);
						this.showConfirmationDialog(message, function(returnCode) {
							if (returnCode === "change") {
								this.onPageSchemaChanged(newPageSchemaId);
							} else {
								this.set("PageSchemaId", oldPageSchema, {showConfirmation: false});
							}
						}, [changeButton, BPMSoft.MessageBoxButtons.CANCEL.returnCode], {defaultButton: 0});
					} else {
						this.onPageSchemaChanged(newPageSchemaId);
					}
				},

				/**
				 * Page schema attributes changed handler.
				 * @private
				 * @param {Object} newPageSchemaId New value of PageSchemaId attribute.
				 */
				onPageSchemaChanged: function(newPageSchemaId) {
					var pageSchemaId = this.get("PageSchemaId");
					var entitySchemaUId = "";
					var pageTypeUId = "";
					if (pageSchemaId) {
						var pageSchemaList = this.get("PageSchemaList");
						var pageSchema = pageSchemaList.get(pageSchemaId.value);
						entitySchemaUId = pageSchema.entitySchemaUId;
						pageTypeUId = pageSchema.typeColumnUId;
					} else {
						this.set("EditMode", null);
					}
					this.set("ReferenceSchemaUId", entitySchemaUId);
					this.set("PageTypeUId", pageTypeUId);
					var afterRecordSavedIndex = this.get("ExecutedAfterRecordSavedIndex");
					var considerElementExecutedLis = this.getConsiderElementExecutedList();
					var afterRecordSaved = considerElementExecutedLis[afterRecordSavedIndex];
					this.set("ConsiderElementExecuted", afterRecordSaved);
					this.set("FilterEditData", null);
					var element = this.get("ProcessElement");
					this.reInitEntityColumnMapping(element, Ext.emptyFn);
					this.set("DecisionalColumn", null);
					this.set("GenerateDecisionsFromColumn", false);
					this.savePageSchemaId(element, newPageSchemaId);
					this.clearRecordId();
					const parameter = element.findParameterByName("RecordId");
					parameter.referenceSchemaUId = entitySchemaUId;
				},

				/**
				 * Saves page schema identifier value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {Object} [newPageSchemaId] New value of PageSchemaId attribute.
				 */
				savePageSchemaId: function(element, newPageSchemaId) {
					if (this.changedValues && this.Ext.isDefined(this.changedValues.PageSchemaId) || newPageSchemaId) {
						var pageSchemaId = newPageSchemaId || this.get("PageSchemaId");
						if (pageSchemaId) {
							var sourceValue = {
								value: String(pageSchemaId.value),
								source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
							};
							var parameter = element.findParameterByName("PageSchemaId");
							parameter.setMappingValue(sourceValue);
						} else {
							var pageSchema = this.findPageSchema(element);
							this.set("PageSchemaId", pageSchema, {showConfirmation: false});
						}
					}
				},

				/**
				 * Saves page type identifier value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				savePageTypeUId: function(element) {
					var parameter = element.findParameterByName("PageTypeUId");
					var pageTypeUId = this.get("PageTypeUId");
					var sourceValue = {};
					if (pageTypeUId) {
						sourceValue = {
							value: pageTypeUId,
							source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
						};
					}
					parameter.setMappingValue(sourceValue);
				},

				// endregion

				// region EditMode

				/**
				 * Initialization EditMode parameter value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initEditMode: function(element) {
					var parameter = element.findParameterByName("EditMode");
					var editModeValue = null;
					var pageSchemaIdParameter = element.findParameterByName("PageSchemaId");
					var pageSchemaId = pageSchemaIdParameter.getValue();
					if (pageSchemaId) {
						var editMode = parameter.getValue();
						var editModeList = this.getEditModeList();
						editModeValue = editModeList[editMode];
					}
					this.set("EditMode", editModeValue);
					this.setValidationInfo("EditMode", true, null);
				},

				/**
				 * Returns EditMode list.
				 * @private
				 * @return {Object}
				 */
				getEditModeList: function() {
					return {
						"0": {
							value: this.get("AddNewRecordIndex"),
							displayValue: resources.localizableStrings.AddNewRecordCaption
						},
						"1": {
							value: this.get("EditExistingRecordIndex"),
							displayValue: resources.localizableStrings.EditExistingRecordCaption
						}
					};
				},

				/**
				 * The event handler for preparing of the data drop-down EditMode.
				 * @private
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareEditModeList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getEditModeList());
				},

				/**
				 * Saves edit mode setting.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveEditMode: function(element) {
					var changes = this.changedValues;
					if (changes && changes.hasOwnProperty("EditMode")) {
						var parameter = element.findParameterByName("EditMode");
						var sourceValue = {};
						var editMode = this.get("EditMode");
						if (!Ext.isEmpty(editMode)) {
							var value = String(editMode.value);
							sourceValue = {
								value: value,
								source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
							};
						}
						parameter.setMappingValue(sourceValue);
					}
				},

				/**
				 * Returns whether AddNewRecordContainer is visible.
				 * @private
				 * @return {boolean}
				 */
				isAddNewRecordContainerVisible: function() {
					var editMode = this.get("EditMode");
					if (editMode) {
						var editModeValue = editMode.value;
						var addNewRecordIndex = this.get("AddNewRecordIndex");
						return editModeValue === addNewRecordIndex;
					} else {
						return false;
					}
				},

				/**
				 * Returns whether EditExistingRecordContainer is visible.
				 * @private
				 * @return {boolean}
				 */
				isEditExistingRecordContainerVisible: function() {
					var editMode = this.get("EditMode");
					if (editMode) {
						var editModeValue = editMode.value;
						var addNewRecordIndex = this.get("EditExistingRecordIndex");
						return editModeValue === addNewRecordIndex;
					} else {
						return false;
					}
				},

				/**
				 * Returns whether EditMode is visible.
				 * @private
				 * @return {boolean}
				 */
				isEditModeVisible: function() {
					var pageSchemaId = this.get("PageSchemaId");
					return Boolean(pageSchemaId);
				},

				/**
				 * Returns whether BottomContainer is visible.
				 * @private
				 * @return {boolean}
				 */
				isBottomContainerVisible: function() {
					var editMode = this.get("EditMode");
					return Boolean(editMode);
				},

				// endregion

				// region RecordId

				/**
				 * Initialization RecordId parameter value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initRecordId: function(element) {
					var parameter = element.findParameterByName("RecordId");
					this.initProperty(parameter);
					var recordId = this.get("RecordId");
					recordId.referenceSchemaUId = this.get("ReferenceSchemaUId");
				},

				/**
				 * Clears value for attribute RecordId.
				 * @private
				 */
				clearRecordId: function() {
					var recordId = {
						value: null,
						displayValue: null,
						source: BPMSoft.ProcessSchemaParameterValueSource.None,
						referenceSchemaUId: this.get("ReferenceSchemaUId")
					};
					this.set("RecordId", recordId);
				},

				// endregion

				// region RecordColumnValues

				/**
				 * @inheritdoc EntityColumnMappingMixin#getEntityColumnMappingSchemaUId
				 * @overridden
				 */
				getEntityColumnMappingSchemaUId: function() {
					var pageSchemaId = this.get("PageSchemaId");
					if (!pageSchemaId) {
						return null;
					}
					return pageSchemaId.entitySchemaUId;
				},

				// endregion

				// region GenerateDecisionsFromColumn

				/**
				 * Initialization "GenerateDecisionsFromColumn" attribute.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initGenerateDecisionsFromColumn: function(element) {
					var parameter = element.findParameterByName("GenerateDecisionsFromColumn");
					var generateDecisionsFromColumn = parameter.getValue();
					this.set("GenerateDecisionsFromColumn", Boolean(generateDecisionsFromColumn));
				},

				// endregion

				// region DecisionalColumnMetaPath

				/**
				 * Initialization "DecisionalColumn" attribute.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 * @param {BPMSoft.Collection} entityColumns Entity columns collection.
				 */
				initDecisionalColumn: function(element, entityColumns) {
					var parameter = element.findParameterByName("DecisionalColumnMetaPath");
					var decisionalColumnMetaPath = parameter.getValue();
					if (decisionalColumnMetaPath) {
						var column = entityColumns.find(decisionalColumnMetaPath);
						var item = this.getDecisionalColumnItem(column);
						this.set("DecisionalColumn", item);
					}
				},

				/**
				 * Saves DecisionalColumnMetaPath parameter value.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveDecisionalColumn: function(element) {
					if (this.changedValues &&
						(this.changedValues.DecisionalColumn || this.changedValues.GenerateDecisionsFromColumn)) {
						var parameter = element.findParameterByName("DecisionalColumnMetaPath");
						var value = "null";
						var generateDecisionsFromColumn = this.get("GenerateDecisionsFromColumn");
						var decisionalColumn = this.get("DecisionalColumn");
						if (generateDecisionsFromColumn && decisionalColumn) {
							value = decisionalColumn.value;
						}
						var sourceValue = {
							value: value,
							source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
						};
						parameter.setMappingValue(sourceValue);
					}
				},

				/**
				 * The event handler for preparing of the data drop-down DecisionalColumn.
				 * @private
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareDecisionalColumnList: function(filter, list) {
					if (!list) {
						return;
					}
					var entityColumns = this.get("EntityColumns");
					var collection = new BPMSoft.Collection();
					entityColumns.each(function(column) {
						if (column.schemaColumn.dataValueType === BPMSoft.DataValueType.LOOKUP) {
							var item = this.getDecisionalColumnItem(column);
							collection.add(item.value, item);
						}
					}, this);
					list.clear();
					list.loadAll(collection);
				},

				/**
				 * Returns decisional column drop-down list item.
				 * @private
				 * @param {Object} column Entity schema column.
				 * @param {String} column.id Column identifier.
				 * @param {String} column.caption Column caption.
				 * @return {Object} Decisional column drop-down list item
				 * @return {String} return.value List item value.
				 * @return {String} return.displayValue List item display value.
				 * @return {String} return.referenceSchemaUId Column entity schema UId.
				 */
				getDecisionalColumnItem: function(column) {
					var item = null;
					if (column) {
						var schemaColumn = column.schemaColumn;
						var referenceSchemaUId = Ext.isObject(schemaColumn) ? schemaColumn.referenceSchemaUId : null;
						item = {
							value: column.id,
							displayValue: column.caption,
							referenceSchemaUId: referenceSchemaUId
						};
					}
					return item;
				},

				/**
				 * Returns whether DecisionalColumn is visible.
				 * @private
				 * @return {Boolean}
				 */
				isDecisionalColumnVisible: function() {
					var editMode = this.get("EditMode");
					var generateDecisionsFromColumn = this.get("GenerateDecisionsFromColumn");
					var decisionalColumnVisible = (editMode != null) && generateDecisionsFromColumn;
					return Boolean(decisionalColumnVisible);
				},

				// endregion

				// region ConsiderElementExecuted

				/**
				 * Initialization "ConsiderElementExecuted" attribute.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				initConsiderElementExecuted: function(element) {
					var parameter = element.findParameterByName("IsMatchConditions");
					var isMatchConditions = parameter.getValue();
					var afterRecordSavedIndex = this.get("ExecutedAfterRecordSavedIndex");
					var ifMatchConditionsIndex = this.get("ExecutedIfMatchConditionsIndex");
					var index = isMatchConditions ? ifMatchConditionsIndex : afterRecordSavedIndex;
					var list = this.getConsiderElementExecutedList();
					var value = list[index];
					this.set("ConsiderElementExecuted", value);
					this.on("change:ConsiderElementExecuted", this.onConsiderElementExecuted, this);
				},

				/**
				 * Returns ConsiderElementExecuted list.
				 * @private
				 * @return {Object}
				 */
				getConsiderElementExecutedList: function() {
					return {
						"0": {
							value: this.get("ExecutedAfterRecordSavedIndex"),
							displayValue: resources.localizableStrings.ExecutedAfterRecordSavedCaption
						},
						"1": {
							value: this.get("ExecutedIfMatchConditionsIndex"),
							displayValue: resources.localizableStrings.ExecutedIfMatchConditionsCaption
						}
					};
				},

				/**
				 * The event handler for preparing of the data drop-down ConsiderElementExecuted.
				 * @private
				 * @param {Object} filter Filters for data preparation.
				 * @param {BPMSoft.Collection} list The data for the drop-down list.
				 */
				prepareConsiderElementExecutedList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getConsiderElementExecutedList());
				},

				/**
				 * Flag that indicates whether FilterModule is visible.
				 * @return {Boolean}
				 */
				getIsFilterModuleVisible: function() {
					var considerElementExecuted = this.get("ConsiderElementExecuted");
					var ifMatchConditionsIndex = this.get("ExecutedIfMatchConditionsIndex");
					var isFilterVisible = considerElementExecuted &&
						(considerElementExecuted.value === ifMatchConditionsIndex);
					return isFilterVisible;
				},

				/**
				 * The event handler for change of the PageSchema attribute.
				 * @private
				 */
				onConsiderElementExecuted: function() {
					var isFilterVisible = this.getIsFilterModuleVisible();
					if (isFilterVisible) {
						this.updateFilterModule();
					} else {
						this.unloadFilterUnitModule();
					}
					this.setFilterInfoButtonVisible();
				},

				/**
				 * Saves ConsiderElementExecuted setting.
				 * @private
				 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
				 */
				saveConsiderElementExecuted: function(element) {
					var changes = this.changedValues;
					if (changes && changes.hasOwnProperty("ConsiderElementExecuted")) {
						var parameter = element.findParameterByName("IsMatchConditions");
						var sourceValue = {};
						var considerElementExecuted = this.get("ConsiderElementExecuted");
						if (!Ext.isEmpty(considerElementExecuted)) {
							var ifMatchConditionsIndex = this.get("ExecutedIfMatchConditionsIndex");
							var value = considerElementExecuted.value === ifMatchConditionsIndex;
							sourceValue = {
								value: value,
								source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
							};
						}
						parameter.setMappingValue(sourceValue);
					}
				},

				/**
				 * Select edit mode event handler.
				 * @private
				 * @param {Object} editMode Selected mode.
				 */
				onChangeEditMode: function(editMode) {
					if (editMode && editMode.value === this.get("EditExistingRecordIndex")) {
						this.clearEntityColumnMapping();
					} else {
						this.clearRecordId();
					}
				}

				// endregion
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"name": "PageSchemaId",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 24 },
						"labelConfig": { "visible": false },
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "preparePageSchemaList" },
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "UserTaskContainer",
					"propertyName": "items",
					"name": "EditMode",
					"values": {
						"layout": { "column": 0, "row": 2, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.EditModeCaption" },
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "prepareEditModeList" },
							"change": {
								"bindTo": "onChangeEditMode"
							}
						},
						"wrapClass": ["top-caption-control"],
						"visible": { "bindTo": "isEditModeVisible" }
					}
				},

				// region AddNewRecordContainer

				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "AddNewRecordContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": { "bindTo": "isAddNewRecordContainerVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "AddNewRecordContainer",
					"propertyName": "items",
					"name": "DefaultValuesLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.DefaultValuesLabelCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "AddNewRecordContainer",
					"propertyName": "items",
					"name": "RecordColumnValuesContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "EntityColumnMappingsControls",
						"onGetItemConfig": "getEntityColumnMappingsControlViewConfig",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "AddNewRecordContainer",
					"propertyName": "items",
					"name": "AddRecordColumnValuesButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.EntityColumnMapping_AddRecordColumnValuesButtonCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": { "bindTo": "Resources.Images.AddButtonImage" },
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": { "bindTo": "onAddEntityColumnMappings" }
					}
				},

				// endregion

				// region EditExistingRecordContainer

				{
					"operation": "insert",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"name": "EditExistingRecordContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": { "bindTo": "isEditExistingRecordContainerVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "EditExistingRecordContainer",
					"propertyName": "items",
					"name": "RecordId",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.RecordIdCaption" },
						"wrapClass": ["top-caption-control"],
						"isRequired": { "bindTo": "isEditExistingRecordContainerVisible" }
					}
				},

				// endregion

				// region BottomContainer

				{
					"operation": "insert",
					"name": "BottomContainer",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"visible": { "bindTo": "isBottomContainerVisible" }
					}
				},
				{
					"operation": "insert",
					"name": "Recommendation",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.RecommendationForFillPageCaption" },
						"wrapClass": ["top-caption-control"],
						"isRequired": true
					}
				},
				{
					"operation": "insert",
					"name": "InformationOnStep",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 1, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.InformationOnStepCaption" },
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ConsiderElementExecutedLabel",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 2, "colSpan": 24 },
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.ConsiderElementExecutedCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ConsiderElementExecuted",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 3, "colSpan": 24 },
						"labelConfig": { "visible": false },
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "prepareConsiderElementExecutedList" }
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"layout": { "column": 0, "row": 4, "colSpan": 23 },
						"id": "ExtendedFiltersContainer",
						"selectors": { "wrapEl": "#ExtendedFiltersContainer" },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["extended-filters-container"]
					}
				},
				{
					"operation": "insert",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"name": "FilterInfoButtonContainer",
					"values": {
						"layout": { "column": 23, "row": 4, "colSpan": 1 },
						"visible": {
							"bindTo": "FilterInfoButtonVisible"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "FilterInfoButtonContainer",
						"wrapClass": ["filter-info-button-container"]
					}
				},
				{
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
				},
				{
					"operation": "insert",
					"name": "GenerateDecisionsFromColumnContainer",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": { "column": 0, "row": 5, "colSpan": 24 },
						"items": [],
						"wrapClass": ["label-info-button-container-wrapClass"]
					}
				},
				{
					"operation": "insert",
					"parentName": "GenerateDecisionsFromColumnContainer",
					"propertyName": "items",
					"name": "GenerateDecisionsFromColumn",
					"values": {
						"caption": { "bindTo": "Resources.Strings.GenerateDecisionsFromColumnCaption" },
						"wrapClass": ["t-checkbox-control"]
					}
				},
				{
					"operation": "insert",
					"name": "HowElementPerformedButton",
					"parentName": "GenerateDecisionsFromColumnContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": { "bindTo": "Resources.Strings.HowElementPerformedLabelCaption" },
						"behaviour": {
							"displayEvent": BPMSoft.controls.TipEnums.displayEvent.CLICK
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"name": "DecisionalColumn",
					"values": {
						"layout": { "column": 0, "row": 6, "colSpan": 24 },
						"caption": { "bindTo": "Resources.Strings.DecisionalColumnMetaPathCaption" },
						"contentType": BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						},
						"controlConfig": {
							"prepareList": { "bindTo": "prepareDecisionalColumnList" }
						},
						"wrapClass": ["top-caption-control"],
						"visible": { "bindTo": "isDecisionalColumnVisible" },
						"isRequired": { "bindTo": "isDecisionalColumnVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "BottomContainer",
					"propertyName": "items",
					"name": "useBackgroundMode",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"controlConfig": {
							"classes": ["control-left"]
						},
						"visible": { "bindTo": "canUseBackgroundProcessMode" },
						"layout": { "column": 0, "row": 7, "colSpan": 24 }
					}
				},
				{
					"operation": "move",
					"name": "ActivityControlsContainer",
					"parentName": "BottomContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "ActivityControlsContainer",
					"parentName": "BottomContainer",
					"values": {
						"layout": { "column": 0, "row": 8, "colSpan": 24 },
					}
				}

				// endregion

			],

			rules: {
				"DecisionalColumn": {
					"RequireDecisionalColumnOnGenerateDecisionsFromColumn": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "GenerateDecisionsFromColumn"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						}]
					}
				}
			}

		};
	}
);
