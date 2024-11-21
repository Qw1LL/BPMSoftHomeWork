define("AccountPageV2", ["ConfigurationConstants", "DaDataSuggestionsMixin"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "Account",
		attributes: {
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
			},

			"Name": {
				"contentType": this.BPMSoft.ContentType.SEARCHABLE_TEXT,
				"searchableTextConfig": {
					"listAttribute": "DaDataSuggestions",
					"prepareListMethod": "prepareSuggestionsExpandableList",
					"listViewItemRenderMethod": "onSuggestionsListViewItemRender",
					"itemSelectedMethod": "onSuggestionItemSelected"
				}
			},

			"MainAddress": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: {}
			},

			"InsertAccountAddressOnSave": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			"AddressWasForcedToInsert": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			"AddressDetailColumnMapping": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: [
					{
						TagName: "Address"
					},
					{
						TagName: "Country",
						isLookup: true
					},
					{
						TagName: "Region",
						isLookup: true
					},
					{
						TagName: "City",
						isLookup: true
					},
					{
						TagName: "GPSN"
					},
					{
						TagName: "GPSE"
					},
					{
						TagName: "Zip"
					},
				]
			},
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		messages: {
			"UpdateAddressRow": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			"SetNewMainAddress": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
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
				this.sandbox.subscribe("SetNewMainAddress", this.setNewMainAddress, this);
				this.initDaDataSuggestionsEntity(this.entitySchemaName, function(result) {
					this.set("DaDataIsActive", result);
					parentInit();
				}, this);
			},

			afterEntitySet(){
				this.setAdditionalFields();
			},

			callDaDataService: function(partialName){
				this.callDaDataAccountSuggestionsService(partialName, "DaDataSearchLine");
			},

			enrichData: function(entity, callback){
				this.callGetAccountSuggestionsFullList(entity, callback)
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseAddressPageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.initDaDataSuggestionsSettings(this.entitySchemaName);
				this.callParent(arguments);
			},
			

			addNewAddressRow: function(){
				let id = BPMSoft.generateGUID();
				let addressType = ConfigurationConstants.AddressTypes.Legal;
				return {
					Id: id,
					Primary: true,
					AddressType: addressType,
				};;
			},

			onDiscardChangesClick: function() {
				this.callParent();
				this.updateDetail({detail: "AccountAddress"});
			},
			
			/**
			 * Выполняет действия, необходимые после сохранения результата подсказки.
			 */
			onDaDataSuggestionResultSaved: function() {
				this.updateDetail({detail: "AccountAddress"});
			},
			
			/**
			 * @inheritdoc BPMSoft.BasePageV2#onSaved
			 */
			onSaved: function() {
				this.callParent(arguments);
				this.saveAddressToDatabase();
				this.onDaDataSuggestionResultSaved();
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
		]/**SCHEMA_DIFF*/
	};
});