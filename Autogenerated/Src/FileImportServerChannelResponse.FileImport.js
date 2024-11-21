define("FileImportServerChannelResponse", [], function() {
	/**
	 * @class BPMSoft.core.BPMSoft
	 * File import server channel response class.
	 */
	Ext.define("BPMSoft.core.FileImportServerChannelResponse", {
		alternateClassName: "BPMSoft.FileImportServerChannelResponse",
		extend: "BPMSoft.BaseServerChannelResponse",

		//region Properties: Private

		/**
		 * Import status
		 * @private
		 * @type {Object}
		 */
		status: null,

		/**
		 * Import session identifier.
		 * @private
		 * @type {String}
		 */
		importSessionId: "",

		//endregion

		//region Methods: Public

		/**
		 * @inheritDoc BPMSoft.BaseObject#constructor.
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			var message = this.message;
			if (Ext.isEmpty(message)) {
				return;
			}
			this.status = message.status;
			this.importSessionId = message.importSessionId;
		},

		/**
		 * Returns import status.
		 * @return {Object} Import status.
		 */
		getStatus: function() {
			return this.status;
		},

		/**
		 * Returns import session identifier.
		 * @return {String} Import session identifier.
		 */
		getImportSessionId: function() {
			return this.importSessionId;
		}

		//endregion

	});
});
