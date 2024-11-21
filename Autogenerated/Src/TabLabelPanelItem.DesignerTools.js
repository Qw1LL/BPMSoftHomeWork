define("TabLabelPanelItem", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {

		/**
		 * @class BPMSoft.TabLabelPanelItem
		 * Tab container item class.
		 */
		Ext.define("BPMSoft.TabLabelPanelItem", {
			extend: "BPMSoft.Label",
			mixins: {
				draggable: "BPMSoft.Draggable"
			},

			/**
			 * @inheritDoc BPMSoft.Draggable#grabbedClassName
			 * @protected
			 */
			grabbedClassName: "tab-label-panel-draggable-item-grabbed",

			/**
			 * @inheritDoc BPMSoft.Draggable#dragActionsCode
			 * @protected
			 */
			dragActionsCode: 1,

			/**
			 * @inheritDoc BPMSoft.Draggable#dragCopy
			 * @protected
			 */
			dragCopy: false,

			/**
			 * @inheritDoc BPMSoft.Label#tpl
			 * @protected
			 */
			tpl: [
				"<label {inputId} id = {id} class = \"{labelClass}\" style = \"{labelStyle}\" title=\"{hint}\">{caption}",
				"<tpl if=\"markerValue\">",
				" data-item-marker=\"{markerValue}\"",
				"</tpl>",
				"</label>"
			],

			/**
			 * Name of marker value.
			 * @type {String}
			 */
			markerValue: null,

			/**
			 * @inheritDoc BPMSoft.Component#constructor
			 * @protected
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
			 * Returns property of caption according markerValut property.
			 * @private
			 * @param {BPMSoft.BaseViewModel} label Model of data.
			 * @return {String} Marker value.
			 */
			getLabelMarkerValue: function(label) {
				return label.caption;
			},

			/**
			 * @inheritDoc BPMSoft.Label#getTplData
			 * @protected
			 */
			getTplData: function() {
				var tplData = this.callParent(arguments);
				this.markerValue = this.getLabelMarkerValue(tplData);
				return tplData;
			},

			/**
			 * @inheritDoc BPMSoft.Component#onAfterRender
			 * @protected
			 */
			onAfterRender: function() {
				this.callParent(arguments);
				this.mixins.draggable.onAfterRender.apply(this, arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Component#onAfterReRender
			 * @protected
			 */
			onAfterReRender: function() {
				this.callParent(arguments);
				this.mixins.draggable.onAfterReRender.apply(this, arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Component#onDestroy
			 * @protected
			 */
			onDestroy: function() {
				this.mixins.draggable.onDestroy.apply(this, arguments);
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.Draggable#getDraggableConfig
			 * @protected
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
			 * onInvalidDrop event handler
			 * @protected
			 */
			onInvalidDrop: function() {
				this.reRender();
			},

			/**
			 * DragOver event handler
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
			 * DragOut event handler
			 * @protected
			 */
			onDragOut: function() {
				this.fireEvent("ondragout");
			},

			/**
			 * DragDrop event handler
			 * @protected
			 */
			onDragDrop: function() {
				this.reRender();
				this.fireEvent("ondragdrop");
			},

			/**
			 * @inheritDoc BPMSoft.Draggable#getDraggableElementDefaultConfig
			 * @protected
			 */
			getDraggableElementDefaultConfig: function() {
				return {
					isTarget: true,
					instance: this,
					tag: this.tag
				};
			}
		});
	});
