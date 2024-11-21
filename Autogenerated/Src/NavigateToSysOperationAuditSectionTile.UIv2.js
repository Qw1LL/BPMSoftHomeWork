define("NavigateToSysOperationAuditSectionTile", ["NavigateToSysOperationAuditSectionTileResources", "MaskHelper",
		"RightUtilities"], function(resources, MaskHelper, RightUtilities) {

		/**
		 * @class BPMSoft.configuration.NavigateToSysOperationAuditSectionTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToSysOperationAuditSectionTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToSysOperationAuditSectionTileViewModel",
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
				if (this.get("CanViewSysOperationAudit") != null) {
					this.navigateToSysOperationAuditSection();
				} else {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanViewSysOperationAudit"
					}, function(result) {
						this.set("CanViewSysOperationAudit", result);
						this.navigateToSysOperationAuditSection();
					}, this);
				}
			},

			/**
			 * ######### ###### "###### ######" ### ########## ######### # ######.
			 * @private
			 */
			navigateToSysOperationAuditSection: function() {
				if (this.get("CanViewSysOperationAudit") === true) {
					MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {
						hash: "SectionModuleV2/SysOperationAuditSectionV2/"
					});
				} else {
					var message = this.get("Resources.Strings.RightsErrorMessage");
					this.BPMSoft.utils.showInformation(message);
				}
			}
		});
	});
