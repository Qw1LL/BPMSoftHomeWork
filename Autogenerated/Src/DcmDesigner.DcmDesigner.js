define("DcmDesigner", ["ext-base", "BPMSoft", "SchemaDesigner", "DcmSchemaDesigner"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.configuration.DcmDesigner
		 */
		Ext.define("BPMSoft.configuration.DcmDesigner", {
			extend: "BPMSoft.SchemaDesigner",
			alternateClassName: "BPMSoft.DcmDesigner",

			/**
			 * @inheritdoc BPMSoft.SchemaDesigner#parseHash
			 * @overridden
			 */
			parseHash: function(hash) {
				var params = hash.split("/");
				var designer = params[0];
				var schemaId = params[1];
				var dcmSettingsId = params[2];
				var packageUId = params[3];
				return {
					designerName: designer,
					id: (schemaId === "add") ? "" : schemaId,
					dcmSettingsId: dcmSettingsId,
					packageUId: packageUId
				};
			},

			/**
			 * @inheritdoc BPMSoft.SchemaDesigner#initDesigner
			 * @overridden
			 */
			initDesigner: function(config) {
				this.callParent(arguments);
				var params = this.parseHash(config.hash);
				this.designer = Ext.create("BPMSoft.DcmSchemaDesigner", {
					sandbox: this.sandbox,
					schemaUId: params.id,
					dcmSettingsId: params.dcmSettingsId,
					packageUId: params.packageUId
				});
			}
		});

		return BPMSoft.configuration.DcmDesigner;
	}
);
