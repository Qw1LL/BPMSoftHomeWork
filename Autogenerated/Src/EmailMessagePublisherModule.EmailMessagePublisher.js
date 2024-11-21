define("EmailMessagePublisherModule", ["BaseMessagePublisherModule"],
		function() {
			Ext.define("BPMSoft.configuration.EmailMessagePublisherModule", {
				extend: "BPMSoft.BaseMessagePublisherModule",
				alternateClassName: "BPMSoft.EmailMessagePublisherModule",

				/**
				 * @inheritdoc BPMSoft.BaseMessagePublisherModule#initSchemaName
				 * @overridden
				 */
				initSchemaName: function() {
					this.schemaName = "EmailMessagePublisherPage";
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaModuleV2#render
				 * @overridden
				 */
				render: function (renderTo) {
					if (Ext.isObject(renderTo) && Ext.isEmpty(renderTo.dom) && !Ext.isEmpty(renderTo.el)) {
						var domEl = Ext.getElementById(renderTo.el.id);
						renderTo.dom = domEl;
					}
					this.callParent(arguments);
				}
			});
			return this.BPMSoft.EmailMessagePublisherModule;
		});
