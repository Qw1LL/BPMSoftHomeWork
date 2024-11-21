 define("WebRTCSession", ["WebRTCObservable"], 
	function(Observable) {
	 	
	 	/**
		 * @class BPMSoft.integration.telephony.basewebrtc.WebRTCSession
		 * Класс сессии WebRTC .
		 */
		Ext.define("BPMSoft.integration.telephony.basewebrtc.WebRTCSession", {
			extend: "BPMSoft.core.BaseObject",
			
			session: null,
    		createCallOptions: null,
    		observable: null,
			log: function () {},
			
			constructor: function({
        		session,
        		observable,
        		createCallOptions,
        		log
    		}) {
        		this.session = session;
        		this.createCallOptions = createCallOptions;

        		const close = this.session._close.bind(this.session);

        		this.session._close = (...args) => {
            		session.connection && session.connection.getStats().then(stats => this.log(
               			'Connection statistics:',
                		Array.from(stats.entries()).reduce(
                	    	(stats, [key, value]) => ((stats[key] = value), stats),
							{}
                		)
           			));
	
            		const value = close(...args);
            		return value;
        		};

        		this.session.on('progress', event =>
            	observable.fireEvent('progress', event));
        		this.session.on('confirmed', () => observable.fireEvent('confirmed'));
        		this.session.on('ended', () => observable.fireEvent('ended'));

        		this.session.on('failed', event => {
            		event && event.cause == 'User Denied Media Access' && observable.fireEvent('getusermediafailed');
            		observable.fireEvent('failed', event);
        		});

        		this.session.on('accepted', () => observable.fireEvent('accepted'));
				this.session.on('hold', () => observable.fireEvent('hold'));
				this.session.on('unhold', () => observable.fireEvent('unhold'));
				this.session.on('muted', () => observable.fireEvent('muted'));
				this.session.on('unmuted', () => observable.fireEvent('unmuted'));
				this.session.on('connecting', () => observable.fireEvent('connecting'));
				
        		this.observable = observable;
    		},
			/**
   			 * @property {id} [string] уникальный идентификатор сессии
   			 */
   			getId: function() {
   			    return this.session.id;
   			},
   			/**
   			 * @property {callId} [string] Значение заголовка Call-ID
   			 */
   			getCallId: function() {
   			    return this.session._request.call_id;
   			},
   			/**
   			 * @property {direction} [Direction] направление звонка
   			 */
   			getDirection: function() {
   			    return this.session.direction;
   			},
   			/**
   			 * @property {remoteUserName} [string] номер телефона позвонившего или вызываемого
   			 */
   			getRemoteUserUri: function() {
   			    return this.session.remote_identity.uri.user;
   			},
   			/**
   			 * @property {remoteUri} [string] URI позвонившего или вызываемого
   			 */
   			getLocalUserUri: function() {
   			    return this.session.local_identity.uri.user;
   			},
   			/**
   			 * @property {isMuted} [boolean] true, если микрофон выключен
   			 */
   			getIsMuted: function() {
   			    return this.session.isMuted().audio;
   			},
   			/**
   			 * @property {connection} [RTCPeerConnection]
   			 */
   			getConnection: function() {
   			    return this.session._connection;
   			},
   			/**
   			 * Отвечает на входящий звонок
   			 *
   			 * @param {mediaConstraints} [MediaStreamConstraints]
   			 */
   			answer: function(mediaConstraints) {
   			    this.session.answer(mediaConstraints);
   			},
			
			/**
   			 * Ставит на удержание текущий звонок
   			 */
			hold: function() {
				this.session.hold();
			},
			
			/**
   			 * Снимает с удержания текущий звонок
   			 */
			unhold: function() {
				this.session.unhold();
			},
				
   			/**
   			 * Завершает звонок
   			 */
   			terminate: function() {
   			    this.session.terminate();
   			},
			
			/**
   			 * Переводит текущий звонок по номеру
			 * @param {target} [string] номер, куда переведется звонок
			 *  	  {options} [Object] дополнительные параметры перевода 
   			 */
			refer: function(target, options) {
				this.session.refer(target, options);
			},
				
   			/**
   			 * Отправляет DTMF
   			 *
   			 * @param {dtmf} [string] DTMF-сообщение которое нужно отправить. Например "#1234" для перевода звонка на номер
   			 * 1234.
   			 */
   			sendDTMF: function(dtmf) {
   			    this.session.sendDTMF(dtmf);
   			},
			
			/**
   			 * Проверяет поставлен ли текущий звонок на удержание
   			 */
			isOnHold: function() {
				return this.session.isOnHold();
			},
			
			/**
   			 * Выключает микрофон
   			 */
			mute: function(audio, video) {
				this.session.mute({audio: audio, video: video});
			},
			
			/**
   			 * Включает микрофон
   			 */
			unmute: function(audio, video) {
				this.session.unmute({audio: audio, video: video});
			},
			
			/**
   			 * Проверяет текущее состояние микрофона
   			 */
			isMuted: function() {
				return this.session.isMuted();
			},
   			/**
   			 * @param {eventsName} [SessionEventName] название события
   			 *
   			 * @param {SessionEventHandler} [handler] обработчик события
   			 */
   			on: function(eventName, handler) {
				this.observable.on(eventName, handler);
   			}
	});
	return BPMSoft.integration.telephony.basewebrtc.WebRTCSession;
});