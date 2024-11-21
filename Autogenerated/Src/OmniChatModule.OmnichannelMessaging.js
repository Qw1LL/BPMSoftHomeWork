define("OmniChatModule", ["OmniChatUtilities", "BaseSchemaModuleV2", "OmnichannelMessagingComponent", "css!OmniChatModule"],
	function(OmniChatUtilities) {
	Ext.define("BPMSoft.configuration.OmniChatModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.OmniChatModule",

		mixins: {
			customEvent: "BPMSoft.CustomEventDomMixin"
		},

		_omniEl: null,

		omniEventName: "OmniChatWSMessages",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @override
		 */
		useHistoryState: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#render
		 * @override
		 */
		render: function() {
			const container = Ext.get("OmniChatModule_WrapContainer");
			_omniEl = document.createElement("ts-omnichannel-messaging-chat-list");
			_omniEl.addEventListener("contactClick", OmniChatUtilities.openContactCard.bind(this));
			_omniEl.addEventListener("accountClick", OmniChatUtilities.openAccountCard.bind(this));
			_omniEl.addEventListener("duplicatesContactsClick", this._openDuplicatesContactsCard.bind(this));
			container.el.appendChild(_omniEl);
			this.sandbox.publish("OmniChatListLoaded");
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this._onChannelMessage, this);
		},

		/**
		 * @private
		 */
		_onChannelMessage: function (scope, message) {
			if (this._isMessageValid(message)) {
				this.mixins.customEvent.publish(this.omniEventName, BPMSoft.encode(message));
			}
		},

		/**
		 * @private
		 */
		_isMessageValid: function (message) {
			return message?.Header?.BodyTypeName !== null;
		},

		/**
		 * @private
		 */
		_openDuplicatesContactsCard: function(event) {
			const contactsId = event.detail.contactsId;
			const currentContactId = event.detail.currentContactId;
			const hash = "CardModuleV2/ChatContactDuplicatesPage/Contact";
			this.sandbox.publish("PushHistoryState", {
				hash: hash,
				stateObj: {
					DuplicatesContacts: contactsId,
					CurrentContactId: currentContactId
				}
			});
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "OmniChatSchema";
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.sandbox.registerMessages({
				"OmniChatListLoaded": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.BROADCAST
				}
			});
			this.mixins.customEvent.init();
		},
	});

	return BPMSoft.OmniChatModule;
});
