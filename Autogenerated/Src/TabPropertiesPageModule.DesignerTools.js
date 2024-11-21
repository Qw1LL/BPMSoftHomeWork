define("TabPropertiesPageModule", [
		"TabPropertiesPageModuleResources",
		"PageItemPropertiesPageModule"
	],
	function(resources) {
		Ext.define("BPMSoft.TabPropertiesPageModule", {
			extend: "BPMSoft.PageItemPropertiesPageModule",

			messages: {
				/**
				 * @message GetTabConfig
				 */
				"GetTabConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SaveTabConfig
				 */
				"SaveTabConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * @inheritdoc PageItemPropertiesPageModule#getItemConfigMessageName
			 * @override
			 */
			getItemConfigMessageName: "GetTabConfig",

			/**
			 * @inheritdoc PageItemPropertiesPageModule#saveItemConfigMessageName
			 * @override
			 */
			saveItemConfigMessageName: "SaveTabConfig",

			/**
			 * @inheritdoc BasePropertiesPageModule#getPageItemType
			 * @override
			 */
			getPageItemType: function() {
				return "tab";
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
			 * @override
			 */
			getPropertiesPageTranslation: function() {
				const baseConfig = this.callParent(arguments);
				const config = {
					"caption": this.resources.localizableStrings.TabModalBoxHeader,
				};
				return Object.assign({}, baseConfig, config);
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#init
			 * @override
			 */
			init: function() {
				this.initResources(resources);
				this.callParent(arguments);
			}

		});
		return BPMSoft.TabPropertiesPageModule;
	});
