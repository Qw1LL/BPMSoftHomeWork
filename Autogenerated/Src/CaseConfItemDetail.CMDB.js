define("CaseConfItemDetail", [],
	function() {
		return {
			entitySchemaName: "ConfItemInCase",
			diff: [
				{
					"operation": "remove",
					"name": "AddRecordButton"
				}
			],
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
				 * Initialize details config.
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "Case";
					config.sectionEntitySchema = "ConfItem";
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
					return "Case";
				}
			}
		};
	});
