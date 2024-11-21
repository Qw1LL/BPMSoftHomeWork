define("SysProcessLogSectionV2GridRowViewModel", ["ext-base", "SysProcessLogSectionV2GridRowViewModelResources",
	"BaseSectionGridRowViewModel"], function(Ext, resources) {
	/**
	 * @class BPMSoft.configuration.SysProcessLogSectionV2GridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.SysProcessLogSectionV2GridRowViewModel", {
		extend: "BPMSoft.BaseSectionGridRowViewModel",
		alternateClassName: "BPMSoft.SysProcessLogSectionV2GridRowViewModel",

		/**
		 * @inheritdoc BPMSoft.BaseSectionGridRowViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initErrorInfo();
		},

		/**
		 * ############## #######.
		 * @overridden
		 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#initResources
		 */
		initResources: function() {
			this.callParent();
			if (!resources.localizableStrings) {
				return;
			}
			BPMSoft.each(resources.localizableStrings, function(value, key) {
				this.set("Resources.Strings." + key, value);
			}, this);
		},

		/**
		 * Determines whether an element has trace data or not.
		 * @returns {boolean} True if it has, false otherwise.
		 */
		getElementHasTraceData: function() {
			return this.get("TraceDataCount") > 0;
		},

		/**
		 * Returns flag, indicates that current log item has error description defined.
		 * @returns {boolean}
		 */
		hasErrorDescription: function() {
			return Boolean(this.getFullErrorDescription());
		},

		/**
		 * Initializes error description data for displaying in grid.
		 */
		initErrorInfo: function() {
			if (!this.hasErrorDescription()) {
				return;
			}
			this._sourceErrorDescription = this.$ErrorDescription;
			const newlineIndex = this._sourceErrorDescription.indexOf("\n");
			if (newlineIndex > -1) {
				this.$ErrorDescription = this._sourceErrorDescription.substring(0, newlineIndex);
			}
		},

		/**
		 * Returns full error description for current log item.
		 * @returns {String}
		 */
		getFullErrorDescription: function() {
			return this._sourceErrorDescription || this.$ErrorDescription;
		}
	});
	return BPMSoft.SysProcessLogSectionV2GridRowViewModel;
});
