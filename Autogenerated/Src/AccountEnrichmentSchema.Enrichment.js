define("AccountEnrichmentSchema", ["ConfigurationConstants", "BaseEnrichmentSchema", "AccountEnrichmentViewModel", "DaDataSuggestionsMixin"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "AccountEnrichedData",
		mixins: {
			DaDataSuggestionsMixin: "BPMSoft.DaDataSuggestionsMixin"
		},
		messages: {
			/**
			 * Hide enrichment data module container.
			 * @message HideEnrichmentDataModule
			 */
			"GetDaDataSuggestionsSettings": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			"SetAccountData": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		attributes: {
			/**
			 * Communication detail name for sync.
			 * @type {String}
			 */
			"CommunicationDetailName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: "Communications"
			},

		},

		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#getEntitySchemaQuery
			 * @overridden
			 */
			getEntitySchemaQuery: function() {
				var rowClassName = this.getRowViewModelClassName();
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName,
					rowViewModelClassName: rowClassName
				});
				esq.addColumn("Id");
				esq.addColumn("SearchDate");
				esq.addColumn("CategoryTag");
				esq.addColumn("Value");
				esq.addColumn("AccountEnrichmentService.Name");
				var primaryColumnValue = this.get("PrimaryColumnValue");
				var primaryColumnFilter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Account",
					primaryColumnValue);
				esq.filters.addItem(primaryColumnFilter);
				var notExistsFilter = this.BPMSoft.createNotExistsFilter("[AccountCommunication:Number:Value].Id");
				var subFilter = esq.createFilter(BPMSoft.ComparisonType.EQUAL,
					"[AccountCommunication:Account:Account].Account", "Account");
				notExistsFilter.subFilters.addItem(subFilter);
				esq.filters.addItem(notExistsFilter);
				return esq;
			},

			loadEnrichmentData: function() {
				this.set("IsDataLoaded", false);
				this.selectExistingEnrichedData(function(response) {
					var collection = response && response.collection;
					let detailColumnMapping = this.get("DetailColumnMapping");
					collection = collection.filterByFn(function(item) {
						let categoryTag = item.get("CategoryTag");
						if(item.get("AccountEnrichmentService.Name") === "EnrichmentService"){
							let communicationMap = BPMSoft.findWhere(detailColumnMapping, {TagName: categoryTag.toLowerCase()});
							return communicationMap;
						}
						return true;
					}, this);
					if (collection && !collection.isEmpty()) {
						this.onLoadEnrichmentData(response);
						return;
					}
					this.executeEnrichmentDataService(this.onLoadEnrichmentData, this);
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#executeEnrichmentDataService
			 * @overridden
			 */
			executeEnrichmentDataService: function(callback, scope){
				this.set("LastEnrichmentRequestFailReason", "");
				this.callService({
					serviceName: "EnrichmentService",
					methodName: "SearchAccountInfo",
					data: {
						accountId: this.get("PrimaryColumnValue")
					},
					timeout: this.get("ServiceRequestTimeOut")
				}, function(response) {
					this.executeDaDataSuggestionsDataService(response, callback, scope);
				}, scope);
			},
			
			executeDaDataSuggestionsDataService: function(enrichmentResponse, callback, scope) {
				this.callService({
					serviceName: "DaDataSuggestionsService",
					methodName: "SearchAccountInfo",
					data: {
						accountId: this.get("PrimaryColumnValue")
					},
					timeout: this.get("ServiceRequestTimeOut")
				}, function(daDataResponse) {
					this.onExecuteEnrichmentDataService(enrichmentResponse, daDataResponse, callback, scope);
				}, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#onExecuteEnrichmentDataService
			 * @overridden
			 */
			onExecuteEnrichmentDataService: function(enrichmentResponse, daDataResponse, callback, scope) {
				let daDataResult = daDataResponse.SearchAccountInfoResult;
				let enrichmentResult = enrichmentResponse.SearchAccountInfoResult;
				if (!daDataResult || BPMSoft.isEmptyObject(enrichmentResponse) && daDataResult.Success === false) {
					BPMSoft.showInformation(
						"Сервис обогащения данных: " + this.get("Resources.Strings.EnricmentServiceBadRequest") 
						+ "\n" 
						+ "\n" 
						+ "Сервис DaData: " + this.get("Resources.Strings.DaDataSuggestionsServiceBadRequest"));
					return;
				}
				if(daDataResult.IsSuccessSearch || (!BPMSoft.isEmptyObject(enrichmentResponse) && enrichmentResult.isSuccessSearch)){
					var callbackFunc = function() {
						if (Ext.isFunction(callback)) {
							callback.apply(scope || this, arguments);
						}
						if (!this.getIsNotEmptyCollection()) {
							let daDataError = "";
							if(!daDataResult.Success){
								daDataError = this.get("Resources.Strings.DaDataAccessError");
							} else if(!daDataResult.IsSuccessSearch){
								daDataError = this.get("Resources.Strings.DaDataNotFoundItems");
							}
							
							let failReason = this.get("Resources.Strings.NoNewData") + daDataError;
							this.set("LastEnrichmentRequestFailReason", failReason);
						}
					};
					this.selectExistingEnrichedData(callbackFunc, scope);
					return;
				} else {
					let enrichmentError = "";
					if(BPMSoft.isEmptyObject(enrichmentResponse) || ('success' in enrichmentResult && !enrichmentResponse.success)){
						enrichmentError = this.get("Resources.Strings.EnrichmentAccessError");
					} else {
						enrichmentError = enrichmentResult.isEnoughDataForEnrichment 
						? this.get("Resources.Strings.EnrichmentNotFoundItems")
						: this.get("Resources.Strings.NotEnoughDataForEnrichment");
					}
					let noDataByRequest = enrichmentError + (daDataResult.Success
						? this.get("Resources.Strings.DaDataNotFoundItems")
						: this.get("Resources.Strings.DaDataAccessError"));
					var failReason = Ext.String.format(noDataByRequest, this.get("AcademyHelpUrl"));
					this.set("LastEnrichmentRequestFailReason", failReason);
				}
				this.Ext.callback(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#loadCommunicationTypes
			 * @overridden
			 */
			loadCommunicationTypes: function(callback, scope) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "CommunicationType"
				});
				esq.addColumn("Name");
				var filter = this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"UseforAccounts", true);
				esq.filters.addItem(filter);
				esq.execute(function(response) {
					this.onLoadCommunicationTypes(response);
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Adds filter to delete query instance.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.DeleteQuery} deleteQuery Delete query instance.
			 */
			addDeleteQueryFilters: function(deleteQuery) {
				deleteQuery.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Account", this.get("PrimaryColumnValue")));
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData
			 * @protected
			 * @overridden
			 */
			getGoogleTagManagerData: function() {
				var data = this.callParent(arguments);
				var action = this.get("LastAction");
				if (!this.Ext.isEmpty(action)) {
					this.Ext.apply(data, {
						primaryColumnValue: this.get("PrimaryColumnValue"),
						moduleName: "DataEnrichment",
						schemaName: "AccountDataEnrichment",
						source: "AccountPageV2",
						action: action
					});
				}
				return data;
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#getItemCaption
			 * @protected
			 * @overridden
			 */
			getItemCaption: function(item) {
				var categoryTag = Ext.isString(item) ? item : item.get("CategoryTag");
				let suggestionsSettings = this.sandbox.publish("GetDaDataSuggestionsSettings");
				if(categoryTag === "Name"){
					return "Название";
				}
				let labelCaption = "";
				suggestionsSettings.forEach(function(setting){
					if(setting.EntityColumnName === categoryTag){
						labelCaption = setting.DaDataSuggestionsFieldName;
					}
				})
				if(labelCaption){
					return labelCaption;
				}
				var communicationTypesCollection = this.get("CommunicationTypesCollection");
				var communicationId = this.getCommunicationTypeId(categoryTag);
				var communicationType = communicationTypesCollection.get(communicationId);
				return communicationType.get("Name");
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#saveDataToDatabase
			 * @protected
			 * @overridden
			 */
			saveDataToDatabase: function() {
				var insertBatchQuery = this.getInsertBatchQuery();
				if (insertBatchQuery.queries.length) {
					insertBatchQuery.execute(this.onSaveDataToDatabase, this);
				}
			},

			onLoadEnrichmentData: function(response) {
				let responseCollection = response && response.collection;
				const collection = this.get("EnrichmentDataCollection");
				collection.clear();
				if (this.isNotEmpty(responseCollection)) {
					const communicationTypes = this.$CommunicationTypesCollection;
					let detailColumnMapping = this.get("DetailColumnMapping");
					responseCollection = responseCollection.filterByFn(function(item) {
						let categoryTag = item.get("CategoryTag");
						if(item.get("AccountEnrichmentService.Name") === "EnrichmentService"){
							let communicationMap = BPMSoft.findWhere(detailColumnMapping, {TagName: categoryTag.toLowerCase()});
							return communicationMap;
						}
						return true;
					}, this);

					responseCollection = responseCollection.filterByFn(function(item) {
						if(item.get("AccountEnrichmentService.Name") === "EnrichmentService"){
							let items = responseCollection.collection.items;
							
							const hasDublicate = items.find(dublicateItem => 
								(dublicateItem.get("CategoryTag").toLowerCase() === item.get("CategoryTag").toLowerCase()
									&& dublicateItem.get("Value") === item.get("Value") 
									&& dublicateItem.get("AccountEnrichmentService.Name") === "DaDataSuggestionsService")
							);
							return !hasDublicate
						} 
						return true
					}, this);

					responseCollection = responseCollection.filterByFn(function(item) {
						const communicationId = this.getCommunicationTypeId(item.$CategoryTag);
						if (communicationTypes.findByAttr("Id", communicationId)) {
							return true;
						} else {
							this.warning(this.Ext.String.format(
								"Communication type {0} is not enabled. Skipped enriched data {1}",
								communicationId, item.$Value));
							return false;
						}
					}, this);
					collection.loadAll(responseCollection);
				}
				this.set("EnrichmentDataCollection", null);
				this.set("EnrichmentDataCollection", collection);
				this.set("IsDataLoaded", true);
				this._adjustContainerHeight();
				this.updateEnrichemntDataCount();
			},

			syncDataWithDetail: function(detailId) {
				var syncedCollection = this.getSelectedItemsCollection();
				let accountData = {};
				let detailColumnMapping = this.get("DetailColumnMapping");
				syncedCollection = syncedCollection.filterByFn(function(item){
					let categoryTag = item.get("CategoryTag")
					isColumnCommunication = false;
					var communicationMap = BPMSoft.findWhere(detailColumnMapping, {TagName: categoryTag.toLowerCase()});
					if(!communicationMap){
						accountData[categoryTag] = item.get("Value");
					}
					return !!communicationMap;
				})
				this.sandbox.publish("SetAccountData", accountData)
				syncedCollection.each(function(item) {
					var communicationTypeId = this.getCommunicationTypeId(item.get("CategoryTag").toLowerCase());
					this.sandbox.publish("SyncCommunication", {
						communicationTypeId: communicationTypeId,
						syncColumnValue: item.get("Value"),
						syncOldColumnValue: item.getPrevious("Value"),
						isSynced: false
					}, [detailId]);
				}, this);
				this.clearEnrichedData(this.closeModule, this);
			},

			/**
			 * Returns batch query for insert enriched data.
			 * @protected
			 * @return {BPMSoft.BatchQuery} Batch query for insert enriched data.
			 */
			getInsertBatchQuery: function() {
				var syncedCollection = this.getSelectedItemsCollection();
				var insertBatchQuery = this.Ext.create("BPMSoft.BatchQuery");
				syncedCollection.each(function(item) {
					var insert = this.getInsertQuery(item);
					insertBatchQuery.add(insert);
				}, this);
				return insertBatchQuery;
			},

			/**
			 * Returns insert query for enriched item.
			 * @param {BPMSoft.BaseEnrichmentViewModel} item Base enrichment view model item.
			 * @return {BPMSoft.InsertQuery} Insert query for enriched item.
			 */
			getInsertQuery: function(item) {
				var communicationTypeId = this.getCommunicationTypeId(item.get("CategoryTag"));
				var insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "AccountCommunication"
				});
				insert.setParameterValue("Number", item.get("Value"), BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("Account", this.get("PrimaryColumnValue"), BPMSoft.DataValueType.GUID);
				insert.setParameterValue("CommunicationType", communicationTypeId, BPMSoft.DataValueType.GUID);
				return insert;
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#clearEnrichedData
			 * @protected
			 * @overridden
			 */
			clearEnrichedData: function() {
				var parentMethod = this.getParentMethod(this, arguments);
				var deleteQuery = this.getDeleteQuery();
				this.addDeleteQueryFilters(deleteQuery);
				deleteQuery.execute(function() {
					parentMethod();
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseEnrichmentSchema#getRowViewModelClassName
			 * @protected
			 * @overridden
			 */
			getRowViewModelClassName: function() {
				return "BPMSoft.configuration.AccountEnrichmentViewModel";
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});