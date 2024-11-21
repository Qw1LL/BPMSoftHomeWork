define("AccountSearchDetailGridRowViewModel", ["AccountSearchDetailGridRowViewModelResources", "BaseGridRowViewModel"],
		function(resources) {

			Ext.define("BPMSoft.configuration.AccountSearchDetailGridRowViewModel", {
				extend: "BPMSoft.BaseGridRowViewModel",
				alternateClassName: "BPMSoft.AccountSearchDetailGridRowViewModel",
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

			return this.BPMSoft.AccountSearchDetailGridRowViewModel;
		});
