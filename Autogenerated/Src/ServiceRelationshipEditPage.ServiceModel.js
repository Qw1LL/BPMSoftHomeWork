define("ServiceRelationshipEditPage", [],
	function() {
		return {
			entitySchemaName: "VwServiceRelationship",
			attributes: {
				"ServiceItemB": {
					"lookupListConfig": {
						"filter": function() {
							return this.getLookupFilter("ServiceItemB", "ServiceItemA");
						}
					}
				},
				"DependencyTypeFilterColumnName": {
					value: "ForServiceService"
				}
			}
		};
	});
