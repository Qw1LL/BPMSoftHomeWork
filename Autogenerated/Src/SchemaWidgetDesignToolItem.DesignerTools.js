define("SchemaWidgetDesignToolItem", ["SchemaDesignToolItem"], function() {
	Ext.define("BPMSoft.SchemaWidgetDesignToolItem", {
		extend: "BPMSoft.SchemaDesignToolItem",

		/**
		 * Widget config.
		 * @type {Object}
		 */
		item: null,

		/**
		 * @inheritdoc BPMSoft.configuration.SchemaDesignToolItem#getDesignItemConfg
		 * @override
		 */
		getDesignItemConfg: function() {
			return {
				itemConfig: {
					name: this.item.type,
					caption: this.item.caption,
					layout: {colSpan: 11}
				},
				widgetType: this.item.type,
				widgetCaption: this.item.caption
			};
		}
	});
	return BPMSoft.SchemaWidgetDesignToolItem;
});
