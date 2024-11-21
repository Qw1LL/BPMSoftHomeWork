/**
 * Parent: EmailTemplatePageMultilingual
 */
define("ChatTemplatePage", ["OmnichannelConsts"], function(OmnichannelConsts) {
	return {
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseMultilingualEntityLookupPage#getModuleSchemaName
			 * @override
			 */
			getModuleSchemaName: function() {
				return "ChatTemplateContentEditSchema";
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				if (this.isNew && this.isEmpty(this.get("Object"))) {
					this.setOmniChatObject();
				}
			},

			/**
			 * Returns query to SysSchemaInfo.
			 * @protected
			 * @return {BPMSoft.EntitySchemaQuery} Query to SysSchemaInfo.
			 */
			getVwSysSchemaInfoEsq: function() {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "VwSysSchemaInfo"
				});
				esq.addColumn("Caption");
				return esq;
			},

			/**
			 * Sets OmniChat schema to Object property.
			 * @protected
			 */
			setOmniChatObject: function() {
				const esq = this.getVwSysSchemaInfoEsq();
				esq.getEntity(OmnichannelConsts.OmniChatSchemaUId, function(result) {
					if (result.success) {
						var entity = result.entity;
						this.set("Object", {
							value: OmnichannelConsts.OmniChatSchemaUId,
							displayValue: entity.get('Caption')
						});
					}
				}, this);
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Object",
				"values": {
					"enabled": false
				}
			},
		]/**SCHEMA_DIFF*/
	};
});
