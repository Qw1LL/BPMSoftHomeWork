define("BaseSectionV2", ["BPMSoft", "ContextCallUtilities"], function(BPMSoft) {
	return {
		messages: {
			"CallCustomer": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			/**
			 * ###### ############ ######.
			 */
			"ContextCallUtilities": "BPMSoft.ContextCallUtilities"
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#linkClicked
			 * @overridden
			 */
			linkClicked: function(rowId, columnName) {
				var handled = this.phoneLinkClicked(rowId, columnName);
				return !(handled || !this.callParent(arguments));
			}

			//endregion

		}
	};
});
