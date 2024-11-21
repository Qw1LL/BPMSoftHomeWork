define("ContextHelpModule", ["HoverMenuButton"], function() {
		/**
		 * @class BPMSoft.configuration.ContextHelpModule
		 * ##### ContextHelpModule ############ ### ######## ########## ###### ########### #######.
		 */
		Ext.define("BPMSoft.configuration.ContextHelpModule", {
			alternateClassName: "BPMSoft.ContextHelpModule",
			extend: "BPMSoft.BaseSchemaModule",
			useHistoryState: false,
			isSchemaConfigInitialized: true,
			schemaName: "ContextHelpSchema"
		});

		return BPMSoft.ContextHelpModule;
	});
