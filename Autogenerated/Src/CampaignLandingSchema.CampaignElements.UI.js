/**
 * Schema of campaign landing element.
 */
define("CampaignLandingSchema", ["CampaignLandingSchemaResources", "CampaignEnums",
		"CampaignBaseAudienceSchema"],
	function(resources, CampaignEnums) {
		/**
		 * @class BPMSoft.manager.CampaignLandingSchema
		 * Schema of base communication element.
		 */
		Ext.define("BPMSoft.manager.CampaignLandingSchema", {
			extend: "BPMSoft.CampaignBaseElementSchema",
			alternateClassName: "BPMSoft.CampaignLandingSchema",

			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin"
			},

			/**
			 * UId of current manager item.
			 */
			managerItemUId: "7D2A5E47-415A-49DD-A311-3A11FEC1D553",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#name
			 */
			name: "CampaignLanding",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#caption
			 */
			caption: resources.localizableStrings.Caption,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#TitleImage
			 */
			titleImage: resources.localizableImages.TitleImage,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#LargeImage
			 */
			largeImage: resources.localizableImages.LargeImage,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#SmallImage
			 */
			smallImage: resources.localizableImages.SmallImage,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
			 */
			editPageSchemaName: "CampaignLandingPage",

			/**
			 * Type of element
			 * @type {string}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_LANDING,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @protected
			 * @overridden
			 */
			typeName: "BPMSoft.Configuration.CampaignLandingElement, BPMSoft.Configuration",

			/**
			 * Background fill color.
			 * @protected
			 * @type {String}
			 */
			color: "rgba(247, 194, 0, 1)",

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
			 * @overridden
			 */
			width: 55,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
			 * @overridden
			 */
			height: 55,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#nodeType
			 * @override
			 */
			nodeType: BPMSoft.diagram.UserHandlesConstraint.Gateway,

			/**
			 * Identifier of the landing page
			 */
			landingId: null,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
			 * @overridden
			 */
			getConnectionUserHandles: function() {
				return ["CampaignSequenceFlow", "LandingConditionalTransition"];
			},

			/**
			 * Clears linked landing when element copy is created.
			 * @inheritdoc BPMSoft.manager.CampaignBaseElementSchema#prepareCopy
			 * @overridden
			 */
			prepareCopy: function() {
				var copy = this.callParent(arguments);
				copy.landingId = null;
				return copy;
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableProperties: function() {
				var baseSerializableProperties = this.callParent(arguments);
				return Ext.Array.push(baseSerializableProperties, ["landingId"]);
			},
			
			/**
			 * @inheritdoc CampaignBaseElementSchema#validate
			 * @override
			 */
			validate: function() {
				var results = Ext.create("BPMSoft.Collection");
				if (this.getIncomingSequenceFlows().length === 0) {
					results.add(CampaignEnums.CampaignFlowSchemaValidationRules.ASYNC_WITHOUT_INCOMINGS,
						resources.localizableStrings.AsyncWithoutIncomingsMessage);
				}
				return results;
			}
		});
		return BPMSoft.CampaignLandingSchema;
	});
