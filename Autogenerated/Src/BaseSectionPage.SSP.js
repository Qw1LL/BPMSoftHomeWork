define("BaseSectionPage", ["SSPGridMixin"], function() {
	return {
		mixins: {
			/**
			 * Provides methods for grid handling in ssp sections.
			 */
			"SSPGridMixin": "BPMSoft.SSPGridMixin"
		},
		methods: {
			
			//region methods: protected

			/**
			 * @inheritdoc BPMSoft.BaseSectionPage#getEsnTabVisible
			 * @overridden
			 */
			getEsnTabVisible: function() {
				return this.getIsFeatureEnabled("ShowESNOnSSP") || !this.BPMSoft.isCurrentUserSsp();
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
 