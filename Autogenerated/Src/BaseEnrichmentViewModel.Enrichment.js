define("BaseEnrichmentViewModel", [], function() {
	Ext.define("BPMSoft.configuration.BaseEnrichmentViewModel", {
		alternateClassName: "BPMSoft.BaseEnrichmentViewModel",
		extend: "BPMSoft.BaseViewModel",
		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 * @inheritdoc BPMSoft.BaseModel#columns
		 * @overridden
		 */
		columns: {
			"IsChecked": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseModel#setInitialValue
		 * @overridden
		 */
		setInitialValue: function() {
			this.callParent(arguments);
			this.set("IsChecked", true);
		},

		/**
		 * On enriched link click.
		 * @protected
		 * @virtual
		 */
		onLinkClick: function() {
			return false;
		},

		/**
		 * Returns is item value is link.
		 * @protected
		 * @virtual
		 * @return {Object} True, if data is linkable.
		 */
		getIsLinkData: function() {
			return false;
		},

		/**
		 * Returns link config.
		 * @protected
		 * @virtual
		 * @return {Object} Enriched data link config.
		 */
		getHref: function() {
			return null;
		},

		/**
		 * Returns marker value.
		 * @protected
		 * @virtual
		 * @return {String} Enriched data marker value.
		 */
		getMarkerValue: function() {
			return this.get("CategoryTag");
		}
	});
});
