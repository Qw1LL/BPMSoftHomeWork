BPMSoft.Configuration.SysSchemasUIds = BPMSoft.Configuration.SysSchemasUIds || {};
BPMSoft.Configuration.SysSchemasUIds.Case = "117d32f9-8275-4534-8411-1c66115ce9cd";

BPMSoft.sdk.RecordPage.configureColumnSet("Case", "DescriptionColumnSet", {
	alwaysShowTitle: true,
	collapsible: true,
	isCollapsed: true,
	customEditConfig: {
		isCollapsed: false
	}
});

BPMSoft.sdk.RecordPage.configureColumnSet("Case", "CaseProfileColumnSet", {
	alwaysShowTitle: true,
	collapsible: true,
	isCollapsed: true,
	customEditConfig: {
		isCollapsed: false
	}
});

BPMSoft.sdk.RecordPage.configureColumn("Case", "DescriptionColumnSet", "Symptoms", {
	isMultiline: true,
	customPreviewConfig: {
		label: null
	},
	customEditConfig: {
		label: null
	},
	placeHolder: "CaseRecordPageSymptomsPlaceHolder"
});

BPMSoft.sdk.RecordPage.configureColumn("Case", "primaryColumnSet", "Number", {
	readOnly: true,
	customEditConfig: {
		hidden: true
	}
});

BPMSoft.sdk.RecordPage.configureColumn("Case", "primaryColumnSet", "Status", {
	readOnly: true
});

BPMSoft.sdk.RecordPage.configureColumn("Case", "primaryColumnSet", "RegisteredOn", {
	readOnly: true
});

BPMSoft.sdk.RecordPage.configureColumn("Case", "primaryColumnSet", "Subject", {
	isMultiline: true
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Case", "CaseFilesDetail", {
	alwaysShowTitle: true,
	collapsible: true,
	isCollapsed: true,
	customEditConfig: {
		isCollapsed: false
	}
});

BPMSoft.sdk.Actions.add("Case", {
	name: "CaseFilesDetailActionAddFileAndLinks",
	detailName: "CaseFilesDetail",
	title: "MobileConstantsActionAddFileAndLinksTitle",
	isVisibleInGrid: false,
	isVisibleInPreview: true,
	isDisplayTitle: true,
	iconCls: "cf-action-add-file-and-links",
	position: 1,
	actionClassName: "BPMSoft.configuration.ActionAddFileAndLinks"
});

BPMSoft.sdk.Actions.add("Case", {
	name: "CaseOpenFeedDetailAction",
	detailModelName: "SocialMessage",
	title: "CaseOpenFeedDetailActionTitle",
	isVisibleInGrid: true,
	isRecordAction: true,
	isVisibleInPreview: true,
	isDisplayTitle: true,
	iconCls: "cf-action-feed-icon",
	position: 2,
	actionClassName: "BPMSoft.configuration.OpenStandardDetailAction"
});

BPMSoft.sdk.Actions.add("Case", {
	name: "OpenPortalMessagePublisherPageAction",
	title: "CaseOpenPortalMessagePublisherPageActionTitle",
	isVisibleInGrid: false,
	isRecordAction: true,
	isVisibleInPreview: true,
	isDisplayTitle: true,
	iconCls: "cf-action-portal-message-icon",
	position: 3,
	actionClassName: "BPMSoft.configuration.OpenPortalMessagePublisherPageAction",
	entitySchemaUId: BPMSoft.Configuration.SysSchemasUIds.Case
});

BPMSoft.sdk.Actions.configure("Case", "BPMSoft.configuration.action.ShareLink", {
	isVisibleInGrid: true,
	isRecordAction: true,
	position: 7
});

BPMSoft.sdk.Actions.configure("Case", "BPMSoft.ActionCopy", {
	position: 8
});

BPMSoft.sdk.Actions.configure("Case", "BPMSoft.ActionDelete", {
	position: 9
});

BPMSoft.sdk.GridPage.configureGroupColumn("Case", "Symptoms", {
	isMultiline: true,
	label: ""
});

BPMSoft.sdk.GridPage.addColumns("Case", ["Priority.Image.Data"]);

BPMSoft.sdk.GridPage.configureSubtitleColumn("Case", "Priority", {
	convertFunction: function(values) {
		var data = values["Priority.Image.Data"];
		if (data) {
			var url = BPMSoft.util.formatUrlForBackgroundImage(data, true);
			var style = BPMSoft.util.getImageStyleByUrl(url);
			return Ext.String.format("<div style=\"{0}\" class=\"cf-list-case-priority-icon\"></div>", style);
		}
		return null;
	}
});

BPMSoft.sdk.Details.setChangeModes("Case", "CaseMessageHistoryStandardDetail", [BPMSoft.ChangeModes.Read]);

BPMSoft.sdk.Details.configure("Case", "ActivityDetailV2StandardDetail", {
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

BPMSoft.sdk.GridPage.setOrderByColumns("Case", [{
	column: "RegisteredOn",
	orderType: BPMSoft.OrderTypes.DESC
}]);
