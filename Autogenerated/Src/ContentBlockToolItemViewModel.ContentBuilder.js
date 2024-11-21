define("ContentBlockToolItemViewModel", [], function() {

	/**
	 * Class for ContentBlockToolItemViewModel.
	 */
	Ext.define("BPMSoft.configuration.ContentBlockToolItemViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.ContentBlockToolItemViewModel",

		sandbox: null,

		columns: {
			Id: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Caption: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Icon: {
				dataValueType: BPMSoft.DataValueType.IMAGE
			},
			Size: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			DragActionsCode: {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},

		/**
		 * Default item config.
		 * @type {Object}
		 */
		DefaultConfig: null,

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				"toolDragOver",
				"toolDragDrop"
			);
		},

		/**
		 * Handler for onDragDrop event.
		 */
		onDragDrop: function() {
			this.fireEvent("toolDragDrop", this);
		},

		/**
		 * Generates event of block group drag.
		 */
		onDragOver: function(intersection) {
			const size = this.$Size;
			const position = {
				rowSpan: size.RowSpan,
				colSpan: size.ColSpan,
				row: intersection.row,
				column: intersection.column
			};
			this.fireEvent("toolDragOver", this, position);
		}

		// endregion

	});

	return BPMSoft.ContentBlockToolItemViewModel;
});
