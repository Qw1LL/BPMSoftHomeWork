define("OrderProductDetailV2", [],
	function() {
		return {
			entitySchemaName: "OrderProduct",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: function () {
					if (BPMSoft.isCurrentUserSsp()) {
						return false;
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: function () {
					if (BPMSoft.isCurrentUserSsp()) {
						return false;
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.ProductDetailV2#getAddRecordOperationMenuItem
				 * @overridden
				 */
				getAddRecordOperationMenuItem: function () {
					if (BPMSoft.isCurrentUserSsp()) {
						return false;
					}
					return this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
