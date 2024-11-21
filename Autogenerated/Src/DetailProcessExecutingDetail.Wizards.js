define("DetailProcessExecutingDetail", ["DetailProcessSettingsManager"], function() {
	return {
		methods: {
			/**
			 * @inheritdoc DataManagerGridUtilities#getEntitySchemaName
			 * @protected
			 * @overridden
			 */
			getEntitySchemaName: function() {
				return "ProcessInDetails";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getProcessRunnerManager
			 * @protected
			 * @overridden
			 */
			getProcessRunnerManager: function() {
				return BPMSoft.DetailManager;
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerName
			 * @protected
			 * @overridden
			 */
			getManagerName: function() {
				return "DetailProcessSettingsManager";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getManagerItemName
			 * @protected
			 * @overridden
			 */
			getManagerItemName: function() {
				return "DetailProcessSettingsManagerItem";
			},

			/**
			 * @inheritdoc BaseProcessExecutingDetail#getIsParameterRequired
			 * @protected
			 * @overridden
			 */
			getIsParameterRequired: function() {
				return true;
			}
		}
	};
});
