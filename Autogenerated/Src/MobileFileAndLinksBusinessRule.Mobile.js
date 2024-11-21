/**
 * @class BPMSoft.configuration.FileAndLinksBusinessRule
 * Provides business rule for file details.
 */
Ext.define("BPMSoft.configuration.FileAndLinksBusinessRule", {
	alternateClassName: "BPMSoft.FileAndLinksBusinessRule",
	extend: "BPMSoft.BaseRule",

	config: {

		/**
		 * @inheritdoc
		 */
		ruleType: "BPMSoft.FileAndLinksBusinessRule",

		/**
		 * @inheritdoc
		 */
		triggeredByColumns: ["Type", "Name"],

		/**
		 * @inheritdoc
		 */
		events: [BPMSoft.BusinessRuleEvents.Load, BPMSoft.BusinessRuleEvents.ValueChanged]

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	execute: function(record, column, customData, callbackConfig) {
		var type = record.get("Type");
		var typeId = type.getId();
		var isKnowledgeBaseLink = (typeId === BPMSoft.Configuration.FileTypeGUID.KnowledgeBaseLink);
		var isFile = (typeId === BPMSoft.Configuration.FileTypeGUID.File) || isKnowledgeBaseLink;
		record.changeProperty("Name", {
			hidden: isFile,
			required: !isFile,
			disabled: isKnowledgeBaseLink
		});
		record.changeProperty("Data", {
			hidden: !isFile
		});
		if (isKnowledgeBaseLink) {
			record.changeProperty("Data", {
				label: BPMSoft.LocalizableStrings.EditPageKnowledgeBaseLinkCaption
			});
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope, [true]);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getRequiredColumns: function() {
		return this.getTriggeredByColumns();
	}

});
