define("UisCtiProvider", ["BPMSoft", "UisCtiProviderResources", "BaseWebRTCProvider"],
	function(BPMSoft, resources) {
		Ext.ns("BPMSoft.integration");
		Ext.ns("BPMSoft.integration.telephony");
		Ext.ns("BPMSoft.integration.telephony.uis");
		
		/**
		 * @class BPMSoft.integration.telephony.basewebrtc.UisCtiProvider
		 * Class of BaseWebRTC provider.
		 */
		Ext.define("BPMSoft.integration.telephony.uis.UisCtiProvider", {
			extend: "BPMSoft.BaseCtiProvider",
			alternateClassName: "BPMSoft.UisCtiProvider",
			singleton: true,
			
			/**
			* Лицензии.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#init
			* @protected
	 		* @override
	 		* @type {String[]}
			*/
			licInfoKeys: [],
			
			/**
			* Класс провайдера.
	 		* @type {BaseCtiProvider}
			*/
			providerClass : null,
			
			/**
			* Название класса провайдера WebRTC.
	 		* @type {String}
			*/
			webRTCProviderName : "BaseWebRTCProvider",
			
			/*
			* Адрес сервера.
	 		* @type {String}
			*/
			uisUrl : "wss://voip.uiscom.ru",
			
			/*
			* Адрес сервиса получения звонка.
	 		* @type {String}
			*/
			callRecordServiceUrl: BPMSoft.workspaceBaseUrl + "/rest/UisCallRecordService/",
			
			/*
			* Метод сервиса получения звонка.
	 		* @type {String}
			*/
			callRecordMethodName: "GetRecordLink",
			
			localizableStrings: {},
			
			/**
			* Инициализация провайдера.
	 		* @inheritdoc BPMSoft.BaseWebRTCProvider#init
	 		* @protected
	 		* @override
			*/
			init: function(config) {
				this.callParent(arguments);
				let scope = this;
				// Добавление ресурсов. Стандартными способами не работает.
				require(["UisCtiProviderResources"], function(module) {
					if (module) {
						scope.localizableStrings = module.localizableStrings;
					}
				});
				if (config.connectionConfig.useWebPhone) {
					
					require([scope.webRTCProviderName], function() {
						scope.providerClass = BPMSoft[scope.webRTCProviderName];
						scope.connect(config);
						scope.providerClass.eventContext = scope;
					});
				}
				else {
					//to do... провайдер для настольного приложения и "Железных телефонов";
					this.connect(config);
				}
			},
			
			/**
			* Инициализация провайдера.
	 		* @inheritdoc BPMSoft.BaseWebRTCProvider#connect
	 		* @protected
	 		* @override
			* @param {Object} Параметры подключения к телефонии.
			*/
			connect: function(config) {
				config.connectionConfig.url = this.uisUrl;
				config.connectionConfig.login = this.getConvertUri(config.connectionConfig.login);
				this.providerClass.init(config);
			},
			
			/**
			* Конвертация логина для авторизации.
	 		* @private
			* @param {String} Логин пользователя.
			*/
			getConvertUri: function(uri) {
				return `sip:${uri}@voip.uiscom.ru`;
			},
			
			/**
			* Закрывает соединение телефонии.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#closeConnection
	 		* @protected
	 		* @override
			*/
			closeConnection: function() {
				this.providerClass.closeConnection();
			},
			
			/**
			* Совершает исходящий звонок.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#makeCall
	 		* @protected
	 		* @override
			* @param {String} Номер абонента.
			*/
			makeCall: function (targetAddress) {
				this.providerClass.makeCall(targetAddress);
			},
			
			/**
			* Picks up the receiver.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#hookup
	 		* @protected
	 		* @override
			*/
			hookup: function () {
				this.providerClass.hookup();
			},
			
			/**
			* Отвечает на входящий звонок.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#answerCall
	 		* @protected
	 		* @override
			*/
			answerCall: function() {
				this.providerClass.answerCall();
			},
			
			/**
			* Ставит или снимает звонок с удержания.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#answerCall
	 		* @protected
	 		* @override
			*/
			holdCall: function() {
				this.providerClass.holdCall();
			},
			
			/**
			* Завершает звонок.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#answerCall
	 		* @protected
	 		* @override
			*/
			dropCall: function() {
				this.providerClass.dropCall();
			},
			
			/**
			* Подготавливает звонок к переводу.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#setupTransferCall
	 		* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} Звонок.
			*/
			setupTransferCall: function(call) {
				this.providerClass.setupTransferCall(call);
			},
			
			/**
			* Совершает консультационный звонок.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#makeConsultCall
	 		* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} Звонок.
			* @param {String}  Номер абонента.
			*/
			makeConsultCall: function(scope, targetAddress) {
				this.providerClass.makeConsultCall(scope,targetAddress);
			},
			
			/**
			* Переводит звонок.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#transferCall
			* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} Звонок.
			* @param {String} Номер для перевода.
			* @param {Boolean} Включен ли слепой перевод.
			*/
			transferCall: function(scope, number, useBlindTransfer) {
				this.providerClass.transferCall(scope, number, useBlindTransfer);
			},
			
			/**
			* Отменяет перевод звонка.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#cancelTransfer
			* @protected
	 		* @override
			*/
			cancelTransfer: function() {
				this.providerClass.cancelTransfer();
			},
			
			/**
			* Слепой перевод звонка.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#blindTransferCall
			* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} звонок.
			* @param {String} номер абонента.
			*/
			blindTransferCall: function(scope, number) {
				this.providerClass.blindTransferCall(scope, number);
			},
			
			/**
			* Устанавливает состояние. Не использовать (Tapi).
			* @inheritdoc BPMSoft.BaseWebRTCProvider#setDnd
			* @protected
	 		* @override
			*/
			setDnd: function() {
				this.providerClass.setDnd();
			},

			/**
			* Prompts the line state.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#queryLineState
			* @protected
	 		* @override
			*/
			queryLineState: function() {
				this.providerClass.queryLineState();
			},

			/**
			* Запрашивает активные звонки.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#queryActiveCallSnapshot
			* @protected
	 		* @override
			*/
			queryActiveCallSnapshot: function() {
				this.providerClass.queryActiveCallSnapshot();
			},

			/**
			* Устанавливает статус оператора.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#setUserState
			* @protected
	 		* @override
			* @param {String} Код статуса.
			* @param {String} Причина смены статуса оператора(опцианально).
			* @param {Object} Функция обратного вызова(опционально).
			*/
			setUserState: function(code, reason, callback) {
				this.providerClass.setUserState(code, reason, callback);
			},

			/**
			* Устанавливает состояние постобработки.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#setWrapUpUserState
			* @protected
	 		* @override
			* @param {Boolean} Указывает на постобработку.
			* @param {Object} Функция обратного вызова(опционально).
			*/
			setWrapUpUserState: function(isWrapUpActive, callback) {
				this.providerClass.setWrapUpUserState(isWrapUpActive, callback);
			},

			/**
			* Определяет использование видео в звонке.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#setVideoState
			* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} Звонок.
			* @param {Boolean} Используется ли видео в звонке.
			* @param {Function} Функция обратного вызова.
			*/
			setVideoState: function(call, isVideoActive, callback) {
				this.providerClass.setVideoState();
			},

			/**
			* Устанавлиет состояние агента.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#queryUserState
			* @protected
	 		* @override
			*/
			queryUserState: function() {
				this.providerClass.queryUserState();
			},

			/**
			* Отправляет код Dtmf.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#sendDtmf
			* @protected
	 		* @override
			* @param {BPMSoft.Telephony.Call} Звонок.
			* @param {String} Цифры для Dtmf.
			*/
			sendDtmf: function(scope, number) {
				this.providerClass.sendDtmf(scope, number);
			},
			
			/**
			* Отключает микрофон.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#mute
			* @protected
	 		* @override
			*/
			mute: function() {
				this.providerClass.mute();
			},

			/**
			* Получает запись разговора.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#queryCallRecords
			* @protected
	 		* @override
			* @param {String} callId Caller ID.
			* @param {Function} Функция обратного вызова.
			*/
			queryCallRecords: function(callId, callback) {
				var scope = this;
				var jsonData = `\"${callId}\"`;
				BPMSoft.AjaxProvider.request({
					url: this.callRecordServiceUrl + this.callRecordMethodName,
					scope: this,
					headers: {
						"Content-Type": "application/json",
						"Accept": "application/json"
					},
					method: "POST",
					callback: function (request, success, response) {
						if (success) {
							scope.getRecordLink(scope, response, callback);
						}
						else {
							window.console.warn(this.localizableStrings.GetRecordMessageConsoleError + response.responseText);
						}
					},
					jsonData: jsonData
				});				
			},
			
			/**
			* Обрабатывает ответ сервиса получения записи звонка.
			* @protected
			* @param {BPMSoft.Telephony.Call} Звонок.
			* @param {Object} Ответ сервиса.
			* @param {Function} Функция обратного вызова.
			*/
			getRecordLink: function (scope, response, callback) {
				var result = JSON.parse(response.responseText);
				if (result.ErrorLastMessage === "")
				{
					result.CallRecordLink ? callback.call(scope, [result.CallRecordLink]) : window.console.warn(this.localizableStrings.CallRecordNotFoundError);
					if (!Ext.isEmpty(result.CallRecordLink)) {
						callback.call(scope, [result.CallRecordLink]);
					}
				}
				else {
					window.console.warn(this.localizableStrings.GetRecordMessageConsoleError + result.ErrorLastMessage);
				}
			},

			/**
			* Меняет статус Call Center.
			* @inheritdoc BPMSoft.BaseWebRTCProvider#changeCallCentreState
			* @protected
	 		* @override
			* @param {Boolean} Статус пользователя в Call Center.
			*/
			changeCallCentreState: function(isActive) {
				this.providerClass.changeCallCentreState(isActive);
			},
			
			getCapabilities: function() {
				return this.providerClass.getCapabilities();
			}
		});
	return BPMSoft.integration.telephony.uis.UisCtiProvider;
	}
);