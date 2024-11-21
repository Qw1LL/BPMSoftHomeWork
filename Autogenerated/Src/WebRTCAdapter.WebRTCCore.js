define("WebRTCAdapter", ["JsSipLibrary", "WebRTCObservable", "WebRTCSession"], 
	function(JsSIP, Observable, Session) {
		 /**
		 * @class BPMSoft.integration.telephony.basewebrtc.WebRTCObservable
		 * Класс адаптер WebRTC на основе JSSIP.
		 */
		Ext.define("BPMSoft.integration.telephony.basewebrtc.WebRTCAdapter", {
			extend: "BPMSoft.core.BaseObject",
			
			observable: null,
			iceServers: null,
			channelsCount: null,
			ua: null,
			log: null,
			instaniated: false,
			debugMode: false,
			
			constructor: function({
			    userAgent,
			    uri,
			    contactUri,
			    authorizationUser,
			    password,
			    webSocketUrl,
			    iceServers,
			    channelsCount,
			    connectionRecoveryMaxInterval,
			    connectionRecoveryMinInterval,
			    log,
				debugMode
			}) {
  		      		
		  
				this.observable = new Observable();
				this.iceServers = iceServers;
				this.channelsCount = channelsCount;
				this.log = log || function(e){};
				this.debugMode = debugMode;
				this.debug();
				instaniated = true;
		  
  		      	const config = {
  		      	    uri,
  		      	    password,
  		      	    sockets: (Array.isArray(webSocketUrl) ? webSocketUrl : [webSocketUrl]).map(
  		      	        url => typeof url == 'string' ? {url, weight: 0} : url
  		      	    ).map(({url, weight}) => {
  		      	        const socket = new JsSIP.WebSocketInterface(url),
  		      	            {connect} = socket;
		  	
  		      	        socket.connect = () => {
  		      	            connect.call(socket);
		  	
  		      	            if (!socket._ws) {
  		      	                return;
  		      	            }
		  	
  		      	            this.observable.fireEvent('webSocketCreated', url, socket._ws);
  		      	        };
		  	
  		      	        return {socket, weight};
  		      	    }, []),
					register_expires: 60,
					connection_recovery_max_interval: connectionRecoveryMaxInterval,
					connection_recovery_min_interval: connectionRecoveryMinInterval,
					user_agent: localStorage.getItem('rmo:user_agent') || undefined
  		      	};
		  
  		      contactUri && (config.contact_uri = contactUri);
  		      authorizationUser && (config.authorization_user = authorizationUser);
  		      userAgent && (config.user_agent = userAgent);
  		      this.ua = new JsSIP.UA(config);
		  
  		      this.ua.on('newRTCSession', ({session}) => {
  		          if (Object.keys(this.ua._sessions).length > this.channelsCount) {
  		              session.terminate({
  		                  cause: 'Busy',
  		                  status_code: 486
  		              });
  		          } else {
  		              const observable = new Observable();
			  	let jsipSession = new Session({
  		                  session,
  		                  observable,
  		                  createCallOptions: this.createCallOptions,
  		                  log
  		              });
  		              this.observable.fireEvent('newRTCSession', jsipSession);
		  
  		              session.direction == 'outgoing' && observable.fireEvent('sending');
  		          }
  		      });
		  
  		      this.ua.on('registered', () => this.observable.fireEvent('registered'));
  		      this.ua.on('registrationFailed', error => {
  		          (!error || error.cause != 'Connection Error') && this.observable.fireEvent('failed');
  		      });
  		      this.ua.on('disconnected', () => this.observable.fireEvent('disconnected'));
  		      this.ua.on('connected', () => this.observable.fireEvent('connected'));
  		    },
			
  		  	/**
  		  	 * Открывает сокет и регистрируется
  		  	 */
  		  	start: function() {
  		  	    this.ua.start();
  		  	},
  		  	/**
  		  	 * Делает регистрацию исчерпанной и закрывает сокет
  		  	 */
  		  	stop: function() {
  		  	    this.ua.stop();
  		  	    this.observable.removeAllHandlers();
  		  	},
  		  	/**
  		  	 * Совершает исходящий звонок
  		  	 *
  		  	 * @param {uri} [string] URI такого вида `sip:${phone}@${sip_host}`, где phone это номер телефона на который должен
  		  	 * быть совершен звонок
  		  	 *
  		  	 * @param {mediaConstraints} [MediaStreamConstraints]
  		  	 *
  		  	 * @param {mediaStream} [MediaStream] аудио-поток
  		  	 */
  		  	call: function(uri, options) {
  		  	    return this.ua.call(uri, options);
  		  	},
			
			createCallOptions: function (mediaOptions, mediaStream) {
				return {
					mediaConstraints: mediaOptions,
					mediaStream: mediaStream,
					pcConfig: {
  		              		iceServers: this.iceServers,
  		              		rtcpMuxPolicy: 'negotiate',
							hackStripTcp: true,
  		          		}
				};
			},
			  
  		  	/**
  		  	 * @param {eventName} [AdapterEventName] название события.
  		  	 *
  		  	 * @param {handler} [AdapterEventHandler] обработчик события
  		  	 */
  		  	on: function(eventName, handler) {
  		  	    this.observable.on(eventName, handler);
  		  	},
  		  	/**
  		  	 * Включает режим отладки
  		  	 */
  		  	debug: function() {
  		    	if (!this.debugMode) {
					JsSIP.debug.disable('JsSIP:*');
					return;
  		    	}
		  
  		    	JsSIP.debug.enable('JsSIP:*');
  		    	this.debugMode = true;
  		  	}
	});
	return BPMSoft.integration.telephony.basewebrtc.WebRTCAdapter;
});