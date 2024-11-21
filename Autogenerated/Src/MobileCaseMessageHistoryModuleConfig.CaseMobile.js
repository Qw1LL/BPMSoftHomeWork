BPMSoft.configuration.MessageNotifierId = BPMSoft.configuration.MessageNotifierId || {};
BPMSoft.configuration.MessageNotifierId.Local = "ed501edb-8ebf-4c76-a35d-6f23be243043";

BPMSoft.sdk.Module.setChangeModes("VwMobileCaseMessageHistory", [BPMSoft.ChangeModes.Read]);

BPMSoft.sdk.GridPage.setImageColumn("VwMobileCaseMessageHistory", "OwnerPhoto.PreviewData",
	"MobileImageListDefaultContactPhoto");

BPMSoft.sdk.GridPage.addColumns("VwMobileCaseMessageHistory", ["MessageNotifier.Id", "MessageNotifier.Description"]);

BPMSoft.sdk.GridPage.setSubtitleColumns("VwMobileCaseMessageHistory", ["CreatedOn", {
		name: "MessageNotifier.Description",
		convertFunction: function(values) {
			var notifierId = values["MessageNotifier.Id"];
			return (notifierId === BPMSoft.configuration.MessageNotifierId.Local) ?
				BPMSoft.LS.SystemInfoNotifierDescriptiion: values["MessageNotifier.Description"];
		}
	},
	{
		name: "Recepient",
		convertFunction: function(values) {
			var recepient = values.Recepient;
			return (!Ext.isEmpty(recepient)) ? Ext.String.format("{0}: {1}", BPMSoft.LS.RecepientPrefix, recepient) : "";
		}
	}
]);

BPMSoft.sdk.GridPage.setGroupColumns("VwMobileCaseMessageHistory", [
	{
		name: "Message",
		isMultiline: true,
		convertFunction: function(values) {
			var message = Ext.htmlDecode(values.Message);
			var text = BPMSoft.String.getTextFromHtml(message);
			return text.replace(/\n/g, "<br>");
		}
	}
]);

BPMSoft.sdk.GridPage.setOrderByColumns("VwMobileCaseMessageHistory", {
	column: "CreatedOn",
	orderType: BPMSoft.OrderTypes.DESC
});

BPMSoft.sdk.GridPage.setSearchColumns("VwMobileCaseMessageHistory", []);

BPMSoft.sdk.RecordPage.configureColumn("VwMobileCaseMessageHistory", "primaryColumnSet", "Message", {
	isMultiline: true,
	customPreviewConfig: {
		htmlEncode: false
	}
});
