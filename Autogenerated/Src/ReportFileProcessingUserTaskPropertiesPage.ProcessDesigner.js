/**
 * Parent: BaseFileProcessingUserTaskPropertiesPage
 */
define("ReportFileProcessingUserTaskPropertiesPage", ["ReportFileProcessingUserTaskPropertiesPageResources",
		"ReportEngineClient", "EntitySchemaDesignerUtilities", "ProcessUserTaskConstants", "FilterModuleMixin",
		"SortingOrderControlsMixin"],
	function(resources, reportEngineClient) {
		return {
			mixins: {
				filterModuleMixin: "BPMSoft.FilterModuleMixin"
			},
			attributes: {

				/**
				 * Source action type.
				 * @type {Integer}
				 */
				"SourceActionType": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: BPMSoft.ProcessUserTaskConstants
						.ObjectFileProcessingUserTaskSourceActionType.GenerateReports
				},

				/**
				 * Report identifier.
				 * @type {String}
				 */
				"ReportId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					parameterBindConfig: {
						onInit: "initProperty",
						onSave: "saveParameter"
					}
				},

				/**
				 * Reports list.
				 * @type {BPMSoft.Collection}
				 */
				"ReportsList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Reports select.
				 * @type {BPMSoft.Collection}
				 */
				"ReportsSelect": {
					dataValueType: BPMSoft.DataValueType.ENUM,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Section name.
				 * @type {String}
				 */
				"SectionName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Determines whether to generate separate reports or not.
				 * @type {Boolean}
				 */
				"IsSeparateReports": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					parameterBindConfig: {
						onInit: "safeInitProperty",
						defaultValue: false,
						onSave: "saveParameter"
					}
				},

				/**
				 * Determines whether the IsSeparateReports checkbox is enabled or not.
				 * @type {Boolean}
				 */
				"IsSeparateReportsEnabled": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Report name.
				 */
				"ReportName": {
					dataValueType: BPMSoft.DataValueType.MAPPING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					parameterBindConfig: {
						onInit: "initPropertySilent",
						onSave: "saveParameter"
					}
				},

				/**
				 * Report entity schema unique identifier.
				 * @type {BPMSoft.Guid}
				 */
				"ReportEntitySchemaUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Report name data source column UId.
				 * @type {String}
				 */
				"ReportNameDataSourceColumnUId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					parameterBindConfig: {
						onInit: "_initDataSourceColumnUIdProperty",
						onSave: "saveParameter"
					}
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Subscribes on the model events.
				 * @private
				 */
				_subscribeEvents: function() {
					this.on("change:ReportEntitySchemaUId", this.onReportEntitySchemaUIdChanged, this);
					this.on("change:IsSeparateReports", this.onIsSeparateReportsChanged, this);
					this.on("change:ReportName", this.onReportNameChanged, this);
				},

				/**
				 * @private
				 */
				_prepareReportsList: function (filter, list) {
					if (!list) {
						return;
					}
					reportEngineClient.getReportTemplates(function(reports) {
						list.clear();
						list.loadAll(reports);
					}, this);
				},

				/**
				 * @private
				 */
				_initIsSeparateReportsAttributes: function(element, selectedReport) {
					if (!selectedReport) {
						return;
					}
					const isNotMsWordReportType = selectedReport.reportType !==
						BPMSoft.Reporting.Enums.ReportType.MsWord;
					this.set("IsSeparateReportsEnabled", isNotMsWordReportType);
					if (!isNotMsWordReportType) {
						this.set("IsSeparateReports", true);
					}
				},

				/**
				 * @private
				 */
				_initSelectedReport: function(callback, scope) {
					const reportId = this.get("ReportId");
					if (!reportId) {
						Ext.callback(callback, scope, [null]);
						return;
					}
					reportEngineClient.getReportTemplates(function(reports) {
						const selectedReport = reports.get(reportId);
						this.set("ReportsSelect", selectedReport);
						this.BPMSoft.EntitySchemaManager.initialize(function() {
							const schema = this.BPMSoft.EntitySchemaManager.findItemByName(
								selectedReport.entitySchemaName);
							if (schema) {
								this.set("ReportEntitySchemaUId", schema.uId);
							}
							const section = this._getSectionByEntitySchemaName(selectedReport.entitySchemaName);
							if (section) {
								this.set("SectionName", section.moduleCaption);
							}
							Ext.callback(callback, scope, [selectedReport]);
						}, this);
					}, this);
				},

				/**
				 * @private
				 */
				_getSectionByEntitySchemaName: function(entitySchemaName) {
					const results = BPMSoft.filter(BPMSoft.configuration.ModuleStructure, function(item) {
						return item.entitySchemaName === entitySchemaName;
					});
					return BPMSoft.firstOrDefault(results);
				},

				/**
				 * @private
				 */
				_changeReport: function(newReportId) {
					this.set("ReportId", newReportId);
					this._initSelectedReport(function(selectedReport) {
						const element = this.get("ProcessElement");
						this._initIsSeparateReportsAttributes(element, selectedReport);
						this.clearFilters();
					}, this);
				},

				/**
				 * @private
				 */
				_canSkipChangeReportDialog: function() {
					return Ext.isEmpty(this.$ReportId) || this.$FilterEditData.isEmpty();
				},

				/**
				 * @private
				 */
				_onReportChange: function(newReport) {
					const oldReportId = this.get("ReportId");
					const newReportId = newReport ? newReport.value : null;
					if (oldReportId === newReportId) {
						return;
					}
					if (this._canSkipChangeReportDialog()) {
						this._changeReport(newReportId);
						return;
					}
					const message = resources.localizableStrings.ChangeReportWarningMessage;
					this.checkCanChangeElementConfig(message, true, function() {
						this._changeReport(newReportId);
					}, function() {
						reportEngineClient.getReportTemplates(function(reports) {
							const oldReport = reports.get(oldReportId);
							this.set("ReportsSelect", oldReport);
						}, this);
					}, this);
				},

				/**
				 * @private
				 */
				_initSourceSchemaColumns: function(callback, scope) {
					const entitySchemaUId = this.get("ReportEntitySchemaUId");
					if (!entitySchemaUId) {
						this.set("SourceSchemaColumns", null);
						callback.call(scope || this);
						return;
					}
					const packageUId = this.get("packageUId");
					const config = {
						schemaUId: entitySchemaUId,
						packageUId: packageUId
					};
					this.BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
						const columns = schema ? schema.columns.clone() : null;
						this.set("SourceSchemaColumns", columns);
						callback.call(scope || this);
					}, this);
				},

				/**
				 * @private
				 */
				_clearReportNameDataSourceColumnValue: function() {
					this.set("ReportNameDataSourceColumnUId", null);
					this._initReportNameParameterDisplayValue();
				},

				/**
				 * @private
				 */
				_findReportNameParameter: function(element) {
					element = element || this.get("ProcessElement");
					return element.findParameterByName("ReportName");
				},

				/**
				 * @private
				 */
				_initReportNameParameterDisplayValue: function(isSilent) {
					const reportNameParameter = this._findReportNameParameter();
					const reportNameParameterName = reportNameParameter.name;
					const source = reportNameParameter.getValueSource();
					if (source !== BPMSoft.ProcessSchemaParameterValueSource.None) {
						return;
					}
					const displayValue = this._getReportNameParameterDisplayValue();
					this.set(reportNameParameterName, {
						value: displayValue,
						displayValue: displayValue,
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					}, {
						silent: isSilent
					});
				},

				/**
				 * @private
				 */
				_getReportNameParameterDisplayValue: function() {
					const columnUId = this.get("ReportNameDataSourceColumnUId");
					const sourceSchemaColumns = this.get("SourceSchemaColumns");
					const sourceSchemaColumn = sourceSchemaColumns ? sourceSchemaColumns.find(columnUId) : null;
					if (!sourceSchemaColumn) {
						return null;
					}
					const sourceColumnCaption = sourceSchemaColumn.caption || "";
					const displayValue = resources.localizableStrings.SelectionResult;
					return "[#" + displayValue + "." + sourceColumnCaption + "#]";
				},

				/**
				 * @private
				 */
				_setReportNameParameterDisplayValue: function() {
					const displayValue = this._getReportNameParameterDisplayValue();
					const options = {
						isSilent: true
					};
					this.applyParameterMappingEditValue("ReportName", {
						value: displayValue,
						displayValue: displayValue,
						source: BPMSoft.ProcessSchemaParameterValueSource.None
					}, options);
				},

				/**
				 * @private
				 */
				_initDataSourceColumnUIdProperty: function() {
					const element = this.get("ProcessElement");
					const parameter = element.findParameterByName("ReportNameDataSourceColumnUId");
					const parameterName = parameter.name;
					const parameterValue = this.getParameterValue(parameter);
					this.set(parameterName, parameterValue);
					this._initReportNameParameterDisplayValue(true);
				},

				//endregion

				//region Methods: Protected

				/**
				 * Handler for ReportEntitySchemaUId value change event.
				 * @protected
				 */
				onReportEntitySchemaUIdChanged: function() {
					this._initSourceSchemaColumns(function() {
						this._clearReportNameDataSourceColumnValue();
					}, this);
				},

				/**
				 * Handler for IsSeparateReports value change event.
				 * @protected
				 */
				onIsSeparateReportsChanged: function(sender, value) {
					if (value === false) {
						this._clearReportNameDataSourceColumnValue();
					}
				},

				/**
				 * Handler for ReportName value change event.
				 * @protected
				 */
				onReportNameChanged: function(sender, value, options) {
					if (!options || !options.isSilent) {
						this.set("ReportNameDataSourceColumnUId", null);
					}
				},

				/**
				 * @inheritdoc BPMSoft.FilterModuleMixin#getFilterReferenceSchemaAttributeName
				 * @override
				 */
				getFilterReferenceSchemaAttributeName: function() {
					return "ReportEntitySchemaUId";
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						BPMSoft.chain(function(next) {
							this.set("ReportsList", Ext.create("BPMSoft.Collection"));
							Ext.callback(next, this);
						},
						this._initSelectedReport,
						function(next, selectedReport) {
							this._initIsSeparateReportsAttributes(element, selectedReport);
							Ext.callback(next, this);
						},
						this.initFilterModule,
						this._initSourceSchemaColumns,
						function() {
							this._initReportNameParameterDisplayValue();
							this._subscribeEvents();
							Ext.callback(callback, scope);
						},
						this);
					}, this]);
				},

				/**
				 * @inheritDoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @protected
				 * @overridden
				 */
				saveParameters: function(element) {
					const reportNameParameter = "ReportName";
					const parameterValue = this.get(reportNameParameter);
					const noneValueSource = BPMSoft.ProcessSchemaParameterValueSource.None;
					if (!parameterValue || parameterValue.source === noneValueSource) {
						const value = {
							value: null,
							displayValue: null,
							source: BPMSoft.ProcessSchemaParameterValueSource.None
						};
						this.set(reportNameParameter, value, { silent: true });
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getIsResultSettingsVisible
				 * @override
				 */
				getIsResultSettingsVisible: function() {
					return this.getIsElementConfigured();
				},

				/**
				 * @inheritdoc BPMSoft.BaseFileProcessingUserTaskPropertiesPage#getIsElementConfigured
				 * @override
				 */
				getIsElementConfigured: function() {
					const reportId = this.get("ReportId");
					return Boolean(reportId);
				},

				/**
				 * @inheritdoc MappingEditMixin#onPrepareMenu
				 * @override
				 */
				onPrepareMenu: function(tag) {
					const isSeparateReports = this.get("IsSeparateReports");
					let sourceColumns = null;
					if (isSeparateReports && tag === "ReportName") {
						const sourceSchemaColumns = this.get("SourceSchemaColumns");
						const targetDataValueTypeInfo = {
							dataValueType: BPMSoft.DataValueType.TEXT
						};
						sourceColumns = BPMSoft.EntitySchemaDesignerUtilities.filterSourceSchemaColumns(
							sourceSchemaColumns, targetDataValueTypeInfo);
					}
					this.set("SourceColumns", sourceColumns);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc MappingEditMixin#onSourceColumnMenuItemClick
				 * @override
				 */
				onSourceColumnMenuItemClick: function(columnUId) {
					this.set("ReportNameDataSourceColumnUId", columnUId);
					this._setReportNameParameterDisplayValue();
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ReportsSelectLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.ReportsSelectCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": true
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "ReportsSelect",
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
							"prepareList": { "bindTo": "_prepareReportsList" },
							"change": { "bindTo": "_onReportChange" },
							"list": { "bindTo": "ReportsList" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"],
						"visible": true
					}
				},
				{
					"operation": "insert",
					"name": "SectionNameLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": { "bindTo": "Resources.Strings.SectionCaption" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": { "bindTo": "getIsResultSettingsVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "SectionName",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"enabled": false,
						"wrapClass": ["no-caption-control"],
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"bindTo": "SectionName",
						"visible": { "bindTo": "getIsResultSettingsVisible"  }
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
							"row": 6,
							"colSpan": 23
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.FilterUnitCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"labelConfig": {
							"visible": { "bindTo": "getIsResultSettingsVisible" }
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
							"row": 7,
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
						"visible": { "bindTo": "getIsResultSettingsVisible"  }
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "IsSeparateReports",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"visible": { "bindTo": "getIsResultSettingsVisible" },
						"enabled": { "bindTo": "IsSeparateReportsEnabled" },
						"caption": { "bindTo": "Resources.Strings.IsSeparateReportsCaption" },
						"wrapClass": ["t-checkbox-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ReportNameLabelContainer",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 9,
							"colSpan": 24
						},
						"visible": { "bindTo": "getIsResultSettingsVisible" },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"classes": {
							"wrapClassName": ["not-compile", "label-container"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ReportNameLabel",
					"parentName": "ReportNameLabelContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ReportNameCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ReportNameLabelContainer",
					"propertyName": "items",
					"name": "ReportNameLabelInfoButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.ReportNameInfoButtonContent"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "ReportName",
					"values": {
						"layout": {
							"column": 0,
							"row": 10,
							"colSpan": 24
						},
						"visible": { "bindTo": "getIsResultSettingsVisible" },
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"controlConfig": {
							"allowInlineEditing": true
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
