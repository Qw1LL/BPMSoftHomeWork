/**
 * Parent: ProcessMappingPage
 */
define("DcmMappingPage", ["BPMSoft", "DcmMappingPageResources"], function() {

	return {
		methods: {
			/**
			 * @inheritdoc BPMSoft.MappingPageTabUtilities#getAllTabsConfig
			 * @overridden
			 */
			getAllTabsConfig: function() {
				var tabsConfig = this.mixins.mappingPageTabUtilities.getAllTabsConfig();
				var mappingTypeEnum = BPMSoft.MappingEnums.MappingType;
				delete tabsConfig[mappingTypeEnum.PROCESS_PARAMETERS];
				return tabsConfig;
			}
		}
	};

});
