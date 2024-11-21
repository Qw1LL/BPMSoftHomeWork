define("SspMiniPageContainerViewModel", ["MiniPageContainerViewModel", "SspMiniPageUtilities"], function() {

	/**
	 * MiniPage container module view model class.
	 * Provides methods for SSP users minipage load logic.
	 * @class BPMSoft.configuration.SspMiniPageContainerViewModel
	 */
	Ext.define("BPMSoft.configuration.SspMiniPageContainerViewModel", {
		extend: "BPMSoft.MiniPageContainerViewModel",
		alternateClassName: "BPMSoft.SspMiniPageContainerViewModel",

		mixins: {
			/**
			 * @class SspMiniPageUtilitiesMixin Provides methods for SSP users minipage usage.
			 */
			SspMiniPageUtilitiesMixin: "BPMSoft.SspMiniPageUtilities"
		},

		//region Methods: Public
		
		/**
		 * @inheritdoc BPMSoft.MiniPageContainerViewModel#getSchemaName
		 * @override
		 */
		getSchemaName: function(entityName, typeId) {
			var miniPageSchema = this.callParent(arguments);
			if (Ext.isEmpty(miniPageSchema)) {
				miniPageSchema = this.getSspMiniPageSchemaName(entityName);
			}
			return miniPageSchema;
		}

		//endregion
	});
});
 