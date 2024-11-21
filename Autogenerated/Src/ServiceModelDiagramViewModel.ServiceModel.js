define("ServiceModelDiagramViewModel", ["ext-base", "ServiceHelper", "ServiceModelDiagramViewModelResources"],
	function(Ext, ServiceHelper, resources) {
		Ext.define("BPMSoft.configuration.ServiceModelDiagramViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.ServiceModelDiagramViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			PortPosition: {
				Center: {
					name: "central",
					offset: {x: 0.5, y: 0.5}
				}
			},

			DIAGRAM_CONTAINER: "diagram-ServiceModelDiagram",

			NODE_BORDER_WIDTH: 0,
			NODE_SHAPE_TYPE: "image",
			NODE_WIDTH: 71,
			NODE_HEIGHT: 71,
			NODE_SHAPE_WIDTH: 45,
			NODE_SHAPE_HEIGHT: 45,
			NODE_SHAPE_OFFSET_X: 16,
			NODE_SHAPE_OFFSET_Y: 16,
			NODE_COLOR_ENABLE: "#7299F8",

			SERVICE_ITEM_NODE_IMAGE_ID: "1B164E63-5F4A-4DED-BD1D-C94B61A33BED",
			CONF_ITEM_NODE_IMAGE_ID: "F263E7EF-BA30-43DB-BF72-12E221B8E26C",
			CONF_ITEM: "ConfItem",
			SERVICE_ITEM: "ServiceItem",
			CONF_ITEM_RX: 15,
			CONF_ITEM_RY: 15,
			SERVICE_ITEM_RX: 35,
			SERVICE_ITEM_RY: 35,

			LABEL_WIDTH: 130,
			LABEL_FONT_FAMILY: "Golos Regular",
			LABEL_FONT_COLOR: "#67748E",
			LABEL_FONT_SIZE: 12,
			EMPTY_COLUMN_LABEL_FONT_SIZE: 18,
			EMPTY_COLUMN_LABEL_WIDTH: 180,
			EMPTY_COLUMN_LABEL_FONT_COLOR: "#67748E",
			LABEL_NAME_OFFSET_X: 0.5,
			LABEL_NAME_OFFSET_Y: 1.2,

			CONNECTOR_WIDTH: 1,
			CONNECTOR_SEGMENTS_TYPE: "straight",
			CONNECTOR_CONFITEM_PADDING: 45,
			CONNECTOR_SERVICEITEM_PADDING: 40,
			CONNECTOR_COLOR_ENABLE: "#AEAEAE",
			DECORATOR_WIDTH: 8,
			DECORATOR_HEIGHT: 5,

			HPADDING: 10,
			VPADDING: 40,
			VTOPPADDING: 35,
			VBOTTOMPADDING: 70,

			COLOR_DISABLE: "#F14E07",

			/**
			 * ########## ###### ####### ####### #########.
			 * @protected
			 * return {Number} ###### ####### ####### #########.
			 */
			getClientWidth: function() {
				return this.Ext.getElementById(this.DIAGRAM_CONTAINER).clientWidth;
			},

			/**
			 * ########## ###### ####### ####### #########.
			 * @protected
			 * return {Number} ###### ####### ####### #########.
			 */
			getClientHeight: function() {
				return this.Ext.getElementById(this.DIAGRAM_CONTAINER + "_canvas_svg").clientHeight;
			},

			/**
			 * ############# ######## ###### ########## #########.
			 * @protected
			 * @param {Number} maxCount ########### ########### ######### # #######
			 */
			setClientHeight: function(maxCount) {
				var maxHeight = (maxCount) * (this.NODE_HEIGHT + this.VPADDING);
				maxHeight = Math.max(maxHeight + this.VBOTTOMPADDING, this.get("ClientHeight"));
				this.set("ScrollTop", (maxHeight - this.get("ClientHeight")) / 2);
				this.set("ClientHeight", maxHeight);
				var element = this.Ext.get(this.DIAGRAM_CONTAINER + "_canvas_svg");
				element.setStyle("height", maxHeight);
			},

			/**
			 * ############# ######## ######## # ######.
			 * @protected
			 * @param {Array} influenceElements ###### ######## #########
			 * @param {Array} dependenceElements ###### ######### #########
			 */
			setContainerSizes: function(influenceElements, dependenceElements) {
				var maxCount = Math.max(influenceElements.length, dependenceElements.length);
				this.set("ClientWidth", this.getClientWidth());
				this.set("ClientHeight", this.getClientHeight());
				this.setClientHeight(maxCount);
			},

			/**
			 * ############# ######## ###### ########## #########.
			 * @protected
			 */
			setClientScrollPosition: function() {
				var element = this.Ext.get(this.DIAGRAM_CONTAINER);
				element.dom.scrollTop = parseInt(this.get("ScrollTop"), 10);
			},

			/**
			 * ####### ### ######## ## ######### #########.
			 * @protected
			 */
			clearAllDiagramNodes: function() {
				var nodes = this.get("Nodes");
				nodes.clear();
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 */
			init: function() {
				this.set("IsServiceModelInited", true);
				this.set("IsServiceModelNetworkFeatureEnabled", this.getIsFeatureEnabled("ServiceModelNetwork"));
				this.set("Nodes", this.Ext.create("BPMSoft.Collection"));
				this.createMainElement();
			},

			/**
			 * ######### ####### #########.
			 * @protected
			 * {Function} callback ####### ########## ##### ########## ##########
			 */
			updateElementsConfigs: function(callback) {
				if (this.get("IsServiceModelInited")) {
					return;
				}
				this.getElementsConfigs(callback);
				return true;
			},

			/**
			 * ######## ###### ############ ######## #########.
			 * @protected
			 */
			createMainElement: function() {
				var defaultInfo = this.getDefaultValues();
				this.set("MainElement", defaultInfo[0]);
			},

			/**
			 * ######## ######## ######### ########-######### ######.
			 * @protected
			 */
			loadServiceModel: function() {
				this.getElementsConfigs();
			},

			/**
			 * ######## ######, ### ######### ###### # #### ######### #########.
			 * @protected
			 */
			getElementsConfigs: function(callback) {
				var mainElement = this.get("MainElement");
				var data = {
					entitySchemaName: mainElement.schemaName,
					elementId: mainElement.id
				};
				var self = this;
				ServiceHelper.callService("ServiceModelDiagramService", "GetServiceModelRelationshipDiagramInfo",
					function(response) {
						this.serviceDiagramServiceCallback(response, callback, self);
					}, data, this);
			},
			/**
			 * ############ ######### ###### #######.
			 * @protected
			 */
			serviceDiagramServiceCallback: function(response, callback, self) {
				var result = response.GetServiceModelRelationshipDiagramInfoResult;
				if (result && result.success === true) {
					if (this.get("IsServiceModelInited")) {
						this.set("IsServiceModelInited", false);
						this.buildDiagramNodes(result);
					} else {
						this.updateCachedConfigs(result);
					}
				}
				if (typeof callback !== "undefined") {
					callback.call(self);
				}
			},

			/**
			 * ######### ####### # ###### ########.
			 * @protected
			 * @param {Array} influenceElements ###### ######## #########
			 * @param {Array} dependenceElements ###### ######### #########
			 * @param {String} collectionName ######## #########
			 */
			addEmptyLabels: function(influenceElements, dependenceElements, collectionName) {
				var emptyInfluenceColumnLabel = resources.localizableStrings.EmptyInfluenceColumnLabel;
				var emptyDependencyColumnLabel = resources.localizableStrings.EmptyDependencyColumnLabel;
				this.addLabelForEmptyColumn(influenceElements, emptyInfluenceColumnLabel, "left", collectionName);
				this.addLabelForEmptyColumn(dependenceElements, emptyDependencyColumnLabel, "right", collectionName);
			},

			/**
			 * ######### ########### ########.
			 * @protected
			 * @param {Object} response ######### ####### #######
			 */
			updateCachedConfigs: function(response) {
				const mainElement = response.mainElement;
				const influenceElements = mainElement.influenceElements;
				const dependenceElements = mainElement.dependenceElements;
				if (!this.$IsServiceModelNetworkFeatureEnabled) {
					this.Ext.getElementById(this.DIAGRAM_CONTAINER).focus();
					this.addEmptyLabels(influenceElements, dependenceElements, "CachedNodes");
				}

				this.set("CachedNodes", this.Ext.create("BPMSoft.Collection"));

				this.addElements([mainElement], "center", "CachedNodes");
				this.addElements(influenceElements, "left", "CachedNodes");
				this.addElements(dependenceElements, "right", "CachedNodes");

				this.addRelatedConnectors(influenceElements, "CachedNodes");
				this.addRelatedConnectors([mainElement], "CachedNodes");
				this.addRelatedConnectors(dependenceElements, "CachedNodes");

				this.set("NetworkNodes", this.$CachedNodes.getItems());
			},

			/**
			 * ############ ######## ####### ## ######### # ########### ## ########### ######### # #######.
			 * @protected
			 * @param {Array} elements ######### #######
			 */
			calculateStartOffset: function(elements) {
				var needHeight = (elements.length) * (this.NODE_HEIGHT + this.VPADDING);
				var maxHeight = parseInt(this.get("ClientHeight"), 10);
				this.set("StartOffsetY", Math.abs(maxHeight - needHeight) / 2 + this.VTOPPADDING);
			},

			/**
			 * ####### # ######### ######## ## #########.
			 * @protected
			 * @param {Array} elements ########
			 * @param {String} side ####### ######## # #######
			 * @param {String} collectionName ######## #########
			 */
			addElements: function(elements, side, collectionName) {
				var nodes = this.get(typeof collectionName !== "undefined" ? collectionName : "Nodes");
				var config;
				this.calculateStartOffset(elements);
				elements.forEach(function(element, index) {
					config = this.getNodeConfig(element, side, index);
					nodes.add(element.id, config);
				}, this);
			},

			/**
			 * ############# ######### #########.
			 * @protected
			 * @param {Array} elements ########
			 */
			recalculatePostions: function(elements) {
				var offset;
				this.calculateStartOffset(elements);
				elements.forEach(function(element, index) {
					offset = this.getElementOffset(element.side, index);
					element.offsetX = offset.x;
					element.offsetY = offset.y;
				}, this);
			},

			/**
			 * ######### ####### ### ###### #######.
			 * @protected
			 * @param {Array} elements ########
			 * @param {String} caption ######### #######
			 * @param {String} side ####### ####### ############ ######## ########
			 * @param {String} collectionName ######## #########
			 */
			addLabelForEmptyColumn: function(elements, caption, side, collectionName) {
				var nodes = this.get(typeof collectionName !== "undefined" ? collectionName : "Nodes");
				if (elements.length !== 0) {
					return;
				}
				var x = parseInt(this.get("ClientWidth"), 10);
				if (side === "left") {
					x = x * (1 / 4) - this.NODE_WIDTH / 2;
				} else {
					x *= (3 / 4);
				}
				var y = parseInt(this.get("ClientHeight"), 10) * (1 / 2) - this.VTOPPADDING / 2;
				var labelConfig = this.getNodeLabelConfig(caption.replace(/ /g, "\n"));
				labelConfig.defaultRendering = !BPMSoft.getIsRtlMode();
				labelConfig.fontSize = this.EMPTY_COLUMN_LABEL_FONT_SIZE;
				labelConfig.fontColor = this.EMPTY_COLUMN_LABEL_FONT_COLOR;
				labelConfig.width = this.EMPTY_COLUMN_LABEL_WIDTH;
				labelConfig.textAlign = "center";
				labelConfig.isLink = false;

				var config = {
					"name": caption + "Id",
					"offsetX": x,
					"offsetY": y,
					"constraints": 4,
					"nodeType": this.BPMSoft.diagram.UserHandlesConstraint.Node,
					"labels": [labelConfig]
				};
				nodes.add(caption + "Id", config);
			},

			/**
			 * ######### ### ######### #########.
			 * @protected
			 * @param {Array} elements ########
			 * @param {String} collectionName ######## #########
			 */
			addRelatedConnectors: function(elements, collectionName) {
				var nodes = this.get(typeof collectionName !== "undefined" ? collectionName : "Nodes");
				var elementConfig, fromElementConfig;
				elements.forEach(function(element) {
					elementConfig = nodes.collection.getByKey(element.id);
					element.influenceElements.forEach(function(fromElement) {
						fromElementConfig = nodes.collection.getByKey(fromElement.id);
						nodes.add(fromElementConfig.name + "/" + elementConfig.name,
							this.getConnectorConfig(fromElementConfig, elementConfig));
					}, this);
				}, this);
			},

			/**
			 * Creates diagram elements.
			 * @protected
			 * @param {Object} response Service response.
			 */
			buildDiagramNodes: function(response) {
				const mainElement = response.mainElement;
				const influenceElements = mainElement.influenceElements;
				const dependenceElements = mainElement.dependenceElements;
				if (!this.$IsServiceModelNetworkFeatureEnabled) {
					this.Ext.getElementById(this.DIAGRAM_CONTAINER).focus();
					this.setContainerSizes(influenceElements, dependenceElements);
					this.addEmptyLabels(influenceElements, dependenceElements);
					this.setClientScrollPosition();
				}
				this.addElements([mainElement], "center");
				this.addElements(influenceElements, "left");
				this.addElements(dependenceElements, "right");

				this.addRelatedConnectors(influenceElements);
				this.addRelatedConnectors([mainElement]);
				this.addRelatedConnectors(dependenceElements);

				const cache = this.Ext.create("BPMSoft.Collection");
				const nodes = this.get("Nodes");
				for (let i = 0; i < nodes.collection.items.length; i++) {
					cache.add(nodes.collection.items[i]);
				}
				this.set("CachedNodes", cache);
				this.set("NetworkNodes", nodes.getItems());
			},

			/**
			 * Rebuilds diagram nodes.
			 * @protected
			 * @param {BPMSoft.Collection} collection Collection of service result.
			 */
			rebuildDiagramNodes: function(collection) {
				this.clearAllDiagramNodes();
				const influenceElements = [];
				const dependenceElements = [];

				for (let i = 0; i < collection.length; i++) {
					if (collection[i].side === "left") {
						influenceElements.push(collection[i]);
					} else if (collection[i].side === "right") {
						dependenceElements.push(collection[i]);
					}
				}
				if (!this.$IsServiceModelNetworkFeatureEnabled) {
					this.setContainerSizes(influenceElements, dependenceElements);
					this.addEmptyLabels(influenceElements, dependenceElements);
					this.recalculatePostions(influenceElements);
					this.recalculatePostions(dependenceElements);
					this.setClientScrollPosition();
				}

				const nodes = this.get("Nodes");
				for (let i = 0; i < collection.length; i++) {
					nodes.add(collection[i]);
				}
				this.set("NetworkNodes", nodes.getItems());
			},

			/**
			 * ########## ############ ############## ####### ##### ##########.
			 * @protected
			 * @param {Object} elementA ######## #######
			 * @param {Object} elementB ####### #######
			 * @return {Object} ############ #######.
			 */
			getConnectorConfig: function(elementA, elementB) {
				var name = elementA.name + "/" + elementB.name;
				var color = elementA.isActive ? this.CONNECTOR_COLOR_ENABLE : this.COLOR_DISABLE;
				var connector = {
					"name": name,
					"sourceNode": elementA.name,
					"targetNode": elementB.name,
					"nodeType": this.BPMSoft.diagram.UserHandlesConstraint.Connector,
					"lineColor": color,
					"lineWidth": this.CONNECTOR_WIDTH,
					"segments": [{
						"type": this.CONNECTOR_SEGMENTS_TYPE
					}],
					"targetDecorator": {
						"width": this.DECORATOR_WIDTH,
						"height": this.DECORATOR_HEIGHT,
						"borderColor": color,
						"fillColor": color
					}
				};
				return connector;
			},

			/**
			 * ############ ########## ######## ## #########.
			 * @protected
			 * @param {String} side  ####### ##########
			 * @param {Number} index ####### ######## # #######
			 * @return {Number} ########## ########
			 */
			getElementOffset: function(side, index) {
				var clientWidth = this.get("ClientWidth");
				var offset = {};
				var startOffsetY = parseInt(this.get("StartOffsetY"), 10);
				switch (side) {
					case "left":
						offset.x = clientWidth / 4 - this.NODE_WIDTH / 2 + this.HPADDING;
						offset.y = index * (this.NODE_HEIGHT + this.VPADDING) + startOffsetY;
						break;
					case "center":
						offset.x = clientWidth / 2 - this.NODE_WIDTH / 2 + this.HPADDING;
						offset.y = startOffsetY;
						break;
					case "right":
						offset.x = clientWidth * (3 / 4) - this.NODE_WIDTH / 2 + this.HPADDING;
						offset.y = index * (this.NODE_HEIGHT + this.VPADDING) + startOffsetY;
						break;
				}
				return offset;
			},

			/**
			 * ########## id ######## ########.
			 * @protected
			 * @param {String} schemaName ####### ##########
			 * @return {String} ############# ######## ########
			 */
			getImageId: function(schemaName) {
				return schemaName === this.CONF_ITEM ? this.CONF_ITEM_NODE_IMAGE_ID : this.SERVICE_ITEM_NODE_IMAGE_ID;
			},

			/**
			 * ########## rx ######## #########.
			 * @protected
			 * @param {String} schemaName ### ########
			 * @return {Number} rx ########
			 */
			getRx: function(schemaName) {
				return schemaName === this.CONF_ITEM ? this.CONF_ITEM_RX : this.SERVICE_ITEM_RX;
			},

			/**
			 * ########## ry ######## #########.
			 * @protected
			 * @param {String} schemaName ### ########
			 * @return {Number} ry ########
			 */
			getRy: function(schemaName) {
				return schemaName === this.CONF_ITEM ? this.CONF_ITEM_RY : this.SERVICE_ITEM_RY;
			},

			/**
			 * ########## ############ ######## ### #########.
			 * @protected
			 * @return {Object} ########## ############ ######## #########
			 */
			getNodeConfig: function(element, side, index) {
				var offset = this.getElementOffset(side, index);
				var node = {
					"name": element.id,
					"width": this.NODE_WIDTH,
					"height": this.NODE_HEIGHT,
					"offsetX": offset.x,
					"offsetY": offset.y,
					"shape": this.getNodeShapeConfig(element),
					"borderWidth": this.NODE_BORDER_WIDTH,
					"nodeType": this.BPMSoft.diagram.UserHandlesConstraint.Node,
					"confItemCategoryId": element.confItemCategoryId,
					"confItemModelId": element.confItemModelId,
					"confItemStatusId": element.confItemStatusId,
					"confItemTypeId": element.confItemTypeId,
					"schemaName": element.entitySchemaName,
					"side": side,
					"isActive": element.isActive,
					"styles": {
						"fill": element.isActive ? this.NODE_COLOR_ENABLE : this.COLOR_DISABLE,
						"rx": this.getRx(element.entitySchemaName),
						"ry": this.getRy(element.entitySchemaName)
					},
					"labels": []
				};
				if (this.$IsServiceModelNetworkFeatureEnabled) {
					this._applyImageSrc(node);
				}
				node.portsSet = [this.PortPosition.Center];
				if (!this.Ext.isEmpty(element.name)) {
					var nameLabel = this.getNodeLabelConfig(element.name);
					node.labels.push(nameLabel);
				}
				return node;
			},

			/**
			 * @private
			 */
			_applyImageSrc: function(node) {
				node.shape.src = this._getImageSrc(node.shape.imageId);
			},

			/**
			 * @private
			 */
			_getImageSrc: function(imageId) {
				if (!imageId) {
					return null;
				}
				return this.BPMSoft.ImageUrlBuilder.getUrl({
					"source": this.BPMSoft.ImageSources.SYS_IMAGE,
					"params": {
						"primaryColumnValue": imageId
					}
				});
			},

			/**
			 * ########## ############ ######## ########.
			 * @protected
			 * @param {Object} element ######## #########
			 * @return {Object} ############ ########
			 */
			getNodeShapeConfig: function(element) {
				return {
					"type": this.NODE_SHAPE_TYPE,
					"imageId": this.getImageId(element.entitySchemaName),
					"styles": {
						"width": this.NODE_SHAPE_WIDTH,
						"height": this.NODE_SHAPE_HEIGHT,
						"x": this.NODE_SHAPE_OFFSET_X,
						"y": this.NODE_SHAPE_OFFSET_Y
					}
				};
			},

			/**
			 * ########## ############ ######### ##### ### ########.
			 * @protected
			 * @param {string} name ############## #########
			 * @return {Object} ############ ######### #####
			 */
			getNodeLabelConfig: function(name) {
				return {
					"fontSize": this.LABEL_FONT_SIZE,
					"fontFamily": this.LABEL_FONT_FAMILY,
					"fontColor": this.LABEL_FONT_COLOR,
					"width": this.LABEL_WIDTH,
					"text": name,
					"name": name,
					"isLink": true,
					"offset": {
						"x": this.LABEL_NAME_OFFSET_X,
						"y": this.LABEL_NAME_OFFSET_Y
					}
				};
			},

			/**
			 * ######### ######## ############## ########.
			 * @protected
			 * @param {Guid} id ############# ########
			 * @param {String} schemaName ######## #####
			 */
			openCardInChainById: function(id, schemaName) {
				var config = {
					"schemaName": schemaName + "Page",
					"id": id,
					"operation": "edit",
					"renderTo": "centerPanel",
					"isLinkClick": true
				};
				this.openCardInChain(config);
			},

			/**
			 * ########## ##### ## ###### # ######## #########.
			 * @protected
			 * @param {Object} node ####### #########
			 */
			onLabelLinkClick: function(node) {
				this.openCardInChainById(node.name, node.schemaName);
				this.clearAllDiagramNodes();
			},

			/**
			 * Opens node edit page.
			 * @param {Event} event Event data.
			 * @param {Object} node Node data.
			 */
			openNodePage: function(event, node) {
				this.openCardInChainById(node.name, node.schemaName);
			}
		});
		return BPMSoft.ServiceModelDiagramViewModel;
	});
