define("CampaignDiagramItem", ["BPMSoft", "ext-base"], function(BPMSoft, Ext) {
	Ext.define("BPMSoft.configuration.CampaignDiagramItem", {
		extend: "BPMSoft.BaseModel",
		alternateClassName: "BPMSoft.CampaignDiagramItem",

		/**
		 * Element name.
		 * @type {String}
		 */
		name: "",
		/**
		 * Configuration object of element.
		 * @type {Object}
		 */
		config: null,
		/**
		 * Wrapped config for diagram element.
		 * @type {Object}
		 */
		element: null,
		/**
		 * Type of diagram element.
		 * @type {PropertyEnums.DiagramElementCategory}
		 */
		elementType: null,
		/**
		 * Source node id.
		 * @type {String}
		 */
		sourceNode: null,
		/**
		 * Target node id.
		 * @type {String}
		 */
		targetNode: null,
		/**
		 * List of incomings.
		 * @type {Array}
		 */
		inEdges: null,
		/**
		 * List of outgoings.
		 * @type {Array}
		 */
		outEdges: null,

		attributes: {
			"AddInfo": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"Text": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.element = Ext.merge({}, this.config);
			this.inEdges = [];
			this.outEdges = [];
			this.on("change:AddInfo", this.onAddInfoChanged, this);
			this.on("change:Text", this.onTextChanged, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:AddInfo", this.onAddInfoChanged, this);
			this.un("change:Text", this.onTextChanged, this);
			this.callParent(arguments);
		},

		/**
		 *
		 * @protected
		 * @param {BPMSoft.BaseModel} model Modified item model.
		 * @param {Object} value Add info object.
		 */
		onAddInfoChanged: function(model, value) {
			this.element.addInfo = value;
		},

		/**
		 *
		 * @protected
		 * @param {BPMSoft.BaseModel} model Modified item model.
		 * @param {Object} value Text value.
		 */
		onTextChanged: function(model, value) {
			this.element.labels[0].text = value;
			if (this.config.labels[0]) {
				this.config.labels[0] = { text: value };
			}
		}
	});
});
