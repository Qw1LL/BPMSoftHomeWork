/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("BaseActivityUserTaskPropertiesPage", ["BPMSoft", "BaseActivityUserTaskPropertiesPageResources", "Activity",
	"ext-base", "ProcessLookupPageMixin", "ActivityConnectionsEditMixin"
], function(BPMSoft) {
	return {
		mixins: {
			processLookupPageMixin: "BPMSoft.ProcessLookupPageMixin",
			activityConnectionsEditMixin: "BPMSoft.ActivityConnectionsEditMixin"
		},
		attributes: {
			/**
			 * Activity connection view models.
			 */
			"ActivityConnectionViewModels": {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: this.Ext.create("BPMSoft.ObjectCollection")
			},
			/**
			 * Entity connections.
			 */
			"EntityConnections": {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ActivityConnectionsEditMixin#getVisibleActivityCategory
			 * @overridden
			 */
			getIsActivityTaskVisible: function() {
				return !this.getIsActivityModuleEnabled();
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
			 * @overridden
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				const activityModuleDisabled = !this.getIsActivityModuleEnabled();
				this.mixins.activityConnectionsEditMixin.init.call(this, activityModuleDisabled);
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#saveParameters
			 * @overridden
			 */
			saveParameters: function(element) {
				this.callParent(arguments);
				if (!this.getIsActivityModuleEnabled()) {
					this.saveActivityConnectionParameters(element);
				}
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsOptionalActivitySupported
			 * @overridden
			 */
			getIsOptionalActivitySupported: function() {
				return false;
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsActivityModuleEnabled
			 * @overridden
			 */
			getIsActivityModuleEnabled: function() {
				return true;
			},

			//endregion

			//region Methods: Private

			/**
			 * Returns ModalBox  captions .
			 * @protected
			 */
			getModalBoxCaption: function() {
				return this.get("Resources.Strings.ProcessLookupPageCaption");
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"name": "Recommendation",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "BaseActivityTaskContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "ActivityControlsContainer",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "ActivityControlsContainer",
				"parentName": "BaseActivityTaskContainer",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
				}
			},
			{
				"operation": "insert",
				"name": "useBackgroundMode",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"visible": { "bindTo": "canUseBackgroundProcessMode" },
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"name": "InformationOnStep",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"caption": { "bindTo": "Resources.Strings.InformationOnStepCaption" },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnectionTitleContainer",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["container-list-header"],
					"items": [],
					"visible": { "bindTo": "getIsActivityTaskVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnectionLabel",
				"parentName": "ActivityConnectionTitleContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.ActivityLinksCaption" },
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddActivityConnectionRecordButton",
				"parentName": "ActivityConnectionTitleContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": { "bindTo": "Resources.Images.AddButtonImage" },
					"click": { "bindTo": "openLookupActivityConnectionWindow" }
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnection",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "ElementId",
					"onItemClick": { "bindTo": "onItemClick" },
					"collection": "ActivityConnectionViewModels",
					"onGetItemConfig": "getConnectionParameterViewConfig",
					"rowCssSelector": ".paramContainer",
					"classes": { "wrapClassName": ["activity-connection"] },
					"visible": { "bindTo": "getIsActivityTaskVisible" }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
