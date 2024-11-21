define("AccountAddressPageV2", ["BusinessRuleModule", "MapsUtilities"], 
function(BusinessRuleModule, MapsUtilities) {
	return {
		entitySchemaName: "AccountAddress",
		attributes: {
			/**
			 * Maps provider config.
			 */
			"MapsProviderConfig": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Address.
			 */
			"Address": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				dependencies: [
					{
						columns: ["Address"],
						methodName: "updateMap"
					}
				]
			},

			/**
			 * Country.
			 */
			"Country": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				dependencies: [
					{
						columns: ["Country"],
						methodName: "updateMap"
					}
				]
			},

			/**
			 * City.
			 */
			"City": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				dependencies: [
					{
						columns: ["City"],
						methodName: "updateMap"
					}
				]
			},

			/**
			 * Zip.
			 */
			"Zip": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				dependencies: [
					{
						columns: ["Zip"],
						methodName: "updateMap"
					}
				]
			}
		},
		messages: {

			/**
			 * @message GetMapsConfig.
			 * Gets maps module configuration.
			 */
			"GetMapsConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message SetMapsConfig.
			 * Sets maps module configuration.
			 */
			"SetMapsConfig": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetCoordinates.
			 * Gets marker's coordinates.
			 */
			"GetCoordinates": {
				"mode": this.BPMSoft.MessageMode.PTP,
				"direction": this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			init: function() {
				let parentInit = this.getParentMethod(this, arguments);

				MapsUtilities.getMapsProviderConfigAsync()
					.then(value => this.$MapsProviderConfig = value)
					.finally(() => parentInit());
			},

			//region Methods: Private

			/**
			 * Gets maps module sandbox identifier.
			 * @private
			 * @return {String} Maps module sandbox identifier.
			 */
			getMapsModuleSandboxId: function() {
				var mapsModuleSandboxId = this.get("mapsModuleSandboxId");
				if (!mapsModuleSandboxId) {
					mapsModuleSandboxId = Ext.String.format("{0}_MapsModule{1}", this.sandbox.id,
						BPMSoft.generateGUID());
					this.set("mapsModuleSandboxId", mapsModuleSandboxId);
				}
				return mapsModuleSandboxId;
			},

			/**
			 * Updates map.
			 * @private
			 */
			updateMap: function() {
				this.set("GPSN", "");
				this.set("GPSE", "");
				this.changeLocation();
			},

			/**
			 * Finds country. May use region or city information.
			 * @private
			 * @return {Object} Country.
			 */
			findCountry: function() {
				var country = this.get("Country");
				if (country) {
					return country;
				}
				var region = this.get("Region");
				if (region && region.Country) {
					return region.Country;
				}
				var city = this.get("City");
				if (city && city.Country) {
					return city.Country;
				}
				return null;
			},

			/**
			 * Gets map container.
			 * @private
			 * @return {Object} Map container.
			 */
			getMapContainer: function() {
				return this.Ext.get("Map");
			},

			/**
			 * Gets map configuration for OSM module.
			 * @protected
			 * @return {Object} Map configuration for OSM module.
			 */
			getMapsConfig: function() {
				var mapsModuleSandboxId = this.getMapsModuleSandboxId();
				var country = this.findCountry();
				var city = this.get("City");
				var mapsConfig = {
					mapsData: [],
					renderTo: this.getMapContainer(),
					scope: this,
					mapsModuleSandboxId: mapsModuleSandboxId
				};
				var markerObject = {};
				if (country || city) {
					var region = this.get("Region");
					var street = this.get("Address");
					var gpsN = this.get("GPSN");
					var gpsE = this.get("GPSE");
					var zip = this.get("Zip");
					var countryValue = country && country.displayValue;
					var cityValue = city && city.displayValue;
					var regionValue = region && region.displayValue;
					markerObject.address = [countryValue, regionValue, cityValue, street, zip];
					markerObject.useDragMarker = true;
					if (gpsN && gpsE) {
						markerObject.address = gpsN + ", " + gpsE;
						markerObject.gpsN = gpsN;
						markerObject.gpsE = gpsE;
					}
				} else {
					markerObject.address = "0.0, 0.0";
					markerObject.gpsN = "0.0";
					markerObject.gpsE = "0.0";
					mapsConfig.mapsData.useCurrentUserLocation = true;
				}
				mapsConfig.mapsData.push(markerObject);
				return mapsConfig;
			},

			/**
			 * Changes location on the map.
			 * @private
			 */
			changeLocation: function() {
				var mapsConfig = this.getMapsConfig();
				this.sandbox.publish("SetMapsConfig", mapsConfig,
					[this.getMapsModuleSandboxId()]);
			},

			/**
			 * Loads maps module.
			 * @private
			 */
			loadMapsModule: function() {
				let mapsProviderConfig = this.$MapsProviderConfig;

				/* По умолчанию грузится OsmMapsModule, если конфиг не определён. Необходимо для того,
				 * чтобы была возможность открыть модуль и пробросить в него неверные параметры,
				 * которые затем там же и провалидируются и на странице пользователя корректно 
				 * отобразятся ошибки согласно ЧТЗ. Не представляется возможным грузить BaseMapsModuel
				 * так как там присутствуют абстрактные функции, требующие реализации.
				 */
				let mapsModuleName = mapsProviderConfig ?
					MapsUtilities.getMapsModuleNameByMapsProviderId(mapsProviderConfig.mapsProviderId)
					: "OsmMapsModule";

				this.sandbox.loadModule(mapsModuleName, {
					id: this.getMapsModuleSandboxId(),
					instanceConfig: {
						mapsProviderConfig: mapsProviderConfig
					}
				});
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 * @protected
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.changeLocation();
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
			 * @overridden
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var mapsModuleSandboxId = this.getMapsModuleSandboxId();
				this.sandbox.subscribe("GetMapsConfig", function() {
					return this.getMapsConfig();
				}, this, [mapsModuleSandboxId]);
				this.sandbox.subscribe("GetCoordinates", function(coordinates) {
					var gpsN = coordinates.lat;
					var gpsE = coordinates.lng;
					this.saveAddressCoordinates(gpsN, gpsE);
				}, this, [mapsModuleSandboxId]);
			},

			//endregion

			//region Methods: Public

			/**
			 * Saves new coordinates.
			 * @param {Number} gpsN GPSN coordinate.
			 * @param {Number} gpsE GPSE coordinate.
			 */
			saveAddressCoordinates: function(gpsN, gpsE) {
				if (gpsN && gpsE) {
					this.set("GPSN", gpsN.toString());
					this.set("GPSE", gpsE.toString());
				}
			}

			//endregion

		},
		details: /**SCHEMA_DETAILS*/{
		}/**SCHEMA_DETAILS*/,
		rules: {
			"AddressType": {
				"FiltrationAddressTypeByOwner": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					baseAttributePatch: "ForAccount",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.CONSTANT,
					value: true
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AddressMapContainer",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"values": {
					"id": "AddressMapContainer",
					"selectors": {"wrapEl": "#AddressMapContainer"},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["addressmap"]
				}
			},
			{
				"operation": "insert",
				"parentName": "AddressMapContainer",
				"propertyName": "items",
				"name": "Map",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.MODULE,
					"moduleName": "MapsModule",
					"afterrender": {bindTo: "loadMapsModule"},
					"classes": {"wrapClassName": "maps-user-class"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
