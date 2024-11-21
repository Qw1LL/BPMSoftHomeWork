 define("OmnichannelContactsMenu", [], function() {
	Ext.define("BPMSoft.controls.OmnichannelContactsMenu", {
		extend: "BPMSoft.Menu",
		alternateClassName: "BPMSoft.OmnichannelContactsMenu",

		/**
		 * @inheritDoc BPMSoft.Image#fixY
		 * @overridden
		 */
		fixY: function(sizes) {
			var menuDocumentOffset = this.menuDocumentOffset;
			var position = sizes.position;
			var buttonBox = sizes.buttonBox;
			var viewSize = sizes.viewSize;
			var bodyScroll = sizes.bodyScroll;
			var menuSize = sizes.menuSize;
			var canFitAbove = (menuSize.height < (buttonBox.y - bodyScroll.top));
			var canFitUnder = ((viewSize.height - (buttonBox.y + buttonBox.height - bodyScroll.top)) > menuSize.height);
			var spaceAbove = viewSize.bottom - buttonBox.bottom;
			var hasMoreSpaceAbove = ((buttonBox.y - bodyScroll.top) > spaceAbove);
			var isBottomMenu = true;
			var hasScrolling = false;
			var height = 0;
			if (!canFitUnder) {
				if (canFitAbove) {
					position.y = sizes.buttonBox.y - sizes.menuSize.height;
					isBottomMenu = false;
				} else {
					this.addScrollBars();
					hasScrolling = true;
					if (hasMoreSpaceAbove) {
						position.y = sizes.bodyScroll.top + menuDocumentOffset;
						height = sizes.buttonBox.y - sizes.bodyScroll.top - menuDocumentOffset;
						isBottomMenu = false;
					} else {
						height = sizes.viewSize.bottom - sizes.buttonBox.bottom - menuDocumentOffset - 100;
					}
				}
			}
			var outSideOffset = this.outSideOffset;
			if (Ext.isIE) {
				outSideOffset += this.outSideOffsetIE;
			}
			if (!this.isRootMenu) {
				if (isBottomMenu) {
					position.y -= outSideOffset;
				}
				height += outSideOffset;
			}
			if (height && hasScrolling) {
				this.wrapEl.setHeight(height);
			}
		},

		/**
		 * @inheritDoc BPMSoft.Image#addScrollBars
		 * @overridden
		 */
		addScrollBars: function() {}
	});
});
