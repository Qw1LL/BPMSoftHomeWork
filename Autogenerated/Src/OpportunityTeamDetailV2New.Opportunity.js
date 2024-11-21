define("OpportunityTeamDetailV2New", [], function() {
	return {
		entitySchemaName: "OpportunityParticipant",
		methods: {
			getGridDataColumns: function() {
				return {
					"Id": {path: "Id"},
					"Contact": {path:  "Contact"},
					"Role": {path:  "Role"},
					"Account": {path:  "Account"},
					"Contact.Phone": {path:  "Contact.Phone"},
					"Contact.Email": {path:  "Contact.Email"},
					"Contact.Name": {path:  "Contact.Name"}
				};
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
			 * @overridden
			 */
			getFilterDefaultColumnName: function() {
				return "Contact";
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"primaryDisplayColumnName": "Contact.Name",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "ContactListedGridColumn",
								"bindTo": "Contact",
								"position": {
									"column": 1,
									"colSpan": 11
								},
								"type": BPMSoft.GridCellType.TITLE
							},
							{
								"name": "RoleListedGridColumn",
								"bindTo": "Role",
								"position": {
									"column": 13,
									"colSpan": 11
								}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {
							"columns": 24,
							"rows": 3
						},
						"items": [
							{
								"name": "ContactTiledGridColumn",
								"bindTo": "Contact",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 11
								},
								"type": BPMSoft.GridCellType.TITLE
							},
							{
								"name": "AccountTiledGridColumn",
								"bindTo": "Account",
								"position": {
									"row": 1,
									"column": 13,
									"colSpan": 11
								}
							},
							{
								"name": "RoleTiledGridColumn",
								"bindTo": "role",
								"position": {
									"row": 2,
									"rowSpan": 2,
									"column": 1,
									"colSpan": 8
								},
								"type": BPMSoft.GridCellType.TITLE
							},
							{
								"name": "PhoneTiledGridColumn",
								"bindTo": "Contact.Phone",
								"position": {
									"row": 2,
									"rowSpan": 2,
									"column": 9,
									"colSpan": 8
								}
							},
							{
								"name": "EmailTiledGridColumn",
								"bindTo": "Contact.Email",
								"position": {
									"row": 2,
									"rowSpan": 2,
									"column": 17,
									"colSpan": 8
								}
							}
						]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
