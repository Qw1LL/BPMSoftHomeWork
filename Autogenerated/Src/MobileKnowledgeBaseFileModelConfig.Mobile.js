/* globals FileType: false */
BPMSoft.sdk.Model.setDefaultValuesFunc("KnowledgeBaseFile", function(model, record) {
	FileType.load(BPMSoft.Configuration.FileTypeGUID.File, {
		success: function(loadedRecord) {
			record.set("Type", loadedRecord);
		}
	});
});
BPMSoft.sdk.Model.addBusinessRule("KnowledgeBaseFile", {
	ruleType: BPMSoft.RuleTypes.Visibility,
	name: "KnowledgeBaseFileVisibleFileRule",
	conditionalColumns: [
		{name: "Type", value: BPMSoft.Configuration.FileTypeGUID.File}
	],
	events: [BPMSoft.BusinessRuleEvents.Load],
	dependentColumnNames: ["Data"]
});
BPMSoft.sdk.Model.addBusinessRule("KnowledgeBaseFile", {
	ruleType: BPMSoft.RuleTypes.Visibility,
	name: "KnowledgeBaseFileVisibleLinkRule",
	conditionalColumns: [
		{name: "Type", value: BPMSoft.Configuration.FileTypeGUID.Link}
	],
	events: [BPMSoft.BusinessRuleEvents.Load],
	dependentColumnNames: ["Name"]
});
BPMSoft.sdk.Model.addBusinessRule("KnowledgeBaseFile", {
	ruleType: BPMSoft.RuleTypes.Visibility,
	name: "KnowledgeBaseFileVisibleKnowledgeBaseLinkRule",
	conditionalColumns: [
		{name: "Type", value: BPMSoft.Configuration.FileTypeGUID.KnowledgeBaseLink}
	],
	events: [BPMSoft.BusinessRuleEvents.Load],
	dependentColumnNames: ["Name"]
});
