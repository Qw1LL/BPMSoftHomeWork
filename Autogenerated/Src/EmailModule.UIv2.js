define("EmailModule", ["BaseSchemaModuleV2"],
	function() {
		/**
		 * @class BPMSoft.configuration.EmailModule
		 * ##### EmailModule ############ ### ######## ########## ###### ### ###### # ######.
		 */
		Ext.define("BPMSoft.configuration.EmailModule", {
			alternateClassName: "BPMSoft.EmailModule",
			extend: "BPMSoft.BaseSchemaModule",
			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 *  ############# ######### ########## ######.
			 * @overridden
			 */
			init: function() {
				this.useHistoryState = false;
				this.callParent(arguments);
			},

			/**
			 * ######## ##### ############ ########.
			 * @protected
			 * @type {String}
			 */
			schemaName: "CommunicationPanelEmailSchema",

			/**
			 * ####### ####, ### ######### ##### ########### #####.
			 * @public
			 * @type {Boolean}
			 */
			isSchemaConfigInitialized: true,

			/**
			 * ######### ########## ###### # #########.
			 * @private
			 * @overridden
			 */
			render: function() {
				this.callParent(arguments);
			}
		});
		return BPMSoft.EmailModule;
	});
