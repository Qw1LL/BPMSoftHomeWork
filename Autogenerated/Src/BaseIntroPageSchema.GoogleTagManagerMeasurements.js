define("BaseIntroPageSchema", ["GoogleTagManagerMeasurementsUtilities"], function() {
	return {

		mixins: {
			GoogleTagManagerMeasurementsUtilities: BPMSoft.GoogleTagManagerMeasurementsUtilities
		},

		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseIntroPageSchema#init
			 * @override
			 */
			init: function() {
				this.startGoogleTagManagerMeasurements();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseIntroPageSchema#onRender
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.stopGoogleTagManagerMeasurements();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#sendGoogleTagManagerData
			 * @override
			 */
			sendGoogleTagManagerData: this.BPMSoft.emptyFn

			//endregion

		}
	};
});
