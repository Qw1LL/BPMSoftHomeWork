BPMSoft.sdk.GridPage.setOrderByColumns("Invoice", {
	column: "DueDate",
	orderType: BPMSoft.OrderTypes.ASC
});

if (BPMSoft.Features.getIsEnabled("UseMobileInvoiceCacheManager")) {
	BPMSoft.ModelCache.registerManagerClassName("Invoice", "BPMSoft.InvoiceDataCacheManager");
	BPMSoft.ModelCache.registerManagerClassName("SocialMessage", "BPMSoft.SocialMessageAssociateModelCacheManager", "Invoice");
}
