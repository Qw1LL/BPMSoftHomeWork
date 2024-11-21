define("DataSourceViewModel", ["DataSourceViewModelResources"], function(resources) {
	/**
	 */
	Ext.define("BPMSoft.configuration.DataSourceViewModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.DataSourceViewModel",

		resources: resources,

		columns: {
			EntitySchemaUId: {dataValueType: BPMSoft.DataValueType.LOOKUP},
			Name: {dataValueType: BPMSoft.DataValueType.TEXT},
			Schema: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT},
			CanAddNewColumn: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				valse: false
			},
			IsPrimary: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			Collapsed: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				valueList: true
			},
			IsPageElementsVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			NewColumnCaptionVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},

		/**
		 * Returns data model column path.
		 * @param {String} columnName Column name.
		 * @return {String} Column path.
		 */
		getColumnPath: function(columnName) {
			return this.get("IsPrimary") ? columnName : this.get("Name") + "." + columnName;
		}

	});

	return BPMSoft.DataSourceViewModel;
});
