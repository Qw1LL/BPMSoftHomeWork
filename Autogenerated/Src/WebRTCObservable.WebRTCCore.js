 define("WebRTCObservable", [], 
	function() {
		 /**
		 * @class BPMSoft.integration.telephony.basewebrtc.WebRTCObservable
		 * Класс наблюдателя событий WebRTC.
		 */
		Ext.define("BPMSoft.integration.telephony.basewebrtc.WebRTCObservable", {
			extend: "BPMSoft.core.BaseObject",
			handlers: null,
			constructor: function() {
				this.removeAllHandlers();
			},
			
			/**
			* Удаляет все слушатели
	 		*/
			removeAllHandlers: function() {
        		this.handlers = {};
			},
			
			/**
			* Подписка нового слушателя
	 		*/
    		on: function(eventName, handler) {
        		(Array.isArray(eventName) ? eventName : [eventName]).forEach(eventName =>
            	this.getHandlers(eventName).push(handler));
    		},
			
			/**
			* Получение всех обработчиков ивента
	 		*/
   			getHandlers: function(eventName) {
        		if (!this.handlers[eventName]) {
            		this.handlers[eventName] = [];
        		}

        		return this.handlers[eventName];
    		},
			
			/**
			* Отправка ивента
	 		*/
    		fireEvent: function(eventName, ...args) {
       			this.fireEventWithCallback(eventName, () => null, ...args);
    		},
			
			/**
			* Отправка ивента с функцией обратного вызова
	 		*/
    		fireEventWithCallback: function(eventName, callback, ...args) {
        		this.getHandlers(eventName).forEach(handler => callback(handler.apply(null, args)));
    		}
	});
	 return BPMSoft.integration.telephony.basewebrtc.WebRTCObservable;
 });
