define("VwMandrillRecipientPageV2",
	["MarketingEnums", "BusinessRuleModule", "ConfigurationEnums", "ext-base"],
	function(MarketingEnums, BusinessRuleModule, ConfigurationEnums, Ext) {
		return {
			entitySchemaName: "VwMandrillRecipient",
			attributes: {
				"Contact": {
					dependencies: [
						{
							columns: ["Contact"],
							methodName: "contactChanged"
						}
					],
					lookupListConfig: {
						columns: ["Email", "DoNotUseEmail"]
					}
				},
				"BulkEmail": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						columns: ["Status", "Type"]
					}
				},
				"IsBulkEmailStatusValid": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				"IsContactUnsubscribed": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				"IsContactExist": {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * ######## email ### ##### ########.
				 * @private
				 */
				contactChanged: function() {
					this.setEmailAddress(null, null);
					var contact = this.get("Contact");
					if (contact) {
						if (contact.DoNotUseEmail === false) {
							this.setContactEmail(contact, this.setEmailAddress, this);
						} else {
							this.setEmailAddress(contact.Email, true);
						}
					}
				},

				/**
				 * ######### email ##### ######## ## ############.
				 * @private
				 * @param {Object} contact #######.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
				 */
				setContactEmail: function(contact, callback, scope) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ContactCommunication"
					});
					esq.addColumn("NonActual");
					esq.filters.add("filterContact", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Contact", contact.Id));
					esq.filters.add("filterNumber", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Number", contact.Email));
					esq.getEntityCollection(function(result) {
						if (result.success) {
							var resultCollection = result.collection;
							if (!resultCollection.isEmpty()) {
								var isNonActual = resultCollection.getByIndex(0).get("NonActual");
								callback.call(scope, contact.Email, isNonActual);
							}
						}
					}, this);
				},

				/**
				 * ############# email, #### ## ##########, # ######### ###### ####### #########.
				 * @private
				 * @param {String} email Email #####.
				 * @param {Boolean} isNonActual #######, ########## email ### ###.
				 */
				setEmailAddress: function(email, isNonActual) {
					if (email && isNonActual) {
						var messageText = Ext.String.format(this.get("Resources.Strings.EmailNonActual"), email);
						this.showInformationDialog(messageText, null, null);
					}
					isNonActual = Ext.isEmpty(isNonActual) ? true : isNonActual;
					this.set("EmailAddress", (isNonActual ? null : email));
				},

				/**
				 * ######### ## ####### ########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				validateBulkEmailStatus: function(next) {
					var status = this.get("BulkEmail").Status;
					var result = (!this.Ext.isEmpty(status) &&
							(status.value === MarketingEnums.BulkEmailStatus.PLANNED ||
							status.value === MarketingEnums.BulkEmailStatus.START_SCHEDULED));
					this.set("IsBulkEmailStatusValid", result);
					if (result) {
						next();
					} else {
						this.showInformationDialog(this.get("Resources.Strings.WarningChangeList"));
					}
				},

				/**
				 * ######## #######, ###########, ### ####### ####### ## ####### #### ########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				setIsContactUnsubscribed: function(next) {
					var contact = this.get("Contact");
					var bulkEmailType = this.get("BulkEmail").Type;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "BulkEmailSubscription"});
					esq.addColumn("Id");
					esq.filters.add("filterContact", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Contact",
						contact.value));
					esq.filters.add("filterBulkEmailType", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "BulkEmailType",
						bulkEmailType.value));
					esq.filters.add("filterSubscriptionStatus", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "BulkEmailSubsStatus",
						MarketingEnums.BulkEmailSubsStatus.UNSUBSCRIBED));
					esq.getEntityCollection(function(result) {
						this.set("IsContactUnsubscribed", result.success && !result.collection.isEmpty());
						next();
					}, this);
				},

				/**
				 * ####### #########, #### ########### ####### ####### ## ####### #### ########
				 * # ############# #########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				validateIsContactUnsubscribed: function(next) {
					if (!this.get("IsContactUnsubscribed")) {
						next();
						return;
					}
					var bulkEmailType = this.get("BulkEmail").Type;
					var message = this.get("Resources.Strings.ContactUnsubscribeMessage");
					var contactUnsubscribedMessage = Ext.String.format(message, bulkEmailType.displayValue);
					this.showInformationDialog(contactUnsubscribedMessage);
				},

				/**
				 * ######### ##### ###### # ########## email ####### # ######### # ####### #########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				setIsContactExist: function(next) {
					var contact = this.get("Contact");
					var emailAddress = this.get("EmailAddress");
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "VwMandrillRecipient"
					});
					esq.rowCount = 1;
					esq.addColumn("Contact");
					esq.filters.add("filterContact", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Contact", contact.value));
					esq.filters.add("emailAddressFilter", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "EmailAddress", emailAddress));
					esq.filters.add("filterMassMailing", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "BulkEmail", this.get("BulkEmail").value));
					esq.getEntityCollection(function(result) {
						var isContactExist = result.success && !result.collection.isEmpty();
						this.set("IsContactExist", isContactExist);
						next();
					}, this);
				},

				/**
				 * ####### #########, #### ####### ########## ###### # ####### #########
				 * # ############# #########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				validateIsContactExist: function(next) {
					if (!this.get("IsContactExist")) {
						next();
						return;
					}
					this.showInformationDialog(this.get("Resources.Strings.WarningExistsContact"));
				},

				/**
				 * ####### ######### ########.
				 * @private
				 * @param {Function} next ####### ######### ###### # #######.
				 */
				baseValidation: function(next) {
					var result = this.validate();
					if (result) {
						next();
					} else {
						var message = this.getValidationMessage();
						this.showInformationDialog(message, null, null);
					}
				},

				/**
				 * ######### ########.
				 * @overridden
				 */
				save: function() {
					var saveArgs = arguments;
					BPMSoft.chain(
						this.baseValidation,
						this.validateBulkEmailStatus,
						this.setIsContactUnsubscribed,
						this.validateIsContactUnsubscribed,
						this.setIsContactExist,
						this.validateIsContactExist,
						function() {
							this.superclass.save.apply(this, saveArgs);
						}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "BulkEmail",
					"values": {
						"bindTo": "BulkEmail",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"bindTo": "Contact",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "EmailAddress",
					"values": {
						"bindTo": "EmailAddress",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"labelConfig": {
							visible: true
						},
						"controlConfig": {
							visible: true
						},
						"enabled": false
					}
				},
				{
					"operation": "merge",
					"name": "Tabs",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						visible: false
					}
				},
				{
					"operation": "remove",
					"name": "actions"
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Contact": {
					"FiltrationContactByDoNotUseEmail": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "DoNotUseEmail",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": false
					},
					"FilterContactByEmailExist": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"baseAttributePatch": "Email",
						"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": " "
					}
				}
			}
		};
	});
