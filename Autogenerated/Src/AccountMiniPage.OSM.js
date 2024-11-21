define("AccountMiniPage", ["MapsUtilities", "AccountMiniPageResources", "AddressHelperV2"],
	function(MapsUtilities) {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			messages: {
				/**
				 * @message GetMapsConfig
				 * Gets config for MapsModule.
				 * @param {Object} Parameters for showing account address on map.
				 */
				"GetMapsConfig": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message AfterRenderMap
				 * Execute function after render map.
				 */
				"AfterRenderMap": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
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
				 * Returns map button visibility.
				 * @protected
				 * @return {Boolean} Map button visibility.
				 */
				getMapButtonVisibility: function() {
					return !this.Ext.isEmpty(this.get("FullAddress")) && this.isViewMode();
				},

				/**
				 * Shows map.
				 * @protected
				 */
				showMap: function() {
					this.showAddressOnMap(this.$MapsProviderConfig, this.close);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "FullAddress",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 21
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "MiniPage",
					"propertyName": "items",
					"name": "ShowMapButton",
					"values": {
						"layout": {
							"column": 21,
							"row": 2,
							"colSpan": 3
						},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "showMap"},
						"classes": {
							"wrapperClass": ["show-map-button-image-wrap"],
							"imageClass": ["show-map-button-image"]
						},
						"imageConfig": {
							"bindTo": "Resources.Images.ShowMapButtonImage"
						},
						"visible": {
							"bindTo": "getMapButtonVisibility"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
