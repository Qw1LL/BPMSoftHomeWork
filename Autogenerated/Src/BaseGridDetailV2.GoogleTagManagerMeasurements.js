define("BaseGridDetailV2", ["GoogleTagManagerMeasurementsUtilities"], function() {
	return {

		mixins: {
			/**
			 * Mixin for conducting measurements for sending this data to Google tag manager.
			 */
			GoogleTagManagerMeasurementsUtilities: BPMSoft.GoogleTagManagerMeasurementsUtilities
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function() {
				this.callParent(arguments);
				this.stopGoogleTagManagerMeasurements();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#sendGoogleTagManagerData
			 * @overridden
			 */
			sendGoogleTagManagerData: this.BPMSoft.emptyFn

			//endregion

		}
	};
});
