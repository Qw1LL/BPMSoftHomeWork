BPMSoft.sdk.RecordPage.setTitle("Activity", "create", "ActivityEditPageNewActivityTitle");

BPMSoft.sdk.RecordPage.configureColumn("Activity", "primaryColumnSet", "Title", {
	isMultiline: true
});

BPMSoft.sdk.RecordPage.configureColumn("Activity", "statusColumnSet", "DetailedResult", {
	isMultiline: true
});

BPMSoft.sdk.RecordPage.addColumn("Activity", {
	name: "ShowInScheduler",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.addColumn("Activity", {
	name: "ProcessElementId",
	hidden: true
});

BPMSoft.sdk.RecordPage.addColumn("Activity", {
	name: "Type",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.addColumn("Activity", {
	name: "AllowedResult",
	readOnly: true,
	disabled: true,
	hidden: true
}, "primaryColumnSet");

BPMSoft.sdk.RecordPage.configureColumn("Activity", "relationsColumnSet", "Account", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.RecordPage.configureColumn("Activity", "relationsColumnSet", "Contact", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.RecordPage.configureColumn("Activity", "ActivityParticipantDetailV2EmbeddedDetail", "Participant", {
	viewType: BPMSoft.ViewTypes.Preview
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Activity", "ActivityParticipantDetailV2EmbeddedDetail", {
	title: "ActivityRecordPageParticipantsDetailTitle",
	imageConfig: {
		column: "Participant.Photo",
		imageDataColumnName: "PreviewData",
		imageDisplayColumnName: "Name",
		defaultImageId: "MobileImageListDefaultContactPhotoEdit"
	},
	alwaysShowTitle: true,
	displaySeparator: true
});

BPMSoft.sdk.RecordPage.configureColumn("Activity", "ActivityParticipantDetailV2EmbeddedDetail", "Participant", {
	customPreviewConfig: {
		component: {
			label: null,
			cls: "x-field-without-label"
		}
	},
	customEditConfig: {
		label: null,
		cls: "x-field-without-label"
	},
	label: {
		pickerTitle: "ActivityRecordPageParticipantsDetailTitle"
	}
});

BPMSoft.sdk.RecordPage.addQueryConfigColumns("Activity", ["Role", "Participant.Photo.PreviewData"],
	"ActivityParticipantDetailV2EmbeddedDetail");

BPMSoft.sdk.GridPage.addColumns("Activity", ["Status.Finish", "Owner", "Contact", "ShowInScheduler", "Type", "Status",
	"AllowedResult", "ActivityCategory", "ProcessElementId", "DueDate", "StartDate", "Account", "Priority"]);

BPMSoft.sdk.GridPage.configureSubtitleColumn("Activity", "StartDate", {
	convertFunction: function(values) {
		var format = BPMSoft.Date.getDateTimeFormat();
		var startDate = Ext.Date.parse(values.StartDate, format);
		var dueDate = Ext.Date.parse(values.DueDate, format);
		if (BPMSoft.util.compareDate(startDate, dueDate)) {
			return Ext.Date.format(startDate, format) + " - " + Ext.Date.format(dueDate,
				BPMSoft.Date.getTimeFormat());
		} else {
			return Ext.Date.format(startDate, format) + " - " + Ext.Date.format(dueDate, format);
		}
	}
});

BPMSoft.sdk.GridPage.setOrderByColumns("Activity", [{
	column: "StartDate",
	orderType: BPMSoft.OrderTypes.ASC
}]);

BPMSoft.sdk.Module.addFilter("Activity", Ext.create("BPMSoft.Filter", {
	compareType: BPMSoft.ComparisonTypes.NotEqual,
	property: "Type",
	value: BPMSoft.GUID.ActivityTypeEmail
}));

BPMSoft.sdk.Actions.configure("Activity", "BPMSoft.ActionCopy", {
	isVisibleInGrid: true,
	isDisplayTitle: true
});

BPMSoft.sdk.GridPage.setAdditionalFilterModule("Activity", {
	type: BPMSoft.FilterModuleTypes.Period,
	name: "ActivityPeriodFilter",
	startDateColumnName: "StartDate",
	endDateColumnName: "DueDate",
	isVisibleInDetail: false
});

BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Activity", "ActivityParticipantDetailV2EmbeddedDetail", {
	pagingConfig: {
		top: 5
	}
});
