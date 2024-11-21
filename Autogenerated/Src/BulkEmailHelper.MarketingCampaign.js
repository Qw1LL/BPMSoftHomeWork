define("BulkEmailHelper", ["BulkEmailHelperResources", "MarketingEnums", "ServiceHelper"],
		function(resources, MarketingEnums, ServiceHelper) {

			/**
			 * ######### ########## ####### #######.
			 * @param {string} bulkEmailId ########## ############# ######## BulkEmail.
			 * @private                       `
			 */
			function reloadSection(bulkEmailId) {
				var gridData = this.get("GridData");
				if (gridData) {
					var record = gridData.get(bulkEmailId);
					if (record) {
						record.loadEntity(bulkEmailId);
					}
				}
			}

			/**
			 * Reloads the card due to current context.
			 * @param {string} bulkEmailId BulkEmail unique identifier.
			 * @param callback Callback function.
			 * @param scope 
			 * @private
			 */
			function reloadCard(bulkEmailId, callback) {
				var isCardVisible = this.get("IsCardVisible");
				if (isCardVisible === true) {
					reloadCardFromSection.call(this, bulkEmailId);
				} else if (typeof isCardVisible === "undefined") {
					reloadCardFromPage.call(this, ["Status", "StartDate"], bulkEmailId, callback);
				}
			}

			/**
			 * Reloads the card in page context.
			 * @param {Array} fields card field to update.
			 * @param {string} bulkEmailId BulkEmail unique identifier.
			 * @param callback Callback function.
			 * @private
			 */
			function reloadCardFromPage(fields, bulkEmailId, callback) {
				if (!this.Ext.isArray(fields) || !bulkEmailId || fields.length === 0) {
					return;
				}
				var fieldsQuantity = fields.length;
				var selectNewValues = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName
				});
				for (var i = 0; i < fieldsQuantity; i++) {
					selectNewValues.addColumn(fields[i]);
				}
				selectNewValues.getEntity(bulkEmailId, function(result) {
					var entity = result.entity;
					if (entity) {
						fields.forEach(function(element) {
							var newValue = entity.get(element);
							this.set(element, newValue);
						}, this);
						this.set("ShowSaveButton", false);
						this.set("ShowDiscardButton", false);
						this.set("ShowCloseButton", true);
						this.updateDetails();
						if(callback) {
							callback.call(this);
						}
					}
				}, this);
				this.updateSendProcessDiagram();
			}

			/**
			 * ######### ######## ####### # ######### #######.
			 * @param {string} bulkEmailId ########## ############# ######## BulkEmail.
			 * @private
			 */
			function reloadCardFromSection(bulkEmailId) {
				this.editRecord(bulkEmailId);
			}

			/**
			 * ######## ###-###### ########### ########.
			 * @param {string} bulkEmailId ########## ############# ######## BulkEmail.
			 * @param {Date} startDate ######## #### ####### ########.
			 * @private
			 */
			function callStartEmailWebService(bulkEmailId, startDate) {
				this.showBodyMask({ caption: "Starting", timeout: 0});
				var webServiceConfig = {
					serviceName: "MailingService",
					methodName: "SendMessage",
					data: {messageId: bulkEmailId}
				};
				var webServiceCallback = function(responseObject) {
					this.hideBodyMask();
					reloadSection.call(this, bulkEmailId);
					reloadCard.call(this, bulkEmailId);
					var result = responseObject.SendMessageResult;
					if (!result || !result.Success) {
						this.BPMSoft.showInformation(
								resources.localizableStrings.MandrillMassMailingFailsMessage);
						return;
					} else if (result.StatusId === MarketingEnums.BulkEmailStatus.STARTING ||
								result.StatusId === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND) {
						this.BPMSoft.showInformation(
								resources.localizableStrings.MandrillMassMailingSuccessMessage);
					} else if (result.StatusId === MarketingEnums.BulkEmailStatus.START_SCHEDULED) {
						var datePattern =  "H:i d.m.Y";
						var displayedStartDate = Ext.Date.format(startDate, datePattern);
						var message = Ext.String.format(
								resources.localizableStrings.MandrillMassMailingScheduledMessage, displayedStartDate);
						this.BPMSoft.showInformation(message);
					}
				};
				this.callService(webServiceConfig, webServiceCallback, this);
			}

			/**
			 * ######### ####### ########.
			 * @param {string} bulkEmailId ########## ############# ######## BulkEmail.
			 * @param {Date} startDate ######## #### ####### ########.
			 * @private
			 */
			function startCurrentBulkEmail(bulkEmailId, startDate) {
				var select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwBulkEmailAudience"
				});
				select.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "AudienceCount");
				select.filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"BulkEmail", bulkEmailId));
				select.rowCount = 1;
				select.getEntityCollection(function(response) {
					if (response.success) {
						var firstElement = response.collection.getByIndex(0);
						var mandrillRecipientCount = firstElement.get("AudienceCount");
						if (mandrillRecipientCount === 0) {
							this.BPMSoft.showInformation(resources.localizableStrings.MandrillInteractionTargetNotFound);
						} else {
							callStartEmailWebService.call(this, bulkEmailId, startDate);
						}
					}
				}, this);
			}

			/**
			 * ############# ####### ########.
			 * @param {string} bulkEmailId ########## ############# ######## BulkEmail.
			 */
			function breakCurrentBulkEmail(bulkEmailId) {
				var webServiceConfig = {
					serviceName: "MailingService",
					methodName: "BreakMailing",
					data: {messageId: bulkEmailId}
				};
				BPMSoft.MaskHelper.showBodyMask();
				var webServiceCallback = function(responseObject) {
					BPMSoft.MaskHelper.hideBodyMask();
					reloadSection.call(this, bulkEmailId);
					reloadCard.call(this, bulkEmailId);
					var result = responseObject.BreakMailingResult;
					if (!result || !result.Success) {
						this.BPMSoft.showInformation(
								resources.localizableStrings.MandrillMassMailingBreakFailsMessage);
						return;
					}
					switch (result.StatusId) {
						case MarketingEnums.BulkEmailStatus.STOPPED :
						case MarketingEnums.BulkEmailStatus.STOPPED_MANUALLY :
						case MarketingEnums.BulkEmailStatus.BREAKING :
							break;
						case MarketingEnums.BulkEmailStatus.COMPLETED :
							this.BPMSoft.showInformation(
									resources.localizableStrings.MandrillMassMailingAlreadyComplitedMessage);
							break;
					}
				};
				this.callService(webServiceConfig, webServiceCallback, this);
			}

			/**
			 * ######### ###### ########. ##### ############# ######## ####### # ####### ####.
			 * @param {Object} email ######, ####### ######## ####### ########, ############# ########,
			 * ######## #### ####### ########, ###### ########
			 * @param {Object} scope ######## ##########.
			 */
			function runMailing(email, scope) {
				var isKeyCorrect = false;
				scope = scope || this;
				scope.showBodyMask({ caption: "Validation", timeout: 0});
				BPMSoft.chain(
						function(next) {
							var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "BulkEmail"
							});
							esq.addColumn("SplitTest");
							esq.getEntity(email.id, function(result) {
								var entity = result.entity;
								if (entity) {
									var splitTest = entity.get("SplitTest");
									if (!splitTest || BPMSoft.isEmptyGUID(splitTest.value)) {
										next();
										return;
									}
								}
								scope.hideBodyMask();
								scope.showInformationDialog(resources.localizableStrings.UsageInSplitTestMessage);
							}, this);
						},
						function(next) {
							ServiceHelper.callService("MailingService", "PingProvider", function(responseObject) {
								isKeyCorrect = responseObject.PingProviderResult;
								next();
							}, null, this);
						},
						function(next) {
							if (isKeyCorrect) {
								next();
							} else {
								scope.hideBodyMask();
								scope.showInformationDialog(resources.localizableStrings.WrongKeyMessage);
							}
						},
						function(next) {
							validateBulkEmail.call(this, email.id, next);
						},
						function() {
							if (email.status === MarketingEnums.BulkEmailStatus.START_SCHEDULED) {
								runScheduledMailing(email, this);
							} else {
								runPlannedMailing(email, this);
							}
						},
						scope);
			}

			function runPlannedMailing(email, scope) {
				var config = {
					style: BPMSoft.MessageBoxStyles.ORANGE
				};
				var confirmationMessage = email.status === MarketingEnums.BulkEmailStatus.PLANNED &&
				!Ext.isEmpty(email.startDate)
					? resources.localizableStrings.ConfirmationScheduleMessage
					: resources.localizableStrings.ConfirmationRunMessage;
				var currentDateTime = new Date();
				scope.hideBodyMask();
				if (Ext.isDate(email.startDate) && (email.startDate < currentDateTime)) {
					scope.showConfirmationDialog(resources.localizableStrings.DateIsExpiredMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								var update = Ext.create("BPMSoft.UpdateQuery", {
									rootSchemaName: "BulkEmail"
								});
								var filters = update.filters;
								var idFilter = update.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Id", email.id);
								filters.add("IdFilter", idFilter);
								update.setParameterValue("StartDate",
									null, BPMSoft.DataValueType.DATE_TIME);
								update.execute(function(response) {
									if (response && response.success) {
										startCurrentBulkEmail.call(scope, email.id, null);
									}
								}, this);
							}
						}, ["yes", "no"], config);
				} else {
					scope.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								startCurrentBulkEmail.call(scope, email.id, email.startDate);
							}
						}, ["yes", "no"], config);
				}
			}
			
			function runScheduledMailing(email, scope) {
				var config = {
					style: BPMSoft.MessageBoxStyles.ORANGE
				};
				var datePattern =  "H:i d.m.Y";
				var displayedStartDate = Ext.Date.format(email.startDate, datePattern);
				var message = Ext.String.format(resources.localizableStrings.IsScheduledMessage,
					displayedStartDate);
				scope.hideBodyMask();
				scope.showConfirmationDialog(message,
					function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							var update = Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: "BulkEmail"
							});
							var filters = update.filters;
							var idFilter = update.createColumnFilterWithParameter(
								BPMSoft.ComparisonType.EQUAL, "Id", email.id);
							filters.add("IdFilter", idFilter);
							update.setParameterValue("Status",
								MarketingEnums.BulkEmailStatus.PLANNED,
								BPMSoft.DataValueType.GUID);
							update.setParameterValue("StartDate",
								null, BPMSoft.DataValueType.DATE_TIME);
							update.setParameterValue("LaunchOption",
								MarketingEnums.BulkEmailLaunchOption.MASS_MAILING_MANUALY,
								BPMSoft.DataValueType.GUID);
							update.execute(function(response) {
								if (response && response.success) {
									startCurrentBulkEmail.call(scope, email.id, null);
								}
							}, this);
						}
					}, ["yes", "cancel"], config);
			}

			function validateBulkEmail(bulkEmailId, onSuccess, onError, scope) {
				scope = scope || this;
				var serviceConfig = {
					serviceName: "MailingService",
					methodName: "ValidateMessage",
					data: {messageId: bulkEmailId}
				};
				this.callService(serviceConfig, function(response) {
					var validationResult = response.ValidateMessageResult || {};
					if (validationResult.success) {
						this.Ext.callback(onSuccess, scope);
					} else {
						this.Ext.callback(onError, scope);
						scope.hideBodyMask();
						scope.showInformationDialog(validationResult.errorInfo.message);
					}
				}, null, this);
			}

			/**
			 * ######### ######### ########.
			 * @param {string} bulkEmailId Unique identifier of BulkEmail instance.
			 * @param {Object} scope Execution context.
			 * @param {string} confirmationMessage Message to show before action is done.
			 */
			function breakMailing(bulkEmailId, scope, confirmationMessage) {
				const buttons = BPMSoft.MessageBoxButtons;
				let message = confirmationMessage ?? resources.localizableStrings.ConfirmationBreakMessage;
				scope.showConfirmationDialog(message,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								breakCurrentBulkEmail.call(scope, bulkEmailId);
							}
						}, [buttons.YES, buttons.NO], {style: BPMSoft.MessageBoxStyles.ORANGE});
			}

			/**
			 * ######### ###### TestBulkEmailModule # #######.
			 * @param {string} bulkEmailId ############# ########.
			 * @param {string} bulkEmailName ######## ########.
			 * @param {Object} scope ######## ##########.
			 */
			function openSendTestBulkEmail(bulkEmailId, bulkEmailName, scope) {
				var bulkEmail = {
					Id: bulkEmailId,
					Name: bulkEmailName,
					value: bulkEmailId,
					displayValue: bulkEmailName
				};
				var testBulkEmailModuleSandboxId = scope.sandbox.id + "_TestBulkEmailModule";
				scope.sandbox.subscribe("GetBulkEmail", function() {
					return bulkEmail;
				}, [testBulkEmailModuleSandboxId]);
				scope.sandbox.loadModule("TestBulkEmailModule", {
					id: testBulkEmailModuleSandboxId,
					keepAlive: true
				});
			}

			/**
			 * Indicates whether user can run bulk email.
			 * @param {Object} status Bulk email status.
			 * @return {Boolean} Returns true, if bulk email could be run, otherwise false.
			 */
			function getIsRunnable(status) {
				return (status === MarketingEnums.BulkEmailStatus.PLANNED ||
					status === MarketingEnums.BulkEmailStatus.START_SCHEDULED ||
					status === MarketingEnums.BulkEmailStatus.STOPPED);
			}

			/**
			 * Indicates whether user can edit bulk email template.
			 * @param {Object} status Email state.
			 * @return {Boolean} Returns true, if bulk email template could be edited, otherwise false.
			 */
			function isBulkEmailTemplateEditable(status) {
				return (status === MarketingEnums.BulkEmailStatus.DRAFT ||
					status === MarketingEnums.BulkEmailStatus.PLANNED ||
					status === MarketingEnums.BulkEmailStatus.START_SCHEDULED ||
					status === MarketingEnums.BulkEmailStatus.STOPPED);
			}

			/**
			 * Indicates whether user can edit trigger email template.
			 * @param {Object} status Email state.
			 * @return {Boolean} Returns true, if trigger email template could be edited, otherwise false.
			 */
			function isTriggerEmailTemplateEditable(status) {
				return status === MarketingEnums.BulkEmailStatus.DRAFT ||
					status === MarketingEnums.BulkEmailStatus.PLANNED ;
			}

			/**
			 * Indicates whether user can edit email template.
			 * @param {Object} status Email state.
			 * @param {Object} emailCategory Email category.
			 * @return {Boolean} Returns true, if trigger email template could be edited, otherwise false.
			 */
			function isEmailTemplateEditable(status, emailCategory) {
				if(emailCategory === MarketingEnums.BulkEmailCategory.MASS_MAILING) {
					return isBulkEmailTemplateEditable(status);
				} else if (emailCategory === MarketingEnums.BulkEmailCategory.TRIGGERED_EMAIL) {
					return isTriggerEmailTemplateEditable(status);
				} else {
					return false;
				}
			}

			/**
			 * Checks whether email is triggered and planned.
			 * @param {Object} category Category identifier.
			 * @param {Object} status Status identifier.
			 * @returns {boolean} True if email is planned and triggered, otherwise false.
			 */
			function getIsPlannedTriggeredEmail(category, status) {
				return (status === MarketingEnums.BulkEmailStatus.PLANNED &&
					category === MarketingEnums.BulkEmailCategory.TRIGGERED_EMAIL);
			}

			/**
			 * ########## ####### ########### ########## ########.
			 * @param {Object} status ####### ########.
			 * @return {Boolean} ########## true, #### ######## ##### #### ###########, ##### false.
			 */
			function getIsBreakable(status) {
				if(BPMSoft.Features.getIsEnabled("BulkEmailStop")) {
					return (status === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND ||
						status === MarketingEnums.BulkEmailStatus.START_SCHEDULED ||
						status === MarketingEnums.BulkEmailStatus.STARTING ||
						status === MarketingEnums.BulkEmailStatus.STARTED ||
						status === MarketingEnums.BulkEmailStatus.QUEUED	
					);
				} else {
					return (status === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND ||
						status === MarketingEnums.BulkEmailStatus.START_SCHEDULED);
				}
			}

			/**
			 * ########## ####### ########## ######### ########.
			 * @param {Object} status ######### ########.
			 * @returns {Boolean} ########## true, #### ######## #######, ##### false.
			 */
			function getIsActiveStatus(status) {
				return (status === MarketingEnums.BulkEmailStatus.STARTING ||
						status === MarketingEnums.BulkEmailStatus.STARTED ||
						status === MarketingEnums.BulkEmailStatus.START_SCHEDULED ||
						status === MarketingEnums.BulkEmailStatus.ACTIVE ||
						status === MarketingEnums.BulkEmailStatus.ERROR_SENDING ||
						status === MarketingEnums.BulkEmailStatus.WAITING_BEFORE_SEND);
			}

			/**
			 * ########## ####### ########### ############## ######### ########.
			 * @param {Object} config ####### ######## # #########.
			 * @return {Boolean} ########## true, #### ######### ##### #### ########, ##### false.
			 */
			function getIsAudienceEditable(config) {
				var result =  !config.isConnectWithCampaign
					&& (config.status === MarketingEnums.BulkEmailStatus.PLANNED
					|| config.status === MarketingEnums.BulkEmailStatus.START_SCHEDULED
					|| config.status === MarketingEnums.BulkEmailStatus.DRAFT);
				if (BPMSoft.Features.getIsEnabled("BulkEmailPause")){
					result = result || config.status === MarketingEnums.BulkEmailStatus.STOPPED;
				}
				return result;
			}

			/**
			 * ######### ########## ########### # ####.
			 * @param {Number} daysCount ########## ####.
			 * @returns {Number} ########## ###########.
			 */
			function daysToMilliseconds(daysCount) {
				//milliseconds in minutes * minutes in hour * hours in day * daysCount
				return minutesToMilliseconds(1) * 60 * 24 * daysCount;
			}

			/**
			 * ######### ########## ########### # #######.
			 * @param {Number} minutesCount ########## #####.
			 * @returns {Number} ########## ###########.
			 */
			function minutesToMilliseconds(minutesCount) {
				//miliseconds in second * seconds in minute
				return 1000 * 60 * minutesCount;
			}

			/**
			 * ######### ######## ###### ## ############# ########## ##########.
			 * @param {BPMSoft.BaseViewModel} data ###### ### #########.
			 * @param {Function} callback ####### ######### ######.
			 */
			function checkDataForUpdateStatistic(data, callback) {
				var status = data.get("Status");
				var statusValue = status.value;
				if (statusValue !== MarketingEnums.BulkEmailStatus.STOPPED &&
						statusValue !== MarketingEnums.BulkEmailStatus.COMPLETED &&
						statusValue !== MarketingEnums.BulkEmailStatus.ERROR_SENDING &&
						statusValue !== MarketingEnums.BulkEmailStatus.STARTED &&
						statusValue !== MarketingEnums.BulkEmailStatus.BREAKING) {
					return;
				}
				var sendStartDate = data.get("SendStartDate");
				if (!sendStartDate) {
					return;
				}
				BPMSoft.SysSettings.querySysSettings(
						["MandrillStatisticUpdatePeriodDays", "MinMandrillStatisticUpdatePeriodMinutes"],
						function(values) {
							var periodDays = values.MandrillStatisticUpdatePeriodDays;
							if (Ext.isEmpty(periodDays)) {
								return;
							}
							var dateNow = new Date();
							var range = dateNow - sendStartDate;
							if (range > daysToMilliseconds(periodDays)) {
								return;
							}
							var periodMinutes = values.MinMandrillStatisticUpdatePeriodMinutes;
							var statisticDate = data.get("StatisticDate");
							if (statisticDate) {
								var statisticUpdateRange = dateNow - statisticDate;
								if (statisticUpdateRange < minutesToMilliseconds(periodMinutes)) {
									return;
								}
							}
							callback.call(this, data);
						}, this);
			}

			/**
			 * ######### ###### # ####### ########## ###### ########## ########.
			 * @param {BPMSoft.BaseViewModel} data ###### ### ######## ## ######.
			 */
			function callUpdateStatisticService(data) {
				var recordId = data.get("Id");
				ServiceHelper.callService("MandrillService", "UpdateStatistic", Ext.emptyFn, {id: recordId}, this);
			}

			/**
			 * ######### ######### ###### ## ############# ########## ##########/######## ###### ########## ##########.
			 * @param {BPMSoft.BaseViewModel} data ###### ### #########/######## ## ######.
			 */
			function updateStatistic(data) {
				checkDataForUpdateStatistic(data, callUpdateStatisticService);
			}

			/**
			 * ######### ######## ####### ######.
			 * @param {BPMSoft.BaseViewModel} bulkEmail ###### ############# ####### BulkEmail.
			 * @return {Boolean} ######### ########.
			 */
			function validateTemplateBody(bulkEmail) {
				var templateBody = bulkEmail.get("TemplateBody");
				var isTemplateBodyEmpty = Ext.isEmpty(templateBody);
				return !isTemplateBodyEmpty;
			}

			return {
				RunMailing: runMailing,
				BreakMailing: breakMailing,
				PauseMailing: breakCurrentBulkEmail,
				OpenSendTestBulkEmail: openSendTestBulkEmail,
				GetIsRunnable: getIsRunnable,
				GetIsPlannedTriggeredEmail: getIsPlannedTriggeredEmail,
				GetIsBreakable: getIsBreakable,
				GetIsActiveStatus: getIsActiveStatus,
				GetIsAudienceEditable: getIsAudienceEditable,
				UpdateStatistic: updateStatistic,
				ReloadCard: reloadCard,
				ValidateTemplateBody: validateTemplateBody,
				ValidateBulkEmail: validateBulkEmail,
				IsEmailTemplateEditable: isEmailTemplateEditable
			};
		});
