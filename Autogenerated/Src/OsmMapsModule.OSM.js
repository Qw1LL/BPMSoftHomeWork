define("OsmMapsModule", ["OsmMapsModuleResources", "BaseSchemaModuleV2", "css!OsmMapsModule"],
		function() {
			/**
			 * @class BPMSoft.configuration.OsmMapsModule.
			 * ##### MapsModule ############ ### ######## ###### #### OpenStreetMap.
			 */
			Ext.define("BPMSoft.configuration.OsmMapsModule", {
				alternateClassName: "BPMSoft.OsmMapsModule",
				extend: "BPMSoft.BaseMapsModule",
				
				getMapAttribution: function() {
					return "Map data &copy; <a href=" + "http://openstreetmap.org" +
                			">OpenStreetMap</a>" + " contributors, <a href=" +
                			"http://creativecommons.org/licenses/by-sa/2.0/>" + 
							"CC-BY-SA</a>";
				},

				/**
				 * @param {Array|String} address Address.
     			 * @returns {Object} Nominatim reauest params.
     			 */
				getNominatimRequestParams: function(address) {
					params = {
						format: "json"
					};

					if (this.Ext.isArray(address)) {
                        if (address[0]) {
                            params.country = address[0];
                        }
                        if (address[1]) {
                            params.state = address[1];
                        }
                        if (address[2]) {
                            params.city = address[2];
                        }
                        if (address[3]) {
                            params.street = address[3];
                        }
                        if (address[4]) {
                            params.postalcode = address[4];
                        }
                    } else {
                        params.q = address;
                    }

					return params;
				},

				/**
     			 * Validates search url params.
     			 * @param {Object} params.
     			 * @returns {Boolean} Valid or invalid.
     			 */
				isSearchParamsValid: function(params) {
					let validateResultFromParent = this.callParent(arguments);
					
					if (!validateResultFromParent) {
						return validateResultFromParent;
					}

					let paramsKeys = BPMSoft.keys(params);

					return !(paramsKeys.length === 1 && paramsKeys[0] === "format");
				}
			});
			
			return BPMSoft.OsmMapsModule;
		});
