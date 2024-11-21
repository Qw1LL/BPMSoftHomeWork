define("SystemDesigner", [], function() {
	return {
		methods: {

			//region Methods: Private

			/**
			 * Opens translation section.
			 * @private
			 */
			navigateToTranslationSection: function() {
				this.openSection("TranslationSection");
			},

			/**
			 * Opens language section.
			 * @private
			 */
			navigateToLanguageSection: function() {
				this.openSection("LanguageSection");
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc SystemDesigner#getOperationRightsDecoupling
			 * @overridden
			 */
			getOperationRightsDecoupling: function() {
				var operationRights = this.callParent(arguments);
				operationRights.navigateToTranslationSection = "CanManageTranslationSection";
				operationRights.navigateToLanguageSection = "CanManageLanguageSection";
				return operationRights;
			},

			//endregion

			//region Methods: Public

			/**
			 * Gets "NavigateToLanguageSection" item visibility.
			 * @return {Boolean}
			 */
			getNavigateToLanguageSectionVisible: function() {
				return true;
			},

			/**
			 * Gets "NavigateToTranslationSection" item visibility.
			 * @return {Boolean}
			 */
			getNavigateToTranslationSectionVisible: function() {
				return true;
			}

			//endregion

		},
	};
});
