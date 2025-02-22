﻿define("NavigateToGeneratedWebFormSectionTile", ["NavigateToGeneratedWebFormSectionTileResources", "MaskHelper",
	"RightUtilities"], function(resources, MaskHelper, RightUtilities) {

	/**
	 * @class BPMSoft.configuration.NavigateToGeneratedWebFormSectionTileViewModel
	 * ##### ###### ############# ######.
	 */
	Ext.define("BPMSoft.configuration.NavigateToGeneratedWebFormSectionTileViewModel", {
		extend: "BPMSoft.SystemDesignerTileViewModel",
		alternateClassName: "BPMSoft.NavigateToGeneratedWebFormSectionTileViewModel",
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
			if (this.get("CanManageWebForms") != null) {
				this.navigateToGeneratedWebFormSection();
			} else {
				RightUtilities.checkCanExecuteOperation({
					operation: "CanManageWebForms"
				}, function(result) {
					this.set("CanManageWebForms", result);
					this.navigateToGeneratedWebFormSection();
				}, this);
			}
		},

		/**
		 * ######### ###### "##### ####### ########" ### ########## ######### # ######.
		 * @private
		 */
		navigateToGeneratedWebFormSection: function() {
			if (this.get("CanManageWebForms") === true) {
				MaskHelper.ShowBodyMask();
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/GeneratedWebFormSectionV2/"
				});
			} else {
				var message = this.get("Resources.Strings.RightsErrorMessage");
				this.BPMSoft.utils.showInformation(message);
			}
		}
	});
});
