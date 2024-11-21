define("MainHeaderSchema", ["IconHelper",
			"IntroPageUtilities", "ConfigurationConstants", "css!MainHeaderCSS", "CheckModuleDestroyMixin", "css!WSFieldsManagementStyles"],
		function(iconHelper, IntroPageUtilities, ConfigurationConstants) {
			return {
				attributes: {},
				messages: {},
				mixins: {},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent(arguments);
						
		            	var $this = this;
						var config = {"attributes": true};
						var observer = new MutationObserver(mutationEvent);
						
						function mutationEvent(mutationsList) {
						    for(var mutation of mutationsList) if (mutation.type == 'attributes') {
								var mainContentWrapper = document.getElementsByTagName("body");
								
								if (mainContentWrapper){
									
									var windowHash = window.location.hash;
									for (var i = 0; i < mainContentWrapper.length; i++) {
										if (windowHash.indexOf('WSPattern1Page') != -1){
											if (!document.body.classList.contains('no-use-backwards-filter')) {
												mainContentWrapper[i].classList.add("no-use-backwards-filter");
											}
										} else {
											if (document.body.classList.contains('no-use-backwards-filter')) {
												mainContentWrapper[i].classList.remove("no-use-backwards-filter");
											}
										}
									}
								}
						    }
						};
						
						observer.observe(document.querySelector('body'), config);
					},
				},
				diff: []
			};
		}
);
