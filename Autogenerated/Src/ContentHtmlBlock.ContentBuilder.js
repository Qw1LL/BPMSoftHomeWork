 /**
 * Class of content builder block for HTML.
 */
 Ext.define("BPMSoft.controls.ContentHtmlBlock", {
	extend: "BPMSoft.controls.ContentMjBlock",
	alternateClassName: "BPMSoft.ContentHtmlBlock",

	hasSelectBtn: false,

	/**
	 * @inheritdoc BPMSoft.AbstractContainer#init
	 * @override
	 */
	init: function() {
		this.callParent(arguments);
		this.addEvents("elementSelectedChange");
	},

	/**
	 * Handles child element select.
	 * @protected
	 */
	onSelectedChanged: function(selected, item) {
		if (selected) {
			this.fireEvent("elementSelectedChange", item.id);
		}
	},

	/**
	 * Subscribes for child items events.
	 * @protected
	 */
	subscribeItemsEvents: function() {
		this.items.each(function(item) {
			item.on("selectedChanged", this.onSelectedChanged, this);
		}, this);
	},

	/**
	 * Unsubscribes from child items events.
	 * @protected
	 */
	unSubscribeItemsEvents: function() {
		this.items.each(function(item) {
			item.un("selectedChanged", this.onSelectedChanged, this);
		}, this);
	},

		/**
	 * Initialize DOM events.
	 * @protected
	 * @override
	 */
	initDomEvents: function() {
		this.callParent(arguments);
		this.subscribeItemsEvents();
	},

	/**
	 * @inheritdoc BPMSoft.controls.Component#onDestroy
	 * @override
	 */
	onDestroy: function() {
		this.unSubscribeItemsEvents();
		this.callParent(arguments);
	}
});
