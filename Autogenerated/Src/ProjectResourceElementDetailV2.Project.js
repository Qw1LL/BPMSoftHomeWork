define("ProjectResourceElementDetailV2", ["BPMSoft", "ProjectResourceElementServiceHelper"],
	function(BPMSoft, ProjectResourceElementServiceHelper) {
		return {
			entitySchemaName: "ProjectResourceElement",
			methods: {
				checkIfDeleteRecords: function() {
					var records = this.getSelectedItems();
					if (!records || !records.length) {
						return;
					}
					if (records && records.length) {
						var self = this;
						var callback = function(response) {
							if (!response.Success) {
								var message;
								switch (response.Code) {
									case 200:
										message = this.get("Resources.Strings.ChildProjectExistsWarning");
										break;
									case 300:
										message = this.get("Resources.Strings.ChildActivityExistsWarning");
										break;
									default:
										message = this.get("Resources.Strings.DefaultWarning");
								}
								self.showInformationDialog(message);
							} else {
								this.set("canDelete", true);
								self.deleteRecords();
							}
						};
						ProjectResourceElementServiceHelper.getCanDelete(records, callback, this);
					}
				},
				deleteRecords: function() {
					if (this.get("canDelete")) {
						this.callParent(arguments);
						this.set("canDelete", false);
					} else {
						this.checkIfDeleteRecords();
					}
				}
			},
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
									"position": {
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "PlanningWorkListedGridColumn",
									"bindTo": "PlanningWork",
									"position": {
										"column": 9,
										"colSpan": 8
									}
								},
								{
									"name": "ActualWorkListedGridColumn",
									"bindTo": "ActualWork",
									"position": {
										"column": 17,
										"colSpan": 8
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
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "PlanningWorkTiledGridColumn",
									"bindTo": "PlanningWork",
									"position": {
										"row": 1,
										"column": 9,
										"colSpan": 8
									}
								},
								{
									"name": "ActualWorkTiledGridColumn",
									"bindTo": "ActualWork",
									"position": {
										"row": 1,
										"column": 17,
										"colSpan": 8
									}
								},
								{
									"name": "PlanningWorkTiledGridColumn",
									"bindTo": "InternalRate",
									"position": {
										"row": 2,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "ActualWorkTiledGridColumn",
									"bindTo": "ExternalRate",
									"position": {
										"row": 2,
										"column": 13,
										"colSpan": 11
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
