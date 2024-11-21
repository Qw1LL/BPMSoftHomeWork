define("PortalPartnershipSection", [], function() {
	return {
		entitySchemaName: "Partnership",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		attributes: {
			/**
			 * @inheritDoc BaseDataView#UseTagModule
			 */
			"UseTagModule": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * @inheritDoc BaseDataView#UseFolderFilter
			 */
			"UseFolderFilter": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseDataView#initQueryFilters
			 * @override
			 */
			initQueryFilters: function (esq) {
				const activePartnershipFilter =
					BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "IsActive", true);
				esq.filters.add("ActivePartnershipFilter", activePartnershipFilter);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseDataView#getDefaultEmptyGridMessageProperties
			 * @override
			 */
			getDefaultEmptyGridMessageProperties: function() {
				let emptyMessageConfig = this.callParent(arguments);
				delete emptyMessageConfig.recommendation;
				delete emptyMessageConfig.useStaticFolderHelpUrl;
				return emptyMessageConfig;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSection#isSeparateModeActionsButtonVisible
			 * @overridden
			 */
			isSeparateModeActionsButtonVisible: function () {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseSectionV2#init
			 * @override
			 */
			init: function () {
				this.callParent(arguments);
				this.$IsAddRecordButtonVisible = false;
			},

			/**
			 * @inheritDoc BaseDataView#loadFiltersModule
			 * @overridden
			 */
			loadFiltersModule: this.BPMSoft.emptyFn
		}
	};
});
