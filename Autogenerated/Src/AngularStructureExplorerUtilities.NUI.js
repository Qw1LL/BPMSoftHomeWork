define("AngularStructureExplorerUtilities", ["ConfigurationEnums", "AngularStructureExplorerViewModel", "StructureExplorer"],
	function() {
		Ext.define("BPMSoft.configuration.AngularStructureExplorerUtilities", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.AngularStructureExplorerUtilities",

			//region Methods: Private

			_convertParameters: function(config) {
				config.excludedDataValueTypes = config.excludeDataValueTypes;
				config.aggregationColumnsOnly = config.summaryColumnsOnly;
				config.onlyLookups = config.lookupsColumnsOnly;
				const defDisplayId = config.displayId || !config.firstColumnsOnly;
				config.displayId = config.summaryColumnsOnly
					? false
					: defDisplayId;
			},

			_prepareConfig: function(config, callback, scope) {
				this._convertParameters(config);
				BPMSoft.chain(
					function(next) {
						this._setEntitySchemaUId(config, next);
					},
					function(next) {
						if (config.columnPath) {
							this._getEntitySchemaColumnInformationByPath(config, next, scope);
						} else {
							next();
						}
					},
					callback,
					scope || this
				);
			},

			_showStructureExplorer: function(config, callback, scope) {
				this.model = Ext.create("BPMSoft.AngularStructureExplorerViewModel", {
					callback: callback,
					scope: scope
				});
				this.model.$config = config;
				this.view = Ext.create("BPMSoft.StructureExplorer", {
					config: {"bindTo": "config"},
					selected: {"bindTo": "handleSelected"}
				});
				this.view.bind(this.model);
				this.view.render(Ext.getBody());
			},

			_getEntitySchemaColumnInformationByPath: function(config, callback, scope) {
				const request = {
					getSchemaColumnInformation: {
						entitySchemaUId: config.entitySchemaUId,
						schemaColumnPath: config.columnPath
					}
				};
				BPMSoft.SchemaDesignerUtilities.execute(request, function(response) {
					var schemaColumnInformation = response && response.getSchemaColumnInformationResponse;
					config.selectedMetaPaths = [schemaColumnInformation.columnMetaPath];
					Ext.callback(callback, scope);
				}, this);
			},

			_setEntitySchemaUId: function(config, callback, scope) {
				BPMSoft.require([config.schemaName], function(schema) {
					config.entitySchemaUId = schema.uId;
					Ext.callback(callback, scope);
				}, scope || this);
			},

			//endregion

			//region Methods: Public

			canOpen: function(config) {
				return !config.useBackwards &&
					!config.customColumns &&
					!config.useOldStructureExplorer &&
					!config.columnsFiltrationMethod &&
					!config.viewModelClassName && !config.viewConfigClassName &&
					BPMSoft.Features.getIsEnabled("UseNewStructureExplorer") &&
					!Ext.isIEOrEdge;
			},

			open: function(config, callback, scope) {
				this._prepareConfig(config, function() {
					this._showStructureExplorer(config, callback, scope);
				}, this);
			}

			//endregion

		});

		return Ext.create("BPMSoft.AngularStructureExplorerUtilities");
	});
