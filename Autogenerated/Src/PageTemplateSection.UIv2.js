/**
 * Parent: BaseLookupSection
 */
define("PageTemplateSection", ["PageTemplate"], function(PageTemplate) {
	return {
		entitySchemaName: "VwPageTemplate",
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getEntitySchemaNameForDelete
			 * @override
			 */
			getEntitySchemaNameForDelete: function() {
				return "PageTemplate";
			},

			/**
			 * @inheritdoc BPMSoft.BaseLookupSection#getModuleCaption
			 * @override
			 */
			getModuleCaption: function() {
				return PageTemplate.caption;
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			}
		]/**SCHEMA_DIFF*/
	};
});
