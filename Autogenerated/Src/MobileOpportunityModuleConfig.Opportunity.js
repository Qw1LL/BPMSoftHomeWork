BPMSoft.sdk.RecordPage.setTitle("Opportunity", "create", "OpportunityEditPageNewOpportunityTitle");

BPMSoft.sdk.RecordPage.configureColumn("Opportunity", "primaryColumnSet", "Title", {
	isMultiline: true
});

BPMSoft.sdk.RecordPage.addColumn("Opportunity", {
	name: "Stage.MaxProbability",
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.configureColumn("Opportunity", "primaryColumnSet", "Account", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.RecordPage.configureColumn("Opportunity", "OpportunityProductDetailV2EmbeddedDetail", "Comment", {
	isMultiline: true
});

BPMSoft.sdk.GridPage.setOrderByColumns("Opportunity",	{
	column: "Title",
	orderType: BPMSoft.OrderTypes.ASC
});

BPMSoft.sdk.Actions.remove("Opportunity", "BPMSoft.ActionCopy");

BPMSoft.sdk.Actions.add("Opportunity", {
	name: "addOpportunityProduct",
	iconCls: "cf-action-add-product",
	type: "addEmbeddedDetailRecord",
	title: "OpportunityRecordPageActionAddProductCaption",
	detailName: "OpportunityProductDetailV2EmbeddedDetail",
	isQuickAction: true,
	useMask: false,
	position: 1
});

BPMSoft.sdk.Actions.add("Opportunity", {
	name: "addOpportunityContact",
	iconCls: "cf-action-add-contact",
	type: "addEmbeddedDetailRecord",
	title: "OpportunityRecordPageActionAddContactCaption",
	detailName: "OpportunityContactDetailV2EmbeddedDetail",
	isQuickAction: true,
	useMask: false,
	position: 2
});

BPMSoft.sdk.Actions.add("Opportunity", {
	name: "Meeting",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionMeeting",
	title: "Sys.Action.Meeting.Caption",
	defineTitle: "Sys.Action.Meeting.Title",
	modelName: "Activity",
	sourceModelColumnNames: ["Id", "Account"],
	destinationModelColumnNames: ["Opportunity", "Account"],
	evaluateModelColumnConfig: [
		{
			column: "Owner",
			value: {
				isMacros: true,
				value: BPMSoft.ValueMacros.CurrentUserContact
			}
		},
		{
			column: "Author",
			value: {
				isMacros: true,
				value: BPMSoft.ValueMacros.CurrentUserContact
			}
		},
		{
			column: "ActivityCategory",
			value: "42c74c49-58e6-df11-971b-001d60e938c6"
		},
		{
			column: "Priority",
			value: "ab96fa02-7fe6-df11-971b-001d60e938c6"
		},
		{
			column: "Status",
			value: "384d4b84-58e6-df11-971b-001d60e938c6"
		},
		{
			column: "Type",
			value: "fbe0acdc-cfc0-df11-b00f-001d60e938c6"
		}
	],
	position: 3
});

BPMSoft.sdk.Actions.configure("Opportunity", "BPMSoft.configuration.action.ShareLink", {
	position: 4
});

BPMSoft.sdk.Actions.configure("Opportunity", "BPMSoft.ActionDelete", {
	position: 5
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Opportunity", "OpportunityProductDetailV2EmbeddedDetail", {
	title: "OpportunityRecordPageOpportunityProductDetailTitle",
	displaySeparator: true
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Opportunity", "OpportunityContactDetailV2EmbeddedDetail", {
	title: "OpportunityRecordPageOpportunityContactDetailTitle",
	displaySeparator: true
});

BPMSoft.sdk.RecordPage.configureColumn("Opportunity", "OpportunityContactDetailV2EmbeddedDetail", "Contact", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.LookupGridPage.setOrderByColumns("OppContactLoyality", [{
	property: "Position",
	direction: "ASC"
}]);