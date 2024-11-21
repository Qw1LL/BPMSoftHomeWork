define("CheckedCommunicationViewModel", ["CheckedCommunicationViewModelResources", "CTIBaseCommunicationViewModel"],
		function(resources) {
			Ext.define("BPMSoft.configuration.CheckedCommunicationViewModel", {
				alternateClassName: "BPMSoft.CheckedCommunicationViewModel",
				extend: "BPMSoft.CTIBaseCommunicationViewModel",

				/**
				 * ########## ####### ## ######### ############ ######## #####.
				 * @protected
				 * @param {Boolean} checked ######### ############.
				 */
				nonActualChanged: function(checked) {
					this.set("NonActual", !checked);
				},

				/**
				 * ########## ######### #### ######## #####.
				 * @protected
				 * @return {String} #########.
				 */
				getCommunicationTypeCaption: function() {
					var communicationType = this.get("CommunicationType");
					return (this.get("NonActual") === true)
							? Ext.String.format("{0} {1}", communicationType.displayValue,
									resources.localizableStrings.NonActualCaption)
							: communicationType.displayValue;
				}
			});
		});
