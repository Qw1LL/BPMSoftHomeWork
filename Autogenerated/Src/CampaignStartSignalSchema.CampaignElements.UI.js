define("CampaignStartSignalSchema", ["CampaignStartSignalSchemaResources",
	"CampaignEnums", "CampaignBaseAudienceSchema", "CampaignElementMixin"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignStartSignalSchema
	 * Schema of start signal element.
	 */
	Ext.define("BPMSoft.manager.CampaignStartSignalSchema", {
		extend: "BPMSoft.CampaignBaseAudienceSchema",
		alternateClassName: "BPMSoft.CampaignStartSignalSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "8172280b-a96e-4f57-8091-0f673c040128",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "CampaignStartSignal",

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
		editPageSchemaName: "CampaignStartSignalPage",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.CampaignStartSignalElement, BPMSoft.Configuration",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.ADD_AUDIENCE,

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */
		color: "rgba(101, 215, 144, 1)",

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
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#incomingConnectionsLimit
		 * @overridden
		 */
		incomingConnectionsLimit: 0,

		/**
		 * @protected
		 * @type {enum}
		 */
		entitySignal: BPMSoft.EntityChangeType.None,

		/**
		 * Signal object unique Id.
		 * @protected
		 * @type {String}
		 */
		signalEntityId: null,

		/**
		 * @protected
		 * @type {String}
		 */
		signal: null,

		/**
		 * @protected
		 * @type {Boolean}
		 */
		waitingRandomSignal: false,

		/**
		 * @protected
		 * @type {Boolean}
		 */
		waitingEntitySignal: true,

		/**
		 * @protected
		 * @type {Boolean}
		 */
		hasEntityColumnChange: false,

		/**
		 * @protected
		 * @type {Boolean}
		 */
		hasEntityFilters: false,

		/**
		 * @protected
		 * @type {Object}
		 */
		newEntityChangedColumns: null,

		/**
		 * @protected
		 * @type {String}
		 */
		entityFilters: null,

		/**
		 * Object unique Id.
		 * @protected
		 * @type {String}
		 */
		entitySchemaUId: null,

		/**
		 * Flag to indicate participant recurring entrance to campaign audience.
		 * @type {Boolean}
		 */
		isRecurring: false,

		/**
		 * @inheritdoc BPMSoft.CampaignBaseAudienceSchema#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.newEntityChangedColumns =
				this._decodeNewEntityChangedColumns(this.newEntityChangedColumns);
		},

		/**
		 * Decode entity columns.
		 * @private
		 * @param {String} stringValue Encoded string value.
		 * @return {Array} Entity columns array.
		 */
		_decodeNewEntityChangedColumns: function(stringValue) {
			var newEntityChangedColumns = [];
			if (Ext.isEmpty(stringValue)) {
				return newEntityChangedColumns;
			}
			var newEntityChangedColumnsRawValue = BPMSoft.decode(stringValue);
			if (Ext.isArray(newEntityChangedColumnsRawValue)) {
				return newEntityChangedColumnsRawValue;
			}
			BPMSoft.each(newEntityChangedColumnsRawValue, function(propertyValue, propertyName) {
				if (propertyName === "$values" && Ext.isArray(propertyValue)) {
					newEntityChangedColumns = propertyValue;
					return true;
				}
			});
			return newEntityChangedColumns;
		},

		/**
		 * @inheritdoc BPMSoft.ProcessFlowElementSchema#validate
		 * @override
		 */
		validate: function() {
			var results = Ext.create("BPMSoft.Collection");
			if (this.getOutgoingsSequenceFlows().length === 0) {
				results.add(CampaignEnums.CampaignFlowSchemaValidationRules.ADD_AUDIENCE_WITHOUT_OUTGOINGS,
					resources.localizableStrings.AddAudienceWithoutOutgoingsMessage);
			}
			return results;
		},

		/**
		 * @inheritdoc BPMSoft.ProcessFlowElementSchema#getSerializableObject
		 * @override
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			serializableObject.newEntityChangedColumns = JSON.stringify(this.newEntityChangedColumns);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessFlowElementSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["signal", "signalEntityId", "entitySignal",
				"waitingRandomSignal", "waitingEntitySignal", "hasEntityColumnChange", "hasEntityFilters",
				"entityFilters", "entitySchemaUId", "isRecurring"]);
		},

		/**
		 * @inheritdoc BPMSoft.CampaignBaseElementSchema#getElementMarkers
		 * @override
		 */
		getElementMarkers: function() {
			var markers = {};
			if (this.isRecurring) {
				markers.recurring = { name: "Recurring" };
			}
			return markers;
		},

		/**
		 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initTitleImage
		 * @override
		 */
		initTitleImage: function() {
			this.titleImage = this.isRecurring
				? resources.localizableImages.TitleIsRecurringImage
				: resources.localizableImages.TitleImage;
		}
	});
	return BPMSoft.CampaignStartSignalSchema;
});
