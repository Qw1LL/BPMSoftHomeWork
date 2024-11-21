define("ElementDataSourceViewModel", [
	"ElementDataSourceViewModelResources",
	"DataSourceViewModel"
], function(resources) {
	/**
	 */
	Ext.define("BPMSoft.configuration.ElementDataSourceViewModel", {
		extend: "BPMSoft.configuration.DataSourceViewModel",
		alternateClassName: "BPMSoft.ElementDataSourceViewModel",

		resources: resources,

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.DataSourceViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.set("UId", this.get("Schema").uId);
			this.set("IsNewPageSchema", this.get("Schema").isNew());
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
				Name: {value: "Elements"},
				/**
				 * @override
				 */
				IsPageElementsVisible: {value: true},
				Caption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: resources.localizableStrings.Caption
				}
			});
		}

		// endregion

	});

	return BPMSoft.ElementDataSourceViewModel;
});
