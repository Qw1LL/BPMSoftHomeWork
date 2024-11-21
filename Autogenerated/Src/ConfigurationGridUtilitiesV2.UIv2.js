define("ConfigurationGridUtilitiesV2", ["ConfigurationGridUtilities"], function() {

	Ext.define("BPMSoft.configuration.mixins.ConfigurationGridUtilitiesV2", {
		extend: "BPMSoft.ConfigurationGridUtilities",
		alternateClassName: "BPMSoft.ConfigurationGridUtilitiesV2",

		/**
		 * @inheritdoc BPMSoft.ConfigurationGridUtilities#onActiveRowAction
		 * @override
		 */
		onActiveRowAction: function(buttonTag, primaryColumnValue) {
			if (buttonTag === "copy") {
				this.copyRow(primaryColumnValue);
			} else if (buttonTag === "card") {
				const gridData = this.getGridData();
				const row = gridData.get(primaryColumnValue);
				this.saveRowChanges(row, () => {
					this.editRecord(row);
				});
			} else {
				this.callParent(arguments);
			}
		}

	});

	return Ext.create("BPMSoft.ConfigurationGridUtilitiesV2");
});
