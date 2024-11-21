 define("EmailEntityConnectionsDetailV2", ["Activity"],
	function(ActivitySchema) {
		return {
			methods: {

				/**
				 * Processes entity connections response.
				 * @protected
				 * @param  {Object} collection Entity connections collection.
				 * @return {BPMSoft.BaseViewModelCollection} Processed entity connections collection.
				 */
				processEntityConnectionsResponse: function (collection) {
					var activityConnectionColumn = ActivitySchema.getColumnByName("ActivityConnection");
					var viewModel = this.Ext.create("BPMSoft.EntityConnectionViewModel", {
						Ext: this.Ext,
						BPMSoft: this.BPMSoft,
						sandbox: this.sandbox,
						values: {
							"ReferenceSchema": ActivitySchema,
							"ColumnName": activityConnectionColumn.name,
							"Caption": activityConnectionColumn.caption,
							"ColumnUId": activityConnectionColumn.uId,
							"Position" : 0,
							"MarkerValue": activityConnectionColumn.name + " " + activityConnectionColumn.caption
						}
					});
					collection.add(viewModel.get("ColumnUId"), viewModel);
					this.callParent(arguments);
				}
			}
		};
});
