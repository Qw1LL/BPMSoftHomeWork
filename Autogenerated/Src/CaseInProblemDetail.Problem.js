define("CaseInProblemDetail", ["CaseInProblemDetailResources"],
function() {
	return {
		entitySchemaName: "ProblemInCase",
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
				config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "Case";
				config.sectionEntitySchema = "Problem";
				config.lookupConfig.multiselect = true;
				config.lookupConfig.hideActions = true;
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
				return "Case";
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
