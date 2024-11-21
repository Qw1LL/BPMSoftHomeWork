define("ConfItemRelationshipEditPage", [],
	function() {
		return {
			entitySchemaName: "VwConfItemRelationship",
			attributes: {
				"ConfItemB": {
					"lookupListConfig": {
						"filter": function() {
							return this.getLookupFilter("ConfItemB", "ConfItemA");
						}
					}
				},
				"DependencyTypeFilterColumnName": {
					value: "ForConfItemConfItem"
				}
			}
		};
	});
