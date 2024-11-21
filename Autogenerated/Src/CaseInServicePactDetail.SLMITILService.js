define("CaseInServicePactDetail",
	function() {
		return {
			entitySchemaName: "Case",
			attributes: {},
			methods: {

				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				getAddRecordButtonVisible: function() {
					return false;
				}
			},
			messages: {}
		};
	});
