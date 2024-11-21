Ext.define("BPMSoft.configuration.view.ActivityParticipantGridPage", {
	extend: "BPMSoft.view.BaseGridPage.View",
	alternateClassName: "BPMSoft.configuration.ActivityParticipantGridPageView",
	config: {
		id: "ActivityParticipantGridPage",
		grid: {
			store: "BPMSoft.configuration.ActivityParticipantGridPageStore"
		}
	}
});

Ext.define("BPMSoft.configuration.store.ActivityParticipantGridPage", {
	extend: "BPMSoft.store.BaseStore",
	alternateClassName: "BPMSoft.configuration.ActivityParticipantGridPageStore",
	config: {
		model: "ActivityParticipant",
		controller: "BPMSoft.configuration.ActivityParticipantGridPageController"
	}
});
