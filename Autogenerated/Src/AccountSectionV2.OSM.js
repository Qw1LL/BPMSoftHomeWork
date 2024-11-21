define("AccountSectionV2", ["MapsUtilities", "MapsHelper"],
	function(MapsUtilities, MapsHelper) {
		return {
			entitySchemaName: "Account",
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
				
				isOpenShowOnMap: function() {
					return this.isAnySelected() && this.$IsMapsProviderConfigValid;
				},

				/**
				 * ######## "######## ## #####".
				 */
				openShowOnMap: function() {
					var config = {
						columnNameLongitude: "GPSE",
						columnNameLatitude: "GPSN"
					};
					MapsHelper.openShowOnMap.call(this, this.entitySchemaName, function(mapsConfig) {
						MapsUtilities.open({
							scope: this,
							mapsConfig: mapsConfig,
							mapsProviderConfig: this.$MapsProviderConfig
						});
					}, null, config);
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
