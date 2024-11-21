/* globals ActivityParticipant: false */

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Title"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["StartDate"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["DueDate"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Status"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityCategoryRequirement",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["ActivityCategory"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "PriorityRequirement",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Priority"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "OwnerRequirement",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Owner"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Activation,
	triggeredByColumns: ["Status"],
	conditionalColumns: [
		{name: "Status.Finish", value: true}
	],
	dependentColumnNames: ["Result", "DetailedResult"]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityCategoryAndTypeMutualFiltrationRule",
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Type", "ActivityCategory"],
	connections: [
		{
			parent: "Type",
			child: "ActivityCategory",
			connectedBy: "ActivityType"
		}
	]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Account", "Contact"],
	connections: [
		{
			parent: "Account",
			child: "Contact"
		}
	]
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityCategoryFilterRule",
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ["ActivityCategory"],
	filters: Ext.create("BPMSoft.Filter", {
		compareType: BPMSoft.ComparisonTypes.NotEqual,
		property: "ActivityType",
		value: BPMSoft.GUID.ActivityTypeEmail,
		name: "81d05412-d90c-440a-831a-03fc52489fa5"
	})
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityResultByActivityCategoryFilter",
	position: 0,
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ["ActivityCategory"],
	filteredColumn: "Result",
	filters: Ext.create("BPMSoft.Filter", {
		property: "ActivityCategory",
		modelName: "ActivityCategoryResultEntry",
		assocProperty: "ActivityResult",
		operation: BPMSoft.FilterOperations.Any,
		name: "0c685faa-26ca-4a55-a6fa-3147b9b5009e"
	})
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Filtration,
	events: [BPMSoft.BusinessRuleEvents.Load],
	triggeredByColumns: ["Owner"],
	filters: Ext.create("BPMSoft.Filter", {
		property: "Active",
		modelName: "SysAdminUnit",
		assocProperty: "Contact",
		operation: BPMSoft.FilterOperations.Any,
		name: "ActivityContact_SysAdminUnit_Filtration",
		value: true
	})
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Comparison,
	triggeredByColumns: ["StartDate"],
	leftColumn: "DueDate",
	comparisonOperation: BPMSoft.ComparisonTypes.GreaterOrEqual,
	rightColumn: "StartDate"
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	ruleType: BPMSoft.RuleTypes.Comparison,
	triggeredByColumns: ["DueDate"],
	leftColumn: "StartDate",
	comparisonOperation: BPMSoft.ComparisonTypes.LessOrEqual,
	rightColumn: "DueDate"
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityResultByAllowedResultFilterRule",
	position: 1,
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Result"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Load],
	executeFn: function(record, rule, column, customData, callbackConfig) {
		var allowedResult = record.get("AllowedResult");
		var filterName = "ActivityResultByAllowedResultFilter";
		if (!Ext.isEmpty(allowedResult)) {
			var allowedResultIds =  Ext.JSON.decode(allowedResult, true);
			var resultIdsAreCorrect = true;
			for (var i = 0, ln = allowedResultIds.length; i < ln; i++) {
				var item = allowedResultIds[i];
				if (!BPMSoft.util.isGuid(item)) {
					resultIdsAreCorrect = false;
					break;
				}
			}
			if (resultIdsAreCorrect) {
				var filter = Ext.create("BPMSoft.Filter", {
					name: filterName,
					property: "Id",
					funcType: BPMSoft.FilterFunctions.In,
					funcArgs: allowedResultIds
				});
				record.changeProperty("Result", {
					addFilter: filter
				});
			} else {
				record.changeProperty("Result", {
					removeFilter: filterName
				});
			}
		} else {
			record.changeProperty("Result", {
				removeFilter: filterName
			});
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope, [true]);
	}
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityResultRequiredByStatusFinishedAndProcessElementId",
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Status", "Result"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Save],
	executeFn: function(record, rule, column, customData, callbackConfig) {
		var isValid = true;
		var processElementId = record.get("ProcessElementId");
		if (processElementId && processElementId !== BPMSoft.GUID_EMPTY) {
			isValid = !(record.get("Status.Id") === BPMSoft.Configuration.ActivityStatus.Finished &&
				Ext.isEmpty(record.get("Result")));
		}
		record.changeProperty("Result", {
			isValid: {
				value: isValid,
				message: BPMSoft.LS["Sys.RequirementRule.message"]
			}
		});
		Ext.callback(callbackConfig.success, callbackConfig.scope, [isValid]);
	}
});

BPMSoft.sdk.Model.setDefaultValuesFunc("Activity", function(config) {
	var coeff = 1000 * 60 * 5;
	var currentDate = new Date();
	var startDate = new Date(Math.round(currentDate.getTime() / coeff) * coeff);
	var dueDate = new Date(startDate.getTime() + 30 * 60000);
	config.record.set("StartDate", startDate);
	config.record.set("DueDate", dueDate);
	config.record.set("ShowInScheduler", true);
	Ext.callback(config.success, config.scope);
});

