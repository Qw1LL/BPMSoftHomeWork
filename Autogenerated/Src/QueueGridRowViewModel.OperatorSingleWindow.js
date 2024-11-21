define("QueueGridRowViewModel", ["ext-base", "BaseGridRowViewModel"],
	function(Ext) {

	/**
	 * @class BPMSoft.configuration.QueueGridRowViewModel
	 * ##### ###### ############# ###### #######
	 */
	Ext.define("BPMSoft.configuration.QueueGridRowViewModel", {
		extend: "BPMSoft.BaseGridRowViewModel",
		alternateClassName: "BPMSoft.QueueGridRowViewModel",

		/**
		 * ########## ####### ######### ###### "##### # ######".
		 * @private
		 * @returns {boolean} ####### #########.
		 */
		getIsProcessRunButtonVisible: function() {
			return !this.get("IsSupervisorMode");
		}
	});

	return BPMSoft.QueueGridRowViewModel;
});
