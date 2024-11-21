define("DuplicatesSearchUtilitiesV2", ["StorageUtilities", "ConfigurationConstants", "RightUtilities",
		"DeduplicationConstants", "DuplicatesSearchUtilitiesV2Resources"],
	function(storageUtilities, ConfigurationConstants, RightUtilities, DeduplicationConstants) {
		Ext.define("BPMSoft.configuration.mixins.DuplicatesSearchUtilitiesV2", {
			alternateClassName: "BPMSoft.DuplicatesSearchUtilitiesV2",

			/**
			 * #### ###### # ####### ####
			 * @protected
			 * @type {String}
			 */
			storageKey: "DuplicateStorage",

			/**
			 * Detail duplicate attribute template.
			 * @private
			 * @type {String}
			 */
			_detailDuplicateAttributeTpl: "DetailRuleValues_{0}",

			/**
			 * Communications schema names.
			 * @private
			 * @type {String[]}
			 */
			_communicationSchemaNames: ["ContactCommunication", "AccountCommunication"],

			/**
			 * Returns default deduplication results view columns.
			 * @returns {String[]} Default deduplication results view columns.
			 * @private
			 */
			_getDefaultDeduplicationViewColumns: function() {
				var entity = this.entitySchema || BPMSoft[this.getDuplicateSchemaName()] || {};
				var columnNames = [];
				if (entity.primaryDisplayColumnName) {
					columnNames.push(entity.primaryDisplayColumnName);
				}
				var ownerColumn = entity.columns && entity.columns.Owner;
				if (ownerColumn) {
					columnNames.push(ownerColumn.name);
				}
				return columnNames;
			},

			/**
			 * Calls iterator function for all rules filters.
			 * @param {Function} iterator Iterator function for all rules filters.
			 * @private
			 */
			_iterateAllDeduplicationColumns: function(iterator) {
				var rules = this.getDeduplicationSettings();
				this.BPMSoft.each(rules, iterator, this);
			},

			/**
			 * Append root entity column values to duplicate rule filter values.
			 * @private
			 * @param {String[]} rootSchemaColumns Root schema column names.
			 * @param {String[]} filterValues Duplicate rule filter values.
			 */
			_appendRootEntityValues: function(rootSchemaColumns, filterValues) {
				this.BPMSoft.each(rootSchemaColumns, function(columnName) {
					var rootEntityValue = this.get(columnName);
					if (!this.Ext.isEmpty(rootEntityValue)) {
						filterValues.push(rootEntityValue.displayValue || rootEntityValue);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_getCommunicationFilterValues: function(filter, config) {
				var communicationValues = this.getCommunications(config);
				var filterCommunications = this.BPMSoft.filter(communicationValues, function(communication) {
					return communication.CommunicationId === filter.type;
				}, this);
				var communicationFilterValues = this.BPMSoft.map(filterCommunications, function(item) {
					return item.Number;
				}, this);
				this._appendRootEntityValues(filter.rootSchemaColumns, communicationFilterValues);
				return this.Ext.Array.unique(communicationFilterValues);
			},

			/**
			 * @private
			 */
			_getDetailFilterValues: function(filter) {
				var detailModelAttribute = this.getDetailDuplicateAttributeName(filter.schemaName);
				var cardModelValue = this.get(filter.columnName) || null;
				cardModelValue = cardModelValue && cardModelValue.displayValue || cardModelValue;
				var cardModelDetailValues = this.get(detailModelAttribute) || {};
				var cardModelDetailColumnValues = cardModelDetailValues[filter.columnName] || [];
				if (cardModelValue) {
					cardModelDetailColumnValues.push(cardModelValue);
				}
				this._appendRootEntityValues(filter.rootSchemaColumns, cardModelDetailColumnValues);
				return this.Ext.Array.unique(cardModelDetailColumnValues);
			},

			/**
			 * @private
			 */
			_callDuplicatesDataService: function(config, next, scope) {
				var data = this.getElasticDuplicatesServiceData(config);
				this.set("DuplicatesDataSend", data);
				this.callService({
					data: data,
					serviceName: "DeduplicationServiceV2",
					methodName: "FindDuplicatesOnSave",
					encodeData: false
				}, next, scope);
			},

			/**
			 * @private
			 */
			_getCommunicationsSchemaName: function(config) {
				var settings = this.getDeduplicationSettings(config);
				var schemaNames = this.Ext.Array.unique(
					settings.map(x => x.schemaName)
						.filter(x => this.Ext.Array.contains(this._communicationSchemaNames, x)
							&& x.includes(this.entitySchemaName)));
				return schemaNames.length === 0 ? null : schemaNames[0];
			},

			/**
			 * @private
			 */
			_getDuplicateRuleDetailColumns: function(detailEntitySchemaName) {
				var duplicateDetailColumns = [];
				this._iterateAllDeduplicationColumns(function(filter) {
					if (filter.schemaName === detailEntitySchemaName) {
						duplicateDetailColumns.push(filter.columnName);
					}
				});
				return duplicateDetailColumns;
			},
			
			/**
			 * Goes to duplicates search page.
			 * @protected
			 * @param {String} duplicatesObjectName Duplicates entity name.
			 */
			openDuplicatesModule: function(duplicatesObjectName) {
				const hash = Ext.String.format("CardModuleV2/{0}/{1}",
						DeduplicationConstants.features.getIsLazyDuplicatesPageEnabled()
							? "LazyDuplicatesPageV2" : "DuplicatesPageV2",
						duplicatesObjectName);
				this.sandbox.publish("PushHistoryState", {
					hash: hash
				});
			},
			
			/**
			 * Returns detail duplicate card attribute name.
			 * @protected
			 * @param {String} entitySchemaName
			 * @returns {String} Detail duplicate card attribute name.
			 */
			getDetailDuplicateAttributeName: function(entitySchemaName) {
				return this.Ext.String.format(this._detailDuplicateAttributeTpl, entitySchemaName);
			},

			/**
			 * ########## #### #### ############# ########### ##### ######
			 * @protected
			 * @virtual
			 * @return {string} ########## #### #### ############# ########### ##### ######
			 */
			getPerformSearchOnSaveKey: function() {
				return this.entitySchema.name + "PerformSearchOnSave";
			},

			/**
			 * ########## ############# ###### ###### ######
			 * @protected
			 * @virtual
			 * @return {string} ########## ############# ###### ###### ######
			 */
			getDuplicateSearchPageId: function() {
				return this.sandbox.id + "_LocalDuplicateSearchPage";
			},

			/**
			 * ########## ### ########## ###### ### ###### ######
			 * @protected
			 * @virtual
			 * @return {string} ########## ### ########## ###### ### ###### ######
			 */
			getFindDuplicatesMethodName: BPMSoft.abstractFn,

			/**
			 * ########## ### ########## ###### ########## ########## ###### # #######
			 * @protected
			 * @virtual
			 * @return {string} ########## ### ########## ###### ########## ########## ###### # #######
			 */
			getSetDuplicatesMethodName: BPMSoft.abstractFn,

			/**
			 * Initialize available find duplicate on save.
			 * @protected
			 */
			initPerformSearchOnSave: function() {
				if (this.getIsFeatureEnabled("ESDeduplication")) {
					this.set("PerformSearchOnSave", true);
				} else {
					var performSearchOnSave = storageUtilities.getItem(this.storageKey,
						this.getPerformSearchOnSaveKey());
					if (!this.Ext.isEmpty(performSearchOnSave)) {
						this.set("PerformSearchOnSave", performSearchOnSave);
					} else {
						var serviceMethodName = "Get" + this.getPerformSearchOnSaveKey();
						BPMSoft.delay(this.callService, this, 1000, [{
							serviceName: "SearchDuplicatesService",
							methodName: serviceMethodName,
							encodeData: false
						}, function(response) {
							performSearchOnSave = response[serviceMethodName + "Result"];
							storageUtilities.setItem(performSearchOnSave, this.storageKey,
								this.getPerformSearchOnSaveKey());
							this.set("PerformSearchOnSave", performSearchOnSave);
						}, this]);
					}
				}
			},

			/**
			 * ############## ######### #######, ############# ## ########### #########
			 * @protected
			 * @virtual
			 */
			init: function() {
				if (this.getIsEntityDeduplicationEnabled()) {
					this.initPerformSearchOnSave();
					this.sandbox.subscribe("GetDuplicateSearchConfig", function() {
						return {
							entitySchemaName: this.entitySchema.name,
							cardSandBoxId: this.sandbox.id, //TODO: ### ## ######## ######?
							list: this.get("FindDuplicatesResult"),
							dataSend: this.get("DuplicatesDataSend") // TODO: Нужно подумать,
							// ###### LocalDuplicateSearchPage # #### ###### ## ###############
						};
					}, this, [this.getDuplicateSearchPageId()]);
					this.sandbox.subscribe("FindDuplicatesResult", function(result) {
						var dataSend = {
							notDuplicateList: result.collection,
							request: result.config.request
						};
						this.set("DuplicateResponse", dataSend);
						this.save(function() {
							Ext.callback(result.callback, result.scope);
							this.sandbox.unloadModule(this.getDuplicateSearchPageId(), "centerPanel");
						}, this);
					}, this, [this.sandbox.id]);
				}
			},

			/**
			 * Finds duplicates on save. If there is a matching / similar records, these records show.
			 * Else, calls callback function.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			findOnSave: function(callback, scope) {
				if (this.getIsEntityDeduplicationEnabled()) {
					if (this.get("DuplicateResponse")) {
						var resultObject = {success: true};
						callback.call(scope, resultObject);
					} else {
						this.findDuplicates(callback, scope);
					}
				} else {
					this.Ext.callback(callback, scope || this);
				}
			},

			/**
			 * Calls service for find duplicates.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @param {Object} config Customizable duplicates search config.
			 */
			findDuplicates: function(callback, scope, config) {
				if (this.getIsFeatureEnabled("ESDeduplication")) {
					this.findElasticDuplicates(callback, scope, config);
					return;
				}
				var data = this.getDataForFindDuplicatesService();
				var serviceName = this.getDuplicatesServiceName();
				var methodName = this.getFindDuplicatesServiceMethodName();
				this.set("DuplicatesDataSend", data);
				this.set("FindDuplicatesMethodName", methodName);
				this.callService({
					data: data,
					serviceName: serviceName,
					methodName: methodName,
					encodeData: false
				}, this.handleResponseFindDuplicatesService.bind(this, callback, scope), this);
			},

			/**
			 * Calls service for find elastic duplicates.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @param {Object} config Customizable duplicates search config.
			 */
			findElasticDuplicates: function(callback, scope, config) {
				this.BPMSoft.chain(
					function(next) {
						this.initCommunicationsDataFromDb(next, scope, config);
					},
					function(next) {
						this._callDuplicatesDataService(config, next, scope);
					},
					function(next, response) {
						this.handleResponseFindDuplicatesService(next, scope, response, config)
					},
					function(next, result) {
						this.Ext.callback(callback, scope, [result]);
					}, this);
			},

			/**
			 * Gets communications entity schema query.
			 * @protected
			 * @param {String} communicationSchemaName Communication schema name.
			 */
			getCommunicationsEsq: function(communicationSchemaName) {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: communicationSchemaName,
				});
				esq.addColumn("Id");
				esq.addColumn("Number");
				esq.addColumn("SearchNumber");
				esq.addColumn("CommunicationType");
				esq.addColumn("[ComTypebyCommunication:CommunicationType:CommunicationType].Communication", "Communication")
				esq.addColumn(this.entitySchemaName);
				esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					this.entitySchemaName,
					this.$Id));
				return esq;
			},

			/**
			 * Process communications response.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @param {Object} response Communications response.
			 */
			processCommunicationsResponse: function(callback, scope, response) {
				if (response.success) {
					var entityCollection = response.collection;
					var result = [];
					entityCollection.each(function(item) {
						var communicationType = item.get("CommunicationType");
						communicationType.communicationValue = item.get("Communication").value
						result.push({
							"Id": item.get("Id"),
							"Number": item.get("Number"),
							"SearchNumber": item.get("SearchNumber"),
							"CommunicationType": item.get("CommunicationType")
						});
					}, this);
					this.set("DBCommunications", result);
				}
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * Initialize communications collection from database.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @param {Object} config Customizable duplicates search config.
			 */
			initCommunicationsDataFromDb: function(callback, scope, config) {
				if (!config || !config.isGetCommunicationsFromDb) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				this.set("DBCommunications", []);
				var communicationSchemaName = this._getCommunicationsSchemaName(config);
				if (!communicationSchemaName) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				var esq = this.getCommunicationsEsq(communicationSchemaName);
				esq.getEntityCollection(function(response) {
					this.processCommunicationsResponse(callback, scope, response);
				}, this);
			},

			_getEntitySchema: function() {
				return this.entitySchema || BPMSoft[this.getDuplicateSchemaName()] || {};
			},

			/**
			 * Returns primary column value for exclude from duplication search result.
			 * @protected
			 * @return {string} Primary column value.
			 */
			getPrimaryColumnValue: function() {
				var entity = this._getEntitySchema();
				return this.get(entity.primaryColumnName) || null;
			},

			/**
			 * Returns data for elastic duplicates service.
			 * @protected
			 * @return {Object} Data for elastic duplicates service.
			 * @param {Object} config Customizable duplicates search config.
			 */
			getElasticDuplicatesServiceData: function(config) {
				var columns = this.getDeduplicationViewDataColumns(config);
				var entity = this._getEntitySchema();
				if (entity.primaryColumnName && !this.BPMSoft.contains(columns, entity.primaryColumnName)) {
					columns.push(entity.primaryColumnName);
				}
				var data = {
					"schemaName": this.getDuplicateSchemaName(),
					"primaryColumnValue": this.getPrimaryColumnValue() || null,
					"model": this.getDeduplicationModel(config),
					"columns": columns,
					"type": (config && config.findByActiveRules) 
						? ConfigurationConstants.DuplicatesRuleType.OnlyActive 
						: ConfigurationConstants.DuplicatesRuleType.Default
				};
				return data;
			},

			/**
			 * Returns name of find duplicates service method.
			 * @protected
			 * @virtual
			 * @return {String} Name of service method.
			 */
			getFindDuplicatesServiceMethodName: function() {
				return this.getFindDuplicatesMethodName();
			},

			/**
			 * Returns name of find duplicates service method.
			 * @protected
			 * @virtual
			 * @return {String} Name of service.
			 */
			getDuplicatesServiceName: function() {
				return "SearchDuplicatesService";
			},

			/**
			 * Returns data for service.
			 * @protected
			 * @virtual
			 * @return {Object} Prepared data for service.
			 */
			getDataForFindDuplicatesService: function() {
				var communication = this.getCommunications() || [];
				var email = this.get("Email");
				if (!this.Ext.isEmpty(email)) {
					communication.push({
						"Number": email,
						"CommunicationTypeId": ConfigurationConstants.CommunicationTypes.Email
					});
				}
				var data = {
					schemaName: this.getDuplicateSchemaName(),
					request: {
						Id: this.get("Id"),
						Name: this.get("Name"),
						AlternativeName: this.get("AlternativeName"),
						Communication: communication
					}
				};
				return data;
			},

			/**
			 * Handles response from service.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @param {Object} response Response present a result of find duplicates.
			 * @param {Object} config Customizable duplicates search config.
			 */
			handleResponseFindDuplicatesService: function(callback, scope, response, config) {
				var result = response[this.get("FindDuplicatesMethodName") + "Result"];
				if (this.getIsFeatureEnabled("ESDeduplication")) {
					result = JSON.parse(response && response.FindDuplicatesOnSaveResult || false) || [];
				}
				if (result && result.length > 0) {
					if (config && config.findByActiveRules) {
						const duplicatesIds = this.BPMSoft.map(result, function(item) {
							return item.Id;
						});
						this.set("DuplicatesRecords", duplicatesIds);
						this.Ext.callback(callback, scope, [{success: true}]);
						this.hideBodyMask();
					} else {
						this.set("FindDuplicatesResult", result);
						this.loadLocalDuplicateSearchPage();
						this.showBodyMask({ timeout: 0 });
					}
				} else {
					if (config && config.findByActiveRules) {
						this.set("DuplicatesRecords", []);
					}
					var resultObject = {success: true};
					this.Ext.callback(callback, scope, [resultObject])
				}
			},

			/**
			 * Saves result of work with duplicates.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 */
			setDuplicates: function(callback) {
				if (this.getIsEntityDeduplicationEnabled()) {
					if (this.get("PerformSearchOnSave") && !this.Ext.isEmpty(this.get("DuplicateResponse"))) {
						var data = this.get("DuplicateResponse");
						var methodName = this.getSetDuplicatesServiceMethodName();
						var serviceName = this.getDuplicatesServiceName();
						data.schemaName = this.getDuplicateSchemaName();
						this.callService({
							data: data,
							serviceName: serviceName,
							methodName: methodName,
							encodeData: false
						}, function() {
							if (callback) {
								callback.call(this);
							}
						}, this);
					} else {
						if (callback) {
							callback.call(this);
						}
					}
				} else {
					this.Ext.callback(callback, this);
				}
			},

			/**
			 * Returns deduplication results view data columns.
			 * @returns {String[]} Deduplication results view data columns.
			 * @param {Object} config Customizable duplicates search config.
			 * @protected
			 */
			getDeduplicationViewDataColumns: function(config) {
				var columnNames = this._getDefaultDeduplicationViewColumns();
				var deduplicationColumns = this.getDeduplicationSettings(config);
				this.BPMSoft.each(deduplicationColumns, function(column) {
					if (column.schemaName === this.getDuplicateSchemaName()) {
						columnNames.push(column.columnName);
					}
				}, this);
				return this.Ext.Array.unique(columnNames);
			},

			/**
			 * Returns name of set duplicates service method.
			 * @protected
			 * @virtual
			 * @return {String} Name of service method.
			 */
			getSetDuplicatesServiceMethodName: function() {
				return this.getSetDuplicatesMethodName();
			},

			/**
			 * Returns duplicate search page config.
			 * @returns {Object} Duplicate search page config.
			 */
			getDuplicateSearchPageConfig: function() {
				var params = this.sandbox.publish("GetHistoryState") || {};
				return {
					hash: params.hash && params.hash.historyState,
					stateObj: {
						cardSandBoxId: this.sandbox.id
					}
				};
			},

			/**
			 * Loads deduplication module.
			 * @protected
			 * @virtual
			 */
			loadLocalDuplicateSearchPage: function() {
				var moduleId = this.getDuplicateSearchPageId();
				this.sandbox.publish("PushHistoryState", this.getDuplicateSearchPageConfig());
				var moduleName = "BaseSchemaModuleV2";
				var loadModuleConfig = {
					renderTo: "centerPanel",
					id: moduleId,
					keepAlive: true
				};
				Ext.apply(loadModuleConfig, {
					instanceConfig: {
						generateViewContainerId: false,
						useHistoryState: false,
						schemaName: "LocalDuplicateSearchPageV2",
						isSchemaConfigInitialized: true
					}
				});
				this.sandbox.loadModule(moduleName, loadModuleConfig);
			},

			/**
			 * Returns communication option array.
			 * @virtual
			 * @param {Object} config Customizable duplicates search config.
			 * @return {Array} Communication option array.
			 */
			getCommunications: function(config) {
				try {
					var communicationDetailName = this.get("CommunicationDetailName");
					var detailId = this.getDetailId(communicationDetailName);
					var communications;
					if	(config && config.isGetCommunicationsFromDb) {
						communications = this.$DBCommunications;
					} else {
						communications = this.sandbox.publish("GetCommunicationsList", null,
							[detailId]);
					}
					return this.BPMSoft.map(communications, function(item) {
						var type = item.CommunicationType;
						var communicationType = type && type.value || type;
						return {
							"Id": item.Id,
							"Number": item.Number,
							"CommunicationTypeId": communicationType,
							"CommunicationId": type && type.communicationValue
						};
					});
				} catch (e) {
					this.log("DuplicateSearchUtilities. getCommunications failed",
						this.BPMSoft.LogMessageType.INFORMATION);
					return [];
				}
			},

			/**
			 * Returns active duplicates rules.
			 * @returns {Object[]} Active duplicates rules on save.
			 * @param {Object} config Customizable duplicates search config.
			 */
			getDeduplicationSettings: function(config) {
				const rules = this._getEntityDeduplicationRules(config);
				if (config && config.findByActiveRules) {
					return rules.IsActive ? rules.DeduplicationColumns : [];
				} else {
					return rules.UseAtSave ? rules.DeduplicationColumns : [];
				}
			},

			/**
			 * Returns rule filters with value.
			 * @protected
			 * @param {Object} config Customizable duplicates search config.
			 * @returns {Object[]} Rule filters with value.
			 */
			getDeduplicationModel: function(config) {
				var modelColumns = [];
				var deduplicationColumns = this.getDeduplicationSettings(config);
				BPMSoft.each(deduplicationColumns, function(column) {
					var modelColumn = this.BPMSoft.deepClone(column);
					modelColumn.value = this.getFilterValue(column, config);
					delete modelColumn.rootSchemaColumns;
					modelColumns.push(modelColumn);
				}, this);
				return modelColumns;
			},

			/**
			 * Returns duplicate rule filter value.
			 * @protected
			 * @param {Object} filter Duplicate rule filter config.
			 * @param {Object} config Customizable duplicates search config.
			 * @returns {String[]} Duplicate rule filter value.
			 */
			getFilterValue: function(filter, config) {
				if (this.Ext.Array.contains(this._communicationSchemaNames, filter.schemaName)) {
					return this._getCommunicationFilterValues(filter, config);
				}
				if (this.getDuplicateSchemaName() !== filter.schemaName) {
					return this._getDetailFilterValues(filter);
				}
				var value = this.get(filter.columnName) || null;
				return [value && value.value || value];
			},

			/**
			 * Returns root search duplicate schema name.
			 * @returns {String} Root search duplicate schema name.
			 * @protected
			 */
			getDuplicateSchemaName: function() {
				return this.entitySchemaName;
			},

			/**
			 * Method to define is deduplication is enabled on entity save.
			 * Returns true if there is at least one active rule on entity schema save.
			 * @virtual
			 */
			getIsEntityDeduplicationEnabled: function() {
				var activeRules = this.getDeduplicationSettings();
				return !Ext.isEmpty(activeRules);
			},

			/**
			 * Returns detail duplicate rule values.
			 * @param {BPMSoft.BaseViewModelCollection} detailGridData Detail grid data.
			 * @param {String} detailEntitySchemaName Detail entity schema name.
			 * @returns {Object} Detail duplicate rule values.
			 */
			getDuplicateDetailRuleValues: function(detailGridData, detailEntitySchemaName) {
				if (!this.getIsFeatureEnabled("ESDeduplication")) {
					return null;
				}
				const duplicateDetailColumns = this._getDuplicateRuleDetailColumns(detailEntitySchemaName);
				if (this.Ext.isEmpty(duplicateDetailColumns)) {
					return null;
				}
				const duplicateDetailRuleValues = {};
				this.BPMSoft.each(this.Ext.Array.unique(duplicateDetailColumns), function(column) {
					duplicateDetailRuleValues[column] = [];
					this.BPMSoft.each(detailGridData, function(item) {
						let value = item.get(column);
						value = value && value.displayValue || value;
						if (value && !this.Ext.Array.contains(duplicateDetailRuleValues[column], value)) {
							duplicateDetailRuleValues[column].push(value);
						}
					}, this);
				}, this);
				return duplicateDetailRuleValues;
			},

			/**
			 * Gets deduplication rules.
			 * @private
			 * @param {Object} config Customizable duplicates search config.
			 * @return {{IsActive: Boolean, DeduplicationColumns: Array, UseAtSave: Boolean, SchemaName: String} | {}}
			 */
			_getEntityDeduplicationRules: function(config) {
				var schemaNamePrefix = BPMSoft.emptyString;
				if (config && config.findByActiveRules && config.duplicationSettingsSchemaNamePrefix) {
					schemaNamePrefix = config.duplicationSettingsSchemaNamePrefix;
				}
				const deduplicationSettings = BPMSoft.configuration.DeduplicationSettings || {};
				var key = Ext.String.format("{0}{1}", schemaNamePrefix, this.getDuplicateSchemaName());
				const deduplicationRules = deduplicationSettings[key];
				return deduplicationRules || {};
			},

			/**
			 * Fetch user permission of the 'CanSearchDuplicates' operation.
			 * @protected
			 * @return {Promise<Boolean>} True if user has 'CanSearchDuplicates' operation permission.
			 */
			fetchCanDeduplicationOperationPermission: function() {
				return new Promise(function(resolve) {
					const featuresEnabled = this.getIsDeduplicationEnable();
					if (!featuresEnabled) {
						return resolve(false);
					}
					RightUtilities.checkCanExecuteOperation({operation: "CanSearchDuplicates"}, resolve, this);
				}.bind(this));
			},

			/**
			 * Returns true if feature 'Deduplication' is enabled.
			 * @protected
			 * @returns {Boolean} True if feature 'Deduplication' is enabled.
			 */
			getIsDeduplicationEnable: function() {
				return this.BPMSoft.Features.getIsEnabled("Deduplication");
			},

			/**
			 * Returns true if features 'BulkESDeduplication', 'Deduplication' is enabled and
			 * section has active search rules and user has permission.
			 * @protected
			 * @returns {Boolean} True if bulk deduplication is enabled.
			 */
			getIsBulkDeduplicationEnabled: function() {
				const deduplicationEnable = this.getIsDeduplicationEnable();
				const isActiveBulkDeduplicationRules = this.isActiveBulkDeduplicationRules();
				const bulkEnabled = isActiveBulkDeduplicationRules
					&& BPMSoft.Features.getIsEnabled("BulkESDeduplication")
					&& BPMSoft.Features.getIsEnabled("GlobalSearch_V2");
				return deduplicationEnable && bulkEnabled;
			},
			
			/**
			 * Returns true if section has active bulk search rules.
			 * @protected
			 * @returns {boolean} True if bulk deduplication rules is enabled for section.
			 */
			isActiveBulkDeduplicationRules: function() {
				const deduplicationRules = this._getEntityDeduplicationRules();
				return Boolean(deduplicationRules.IsActive);
			}
		});
		return Ext.create("BPMSoft.DuplicatesSearchUtilitiesV2");
	});
