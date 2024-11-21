define("ServiceItemInReleaseDetail", [],
	function() {
		return {
			entitySchemaName: "ReleaseServiceItem",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * Initialize detail config.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "ServiceItem";
					config.sectionEntitySchema = "Release";
					config.lookupConfig.hideActions = true;
				},
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "ServiceItem";
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
