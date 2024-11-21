define("ViewModuleHelper", ["ext-base", "BPMSoft", "ViewModuleHelperResources", "RightUtilities",
	"CtiBaseHelper", "CtiConstants", "CtiLinkColumnUtility"],
	function(Ext, BPMSoft, resources, RightUtilities, CtiBaseHelper, CtiConstants, CtiLinkColumnUtility) {

		/**
		 * ####### ######### # #######.
		 * @private
		 * @deprecated 7.15.2 SonarQube vulnerability: Console logging should not be used.
		 * @param message #########.
		 */
		function log(message) {	}

		/**
		 * ############## ####### ###### # ######### #### "######".
		 */
		function initLinkColumnUtilities() {
			var linkColumnUtilities = BPMSoft.LinkColumnUtilities || {};
			linkColumnUtilities.Telephony = Ext.create(CtiLinkColumnUtility);
			BPMSoft.LinkColumnUtilities = linkColumnUtilities;
		}

		/**
		 * ############## ########## ######### ### ######## ###### #############.
		 */
		function initSettings() {
			initLinkColumnUtilities();
		}

		/**
		 * ####### ############ ##### ###### ## #########.
		 * @param {Function} callback ####### ######### ######.
		 */
		function getSideBarDefaultConfig(callback) {
			var menuConfig = {
				items: [{
					name: "LeftPanelTopMenuModule",
					id: "leftPanelTopMenu",
					showInHeader: true
				}, {
					name: "LeftPanelClientWorkplaceMenu",
					id: "leftPanelClientWorkplaceMenu",
					showInHeader: true
				}, {
					name: "SectionMenuModule",
					id: "sectionMenuModule"
				}]
			};
			callback(menuConfig);
		}

		return {
			getSideBarDefaultConfig: getSideBarDefaultConfig,
			initSettings: initSettings
		};
	});
