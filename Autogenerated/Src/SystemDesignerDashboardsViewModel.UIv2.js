define("SystemDesignerDashboardsViewModel", ["SystemDesignerDashboardsViewModelResources",
		"ext-base", "DashboardBuilder"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.SystemDesignerDashboardsViewModel
		 * ##### ###### ############# ###### ##### ### ####### ######### #######.
		 */
		return Ext.define("BPMSoft.configuration.SystemDesignerDashboardsViewModel", {
			extend: "BPMSoft.BaseDashboardsViewModel",
			alternateClassName: "BPMSoft.SystemDesignerDashboardsViewModel",

			/**
			 * ############## ######### ########.
			 * @protected
			 * @virtual
			 */
			initHeader: Ext.emptyFn,

			/**
			 * ########## ######## ## ####### ## #####.
			 * @private
			 * @overridden
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## ####### ######### ######.
			 */
			getActiveTabNameFromProfile: function(callback, scope) {
				if (callback) {
					callback.call(scope);
				}
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @overridden
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ########.
			 */
			init: function(callback, scope) {
				this.initResourcesValues(resources);
				this.callParent([function() {
					BPMSoft.SysSettings.querySysSettingsItem("SystemDesignerSectionEditMode", function(value) {
						this.set("EditMode", value);
						callback.call(scope || this);
					}, this);
				}, this]);
			}
		});
	});
