define("CampaignSchema", ["CampaignSchemaResources", "MarketingEnums", "CampaignEnums",
		"CampaignElementSchemaManager", "CampaignLabelSchema"],
	function(resources, MarketingEnums, CampaignEnums) {
	Ext.define("BPMSoft.manager.CampaignSchema", {
		extend: "BPMSoft.ProcessSchema",
		alternateClassName: "BPMSoft.CampaignSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessSchema#elementSchemaManagerName
		 * @overridden
		 */
		elementSchemaManagerName: "CampaignElementSchemaManager",

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchema#contractName
		 * @overridden
		 */
		contractName: "ContractCampaignSchema",

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchema#typeName
		 * @overridden
		 */
		typeName: "BPMSoft.Core.Campaign.CampaignSchema",

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchema#typeCaption
		 * @overridden
		 */
		typeCaption: resources.localizableStrings.TypeCaption,

		/**
		 * Properties page caption.
		 * @protected
		 * @type {string}
		 */
		propertiesPageCaption: resources.localizableStrings.PropertiesPageCaption,

		/**
		 * Unique identifier for campaign.
		 * @protected
		 * @type {Guid}
		 */
		entityId: null,

		/**
		 * Value in minutes for campaign fire period.
		 * @type {Number}
		 */
		defaultCampaignFirePeriod: null,

		/**
		 * Flag to indicate that campaign has critical execution lateness or not.
		 * @protected
		 * @type {Boolean}
		 */
		hasCriticalExecutionLateness: false,

		/**
		 * Critical lateness of campaign execution in minutes.
		 * @protected
		 * @type {Number}
		 */
		criticalExecutionLateness: MarketingEnums.CampaignFirePeriod.ONE_HOUR.Value,

		/**
		 * Code of selected time zone for campaign.
		 * @protected
		 * @type {String}
		 */
		timeZoneCode: null,

		/**
		 * Collection of schema validation results.
		 * @protected
		 * @type {BPMSoft.Collection}
		 */
		validationResult: null,

		/**
		 * Creates default lane set for diagram.
		 * @private
		 * @param {String} schemaUId Campaign schema identifier.
		 * @return {BPMSoft.ProcessLaneSetSchema}
		 */
		_createLaneSet: function(schemaUId) {
			var laneSet = Ext.create("BPMSoft.ProcessLaneSetSchema", {
				uId: BPMSoft.generateGUID(),
				name: "LaneSet1",
				createdInSchemaUId: schemaUId,
				modifiedInSchemaUId: schemaUId
			});
			return laneSet;
		},

		/**
		 * Creates default lane for diagram.
		 * @private
		 * @param {String} schemaUId Campaign schema identifier.
		 * @param {String} containerUId Parent element identifier.
		 * @return {BPMSoft.ProcessLaneSchema}
		 */
		_createLane: function(schemaUId, containerUId) {
			var lane = Ext.create("BPMSoft.ProcessLaneSchema", {
				uId: "bd0ac34a-1036-48d7-b196-79707e0ad01a",
				name: "Lane1",
				containerUId: containerUId,
				createdInSchemaUId: schemaUId,
				modifiedInSchemaUId: schemaUId,
				parentSchema: this
			});
			return lane;
		},

		/**
		 * Removes unlinked elements or flows from the incomming flowElements collection.
		 * @private
		 * @param {BPMSoft.Collection} flowElements Flow elements collection.
		 * @return {Boolean} Returns true if any items where removed.
		 */
		_removeUnlinkedItems: function(flowElements) {
			var isRemoved = false;
			BPMSoft.each(flowElements, function(el) {
				if (el instanceof BPMSoft.ProcessSequenceFlowSchema) {
					var sourceElement = flowElements.findByPath("uId", el.sourceRefUId);
					var targetElement = flowElements.findByPath("uId", el.targetRefUId);
					if (!sourceElement || !targetElement) {
						flowElements.removeByKey(el.name);
						isRemoved = true;
					}
					return true;
				}
				var outgoingSequenceFlows = flowElements.filterByFn(function(item) {
					return item instanceof BPMSoft.ProcessSequenceFlowSchema && item.sourceRefUId === el.uId;
				}, this);
				var incommingSequenceFlows = flowElements.filterByFn(function(item) {
					return item instanceof BPMSoft.ProcessSequenceFlowSchema && item.targetRefUId === el.uId;
				}, this);
				var totalFlows = outgoingSequenceFlows.getCount() * incommingSequenceFlows.getCount();
				if (totalFlows === 0) {
					flowElements.removeByKey(el.name);
					isRemoved = true;
				}
			}, this);
			return isRemoved;
		},

		/**
		 * Removes delayed transitions from flowElements collection.
		 * @param {BPMSoft.Collection} flowElements Flow elements collection.
		 * @private
		 */
		_removeTransitionsWithDelayedStart: function(flowElements) {
			var transitionWithDelayedStart = flowElements.findByPath("isDelayedStart", true);
			while (transitionWithDelayedStart) {
				flowElements.removeByKey(transitionWithDelayedStart.name);
				transitionWithDelayedStart = flowElements.findByPath("isDelayedStart", true);
			}
		},

		/**
		 * Validates flow schema. Tries to find a loop without any delayed transitions.
		 * @private
		 */
		_validateFlowSchemaLoops: function() {
			var flowElements = this.flowElements.clone();
			this._removeTransitionsWithDelayedStart(flowElements);
			var needToRemoveUnlinkedElements = true;
			while (needToRemoveUnlinkedElements) {
				needToRemoveUnlinkedElements = this._removeUnlinkedItems(flowElements);
			}
			const minNumberOfElementsForLoop = 4;
			var isSchemaContainsLoop = flowElements.getCount() >= minNumberOfElementsForLoop;
			if (!isSchemaContainsLoop) {
				return;
			}
			this.validationResult.add(CampaignEnums.CampaignFlowSchemaValidationRules.LOOP_WITHOUT_DELAYED_TRANSITIONS,
				resources.localizableStrings.LoopWithoutDelayedTransitionsMessage);
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchema#getEditPageSchemaName
		 * @overridden
		 * @param {Function} callback Callback function.
		 * @param {String} callback.editPageSchemaName Edit page schema name.
		 * @param {Object} scope Callback function scope.
		 */
		getEditPageSchemaName: function(callback, scope) {
			callback.call(scope, "CampaignSchemaPropertiesPage");
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["entityId",
				"defaultCampaignFirePeriod", "hasCriticalExecutionLateness",
				"criticalExecutionLateness", "timeZoneCode"]);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessSchema#getLocalizableValues
		 * @override
		 */
		getLocalizableValues: function(localizableValues) {
			localizableValues[this.uId + ".caption"] = this.getSerializableProperty(this.caption);
			localizableValues[this.uId + ".description"] = this.getSerializableProperty(this.description);
			this.flowElements.each(function(flowElement) {
				flowElement.getLocalizableValues(localizableValues);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getTitleImage
		 * @overridden
		 */
		getTitleImage: function() {
			return this.mixins.campaignElementMixin
				.getImage(resources.localizableImages.TitleImage);
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.flowElements.on("remove", this.onElementRemoved, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.flowElements.un("remove", this.onElementRemoved, this);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessSchema#add
		 * @override
		 */
		add: function(item) {
			if (this.contains(item.name) && item instanceof BPMSoft.CampaignLabelSchema) {
				this.labels.removeByKey(item.name);
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessSchema#createLabel
		 * @override
		 */
		createLabel: function(config) {
			return new BPMSoft.CampaignLabelSchema(config);
		},

		/**
		 * Handler on flow elements collection item remove event.
		 * @protected
		 */
		onElementRemoved: function(item) {
			BPMSoft.each(this.flowElements, function(el) {
				if (el instanceof BPMSoft.CampaignBaseElementSchema) {
					el.onSchemaItemRemoved(item);
				}
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessSchema#initLaneSets
		 * @override
		 */
		initLaneSets: function() {
			this.callParent(arguments);
			if (!this.laneSets.collection.length) {
				var laneSet = this._createLaneSet(this.uId);
				var lane = this._createLane(this.uId, laneSet.uId);
				laneSet.lanes.add(lane.name, lane);
				this.laneSets.add(laneSet.name, laneSet);
				this.lanes.add(lane.name, lane);
			}
		},

		/**
		 * Sets default values for required fields for campaign schema instance.
		 * @protected
		 */
		setDefaultValues: function() {
			if (!this.defaultCampaignFirePeriod) {
				this.defaultCampaignFirePeriod = MarketingEnums.CampaignFirePeriod.ONE_HOUR.Value;
			}
			if (!this.timeZoneCode) {
				this.timeZoneCode = "UTC";
			}
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseProcessSchema#validate
		 * @override
		 */
		validate: function(validationErrorLevel) {
			this.validationResult = Ext.create("BPMSoft.Collection");
			this._validateFlowSchemaLoops();
			return this.callParent(arguments);
		}
	});
	return BPMSoft.CampaignSchema;
});
