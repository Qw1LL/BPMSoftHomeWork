BPMSoft.sdk.GridPage.setTitle("ActivityParticipant", "MobileActivityParticipantGridPageTitle");

BPMSoft.sdk.GridPage.setPrimaryColumn("ActivityParticipant", "Participant");

BPMSoft.sdk.GridPage.setSubtitleColumns("ActivityParticipant", [
	{
		name: "Participant.Account"
	}
]);

BPMSoft.sdk.GridPage.setImageColumn("ActivityParticipant", "Participant.Photo.PreviewData",
	"MobileImageListDefaultContactPhoto");

BPMSoft.sdk.RecordPage.addColumn("ActivityParticipant", {
	name: "Participant"
}, "primaryColumnSet");

BPMSoft.sdk.Actions.add("ActivityParticipant", {
	name: "DeleteAction",
	isVisibleInGrid: true,
	isRecordAction: true,
	isVisibleInPreview: false,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionDelete"
});
