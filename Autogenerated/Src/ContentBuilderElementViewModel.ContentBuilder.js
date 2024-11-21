define("ContentBuilderElementViewModel", ["BaseContentSerializableViewModelMixin"], function() {

	/**
	 * @class BPMSoft.controls.ContentBuilderElementViewModel
	 */
	Ext.define("BPMSoft.controls.ContentBuilderElementViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.ContentBuilderElementViewModel",

		mixins: {
			SerializableMixin: "BPMSoft.BaseContentSerializableViewModelMixin"
		},

		columns: {
			"ItemType": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"Caption": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"Icon": {
				value: null
			},
			"GroupName": {
				value: null
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"ondragover",
				"ondragdrop",
				"oninvaliddrop"
			);
		},

		/**
		 * Handles event for element drag enter.
		 * @protected
		 */
		onDragEnter: BPMSoft.emptyFn,

		/**
		 * Generates event for element drag.
		 * @protected
		 * @param {String} blockId The identifier of crossed block.
		 */
		onDragOver: function(blockId) {
			this.fireEvent("ondragover", this, blockId);
		},

		/**
		 * Handles event for element drag out.
		 * @protected
		 */
		onDragOut: BPMSoft.emptyFn,

		/**
		 * Generates event for element drop.
		 * @protected
		 */
		onDragDrop: function() {
			this.fireEvent("ondragdrop", this);
		},

		/**
		 * Generates event of block group invalid drop.
		 * @protected
		 */
		onInvalidDrop: function() {
			this.fireEvent("oninvaliddrop", this);
		}

	});
});
