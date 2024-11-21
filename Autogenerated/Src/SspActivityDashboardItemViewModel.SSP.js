define("SspActivityDashboardItemViewModel", ["SspActivityDashboardItemViewModelResources", "ActivityDashboardItemViewModel", 
	"SspMiniPageUtilities"], function() {

		/**
		 * Action dashboard item view model class.
		 * Provides methods for SSP users action dashboard items logic.
		 * @class BPMSoft.configuration.SspActivityDashboardItemViewModel
		 */
		Ext.define("BPMSoft.configuration.SspActivityDashboardItemViewModel", {
			extend: "BPMSoft.ActivityDashboardItemViewModel",
			alternateClassName: "BPMSoft.SspActivityDashboardItemViewModel",

			mixins: {
				/**
				 * @class SspMiniPageUtilitiesMixin Provides methods for SSP users minipage usage.
				 */
				SspMiniPageUtilitiesMixin: "BPMSoft.SspMiniPageUtilities"
			},

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.MiniPageUtilities#getMiniPages
			 * @override
			 */
			getMiniPages: function(entityName) {
				var result = this.callParent(arguments);
				if (Ext.isEmpty(result)) {
					const sspMiniPage = this.getSspMiniPageSchemaName(entityName);
					if (!Ext.isEmpty(sspMiniPage)) {
						result.push(sspMiniPage);
					}
				}
				return result;
			}

			//endregion

		});
	});
