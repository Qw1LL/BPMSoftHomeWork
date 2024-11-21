define("RelationshipDiagramModule", ["BPMSoft", "ext-base", "ej-diagram", "RelationshipDiagramModuleResources",
		"BaseNestedModule", "RelationshipDiagramViewModel", "RelationshipDiagram"
	],
	function(BPMSoft, Ext) {

		/**
		 * @class BPMSoft.configuration.RelationshipDiagramViewConfig
		 * ##### ############ ############ ############# ###### ############.
		 */
		Ext.define("BPMSoft.configuration.RelationshipDiagramViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.RelationshipDiagramViewConfig",

			/**
			 * ########## ############ ############# ###### ############.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ############ ############# ###### ############.
			 */
			generate: function() {
				return {
					className: "BPMSoft.RelationshipDiagram",
					id: "relationship-diagram",
					itemType: BPMSoft.ViewItemType.MODULE,
					classes: {
						wrapClassName: ["diagram"]
					},
					items: {
						bindTo: "Nodes"
					}
				};
			}
		});

		/**
		 * @class BPMSoft.configuration.RelationshipDiagramModule
		 * ##### ########### ###### ############.
		 */
		Ext.define("BPMSoft.configuration.RelationshipDiagramModule", {
			extend: "BPMSoft.BaseNestedModule",
			alternateClassName: "BPMSoft.RelationshipDiagramModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,
			/**
			 * ### ###### ###### ############# ### ######.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.RelationshipDiagramViewModel",

			/**
			 * ### ##### ########## ############ ############# ######.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.RelationshipDiagramViewConfig",

			/**
			 * ### ##### ########## #############.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * ####### ########## ###### ############.
			 * @protected
			 * @virtual
			 * param {Object} config ############ ######## ### ########## ###### ############.
			 * @param {String} config.renderTo ### ########## ### ##########.
			 * @return {boolean} ########## true.
			 */
			onReloadRelationshipDiagram: function(config) {
				var viewModel = this.viewModel;
				if (viewModel) {
					var renderTo = config.renderTo ? Ext.get(config.renderTo) : this.renderToId;
					var view = this.view;
					if (view && !view.destroyed) {
						view.destroy();
					}
					this.view = view = null;
					this.initConfig();
					if (viewModel && !viewModel.destroyed) {
						viewModel.destroy();
					}
					this.viewModel = viewModel = null;
					this.initViewModelClass(function() {
						if (this.destroyed) {
							return;
						}
						this.initViewConfig(function() {
							if (this.destroyed) {
								return;
							}
							viewModel = this.viewModel = this.createViewModel();
							viewModel.init(function() {
								if (!this.destroyed && renderTo) {
									this.render(renderTo);
								}
							}, this);
						}, this);
					}, this);

					return true;
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig);
				generatorConfig.viewModelClass = this.viewModelClass;
				this.buildView(generatorConfig, function(view) {
					view[0].items = {
						bindTo: "Nodes"
					};
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseNestedModule#init
			 * @overridden
			 */
			init: function() {
				if (!this.viewModel) {
					this.initConfig();
					this.subscribeMessages();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.viewModelClass = Ext.ClassManager.get(this.viewModelClassName);
				callback.call(scope);
			},

			/**
			 * ####### ######### ###### BPMSoft.ViewGenerator.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.ViewGenerator} ########## ###### BPMSoft.ViewGenerator.
			 */
			createViewGenerator: function() {
				return this.Ext.create(this.viewGeneratorClass);
			},

			/**
			 * @inheritdoc BPMSoft.BaseNestedModule#createViewModel
			 * @overridden
			 */
			createViewModel: function() {
				var viewModel = this.callParent(arguments);
				viewModel.set("AccountId", this.moduleConfig.accountId);
				return viewModel;
			},

			/**
			 * ####### ############ ############# ########## ######.
			 * @protected
			 * @virtual
			 * param {Object} config ###### ############.
			 * param {Function} callback ####### ######### ######.
			 * param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
			 * @return {Object[]} ########## ############ ############# ########## ######.
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
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * ############## ###### ############ ######.
			 * @protected
			 * @virtual
			 */
			initConfig: function() {
				this.moduleConfig = {};
				var sandbox = this.sandbox;
				var moduleConfig = sandbox.publish("GetRelationshipDiagramInfo", null, [sandbox.id]);
				if (!this.Ext.isEmpty(moduleConfig)) {
					this.moduleConfig = moduleConfig;
				}
			},

			/**
			 * ############# ## #########.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				var sandbox = this.sandbox;
				sandbox.subscribe("ReloadRelationshipDiagram", this.onReloadRelationshipDiagram, this, [sandbox.id]);
			}

		});

		return BPMSoft.RelationshipDiagramModule;
	}
);
