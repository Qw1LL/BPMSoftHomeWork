define("UserCasesListModule", ["BPMSoft", "ext-base", "UserCasesListModuleResources", "PortalClientConstants",
		"BaseNestedModule", "GridUtilitiesV2", "ContainerListGenerator", "ContainerList", "DashboardGridModule",
		"css!PortalModulesCSS"],
	function(BPMSoft, Ext, resources, PortalClientConstants) {

		/**
		 * @class BPMSoft.configuration.UserCasesListViewConfig
		 * ##### ############ ############ ############# ###### ###### ######### ## #######.
		 */
		Ext.define("BPMSoft.configuration.UserCasesListViewConfig", {
			extend: "BPMSoft.DashboardGridViewConfig",
			alternateClassName: "BPMSoft.UserCasesListViewConfig",

			/**
			 * ########## ############ ############# ###### ###### ######### ## #######.
			 * @protected
			 * @overridden
			 * @param {Object} config ###### ############.
			 * @return {Object[]} ########## ############ ############# ###### ###### ######### ## #######.
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
									"name": "dashboard-grid-createbutton",
									"classes": {
										"wrapClassName": ["default-widget-createbutton", config.style],
										"textClass": "dashboard-grid-createbutton"
									},
									"itemType": BPMSoft.ViewItemType.BUTTON,
									"caption": {
										"bindTo": "Resources.Strings.CreateButtonCaption"
									},
									"click": {
										"bindTo": "openAddCard"
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
							"getEmptyMessageConfig": {
								"bindTo": "prepareEmptyGridMessageConfig"
							},
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
		 * @class BPMSoft.configuration.UserCasesListViewModel
		 * ##### ###### ############# ###### ###### ######### ## #######.
		 */
		Ext.define("BPMSoft.configuration.UserCasesListViewModel", {
			extend: "BPMSoft.DashboardGridViewModel",
			alternateClassName: "BPMSoft.UserCasesListViewModel",

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
			 * ######### ############ ### ################# ######### # ###### #######.
			 * @protected
			 * @param {Object} config ############ ### ################# ######### # ###### #######.
			 */
			prepareEmptyGridMessageConfig: function(config) {
				var emptyGridMessageProperties = {
					title: this.get("Resources.Strings.EmptyInfoTitle"),
					recommendation: this.get("Resources.Strings.EmptyInfoRecommendation"),
					image: this.get("Resources.Images.EmptyInfoImage")
				};
				var emptyGridMessageViewConfig = this.getEmptyGridMessageViewConfig(emptyGridMessageProperties);
				this.Ext.apply(config, emptyGridMessageViewConfig);
			},

			/**
			 * ########## ############ ############# ######### # ###### #######.
			 * @param {Object} emptyGridMessageProperties ######### ######### # ###### #######.
			 * @return {Object} ############ ############# ######### # ###### #######.
			 */
			getEmptyGridMessageViewConfig: function(emptyGridMessageProperties) {
				var config = {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["empty-container-list-message"]
					},
					items: []
				};
				config.items.push({
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["image-container"]
					},
					items: [
						{
							className: "BPMSoft.ImageEdit",
							readonly: true,
							classes: {
								wrapClass: ["image-control"]
							},
							imageSrc: this.BPMSoft.ImageUrlBuilder.getUrl(emptyGridMessageProperties.image)
						}
					]
				});
				var descriptionConfig = {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["description"]
					},
					items: []
				};
				descriptionConfig.items.push({
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["message"]
					},
					items: [
						{
							className: "BPMSoft.Label",
							caption: emptyGridMessageProperties.title
						}
					]
				});

				var recommendation = emptyGridMessageProperties.recommendation;
				if (!this.Ext.isEmpty(recommendation)) {
					descriptionConfig.items.push({
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["separator"]
						},
						items: [
							{
								selectors: {
									wrapEl: ".separator"
								},
								className: "BPMSoft.HtmlControl"
							}
						]
					});
					var recommendationHtml = this.getRecommendationHtml(recommendation);
					descriptionConfig.items.push({
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["reference"]
						},
						items: [
							{
								selectors: {
									wrapEl: ".reference"
								},
								className: "BPMSoft.HtmlControl",
								html: recommendationHtml
							}
						]
					});
					config.items.push(descriptionConfig);
				}
				return config;
			},

			/**
			 * ######### ######## ########## ######.
			 * @private
			 */
			openAddCard: function() {
				var addCardUrl = this.getAddCardUrl();
				this.sandbox.publish("PushHistoryState", {
					hash: addCardUrl
				});
			},

			/**
			 * ######### ###### ## ######## ########## ######.
			 * @private
			 * @returns {String} ###### ## ######## ########## ######.
			 */
			getAddCardUrl: function() {
				var schemaName = this.get("entitySchemaName");
				var moduleStructure = BPMSoft.configuration.ModuleStructure;
				var module = moduleStructure[schemaName];
				var addCardUrl = module.cardModule + "/" + module.cardSchema + "/add";
				return addCardUrl;
			},

			/**
			 * ######### html ### ##### ############.
			 * @private
			 * @param {String} recommendation ######### ### ############.
			 * @returns {String} Html ### ##### ############.
			 */
			getRecommendationHtml: function(recommendation) {
				var addCardUrl = this.getAddCardUrl();
				var startTagPart = "<a class=\"t-label label-link\" href=\"ViewModule.aspx#" + addCardUrl + "\">";
				var endTagPart = "</a>";
				var recommendationHtml = this.Ext.String.format(recommendation, startTagPart, endTagPart);
				return recommendationHtml;
			}
		});

		/**
		 * @class BPMSoft.configuration.UserCasesListModule
		 * ##### ###### ###### ######### ## #######.
		 */
		Ext.define("BPMSoft.configuration.UserCasesListModule", {
			extend: "BPMSoft.DashboardGridModule",
			alternateClassName: "BPMSoft.UserCasesListModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,

			/**
			 * ### ###### ###### ############# ### ########## ######.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.UserCasesListViewModel",

			/**
			 * ### ##### ########## ############ ############# ########## ######.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.UserCasesListViewConfig",

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
					"entitySchemaName": "Case",
					"filterData": "{\"className\":\"BPMSoft.FilterGroup\",\"items\":{},\"logicalOperation\":0," +
						"\"isEnabled\":true,\"filterType\":6,\"rootSchemaName\":\"Case\",\"key\":\"\"}",
					"style": "widget-green",
					"orderDirection": 2,
					"orderColumn": "RegisteredOn",
					"rowCount": 10,
					"gridConfig": {
						"items": [
							{
								"bindTo": "Number",
								"type": "text",
								"position": {
									"column": 0,
									"colSpan": 6,
									"row": 1
								},
								"aggregationType": "",
								"metaPath": "Number",
								"path": "Number"
							},
							{
								"bindTo": "Subject",
								"type": "title",
								"position": {
									"column": 6,
									"colSpan": 18,
									"row": 1
								},
								"dataValueType": 1,
								"aggregationType": "",
								"metaPath": "Subject",
								"path": "Subject"
							},
							{
								"bindTo": "RegisteredOn",
								"type": "title",
								"position": {
									"column": 50,
									"colSpan": 0,
									"row": 1
								},
								"orderDirection": 2,
								"orderPosition": 1,
								"dataValueType": 7,
								"aggregationType": "",
								"metaPath": "RegisteredOn",
								"path": "RegisteredOn"
							}
						]
					}
				};
			}

		});

		return BPMSoft.UserCasesListModule;
	}
);
