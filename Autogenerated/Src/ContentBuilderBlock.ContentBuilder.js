define("ContentBuilderBlock", ["css!ContentBuilderElement", "ContentBuilderElement",
		"ContentBuilderBlockViewModel"],
	function() {

	/**
	 * @class BPMSoft.controls.ContentBuilderBlock
	 */
	Ext.define("BPMSoft.controls.ContentBuilderBlock", {
		extend: "BPMSoft.ContentBuilderElement",
		alternateClassName: "BPMSoft.ContentBuilderBlock",
		mixins: {
			draggable: "BPMSoft.DraggableContentBlock"
		},

		/**
		 * @inheritdoc BPMSoft.core.mixins.Draggable#showDropZoneHint
		 * @override
		 */
		showDropZoneHint: true

	});

	return BPMSoft.ContentBuilderBlock;
});
