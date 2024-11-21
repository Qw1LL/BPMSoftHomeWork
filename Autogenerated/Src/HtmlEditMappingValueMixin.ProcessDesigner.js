define("HtmlEditMappingValueMixin", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.mixins.HtmlEditMappingValueMixin", {
		alternateClassName: "BPMSoft.HtmlEditMappingValueMixin",

		/**
		 * Initialize mixin. Subscribes on change events by attributes config.
		 */
		init: function() {
			var attributesConfig = this.getAttributesConfig();
			if (attributesConfig == null) {
				return;
			}
			this.attributesConfig = attributesConfig;
			BPMSoft.each(attributesConfig, function(attributeConfig, attributeName) {
				this.on("change:" + attributeName, this.onAttributeChange.bind(this, attributeName));
				this.on("change:" + attributeConfig.displayAttributeName, this.onDisplayAttributeChange.bind(this, attributeName));
			}, this);
		},

		/**
		 * Returns attributes config. Like this:
		 * 	{
		 * 		attributeName: {
		 * 			displayAttributeName: [DisplayAttributeName],
		 * 			enabledAttributeName: [EnabledAttributeName]
		 * 		}
		 * 	}
		 * @virtual
		 * @return {Object}
		 */
		getAttributesConfig: BPMSoft.emptyFn,

		/**
		 * Returns attribute config by name.
		 * @param {String} name Attribute name.
		 * @return {Object}
		 */
		getAttributeConfigByName: function(name) {
			return this.attributesConfig[name];
		},

		/**
		 * Attribute change event handler. If value is mapping value, sets false to
		 * 'enabledAttribute', and to display value to 'displayAttribute'. If vlaue is not mapping,
		 * sets to 'enabledAttribute' true.
		 * @private
		 * @param {String} attributeName CHanged attribute name.
		 */
		onAttributeChange: function(attributeName) {
			var attributeConfig = this.getAttributeConfigByName(attributeName);
			var attributeValue = this.get(attributeName);
			var isMapping = BPMSoft.ProcessSchemaDesignerUtilities.getIsMappingParameterValue(attributeValue);
			this.set(attributeConfig.enabledAttributeName, !isMapping);
			var displayValue = "";
			if (attributeValue) {
				displayValue = attributeValue.displayValue || attributeValue.value;
			}
			this.set(attributeConfig.displayAttributeName, displayValue);
		},

		/**
		 * Sets attribute value to constant value when 'enabledAttribute' is true.
		 * @private
		 * @param {String} attributeName CHanged attribute name.
		 */
		onDisplayAttributeChange: function(attributeName) {
			var attributeConfig = this.getAttributeConfigByName(attributeName);
			var isEnabled = this.get(attributeConfig.enabledAttributeName);
			if (isEnabled) {
				var displayValue = this.get(attributeConfig.displayAttributeName);
				var attributeValue = {
					value: displayValue,
					displayValue: displayValue,
					source: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
				};
				this.set(attributeName, attributeValue);
			}
		}
	});
	return BPMSoft.HtmlEditMappingValueMixin;
});
