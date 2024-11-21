define("GridLayoutEditItemModel", ["GridLayoutEditItemModelResources", "DesignTimeItemModel"], function(resources) {

	/**
	 * Grid element model class for client schemes designer.
	 */
	Ext.define("BPMSoft.configuration.GridLayoutEditItemModel", {
		extend: "BPMSoft.configuration.DesignTimeItemModel",
		alternateClassName: "BPMSoft.GridLayoutEditItemModel",

		/**
		 * Grid item configuration.
		 * @type {Object}
		 */
		itemConfig: null,

		/**
		 * Default grid layout item position.
		 * @private
		 * @type {Object}
		 */
		defaultGridLayoutItemConfig: {
			colSpan: 11,
			rowSpan: 1,
			column: 0,
			row: 0
		},

		/**
		 * Initializes layout model parameters, which are responsible for the element location in the grid.
		 * @public
		 * @virtual
		 */
		initLayout: function() {
			var layout = this.itemConfig.layout;
			var itemLayout = Ext.apply({}, layout, this.defaultGridLayoutItemConfig);
			this.itemConfig.layout = itemLayout;
			BPMSoft.each(itemLayout, function(item, key) {
				this.set(key, item);
			}, this);
		},

		/**
		 * Updates the layout object in the element configuration according to the current position.
		 * @protected
		 * @virtual
		 */
		updateLayout: function() {
			var layout = this.itemConfig.layout;
			BPMSoft.each(layout, function(item, key) {
				layout[key] = this.get(key);
			}, this);
		},

		/**
		 * Returns updated object of grid element configuration.
		 * @return {Object}
		 */
		getConfigObject: function() {
			this.updateLayout();
			return BPMSoft.deepClone(this.itemConfig);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.set("itemId", this.itemConfig && this.itemConfig.name);
			this.initLayout();
			this.initCaption();
		},

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#removeFromDesignSchema
		 * @overridden
		 */
		removeFromDesignSchema: function(config) {
			var collection = this.designSchema.getGridLayoutEditCollection(config.layoutName);
			collection.remove(this);
		}
	});

	return BPMSoft.GridLayoutEditItemModel;
});
