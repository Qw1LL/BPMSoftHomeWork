define("ContactDuplicateSearchMixin", [], function() {

	Ext.define("BPMSoft.configuration.mixins.ContactDuplicateSearchMixin", {
		alternateClassName: "BPMSoft.ContactDuplicateSearchMixin",

		/**
		 * Returns duplicate rule filter value for contact name column.
		 * @returns {String[]} Duplicate rule filter value.
		 */
		getContactNameForSearchDuplicates: function() {
			var value = this.$Name || this._getFullName() || null;
			return [value];
		},

		/**
		 * Checks duplicate rule filter and returns true if duplicate rule by name.
		 * @param {Object} filter Duplicate rule filter config.
		 * @returns {Boolean} True if duplicate rule by name.
		 */
		isDuplicateRuleByName: function(filter) {
			return filter && filter.columnName === "Name";
		},

		/**
		 * @private
		 */
		_getFullName: function() {
			const nameFromSGM = Ext.String.format("{0} {1} {2}", 
				this.$Surname || "",
				this.$GivenName || "",
				this.$MiddleName || "");
			return Ext.String.trim(nameFromSGM);
		}
	});
});