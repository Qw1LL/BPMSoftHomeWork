define("MobileDesignerConfigManager", ["EntityStructureHelperMixin"],
	function() {

		Ext.define("BPMSoft.configuration.MobileDesignerConfigManager", {
			alternateClassName: "BPMSoft.MobileDesignerConfigManager",

			mixins: {
				EntityStructureHelper: "BPMSoft.EntityStructureHelperMixin"
			},

			config: {

				schemaInstance: null

			},

			//region Methods: Private

			/**
			 * @private
			 */
			getParentDesignerConfig: function(diffs) {
				var parentConfig = [];
				for (var i = 0, ln = diffs.length; i < ln; i++) {
					parentConfig = BPMSoft.JsonApplier.applyDiff(parentConfig, diffs[i]);
				}
				return parentConfig;
			},

			/**
			 * @private
			 */
			getSchemaDiff: function(config) {
				var parentConfig = this.getParentDesignerConfig(config.diffs);
				var schemaSettings = JSON.parse(this.getSchemaInstance().body);
				var designerConfig = BPMSoft.JsonApplier.applyDiff(parentConfig, schemaSettings);
				designerConfig = (designerConfig && designerConfig.length === 0) ? null : designerConfig[0];
				var localizableStrings = config.localizableStrings;
				if (localizableStrings && designerConfig !== null) {
					designerConfig.localizableStrings = localizableStrings;
				}
				return designerConfig;
			},

			/**
			 * @private
			 */
			formatMetadata: function(metadata) {
				return JSON.stringify(metadata, null, "\t");
			},

			/**
			 * @private
			 */
			processDesignerConfig: function(config) {
				var items = (!Ext.isArray(config)) ? [config] : config;
				BPMSoft.each(items, function(item) {
					BPMSoft.each(item, function(itemProperty) {
						if (Ext.isArray(itemProperty)) {
							this.processDesignerConfig(itemProperty);
						}
					}, this);
					item.operation = "insert";
				}, this);
				return config;
			},

			/**
			 * @private
			 */
			getSchemaDiffs: function(config) {
				var schemaInstance = this.getSchemaInstance();
				var schemaPackageUId = schemaInstance.packageUId;
				BPMSoft.SchemaDesignerUtilities.getSchemaHierarchy(schemaInstance, function(schemas) {
					var diffs = [];
					var localizableStrings = {};
					for (var i = 0, ln = schemas.length; i < ln; i++) {
						var schema = schemas[i];
						var schemaLocalizableStrings =
							BPMSoft.MobileDesignerSchemaManager.getSchemaLocalizableStrings(schema);
						localizableStrings = Ext.merge(localizableStrings, schemaLocalizableStrings);
						if (!schema || schema.packageUId === schemaPackageUId) {
							continue;
						}
						var diff = JSON.parse(schema.body);
						if (diff) {
							diffs.push(diff);
						}
					}
					Ext.callback(config.callback, config.scope, [diffs, localizableStrings]);
				}, this);
			},

			//#endregion

			//region Methods: Public

			constructor: function(config) {
				this.initConfig(config);
			},

			/**
			 * ###### ########## ####### ######## ## ###### ####### ########, ###### ## ###### #######.
			 * @param {Object} config ################ ###### # ########### ###### ######:
			 * @param {Object} config.schemaInstance ######### #####.
			 * @param {Function} config.callback ####### ######### ######.
			 * @param {Object} config.scope ######## ####### ######### ######.
			 */
			buildDesignerConfig: function(config) {
				this.getSchemaDiffs({
					callback: function(diffs, localizableStrings) {
						var schemaDiff = this.getSchemaDiff({
							diffs: diffs,
							localizableStrings: localizableStrings
						});
						Ext.callback(config.callback, config.scope, [schemaDiff]);
					},
					scope: this
				});
			},

			applyDesignerConfig: function(config) {
				var schemaInstance = this.getSchemaInstance();
				var designerConfig = this.processDesignerConfig(config.designConfig);
				this.getSchemaDiffs({
					callback: function(diffs) {
						var parentConfig = this.getParentDesignerConfig(diffs);
						designerConfig.name = "settings";
						var diff = BPMSoft.JsonDiffer.getJsonDiff(parentConfig, designerConfig);
						var body = this.formatMetadata(diff);
						schemaInstance.setPropertyValue("body", body);
						var localizableStrings = config.designConfig.localizableStrings;
						for (var name in localizableStrings) {
							if (localizableStrings.hasOwnProperty(name)) {
								var value = localizableStrings[name];
								BPMSoft.MobileDesignerSchemaManager.addLocalizableString(schemaInstance, name, value);
							}
						}
						Ext.callback(config.callback, config.scope, [diff]);
					},
					scope: this
				});
			}

			//#endregion

		});

		return BPMSoft.MobileDesignerConfigManager;
	}
);
