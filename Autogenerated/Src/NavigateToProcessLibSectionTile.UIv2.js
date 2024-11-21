define("NavigateToProcessLibSectionTile", ["NavigateToProcessLibSectionTileResources", "MaskHelper", "RightUtilities"],
	function(resources, MaskHelper, RightUtilities) {

		/**
		 * @class BPMSoft.configuration.NavigateToProcessLibSectionTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToProcessLibSectionTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToProcessLibSectionTileViewModel",
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
				if (this.get("CanManageProcessDesign") != null) {
					this.navigateToProcessLibSection();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageProcessDesign"
					}, function(result) {
						this.set("CanManageProcessDesign", result);
						this.navigateToProcessLibSection();
					}, this);
				}
			},

			/**
			 * ######### ###### "########## ########" ### ########## ######### # ######.
			 * @private
			 */
			navigateToProcessLibSection: function() {
				if (this.get("CanManageProcessDesign") === true) {
					MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {
						hash: "SectionModuleV2/VwProcessLibSection/"
					});
				} else {
					var message = this.get("Resources.Strings.RightsErrorMessage");
					this.BPMSoft.utils.showInformation(message);
				}
			}
		});
	});
