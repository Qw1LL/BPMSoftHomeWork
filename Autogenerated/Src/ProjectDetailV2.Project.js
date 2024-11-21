define("ProjectDetailV2", ["XRMConstants"],
	function(XRMConstants) {
		return {
			entitySchemaName: "Project",
			methods: {
				/**
				 * ############## ######### ####### ############## ########
				 * @overridden
				 */
				initEditPages: function() {
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					var keys = editPages.getKeys();
					var projectTypeId = XRMConstants.Project.EntryType.Project;
					this.BPMSoft.each(keys, function(key) {
						if (key !== projectTypeId) {
							editPages.removeByKey(key);
						}
					}, this);
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
							"items": [{
								"name": "NameListedGridColumn",
								"bindTo": "Name",
								"position": {
									"column": 1,
									"colSpan": 11
								}
							}, {
								"name": "StartDateListedGridColumn",
								"bindTo": "StartDate",
								"position": {
									"column": 13,
									"colSpan": 4
								}
							}, {
								"name": "EndDateListedGridColumn",
								"bindTo": "EndDate",
								"position": {
									"column": 17,
									"colSpan": 4
								}
							}, {
								"name": "ActualCompletionListedGridColumn",
								"bindTo": "ActualCompletion",
								"position": {
									"column": 21,
									"colSpan": 4
								}
							}]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [{
								"name": "NameTiledGridColumn",
								"bindTo": "Name",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 11
								}
							}, {
								"name": "StartDateTiledGridColumn",
								"bindTo": "StartDate",
								"position": {
									"row": 1,
									"column": 13,
									"colSpan": 4
								}
							}, {
								"name": "EndDateTiledGridColumn",
								"bindTo": "EndDate",
								"position": {
									"row": 1,
									"column": 17,
									"colSpan": 4
								}
							}, {
								"name": "ActualCompletionTiledGridColumn",
								"bindTo": "ActualCompletion",
								"position": {
									"row": 1,
									"column": 21,
									"colSpan": 4
								}
							}]
						}
					}
				}]/**SCHEMA_DIFF*/
			};
	});
