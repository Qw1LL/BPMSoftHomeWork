 define("CampaignTemplateGallery", ["CampaignGallery"], function() {
	/**
	 * Component for ts-campaign-template-gallery
	 */
	Ext.define("BPMSoft.control.CampaignTemplateGallery", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.CampaignTemplateGallery",

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"CampaignTemplateGallery-wrap\">',
			'<ts-campaign-template-gallery id=\"{id}\" ' +
			'class="ts-campaign-template-gallery-component">',
			'</ts-campaign-template-gallery>',
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
				wrapEl: "#CampaignTemplateGallery-wrap",
				galleryEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"templateSelected",
				"galleryViewCanceled"
			);
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			var el = this.galleryEl;
			if (el) {
				el.on("Selected", this.onItemSelected, this);
				el.on("Canceled", this.onCanceled, this);
			}
		},

		/**
		 *
		 * @param {Object} event Template selected action data.
		 */
		onItemSelected: function(event) {
			const templateId = event.browserEvent.detail.recordIds[0]
			this.fireEvent("templateSelected", templateId);
		},

		/**
		 *
		 */
		onCanceled: function(event) {
			this.fireEvent("galleryViewCanceled", event);
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.galleryEl;
			if (el) {
				el.un("Selected", this.onItemSelected, this);
				el.un("Canceled", this.onCanceled, this);
			}
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

		setResources: function(resources) {
			if (this.rendered) {
				this.galleryEl.resources = resources;
			}
		}
	});
	return BPMSoft.CampaignTemplateGallery;
});
