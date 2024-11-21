BPMSoft.sdk.Model.addBusinessRule("Lead", {
	name: "LeadTypeRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["LeadType"]
});

BPMSoft.sdk.Model.addBusinessRule("Lead", {
	name: "LeadCountryRegionCityMutualFiltrationRule",
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Country", "Region", "City"],
	events: [BPMSoft.BusinessRuleEvents.Load, BPMSoft.BusinessRuleEvents.ValueChanged],
	connections: [
		{
			parent: "Country",
			child: "City"
		},
		{
			parent: "Country",
			child: "Region"
		},
		{
			parent: "Region",
			child: "City"
		}
	]
});

(function() {
	function getLeadType(record) {
		return new Promise(function(resolve) {
			var leadType = record.get("LeadType");
			if (!(leadType instanceof BPMSoft.model.BaseModel)) {
				BPMSoft.DataUtils.loadRecords({
					modelName: "LeadType",
					proxyType: BPMSoft.ProxyType.Offline,
					columns: ["Name"],
					filters: Ext.create("BPMSoft.Filter", {
						property: "Id",
						value: leadType
					}),
					success: function(records) {
						if (!Ext.isEmpty(records)) {
							resolve(records[0]);
						} else {
							resolve(null);
						}
					},
					failure: function(exception) {
						resolve(null);
					},
					scope: this
				});
			} else {
				resolve(leadType);
			}
		});
	}

	function calculateLeadName(config) {
		var record = this;
		var values = [];
		var account = record.get("Account");
		var contact = record.get("Contact");
		var contacts = [];
		if (!Ext.isEmpty(contact)) {
			contacts.push(contact);
		}
		if (!Ext.isEmpty(account)) {
			contacts.push(account);
		}
		contacts = contacts.join(", ");
		values.push(contacts);
		getLeadType(record).then(function(leadTypeRecord) {
			if (leadTypeRecord) {
				values.unshift(leadTypeRecord.getPrimaryDisplayColumnValue());
			}
			var newLeadName = values.join(" / ");
			if (record.get("LeadName") !== newLeadName) {
				record.set("LeadName", newLeadName);
			}
			Ext.callback(config.success, config.scope);
		}.bind(this));
	}

	BPMSoft.sdk.Model.setModelEventHandler("Lead", BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.Before].insert,
		calculateLeadName
	);
	BPMSoft.sdk.Model.setModelEventHandler("Lead", BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.Before].update,
		calculateLeadName
	);
})();
