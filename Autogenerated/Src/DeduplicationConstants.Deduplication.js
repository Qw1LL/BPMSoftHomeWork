define("DeduplicationConstants", [], function() {
	return {
		serviceName: "DeduplicationService",
		findDuplicatesMethodName: "FindDuplicatesOnSave",
		setDuplicatesMethodName: "SetDuplicatesOnSave",
		features: {
			bulkDeduplication: "BulkESDeduplication",
			getIsLazyDuplicatesPageEnabled: function() {
				return BPMSoft.Features.getIsEnabled("BulkESDeduplication") 
					&& BPMSoft.Features.getIsEnabled("LazyLoadDeduplicationResult") 
			}
		}
	};
});
