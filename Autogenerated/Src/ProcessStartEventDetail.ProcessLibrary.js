define("ProcessStartEventDetail", function() {
	return {
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseProcessSettingDetailV2#getProcessElementCaptionColumnsConfig
			 * @override
			 */
			getProcessElementCaptionColumnsConfig: function() {
				return {
					detailColumn: "ElementName",
					processElementUIdColumn: "ProcessElementUId"
				};
			}
		}
	};
});