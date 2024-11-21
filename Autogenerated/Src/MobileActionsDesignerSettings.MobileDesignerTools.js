define("MobileActionsDesignerSettings", ["ext-base", "MobileBaseDesignerSettings"],
	function(Ext) {

		/**
		 * @class BPMSoft.configuration.MobileActionsDesignerSettings
		 * ##### ######### ########.
		 */
		var module = Ext.define("BPMSoft.configuration.MobileActionsDesignerSettings", {
			alternateClassName: "BPMSoft.MobileActionsDesignerSettings",
			extend: "BPMSoft.MobileBaseDesignerSettings",

			/**
			 * ###### ############ ########.
			 * @type {Object[]}
			 */
			items: null,

			/**
			 * @private
			 * In some modules there is no need to add default actions, cause this modules have own customized actions.
			 */
			notConfigurableModels: ["SocialMessage"],

			/**
			 * @private
			 */
			getDefaultItems: function() {
				if (Ext.Array.contains(this.notConfigurableModels, this.entitySchema.name)) {
					return [];
				}
				return [
					{
						name: "BPMSoft.configuration.action.ShareLink"
					},
					{
						name: "BPMSoft.ActionCopy"
					},
					{
						name: "BPMSoft.ActionDelete"
					}
				];
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerSettings#initializeDefaultValues
			 * @overridden
			 */
			initializeDefaultValues: function() {
				this.callParent(arguments);
				if (!this.items) {
					this.items = this.getDefaultItems();
				}
			},

			/**
			 * @inheritDoc BPMSoft.MobileBaseDesignerSettings#getSettingsConfig
			 * @overridden
			 */
			getSettingsConfig: function() {
				var settingsConfig = this.callParent(arguments);
				settingsConfig.items = this.items;
				return settingsConfig;
			}

		});
		return module;

	});
