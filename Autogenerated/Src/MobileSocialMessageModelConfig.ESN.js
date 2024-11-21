/* globals VwSocialSubscription: false */
BPMSoft.sdk.Model.addBusinessRule("SocialMessage", {
	name: "SocialMessageMessageRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Message"],
	position: 0
});

BPMSoft.Configuration.updateSocialSubscription = function(config) {
	var socialMessageId = this.getId();
	var entityId = this.get("EntityId");
	var successFn = config.success;
	var failureFn = config.failure;
	var callbackScope = config.scope;
	var vwSocialSubscriptionRecord = VwSocialSubscription.create({
		SocialMessage: socialMessageId,
		SysAdminUnit: BPMSoft.CurrentUserInfo.userId,
		EntityId: entityId
	});
	vwSocialSubscriptionRecord.save({
		queryConfig: Ext.create("BPMSoft.QueryConfig", {
			modelName: "VwSocialSubscription",
			columns: ["SocialMessage", "SysAdminUnit", "EntityId"],
			isLogged: false
		}),
		success: function() {
			Ext.callback(successFn, callbackScope);
		},
		failure: function(exception) {
			Ext.callback(failureFn, callbackScope, [exception]);
		}
	}, this);
};

if (!BPMSoft.ApplicationUtils.isOnlineMode()) {
	BPMSoft.sdk.Model.setModelEventHandler("SocialMessage",
		BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.After].insert,
		BPMSoft.Configuration.updateSocialSubscription);
}
