define("AccountPageV2", ["ConfigurationConstants", "EnrichmentDataModuleMixin", "css!BaseEnrichmentSchemaCSS"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Account",
			messages: {
				/**
				 * Hides enrichment data module.
				 * @message HideEnrichmentDataModule
				 */
				"HideEnrichmentDataModule": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"GetDaDataSuggestionsSettings": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"SetAccountData": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
	
				/**
				 * Returns detail id by name.
				 * @message GetDetailId
				 * @param {String} detailName Detail name.
				 */
				"GetDetailId": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},
	
				/**
				 * Сопоставление полей DaData с полями на карточке.
				 */
				"DaDataSuggestionsSettings": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					value: []
				},
	
				"DaDataIsActive": {
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				"IsSettingsSet": {
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},
	
				/**
				 * Shows enrichment data module.
				 * @message ShowEnrichmentDataModule
				 */
				"ShowEnrichmentDataModule": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
			},
			mixins: {
				EnrichmentDataModuleMixin: "BPMSoft.EnrichmentDataModuleMixin"
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.mixins.EnrichmentDataModuleMixin.init.call(this);
					let parentInit = this.getParentMethod(this, arguments);
					this.initDaDataSuggestionsEntity(this.entitySchemaName, function(result) {
						this.set("DaDataIsActive", result);
						this.checkSysSettings();
						parentInit();
					}, this);
				},
	
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetDaDataSuggestionsSettings", this.getDaDataSuggestionsSettings, this);
					this.sandbox.subscribe("SetAccountData", this.setAccountData, this);
				},
	
				getDaDataSuggestionsSettings: function(){
					return this.get("DaDataSuggestionsSettings");
				},
	
				setAccountData(accountData){
					this.set("MainAddress", {});
					this.set("InsertAccountAddressOnSave", true)
					let detailColumnMapping = this.get("AddressDetailColumnMapping");
					let newAddressRow = detailColumnMapping ? this.addNewAddressRow() : null;
	
					for (let key in accountData)
					{
						let addressMap = BPMSoft.findWhere(detailColumnMapping, {TagName: key});
						if(newAddressRow && addressMap) {
							if(addressMap){
								newAddressRow[key] = accountData[key];
							}
						} else {
							let column = this.columns[key];
							if (column) {
								if (column.dataValueType === BPMSoft.DataValueType.DATE || column.dataValueType === BPMSoft.DataValueType.DATE_TIME) {							
									let milliseconds = Number.parseInt(accountData[key]);
									let date = milliseconds
										? new Date(milliseconds)
										: null;
									this.set(key, date);
								} else if (column.isLookup) {
									this.setLookupValueByName(
										accountData[key], column.referenceSchemaName, key);
								} else {
									this.set(key, accountData[key]);
								}
							} else {
								this.set(key, accountData[key]);
							}
						}
					}
					if(newAddressRow){
						this.setLookupsConfig(newAddressRow, function(){
							this.selectPrimaryAddress(newAddressRow, true);
						})
					}
				},
	
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.getEnrichedDataCount(this.onGetEnrichedDataCount, this);
					this.initDaDataSuggestionsSettings(this.entitySchemaName);
				},
	
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					this.getEnrichedDataCount(this.onGetEnrichedDataCount, this);
				},
	
				/**
				 * Handler of the getEnrichedDataCount.
				 * @private
				 * @param {Object} response Enrichment data count response.
				 */
				onGetEnrichedDataCount: function(response) {
					if (response.success) {
						var selectResult = response.collection.getByIndex(0);
						var rowsCount = selectResult.get("Count");
						this.set("EnrichedDataCount", rowsCount);
					}
				},
	
				/**
				 * Gets enrichment button icon.
				 * @protected
				 * @return {Object} Icon config.
				 */
				getEnrichmentButtonIcon: function() {
					var enrichedDataCount = this.get("EnrichedDataCount");
					var buttonIcon = this.get("Resources.Images.DataSearch");
					if (enrichedDataCount) {
						buttonIcon = this.get("Resources.Images.EnrichedDefaultIcon");
					}
					return buttonIcon;
				},
	
				/**
				 * Gets enrichment button caption.
				 * @protected
				 * @return {String} Button caption.
				 */
				getEnrichmentButtonCaption: function() {
					var enrichedDataCount = this.get("EnrichedDataCount");
					var buttonCaption = this.get("Resources.Strings.EnrichmentDefaultButtonCaption");
					if (enrichedDataCount) {
						var buttonCaptionTemplate = this.get("Resources.Strings.EnrichedDefaultButtonCaption");
						buttonCaption = this.Ext.String.format(buttonCaptionTemplate, enrichedDataCount);
					}
					return buttonCaption;
				},
	
				/**
				 * Gets enrichment button hint.
				 * @protected
				 * @return {String} Button hint
				 */
				getEnrichmentButtonHint: function() {
					var enrichedDataCount = this.get("EnrichedDataCount");
					var buttonHint = this.get("Resources.Strings.EnrichmentDefaultButtonHint");
					if (enrichedDataCount) {
						buttonHint = this.get("Resources.Strings.EnrichedDefaultButtonHint");
					}
					return buttonHint;
				},
	
				/**
				 * @inheritdoc BPMSoft.EnrichmentDataModuleMixin#getEnrichedDataCountEsq
				 * @overridden
				 */
				getEnrichedDataCountEsq: function() {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "AccountEnrichedData"
					});
					esq.addAggregationSchemaColumn("Id",
							this.BPMSoft.AggregationType.COUNT, "Count");
					esq.filters.addItem(esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Account", this.get(this.primaryColumnName)));
					var notExistsFilter = this.BPMSoft.createNotExistsFilter(
							"[AccountCommunication:Number:Value].Id");
					var subFilter = esq.createFilter(BPMSoft.ComparisonType.EQUAL,
							"[AccountCommunication:Account:Account].Account", "Account");
					notExistsFilter.subFilters.addItem(subFilter);
					esq.filters.addItem(notExistsFilter);
					return esq;
				},
	
				setAdditionalFields: function() {
					this.set("AddressType", ConfigurationConstants.AddressTypes.Legal);
				},

				checkSysSettings: function(){
					this.checkEnrichmentSysSettings((isSet) => {
						this.set("IsSettingsSet", this.get("DaDataIsActive") || isSet);
					})
				}
			},
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
				 * Enrichment data count.
				 * @type {Integer}
				 */
				"EnrichedDataCount": {
					dataValueType: this.BPMSoft.DataValueType.INTEGER,
					value: 0
				},
				/**
				 * Enrichment operation code.
				 * @type {String}
				 */
				"EnrichmentOperationCode": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: "CanEnrichAccountData"
				}
			},
			modules: {
				"EnrichmentModule": {
					"config": {
						"schemaName": "AccountEnrichmentSchema",
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"AlignToElId": "EnrichmentButtonContainer",
								"PrimaryColumnName": "Id"
							}
						}
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "EnrichmentModuleContainer",
					"parentName": "AccountPhotoContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "IsEnrichmentModuleVisible"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "EnrichmentModule",
					"parentName": "EnrichmentModuleContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.MODULE
					}
				},
				{
					"operation": "insert",
					"name": "EnrichmentButtonContainer",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"values": {
						"id": "EnrichmentButtonContainer",
						"selectors": {
							"wrapEl": "#EnrichmentButtonContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["enrichment-button-container"],
						"items": [],
						"visible": {
							"bindTo": "IsSettingsSet"
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EnrichmentButtonContainer",
					"name": "EnrichmentActionButton",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getEnrichmentButtonIcon"},
						"caption": {"bindTo": "getEnrichmentButtonCaption"},
						"hint": {"bindTo": "getEnrichmentButtonHint"},
						"classes": {
							"wrapperClass": ["enrichment-action-button"]
						},
						"click": {"bindTo": "loadEnrichmentModule"},
						'style': BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				}
			]/**SCHEMA_DIFF*/
		};
});