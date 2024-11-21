define("NavigateToSysProcessLogSectionTile", ["NavigateToSysProcessLogSectionTileResources", "MaskHelper"],
	function(resources, MaskHelper) {

		/**
		 * @class BPMSoft.configuration.NavigateToSysProcessLogSectionTileViewModel
		 * ##### ###### ############# ######.
		 */
		Ext.define("BPMSoft.configuration.NavigateToSysProcessLogSectionTileViewModel", {
			extend: "BPMSoft.SystemDesignerTileViewModel",
			alternateClassName: "BPMSoft.NavigateToSysProcessLogSectionTileViewModel",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * ######### ###### "###### ########".
			 * @inheritDoc BPMSoft.configuration.SystemDesignerTileViewModel#onClick
			 * @overridden
			 */
			onClick: function() {
				MaskHelper.ShowBodyMask();
				this.sandbox.publish("PushHistoryState", {
					hash: "SectionModuleV2/SysProcessLogSectionV2/"
				});
			}
		});
	});
