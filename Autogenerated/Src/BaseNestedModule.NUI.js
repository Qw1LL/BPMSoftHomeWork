define("BaseNestedModule", ["BPMSoft", "ext-base", "BaseModule"],
	function(BPMSoft, Ext) {

		/**
		 * Basic visual class of the nested module.
		 */
		Ext.define("BPMSoft.configuration.BaseNestedModule", {
			extend: "BPMSoft.BaseModule",
			alternateClassName: "BPMSoft.BaseNestedModule",

			/**
			 * ####### ############# ######.
			 * @type {Boolean}
			 */
			isAsync: true,

			/**
			 * ###### ############# ######.
			 * @type {BPMSoft.Component}
			 */
			view: null,

			/**
			 * ##### ###### #############.
			 * @type {String}
			 */
			viewModelClass: null,

			/**
			 * ###### ###### ############# ######.
			 * @type {BPMSoft.BaseModel}
			 */
			viewModel: null,

			/**
			 * ###### ############ ############# ######.
			 * @type {Object}
			 */
			viewConfig: null,

			/**
			 * ####### ############# ### ########## ######.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.Component} ########## ######### ############# ### ########## ######.
			 */
			createView: function() {
				var viewConfig = BPMSoft.deepClone(this.viewConfig);
				var containerClassName = viewConfig.className || "BPMSoft.Container";
				return this.Ext.create(containerClassName, viewConfig);
			},

			/**
			 * ####### ###### ############# ### ########## ######.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.BaseModel} ########## ######### ###### ############# ### ########## ######.
			 */
			createViewModel: function() {
				return this.Ext.create(this.viewModelClass, this.getViewModelConfig());
			},

			/**
			 * ########## ######### ### ######## ###### ############# ######.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ######### ### ######## ###### ############# ######.
			 */
			getViewModelConfig: function() {
				return {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft
				};
			},

			/**
			 * ############## ###### ############ ############# ######.
			 * @protected
			 * @abstract
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			initViewConfig: BPMSoft.abstractFn,

			/**
			 * ############## ##### ###### ############# ######.
			 * @protected
			 * @abstract
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			initViewModelClass: BPMSoft.abstractFn,

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				callback = callback || Ext.emptyFn;
				if (this.viewModel) {
					this.viewModel.set("Restored", true);
					callback.call(scope);
					return;
				}
				this.initViewModelClass(function() {
					if (this.destroyed) {
						return;
					}
					this.initViewConfig(function() {
						if (this.destroyed) {
							return;
						}
						var viewModel = this.viewModel = this.createViewModel();
						this.initViewModel(viewModel, callback, scope);
					}, this);
				}, this);
			},

			/**
			 * Initializes the model.
			 * @protected
			*/
			initViewModel: function(viewModel, callback, scope) {
				viewModel.init(function() {
					if (!this.destroyed) {
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * ######### ######### ######.
			 * @protected
			 * @virtual
			 * @param {Object} renderTo ######### ###### ## Ext.Element # ####### ##### ########### ####### ##########.
			 */
			render: function(renderTo) {
				this.callParent(arguments);
				var viewModel = this.viewModel;
				var view = this.view;
				if (!view || view.destroyed) {
					view = this.view = this.createView();
					view.bind(viewModel);
					view.render(renderTo);
				} else {
					view.reRender(0, renderTo);
				}
				viewModel.renderTo = renderTo.id;
				viewModel.onRender();
			},

			/**
			 * ####### ### ######## ## ####### # ########## ######.
			 * @overridden
			 * @param {Object} config ######### ########### ######
			 */
			destroy: function(config) {
				const keepAlive = config && config.keepAlive === true;
				if (!keepAlive) {
					BPMSoft.clearProperty(this, "viewModel");
					this.callParent(arguments);
				}
			}
		});
	});
