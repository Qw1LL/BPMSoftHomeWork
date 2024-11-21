 /**
 * Parent: EmailTemplateUserTaskPropertiesPage => BaseActivityUserTaskPropertiesPage => BaseUserTaskPropertiesPage
 * => RootUserTaskPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("DcmEmailTemplateUserTaskPropertiesPage", [],
	function() {
		return {

			/**
			 * Use base DCM schema.
			 * @type {Boolean}
			 */
			useBaseDcmSchema: true,

			methods: {

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getMainRecordMappingConfig
				 * @override
				 */
				getMainRecordMappingConfig: function() {
					const mappingTag = this.tag;
					const disabledMappings = ["Sender"];
					const disabledIcons = ["EmailRecipientItem"];
					return {
						enabled: !Ext.Array.contains(disabledMappings, mappingTag),
						hideIcon: Ext.Array.contains(disabledIcons, mappingTag)
					};
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	}
);
