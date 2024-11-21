define("BaseWebRTCProvider", ["ext-base", "BPMSoft", "BaseWebRTCProviderResources", "ServiceHelper", "WebRTCAdapter", "PageUpdateBlocker"],
	function(Ext, BPMSoft, resources, ServiceHelper, JsSipAdapter, PageUpdateBlocker) {
		Ext.ns("BPMSoft.integration");
		Ext.ns("BPMSoft.integration.telephony");
		Ext.ns("BPMSoft.integration.telephony.basewebrtc");

		/**
		 * @class BPMSoft.integration.telephony.basewebrtc.BaseWebRTCProvider
		 * Class of BaseWebRTC provider.
		 */
		Ext.define("BPMSoft.integration.telephony.basewebrtc.BaseWebRTCProvider", {
			extend: "BPMSoft.BaseCtiProvider",
			alternateClassName: "BPMSoft.BaseWebRTCProvider",
			singleton: true,
			
			/**
			* Лицензии.
	 		* @inheritdoc BPMSoft.BaseWebRTCProvider#licInfoKeys
	 		* @protected
	 		* @override
	 		* @type {String[]}
	 		*/
			licInfoKeys: [],
			
			/**
			* Экземпляр WebRTC.
			* @type {WebRTCAdapter}
			*/
			webRTC: null,
			
			/**
			* Сессия WebRTC.
			* @type {WebRTCSession}
			*/
			webRTCSession: null,
			
			/**
			* Консультационная сессия WebRTC.
			* @type {WebRTCSession}
			*/
			webRTCConsultSession : null,
			
			/**
			* Текущий звонок.
			* @type {BPMSoft.Telephony.Call}
			*/
			activeCall: null,
			
			/**
			* Текущий консультационный звонок.
			* @type {BPMSoft.Telephony.Call}
			*/
			consultCall: null,
			
			/**
			* Номер консультационного звонка.
			* @type {String}
			*/
			consultCallTarget: null,
			
			/**
			* текущий номер пользователя.
			* @type {String}
			*/
			currentNumber : null,
			
			/**
			Звуки звонков.
			* @type {Object}
	 		*/
			sounds: {
				proccessRing: null,
				incomingRing: null,
				cancelRing: null
			},
			
			/**
			* Плеер для воспроизведения звука звонков.
			* @type {Audio}
	 		*/
			player : new Audio(),
			
			/**
			* Адрес сервиса телефонии.
			* @private
			* @type {String}
			*/
			msgUtilServiceUrl: BPMSoft.workspaceBaseUrl + "/ServiceModel/MsgUtilService.svc/",
		
			 /**
			 * Метод авторизации в телефонии.
			 * @private
			 * @type {String}
			 */
			loginMethodName: "LogInMsgServer",
		
			/**
			* Метод обновления записи звонка.
			* @private
			* @type {String}
			*/
			updateCallMethodName: "UpdateCall",
			
			/**
			* Контекст для ивентов.
			* @private
			* @type {BaseCtiProvider}
			*/
			eventContext: null,
			
			/**
			* Блокиратор обновления страницы во время звонка.
			* @private
			* @type {PageUpdateBlocker}
			*/
			pageBlocker: null,
			
			/**
			* Статус абонента.
			* @private
			* @type {string}
			*/
			telephonyStatus: "Active",
			
			/**
			* Функции CTI-панели.
			* @type {String}
			*/
			connectedCallFeaturesSet: BPMSoft.CallFeaturesSet.CAN_HOLD |
			BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
			BPMSoft.CallFeaturesSet.CAN_BLIND_TRANSFER | BPMSoft.CallFeaturesSet.CAN_DROP |
			BPMSoft.CallFeaturesSet.CAN_DTMF|
			BPMSoft.CallFeaturesSet.CAN_MUTE,
			
			/**
	 		* @inheritdoc BPMSoft.BaseWebRTCProvider#init
	 		* @protected
	 		* @override
			*/
			init: function(config) {
				this.callParent(arguments);
				this.getSounds();
				this.loginMsgService(this.msgUtilServiceUrl + this.loginMethodName, {
					"LicInfoKeys": this.licInfoKeys,
					"UserUId": BPMSoft.SysValue.CURRENT_USER.value
				}, this.connect.bind(this));
			},
			
			/**
	 		* Метод подключения телефонии.
	 		* @private
	 		* @param {Object} config connection parameters.
	 		*/
			connect: function(config) {
				this.currentNumber = config.number; 
				this.eventContext = this.eventContext || this;
				let configuration = this.getConnectConfig(config);
				this.webRTC = new JsSipAdapter(configuration);
				this.subscribeOnWebRTCEvents();
				this.webRTC.start();
				this.eventContext.fireEvent("initialized");
			},
			
			/**
	 		* Конфиг подключения к телефонии.
	 		* @private
	 		* @param {Object} config connection parameters.
	 		*/
			getConnectConfig: function(config) {
				var socket = config.url;
				return  {
					webSocketUrl  : [ socket ],
					uri      : config.login,
					password : config.password,
					channelsCount : 2,
					debugMode : config.debugMode,
					//iceServers: [
					//	{
					//		"urls":["stun:stun.l.google.com:19302", 
					//				"stun:stun.counterpath.net:3478", 
					//				"stun:numb.viagenie.ca:3478"]
					//	},
					//]
				};
			},
			
			/**
	 		* Получение звука рингтонов из системных настроек.
	 		* @private
	 		*/
			getSounds: function() {
				let scope = this;
				BPMSoft.SysSettings.querySysSettings(["WebRTCOutRing", "WebRTCInRing", "WebRTCCancelRing"], function(sysSettings) {
					scope.sounds.proccessRing = "data:audio/mpeg;base64," + sysSettings.WebRTCOutRing;
					scope.sounds.incomingRing = "data:audio/mpeg;base64," + sysSettings.WebRTCInRing;
					scope.sounds.cancelRing = "data:audio/mpeg;base64," + sysSettings.WebRTCCancelRing;
				});
			},
			
			/**
	 		* Метод воспроизведения звука.
	 		* @param {String} Название звука,
			* @param {Boolean} Цикличность звука.
	 		*/
			playSound: function(sound, loop) {
				let sounds = this.sounds;
				let player = this.player;
				
				switch(sound) {
					case "ProccessRing": player.src = sounds.proccessRing;
						break;
					case "IncomingRing": player.src = sounds.incomingRing;
						break;
					case "CancelRing": player.src = sounds.cancelRing;
						break;
					default: return;
				}
				if (!player.src) {
					return;
				}
				player.loop = loop;
				// Решение для исправления проблем с воспроизведением звука в браузере Chrome.
				const playPromise = player.play();
				if (playPromise !== null) {
				    playPromise.catch(() => { player.play(); })
				}
			},
			
			/**
	 		* Метод остановки звука.
			*/
			stopSound: function() {
				let player = this.player;
				player.pause();
			},
			
			/**
	 		* Подписка ивентов WebRTC для консультационного звонка.
			*/
			subscribeOnWebRTCEvents: function() {
				var scope = this;
				
				this.webRTC.on("newRTCSession", function(session) {
					if (scope.webRTCConsultSession) {
						scope.onNewConsultRTCSession(session, scope);
					}
					else {
						scope.onNewRTCSession(session, scope);
					}
				});
				this.webRTC.on("disconnected", function() {
					scope.webRTCConsultSession = null;
					scope.stopSound();
				});
			},
			
			/**
	 		* Подписка ивентов консультационной сессии WebRTC.
			* @param {WebRTCSession} Сессия WebRTC.
			* @param {BaseWebRTCProvider} Контекст провайдера.
			*/
			onNewConsultRTCSession: function(session, scope) {
				scope.webRTCConsultSession = session;
				scope.addIncomingSound(scope, session);
				scope.mute();
				if (scope.activeCall.state !== BPMSoft.GeneralizedCallState.HOLDED) {
					scope.holdCall();
				}
				let call = scope.createCall(BPMSoft.CallDirection.OUT, scope, true);
				call.parentCall = scope.activeCall;
				call.callerId = scope.currentNumber;
				call.calledId = scope.consultCallTarget;
				scope.consultCall = call; 
				scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_SETUP_TRANSFER;
				scope.eventContext.fireEvent("hold", scope.activeCall);
				scope.eventContext.fireEvent("callStarted", call);
			
				this.webRTCConsultSession.on("ended", function(e) {
					scope.consultCall.state = BPMSoft.GeneralizedCallState.NONE;
					scope.eventContext.fireEvent("callFinished", scope.consultCall);
					scope.consultCall.timeStamp = new Date();
					scope.updateDbCall(scope.consultCall, scope.onUpdateDbCall);
					scope.consultCall = null;
					scope.consultCallTarget = "";
					if (scope.activeCall) {
						scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_UNHOLD |
						BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL;
						scope.eventContext.fireEvent("callInfoChanged", scope.activeCall);
					}
					scope.webRTCConsultSession = null;
					scope.cancelTransfer();
					scope.stopSound();
				});
				this.webRTCConsultSession.on("failed", function(e) {
					scope.consultCall.state = BPMSoft.GeneralizedCallState.NONE;
					scope.eventContext.fireEvent("callFinished", scope.consultCall);
					scope.consultCall.timeStamp = new Date();
					scope.updateDbCall(scope.consultCall, scope.onUpdateDbCall);
					scope.consultCall = null;
					scope.consultCallTarget = "";
					if (scope.activeCall) {
						scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_UNHOLD |
						BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL;
						scope.eventContext.fireEvent("callInfoChanged", scope.activeCall);
					}
					scope.webRTCConsultSession = null;
					scope.cancelTransfer();
					scope.stopSound();
				});
				this.webRTCConsultSession.on("confirmed", function(e) {
					scope.consultCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
					scope.consultCall.timeStamp = new Date();
					scope.consultCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER;
					scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER;
					scope.eventContext.fireEvent("callInfoChanged", scope.activeCall);
					scope.eventContext.fireEvent("commutationStarted", scope.consultCall);
					scope.updateDbCall(scope.consultCall, scope.onUpdateDbCall);
				});
			},
			
			/**
	 		* Подписка ивентов WebRTC для обычного звонка.
			* @param {WebRTCSession} Сессия WebRTC.
			* @param {BaseWebRTCProvider} Контекст провайдера.
			*/
			onNewRTCSession: function(session, scope) {
				scope.webRTCSession = session;
				this.subscribeOnSessionEvents(scope);
				if (scope.webRTCSession.getDirection() === "outgoing") {
					scope.addIncomingSound(scope, session);
					scope.playSound("ProccessRing", true);
					scope.activeCall = scope.createCall(BPMSoft.CallDirection.OUT, scope);
					scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_DROP;
					scope.eventContext.fireEvent("callStarted", scope.activeCall);
				}
				if (scope.webRTCSession.getDirection() === "incoming") {
					if (scope.telephonyStatus && scope.telephonyStatus.toLowerCase() == "dnd") {
						scope.terminateCallWithStatusBusy(session);
						return;
					}
					if (!scope.activeCall) {
						scope.playSound("IncomingRing", true);
						scope.activeCall = scope.createCall(BPMSoft.CallDirection.IN, scope);
						scope.activeCall.state = BPMSoft.GeneralizedCallState.ALERTING;
						scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_ANSWER | BPMSoft.CallFeaturesSet.CAN_DROP;
						scope.eventContext.fireEvent("callStarted", scope.activeCall);
					}
					else {
						scope.terminateCallWithStatusBusy(session);
					}	
				}
			},
			
			/**
	 		* Сбрасывает сессию, если абонент уже разговаривает или статус "Не беспокоить".
			* @param {WebRTCSession} Сессия WebRTC.
			*/
			terminateCallWithStatusBusy: function(session) {
				session.terminate({
                   			cause: 'Busy',
                   			status_code: 486
                		});
			},
				
			/**
	 		* Подписка ивентов сессии обычного звонка WebRTC.
			* @param {BaseWebRTCProvider} Контекст провайдера.
			*/
			subscribeOnSessionEvents: function (scope) {
				this.webRTCSession.on("progress", function(data) {
					if (data.originator === 'remote') {
						data.response.body = null;
					}
				});
				this.webRTCSession.on("ended", function(e) {
					scope.activeCall.state = BPMSoft.GeneralizedCallState.NONE;
					scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_DIAL;
					scope.eventContext.fireEvent("callFinished", scope.activeCall);
					call.timeStamp = new Date();
					scope.updateDbCall(scope.activeCall, scope.onUpdateDbCall);
					scope.activeCall = null;
					scope.stopSound();
					window.obUnloader && window.obUnloader.destructor();
				});
				this.webRTCSession.on("failed", function(e) {
					if (scope.activeCall) {
						scope.activeCall.state = BPMSoft.GeneralizedCallState.NONE;
						scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_DIAL;
						scope.eventContext.fireEvent("callFinished", scope.activeCall);
						call.timeStamp = new Date();
						scope.updateDbCall(scope.activeCall, scope.onUpdateDbCall);
						scope.activeCall = null;
						scope.stopSound();
						scope.playSound("CancelRing", false);
						window.obUnloader && window.obUnloader.destructor();
					}
				});
				this.webRTCSession.on("confirmed", function(e) {
					window.obUnloader = new PageUpdateBlocker();
					scope.activeCall.callFeaturesSet = scope.connectedCallFeaturesSet;
					call.oldState = BPMSoft.GeneralizedCallState.ALERTING;
					scope.activeCall.state = BPMSoft.GeneralizedCallState.CONNECTED;
					scope.activeCall.timeStamp = new Date();
					scope.eventContext.fireEvent("commutationStarted", scope.activeCall);
					scope.updateDbCall(scope.activeCall, scope.onUpdateDbCall);
					scope.stopSound();
				});
				this.webRTCSession.on("hold", function(e) {
					scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_UNHOLD |
						BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL;
					if (scope.webRTCConsultSession) {
						scope.activeCall.callFeaturesSet = BPMSoft.CallFeaturesSet.CAN_SETUP_TRANSFER;
					}
					scope.activeCall.state = BPMSoft.GeneralizedCallState.HOLDED;
					scope.eventContext.fireEvent("hold", scope.activeCall);
					scope.updateDbCall(scope.activeCall, scope.onUpdateDbCall);
				});
				this.webRTCSession.on("unhold", function(e) {
					scope.activeCall.callFeaturesSet = scope.connectedCallFeaturesSet;
					scope.activeCall.state = BPMSoft.GeneralizedCallState.CONFERENCED;
					scope.eventContext.fireEvent("unhold", scope.activeCall);
					scope.updateDbCall(scope.activeCall, scope.onUpdateDbCall);
				});
				this.webRTCSession.on("muted", function(e) {
					//Нет ивента в BpmSoft 
				});
				this.webRTCSession.on("unmuted", function(e) {
					//Нет ивента в BpmSoft 
				});
				this.webRTCSession.on("progress", function(e) {
					scope.stopSound();
				});
			},
			
			/**
	 		* Получение функциональности CTI- панели.
			*/
			getCapabilities: function() {
				return {
            		callCapabilities : BPMSoft.CallFeaturesSet.CAN_RECALL | BPMSoft.CallFeaturesSet.CAN_DIAL |
						BPMSoft.CallFeaturesSet.CAN_DROP |
						BPMSoft.CallFeaturesSet.CAN_HOLD | BPMSoft.CallFeaturesSet.CAN_UNHOLD |
						BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER |
						BPMSoft.CallFeaturesSet.CAN_BLIND_TRANSFER | BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL |
						BPMSoft.CallFeaturesSet.CAN_DTMF,
           			agentCapabilities: BPMSoft.AgentFeaturesSet.CAN_GET_CALL_RECORDS
        		};
			},
			
			getAgentLogoutCode: BPMSoft.emptyFn,

			/**
			* Закрывает соединение телефонии.
			*/
			closeConnection: function() {
				this.webRTC.stop();
			},
			
			/**
	 		* Создает класс звонка.
			* @param {String} Направление звонка.
			* @param {BaseWebRTCProvider} Контекст провайдера.
			*/
			createCall: function(direction, scope, isConsultCall) {
				let call = Ext.create("BPMSoft.integration.telephony.Call");
				call.id = BPMSoft.generateGUID();
				call.direction = direction;
				call.deviceId = scope.currentNumber;
				let caller = (scope.webRTCSession.getRemoteUserUri()).toString();
				let called = (scope.currentNumber ||scope.webRTCSession.getLocalUserUri()).toString()
				if (direction === BPMSoft.CallDirection.IN) {
					call.callerId = caller;
					call.calledId = called;
				} else {
					if (isConsultCall) {
						call.callerId = called;
						call.calledId = scope.consultCallTarget;
					}
					else {
						call.callerId = called;
						call.calledId = caller;
					}
				}
				call.ctiProvider = scope;
				call.timeStamp = new Date();
				call.callFeaturesSet =  BPMSoft.CallFeaturesSet.CAN_NOTHING;
				call.state = BPMSoft.GeneralizedCallState.ALERTING;
				scope.updateDbCall(call, this.onUpdateDbCall);
				return call;
			},
			
			/**
	 		* Обработчик после сохранения звонка.
			*/
			onUpdateDbCall: function (request, success, response) {
				let callDatabaseUid = BPMSoft.isGUID(response.responseText) ? response.responseText : BPMSoft.decode(response.responseText);
				let callId = BPMSoft.deserialize(request.jsonData).id;
				if (success && BPMSoft.isGUID(callDatabaseUid)) {
					if (callId === (this.activeCall && this.activeCall.id)) {
						call = this.activeCall;
					}
					if (callId === (this.consultCall && this.consultCall.id)) {
						call = this.consultCall
					}
					if (!call) {
						return;
					}
					call.databaseUId = callDatabaseUid;
					this.eventContext.fireEvent("callSaved", call);
				}
				else {
					var errorInfo = {
						internalErrorCode: null,
						data: responseText,
						source: "App server",
						errorType: BPMSoft.MsgErrorType.COMMAND_ERROR
					};
					this.eventContext.fireEvent("error", errorInfo);
				}
			},
			
			/**
	 		* Добавление входящего голоса для звонка.
			* @param {BaseWebRTCProvider} Контекст провайдера.
			* @param {WebRTCSession} Сессия WebRTC.
			*/
			addIncomingSound: function(scope, session) {
				if (!session) {
					session = scope.webRTCSession;
				}
				session.getConnection().addEventListener('addstream', function (e) {
					var localAudio = new Audio();
					localAudio.srcObject = e.stream;
					localAudio.play();
				});
			},

			/**
			* Делает исходящий звонок.
			* @param {String} номер звонка.
			*/
			makeCall: function (targetAddress) {
				this.getCallConfig(function(config){
					this.webRTC.call(targetAddress, config);
				});
			},
			
			/**
			* Возвращает звуковые настройки звонка.
			*/
			getCallConfig: function(callback) {
				let scope = this;
				const mediaOptions = {'audio': true, 'video': false}
				let config = {
					mediaConstraints: mediaOptions,
					pcConfig: {
  		          		iceServers: this.iceServers,
  		        		rtcpMuxPolicy: 'negotiate',
						hackStripTcp: true,
					}
				};
				if (navigator) {
					let mediaStream = navigator.getUserMedia(mediaOptions,
						(stream) => {
							config.mediaStream = stream;
							Ext.callback(callback, scope, [config]);
						},
						(err) => {
						console.error("Нет доступа к микрофону");
					});
				}
				else {
					Ext.callback(callback, scope, [config]);
				}
			},
			
			/**
			* Picks up the receiver.
			* @method
			* @abstract
			*/
			hookup: BPMSoft.emptyFn,

			/**
			* Отвечает на входящий звонок.
			*/
			answerCall: function() {
				let scope = this;
				this.getCallConfig(function(config){
					scope.webRTCSession.answer(config);
					scope.addIncomingSound(scope);
				});				   
			},

			/**
			* Ставит или снимает звонок с удержания.
			*/
			holdCall: function() {
				if (!this.webRTCSession.isOnHold().local) {
					this.webRTCSession.hold();
				}
				else {
					this.webRTCSession.unhold();
				}
			},

			/**
			* Завершает звонок.
			*/
			dropCall: function() {
				if (this.webRTCConsultSession) {
					this.transferCall(this.consultCallTarget);
				}
				this.webRTCSession.terminate();
			},

			/**
			* Подготавливает звонок (Tapi).
			* @abstract
			* @param {BPMSoft.Telephony.Call} call
			*/
			setupTransferCall: BPMSoft.emptyFn,

			/**
			* Совершает консультационный звонок.
			* @param {BPMSoft.Telephony.Call} звонок.
			* @param {String}  Номер абонента.
			*/
			makeConsultCall: function(scope, targetAddress) {
				this.webRTCConsultSession = true;
				this.consultCallTarget = targetAddress;
				this.makeCall(targetAddress);
			},

			/**
			* Переводит звонок.
			* @param {BPMSoft.Telephony.Call} звонок.
			* @param {String} номер для перевода.
			* @param {Boolean} включен ли слепой перевод.
			*/
			transferCall: function(scope, number, useBlindTransfer) {
				this.webRTCSession.unmute(true, false);
				this.webRTCSession.unhold();
				let options = this.getTrasferEventHandlers(useBlindTransfer);
				this.webRTCSession.refer(this.consultCallTarget || number, options);
				this.stopSound();
			},
			
			/**
			* Возвращет конфиг опций перевода.
			* @param {Boolean} включен ли слепой перевод.
			*/
			getTrasferEventHandlers: function(useBlindTransfer) {
				let scope = this;
				let handlers = {
					eventHandlers: {
						requestSucceeded: function (e) {
							scope.activeCall.redirectingId = scope.currentNumber;
							scope.activeCall.redirectionId = scope.consultCallTarget; 
							scope.webRTCConsultSession && scope.webRTCConsultSession.terminate();
							scope.webRTCSession.terminate();
						},
						requestFailed: function (e) {
						},
						trying: function (e) {
						},
						progress: function (e) {},
						accepted: function (e) {
						},
						failed: function (e) {
						}
					},
					mediaConstraints: {'audio': true, 'video': false}
				};
				if (!useBlindTransfer) {
					handlers.replaces = scope.webRTCConsultSession.session;
				}
				return handlers;
			},
			
			/**
			* Отменяет перевод звонка.
			*/
			cancelTransfer: function() {
				if (this.webRTCConsultSession) {
					this.webRTCConsultSession.terminate();
				}
				this.webRTCConsultSession = null;
				this.webRTCSession.unmute(true, false);
			},

			/**
			* Слепой перевод звонка.
			* @param {BPMSoft.Telephony.Call} звонок.
			* @param {String} номер абонента.
			*/
			blindTransferCall: function(scope, number) {
				this.consultCallTarget = number; 
				this.transferCall(this, number, true);
			},
			
			/**
			* Sets the state Do not disturb (Tapi).
			* @method
			* @abstract
			*/
			setDnd: BPMSoft.emptyFn,

			/**
			* Prompts the line state.
			* @method
			* @abstract
			*/
			queryLineState: BPMSoft.emptyFn,

			/**
			* Requests a collection of active calls.
			* @method
			* @abstract
			*/
			queryActiveCallSnapshot: BPMSoft.emptyFn,

			/**
			* Устанавливает статус оператора.
			* @abstract
			* @param {String} code Status code.
			* @param {String} reason (optional) The reason for the change in state.
			* @param {Object} callback (optional) Callback function.
			*/
			setUserState: function(e, t, n)
			{
				this.telephonyStatus = e;
			},

			/**
			* Sets the post-processing state.
			* @abstract
			* @param {Boolean} isWrapUpActive Indicates the post-processing activity.
			* @param {Object} callback (optional) Callback function.
			*/
			setWrapUpUserState: BPMSoft.emptyFn,

			/**
			* Sets the state of using the video during a call.
			* @abstract
			* @param {BPMSoft.Telephony.Call} call.
			* @param {Boolean} isVideoActive Indicates using the video during the call.
			* @param {Function} callback The callback function.
			* @param {Boolean} callback.isVideoActive A sign of using the video during the call.
			* The value is determined as a result of the method performed by the telephony provider.
			*/
			setVideoState: BPMSoft.emptyFn,

			/**
			* Requests the state of the agent.
			* @method
			* @abstract
			*/
			queryUserState: BPMSoft.emptyFn,

			/**
			* Отправляет код Dtmf.
			* @param {BPMSoft.Telephony.Call} звонок
			* @param {String} цифры для Dtmf.
			*/
			sendDtmf: function(scope, number) {
				this.webRTCSession.sendDTMF(number);
			},

			/**
			* Отключает микрофон.
			* @param {BPMSoft.Telephony.Call} звонок.
			*/
			mute: function() {
				var statusMute = this.webRTCSession.isMuted();
				if (!statusMute.audio)
					this.webRTCSession.mute(true, false);
				else {
					this.webRTCSession.unmute(true, false);
				}
			},

			/**
			* Requests records of call conversations.
			* @abstract
			* @param {String} callId Caller ID.
			* @param {Function} callback Callback function.
			* @param {String[]} callback.callRecords An array of references to call records.
			*/
			queryCallRecords: BPMSoft.emptyFn,

			/**
			* Changes the status of the user in the Call Center.
			* @abstract
			* @param {Boolean} isActive The user's status in the Call Center.
			*/
			changeCallCentreState: BPMSoft.emptyFn,

		});
	return BPMSoft.integration.telephony.basewebrtc.BaseWebRTCProvider;
	}
);