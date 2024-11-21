 define("SspBusinessRuleSection", ["BusinessRuleSection"], function() {
	return {
		attributes: {},
		methods: {

			/**
			 * @inheritDoc BPMSoft.BusinessRuleSection#getModuleDesignerConfig
			 * @override
			 */
			getModuleDesignerConfig: function () {
				let config = this.callParent(arguments);
				config["entitySchemaUId"] = this.getBusinessRuleEntitySchemaUId();
				return config;
			},

			/**
			 * Returns entity schema UId for business rules.
			 * @protected
			 * @returns {Guid} UId of business rule entity schema.
			 */
			getBusinessRuleEntitySchemaUId: function () {
				const config = BPMSoft.BusinessRuleSchemaManager.getDataSourcesConfig();
				const values = _.values(config);
				if (this.Ext.isEmpty(values)) {
					return;
				}
				const schemaName = values[0].entitySchemaName;
				return BPMSoft.EntitySchemaManager.findItemByName(schemaName).uId;
			}
		},

		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
