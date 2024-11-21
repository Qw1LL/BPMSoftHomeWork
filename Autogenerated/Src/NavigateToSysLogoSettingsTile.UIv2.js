define("NavigateToSysLogoSettingsTile", ["NavigateToSysLogoSettingsTileResources", "MaskHelper", "RightUtilities"],
	function(resources, MaskHelper, RightUtilities) {

		/**
		 * @class BPMSoft.configuration.NavigateToSysLogoSettingsTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToSysLogoSettingsTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToSysLogoSettingsTileViewModel",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.SystemDesignerTileViewModel#onClick
			 * @overridden
			 */
			onClick: function() {
				if (this.get("CanManageLogo") != null) {
					this.navigateToSysWorkPlaceSection();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageLogo"
					}, function(result) {
						this.set("CanManageLogo", result);
						this.navigateToSysWorkPlaceSection();
					}, this);
				}
			},

			/**
			 * ######### ###### ######### ############# ######### ### ########## ######### ## ######.
			 * @private
			 */
			navigateToSysWorkPlaceSection: function() {
				if (this.get("CanManageLogo") === true) {
					MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {
						hash: "SysLogoSettingsModule"
					});
				} else {
					var message = this.get("Resources.Strings.RightsErrorMessage");
					this.BPMSoft.utils.showInformation(message);
				}
			}
		});
	});
