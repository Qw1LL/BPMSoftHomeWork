define("BaseEditWithButtonGenerator", ["css!BaseEditWithButtonGenerator"], function() {
	Ext.define("BPMSoft.configuration.BaseEditWithButtonGenerator", {
		alternateClassName: "BPMSoft.BaseEditWithButtonGenerator",
		extend: "BPMSoft.ViewGenerator",
		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * @private
		 */
		_addExtraButton: function(baseControl, initializationConfig, actionButtonConfig) {
			const generatedButton = this._getButtonView(actionButtonConfig, initializationConfig);
			if (generatedButton) {
				const buttonContainer = this.getExtraButtonContainer(baseControl);
				buttonContainer.push(generatedButton);
			}
		},

		/**
		 * @private
		 */
		_getButtonView: function(config, initializationConfig) {
			const configButton = this.getExtraButtonViewConfig(config);
			const initConfig = this._getBaseConfig(initializationConfig);
			return this.generatePartial(configButton, initConfig)[0];
		},

		/**
		 * @private
		 */
		_getBaseConfig: function(config) {
			return Ext.apply({
				schema: {},
				schemaType: BPMSoft.SchemaType.MODULE
			}, config);
		},

		/**
		 * Generates config for control.
		 * @protected
		 * @param {Object} config Internal control config.
		 * @param {Object} initializationConfig Control config.
		 * @return {Object} Generated config BaseEdit with extra button.
		 */
		generateEditWithExtraButton: function(config, initializationConfig) {
			if (BPMSoft.Features.getIsDisabled("UseBaseEditWithButtonGenerator")) {
				delete config.generator;
				delete config.buttonConfig;
				return this.generatePartial(config, initializationConfig);
			}
			this.viewModelClass = initializationConfig.viewModelClass;
			const actionButtonConfig = BPMSoft.deepClone(config.buttonConfig);
			delete config.generator;
			delete config.buttonConfig;
			const baseControl = this.generateModelItem(config);
			this._addExtraButton(baseControl, initializationConfig, actionButtonConfig);
			return baseControl;
		},

		/**
		 * Get control container to insert button.
		 * @protected
		 * @virtual
		 * @param baseControl Parent entire control config.
		 * @returns {Array} Container config to insert button.
		 */
		getExtraButtonContainer: function(baseControl) {
			const editContainer = baseControl.items[0];
			return Ext.isArray(editContainer.items[0].items)
				? editContainer.items[0].items : editContainer.items;
		},

		/**
		 * Get view config for extra button.
		 * @protected
		 * @virtual
		 * @param {Object} buttonConfig Button configuration object.
		 * @param {String} buttonConfig.id Element id.
		 * @param {String} buttonConfig.imageConfig Button image url.
		 * @param {Function} buttonConfig.click Button click handler.
		 * @param {String} buttonConfig.markerValue Button marker value.
		 * @param {Object} buttonConfig.tag Button click tag value.
		 * @returns {Object} Extra button view config.
		 */
		getExtraButtonViewConfig: function(buttonConfig) {
			const config = {
				"id": buttonConfig.id || Ext.id(),
				"itemType": BPMSoft.ViewItemType.BUTTON,
				"imageConfig": buttonConfig.imageConfig,
				"classes": {
					"wrapperClass": ["base-edit-extra-button"]
				},
				"click": buttonConfig.click,
				"visible": buttonConfig.visible
			};
			config.markerValue = buttonConfig.markerValue || config.id;
			if (buttonConfig.tag) {
				config.tag = buttonConfig.tag;
			}
			return config;
		}
	});
	return Ext.create("BPMSoft.BaseEditWithButtonGenerator");
});
