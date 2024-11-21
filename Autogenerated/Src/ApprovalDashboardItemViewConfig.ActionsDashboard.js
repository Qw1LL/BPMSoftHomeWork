define("ApprovalDashboardItemViewConfig", ["BaseDashboardItemViewConfig"], function() {
	Ext.define("BPMSoft.configuration.ApprovalDashboardItemViewConfig", {
		extend: "BPMSoft.BaseDashboardItemViewConfig",
		alternateClassName: "BPMSoft.ApprovalDashboardItemViewConfig",

		/**
		 * @inheritdoc BPMSoft.BaseDashboardItemViewConfig#getActionsViewConfig
		 * @overridden
		 */
		getActionsViewConfig: function() {
			return {
				"name": "Actions",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["dashboard-item-actions on-hover-visible", "approval-dashboard-item-actions"]
				},
				"items": [
					{
						"name": "Approve",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "ApproveButtonCaption"},
						"click": {"bindTo": "onApproveButtonClick"},
						"visible": true,
						"tag": {
							"imageName": "ApproveButtonIcon"
						},
						"imageConfig": {"bindTo": "getButtonImageConfig"},
						"hint": {"bindTo": "ApproveButtonCaption"}
					},
					{
						"name": "Reject",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "RejectButtonCaption"},
						"click": {"bindTo": "onRejectButtonClick"},
						"visible": true,
						"tag": {
							"imageName": "RejectButtonIcon"
						},
						"imageConfig": {"bindTo": "getButtonImageConfig"},
						"hint": {"bindTo": "RejectButtonCaption"}
					},
					{
						"name": "ChangeApprover",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "ChangeApproverButtonCaption"},
						"click": {"bindTo": "onChangeApproverButtonClick"},
						"visible": {"bindTo": "IsAllowedToDelegate"},
						"tag": {
							"imageName": "ChangeApproverButtonIcon"
						},
						"imageConfig": {"bindTo": "getButtonImageConfig"},
						"hint": {"bindTo": "ChangeApproverButtonCaption"}
					}
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseDashboardItemViewConfig#getContainerViewConfig
		 * @overridden
		 */
		getContainerViewConfig: function() {
			return {
				"name": "Content",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {wrapClassName: ["dashboard-item-content"]},
				"items": [
					{
						"name": "Caption",
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getCaption"},
						"markerValue": {"bindTo": "Caption"},
						"isRequired": {"bindTo": "IsRequired"},
						"classes": {
							"labelClass": ["dashboard-item"]
						},
						"tips": [{
							"content": {"bindTo": "Caption"},
							"markerValue": {"bindTo": "Caption"}
						}]
					}
				]
			};
		}
	});
});
