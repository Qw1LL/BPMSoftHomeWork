define("DuplicatesPageV2", [
			"RightUtilities", "AcademyUtilities", "SchemaBuilderV2", "ViewGeneratorV2", "ServiceHelper", "DefaultProfileHelper",
			"BaseGridDetailV2Resources", "BaseDataViewResources", "DuplicatesPageV2Resources", 
			"DuplicatesMergeHelper", "GridUtilitiesV2", "MultilineLabel", "DuplicatesDetailModuleV2", 
			"ImageCustomGeneratorV2", "css!MultilineLabel", "css!DeduplicationModuleCSS",
			"css!SectionModuleV2", "DeduplicationStorage"
		],
		function(
				RightUtilities, 
				AcademyUtilities, 
				SchemaBuilder, 
				ViewGenerator, 
				ServiceHelper, 
				DefaultProfileHelper, 
				baseDetailResources, 
				baseDataViewResources) {
			return {
				entitySchemaName: "DuplicatesRule",
				mixins: {
					GridUtilities: "BPMSoft.GridUtilities",
					DuplicatesMergeHelper: "BPMSoft.DuplicatesMergeHelper"
				},
				attributes: {
					/**
					 * True if 'DuplicatesRulesSetup' button visible.
					 */
					"CanManageDuplicatesRules": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: false
					},
					"CanSearchDuplicates": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: false
					},
					/**
					 * Collection of the duplicate items groups.
					 */
					"DuplicatesContainerItems": {
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"dataValueType": BPMSoft.DataValueType.COLLECTION,
						"isCollection": true,
						"value": Ext.create("BPMSoft.BaseViewModelCollection")
					},
					/**
					 * Collection of the duplicate hidden items groups.
					 */
					"DuplicatesContainerHiddenItems": {
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"dataValueType": BPMSoft.DataValueType.COLLECTION,
						"value": Ext.create("BPMSoft.Collection")
					},
					/**
					 * Text of the header lable.
					 */
					"HeaderLabelCaption": {
						"value": "",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Text of the information container title.
					 */
					"InfoLabelTitleCaption": {
						"value": "",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Text of the information container description.
					 */
					"InfoLabelDescriptionCaption": {
						"value": "",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Name of the duplicates schema.
					 */
					"DuplicatesSchemaName": {
						"value": "",
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Grid profile.
					 */
					"GridProfile": {
						"value": null,
						"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Sign of an empty duplicates collection.
					 */
					"IsDuplicatesContainerItemsEmpty": {
						"value": false,
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"dependencies": [
							{
								"columns": ["IsSearchInProcess"],
								"methodName": "onIsSearchInProcessChanged"
							}
						]
					},
					/**
					 * Offset of the next duplicates group to be loaded.
					 */
					"NextDuplicatesGroupOffset": {
						"value": 0,
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Last date of the duplicates search.
					 */
					"LastDuplicatesSearchRun": {
						"dataValueType": BPMSoft.DataValueType.DATE_TIME,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Indicates that the search of duplicates is in process.
					 */
					"IsSearchInProcess": {
						"value": false,
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Load duplicates row count per page.
					 * @protected
					 */
					"DuplicatesPageRowCount": {
						"value": 50,
						"dataValueType": BPMSoft.DataValueType.INTEGER
					},

					/**
					 * Is show bulk duplicates summary feature enabled.
					 */
					"IsShowBulkDuplicatesSummary": {
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"value": BPMSoft.Features.getIsEnabled("ShowBulkDuplicatesSummary")
					},
				},
				messages: {
					"GetConfig": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"GetGridData": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"HideDetail": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GetGridSettingsInfo
					 * Returns informations of grid settings.
					 * @return {Object} informations of grid settings.
					 */
					"GetGridSettingsInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GridSettingsChanged
					 * Informs about changing grid settings.
					 */
					"GridSettingsChanged": {
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
						mode: BPMSoft.MessageMode.PTP
					},
					/**
					 * @message NotDuplicatesOperationExecuted
					 * Message on not duplicates operation executed.
					 */
					"NotDuplicatesOperationExecuted": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},					
					/**
					 * @message GetSectionEntitySchema
					 * Gets section entity schema for quick filters module.
					 */
					"GetSectionEntitySchema": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message RerenderQuickFilterModule
					 * Publishes message for redraw the filter.
					 */
					"RerenderQuickFilterModule": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message GetExtendedFilterConfig
					 * Get extended filters settings for quick filters module.
					 */
					"GetExtendedFilterConfig": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					
					/**
					 * @message GetExtendedFilterConfig
					 * Extended filters settings message.
					 */
					"UpdateFilter": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},					
					
					/**
					 * @message UpdateExtendedFilterValues
					 */
					"UpdateExtendedFilterValues": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},

					/**
					 * @message GetSectionFiltersInfo
					 * Gets section filters for quick filters module.
					 */
					"GetSectionFiltersInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message GetModuleSchema
					 * Returns information about entity which works with filter.
					 */
					"GetModuleSchema": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message MergeEntityDuplicatesExecuted
					 * Message on merge duplicates operation executed.
					 */
					"MergeEntityDuplicatesExecuted": {
						mode: BPMSoft.MessageMode.BROADCAST,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				methods: {
					/**
					 * Sets the can manage duplicates rules attribute flag
					 * @param {Boolean} canManageDuplicatesRulesOperation.
					 */
					_setCanManageDuplicatesRulesAttributes: function(canManageDuplicatesRulesOperation) {
						this.set("CanManageDuplicatesRules", canManageDuplicatesRulesOperation);
					},

					/**
					 * Sets the can manage duplicates rules attribute flag
					 * @param {Boolean} canManageDuplicatesRulesOperation.
					 */
					 _setCanSearchDuplicatesAttributes: function(canSearchDuplicatesOperation) {
						this.set("CanSearchDuplicates", canSearchDuplicatesOperation);
					},

					/**
					 * Check is the current user able to manage duplicates rules
					 */
   					_checkCanManageDuplicatesRules: function () {
						RightUtilities.checkCanExecuteOperation({ operation: "CanManageDuplicatesRules" },
						this._setCanManageDuplicatesRulesAttributes, this);
					},

					/**
					 * Check is the current user able to search duplicates
					 */
					 _checkCanSearchDuplicates: function () {
						RightUtilities.checkCanExecuteOperation({ operation: "CanSearchDuplicates" },
						this._setCanSearchDuplicatesAttributes, this);
					},

					/**
					 * Show error message if response isn't successful or set IsSearchInProcess to true if successfull
					 * @param {String} methodName _handleFindEntityDuplicatesAsyncResponse.
					 * @param {response} response Additional parameters.
					 */
					_handleFindEntityDuplicatesResponse: function(response, errorMessage) {
							if (!response) {
								return;
							}

							const isSuccessResponse = this.$IsSearchInProcess = !Ext.isEmpty(response) && response.success;
							
							if (isSuccessResponse) {
								this.hideItems();
							} else {
								this._showErrorDeduplicationMessage(errorMessage);
							}
					},
					
					/**
					 * @private
					 */
					_showSetUpRulesConfirmationDialog: function () {
						const setUpRulesButtonCaption = this.get("Resources.Strings.DuplicatesRulesSetupCaption");
						const setUpRulesButton = {
							className: "BPMSoft.Button",
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: setUpRulesButtonCaption,
							markerValue: setUpRulesButtonCaption,
							returnCode: "setupRules"
						};
						this.showConfirmationDialog(this.get("Resources.Strings.SetUpBulkDeduplicationRules"),
								function (returnCode) {
									if (returnCode === setUpRulesButton.returnCode) {
										this.duplicatesRulesSetup();
									}
								}, [setUpRulesButton, BPMSoft.MessageBoxButtons.CLOSE]);
					},
					
					/**
					 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
					 * @overridden
					 */
					getPageHeaderCaption: function() {
						return this.getHeader();
					},
					/**
					 * Initialize the name of the schema of duplicates.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					initDuplicatesSchemaName: function(callback, scope) {
						var historyState = this.getHistoryStateInfo();
						var schemaName = historyState.operation;
						this.set("DuplicatesSchemaName", schemaName);
						if (callback) {
							callback.call(scope || this);
						}
					},

					/**
					 * Returns the name of the schema of duplicates.
					 * @returns {String} Name of the schema.
					 */
					getDuplicatesSchemaName: function() {
						if (!this.get("DuplicatesSchemaName")) {
							this.initDuplicatesSchemaName();
						}
						return this.get("DuplicatesSchemaName");
					},

					/**
					 * IsSearchInProcess changed handler.
					 */
					onIsSearchInProcessChanged: function() {
						if (this.get("IsSearchInProcess") === true) {
							this.set("IsDuplicatesContainerItemsEmpty", true);
						}
					},

					/**
					 * Loads elastic search deduplication results.
					 * @protected
					 */
					getBulkESDeduplicationResults: function() {
						if (this.get("NextDuplicatesGroupOffset") < 0) {
							return;
						}
						this.showBodyMask();
						var config = {
							"entityName": this.getDuplicatesSchemaName(),
							"columns": this.getDuplicatesColumns(),
							"offset": this.$NextDuplicatesGroupOffset,
							"count": this.$DuplicatesPageRowCount
						};
						BPMSoft.DeduplicationStorage.getDeduplicationResults(config, function(result) {
							if (result.allDownloaded) {
								result.nextOffset = -1;
							}
							this.processDeduplicationResults(result);
						}, this);
					},

					/**
					 * Loads elastic search deduplication results.
					 * @protected
					 */
					getBulkESDeduplicationCountData: function() {
						if (!this.getIsShowDuplicatesSummary()) {
							return;
						}
						var config = {
							"entityName": this.getDuplicatesSchemaName(),
						};
						this.BPMSoft.DeduplicationStorage.fetchDuplicatesCount(config, function(result) {
							this.set("DeduplicationGroupsCount", result?.groupsCount ?? 0);
							this.set("DuplicatesCount", result?.duplicatesCount ?? 0);
						}, this);
					},

					/**
					 * Get deduplication results callback.
					 * @protected
					 */
					processDeduplicationResults: function(result) {
						this.hideBodyMask();
						this.set("NextDuplicatesGroupOffset", result.nextOffset);
						const groups = result.groups || [];
						if (Ext.isEmpty(groups) === false) {
							this.prepareRowConfig(result.rowConfig);
							this.loadDuplicatesDetails(groups, result.rowConfig);
						}
						const duplicatesContainerItems = this.get("DuplicatesContainerItems");
						const isEmpty = duplicatesContainerItems.getCount() === 0;
						this.set("IsDuplicatesContainerItemsEmpty", isEmpty);
						const filters = this.getCustomFiltersGroup();
						if (filters && filters.getCount() !== 0 && isEmpty) {
							this.processEmptyResultsWithFilters();
						} else {
							this.initInfoLabelCaption();
						}
					},

					/**
					 * Processes query results if custom filters are specified.
					 */
					processEmptyResultsWithFilters: function() {
						const isEmpty = this.get("IsDuplicatesContainerItemsEmpty");
						this.set("InfoLabelTitleCaption", this.get("Resources.Strings.EmptyCollectionWithFiltersTitle"));
						this.set("InfoLabelDescriptionCaption", this.get("Resources.Strings.EmptyCollectionWithFiltersDescription"));
						const blankSlateContainer = this.Ext.get("InfoContentContainer");
						blankSlateContainer.addCls("empty-result-with-filters");
					},

					/**
					 * Loads a collection of groups of duplicates.
					 */
					getDeduplicationResults: function() {
						if (this._isBulkESDeduplicationEnabled()) {
							this.getBulkESDeduplicationResults();
							this.getBulkESDeduplicationCountData();
							return;
						}
						if (this.get("IsSearchInProcess")) {
							return;
						}
						var allGroupsLoaded = this.get("NextDuplicatesGroupOffset") < 0;
						if (allGroupsLoaded) {
							return;
						}
						var entitySchemaName = this.getDuplicatesSchemaName();
						var columns = this.getDuplicatesColumns();
						var config = {
							"schemaName": entitySchemaName,
							"columns": columns,
							"offset": this.get("NextDuplicatesGroupOffset")
						};
						this.callDeduplicationServiceMethod("GetDeduplicationResults",
								this.getDeduplicationResultsCallback, config);
					},

					/**
					 * Handle response from the GetDeduplicationResults method of DeduplicationService service.
					 * @param {Object} response Service response.
					 */
					getDeduplicationResultsCallback: function(response) {
						response = response || {};
						var responseResult = response.GetDeduplicationResultsResult;
						var parsedResult = JSON.parse(responseResult);
						this.processDeduplicationResults(parsedResult);
					},
					
					/**
					 * Run procedure of searching duplicates entities if the search is not currently in process.
					 */
					findEntityDuplicates: function() {
						this.initDuplicatesSearchInfo(function() {
							if (this.$IsSearchInProcess) {
								this._showErrorDeduplicationMessage(
									this.get("Resources.Strings.SearchIsInProcessErrorMessage"));
							} else if (this.$IsDuplicatesContainerItemsEmpty) {
								this.findEntityDuplicatesAsync();
							} else {
								var config = {
									style: BPMSoft.MessageBoxStyles.ORANGE
								};
								this.showConfirmationDialog(this.get("Resources.Strings.ConfirmationRunDeduplicationMessage"),
										function(returnCode) {
											if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
												this.findEntityDuplicatesAsync();
											}
										}, ["yes", "no"], config);
							}
						}, this);
						return false;
					},

					/**
					 * Find elastic search duplicates.
					 * @protected
					 */
					findBulkESDeduplicationEntities: function() {
						if (!this.isActiveBulkDeduplicationRules()) {
							this._showSetUpRulesConfirmationDialog();
							return;
						}
						var config = {
							"entityName": this.getDuplicatesSchemaName()
						};
						this.callDeduplicationServiceMethod("FindDuplicateEntities", function(response) {
							this._handleFindEntityDuplicatesResponse(response, 
								this.get("Resources.Strings.CommonErrorMessage"));
						}, config);
					},

					/**
					 * @private
					 */
					_showErrorDeduplicationMessage: function(messageText) {
						var messageConfig = {
							caption: messageText,
							buttons: ["ok"],
							defaultButton: 0,
							style: BPMSoft.MessageBoxStyles.ORANGE
						};
						BPMSoft.utils.showMessage(messageConfig);
					},

					/**
					 * Call FindEntityDuplicatesAsync method of deduplication service.
					 */
					findEntityDuplicatesAsync: function() {
						if (this._isBulkESDeduplicationEnabled()) {
							this.findBulkESDeduplicationEntities();
							return;
						}
						var entitySchemaName = this.getDuplicatesSchemaName();
						var config = {
							"schemaName": entitySchemaName
						};
						this.callDeduplicationServiceMethod("FindEntityDuplicatesAsync", function(response) {
							if (response) {
								const responseForHandling = response.FindEntityDuplicatesAsyncResult;
								const errorMessage = responseForHandling && responseForHandling.message;

								this._handleFindEntityDuplicatesResponse(responseForHandling, errorMessage);
							}

						}, config);
					},

					/**
					 * Call method of deduplication service.
					 * @param {String} methodName Name of method.
					 * @param {Function} callback Callback function.
					 * @param {Object} config Additional parameters.
					 */
					callDeduplicationServiceMethod: function(methodName, callback, config) {
						var serviceName = this._isBulkESDeduplicationEnabled()
							? "BulkDeduplicationService"
							: "DeduplicationService";
						ServiceHelper.callService(serviceName, methodName, callback, config, this);
					},

					/**
					 * Returns duplicates detail module render to element identifier.
					 * @protected
					 * @param {String} id Unique module identifier.
					 * @returns {String} Render to element identifier.
					 */
					getDuplicatesDetailModuleRootContainerId: function (id) {
						return Ext.String.format("DuplicatesPageV2DuplicateContainerContainer-{0}-listItem", id);
					},
					
					/**
					 * Returns duplicates detail module identifier.
					 * @protected
					 * @param {String} id Unique module identifier.
					 * @returns {String} Module identifier.
					 */
					getDuplicatesDetailModuleId: function (id) {
						return Ext.String.format("DuplicatesDetailModule{0}", id);
					},
					
					/**
					 * Loads group of duplicates to the BPMSoft.DuplicatesDetailModule.
					 * @param {String} id Unique module identifier.
					 * @param {BPMSoft.BaseViewModel} rootItem Root item of duplicates group.
					 * @param {BPMSoft.BaseViewModelCollection} rows List of duplicates.
					 * @param {Object} group Duplicate group data.
					 */
					loadDuplicatesDetailModule: function(id, rootItem, rows, group) {
						var detailId = this.getDuplicatesDetailModuleId(id);
						var containerId = this.getDuplicatesDetailModuleRootContainerId(id);
						var sandbox = this.sandbox;
						sandbox.loadModule("DuplicatesDetailModuleV2", {
							renderTo: containerId,
							id: detailId
						});
						sandbox.subscribe("GetConfig", function() {
							return this.getDuplicatesGroupDetailConfig(id, rootItem, group);
						}, this, [detailId]);
						sandbox.subscribe("GetGridData", function() {
							return rows;
						}, this, [detailId]);
						sandbox.subscribe("HideDetail", function() {
							this.hideItem(id);
						}, this, [detailId]);
					},
					
					/**
					 * Returns duplicates detail group configuration.
					 * @protected
					 * @param {String} groupId Duplicate group id.
					 * @param {BPMSoft.BaseViewModel} rootItem Root item of duplicates group.
					 * @param {Object} group Duplicate group data.
					 * @returns {Object} Duplicates detail group configuration.
					 */
					getDuplicatesGroupDetailConfig: function(groupId, rootItem, group) {
						var profile = this.get("GridProfile");
						var primaryDisplayColumnName = rootItem.entitySchema.primaryDisplayColumnName;
						var rootItemPrimaryDisplayValue = rootItem.get(primaryDisplayColumnName);
						return {
							caption: rootItemPrimaryDisplayValue,
							groupId: group && group.groupId || groupId,
							gridConfig: profile.listedConfig,
							entitySchemaName: this.getDuplicatesSchemaName()
						};
					},

					/**
					 * Moves identifier of item to hidden items collection, enable IsDuplicatesContainerItemsEmpty flag
					 * when all items are hidden.
					 * @param {String} key Identifier of item.
					 */
					hideItem: function(key) {
						var items = this.get("DuplicatesContainerItems");
						var hiddenItems = this.get("DuplicatesContainerHiddenItems");
						hiddenItems.add(key);
						var difference = Ext.Array.difference(items.getKeys(), hiddenItems.getItems());
						var differenceLength = difference.length;
						var amountToStartLoading = 6;
						if (differenceLength === amountToStartLoading) {
							this.getDeduplicationResults();
						} else {
							if (differenceLength === 0) {
								this.set("IsDuplicatesContainerItemsEmpty", true);
							}
						}
					},

					/**
					 * Clears data collection.
					 */
					clearItems: function() {
						const items = this.get("DuplicatesContainerItems");
						items.clear();
					},

					/**
					 * Clear collection of content items.
					 */
					hideItems: function() {
						this.clearItems();
						this.set("IsDuplicatesContainerItemsEmpty", true);
						this.initInfoLabelCaption();
						this.set("DeduplicationGroupsCount", 0);
						this.set("DuplicatesCount", 0);
					},

					/**
					 * Loads groups of duplicates on page.
					 * @param {Array} groups List of duplicate groups.
					 * @param {Object} rowConfig Columns configuration.
					 */
					loadDuplicatesDetails: function(groups, rowConfig) {
						var items = Ext.create("BPMSoft.Collection");
						BPMSoft.each(groups, function(group) {
							var groupId = group.groupId.toString();
							var entityCollection = this.groupOfDuplicatesToViewModelCollection(group.rows, rowConfig);
							if (!entityCollection.isEmpty()) {
								var item = this.createGroupOfDublicates(groupId, entityCollection, group);
								items.add(groupId, item);
							}
						}, this);
						var duplicatesContainerItems = this.get("DuplicatesContainerItems");
						duplicatesContainerItems.loadAll(items);
					},

					/**
					 * Creates group of duplicates.
					 * @param {String} groupId Group identifier.
					 * @param {BPMSoft.BaseViewModelCollection} entityCollection List of duplicates.
					 * @param {Object} group Duplicate group data.
					 * @returns {BPMSoft.BaseViewModel} Root item attached to the duplicates group.
					 */
					createGroupOfDublicates: function(groupId, entityCollection, group) {
						this.prepareResponseCollection(entityCollection);
						var rootItem = this.getRootDuplicateViewModel(group, entityCollection);
						rootItem.set("DuplicatesGroupId", groupId);
						rootItem.addEvents("itemContainerRendered");
						rootItem.onItemContainerRendered = function() {
							this.fireEvent("itemContainerRendered", this);
						}.bind(rootItem);
						rootItem.on("itemContainerRendered", function() {
							this.loadDuplicatesDetailModule(groupId, rootItem, entityCollection, group);
						}, this);
						return rootItem;
					},
					
					/**
					 * Returns root duplicate view model in group.
					 * @protected
					 * @param {Object} group Duplicate group data.
					 * @param {BPMSoft.BaseViewModelCollection} entityCollection List of duplicates.
					 * @returns {BPMSoft.BaseViewModel} Root duplicate view model in group.
					 */
					getRootDuplicateViewModel: function(group, entityCollection) {
						return entityCollection.findByFn(function(entity) {
							return entity.values.IsSourceEntity;
						}, this) || entityCollection.getByIndex(0);
					},
					
					/**
					 * Converts array of rows to BPMSoft.BaseViewModelCollection.
					 * @param {Array} rows.
					 * @param {Object} rowConfig.
					 * @returns {BPMSoft.BaseViewModelCollection}.
					 */
					groupOfDuplicatesToViewModelCollection: function(rows, rowConfig) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: this.getDuplicatesSchemaName(),
							rootSchema: this.entitySchema,
							rowViewModelClassName: "BPMSoft.BaseGridRowViewModel"
						});
						var responseData = {
							success: true,
							rowsAffected: rows.length,
							rows: this.formatDateTimeColumnValues(rows, rowConfig),
							rowConfig: rowConfig
						};
						var entityCollection = null;
						esq.parseResponse(responseData, function(result) {
							entityCollection = result.collection;
						}, this);
						return entityCollection;
					},

					/**
					 * Converts DateTime columns to ISO 8601 format.
					 * @param {Array} rows.
					 * @param {Object} rowConfig.
					 * @returns {Array}.
					 */
					formatDateTimeColumnValues: function (rows, rowConfig) {
						BPMSoft.each(rows, function(row) {
							BPMSoft.each(rowConfig, function(column, columnName) {
								var rowDataType = column.dataValueType;
								if (rowDataType === BPMSoft.DataValueType.DATE || rowDataType === BPMSoft.DataValueType.DATE_TIME ||
									rowDataType === BPMSoft.DataValueType.TIME) {
									var rawDate = row[columnName];
									if (typeof rawDate == 'object') {
										row[columnName] = Ext.isEmpty(rawDate) ? null : rawDate.toISOString();
									}
								}
							}, this);
						}, this);
						return rows;
					},

					/**
					 * Adds the necessary parameters in the columns configuration.
					 * @param {Object} rowConfig Columns configuration.
					 */
					prepareRowConfig: function(rowConfig) {
						var columns = this.getProfileColumns();
						BPMSoft.each(columns, function(item, key) {
							rowConfig[key].columnPath = item.path;
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#getProfileColumns
					 * @overridden
					 */
					getProfileColumns: function() {
						var profileColumns = {};
						var profile = this.get("GridProfile");
						this.convertProfileColumns(profileColumns, profile);
						return profileColumns;
					},

					/**
					 * Returns columns list of duplicates detail.
					 * @returns {Array} Columns list.
					 */
					getDuplicatesColumns: function() {
						var profileColumns = this.getProfileColumns();
						var columns = [];
						BPMSoft.each(profileColumns, function(column, columnName) {
							if (columnName !== this.entitySchema.primaryColumnName) {
								columns.push(columnName);
							}
						}, this);
						var primaryDisplayColumnName = this.entitySchema.primaryDisplayColumnName;
						if (Ext.Array.contains(columns, primaryDisplayColumnName) === false) {
							columns.push(primaryDisplayColumnName);
						}
						return columns;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @overridden
					 */
					init: function(callback) {
						this.BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onMessageReceived, this);
						this._checkCanManageDuplicatesRules();
						this._checkCanSearchDuplicates();
						this.debounceWindowResize = BPMSoft.debounce(this.changeCardContentContainerSize, 100);
						this.Ext.EventManager.addListener(window, "resize", this.debounceWindowResize, this);
						this.callParent([
							function() {
								var previewItems = this.get("DuplicatesContainerItems");
								previewItems.clear();
								var hiddenItems = this.get("DuplicatesContainerHiddenItems");
								hiddenItems.clear();
								BPMSoft.chain(
										this.initDuplicatesSchemaName,
										this.loadProfileFilters,
										this.initDuplicatesSearchInfo,
										this.initializeSchema,
										this.initProfile,
										this.initInfoLabelCaption,
										callback,
										this
								);
							}, this
						]);
					},

					/**
					 * @private
					 */
					_getBulkESDeduplicationInfo: function(callback, scope) {
						var config = {
							"entityName": this.getDuplicatesSchemaName()
						};
						this.callDeduplicationServiceMethod("GetDeduplicationInfo", function(response) {
							var info = response && response.deduplicationInfo || {};
							this.bulkDeduplicationInfoCallbackHandler(info, callback, scope);
						}, config);
					},
					
					/**
					 * Handles deduplication info response.
					 * @protected
					 * @param {Object} deduplicationInfo Deduplication info response.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					bulkDeduplicationInfoCallbackHandler: function(deduplicationInfo, callback, scope) {
						this.set("LastDuplicatesSearchRun", deduplicationInfo.isFirstRun && null);
						this.set("IsSearchInProcess", Boolean(deduplicationInfo.isRunning));
						Ext.callback(callback, scope || this);
					},

					/**
					 * @private
					 */
					_isBulkESDeduplicationEnabled: function (){
						return this.getIsFeatureEnabled("BulkESDeduplication");
					},

					/**
					 * Initialize information of the duplicates search process.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					initDuplicatesSearchInfo: function(callback, scope) {
						if (this._isBulkESDeduplicationEnabled()) {
							this._getBulkESDeduplicationInfo(callback, scope);
							return;
						}
						var config = {
							"schemaName": this.getDuplicatesSchemaName()
						};
						this.callDeduplicationServiceMethod("GetSearchInfo", function(response) {
							var searchInfoResult = null;
							var searchInProgress = false;
							if (response && response.GetSearchInfoResult) {
								var responseResult = response.GetSearchInfoResult.response;
								if (!Ext.isEmpty(responseResult)) {
									var searchInfo = this.mixins.DuplicatesMergeHelper.dictionaryToObject(responseResult);
									searchInfoResult = searchInfo.LastExecutionDate;
									searchInProgress = JSON.parse(searchInfo.IsInProgress);
								}
							}
							this.set("LastDuplicatesSearchRun", searchInfoResult);
							this.set("IsSearchInProcess", searchInProgress);
							callback.call(scope || this);
						}, config);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onRender
					 * @overridden
					 */
					onRender: function() {
						this.callParent(arguments);
						if (this.get("GridSettingsChanged") === true) {
							this.set("NextDuplicatesGroupOffset", 0);
							this.BPMSoft.chain(
								this.initProfile,
								this.getDeduplicationResults,
								this
							);
							return;
						}
						this.getDeduplicationResults();
					},

					/**
					 * Initialize entity schema.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					initializeSchema: function(callback, scope) {
						var schemaName = this.getDuplicatesSchemaName();
						BPMSoft.require([schemaName], function(response) {
							this.entitySchemaName = response.name;
							this.entitySchema = response;
							callback.call(scope || this);
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#getProfileKey
					 * @overridden
					 */
					getProfileKey: function() {
						var schemaName = this.getDuplicatesSchemaName();
						var profileKey = schemaName + "DuplicatesPageV2DuplicatesDetailV2DataGrid";
						return profileKey;
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#getGridData
					 * @overridden
					 */
					getGridData: function() {
						return this.get("DuplicatesContainerItems");
					},

					/**
					 * Initialize columns list of duplicates detail.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					initProfile: function(callback, scope) {
						var profileKey = this.getProfileKey();
						SchemaBuilder.getProfile(profileKey, function(profile) {
							profile = Ext.Object.isEmpty(profile)
								? DefaultProfileHelper.getEntityProfile(profileKey, this.entitySchemaName,
									this.BPMSoft.GridType.LISTED)
								: profile;
							profile = profile.DataGrid || profile;
							var listedConfig = JSON.parse(profile.listedConfig);
							profile.isTiled = false;
							listedConfig.captionsConfig = ViewGenerator.generateGridCaptionsConfig(listedConfig.items);
							listedConfig.columnsConfig = ViewGenerator.generateGridRowConfig(profile, listedConfig.items);
							ViewGenerator.addLinks(listedConfig, false, this.entitySchema);
							profile.listedConfig = JSON.stringify(listedConfig);
							this.set("GridProfile", profile);
							callback.call(scope || this);
						}, this);
					},

					/**
					 * Returns find duplicates button caption.
					 * @returns {String} Find duplicates button caption.
					 */
					getFindDuplicateBtnCaption: function() {
						const moduleCaption = this._getModuleCaption();
						const pattern = this.get("Resources.Strings.FindDuplicatesButtonCaptionPattern");
						return Ext.String.format(pattern, moduleCaption);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getActions
					 * @overridden
					 */
					getActions: function() {
						const actionMenuItems = this.callParent(arguments);
						actionMenuItems.clear();
						actionMenuItems.addItem(this.getButtonMenuItem({
							Caption: {bindTo: "getFindDuplicateBtnCaption"},
							Visible: {"bindTo": "CanSearchDuplicates"},
							Tag: "findEntityDuplicates"
						}));
						actionMenuItems.addItem(this.getButtonMenuItem({
							Caption: {bindTo: "Resources.Strings.DuplicatesRulesSetupCaption"},
							Tag: "duplicatesRulesSetup",
							Visible: {"bindTo": "CanManageDuplicatesRules"},
						}));
						if(!(this.get("CanSearchDuplicates") && this.get("CanManageDuplicatesRules"))){
							actionMenuItems.clear();
						}
						return actionMenuItems;
					},

					/**
					 * Navigates to section of setting rules of doubles.
					 */
					duplicatesRulesSetup: function() {
						this.sandbox.publish("PushHistoryState", {hash: "SectionModuleV2/DuplicatesRuleSectionV2"});
					},

					/**
					 * @inheritdoc BPMSoft.ProcessEntryPointUtilities#initRunProcessButtonMenu
					 * @overridden
					 */
					initRunProcessButtonMenu: Ext.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getViewOptionsButtonVisible
					 * @overridden
					 */
					getViewOptionsButtonVisible: function() {
						return true;
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#addSectionDesignerViewOptions
					 * @protected
					 * @overridden
					 */
					addSectionDesignerViewOptions: BPMSoft.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getHeader
					 * @overridden
					 */
					getHeader: function() {
						const moduleCaption = this._getModuleCaption();
						const pageHeaderMask = this.get("Resources.Strings.PageHeaderMask");
						return Ext.String.format(pageHeaderMask, moduleCaption);
					},

					/**
					 * @return {String}
					 * @private
					 */
					_getModuleCaption: function() {
						const schemaName = this.getDuplicatesSchemaName();
						const moduleStructure = this.getModuleStructure(schemaName) || {};
						return moduleStructure.moduleCaption;
					},

					/**
					 * Returns localizable string name for header.
					 * @returns {String} Localizable string name.
					 */
					getHeaderLocalizableStringName: function() {
						const schemaName = this.getDuplicatesSchemaName();
						return Ext.String.format("Resources.Strings.{0}HeaderCaption", schemaName);
					},

					/**
					 * Initialize text of InfoLabel.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					initInfoLabelCaption: function(callback, scope) {
						var titleName = this.getInfoTitleLabelLocalizableStringName();
						var descriptionName = this.getInfoDescriptionLabelLocalizableStringName();
						var title = this.get(titleName);
						var description = this.get(descriptionName);
						this.set("InfoLabelTitleCaption", title);
						this.set("InfoLabelDescriptionCaption", description);
						if (callback) {
							callback.call(scope || this);
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#getViewOptions
					 * @overridden
					 */
					getViewOptions: function() {
						var viewOptions = this.callParent(arguments);
						viewOptions.addItem(this.getButtonMenuItem({
							"Caption": {"bindTo": "Resources.Strings.OpenListSettingsCaption"},
							"Click": {"bindTo": "openGridSettings"},
							"Visible": true,
							"ImageConfig": this.get("Resources.Images.GridSettingsIcon")
						}));
						return viewOptions;
					},

					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#getGridSettingsInfo
					 * @overridden
					 */
					getGridSettingsInfo: function() {
						var gridSettingsInfo = this.mixins.GridUtilities.getGridSettingsInfo.call(this);
						gridSettingsInfo.baseGridType = this.BPMSoft.GridType.LISTED;
						gridSettingsInfo.isSingleTypeMode = true;
						return gridSettingsInfo;
					},

					/**
					 * Returns localizable string name for info description label.
					 * @returns {String} Localizable string name.
					 */
					getInfoDescriptionLabelLocalizableStringName: function() {
						var searchInProcess = this.get("IsSearchInProcess");
						var prefix = "SearchInProcess";
						if (searchInProcess === false) {
							var lastRun = this.get("LastDuplicatesSearchRun");
							var isFirstRun = Ext.isEmpty(lastRun);
							prefix = "FirstRun";
							if (isFirstRun === false) {
								prefix = "Empty";
							}
						}
						return Ext.String.format("Resources.Strings.{0}InfoDescriptionLabelCaption", prefix);
					},

					/**
					 * Returns localizable string name for info title label.
					 * @returns {String} Localizable string name.
					 */
					getInfoTitleLabelLocalizableStringName: function() {
						var searchInProcess = this.get("IsSearchInProcess");
						var prefix = "SearchInProcess";
						var schemaName = "";
						if (searchInProcess === false) {
							var lastRun = this.get("LastDuplicatesSearchRun");
							var isFirstRun = Ext.isEmpty(lastRun);
							prefix = "FirstRun";
							if (isFirstRun === false) {
								schemaName = this.getDuplicatesSchemaName();
								prefix = "Empty";
							}
						}
						return Ext.String.format("Resources.Strings.{0}{1}InfoTitleLabelCaption", schemaName, prefix);
					},

					/**
					 * @inheritDoc BPMSoft.BasePageV2#changeSelectedSideBarMenu
					 * @overriden
					 */
					changeSelectedSideBarMenu: function() {
						var moduleName = this.getDuplicatesSchemaName();
						var moduleConfig = BPMSoft.configuration.ModuleStructure[moduleName];
						if (moduleConfig) {
							var sectionSchema = moduleConfig.sectionSchema;
							var config = moduleConfig.sectionModule + "/";
							if (sectionSchema) {
								config += moduleConfig.sectionSchema + "/";
							}
							this.sandbox.publish("SelectedSideBarItemChanged", config, ["sectionMenuModule"]);
						}
					},

					/**
					 * DuplicatesContainer scroll handler.
					 */
					onLoadNext: function() {
						this.getDeduplicationResults();
					},

					/**
					 * Returns url of info content image.
					 * @returns {String} Image url.
					 */
					getInfoContentImage: function() {
						const lastRun = this.get("LastDuplicatesSearchRun");
						const searchInProcess = this.get("IsSearchInProcess");
						const filters = this.getCustomFiltersGroup();
						let imageSource;
						if (filters && filters.getCount() !== 0) {
							imageSource = baseDataViewResources.localizableImages.EmptyFilterImage;
						} else if (searchInProcess) {
							imageSource = this.get("Resources.Images.SearchInProcessImage");
						} else if (Ext.isEmpty(lastRun)) {
							imageSource = this.get("Resources.Images.FirstRunImage");
						}  else {
							imageSource = this.get("Resources.Images.ItemsIsEmptyImage");
						}
						return BPMSoft.ImageUrlBuilder.getUrl(imageSource);
					},

					/**
					 * Returns data-item-marker value for info content.
					 * @returns {String} data-item-marker value.
					 */
					getInfoContentMarkerValue: function() {
						var lastRun = this.get("LastDuplicatesSearchRun");
						var searchInProcess = this.get("IsSearchInProcess");
						var marker;
						if (searchInProcess) {
							marker = this.get("Resources.Strings.SearchInProcessMarker");
						} else if (Ext.isEmpty(lastRun)) {
							marker = this.get("Resources.Strings.FirstRunMarker");
						} else {
							marker = this.get("Resources.Strings.ItemsIsEmptyMarker");
						}
						return marker;
					},

					/**
					 * @inheritdoc
					 * @override BPMSoft.GridUtilities#getGridSettingsModuleConfig
					 */
					getGridSettingsModuleConfig: function(gridSettingsId) {
						return {
							renderTo: "centerPanel",
							id: gridSettingsId,
							keepAlive: true,
							instanceConfig: {
								schemaName: "GridSettingsPage",
								isSchemaConfigInitialized: true,
								parameters: {
									viewModelConfig: {
										UseBackwards: false
									}
								}
							}
						};
					},

					/**
					 * @inheritdoc BasePageV2#subscribeSandboxEvents
					 * @protected
					 * @overridden
					 */
					subscribeSandboxEvents: function() {
						this.callParent();
						this.sandbox.subscribe("NotDuplicatesOperationExecuted", this.onNotDuplicatesOperationExecuted, this);
						this.sandbox.subscribe("MergeEntityDuplicatesExecuted", this.onMergeEntityDuplicatesExecuted, this);
						this.sandbox.subscribe("GetSectionEntitySchema", function() {
							return this.entitySchema;
						}, this);
						this.initQuickFilterMessages();
					},

					/**
					 * Initiates quick filters config.
					 * @protected
					 */
					initQuickFilterMessages: function() {
						this.sandbox.subscribe("GetModuleSchema", function() {
							return {
								entitySchema: this.entitySchema,
								filterDefaultColumnName: 
									this.entitySchema.primaryDisplayColumn && 
									this.entitySchema.primaryDisplayColumn.name,
								isShortFilterVisible: true
							};
						}, this, [this.getQuickFilterModuleId()]);
						this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfig,
							this, [this.getQuickFilterModuleId()]);
						this.sandbox.subscribe("UpdateFilter", this.onFiltersChanged,
							this, [this.getQuickFilterModuleId()]);
						this.sandbox.subscribe("GetSectionFiltersInfo", this.onGetPageFiltersInfo,
							this, [this.getQuickFilterModuleId()]);
					},

					/**
					 * Merge entities handler
					 * @protected
					 */
					onMergeEntityDuplicatesExecuted: function (mergedRecordsIds) {
						this.set("IsSearchInProcess", false);
						this.initInfoLabelCaption();
					},

					/**
					 * Handles not duplicates operation execution ended.
					 */
					onNotDuplicatesOperationExecuted: function() {
						this.getBulkESDeduplicationCountData();
					},

					/**
					 * Handles web-socket message receiving.
					 * @param {Object} event
					 * @param {Object} message
					 */
					onMessageReceived: function(event, message) {
						const messageCode = message && message.Header.Sender;
						if (messageCode === "DuplicatesOperationExecuted") {
							this.getBulkESDeduplicationCountData();
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaModule#destroy
					 * @override
					 */
					destroy: function() {
						const utilsContainer = document.querySelector('.utils-container-wrapper-wrapClass');
						const cardContentContainer = document.querySelector('.duplicates-card-content-container');
						cardContentContainer && cardContentContainer.classList.remove('no-filters');
						utilsContainer && utilsContainer.classList.remove('no-filters');
						this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE, this.onMessageReceived, this);
						this.callParent(arguments);
					},

					/**
					 * Returns included pages for duplicates duplicates summary.
					 * @protected
					 */
					getIncludedDuplicatesSummaryPages: function() {
						return [
							"LazyDuplicatesPageV2",
						];
					},

					/**
					 * Returns is show duplicates summary
					 * @protected
					 */
					getIsShowDuplicatesSummary: function() {
						return this.$IsShowBulkDuplicatesSummary 
						&& this.getIncludedDuplicatesSummaryPages().includes(this.name);
					},
					
					/**
					 * Handles quick filters change.
					 * @param {Object} filtersConfig Filters config.
					 */
					onFiltersChanged: function(filtersConfig) {
						if (!this.getIsFeatureEnabled("DuplicatesPageFilters") || !this._isBulkESDeduplicationEnabled()) {
							return;
						}
						if (this.get("InitialFiltersLoad")) {
							this.set("InitialFiltersLoad", false);
							return;
						}
						this.saveFilters(filtersConfig);
						this.clearItems();
						this.set("NextDuplicatesGroupOffset", 0);
						this.getDeduplicationResults();
					},

					/**
					 * Saves filters to profile.
					 * @param {Object} filtersConfig Filters configuration.
					 * @param {BPMSoft.Collection} filtersConfig.filters Filters collection.
					 */
					saveFilters: function(filtersConfig) {
						this.set("CustomFilters", filtersConfig);
						const filtersToSave = {
							filtersValue: filtersConfig.filtersValue,
							filters: []
						};
						filtersConfig.filters.each(function(item) {
							filtersToSave.filters.push(this.getSerializableFilter(item));
						}, this);
						this.BPMSoft.saveUserProfile(this.getFiltersProfileKey(), filtersToSave, false);
					},

					/**
					 * Gets serializable filter.
					 * @protectec
					 * @param {BPMSoft.FilterGroup} filter Filter group.
					 * @return {Object} Serializable filter object.
					 */
					getSerializableFilter: function(filter) {
						filter.serializationInfo = {serializeFilterManagerInfo: true};
						const serializableFilter = {};
						filter.getSerializableObject(serializableFilter, filter.serializationInfo);
						return serializableFilter;
					},

					/**
					 * Loads custom filters from profile.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					loadProfileFilters: function(callback, scope) {
						this.BPMSoft.require(["profile!" + this.getFiltersProfileKey()],
							function(filters) {
								const filtersToSave = {
									filtersValue: filters.filtersValue,
									filters: Ext.create("BPMSoft.Collection")
								};
								if (filters.filters) {
									filters.filters.forEach(function(item, index) {
										filtersToSave.filters.add(index, this.BPMSoft.deserialize(item));
									});	
								}
								this.set("CustomFilters", filtersToSave);
								this.Ext.callback(callback, scope);
							}, this);
					},

					/**
					 * Gets filters profile key.
					 * @return {string} Filters profile key.
					 */
					getFiltersProfileKey: function() {
						return "DuplicatesFilters_" + this.getDuplicatesSchemaName() + this.sandbox.id;	
					},

					/**
					 * Gets extended filter configuration.
					 * @protected
					 */
					onGetExtendedFilterConfig: function() {
						return {
							isFoldersHidden: true,
							hasExtendedMode: false,
							filterButtonCaption: this.get("Resources.Strings.FilterButtonCaption"),
							filterIcon: baseDetailResources.localizableImages.ImageFilter,
							showButtonCaption: true
						};
					},

					/**
					 * Forms quick filter module identifier.
					 * @protected
					 * @return {String} Module identifier.
					 */
					getQuickFilterModuleId: function() {
						return this.sandbox.id + "_module_QuickFilterModuleV2";
					},

					/**
					 * Loads quick filter moduke.
					 * @param {Object} config Loading configuration.
					 */
					loadQuickFilter: function(config) {
						if (!this.getIsFeatureEnabled("DuplicatesPageFilters")) {
							const utilsContainer = document.querySelector('.utils-container-wrapper-wrapClass');
							const cardContentContainer = document.querySelector('.duplicates-card-content-container');
							cardContentContainer && cardContentContainer.classList.add('no-filters');
							utilsContainer && utilsContainer.classList.add('no-filters');
							return;
						}
						const moduleId = this.getModuleId(config.moduleName);
						const args = {
							renderTo: config.containerId
						};
						const rendered = this.sandbox.publish("RerenderQuickFilterModule", args, [moduleId]);
						if (!rendered) {
							this.set("InitialFiltersLoad", true);
							this.loadModule(config);
						}
					},

					/**
					 * Changes CardContentContainer size on filter container size change.
					 */
					changeCardContentContainerSize: function() {
						if (!this.getIsFeatureEnabled("DuplicatesPageFilters")) {
						
							return;
						}
						if (!this.throttledChangeCardContentContainerSize) {
							this.throttledChangeCardContentContainerSize = BPMSoft.throttle(function() {
								const cardContentWrapper = Ext.get("CardContentWrapper");
								const filtersContainer = cardContentWrapper &&
									document.querySelector('.utils-container-wrapClass')
								const cardContentContainer = filtersContainer &&
									cardContentWrapper.select(".duplicates-card-content-container").first();
								if (filtersContainer && cardContentContainer) {
									const height = filtersContainer.getBoundingClientRect().height;
									cardContentContainer.setStyle("margin-top", height + 36 + "px");
									const cardContentContainerHeight = window.innerHeight - 246;
									cardContentContainer.setStyle("min-height", cardContentContainerHeight + "px");
								}
							}, 80);
						}
						this.throttledChangeCardContentContainerSize();
					},

					/**
					 * Forms filters group for data query.
					 * @return {String} Filters group.
					 */
					getCustomFiltersGroup: function() {
						const filtersConfig = this.get("CustomFilters");
						const group = this.Ext.create("BPMSoft.FilterGroup");
						group.logicalOperation = BPMSoft.LogicalOperatorType.AND;
						if (filtersConfig && filtersConfig.filters) {
							filtersConfig.filters.each(function(filter) {
								group.addItem(filter);
							}, this)
						}
						return group;
					},

					/**
					 * Handles get filters event for quick filter module.
					 * @return {BPMSoft.Collection}
					 */
					onGetPageFiltersInfo: function() {
						const filtersInfo = this.Ext.create("BPMSoft.Collection");
						const filtersConfig = this.get("CustomFilters");
						const filtersValue = filtersConfig.filtersValue; 
						if (filtersValue) {
							filtersInfo.add("CustomFilters", filtersValue);
						}
						return filtersInfo;
					}
				},

				diff: /**SCHEMA_DIFF*/
						[
							{
								"operation": "insert",
								"name": "GroupSummaryContainer",
								"parentName": "LeftContainer",
								"propertyName": "items",
								"values": {
									"classes": {
										"wrapClassName": ["duplicate-summary-item-container"]
									},
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"visible": {"bindTo": "getIsShowDuplicatesSummary"},
									"items": []
								},
								"index": 10
							},
							{
								"operation": "insert",
								"name": "GroupSummaryTitle",
								"parentName": "GroupSummaryContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["duplicate-summary-item-caption"]
									},
									"caption": {"bindTo": "Resources.Strings.GroupSummaryCaption"}
								}
							},
							{
								"operation": "insert",
								"name": "GroupSummaryValue",
								"parentName": "GroupSummaryContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["duplicate-summary-item-value"]
									},
									"caption":  {"bindTo": "DeduplicationGroupsCount"}
								}
							},
							{
								"operation": "insert",
								"name": "DuplicatesSummaryContainer",
								"parentName": "LeftContainer",
								"propertyName": "items",
								"values": {
									"classes": {
										"wrapClassName": ["duplicate-summary-item-container"]
									},
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"visible": {"bindTo": "getIsShowDuplicatesSummary"},
									"items": []
								},
								"index": 11
							},
							{
								"operation": "insert",
								"name": "DuplicatesSummaryTitle",
								"parentName": "DuplicatesSummaryContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["duplicate-summary-item-caption"]
									},
									"caption": {"bindTo": "Resources.Strings.DuplicatesSummaryCaption"}
								}
							},
							{
								"operation": "insert",
								"name": "DuplicatesSummaryValue",
								"parentName": "DuplicatesSummaryContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["duplicate-summary-item-value"]
									},
									"caption":  {"bindTo": "DuplicatesCount"}
								}
							},
							{
								"operation": "merge",
								"name": "CardContentWrapper",
								"values": {
									"wrapClass": ["card-content-container", "duplicates-content-wrap"]
								}
							},
							{
								"operation": "merge",
								"name": "CardContentContainer",
								"values": {
									"wrapClass": ["center-main-container duplicates-card-content-container"]
								}
							},
							{
								"operation": "remove",
								"name": "actions"
							},
							{
								"operation": "insert",
								"parentName": "LeftContainer",
								"propertyName": "items",
								"name": "actions",
								"values": {
									"itemType": BPMSoft.ViewItemType.BUTTON,
									"caption": {"bindTo": "Resources.Strings.ActionButtonCaption"},
									"classes": {
										"textClass": ["actions-button-margin-right"],
										"wrapperClass": ["actions-button-margin-right"]
									},
									"menu": {
										"items": {"bindTo": "ActionsButtonMenuItems"}
									},
									"visible": {"bindTo": "ActionsButtonVisible"}
								},
								"index": 5
							},
							{
								"operation": "insert",
								"name": "GridUtilsContainer",
								"parentName": "GridUtilsContainerWrapper",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["utils-container-wrapClass"],
									"observeMutations": true,
									"mutationConfig": {"attributes": true, "childList": true, "subtree": true},
									"mutate": {"bindTo": "changeGridUtilitiesContainerSize"},
									"items": []
								}
							},
							{
								"operation": "insert",
								"name": "GridUtilsContainerWrapper",
								"parentName": "LazyDuplicatesPageV2Container",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["utils-container-wrapper-wrapClass"],
									"items": []
								}
							},
							{
								"operation": "merge",
								"name": "GridUtilsContainer",
								"parentName": "GridUtilsContainerWrapper",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["utils-container-wrapClass"],
								}
							},
							{
								"operation": "insert",
								"name": "LeftGridUtilsContainer",
								"parentName": "GridUtilsContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["left-utils-container-wrapClass"],
									"items": []
								}
							},
							{
								"operation": "insert",
								"parentName": "LeftGridUtilsContainer",
								"propertyName": "items",
								"name": "FiltersContainer",
								"values": {
									"itemType": BPMSoft.ViewItemType.MODULE,
									"moduleName": "QuickFilterModuleV2",
									"generateId": true,
									"makeUniqueId": true,
									"classes": {
										"wrapClassName": ["detail-filter-container-style"]
									},
									"afterrender": {"bindTo": "loadQuickFilter"},
									"afterrerender": {"bindTo": "sendFilterRerender"},
									"observeMutations": true,
									"mutationConfig": {"attributes": true, "childList": true, "subtree": true},
									"mutate": {"bindTo": "changeCardContentContainerSize"},
								},
							},
							{
								"operation": "remove",
								"name": "HeaderContainer"
							},
							{
								"operation": "insert",
								"name": "InfoContentContainer",
								"parentName": "CardContentContainer",
								"propertyName": "items",
								"values": {
									"id": "InfoContentContainer",
									"classes": {
										"wrapClassName": ["empty-grid-message"]
									},
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"markerValue": {"bindTo": "getInfoContentMarkerValue"},
									"visible": {"bindTo": "IsDuplicatesContainerItemsEmpty"},
									"items": []
								}
							},
							{
								"operation": "insert",
								"name": "InfoImageContainer",
								"parentName": "InfoContentContainer",
								"propertyName": "items",
								"values": {
									"classes": {
										"wrapClass": ["image-container"]
									},
									"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
									"onPhotoChange": BPMSoft.emptyFn,
									"getSrcMethod": "getInfoContentImage",
									"visible": {"bindTo": "IsDuplicatesContainerItemsEmpty"},
									"items": []
								}
							},
							{
								"operation": "insert",
								"name": "InfoTitleLabelContainer",
								"parentName": "InfoContentContainer",
								"propertyName": "items",
								"values": {
									"classes": {
										"wrapClassName": ["title"]
									},
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"visible": {"bindTo": "IsDuplicatesContainerItemsEmpty"},
									"items": []
								}
							},
							{
								"operation": "insert",
								"name": "InfoDescriptionLabelContainer",
								"parentName": "InfoContentContainer",
								"propertyName": "items",
								"values": {
									"classes": {
										"wrapClassName": ["description"]
									},
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"visible": {"bindTo": "IsDuplicatesContainerItemsEmpty"},
									"items": []
								}
							},
							{
								"operation": "insert",
								"name": "InfoTitleLabel",
								"parentName": "InfoTitleLabelContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["t-label"]
									},
									"caption": {"bindTo": "InfoLabelTitleCaption"}
								}
							},
							{
								"operation": "insert",
								"name": "InfoDescriptionLabel",
								"parentName": "InfoDescriptionLabelContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.LABEL,
									"classes": {
										"labelClass": ["t-label"]
									},
									"caption": {"bindTo": "InfoLabelDescriptionCaption"}
								}
							},
							{
								"operation": "insert",
								"name": "InfoDescriptionRunBtn",
								"parentName": "InfoDescriptionLabelContainer",
								"propertyName": "items",
								"values": {
									"itemType": BPMSoft.ViewItemType.HYPERLINK,
									"click": {"bindTo": "findEntityDuplicates"},
									"caption": {"bindTo": "getFindDuplicateBtnCaption"},
									"visible": {
										"bindTo": "IsSearchInProcess",
										"bindConfig": {
											"converter": function(value) {
												var inProcess = value || false;
												return this.get("CanSearchDuplicates") && !inProcess;
											}
										}
									}
								}
							},
							{
								"operation": "insert",
								"name": "DuplicatesContainer",
								"parentName": "CardContentContainer",
								"propertyName": "items",
								"values": {
									"idProperty": "DuplicatesGroupId",
									"collection": {"bindTo": "DuplicatesContainerItems"},
									"generator": "ContainerListGenerator.generatePartial",
									"maskVisible": {"bindTo": "IsPreviewItemsLoading"},
									"selectableRowCss": "duplicates-container-item",
									"itemType": BPMSoft.ViewItemType.GRID,
									"classes": {wrapClassName: ["content-preview-block-container content-container-wrapClass"]},
									"itemPrefix": "listItem",
									"observableRowNumber": 1,
									"observableRowVisible": {"bindTo": "onLoadNext"},
									"itemConfig": [
										{
											"name": "DuplicateContainer",
											"itemType": BPMSoft.ViewItemType.CONTAINER,
											"classes": {wrapClassName: ["ts-controlgroup control-group-margin-bottom"]},
											"afterrender": {"bindTo": "onItemContainerRendered"}
										}
									]
								}
							}
						]/**SCHEMA_DIFF*/
			};
		});
