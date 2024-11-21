define("ProductSelectionSchema", [], function() {
	return {
		methods: {
			/**
			 * @inheritdoc BPMSoft.ProductSelectionSchema#getEditableColumns
			 * @override
			 */
			getEditableColumns: function() {
				let parentColumns = this.callParent(arguments);
				if (this.BPMSoft.isCurrentUserSsp()) {
					parentColumns = this.BPMSoft.without(parentColumns, "Price");
				}
				return parentColumns;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
