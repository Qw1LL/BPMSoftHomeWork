BPMSoft.sdk.RecordPage.setTitle("Lead", "create", "LeadEditPageNewLeadTitle");

BPMSoft.sdk.RecordPage.addColumn("Lead", {
	name: "LeadName",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.addColumn("Lead", {
	name: "QualifyStatus",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.addColumn("Lead", {
	name: "LeadTypeStatus",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.configureColumn("Lead", "communicationColumnSet", "BusinesPhone", {
	viewType: BPMSoft.ViewTypes.Phone
});

BPMSoft.sdk.RecordPage.configureColumn("Lead", "communicationColumnSet", "MobilePhone", {
	viewType: BPMSoft.ViewTypes.Phone
});

BPMSoft.sdk.RecordPage.configureColumn("Lead", "communicationColumnSet", "Email", {
	viewType: BPMSoft.ViewTypes.Email
});

BPMSoft.sdk.RecordPage.configureColumn("Lead", "communicationColumnSet", "Website", {
	viewType: BPMSoft.ViewTypes.Url
});

BPMSoft.sdk.RecordPage.configureColumn("Lead", "addressColumnSet", "Address", {
	viewType: BPMSoft.ViewTypes.Map,
	typeConfig: {
		searchColumns: ["Address", "City", "Region", "Country"]
	}
});

BPMSoft.sdk.RecordPage.configureColumn("Lead", "secondaryColumnSet", "Commentary", {
	isMultiline: true
});

BPMSoft.sdk.GridPage.addColumns("Lead", ["Account", "Contact", "LeadType"]);

BPMSoft.sdk.RecordPage.setPreviewPageTitleConvertFunction("Lead",
	function(values) {
		var account = values.Account;
		var contact = values.Contact;
		var leadName = !Ext.isEmpty(account) ? account : "";
		leadName += (!Ext.isEmpty(leadName) && !Ext.isEmpty(contact)) ? ", " : "";
		leadName += !Ext.isEmpty(contact) ? contact : "";
		return leadName;
	}
);

BPMSoft.sdk.GridPage.setSearchColumn("Lead", "LeadName");

BPMSoft.sdk.GridPage.setOrderByColumns("Lead", {
	column: "LeadName",
	orderType: BPMSoft.OrderTypes.ASC
});

BPMSoft.sdk.Actions.add("Lead", {
	name: "Meeting",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionMeeting",
	title: "LeadActionMeetingTitle",
	defineTitle: function() {
		return null;
	},
	modelName: "Activity",
	sourceModelColumnNames: ["Id"],
	destinationModelColumnNames: ["Lead"],
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
			value: "f51c4643-58e6-df11-971b-001d60e938c6"
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
	]
});

BPMSoft.sdk.Actions.remove("Lead", "BPMSoft.ActionCopy");

BPMSoft.sdk.Actions.setOrder("Lead", {
	"Meeting": 0,
	"BPMSoft.configuration.action.ShareLink": 1,
	"BPMSoft.ActionDelete": 2
});
