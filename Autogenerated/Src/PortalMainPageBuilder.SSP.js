define("PortalMainPageBuilder", ["ext-base", "PortalMainPageBuilderResources",
	"DashboardManager", "DashboardManagerItem", "DashboardBuilder"],
function(Ext, resources) {

	/**
	 * @class BPMSoft.configuration.PortalMainPageViewConfig
	 * ##### ############ ############ ############# ###### ####### ######## #######.
	 */
	Ext.define("BPMSoft.configuration.PortalMainPageViewConfig", {
		extend: "BPMSoft.DashboardsViewConfig",
		alternateClassName: "BPMSoft.PortalMainPageViewConfig",

		/**
		 * ########## ############ ############# ###### ####### ######## #######.
		 * @protected
		 * @overridden
		 * @returns {Object[]} ########## ############ ############# ###### ####### ######## #######.
		 */
		generate: function() {
			var viewConfig = this.callParent(arguments);
			var viewConfigElementsNames = viewConfig.map(function(element) {
				return element.name;
			});
			var tabsElementIndex = viewConfigElementsNames.indexOf("Tabs");
			if (tabsElementIndex !== -1) {
				var tabElement = viewConfig[tabsElementIndex];
				tabElement.visible = {
					"bindTo": "isTabsHeadersVisible"
				};
				tabElement.classes.wrapClass.push("portal-main-page-tab");
				if (!BPMSoft.isCurrentUserSsp()) {
					tabElement.classes.wrapClass.push("portal-main-page-tab-settings");
				}
				var tabElementControlConfig = tabElement.controlConfig;
				var tabElementItems = tabElementControlConfig.items;
				var tabElementItemsMarkerValues = tabElementItems.map(function(element) {
					return element.markerValue;
				});
				var settingsButtonIndex = tabElementItemsMarkerValues.indexOf("SettingsButton");
				if (settingsButtonIndex !== -1) {
					tabElementItems[settingsButtonIndex].visible = {
						"bindTo": "IsNotSSP"
					};
				}
			}
			return viewConfig;
		}
	});

	/**
	 * @class BPMSoft.configuration.BasePortalMainPageViewModel
	 * ##### ###### ############# ###### ####### ######## #######.
	 */
	Ext.define("BPMSoft.configuration.BasePortalMainPageViewModel", {
		extend: "BPMSoft.BaseDashboardsViewModel",
		alternateClassName: "BPMSoft.BasePortalMainPageViewModel",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		attributes: {
			/**
			 * ####### ####, ### ############ ######### ## ## #######.
			 * @type {Boolean}
			 */
			"IsNotSSP": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			}
		},

		/**
		 * #########, ### ######### ########## ######### #######.
		 * @protected
		 * @private
		 * @return {Boolean} ########## true #### ##### ########## # false # ######## ######.
		 */
		isTabsHeadersVisible: function() {
			var tabCollection = this.get("TabsCollection");
			return this.get("IsNotSSP") || tabCollection.getCount() > 1;
		},

		/**
		 * ############## ######### ######## ######.
		 * @protected
		 * @overridden
		 */
		init: function() {
			this.callParent(arguments);
			this.set("IsNotSSP", BPMSoft.CurrentUser.userType !== BPMSoft.UserType.SSP);
		},

		/**
		 * ############## ###### ########## ######## ## ####### ########.
		 * @protected
		 * @overridden
		 */
		initResourcesValues: function() {
			var resourcesSuffix = "Resources";
			BPMSoft.each(resources, function(resourceGroup, resourceGroupName) {
				resourceGroupName = resourceGroupName.replace("localizable", "");
				BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
					var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
					this.set(viewModelResourceName, resourceValue);
				}, this);
			}, this);
		},

		/**
		 * @inheritdoc BaseDashboardsViewModel#subscribeSandboxMessages
		 * @overridden
		 */
		subscribeSandboxMessages: function() {
			this.callParent(arguments);
			this.sandbox.subscribe("NeedHeaderCaption", function() {
				this.sandbox.publish("InitDataViews", {
					caption: this.get("Resources.Strings.Caption")
				});
			}, this);
		}

	});

	/**
	 * @class BPMSoft.configuration.PortalMainPageBuilder
	 * ##### ############### # #### ###### ######### #############
	 * # ###### ###### ############# ### ###### ####### ######## #######.
	 */
	var portalMainPageBuilder = Ext.define("BPMSoft.configuration.PortalMainPageBuilder", {
		extend: "BPMSoft.DashboardBuilder",
		alternateClassName: "BPMSoft.PortalMainPageBuilder",

		/**
		 * ### ####### ###### ############# ### ###### ####### ######## #######.
		 * @type {String}
		 */
		viewModelClass: "BPMSoft.BasePortalMainPageViewModel",

		/**
		 * ### ######## ##### ########## ############ ############# ####### ######## #######.
		 * @type {String}
		 */
		viewConfigClass: "BPMSoft.PortalMainPageViewConfig"

	});

	return portalMainPageBuilder;

});
