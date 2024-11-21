/**
 * @class BPMSoft.configuration.CardWidgetModuleViewConfig
 */
Ext.define("BPMSoft.configuration.CardWidgetModuleViewConfig", {
	extend: "BPMSoft.BaseObject",
	alternateClassName: "BPMSoft.CardWidgetModuleViewConfig",

	/**
	 * Generates view config.
	 * @param {String} id Root element id.
	 * @returns {Object} View config.
	 */
	generate: function(id) {
		var viewConfig = [];
		var diff = [
			{
				"operation": "insert",
				"name": "CardWidgetContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"id": id,
					"selectors": {"wrapEl": "#" + id},
					"items": []
				}
			}
		];
		return BPMSoft.JsonApplier.applyDiff(viewConfig, diff);
	}

});