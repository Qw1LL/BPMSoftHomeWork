define("ContentBuilderUserBlock", ["ContentBuilderUserBlockResources", "css!ContentBuilderUserBlock",
		"ContentBuilderBlock"], function(resources) {

	/**
	 * @class BPMSoft.controls.ContentBuilderUserBlock
	 */
	Ext.define("BPMSoft.controls.ContentBuilderUserBlock", {
		extend: "BPMSoft.ContentBuilderBlock",
		alternateClassName: "BPMSoft.ContentBuilderUserBlock",
		/**
		 * Element parameters.
		 * @override
		 * @type {Object}
		 */
		tplConfig: {
			classes: {
				wrapClasses: ["content-builder-element-wrap"],
				imageWrapClasses: ["content-builder-element-image-wrap-class", "user-block"],
				imageClasses: ["content-builder-element-image-class", "user-block"],
				captionWrapClasses: ["content-builder-element-caption-wrap-class", "user-block"]
			}
		},

		/**
		 * @inheritdoc BPMSoft.component#tpl
		 * @overridden
		 */
		tpl: [
			/* jscs:disable */
			/* jshint quotmark: false */
			'<div id="{id}-content-builder-element-wrap" class="{wrapClasses}">',
				'<img id="{id}-content-user-block-delete-icon" class="content-user-block-delete-image" src="' +
					BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DeleteImage) + '"' +
					'data-item-marker="delete-user-block-icon"/>',
				'<div class="{imageWrapClasses}">',
					'<img class="{imageClasses}" src="{imageUrl}"/>',
				'</div>',
				'<tpl if="!!caption">',
					'<div class="{captionWrapClasses}">',
						'{caption}',
					'</div>',
				'</tpl>',
			'</div>'
		],

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event
				 * The event generated when you click on the content user block delete icon.
				 */
				"deleteiconclick"
			);
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			var deleteIconEl = Ext.get(this.id + "-content-user-block-delete-icon");
			deleteIconEl.on("click", this.onUserBlockDeleteIconClick, this);
		},

		/**
		 * Handles on user block icon delete event.
		 * @protected
		 */
		onUserBlockDeleteIconClick: function() {
			this.fireEvent("deleteiconclick", this);
		}
	});
	return BPMSoft.ContentBuilderUserBlock;
});
