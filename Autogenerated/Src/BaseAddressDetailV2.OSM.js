define("BaseAddressDetailV2", ["MapsUtilities", "AddressHelperV2"], 
function(MapsUtilities) {
	return {
		mixins: {
			AddressHelperV2: "BPMSoft.AddressHelperV2"
		},
		attributies: {
			/**
			 * Maps provider config.
			 */
			"MapsProviderConfig": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Is maps provider config valid.
			 */
			"IsMapsProviderConfigValid": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},
		methods: {
			init: function() {
				let parentInit = this.getParentMethod(this, arguments);

				MapsUtilities.getMapsProviderConfigAsync()
					.then(value => {
						this.$MapsProviderConfig = value;
						this.$IsMapsProviderConfigValid = Boolean(this.$MapsProviderConfig?.isValid);
						parentInit();
					});
			},

			/**
			 * Show on map action handler.
			 */
			openShowOnMap: function() {
				var gridData = this.getGridData();
				var selectedRows = this.getSelectedItems();
				var selectedAddresses = [];
				BPMSoft.each(selectedRows, function(rowId) {
					selectedAddresses.push(gridData.get(rowId));
				}, this);
				this.showOnMapAddressesFromDetail(selectedAddresses, this.$MapsProviderConfig);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
