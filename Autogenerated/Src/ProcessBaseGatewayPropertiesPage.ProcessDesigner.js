/**
 * ProcessBaseGatewayPropertiesPage edit page schema.
 * Parent: BaseProcessSchemaElementPropertiesPage.
 */
define("ProcessBaseGatewayPropertiesPage", function() {
	return {
		messages: {},
		attributes: {},
		methods: {
			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getIsSerializeToDBVisible
			 * @overridden
			 */
			getIsSerializeToDBVisible: function() {
				return false;
			},
			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#getIsLoggingVisible
			 * @overridden
			 */
			getIsLoggingVisible: function() {
				return false;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
