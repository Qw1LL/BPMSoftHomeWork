define("BaseMapsModule", ["BaseMapsModuleResources", "ModalBox", "MapsHelper",
"BaseSchemaModuleV2", "Leaflet", "css!Leaflet", "css!BaseMapsModule"],
function(resources, ModalBox, MapsHelper) {
/**
 * @class BPMSoft.configuration.BaseMapsModule.
 * ##### MapsModule ############ ### ######## ###### #### OpenStreetMap.
 */
Ext.define("BPMSoft.configuration.BaseMapsModule", {
    alternateClassName: "BPMSoft.BaseMapsModule",
    extend: "BPMSoft.BaseModule",

    /**
     * Flag responsible that has already error message set into map. 
     * it is needed in order not to perform DOM operations such as get element and update element.
     */
    errorMessageHasAlreadySetIntoMap: false,

    /**
     * Map container unique identifier.
     * @type {String}.
     */
    mapContainerId: "maps-container-" + BPMSoft.generateGUID(),

    /**
     * ###### ### ###### # Leaflet. ## ######### window.L.
     * @type {Object}
     */
    L: window.L,

    /**
     * Maps provider config.
     * @type {Object}
     */
    mapsProviderConfig: {},

    /**
     * @return {String} Map attribution string.
     */
    getMapAttribution: BPMSoft.abstractFn,

    /**
     * @param {Array|String} address Address.
     * @returns {URLSearchParams} Nominatim reauest params.
     */
    getNominatimRequestParams: BPMSoft.abstractFn,

    /**
     * @param {Object} mapsProviderConfig Map provider config. 
     */
    constructor: function(config) {
        this.callParent(arguments);
    },

    /**
     * Initialize module.
     */
    init: async function() {
        var mapData = this.sandbox.publish("GetMapsConfig", null, [this.sandbox.id]);
        var viewModel = this.Ext.create("BPMSoft.BaseViewModel", this.generateViewModel());
        viewModel.setLocationDebounce = BPMSoft.debounce(viewModel.setLocation, 200);

        if (mapData) {
            viewModel.set("IsModalBox", mapData.isModalBox);
            viewModel.set("RenderTo", mapData.renderTo);

            this.validateMapsProviderConfig(this.mapsProviderConfig, viewModel);
            await this.validateTileUrlAsync(viewModel);

            viewModel.setLocationDebounce(mapData);
        }

        this.subscribeSandboxEvents.call(viewModel);
    },

    /**
     * Subscribes on sandbox events.
     */
    subscribeSandboxEvents: function() {
        this.sandbox.subscribe("SetMapsConfig", function(mapData) {
            this.set("Markers", []);
            if (mapData.normalizeSizeMap) {
                this.normalizeSizeMap();
            } else {
                this.setLocationDebounce(mapData);
            }
        }, this, [this.sandbox.id]);
    },

    validateMapsProviderConfig: function(mapsProviderConfig, viewModel) {
        if (!mapsProviderConfig || mapsProviderConfig.isValid === false) {
            let errorMessage;

            if (!mapsProviderConfig?.mapsProviderId) {
                errorMessage = resources.localizableStrings.MapServiceIsNotSetup;
            } else if (mapsProviderConfig.useApiKey && !mapsProviderConfig.apiKey) {
                errorMessage = resources.localizableStrings.ApiKeyIsEmpty;
            } else {
                errorMessage = resources.localizableStrings.WrongMapsProviderConfiguration;
            }

            this.renderErrorMessageIntoMap(viewModel, errorMessage, viewModel.$MapContainerId);
            throw new Error(errorMessage);
        } else if (!mapsProviderConfig.isValid) {
            mapsProviderConfig.isValid = 
                BPMSoft.MapsUtilities.validateMapsProviderConfig(mapsProviderConfig);

            this.validateMapsProviderConfig(mapsProviderConfig);
        }
    },

    /**
     * Checks tile url availability and render error into map container.
     * @param {Object} viewModel View model.
     */
    validateTileUrlAsync: async function(viewModel) {
        let mapsProviderConfig = this.mapsProviderConfig;
        
        let moscowCoordinates = {
            z: 18,
            x: 158464,
            y: 81953
        };
        
        let tileUrl = 
            mapsProviderConfig.urlForGettingTiles
                .replace("//{s}", "https://a")
                .replace("{z}", moscowCoordinates.z)
                .replace("{x}", moscowCoordinates.x)
                .replace("{y}", moscowCoordinates.y);

        if (mapsProviderConfig.useApiKey) {
            tileUrl = tileUrl.replace("{0}", mapsProviderConfig.apiKey);
        }

        await fetch(tileUrl, {
            method: 'GET'
        })
        .catch((error) => {
            if (!error?.status && error.status !== 200) {
                let errorMessage = this.getMapsRequestErrorMessage(error);
                this.renderErrorMessageIntoMap(viewModel, errorMessage, viewModel.$MapContainerId);
    
                throw new Error(errorMessage);
            }
        });
    },

    /**
     * Validates search url params.
     * @param {Object} params.
     * @returns {Boolean} Valid or invalid.
     */
    isSearchParamsValid: function(params) {
        let paramsKeys = BPMSoft.keys(params);
        return !BPMSoft.isEmpty(paramsKeys);
    },

    /**
     * Render error message into view model of map.
     * @param {Object} viewModel View model.
     * @param {String} errorMessage Error message.
     * @param {String} mapsContainerId Maps container Id.
     */
    renderErrorMessageIntoMap: function(viewModel, errorMessage, mapsContainerId) {
        if (viewModel) {
            this.finallyRender(viewModel);
        }

        this.setErrorMessageIntoMap(errorMessage, mapsContainerId);
        MapsHelper.hideMask();
    },

    /**
     * @param {String} errorMessage Error message.
     * @returns {Object} Error text component.
     */
    getErrorTextComponent: function(errorMessage) {
        return `<p class="map-error-text">${errorMessage}</p>`;
    },

    /**
     * Sets error message into map container.
     * @param {String} errorMessage Error message.
     * @param {String} mapContainerId Id of map container, which will be used for
     * setting error message to itself.
     */
    setErrorMessageIntoMap: function(errorMessage, mapContainerId) {
        if (this.errorMessageHasAlreadySetIntoMap) {
            return;
        }

        let mapContainer = Ext.get(mapContainerId);

        if (mapContainer) {
            let errorTextComponent = this.getErrorTextComponent(errorMessage);

            mapContainer.setStyle({
                background: '#fff'
            });

            mapContainer.update(errorTextComponent);

            this.errorMessageHasAlreadySetIntoMap = true;
        }
    },

    /**
     * @param {Object} error Error.
     * @returns {String} Maps request error message.
     */
    getMapsRequestErrorMessage: function(error) {
        let errorMessage = 
                    resources.localizableStrings.ErrorWhileRequestingMapService;

        let code = error?.status;

        if (code) {
            let codeCaption = 
                resources.localizableStrings.CodeCaption;

                errorMessage += ` - ${codeCaption} ${code}`;
        }

        return errorMessage;
    },

    /**
     * Handle success response of nominatim request handler.
     * @param {Object} options Nominatim request options.
     * @param {Object} jsonData Response.
     */
    successNominatimRequestHandler: function(options, jsonData) {
        options.success(jsonData);
    },

    /**
     * Generates view for maps module.
     * @param {Object} renderTo Render container.
     * @return {Object} View.
     */
    generateView: function(renderTo) {
        var view = {
            renderTo: renderTo,
            id: "maps",
            selectors: {
                wrapEl: "#maps"
            },
            classes: {
                wrapClassName: ["maps-class"]
            },
            items: [
                this.generateHeaderContainer(),
                {
                    className: "BPMSoft.Container",
                    id: this.mapContainerId,
                    selectors: {wrapEl: "#" + this.mapContainerId},
                    classes: {wrapClassName: ["maps-container-class"]},
                    items: []
                }
            ]
        };
        return view;
    },

    generateHeaderContainer: function() {
        var container={
            id: "maps-header",
            className: "BPMSoft.Container",
            selectors: {
                wrapEl: "#maps-header"
            },
            classes: {
                wrapClassName: ["maps-header"]
            },
            items: [
                {
                    className: "BPMSoft.Label",
                    caption: {bindTo: "HeadMessage"},
                    labelClass: "head-label-user-class",
                    visible: {bindTo: "IsModalBox"}
                },
                {
                    className: "BPMSoft.Button",
                    imageConfig: resources.localizableImages.CloseIcon,
                    style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
                    classes: {wrapperClass: "close-btn-user-class"},
                    click: {bindTo: "onClickCloseMap"},
                    visible: {bindTo: "IsModalBox"}
                }
            ]
        };
        return container;
    },

    /**
     * Generates map view model.
     * @return {Object} Map view model.
     */
    generateViewModel: function() {
        var finallyRender = this.finallyRender;
        var viewModel = {
            values: {
                /**
                 * ######## #####, ### ########### # ###### ###### #### #####.
                 * @type {String}.
                 */
                MapAttribution: this.getMapAttribution(),
                /**
                 * Maps provider config.
                 * @type {String}.
                 */
                MapsProviderConfig: this.mapsProviderConfig,
                /**
                 * #######, ########## ######### ######.
                 * @type {Boolean}.
                 */
                IsRendered: false,
                /**
                 * #######, ############# ########## ####.
                 * @type {Boolean}.
                 */
                IsModalBox: false,
                /**
                 * ###### ######## # ############ ### ########## # ####.
                 */
                SaveMapsData: null,
                /**
                 * ###### ######## ### ########### ## #####.
                 * @type {Array}.
                 */
                MapsData: [],
                /**
                 * ###### ######## ### ########### ## #####.
                 * @type {Array}.
                 */
                Markers: [],
                /**
                 * ###### ### ######### ######.
                 * @type {Object}.
                 */
                RenderTo: null,
                /**
                 * ###### ## ###### Leaflet #####.
                 * @type {Object}.
                 */
                LeafletMap: null,
                /**
                 * ###### ## ###### Leaflet ###### ########.
                 * @type {Object}.
                 */
                LeafletGroup: null,
                /**
                 * ######## #### ##### ## #########.
                 * @type {Number}.
                 */
                ScaleSize: 13,
                /**
                 * ######## ###### ####### ### ########## ###########.
                 * @type {Number}.
                 */
                ShiftLength: 0.00003,
                /**
                 * Map container unique identifier.
                 * @type {String}.
                 */
                MapContainerId: this.mapContainerId
            },
            methods: {
                Ext: Ext,
                BPMSoft: BPMSoft,
                sandbox: this.sandbox,
                setLocationDebounce: null,
                /**
                 * Module parent scope.
                 */
                parentScope: this,

                /**
                 * ############ ############# ###### ####.
                 * @param viewModel ######## ###### ############# ####.
                 */
                finallyRender: finallyRender,

                /**
                 * @param {Array|String} address Address.
                 * @returns {URLSearchParams} Nominatim request params.
                 */
                getNominatimRequestParams: this.getNominatimRequestParams,

                /**
                 * Handle success response of nominatim request handler.
                 * @param {Object} options Nominatim request options.
                 * @param {Object} jsonData Response.
                 */
                successNominatimRequestHandler: this.successNominatimRequestHandler,

                /**
                 * Sets error message into map container.
                 * @param {String} errorMessage Error message.
                 */
                setErrorMessageIntoMap: this.setErrorMessageIntoMap,

                /**
                 * Validates search url params.
                 * @param {Object} params.
                 * @returns {Boolean} Valid or invalid.
                 */
                isSearchParamsValid: this.isSearchParamsValid,

                /**
                 * @param {String} errorMessage Error message.
                 * @returns {Object} Error text component.
                 */
                getErrorTextComponent: this.getErrorTextComponent,

                /**
                 * @param {Object} error Error.
                 * @returns {String} Maps request error message.
                 */
                getMapsRequestErrorMessage: this.getMapsRequestErrorMessage,

                /**
                 * ########## ####### ###### #######.
                 */
                onClickCloseMap: function() {
                    ModalBox.close();
                },

                /**
                 * ############# ########### ##### ## ###########.
                 * @param {Array} mapData ####### ###### ### ########### ## #####.
                 */
                setLocation: function(mapData) {
                    var mapsItems = [];
                    if (this.Ext.isEmpty(mapData)) {
                        MapsHelper.hideMask();
                        this.showInformationDialog(resources.localizableStrings.DataWithoutAddresses);
                        return;
                    }
                    BPMSoft.chain(
                            function(next) {
                                this.set("MapsData", mapData.mapsData);
                                if (this.checkMapsData(mapsItems, mapData)) {
                                    next();
                                }
                            },
                            function(next) {
                                if (!this.Ext.isEmpty(mapsItems)) {
                                    if (this.get("IsRendered")) {
                                        MapsHelper.showMask(true);
                                    }
                                    this.getCoordinates(mapsItems, function() {
                                        var marker = this.get("Markers")[0];
                                        var gpsData = marker[0];
                                        var geoObject = {
                                            lat: gpsData.lat,
                                            lng: gpsData.lon
                                        };
                                        this.sendCoordinates(geoObject);
                                        next();
                                    });
                                } else {
                                    next();
                                }
                            },
                            function(next) {
                                this.finallyRender.call(this.parentScope, this);
                                next();
                            },
                            function(next) {
                                if (mapData.useCurrentUserLocation) {
                                    var locationView = this.getLocationFromMarkers();
                                    this.renderMap(next, locationView);
                                } else {
                                    this.renderMap(next);
                                }
                                MapsHelper.hideMask();
                                next();
                            },
                            function() {
                                this.saveLocationCoordinates();
                            },
                            this);
                },

                /**
                 * ######### ###### ### ########### ## ##### ## ############# ######.
                 * ######### ###### ###### # ############# ########.
                 * @param {Array} mapsItems ######, ####### ##### ########## ## #####.
                 * @param {Array} mapData ####### ###### ### ########### ## #####.
                 * @return {Boolean} ######### ######## ############# ######.
                 */
                checkMapsData: function(mapsItems, mapData) {
                    if (mapData.useDefaultLocation) {
                        this.finallyRender.call(this.parentScope, this);
                        this.renderMap(null, [0, 0]);
                        MapsHelper.hideMask();
                        return false;
                    }
                    BPMSoft.each(mapData.mapsData, function(item) {
                        if (!this.Ext.isEmpty(item.address) || item.isCoordsItem) {
                            if (item.gpsN && item.gpsE) {
                                var geoObject = [
                                    {
                                        lat: item.gpsN,
                                        lon: item.gpsE
                                    }
                                ];
                                geoObject.content = item.content;
                                geoObject.useDragMarker = item.useDragMarker;
                                geoObject.markerIcon = item.markerIcon;
                                this.addMarker(geoObject);
                            } else {
                                mapsItems.push(item);
                            }
                        }
                    }, this);
                    var markers = this.get("Markers") || [];
                    if (mapsItems.length === 0 && markers.length === 0) {
                        this.showInformationDialog(resources.localizableStrings.DataWithoutAddresses);
                        MapsHelper.hideMask();
                        return false;
                    }
                    return true;
                },

                /**
                 * ########## ########## ####### #######.
                 * @return {Array} ########## ####### #######.
                 */
                getLocationFromMarkers: function() {
                    var markers = this.get("Markers");
                    if (Ext.isEmpty(markers)) {
                        return [0, 0];
                    }
                    var marker = markers[0];
                    return [marker[0].lat, marker[0].lon];
                },

                /**
                 * ######## ########## ## #### #######.
                 * @param {Array} items ###### ### ########### ## #####.
                 * @param {Function} callback ####### #### #########.
                 */
                getCoordinates: function(items, callback) {
                    var item = items[0];
                    this.getGeoObject(item, item.address, function(geoObjects) {
                        geoObjects.content = item.content;
                        geoObjects.useDragMarker = item.useDragMarker;
                        geoObjects.markerIcon = item.markerIcon;
                        this.addMarker(geoObjects);
                        items.splice(0, 1);
                        if (items.length) {
                            this.getCoordinates(items, callback);
                        } else {
                            callback.call(this);
                        }
                    });
                },

                /**
                 * ######### ###### ### ########### ## #####.
                 * @param {Array} geoObjects ###### ## ####### # geo #######.
                 */
                addMarker: function(geoObjects) {
                    var markers = this.get("Markers");
                    if (!this.Ext.isArray(markers)) {
                        markers = [];
                    }
                    if (geoObjects) {
                        markers.push(geoObjects);
                    }
                    this.set("Markers", markers);
                },

                /**
                 * ######## ###### ######## #### Leaflet.marker.
                 * @return {Array} ###### ########.
                 */
                getLeafletMarkersArray: function() {
                    var markerArray = [];
                    this.get("Markers").forEach(function(item) {
                        var icon = this.getMarkerIcon(item);
                        var geoObject = item[0];
                        var marker = L.marker([geoObject.lat, geoObject.lon], {
                            icon: icon,
                            draggable: item.useDragMarker
                        });
                        if (item.content) {
                            marker.bindPopup(item.content);
                        }
                        marker.on("dragend", this.processDragEndMarker, this);
                        markerArray.push(marker);
                    }, this);
                    return markerArray;
                },

                /**
                 * ############# ####### ####### ##### ############ ###### ########.
                 * @param {Object} map ###### #####.
                 * @param {Object} group ###### ###### ########.
                 */
                fitBoundsMap: function(map, group) {
                    map.fitBounds(group.getBounds(), {
                        paddingTopLeft: [50, 50],
                        paddingBottomRight: [20, 0]
                    });
                },

                /**
                 * ############## ##### ############ ##### ######## ##########.
                 */
                normalizeSizeMap: function() {
                    var map = this.get("LeafletMap");
                    var group = this.get("LeafletGroup");
                    map.invalidateSize({reset: true});
                    if (!this.Ext.isEmpty(group) && !this.Ext.isEmpty(group.getLayers())) {
                        this.fitBoundsMap(map, group);
                    }
                },

                getTileUrl: function() {
                    let mapsProviderConfig = this.$MapsProviderConfig;
                    let mapTileUrl = mapsProviderConfig.urlForGettingTiles;

                    if (mapsProviderConfig.useApiKey) {
                        mapTileUrl = mapTileUrl.replace("{0}", mapsProviderConfig.apiKey);
                    }

                    return mapTileUrl;
                },

                /**
                 * ######### #####.
                 * @param {Function} callback ####### #### #########.
                 * @param {Array} locationView ##########.
                 */
                renderMap: function(callback, locationView) {
                    var map = this.get("LeafletMap");
                    var group = this.get("LeafletGroup");
                    if (this.Ext.isEmpty(map)) {
                        map = L.map(this.get("MapContainerId"));
                        let mapTileUrl = this.getTileUrl();
                        L.tileLayer(mapTileUrl, {attribution: this.get("MapAttribution")
                        }).addTo(map);
                        map.on("resize", this.normalizeSizeMap, this);
                    }
                    if (!this.Ext.isEmpty(locationView)) {
                        map.setView(locationView, this.get("ScaleSize"));
                        this.set("LeafletMap", map);
                        this.set("Markers", []);
                        if (!this.Ext.isEmpty(group)) {
                            group.clearLayers();
                        }
                        return;
                    }
                    var markerArray = this.getLeafletMarkersArray();
                    markerArray = this.reorderSimilarMarker(markerArray, this.get("ShiftLength"));
                    if (!this.Ext.isEmpty(group)) {
                        group.clearLayers();
                        group.addLayer(L.featureGroup(markerArray));
                    } else {
                        var featureGroup = new L.featureGroup(markerArray);
                        group = featureGroup.addTo(map);
                    }
                    this.fitBoundsMap(map, group);
                    this.setHeaderCaption();
                    this.set("LeafletGroup", group);
                    this.set("LeafletMap", map);
                    this.set("Markers", []);
                    if (this.get("IsModalBox")) {
                        ModalBox.updateSizeByContent();
                    }
                    if (this.Ext.isFunction(callback)) {
                        callback.call(this);
                    }
                },

                /**
                 * ######### ####### # ########### ############ # ##### ## #########.
                 * @param {Array} inputMarkers ####### ###### ########.
                 * @param {number} step ######## ####### ########.
                 * @return {Array} ################## ###### ########.
                 */
                reorderSimilarMarker: function(inputMarkers, step) {
                    var outputMarkers = [];
                    inputMarkers.forEach(function(item) {
                        var geoObject = item._latlng;
                        var lat = geoObject.lat;
                        var lng = geoObject.lng;
                        item.delta = 0;
                        outputMarkers.forEach(function(outItem) {
                            if ((outItem._latlng.lat === lat) && (outItem._latlng.lng === lng)) {
                                item.delta = outItem.delta + step;
                            }
                        });
                        outputMarkers.push(item);
                    });
                    outputMarkers.forEach(function(item) {
                        var delta = item.delta;
                        var latLng = item._latlng;
                        latLng.lat += delta;
                        latLng.lng += delta;
                    });
                    return outputMarkers;
                },

                /**
                 * Returns marker icon params.
                 * @param {Object} config Map item config.
                 * @param {Object} config.markerIcon Map item marker icon.
                 * @return {Object} Marker icon params.
                 */
                getMarkerIcon: function(config) {
                    config = config || {};
                    var iconUrl = BPMSoft.ImageUrlBuilder.getUrl(config.markerIcon ||
                            resources.localizableImages.MarkerIcon);
                    var shadowUrl = BPMSoft.ImageUrlBuilder.getUrl(
                            resources.localizableImages.MarkerShadow);
                    return L.icon({
                        iconUrl: iconUrl,
                        shadowUrl: shadowUrl,
                        iconSize: [25, 41],
                        shadowSize: [41, 41],
                        iconAnchor: [11, 41],
                        shadowAnchor: [12, 41],
                        popupAnchor: [1, -32]
                    });
                },

                /**
                 * ############# ######### ########## ####.
                 */
                setHeaderCaption: function() {
                    var mapsData = this.get("MapsData");
                    var markers = this.get("Markers");
                    var addressCount = mapsData.length;
                    var foundedAddressCount = markers.length;
                    if (addressCount === foundedAddressCount) {
                        this.set("HeadMessage", resources.localizableStrings.AddressesFoundFull);
                    } else {
                        var message = this.Ext.String.format(resources.localizableStrings.AddressesFoundPartially,
                                foundedAddressCount, addressCount);
                        this.set("HeadMessage", message);
                    }
                },

                /**
                 * ########## ########## ############## #######.
                 * @param {Object} marker ########## # #######.
                 */
                processDragEndMarker: function(marker) {
                    var map = this.get("LeafletMap");
                    var group = this.get("LeafletGroup");
                    this.fitBoundsMap(map, group);
                    var latLng = marker.target.getLatLng();
                    this.sendCoordinates(latLng);
                },

                /**
                 * ######## ######### # ########.
                 * @param {Array} latLng ##########.
                 */
                sendCoordinates: function(latLng) {
                    if (this.Ext.isEmpty(latLng)) {
                        return;
                    }
                    this.sandbox.publish("GetCoordinates", latLng, [this.sandbox.id]);
                },

                /**
                 * ######## ########## ## ######### ###### ######### ###### Nominatim.
                 * @param {Object} mapDataItem ####### ####### ### #####.
                 * @param {Array|String} address #####.
                 * @param {Function} callback ####### #### #########.
                 */
                getGeoObject: function(mapDataItem, address, callback) {
                    if (MapsHelper.getIsEmptyAddress(address)) {
                        MapsHelper.hideMask();
                        this.showInformationDialog(resources.localizableStrings.AddressesNotFound);
                    } else {
                        var options = this.getNominatimRequestOptions(mapDataItem, address, callback);
                        this.executeCoordinatesRequest(options);
                    }
                },

                /**
                 * Get coordinates from maps provider.
                 * @param {Object} options Request options.
                 */
                executeCoordinatesRequest: function(options) {
                    if (!this.isSearchParamsValid(options.params)) {
                        MapsHelper.hideMask();
                        this.showInformationDialog(resources.localizableStrings.AddressesNotFound);

                        return;
                    }

                    let params = new URLSearchParams(options.params);
                    let me = this;

                    fetch(options.url + '?' + params, {
                        method: 'GET'
                    })
                    .then((response) => {
                        if (!response.ok) {
                            return Promise.reject(response);
                        }

                        return response.json();
                    })
                    .then((jsonData) => me.successNominatimRequestHandler(options, jsonData))
                    .catch((error) => options.failure(error));
                },

                /**
                 * Processes response from Nominatime geo service.
                 * @param {Object} response Service response.
                 * @param {Object} mapDataItem Current map element.
                 * @param {Function} callback Callback function.
                 */
                processNominatimResponse: function(response, mapDataItem, callback) {
                    if (!this.Ext.isEmpty(response)) {
                        if (mapDataItem.updateCoordinatesConfig) {
                            this.addSaveMapsData(mapDataItem, response[0]);
                        }
                        callback.call(this, response);
                    } else {
                        MapsHelper.hideMask();
                        this.showInformationDialog(resources.localizableStrings.AddressesNotFound);
                    }
                },

                /**
                 * ####### ######### ####### ## ######.
                 * @param {Array|String} address #####.
                 * @return {Array} #####.
                 */
                addressPop: function(address) {
                    if (!this.Ext.isArray(address)) {
                        address = address.split(", ");
                    }
                    address.pop();
                    return address.join(", ");
                },

                /**
                 * Returns options for building Nominatim service query.
                 * @param {Object} mapDataItem Curent element for map.
                 * @param {Array|String} address Address.
                 * @return {Object} Service request options Nominatim.
                 */
                getNominatimRequestOptions: function(mapDataItem, address, callback) {
                    var me = this;
                    var url = this.$MapsProviderConfig.urlForGettingAddresses;
                    var params = this.getNominatimRequestParams(address);
                    
                    return {
                        url: url,
                        params: params,
                        failure: function(error) {
                            let errorMessage = me.getMapsRequestErrorMessage(error);
                            me.setErrorMessageIntoMap(errorMessage, me.$MapContainerId);
                        },
                        success: function(response) {
                            me.processNominatimResponse(response, mapDataItem, callback);
                        }
                    };
                },

                /**
                 * ######### # ###### ######## # ############ ### ########## # ####.
                 * @param {Object} mapDataItem ###### ### ###########.
                 * @param {Object} geoObject ###### # ############
                 */
                addSaveMapsData: function(mapDataItem, geoObject) {
                    if (mapDataItem.gpsN === geoObject.lat && mapDataItem.gpsE === geoObject.lon) {
                        return;
                    }
                    var saveMapsData = this.get("SaveMapsData");
                    var saveMapItem = {
                        id: mapDataItem.updateCoordinatesConfig.id,
                        schemaName: mapDataItem.updateCoordinatesConfig.schemaName,
                        gpsN: geoObject.lat,
                        gpsE: geoObject.lon
                    };
                    if (!Ext.isArray(saveMapsData)) {
                        saveMapsData = [];
                    }
                    saveMapsData.push(saveMapItem);
                    this.set("SaveMapsData", saveMapsData);
                },

                /**
                 * ######### ########## # ####.
                 */
                saveLocationCoordinates: function() {
                    var items = this.get("SaveMapsData");
                    if (Ext.isEmpty(items)) {
                        return;
                    }
                    var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
                    var requestUrl = workspaceBaseUrl + "/rest/MapsService/CacheCoordinates";
                    BPMSoft.AjaxProvider.request({
                        url: requestUrl,
                        headers: {
                            "Accept": "application/json",
                            "Content-Type": "application/json"
                        },
                        method: "POST",
                        jsonData: {
                            itemsJSON: Ext.JSON.encode(items)
                        },
                        callback: function(request, success) {
                            if (success) {
                                this.set("SaveMapsData", []);
                            }
                        },
                        scope: this
                    });
                }
            }
        };
        return viewModel;
    },

    /**
     * ############ ############# ###### ####.
     * @param {Object} viewModel ######## ###### ############# ####.
     */
    finallyRender: function(viewModel) {
        if (viewModel.get("IsRendered")) {
            return;
        }
        var renderTo = viewModel.get("RenderTo");
        if (viewModel.get("IsModalBox")) {
            var boxSize = {
                minWidth: 43,
                maxWidth: 43,
                minHeight: 58,
                maxHeight: 58,
                boxClasses: 'map-modal'
            };
            renderTo = ModalBox.show(boxSize);
        }
        var view = this.Ext.create("BPMSoft.Container", this.generateView(renderTo));
        view.bind(viewModel);
        this.sandbox.publish("AfterRenderMap", null, [this.sandbox.id]);
        viewModel.set("IsRendered", true);
    }
});
return BPMSoft.BaseMapsModule;
});
