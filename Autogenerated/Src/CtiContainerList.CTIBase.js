define("CtiContainerList", ["BPMSoft", "ext-base", "ContainerList", "SchemaBuilderV2"], function(BPMSoft, Ext) {

	/**
	 * Class implements displaying of panel collections.
	 */
	Ext.define("BPMSoft.controls.CtiContainerList", {
		extend: "BPMSoft.ContainerList",
		alternateClassName: "BPMSoft.CtiContainerList",

		/**
		 * Prefix of panel of elements identifier.
		 * @type {String}
		 */
		dataItemIdPrefix: "cti-panel-item",

		/**
		 * Sandbox identifier.
		 * Used to form unique identifier for panel element.
		 * @type {String}
		 */
		sandboxId: "",

		/**
		 * ##### ######## ########## ######.
		 * @type {String}
		 */
		wrapClassName: "list-item-container",

		/**
		 * CSS ######## ######## #########.
		 * @type {String}
		 */
		rowCssSelector: ".list-item-container",

		/**
		 * @inheritdoc BPMSoft.ContainerList#getItemElementId
		 * @overridden
		 */
		getItemElementId: function(item) {
			var id = item.get(this.idProperty);
			return this.dataItemIdPrefix + "-" + id + item.sandbox.id;
		},

		/**
		 * ######## ########## marker value ######## ##########.
		 * @protected
		 * @param {Object} item ####### ######### #######.
		 * @returns {String} ########## marker value ######## ##########.
		 */
		getItemMarkerValue: function(item) {
			var id = item.get(this.idProperty);
			return this.dataItemIdPrefix + "-" + id;
		},

		/**
		 * ########## ############ ############# ######## ######.
		 * @protected
		 * @param {Object} item ####### ######### #######.
		 * @returns {Object} ############ ############# ######## ######.
		 */
		getItemConfig: function(item) {
			var itemConfig = this.defaultItemConfig;
			var itemCfg = {};
			this.fireEvent("onGetItemConfig", itemCfg, item);
			if (itemCfg.config) {
				itemConfig = itemCfg.config;
				this.defaultItemConfig = itemCfg.config;
			}
			if (Ext.isFunction(this.getCustomItemConfig)) {
				itemConfig = this.getCustomItemConfig(item) || itemConfig;
			}
			return BPMSoft.deepClone(itemConfig);
		},

		/**
		 * @inheritdoc BPMSoft.ContainerList#getItemView
		 * @overridden
		 */
		getItemView: function(item) {
			this.sandboxId = item.sandbox.id;
			var itemConfig = this.getItemConfig(item);
			var itemMarkerValue = this.getItemMarkerValue(item);
			var itemElementId = this.getItemElementId(item);
			this.decorateView(itemConfig, itemElementId, this.sandboxId);
			return Ext.create("BPMSoft.Container", {
				id: itemElementId,
				markerValue: itemMarkerValue,
				items: itemConfig,
				classes: {"wrapClassName": [this.wrapClassName]}
			});
		}

	});

});
