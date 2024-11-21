define("AngularPostMessageConnector", [], function() {
	return Ext.define("BPMSoft.Configuration.AngularPostMessageConnector", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.AngularPostMessageConnector",

		//region Fields: Private

		_handshakeMessage: 'handshake',
		_origin: null,

		//endregion

		//region Fields: Public

		initializeMessage: 'initialize',
		target: null,
		channelName: null,
		connected: false,
		connectTimeout: 20000,
		intervalConnectionPolling: 200,

		//endregion

		//region Constructors: Public

		constructor: function(config) {
			this.callParent(arguments);
			this._origin = window.location.origin;
		},

		//endregion

		//region Methods: Private

		_checkParameters: function() {
			const missingProperties = [];
			if (!this.target) {
				missingProperties.push('target');
			}
			if (!this.channelName) {
				missingProperties.push('channelName');
			}
			if (missingProperties.length !== 0) {
				throw new BPMSoft.NullOrEmptyException({
					message: 'Missing properties: ' + missingProperties.join(', ')
				});
			}
		},

		_checkEvent: function(event) {
			const data = event.data;
			return data.channel === this.channelName && event.origin === this._origin
		},

		_handshake: function(callback, scope) {
			let pollingTimerId;
			const handshakeFunction = function(event) {
				const data = event.data;
				if (this._checkEvent(event) && data.name === this._handshakeMessage) {
					this.connected = true;
					clearInterval(pollingTimerId);
					window.addEventListener('message', this._onMessageReceived.bind(this), false);
					Ext.callback(callback, scope, [true]);
				}
			}.bind(this);
			setTimeout(function() {
				if (this.connected === false) {
					clearInterval(pollingTimerId);
					window.removeEventListener('message', handshakeFunction);
					Ext.callback(callback, scope, [false]);
				}
			}.bind(this), this.connectTimeout);
			window.addEventListener('message', handshakeFunction, {once: true});
			pollingTimerId = this._poll();
		},

		_poll: function() {
			const initializeMessage = this._createInitializeMessage();
			this._sendMessage(initializeMessage);
			return setInterval(function() {
				this._sendMessage(initializeMessage);
			}.bind(this), this.intervalConnectionPolling);
		},

		_createInitializeMessage: function() {
			const payload = {
				handshakeMessage: this._handshakeMessage
			};
			return this._createMessage(this.initializeMessage, payload);
		},

		_createMessage: function(name, payload) {
			return {
				channel: this.channelName,
				name: name,
				payload: payload
			};
		},

		_sendMessage: function(message) {
			this.target.postMessage(message, this._origin);
		},

		_onMessageReceived: function(event) {
			const data = event.data;
			if (this._checkEvent(event)) {
				this.fireEvent(data.name, data.payload);
			}
		},

		//endregion

		//region Methods: Public

		connect: function(callback, scope) {
			this._checkParameters();
			this._handshake(callback, scope);
		},

		sendMessage: function(name, payload) {
			const message = this._createMessage(name, payload);
			this._sendMessage(message);
		}

		//endregion

	});
});
