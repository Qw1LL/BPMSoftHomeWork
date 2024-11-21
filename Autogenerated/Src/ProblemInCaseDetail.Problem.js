define("ProblemInCaseDetail", ["ProblemInCaseDetailResources"],
function() {
	return {
		entitySchemaName: "ProblemInCase",
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"rowDataItemMarkerColumnName": "Problem.Number"
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {},
		messages: {},
		methods: {
			/**
			 * @inheritDoc BPMSoft.BaseManyToManyGridDetail#initConfig
			 * @overridden
			 */
			initConfig: function() {
				this.callParent(arguments);
				var config = this.getConfig();
				config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "Problem";
				config.sectionEntitySchema = "Case";
				config.lookupConfig.multiselect = true;
			},

			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#init
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
				return "Problem";
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: this.BPMSoft.emptyFn
		}
	};
});
