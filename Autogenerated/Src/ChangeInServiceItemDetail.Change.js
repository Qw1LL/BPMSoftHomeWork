define("ChangeInServiceItemDetail", [],
		function() {
			return {
				entitySchemaName: "ChangeServiceItem",
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
						config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "Change";
						config.sectionEntitySchema = "ServiceItem";
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
						return "Change";
					}
				},
				diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
			};
		});
