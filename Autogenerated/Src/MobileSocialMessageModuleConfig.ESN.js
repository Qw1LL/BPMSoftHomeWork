BPMSoft.sdk.GridPage.setPrimaryColumn("SocialMessage", "CreatedBy");

BPMSoft.sdk.GridPage.setGroupColumns("SocialMessage", [
	{
		name: "Message",
		isMultiline: true
	}
]);

BPMSoft.sdk.RecordPage.setTitle("SocialMessage", "update", "SocialMessageRecordPageTitle");

BPMSoft.sdk.RecordPage.setTitle("SocialMessage", "create", "SocialMessageRecordPageTitle");

BPMSoft.sdk.RecordPage.addColumnSet("SocialMessage", {
	name: "primaryColumnSet",
	isPrimary: true,
	position: 0
});

BPMSoft.sdk.RecordPage.addColumn("SocialMessage", {
	name: "Message",
	isMultiline: true,
	placeHolder: "SocialMessageSearchPlaceholder",
	customEditConfig: {
		xtype: "cfsocialmessagehtmlfield",
		tags: {
			"@": {
				modelName: "Contact",
				urlTpl: "Nui/ViewModule.aspx#CardModuleV2/ContactPageV2/edit/{0}"
			},
			"$": {
				modelName: "Account",
				urlTpl: "Nui/ViewModule.aspx#CardModuleV2/AccountPageV2/edit/{0}"
			}
		},
		requiredSymbol: ""
	}
}, "primaryColumnSet");

BPMSoft.sdk.Module.addFilter("SocialMessage", Ext.create("BPMSoft.Filter", {
	type: BPMSoft.FilterTypes.Group,
	subfilters: [
		{
			property: "Parent",
			isNot: true,
			compareType: BPMSoft.ComparisonTypes.NotEqual,
			value: null
		},
		{
			type: BPMSoft.FilterTypes.Group,
			logicalOperation: BPMSoft.FilterLogicalOperations.Or,
			subfilters: [
				{
					property: "EntityId",
					value: BPMSoft.CurrentUserInfo.contactId
				},
				{
					type: BPMSoft.FilterTypes.Group,
					logicalOperation: BPMSoft.FilterLogicalOperations.And,
					subfilters: [
						{
							modelName: "VwSocialSubscription",
							operation: BPMSoft.FilterOperations.Any,
							assocProperty: "SocialMessage",
							property: "SysAdminUnit",
							value: BPMSoft.CurrentUserInfo.userId
						},
						{
							type: BPMSoft.FilterTypes.Group,
							isNot: true,
							subfilters: [
								{
									modelName: "VwSocialUnsubscription",
									operation: BPMSoft.FilterOperations.Any,
									assocProperty: "SocialMessage",
									property: "SysAdminUnit",
									value: BPMSoft.CurrentUserInfo.userId
								}
							]
						}
					]
				}
			]
		}
	]
}));

BPMSoft.sdk.GridPage.setImageColumn("SocialMessage", "CreatedBy.Photo.PreviewData",
	"MobileImageListDefaultContactPhoto");

BPMSoft.sdk.GridPage.setOrderByColumns("SocialMessage", {
	column: "CreatedOn",
	orderType: BPMSoft.OrderTypes.DESC
});

BPMSoft.sdk.GridPage.addColumns("SocialMessage",
	["EntityId", "EntitySchemaUId", "Message", "LikeCount", "CommentCount", "CreatedOn", "CreatedBy"]);

BPMSoft.sdk.GridPage.setSearchPlaceholder("SocialMessage",
	BPMSoft.LocalizableStrings.SocialMessageSearchPlaceholder);

BPMSoft.sdk.Actions.add("SocialMessage", {
	name: "ShareLink",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.configuration.action.ShareLink"
});

BPMSoft.sdk.Actions.add("SocialMessage", {
	name: "Edit",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionEdit"
});

BPMSoft.sdk.Actions.add("SocialMessage", {
	name: "Delete",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	actionClassName: "BPMSoft.ActionDelete"
});

BPMSoft.sdk.Actions.add("SocialMessage", {
	name: "DeleteComment",
	isVisibleInGrid: true,
	isDisplayTitle: true,
	useInComment: true,
	autoNavigation: false,
	actionClassName: "BPMSoft.ActionDelete"
});
