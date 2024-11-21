define("PageDesignerButtonsContainer", ["ext-base", "BPMSoft", "PageDesignerButtonsContainerResources",
	"DesignTimeReorderableContainer"
], function(Ext, BPMSoft, resources) {

	Ext.define("BPMSoft.PageDesignerButtonsContainer", {
		extend: "BPMSoft.DesignTimeReorderableContainer",

		/**
		 * @inheritDoc BPMSoft.Reorderable#reorderableElCls
		 * @protected
		 */
		reorderableElCls: "page-designer-button-reorderable-position",

		/**
		 * @inheritdoc BPMSoft.Reorderable#zeroElClassName
		 * @override
		 */
		zeroElClassName: "page-designer-button-reorderable-zero-element",

		/**
		 * @inheritdoc BPMSoft.Draggable#showDropOverZoneHint
		 * @override
		 */
		showDropOverZoneHint: true,

		// region Methods: Private

		/**
		 * @private
		 */
		_getButtonToolItems: function() {
			return [
				{
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": resources.localizableImages.Remove,
					"click": {"bindTo": "onRemoveClick"}
				}
			];
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.Reorderable#getItemConfig
		 * @override
		 */
		getItemConfig: function(viewModelItem) {
			return {
				"className": "BPMSoft.PageDesignerButton",
				"id": viewModelItem.get("Name"),
				"markerValue": viewModelItem.get("Tag"),
				"classes": {"wrapClassName": ["button-reordable-item"]},
				"ondragenter": {"bindTo": "onDragEnter"},
				"ondragdrop": {"bindTo": "onDragDrop"},
				"ondragout": {"bindTo": "onDragOut"},
				"ondblclick": {"bindTo": "onEditClick"},
				"onselect": {"bindTo": "onSelect"},
				"selected": {"bindTo": "Selected"},
				"groupName": "ProcessActionButtons_ReorderableContainer",
				"items": [
					{
						"className": "BPMSoft.Container",
						"classes": {"wrapClassName": ["page-designer-btn-wrapper"]},
						"items": [{
							"className": "BPMSoft.Button",
							"caption": {"bindTo": "Caption"},
							"style": {"bindTo": "Style"},
							"enabled": {"bindTo": "Enabled"}
						}]
					},
					{
						"className": "BPMSoft.Container",
						"classes": {"wrapClassName": ["tools-container"]},
						"items": this._getButtonToolItems()
					}
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"mousedown"
			);
		},

		/**
		 * @inheritdoc BPMSoft.Component#initDomEvents
		 * @protected
		 */
		initDomEvents: function() {
			var wrapEl = this.getWrapEl();
			wrapEl.on("mousedown", this.onMouseDown, this);
		},

		/**
		 * Event handler of mouse down.
		 * @protected
		 */
		onMouseDown: function() {
			this.fireEvent("mousedown");
		}

		// endregion

	});

	return BPMSoft.PageDesignerButtonsContainer;
});
