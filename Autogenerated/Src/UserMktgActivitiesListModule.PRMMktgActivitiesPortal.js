define("UserMktgActivitiesListModule", ["BPMSoft", "ext-base", "UserMktgActivitiesListModuleResources",
		"PortalClientConstants", "BaseNestedModule", "GridUtilitiesV2", "ContainerListGenerator", "ContainerList",
		"DashboardGridModule", "css!PortalModulesCSS"],
	function(BPMSoft, Ext, resources, PortalClientConstants) {

		/**
		 * @class BPMSoft.configuration.UserMktgActivitiesListViewConfig
		 * Class generating a representation of the module configuration list of activities on the portal.
		 */
		Ext.define("BPMSoft.configuration.UserMktgActivitiesListViewConfig", {
			extend: "BPMSoft.DashboardGridViewConfig",
			alternateClassName: "BPMSoft.UserMktgActivitiesListViewConfig",

			/**
			 * Generates a configuration presentation module of activities.
			 * @protected
			 * @overridden
			 * @param {Object} config Configuration object.
			 * @return {Object[]} Returns configuration presentation module requests a list activities on the portal.
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
						wrapClassName: ["dashboard-grid-container", config.style]
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
										"textClass": "dashboard-grid-gotobutton"
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
								wrapClassName: ["dashboard-grid-list"]
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
		 * @class BPMSoft.configuration.UserMktgActivitiesListViewModule
		 * Class model representation of the module on the portal a list of activities.
		 */
		Ext.define("BPMSoft.configuration.UserMktgActivitiesListViewModule", {
			extend: "BPMSoft.DashboardGridViewModel",
			alternateClassName: "BPMSoft.UserMktgActivitiesListViewModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * Initializes model resource values from the resource object.
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
			 * Generates a configuration for a custom message on empty registry.
			 * @protected
			 * @param {Object} config The configuration for custom reports of empty registry.
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
			 * Returns the configuration of submission of the empty registry.
			 * @param {Object} emptyGridMessageProperties Parameters reported empty registry.
			 * @return {Object} Configuration of submission of the empty registry.
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
			 * Opens add an entry card.
			 * @private
			 */
			openAddCard: function() {
				var addCardUrl = this.getAddCardUrl();
				this.sandbox.publish("PushHistoryState", {
					hash: addCardUrl
				});
			},

			/**
			 * Creates a link to add an entry card.
			 * @private
			 * @returns {String} Link to add an entry card.
			 */
			getAddCardUrl: function() {
				var schemaName = this.get("entitySchemaName");
				var moduleStructure = BPMSoft.configuration.ModuleStructure;
				var module = moduleStructure[schemaName];
				var addCardUrl = module.cardModule + "/" + module.cardSchema + "/add";
				return addCardUrl;
			},

			/**
			 * Generates html for advice unit.
			 * @private
			 * @param {String} recommendation Report recommendations.
			 * @returns {String} Html for recommendations block.
			 */
			getRecommendationHtml: function(recommendation) {
				var addCardUrl = this.getAddCardUrl();
				var startTagPart = "<a class=\"t-label label-link\" href=\"ViewModule.aspx#" + addCardUrl + "\">";
				var endTagPart = "</a>";
				var recommendationHtml = this.Ext.String.format(recommendation, startTagPart, endTagPart);
				return recommendationHtml;
			},

			/**
			 * @inheritdoc DashboardGridViewConfig#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var filterGroup = this.callParent(arguments);
				filterGroup.add("ActiveFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "[Partnership:Id:Partnership].IsActive", true));
				return filterGroup;
			}
		});

		/**
		 * @class BPMSoft.configuration.UserMktgActivitiesListModule
		 * Class module activities on the portal List.
		 */
		Ext.define("BPMSoft.configuration.UserMktgActivitiesListModule", {
			extend: "BPMSoft.DashboardGridModule",
			alternateClassName: "BPMSoft.UserMktgActivitiesListModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,

			/**
			 * Name of the class presentation models for embedded module.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.UserMktgActivitiesListViewModule",

			/**
			 * Generator class name embedded module configuration representation.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.UserMktgActivitiesListViewConfig",

			/**
			 * Generator Class Name of the view.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * Initializes the module configuration.
			 * @protected
			 * @overridden
			 */
			initConfig: function() {
				this.moduleConfig =	{
					"caption": "",
					"sectionId": PortalClientConstants.SysModule.PortalMainPageSectionId,
					"entitySchemaName": "MktgActivity",
					"filterData": "{\"className\":\"BPMSoft.FilterGroup\",\"items\":{},\"logicalOperation\":0," +
					"\"isEnabled\":true,\"filterType\":6,\"rootSchemaName\":\"MktgActivity\",\"key\":\"\"}",
					"style": "widget-violet",
					"orderDirection": 2,
					"orderColumn": "Name",
					"gridConfig": {
						"items": [
							{
								"bindTo": "Name",
								"type": "text",
								"position": {
									"column": 0,
									"colSpan": 10,
									"row": 1
								},
								"aggregationType": "",
								"metaPath": "Name",
								"path": "Name"
							},
							{
								"bindTo": "SpentBudget",
								"type": "title",
								"position": {
									"column": 10,
									"colSpan": 4,
									"row": 1
								},
								"dataValueType": 1,
								"aggregationType": "",
								"metaPath": "SpentBudget",
								"path": "SpentBudget"
							},
							{
								"bindTo": "Status.Name",
								"type": "title",
								"position": {
									"column": 14,
									"colSpan": 10,
									"row": 1
								},
								"dataValueType": 10,
								"aggregationType": "",
								"metaPath": "Status",
								"path": "Status"
							}
						]
					}
				};
			}

		});

		return BPMSoft.UserMktgActivitiesListModule;
	}
);
