/**
 * Parent: BaseDataModificationUserTaskPropertiesPage
 */
define("DeleteDataUserTaskPropertiesPage", [],
		function() {
			return {
				methods: {

					/**
					 * @inheritdoc BaseDataModificationUserTaskPropertiesPage#getReferenceSchemaUIdParameterName
					 * @overridden
					 */
					getReferenceSchemaUIdParameterName: function() {
						return "EntitySchemaId";
					}
				}
			};
		}
);
