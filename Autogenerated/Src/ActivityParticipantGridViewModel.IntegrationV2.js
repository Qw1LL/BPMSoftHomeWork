define("ActivityParticipantGridViewModel", ["ActivityParticipantGridViewModelResources", "ConfigurationConstants",
		"BaseGridRowViewModel", "NavigationServiceUtility", "css!ActivityParticipantGridViewModel"],
	function(resources, configurationConstants) {
 	/**
	 * @class BPMSoft.configuration.ActivityParticipantGridViewModel
	 */
	Ext.define("BPMSoft.configuration.ActivityParticipantGridViewModel", {
		extend: "BPMSoft.BaseGridRowViewModel",
		alternateClassName: "BPMSoft.ActivityParticipantGridViewModel",

		//region Methods: Protected
		
		/**
		 * Returns current participant name.
		 * @protected
		 * @return {String} Current participant name.
		 */
		getParticipantName: function() {
			const participant = this.$Participant || {};
			return participant.displayValue;
		},

		/**
		 * Returns marker value for invitation state icon.
		 * @protected
		 * @return {String} Marker value for invitation state icon.
		 */
		getStateIconMarekValue: function () {
			const participantName = this.getParticipantName();
			let markerValue = participantName + " InvitationStateIcon";
			const inviteResponse = this.$InviteResponse;
			if (inviteResponse) {
				markerValue += " " + inviteResponse.displayValue;
			}
			return markerValue;
		},

		/**
		 * Returns tip for invitation state icon.
		 * @protected
		 * @return {String} Tip for invitation state icon.
		 */
		getStateIconTip: function () {
			let tip; 
			const inviteResponse = this.$InviteResponse;
			switch (inviteResponse.value) {
				case configurationConstants.Activity.ParticipantInviteResponse.Confirmed:
					tip = resources.localizableStrings.AcceptedTip;
					break;
				case configurationConstants.Activity.ParticipantInviteResponse.Declined:
					tip = resources.localizableStrings.DeclinedTip;
					break;
				case configurationConstants.Activity.ParticipantInviteResponse.InDoubt:
					tip = resources.localizableStrings.InDoubtTip;
					break;
				default:
					tip = resources.localizableStrings.UnknownTip;
					break;
			}
			return tip;
		},

		/**
		 * Returns participant invitation state icon config.
		 * @protected
		 * @return {Object} Participant invitation icon image config.
		 */
		getStateIconConfig: function () {
			if (!this.$InviteParticipant) {
				return BPMSoft.emptyString;
			}
			let icon; 
			const inviteResponse = this.$InviteResponse;
			switch (inviteResponse.value) {
				case configurationConstants.Activity.ParticipantInviteResponse.Confirmed:
					icon = resources.localizableImages.InvitationAcceptedIcon;
					break;
				case configurationConstants.Activity.ParticipantInviteResponse.Declined:
					icon = resources.localizableImages.InvitationDeclinedIcon;
					break;
				default:
					icon = resources.localizableImages.InDoubtIcon;
					break;
			}
			return icon;
		},

		/**
		 * Get navigation link to contact entity.
		 * @returns {String} Navigation link to contact entity.
		 */
		getParticipantLink: function() {
			var participant = this.$Participant || {};
			const recordId = participant.value;
			return BPMSoft.NavigationServiceUtility.getEntitySchemaRecordUrl("Contact", recordId);
		}

		//endregion

	});

	return BPMSoft.ActivityParticipantGridViewModel;
});
