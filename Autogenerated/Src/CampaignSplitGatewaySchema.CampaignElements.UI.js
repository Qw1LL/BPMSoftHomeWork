 /**
 * Schema of campaign split gateway element.
 */
define("CampaignSplitGatewaySchema", ["CampaignSplitGatewaySchemaResources", "CampaignEnums",
		"CampaignBaseElementSchema", "CampaignLabelSchema"],
	function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignSplitGatewaySchema
	 * Schema of campaign split gateway element.
	 */
	Ext.define("BPMSoft.manager.CampaignSplitGatewaySchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignSplitGatewaySchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "38ea507c-55e6-df11-971b-001d60e938c4",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 * @override
		 */
		name: "CampaignSplitGateway",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 * @override
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#group
		 * @override
		 */
		group: "Intermediates",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#TitleImage
		 * @override
		 */
		titleImage: resources.localizableImages.TitleImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#LargeImage
		 * @override
		 */
		largeImage: resources.localizableImages.LargeImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#SmallImage
		 * @override
		 */
		smallImage: resources.localizableImages.SmallImage,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 * @override
		 */
		editPageSchemaName: "CampaignSplitGatewayPage",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_SPLIT_GATEWAY,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignSplitGatewayElement, BPMSoft.Configuration",

		/**
		 * Background fill color.
		 * @type {String}
		 */

		color: "rgba(254, 205, 102, 1)",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
		 * @override
		 */
		width: 55,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
		 * @override
		 */
		height: 55,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#nodeType
		 * @override
		 */
		nodeType: BPMSoft.diagram.UserHandlesConstraint.Gateway,

		/**
		 * Serialized split distribution for flows.
		 * @type {String}
		 */
		distribution: null,

		/**
		 * Flag to indicate that distribution is customized for flows.
		 * @type {Boolean}
		 */
		useCustomDistribution: false,

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			if (!BPMSoft.CampaignElementGroups.Items.contains("Intermediates")) {
				BPMSoft.CampaignElementGroups.Items.add("Intermediates", {
					name: "Intermediates",
					caption: resources.localizableStrings.IntermediatesGroupCaption
				});
			}
			this.callParent(arguments);
		},

		/**
		 * @private
		 */
		_getDescriptionCaption: function(value) {
			var caption = Ext.String.format("{0}%", value);
			return new BPMSoft.LocalizableString(caption);
		},

		/**
		 * @private
		 */
		_createDistributionLabel: function(flow, value) {
			var uId = BPMSoft.generateGUID();
			var label = new BPMSoft.CampaignLabelSchema({
				parentUId: flow.uId,
				name: flow.name + "_label_distribution",
				uId: uId,
				description: this._getDescriptionCaption(value)
			});
			return label;
		},

		/**
		 * @private
		 */
		_actualizeFlowDescriptions: function() {
			var flows = this.getOutgoingsSequenceFlows();
			var distributionValues = JSON.parse(this.distribution);
			BPMSoft.each(flows, function(flow) {
				var value = distributionValues[flow.transitionId];
				this.updateFlowDescription(flow, value);
			}, this);
		},

		/**
		 * @private
		 */
		_actualizeDistribution: function() {
			var isEqualized = !this.useCustomDistribution;
			var distribution = this.getEqualizedDistribution(isEqualized);
			this.saveDistribution(distribution);
			this._actualizeFlowDescriptions();
		},

		/**
		 * @inheritdoc BPMSoft.configuration.mixins.CampaignElementMixin#getElementSpecificPropertiesNames
		 * @overridden
		 */
		getElementSpecificPropertiesNames: function() {
			return  ["distribution", "useCustomDistribution"];
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["distribution", "useCustomDistribution"]);
		},

		/**
		 * Returns equalized distribution for current split gateway.
		 * @param {Boolean} equal Flag to specify that all values have to be equal.
		 * @returns {Object}
		 */
		getEqualizedDistribution: function(equal) {
			var flows = this.getOutgoingsSequenceFlows();
			var distribution = {};
			var flowsCount = flows.length;
			var value = Math.floor((1 / flowsCount) * 100);
			var counter = 1;
			BPMSoft.each(flows, function(flow) {
				distribution[flow.transitionId] = counter !== flowsCount || equal
					? value
					: (100 - (flowsCount - 1) * value);
				counter++;
			}, this);
			return distribution;
		},

		/**
		 * Applies specified distribution for current element instance.
		 * @param {Number} value Distribution to save.
		 */
		saveDistribution: function(value) {
			this.distribution = JSON.stringify(value);
		},

		/**
		 * @inheritdoc CampaignBaseSchemaElement#onSchemaItemRemoved
		 * @override
		 */
		onSchemaItemRemoved: function(item) {
			this.callParent(arguments);
			var distributionValues = JSON.parse(this.distribution);
			if (distributionValues[item.transitionId]) {
				this._actualizeDistribution();
			}
		},

		/**
		 * Handler on diagram connection added event.
		 * @protected
		 */
		onFlowAdded: function() {
			this._actualizeDistribution();
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
		},

		/**
		 * Highlights specified transition on diagram.
		 * @protected
		 */
		highlightFlow: function(connectionId, state) {
			var changes = {
				highlight: {
					id: connectionId,
					state: state
				}
			};
			this.fireEvent("changed", changes, this);
		},

		/**
		 * Updates flow description with new distribution on diagram.
		 * @protected
		 */
		updateFlowDescription: function(flow, value) {
			var description = this._getDescriptionCaption(value);
			var changes = {
				description: {
					id: flow.uId,
					description: description.toString()
				}
			};
			flow.description = description;
			this.fireEvent("changed", changes, this);
		},

		/**
		 * @inheritdoc CampaignBaseElementSchema#applyElementData
		 * @override
		 */
		applyElementData: function(items) {
			var flows = this.getOutgoingsSequenceFlows();
			var distributionValues = JSON.parse(this.distribution);
			BPMSoft.each(flows, function(flow) {
				var value = distributionValues[flow.transitionId];
				var existing = items.findByFn(function(x) {
					return x.parentUId === flow.uId;
				});
				if (!existing) {
					var extraLabel = this._createDistributionLabel(flow, value);
					items.addIfNotExists(extraLabel.name, extraLabel);
					this.parentSchema.labels.addIfNotExists(extraLabel.name, extraLabel);
				}
				var connection = items.findByFn(function(x) {
					return x.uId === flow.uId;
				});
				if (connection) {
					connection.description = this._getDescriptionCaption(value);
				}
			}, this);
		}
	});
	return BPMSoft.CampaignSplitGatewaySchema;
});
