define("EmptyEmailPanelSchema", ["AcademyUtilities", "ModalBox", "EmailConstants",
		"ContextHelpMixin"], function(AcademyUtilities, ModalBox, EmailConstants) {
			return {
				attributes: {
					/**
					 * Academy page url.
					 */
					"HelpUrl": {
						dataValueType: this.BPMSoft.DataValueType.TEXT
					},

					/**
					 * Current user has active mailboxes flag.
					 */
					"MailboxExists": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},

					/**
					 * Current email panel message type.
					 */
					"EmailType": {
						"dataValueType": BPMSoft.DataValueType.GUID,
						"value": EmailConstants.emailType.INCOMING
					}
				},
				mixins: {
					/**
					 * Context help methods mixin.
					 */
					ContextHelpMixin: "BPMSoft.ContextHelpMixin"
				},
				methods: {

					//region Methods: Private

					/**
					 * Sets academy page url to HelpUrl attribute.
					 * @private
					 * @param {String} url Academy page url.
					 */
					_setAcademyUrl: function(url) {
						this.set("HelpUrl", url);
					},

					/**
					 * Returns window object.
					 * @private
					 * @return {Object} Window object.
					 */
					_getDocument: function() {
						return window;
					},

					//endregion

					//region Methods: Protected

					/**
					 * Sets academy page url for email panel.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback function scope.
					 */
					initAcademyUrl: function(callback, scope) {
						var config = this.getContextHelpConfig();
						config.callback = function(url) {
							this._setAcademyUrl(url);
							this.Ext.callback(callback, scope || this);
						}.bind(this);
						AcademyUtilities.getUrl(config);
					},

					/**
					 * Sets MailboxExists attribute value for current user.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {object} scope Callback function scope.
					 */
					initHasMailboxes: function(callback, scope) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "MailboxSyncSettings"
						});
						esq.addColumn("Id");
						esq.addColumn("EnableMailSynhronization");
						var filter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"SysAdminUnit", this.BPMSoft.SysValue.CURRENT_USER.value);
						esq.filters.addItem(filter);
						esq.getEntityCollection(function(response) {
							if (!response.success) {
								return;
							}
							var collection = response.collection;
							var isMailboxExist = false;
							if (!collection.isEmpty()) {
								collection.each(function(item) {
									isMailboxExist = isMailboxExist || (item.get("EnableMailSynhronization") === true);
								});
							}
							this.set("MailboxExists", isMailboxExist);
							this.Ext.callback(callback, scope || this);
						}, this);
					},

					/**
					 * Returns email panel context page code.
					 * @protected
					 * @return {String} Email panel context page code.
					 */
					getContextHelpCode: function() {
						return "CommunicationPanelEmailSchema";
					},

					//endregion

					//region Methods: Public

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @override
					 */
					init: function(callback, scope) {
						this.callParent([function() {
							BPMSoft.chain(
								this.initHasMailboxes,
								this.initAcademyUrl,
								function() {
									this.Ext.callback(callback, scope || this);
								}, this);
						}, this]);
					},

					/**
					 * Opens academy email page.
					 * @return {Boolean} False value returns to prevent click event propagation.
					 */
					openAcademy: function() {
						var url = this.get("HelpUrl");
						var doc = this._getDocument();
						var openedWindow = doc.open(url, "_blank");
						openedWindow.focus();
						return false;
					},

					/**
					 * Add email account action handler.
					 */
					addEmailAccount: function() {
						var modalBoxSize = {
							minHeight: "1",
							minWidth: "1",
							maxHeight: "100",
							maxWidth: "100",
							widthPixels: "425",
							heightPixels: "200"
						};
						var modalBoxContainer = ModalBox.show(modalBoxSize);
						this.sandbox.loadModule("CredentialsSyncSettingsEdit", {
							renderTo: modalBoxContainer,
							instanceConfig: {
								schemaName: "BaseSyncSettingsEdit",
								isSchemaConfigInitialized: true,
								useHistoryState: false
							}
						});
						return false;
					},

					/**
					 * Returns empty panel message.
					 * When user has mailboxes for synchronization, no emails in folder message will be used.
					 * When user has no mailboxes for synchronization, mailboxes not set message will be used.
					 * No emails in folder message will be allways used for Drafts tab.
					 * @return {String} Empty panel message.
					 */
					getMessage: function() {
						var isDraftPanel = this.get("EmailType") === EmailConstants.emailType.DRAFT;
						return this.get("MailboxExists") || isDraftPanel
							? this.get("Resources.Strings.NoEmailsInFolder")
							: this.get("Resources.Strings.NoMailboxes");
					},

					/**
					 * Returns new mailbox acoount message visibility.
					 * This message will be visible on Incoming and Outgoind tabs only,
					 * when user has no mailboxes for synchronization.
					 * @return {Boolean} New mailbox acoount message visibility.
					 */
					getNewAccountLinkVisible: function() {
						var isDraftPanel = this.get("EmailType") === EmailConstants.emailType.DRAFT;
						return !this.get("MailboxExists") && !isDraftPanel;
					}

					//endregion
				},
				diff: /**SCHEMA_DIFF*/[{
					"operation": "insert",
					"name": "EmptyEmailPanelContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["email-empty-message-container"]
						},
						"markerValue": "EmptyEmailPanel",
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "EmptyEmailPanelContainer",
					"propertyName": "items",
					"name": "NoEmailsInFolderLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": ["email-empty-message"]
						},
						"caption": {"bindTo": "getMessage"}
					}
				}, {
					"operation": "insert",
					"parentName": "EmptyEmailPanelContainer",
					"propertyName": "items",
					"name": "LinksPanelContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["border-container"]
						},
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": "LinksPanelContainer",
					"propertyName": "items",
					"name": "EmptyMessagePart1",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "Resources.Strings.EmptyMessagePart1"},
						"classes": {
							"labelClass": ["email-empty-message-link"]
						},
						"click": {bindTo: "addEmailAccount"},
						"visible": {"bindTo": "getNewAccountLinkVisible"},
						"markerValue": "AddEmailAccount"
					}
				}, {
					"operation": "insert",
					"parentName": "LinksPanelContainer",
					"propertyName": "items",
					"name": "EmptyMessagePart2",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"visible": {"bindTo": "getNewAccountLinkVisible"},
						"caption": {"bindTo": "Resources.Strings.EmptyMessagePart2"},
					}
				}, {
					"operation": "insert",
					"parentName": "LinksPanelContainer",
					"propertyName": "items",
					"name": "EmptyMessagePart3",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.EmptyMessagePart3"},
					}
				}, {
					"operation": "insert",
					"parentName": "LinksPanelContainer",
					"propertyName": "items",
					"name": "EmptyMessagePart4",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "Resources.Strings.EmptyMessagePart4"},
						"classes": {
							"labelClass": ["email-empty-message-link"]
						},
						"click": {bindTo: "openAcademy"},
						"markerValue": "OpenEmailAcademyPageLink"
					}
				}]/**SCHEMA_DIFF*/
			};
		});
