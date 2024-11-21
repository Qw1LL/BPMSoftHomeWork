define("BaseDashboardManager", ["DashboardManagerItem"], function() {

	/**
	 * @class BPMSoft.BaseDashboardManager
	 * @public
	 * Base dashboard manager class.
	 */
	Ext.define("BPMSoft.BaseDashboardManager", {
		extend: "BPMSoft.ObjectManager",
		alternateClassName: "BPMSoft.BaseDashboardManager",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.DashboardManagerItem",

		// endregion

		//region Methods: Public

		/**
		 * @inheritdoc BPMSoft.manager.ObjectManager#createItem
		 * @overridden
		 */
		createItem: function(config, callback, scope) {
			scope = scope || this;
			if (config && config.dataManagerItem) {
				var dashboardManagerItem = this.createManagerItem(config);
				callback.call(scope, dashboardManagerItem);
			} else {
				var createConfig = {
					entitySchemaName: this.entitySchemaName
				};
				if (config && config.sectionId) {
					Ext.apply(createConfig, {
						columnValues: {Section: {value: config.sectionId}}
					});
				}
				var createCallback = function(dataManagerItem) {
					var managerItem = this.createManagerItem({dataManagerItem: dataManagerItem});
					var propertyValues = config && config.propertyValues;
					BPMSoft.each(propertyValues, function(propertyValue, propertyName) {
						managerItem.setPropertyValue(propertyName, propertyValue);
					}, this);
					callback.call(scope, managerItem);
				};
				BPMSoft.DataManager.createItem(createConfig, createCallback, this);
			}
		}

		//endregion

	});
	return BPMSoft.BaseDashboardManager;
});
