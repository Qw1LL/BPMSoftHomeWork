/**
 * Schema of campaign add to event element.
 */
define("CampaignAddToEventSchema", ["CampaignAddToEventSchemaResources", "CampaignEnums",
		"CampaignBaseEventSchema"],
	function(resources, CampaignEnums) {
		/**
		 * @class BPMSoft.manager.CampaignAddToEventSchema
		 * Schema of add to event element.
		 */
		Ext.define("BPMSoft.manager.CampaignAddToEventSchema", {
			extend: "BPMSoft.CampaignBaseEventSchema",
			alternateClassName: "BPMSoft.CampaignAddToEventSchema",

			/**
			 * UId of current manager item.
			 */
			managerItemUId: "233d5c17-4274-445e-af00-5bf68afc4e4e",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#name
			 */
			name: "CampaignAddToEvent",

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
			 * Type of element
			 * @type {string}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_EVENT,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @protected
			 * @override
			 */
			typeName: "BPMSoft.Configuration.CampaignAddToEventElement, BPMSoft.Configuration",

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
			 */
			editPageSchemaName: "CampaignAddToEventPage",

			/**
			 * Background fill color.
			 * @protected
			 * @type {String}
			 */
			color: "rgba(131, 157, 195, 1)",

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
			 * @override
			 */
			width: 69,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#nodeType
			 * @override
			 */
			nodeType: BPMSoft.diagram.UserHandlesConstraint.Node,

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
		return BPMSoft.CampaignAddToEventSchema;
	});
