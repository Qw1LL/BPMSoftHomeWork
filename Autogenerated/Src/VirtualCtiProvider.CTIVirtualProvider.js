define("VirtualCtiProvider", ["ext-base", "VirtualCtiProviderResources"],
	function(Ext, resources) {
		Ext.ns("BPMSoft.integration");
		Ext.ns("BPMSoft.integration.telephony");

		/**
		 * @class BPMSoft.integration.telephony.webitel.VirtualCtiProvider
		 * Virtual provider class.
		 */
		Ext.define("BPMSoft.integration.telephony.VirtualCtiProvider", {
			extend: "BPMSoft.BaseCtiProvider",
			alternateClassName: "BPMSoft.VirtualCtiProvider",
			singleton: true,

			// region Properties: Private

			/**
			 * Device unique identifier.
			 * @private
			 * @type {String}
			 */
			deviceId: "",

			/**
			 * Active call unique identifier.
			 * @private
			 * @type {String}
			 */
			activeCallId: "",

			/**
			 * Is connection established.
			 * @private
			 * @type {Boolean}
			 */
			isConnected: false,

			/**
			 * Virtually active calls.
			 * @private
			 * @type {BPMSoft.Collection}
			 */
			activeCalls: null,

			/**
			 * Can use video.
			 * @private
			 * @type {Boolean}
			 */
			useVideo: false,

			/**
			 * Call attachment schema UId.
			 * @private
			 * @type {String}
			 */
			callFileSchemaUId: "5956808f-648a-428e-be89-f2dd71f98166",

			/**
			 * Unique identifier of the test call record.
			 * @private
			 * @type {String}
			 */
			testCallRecordId: "1cf9c84c-21ba-4554-929e-f5332f9777d0",

			/**
			 * Path of the GetFile method of the FileService.
			 * @private
			 * @type {String}
			 */
			getFilePath: BPMSoft.workspaceBaseUrl + "/rest/FileService/GetFile/",

			/**
			 * Call record url.
			 * @private
			 * @type {String}
			 */
			callRecordUrl: "",

			/**
			 * Auto answering number.
			 * @private
			 * @type {String}
			 */
			autoAnsweringNumber: "00",

			//endregion

			// region Methods: Private

			/**
			 * Sets connection and connection properties.
			 * @private
			 */
			connect: function() {
				if (this.isConnected) {
					return;
				}
				var initialConfig = this.initialConfig;
				if (initialConfig) {
					var connectionConfig = initialConfig.connectionConfig;
					if (connectionConfig) {
						this.deviceId = connectionConfig.deviceId;
						this.useVideo = connectionConfig.useVideo;
						var autoAnsweringNumber = connectionConfig.autoAnsweringNumber;
						if (!Ext.isEmpty(autoAnsweringNumber)) {
							this.autoAnsweringNumber = autoAnsweringNumber;
						}
					}
				}
				this.isConnected = true;
				this.fireEvent("initialized", this);
				this.fireEvent("agentStateChanged", {userState: "Active"});
			},

			/**
			 * Handler for active call add to collection event.
			 * @private
			 */
			onActiveCallAdded: function() {
				if (this.activeCalls.getCount() === 1) {
					var activeCall = this.activeCalls.getByIndex(0);
					this.activeCallId = activeCall.id;
				}
			},

			/**
			 * Handler for active call remove from collection event.
			 * @private
			 */
			onActiveCallRemoved: function() {
				var activeCallsCount = this.activeCalls.getCount();
				switch (activeCallsCount) {
					case 0:
						this.activeCallId = "";
						this.fireEvent("lineStateChanged", {callFeaturesSet: BPMSoft.CallFeaturesSet.CAN_DIAL});
						break;
					case 1:
						var currentCall = this.activeCalls.getByIndex(0);
						this.activeCallId = currentCall.id;
						this.updateCallFeaturesSet(currentCall);
						this.fireCallEvent(currentCall);
						break;
					default:
						if (Ext.isEmpty(this.activeCalls.find(this.activeCallId))) {
							var activeCall = this.activeCalls.getByIndex(0);
							this.activeCallId = activeCall.id;
						}
						break;
				}
			},

			/**
			 * Handler for active call collection clear event.
			 * @private
			 */
			onActiveCallsCleared: function() {
				this.activeCallId = "";
			},

			/**
			 * Creates new call object.
			 * @private
			 * @param {Object} config Default properties of new call.
			 * @return {BPMSoft.integration.telephony.Call} Call.
			 */
			createNewCall: function(config) {
				var call = Ext.create("BPMSoft.integration.telephony.Call");
				call.deviceId = this.deviceId;
				call.ctiProvider =  this;
				Ext.apply(call, config);
				return call;
			},

			/**
			 * Processes call.
			 * @private
			 * @param {BPMSoft.integration.telephony.Call} call Call.
			 */
			processCall: function(call) {
				this.updateCallFeaturesSet(call);
				this.fireCallEvent(call);
				if (this.useVideo) {
					this.fireWebRTCEvent(call);
				}
				this.updateDbCall(call, this.onUpdateDbCall.bind(this));
			},

			/**
			 * Processes drop call.
			 * @private
			 * @param {BPMSoft.integration.telephony.Call} call Call.
			 */
			processDropCall: function(call) {
				call.oldState = call.state;
				call.state = BPMSoft.GeneralizedCallState.NONE;
				this.processCall(call);
				this.activeCalls.remove(call);
			},

			/**
			 * Generates error event.
			 * @private
			 * @param {String} errorMessage Error message.
			 */
			fireErrorEvent: function(errorMessage) {
				var errorInfo = {
					internalErrorCode: "100500",
					data: errorMessage,
					source: "VirtualCtiProvider",
					errorType: BPMSoft.MsgErrorType.GENERAL_ERROR
				};
				this.fireEvent("error", errorInfo);
			},

			/**
			 * Generates call event depending on the call state.
			 * @private
			 * @param {BPMSoft.integration.telephony.Call} call Call.
			 */
			fireCallEvent: function(call) {
				var event;
				if (call.state !== call.oldState) {
					switch (call.state) {
						case BPMSoft.GeneralizedCallState.ALERTING:
							event = "callStarted";
							break;
						case BPMSoft.GeneralizedCallState.CONNECTED:
							event = (call.oldState === BPMSoft.GeneralizedCallState.HOLDED)
								? "unhold"
								: "commutationStarted";
							break;
						case BPMSoft.GeneralizedCallState.HOLDED:
							event = "hold";
							break;
						case BPMSoft.GeneralizedCallState.NONE:
							event = "callFinished";
							break;
						default:
							break;
					}
				}
				if (!Ext.isEmpty(event)) {
					this.fireEvent(event, call);
				}
			},

			/**
			 * Generates WebRTC event depending on the call state.
			 * @private
			 * @param {BPMSoft.integration.telephony.Call} call Call.
			 */
			fireWebRTCEvent: function(call) {
				if (call.state === call.oldState) {
					return;
				}
				switch (call.state) {
					case BPMSoft.GeneralizedCallState.ALERTING:
						this.fireEvent("webRtcStarted", call.id, {});
						break;
					case BPMSoft.GeneralizedCallState.CONNECTED:
						this.fireEvent("webRtcVideoStarted", call.id);
						break;
					case BPMSoft.GeneralizedCallState.HOLDED:
					case BPMSoft.GeneralizedCallState.NONE:
						this.fireEvent("webRtcDestroyed", call.id);
						break;
					default:
						break;
				}
			},

			/**
			 * Updates call features set, depending on the call state.
			 * @private
			 * @param {BPMSoft.integration.telephony.Call} call Call.
			 */
			updateCallFeaturesSet: function(call) {
				var callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_NOTHING;
				/*jshint bitwise:false*/
				switch (call.state) {
					case BPMSoft.GeneralizedCallState.ALERTING:
						callFeaturesSet = callFeaturesSet | BPMSoft.CallFeaturesSet.CAN_DROP;
						if (call.direction === BPMSoft.CallDirection.IN) {
							callFeaturesSet = callFeaturesSet | BPMSoft.CallFeaturesSet.CAN_ANSWER;
						}
						break;
					case BPMSoft.GeneralizedCallState.CONNECTED:
						callFeaturesSet = callFeaturesSet | BPMSoft.CallFeaturesSet.CAN_DROP |
							BPMSoft.CallFeaturesSet.CAN_HOLD | BPMSoft.CallFeaturesSet.CAN_DTMF |
							BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
							BPMSoft.CallFeaturesSet.CAN_BLIND_TRANSFER;
						break;
					case BPMSoft.GeneralizedCallState.HOLDED:
						callFeaturesSet = callFeaturesSet | BPMSoft.CallFeaturesSet.CAN_DROP |
							BPMSoft.CallFeaturesSet.CAN_UNHOLD;
						break;
					default:
						break;
				}
				/*jshint bitwise:true*/
				call.callFeaturesSet = callFeaturesSet;
			},

			/**
			 * Handler for call saved in database event.
			 * @private
			 * @param {Object} request Request object.
			 * @param {Boolean} success Is saving successfully completed.
			 * @param {Object} response Response object.
			 */
			onUpdateDbCall: function(request, success, response) {
				const responseText = response.responseText;
				var callDatabaseUid = BPMSoft.isGUID(responseText) ? responseText : BPMSoft.decode(responseText);
				if (success && BPMSoft.isGUID(callDatabaseUid)) {
					var call = BPMSoft.decode(request.jsonData);
					call.databaseUId = callDatabaseUid;
					var activeCall = this.activeCalls.find(call.id);
					if (!Ext.isEmpty(activeCall)) {
						activeCall.databaseUId = callDatabaseUid;
					}
					this.fireEvent("callSaved", call);
				} else {
					this.fireErrorEvent(responseText);
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * Constructor for virtual cti provider class.
			 */
			constructor: function() {
				this.callParent(arguments);
				this.activeCalls = Ext.create("BPMSoft.Collection");
				this.activeCalls.on("add", this.onActiveCallAdded, this);
				this.activeCalls.on("remove", this.onActiveCallRemoved, this);
				this.activeCalls.on("clear", this.onActiveCallsCleared, this);
				this.callRecordUrl = Ext.String.format("{0}{1}/{2}", this.getFilePath, this.callFileSchemaUId,
					this.testCallRecordId);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.connect();
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#closeConnection
			 * @overridden
			 */
			closeConnection: function() {
				this.isConnected = false;
				this.activeCalls.clear();
				this.fireEvent("disconnected");
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#makeCall
			 * @overridden
			 */
			makeCall: function(targetAddress) {
				var callId = BPMSoft.generateGUID();
				var config = {
					id: callId,
					direction: BPMSoft.CallDirection.OUT,
					callerId: this.deviceId,
					calledId: targetAddress,
					state: BPMSoft.GeneralizedCallState.ALERTING,
					oldState: BPMSoft.GeneralizedCallState.NONE
				};
				var call = this.createNewCall(config);
				this.activeCalls.add(callId, call);
				this.processCall(call);
				if (targetAddress === this.autoAnsweringNumber) {
					this.answerOutgoingCall(callId);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#answerCall
			 * @overridden
			 */
			answerCall: function(call) {
				var callId = call.id;
				var activeCall = this.activeCalls.get(callId);
				if (activeCall.state === BPMSoft.GeneralizedCallState.ALERTING) {
					activeCall.oldState = activeCall.state;
					activeCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
				} else {
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, BPMSoft.GeneralizedCallState.ALERTING);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#holdCall
			 * @overridden
			 */
			holdCall: function(call) {
				var callId = call.id;
				var activeCall = this.activeCalls.get(callId);
				if (activeCall.state === BPMSoft.GeneralizedCallState.HOLDED) {
					activeCall.oldState = activeCall.state;
					activeCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
				} else if (activeCall.state === BPMSoft.GeneralizedCallState.CONNECTED) {
					activeCall.oldState = activeCall.state;
					activeCall.state = BPMSoft.GeneralizedCallState.HOLDED;
				} else {
					var expectedState = Ext.String.format("{0} " + resources.localizableStrings.OrMessage + " {1}",
						BPMSoft.GeneralizedCallState.HOLDED, BPMSoft.GeneralizedCallState.CONNECTED);
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, expectedState);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#dropCall
			 * @overridden
			 */
			dropCall: function(call) {
				var activeCall = this.activeCalls.get(call.id);
				this.processDropCall(activeCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#makeConsultCall
			 * @overridden
			 */
			makeConsultCall: function(call, targetAddress) {
				this.makeCall(targetAddress);
				var activeCall = this.activeCalls.get(call.id);
				activeCall.oldState = activeCall.state;
				activeCall.state = BPMSoft.GeneralizedCallState.HOLDED;
				/*jshint bitwise:false*/
				activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_DROP |
					BPMSoft.CallFeaturesSet.CAN_UNHOLD |
					BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER;
				/*jshint bitwise:true*/
				this.fireCallEvent(activeCall);
				if (this.useVideo) {
					this.fireWebRTCEvent(activeCall);
				}
				this.updateDbCall(activeCall, this.onUpdateDbCall.bind(this));
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#transferCall
			 * @overridden
			 */
			transferCall: function(currentCall, consultCall) {
				var activeCurrentCall = this.activeCalls.get(currentCall.id);
				var activeConsultCall = this.activeCalls.get(consultCall.id);
				this.processDropCall(activeConsultCall);
				activeCurrentCall.redirectingId = activeConsultCall.callerId;
				activeCurrentCall.redirectionId = activeConsultCall.calledId;
				this.processDropCall(activeCurrentCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#cancelTransfer
			 * @overridden
			 */
			cancelTransfer: function(currentCall, consultCall) {
				var currentCallId = currentCall.id;
				var activeCurrentCall = this.activeCalls.get(currentCallId);
				var activeConsultCall = this.activeCalls.get(consultCall.id);
				this.processDropCall(activeConsultCall);
				if (activeCurrentCall.state === BPMSoft.GeneralizedCallState.HOLDED) {
					activeCurrentCall.oldState = activeCurrentCall.state;
					activeCurrentCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
				} else {
					var errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						currentCallId, activeCurrentCall.state, BPMSoft.GeneralizedCallState.HOLDED);
					this.fireErrorEvent(errorMessage);
					return;
				}
				this.processCall(activeCurrentCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#blindTransferCall
			 * @overridden
			 */
			blindTransferCall: function(call, targetAddress) {
				var activeCall = this.activeCalls.get(call.id);
				activeCall.redirectingId = activeCall.deviceId;
				activeCall.redirectionId = targetAddress;
				this.processDropCall(activeCall);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#queryLineState
			 * @overridden
			 */
			queryLineState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#queryActiveCallSnapshot
			 * @overridden
			 */
			queryActiveCallSnapshot: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#setUserState
			 * @overridden
			 */
			setUserState: function(code, reason) {
				this.fireEvent("agentStateChanged", {
					userState: code,
					userStateReasonCode: reason
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#setVideoState
			 * @overridden
			 */
			setVideoState: function(call, isVideoActive, callback) {
				var isCallActive = this.activeCalls.contains(call.id);
				callback(isVideoActive && isCallActive);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#queryUserState
			 * @overridden
			 */
			queryUserState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#sendDtmf
			 * @overridden
			 */
			sendDtmf: function(call, digit) {
				var activeCall = this.activeCalls.get(call.id);
				/*jshint bitwise:false */
				if ((activeCall.callFeaturesSet & BPMSoft.CallFeaturesSet.CAN_DTMF) > 0) {
					this.fireEvent("dtmfEntered", digit);
				}
				/*jshint bitwise:true */
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#queryCallRecords
			 * @overridden
			 */
			queryCallRecords: function(callId, callback) {
				callback([this.callRecordUrl]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#changeCallCentreState
			 * @overridden
			 */
			changeCallCentreState: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseCtiProvider#getCapabilities
			 * @overridden
			 */
			getCapabilities: function() {
				/*jshint bitwise:false */
				var callCapabilities = BPMSoft.CallFeaturesSet.CAN_RECALL | BPMSoft.CallFeaturesSet.CAN_DIAL |
					BPMSoft.CallFeaturesSet.CAN_DROP |
					BPMSoft.CallFeaturesSet.CAN_HOLD | BPMSoft.CallFeaturesSet.CAN_UNHOLD |
					BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER |
					BPMSoft.CallFeaturesSet.CAN_BLIND_TRANSFER | BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
					BPMSoft.CallFeaturesSet.CAN_DTMF | BPMSoft.CallFeaturesSet.CAN_ANSWER |
					BPMSoft.CallFeaturesSet.CAN_VIDEO;
				/*jshint bitwise:true */
				return {
					callCapabilities: callCapabilities,
					agentCapabilities: BPMSoft.AgentFeaturesSet.CAN_GET_CALL_RECORDS
				};
			},

			/**
			 * Virtually answers outgoing call.
			 * @param {String} callId Unique call identifier.
			 */
			answerOutgoingCall: function(callId) {
				var activeCall = this.activeCalls.find(callId);
				var errorMessage;
				if (Ext.isEmpty(activeCall)) {
					errorMessage = Ext.String.format(resources.localizableStrings.CallNotFoundMessage, callId);
					throw new BPMSoft.ItemNotFoundException({message: errorMessage});
				}
				if (activeCall.state === BPMSoft.GeneralizedCallState.ALERTING) {
					activeCall.oldState = activeCall.state;
					activeCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
					this.processCall(activeCall);
				} else {
					errorMessage = Ext.String.format(resources.localizableStrings.InvalidCallStateMessage,
						callId, activeCall.state, BPMSoft.GeneralizedCallState.ALERTING);
					throw new BPMSoft.InvalidObjectState({message: errorMessage});
				}
			},

			/**
			 * Virtually creates incoming call.
			 * @param {String} callerId Caller number.
			 */
			createIncomingCall: function(callerId) {
				var callId = BPMSoft.generateGUID();
				var config = {
					id: callId,
					direction: BPMSoft.CallDirection.IN,
					callerId: callerId,
					calledId: this.deviceId,
					state: BPMSoft.GeneralizedCallState.ALERTING,
					oldState: BPMSoft.GeneralizedCallState.NONE
				};
				var call = this.createNewCall(config);
				this.activeCalls.add(callId, call);
				this.processCall(call);
			}

			//endregion

		});
	}
);
