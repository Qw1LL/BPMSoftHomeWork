define("NavigateToSysWorkplaceSectionTile", ["NavigateToSysWorkplaceSectionTileResources", "MaskHelper",
		"RightUtilities"],
	function(resources, MaskHelper, RightUtilities) {

		/**
		 * @class BPMSoft.configuration.NavigateToSysWorkplaceSectionTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToSysWorkplaceSectionTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToSysWorkplaceSectionTileViewModel",
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
				if (this.get("CanManageWorkplaces") != null) {
					this.navigateToSysWorkPlaceSection();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageWorkplaceSettings"
					}, function(result) {
						this.set("CanManageWorkplaces", result);
						this.navigateToSysWorkPlaceSection();
					}, this);
				}
			},

			/**
			 * ######### ###### ######### ####### #### ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysWorkPlaceSection: function() {
				if (this.get("CanManageWorkplaces") === true) {
					MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {
						hash: "SectionModuleV2/SysWorkplaceSectionV2/"
					});
				} else {
					var message = this.get("Resources.Strings.RightsErrorMessage");
					this.BPMSoft.utils.showInformation(message);
				}
			}
		});
	});
