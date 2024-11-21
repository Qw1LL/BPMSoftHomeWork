define("SocialChannelSectionV2", [],
		function() {
			return {
				entitySchemaName: "SocialChannel",
				columns: {},
				messages: {
					"CanSubscribe": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				methods: {
					getAddRecordButtonCaption: function() {
						return this.get("Resources.Strings.AddChannel");
					},

					/**
					 * ############# ######## ## ######### CanSubscribe ## ########
					 */
					initCanSubscribeChangedHandler: function() {
						var me = this;
						this.sandbox.subscribe("CanSubscribe", function(config) {
							me.set(config.key, config.value);
						});
					},

					/**
					 * #############
					 * @overridden
					 */
					init: function() {
						this.initCanSubscribeChangedHandler();
						this.callParent(arguments);
					},

					/**
					 * @overridden
					 */
					initContextHelp: function() {
						this.set("ContextHelpId", 1037);
						this.callParent(arguments);
					},

					/**
					 * ######### ######### #######
					 * @overridden
					 */
					getDefaultGridDataViewCaption: function() {
						return this.get("Resources.Strings.GridDataViewCaption");
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "CombinedModeActionButtonsCardLeftContainer",
						"propertyName": "items",
						"name": "SubscribeChannelButton",
						"index": 0,
						"values": {
							itemType: this.BPMSoft.ViewItemType.BUTTON,
							caption: {
								bindTo: "Resources.Strings.SubscribeButtonCaption"
							},
							click: {bindTo: "onCardAction"},
							visible: {bindTo: "ToSubscribe"},
							classes: {textClass: ["actions-button-margin-right"]},
							tag: "onSubscribeChannelClick"
						}
					},
					{
						"operation": "insert",
						"parentName": "CombinedModeActionButtonsCardLeftContainer",
						"propertyName": "items",
						"name": "UnsubscribeChannelButton",
						"index": 0,
						"values": {
							itemType: this.BPMSoft.ViewItemType.BUTTON,
							caption: {
								bindTo: "Resources.Strings.UnsubscribeButtonCaption"
							},
							click: {bindTo: "onCardAction"},
							visible: {bindTo: "ToUnsubscribe"},
							classes: {textClass: ["actions-button-margin-right"]},
							tag: "onUnsubscribeChannelClick"
						}
					}
				]/**SCHEMA_DIFF*/,
				userCode: {}
			};
		});
