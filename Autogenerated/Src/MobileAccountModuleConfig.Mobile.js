BPMSoft.sdk.RecordPage.setTitle("Account", "create", "AccountEditPage_navigationPanel_title_create");

BPMSoft.sdk.GridPage.addColumns("Account", ["GPSN", "GPSE", "Address"]);

BPMSoft.sdk.RecordPage.configureColumn("Account", "primaryColumnSet", "Name", {
	isMultiline: true
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "primaryColumnSet", "PrimaryContact", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.GridPage.setOrderByColumns("Account",	{
	column: "Name",
	orderType: BPMSoft.OrderTypes.ASC
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Account", "AccountCommunicationDetailEmbeddedDetail", {
	title: "AccountRecordPage_accountCommunicationsDetail_title",
	displaySeparator: false,
	orderByColumns: [
		{
			column: "CommunicationType",
			orderType: BPMSoft.OrderTypes.ASC
		}
	],
	isCollapsed: false,
	hideTitle: true,
	previewConfig: {
		valueColumn: "Number",
		label: {
			column: "CommunicationType"
		}
	},
	isInPlaceEditingMode: true
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "AccountCommunicationDetailEmbeddedDetail", "CommunicationType", {
	useAsLabel: true,
	label: {
		emptyText: "AccountRecordPage_accountCommunicationsDetail_CommunicationType_emptyText",
		pickerTitle: "AccountRecordPage_accountCommunicationsDetail_CommunicationType_label"
	}
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "AccountCommunicationDetailEmbeddedDetail", "Number", {
	hideLabel: true,
	viewType: {
		typeColumn: "CommunicationType"
	},
	placeHolder: "AccountRecordPage_accountCommunicationsDetail_Number_placeHolder"
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Account", "AccountAddressDetailV2EmbeddedDetail", {
	title: "AccountRecordPage_accountAddressesDetail_title",
	displaySeparator: true,
	orderByColumns: [
		{
			column: "Primary",
			orderType: BPMSoft.OrderTypes.DESC
		}
	],
	previewConfig: BPMSoft.Configuration.util.getAddressEmbeddedDetailPreviewConfig(),
	isInPlaceEditingMode: true,
	hideTitle: true
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "AccountAddressDetailV2EmbeddedDetail", "Address", {
	viewType: BPMSoft.ViewTypes.Map,
	typeConfig: {
		searchColumns: ["Address", "City", "Region", "Country"]
	},
	isMultiline: true
});

BPMSoft.sdk.RecordPage.addColumn("Account", {
	name: "Primary",
	hidden: true
}, "AccountAddressDetailV2EmbeddedDetail");

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Account", "AccountAnniversaryDetailV2EmbeddedDetail", {
	title: "AccountRecordPage_accountAnniversariesDetail_title",
	orderByColumns: [
		{
			column: "Date",
			orderType: BPMSoft.OrderTypes.ASC
		}
	],
	displaySeparator: false,
	previewConfig: {
		valueColumn: "Date",
		label: {
			column: "AnniversaryType"
		}
	},
	isInPlaceEditingMode: true
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "AccountAnniversaryDetailV2EmbeddedDetail", "AnniversaryType", {
	useAsLabel: true,
	label: {
		emptyText: "AccountRecordPage_accountAnniversariesDetail_AnniversaryType_emptyText",
		pickerTitle: "AccountRecordPage_accountAnniversariesDetail_AnniversaryType_label"
	}
});

BPMSoft.sdk.RecordPage.configureColumn("Account", "AccountAnniversaryDetailV2EmbeddedDetail", "Date", {
	hideLabel: true,
	viewType: {
		typeColumn: "AnniversaryType"
	},
	placeHolder: "AccountRecordPage_accountAnniversariesDetail_Date_placeHolder"
});

BPMSoft.sdk.Actions.add("Account", {
	name: "Meeting",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionMeeting",
	title: "AccountActionMeeting_title",
	defineTitle: function() {
		return null;
	},
	modelName: "Activity",
	sourceModelColumnNames: ["Id"],
	destinationModelColumnNames: ["Account"],
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

BPMSoft.sdk.Actions.add("Account", {
	name: "addAccountCommunication",
	type: "addEmbeddedDetailRecord",
	title: "AccountRecordPageActionAddContactCommunicationCaption",
	detailName: "AccountCommunicationDetailEmbeddedDetail",
	iconCls: BPMSoft.ActionIcons.Communication,
	isQuickAction: true,
	useMask: false
});

BPMSoft.sdk.Actions.add("Account", {
	name: "addAccountAddress",
	type: "addEmbeddedDetailRecord",
	title: "AccountRecordPageActionAddAddressCaption",
	detailName: "AccountAddressDetailV2EmbeddedDetail",
	iconCls: BPMSoft.ActionIcons.Address,
	isQuickAction: true,
	useMask: false
});

BPMSoft.sdk.Actions.add("Account", {
	name: "addAccountAnniversary",
	type: "addEmbeddedDetailRecord",
	title: "AccountRecordPageActionAddAnniversaryCaption",
	detailName: "AccountAnniversaryDetailV2EmbeddedDetail",
	iconCls: BPMSoft.ActionIcons.Activity,
	isQuickAction: true,
	useMask: false
});

BPMSoft.sdk.Actions.setOrder("Account", {
	"addAccountCommunication": 0,
	"addAccountAddress": 1,
	"addAccountAnniversary": 2,
	"Meeting": 3,
	"BPMSoft.configuration.action.ShareLink": 4,
	"BPMSoft.ActionCopy": 5,
	"BPMSoft.ActionDelete": 6
});

BPMSoft.sdk.Details.configure("Account", "ActivityDetailV2StandartDetail", {
	filters: Ext.create("BPMSoft.Filter", {
		type: BPMSoft.FilterTypes.Group,
		subfilters: [
			Ext.create("BPMSoft.Filter", {
				compareType: BPMSoft.ComparisonTypes.NotEqual,
				property: "Type",
				value: BPMSoft.GUID.ActivityTypeEmail
			})
		]
	})
});
