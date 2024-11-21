define("DashboardGridDesigner", ["DashboardGridDesignerResources", "PivotDashboardGridModule", 
		"css!PivotTableDesignerCSS", "PivotTableUtilities"], function() {
	return {
		messages: {},
		mixins: {
			PivotTableUtilities: "BPMSoft.PivotTableUtilities"
		},
		attributes: {
			"PivotTableConfig": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"CustomModuleName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "PivotDashboardGridModule"
			},
			"PivotTableDesignerOptions": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"LoadPivotTableModuleDelay": {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 200
			},
			"IsValidPivotTableConfig": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {
			/**
			 * @inheritdoc
			 * @override
			 */
			initTabs: function() {
				this.callParent(arguments);
				const isEnabledPivotTable = BPMSoft.PivotTableUtilities.isEnabledPivotTable();
				if (!isEnabledPivotTable) {
					const tabs = this.$SittingsTabsCollection;
					tabs.removeByKey("PivotTableSettingsTab");
					return;
				}
				this.set("PivotTableSettingsTab", true);
			},

			/**
			 * @inheritdoc
			 * @override
			 */
			initWidgetDesigner: function() {
				this.loadPivotTablePreviewModuleDebounce = 
						BPMSoft.debounce(this._loadPivotTablePreviewModule, this.$LoadPivotTableModuleDelay);
				const isEnabledPivotTable = BPMSoft.PivotTableUtilities.isEnabledPivotTable();
				if (!isEnabledPivotTable) {
					this.callParent(arguments);
					return;
				}
				const parentMethod = this.getParentMethod();
				const parentMethodArgs = arguments;
				BPMSoft.require(["PivotTableDesigner"], function() {
					Ext.callback(parentMethod, this, parentMethodArgs);
				}, this);
			},

			/**
			 * Debounce load pivot table preview method.
			 * @protected
			 */
			loadPivotTablePreviewModuleDebounce: null,

			/**
			 * @inheritdoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.setTabDataContainerVisible("PivotTableSettingsTab", false);
			},

			/**
			 * @inheritdoc
			 * @override
			 */
			activeSettingsTabChange: function() {
				this.callParent(arguments);
				const widgetConfig = this.getDesignWidgetConfig();
				this._setPivotTableDesignerOptions(widgetConfig);
				this.loadPivotTablePreviewModuleDebounce();
			},

			/**
			 * @private
			 */
			_loadPivotTablePreviewModule: function() {
				const IsPivotTableSettingsTabInactive = this.get("ActiveTabName") !== "PivotTableSettingsTab";
				const isInvalidPivotTableConfig = !this.$IsValidPivotTableConfig;
				var moduleId = this.getWidgetPreviewModuleId();
				if (isInvalidPivotTableConfig || IsPivotTableSettingsTabInactive) {
					this.sandbox.unloadModule(moduleId);
					return;
				}
				this.sandbox.loadModule("PivotDashboardGridModule", {
					renderTo: "PivotTableComponent",
					id: moduleId
				});
			},

			/**
			 * Actualize pivot table config by grid columns.
			 * @protected
			 */
			actualizePivotTableConfig: function() {
				const pivotTableConfig = JSON.parse(this.$PivotTableConfig || "{}");
				const gridCongig = this.$gridConfig || {};
				const gridColumnsIdentifiers = BPMSoft.map(gridCongig.items, function(column) {
					return column.bindTo;
				});
				pivotTableConfig.rows = _.intersection(pivotTableConfig.rows, gridColumnsIdentifiers);
				pivotTableConfig.columns = _.intersection(pivotTableConfig.columns, gridColumnsIdentifiers);
				pivotTableConfig.aggregates = _.filter(pivotTableConfig.aggregates, function(agg) {
					return gridColumnsIdentifiers.indexOf(agg.aggregationField) >= 0;
				});
				this.set("PivotTableConfig", JSON.stringify(pivotTableConfig), { silent: true });
			},

			/**
			 * @inheritdoc
			 * @override
			 */
			setWidgetModuleProperties: function(widgetConfig, callback, scope) {
				this.callParent([
					widgetConfig, function() {
						this._setPivotTableDesignerOptions(widgetConfig);
						Ext.callback(callback, scope || this);
					}, scope || this
				]);
			},

			/**
			 * @private
			 */
			_setPivotTableDesignerOptions: function(widgetConfig) {
				const pivotTableConfig = widgetConfig.pivotTableConfig
					? JSON.parse(widgetConfig.pivotTableConfig)
					: this.getDefaultPivotTableConfig();
				const gridConfig = widgetConfig.gridConfig;
				this.$PivotTableDesignerOptions = {
					viewOptions: this.getPivotViewOptions(gridConfig),
					aggregationOptions: pivotTableConfig
				};
			},

			/**
			 * @inheritdoc
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				const dashboardGridProperties = {
					"PivotTableConfig": "pivotTableConfig",
					"CustomModuleName": "customModuleName"
				};
				return Ext.apply(this.callParent(arguments), dashboardGridProperties);
			},
			
			/**
			 * @inheritdoc
			 * @override
			 */
			applyGridConfig: function() {
				this.callParent(arguments);
				this.actualizePivotTableConfig();
			},

			/**
			 * Pivot table designer options changed event handler.
			 * @protected
			 * @param {Object} options Pivot table options.
			 */
			onPivotTableOptionsChanged: function(options) {
				options = options || {};
				if (BPMSoft.Features.getIsEnabled("UseColumnExpression")) {
					const fieldsOptions = options.viewOptions && options.viewOptions.fieldsOptions || [];
					this._handleFieldOptionsChanged(fieldsOptions);
				}
				const aggregationOptions = options.aggregationOptions;
				this._handleAggregationOptionsChanged(aggregationOptions);
				this.loadPivotTablePreviewModuleDebounce();
			},

			/**
			 * @param {Array<Object>} fieldsOptions
			 * @private
			 */
			_handleFieldOptionsChanged: function(fieldsOptions) {
				const gridConfig = this.get("gridConfig") || {};
				const gridColumns = gridConfig.items || [];
				const profileColumns = fieldsOptions.map(function(fieldOption) {
					const defaultPosition = {column: 0, colSpan: 2, row: 1};
					const expressionDataValueType = fieldOption.fieldExpression && fieldOption.fieldExpression.dataType;
					const changedOptions = {
						bindTo: fieldOption.fieldId,
						caption: fieldOption.fieldCaption,
						expression: fieldOption.fieldExpression,
						dataValueType: Ext.isEmpty(expressionDataValueType) ? fieldOption.fieldType : expressionDataValueType,
					};
					const profileColumn = BPMSoft.findWhere(gridColumns, {bindTo: fieldOption.fieldId}) || {};
					Ext.apply(profileColumn, changedOptions);
					if (!profileColumn.position) {
						profileColumn.position = defaultPosition;
					}
					return profileColumn;
				}, this);
				gridConfig.items = profileColumns;
				this.set("gridConfig", gridConfig);
			},

			/**
			 * @param {Object} aggregationOptions
			 * @private
			 */
			_handleAggregationOptionsChanged: function(aggregationOptions) {
				const pivotTableConfig = JSON.stringify(aggregationOptions);
				this.set("PivotTableConfig", pivotTableConfig, { silent: true });
				this.$IsValidPivotTableConfig = BPMSoft.PivotTableUtilities
					.validatePivotConfig(aggregationOptions);
			},

			/**
			 * Returns blank slate icon url.
			 * @protected
			 * @virtual
			 * @return {String} Blank slate icon url.
			 */
			getBlankSlateIcon: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.PivotTableBlankSlateIcon"));
			},
		},
		diff: [
			{
				"operation": "insert",
				"name": "PivotTableSettingsTab",
				"parentName": "SittingsTabs",
				"propertyName": "tabs",
				"values": {
					caption: {
						"bindTo": "Resources.Strings.PivotTableSettingsTabCaption"
					},
					items: []
				}
			},
			{
				"operation": "insert",
				"name": "PivotTableSettingsWrapper",
				"parentName": "PivotTableSettingsTab",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["pivot-table-settings-wrapper"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PivotTableSettings",
				"parentName": "PivotTableSettingsWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["pivot-table-settings-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "PivotTableSettings",
				"propertyName": "items",
				"name": "PivotTableDesigner",
				"values": BPMSoft.PivotTableUtilities.getPivotTableDesignerViewConfig()
			},
			{
				"operation": "insert",
				"name": "PivotTablePreview",
				"parentName": "PivotTableSettingsWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["pivot-table-preview-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PivotTableComponent",
				"parentName": "PivotTablePreview",
				"propertyName": "items",
				"values": {
					"id": "PivotTableComponent",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "IsValidPivotTableConfig",
						"bindConfig": { "converter": "toBoolean" }
					},
					"classes": {
						"wrapClassName": ["pivot-table-component-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PivotTableBlankSlate",
				"parentName": "PivotTablePreview",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "IsValidPivotTableConfig",
						"bindConfig": { "converter": "invertBooleanValue" }
					},
					"classes": {
						"wrapClassName": ["pivot-table-blank-slate"]
					},
					"items": []
				}				
			},
			{
				"operation": "insert",
				"name": "BlankSlateIcon",
				"parentName": "PivotTableBlankSlate",
				"propertyName": "items",
				"values": {
					"getSrcMethod": "getBlankSlateIcon",
					"readonly": true,
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"classes": {
						"wrapClass": ["blank-slate-icon"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BlankSlateDescription",
				"parentName": "PivotTableBlankSlate",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["blank-slate-description"]
					},
					"items": []
				}				
			},
			{
				"operation": "insert",
				"name": "BlankSlateDescriptionLabel",
				"parentName": "BlankSlateDescription",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.BlankSlateDescription"
					}
				}
			},
		]
	};
});

