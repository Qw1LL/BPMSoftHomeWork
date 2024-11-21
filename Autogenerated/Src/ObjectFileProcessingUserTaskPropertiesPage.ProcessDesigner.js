/**
 * Parent: BaseFileProcessingUserTaskPropertiesPage
 */
define("ObjectFileProcessingUserTaskPropertiesPage", ["ObjectFileProcessingUserTaskPropertiesPageResources",
		"ProcessSchemaUserTaskUtilities", "EntitySchemaDesignerUtilities", "ProcessUserTaskConstants",
		"FilterModuleMixin", "SortingOrderControlsMixin"],
	function(resources, userTaskUtilities) {
		return {
			properties: {
				_defaultRecordsToRead: 50
			},
			mixins: {
				sortingOrderControlsMixin: "BPMSoft.SortingOrderControlsMixin"
			},
			messages: {
			},
			attributes: {

				/**
				 * Source action type.
				 * @type {Integer}
				 */
				"SourceActionType": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: BPMSoft.ProcessUserTaskConstants.ObjectFileProcessingUserTaskSourceActionType.ReadFiles
				},

				/**
				 * Source entity schema unique identifier.
				 * @type {String}
				 */
				"SourceEntitySchemaUId": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "SysSchema",
					isRequired: true
				},

				/**
				 * Attribute for select control of an entity schema.
				 * @protected
				 * @type {Object}
				 */
				"SourceEntitySchemaSelect": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Collection of the sorting order.
				 * @protected
				 * @type {BPMSoft.ObjectCollection}
				 */
				"SortingOrderDirections": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Sorting order view config.
				 * @protected
				 * @type {Object}
				 */
				"SortingOrderViewConfig": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * View models of sorting orders.
				 * @protected
				 * @type {BPMSoft.ObjectCollection}
				 */
				"SortingOrderControls": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: this.Ext.create("BPMSoft.ObjectCollection")
				},

				/**
				 * Number of records to read.
				 * @type {Integer}
				 */
				"RecordsToRead": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_getSourceSchemaUIdParameterName: function() {
					return "SourceEntitySchemaUId";
				},

				/**
				 * @private
				 */
				_initRecordsToRead: function(element) {
					const parameter = element.findParameterByName("RecordsToRead");
					if (parameter) {
						const rowsCount = parameter.getValue();
						this.set("RecordsToRead", Ext.isEmpty(rowsCount)
							? this._defaultRecordsToRead
							: rowsCount !== "0" ? Number(rowsCount) : null)
					}
				},

				/**
				 * @private
				 */
				_resetSortingColumns: function() {
					const value = this.get("SortingOrderControls");
					if (value) {
						value.clear();
					}
				},

				/**
				 * Initializes SortingColumnsSelect needed by FilterModuleMixin
				 * @protected
				 */
				_initSortingColumnsSelect: function(schemaUId, callback, scope) {
					if (BPMSoft.isEmpty(schemaUId)) {
						Ext.callback(callback, scope);
						return;
					}
					const packageUId = this.get("packageUId");
					BPMSoft.EntitySchemaDesignerUtilities.getSortingColumnsSelectItems(packageUId, schemaUId,
						function(entitySchemaColumns) {
							this.set("EntitySchemaColumnsSelect", entitySchemaColumns);
							Ext.callback(callback, scope);
						}, this);
				},

				/**
				 * @private
				 */
				_onSourceEntitySchemaChanged: function(value) {
					this.onEntitySchemaChange(value, "Source", function(entitySchemaUId, changed) {
						if (changed) {
							this._initSortingColumnsSelect(entitySchemaUId, function() {
								this._resetSortingColumns();
								this.set("SourceEntitySchemaUId", entitySchemaUId);
								this.clearFilters();
							}, this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_saveRecordsToRead: function(element) {
					const recordsToRead = this.get("RecordsToRead");
					const rowsCount = recordsToRead && recordsToRead.toString();
					let parameter = element.findParameterByName("RecordsToRead");
					parameter.setMappingValue({
						value: rowsCount,
						source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
					});
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						BPMSoft.chain(function(next) {
								const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
								const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
								this._initSortingColumnsSelect(sourceSchemaUId, next, this);
							},
							this.initFilterModule,
							function() {
								this.set("ResultActionTypeList", Ext.create("BPMSoft.Collection"));
								this._initRecordsToRead(element);
								this.initSortingOrderControlsMixin(element);
								Ext.callback(callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterReferenceSchemaAttributeName
				 * @override
				 */
				getFilterReferenceSchemaAttributeName: function() {
					return this._getSourceSchemaUIdParameterName();
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getCanChangeElementConfig
				 * @override
				 */
				getCanChangeElementConfig: function() {
					const element = this.get("ProcessElement");
					const parentSchema = element.parentSchema;
					const parameter = element.findParameterByName("CreatedObjectFileIds");
					const checkResult = parentSchema.canRemoveParameter(parameter);
					return {
						canRemove: checkResult.canRemove,
						validationInfo: checkResult.validationInfo
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#saveReferencedSchemas
				 * @override
				 */
				saveReferencedSchemas: function(element) {
					this.callParent(arguments);
					const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
					this.saveReferenceSchemaUId(element, sourceSchemaUIdParameterName, sourceSchemaUIdParameterName);
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#saveValues
				 * @override
				 */
				saveValues: function() {
					const element = this.get("ProcessElement");
					this.saveSortingOrderInfo(element);
					this._saveRecordsToRead(element);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc SortingOrderControlsMixin#getOrderInfoParameterName
				 * @overridden
				 */
				getOrderInfoParameterName: function() {
					return "OrderByInfo";
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					const rowsCountRangeValidator = userTaskUtilities.validateRowsCountRange;
					this.addColumnValidator("RecordsToRead", rowsCountRangeValidator);
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getReferencedSchemaUIds
				 * @override
				 */
				getReferencedSchemaUIds: function(element) {
					const parentList = this.callParent(arguments);
					const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
					this.initReferenceSchemaUId(element, sourceSchemaUIdParameterName, sourceSchemaUIdParameterName, true);
					const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
					parentList.push(sourceSchemaUId);
					return parentList;
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#onGetEntitySchemas
				 * @override
				 */
				onGetEntitySchemas: function(fileEntities, callback, scope) {
					this.callParent([fileEntities, function() {
						const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
						const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
						this.set("SourceEntitySchemaSelect", fileEntities[sourceSchemaUId], { silent: true });
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getIsResultSettingsVisible
				 * @override
				 */
				getIsResultSettingsVisible: function() {
					return this.getIsSourceSchemaVisible();
				},

				/**
				 * Determines whether the source schema is visible or not.
				 * @protected
				 */
				getIsSourceSchemaVisible: function() {
					return this.getIsElementConfigured();
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getIsElementConfigured
				 * @override
				 */
				getIsElementConfigured: function() {
					const sourceSchemaAttributeName = this._getSourceSchemaUIdParameterName();
					const sourceSchemaUId = this.get(sourceSchemaAttributeName);
					return !BPMSoft.isEmpty(sourceSchemaUId);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SourceEntitySchemaSelectLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SourceEntitySchemaSelectCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "SourceEntitySchemaSelect",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "prepareFileEntityList" },
							"filterComparisonType": BPMSoft.StringFilterType.CONTAIN,
							"change": { "bindTo": "_onSourceEntitySchemaChanged" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "FilterUnitLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 23
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.FilterUnitCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"labelConfig": {
							"visible": {"bindTo": "getIsSourceSchemaVisible"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"id": "ExtendedFiltersContainer",
						"selectors": { "wrapEl": "#ExtendedFiltersContainer" },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["extended-filters-container"],
						"beforererender": { "bindTo": "unloadFilterUnitModule" },
						"afterrender": { "bindTo": "updateFilterModule" },
						"afterrerender": { "bindTo": "updateFilterModule" },
						"visible": { "bindTo": "getIsSourceSchemaVisible"  }
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "RowCountContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["row-count-container"],
						"visible": { "bindTo": "getIsSourceSchemaVisible" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "RowCountContainer",
					"propertyName": "items",
					"name": "RecordsToRead",
					"values": {
						"bindTo": "RecordsToRead",
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"caption": "$Resources.Strings.ReadOnlyCaption"
					}
				},
				{
					"operation": "insert",
					"name": "MoreLabel",
					"parentName": "RowCountContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.RecordsCaption"
					}
				},
				{
					"operation": "insert",
					"name": "OrderDirectionLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.OrderDirectionCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": {
							"bindTo": "getIsSourceSchemaVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "SortingOrderContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": { "bindTo": "getIsSourceSchemaVisible" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SortingOrderContainer",
					"propertyName": "items",
					"name": "SelectedSortingOrderContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "SortingOrderControls",
						"onGetItemConfig": "getSelectedSortingOrderViewConfig",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SortingOrderContainer",
					"propertyName": "items",
					"name": "AddSortingOrderButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddSortingOrderButtonCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {
							"bindTo": "onAddSortingOrderButtonClick"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
 