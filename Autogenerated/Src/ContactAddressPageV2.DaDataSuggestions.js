define("ContactAddressPageV2", ["BusinessRuleModule", "DaDataSuggestionsMixin"], function(BusinessRuleModule) {
	return {
		entitySchemaName: "ContactAddress",
		details: /**SCHEMA_DETAILS*/{
		}/**SCHEMA_DETAILS*/,
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
		mixins: {
			DaDataSuggestionsMixin: "BPMSoft.DaDataSuggestionsMixin"
		},
		rules: {
			"AddressType": {
				"FiltrationAddressTypeByOwner": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					baseAttributePatch: "ForContact",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.CONSTANT,
					value: true
				}
			}
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
		},
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
				"name": "ContactPageGeneralTabContainerGroupce05462e",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.ContactPageGeneralTabContainerGroupce05462eGroupCaption"
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
				"name": "ContactPageGeneralTabContainerGridLayout213f25ec",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "ContactPageGeneralTabContainerGroupce05462e",
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
						"layoutName": "ContactPageGeneralTabContainerGridLayout213f25ec"
					},
					"bindTo": "DaDataSearchLine",
					"contentType": 6
				},
				"parentName": "ContactPageGeneralTabContainerGridLayout213f25ec",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/
	};
});