define("SectionProcessSettingsManagerItem", ["BaseProcessSettingsManagerItem"], function() {
	Ext.define("BPMSoft.SectionProcessSettingsManagerItem", {
		extend: "BPMSoft.BaseProcessSettingsManagerItem",
		alternateClassName: "BPMSoft.SectionProcessSettingsManagerItem",

		/**
		 * Section.
		 * @private
		 * @type {Object}
		 */
		moduleId: null,

		/**
		 * @inheritdoc BaseProcessSettingsManagerItem#getProcessRunnerId
		 * @overridden
		 */
		getProcessRunnerId: function() {
			var result = this.getPropertyValue("moduleId");
			if (Ext.isEmpty(result) && this.dataManagerItem) {
				var lookup = this.dataManagerItem.getColumnValue("SysModule");
				result = lookup.value;
			}
			return result;
		},

		/**
		 * @inheritdoc BaseProcessSettingsManagerItem#setProcessRunnerId
		 * @overridden
		 */
		setProcessRunnerId: function(value) {
			this.setPropertyValue("moduleId", value);
			this.dataManagerItem.setColumnValue("SysModule", {
				value: value
			});
		}
	});
	return BPMSoft.SectionProcessSettingsManagerItem;
});
