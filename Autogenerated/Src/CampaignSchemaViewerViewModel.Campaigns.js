define("CampaignSchemaViewerViewModel", ["CampaignSchemaManager",
		"CampaignSchemaDesignerViewModelNew"], function() {
	Ext.define("BPMSoft.configuration.CampaignSchemaViewerViewModel", {
		extend: "BPMSoft.CampaignSchemaDesignerViewModelNew",
		alternateClassName: "BPMSoft.CampaignSchemaViewerViewModel",
		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#schemaManager
		 * @overridden
		 */
		schemaManager: BPMSoft.CampaignSchemaManager,

		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#contextHelpCode
		 * @overridden
		 */
		contextHelpCode: "CampaignSectionV2",

		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#urlHashPrefix
		 * @overridden
		 */
		urlHashPrefix: "campaign",

		/**
		 * @inheritdoc BPMSoft.model.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.addEvents(
				/**
				 * @event initializeBadges
				 * Event for initialization of analytics badges.
				 */
				"initializeBadges"
			);
		},

		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#onSchemaLoaded
		 * @override
		 */
		onSchemaLoaded: function(schema) {
			this.onSandboxInitialized();
			schema.entityId = this.$EntityId || schema.entityId;
			this.loadItems(schema);
			this.fireEvent("initializeBadges", this);
			this.fireEvent("initialized", this);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessSchemaDesignerViewModel#init
		 * @override
		 */
		init: function() {
			this.setVisiblePropertyPage(false);
			this.callParent(arguments);
			this.set("IsSearchVisible", false);
		},

		/**
		 * @inheritdoc BPMSoft.Designers.BaseProcessSchemaDesignerViewModel#saveElementProperties
		 * @override
		 */
		saveElementProperties: BPMSoft.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseProcessSchemaDesignerViewModel#onItemChanged
		 * @override
		 */
		onItemChanged: BPMSoft.emptyFn
	});
});
