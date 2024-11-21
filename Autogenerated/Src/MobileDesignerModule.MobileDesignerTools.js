define("MobileDesignerModule", ["ext-base", "BPMSoft", "MobileDesignerModuleResources", "SectionDesignerUtils", "LookupUtilities", "MobileDesignerUtils", "LocalizableHelper", "BaseViewModule", "ImageView"],
		function(Ext, BPMSoft, resources) {

			/**
			 * @class BPMSoft.configuration.MobileDesignerModule
			 * Visual module of mobile application wizard.
			 */
			Ext.define("BPMSoft.configuration.MobileDesignerModule", {
				extend: "BPMSoft.BaseViewModule",
				alternateClassName: "BPMSoft.MobileDesignerModule",
				isAsync: true,

				/**
				 * @inheritDoc BPMSoft.configuration.BaseViewModule
				 * @overridden
				 */
				defaultHomeModule: "MobileSectionDesignerSchemaModule",

				/**
				 * Difference of view config.
				 * @type {Object[]}
				 */
				diff: [
					{
						"operation": "insert",
						"name": "MobileDesignerContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["mobile-designer-container"],
							"id": "mobileDesignerContainer",
							"selectors": {"wrapEl": "#mobileDesignerContainer"},
							"markerValue": "mobileDesignerContainer",
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "MobileDesignerHeaderContainer",
						"parentName": "MobileDesignerContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["mobile-designer-header-container"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "MobileDesignerLabel",
						"parentName": "MobileDesignerHeaderContainer",
						"propertyName": "items",
						"values": {
							"id": "mobileDesignerLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": resources.localizableStrings.DesignerCaption
						}
					},
					{
						"operation": "insert",
						"name": "RightHeaderContainer",
						"parentName": "MobileDesignerHeaderContainer",
						"propertyName": "items",
						"values": {
							"id": "right-header-container",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["right-header-container-class"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "RightLogoContainer",
						"parentName": "RightHeaderContainer",
						"propertyName": "items",
						"values": {
							"id": "main-header-logo-container",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["main-header-logo-container-class"],
							"visible": {"bindTo": "IsLogoVisible"},
							"items": []
						}
					},

					{
						"operation": "insert",
						"name": "centerPanelContainer",
						"values": {
							"id": "centerPanelContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["center-panel"],
							"selectors": { "wrapEl": "#centerPanelContainer" },
							"items": []
						}
					},
					{
						"operation": "move",
						"name": "centerPanel",
						"parentName": "centerPanelContainer",
						"propertyName": "items",
						"index": 0
					}
				],

				/**
				 * @private
				 */
				getWorkplaceType: function(workplaceCode, callback) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysMobileWorkplace"
					});
					esq.addColumn("Id");
					esq.addColumn("Type", "Type");
					esq.filters.add("filterCode", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Code", workplaceCode));
					esq.getEntityCollection(function(result) {
						var items = result.collection.getItems();
						var workplaceTypeId = null;
						if (result.success && (items.length > 0)) {
							var type = items[0].get("Type");
							workplaceTypeId = type && type.value;
						}
						Ext.callback(callback, this, [workplaceTypeId]);
					}, this);
				},

				/**
				 * Subscribes on messages.
				 * @protected
				 * @virtual
				 */
				subscribeMessages: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("ChangeHeaderCaption", this.updateDesignerCaption, this);
				},

				/**
				 * Updates caption of designer.
				 * @public
				 * @param {Object} config Configuration object.
				 * @param {String} config.caption Caption of the page.
				 */
				updateDesignerCaption: function(config) {
					var label = Ext.getCmp("mobileDesignerLabel");
					label.caption = label.markerValue = config.caption;
					label.reRender();
				},

				/**
				 * @inheritDoc BPMSoft.configuration.BaseViewModule
				 * @overridden
				 */
				loadModuleFromHistoryState: function() {
					var currentState = this.sandbox.publish("GetHistoryState");
					var currentStateHash = currentState.hash;
					var workplace = currentStateHash.moduleName;
					this.getWorkplaceType(workplace, function(workplaceTypeId) {
						this.sandbox.loadModule(this.defaultHomeModule, {
							renderTo: "centerPanel",
							instanceConfig: {
								workplace: workplace,
								workplaceTypeId: workplaceTypeId
							}
						});
					});
				},

				/**
				 * @inheritDoc BPMSoft.configuration.BaseViewModule
				 * @overridden
				 */
				render: function(renderTo) {
					renderTo.addCls("section-designer-shown");
					this.callParent(arguments);
				}

			});

			return BPMSoft.MobileDesignerModule;
		});
