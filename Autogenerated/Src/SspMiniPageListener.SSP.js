define("SspMiniPageListener", ["MiniPageListener", "SspMiniPageContainerViewModel"], function() {
	
	/**
	 * Overrides MiniPage container module view model class name in {@link BPMSoft.MiniPageListener}.
	 */
	Ext.apply(BPMSoft.MiniPageListener, {
		viewModelClass: "BPMSoft.SspMiniPageContainerViewModel",
	});

	return {
		init: Ext.emptyFn
	};
});
 