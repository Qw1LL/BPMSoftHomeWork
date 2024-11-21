define("ForecastColumnDesignerMiniPage", ["ForecastConstants", "css!ForecastColumnDesignerMiniPage"],
	function(ForecastConstants) {
		return {
			entitySchemaName: "ForecastColumn",
			properties: {
				loadedModuleId: "",
				forecastServiceName: "forecast.api"
			},
			messages: {
				/**
				 * Gets column config from loaded module.
				 */
				"GetColumnConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * Sign forecast column saved.
				 */
				"ForecastColumnSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * @inheritDoc BaseMiniPage#MiniPageModes
				 * @override
				 */
				"MiniPageModes": {
					"value": [
						this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						this.BPMSoft.ConfigurationEnums.CardOperation.EDIT
					]
				},

				/**
				 * Column title.
				 */
				"Title": {
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"isRequired": true,
					"value": ""
				},

				/**
				 * Column type.
				 */
				"Type": {
					"isRequired": true,
					"onChange": "switchColumnEditor"
				},

				/**
				 * Defines summary column edit case.
				 */
				"IsSummaryColumn" : {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Defines fractional part hidden case.
				 */
				"IsFractionalPartHidden" : {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Flag indicates does fractional part setting visible.
				 */
				"IsFractionalPartHiddenVisible" : {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
			},
			methods: {

				/**
				 * @inheritDoc BaseMiniPage#onEntityInitialized
				 * @protected
				 * @override
				 */
				onEntityInitialized: function() {
					this.miniPageContainerBottomOffset = 120;
					this.$OldType = this.$Type;
					this.$IsFractionalPartHidden = this._getColumnSettings().isFractionalPartHidden || false;
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseMiniPage#getMiniPageHeader
				 * @protected
				 * @override
				 */
				getMiniPageHeader: function() {
					return this.Ext.String.format(
						this.get("Resources.Strings.HeaderCaption"), (this.$Title != "" ? ": " + this.$Title : ""));
				},

				/**
				 * Switches type of editor.
				 * @param {Backbone.Model} model View model.
				 * @param {Object} selectedItem Selected item.
				 * @protected
				 * @virtual
				 */
				switchColumnEditor: function(model, selectedItem) {
					if (selectedItem == null) {
						return;
					}
					this._setIsFractionalPartHiddenVisible();
					switch (selectedItem.value) {
						case ForecastConstants.ColumnType.ObjectValue:
							this._loadColumnDesignerSchema("ValueFromObjectColumnDesigner", {
								forecastSourceItemName: this.$forecastSourceItemName
							});
							break;
						case ForecastConstants.ColumnType.Editable:
							this._loadColumnDesignerSchema("ForecastEditableColumnDesigner");
							break;
						case ForecastConstants.ColumnType.Formula:
							this._loadColumnDesignerSchema("FormulaColumnDesigner", {
								ForecastSheetId: this.$Sheet.value,
								IsSummaryColumn: this.$IsSummaryColumn,
							});
							break;
						default:
							break;
					}
				},

				/**
				 * @private
				 */
				_setIsFractionalPartHiddenVisible: function() {
					this.$IsFractionalPartHiddenVisible = this.$Type.value !== ForecastConstants.ColumnType.Editable;
				},

				/**
				 * @private
				 */
				_getModuleId: function(schemaName) {
					return this.sandbox.id + "_" + schemaName;
				},

				/**
				 * @private
				 */
				_loadColumnDesignerSchema: function(schemaName, viewModelInitialValues) {
					if (this.loadedModuleId) {
						this.sandbox.unloadModule(this.loadedModuleId);
					}
					if (!schemaName) {
						return;
					}
					this.loadedModuleId = this._getModuleId(schemaName);
					const viewModelConfig = {
						ColumnSettings: this._getColumnSettings()
					};
					this.Ext.apply(viewModelConfig, viewModelInitialValues);
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						id: this.loadedModuleId,
						renderTo: "ColumnEditorWrapContainer",
						instanceConfig: {
							generateViewContainerId: false,
							useHistoryState: false,
							schemaName: schemaName,
							isSchemaConfigInitialized: true,
							parameters: {
								viewModelConfig: viewModelConfig
							}
						},
						keepAlive: true
					});
				},

				/**
				 * @private
				 */
				_getColumnSettings: function() {
					return this.isNotEmpty(this.$Settings)
						? this.BPMSoft.decode(this.$Settings)
						: {};
				},

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#save
				 * @override
				 */
				save: function() {
					const columnConfig = this.sandbox.publish("GetColumnConfig", null, [this.loadedModuleId], this);
					if (this._isPreventSaving(columnConfig)) {
						this.validate();
						return;
					}
					if (this.isNotEmpty(columnConfig)) {
						columnConfig.isFractionalPartHidden = this.$IsFractionalPartHidden;
						this.$Settings = this.BPMSoft.encode(columnConfig);
					}
					const parentMethod = this.getParentMethod(this, arguments);
					this._validateColumn(function () {
						if (this._isTypeChanged() && this.isEditMode()) {
							this._deleteOldCells(parentMethod);
						} else {
							this.Ext.callback(parentMethod, this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_isPreventSaving: function(columnConfig) {
					return this.isEmpty(this.$Type) || (this.isEmpty(columnConfig));
				},

				/**
				 * @private
				 */
				_isTypeChanged: function() {
					const newTypeValue = this.$Type && this.$Type.value;
					const oldTypeValue = this.$OldType && this.$OldType.value;
					return newTypeValue !== oldTypeValue;
				},

				/**
				 * @private
				 */
				_deleteOldCells: function(callback) {
					const config = {
						serviceName: this.forecastServiceName,
						methodName: "forecast/cells/delete",
						data: {
							forecastId: this.$Sheet.value,
							columnId: this.$Id
						}
					};
					this.callService(config, callback, this);
				},

				/**
				 * @private
				 */
				_validateColumn: function(callback) {
					const config = {
						serviceName: this.forecastServiceName,
						methodName: "forecast/column/validate",
						data: {
							columnTypeId: this.$Type.value,
							settings: this.$Settings,
							type: this._getColumnType()
						}
					};
					this.callService(config, function(response) {
						response = response.GetIsValidColumnResult;
						if (response && response.success) {
							this.Ext.callback(callback, this);
							return;
						}
						this.showInformationDialog(response.errorInfo.message);
					}, this);
				},

				_getColumnType: function(){
					return this.$IsSummaryColumn
						? ForecastConstants.FormulaSettingType.Summary
						: ForecastConstants.FormulaSettingType.Default;
				},

				/**
				 * @inheritDoc BPMSoft.BaseMiniPage#onSaved
				 * @override
				 */
				onSaved: function() {
					this.sandbox.publish("ForecastColumnSaved", this.$Type.value, [this.sandbox.id], this);
					this.callParent(arguments);
				},

				/**
				 * Returns sign of new mode.
				 * @return {Boolean} True if is not new mode.
				 */
				isNotNewMode: function() {
					return !this.isNewMode();
				},

				/**
				 * Deletes column.
				 */
				deleteColumn: function() {
					const config = {
						serviceName: this.forecastServiceName,
						methodName: "forecast/column/delete",
						data: {
							columnId: this.$Id,
							sheetId: this.$Sheet.value
						}
					};
					this.callService(config, function(response) {
						response = response.DeleteColumnResult;
						if (response && response.success) {
							this.sandbox.publish("ForecastColumnSaved", null, [this.sandbox.id], this);
							this.close();
							return;
						}
						this.showInformationDialog(response.errorInfo.message);
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#destroy
				 * @override
				 */
				destroy: function() {
					this.sandbox.unloadModule(this.loadedModuleId);
					this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AlignableMiniPageContainer",
					"values": {
						"wrapClass": [
							"minipage-alignable-container",
							"forecast-column-designer-alignable-container"
						]
					}
				},
				{
					"operation": "merge",
					"name": "MiniPageContentContainer",
					"values": {
						"wrapClass": [
							"minipage-content-container",
							"forecast-column-designer-container"
						]
					}
				},
				{
					"operation": "merge",
					"name": "EditButtonsContainer",
					"values": {
						"wrapClass": [
							"base-minipage-edit-button-container",
							"forecast-column-designer-button-container"
						]
					}
				},
				{
					"operation": "remove",
					"name": "EditButtonsContainer",
				},
				{
					"operation": "insert",
					"name": "DesignerButtonsContainer",
					"parentName": "AlignableMiniPageContainer",
					"propertyName": "items",
					"values": {
						"id": "MiniPageEditButtonsContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["base-minipage-edit-button-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SaveEditButton",
					"parentName": "DesignerButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.SaveEditButtonCaption"},
						"classes": {
							"textClass": ["base-minipage-save-button"],
							"wrapperClass": ["base-minipage-save-button-wrapper"],
							"imageClass": ["base-minipage-action-button-image"]
						},
						"click": {"bindTo": "save"},
						"visible": {"bindTo": "isNotViewMode"},
						"hint": {"bindTo": "Resources.Strings.SaveEditButtonHint"}
					}
				},
				{
					"operation": "insert",
					"name": "CancelEditButton",
					"parentName": "DesignerButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.CancelEditButtonCaption"},
						"classes": {
							"textClass": ["base-minipage-cancel-button"],
							"wrapperClass": ["base-minipage-cancel-button-wrapper"],
							"imageClass": ["base-minipage-action-button-image"]
						},
						"click": {"bindTo": "close"},
						"visible": {"bindTo": "isNotViewMode"}
					}
				},
				{
					"operation": "insert",
					"name": "DeleteButton",
					"parentName": "DesignerButtonsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"caption": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
						"classes": {
							"textClass": ["delete-button"]
						},
						"enabled": {
							"bindTo": "isNotNewMode"
						},
						"click": {"bindTo": "deleteColumn"}
					},
				},
				{
					"operation": "merge",
					"name": "MiniPageHeaderCaption",
					"values": {
						"visible": true
					}
				},
				{
					"operation": "merge",
					"name": "OpenCurrentEntityPage",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"name": "CommonContainer",
					"parentName": "MiniPage",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["choose-column-container"],
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"items": []
					}
				},
				{
					"name": "Title",
					"parentName": "CommonContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"labelConfig": {
							"visible": true
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"name": "Type",
					"parentName": "CommonContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"enabled": {
							"bindTo": "IsSummaryColumn",
							"bindConfig": {"converter": "invertBooleanValue"},
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"name": "IsHide",
					"parentName": "CommonContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"wrapClass": [
							"hide-column-checkbox-container"
						],
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"name": "IsFractionalPartHidden",
					"parentName": "CommonContainer",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"wrapClass": [
							"fractional-part-checkbox-container"
						],
						"caption": {"bindTo": "Resources.Strings.IsFractionalPartHiddenCaption"},
						"visible": {"bindTo": "IsFractionalPartHiddenVisible"},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						}
					}
				},
				{
					"name": "ColumnEditor",
					"parentName": "MiniPage",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"id": "ColumnEditorWrapContainer",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
