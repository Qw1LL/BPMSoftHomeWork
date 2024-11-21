define("ChatContactDuplicatesDetailViewConfig", ["DuplicatesDetailViewConfigV2Resources", "DuplicatesDetailViewConfigV2", "ControlGridModule"],
	function(resources) {
		Ext.define("BPMSoft.configuration.ChatContactDuplicatesDetailViewConfig", {
			extend: "BPMSoft.DuplicatesDetailViewConfig",
			alternateClassName: "BPMSoft.ChatContactDuplicatesDetailViewConfig",

			/**
			 * @protected
			 */
			getDuplicatesDetailGridViewConfig: function () {
				const config = this.callParent(arguments);
				return Ext.apply(config, {
					"className": "BPMSoft.ControlGrid",
					"applyControlConfig": {"bindTo": "applyControlConfig"},
					"controlColumnName": "Name",
				});
			}
		});
	});
