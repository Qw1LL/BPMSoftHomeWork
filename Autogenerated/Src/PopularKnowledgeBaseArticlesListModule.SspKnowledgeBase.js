define("PopularKnowledgeBaseArticlesListModule", ["BPMSoft", "ext-base",
		"PopularKnowledgeBaseArticlesListModuleResources", "PortalClientConstants", "BaseNestedModule",
		"GridUtilitiesV2", "ContainerListGenerator", "ContainerList", "DashboardGridModule", "css!PortalModulesCSS"],
	function(BPMSoft, Ext, resources, PortalClientConstants) {

		/**
		 * @class BPMSoft.configuration.PopularKnowledgeBaseArticlesListViewConfig
		 * ##### ############ ############ ############# ###### ###### ########## ###### ## #######.
		 */
		Ext.define("BPMSoft.configuration.PopularKnowledgeBaseArticlesListViewConfig", {
			extend: "BPMSoft.DashboardGridViewConfig",
			alternateClassName: "BPMSoft.PopularKnowledgeBaseArticlesListViewConfig",

			/**
			 * ########## ############ ############# ###### ###### ########## ###### ## #######.
			 * @protected
			 * @overridden
			 * @param {Object} config ###### ############.
			 * @return {Object[]} ########## ############ ############# ###### ###### ########## ###### ## #######.
			 */
			generate: function(config) {
				var columnsConfig = this.getColumnsConfig(config) || [];
				var entitySchema = config.entitySchema;
				var primaryColumnName = (entitySchema) ? entitySchema.primaryColumnName : "Id";
				var moduleId = BPMSoft.Component.generateId();
				return {
					"name": "gridContainer" + moduleId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["dashboard-grid-container portal-list", config.style]
					},
					"items": [
						{
							"name": "gridCaptionContainer" + moduleId,
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"classes": {
								"wrapClassName": ["default-widget-header", config.style]
							},
							"items": [
								{
									"name": "dashboard-grid-caption" + moduleId,
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": {
										"bindTo": "Resources.Strings.ListHeaderCaption"
									},
									"labelClass": "default-widget-header-label"
								},
								{
									"name": "dashboard-grid-gotobutton",
									"classes": {
										"wrapClassName": ["dashboard-grid-gotobutton", config.style],
										"textClass": "dashboard-grid-gotobutton"
									},
									"itemType": BPMSoft.ViewItemType.BUTTON,
									"caption": {
										"bindTo": "Resources.Strings.GoToKnowledgeBaseCaption"
									},
									"click": {
										"bindTo": "goToSectionModule"
									}
								}
							]
						},
						{
							"name": "DataGrid" + moduleId,
							"idProperty": primaryColumnName,
							"collection": {
								"bindTo": "GridData"
							},
							"classes": {
								wrapClassName: ["portal-dashboard-grid-list"]
							},
							"generator": "ContainerListGenerator.generatePartial",
							"itemType": BPMSoft.ViewItemType.GRID,
							"itemConfig": [
								{
									itemType: BPMSoft.ViewItemType.GRID_LAYOUT,
									name: "itemGridLayout",
									items: columnsConfig
								}
							]
						}
					]
				};
			}
		});

		/**
		 * @class BPMSoft.configuration.PopularKnowledgeBaseArticlesListViewModel
		 * ##### ###### ############# ###### ###### ########## ###### ## #######.
		 */
		Ext.define("BPMSoft.configuration.PopularKnowledgeBaseArticlesListViewModel", {
			extend: "BPMSoft.DashboardGridViewModel",
			alternateClassName: "BPMSoft.PopularKnowledgeBaseArticlesListViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * @inheritdoc BPMSoft.DashboardGridViewModel#initGridData
			 * @protected
			 * @overridden
			 */
			initGridData: function() {
				this.callParent(arguments);
				this.set("rowCount", 6);
			},

			/**
			 * ############## ###### ########## ######## ## ####### ########.
			 * @protected
			 * @overridden
			 */
			initResourcesValues: function() {
				var resourcesSuffix = "Resources";
				BPMSoft.each(resources, function(resourceGroup, resourceGroupName) {
					resourceGroupName = resourceGroupName.replace("localizable", "");
					BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
						var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
						this.set(viewModelResourceName, resourceValue);
					}, this);
				}, this);
			},


			/**
			 * ####### # ######.
			 * @private
			 */
			goToSectionModule: function() {
				var schemaName = this.get("entitySchemaName");
				var moduleStructure = BPMSoft.configuration.ModuleStructure;
				var module = moduleStructure[schemaName];
				var url = module.sectionModule + "/" + module.sectionSchema;
				this.sandbox.publish("PushHistoryState", {
					hash: url
				});
			}
		});

		/**
		 * @class BPMSoft.configuration.PopularKnowledgeBaseArticlesListModule
		 * ##### ###### ###### ########## ###### ## #######.
		 */
		Ext.define("BPMSoft.configuration.PopularKnowledgeBaseArticlesListModule", {
			extend: "BPMSoft.DashboardGridModule",
			alternateClassName: "BPMSoft.PopularKnowledgeBaseArticlesListModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,

			/**
			 * ### ###### ###### ############# ### ########## ######.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.PopularKnowledgeBaseArticlesListViewModel",

			/**
			 * ### ##### ########## ############ ############# ########## ######.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.PopularKnowledgeBaseArticlesListViewConfig",

			/**
			 * ### ##### ########## #############.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * ############## ###### ############ ######.
			 * @protected
			 * @overridden
			 */
			initConfig: function() {
				this.moduleConfig =	{
					"caption": "",
					"sectionId": PortalClientConstants.SysModule.PortalMainPageSectionId,
					"entitySchemaName": "KnowledgeBase",
					"filterData": "{\"className\":\"BPMSoft.FilterGroup\",\"items\":{},\"logicalOperation\":0," +
						"\"isEnabled\":true,\"filterType\":6,\"rootSchemaName\":\"KnowledgeBase\",\"key\":\"\"}",
					"style": "widget-blue",
					"orderDirection": 2,
					"orderColumn": "[Like:KnowledgeBase].Id",
					"rowCount": 10,
					"gridConfig": {
						"items": [
							{
								"bindTo": "Name",
								"type": "text",
								"position": {
									"column": 0,
									"colSpan": 24,
									"row": 1
								},
								"aggregationType": "",
								"metaPath": "Name",
								"path": "Name"
							},
							{
								"bindTo": "[Like:KnowledgeBase].Id",
								"type": "text",
								"position": {
									"column": 50,
									"colSpan": 0,
									"row": 1
								},
								"orderDirection": 2,
								"orderPosition": 1,
								"dataValueType": 4,
								"aggregationType": 1,
								"isBackward": true,
								"metaPath": "[Like:KnowledgeBase].Id",
								"path": "[Like:KnowledgeBase].Id",
								"referenceSchemaName": "Like"
							}
						]
					}
				};
			}

		});

		return BPMSoft.PopularKnowledgeBaseArticlesListModule;
	}
);
