define("PredefinedFilterItemViewModel", [], function() {
	Ext.define("BPMSoft.configuration.PredefinedFilterItemViewModel", {
		alternateClassName: "BPMSoft.PredefinedFilterItemViewModel",
		extend: "BPMSoft.BaseViewModel",

		//region Properties: Protected

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		//endregion

		//region Properties: Public

		/**
		 * @inheritdoc
		 * @overridden
		 */
		columns: {
			"ColumnPath": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"Caption": {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},

		//endregion

		//region Methods: Public

		/**
		 * @inheritdoc
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
					/**
					 * @event
					 * Deleting event.
					 */
					"delete"
			);
		},

		/**
		 * Handles delete button click.
		 */
		onDeleteButtonClick: function() {
			this.fireEvent("delete", this);
		}

		//endregion
	});
});
