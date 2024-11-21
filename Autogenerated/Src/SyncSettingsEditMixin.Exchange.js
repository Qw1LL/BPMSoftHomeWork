define("SyncSettingsEditMixin", ["SyncSettingsEditMixinResources", "ExchangeNUIConstants",
			"SocialAccountAuthUtilities", "ConfigurationConstants"],
		function(Resources, ExchangeConstants, SocialAccountAuthUtilities, ConfigurationConstants) {
			Ext.define("BPMSoft.configuration.mixins.SyncSettingsEditMixin", {
				alternateClassName: "BPMSoft.SyncSettingsEditMixin",

				//region Properties: Protected

				/**
				 * Setting of sync to mail box.
				 * @type {BPMSoft.Collection}
				 */
				mailboxSyncSettings: null,

				//endregion

				//region Methods: Protected

				/**
				 * Sets clear values to setting of sync.
				 */
				clearValueSyncSetting: function() {
					var emptyString = this.Ext.emptyString;
					this.set("SenderEmailAddress", emptyString);
					this.set("UserLogin", emptyString);
					this.set("ServerName", emptyString);
				},

				/**
				 * Add columns to entity schema query for getting server list for sync.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query for getting server list for sync.
				 */
				addFiltersToServerListEsq: function(esq) {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.add("Exchange", this.BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Type", ExchangeConstants.MailServer.Type.Exchange));
					filterGroup.add("Gmail", this.BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Id", ExchangeConstants.MailServer.Gmail));
					esq.filters.add("IsWithSyncContactOrActivity", filterGroup);
				},

				/**
				 * Creates entity sync settings insert query.
				 * @return {BPMSoft.InsertQuery} Entity sync settings insert query.
				 */
				getEntitySyncSettingInsert: function() {
					var insert = this.getInsertEntitySyncSetting();
					this.setParametersToInsertEntitySyncSetting(insert);
					return insert;
				},

				/**
				 * Returns prompted to insert records of entity sync setting.
				 * @protected
				 * @return {BPMSoft.InsertQuery}
				 */
				getInsertEntitySyncSetting: function() {
					var entitySchemaName = this.getEntitySchemaName();
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: entitySchemaName
					});
					return insert;
				},

				/**
				 * Add contact communication.
				 * @protected
				 * @param {Object} parameters Configuration object.
				 * @param {String} parameters.communicationTypeId Communication type.
				 * @param {String} parameters.number User number in external resource.
				 * @param {String} parameters.socialMediaId User Id in external resource.
				 * @param {Function} parameters.callback Callback function.
				 * @param {Object} parameters.scope Callback function context.
				 */
				addContactCommunication: function(parameters) {
					var callback = parameters.callback,
							scope = parameters.scope || this;
					var insert = this.getContactCommunicationInsert(parameters);
					insert.execute(callback, scope);
				},

				/**
				 * Creates contact communication insert query.
				 * @protected
				 * @param {Object} parameters Configuration object.
				 * @param {String} parameters.communicationTypeId Communication type.
				 * @param {String} parameters.number User number in external resource.
				 * @param {String} parameters.socialMediaId User Id in external resource.
				 */
				getContactCommunicationInsert: function(parameters) {
					var communicationTypeId = parameters.communicationTypeId,
							number = parameters.number,
							socialMediaId = parameters.socialMediaId;
					var insert = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "ContactCommunication"
					});
					var id = this.BPMSoft.utils.generateGUID();
					insert.setParameterValue("Id", id, this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("CommunicationType", communicationTypeId,
							this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Contact", this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
							this.BPMSoft.DataValueType.GUID);
					insert.setParameterValue("Number", number, this.BPMSoft.DataValueType.TEXT);
					insert.setParameterValue("SocialMediaId", socialMediaId, this.BPMSoft.DataValueType.TEXT);
					return insert;
				},

				//endregion

				//region Methods: Public

				/**
				 * Check contact communication exists.
				 * @param {Object} parameters Configuration object.
				 * @param {String} parameters.communicationTypeId Communication type.
				 * @param {String} parameters.number User number in external resource.
				 * @param {Function} parameters.callbackSuccess Callback function on success.
				 * @param {Function} parameters.callbackFail Callback function on fail.
				 * @param {Object} parameters.scope Callback function context.
				 */
				checkContactCommunicationExists: function(parameters) {
					var communicationTypeId = parameters.communicationTypeId,
							number = parameters.number,
							callbackSuccess = parameters.callbackSuccess,
							callbackFail = parameters.callback,
							scope = parameters.scope || this;
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ContactCommunication"
					});
					esq.addColumn("CommunicationType");
					esq.addColumn("Number");
					esq.addColumn("Contact");
					esq.filters.add("TypeFilter", esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"CommunicationType", communicationTypeId));
					esq.filters.add("ValueFilter", esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Number", number));
					esq.filters.add("UserFilter", esq.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"Contact", this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
					esq.getEntityCollection(function(result) {
						if (result.success) {
							if (result.collection.isEmpty()) {
								callbackSuccess.call(scope || this, parameters);
							} else {
								callbackFail.call(scope || this);
							}
						}
					}, this);
				},

				/**
				 * Publish that sync settings is set.
				 */
				publishSyncSettingsIsSet: function() {
					var itemId = this.get("MailboxSyncSettingsId");
					this.sandbox.publish("ShowSyncSettingsSetTip", itemId);
				},

				/**
				 * Gets google account exists.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 * @protected
				 */
				getGoogleAccountExists: function(callback, scope) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SocialAccount"
					});
					esq.filters.add("UserFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"User", this.BPMSoft.SysValue.CURRENT_USER.value));
					esq.filters.add("TypeFilter", esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Type", ConfigurationConstants.CommunicationTypes.Google));
					esq.getEntityCollection(function(result) {
						if (result.success) {
							var response = {
								isValid: true,
								errorMessage: null
							};
							if (result.collection.getCount() > 0) {
								response.isValid = false;
								response.errorMessage = Resources.localizableStrings.OnlyOneGoogleAccountAllowedCaption;
							}
							if (callback) {
								callback.call(scope || this, response);
							}
						}
					}, this);
				},

				/**
				 * Start google authorization.
				 */
				startGoogleAuth: function() {
					this.getGoogleAccountExists(function(response) {
						if (response && !response.isValid) {
							this.showInformationDialog(response.errorMessage);
							return;
						}
						var socialNetwork = "Google";
						var consumerKeySetting = "GoogleConsumerKey";
						var consumerSecretSetting = "GoogleConsumerSecret";
						var useSharedApplicationSetting = "UseGoogleSharedApplication";
						var arrayToQuery = [consumerKeySetting, consumerSecretSetting, useSharedApplicationSetting];
						this.BPMSoft.SysSettings.querySysSettings(arrayToQuery, function(values) {
							var socialAccountOptions = {
								consumerKey: values[consumerKeySetting],
								consumerSecret: values[consumerSecretSetting],
								useSharedApplication: values[useSharedApplicationSetting],
								socialNetwork: socialNetwork,
								sandbox: this.sandbox,
								callAfter: function(data, login, socialNetworkId) {
									var communicationTypeId = socialNetworkId;
									var socialMediaId = data.socialId;
									if (socialNetwork === "Google") {
										communicationTypeId = ConfigurationConstants.CommunicationTypes.Email;
									}
									if (communicationTypeId && !Ext.isEmpty(login) && !Ext.isEmpty(socialMediaId)) {
										var config = {
											communicationTypeId: communicationTypeId,
											number: login,
											socialMediaId: socialMediaId,
											callbackSuccess: this.addContactCommunication,
											callback: this.publishSyncSettingsIsSet,
											scope: this
										};
										this.checkContactCommunicationExists(config);
									}
								}.bind(this)
							};
							var isValid = SocialAccountAuthUtilities.checkSettingsAndOpenWindow(socialAccountOptions);
							if (!isValid) {
								var message = Resources.localizableStrings.MailboxGmailNotHaveSettings;
								this.BPMSoft.showInformation(message);
							}
						}, this);
					}, this);
				},

				/**
				 * Add value parameters to insert query of entity sync setting.
				 * @param {BPMSoft.InsertQuery} insert Insert query.
				 */
				setParametersToInsertEntitySyncSetting: this.BPMSoft.emptyFn,

				/**
				 * Returns name of entity.
				 * @return {String} A name of entity.
				 */
				getEntitySchemaName: this.BPMSoft.emptyFn

				//endregion

			});
			return BPMSoft.SyncSettingsEditMixin;
		});
