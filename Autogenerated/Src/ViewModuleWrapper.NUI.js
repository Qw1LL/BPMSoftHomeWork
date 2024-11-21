define("ViewModuleWrapper", ["ext-base", "sandbox", "BPMSoft", "ConfigurationBootstrap", "css!CommonCSSV2",
	"css!ViewModule", "css!BasePageV2CSS", "css!BaseFontsCSS", "css!RtlCSS", "CheckWSConnectionMixin", "css!ServiceDesignerStyles"],
	function(Ext, sandbox, BPMSoft) {
		/**
		 * @class BPMSoft.configuration.ViewModule
		 * ##### ######-####### ### ########## ####### #############.
		 */
		Ext.define("BPMSoft.configuration.ViewModuleWrapper", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.ViewModuleWrapper",

			mixins: ["BPMSoft.CheckWSConnectionMixin"],

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * Default view module name.
			 * @type {String}
			 */
			defaultViewModule: "ConfigurationViewModule",

			/**
			 * Default view module name for section designer.
			 * @type {String}
			 */
			sectionDesignerViewModule: "SectionDesignerViewModule",

			/**
			 * Container for load module.
			 * @type {Object}
			 */
			renderTo: Ext.getBody(),

			/**
			 * Module async state.
			 * @type {Boolean}
			 */
			isAsync: true,

			/**
			 * ############## ######.
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			init: function(callback, scope) {
				this.initQueryParameters();
				this.subscribeMessages();
				if (this.isSectionDesigner()) {
					this.defaultViewModule = this.sectionDesignerViewModule;
				}
				this.initUiFeature();
				this.appendBrowserCssClasses();
				this.checkWSInitialized();
				callback.call(scope);
			},

			/**
			 * Initializes BPMSoft.QueryParameters object.
			 * @protected
			 */
			initQueryParameters: function() {
				var search = window.location.search;
				if (!search) {
					return;
				}
				search = search.substring(1);
				var urlParams = search.split("&");
				BPMSoft.QueryParameters = BPMSoft.QueryParameters || {};
				for (var i = 0; i < urlParams.length; i++) {
					var pair = urlParams[i].split("=");
					BPMSoft.QueryParameters[pair[0]] = pair[1];
				}
			},

			/**
			 * Appends to body browser css classes.
			 * @protected
			 */
			appendBrowserCssClasses: function() {
				if (this.Ext.isIE || this.Ext.isEdge) {
					this.renderTo.addCls("x-ie");
				}
				if (this.Ext.isEdge) {
					this.renderTo.addCls("x-edge");
				}
			},

			/**
			 * Initializes new UI.
			 * @protected
			 */
			initUiFeature: function() {
				this._setFeatureAttribute("OldUI");
				this._setFeatureAttribute("UseAnimationSpinner");
			},

			/**
			 * Sets feature attribute.
			 * @param {String} featureCode Feature code.
			 * @private
			 */
			_setFeatureAttribute: function(featureCode) {
				var featureState = BPMSoft.Features.getIsEnabled(featureCode);
				var renderTo = this.renderTo;
				renderTo.dom.setAttribute(featureCode, featureState);
			},

			/**
			 * #########, ######## ## ## # ########## ########.
			 * @protected
			 * @virtual
			 * @return {Boolean} ########## true #### ## ######## # ########## #######, false # ######## ######.
			 */
			isSectionDesigner: function() {
				var hash = BPMSoft.router.Router.getHash();
				return hash.indexOf("SectionDesigner") === 0;
			},

			/**
			 * ########### #############.
			 * @virtual
			 * @param {Ext.Element} renderTo ###### ## #########, # ####### ##### ############ #############.
			 */
			render: function(renderTo) {
				Ext.create("BPMSoft.Container", {
					renderTo: renderTo,
					id: "mainContentWrapper",
					classes: {wrapClassName: ["main-content-wrapper"]},
					selectors: {wrapEl: "#mainContentWrapper"}
				});
				this.reloadViewModule();
			},

			/**
			 * Subscribes for messages.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				var sandbox = this.sandbox;
				sandbox.subscribe("ReloadViewModule", this.reloadViewModule, this, [this.sandbox.id]);
			},

			/**
			 * ######### ###### #############.
			 * @protected
			 * @virtual
			 * @param {Object} config ###### ############.
			 * @param {String} config.viewModuleName ### ###### ### ########.
			 */
			reloadViewModule: function(config) {
				var queryParameters = BPMSoft.QueryParameters || {};
				var queryParameter = queryParameters.vm;
				var queryViewModuleName = queryParameter && queryParameter.split("/")[0];
				var viewModuleName = (config && config.viewModuleName) || queryViewModuleName || this.defaultViewModule;
				var sandbox = this.sandbox;
				sandbox.loadModule(viewModuleName, {
					renderTo: "mainContentWrapper",
					id: "ViewModule"
				});
			}
		});

		return Ext.create("BPMSoft.ViewModuleWrapper", {
			Ext: Ext,
			sandbox: sandbox,
			BPMSoft: BPMSoft
		});
	});
