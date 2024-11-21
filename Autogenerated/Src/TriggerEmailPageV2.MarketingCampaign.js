define("TriggerEmailPageV2", ["TriggerEmailPageV2Resources", "MarketingEnums", "BulkEmailHelper", "BusinessRuleModule",
		"MarketingCommonUtilities", "css!InfoButtonStyles", "css!InfoButtonCSS"],
	function(resources, MarketingEnums, BulkEmailHelper, BusinessRuleModule, MarketingCommonUtilities) {
		return {
			entitySchemaName: "BulkEmail",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {
				"IsActiveTriggerEmail": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					dependencies: [
						{
							columns: ["Status"],
							methodName: "processStatusColumn"
						}
					]
				},
				"CampaignStatus": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					columnPath: "Campaign.CampaignStatus",
					dataValueType: BPMSoft.DataValueType.LOOKUP
				},
				"CampaignType": {
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					columnPath: "Campaign.Type.Id",
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				"OldDesignerTypeId": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "389eb587-52d4-4ab6-b4ad-e7e2f0d62eac"
				},
				"SendDueDateCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					dependencies: [
						{
							columns: ["LaunchOption"],
							methodName: "processLaunchOptionColumn"
						}
					]
				},
				"SendStartDateCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					dependencies: [
						{
							columns: ["LaunchOption"],
							methodName: "processLaunchOptionColumn"
						}
					]
				},
				"IsHeaderCampaignGridLayoutVisible": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			methods: {
				/**
				 * @override
				 */
				getIsThrottlingQueueFeatureEnabled: function() {
					return this.getIsFeatureEnabled("TriggerEmailThrottlingQueue");
				},
				
				/**
				 * @override
				 */
				showAudienceSchema: function() {
					this.callParent(arguments);
					return BPMSoft.Features.getIsEnabled("CampaignAudienceImport");
				},

				/**
				 * Gets the date and time of sending the following letter.
				 * @private
				 * @return {Object} Date and time next sending letter.
				 */
				getNextTriggerDateTime: function() {
					var startDate = this.get("StartDate");
					if (!startDate) {
						return startDate;
					}
					var date = Ext.Date.clearTime(startDate, new Date());
					var millisecondsCount = Ext.Date.getElapsed(date, startDate);
					var nowDate = Ext.Date.clearTime(new Date());
					var nextTriggerDateTime = Ext.Date.add(nowDate, Ext.Date.MILLI, millisecondsCount);
					if (nextTriggerDateTime < new Date()) {
						nextTriggerDateTime = Ext.Date.add(nextTriggerDateTime, Ext.Date.DAY, 1);
					}
					return nextTriggerDateTime;
				},

				/**
				 * Gets the date and time, rounded to the specified number of minutes.
				 * @param {Object} dateTime Object Date/Time.
				 * @param {Number} minuteInterval Multiplicity of rounding in minutes.
				 * @private
				 * @return {Object} Date and time rounded.
				 */
				getRoundDateTime: function(dateTime, minuteInterval) {
					if (!dateTime) {
						dateTime = new Date();
					}
					var roundMinuteCount = Math.round(dateTime.getMinutes() / minuteInterval + 0.5) * minuteInterval;
					var minutCount = roundMinuteCount - dateTime.getMinutes();
					return Ext.Date.add(dateTime, Ext.Date.MINUTE, minutCount);
				},

				/**
				 * Method handler pressing context-sensitive help for the field time (StartDate).
				 * @private
				 */
				showInfoToolTip: function() {
					var status = this.get("Status");
					var isActive = BulkEmailHelper.GetIsActiveStatus.call(this, status.value);
					var launchOption = this.get("LaunchOption").value;
					var message = "";
					if (launchOption === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED) {
						message = this.getScheduledTriggerEmailToolTipMessage(isActive);
					} else if (launchOption === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_IMMEDIATE) {
						message = this.getImmediateTriggerEmailToolTipMessage(isActive);
					} else if (launchOption === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_HOURLY) {
						message = this.getHourlyTriggerEmailToolTipMessage(isActive);
					}
					this.showInformationDialog(message);
				},

				/**
				 * Gets the help text for the scheduled trigger emails.
				 * @param {Boolean} isActive Attribute an active trigger.
				 * @returns {String} Message text.
				 */
				getScheduledTriggerEmailToolTipMessage: function(isActive) {
					var message;
					var dateFormat = "d.m.Y H:i";
					var nextTriggerDateTime = this.getNextTriggerDateTime();
					if (nextTriggerDateTime) {
						var nextDate = Ext.Date.format(nextTriggerDateTime, dateFormat);
						message = (isActive)
							? this.get("Resources.Strings.StartDateForActiveEmailTooltip")
							: this.get("Resources.Strings.StartDateForDeactivateEmailTooltip");
						message = Ext.String.format(message, nextDate);
					} else {
						message = (isActive)
							? this.get("Resources.Strings.StartDateTooltipWithUnknownDateActivate")
							: this.get("Resources.Strings.StartDateTooltipWithUnknownDateDeactivate");
					}
					return message;
				},

				/**
				 * Gets the help text for instant trigger emails.
				 * @param {Boolean} isActive Attribute an active trigger.
				 * @returns {String} Message text.
				 */
				getImmediateTriggerEmailToolTipMessage: function(isActive) {
					return (isActive)
						? this.get("Resources.Strings.ImmediateStartDateForActiveEmailTooltip")
						: this.get("Resources.Strings.ImmediateStartDateForDeactivateEmailTooltip");
				},

				/**
				 * Gets the help text for the trigger letter with the launch of the company.
				 * @param {Boolean} isActive Attribute an active trigger.
				 * @returns {String} Message text.
				 */
				getHourlyTriggerEmailToolTipMessage: function(isActive) {
					return (isActive)
						? this.get("Resources.Strings.ImmediateStartDateForActivateEmailFromCampaignTooltip")
						: this.get("Resources.Strings.ImmediateStartDateForDeactivateEmailFromCampaignTooltip");
				},

				/**
				 * Executing bulk email.
				 * @inheritDoc BaseBulkEmailPageV2#runMandrillMassMailing
				 * @overridden
				 */
				runMandrillMassMailing: function() {
					this.runActionAfterSave(function() {
						if (this.get("IsPublicDemoBuild")) {
							MarketingCommonUtilities.ShowConfirmationDialogWithGoButton(
								this.get("Resources.Strings.DemoDataMessage"),
								this.get("TrialUrl"),
								this.get("Resources.Strings.TryTrialButtonCaption"),
								this
							);
							return;
						}
						var maskId = BPMSoft.Mask.show();
						BPMSoft.chain(
							function(next) {
								if (this.isAssignedWithCampaign() && this.isLaunchedCampaign()) {
									next();
								} else {
									BPMSoft.Mask.hide(maskId);
									this.showInformationDialog(this.get("Resources.Strings.CannotStartMailingForNotLaunchedCampaign"));
								}
							},
							function(next) {
								BulkEmailHelper.ValidateBulkEmail.call(this, this.get("Id"), next, function() {
									BPMSoft.Mask.hide(maskId);
								});
							},
							function(next) {
								this.setBulkEmailStatus(MarketingEnums.BulkEmailStatus.ACTIVE, function() {
									next();
								}, this);
							},
							function() {
								BulkEmailHelper.ReloadCard.call(this, this.get("Id"));
								BPMSoft.Mask.hide(maskId);
								this.showLaunchMessage();
							},
							this);
					});
				},

				/**
				 * Gets message about start of trigger email.
				 * @private
				 * @returns {String}  Message about start of trigger email.
				 */
				getLaunchMessage: function() {
					var message;
					var launchOption = this.get("LaunchOption");
					switch (launchOption.value) {
						case MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED:
							message = this.get("Resources.Strings.TriggeredEmailScheduledCaption");
							var datePattern = "H:i d.m.Y";
							var startDate = this.get("StartDate");
							var displayedStartDate = Ext.Date.format(startDate, datePattern);
							message = Ext.String.format(
								this.get("Resources.Strings.TriggeredEmailScheduledCaption"),
								displayedStartDate);
							break;
						default:
							message = this.get("Resources.Strings.TriggeredEmailLaunchedCaption");
							break;
					}
					return message;
				},

				/**
				 * Shows message about the successful inclusion of the trigger message.
				 * @private
				 */
				showLaunchMessage: function() {
					var message = this.getLaunchMessage();
					this.showInformationDialog(message);
				},

				/**
				 * @inheritDoc BaseBulkEmailPageV2#breakMailingAction
				 * @overridden
				 */
				breakMailingAction: function() {
					BPMSoft.chain(
						function(next) {
							if (BPMSoft.Features.getIsEnabled("BulkEmailStop")) {
								let config = {
									confirmationMessage: this.get("Resources.Strings.StopSendingConfirmationMessage")
								}
								this.stopEmailSending(config);
							} else {
								this.setBulkEmailStatus(MarketingEnums.BulkEmailStatus.STOPPED, function() {
									next();
								}, this);
							}
						},
						function() {
							BulkEmailHelper.ReloadCard.call(this, this.get("Id"));
							this.showInformationDialog(this.get("Resources.Strings.TriggeredEmailStoppedCaption"));
						},
						this);
				},

				/**
				 * Set status bulk email.
				 * @protected
				 * @param {Object} status Status bulk email.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope v.
				 */
				setBulkEmailStatus: function(status, callback, scope) {
					var update = Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "BulkEmail"
					});
					var filters = update.filters;
					var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"Id", this.get("Id"));
					filters.add("IdFilter", idFilter);
					update.setParameterValue("Status", status, BPMSoft.DataValueType.GUID);
					update.execute(callback, scope);
				},

				/**
				 * @inheritDoc BaseBulkEmailPageV2#processStatusColumn
				 * @overriden
				 */
				processStatusColumn: function() {
					this.callParent(arguments);
					var status = this.get("Status");
					var isUseUtm = this.get("UseUtm");
					var isActiveEnabled = !BulkEmailHelper.GetIsActiveStatus(status.value);
					var isOilCampaignRelated = this.get("CampaignType") === this.get("OldDesignerTypeId");
					var isTemplateEditable = BulkEmailHelper.IsEmailTemplateEditable(status.value,
						MarketingEnums.BulkEmailCategory.TRIGGERED_EMAIL);
					this.set("IsUtmCheckBoxEnabled", isTemplateEditable);
					this.set("IsUtmEnabled", isUseUtm && isTemplateEditable);
					this.set("IsRunEnabled", isActiveEnabled);
					this.set("IsTemplateEditable", isTemplateEditable);
					this.sandbox.publish("WeekDayCronEditableChanged", {isEditable: isTemplateEditable});
					this.set("IsBlankSlatesAudienceVisible", isTemplateEditable);
					this.set("IsOppAudienceVisible", !isTemplateEditable);
					this.set("IsRunDisplayed", isOilCampaignRelated && isActiveEnabled);
					var stopFeatureEnabled = BPMSoft.Features.getIsEnabled("TriggerEmailThrottlingQueue");
					this.set("IsBreakEnabled", !isActiveEnabled && stopFeatureEnabled);
					this.set("IsAnalysisVisible", !isTemplateEditable);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.processLaunchOptionColumn();
					this.set("SendMailingActionCaption",
						this.get("Resources.Strings.RunMandrillMassMailingActionCaption"));
					this.on("change:LaunchOption", function() {
						this.processLaunchOptionColumn();
					}, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseBulkEmailPageV2#setDefaultEmailValues
				 * @overriden
				 */
				setDefaultEmailValues: function() {
					this.callParent(arguments);
					this.loadLookupDisplayValue("LaunchOption",
						MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED);
					var offsetSheduleTime = 15;
					var roundDateTime = this.getRoundDateTime(new Date(), offsetSheduleTime);
					var nextTriggerDateTime = this.getNextTriggerDateTime() || roundDateTime;
					this.set("StartDate", nextTriggerDateTime);
				},

				/**
				 * Handler of email laucnh option test.
				 * @private
				 */
				processLaunchOptionColumn: function() {
					var launchOption = this.get("LaunchOption");
					if (!launchOption) {
						return;
					}
					var startDate = this.get("StartDate");
					var value;
					if (launchOption &&
						(launchOption.value === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_IMMEDIATE ||
							launchOption.value === MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_HOURLY)) {
						value = false;
						this.set("SendDueDateCaption", this.get("Resources.Strings.ImmediateSendDueDateCaption"));
						if (!Ext.isEmpty(startDate)) {
							this.set("StartDate", null);
						}
					} else {
						value = true;
						this.set("SendDueDateCaption", this.get("Resources.Strings.ScheduledDueDateCaption"));
						this.set("SendStartDateCaption", this.get("Resources.Strings.ScheduledSendStartDateCaption"));
					}
					if (this.get("IsSendScheduled") !== value) {
						this.set("IsSendScheduled", value);
					}
				},

				/**
				 * Saves card.
				 * @overridden
				 */
				save: function() {
					var launchOption = this.get("LaunchOption");
					if (launchOption && launchOption.value ===
							MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED) {
						var nextTriggerDateTime = this.getNextTriggerDateTime();
						if (nextTriggerDateTime) {
							this.set("StartDate", nextTriggerDateTime);
						}
					}
					this.callParent(arguments);
				},

				/**
				 * Checks wether email is planned.
				 * @param {Boolean} value
				 * @returns {Boolean}
				 */
				isSendNotScheduled: function(value) {
					return (value !== true);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "StartDate"
				},
				{
					"operation": "remove",
					"name": "LaunchOption"
				},
				{
					"operation": "merge",
					"name": "SendDueDate",
					"values": {
						"caption": {
							"bindTo": "SendDueDateCaption"
						}
					},
					"parentName": "CommonSettingsGridLayout",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "SendStartDate",
					"values": {
						"caption": {
							"bindTo": "SendStartDateCaption"
						}
					},
					"parentName": "CommonSettingsGridLayout",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "SendProcessDiagramContainer"
				},
				{
					"operation": "insert",
					"name": "RecipientCount",
					"values": {
						"layout": {"colSpan": 11, "rowSpan": 1, "column": 0, "row": 1, "layoutName": "Header"},
						"bindTo": "RecipientCount",
						"enabled": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "remove",
					"name": "BulkEmailInfoContainer"
				}
			], /**SCHEMA_DIFF*/
			rules: {
				"DurationBulkEmail": {
					DurationBulkEmailVisible: {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.VISIBLE,
						logical: BPMSoft.LogicalOperatorType.AND,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "IsSendScheduled"
								},
								comparisonType: BPMSoft.core.enums.ComparisonType.NOT_EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: false
								}
							}
						]
					}
				},
				"SendStartDate": {
					SendStartDateVisible: {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.VISIBLE,
						logical: BPMSoft.LogicalOperatorType.AND,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "IsSendScheduled"
								},
								comparisonType: BPMSoft.core.enums.ComparisonType.NOT_EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: false
								}
							}
						]
					}
				},
				"LaunchOption": {
					StartDateEnabled: {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						logical: BPMSoft.LogicalOperatorType.AND,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "Status"
								},
								comparisonType: BPMSoft.core.enums.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: MarketingEnums.BulkEmailStatus.PLANNED
								}
							}
						]
					}
				}
			}
		};
	});
