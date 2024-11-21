define("BaseConfigurationGridRow", ["BPMSoft", "LookupQuickAddMixin"], function(BPMSoft) {
	return {
		mixins: {
			RelatedEntityColumnsMixin: "BPMSoft.RelatedEntityColumns",
			LookupQuickAddMixin: "BPMSoft.LookupQuickAddMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#updateDetails
			 * @overridden
			 */
			updateDetails: BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BasePageV2#clearPageHeaderCaption
			 * @overridden
			 */
			clearPageHeaderCaption: BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BasePageV2#resetBodyAttributes
			 * @overridden
			 */
			resetBodyAttributes: BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BasePageV2#discardDetailChange
			 * @overridden
			 */
			discardDetailChange: BPMSoft.emptyFn,
			/**
			 * @inheritdoc BPMSoft.BasePageV2#updatePageHeaderCaption
			 * @overridden
			 */
			updatePageHeaderCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @overridden
			 */
			constructor: function(config) {
				this.callParent(arguments);
				this.setRelatedColumnsValues(this, this.columns);
				this.mixins.LookupQuickAddMixin.init.call(this);
				this._cloneDataModelCollection();
				this._setPrimaryDataModelStatus(config);
			},

			/**
			 * @private
			 */
			_cloneDataModelCollection: function() {
				const dataModelCollection = new BPMSoft.DataModelCollection();
				dataModelCollection.init(this.dataModelCollection.dataModelsConfig);
				this.dataModelCollection = dataModelCollection;
			},

			/**
			 * @private
			 */
			_setPrimaryDataModelStatus: function(config) {
				if (!config) {
					return;
				}
				const primaryModel = this.dataModelCollection.findPrimary();
				primaryModel.isNew = config.isNew;
			}
		}
	};
});
