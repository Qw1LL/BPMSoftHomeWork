define("AddressHelperV2", ["MapsUtilities"], function(MapsUtilities) {
	/**
	 * @class BPMSoft.configuration.mixins.AddressHelperV2
	 */
	Ext.define("BPMSoft.configuration.mixins.AddressHelperV2", {
		alternateClassName: "BPMSoft.AddressHelperV2",

		/**
		 * Forms attribute name.
		 * @private
		 * @param {String} name Attribute name.
		 * @param {String} [prefix] Attribute prefix.
		 * @return {String} Formatted attribute name.
		 */
		getAttributeName: function(name, prefix) {
			if (this.Ext.isEmpty(prefix)) {
				return name;
			}
			return this.Ext.String.format("{0}{1}", prefix, name);
		},

		/**
		 * Prepares map data.
		 * @private
		 * @return {Object} Map data.
		 */
		prepareMapData: function(scope) {
			var addressType = scope.get("AddressType");
			var addressTypeValue = addressType.displayValue;
			var address = this.getConfigFullAddress(scope);
			var content = this.Ext.String.format("<h2>{0}</h2><div>{1}</div>", addressTypeValue, address);
			return {
				caption: addressTypeValue,
				content: content,
				address: address,
				gpsN: scope.get("GPSN"),
				gpsE: scope.get("GPSE"),
			};
		},
		/**
		 * Opens map.
		 * @private
		 * @param {Object} mapsConfig Map configuration.
		 * @param {Object} mapsProviderConfig Maps provider config.
		 * @param {Function} [afterRender] Calls after map module render.
		 * @param {Function} [scope] Execution context.
		 */
		openMap: function(mapsConfig, mapsProviderConfig, afterRender, scope) {
			MapsUtilities.open({
				scope: scope || this,
				mapsConfig: mapsConfig,
				mapsProviderConfig: mapsProviderConfig,
				afterRender: afterRender
			});
		},

		/**
		 * Returns address attribute value.
		 * @private
		 * @param {Object|String} addressAttribute Address attribute.
		 * @return {String} Modified addressAttribute.
		 */
		getAddressAttributeValue: function(addressAttribute) {
			if (this.Ext.isObject(addressAttribute)) {
				return addressAttribute.displayValue;
			} else if (!this.Ext.isEmpty(addressAttribute)) {
				return addressAttribute;
			}
			return null;
		},

		/**
		 * Returns full address.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.BaseViewModel} [scope] Scope.
		 * @param {String} [attributePrefix] Attributes prefix.
		 * @return {Array} Full address.
		 */
		getConfigFullAddress: function(scope, attributePrefix) {
			var fullAddress = [];
			scope = scope || this;
			var prefix = attributePrefix || "";
			var addressElementName = ["Country", "Region", "City", "Address", "Zip"];
			BPMSoft.each(addressElementName, function(item) {
				fullAddress.push(this.getAddressAttributeValue(
					scope.get(this.getAttributeName(item, prefix))));
			}, this);
			return fullAddress;
		},

		/**
		 * Returns full address.
		 * @obsolete
		 * @protected
		 * @virtual
		 * @return {Array} Full address.
		 */
		getFullAddress: function() {
			var scope = arguments[0];
			var attributePrefix = arguments[1];
			return this.getConfigFullAddress(scope, attributePrefix);
		},


		/**
		 * Returns coordinates.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.BaseViewModel} [scope] Scope.
		 * @param {String} [attributePrefix] Attributes prefix.
		 * @return {Array} Coordinates.
		 */
		getCoords: function(scope, attributePrefix) {
			scope = scope || this;
			var prefix = attributePrefix || "";
			var coords = [];
			coords.push(scope.get(this.getAttributeName("GPSN", prefix)));
			coords.push(scope.get(this.getAttributeName("GPSE", prefix)));
			return coords;
		},

		/**
		 * Shows address on map.
		 * @param {Object} mapsProviderConfig Maps provider config.
		 * @param {Function} [callback] Callback function.
		 * @param {Function} [scope] Execution context.
		 */
		showAddressOnMap: function(mapsProviderConfig, callback, scope) {
			scope = scope || this;
			var mapData = this.prepareMapData(scope);
			var mapsConfig = {
				mapsData: [mapData]
			};
			this.openMap(mapsConfig, mapsProviderConfig, callback, scope);
		},
		/**
		 * Shows address on map.
		 * @param {Array} [selectedAddresses] Callback function.
		 * @param {Object} mapsProviderConfig Maps provider config.
		 */
		showOnMapAddressesFromDetail: function(selectedAddresses, mapsProviderConfig) {
			var mapsData = [];
			var mapsConfig = {
				mapsData: mapsData
			};
			this.BPMSoft.each(selectedAddresses, function(address) {
				var addressConfig = this.prepareMapData(address);
				var customAddressConfig = this.getAddressConfig(address);
				if (customAddressConfig) {
					this.Ext.apply(addressConfig, customAddressConfig);
				}
				mapsData.push(addressConfig);
			}, this);
			this.openMap.call(this, mapsConfig, mapsProviderConfig);
		},

		/**
		 * Get address config.
		 * @protected
		 * @param {BPMSoft.BaseViewModel} address Address view model.
		 * @return {Object} Address config.
		 */
		getAddressConfig: BPMSoft.emptyFn
	});
	return Ext.create("BPMSoft.configuration.mixins.AddressHelperV2");
});
