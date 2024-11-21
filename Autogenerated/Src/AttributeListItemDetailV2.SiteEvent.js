define("AttributeListItemDetailV2", [],
	function() {
		return {
			entitySchemaName: "SiteEventAttrListItem",
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "NameListedGridColumn",
									"bindTo": "Name",
									"position": {"column": 0, "colSpan": 24}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 1
							},
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"position": {"row": 0, "column": 0, "colSpan": 11}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
