define("BaseSectionV2", ["EmailLinksMixin"], function() {
	return {
		mixins: {
			/**
			 * Provides methods for email sending.
			 */
			"EmailLinksMixin": "BPMSoft.EmailLinksMixin"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.initSyncMailboxCount();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId, columnName) {
				var handled = false;
				var column = this.columns[columnName];
				if (column.name !== this.primaryDisplayColumnName && !column.isLookup) {
					var row = this.getGridDataRow(rowId);
					var emailConfig = this.getEmailConfig(rowId, row.get(columnName),
						row.get(this.primaryDisplayColumnName));
					handled = this.emailLinkClicked(emailConfig);
				}
 				return !handled && this.callParent(arguments);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[ ]/**SCHEMA_DIFF*/
	};
});
