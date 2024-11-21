define("ForecastsModule", ["ext-base", "BaseSchemaModuleV2", "ForecastBuilder", "ForecastSection"],
	function() {

		/**
		 * @class BPMSoft.configuration.ForecastsModule
		 * Forecasts section module.
		 */
		Ext.define("BPMSoft.configuration.ForecastsModule", {
			extend: "BPMSoft.BaseSchemaModule",
			alternateClassName: "BPMSoft.ForecastsModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			viewModelClassName: "BPMSoft.BaseForecastsViewModel",

			builderClassName: "BPMSoft.ForecastBuilder",

			viewConfigClass: "BPMSoft.ForecastsViewConfig",

			/**
			 * Returns forecasts section module profile key.
			 * @override
			 * @protected
			 * @return {String} Forecast module profile key.
			 */
			getProfileKey: function() {
				return "ForecastId";
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#initSchemaName
			 * @override
			 */
			initSchemaName: function() {
				if (BPMSoft.Features.getIsEnabled("ForecastV2")) {
					this.schemaName = "ForecastSection";
					this.entitySchemaName = "Forecast";
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Creates forecasts view model.
			 * @param {Object} viewModelClass View model class.
			 * @return {BPMSoft.BaseViewModel} Forecast view model instance.
			 */
			createViewModel: function(viewModelClass) {
				return this.Ext.create(viewModelClass, {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft
				});
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#generateSchemaStructure
			 * @override
			 */
			generateSchemaStructure: function(callback, scope) {
				if (BPMSoft.Features.getIsEnabled("ForecastV2")) {
					this.callParent(arguments);
					return;
				}
				var builder = Ext.create(this.builderClassName, {
					viewModelClass: this.viewModelClassName,
					viewConfigClass: this.viewConfigClass
				});
				var config = {};
				builder.build(config, function(viewModelClass, view) {
					callback.call(scope, viewModelClass, view);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#destroy
			 * @override
			 */
			destroy: function() {
				this.callParent(arguments);
				this.renderContainer = null;
			}

		});
		return BPMSoft.ForecastsModule;
	});
