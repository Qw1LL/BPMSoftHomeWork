define("PreviewDefaultReplicaViewModel", ["PreviewReplicaViewModel"], function() {
	Ext.define("BPMSoft.configuration.PreviewDefaultReplicaViewModel", {
		alternateClassName: "BPMSoft.PreviewDefaultReplicaViewModel",
		extend: "BPMSoft.PreviewReplicaViewModel",

		/**
		 * Validate required columns.
		 * @returns {Boolean}
		 * @override
		 */
		hasError: function () {
			var hasError = Ext.isEmpty(this.$Subject) || Ext.isEmpty(this.$SenderEmail) || Ext.isEmpty(this.$SenderName);
			return hasError;
		}
	});
});
