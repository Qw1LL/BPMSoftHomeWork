define("DataGridFilterPage", ["DataGridFilterPageResources", "FilterModuleMixin"],
	function(resources) {
	return {
		modules: {},
		attributes: {
			FilterData: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			SchemaName: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
		},
		messages: {
			"GetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"OnFiltersChanged": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * Returns sandbox's FilterEditModule Id.
			 * @private
			 * @return {string} Id of FilterEditModule.
			 */
			_getFilterEditModuleId: function() {
				return this.sandbox.id + "_FilterEditModule";
			},
			/**
			 * Hides mask
			 * @private
			 */
			_hidePlaceholder: function() {
				var body = Ext.getBody();
				body.set({
					"maskState": "none"
				});
			},
			/**
			 * Loads Filter module to display filters.
			 * @protected
			 */
			loadFilterModule: function() {
				var moduleId = this._getFilterEditModuleId();
				var sandbox = this.sandbox;
				sandbox.subscribe("OnFiltersChanged", this.onFiltersChanged, this, [moduleId]);
				sandbox.subscribe("GetFilterModuleConfig",
					this.onGetConditionFilterModuleConfig, this, [moduleId]);
				sandbox.loadModule("FilterEditModule", {renderTo: "GridFiltersContainer", id: moduleId});
			},
			/**
			 * Listener on filters changed.
			 * Sets value of FilterData attribute.
			 * @param {object} args { filter: object, serializedFilter: string } Filters.
			 * @protected
			 */
			onFiltersChanged: function(args) {
				this.set("FilterData", args.serializedFilter);
			},
			/**
			 * Returns FilterModuleConfig to load filter module.
			 * @protected
			 * @return {object} Filter module config.
			 */
			onGetConditionFilterModuleConfig: function() {
				return {
					rootSchemaName: this.get("SchemaName"),
					rightExpressionMenuAligned: true,
					filters: this.get("FilterData"),
					filterProviderClassName: "BPMSoft.EntitySchemaFilterProvider"
				};
			},
			/**
			 * @inheritdoc BPMSoft.BaseViewModule#init
			 * @overridde
			 */
			init: function() {
				this.callParent(arguments);
				this._hidePlaceholder();
				var historyState = this.sandbox.publish("GetHistoryState");
				var schemaName = historyState.hash.operationType || "BaseObject";
				this.set("SchemaName", schemaName);
				this.set("FilterData", window.FilterData || null);
			},
			/**
			 * @inheritdoc BPMSoft.BaseViewModel#onRender
			 * @override
			 */
			onRender: function() {
				this.loadFilterModule();
			},
			/**
			 * Saves the filter to the parent window
			 * @protected
			 */
			save: function() {
				// TODO Post message to Window.
				var filterData =  this.get("FilterData") || null;
				window.FilterData = filterData;
				console.log(filterData);
			},
			/**
			 * #ancels filter changes
			 * @protected
			 */
			cancel: function() {
				// TODO Post message to Window.
				console.log("Cancel button pressed ...");
			}
		},
		diff: [
			
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SaveButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {"bindTo": "save"},
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"classes": {
						"textClass": "actions-button-margin-right"
					},
					"click": {"bindTo": "cancel"},
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"values": {
					"classes": {
						"textClass": "center-panel",
						"wrapClassName": ["data-grid-filter-page-wrap"]
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainContainer",
				"propertyName": "items",
				"name": "FiltersContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "GridFiltersContainer",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"values": {
					"id": "GridFiltersContainer",
					"selectors": {"wrapEl": "#GridFiltersContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			}
		]
	};
});
