/**
 * Parent: BasePageV2
 */
define("BaseProcessSettings", ["BaseWizardStepSchemaMixin",	"css!BaseProcessSettingsCSS"], function() {
	return {
		entitySchemaName: "ProcessInModules",
		mixins: {
			BaseWizardStepSchemaMixin: "BPMSoft.BaseWizardStepSchemaMixin"
		},
		messages: {
			"getCardInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * PackageUId.
			 */
			"PackageUId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.BaseWizardStepSchemaMixin.init.call(this, function() {
						this.hideBodyMask();
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config, next, scope) {
				this.set("PackageUId", config.packageUId);
				Ext.callback(next, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onValidate
			 * @override
			 */
			onValidate: function() {
				this.publishValidationResult(true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepSchemaMixin#onSave
			 * @override
			 */
			onSave: function() {
				this.publishSavingResult();
			}

			// endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "CardContentWrapper"
			},
			{
				"operation": "insert",
				"name": "BusinessProcessSettings",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["process-settings-container"]
					},
					"items": []
				}
			}
		]
	};
});
