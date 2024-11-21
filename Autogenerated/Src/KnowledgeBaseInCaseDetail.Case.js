define("KnowledgeBaseInCaseDetail", [],
	function() {
		return {
			entitySchemaName: "KnowledgeBaseInCase",
			methods: {
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "KnowledgeBase";
					config.sectionEntitySchema = "Case";
				},
				/**
				 * ######### #############.
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},
				/**
				* ########## ### ####### ### ########## ## #########.
				* @overridden
				* @return {String} ### #######.
				*/
				getFilterDefaultColumnName: function() {
					return "KnowledgeBase";
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn
			}
		};
	});
