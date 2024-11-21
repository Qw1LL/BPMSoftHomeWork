define("GlobalSearchResultPage", ["BusinessRulesApplierV2", "AcademyUtilities", "performancecountermanager",
	"GoogleTagManagerUtilities", "css!SectionModuleV2", "ContainerListGenerator", "css!GlobalSearchResultPageCSS",
		"GlobalSearchStorage", "ConfigurationServiceProvider"],
		function(BusinessRulesApplier, AcademyUtilities, performanceManager, GoogleTagManagerUtilities) {
	return {
		messages: {
			/**
			 * @message ChangeHeaderCaption
			 * Changes current page header.
			 */
			"ChangeHeaderCaption": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message InitDataViews
			 * Sends header parameters on request.
			 */
			"InitDataViews": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message NeedHeaderCaption
			 * Gets header parameters request.
			 */
			"NeedHeaderCaption": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message PushHistoryState
			 * Change history state.
			 */
			"PushHistoryState": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message HistoryStateChanged
			 * Subscribe of the state changed.
			 */
			"HistoryStateChanged": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message GlobalSearch
			 * Global search.
			 */
			"GlobalSearch": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * Is search success tag.
			 */
			"SuccessSearch": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Is data loaded tag.
			 */
			"IsDataLoaded": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Search result collection.
			 * @Type {BPMSoft.BaseViewModelCollection}
			 */
			"ResultCollection": {
				dataValueType: this.BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Academy url.
			 */
			"AcademyUrl": {
				dataValueType: this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Academy error url.
			 */
			"AcademyErrorUrl": {
				dataValueType: this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Academy help id.
			 */
			"HelpId": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 1014
			},
			/**
			 * Academy error help id.
			 */
			"ErrorHelpId": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 1698
			},
			/**
			 * Base search row schema name.
			 */
			"BaseSearchRowSchemaName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: "BaseSearchRowSchema"
			},
			/**
			 * File search row schema name.
			 */
			"FileSearchRowSchemaName": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: "FileSearchRowSchema"
			},
			/**
			 * Search result record count.
			 * @type {Number}
			 */
			"RecordCount": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 15
			},
			/**
			 * Last loaded record count.
			 * @type {Number}
			 */
			"LastLoadedRecordsCount": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * First item index for search.
			 * @type {Number}
			 */
			"From": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Search start date time in ms.
			 * @type {Number}
			 */
			"SearchStart": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Search end date time in ms.
			 * @type {Number}
			 */
			"SearchEnd": {
				dataValueType: this.BPMSoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Search request instance id.
			 * @type {String}
			 */
			"SearchRequestId": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: null
			},
			/**
			 * Results container selector.
			 * @type {String}
			 */
			"ResultsContainerSelector": {
				dataValueType: this.BPMSoft.DataValueType.TEXT,
				value: ".results-container"
			},
			/**
			 * Is loading next data tag.
			 * @type {Boolean}
			 */
			"IsLoadingNextData": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {
			/**
			 * Initialize schema.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initAttributeValues();
					this.initHeader();
					this.subscribeSandboxEvents();
					this.initHelpUrl(callback, scope);
					this.sandbox.subscribe("HistoryStateChanged", this._abortPreviousRequest, this);
				}, this]);
				this.getViewModuleContainer();
			},

			getViewModuleContainer: function() {
				let viewModuleContainer = this.Ext.get("ViewModuleContainer");
				viewModuleContainer.addCls("global-search-viewmodule");
			},

			/**
			 * Initializes and sets academy url.
			 * @private
			 * @param {Object} config Config.
			 * @param {String} config.helpIdAttribute Help id attribute name.
			 * @param {Object} config.academyUrlAttribute Academy url attribute name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope
			 */
			initAcademyUrl: function(config, callback, scope) {
				var helpIdAttribute = config.helpIdAttribute;
				var academyUrlAttribute = config.academyUrlAttribute;
				AcademyUtilities.getUrl({
					scope: this,
					contextHelpId: this.get(helpIdAttribute),
					callback: function(url) {
						this.set(academyUrlAttribute, url);
						Ext.callback(callback, scope || this);
					}
				});
			},

			/**
			 * Subscribes on events.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("GlobalSearch", this.search, this);
			},

			/**
			 * Initialize academy link url.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope
			 */
			initHelpUrl: function(callback, scope) {
				var chain = [];
				chain.push(function(next) {
					this.initAcademyUrl({
						helpIdAttribute: "HelpId",
						academyUrlAttribute: "AcademyUrl"
					}, next, scope);
				});
				chain.push(function() {
					this.initAcademyUrl({
						helpIdAttribute: "ErrorHelpId",
						academyUrlAttribute: "AcademyErrorUrl"
					}, callback, scope);
				});
				BPMSoft.chain.apply(this, chain);
			},

			/**
			 * Initializes viewModel attributes.
			 * @protected
			 */
			initAttributeValues: function() {
				this.set("ResultCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
			},

			/**
			 * Initializes Header.
			 * @private
			 */
			initHeader: function() {
				this.initPageCaption();
				this.sandbox.subscribe("NeedHeaderCaption", function() {
					this.sandbox.publish("InitDataViews", {caption: this.get("Resources.Strings.HeaderCaption")});
				}, this);
			},

			/**
			 * Initializes page caption.
			 * @protected
			 */
			initPageCaption: function() {
				this.sandbox.publish("ChangeHeaderCaption", {
					"caption": this.get("Resources.Strings.HeaderCaption"),
					"dataViews": Ext.create("BPMSoft.Collection")
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				this.initPageCaption();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#sendGoogleTagManagerData
			 * @overridden
			 */
			sendGoogleTagManagerData: BPMSoft.emptyFn,

			/**
			 * Run global search by query.
			 * @param {Object} [searchParams] Search parameters.
			 * @param {String} [searchParams.query] Search parameters Search query.
			 * @param {String} [searchParams.sectionEntityName] Section entity name.
			 * @return {boolean} Returns true if search success.
			 */
			search: function(searchParams) {
				this.set("IsDataLoaded", false);
				searchParams = searchParams || this.getSearchConfig();
				if (!searchParams) {
					this.set("IsDataLoaded", true);
					return false;
				}
				BPMSoft.GlobalSearchStorage.setSearchConfig(searchParams);
				this.showBodyMask({
					timeout: 0,
					selector: this.get("ResultsContainerSelector")
				});
				var queryString = searchParams.query;
				performanceManager.start("search_callService");
				this.set("SearchStart", Date.now());
				this.set("From", 0);
				this.callSearchService(searchParams, true);
				this.sandbox.publish("SetCommandLineValue", queryString);
				this.scrollToTop();
				return true;
			},

			/**
			 * Returns search config.
			 * @protected
			 * @return {Object} Search params of the history state.
			 */
			getSearchConfig: function() {
				var historyState = this.sandbox.publish("GetHistoryState");
				var state = historyState.state;
				var searchParams = state && state.SearchParams;
				return searchParams|| BPMSoft.GlobalSearchStorage.getSearchConfig();
			},

			/**
			 * Scrolls result page to top.
			 */
			scrollToTop: function() {
				this.BPMSoft.setTopScroll(0);
			},

			/**
			 * Calls global search service.
			 * @protected
			 * @param {Object} [searchParams] Search parameters.
			 * @param {String} [searchParams.query] Search parameters Search query.
			 * @param {String} [searchParams.sectionEntityName] Section entity name.
			 * @param {Boolean} clearCollection Is need clear result collection tag.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			callSearchService: function(searchParams, clearCollection, callBack, scope) {
				searchParams = searchParams || this.getSearchConfig();
				this._abortPreviousRequest();
				var searchRequestId = BPMSoft.generateGUID();
				this.set("SearchRequestId", searchRequestId);
				var sectionEntityName = searchParams.type || searchParams.sectionEntityName;
				BPMSoft.ConfigurationServiceProvider.callService({
					serviceName: "GlobalSearchService",
					methodName: "Search",
					data: {
						queryString: searchParams.query,
						sectionEntityName: sectionEntityName,
						recordCount: this.get("RecordCount"),
						from: this.get("From"),
						type: searchParams.type
					},
					instanceId: searchRequestId
				}, function(response) {
					this.onSearchComplete({
						response: response,
						searchParams: searchParams,
						clearCollection: clearCollection,
						callBack: callBack,
						scope: scope
					});
				}, this);
			},

			/**
			 * Aborted previous search request.
			 * @private
			 */
			_abortPreviousRequest: function() {
				var searchRequestId = this.get("SearchRequestId");
				if (searchRequestId) {
					BPMSoft.AjaxProvider.abortRequestByInstanceId(searchRequestId);
				}
			},

			/**
			 * Loads next search result.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			onLoadNextSearchResult: function(callback, scope) {
				if (this.get("LastLoadedRecordsCount") === this.get("RecordCount")) {
					this.set("IsLoadingNextData", true);
					this.callSearchService(null, false, callback, scope || this);
				}
			},

			/**
			 * Handler on search complete.
			 * @protected
			 * @param {Object} config Config.
			 * @param {Object} [config.response] Search response.
			 * @param {Object} [config.searchParams] Search parameters.
			 * @param {String} [config.searchParams.query] Search parameters Search query.
			 * @param {String} [config.searchParams.sectionEntityName] Section entity name.
			 * @param {Boolean} [config.clearCollection] Is need clear result collection tag.
			 * @param {Function} [config.callback] Callback function.
			 * @param {Object} [config.scope] Callback function scope.
			 */
			onSearchComplete: function(config) {
				this.set("SearchEnd", Date.now());
				var searchTime = this.get("SearchEnd") - this.get("SearchStart");
				performanceManager.stop("search_callService");
				this.sendGoogleTagManagerSearchData(searchTime, config.searchParams.currentPage);
				var searchResult = {};
				if (config && config.response && config.response.SearchResult) {
					searchResult = JSON.parse(config.response.SearchResult);
				}
				this.onDataLoaded(searchResult, config.callBack, config.scope, config.clearCollection);
			},

			/**
			 * Sends Google tag manager data.
			 * @param {Number} searchTime Search time.
			 * @param {String} pageName Page name.
			 */
			sendGoogleTagManagerSearchData: function(searchTime, pageName) {
				var isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
				if (!isGoogleTagManagerEnabled) {
					return;
				}
				var data = this.getGoogleTagManagerData();
				this.Ext.apply(data, {
					loadTime: searchTime,
					source: pageName
				});
				GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * @inheritdoc BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this._abortPreviousRequest();
				this.sandbox.publish("SetCommandLineValue", null);
				var viewModuleContainer = this.Ext.get("ViewModuleContainer");
				viewModuleContainer.removeCls("global-search-viewmodule");
				this.callParent(arguments);
			},

			/**
			 * Search callback. Process search service response.
			 * @protected
			 * @param {Object} result Search service response.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 * @param {Boolean} clearCollection Is need clear result collection tag.
			 */
			onDataLoaded: function(result, callback, scope, clearCollection) {
				performanceManager.start("onDataLoaded");
				var collection = this.get("ResultCollection");
				if (result.success) {
					this.set("SuccessSearch", true);
					this.set("From", result.nextFrom);
					var chain = [];
					var processedItemsCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(result.data, function(item) {
						item.columnValues = this._processColumnValues(item.columnValues);
						chain.push(function(next) {
							this.initRowSchema(item, processedItemsCollection, next, this);
						});
					}, this);
					chain.push(function() {
						if (clearCollection) {
							collection.clear();
						}
						collection.loadAll(processedItemsCollection);
						this.set("IsDataLoaded", true);
						this.set("LastLoadedRecordsCount", processedItemsCollection.getCount());
						this.hideMasks();
						performanceManager.stop("onDataLoaded");
						Ext.callback(callback, scope || this);
					}, this);
					BPMSoft.chain.apply(this, chain);
				} else {
					this.set("SuccessSearch", false);
					this.set("IsDataLoaded", true);
					collection.clear();
					this.hideMasks();
					Ext.callback(callback, scope || this);
				}
			},

			/**
			 * Processes search result column values
			 * @param {Object} columnValues
			 * @private
			 */
			_processColumnValues: function(columnValues) {
				var result = {};
				BPMSoft.each(columnValues, function(value, key) {
					result[key] = BPMSoft.removeHtmlTags(value);
				}.bind(this));
				return result;
			},

			/**
			 * Hides masks.
			 * @private
			 */
			hideMasks: function() {
				this.hideBodyMask({selector: this.get("ResultsContainerSelector")});
				this.set("IsLoadingNextData", false);
			},

			/**
			 * Sets view model found columns from search result data.
			 * @protected
			 * @param {Object} data Search service row data.
			 * @param {BPMSoft.BaseViewModel} viewModel Row view model.
			 */
			setViewModelFoundColumns: function(data, viewModel) {
				var foundColumnsCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				var foundColumns = this.Ext.create("BPMSoft.BaseSchemaViewModel", {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft,
					values: {
						"FoundColumns": data.foundColumns
					}
				});
				foundColumnsCollection.addItem(foundColumns);
				viewModel.set("FoundColumnsCollection", foundColumnsCollection);
			},

			/**
			 * Sets view model values from search result data.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} viewModel Row view model.
			 * @param {Object} data Search service row data.
			 * @param {Object} view Row view config.
			 */
			setViewModelValues: function(viewModel, data, view) {
				viewModel.set(viewModel.primaryColumnName, data.id);
				BPMSoft.each(data.columnValues, function(value, key) {
					viewModel.set(key, value);
				}, this);
				this.setViewModelFoundColumns(data, viewModel);
				viewModel.set("ViewConfig", view);
			},

			/**
			 * Returns unique collection item identifier.
			 * @private
			 * @param {BPMSoft.BaseViewModel} viewModel Row view model.
			 * @param {BPMSoft.BaseViewModelCollection} collection Search result collection.
			 * @return {String} Unique collection item identifier.
			 */
			_getViewModelItemCollectionId: function(viewModel, collection) {
				var itemId = viewModel.get("Id");
				if (collection.contains(itemId)) {
					itemId = this.BPMSoft.generateGUID();
				}
				return itemId;
			},

			/**
			 * Initializes row schema and prepare result collection.
			 * @protected
			 * @param {Object} data Search service row data.
			 * @param {BPMSoft.BaseViewModelCollection} collection Search result collection.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope
			 */
			initRowSchema: function(data, collection, callback, scope) {
				var schemaBuilder = this.Ext.create("BPMSoft.SchemaBuilder", {
					"viewGeneratorClassName": "BPMSoft.GlobalSearchViewGenerator"
				});
				var generatorConfig = this.getBuilderConfig(data.entityName);
				performanceManager.start("initRowSchema - " + data.entityName);
				schemaBuilder.build(generatorConfig, function(viewModelClass, viewConfig) {
					var view = this.getRowViewConfig(viewConfig);
					var viewModel = this.getRowViewModel(viewModelClass);
					this.setViewModelValues(viewModel, data, view);
					BusinessRulesApplier.applyDependencies(viewModel);
					viewModel.init();
					collection.add(this._getViewModelItemCollectionId(viewModel, collection), viewModel);
					performanceManager.stop("initRowSchema - " + data.entityName);
					Ext.callback(callback, scope, []);
				}, this);
			},

			/**
			 * Returns row view config.
			 * @protected
			 * @param {Object} viewConfig Row schema view config.
			 * @return {Object} Row view config.
			 */
			getRowViewConfig: function(viewConfig) {
				return {
					"classes": {wrapClassName: ["result-container"]},
					"items": [
						{
							"className": "BPMSoft.Container",
							"items": viewConfig
						}
					]
				};
			},

			/**
			 * Returns row view model.
			 * @protected
			 * @param viewModelClass
			 * @return {BPMSoft.BaseViewModel} Row view model.
			 */
			getRowViewModel: function(viewModelClass) {
				return this.Ext.create(viewModelClass, {
					Ext: this.Ext,
					sandbox: this.sandbox,
					BPMSoft: this.BPMSoft
				});
			},

			/**
			 * Returns builder config.
			 * @protected
			 * @param {String} entityName Entity name.
			 * @return {Object} Builder config.
			 */
			getBuilderConfig: function(entityName) {
				return {
					schemaName: this.getRowEntitySchemaName(entityName),
					entitySchemaName: entityName
				};
			},

			/**
			 * Returns row entity schema name.
			 * @protected
			 * @param {String} entityName Entity name.
			 * @return {String} Row entity schema name.
			 */
			getRowEntitySchemaName: function(entityName) {
				var entityStructure = this.getEntityStructure(entityName);
				if (entityStructure && entityStructure.searchRowSchema) {
					return entityStructure.searchRowSchema;
				}
				var fileSuffix = "File";
				if (entityName.indexOf(fileSuffix, entityName.length - fileSuffix.length) > -1
						|| entityName === "FileLead") {
					return this.get("FileSearchRowSchemaName");
				}
				return this.get("BaseSearchRowSchemaName");
			},

			/**
			 * Generates configuration of the element view.
			 * @protected
			 * @param {Object} itemConfig Link to the configuration element of ContainerList.
			 * @param {BPMSoft.BaseViewModel} item ViewModel item.
			 */
			onGetItemConfig: function(itemConfig, item) {
				itemConfig.config = item.get("ViewConfig");
			},

			/**
			 * Returns image container view config.
			 * @private
			 * @return {Object} Image container view config.
			 */
			getImageConfig: function() {
				var imageKey = this.get("SuccessSearch") === false ?
						"Resources.Images.ErrorEmptyResultImage" : "Resources.Images.EmptyResultImage";
				var imgSrc = this.BPMSoft.ImageUrlBuilder.getUrl(this.get(imageKey));
				return {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["image-container"]
					},
					"items": [
						{
							"className": "BPMSoft.ImageEdit",
							"readonly": true,
							"classes": {
								"wrapClass": ["image-control"]
							},
							"imageSrc": imgSrc
						}
					]
				};
			},

			/**
			 * Returns title container view config.
			 * @private
			 * @return {Object} Title container view config.
			 */
			getTitleConfig: function() {
				var captionKey = this.get("SuccessSearch") === false ?
						"Resources.Strings.ErrorEmptyResultCaption" : "Resources.Strings.EmptyResultCaption";
				var caption = this.get(captionKey);
				return {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["title"]
					},
					"items": [
						{
							"className": "BPMSoft.Label",
							"caption": caption
						}
					]
				};
			},

			/**
			 * Returns recommendation container view config.
			 * @private
			 * @return {Object} Recommendation container view config.
			 */
			getRecommendationConfig: function() {
				var isSuccessSearch = this.get("SuccessSearch");
				var recommendationTemplateKey = isSuccessSearch === false ?
						"Resources.Strings.ErrorRecommendationTemplate" : "Resources.Strings.RecommendationTemplate";
				var recommendationTemplate = this.get(recommendationTemplateKey);
				var recomendationHtml = Ext.String.format(recommendationTemplate,
						isSuccessSearch === false ? this.get("AcademyErrorUrl") : this.get("AcademyUrl"));
				return {
					"className": "BPMSoft.Container",
					"classes": {
						"wrapClassName": ["description"]
					},
					"items": [
						{
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["reference"]
							},
							"items": [
								{
									selectors: {
										wrapEl: ".reference"
									},
									"className": "BPMSoft.HtmlControl",
									"html": recomendationHtml
								}
							]
						}
					]
				};
			},

			/**
			 * Creates a configuration element that will be shown if there are no elements in the list.
			 * @protected
			 * @param {Object} config Preconfigured options.
			 * @return {Object} Empty message view config.
			 */
			getEmptyMessageConfig: function(config) {
				config.className = "BPMSoft.Container";
				config.classes = {
					"wrapClassName": ["empty-grid-message", "search-empty-result"]
				};
				config.items = [
					this.getImageConfig(),
					this.getTitleConfig(),
					// this.getRecommendationConfig();
				];
			},

			/**
			 * Returns results container dom attributes.
			 * @private
			 * @return {Object} Results container dom attributes.
			 */
			getResultsContainerAttributes: function() {
				return {dataloaded: this.get("IsDataLoaded") === true};
			},

			/**
			 * Returns container visibility filter module flag.
			 * @private
			 * @return {Boolean} True if filter module is visible.
			 */
			getIsVisibleFilterModule: function() {
				var searchParams = this.getSearchConfig();
				var isSuccessSearch = this.get("SuccessSearch");
				var isDataLoaded = this.get("IsDataLoaded");
				var collection = this.get("ResultCollection");
				var isHasType = searchParams && searchParams.type;
				return Boolean(isHasType) || !(isDataLoaded && !isSuccessSearch || collection.isEmpty());
			}
		},
		modules: /**SCHEMA_MODULES*/{
			"GlobalSearchFilterModule": {
				"config": {
					"isSchemaConfigInitialized": true,
					"schemaName": "GlobalSearchFilter",
					"useHistoryState": false
				},
				"keepAlive": true
			}
		}/**SCHEMA_MODULES*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "GlobalSearchWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["global-search-wrapper"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LeftContainer",
				"parentName": "GlobalSearchWrapper",
				"propertyName": "items",
				"values": {
					"id": "LeftContainer",
					"selectors": {"wrapEl": "#LeftContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["left-container"],
					"items": [],
					"markerValue": "LeftContainer"
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "GlobalSearchFilterModule",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {wrapClassName: ["global-search-filter-module"]},
					"visible": {"bindTo": "getIsVisibleFilterModule"}
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"parentName": "GlobalSearchWrapper",
				"propertyName": "items",
				"values": {
					"id": "MainContainer",
					"selectors": {"wrapEl": "#MainContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["main-container"],
					"items": [],
					"markerValue": "MainContainer"
				}
			},
			{
				"operation": "insert",
				"name": "ResultsContainer",
				"parentName": "MainContainer",
				"propertyName": "items",
				"values": {
					"id": "ResultsContainer",
					"selectors": {"wrapEl": "#ResultsContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["results-container"],
					"items": [],
					"markerValue": "ResultsContainer",
					"domAttributes": {"bindTo": "getResultsContainerAttributes"}
				}
			},
			{
				"operation": "insert",
				"name": "ResultContainerList",
				"propertyName": "items",
				"parentName": "ResultsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "ContainerListGenerator.generateGrid",
					"isAsync": false,
					"collection": {"bindTo": "ResultCollection"},
					"classes": {"wrapClassName": ["result-container-list"]},
					"onGetItemConfig": {"bindTo": "onGetItemConfig"},
					"idProperty": "Id",
					"observableRowNumber": 1,
					"observableRowVisible": {"bindTo": "onLoadNextSearchResult"},
					"rowCssSelector": ".selectable",
					"getEmptyMessageConfig": {bindTo: "getEmptyMessageConfig"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LoadingSpinner",
				"parentName": "ResultsContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.ProgressSpinner",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"visible": {"bindTo": "IsLoadingNextData"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
