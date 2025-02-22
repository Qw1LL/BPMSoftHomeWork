﻿define("SearchEditGenerator", ["ViewGeneratorV2"],
	function() {
		/**
		 * @class BPMSoft.configuration.SearchEditGenerator
		 * Custom view generator for BaseSearchEdit control. Extends BPMSoft.ViewGenerator.
		 */
		Ext.define("BPMSoft.configuration.SearchEditGenerator", {
			extend: "BPMSoft.ViewGenerator",
			alternateClassName: "BPMSoft.SearchEditGenerator",

			/**
			 * Returns configuration for {BPMSoft.BaseSearchEdit}.
			 * @private
			 * @return {Object} Configuration object.
			 */
			getSearchEditConfig: function() {
				var inlineTextEditConfig = {
					"className": "BPMSoft.BaseSearchEdit"
				};
				return inlineTextEditConfig;
			},

			/**
			 * Generates view config for BaseSearchEdit control.
			 * @param {Object} schemaItemConfig Schema item configuration.
			 * @param {Object} generatorConfig Configuration for view generator.
			 * @return {Object} view config.
			 */
			generate: function(schemaItemConfig, generatorConfig) {
				this.initGenerator(generatorConfig);
				var controlConfig = schemaItemConfig.controlConfig;
				var className = controlConfig.className;
				var id = this.getControlId(schemaItemConfig, className);
				var searchEditControlConfig = this.getSearchEditConfig();
				this.applyControlId(searchEditControlConfig, schemaItemConfig, id);
				var defaultBindings = this.getAutoBindings(schemaItemConfig);
				Ext.apply(searchEditControlConfig, defaultBindings);
				Ext.apply(searchEditControlConfig, this.getConfigWithoutServiceProperties(schemaItemConfig,
						["generator", "labelConfig", "placeholder"]));
				this.applyControlConfig(searchEditControlConfig, schemaItemConfig);
				var searchEditWrapControlConfig = this.generateEditControlWrap(searchEditControlConfig);
				searchEditWrapControlConfig.items.push(searchEditControlConfig);
				return searchEditWrapControlConfig;
			},

			/**
			 * Initializes base generator properties.
			 * @param {Object} generatorConfig Configuration object.
			 */
			initGenerator: function(generatorConfig) {
				var schema = generatorConfig.schema;
				this.generateConfig = generatorConfig;
				this.schemaName = generatorConfig.schemaName || (schema && schema.schemaName) || "";
				this.schemaType = generatorConfig.schemaType || (schema && schema.type);
				this.schemaProfile = schema.profile || [];
				this.viewModelClass = generatorConfig.viewModelClass;
				this.customGenerators = generatorConfig.customGenerators;
			}
		});
		return Ext.create("BPMSoft.SearchEditGenerator");
	});
