define("ServiceModelNetwork", ["ServiceModelNetworkComponent"], function() {
	Ext.define("BPMSoft.control.ServiceModelNetwork", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.ServiceModelNetwork",

		nodes: [],

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\" style=\"height: 800px;\">',
			'<ts-service-model-network id=\"{id}\" is-nodes-loaded=\"{isNodesLoaded}\">',
			'</ts-service-model-network>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				serviceModelNetworkEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"nodeClicked"
			);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const networkBindConfig = {
				items: {
					changeMethod: "setNodes"
				}
			};
			Ext.apply(networkBindConfig, bindConfig);
			return networkBindConfig;
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.serviceModelNetworkEl;
			if (el) {
				el.on("nodeClicked", this.handleNodeClicked, this);
			}
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.serviceModelNetworkEl;
			if (el) {
				el.un("nodeClicked", this.handleNodeClicked, this);
			}
		},

		/**
		 * @inheritdoc BPMSoft.Component#onAfterRender
		 * @protected
		 * @override
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			this._applyNodesToElement();
		},

		/**
		 * Handles clicking on node.
		 * @param {Object} event Event data.
		 * @protected
		 */
		handleNodeClicked: function(event) {
			const nodeData = event.browserEvent.detail.nodeData;
			this.fireEvent("nodeClicked", event, nodeData);
		},

		/**
		 * Sets nodes.
		 * @param {Array} nodeItems Items of nodes.
		 */
		setNodes: function(nodeItems) {
			if (this.nodes === nodeItems || Ext.isEmpty(nodeItems)) {
				return;
			}
			this.nodes = nodeItems;
			this._applyNodesToElement();
		},

		/**
		 * @private
		 */
		_applyNodesToElement: function() {
			this._setAttribute("is-nodes-loaded", false);
			if (this.serviceModelNetworkEl) {
				this.serviceModelNetworkEl.dom.nodes = BPMSoft.encode(this.nodes);
			}
			this._setAttribute("is-nodes-loaded", true);
		},

		/**
		 * @private
		 */
		_setAttribute: function(name, value) {
			if (this.rendered) {
				this.serviceModelNetworkEl.dom.setAttribute(name, value);
			}
		}

	});

	return BPMSoft.ServiceModelNetwork;
});
