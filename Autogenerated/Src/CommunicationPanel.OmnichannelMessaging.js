define("CommunicationPanel", ["DesktopPopupNotification", "RightUtilities", "AcademyUtilities", "CommunicationPanelHelper", "css!OmniChatCommunicationPanelCSS"],
	function (DesktopPopupNotification, RightUtilities, AcademyUtilities) {
		return {
			attributes: {
				/**
				 * Counter of unread chats.
				 * @type {String}
				 */
				"OmniChatCounter": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * User has omnichannel license operation.
				 * @type {Boolean}
				 */
				"HasOmnichannelLicOperation": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * User has omnichannel license.
				 * @type {Boolean}
				 */
				"HasOmnichannelEditRights": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * Sign of omnichannel messaging chat list loading status.
				 * @type {Boolean}
				 */
				"IsOmniChatListLoaded": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false,
					"onChange": "_handleChatListLoaded"
				}
			},
			mixins: {
				customEvent: "BPMSoft.CustomEventDomMixin"
			},
			messages: {
				/**
				 * @message OpenChatWithContact
				 * Notify about start conversation with contact.
				 */
				"OpenChatWithContact": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message OmniChatListLoaded
				 * Notify about loading complete OmniChatList.
				 */
				"OmniChatListLoaded": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			properties: {
				/**
				 * New chats ids.
				 * @type {Array}
				 */
				_newOmniChats: null,

				/**
				 * Announced chats ids.
				 * @type {Array}
				 */
				_notifiedOmniChats: null,

				/**
				 * Notification sound.
				 * @type {Audio}
				 */
				_audioNotification: null,

				/**
				 * Omnichannel operator service url.
				 * @type {String}
				 */
				_omnichannelOperatorServiceName: "OmnichannelChatService",

				/**
				 * Indicates is current page active (on focus).
				 * @type {Boolean}
				 */
				 _isPageActive: false,

				 /**
				 * Enum of message directions.
				 * @type {Object}
				 */
				 _messageDirection: {
					Incoming : 1,
					Outcoming : 2
				},

				 /**
				 * Enum of message types.
				 * @type {Object}
				 */
				 _messageType: {
					Text: 0,
					File: 1,
					Image: 2,
					System: 5
				}
			},
			methods: {

				//region methods: private

				/**
				 * Get new chats count.
				 * @private
				 */
				_initChatCounter: function () {
					const config = {
						serviceName: "OmnichannelChatService",
						methodName: "GetUnreadChatsCount"
					};
					this.callService(config, function (result) {
						const count = result && result.GetUnreadChatsCountResult || 0;
						this.$OmniChatCounter = count > 0 ? count : "";
					}, this);
				},

				_initNotificationSound: function () {
					const audioConfig = {
						params: {
							r: "OmniChatNotificationSound"
						},
						source: this.BPMSoft.ImageSources.SYS_SETTING
					};
					const audioUrl = this.BPMSoft.ImageUrlBuilder.getUrl(audioConfig);
					_audioNotification = new Audio(audioUrl);
				},

				_showNotification: function (body) {
					const config = DesktopPopupNotification.createConfig();
					const image = BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.OmniChatNotificationIcon"));
					var notificationText;
					if(body.text !== ''){
						notificationText = body.text;
					} else {
						notificationText = body.attachments !== null ? `Attachment: ${body.attachments[0].fileName}` : '';
					}
					DesktopPopupNotification.show(this.Ext.apply(config, {
						onClick: this.Ext.global.focus,
						title: body.author.name,
						body: notificationText,
						icon: image,
						silent: true,
						scope: this
					}));
					this.playNotificationSound();
				},

				/**
				 * Primary content of notified chats.
				 * @private
				 */
				_fillNotifiedChats: function () {
					this._notifiedOmniChats = [];
					this.getExistingChats(function (chats) {
						if (this.isNotEmpty(chats) && chats.length) {
							this.BPMSoft.each(chats, function (chat) {
								!this.Ext.Array.contains(this._notifiedOmniChats, chat.Id)
									&& this._notifiedOmniChats.push(chat.Id);
							}, this);
						}
					}, this);
				},

				/**
				 * Check license operation for using chats.
				 */
				_checkOmnichannelLicOperation: function() {
					this.callService({
						serviceName: "CtiRightsService",
						methodName: "GetUserHasOperationLicense",
						data: {
							operations: ['Chats.Use'],
							isAnyOperation: false
						}
					}, function(result) {
						this.$HasOmnichannelLicOperation = result.GetUserHasOperationLicenseResult;
						if(this.$HasOmnichannelLicOperation) {
							this._newOmniChats = [];
							this._fillNotifiedChats();
							this._initChatCounter();
							this._initNotificationSound();
						}
					}, this);
				},

				//endregion

				//region methods: protected

				/**
				 * Plays notification sound.
				 * @protected
				 */
				playNotificationSound: function () {
					_audioNotification.play();
				},

				/**
				 * Check edit rights on chat object.
				 */
				checkOmnichannelLicenses: function () {
					RightUtilities.getSchemaEditRights({ schemaName: "OmniChat" }, function (result) {
						if (this.Ext.isEmpty(result)) {
							this._newOmniChats = [];
							this._fillNotifiedChats();
							this._initChatCounter();
							this._initNotificationSound();
							this.$HasOmnichannelEditRights = true;
						} else {
							this.$HasOmnichannelEditRights = false;
						}
					}, this);
				},

				/**
				 * Getting a collection of operator chats.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 * @returns {Array} A collection of operator chats.
				 */
				getExistingChats: function (callback, scope) {
					const config = {
						serviceName: this._omnichannelOperatorServiceName,
						methodName: "GetChats",
						data: {
							operatorId: BPMSoft.SysValue.CURRENT_USER.value
						}
					};
					this.callService(config, function (response) {
						if (response) {
							if (response.success) {
								Ext.callback(callback, scope || this, [response.Chats]);
							} else if (response.errorInfo) {
								this.error(response.errorInfo.message);
							}
						}
					}, this);
				},

				//endregion

				//region methods: public

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function (callback, scope) {
					this.set("OperatorState", "DisabledState");
					if (this.BPMSoft.isCurrentUserSsp()) {
						this.callParent(arguments);
						return;
					}
					this.callParent([
						function() {
							this.getCurrentUserOperatorInfo(callback, scope || this);
						}, this
					]);
					if (this.getIsFeatureEnabled("ShowOmniChatInCommPanel")) {
						this.checkOmnichannelLicenses();
					}
					window.onblur = () => this._isPageActive = false;
					window.onfocus = () => this._isPageActive = true;
					window.onclick = () => this._isPageActive = true;
				},

				/**
				 * Omnichannel chat visibility.
				 * @return {Boolean} chat button visibility.
				 */
				isOmnichannelEnabled: function () {
					return !this.BPMSoft.isCurrentUserSsp()
						&& this.getIsFeatureEnabled("ShowOmniChatInCommPanel")
						&& this.$HasOmnichannelEditRights;
				},

				/**
				 * @inheritDoc CommunicationPanel#onServerChannelMessage
				 * @override
				 */
				onServerChannelMessage: function (scope, message) {
					this.callParent(arguments);
					this.processOmniChatMessage(message);
				},

				/**
				 * Omnichannel chat websocket messages handler.
				 * @param {String} message Server channel message.
				 */
				processOmniChatMessage: function (message) {
					if (message && message.Header && message.Header.Sender !== "UnreadChatsCount"
						&& message.Header.Sender !== "NewIncomingChat"
						&& message.Header.Sender !== "NewConversationMessage"
						&& message.Header.Sender !== "OperatorStateChanged"
						&& message.Header.Sender !== "NewTransferredChat"
						&& message.Header.Sender !== "AcceptChat") {
						return;
					}
					const sender = message.Header.Sender;
					const body = this.BPMSoft.decode(message.Body);
					if (sender === "AcceptChat" && this.$OmniChatCounter !== "") {
						const chatCount = +this.$OmniChatCounter;
						this.$OmniChatCounter = chatCount > 1 ? chatCount - 1 : "";
					}
					if (sender === "UnreadChatsCount") {
						this.$OmniChatCounter = body.Count > 0 ? body.Count : "";
						return;
					}
					if (sender === "NewConversationMessage") {
						if (body.Message && this._isNeedToShowPopup(body.Message)) {
							this._showNotification(body.Message);
						}
					}
					if (sender === "OperatorStateChanged") {
						this.$OperatorState = body.StateCode;
					}

					if(this._isNeedToOpenPanel(message)) {
						this.$SelectedMenuItem = "OmniChat";
					}
				},

				/**
				 * @private
				 */
				_isNeedToShowPopup: function(message) {
					if(!window.localStorage.getItem(message.id)) {
						window.localStorage.setItem(message.id, 'delivered');
						return !this._isPageActive && this._isIncomingMessage(message);
					}

					return false;
				},

				/**
				 * @private
				 */
				_isIncomingMessage: function(message) {
					return (message.direction !== this._messageDirection.Outcoming || message.type === this._messageType.System || message.isBotMessage);
				},

				/**
				 * @private
				 */
				_isNeedToOpenPanel: function(message) {
					return message.Header.Sender === "NewIncomingChat" || message.Header.Sender === "NewTransferredChat";
				},

				/**
				 * @private
				 */
				_initAcademyLink: function () {
					var config = {
						contextHelpId: "1011",
						scope: this
					};
					config.callback = function(url) {
						url += '#title-758-2';
						this.mixins.customEvent.publish("AcademyNotificationsLink", url);
					};
					AcademyUtilities.getUrl(config);
				},

				/**
				 * @inheritDoc BPMSoft.CommunicationPanel#initSelectedMenuItem
				 * @override
				 */
				initSelectedMenuItem: function (callback) {
					if (!this.getIsFeatureEnabled("ShowOmniChatInCommPanel")
						&& ((this.$Profile || {}).selectedItemTag === 'OmniChat')) {
						this.Ext.callback(callback, this);
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * Getting the current state of the operator.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 * @protected
				 */
				getCurrentUserOperatorInfo: function (callback, scope) {
					const config = {
						serviceName: "OmnichannelOperatorService",
						methodName: "GetCurrentState"
					};
					this.callService(config, function (response) {
						if (response) {
							if (response.success && response.CurrentStateCode) {
								this.set("OperatorState", response.CurrentStateCode);
							} else if (response.errorInfo) {
								this.error(response.errorInfo.message);
							}
						}
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.CommunicationPanel#onSelectedMenuItemChanged
				 * @override
				 */
				onSelectedMenuItemChanged: function() {
					this.callParent(arguments);
					const omniChatActive = this.get("OmniChatActive");
					sessionStorage.setItem(
						'CommunicationOmniChatPanelActive',
						omniChatActive,
					);
					this.mixins.customEvent.publish("OmniChatWSMessages", BPMSoft.encode({
						Header: {
							Sender: "CommunicationOmniChatPanelActive",
						},
						Body: {
							isChatPannelActive: omniChatActive
						}
					}));
				},

				/**
				 * @inheritDoc BPMSoft.CommunicationPanel#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("OpenChatWithContact", this._openChatWithContact, this);
					this.sandbox.subscribe("OmniChatListLoaded", this._omniChatListLoaded, this);
				},

				/**
				 * @private
				 */
				_openChatWithContact: function(chatId) {
					this.$SelectedMenuItem = "OmniChat";
					if (this.$IsOmniChatListLoaded) {
						this.mixins.customEvent.publish("OmniChatWSMessages", BPMSoft.encode({
							Header: {
								Sender: "OpenChatWithContact",
							},
							Body: {
								ChatId: chatId
							}
						}));
						delete this.$OpenChatDelegate;
					} else {
						this.$OpenChatDelegate = this._openChatWithContact.bind(this, chatId);
					}
				},

				/**
				 * @private
				 */
				 _setOmniChatListLoaded: function() {
					this.$IsOmniChatListLoaded = true;
				},

				/**
				 * @private
				 */
				_omniChatListLoaded: function() {
					this._initAcademyLink();
					this._setOmniChatListLoaded();
				},

				/**
				 * @private
				 */
				_handleChatListLoaded: function() {
					this.Ext.callback(this.$OpenChatDelegate, this);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"index": 2,
					"parentName": "communicationPanelContent",
					"name": "OmniChatCommunicationPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "ChatCommPanelContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": { "bindTo": "OperatorState" },
					}
				},
				{
					"operation": "insert",
					"parentName": "OmniChatCommunicationPanelContainer",
					"propertyName": "items",
					"name": "OmniChat",
					"values": {
						"tag": "OmniChat",
						"visible": { "bindTo": "isOmnichannelEnabled" },
						"generator": "CommunicationPanelHelper.generateMenuItem",
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
