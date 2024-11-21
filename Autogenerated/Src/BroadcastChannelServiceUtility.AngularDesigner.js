/**
 * @class BPMSoft.configuration.BroadcastChannelServiceUtility
 * Utility class for communicating between Ext and Angular frameworks using BroadcastChannel.
 */
define("BroadcastChannelServiceUtility", ["sandbox", "ext-base", "BPMSoft"], function (sandbox, Ext, BPMSoft) {
    Ext.define("BPMSoft.configuration.BroadcastChannelServiceUtility", {
        extend: "BPMSoft.BaseObject",
        alternateClassName: "BPMSoft.BroadcastChannelServiceUtility",
        singleton: true,

        /**
         * The BroadcastChannel instance for communication.
         * @private
         * @type {BroadcastChannel}
         */
        channel: null,
		pages:'',

        /**
         * An object to store the registered messages.
         * @private
         * @type {Object}
         */
        messages: {},

        /**
         * ###### sandbox
         * @private
         * @type {Object}
         */
        sandbox: null,

        /**
         * The constructor for the class, which initializes the channel and its listener immediately after service creation.
         */
        constructor: function () {
            this.callParent(arguments);
            this.initSandbox(sandbox);
            this.initChannel();
        },

        updateContext: function () {
            const hash = window.BPMSoft.router.Router.getHash();
            const urls = hash.split("/");
            this.pages = urls[urls.length - 1];
            console.log("pages", this.pages)
            this.dispose();
            this.initChannel();
        },

        /**
         * Sets sandbox for current item and subscribes on its messages.
         * @public
         * @param {Object} sandbox Sandbox object.
         */
        initSandbox: function (sandbox) {
			const hash = window.BPMSoft.router.Router.getHash();
			const urls = hash.split("/");
			this.pages =  urls[urls.length - 1];
            this.sandbox = new sandbox();
        },

        /**
         * Initializes the BroadcastChannel and sets up the message event handler.
         */
        initChannel: function () {
            this.channel = new BroadcastChannel(`AngularChannel ${this.pages}`);
            this.channel.onmessage = this.handleMessage.bind(this);
        },

        /**
         * Handles incoming messages through the channel.
         * @param {Event} event - The event containing the message data.
         */
        handleMessage: function (event) {
            console.log("Received event:", event);
            const data  = JSON.parse(event.data);
            const name = data.name;
            
            if (name) {
                // Create a message object with the required parameters
                const message = {
                    mode: BPMSoft.MessageMode.BROADCAST,
                    direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
                };

                // Adding the message to the messages object
                this.messages[name] = message;

                // Register all messages in the sandbox
                this.sandbox.registerMessages(this.messages);

                // Publish the message using the event name and data
                this.sandbox.publish(name, data.data, ['angularSandboxParams']);
            } else {
                console.warn("Event name is not defined.");
            }

            console.log("Message data:", data);
        },

        /**
         * Sends a message through the channel.
         * @param {Object} message - The message to be sent.
         */
        sendMessageToAngular: function (message) {
            this.channel.postMessage(message);
        },

        sendMessageToAngularByChannel: function (message,channelName) {
            let customChannel = new BroadcastChannel(`${channelName} ${this.pages}`);
            customChannel.postMessage(message);
        },

        /**
         * Deinitializes the channel and clears resources.
         */
        dispose: function () {
            // Очистка канала и обработчиков сообщений
            if (this.channel) {
                this.channel.close();
                this.channel = null;
            }

            // Очистка объекта сообщений
            if (this.messages) {
                this.sandbox.unRegisterMessages(this.messages);
                this.messages = {};
            }
        }

    });
    return BPMSoft.BroadcastChannelServiceUtility;
});