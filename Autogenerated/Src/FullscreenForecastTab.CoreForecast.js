define("FullscreenForecastTab", [
		"ForecastTab",
		"ForecastSheetQueryMixin",
		"ImageCustomGeneratorV2",
		"css!ForecastModule",
		"css!ForecastsModule",
		"css!FullscreenViewModule",
		"css!FullscreenForecastModule"],
	function() {
		return {
			attributes: {
				"ForecastId": {
					dataValueType: this.BPMSoft.DataValueType.GUID,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"ForecastInfo": {
					dataValueType: this.BPMSoft.DataValueType.ENTITY,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"HeaderCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsBlankSlateVisible": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			mixins: {
				"ForecastSheetQueryMixin": "BPMSoft.ForecastSheetQueryMixin"
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_parseHash: function() {
					var currentState = this.sandbox.publish("GetHistoryState");
					var hashParts = currentState.hash.historyState.split("/");
					return {
						moduleName: hashParts[0],
						forecastId: hashParts[1]
					};
				},

				/**
				 * @private
				 */
				_initForecastId: function() {
					var hash = this._parseHash();
					this.$ForecastId = hash.forecastId;
				},

				/**
				 * @private
				 */
				_initHeaderCaption: function() {
					this.$HeaderCaption = this.get("Resources.Strings.ForecastModuleCaption");
					if (!this.Ext.isEmpty(this.$ForecastInfo) && !this.Ext.isEmpty(this.$ForecastInfo.$Name)) {
						this.$HeaderCaption = this.$ForecastInfo.$Name;
					}
					this.sandbox.publish("UpdatePageHeaderCaption", {
						pageHeaderCaption: this.$HeaderCaption
					});
				},

				/**
				 * @private
				 */
				_initBlankStateVisible: function() {
					this.$IsBlankSlateVisible = this.Ext.isIEOrEdge;
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this.showBodyMask();
					this.callParent(arguments);
					this._initBlankStateVisible();
					this._initForecastId();
				},

				/**
				 * @inheritdoc BPMSoft.ForecastTab#initForecasts
				 * @override
				 */
				initForecasts: function() {
					var parentMethod = this.getParentMethod();
					var args = arguments;
					this.loadForecasts(function() {
						this._initHeaderCaption();
						parentMethod.apply(this, args);
						this.hideBodyMask();
					}, this);
				},

				onRender: function() {
					this.callParent(arguments);
					this._initHeaderCaption();
				},

				/**
				 * Loads sorted by name forecasts.
				 * @protected
				 * @virtual
				 * @param {Function} callback Callback function.
				 * @param {BPMSoft.BaseModel} scope Context of callback function.
				 * @return {BPMSoft.Collection} Collection of forecasts.
				 */
				loadForecasts: function(callback, scope) {
					var esq = this.getForecastsEsq();
					esq.getEntity(this.$ForecastId, function(response) {
						if (response && response.success) {
							this.$ForecastInfo = response.entity;
							this.Ext.callback(callback, scope || this);
						}
					}, this);
				},

				/**
				 * @inheritdoc BPMSoft.ForecastTab#getForecastObject
				 * @override
				 */
				getForecastObject: function() {
					if (this.Ext.isEmpty(this.$ForecastInfo)) {
						return {};
					}
					return {
						"forecastId": this.$ForecastId,
						"forecastEntityId": this.$ForecastInfo.$ForecastEntityId,
						"forecastEntityName": this.$ForecastInfo.$ForecastEntityName,
						"forecastForecastEntityInCellUId": this.$ForecastInfo.$ForecastEntityInCellUId,
						"forecastSetting": this.$ForecastInfo.$Setting
					};
				},

				//endregion

				//region Methods: Public

				/**
				 * Returns blank slate icon url.
				 */
				getBlankSlateIcon: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.BlankSlateIcon"));
				},

				/**
				 * Returns back to Forecast Page.
				 */
				onCloseFullscreenClick: function() {
					const moduleName = "ForecastsModule";
					const previousUrl = Ext.String.format("ViewModule.aspx?#{0}/", moduleName);
					window.location = previousUrl;
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "BlankSlateContainer",
					"parentName": "ForecastModuleContainerMain",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["blank-slate-wrap"]
						},
						"visible": {
							"bindTo": "IsBlankSlateVisible"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateIcon",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getBlankSlateIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["blank-slate-icon"]
						},
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 5
						}
					}
				},
				{
					"operation": "insert",
					"name": "BlankSlateDescription",
					"parentName": "BlankSlateContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.BlankSlateDescription"
						},
						"labelClass": ["blank-slate-description"],
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24,
							"rowSpan": 5
						}
					}
				},
				{
					"operation": "merge",
					"name": "buttonContainer",
					"values": {
						"visible": {
							"bindTo": "IsBlankSlateVisible",
							"bindConfig": {"converter": "invertBooleanValue"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "fullscreenCloseButton",
					"parentName": "rightToolsContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"click": {"bindTo": "onCloseFullscreenClick"},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"markerValue": "fullscreenCloseButton",
						"selectors": {"wrapEl": "#actionsButton"},
						"imageConfig": {"bindTo": "Resources.Images.ToggleFullscreenIcon"},
						"menu": [],
						"visible": {
							"bindTo": "FullscreenForecastsEnabled"
						}
					}
				},
				{
					"operation": "merge",
					"name": "ForecastApp",
					"values": {
						"visible": {
							"bindTo": "IsBlankSlateVisible",
							"bindConfig": {"converter": "invertBooleanValue"}
						}
					}
				},
				{
					"operation": "merge",
					"name": "forecastDatetimeFilter",
					"values": {
						"wrapClass": ["fullscreen-forecast-datetime-filter-container"],
						"items": []
					}
				},
				{
					"operation": "remove",
					"name": "fullscreenButton",
				},
				{
					"operation": "insert",
					"name": "FullScreenForecastFooterContainer",
					"parentName": "centerPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "FullScreenForecastFooterContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["fullscreen-forecast-footer-container"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FullScreenForecastFooterContainer",
					"name": "ButtonsFullScreenForecastContainer",
					"propertyName": "items",
					"values": {
						"id": "ButtonsFullScreenForecastContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["fullscreen-forecast-buttons-wrapper"],
						"items": []
					}
				},
				{
					"operation": "move",
					"name": "addButton",
					"parentName": "ButtonsFullScreenForecastContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "addButton",
					"parentName": "ButtonsFullScreenForecastContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"classes": {"textClass": ["actions-button-margin-right"]},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					}
				},
				{
					"operation": "insert",
					"parentName": "ButtonsFullScreenForecastContainer",
					"name": "FullScreenForecastCloseButton",
					"propertyName": "items",
					"index": 0,
					"values": {
						"id": "FullScreenForecastCloseButton",
						"caption": BPMSoft.Resources.Controls.MessageBox.ButtonCaptionClose,
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"classes": {
							"wrapperClass": ["button"],
							"imageClass": ["button-image"],
							"textClass": ["actions-button-margin-right"]
						},
						"click": {"bindTo": "onCloseFullscreenClick"},
						"tag": "Close",
						"markerValue": "CloseResultPageButton"
					}
				},

				{
					"operation": "merge",
					"name": "ForecastApp",
					"values": {
						"visible": {
							"bindTo": "IsBlankSlateVisible",
							"bindConfig": {"converter": "invertBooleanValue"}
						},
						/**
						 * @override of ForecastTab => diff => ForecastApp.getExtraBottomOffset
						 * @returns {number}
						 */
						"getExtraBottomOffset": function() {
							const centerPanel = Ext.getCmp('FullScreenForecastFooterContainer');
							return centerPanel.getWrapEl().dom.offsetHeight;
						}
					}
				},
			]
		};
	}
);
