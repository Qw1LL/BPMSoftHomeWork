define("BasePageV2", ["GoogleTagManagerMeasurementsUtilities"], function() {
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
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @overridden
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
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
