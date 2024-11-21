define("AccountAddressPageV2", ["DaDataSuggestionsMixin"], function() {
	return {
		entitySchemaName: "AccountAddress",
		attributes: {
			/**
			 * Строка поиска адреса.
			 */
			"DaDataSearchLine": {
				"contentType": this.BPMSoft.ContentType.SEARCHABLE_TEXT,
				"caption": { "bindTo": "Resources.Strings.DaDataSearchLineCaption"},
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"searchableTextConfig": {
					"listAttribute": "DaDataSuggestions",
					"prepareListMethod": "prepareSuggestionsExpandableList",
					"listViewItemRenderMethod": "onSuggestionsListViewItemRender",
					"itemSelectedMethod": "onSuggestionItemSelected"
				}
			},
			
			/**
			 * Сопоставление полей DaData с полями на карточке.
			 */
			"DaDataSuggestionsSettings": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": []
			},
			
			/**
			 * Сопоставление полей DaData с полями на карточке.
			 */
			"DaDataDisplayColumnName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"value": "Address"
			},
			
			/**
			 * Признак отображения блока подсказок на странице.
			 */
			"DaDataIsActive": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		messages: {},
		mixins: {
			DaDataSuggestionsMixin: "BPMSoft.DaDataSuggestionsMixin"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				let parentInit = this.getParentMethod(this, arguments);
				this.initDaDataSuggestionsEntity(this.entitySchemaName, function(result) {
					this.set("DaDataIsActive", result);
					parentInit();
				}, this);
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseAddressPageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.initDaDataSuggestionsSettings(this.entitySchemaName);
				this.callParent(arguments);
				this.updateSearchLines();
			},

			callDaDataService: function(partialName) {
				this.callDaDataAddressSuggestionsService(partialName, "DaDataSearchLine");
			},
			
			/**
			 * Повторный запрос к сервису для получения координат по конкретной записи.
			 * @inheritdoc BPMSoft.DaDataSuggestionsMixin#setAdditionalFields
			 * @override
			 */
			setAdditionalFields: function() {
				let searchLine = this.get("DaDataSearchLine");
				//Вызов сервиса получения подсказок по адресам из DaData.
				this.callDaDataAddressSuggestionsService(searchLine, "DaDataSearchLine", this.setGeo, 1);
			},
			
			/**
			 * Установить значения геокоординат адреса.
			 * @param {Object} response Ответ метода GetAddressSuggestionsList сервиса DaDataSuggestionsService.
			 */
			setGeo: function(response) {
				if (response &&
					response.GetAddressSuggestionsListResult &&
					response.GetAddressSuggestionsListResult.suggestions &&
					response.GetAddressSuggestionsListResult.suggestions.length === 1) {
					
					let suggestion = response.GetAddressSuggestionsListResult.suggestions[0];
					this.set("GeoLat", suggestion.data.geo_lat);
					this.set("GeoLon", suggestion.data.geo_lon);
					this.updateMap();
				}
			},
			
			/**
			 * Обновляет координаты метки на карте значениями геокоординат адреса.
			 * @param {Object} Конфигурация объекта метки карты.
			 */
			updateMarkerObject: function(markerObject) {
				let gpsN = this.get("GeoLat");
				let gpsE = this.get("GeoLon");
				if (gpsN && gpsE) {
					markerObject.address = gpsN + ", " + gpsE;
					markerObject.gpsN = gpsN;
					markerObject.gpsE = gpsE;
					
					this.set("GPSN", gpsN);
					this.set("GPSE", gpsE);
				}
			},
			
			/**
			 * @inheritdoc BPMSoft.AccountAddressPageV2#getMapsConfig
			 * @override
			 */
			getMapsConfig: function() {
				let mapsConfig = this.callParent();
				let markerObject = mapsConfig.mapsData[0] || {};
				this.updateMarkerObject(markerObject);
				return mapsConfig;
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DaDataHeaderContainer",
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": {"bindTo": "DaDataHeaderContainerMarkerValue"},
					"visible": {"bindTo": "DaDataIsActive"}
				},
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccountPageGeneralTabContainerGroupce05462e",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AccountPageGeneralTabContainerGroupce05462eGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "DaDataHeaderContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccountPageGeneralTabContainerGridLayout213f25ec",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "AccountPageGeneralTabContainerGroupce05462e",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DaDataSearchLinef8039a04-e03d-43c3-8590-2eafd4d354f6",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "AccountPageGeneralTabContainerGridLayout213f25ec"
					},
					"bindTo": "DaDataSearchLine",
					"contentType": 6
				},
				"parentName": "AccountPageGeneralTabContainerGridLayout213f25ec",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/
	};
});