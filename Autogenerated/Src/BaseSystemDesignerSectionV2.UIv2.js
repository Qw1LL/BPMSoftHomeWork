define("BaseSystemDesignerSectionV2", ["BPMSoft", "SystemDesignerDashboardsModule", "SystemDesignerDashboardBuilder",
		"SystemDesignerDashboardsViewModel"],
	function(BPMSoft) {
		return {
			/**
			 * #########, ########### ### ########## ############ ############ #####
			 * @type {Object}
			 */
			messages: {
				/**
				 * @message NeedHeaderCaption
				 * ######### # ############# ######### ######### ########.
				 */
				"NeedHeaderCaption": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ChangeHeaderCaption
				 * ######### ### ########## ######### ########.
				 * @param {Object} config ################ ###### #########.
				 * @param {String} config.caption ######### ########.
				 * @param {BPMSoft.Collection} config.dataViews ######### #############.
				 * @param {String} config.moduleName ######## ######.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message RerenderModule
				 * ########## ######### ############# ###### ######.
				 * @return {Boolean} ######### ###### ######.
				 */
				"RerenderModule": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * ###### ###### ############# #######
			 * @type {Object}
			 */
			methods: {
				/**
				 * ############## ######### ######### ###### #############.
				 * @protected
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ########.
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.subscribeSandboxEvents();
						this.initDashboardEnums();
						this.initMainHeaderCaption();
						callback.call(scope);
					}, this]);
				},

				/**
				 * ########## ######## ######### #######.
				 * @protected
				 */
				onRender: function() {
					this.loadDashboardModule();
				},

				/**
				 * ########## ######## ## ######### sandbox.
				 * @protected
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("NeedHeaderCaption", this.initMainHeaderCaption, this);
				},

				/**
				 * ######### ######### ######### ########.
				 * @protected
				 */
				initMainHeaderCaption: function() {
					var dataViews = this.Ext.create("BPMSoft.Collection");
					var caption = this.getCaption();
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: caption,
						dataViews: dataViews,
						moduleName: this.name
					});
				},

				/**
				 * ######### ###### ###### ### ########### ######.
				 * @protected
				 */
				loadDashboardModule: function() {
					var moduleId = this.sandbox.id + "_SystemDesignerDashboards";
					var renderTo = "SectionItemsContainer";
					var rendered = this.sandbox.publish("RerenderModule", {
						renderTo: renderTo
					}, [moduleId]);
					if (!rendered) {
						this.sandbox.loadModule("SystemDesignerDashboardsModule", {
							renderTo: renderTo,
							id: moduleId
						});
					}
				},

				/**
				 * ########## ######### #######.
				 * @virtual
				 * @return {String} ######### #######.
				 */
				getCaption: function() {
					return this.get("Resources.Strings.SectionCaption");
				},

				/**
				 * ######### ########### ### ######### ###### ####### ######## ############.
				 * @private
				 */
				initDashboardEnums: function() {
					var tileWidgetType = {
						"view": {
							"moduleName": "SystemDesignerTileModule",
							"configurationMessage": "GetSystemDesignerTileConfig"
						},
						"design": {
							"moduleName": "ConfigurationModuleV2",
							"configurationMessage": "GetSystemDesignerTileConfig",
							"resultMessage": "PostModuleConfig",
							"stateConfig": {
								"stateObj": {
									"designerSchemaName": "SystemDesignerTileConfigEdit"
								}
							}
						}
					};
					var wigetType = BPMSoft.DashboardEnums.WidgetType;
					if (!wigetType.hasOwnProperty("SystemDesignerTile")) {
						wigetType.SystemDesignerTile = tileWidgetType;
					}
				},

				/**
				 * @protected
				 * @overridden
				 */
				destroy: function() {
					var wigetType = BPMSoft.DashboardEnums.WidgetType;
					var historyState = this.sandbox.publish("GetHistoryState");
					var state = historyState.state;
					var moduleId = state.moduleId ? state.moduleId : "";
					if (wigetType.hasOwnProperty("SystemDesignerTile") && moduleId.indexOf("SystemDesigner") === -1) {
						delete wigetType.SystemDesignerTile;
					}
					this.callParent(arguments);
					this.destroyed = true;
				}
			},

			/**
			 * ############# #######
			 * @type {Object[]}
			 */
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SectionItemsContainer",
					"values": {
						"id": "SectionItemsContainer",
						"selectors": {"wrapEl": "#SectionItemsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["system-designer-section-container-wrapClass"],
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
