define("CampaignDesigner", ["ext-base", "BPMSoft", "css!CampaignDesignerCSS",
		"SchemaDesigner", "CampaignSchemaDesigner", "CampaignSchemaDesignerNew"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.configuration.CampaignDesigner
		 */
		Ext.define("BPMSoft.configuration.CampaignDesigner", {
			extend: "BPMSoft.SchemaDesigner",
			alternateClassName: "BPMSoft.CampaignDesigner",

			schemaDesignerName: "BPMSoft.CampaignSchemaDesignerNew",

			/**
			 * @inheritdoc BPMSoft.SchemaDesigner#parseHash
			 * @override
			 */
			parseHash: function(hash) {
				var params = hash.split("/");
				var designer = params[0];
				var schemaUId = params[1];
				var entityId = params[2];
				var entitySchemaUId = params[3];
				return {
					designerName: designer,
					schemaUId: (schemaUId === "add") ? "" : schemaUId,
					entityId: entityId,
					entitySchemaUId: entitySchemaUId
				};
			},

			/**
			 * @inheritdoc BPMSoft.SchemaDesigner#initDesigner
			 * @overridden
			 */
			initDesigner: function(config) {
				this.callParent(arguments);
				var params = this.parseHash(config.hash);
				this.designer = this.Ext.create(this.schemaDesignerName, {
					sandbox: this.sandbox,
					schemaUId: params.schemaUId,
					entityId: params.entityId,
					entitySchemaUId: params.entitySchemaUId
				});
			}
		});

		return BPMSoft.configuration.CampaignDesigner;
	}
);
