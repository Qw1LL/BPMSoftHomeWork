Ext.define("BPMSoft.configuration.ActivityCacheManager", {
	extend: "BPMSoft.core.SynchronizableCacheManager",

	/**
	 * @private
	 */
	 cacheSysAdminUnitIfNeeded: function(record) {
		var ownerId = record.get("Owner.Id");
		if (!record.dirty || !record.modified.hasOwnProperty("Owner") || !ownerId) {
			return Promise.resolve();
		} else {
			var manager = BPMSoft.ModelCache.getManager("SysAdminUnit");
			return manager.putRecord(record.get("Owner"));
		}
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	getIsCached: function() {
		return Promise.resolve(true);
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	getIsCachedWithFilters: function() {
		return Promise.resolve(true);
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	synchronizeFromCache: function() {
		return Promise.resolve();
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	synchronizeToCache: function() {
		return Promise.resolve();
	},

	/**
	 * @inheritdoc
	 * @overridden
	 */
	cacheRelatedRecords: function(record) {
		var args = arguments;
		return this.cacheSysAdminUnitIfNeeded(record).then(function() {
			return BPMSoft.configuration.ActivityCacheManager.superclass.cacheRelatedRecords.apply(this, args);
		}.bind(this));
	}

});

BPMSoft.ModelCache.registerManagerClassName("Activity", "BPMSoft.configuration.ActivityCacheManager");
