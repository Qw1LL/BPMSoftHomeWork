define("CampaignDiagramToolsModule", ["CampaignDiagramToolsModuleResources", "CampaignLocalizableHelper",
		"CampaignEnums", "BaseNestedModule",
		"CampaignDraggableContainer"],
	function(resources, LocalizableHelper, CampaignEnums) {

		/**
		 * @class BPMSoft.configuration.CampaignDiagramToolsViewConfig
		 * ##### ############ ############ ############# ###### ###### ############ ########.
		 */
		Ext.define("BPMSoft.configuration.CampaignDiagramToolsViewConfig", {
			extend: "BPMSoft.BaseModel",
			alternateClassName: "BPMSoft.CampaignDiagramToolsViewConfig",

			/**
			 * ########## ############ ############# ###### ###### ############ ########.
			 * @protected
			 * @virtual
			 * @return {Object[]} ########## ############ ############# ###### ###### ############ ########.
			 */
			generate: function() {
				return {
					"name": "CampaignDiagramTools",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["campaign-diagram-tools-container"],
					"items": [
						{
							"name": "Row-1",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-caption"],
							"items": [
								{
									"name": "ToolsCaption",
									"itemType": BPMSoft.ViewItemType.LABEL,
									"caption": resources.localizableStrings.ToolsCaption,
									"classes": {
										"labelClass": ["tools-caption"]
									}
								}
							]
						},
						{
							"name": "Row-2",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-icon"],
							"items": [
								{
									"name": "EmailToolIconDrag",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"className": "BPMSoft.CampaignDraggableContainer",
									"wrapClass": ["drag-icon-container"],
									"onDragDrop": {"bindTo": "onToolsIconDrop"},
									"tag": "Email",
									"items": [
										{
											"name": "EmailToolIcon",
											"getSrcMethod": "getEmailToolIconSrc",
											"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
											"onPhotoChange": BPMSoft.emptyFn,
											"classes": {
												"wrapClass": ["tools-icon"]
											}
										}
									]
								}
							]
						},
						{
							"name": "Row-4",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-icon"],
							"items": [
								{
									"name": "EventToolIconDrag",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"className": "BPMSoft.CampaignDraggableContainer",
									"wrapClass": ["drag-icon-container"],
									"onDragDrop": {"bindTo": "onToolsIconDrop"},
									"tag": "Event",
									"items": [
										{
											"name": "EventToolIcon",
											"getSrcMethod": "getEventToolIconSrc",
											"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
											"onPhotoChange": BPMSoft.emptyFn,
											"classes": {
												"wrapClass": ["tools-icon"]
											}
										}
									]
								}
							]
						},
						{
							"name": "Row-6",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-icon"],
							"items": [
								{
									"name": "LandingToolIconDrag",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"className": "BPMSoft.CampaignDraggableContainer",
									"wrapClass": ["drag-icon-container"],
									"onDragDrop": {"bindTo": "onToolsIconDrop"},
									"tag": "Landing",
									"items": [
										{
											"name": "LandingToolIcon",
											"getSrcMethod": "getLandingToolIconSrc",
											"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
											"onPhotoChange": BPMSoft.emptyFn,
											"classes": {
												"wrapClass": ["tools-icon"]
											}
										}
									]
								}
							]
						},
						{
							"name": "Row-8",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-icon"],
							"items": [
								{
									"name": "AudienceToolIconDrag",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"className": "BPMSoft.CampaignDraggableContainer",
									"wrapClass": ["drag-icon-container"],
									"onDragDrop": {"bindTo": "onToolsIconDrop"},
									"tag": "Audience",
									"items": [
										{
											"name": "AudienceToolIcon",
											"getSrcMethod": "getAudienceToolIconSrc",
											"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
											"onPhotoChange": BPMSoft.emptyFn,
											"classes": {
												"wrapClass": ["tools-icon"]
											}
										}
									]
								}
							]
						},
						{
							"name": "Row-10",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["tools-cell", "tools-cell-icon"],
							"items": [
								{
									"name": "CreateLeadToolIconDrag",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"className": "BPMSoft.CampaignDraggableContainer",
									"wrapClass": ["drag-icon-container"],
									"onDragDrop": {"bindTo": "onToolsIconDrop"},
									"tag": "CreateLead",
									"items": [
										{
											"name": "CreateLeadToolIcon",
											"getSrcMethod": "getCreateLeadToolIconSrc",
											"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
											"onPhotoChange": BPMSoft.emptyFn,
											"classes": {
												"wrapClass": ["tools-icon"]
											}
										}
									]
								}
							]
						}
					]
				};
			}
		});

		/**
		 * @class BPMSoft.configuration.CampaignDiagramToolsViewModel
		 * ##### ###### ###### ############ ########.
		 */
		Ext.define("BPMSoft.configuration.CampaignDiagramToolsViewModel", {
			extend: "BPMSoft.BaseModel",
			alternateClassName: "BPMSoft.CampaignDiagramToolsViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			onRender: Ext.emptyFn,

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback
			 */
			init: function(callback, scope) {
				callback.call(scope);
			},

			/**
			 * ########## URL-##### ###### ########.
			 * @protected
			 * @return {String} URL-#####.
			 */
			getEmailToolIconSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(LocalizableHelper.localizableImages.StepTypeEmailToolImage);
			},

			/**
			 * ########## URL-##### ###### ##########.
			 * @protected
			 * @return {String} URL-#####.
			 */
			getEventToolIconSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(LocalizableHelper.localizableImages.StepTypeEventToolImage);
			},

			/**
			 * ########## URL-##### ###### #######.
			 * @protected
			 * @return {String} URL-#####.
			 */
			getLandingToolIconSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(LocalizableHelper.localizableImages.StepTypeLandingToolImage);
			},

			/**
			 * ########## URL-##### ###### #########.
			 * @protected
			 * @return {String} URL-#####.
			 */
			getAudienceToolIconSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(LocalizableHelper.localizableImages.StepTypeAudienceToolImage);
			},

			/**
			 * ########## URL-##### ###### ####### ###.
			 * @protected
			 * @return {String} URL-#####.
			 */
			getCreateLeadToolIconSrc: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(LocalizableHelper.localizableImages.StepTypeCreateLeadImage);
			},

			/**
			 * ######### ####### drop ########.
			 * @protected
			 * @param {Object} event ###.
			 */
			onToolsIconDrop: function(event) {
				var config = {nodes: []};
				var node = CampaignEnums["GetDefault" + event.element.tag + "Node"]();
				node.offsetX = event.localX;
				node.offsetY = event.localY;
				config.nodes.push(node);
				this.sandbox.publish("ToolIconDropped", config, [this.sandbox.id]);
			}
		});

		/**
		 * @class BPMSoft.configuration.CampaignDiagramToolsModule
		 * ###### ###### ############ ########.
		 */
		Ext.define("BPMSoft.configuration.CampaignDiagramToolsModule", {
			extend: "BPMSoft.BaseNestedModule",
			alternateClassName: "BPMSoft.CampaignDiagramToolsModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: false,

			/**
			 * ### ###### ###### ############# ### ###### ##########.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.CampaignDiagramToolsViewModel",

			/**
			 * ### ##### ########## ############ ############# ###### ##########.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.CampaignDiagramToolsViewConfig",

			/**
			 * ### ##### ########## #############.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * ####### ######### ###### BPMSoft.ViewGenerator.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.ViewGenerator} ########## ###### BPMSoft.ViewGenerator.
			 */
			createViewGenerator: function() {
				return Ext.create(this.viewGeneratorClass);
			},

			/**
			 * ####### ############ ############# ########## ######.
			 * @protected
			 * @virtual
			 * param {Object} config ###### ############.
			 * param {Function} callback ####### ######### ######.
			 * param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
			 * @return {Object[]} ########## ############ ############# ########## ######.
			 */
			buildView: function(config, callback, scope) {
				var viewGenerator = this.createViewGenerator();
				var viewClass = Ext.create(this.viewConfigClassName);
				var schema = {
					viewConfig: [viewClass.generate(config)]
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig) || {};
				generatorConfig.viewModelClass = this.viewModelClass;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.viewModelClass = Ext.ClassManager.get(this.viewModelClassName);
				callback.call(scope);
			}
		});

		return BPMSoft.CampaignDiagramToolsModule;
	});
