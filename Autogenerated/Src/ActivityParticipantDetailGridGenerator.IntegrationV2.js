define("ActivityParticipantDetailGridGenerator", ["ViewGeneratorV2", "ConfigurationEnumsV2"], function() {

	/**
	 * Mini Page controls generator class.
	 */
	Ext.define("BPMSoft.configuration.ActivityParticipantDetailGridGenerator", {
		extend: "BPMSoft.configuration.ViewGenerator",
		alternateClassName: "BPMSoft.ActivityParticipantDetailGridGenerator",

		generateGrid: function(config) {
			if (BPMSoft.Features.getIsEnabled("ShowInvitationState")) {
				config.className = "BPMSoft.ControlGrid";
				config.controlColumnName = "Participant";
				config.applyControlConfig = {"bindTo": "getParticipantControlConfig"};
			}
			return this.callParent(arguments);
		}

	});

	return Ext.create("BPMSoft.ActivityParticipantDetailGridGenerator");
});
 