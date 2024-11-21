define("ProblemInServiceItemDetail",
	function() {
		return {
			entitySchemaName: "Problem",
			attributes: {},
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
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 24
									}
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
									"type": "text",
									"position": {
										"row": 1,
										"column": 0,
										"colSpan": 24
									},
									"captionConfig": {
										"visible": false
									}
								}
							]
						}
					}
				},
				{
					"operation": "remove",
					"name": "CopyRecordMenu"
				},
				{
					"operation": "remove",
					"name": "EditRecordMenu"
				}
			]/**SCHEMA_DIFF*/,
			methods: {},
			messages: {}
		};
	});
