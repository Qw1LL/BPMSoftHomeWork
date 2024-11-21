define("DesignTimeReorderableItem", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

	Ext.define("BPMSoft.DesignTimeReorderableItem", {
		alternateClassName: "BPMSoft.configuration.DesignTimeReorderableItem",
		extend: "BPMSoft.DraggableContainer",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.Draggable#grabbedClassName
		 * @override
		 */
		grabbedClassName: "design-time-draggable-item-grabbed",

		/**
		 * @inheritdoc BPMSoft.Draggable#dragActionsCode
		 * @override
		 */
		dragActionsCode: BPMSoft.DragAction.MOVE,

		/**
		 * @inheritdoc BPMSoft.Draggable#dragCopy
		 * @override
		 */
		dragCopy: false,

		/**
		 * @inheritdoc BPMSoft.Draggable#showDropOverZoneHint
		 * @override
		 */
		showDropOverZoneHint: true,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.Component#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"ondragenter",
				"ondragout",
				"ondragdrop"
			);
		},

		/**
		 * @inheritdoc BPMSoft.Draggable#getDraggableConfig
		 * @override
		 */
		getDraggableConfig: function() {
			var draggableConfig = {};
			draggableConfig[BPMSoft.DragAction.MOVE] = {
				handlers: {
					onDragOver: "onDragEnter",
					onDragOut: "onDragOut",
					onDragDrop: "onDragDrop",
					onInvalidDrop: "onInvalidDrop"
				}
			};
			return draggableConfig;
		},

		/**
		 * @inheritdoc BPMSoft.Draggable#getDraggableElementDefaultConfig
		 * @override
		 */
		getDraggableElementDefaultConfig: function() {
			return {
				isTarget: true,
				instance: this,
				tag: this.tag
			};
		},

		/**
		 * DragOver event handler.
		 * @protected
		 */
		onDragEnter: function(event, crossedBlocks) {
			BPMSoft.each(crossedBlocks, function(crossedBlock) {
				if (!crossedBlock.droppableInstance) {
					this.fireEvent("ondragenter", crossedBlock.id);
					return false;
				}
			}, this);
		},

		/**
		 * DragOut event handler.
		 * @protected
		 */
		onDragOut: function() {
			this.fireEvent("ondragout");
		},

		/**
		 * Handler for onDragDrop event.
		 * @protected
		 */
		onDragDrop: function() {
			this.reRender();
			this.fireEvent("ondragdrop");
		},

		/**
		 * Handler for onInvalidDrop event.
		 * @protected
		 */
		onInvalidDrop: function() {
			this.reRender();
		}

		// endregion

	});
});
