define("CampaignElementGroups", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.CampaignElementGroups", {
		singleton: true,

		Items: Ext.create("BPMSoft.Collection")
	});
	return BPMSoft.CampaignElementGroups;
});

