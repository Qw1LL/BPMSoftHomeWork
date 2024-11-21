define("SyncSettingsErrorItem", ["SyncSettingsErrorItemResources", "css!SyncSettingsErrorsCSS",
	"CredentialsSyncSettingsMixin", "OAuthAuthenticationMixin", "AcademyUtilities"], function() {
		return {
			mixins: {
				/**
				 * @class CasePageUtilitiesV2 implements quick save cards in one click.
				 */
				CredentialsSyncSettingsMixin: "BPMSoft.CredentialsSyncSettingsMixin",

				/**
				 * @class OAuthAuthenticationMixin The mixin to work with OAuth authentication.
				 */
				OAuthAuthenticationMixin: "BPMSoft.OAuthAuthenticationMixin"
			},
			messages: {

				/**
				 * @message OpenSyncSettingsEdit
				 * Opens SyncSettingsEdit page.
				 */
				"OpenSyncSettingsEdit": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Error text.
				 * @type {String}
				 */
				"Text": {
					dataValueType: this.BPMSoft.DataValueType.TEXT
				},

				/**
				 * Error text template.
				 * @type {String}
				 */
				"TextTpl": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * Mailbox with which a connection error occurred.
				 * @type {String}
				 */
				"Mailbox": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Displayed custom action.
				 * @type {String}
				 */
				"Action": {
					dataValueType: this.BPMSoft.DataValueType.TEXT
				},

				/**
				 * Url for an article about ExchangeListener at the academy.
				 * @type {String}
				 */
				"ExchangeListenerAcademyUrl": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Id of the article about ExchangeListener at the academy.
				 * @type {Number}
				 */
				"ExchangeListenerAcademyArticleId": {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 2074
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Sets the academy url about ExchangeListener.
				 */
				_setExchangeListenerAcademyUrl: function() {
					const config = {
						contextHelpId: this.get("ExchangeListenerAcademyArticleId"),
						scope: this,
						callback: function(url) {
							this.set("ExchangeListenerAcademyUrl", url);
						}
					};
					BPMSoft.AcademyUtilities.getUrl(config);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function() {
					this.initErrorText();
					this._setExchangeListenerAcademyUrl();
					this.callParent(arguments);
				},

				/**
				 * Sets error text value.
				 */
				initErrorText: function() {
					var mailbox = this.get("Mailbox");
					var textTpl = this.get("TextTpl");
					this.set("Text", this.Ext.String.format(textTpl, mailbox && mailbox.senderEmailAddress || ""));
				},

				/**
				 * Sets error text value.
				 */
				changeSyncSettings: function() {
					var mailbox = this.get("Mailbox");
					this.openCredentialsSyncSettingsEdit(mailbox);
					this.sandbox.publish("OpenSyncSettingsEdit", null, ["SyncSettingsErrorItem"]);
				},

				/**
				 * Initiates OAuth authentication.
				 */
				authenticateOAuth: function() {
					var mailbox = this.get("Mailbox");
					if (mailbox.oAuthApplicationName) {
						this.useOAuthAuthentication(
							mailbox.senderEmailAddress, mailbox.oAuthApplicationName, mailbox.mailServerId);
					} else {
						this.changeSyncSettings();
					}
				},

				getExchangeListenerServiceAcademyUrl: function() {
					return this.get("Resources.Strings.LinkToExchangeListenerServiceAcademyUrl");
				},

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["sync-error"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"name": "ErrorText",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {bindTo: "Text"},
						"markerValue": {bindTo: "Text"}
					}
				},
				{
					"operation": "insert",
					"name": "ChangeSyncSettings",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "changeSyncSettings"},
						"markerValue": "changeSyncSettingsButton",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": [
								"change-sync-settings-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.SpecifyNewPasswordLocalizableString"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "ChangePassword";
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "OAuthAuthenticate",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "authenticateOAuth"},
						"markerValue": "oAuthAuthenticateButton",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"textClass": [
								"oauth-authenticate-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.OAuthAuthenticateLocalizableString"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "OAuthAuthenticate";
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "LinkToExchangeListenerServiceAcademy",
					"parentName": "ErrorContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"href": {
							"bindTo": "ExchangeListenerAcademyUrl"
						},
						"markerValue": "linkToExchangeListenerServiceAcademyButton",
						"classes": {
							"hyperlinkClass": [
								"link-to-exchange-listener-service-academy-button"
							]
						},
						"caption": {"bindTo": "Resources.Strings.LinkToExchangeListenerServiceAcademyCaption"},
						"visible": {
							"bindTo": "Action",
							"bindConfig": {
								"converter": function(action) {
									return action === "LinkToExchangeListenerServiceAcademy";
								}
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
