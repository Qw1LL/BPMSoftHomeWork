﻿define("BaseWidgetModule", ["BPMSoft", "ext-base", "BaseNestedModule", "css!BaseWidgetModule", "css!BaseWidgetDesignerCSS"],
	function(BPMSoft, Ext) {

		/**
		 * @class BPMSoft.configuration.BaseWidgetModule
		 *
		 */
		Ext.define("BPMSoft.configuration.BaseWidgetModule", {
			extend: "BPMSoft.BaseNestedModule",
			alternateClassName: "BPMSoft.BaseWidgetModule",

			/**
			 * Ext framework.
			 * @type {Object}.
			 */
			Ext: null,

			/**
			 * Sandbox.
			 * @type {Object}.
			 */
			sandbox: null,

			/**
			 * BPMSoft framework.
			 * @type {Object}.
			 */
			BPMSoft: null,

			/**
			 * Show mask flag.
			 * @type {Boolean}.
			 */
			showMask: false,

			/**
			 * Module config.
			 * @type {Object}
			 */
			moduleConfig: null,

			/**
			 * Used messages.
			 * @protected
			 */
			messages: {
				/**
				 * @message GetExtendedFilterModuleId
				 * For subscription on onGenerateWidget
				 */
				"GetExtendedFilterModuleId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message ApplyResultExtendedFilter
				 * For subscription on onGenerateWidget
				 */
				"ApplyResultExtendedFilter": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SectionUpdateFilter
				 * Updates filters from section.
				 */
				"SectionUpdateFilter": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}

			},

			/**
			 * Class name of view generator.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * Class name of view config generator.
			 * @type {String}
			 */
			viewConfigClassName: "",

			/**
			 * Creates instance of BPMSoft.ViewGenerator.
			 * @return {BPMSoft.ViewGenerator} Return object of BPMSoft.ViewGenerator.
			 */
			createViewGenerator: function() {
				return this.Ext.create(this.viewGeneratorClass);
			},

			/**
			 * @inheritdoc BPMSoft.configuration.BaseNestedModule#init
			 * @overridden
			 */
			init: function() {
				if (!this.viewModel) {
					this.initConfig();
					this.initModuleMessages();
					this.registerMessages();
					this.subscribeMessages();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig) || {};
				generatorConfig.viewModelClass = this.viewModelClass;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * Initializes module messages collection.
			 * @protected
			 * @virtual
			 * @return {Object[]} Return module messages collection.
			 **/
			initModuleMessages: function() {
				var messages = this.getModuleMessages();
				this.messages = messages;
			},

			/**
			 * Returns model messages. If messages property is null, returns empty object.
			 * @virtual
			 * @protected
			 * @return {Object} Messages columns.
			 */
			getModuleMessages: function() {
				return this.messages || {};
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.viewModelClass = this.Ext.ClassManager.get(this.viewModelClassName);
				callback.call(scope);
			},

			/**
			 * Initializes configuration of module.
			 * @protected
			 * @virtual
			 */
			initConfig: function(getConfigMessageName, sandbox) {
				var currentSandbox = sandbox || this.sandbox;
				this.moduleConfig = this.moduleConfig || currentSandbox.publish(getConfigMessageName, null, [currentSandbox.id]);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#getViewModelConfig
			 * @overridden
			 */
			getViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values = this.moduleConfig;
				return config;
			},

			/**
			 * Creates nested module view configuration.
			 * @protected
			 * @virtual
			 * param {Object} config Configuration object.
			 * param {Function} callback Callback function.
			 * param {BPMSoft.BaseModel} scope Callback function context.
			 * @return {Object[]} Return nested module view configuration.
			 */
			buildView: function(config, callback, scope) {
				var viewGenerator = this.createViewGenerator();
				var viewClass = this.Ext.create(this.viewConfigClassName);
				var schema = {
					viewConfig: [viewClass.generate(config)]
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewConfig.schemaName = "";
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * Subscribes to the parent module posts.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: BPMSoft.emptyFn,

			/**
			 * Checks is widget bound to section.
			 * @private
			 */
			_isWidgetBoundToSection: function() {
				return !(Ext.isEmpty(this.moduleConfig.sectionId) ||
					Ext.isEmpty(this.moduleConfig.sectionBindingColumn));
			},

			/**
			 * Subscribes to the parent module posts.
			 * @protected
			 * @virtual
			 */
			subscribeMessagesInternal: function(widgetGenerationMessage) {
				const sandbox = this.sandbox;
				const sectionFilterModuleId = sandbox.publish("GetSectionFilterModuleId");
				sandbox.subscribe(widgetGenerationMessage, this.onGenerateWidget, this, [sandbox.id]);
				const extendedFiltersModuleId = sandbox.publish("GetExtendedFilterModuleId");
				sandbox.subscribe("ApplyResultExtendedFilter", function() {
					if (this._isWidgetBoundToSection()) {
						this.onGenerateWidget();
					}
				}, this, [extendedFiltersModuleId]);
				sandbox.subscribe("UpdateFilter", function() {
					if (this._isWidgetBoundToSection()) {
						this.onGenerateWidget();
					}
				}, this, [sectionFilterModuleId]);
				sandbox.subscribe("SectionUpdateFilter", function() {
					if (this._isWidgetBoundToSection()) {
						this.onGenerateWidget();
					}
				}, this, [sectionFilterModuleId]);
			},

			/**
			 * Extends module messages configuration by messages described in module.
			 * @protected
			 */
			registerMessages: function() {
				this.sandbox.registerMessages(this.messages);
			},

			/**
			 * Handles widget generation.
			 * @protected
			 * @virtual
			 */
			onGenerateWidget: function() {
				var viewModel = this.viewModel;
				if (!viewModel) {
					return;
				}
				this.moduleConfig = null;
				this.initConfig();
				viewModel.loadFromColumnValues(this.moduleConfig);
				viewModel.prepareWidget(function() {
					var view = this.view;
					if (view && !view.destroyed) {
						view.destroy();
					}
					this.initViewConfig(function() {
						var renderTo = Ext.get(viewModel.renderTo);
						if (renderTo) {
							this.render(renderTo);
						}
					}, this);
				}, this);
			}

		});

		return BPMSoft.BaseWidgetModule;
	});
