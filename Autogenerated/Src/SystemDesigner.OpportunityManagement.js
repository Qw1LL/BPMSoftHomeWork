define("SystemDesigner", ["ProcessModuleUtilities", "OppManagementMigrationUtils"], function(ProcessModuleUtilities) {
	return {
		mixins: {
			"OppManagementMigrationUtils": "BPMSoft.OppManagementMigrationUtils"
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initOldProcessUsageState(callback, scope);
				}, this]);
			},

			/**
			 * Returns {@link BPMSoft.ProcessModuleUtilities} instance.
			 * @private
			 * @return {BPMSoft.ProcessModuleUtilities}
			 */
			getProcessModuleUtilities: function() {
				return ProcessModuleUtilities;
			},

			/**
			 * Starts OpportunityManagement actualization process.
			 * @private
			 */
			runActualizeOpportunityManagementProcess: function(callback) {
				var processUtils = this.getProcessModuleUtilities();
				this.showBodyMask();
				processUtils.executeProcess({
					sysProcessName: "ActualizeOpportunityManagement",
					callback: function() {
						this.hideBodyMask();
						callback.call(this);
					},
					scope: this
				});
			},

			/**
			 * Returns caption for changing opportunity management process link.
			 * @protected
			 * @return {String}
			 */
			getOpportunityManagementProcessLinkCaption: function() {
				var resourceCode = this.isOldProcessEnabled() ?
					"UseOpportunityManagementProcess100" :
					"UseOldOpportunityManagementProcess";
				return this.get("Resources.Strings." + resourceCode);
			},

			/**
			 * Changes current state of old opportunity management process usage.
			 * @protected
			 */
			changeOpportunityManagementProcessMode: function() {
				this.BPMSoft.chain(
					this.toggleOldProcessUsageState,
					this.runActualizeOpportunityManagementProcess,
					this.initOldProcessUsageState.bind(this, this.Ext.emptyFn),
					this
				);
				return false;
			}

		},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SystemSettingsTile",
				"name": "ChangeOpportunityManagementProcess",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "getOpportunityManagementProcessLinkCaption"},
					"click": {"bindTo": "changeOpportunityManagementProcessMode"},
					"visible": BPMSoft.Features.getIsEnabled("ChangeOpportunityManagementProcess")
				}
			}
		]
	};

});
