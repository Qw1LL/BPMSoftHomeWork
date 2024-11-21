define("RecipientsSearchLookupEdit", ["BPMSoft", "ext-base", "ContainerList", "SchemaBuilderV2"],
		function(BPMSoft, Ext) {
	/**
	 * Control for working with lookups.
	 */
	Ext.define("BPMSoft.controls.RecipientsSearchLookupEdit", {
		extend: "BPMSoft.controls.LookupEdit",
		alternateClassName: "BPMSoft.RecipientsSearchLookupEdit",
		/**
		 * Lookup minimum search chars count.
		 * @private
		 * @type {Integer}
		 */
		_minSearchCharsCount: -1,

		/**
		 * inheritdoc BPMSoft.Component#init
		 * Overridden minSearchCharsCount value.
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.minSearchCharsCount = this._minSearchCharsCount;
		},

		/**
		 * @inheritdoc BPMSoft.controls.mixins.ExpandableList#expandList
		 * Search value definition.
		 * @protected
		 * @overridden
		 */
		expandList: function(searchValue) {
			searchValue = searchValue || this.typedValue || this.getTypedValue() || "";
			this.mixins.expandableList.expandList.call(this, searchValue);
		}
	});
});