define("RuMapsModule", ["RuMapsModuleResources", "BaseSchemaModuleV2", "css!RuMapsModule"],
        function() {
            /**
             * @class BPMSoft.configuration.RuMapsModule.
             * ##### MapsModule ############ ### ######## ###### #### OpenStreetMap.
             */
            Ext.define("BPMSoft.configuration.RuMapsModule", {
                alternateClassName: "BPMSoft.RuMapsModule",
                extend: "BPMSoft.BaseMapsModule",

                getMapAttribution: function() {
                    return "&copy; <a href=" + "http://www.digimap.ru" +
                            ">ЗАО «Геоцентр-Консалтинг»</a> <a href=" + 
                            "https://rumap.ru/rules.html" +
                            ">Условия использования</a>";
                },

                /**
				 * @param {Array|String} address Address.
     			 * @returns {Object} Nominatim reauest params.
     			 */
				getNominatimRequestParams: function(address) {
                    var mapsProviderConfig = this.$MapsProviderConfig;
                    var params = {};

					if (mapsProviderConfig.useApiKey) {
						params.guid = mapsProviderConfig.apiKey;
					}

                    var searchString = BPMSoft.emptyString;

                    if (Ext.isArray(address)) {
                        searchString = _.compact(address).join(", ");
                    }

                    params.text = searchString;
                    params.data = "address";
                    params.format = "simple";
                    params.mode = "search";

                    return params;
                },

                /**
                 * Handle success response of nominatim request handler.
                 * @param {Object} options Nominatim request options.
                 * @param {Object} jsonData Response.
                 */
                successNominatimRequestHandler: function(options, jsonData) {
                    var address = jsonData.address;

                    var prepearedJsonData = Object.keys(address).map((key) => {
                        var item = address[key];

                        item.lon = item.x;
                        delete item.x;

                        item.lat = item.y;
                        delete item.y;

                        return item;
                    });

                    this.callParent([options, prepearedJsonData]);
                },

                /**
     			 * Validates search url params.
     			 * @param {Object} params.
     			 * @returns {Boolean} Valid or invalid.
     			 */
				isSearchParamsValid: function(params) {
                    return this.callParent(arguments) && !BPMSoft.isEmpty(params.text);
                }
            });
            return BPMSoft.RuMapsModule;
        });
