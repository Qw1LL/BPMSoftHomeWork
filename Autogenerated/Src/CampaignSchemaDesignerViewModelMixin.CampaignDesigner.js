define ("CampaignSchemaDesignerViewModelMixin", ["CampaignSchemaDesignerViewModelMixinResources",
		"CampaignEnums", "MarketingEnums", "ProfileUtilities"], function(resources, CampaignEnums, MarketingEnums) {
	Ext.define("BPMSoft.configuration.mixins.CampaignSchemaDesignerViewModelMixin", {
		alternateClassName: "BPMSoft.CampaignSchemaDesignerViewModelMixin",

		/**
		 * Campaign time zone migration key for SysProfileData.
		 * @type {String}
		 */
		timeZoneMigrationSysProfileKey: "CampaignTimeZoneMigrationTo7120",

		/**
		 * @private
		 */
		_getSchemaEntity: function(schema, callback, scope) {
			var columns = ["Id", "Name"];
			BPMSoft.EntitySchemaManager.getItemByUId(schema.entitySchemaUId,
				function(entitySchemaManagerItem) {
					this.mixins.campaignElementMixin.loadLinkedEntity(schema.entityId,
						entitySchemaManagerItem.name, columns, callback, scope);
				},
			this);
		},

		/**
		 * Gets campaign entity by id.
		 * @private
		 * @param {String} entityId Unique identifier of campaign entity.
		 * @param {Function} callback Callback function to call when response will be received.
		 * @param {Object} scope Context.
		 */
		_getCampaignEntity: function(entityId, callback, scope) {
			var columns = ["Id", "CampaignStatus"];
			this.mixins.campaignElementMixin.loadLinkedEntity(entityId, "Campaign", columns, function(entity) {
				callback.call(scope, entity);
			}, this);
		},

		/**
		 * Returns result message of campaign flow schema validation.
		 * @private
		 * @return {String} Validation message.
		 */
		_getFlowSchemaValidationMessage: function() {
			var message = "";
			BPMSoft.each(this.validationInfo.attributes, function(attribute) {
				if (!attribute.isValid && attribute.isFlowSchemaValidationMessage) {
					message = this._addNewMessageLine(message, attribute.invalidMessage);
				}
			}, this);
			return message;
		},

		/**
		 * Returns result message of campaign validation for items with specific validation type.
		 * @private
		 * @param {String} validationType Validation type - error/warning/info
		 * (BPMSoft.ValidationType).
		 * @return {String} Validation message.
		 */
		_getExtendedValidationMessage: function(validationType) {
			var message = "";
			BPMSoft.each(this.validationInfo.customValidationResults, function(attribute) {
				if (!attribute.isValid && attribute.isCustomMessage
						&& attribute.validationType === validationType) {
					message = this._addNewMessageLine(message, attribute.invalidMessage);
				}
			}, this);
			return message;
		},

		/**
		 * Appends new message to base message text with line breaks.
		 * @private
		 * @param {String} message Base message.
		 * @param {String} line New message to append.
		 * @return {String} Extended with new line message.
		 */
		_addNewMessageLine: function(message, line) {
			if (line) {
				message += line + "\r\n\r\n";
			}
			return message;
		},

		/**
		 * Shows info message box for first user intry.
		 * In otherwise shows nothing.
		 * @private
		 */
		_showTimeZoneMigrationInfoMessage: function() {
			var config = {
				schemaName: "CampaignSchemaDesignerViewModel",
				profileKey: this.timeZoneMigrationSysProfileKey
			};
			BPMSoft.ProfileUtilities.getProfile(config, function(profile) {
				if (!BPMSoft.isEmptyObject(profile)) {
					this._showInfoMigrationMessageBox(resources.localizableStrings.TimeZoneMigrationInfoMessage,
						this);
				}
			}, this);
		},

		/**
		 * Shows message box with migration information in campaign designer.
		 * @private
		 * @param {String} message Message which will shown in migration message box.
		 */
		_showInfoMigrationMessageBox: function(message) {
			var currentButtons = [BPMSoft.MessageBoxButtons.OK];
			this._showMessageBox(resources.localizableStrings.TimeZoneMigrationInfoMessageBoxCaption,
				message, currentButtons, this._deleteTimeZoneMigrationUserProfile, this);
		},

		/**
		 * Callback for "Ok" button in migration message box.
		 * Deletes record for this user in SysProfileData by key timeZoneMigrationSysProfileKey.
		 * @private
		 */
		_deleteTimeZoneMigrationUserProfile: function() {
			var query = Ext.create("BPMSoft.DeleteQuery", {
				rootSchemaName	: "SysProfileData"
			});
			var filters = BPMSoft.createFilterGroup();
			filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
			filters.addItem(BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Contact", BPMSoft.SysValue.CURRENT_USER_CONTACT.value)
			);
			filters.addItem(BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Key", this.timeZoneMigrationSysProfileKey)
			);
			query.filters.add("currentUserSysProfileFilter", filters);
			query.execute();
		},

		/**
		 * Displays default messageBox with specific validation result content.
		 * @private
		 * @param {String} caption Caption of MeaasgeBox.
		 * @param {String} validationMessage Message that displays inside message block.
		 * @param {Array} currentButtons Collection of MessageBox buttons to display.
		 * @param {Function} callback Callback function to call when messageBox will be closed.
		 * @param {Object} scope Context.
		 */
		_showMessageBox: function(caption, validationMessage, currentButtons, callback, scope) {
			BPMSoft.ProcessSchemaDesignerUtilities.showProcessMessageBox({
				caption: caption,
				message: validationMessage,
				buttons: currentButtons,
				defaultButton: 0,
				handler: function(returnCode) {
					var doSave = returnCode === "SaveProcess";
					callback.call(scope, doSave);
				},
				scope: scope
			});
		},

		/**
		 * Returns caption of MessageBox, which displays main information about validation error.
		 * @private
		 * @param {Object} baseResources Process resource messages object.
		 * @param {BPMSoft.CampaignSchema} schema Campaign schema of current viewmodel.
		 * @return {String} Caption text.
		 */
		_getMessageBoxCaption: function(baseResources, schema) {
			if (this._getSchemaElementsValidationResult()
					&& !this._getCampaignFlowSchemaValidationResult()) {
				return resources.localizableStrings.CampaignFlowSchemaIsNotValidCaption;
			}
			var typeCaption = schema.typeCaption.toLowerCase();
			return Ext.String.format(baseResources.SchemaValidationMessageCaption, typeCaption);
		},

		/**
		 * Returns result message of campaign flow schema validation.
		 * @private
		 * @return {String} Validation message.
		 */
		_getCampaignFlowSchemaValidationResult: function() {
			var result = true;
			BPMSoft.each(this.validationInfo.attributes, function(attribute) {
				result = attribute.isValid || !attribute.isFlowSchemaValidationMessage;
				return result;
			}, this);
			return result;
		},

		/**
		 * Returns caption of campaign schema or campaign schema element by name.
		 * @private
		 * @param {String} name Element's name.
		 * @return {String} Element's caption.
		 */
		_getElementCaptionByName: function(name) {
			var element = this.$Schema.flowElements.collection.getByKey(name);
			if (element) {
				return element.caption.toString() || element.name;
			}
			return this.$Schema.caption.toString() || name;
		},

		/**
		 * Removes line break at the end of validation message.
		 * @private
		 * @param {String} validationMessage Validation message to process.
		 * @returns {String} Correct validation message.
		 */
		_clearLineBreak: function(validationMessage) {
			var regexp = /(\r\n)+$/;
			var matchResult = validationMessage.match(regexp);
			if (matchResult) {
				return validationMessage.substring(0, matchResult.index);
			}
			return validationMessage;
		},

		/**
		 * Returns schema validation result.
		 * @private
		 * @param {String} BPMSoft.ValidationType validationType (error, warning, info etc).
		 * @return {Boolean} Validation result.
		 */
		_getSchemaElementsValidationResult: function(validationType) {
			var schema = this.get("Schema");
			var validationResults = schema.getValidationResults(validationType);
			return validationResults.length === 0;
		},

		/**
		 * Creates validation result message and extends validation info of current viewModel.
		 * @private
		 * @param {BPMSoft.Collection} validateResult Current campaign flow schema validation result.
		 */
		_createValidationMessage: function(validateResult) {
			validateResult.eachKey(function(rule, item) {
				var message = "";
				var isValid = item.elements.length === 0;
				if (!isValid) {
					message = item.message;
					item.elements.forEach(function(el) {
						message += "\r\n - " + el;
					});
				}
				this.validationInfo.set(rule, {
					isValid: isValid,
					isCustomMessage: true,
					isFlowSchemaValidationMessage: true,
					invalidMessage: message
				});
			}, this);
		},

		/**
		 * Adds extended messages to items' custom validation result.
		 * @private
		 * @param {Object} itemValidationInfo Validation info of campaign schema item.
		 * @return {Boolean} Validation result.
		 */
		_validateItem: function(itemValidationInfo) {
			var result = true;
			BPMSoft.each(itemValidationInfo.validationResults, function(el) {
				if (!el.isValid) {
					this.validationInfo.customValidationResults.push({
						validationType: el.validationType,
						propertyName: el.propertyName,
						invalidMessage: el.message,
						isValid: el.isValid,
						isCustomMessage: el.isCustomMessage
					});
					result = false;
				}
			}, this);
			return result;
		},

		/**
		 * Grouped validation result of each flow element by rules.
		 * @private
		 * @param {BPMSoft.Collection} result Campaign flow schema validation result.
		 * @return {BPMSoft.Collection} Grouped validation result.
		 */
		_groupValidationResultByRules: function(result) {
			var groupedResult = Ext.create("BPMSoft.Collection");
			result.eachKey(function(elementName, rules) {
				var elementCaption = this._getElementCaptionByName(elementName);
				rules.eachKey(function(code, message) {
					var existingRule = groupedResult.collection.getByKey(code);
					if (!existingRule) {
						groupedResult.add(code, {
							message: message,
							elements: [elementCaption]
						});
					} else {
						groupedResult.collection.getByKey(code).elements.push(elementCaption);
					}
				});
			}, this);
			return groupedResult;
		},

				/**
		 * Returns text of message to be displayed in messagebox error description section.
		 * @param {String} message Validation message.
		 * @param {Object} validationInfo Campaign validation result.
		 * @returns {String} Validation message.
		 */
		getCampaignValidationMessage: function(message, validationInfo) {
			var warningTitle = resources.localizableStrings.CampaignWarningMessageCaption;
			var errorTitle = resources.localizableStrings.CampaignErrorMessageCaption;
			var hasErrors = validationInfo.errorInfo && !Ext.isEmpty(validationInfo.errorInfo.message);
			var hasWarnings = validationInfo.warningInfo && !Ext.isEmpty(validationInfo.warningInfo.message);
			if (!Ext.isEmpty(message)) {
				message += "\r\n\r\n";
			}
			if (hasErrors) {
				message += !Ext.isEmpty(message) || hasWarnings ? errorTitle + "\r\n" : "";
				message += validationInfo.errorInfo.message + "\r\n\r\n";
			}
			if (hasWarnings) {
				message += !Ext.isEmpty(message) || hasErrors ? warningTitle + "\r\n" : "";
				message += validationInfo.warningInfo.message;
			}
			return this._clearLineBreak(message);
		},

		/**
		 * Returns list of buttons for validation message box.
		 * @param {Object} baseResources Process resource messages object.
		 * @param {BPMSoft.CampaignSchema} schema Campaign schema of current viewmodel.
		 * @param {String} status Current campaign status.
		 * @param {Boolean} isValid True when campaign schema is valid.
		 * @param {Boolean} hasErrors True when campaign validation result has errors.
		 * @returns {Array} Validation box buttons.
		 */
		getValidationMessageButtons: function(baseResources, schema, status, isValid, hasErrors) {
			var buttons = [BPMSoft.MessageBoxButtons.CANCEL];
			if (status === MarketingEnums.CampaignStatus.PLANNED
					|| status === MarketingEnums.CampaignStatus.STOPPED
					|| (isValid && !hasErrors)) {
				var buttonSaveProcess = this.getSaveButton(baseResources, schema);
				buttons.unshift(buttonSaveProcess);
			}
			return buttons;
		},

		/**
		* Returns save button object.
		* @param {Object} baseResources Resources of parent process view model.
		* @param {BPMSoft.CampaignSchema} schema Campaign schema of current viewmodel.
		* @returns {Object} Save button object.
		*/
		getSaveButton: function(baseResources, schema) {
			var saveButtonCaption = Ext.String.format(baseResources.SaveInvalidProcessButtonCaption,
				schema.typeCaption);
			return {
				className: "BPMSoft.Button",
				returnCode: "SaveProcess",
				markerValue: saveButtonCaption,
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				caption: saveButtonCaption
			};
		},

		/**
		 * Validates campaign flow schema to be correct.
		 * @return {Boolean} Validation result.
		 */
		validateCampaignFlowSchema: function() {
			this.clearFlowSchemaValidationInfo();
			var schema = this.get("Schema");
			var result = this.flowSchemaValidator.validate(schema);
			var validationResult = this._groupValidationResultByRules(result);
			this._createValidationMessage(validationResult);
			return validationResult.isEmpty();
		},

		/**
		 * Validates campaign schema including custom validation.
		 * @return {Boolean} Validation result.
		 */
		extendedValidate: function() {
			var result = true;
			var schemaValidationInfo = this.$Schema.validationInfo;
			BPMSoft.each(schemaValidationInfo.itemsValidationInfo, function(el) {
				result = this._validateItem(el) && result;
			}, this);
			return result;
		},

		/**
		 * Clears all previous campaign flow schema validation results for default rules.
		 */
		clearFlowSchemaValidationInfo: function() {
			BPMSoft.each(CampaignEnums.CampaignFlowSchemaValidationRules, function(rule) {
				this.validationInfo.set(rule, {
					isValid: true,
					isCustomMessage: true,
					isFlowSchemaValidationMessage: true,
					invalidMessage: ""
				});
			}, this);
		},

		/**
		 * Extended handler for schema loaded event.
		 * @param {BPMSoft.CampaignSchema} schema Instance of campaign schema.
		 */
		onSchemaLoaded: function(schema) {
			var args = arguments;
			var entitySchemaUId = this.get("EntitySchemaUId");
			schema.entitySchemaUId = entitySchemaUId || schema.entitySchemaUId;
			var entityId = this.get("EntityId");
			schema.entityId = entityId || schema.entityId;
			this._getSchemaEntity(schema, function(entity) {
				if (entity) {
					schema.caption.setValue(entity.get("Name"));
					this._showTimeZoneMigrationInfoMessage();
				}
				this.superclass.onSchemaLoaded.apply(this, args);
			}, this);
		},

		/**
		 * Shows schema validation message box.
		 * @param {String} validationMessage Base validation message.
		 * @param {Object} validationInfo Validation result.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Context.
		*/
		showValidationMessageBox: function(validationMessage, validationInfo, callback, scope) {
			var self = this;
			var schema = this.get("Schema");
			var baseResources = BPMSoft.Resources.ProcessSchemaDesigner.Messages;
			var caption = this._getMessageBoxCaption(baseResources, schema);
			var message = this.getCampaignValidationMessage(validationMessage, validationInfo);
			this._getCampaignEntity(schema.entityId, function(entity) {
				if (entity) {
					var status = entity.get("CampaignStatus").value;
					var isValid = Ext.isEmpty(validationMessage);
					var hasErrors = validationInfo.errorInfo && !Ext.isEmpty(validationInfo.errorInfo.message);
					var buttons = self.getValidationMessageButtons(baseResources, schema, status, isValid, hasErrors);
					self._showMessageBox(caption, message, buttons, function(doSave) {
						if (doSave) {
							self.sandbox.publish("SetDefaultValuesApproved");
						}
						callback.call(scope, doSave);
					}, scope);
				}
			}, this);
		},

		/**
		 * Returns campaign schema validation message.
		 * @returns {String} Schema validation message.
		 */
		getSchemaValidationMessage: function() {
			var validationMessage = "";
			if (!this._getSchemaElementsValidationResult(BPMSoft.ValidationType.ERROR)) {
				var baseMessage = this.getProcessSchemaValidationMessage.apply(this, arguments);
				validationMessage = this._addNewMessageLine(validationMessage, baseMessage);
			}
			validationMessage += this._getExtendedValidationMessage(BPMSoft.ValidationType.ERROR);
			validationMessage += this._getFlowSchemaValidationMessage();
			validationMessage += this._getExtendedValidationMessage(BPMSoft.ValidationType.WARNING);
			return this._clearLineBreak(validationMessage);
		},

		/**
		 * Returns text of campaign schema validation message.
		 * @returns {String} Validation message.
		 */
		validateCampaignSchema: function() {
			var schema = this.get("Schema");
			var validationResults = schema.getValidationResults();
			BPMSoft.each(validationResults, function(validationInfo) {
				var element = schema.findItemByUId(validationInfo.uId);
				if (element) {
					this.fireEvent("itemIsValidChanged", element);
				}
			}, this);
			return this.getSchemaValidationMessage(validationResults);
		},

		/**
		 * Makes validation request for designed campaign schema.
		 * @param {Function} callback Callback function to call when response will be received.
		 * @param {Object} scope Context.
		 */
		validateCampaign: function(callback, scope) {
			var item = this.get("SchemaManagerItem");
			item.validate(function(response) {
				callback.call(scope, response);
			}, this);
		},

		/**
		 * Validates current campaign schema designer view model.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Context.
		 */
		validateViewModel: function(callback, scope) {
			this.validateSubProcessSchema(function() {
				var isValid = this.validate();
				var validationMessage = this.getValidationMessage();
				if (Ext.isEmpty(validationMessage)) {
					validationMessage = this.validateCampaignSchema() || "";
					this.validateCampaign(function(response) {
						if (isValid && response.isValid) {
							callback.call(scope, isValid, true);
						} else {
							this.showValidationMessageBox(validationMessage, response, function(doSave) {
								callback.call(scope, isValid, doSave);
							}, scope);
						}
					}, this);
				} else {
					this.showInformationDialog(validationMessage, function() {
						callback.call(scope, isValid, false);
					});
				}
			}, this);
		},

		/**
		 * Validates campaign schema.
		 * @param {Boolean} baseResult Result of base validation.
		 * @returns {Boolean} Validation result.
		 */
		validate: function(baseResult) {
			this.validationInfo.customValidationResults = [];
			var flowSchemaValidationResult = this.validateCampaignFlowSchema();
			var extendedValidationResult = this.extendedValidate();
			return baseResult && flowSchemaValidationResult && extendedValidationResult;
		},

		/**
		 * Returns callback function after get schema instance action.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Context.
		 * @returns {Function} Callback function.
		 */
		getSchemaInstanceCallbackFn: function(callback, scope) {
			return function(schema) {
				var args = arguments;
				schema.setDefaultValues();
				Ext.callback(callback, scope, args);
			};
		},

		/**
		 * Handler for after schema saved event.
		 */
		onAfterSchemaSaved: function() {
			this.$Schema.setDefaultValues();
			BPMSoft.each(this.$Schema.flowElements, function(el) {
				el.onAfterSave();
			});
		},

		/**
		 * Registers messages for sandbox.
		 * @param {Object} sandbox Sandbox instance.
		 */
		registerSandboxMessages: function(sandbox) {
			sandbox.registerMessages({
				"SetDefaultValuesApproved": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			});
		}
	});
});
