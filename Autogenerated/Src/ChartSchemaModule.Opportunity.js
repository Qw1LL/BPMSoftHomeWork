define("ChartSchemaModule", ["ext-base", "ChartModule", "SchemaBuilderV2", "ViewModelGeneratorV2"],
	function(Ext) {
		/**
		 * @class BPMSoft.configuration.ChartSchemaModule
		 * Base module for chart generated from schema.
		 */
		Ext.define("BPMSoft.configuration.ChartSchemaModule", {
			extend: "BPMSoft.ChartModule",
			alternateClassName: "BPMSoft.ChartSchemaModule",

			/**
			 * Instance of {BPMSoft.SchemaBuilder} for view and view model generation.
			 * @private
			 * @type {BPMSoft.SchemaBuilder}
			 */
			schemaBuilder: null,

			/**
			 * Class of schema builder used for build module.
			 * @virtual
			 * @type {String}
			 */
			schemaBuilderClassName: "BPMSoft.SchemaBuilder",

			/**
			 * Schema name.
			 * @virtual
			 * @type {String}
			 */
			schemaName: null,

			/**
			 * Creates {BPMSoft.SchemaBuilder} instance for generation view and viewModel.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.SchemaBuilder} Instance of hierarchy view and viewModel generator.
			 */
			getSchemaBuilder: function() {
				return this.schemaBuilder || (this.schemaBuilder = this.Ext.create(this.schemaBuilderClassName));
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				if (this.viewModelClass) {
					callback.call(scope);
					return;
				}
				var config = {
					schemaName: this.schemaName
				};
				var schemaBuilder = this.getSchemaBuilder();
				schemaBuilder.build(config, function(viewModelClass) {
					this.viewModelClass = viewModelClass;
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function() {
				var viewModel = this.viewModel || this.createViewModel();
				if (this.Ext.isFunction(viewModel.getViewConfigClassName)) {
					var customViewConfigClassName = viewModel.getViewConfigClassName();
					if (!this.Ext.isEmpty(customViewConfigClassName)) {
						this.viewConfigClassName = customViewConfigClassName;
					}
				}
				this.callParent(arguments);
			}
		});
	});
