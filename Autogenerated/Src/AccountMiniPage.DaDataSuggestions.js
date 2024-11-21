define("AccountMiniPage", ["ConfigurationConstants", "DaDataSuggestionsMixin"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "Account",
		attributes: {
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
			 * Массив подсказок, полученных из DaData по последнему запросу.
			 */
			"DaDataSuggestions": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: []
			},
			
			/**
			 * Сопоставление полей DaData с полями на карточке.
			 */
			"DaDataSuggestionsSettings": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: []
			},
			
			/**
			 * Сопоставление полей DaData с полями на карточке.
			 */
			"DaDataDisplayColumnName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: "Name"
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
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
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

			callDaDataService: function(partialName){
				this.callDaDataAccountSuggestionsService(partialName, "DaDataSearchLine")
			},

			enrichData: function(entity, callback){
				this.callGetAccountSuggestionsFullList(entity, callback)
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseAddressPageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.initDaDataSuggestionsSettings("Account");
				this.callParent(arguments);
				this.updateSearchLines();
			},
			
			/**
			 * @inheritdoc BPMSoft.DaDataSuggestionsMixin#setAdditionalFields
			 * @override
			 */
			setAdditionalFields: function() {
				this.set("AddressType", ConfigurationConstants.AddressTypes.Legal);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DaDataMiniPageEditModeContainer",
				"parentName": "MiniPageEditModeContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": {"bindTo": "DaDataMiniPageEditModeContainer"},
					"visible": {"bindTo": "DaDataIsActive"}
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DaDataSearchLineInAddMode",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					},
					"visible": {"bindTo": "isNotViewMode"},
					"isMiniPageModelItem": true,
					"bindTo": "DaDataSearchLine",
					"contentType": 6,
					"controlConfig": {
						"placeholder": { "bindTo": "Resources.Strings.DaDataSearchLinePlaceholder"}	
					}
				},
				"parentName": "DaDataMiniPageEditModeContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "NameInAddMode",
				"values": {
					"controlConfig": {
						"focused": false
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});