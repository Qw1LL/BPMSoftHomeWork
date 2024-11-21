define("CampaignDiagramElementManager", ["CampaignElementShapeForm", "CampaignEnums",
		"CampaignElementSchemaManager"], function(campaignElementShapeForm, CampaignEnums) {
	Ext.define("BPMSoft.manager.CampaignDiagramElementManager", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.CampaignDiagramElementManager",

		singleton: true,

		/**
		 * Collection of available campaign diagram elements.
		 * @private
		 */
		_items: new BPMSoft.Collection(),

		/**
		 * Flag to indicate that instance of manager is initialized.
		 * @type {Boolean}
		 */
		initialized: false,

		/**
		 * @private
		 */
		_isElement: function(item) {
			return item.nodeType !== BPMSoft.diagram.UserHandlesConstraint.Lane
				&& item.nodeType !== BPMSoft.diagram.UserHandlesConstraint.LaneSet;
		},

		/**
		 * @private
		 */
		_getDiagramNodeType: function(element) {
			if (element.nodeType === BPMSoft.diagram.UserHandlesConstraint.Connector) {
				return null;
			}
			if (element.incomingConnectionsLimit === 0) {
				return CampaignEnums.CampaignDiagramNodeTypes.START;
			}
			if (element.outgoingConnectionsLimit === 0
					|| BPMSoft.isEmpty(element.getConnectionUserHandles())) {
				return CampaignEnums.CampaignDiagramNodeTypes.END;
			}
			return CampaignEnums.CampaignDiagramNodeTypes.INTERMEDIATE;
		},

		/**
		 * @private
		 */
		_createDiagramItem: function(element) {
			var typeName = element.name;
			if (element.nodeType === BPMSoft.diagram.UserHandlesConstraint.Connector) {
				typeName = "connection";
			}
			return {
				type: typeName,
				className: element.typeName,
				schemaInstanceId: element.instanceId,
				paletteImage: element.smallImage && BPMSoft.ImageUrlBuilder.getUrl(element.smallImage),
				titleImage: element.largeImage && BPMSoft.ImageUrlBuilder.getUrl(element.largeImage),
				caption: element.caption.toString(),
				size: element.size,
				shapeFormType: campaignElementShapeForm.convertNodeTypeInShapeForm(element.nodeType),
				diagramNodeType: this._getDiagramNodeType(element)
			};
		},

		/**
		 * @private
		 */
		_initItems: function() {
			var items = new BPMSoft.Collection();
			var elements = BPMSoft.CampaignElementSchemaManager.getItems();
			BPMSoft.each(elements, function(element) {
				if (this._isElement(element.instance)) {
					var diagramItem = this._createDiagramItem(element.instance);
					items.add(diagramItem.className, diagramItem);
				}
			}, this);
			this._items.reloadAll(items);
		},

		/**
		 * Initializes diagram elements collection based on campaign element schema manager.
		 */
		initialize: function(callback, scope) {
			var callbackFn = function() {
				this._initItems();
				this.initialized = true;
				callback.call(scope);
			};
			if (!BPMSoft.CampaignElementSchemaManager.initialized) {
				BPMSoft.CampaignElementSchemaManager.initialize(callbackFn, this);
			} else {
				callbackFn.call(this);
			}
		},

		/**
		 * Returns collection of all campaign giagram elements.
		 * @throws {BPMSoft.exceptions.InvalidObjectState} Throws BPMSoft.exceptions.InvalidObjectState
		 * if manager have not been initialized yet.
		 * @returns {BPMSoft.Collection} Items.
		 */
		getItems: function() {
			if (!this.initialized) {
				throw new BPMSoft.exceptions.InvalidObjectState();
			}
			return this._items;
		},

		/**
		 * Returns collection of campaign elements.
		 * @returns {BPMSoft.Collection} Items.
		 */
		getDiagramElements: function() {
			return this._items.filterByFn(function(x) {
				return x.type !== "connection";
			});
		},

		/**
		 * Returns item by specific element class name.
		 * @param {String} typeName Diagram element type name.
		 * @returns {Object} Diagram item.
		 */
		findItemByClassName: function(className) {
			return this._items.findByFn(function(item) {
				return item.className === className;
			});
		}
	});
	return BPMSoft.CampaignDiagramElementManager;
});
