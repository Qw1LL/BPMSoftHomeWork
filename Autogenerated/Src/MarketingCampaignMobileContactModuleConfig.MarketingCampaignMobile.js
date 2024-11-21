BPMSoft.sdk.RecordPage.configureEmbeddedDetail("Contact", "ContactCommunicationDetailEmbeddedDetail", {
	filters: {
		property: "NonActual",
		value: false
	}
});

BPMSoft.sdk.RecordPage.addQueryConfigColumns("Contact", ["NonActual"], "ContactCommunicationDetailEmbeddedDetail");

BPMSoft.sdk.Model.setDefaultValuesFunc("ContactCommunication", function(config) {
	config.record.set("NonActual", false);
	Ext.callback(config.success, config.scope);
});
