define("EntityDataSourceViewModel", [
	"EntityDataSourceViewModelResources",
	"DataSourceViewModel"
], function(resources) {
	/**
	 */
	Ext.define("BPMSoft.configuration.EntityDataSourceViewModel", {
		extend: "BPMSoft.configuration.DataSourceViewModel",
		alternateClassName: "BPMSoft.EntityDataSourceViewModel",

		resources: resources,

		// region Methods: Protected

		/**
		 * @protected
		 */
		onEditDataSourceClick: function() {
			var designer = this.get("Designer");
			designer.onEditDataSource(this.get("Name"));
		},

		/**
		 * @protected
		 */
		onRemoveDataSourceClick: function() {
			var designer = this.get("Designer");
			var dataModelName = this.get("Name");
			var template = designer.get("Resources.Strings.DataModelRemoveConfirmation");
			var message = Ext.String.format(template, dataModelName);
			BPMSoft.showConfirmation(message, function(returnCode) {
				if (returnCode === "yes") {
					designer.onRemoveDataSource(this.get("Name"));
				}
			}, ["no", "yes"], this);
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
				NewColumnCaptionVisible: {value: true},
				DataModelMenu: {dataValueType: BPMSoft.DataValueType.COLLECTION},
				Designer: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT}
			});
		}

		// endregion

	});

	return BPMSoft.EntityDataSourceViewModel;
});
