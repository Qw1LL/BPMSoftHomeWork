define("SectionActionsDashboard", ["SectionActionsDashboardResources", "SocialMessagePublisherModule"],
	function(resources) {
		return {
			attributes: {},
			messages: {},
			methods: {

				//region methods: protected

				/**
				 * Returns ESN channel button visibility.
				 * @protected
				 * @return {Boolean} ESN channel button visibility.
				 */
				getEsnChannelVisible: function() {
					return this.getExtraActionDashboadTabVisible();
				},

				/**
				 * @inheritdoc BPMSoft.ActionsDashboard#getExtendedConfig
				 * @overridden
				 */
				getExtendedConfig: function() {
					var config = this.callParent(arguments);
					var lczImages = resources.localizableImages;
					config.SocialMessageTab = {
						"ImageSrc": this.BPMSoft.ImageUrlBuilder.getUrl(lczImages.SocialMessageTabImage),
						"MarkerValue": "social-message-tab",
						"Align": this.BPMSoft.Align.RIGHT,
						"Visible": this.getEsnChannelVisible(),
						"Tag": "Social"
					};
					return config;
				},

				/**
				 * @inheritdoc BPMSoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @overridden
				 */
				getSectionPublishers: function() {
					var publishers = this.callParent(arguments);
					publishers.push("Social");
					return publishers;
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SocialMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialMessageTabContainer",
					"parentName": "SocialMessageTab",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"classes": {
							"wrapClassName": ["social-message-content"]
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "SocialMessageModule",
					"parentName": "SocialMessageTab",
					"propertyName": "items",
					"values": {
						"classes": {
							"wrapClassName": ["social-message-module", "message-module"]
						},
						"itemType": this.BPMSoft.ViewItemType.MODULE,
						"moduleName": "SocialMessagePublisherModule",
						"afterrender": {
							"bindTo": "onMessageModuleRendered"
						},
						"afterrerender": {
							"bindTo": "onMessageModuleRendered"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
