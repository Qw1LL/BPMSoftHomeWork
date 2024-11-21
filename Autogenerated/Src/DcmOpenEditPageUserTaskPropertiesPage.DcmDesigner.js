 /**
 * Parent: OpenEditPageUserTaskPropertiesPage => BaseUserTaskPropertiesPage => RootUserTaskPropertiesPage
 * => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("DcmOpenEditPageUserTaskPropertiesPage", [],
	function() {
		return {

			/**
			 * Use base DCM schema.
			 * @type {Boolean}
			 */
			useBaseDcmSchema: true,

			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "GenerateDecisionsFromColumnContainer"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
