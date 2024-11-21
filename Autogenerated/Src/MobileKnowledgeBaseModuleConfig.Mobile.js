BPMSoft.sdk.Module.setChangeModes("KnowledgeBase", []);
BPMSoft.sdk.RecordPage.addColumnSet("KnowledgeBase", {
	name: "primaryColumnSet",
	isPrimary: true,
	position: 0
});
BPMSoft.sdk.RecordPage.addColumn("KnowledgeBase", {
	name: "Name"
});
BPMSoft.sdk.RecordPage.addEmbeddedDetail("KnowledgeBase", {
		name: "KnowledgeBaseFilesDetail",
		position: 0,
		title: "KnowledgeBase_FilesDetail_title",
		modelName: "KnowledgeBaseFile",
		primaryKey: "Id",
		foreignKey: "KnowledgeBase",
		displaySeparator: false
	},
	[
		{
			name: "Data",
			displayColumn: "Name",
			label: "KnowledgeBaseRecordPage_FilesDetail_Data",
			viewType: BPMSoft.ViewTypes.File
		},
		{
			name: "Type",
			hidden: true
		},
		{
			name: "Name",
			label: "KnowledgeBaseRecordPage_FilesDetail_Name",
			viewType: BPMSoft.ViewTypes.Url
		}
	]
);
