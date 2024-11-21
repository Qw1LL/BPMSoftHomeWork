/* global ej: false */
/* jshint bitwise: false */
define("ServiceModelDiagram", ["BPMSoft", "ext-base", "ej-diagram"],
	function(BPMSoft, Ext) {

		/**
		 * @class BPMSoft.configuration.ServiceModelDiagram
		 * ##### ######### ############.
		 */
		Ext.define("BPMSoft.configuration.ServiceModelDiagram", {
			extend: "BPMSoft.Diagram",
			alternateClassName: "BPMSoft.ServiceModelDiagram",

			autoScroll: true,

			/**
			 * @inheritdoc BPMSoft.Diagram#onSelectionChange
			 * @overridden
			 */
			onSelectionChange: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.Diagram#nodeTemplate
			 * @overridden
			 */
			nodeTemplate: function(node) {
				if (!Ext.isEmpty(node)) {
					var shape = node.shape;
					if (shape && shape.type === ej.datavisualization.Diagram.Shapes.Image && shape.imageId) {
						shape.src = this.getImageSrc(shape.imageId);
					}
					this.nodePortsTemplate(node);
				}
			},

			/**
			 * ########## ### ############ ######## #### ###### #### ##### ###########.
			 * @param {Object} node ####### #########
			 */
			nodePortsTemplate: function(node) {
				BPMSoft.each(node.ports, function(port) {
					port.visibility = port.visibility || ej.Diagram.PortVisibility.Hidden;
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.Diagram#setDefaults
			 * @overridden
			 */
			setDefaults: function() {
				this.callParent(arguments);
				this.connectorConstraints = ej.Diagram.ConnectorConstraints.Delete;
				var nodeConstraints = ej.Diagram.NodeConstraints;
				this.nodeConstraints = nodeConstraints.Connect | nodeConstraints.Select | nodeConstraints.Drag |
					nodeConstraints.Shadow | nodeConstraints.Delete;
			},

			/**
			 * @inheritdoc BPMSoft.Diagram#getDiagramConfig
			 * @overridden
			 */
			getDiagramConfig: function() {
				var diagramConfig = this.callParent(arguments);
				Ext.apply(diagramConfig.diagram, {
					"tool": ej.datavisualization.Diagram.Tool.None
				});
				return diagramConfig;
			},

			/**
			 * @inheritdoc BPMSoft.Diagram#customizeDiagram
			 * @overridden
			 */
			customizeDiagram: function() {
				this.callParent(arguments);
				this.customizeRenderConnector();
				this.customizeRenderLabel();
				this.customizeWrapText();
				this.customizeUpdateSelector();
			},

			/**
			 * ########### ######### #######.
			 * @private
			 * */
			customizeRenderConnector: function() {
				var svgContext = ej.Diagram.SvgContext;
				var baseRenderConnector = svgContext.renderConnector;
				svgContext.renderConnector = function(connector, svg) {
					baseRenderConnector.apply(this, arguments);
					var attr = {
						id: connector.name + "segments"
					};
					var segments = svg.element(attr);
					if (segments) {
						ej.datavisualization.Diagram.Util.attr(segments, attr);
					}
				};
			},

			/**
			 * ########### ########## ######### ########.
			 * @private
			 */
			customizeUpdateSelector: function() {
				var svgContext = ej.Diagram.SvgContext;
				var baseUpdateNode = svgContext.updateSelector;
				svgContext.updateSelector = function(node, svg) {
					baseUpdateNode.apply(this, arguments);
					if (node && node.shape && node.shape.styles) {
						var segments = svg.element(node.shape.styles);
						if (segments) {
							ej.datavisualization.Diagram.Util.attr(segments, node.shape.styles);
						}
					}
				};
			},

			/**
			 * ########### ######### ########.
			 * @private
			 */
			customizeRenderLabel: function() {
				var svgContext = ej.Diagram.SvgContext;
				var scope = this;
				var baseRenderLabel = svgContext._renderLabel;
				svgContext._renderLabel = function(node, label, svg) {
					baseRenderLabel.apply(this, arguments);
					var lbAttr = {
						"id": node.name + "_" + label.name + "_lblbg",
						"data-item-marker": label.name + "_lblbg",
						"cursor": "pointer"
					};
					var labelBackground = svg.element(lbAttr);
					if (labelBackground) {
						ej.datavisualization.Diagram.Util.attr(labelBackground, lbAttr);
						if (label.isLink) {
							var model = scope.model;
							if (model) {
								$(labelBackground).click(function() {
									scope.diagram._clearSelection();
									model.onLabelLinkClick(node, label);
								});
							}
						}
					}
				};
			},

			/**
			 * ########### ########## ######## ## ######### #####.
			 * @private
			 */
			customizeWrapText: function() {
				var svgContext = ej.Diagram.SvgContext;
				var baseWrapText = svgContext._wrapText;
				svgContext._wrapText = function(node, textBBox, text, label, svg) {
					var appendLine = function(newWord) {
						var tspan = svg.tspan({
							"nodeName": node.name
						});
						text.appendChild(tspan);
						line = newWord;
						tspan.textContent = line;
						lineCount++;
						wordsInLineCount = 0;
					};
					var trimLine = function() {
						for (var i = line.length - 1; i > 0; i--) {
							line = line.substr(0, i);
							tspan.textContent = line;
							tempWidth = tspan.getComputedTextLength();
							if (tempWidth <= maxWidth) {
								tspan.textContent = line.substr(0, line.length - 3);
								if (!Ext.isIEOrEdge || !BPMSoft.getIsRtlMode()) {
									tspan.textContent = tspan.textContent + "...";
								}
								break;
							}
						}
					};
					if (label.defaultRendering === true) {
						return baseWrapText.apply(this, arguments);
					}
					var str = label.text;
					while (text.hasChildNodes()) {
						text.removeChild(text.lastChild);
					}
					var tspan;
					var childNodes = text.childNodes;
					if (childNodes && (str.length > 0)) {
						var maxWidth = label.width;
						var lineCount = 1;
						var words = str.match(/(\S+)|(\s+)/g);
						var wordsInLineCount = 0;
						var line = "";
						var tempWidth;
						tspan = svg.tspan({
							"nodeName": node.name
						});
						tspan.style.fontSize = label.fontSize;
						text.appendChild(tspan);
						var wordsLength = words.length;
						var maxLineCount = BPMSoft.getIsRtlMode() ? 2 : 3;
						for (var n = 0; n < wordsLength && lineCount < maxLineCount; n++) {
							tspan = childNodes[childNodes.length - 1];
							var tempLine = line + words[n];
							if (lineCount === 2) {
								tempLine = line + words.slice(n, words.length).join("");
								line = tempLine;
							}
							tspan.textContent = tempLine;
							tempWidth = tspan.getComputedTextLength();
							var isLineOverflow = tempWidth > maxWidth;
							if ((isLineOverflow && (wordsInLineCount === 1)) || lineCount === 2) {
								if (isLineOverflow) {
									trimLine();
								}
								appendLine(Ext.emptyString);
								continue;
							}
							if (isLineOverflow && (n > 0)) {
								tspan.textContent = line;
								if (Ext.isIEOrEdge && BPMSoft.getIsRtlMode()) {
									break;
								}
								tspan.textContent = tspan.textContent + "...";
								appendLine(Ext.emptyString);
								line = words[n];
								lineCount = 2;
								wordsLength++;
							} else {
								line = tempLine;
								tspan.textContent = line;
								wordsInLineCount++;
							}
						}
						tempWidth = tspan.getComputedTextLength();
						line = tspan.textContent;
						if (tempWidth > maxWidth) {
							trimLine();
						}
						this._wrapTextAlign(text, childNodes, label.fontSize, label.textAlign);
					}
				};
			},
			/**
			 * @inheritdoc BPMSoft.Diagram#customizeRenderNode
			 * @overridden
			 */
			customizeRenderNode: function() {
				this.callParent(arguments);
				var svgContext = ej.Diagram.SvgContext;
				var baseRenderNode = svgContext._renderNode;
				svgContext._renderNode = function(node, svg) {
					baseRenderNode.apply(this, arguments);
					if (!node.styles) {
						node.styles = {};
					}
					node.styles.id = node.name + "_backRect";
					node.styles["pointer-events"] = "none";
					var nodeBackground = svg.element(node.styles);
					if (nodeBackground) {
						ej.datavisualization.Diagram.Util.attr(nodeBackground, node.styles);
					}

					if (!node.shape) {
						node.shape = {};
					}
					if (!node.shape.styles) {
						node.shape.styles = {};
					}
					node.shape.styles.id = node.name + "_shape";
					var imageBackground = svg.element(node.shape.styles);
					if (imageBackground) {
						ej.datavisualization.Diagram.Util.attr(imageBackground, node.shape.styles);
					}
				};
			},

			/**
			 * @inheritdoc BPMSoft.Diagram#disableKeys
			 * @overridden
			 */
			disableKeys: function() {
				ej.Diagram.prototype._keydown = Ext.emptyFn;
				ej.Diagram.prototype._keyup = Ext.emptyFn;
			},

			/**
			 * ####### ######### ###### ## ###########.
			 * @param {Guid} imageId ############# ###########
			 * @return {String} #### # ###########
			 */
			getImageSrc: function(imageId) {
				if (!imageId) {
					return null;
				}
				return BPMSoft.ImageUrlBuilder.getUrl({
					"source": BPMSoft.ImageSources.SYS_IMAGE,
					"params": {
						"primaryColumnValue": imageId
					}
				});
			}
		});
	}
);
