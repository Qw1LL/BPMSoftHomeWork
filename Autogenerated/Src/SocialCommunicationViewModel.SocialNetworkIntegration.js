define("SocialCommunicationViewModel", ["BaseCommunicationViewModel"], function() {
	Ext.define("BPMSoft.configuration.SocialCommunicationViewModel", {
		alternateClassName: "BPMSoft.SocialCommunicationViewModel",
		extend: "BPMSoft.BaseCommunicationViewModel",

		/**
		 * ########## ####### ######### ######### ######## ###-####.
		 * @protected
		 * @param {Boolean} value ######### ######## ###-####.
		 */
		onSelectItem: function(value) {
			this.isDeleted = !value;
		},

		/**
		 * @inheritdoc BPMSoft.BaseCommunicationViewModel#getTypeButtonStyle
		 * @overridden
		 */
		getTypeButtonStyle: function() {
			var communicationType = this.get("CommunicationType");
			if (!communicationType) {
				return "red-communication-type";
			} else {
				return BPMSoft.controls.ButtonEnums.style.TRANSPARENT;
			}
		},

		/**
		 * ########## ###### ### ###-#####.
		 */
		getCheckBoxEditMarkerValue: function() {
			return Ext.String.format("{0} {1}", this.getIconTypeButtonMarkerValue(), "checkbox");
		}
	});
});
