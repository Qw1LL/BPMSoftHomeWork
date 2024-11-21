define("CampaignBaseElementSchema", ["ext-base", "BPMSoft", "CampaignBaseElementSchemaResources",
	"CampaignElementMixin"], function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.manager.CampaignBaseElementSchema
	 * Schema of base campaign element.
	 */
	Ext.define("BPMSoft.manager.CampaignBaseElementSchema", {
		extend: "BPMSoft.ProcessFlowElementSchema",
		alternateClassName: "BPMSoft.CampaignBaseElementSchema",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement",
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		//region Properties: Protected

		managerItemUId: "5880fbc6-22c0-456c-8b0f-35133afdfc8f",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "CampaignElement",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.BaseAudienceCaption,

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
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
		 * @override
		 */
		width: 69,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
		 * @override
		 */
		height: 55,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#silverlightOffsetX
		 * @override
		 */
		silverlightOffsetX: 0,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#silverlightOffsetY
		 * @override
		 */
		silverlightOffsetY: 0,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#captionWidth
		 * @override
		 */
		captionWidth: 80,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: null,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Core.Campaign.CampaignSchemaElement",

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */
		fillColor: "",

		/**
		 * Count of campaign participants which have completed the step.
		 * @protected
		 * @type {Number}
		 */
		completedCount: 0,

		/**
		 * Count of campaign participants which have not completed the step.
		 * @protected
		 * @type {Number}
		 */
		nonCompletedCount: 0,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
		 * @override
		 */
		getConnectionUserHandles: function() {
			return ["CampaignSequenceFlow", "CampaignConditionalSequenceFlow"];
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getLocalizableValues
		 * @override
		 */
		getLocalizableValues: function(localizableValues) {
			this.callParent(arguments);
			this.mixins.parametrizedProcessSchemaElement.getParametersLocalizableValues.call(this, localizableValues);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.mixins.parametrizedProcessSchemaElement.constructor.call(this);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getSmallImage
		 * @override
		 */
		getSmallImage: function() {
			return this.mixins.campaignElementMixin
				.getImage(this.smallImage);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getLargeImage
		 * @override
		 */
		getLargeImage: function() {
			this.initLargeImage();
			return this.mixins.campaignElementMixin
				.getImage(this.largeImage);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getTitleImage
		 * @override
		 */
		getTitleImage: function() {
			this.initTitleImage();
			return this.mixins.campaignElementMixin
				.getImage(this.titleImage);
		},

		/**
		 * Gets markers according to element properties.
		 * @protected
		 * @return {Object} Element markers.
		 */
		getElementMarkers: function() {
			return null;
		},

		/**
		 * Applies specific logic to init title image.
		 * @protected
		 */
		initTitleImage: BPMSoft.emptyFn,

		/**
		 * Applies specific logic to init large image.
		 * @protected
		 */
		initLargeImage: BPMSoft.emptyFn,

		/**
		 * Changes state of element markers.
		 * @protected
		 */
		updateMarkers: function() {
			var changes = {
				markers: this.getElementMarkers()
			};
			this.fireEvent("changed", changes, this);
		},

		/**
		 * Applies specific logic when copy process is running.
		 * Default behavior is to return existing schema.
		 * @returns {CampaignBaseElementSchema} Element copy.
		 * @protected
		 */
		prepareCopy: function() {
			return this;
		},

		/**
		 * Applies specific logic when server saving process is successfully finished.
		 * @protected
		 */
		onAfterSave: BPMSoft.emptyFn,

		/**
		 * Applies specific logic when campaign schema item is successfully removed.
		 * @protected
		 */
		onSchemaItemRemoved: BPMSoft.emptyFn,

		/**
		 * Validates campaign schema element as a part of campaign flow schema.
		 * @protected
		 * @return {BPMSoft.Collection} Validation result.
		 */
		validate: BPMSoft.emptyFn,

		/**
		 * Applies additional properties on diagram elements.
		 * @protected
		 */
		applyElementData: BPMSoft.emptyFn

		//endregion
	});
	return BPMSoft.CampaignBaseElementSchema;
});
