define("CampaignDraggableContainer", function() {

	/**
	 * @class BPMSoft.configuration.CampaignDraggableContainer
	 * ##### ######## ########## ################ ##########.
	 */
	var draggableContainer = Ext.define("BPMSoft.controls.CampaignDraggableContainer", {
		alternateClassName: "BPMSoft.CampaignDraggableContainer",
		extend: "BPMSoft.DraggableContainer",

		mixins: {
			draggable: "BPMSoft.Draggable"
		},

		/**
		 * ### ######### ######## ##############.
		 * @protected
		 * @type {Number}
		 */
		dragActionsCode: 1,

		/**
		 * ##### ############# ##########.
		 * @protected
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents("onDragDrop");
		},

		/**
		 * @inheritdoc BPMSoft.Draggable#getDraggableConfig
		 * @overridden
		 */
		getDraggableConfig: function() {
			var draggableConfig = {};
			draggableConfig[BPMSoft.DragAction.MOVE] = {
				handlers: {
					b4StartDrag: function() {
						this.wrapEl.setStyle({
							"z-index": "100",
							position: "absolute",
							opacity: "0.5"
						});
					},
					onDragDrop: function() {
						var bEvent = arguments[0].browserEvent;
						var clickY = bEvent.clientY;
						var clickX = bEvent.clientX;
						var domRef = Ext.get(arguments[1][0].id);
						var rect = domRef.dom.getBoundingClientRect();
						var config = {
							element: this,
							localX: clickX - rect.left,
							localY: clickY - rect.top
						};
						this.fireEvent("onDragDrop", config);
						this.reRender();
					},
					onInvalidDrop: function() {
						this.reRender();
					}
				}
			};
			return draggableConfig;
		},

		/**
		 * @inheritdoc BPMSoft.Draggable#getGroupName
		 * @overridden
		 */
		getGroupName: function() {
			return "CampaignDroppableContainer";
		}
	});

	return draggableContainer;
});
