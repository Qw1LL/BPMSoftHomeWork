define("ConfItemAddressDetail", [],
	function() {
		return {
			entitySchemaName: "ConfItemAddress",
			messages: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: this.BPMSoft.emptyFn,
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Address";
				}
			},
			diff: []
		};
	}
);