BPMSoft.updateParticipant = function(changedColumnName, oldValue, newValue, record, config, mode, callback) {
	var callbackFn = function() {
		if (Ext.isFunction(callback)) {
			Ext.callback(callback, this);
		} else if (callback === true) {
			Ext.callback(config.success, config.scope);
		}
	};
	if (Ext.isEmpty(mode)) {
		callbackFn();
		return;
	}
	var proxyType = record.getProxyType();
	var queryConfig = Ext.create("BPMSoft.QueryConfig", {
		columns: ["Activity", "Participant"],
		modelName: "ActivityParticipant"
	});

	function getDefaultOperationConfig() {
		return {
			isCancelable: false,
			queryConfig: queryConfig,
			success: callbackFn,
			failure: function(exception) {
				BPMSoft.Logger.logException(BPMSoft.LogSeverityLevel.Error, exception);
			},
			scope: this
		};
	}

	function loadParticipant(activityRecord, contactRecord, success) {
		var store = Ext.create("BPMSoft.BaseStore", {
			model: "ActivityParticipant"
		});
		var filter = Ext.create("BPMSoft.Filter", {
			type: "BPMSoft.FilterTypes.Group",
			subfilters: [
				{
					property: "Activity",
					value: activityRecord.get("Id")
				},
				{
					property: "Participant",
					value: contactRecord
				}
			]
		});
		store.setProxyType(proxyType);
		store.loadPage(1, {
			isCancelable: false,
			queryConfig: queryConfig,
			filters: filter,
			callback: success
		}, this);
	}

	function insertParticipant(activityRecord, contactRecord) {
		var newRecord = ActivityParticipant.create({
			"Activity": activityRecord,
			"Participant": contactRecord
		});
		newRecord.setProxyType(proxyType);
		newRecord.save(getDefaultOperationConfig());
	}

	function updateParticipant(participantRecord, contactRecord) {
		participantRecord.setProxyType(proxyType);
		participantRecord.set("Participant", contactRecord, true);
		participantRecord.save(getDefaultOperationConfig(), this);
	}

	function deleteParticipant(participantRecord) {
		participantRecord.setProxyType(proxyType);
		participantRecord.erase(getDefaultOperationConfig(), this);
	}

	if (mode === "insert") {
		insertParticipant(record, newValue);
	} else {
		loadParticipant(record, oldValue, function(data, operation, success) {
			if (success !== true) {
				callbackFn();
				return;
			}
			var hasLocalRecord = data.length > 0;
			if (mode === "update") {
				if (hasLocalRecord) {
					updateParticipant(data[0], newValue);
				} else {
					insertParticipant(record, newValue);
				}
			} else if (mode === "delete" && hasLocalRecord) {
				deleteParticipant(data[0]);
			} else {
				callbackFn();
			}
		});
	}
};

BPMSoft.processActivityColumnForUpdateActivityParticipantDetail = function(config, record, columnName, callback) {
	var mode = "";
	var oldValue = record.modified[columnName];
	var newValue = record.get(columnName);
	if ((record.phantom && !Ext.isEmpty(newValue)) || (oldValue === null && !Ext.isEmpty(newValue))) {
		mode = "insert";
	} else if (Ext.isEmpty(newValue) && !Ext.isEmpty(oldValue)) {
		mode = "delete";
	} else if (!Ext.isEmpty(newValue) && !Ext.isEmpty(oldValue) && (oldValue !== newValue)) {
		mode = "update";
	}
	BPMSoft.updateParticipant(columnName, oldValue, newValue, record, config, mode, callback);
};

BPMSoft.updateActivityParticipant = function(config) {
	var contact = this.get("Contact");
	var owner = this.get("Owner");
	if (contact && owner && (contact.getId() === owner.getId())) {
		BPMSoft.processActivityColumnForUpdateActivityParticipantDetail(config, this, "Contact", true);
	} else {
		BPMSoft.processActivityColumnForUpdateActivityParticipantDetail(config, this, "Contact", function() {
			BPMSoft.processActivityColumnForUpdateActivityParticipantDetail(config, this, "Owner", true);
		}.bind(this));
	}
};

(function() {
	var onActivityAfterInsertFn = function(config) {
		var record = this;
		if (record.get("ShowInScheduler")) {
			BPMSoft.configuration.ActivityGridCachedOperation.add([record]);
		}
		Ext.callback(config.success, config.scope);
	};
	var onActivityAfterUpdateFn = function(config) {
		var record = this;
		BPMSoft.configuration.ActivityGridCachedOperation.remove([record]);
		BPMSoft.configuration.ActivityGridCachedOperation.add([record]);
		Ext.callback(config.success, config.scope);
	};
	if (!BPMSoft.ApplicationUtils.isOnlineMode() || BPMSoft.ModelCache.isEnabledForModel("Activity")) {
		BPMSoft.sdk.Model.setModelEventHandler("Activity",
			BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.After].insert, BPMSoft.updateActivityParticipant);
		BPMSoft.sdk.Model.setModelEventHandler("Activity",
			BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.Before].update, BPMSoft.updateActivityParticipant);
	} else {
		BPMSoft.sdk.Model.setModelEventHandler("Activity",
			BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.After].insert, onActivityAfterInsertFn);
		BPMSoft.sdk.Model.setModelEventHandler("Activity",
			BPMSoft.ModelEvents[BPMSoft.ModelEventKinds.After].update, onActivityAfterUpdateFn);
	}
}());
