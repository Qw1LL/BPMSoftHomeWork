define("ProcessCampaignConditionalSequenceFlowSchema", ["CampaignConnectorManager",
	"CampaignEnums", "ProcessCampaignConditionalSequenceFlowSchemaResources",
	"CampaignElementMixin", "CampaignLabelSchema"],
		function(campaignConnectorManager, CampaignEnums, resources) {
	Ext.define("BPMSoft.manager.ProcessCampaignConditionalSequenceFlowSchema", {
		extend: "BPMSoft.ProcessConditionalSequenceFlowSchema",
		alternateClassName: "BPMSoft.ProcessCampaignConditionalSequenceFlowSchema",

		mixins: {
			parametrizedProcessSchemaElement: "BPMSoft.ParametrizedProcessSchemaElement",
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.ConditionalSequenceFlowElement, BPMSoft.Configuration",

		/**
		 * Sequence flow name.
		 * @type {String}
		 */
		connectionUserHandleName: "CampaignConditionalSequenceFlow",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignConditionalSequenceFlowPropertiesPage",

		/**
		 * Type of element.
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CONDITIONAL_TRANSITION,

		/**
		 * Hint of element.
		 * @protected
		 * @type {String}
		 */
		hint: null,

		/**
		 * Delay unit property.
		 * @protected
		 * @type {number}
		 */
		delayUnit: 0,

		/**
		 * Property for number of delayed days when DelayUnit is 0 (delay in days),
		 * or number of delayed hours when DelayUnit is 1 (delay in hours).
		 * @protected
		 * @type {number}
		 */
		delayInDays: 0,

		/**
		 * Id of filter
		 * @protected
		 * @type {Guid}
		 */
		filterId: null,

		/**
		 * Root schema id to filter campaign audience.
		 * @protected
		 * @type {Guid}
		 */
		filterEntitySchemaId: null,

		/**
		 * Serialized json data of filter.
		 * @protected
		 * @type {string}
		 */
		filter: "",

		/**
		 * Is filter visible.
		 * @protected
		 * @type {Boolean}
		 */
		hasFilter: true,

		/**
		 * Is filter changed.
		 * @protected
		 * @type {Boolean}
		 */
		isFilterChanged: false,

		/**
		 * Is start delayed.
		 * @protected
		 * @type {Boolean}
		 */
		isDelayedStart: false,

		/**
		 * Start time property.
		 * @protected
		 * @type {Date}
		 */
		startTime: null,

		/**
		 * Flag to indicate that transition can be executed at specified time.
		 * @protected
		 * @type {Boolean}
		 */
		hasStartTime: true,

		/**
		 * Is synchronous.
		 * @protected
		 * @type {Boolean}
		 */
		isSynchronous: false,

		/**
		 * Priority of transition.
		 * @protected
		 * @type {number}
		 */
		priority: 0,

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * ConnectorManager to manipulate connectors.
		 * @type {BPMSoft.CampaignConnectorManager}
		 */
		connectorManager: campaignConnectorManager,

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaItem#isValid
		 * @override
		 */
		isValid: true,

		/**
		 * Description text.
		 * @type {String}
		 */
		description: null,

		/**
		 * Template for delay description icon.
		 * @type {String}
		 */
		delayIconTpl: "<span class=\"material-icons icon-time2_24\"></span>",

		/**
		 * Template for time description icon.
		 * @type {String}
		 */
		timeIconTpl: "<span class=\"material-icons icon-watch_24\">",

		/**
		 * Template for filter description icon.
		 * @type {String}
		 */
		filterIconTpl: "<span class=\"material-icons icon-Filtr_24\"></span>",

		/**
		 * @inheritdoc BPMSoft.ProcessSequenceFlowSchema#constructor
		 */
		constructor: function() {
			this.callParent(arguments);
			this.mixins.parametrizedProcessSchemaElement.constructor.call(this);
		},

		/**
		 * @private
		 */
		_createLabel: function(description) {
			var uId = BPMSoft.generateGUID();
			var label = new BPMSoft.CampaignLabelSchema({
				parentUId: this.uId,
				name: this.name + "_label_description",
				uId: uId,
				description: description
			});
			return label;
		},

		/**
		 * @private
		 */
		_isAnyFilterEnabled: function(filterGroup) {
			var result = false;
			if (!filterGroup.isEnabled) {
				return result;
			}
			BPMSoft.each(filterGroup.collection, function(filter) {
				if (filter instanceof BPMSoft.BaseFilter) {
					result |= filter.isEnabled;
					return !result;
				}
				result |= this._isAnyFilterEnabled(filter);
				return !result;
			}, this);
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#getTitleImage
		 * @override
		 */
		getTitleImage: function() {
			return this.mixins.campaignElementMixin
				.getImage(resources.localizableImages.TitleImage);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.mixins.CampaignElementMixin#getElementSpecificPropertiesNames
		 * @overridden
		 */
		getElementSpecificPropertiesNames: function() {
			return ["isDelayedStart", "delayUnit", "delayInDays", "hasStartTime", "startTime"];
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			Ext.Array.push(baseSerializableProperties, ["isSynchronous", "priority", "delayUnit", "delayInDays",
				"startTime", "isDelayedStart", "filterId", "filter", "hasFilter", "isFilterChanged", "hasStartTime",
				"filterEntitySchemaId"]);
			return baseSerializableProperties;
		},

		/**
		 * Inserts an element into the flow changes the current flow and adds a new one.
		 * @param {BPMSoft.ProcessFlowElementSchema} flowElement Element, which moved to the flow.
		 * @returns {BPMSoft.ProcessSequenceFlowSchema} New flow obtained by dividing the current.
		 */
		insertFlowElement: function(flowElement) {
			var className = this.connectorManager.getConnectorType(flowElement.getTypeInfo().typeName);
			var parentSchema = this.parentSchema;
			var targetFlowElement = this.findItemByUId(this.targetRefUId);
			var flowElementPoint = parentSchema.getItemPosition(flowElement);
			var targetFlowElementPoint = parentSchema.getItemPosition(targetFlowElement);
			var sourcePort = this.getDefSequenceFlowPortName(flowElementPoint, targetFlowElementPoint);
			var newSequenceFlow = Ext.create(className, {
				uId: BPMSoft.generateGUID(),
				name: this.connectionUserHandleName,
				managerItemUId: this.managerItemUId,
				sourceRefUId: flowElement.uId,
				targetRefUId: targetFlowElement.uId,
				showPropertiesWindowOnAdding: false,
				hasFilter: true
			});
			newSequenceFlow.sourceSequenceFlowPointLocalPosition = sourcePort;
			newSequenceFlow.targetSequenceFlowPointLocalPosition = this.targetSequenceFlowPointLocalPosition;
			var sourceFlowElement = this.findItemByUId(this.sourceRefUId);
			var sourceFlowElementPoint = parentSchema.getItemPosition(sourceFlowElement);
			var targetPort = this.getDefSequenceFlowPortName(flowElementPoint, sourceFlowElementPoint);
			this.targetRefUId = flowElement.uId;
			this.targetSequenceFlowPointLocalPosition = targetPort;
			return newSequenceFlow;
		},

		/**
		 * Applies specific logic when server saving process is successfully finished.
		 * @protected
		 */
		onAfterSave: function() {
			this.isFilterChanged = false;
		},

		/**
		 * Validates campaign schema sequence flow element as a part of campaign flow schema.
		 * @protected
		 */
		validate: BPMSoft.emptyFn,

		/**
		 * Returns True if condition flow has filter conditions.
		 * @protected
		 * @returns {Boolean}
		 */
		hasNotEmptyFilter: function() {
			var filter = this.filter && BPMSoft.deserialize(this.filter);
			return Boolean(this.hasFilter
				&& ((filter && !filter.isEmpty() && this._isAnyFilterEnabled(filter))
					|| this.filterId));
		},

		/**
		 * Returns info text about delay condition.
		 * @protected
		 * @returns {String}
		 */
		getDelayText: function() {
			if (this.isDelayedStart) {
				var delayUnitText = resources.localizableStrings["DelayUnitLookup" + this.delayUnit];
				return Ext.String.format("{0}<span>{1}{2}</span>", this.delayIconTpl, this.delayInDays,
					delayUnitText);
			}
			return "";
		},

		/**
		 * Returns info text about start time condition.
		 * @protected
		 * @returns {String}
		 */
		getStartTimeText: function() {
			if (this.isDelayedStart && this.hasStartTime) {
				var startDateTime = new Date(this.startTime);
				var time = Ext.Date.format(startDateTime, BPMSoft.Resources.CultureSettings.timeFormat);
				return Ext.String.format("{0}</span><span>{1}</span>", this.timeIconTpl, time);
			}
			return "";
		},

		/**
		 * Returns info text about filters condition.
		 * @protected
		 * @returns {String}
		 */
		getFilterText: function() {
			if (this.hasNotEmptyFilter()) {
				return Ext.String.format("{0}", this.filterIconTpl);
			}
			return "";
		},

		/**
		 * Returns transition description based on selected conditions.
		 * @protected
		 * @returns {BPMSoft.LocalizableString}
		 */
		getDescription: function() {
			var parts = [
				this.getDelayText(),
				this.getStartTimeText(),
				this.getFilterText()
			].filter(function(el) {
				return el && el.trim();
			});
			var description = parts.join(" ");
			if (!description) {
				return new BPMSoft.LocalizableString("");
			}
			return new BPMSoft.LocalizableString("<div class=\"campaign-flow-description-wrap\">" + description + "</div>");
		},

		/**
		 * @inheritdoc BPMSoft.CampaignBaseElementSchema#applyElementData
		 * @override
		 */
		applyElementData: function(items) {
			if (!BPMSoft.Features.getIsEnabled("CampaignConditionalTransitionDescription")) {
				return;
			}
			var description = this.getDescription();
			if (!this.caption.toString().trim()) {
				var extraLabel = this._createLabel(description);
				items.addIfNotExists(extraLabel.name, extraLabel);
				this.parentSchema.labels.addIfNotExists(extraLabel.name, extraLabel);
			}
			this.description = description;
		},

		/**
		 * Updates flow description based on selected conditions.
		 * @protected
		 */
		updateDescription: function() {
			if (!BPMSoft.Features.getIsEnabled("CampaignConditionalTransitionDescription")) {
				return;
			}
			var description = this.getDescription();
			var changes = {
				description: {
					id: this.uId,
					description: description.toString()
				}
			};
			this.description = description;
			this.fireEvent("changed", changes, this);
		}
	});
	return BPMSoft.ProcessCampaignConditionalSequenceFlowSchema;
});
