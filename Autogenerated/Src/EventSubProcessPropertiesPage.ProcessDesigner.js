/**
 * Parent: BaseProcessSchemaElementPropertiesPage
 */
define("EventSubProcessPropertiesPage", [],
	function() {
		return {
			messages: {},
			mixins: {},
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseProcessSchemaElementPropertiesPage#getIsEditPageDefault
				 * @overridden
				 */
				getIsEditPageDefault: function() {
					return true;
				}
			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	}
);
