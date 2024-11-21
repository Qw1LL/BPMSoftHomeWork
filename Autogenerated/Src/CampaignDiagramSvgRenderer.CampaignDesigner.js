define("CampaignDiagramSvgRenderer", ["BPMSoft", "SvgRenderer"], function(BPMSoft, SvgRenderer) {
	/**
	 * Class provides functionality for rendering SVG on the canvas.
	 */
	Ext.define("BPMSoft.CampaignDiagramSvgRenderer", {

		fixImageXlinkHref: function(svg) {
			return svg.replaceAll("xlink:href", "href");
		},

		_scaleAndTranslateSvg: function(svgGroup, svgGroupBox, targetWidth, targetHeight) {
			var widthScale = targetWidth / svgGroupBox.width;
			var heightScale = targetHeight / svgGroupBox.height;
			var scale = Math.min(widthScale, heightScale);
			var scaleTransform = "";
			if (scale < 1) {
				scaleTransform = "scale(" + scale + ") ";
			} else {
				scale = 1;
			}
			var translateX = (targetWidth - svgGroupBox.width * scale) / 2 - svgGroupBox.x;
			var translateY = (targetHeight - svgGroupBox.height * scale) / 2 - svgGroupBox.y;
			var translateTransform = "translate(" + translateX + "," + translateY + ")";
			svgGroup.setAttribute("transform", scaleTransform + translateTransform);
		},

		_createCanvas: function (width, height) {
			var canvas = document.createElement("canvas");
			canvas.width = width;
			canvas.height = height;
			return canvas;
		},

		_removeServiceTags: function(cloneSvgGroup) {
			var classesToRemove = ".layer-resizers, .layer-overlays, .layer-snap, .djs-outline, .djs-validate-outline";
			var nodes = cloneSvgGroup.querySelectorAll(classesToRemove);
			if (nodes) {
				nodes.forEach(function(node) {
					node.remove();	
				});
			}
		},

		svgToCanvas: function(svgSelector, targetWidth, targetHeight, renderCallback) {
			var svgElement = document.querySelector(svgSelector);
			if (!svgElement) {
				return;
			}
			var svgGroupBox = svgElement.querySelector("g.viewport").getBBox();
			var cloneElement = svgElement.cloneNode(true);
			var cloneSvgGroup = cloneElement.querySelector("g.viewport");
			this._scaleAndTranslateSvg(cloneSvgGroup, svgGroupBox, targetWidth, targetHeight);
			this._removeServiceTags(cloneSvgGroup);
			var svg = this.fixImageXlinkHref(cloneElement.outerHTML);
			var canvas = this._createCanvas(targetWidth, targetHeight);
			var context = canvas.getContext('2d');
			var renderer = SvgRenderer.Canvg.fromString(context, svg, {
				ignoreAnimation: true,
				ignoreMouse:     true
			});
			renderer.render();
			setTimeout(renderCallback.bind(this), 400, canvas);
        }
	});

	
	return new BPMSoft.CampaignDiagramSvgRenderer;
});
