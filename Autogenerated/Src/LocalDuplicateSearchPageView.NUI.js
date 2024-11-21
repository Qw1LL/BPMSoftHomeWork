define("LocalDuplicateSearchPageView", ["BPMSoft", "LocalDuplicateSearchPageViewResources"], function(BPMSoft,
		resources) {
	function generate(entitySchemaName) {
		this.entitySchemaName = entitySchemaName;
		var columnsConfig = [];
		if (entitySchemaName === "Account") {
			columnsConfig = [{
				cols: 6,
				key: [{
					name: resources.localizableStrings["GridTitle" + this.entitySchemaName],
					type: "caption"
				}, {
					name: {bindTo: "Name"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountPhone,
					type: "caption"
				}, {
					name: {bindTo: "Phone"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountAdditionalPhone,
					type: "caption"
				}, {
					name: {bindTo: "AdditionalPhone"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleAccountWeb,
					type: "caption"
				}, {
					name: {bindTo: "Web"}
				}]
			}];
		} else {
			columnsConfig = [{
				cols: 6,
				key: [{
					name: resources.localizableStrings["GridTitle" + this.entitySchemaName],
					type: "caption"
				}, {
					name: {bindTo: "Name"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactMobilePhone,
					type: "caption"
				}, {
					name: {bindTo: "MobilePhone"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactHomePhone,
					type: "caption"
				}, {
					name: {bindTo: "HomePhone"}
				}]
			}, {
				cols: 6,
				key: [{
					name: resources.localizableStrings.GridTitleContactEmail,
					type: "caption"
				}, {
					name: {bindTo: "Email"}
				}]
			}];
		}

		return {
			id: "localDuplicateSearchContainer",
			selectors: {wrapEl: "#localDuplicateSearchContainer"},
			items: [
				{
					className: "BPMSoft.Container",
					id: "buttonsContainer",
					selectors: {wrapEl: "#buttonsContainer"},
					items: [
						{
							className: "BPMSoft.Button",
							id: "acceptButton",
							caption: resources.localizableStrings.OkButtonCaption,
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							tag: "AcceptButton",
							click: {bindTo: "okClick"}
						},
						{
							className: "BPMSoft.Button",
							caption: resources.localizableStrings.CancelButtonCaption,
							tag: "CancelButton",
							click: {bindTo: "cancelClick"}
						}
					]
				},
				{
					className: "BPMSoft.Container",
					id: "DescriptionContainer",
					selectors: {
						wrapEl: "#DescriptionContainer"
					},
					items: [
						{
							className: "BPMSoft.Label",
							caption: {
								bindTo: "DescriptionCaption"
							}
						}
					]
				},
				{
					id: "duplicateGrid",
					className: "BPMSoft.Grid",
					type: "tiled",
					primaryColumnName: "Id",
					activeRow: {bindTo: "activeRow"},
					columnsConfig: [columnsConfig],
					collection: {bindTo: "gridData"},
					activeRowAction: {bindTo: "onActiveRowAction"},
					watchRowInViewport: 2,
					watchedRowInViewport: {bindTo: "needLoadData"},
					activeRowActions: [
						{
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: resources.localizableStrings.IsNotDuplicateCaption,
							tag: "IsNotDuplicate",
							visible: {bindTo: "getGridButtonIsNotDuplicateVisible"}
						},
						{
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: resources.localizableStrings.IsDuplicateCaption,
							tag: "IsDuplicate",
							visible: {bindTo: "getGridButtonIsDuplicateVisible"}
						}
					]
				}
			]
		};
	}

	return {generate: generate};
});
