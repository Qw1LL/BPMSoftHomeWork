define("RelationshipChart", ["ext-base", "RelationshipChartResources", "OrgChart", "css!OrgChartCSS",
	"css!RelationshipChart"],
function(Ext, Resources) {
	/**
	 * @class BPMSoft.controls.RelationshipChart
	 * Class wrapper for chart.
	 */
	Ext.define("BPMSoft.controls.RelationshipChart", {
		alternateClassName: "BPMSoft.RelationshipChart",
		extend: "BPMSoft.Component",

		//region Fields: Protected

		/**
		 * @inheritdoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/* jshint ignore:start */
			/* jscs:disable */
			'<div id="{id}-relationship-chart-wrap" class="relationship-chart-wrap">' +
				'<div id="{id}-relationship-chart" class="relationship-chart"></div>' +
			'</div>'
			/* jscs:enable */
			/* jshint ignore:end */
		],

		/**
		 * Contains a relationship chart.
		 * @type {Object}
		 */
		$chartObject: null,

		/**
		 * Master node object instance.
		 * @type {Object}
		 */
		$masterNode: null,

		/**
		 * Last scroll position (x and y axises).
		 * @type {Object}
		 */
		scrollPosition: null,

		//endregion

		//region Fields: Public

		/**
		 * Array of chart elements.
		 * @type {Array}
		 * @param {Object} item.id Chart node identifier.
		 * @param {Object} item.title Title of chart node.
		 * @param {Object} item.description Description of chart node.
		 */
		items: null,

		/**
		 * Identifier of master node (optional). This node will be centered in viewport by default.
		 * @type {String}
		 */
		masterNodeId: null,

		/**
		 * CSS class of chart main element (optional).
		 */
		cssClass: null,

		/**
		 * Tooltips to be displayed on node buttons.
		 */
		buttonTooltips: {
			addParentNode: Resources.localizableStrings.AddParentTooltip,
			addChildNode: Resources.localizableStrings.AddChildTooltip,
			deleteNode: Resources.localizableStrings.DeleteTooltip,
		},

		//endregion

		//region Methods: Private

		/**
		 * Scrolls the current element into the visible area of the browser window.
		 * @private
		 * @param {Object} element Dom element.
		 */
		_scrollIntoView: function(element) {
			element.scrollIntoView({
				block: "center",
				inline: "center",
				behavior: "smooth"
			});
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * Relationship tree node title mouse over event.
				 * @param {String} Node Id.
				 */
				"nodeTitleMouseOver",

				/**
				 * Relationship tree node title click event.
				 * @param {String} Node Id.
				 */
				"nodeTitleClick",

				/**
				 * Relationship tree node remove event.
				 * @param {String} Node Id.
				 * @param {Function} Remove chart node callback.
				 */
				"nodeRemove",

				/**
				 * Event fired on adding parent node for relationship tree node.
				 * @param {String} Node Id.
				 * @param {Function} Remove chart node callback.
				 */
				"addParentNode",

				/**
				 * Event fired on adding child node for relationship tree node.
				 * @param {String} Node Id.
				 * @param {Function} Remove chart node callback.
				 */
				"addChildNode"
			);
			this.selectors = {
				wrapEl: "#" + this.id + "-relationship-chart-wrap",
				chartEl: "#" + this.id + "-relationship-chart"
			};
		},

		/**
		 * @inheritdoc BPMSoft.controls.Component#onAfterRender
		 * @override
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			this.renderChart();
			this.centerOnMasterNode();
		},

		/**
		 * @inheritdoc BPMSoft.controls.Component#onAfterReRender
		 * @override
		 */
		onAfterReRender: function() {
			this.callParent(arguments);
			this.renderChart();
			this.centerOnMasterNode();
		},

		/**
		 * @inheritdoc BPMSoft.controls.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			var bindConfig = this.callParent(arguments);
			Ext.apply(bindConfig, {
				"items": {
					"changeMethod": "setItems"
				},
				"masterNodeId": {
					"changeMethod": "setMasterNodeId"
				},
				"buttonTooltips": {
					"changeMethod": "setButtonTooltips"
				}
			});
			return bindConfig;
		},

		/**
		 * Saves current scroll position of the chart.
		 */
		saveScrollPosition: function() {
			var $chartObject = this.$chartObject;
			var chartObjectElement = $chartObject && $chartObject.$chart[0];
			this.lastScrollPosition = chartObjectElement
				? {
					x: chartObjectElement.scrollLeft,
					y: chartObjectElement.scrollTop
				}
				: null;
		},

		/**
		 * Scrolls the chart to last saved scroll position.
		 */
		restoreScrollPosition: function() {
			var $chartObject = this.$chartObject;
			var chartObjectElement = $chartObject && $chartObject.$chart[0];
			var scrollPosition = this.lastScrollPosition;
			this.lastScrollPosition = null;
			if (!chartObjectElement || !scrollPosition) {
				return;
			}
			chartObjectElement.scrollLeft = scrollPosition.x;
			chartObjectElement.scrollTop = scrollPosition.y;
		},

		/**
		 * Creates template for a button for a node panel.
		 * @protected
		 * @param {Object} buttonConfig Config for button.
		 * @param {Object} buttonConfig.imageUrlConfig Config to get URL of button image.
		 * @param {String} buttonConfig.buttonTitle Button title.
		 * @param {String} buttonConfig.additionalClasses Additional classes for the created button.
		 */
		getPanelButtonTemplate: function(buttonConfig) {
			/* jshint ignore:start */
			/* jscs:disable */
			var iconLink = BPMSoft.ImageUrlBuilder.getUrl(buttonConfig.imageUrlConfig);
			var buttonStyle = Ext.String.format("background-image: url({0})", iconLink);
			var classes = "node-button";
			if (buttonConfig.additionalClasses) {
				classes += " " + buttonConfig.additionalClasses;
			}
			return Ext.String.format('<span style="{0}" class="{1}" title="{2}"></span>', buttonStyle, classes,
				buttonConfig.buttonTitle);
			/* jshint ignore:end */
		},

		/**
		 * Creates remove button template.
		 * @param {String} buttonTitle Button title.
		 * @protected
		 */
		getRemoveButtonTemplate: function(buttonTitle) {
			return this.getPanelButtonTemplate({
				imageUrlConfig: Resources.localizableImages.DeleteIcon,
				buttonTitle: buttonTitle,
				additionalClasses: "remove-button"
			});
		},

		/**
		 * Creates template for 'Add parent' button.
		 * @param {String} buttonTitle Button title.
		 * @protected
		 */
		getAddParentButtonTemplate: function(buttonTitle) {
			return this.getPanelButtonTemplate({
				imageUrlConfig: Resources.localizableImages.AddIcon,
				buttonTitle: buttonTitle,
				additionalClasses: "add-button add-parent-button"
			});
		},

		/**
		 * Creates template for 'Add child' button.
		 * @param {String} buttonTitle Button title.
		 * @protected
		 */
		getAddChildButtonTemplate: function(buttonTitle) {
			return this.getPanelButtonTemplate({
				imageUrlConfig: Resources.localizableImages.AddIcon,
				buttonTitle: buttonTitle,
				additionalClasses: "add-button add-child-button"
			});
		},

		/**
		 * Creates node title content for account.
		 * @param {Object} data Chart node data.
		 * @param {Object} data.title Title of node.
		 * @param {Object} data.titleUrl Title Url of node.
		 */
		getNodeTitleTemplate: function(data) {
			var nodeTitle = "";
			if (!data.titleUrl) {
				nodeTitle = data.title;
			} else {
				var content = "<a id=\"node-title-link-{0}\" class=\"base-edit-link\" " +
					"href=\"{1}\" target=\"blank\">{2}</a>";
				nodeTitle = Ext.String.format(content, data.id, data.titleUrl, data.title);
			}
			return [
				"<div class=\"node-title-wrapper\">",
				"<div class=\"node-title\">",
				nodeTitle,
				"</div>",
				"</div>",
			].join("");
		},

		/**
		 * Creates chart node template.
		 * @protected
		 * @param {Object} data Chart node data.
		 * @param {Object} data.id Node identifier.
		 * @param {Object} data.title Title of node.
		 * @param {Object} data.titleUrl Title Url of node.
		 * @param {Object} data.description Description of node.
		 */
		getChartNodeTemplate: function(data) {
			var buttonTooltips = this.buttonTooltips;
			/* jshint ignore:start */
			/* jscs:disable */
			var nodeTopPanel = [
				'<div class="node-panel node-top-panel">',
				data.parentId ? this.getRemoveButtonTemplate(buttonTooltips.deleteNode)
					: this.getAddParentButtonTemplate(buttonTooltips.addParentNode),
				'</div>'
			].join('');
			var nodeContent = [
				'<div class="node-content">',
				this.getNodeTitleTemplate(data),
				'<div class="node-description">', data.description, '</div>',
				'</div>'
			].join('');
			var nodeBottomPanel = [
				'<div class="node-panel node-bottom-panel">',
				this.getAddChildButtonTemplate(buttonTooltips.addChildNode),
				'</div>'
			].join('');
			var nodeContentWrapperClass = "node-content-wrapper";
			if (this.masterNodeId && data.id === this.masterNodeId) {
				nodeContentWrapperClass += " master-node";
			}
			return [
				'<div class="' + nodeContentWrapperClass + '" data-node-id="', data.id, '">',
				nodeTopPanel,
				nodeContent,
				nodeBottomPanel,
				'</div>'
			].join('');
			/* jscs:enable */
			/* jshint ignore:end */
		},

		/**
		 * Handles remove button click action.
		 * @protected
		 * @param {Object} $currentNode Chart node object.
		 * @param {Object} data Chart node data.
		 */
		onNodeRemoveButtonClick: function($currentNode, data) {
			this.fireEvent("nodeRemove", data.id);
		},

		/**
		 * Handles add parent button click action.
		 * @protected
		 * @param {Object} $currentNode Chart node object.
		 * @param {Object} data Chart node data.
		 */
		onNodeAddParentButtonClick: function($currentNode, data) {
			this.fireEvent("addParentNode", data.id);
		},

		/**
		 * Handles add child button click action.
		 * @protected
		 * @param {Object} $currentNode Chart node object.
		 * @param {Object} data Chart node data.
		 */
		onNodeAddChildButtonClick: function($currentNode, data) {
			this.fireEvent("addChildNode", data.id);
		},

		/**
		 * Node title mouse click event handler.
		 * @protected
		 * @param {Object} $node Chart node object.
		 * @param {Object} data Chart node data.
		 * @param {Object} event Event.
		 */
		onTitleClick: function($node, data, event) {
			event.preventDefault();
			this.fireEvent("nodeTitleClick", data.id);
		},

		/**
		 * Node title mouse over event handler.
		 * @protected
		 * @param {Object} $node Chart node object.
		 * @param {Object} data Chart node data.
		 * @param {Object} event Event.
		 */
		onTitleMouseOver: function($node, data, event) {
			this.fireEvent("nodeTitleMouseOver", data.id);
		},

		/**
		 * Subscribes chart node events.
		 * @protected
		 * @param {Object} $node Chart node object.
		 * @param {Object} data Chart node data.
		 */
		subscribeNodeEvents: function($node, data) {
			if (data.parentId) {
				$node.find(".remove-button").on("click", this.onNodeRemoveButtonClick.bind(this, $node, data));
			} else {
				$node.find(".add-parent-button").on("click", this.onNodeAddParentButtonClick.bind(this, $node, data));
			}
			$node.find(".add-child-button").on("click", this.onNodeAddChildButtonClick.bind(this, $node, data));
			var $titleElement = $node.find(".node-title");
			$titleElement.on("click", this.onTitleClick.bind(this, $node, data));
			$titleElement.on("mouseover", this.onTitleMouseOver.bind(this, $node, data));
		},

		/**
		 * Applies additional functionality to chart node.
		 * @protected
		 * @param {Object} $node Chart node object.
		 * @param {Object} data Chart node data.
		 */
		createNode: function($node, data) {
			if (this.masterNodeId && data.id === this.masterNodeId) {
				this.$masterNode = $node;
			}
			this.subscribeNodeEvents($node, data);
		},

		/**
		 * Wraps a nodes in a div.
		 * @protected
		 */
		wrapChartNodes: function() {
			$(".node").wrap("<div class='node-wrapper'>");
		},

		/**
		 * Render the chart.
		 * @protected
		 */
		renderChart: function() {
			if (!this.canCreateChartObject()) {
				return;
			}
			this.chartEl.update("");
			this.createChartObject();
			this.wrapChartNodes();
			this.deactivateChartCollapsableFeature();
		},

		/**
		 * Checks if chart object can be created.
		 * @protected
		 * @return {Boolean}
		 */
		canCreateChartObject: function() {
			return Boolean(this.chartEl && this.visible && this.items);
		},

		/**
		 * Checks that the relationship chart is currently visible.
		 * @protected
		 * @return {Boolean}
		 */
		isChartVisible: function() {
			var $chartObject = this.$chartObject;
			var chartObjectElement = $chartObject && $chartObject.$chart[0];
			return chartObjectElement && chartObjectElement.offsetParent !== null;
		},

		/**
		 * Creates chart configuration.
		 * @protected
		 * @return {Object} Configuration object.
		 */
		getChartConfig: function() {
			var config = {
				"data": this.items,
				"nodeTemplate": this.getChartNodeTemplate.bind(this),
				"createNode": this.createNode.bind(this)
			};
			if (this.cssClass) {
				config.chartClass = this.cssClass
			}
			return config;
		},

		/**
		 * Creates and render chart object.
		 * @protected
		 */
		createChartObject: function() {
			this.$chartObject = $(this.chartEl.dom).orgchart(this.getChartConfig());
		},

		/**
		 * Deactivates chart collapsable feature.
		 * @protected
		 */
		deactivateChartCollapsableFeature: function() {
			this.$chartObject.$chart.addClass("noncollapsable");
		},

		/**
		 * Centers viewport of the chart on master node.
		 * @protected
		 */
		centerOnMasterNode: function() {
			var masterNode = this.$masterNode && this.$masterNode[0];
			if (!masterNode) {
				return;
			}
			this._scrollIntoView(masterNode);
		},

		//endregion

		//region Methods: Public

		/**
		 * Sets chart elements.
		 * @param {Array} items Array of chart elements.
		 */
		setItems: function(items) {
			this.items = items;
			if (!this.rendered) {
				return;
			}
			var needCenterOnMasterNode = Boolean(this.lastScrollPosition || !this.isChartVisible());
			if (!needCenterOnMasterNode) {
				this.saveScrollPosition();
			}
			this.renderChart();
			this.restoreScrollPosition();
			if (needCenterOnMasterNode) {
				this.centerOnMasterNode();
			}
		},

		/**
		 * Sets master node identifier of the chart.
		 * @param {String} masterNodeId Identifier of the master node.
		 */
		setMasterNodeId: function(masterNodeId) {
			this.saveScrollPosition();
			this.masterNodeId = masterNodeId;
		},

		/**
		 * Sets button tooltips for chart nodes.
		 * @param {Object} tooltipsConfig Object containing tooltip for each node button.
		 */
		setButtonTooltips: function(tooltipsConfig) {
			if (tooltipsConfig && Object.keys(tooltipsConfig).length > 0) {
				this.buttonTooltips = tooltipsConfig;
			}
		}

		//endregion

	});
	return BPMSoft.RelationshipChart;
});
