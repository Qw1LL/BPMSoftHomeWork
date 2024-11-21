define("BaseSearchRowSchema", ["LinkColumnHelper", "ContextCallUtilities"], function(LinkColumnHelper) {
	return {
		mixins: {
			ContextCallUtilities: "BPMSoft.ContextCallUtilities"
		},
		messages: {
			/**
			 * @message CallCustomer
			 * Make a call for customer.
			 */
			"CallCustomer": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel.BaseSectionV2#getLinkUrl
			 * @overridden
			 */
			getLinkUrl: function(columnName) {
				var phoneLinkUrl = LinkColumnHelper.createLink(this.entitySchemaName,
						columnName, this.get(columnName), this.get(this.primaryColumnName));
				return phoneLinkUrl || this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel.BaseSectionV2#onLinkClick
			 * @overridden
			 */
			onLinkClick: function(url, columnName) {
				var handled = this.callCustomer({
					entityColumnName: columnName,
					entitySchemaName: this.entitySchemaName,
					entityId: this.get(this.primaryColumnName),
					number: this.get(columnName)
				});
				return !(handled || !this.callParent(arguments));
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
