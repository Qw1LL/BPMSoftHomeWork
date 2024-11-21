define("ParameterDataSourceViewModel", ["ParameterDataSourceViewModelResources", "DataSourceViewModel"], function(resources) {
	/**
	 */
	Ext.define("BPMSoft.configuration.ParameterDataSourceViewModel", {
		extend: "BPMSoft.configuration.DataSourceViewModel",
		alternateClassName: "BPMSoft.ParameterDataSourceViewModel",

		resources: resources,

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.DataSourceViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.set("UId", this.get("Schema").uId);
			this.set("CanAddNewColumn", this.get("Schema").canDesignSchema());
		},

		/**
		 * @inheritdoc BPMSoft.DataSourceViewModel#getModelColumns
		 * @override
		 */
		getModelColumns: function() {
			var baseColumns = this.callParent(arguments);
			return Ext.apply(baseColumns, {
				/**
				 * @override
				 */
				Name: {value: "Parameters"},
				/**
				 * @override
				 */
				IsPrimary: {value: true},
				/**
				 * @override
				 */
				NewColumnCaptionVisible: {value: true},
				Caption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.Caption
				}
			});
		}

		// endregion

	});

	return BPMSoft.ParameterDataSourceViewModel;
});
