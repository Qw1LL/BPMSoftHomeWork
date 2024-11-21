define("BaseEntityPage", ["DeduplicationConstants", "DuplicatesSearchUtilitiesV2"], function(DeduplicationConstants) {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		messages: {
			/**
			 * @message GetDuplicateSearchConfig
			 * Sends parameters for duplicates search.
			 * @return {Object} Parameters for duplicates search.
			 */
			"GetDuplicateSearchConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 *@message FindDuplicatesResult
			 * Handles search duplicates results.
			 * @param {Object} Search duplicates result.
			 */
			"FindDuplicatesResult": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		mixins: {
			DuplicatesSearchUtilitiesV2: "BPMSoft.DuplicatesSearchUtilitiesV2"
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.mixins.DuplicatesSearchUtilitiesV2.init.call(this);
			},

			/**
			 * Should return true when page open for new record.
			 * @protected
			 */
			isNewMode: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#asyncValidate
			 * @overridden
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(result) {
					if (this.getIsFeatureEnabled("ESDeduplication") && !this.isNewMode()) {
						Ext.callback(callback, scope, [result]);
						return;
					}
					if (result.success && this.get("PerformSearchOnSave")) {
						this.findOnSave(callback, scope);
					} else {
						callback.call(scope, result);
					}
				}, this]);
			},

			/**
			 * Returns true if feature 'FindDuplicatesOnSave' is enabled.
			 * @returns {Boolean} True if feature 'FindDuplicatesOnSave' is enabled.
			 */
			getIsFindDuplicatesOnSaveEnable: function() {
				return this.BPMSoft.Features.getIsEnabled("FindDuplicatesOnSave");
			},

			/**
			 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getFindDuplicatesServiceName
			 * @overridden
			 */
			getDuplicatesServiceName: function() {
				if (this.getIsFindDuplicatesOnSaveEnable()) {
					return DeduplicationConstants.serviceName;
				}
				return "SearchDuplicatesService";
			},

			/**
			 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getFindDuplicatesServiceMethodName
			 * @overridden
			 */
			getFindDuplicatesServiceMethodName: function() {
				if (this.getIsFindDuplicatesOnSaveEnable()) {
					return DeduplicationConstants.findDuplicatesMethodName;
				}
				return this.getFindDuplicatesMethodName();
			},

			/**
			 * @inheritdoc BPMSoft.DuplicatesSearchUtilitiesV2#getFindDuplicatesServiceMethodName
			 * @overridden
			 */
			getSetDuplicatesServiceMethodName: function() {
				if (this.getIsFindDuplicatesOnSaveEnable()) {
					return DeduplicationConstants.setDuplicatesMethodName;
				}
				return this.getSetDuplicatesMethodName();
			},

			/**
			 * Gets method name for search duplicates.
			 * @protected
			 * @return {String} Method name.
			 */
			getFindDuplicatesMethodName: function() {
				if (this.BPMSoft.Features.getIsEnabled("ESDeduplication")) {
					return "FindDuplicates";
				} else {
					return this.Ext.String.format("{0}{1}{2}", "Find", this.entitySchemaName, "Duplicates");
				}
			},

			/**
			 * Gets method name for setting duplicates.
			 * @protected
			 * @return {String} Method name.
			 */
			getSetDuplicatesMethodName: function() {
				if (this.BPMSoft.Features.getIsEnabled("ESDeduplication")) {
					return "SetDuplicates";
				} else {
					return this.Ext.String.format("{0}{1}{2}", "Set", this.entitySchemaName, "Duplicates");
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
