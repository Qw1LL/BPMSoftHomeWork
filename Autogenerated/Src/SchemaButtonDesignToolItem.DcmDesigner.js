define("SchemaButtonDesignToolItem", ["SchemaDesignToolItem"], function() {
	Ext.define("BPMSoft.SchemaButtonDesignToolItem", {
		extend: "BPMSoft.SchemaDesignToolItem",

		/**
		 * Button caption.
		 * @type {String}
		 */
		caption: null,

		/**
		 * @inheritdoc BPMSoft.SchemaColumnDesignToolItem#getDesignItemConfg
		 * @override
		 */
		getDesignItemConfg: function() {
			return {
				itemConfig: {
					name: "Button",
					caption: this.caption
				}
			};
		}
	});
	return BPMSoft.SchemaButtonDesignToolItem;
});
