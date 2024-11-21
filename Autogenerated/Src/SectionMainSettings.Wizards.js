define("SectionMainSettings", [
	"SectionMainSettingsResources"
], function() {
	return {
		messages: {
			/**
			 * Subscribing on message who call when MiniPage module settings is initialized.
			 */
			"MiniPageModuleSettingsInitialized": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * Publishing message for saving MiniPage settings.
			 */
			"SaveSectionMiniPageSettings": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Initialized.
			 */
			"Initialized": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				onChange: "onCaptionChange",
				dependencies: [
					{
						columns: ["PropertyInitialized", "MultiPageInitialized", "SectionPageSettingsInitialized",
							"MiniPageModuleSettingsInitialized", "VisaSettingsInitialized"],
						methodName: "onInitialized"
					}
				]
			},
			/**
			 * Indicates if MiniPageModuleSettings initialized.
			 */
			"MiniPageModuleSettingsInitialized": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		modules: {
			"MultiPageModule": {
				config: {
					schemaName: "SectionPageSettings",
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			},
			"MiniPageSettingsModule": {
				config: {
					schemaName: "SectionMiniPageSettings",
					isSchemaConfigInitialized: true,
					useHistoryState: false
				}
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_subscribeMiniPageSettingsMessages: function() {
				const tag = this.getMiniPageSettingsModuleId();
				this.sandbox.subscribe("GetSysModuleSettings", this.onGetSysModuleSettings, this, [tag]);
				this.sandbox.subscribe("MiniPageModuleSettingsInitialized", this.onMiniPageModuleSettingsInitialized, this, [tag]);
				this.sandbox.subscribe("GetEntitySchemaInstance", this._onGetEntitySchemaInstance, this, [tag]);
				this.sandbox.subscribe("PageSettingsChanged", this.onPageSettingsChanged, this, [tag]);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionMainSettings#getSubModulesIsInitedColumns
			 * @override
			 */
			getSubModulesIsInitedColumns: function() {
				var columns = this.callParent(arguments);
				columns.push("MiniPageModuleSettingsInitialized");
				return columns;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionMainSettings#subscribeMessages
			 * @override
			 */
			subscribeMessages: function() {
				this._subscribeMiniPageSettingsMessages();
				this.callParent(arguments);
			},

			/**
			 * Handler for message MiniPageModuleSettingsInitialized.
			 * @protected
			 */
			onMiniPageModuleSettingsInitialized: function() {
				this.set("MiniPageModuleSettingsInitialized", true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionMainSettings#saveAditionalInfo
			 * @override
			 */
			saveAditionalInfo: function(callback, scope) {
				this.callParent([function() {
					BPMSoft.chain(
						function(next) {
							var tag = this.getMiniPageSettingsModuleId();
							this.sandbox.publish("SaveSectionMiniPageSettings", next, [tag]);
						},
						function() {
							Ext.callback(callback, scope);
						},
						this
					);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionMainSettings#publishChangeModuleSettingsMessage
			 * @override
			 */
			publishChangeModuleSettingsMessage: function(message) {
				this.callParent(arguments);
				this.sandbox.publish("ChangeModuleSettings", message, [this.getMiniPageSettingsModuleId()]);
			},

			/**
			 * Returns MiniPageSettingsModule id.
			 * @protected
			 * @return {String}
			 */
			getMiniPageSettingsModuleId: function() {
				return Ext.String.format("{0}_module_MiniPageSettingsModule", this.sandbox.id);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionMainSettings#afterPageSettingsChanged
			 * @override
			 */
			afterPageSettingsChanged: function(moduleEntity) {
				const settings = {
					sysModuleEntityUId: moduleEntity.id,
					packageUId: this.get("packageUId"),
					sectionManagerItemId: this.get(this.sectionManagerItemColumnName).getId()
				};
				this.sandbox.publish("ChangeModuleSettings", settings, [this.getMiniPageSettingsModuleId()]);
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "MainSettingsWrapper",
				"propertyName": "items",
				"name": "SectionMiniPageSettingsModuleContainer",
				"index": 2,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["mini-page-settings-module-container"]},
					"items": [
						{
							"name": "MiniPageSettingsModule",
							"itemType": BPMSoft.ViewItemType.MODULE
						}
					]
				}
			}
		]
	};
});
