/**
 * @class BPMSoft.configuration.SocialMessageAssociateModelCacheManager
 * Implementation of cache manager for "Feed" detail.
 */
Ext.define("BPMSoft.configuration.SocialMessageAssociateModelCacheManager", {
	extend: "BPMSoft.core.AssociateModelCacheManager",
	alternateClassName: "BPMSoft.SocialMessageAssociateModelCacheManager",

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	shouldPutToCache: function() {
		return true;
	}

});
