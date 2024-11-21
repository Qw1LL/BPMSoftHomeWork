define("BaseClickHeatmapRowViewModel", ["BaseClickHeatmapRowViewModelResources"], function(resources) {
	/**
	 * @class BPMSoft.configuration.BaseClickHeatmapRowViewModel
	 */
	Ext.define("BPMSoft.configuration.BaseClickHeatmapRowViewModel", {
		extend: "BPMSoft.BaseModel",
		alternateClassName: "BPMSoft.BaseClickHeatmapRowViewModel",

		// region Fields: Protected

		/**
		 * Replica recipient info text template.
		 * @protected
		 * @type {String}
		 */
		replicaRecipientInfoTextTemplate: resources.localizableStrings.replicaRecipientInfoTextTemplate,

		// endregion

		// region Methods: Public

		/**
		 * Returns replica recipient info text.
		 * @return {String}
		 */
		getReplicaRecipientInfoText: function() {
			return Ext.String.format(this.replicaRecipientInfoTextTemplate, this.get("RecipientCount"),
				this.get("ReplicaPercent"));
		}

		// endregion
	});
	return BPMSoft.BaseClickHeatmapRowViewModel;
});
