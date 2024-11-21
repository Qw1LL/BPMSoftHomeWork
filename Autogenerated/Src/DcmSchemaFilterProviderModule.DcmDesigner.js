define("DcmSchemaFilterProviderModule", ["BPMSoft", "sandbox", "DcmSchemaFilterProviderModuleResources",
		"StructureExplorerUtilities", "LookupUtilities", "EntitySchemaFilterProviderModule"],
	function(BPMSoft, sandbox) {
		/**
		 * @class BPMSoft.data.filters.DcmSchemaFilterProvider
		 * Dcm schema start filters provider.
		 */
		Ext.define("BPMSoft.data.filters.DcmSchemaFilterProvider", {
			extend: "BPMSoft.data.filters.EntitySchemaFilterProvider",
			alternateClassName: "BPMSoft.DcmSchemaFilterProvider",
			sandbox: sandbox,

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#shouldHideLookupActions
			 * @override
			 */
			shouldHideLookupActions: true,

			/**
			 * Allowed filter comparison types.
			 * @type {Array}
			 */
			allowedFilterComparisonTypes: null,

			//region Constructors: Public

			constructor: function() {
				this.callParent(arguments);
				this.allowedFilterComparisonTypes = [
					BPMSoft.ComparisonType.EQUAL,
					BPMSoft.ComparisonType.IS_NULL
				];
				this.initEvents();
			},

			//endregion

			//region Methods: Private

			/**
			 * Initialize provider events.
			 * @private
			 */
			initEvents: function() {
				this.addEvents(
					"GetAllowedFilterManageOperations",
					"GetAllowedFilterGroupManageOperations"
				);
			},

			/**
			 * Returns allowed manage operation for filter item.
			 * @private
			 * @param {String} eventName Event to be fired.
			 * @param {BPMSoft.BaseFilter} filterItem Filter item for which manage operation are requested.
			 * @param {Object} defaultManageOperations Default filter item manage operations.
			 * @return {Object}
			 */
			getAllowedManageOperations: function(eventName, filterItem, defaultManageOperations) {
				var eventArgs = {
					filterItem: filterItem,
					allowedManageOperations: BPMSoft.deepClone(defaultManageOperations)
				};
				if (this.fireEvent(eventName, eventArgs) === false) {
					return eventArgs.allowedManageOperations;
				}
				return defaultManageOperations;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#getLeftExpressionConfig
			 * @override
			 */
			getLeftExpressionConfig: function() {
				var config = this.callParent(arguments);
				config.lookupsColumnsOnly = true;
				config.useBackwards = false;
				config.displayId = false;
				config.firstColumnsOnly = true;
				return config;
			},

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#getSimpleFilterComparisonTypes
			 * @override
			 */
			getSimpleFilterComparisonTypes: function() {
				return this.allowedFilterComparisonTypes;
			},

			/**
			 * @inheritdoc BPMSoft.data.filters.EntitySchemaFilterProvider#getAllowedMacrosTypes
			 * @override
			 */
			getAllowedMacrosTypes: function() {
				return [];
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.data.filters.BaseFilterProvider#getAllowedFilterManageOperations
			 * @override
			 */
			getAllowedFilterManageOperations: function(filter) {
				var allowedManageOperations = this.callParent(arguments);
				return this.getAllowedManageOperations("GetAllowedFilterManageOperations",
					filter, allowedManageOperations);
			},

			/**
			 * @inheritdoc BPMSoft.data.filters.BaseFilterProvider#getAllowedFilterGroupManageOperations
			 * @override
			 */
			getAllowedFilterGroupManageOperations: function(filterGroup) {
				var allowedManageOperations = this.callParent(arguments);
				return this.getAllowedManageOperations("GetAllowedFilterGroupManageOperations",
					filterGroup, allowedManageOperations);
			}

			//endregion

		});

		return BPMSoft.DcmSchemaFilterProvider;
	}
);
