define("WebPageModule", ["WebPageModuleResources", "BaseWidgetModule"], function(resources) {
	/**
	 * A class that generates a configuration for the presentation of a Web page module.
	 */
	Ext.define("BPMSoft.configuration.WebPageViewConfig", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.WebPageViewConfig",

		/**
		 * Generates the configuration module view a Web page.
		 * @protected
		 * @param {Object} config A configuration object.
		 * @return {Object[]} Returns the configuration module view a Web page.
		 */
		generate: function(config) {
			var id = BPMSoft.Component.generateId();
			var iframeHtml = this.getIframeParams(config, id);
			var result = {
				"name": id,
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					wrapClassName: ["WebPage-module-wraper"]
				},
				"items": [
					{
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"html": iframeHtml,
						"selectors": {
							"wrapEl": "#" + id + "Container"
						}
					}
				]
			};
			return result;
		},

		/**
		 * Returns IFrame html.
		 * @private
		 * @param {Object} config A configuration object.
		 * @param {String} id The ID of the container IFrame.
		 * @return {String} The IFrame html.
		 */
		getIframeParams: function(config, id) {
			const url = config.url;
			if (Ext.isEmpty(url)) {
				return "";
			}
			const encodedUrl = BPMSoft.utils.string.encodeHtml(url);
			const isInvalidUrl= !BPMSoft.isUrl(encodedUrl) && !BPMSoft.utils.uri.isAValidUrlIgnoreProtocol(encodedUrl);
			if (isInvalidUrl) {
				return "";
			}
			const iframeStyle = config.style ? "style='" + BPMSoft.utils.string.encodeHtml(config.style) + "'" : "";
			const currentID=`${id}-webpage-widget`;
			const iframeHtml = `<iframe id = '${currentID}' class = 'webpage-widget' src='${encodedUrl}' width='100%' height='100%' ${iframeStyle} onload='Ext.create(&quot;BPMSoft.configuration.WebPageViewConfig&quot;).loadIframe(${"\""+id+"\""})''></iframe>`;
			return iframeHtml;
		},

		loadIframe: function(id) {
			const iframeContainer = document.getElementById(id+'Container');
			const iframe = document.getElementById(id+'-webpage-widget');
			const widgetModule=document.getElementById('WidgetModule');
			iframeContainer.style.height="100%";
		}
	});
	
	Ext.define("BPMSoft.configuration.WebPageViewModel", {
		extend: "BPMSoft.model.BaseModel",
		alternateClassName: "BPMSoft.WebPageViewModel",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		onRender: Ext.emptyFn,

		/**
		 * @inheritdoc BPMSoft.core.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * Init model the resource values of the resource object.
		 * @protected
		 * @param {Object} resourcesObj A resource object.
		 */
		initResourcesValues: function(resourcesObj) {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * Init the initial values of the model.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		init: function(callback, scope) {
			callback.call(scope);
		}

	});

	Ext.define("BPMSoft.configuration.WebPageModule", {
		extend: "BPMSoft.configuration.BaseWidgetModule",
		alternateClassName: "BPMSoft.WebPageModule",

		/**
		 * @inheritdoc BPMSoft.core.BaseModule#viewModelClassName
		 * @override
		 */
		viewModelClassName: "BPMSoft.WebPageViewModel",

		/**
		 * @inheritdoc BPMSoft.configuration.BaseWidgetModule#viewConfigClassName
		 * @override
		 */
		viewConfigClassName: "BPMSoft.WebPageViewConfig",

		/**
		 * @inheritdoc BPMSoft.configuration.BaseWidgetModule#initConfig
		 * @override
		 */
		initConfig: function() {
			this.callParent(["GetWebPageConfig", this.sandbox]);
		},

		/**
		 * Subscribes to messages of the parent module.
		 * @protected
		 */
		subscribeMessages: function() {
			this.sandbox.subscribe("GenerateWebPage", this.onGenerateWebPage, this, [this.sandbox.id]);
		},

		/**
		 * A method of processing messages to generate a web page.
		 * @protected
		 */
		onGenerateWebPage: function() {
			var viewModel = this.viewModel;
			this.moduleConfig = null;
			this.initConfig();
			viewModel.loadFromColumnValues(this.moduleConfig);
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
		}
	});

	return BPMSoft.WebPageModule;
});
