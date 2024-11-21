define("MessageHistoryMultilineLabel", ["MessageHistoryMultilineLabelResources", "MultilineLabel",
		"css!MessageHistoryMultilineLabel"],
	function(resources) {

		Ext.define("BPMSoft.MessageHistoryMultilineLabel", {
			extend: "BPMSoft.MultilineLabel",
			alternateClassName: "BPMSoft.controls.MessageHistoryMultilineLabel",

			/**
			 * @inheritdoc BPMSoft.Component#tpl
			 * @override
			 */
			tpl: [
				"<div id=\"{id}\" class=\"{multilineLabelClass}\">",
				"<div id=\"{id}_content\" class=\"{labelContentContainer}\">",
				"<div id=\"{id}_label\" class=\"{labelClass}\">",
				"<tpl if=\"isHtmlBody\">",
				"<iframe id=\"{id}_iframe\">",
				"</tpl>",
				"{%this.renderContent(out, values)%}",
				"<tpl if=\"isHtmlBody\">",
				"</iframe>",
				"</tpl>",
				"</div>",
				"</div>",
				"<div class=\"read-buttons-container\">",
					"<div id=\"{id}_readMore\" class=\"{readMoreClass}\">",
						"<div class=\"collapse-history-message-image-container\">",
							"<img class=\"collapse-history-message\" src={readMoreButtonImage} />",
						"</div>",
						"<label class=\"read-button-label\">{readMoreCaption}</label>",
					"</div>",
					"<div id=\"{id}_readLess\" class=\"{readLessClass}\">",
						"<div class=\"collapse-history-message-image-container\">",
							"<img class=\"collapse-history-message\" src={readLessButtonImage} />",
						"</div>",
						"<label class=\"read-button-label\">{readLessCaption}</label>",
					"</div>",
				"</div>",
				"</div>"
			],

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#frameMinHeight
			 * @override
			 */
			frameMinHeight: 400,

			/**
			 * Stores height for the element.
			 */
			currentElementHeight: 400,

			/**
			 * Stores a value on which the element height will be increased.
			 */
			elementNextHeightStep: 400,

			/**
			 * "Read less" button visibility.
			 */
			readLessVisible: false,

			/**
			 * "Read more" button visibility.
			 */
			readMoreVisible: false,

			/**
			 * "Expanded mode" in which full content shows always.
			*/
			isExpandedMode: false,

			/**
			 * Attribute indicates that iFrame resizing is in progress.
			 */
			isResizing: false,

			/**
			 * Attribute indicates that quotation already initialized.
			 */
			quoteNotInitialized: true,

			/**
			 * Quotation offset.
			 */
			quoteOffsetHeight: 0,

			/**
			 * @inheritdoc BPMSoft.Component#getTplData
			 * @override
			 */
			getTplData: function() {
				var labelTplData = this.callParent(arguments);
				var readLessButtonCaption = resources.localizableStrings.readLessButtonCaption;
				var readMoreButtonCaption = resources.localizableStrings.readMoreButtonCaption;
				var readLessButtonImage = resources.localizableImages.readLessButtonImage;
				var readMoreButtonImage = resources.localizableImages.readMoreButtonImage;
				Ext.apply(labelTplData, {
					readLessCaption: BPMSoft.encodeHtml(readLessButtonCaption),
					readMoreCaption: BPMSoft.encodeHtml(readMoreButtonCaption),
					readLessClass: ["read-less"],
					readLessButtonImage: BPMSoft.ImageUrlBuilder.getUrl(readLessButtonImage),
					readMoreButtonImage: BPMSoft.ImageUrlBuilder.getUrl(readMoreButtonImage)
				});
				return labelTplData;
			},

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#resizeIframe
			 * @override
			 */
			resizeIframe: function() {
				var body = this.getIframeBody();
				if (!body) {
					return;
				}
				this.setReadMoreButtonVisible();
				var calculatedHeight = this.getCalculatedHeight();
				var height = calculatedHeight + "px";
				if (calculatedHeight !== body.dom.scrollHeight && this.isExpandedMode) {
					this.isExpandedMode = false;
					this.iframeEl.setStyle("height", height);
					return;
				}
				this.iframeEl.setStyle("height", height);
				if (calculatedHeight === body.dom.scrollHeight && !this.isExpandedMode) {
					this.isExpandedMode = true;
				}
			},

			/**
			 * Fit iframe size based on it's content.
			 * @protected
			 */
			fitIframeHeight: function () {
				if (!this.iframeEl || this.iframeEl.getHeight() === this.frameMinHeight) {
					return;
				}
				if (this.iframeEl.getHeight() > 150 && !this.isQuoteMode()) {
					this.iframeEl.setStyle("height", "100%");
				}
				var expandedHeight = this.iframeEl.dom.contentDocument.body.scrollHeight;
				if (parseInt(this.iframeEl.getStyle("height"), 10) !== expandedHeight &&
					!this.isQuoteMode()) {
					this.iframeEl.setStyle("height", expandedHeight + "px");
				}
			},

			/**
			 * Window resize event handler.
			 */
			onResize: function() {
				if (this.isResizing || !this.isExpandedMode) {
					return;
				}
				this.isResizing = true;
				this.fitIframeHeight();
				BPMSoft.delay(function() {
					this.isResizing = false;
				}, this, 500);
			},

			/**
			 * Subscribe iframe on "resize" event.
			 */
			subscribeResizeListener: function() {
				if (this.iframeEl) {
					Ext.EventManager.addListener(this.iframeEl.dom.contentWindow, "resize", this.onResize, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.Component#getSelectors
			 * @override
			 */
			getSelectors: function() {
				var selectors = this.callParent(arguments);
				selectors.readLessButtonEl = "#" + this.id + "_readLess";
				return selectors;
			},

			/**
			 * @inheritdoc BPMSoft.Component#initDomEvents
			 * @override
			 */
			initDomEvents: function() {
				this.callParent(arguments);
				this.readLessButtonEl.on("click", this.onReadLessButtonClick, this);
				this.subscribeResizeListener();
			},

			/**
			 * @inheritdoc BPMSoft.Component#clearDomListeners
			 * @override
			 */
			clearDomListeners: function() {
				this.callParent(arguments);
				if (this.rendered) {
					this.readLessButtonEl.un("click", this.onReadLessButtonClick, this);
				}
			},

			/**
			 * Shows "Read more" button.
			 * @protected
			 * @virtual
			 */
			showReadMoreButton: function () {
				var labelElHeight = this.getLabelElementHeight();
				var wrapEl = this.getWrapEl();
				if (labelElHeight > this.currentElementHeight || this.isQuoteMode()) {
					wrapEl.addCls("read-more-button-visible");
					this.readMoreVisible = true;
				}
			},

			/**
			 * Hides "Read more" button.
			 * @protected
			 * @virtual
			 */
			hideReadMoreButton: function() {
				var labelElHeight = this.getLabelElementHeight();
				var wrapEl = this.getWrapEl();
				if (labelElHeight <= this.currentElementHeight) {
					wrapEl.removeCls("read-more-button-visible");
					this.readMoreVisible = false;
				}
			},

			/**
			 * Shows "Read less" button.
			 * @protected
			 * @virtual
			 */
			showReadLessButton: function () {
				const wrapEl = this.getWrapEl();
				if (this.currentElementHeight > this._getComparisonHeightForLessButton()) {
					wrapEl.addCls("read-less-button-visible");
					this.readLessVisible = true;
				}
			},

			/**
			 * @private
			 */
			_getComparisonHeightForLessButton: function() {
				return this.isQuoteMode() ? this.quoteOffsetHeight : this.frameMinHeight;
			},

			/**
			 * Hides "Read less" button.
			 * @protected
			 * @virtual
			 */
			hideReadLessButton: function () {
				var wrapEl = this.getWrapEl();
				if (this.currentElementHeight <= this._getComparisonHeightForLessButton()) {
					wrapEl.removeCls("read-less-button-visible");
					this.readLessVisible = false;
				}
			},

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#setReadMoreButtonVisible
			 * @override
			 */
			setReadMoreButtonVisible: function () {
				this.setQuotesParameters();
				this.showReadMoreButton();
				this.showReadLessButton();
				this._applyReadMoreLessContainerVisibility();
				var body = this.getIframeBody();
				if (!body) {
					return;
				}
				var calculatedHeight = this.getCalculatedHeight();
				if (calculatedHeight === body.dom.scrollHeight && !this.isExpandedMode) {
					this.isExpandedMode = true;
				}
			},

			/**
			 * Gets height of the element.
			 * @returns {Number} Element height.
			 */
			getLabelElementHeight: function () {
				return this.isHtmlBody ? this.getContentHeight() : this.labelEl.getHeight();
			},

			/**
			 * Gets height of the element or minimum permissible height.
			 * @returns {number}
			 */
			getLabelElementDefaultHeight: function () {
				return Math.min(this.getLabelElementHeight(), this.frameMinHeight);
			},

			/**
			 * Increments content height for the element.
			 * @protected
			 * @virtual
			 */
			incrementContentElementHeight: function() {
				this.setContentVisibleClass();
				if (this.isHtmlBody) {
					this.resizeIframe();
				} else {
					this.currentElementHeight = this.getCalculatedHeight();
					this.setContentElementHeight();
				}
			},

			/**
			 * Decrements content height for the element.
			 * @protected
			 * @virtual
			 */
			decrementContentElementHeight: function () {
				this.setContentVisibleClass();
				if (this.isHtmlBody) {
					this.resizeIframe();
				} else {
					this.currentElementHeight = (this.currentElementHeight < this.frameMinHeight)
						? this.frameMinHeight
						: this.currentElementHeight;
					this.setContentElementHeight();
				}
			},

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#prepareOnRender
			 * @override
			 */
			prepareOnRender: function () {
				this.callParent(arguments);
				this.setContentVisibleClass();
				let body = this.contentEl;
				if (!this.isHtmlBody) {
					this.currentElementHeight = this.getLabelElementDefaultHeight();
					this.setContentElementHeight();
				} else {
					var bodyEl = this.getIframeBody();
					bodyEl.setStyle("width", "100%");
					bodyEl.setStyle("word-wrap", "break-word");
					BPMSoft.delay(this.fitIframeHeight, this, 500);
					body = bodyEl;
				}
				this._decorateImages(body);
			},

			/**
			 * Sets height for the element.
			 * @protected
			 * @virtual
			 */
			setContentElementHeight: function () {
				this.contentEl.setStyle("height", this.currentElementHeight >= this.getLabelElementHeight()
					? "100%" : this.currentElementHeight + "px");
			},

			/**
			 * Calculates height for the element.
			 * @returns {Number} Calculated element height. When new calculated height bigger than element height,
			 * returns calculated remains height.
			 */
			getCalculatedHeight: function () {
				var remainsHeight = this.getLabelElementHeight() - this.currentElementHeight + this.frameMinHeight;
				if (remainsHeight <= this.elementNextHeightStep) {
					return this.currentElementHeight - this.elementNextHeightStep + remainsHeight;
				}
				return this.currentElementHeight;
			},

			/**
			 * Check if it is quote mode.
			 * @protected
			 * @returns {Boolean} True if it is quote mode, otherwise false
			 */
			isQuoteMode: function() {
				return this.quoteOffsetHeight > 0;
			},

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#setIframeHeightStyle
			 * @override
			 */
			setIframeHeightStyle: function() {
				if(this.isQuoteMode()) {
					const height = this.quoteOffsetHeight + "px";
					this.iframeEl.setStyle("height", height);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Try to find quotation in content and set offset height.
			 * @protected
			 */
			setQuotesParameters: function() {
				if(this.quoteNotInitialized && this.isHtmlBody &&
					BPMSoft.Features.getIsEnabled("QuotedEmailInMessageHistory")) {
					const quotes = this.iframeEl.dom.contentDocument.getElementsByTagName("blockquote");
					this.quoteNotInitialized = false;
					if(quotes && quotes[0]) {
						let element = quotes[0];
						let offset = 0;
						do {
							if (Ext.isNumber(element.offsetTop)) {
								offset += element.offsetTop;
							}
							element = element.offsetParent;
						} while(element);
						this.quoteOffsetHeight = this.currentElementHeight = offset;
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.MultilineLabel#onReadMoreButtonClick
			 * @override
			 */
			onReadMoreButtonClick: function() {
				this.currentElementHeight += this.elementNextHeightStep;
				this.incrementContentElementHeight();
				this.hideReadMoreButton();
				this.showReadLessButton();
			},

			/**
			 * "Read less" button handler. Roll ups text.
			 * @protected
			 * @virtual
			 */
			onReadLessButtonClick: function() {
				this.currentElementHeight -= this.elementNextHeightStep;
				this.decrementContentElementHeight();
				this.hideReadLessButton();
				this.showReadMoreButton();
			},

			/**
			 * @private
			 */
			_applyReadMoreLessContainerVisibility: function() {
				var wrapEl = this.getWrapEl();
				if (!this.readMoreVisible && !this.readLessVisible) {
					wrapEl.addCls("read-buttons-container-hidden");
				} else {
					wrapEl.removeCls("read-buttons-container-hidden");
				}
			},

			/**
			 * @private
			 */
			_decorateImages: function(body) {
				if (Ext.isEmpty(body)) {
					return;
				}
				const imageTags = this._findImages(body);
				BPMSoft.each(imageTags, function(el) {
					el.addEventListener("click", this.onImageClick);
					el.style.cursor = "pointer";
				}, this);
			},

			/**
			 * @private
			 */
			_findImages: function(body) {
				const allImages = body.query("img");
				const imagesInLink = body.query("a:has(img) img");
				return BPMSoft.difference(allImages, imagesInLink);
			},
			/**
			 * Handles click on image.
			 * @param {Object} event Mouse click event.
			 */
			onImageClick: function(event) {
				const img = event.target;
				const body = Ext.getBody();
				const box = body.getBox();
				const container = document.createElement("div");
				let isToFit = false;
				const isLargeSize = img.width >= box.width || img.height >= box.height;
				const isLargeNaturalSize = img.naturalWidth >= box.width || img.naturalHeight >= box.height;
				if (isLargeSize || isLargeNaturalSize) {
					isToFit = true;
				}
				container.classList.add("full-image-container");
				container.style.backgroundImage = "url('" + img.src + "')";
				container.style.backgroundSize = isToFit ? "contain" : "auto";
				container.addEventListener("click", function() {
					Ext.removeNode(container);
				});
				body.appendChild(container);
			}
		});

		return BPMSoft.MessageHistoryMultilineLabel;
	}
);
