 define("PageUpdateBlocker", ["jquery"], 
	function() {
    Ext.define("BPMSoft.integration.telephony.basewebrtc.PageUpdateBlocker", {
			extend: "BPMSoft.core.BaseObject",
			
			/*
			* Локализируемые строки.
			*/
			localizableStrings: {},
		
			constructor: function () {
				 var scope = this;
				
				// Добавление ресурсов. Стандартными способами не работает.
				require(["PageUpdateBlockerResources"], function(module) {
					if (module) {
						scope.localizableStrings = module.localizableStrings;
					}
				});
				
				 this.unload = function(evt) {
        			return scope.localizableStrings.ClosePageWarningMessage;
    			};
				
    			this.resetUnload = function() {
    			    $(window).off('beforeunload', scope.unload);
					setTimeout(function(){
    			        $(window).on('beforeunload', scope.unload);
    			    }, 1000);
    			};
 			
    			this.init = function() {
        			$(window).on('beforeunload', scope.unload);
        			$('a').on('click', scope.resetUnload);
        			$(document).on('submit', 'form', scope.resetUnload);
					// F5 и Ctrl+F5, Enter
					$(document).on('keydown', function(event){
						if((event.ctrlKey && event.keyCode == 116) || event.keyCode == 116 || event.keyCode == 13){
							if(confirm(scope.localizableStrings.ClosePageWarningMessage)){
								scope.resetUnload();
							} else {
								return false;
							}
						}
					});    
    			};
    			this.init();
			},
		
			destructor: function() {
				$(window).off('beforeunload');
				$('a').off('click');
				$(document).off('submit', 'form');
				$(document).off('keydown');
			}
	});
	 return BPMSoft.integration.telephony.basewebrtc.PageUpdateBlocker;
 });