define("CampaignSchemaViewerModule", ["ext-base", "BPMSoft", "BaseModule", "CampaignSchemaViewer"],
		function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.CampaignSchemaViewerModule", {
		alternateClassName: "BPMSoft.CampaignSchemaViewerModule",
		extend: "BPMSoft.BaseModule",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 * Schema designer instance.
		 * @private
		 * @type {BPMSoft.BaseSchemaDesigner}
		 */
		designer: null,

		/**
		 * Initializes campaign schema viewer.
		 */
		init: function() {
			this.initDesigner();
			if (this.renderToId && this.designer && this.designer.schemaUId) {
				this.designer.render({
					renderTo: Ext.get(this.renderToId),
					sandbox: this.sandbox
				});
			}
		},

		/**
		 * Initializes campaign schema viewer instance.
		 */
		initDesigner: function() {
			var viewerConfig = this.sandbox.publish("GetSchemaViewerConfig", null, [this.sandbox.id]);
			this.designer = this.Ext.create("BPMSoft.CampaignSchemaViewer", {
				sandbox: this.sandbox,
				schemaUId: viewerConfig.schemaUId,
				entityId: viewerConfig.entityId,
				entitySchemaUId: viewerConfig.entitySchemaUId
			});
		},

		/**
		 * @overridden
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 */
		onDestroy: function() {
			var designer = this.designer;
			if (designer) {
				designer.destroy();
			}
			this.callParent(arguments);
		}
	});
	return BPMSoft.CampaignSchemaViewerModule;
});
