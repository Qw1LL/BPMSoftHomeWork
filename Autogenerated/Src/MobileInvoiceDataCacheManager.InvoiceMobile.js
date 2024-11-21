/**
 * @class BPMSoft.configuration.InvoiceDataCacheManager
 * Implementation of cache manager of invoices.
 */
Ext.define("BPMSoft.configuration.InvoiceDataCacheManager", {
	extend: "BPMSoft.core.SynchronizableCacheManager",
	alternateClassName: "BPMSoft.InvoiceDataCacheManager",

	//region Properties: Protected

	/**
	 * @inheritdoc
	 * @property
	 * @protected
	 */
	importerClassName: "BPMSoft.InvoiceDataCacheImporter",

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getIsCached: function() {
		return new Promise(function(resolve) {
			BPMSoft.DataUtils.loadRecords({
				pageSize: 1,
				proxyType: BPMSoft.ProxyType.Offline,
				modelName: this.modelName,
				columns: ["Id"],
				success: function(loadedRecords) {
					resolve(loadedRecords.length > 0);
				},
				failure: function() {
					resolve(false);
				},
				scope: this
			});
		}.bind(this));
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getAutoExportModels: function() {
		var models = this.callParent(arguments);
		models.push("SocialLike");
		return models;
	}

	//endregion

});
