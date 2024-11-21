 define("InfinityCtiProvider", ["css!InfinityCtiProvider"],
	function() {
		Ext.ns("BPMSoft.integration");
		Ext.ns("BPMSoft.integration.telephony");
		Ext.ns("BPMSoft.integration.telephony.infinity");

		/**
		 * @class BPMSoft.integration.telephony.infinity.InfinityCtiProvider
		 * Class of infinity provider.
		 */
		Ext.define("BPMSoft.integration.telephony.infinity.InfinityCtiProvider", {
			extend: "BPMSoft.BaseCtiProvider",
			alternateClassName: "BPMSoft.InfinityCtiProvider",
			singleton: !0,
			
			/**
			* Шаблон ссылки получения записи звонка.
			*/
			callRecordURLTemplate: "",
			
			/**
			* Адрес сервиса телефонии.
			*/
   			serviceUrl: "",
			
			/**
			* URL подключения.
			*/
			webServiceURL: "",
			
			/**
			* Служебный канал.
			*/
   			serviceChannel: null,
			
			/**
			* UId экземпляра библиотеки.
			*/
   			libraryInstanceUId: "",
			
			/**
			* UId соединения.
			*/
   			connectionUId: "",
			
			/**
			* Обработчик закрытия соединения.
			*/
   			channelClosedHandler: function() {
   			    this.log("Messaging service channel closed"),
   			    this.fireEvent("disconnected", this)
   			},
			
			/**
			* Процесс обработки сообщений канала.
			*/
   			processMsg: function(e) {
   			    if (this.fireEvent("rawMessage", e),
   			    Ext.isObject(e) && Ext.isNumber(e.eventType)) {
   			        var t = Ext.create("BPMSoft.MsgEventInfo", e);
   			        if (t.eventType !== BPMSoft.MsgEventType.NONE) {
   			            var r, n = t.content, i = t.privateData;
   			            switch (t.eventType) {
   			            case BPMSoft.MsgEventType.LIBRARY_INITIALIZED:
   			                this.libraryInstanceUId = n,
   			                this.initializeConnection(this.initialConfig);
   			                break;
   			            case BPMSoft.MsgEventType.CONNECTION_CREATED:
   			                this.connectionUId = t.connectionUId,
   			                this.fireEvent("initialized", i);
   			                break;
   			            case BPMSoft.MsgEventType.ERROR:
   			                this.fireEvent("error", BPMSoft.decode(n), i);
   			                break;
   			            case BPMSoft.MsgEventType.COMMAND_INFO:
   			                this.fireEvent("commandExecuted", n, i);
   			                break;
   			            case BPMSoft.MsgEventType.RING_STARTED:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("callStarted", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.RING_FINISHED:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("callFinished", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.COMMUTATION_STARTED:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("commutationStarted", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.PUT_HOLD_ACTION:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("hold", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.END_HOLD_ACTION:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("unhold", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.ACTIVE_CALL_SNAPSHOT:
   			                this.fireEvent("activeCallSnapshot", BPMSoft.decode(n), i);
   			                break;
   			            case BPMSoft.MsgEventType.LINE_STATE_CHANGED:
   			                this.fireEvent("lineStateChanged", BPMSoft.decode(n), i);
   			                break;
   			            case BPMSoft.MsgEventType.AGENT_STATE_CHANGED:
   			                this.fireEvent("agentStateChanged", {
   			                    userState: BPMSoft.decode(n)
   			                }, i);
   			                break;
   			            case BPMSoft.MsgEventType.ABONENT_BUSY:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("callBusy", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.DISCONNECTED:
   			                var a = BPMSoft.decode(n);
   			                this.fireEvent("disconnected", a, i);
   			                break;
   			            case BPMSoft.MsgEventType.CALL_SAVED_IN_DB:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("callSaved", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.CALL_INFO_CHANGED:
   			                r = Ext.create("BPMSoft.integration.telephony.Call", BPMSoft.decode(n)),
   			                this.fireEvent("callInfoChanged", r, i);
   			                break;
   			            case BPMSoft.MsgEventType.DTMF_ENTERED:
   			                this.fireEvent("dtmfEntered", BPMSoft.decode(n), i)
   			            }
   			        }
   			    }
   			},
			
			/**
			* Обработчик сообщений канала.
			*/
   			channelMsgHandler: function(e, t) {
   			    try {
   			        var r = Ext.decode(t);
   			        this.processMsg(r)
   			    } catch (e) {
   			        this.logError("Processing msg exception:" + e)
   			    }
   			},
			
			/**
			* Обработчик открытия канала
			*/
   			channelOpenedHandler: function() {
   			    this.log("Messaging service channel created"),
   			    this.initializeLibrary(this.initialConfig)
   			},
			
			/**
			* Отправка вызова.
			*/
   			postCallCommand: function(e, t, r) {
   			    var n = {
   			        commandExecutor: e,
   			        parameters: r
   			    };
   			    this.postCommand(t, n)
   			},
			
			/**
			* Инициализация канала подключения.
			*/
   			_initServiceChannel: function(e) {
				this.getCallRecordURLTemplate();
   			    var t = e.startsWith("http") ? "BPMSoft.SignalRChannel" : "BPMSoft.WebSocketChannel";
   			    return this.serviceChannel = Ext.create(t, {}),
   			    this.serviceChannel.serviceUrl = e,
   			    this.serviceUrl = e,
   			    this.serviceChannel
   			},
			
			/**
			* Initializes module.
			*/
   			init: function(e) {
   			    this.callParent(arguments);
   			    var t = this._initServiceChannel(e.msgServiceUrl);
   			    t.close(),
   			    t.init(),
   			    t.on(BPMSoft.EventName.ON_CONNECTION_INITIALIZED, this.channelOpenedHandler, this),
   			    t.on(BPMSoft.EventName.ON_MESSAGE, this.channelMsgHandler, this),
   			    t.on(BPMSoft.EventName.ON_CHANNEL_CLOSED, this.channelClosedHandler, this)
   			},
			
			/**
			* Отправить команду
			*/
   			postCommand: function(e, t) {
   			    if (this.serviceChannel.getConnectionState() !== BPMSoft.SocketConnectionState.OPEN) {
   			        var r = BPMSoft.Resources.Telephony.Exception.SocketConnectionChannelIsNotOpened;
   			        throw this.logError(r);
   			        new BPMSoft.InvalidObjectState(r);
   			    }
   			    t = t || {};
   			    var n = Ext.create("BPMSoft.MsgCommandInfo", {
   			        command: e,
   			        parameters: t.parameters,
   			        libraryInstanceUId: this.libraryInstanceUId,
   			        connectionUId: this.connectionUId,
   			        commandExecutor: t.commandExecutor
   			    });
   			    Ext.isObject(t.commandExecutor) && (n.commandExecutorId = t.commandExecutor.id,
   			    Ext.getClassName(t.commandExecutor) === Ext.getClassName(BPMSoft.integration.telephony.Call) && (n.commandExecutorType = BPMSoft.MessagingCommandExecutorType.CALL,
   			    n.commandExecutor = t.commandExecutor.serialize()));
   			    var i = n.serialize();
   			    this.serviceChannel.postRawMessage(i),
   			    this.log(i)
   			},
			
			/**
			* Иницализация библиотеки.
			*/
   			initializeLibrary: function(e) {
   			    var t = {
   			        parameters: {
   			            AssemblyName: e.library
   			        }
   			    };
   			    this.postCommand(BPMSoft.CtiCommand.LOAD_LIBRARY, t)
   			},
			
			/**
			* Инициализация соединения.
			*/
   			initializeConnection: function(e) {
   			    var t = {
   			        parameters: {
   			            connectionParams: BPMSoft.encode(e.connectionConfig),
   			            sessionServiceParams: BPMSoft.encode(e.sessionServiceParams)
   			        }
   			    };
   			    this.postCommand(BPMSoft.CtiCommand.OPEN_CONNECTION, t)
   			},
			
			/**
			* Закрыть соединение.
			*/
   			closeConnection: function() {
   			    this.postCommand(BPMSoft.CtiCommand.CLOSE_CONNECTION)
   			},
			
			/**
			* Сделать звонок.
			*/
   			makeCall: function(e) {
   			    this.postCommand(BPMSoft.CtiCommand.MAKE_CALL, {
   			        parameters: {
   			            targetAddress: e
   			        }
   			    })
   			},
			
			/**
			* Соденение.
			*/
   			hookup: function() {
   			    this.postCommand(BPMSoft.CtiCommand.HOOKUP)
   			},
			
			/**
			* Ответить на звонок.
			*/
   			answerCall: function(e) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.ANSWER_CALL)
   			},
			
			/**
			* Удержание звонка.
			*/
   			holdCall: function(e) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.HOLD_CALL)
   			},
			
			/**
			* Сбросить звонок.
			*/
   			dropCall: function(e) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.DROP_CALL)
   			},
			
			/**
			* Установка перевода звонка.
			*/
   			setupTransferCall: function(e) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.SETUP_TRANSFER_CALL)
   			},
			
			/**
			* Сделать консультационный звонок.
			*/
   			makeConsultCall: function(e, t) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.MAKE_CONSULT_CALL, {
   			        targetAddress: t
   			    })
   			},
			
			/**
			* Перевести звонок.
			*/
   			transferCall: function(e, t) {
   			    var r = Ext.getClassName(t) === Ext.getClassName(BPMSoft.integration.telephony.Call) ? t.serialize() : BPMSoft.encode(t);
   			    this.postCallCommand(e, BPMSoft.CtiCommand.TRANSFER_CALL, {
   			        consultationCall: r
   			    })
   			},
			
			/**
			* Отменить звонок.
			*/
   			cancelTransfer: function(e, t) {
   			    var r = e.serialize();
   			       n = t.serialize();
   			    this.postCommand(BPMSoft.CtiCommand.CANCEL_TRANSFER, {
   			        parameters: {
   			            currentCall: r,
   			            consultCall: n
   			        }
   			    })
   			},
			
			/**
			* Слепой перевод звонка.
			*/
   			blindTransferCall: function(e, t) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.BLIND_TRANSFER_CALL, {
   			        targetAddress: t
   			    })
   			},
			
			/**
			* Установить режим не беспокоить.
			*/
   			setDnd: function() {
   			    this.postCommand(BPMSoft.CtiCommand.SET_DND)
   			},
			
			/**
			* Проверка состояния запроса.
			*/
   			queryLineState: function() {
   			    this.postCommand(BPMSoft.CtiCommand.QUERY_LINE_STATE)
   			},
			
			/**
			* Запрос на моментальный перевод звонка.
			*/
   			queryActiveCallSnapshot: function() {
   			    this.postCommand(BPMSoft.CtiCommand.QUERY_ACTIVE_CALL_SNAPSHOT)
   			},
			
			/**
			* Установка состояния пользователя.
			*/
   			setUserState: function(e, t, r) {
   			    var n = {
   			        code: e,
   			        reason: t || ""
   			    };
   			    this.postCommand(BPMSoft.CtiCommand.SET_MSG_USER_STATE, {
   			        parameters: n
   			    }),
   			    Ext.isFunction(r) && r.call(this)
   			},
			
			/**
			* Установка итговое состояние пользователя. 
			*/
   			setWrapUpUserState: function(e, t) {
   			    this.postCommand(BPMSoft.CtiCommand.SET_WRAP_UP_USER_STATE, {
   			        parameters: {
   			            isWrapUpActive: e
   			        }
   			    }),
   			    Ext.isFunction(t) && t.call(this)
   			},
			
			/**
			* Запрос состояния пользователя.
			*/
   			queryUserState: function() {
   			    this.postCommand(BPMSoft.CtiCommand.QUERY_MSG_USER_STATE)
   			},
			
			/**
			* Установка тонального сигнала.
			*/
   			sendDtmf: function(e, t) {
   			    this.postCallCommand(e, BPMSoft.CtiCommand.SEND_DTMF, {
   			        digits: t
   			    })
   			},
			
			/**
			* Получение списка достпных возможностей телефонии.
			*/
   			getCapabilities: function() {
   			    return {
   			        callCapabilities: 
						BPMSoft.CallFeaturesSet.CAN_RECALL | 
						BPMSoft.CallFeaturesSet.CAN_DIAL | 
						BPMSoft.CallFeaturesSet.CAN_DROP | 
						BPMSoft.CallFeaturesSet.CAN_ANSWER | 
						BPMSoft.CallFeaturesSet.CAN_HOLD | 
						BPMSoft.CallFeaturesSet.CAN_UNHOLD | 
						BPMSoft.CallFeaturesSet.CAN_COMPLETE_TRANSFER | 
						BPMSoft.CallFeaturesSet.CAN_BLIND_TRANSFER | 
						BPMSoft.CallFeaturesSet.CAN_MAKE_CONSULT_CALL | 
						BPMSoft.CallFeaturesSet.CAN_DTMF,
   			        agentCapabilities: BPMSoft.AgentFeaturesSet.CAN_GET_CALL_RECORDS
   			    }
   			},

			/**
			* Получение шаблона ссылки на скачивание звонка.
			*/
			getCallRecordURLTemplate: function() {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "TelephonyIntegration"
				});
				esq.addColumn("CallRecordLinkUrlTemplate");
				esq.addColumn("WebServiceURL");
				esq.filters.add("sysMsgLibFilter", esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"SysMsgLib.Id", BPMSoft.SysValue.CTI.sysMsgLibId));
				esq.getEntityCollection(function (result) {
					if (result.success) {
						if(result.collection.getItems().length !== 0) {
							this.callRecordURLTemplate = result.collection.getItems()[0].values.CallRecordLinkUrlTemplate;
							this.webServiceURL = result.collection.getItems()[0].values.WebServiceURL;
						} else {
							console.log("В объекте CallRecordLinkUrlTemplate отсутствует шаблон ссылки получения записи разговора.");
						}
					}
				}, this);
			},

			/**
			* Метод получения ссылки на скачивание звонка.
			*/
			queryCallRecords: function(callId, callback) {
				var callRecordUrl;
				var callRecordId;
				var scope = this;
				
				Ext.Ajax.request({
					//Get id to get the call record
    			    url: this.webServiceURL + "stat/connectionsbycall/?IDCall=" + callId + "&Recorded=1",
    			    success: function(response, options){
    			    	callRecordId = BPMSoft.decode(response.responseText).result.Connections[0];
						
						if(callRecordId) {
							if(scope.callRecordURLTemplate && callId) {
								callRecordUrl = scope.callRecordURLTemplate + callRecordId + "&codec=pcm";
							} else {
								console.error("Одно из значений пустое: callRecordURLTemplate, callId.");
							}
							callback([callRecordUrl]);
						} 
						else {
							console.error("Запись звонка отсуствует.");
							callback([]);
						} 
    			    },
    			    failure: function(response, options){
    			         console.error("Не удалось получить идентификатор записи звонка.");
    			    }
    			}); 
			},
		});
	}
);
