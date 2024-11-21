define("WebPageDesigner", ["BPMSoft"],
	function(BPMSoft) {
		return {
			messages: {
				/**
				 * ######## ## ######### ### ######### ########## ############# ###### web-########.
				 */
				"GetWebPageConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ########## ######### ### ######### web-########.
				 */
				"GenerateWebPage": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * ####### ###### ######.
				 */
				url: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
				/**
				 * ####### ##### ######.
				 */
				style: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * ################ ####### ######## ##### (##### ##############).
				 */
				entitySchemaName: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: false
				}
			},
			methods: {
				/**
				 * ########## ######## ######### ######### ######## ###### #######.
				 * @protected
				 * @overridden
				 * @return {String} ########## ######## ######### ######### ######## ###### #######.
				 */
				getWidgetConfigMessage: function() {
					return "GetWebPageConfig";
				},

				/**
				 * ########## ######## ######### ########## #######.
				 * @protected
				 * @overridden
				 * @return {String} ########## ######## ######### ########## #######.
				 */
				getWidgetRefreshMessage: function() {
					return "GenerateWebPage";
				},

				/**
				 * ########## ############## ######.
				 * @protected
				 * @overridden
				 * @returns {string} ############# ######.
				 */
				getModuleId: function() {
					return this.sandbox.id;
				},

				/**
				 * ########## ######## ###### #######.
				 * @protected
				 * @overridden
				 * @return {String} ########## ######## ###### #######.
				 */
				getWidgetModuleName: function() {
					return "WebPageModule";
				},

				/**
				 * ############## #### # ############ # ############# ######.
				 * @protected
				 * @overridden
				 */
				initializeValues: function(callback, scope) {
					var config = this.sandbox.publish("GetModuleConfig", null, [this.getModuleId()]);
					this.loadFromColumnValues(config);
					callback.call(scope);
				},

				/**
				 * ########## ###### ########### ####### ###### ####### # ###### ######### #######.
				 * @protected
				 * @overridden
				 * @return {Object} ########## ###### ########### ####### ###### ####### # ###### ######### #######.
				 */
				getWidgetModulePropertiesTranslator: function() {
					var widgetModulePropertiesTranslator = {
						moduleName: "webPageName",
						caption: "caption",
						url: "url",
						style: "style"
					};
					return Ext.apply(this.callParent(arguments), widgetModulePropertiesTranslator);
				}
			},
			rules: {},
			diff: [
				{
					"operation": "remove",
					"name": "QueryProperties"
				},
				{
					"operation": "remove",
					"name": "EntitySchemaName"
				},
				{
					"operation": "remove",
					"name": "FilterPropertiesGroup"
				},
				{
					"operation": "remove",
					"name": "FilterProperties"
				},
				{
					"operation": "remove",
					"name": "SectionBindingGroup"
				},
				{
					"operation": "remove",
					"name": "sectionBindingColumn"
				},
				{
					"operation": "remove",
					"name": "FormatProperties"
				},
				{
					"operation": "insert",
					"name": "Url",
					"parentName": "WidgetProperties",
					"propertyName": "items",
					"values": {
						"bindTo": "url",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.TEXT,
						"labelConfig": {
							"visible": true,
							"caption": {
								"bindTo": "Resources.Strings.UrlEditCaption"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "Style",
					"parentName": "WidgetProperties",
					"propertyName": "items",
					"values": {
						"bindTo": "style",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": true,
							"caption": {
								"bindTo": "Resources.Strings.StyleEditCaption"
							}
						}
					}
				}
			]
		};
	});
