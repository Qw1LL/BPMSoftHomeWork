define("FullscreenViewModule", ["BaseViewModule"],
		function() {
			/**
			 * @class BPMSoft.configuration.FullscreenViewModule
			 */
			Ext.define("BPMSoft.configuration.FullscreenViewModule", {
				extend: "BPMSoft.BaseViewModule",
				alternateClassName: "BPMSoft.FullscreenViewModule",

				/**
				 * Difference of view config.
				 * @type {Object[]}
				 */
				diff: [
					{
						"operation": "insert",
						"name": "centerPanelContainer",
						"values": {
							"id": "centerPanelContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["fullscreen-center-panel"],
							"selectors": {"wrapEl": "#centerPanelContainer"},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "mainHeader",
						"parentName": "centerPanelContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.MODULE,
							"moduleName": "FullscreenHeaderModule"
						}
					},
					{
						"operation": "move",
						"name": "centerPanel",
						"parentName": "centerPanelContainer",
						"propertyName": "items"
					}
				],

				/**
				 * @protected
				 */
				loadClientMessageBridge: function() {
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						id: this.sandbox.id + "_clientMessageBridge",
						instanceConfig: {
							generateViewContainerId: false,
							useHistoryState: false,
							schemaName: "ClientMessageBridge",
							isSchemaConfigInitialized: true
						}
					});
				},

				/**
				 * @protected
				 */
				loadMultiDeleteResultSchema: function() {
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						id: this.sandbox.id + "_multiDeleteResultModule",
						instanceConfig: {
							generateViewContainerId: false,
							useHistoryState: false,
							schemaName: "MultiDeleteResultSchema",
							isSchemaConfigInitialized: true
						},
						keepAlive: true
					});
				},

				/**
				 * @inheritdoc BaseViewModule#loadNonVisibleModules
				 * @override
				 */
				loadNonVisibleModules: function() {
					this.callParent(arguments);
					this.sandbox.loadModule("MiniPageListener");
					this.loadClientMessageBridge();
					this.loadMultiDeleteResultSchema();
				}

			});

			return BPMSoft.FullscreenViewModule;
		});
