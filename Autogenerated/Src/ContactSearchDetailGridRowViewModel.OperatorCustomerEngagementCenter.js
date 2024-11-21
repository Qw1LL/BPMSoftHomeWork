define("ContactSearchDetailGridRowViewModel", ["ContactSearchDetailGridRowViewModelResources", "BaseGridRowViewModel"],
		function(resources) {

	Ext.define("BPMSoft.configuration.ContactSearchDetailGridRowViewModel", {
		extend: "BPMSoft.BaseGridRowViewModel",
		alternateClassName: "BPMSoft.ContactSearchDetailGridRowViewModel",

		/**
		 * ############## #######.
		 * @overridden
		 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#initResources
		 */
		initResources: function() {
			this.callParent(arguments);
			var strings = resources.localizableStrings;
			if (this.get("CaseVisibility")) {
				this.set("SelectButtonCaption", strings.SelectConsultationButtonCaption);
			} else if (!this.get("SelectButtonCaption")) {
				this.set("SelectButtonCaption", strings.SelectCaseButtonCaption);
			}
		}
	});

	return this.BPMSoft.ContactSearchDetailGridRowViewModel;
});
