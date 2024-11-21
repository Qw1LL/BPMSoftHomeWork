define("BulkEmailHyperlinkDetailV2", ["css!BulkEmailHyperlinkDetailV2CSS"],
	function() {
		return {
			entitySchemaName: "BulkEmailHyperlink",
			messages: {

				/**
				 * @message GetReplicaRepository
				 * Requests the instance of replica repository from master page.
				 */
				"GetReplicaRepository": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateExtendedFilter
				 * Updates extended filter.
				 */
				"UpdateExtendedFilter": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateExtendedFilterValues
				 * Updates extended filter values.
				 */
				"UpdateExtendedFilterValues": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				"Caption": {
					type: this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					name: "Caption",
					columnPath: "Caption",
					dataValueType: this.BPMSoft.DataValueType.TEXT
				},
				"ReplicaList": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},
				"ReplicaFilter": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},
				"ReplicaRepository": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
				},
				"IsGroupingApplied": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				}
			},
			methods: {

				// region Methods: Private

				/**
				 * @private
				 */
				_onGroupingLabelClick: function() {
					this.$IsGroupingApplied = !this.$IsGroupingApplied;
					this.reloadGridData();
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridDataColumns
				 * @override
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns.Url = gridDataColumns.Url || {
						path: "Url"
					};
					gridDataColumns.ClicksCount = gridDataColumns.ClicksCount || {
						path: "ClicksCount"
					};
					return gridDataColumns;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @override
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @override
				 */
				getDeleteRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @override
				 */
				getSwitchGridModeMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getFilters
				 * @override
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					if (this.$ReplicaFilter) {
						filters.add("replicaFilter", this.$ReplicaFilter);
					}
					return filters;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#updateDetail
				 * @override
				 */
				updateDetail: function(config) {
					if (config.reloadAll) {
						var detailInfo = this.getDetailInfo();
						this.set("MasterRecordId", detailInfo.masterRecordId);
						this.initReplicaList();
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#initData
				 * @override
				 */
				initData: function(callback, scope) {
					this.callParent([function() {
						this.initReplicaList(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var sandbox = this.sandbox;
					var replicaFilterModuleId = this.getReplicaFilterModuleId();
					sandbox.subscribe("GetModuleSchema", this.getReplicaFilterModuleSchemaConfig, this, [replicaFilterModuleId]);
					sandbox.subscribe("GetExtendedFilterConfig", this.getReplicaExtendedFilterConfig, this, [replicaFilterModuleId]);
					sandbox.subscribe("UpdateFilter", this.onReplicaFilterUpdate, this, [replicaFilterModuleId]);
				},

				/**
				 * Returns replica filter module identifier.
				 * @protected
				 * @return {String} Replica filter module identifier.
				 */
				getReplicaFilterModuleId: function() {
					return this.sandbox.id + "_QuickFilterModuleV2_ReplicaFilter";
				},

				/**
				 * Loads replica filter module.
				 * @protected
				 */
				loadReplicaFilterModule: function() {
					if (!this.getReplicaFilterModuleContainerVisible()) {
						return;
					}
					var sandbox = this.sandbox;
					var replicaFilterModuleId = this.getReplicaFilterModuleId();
					var args = {
						renderTo: "ReplicaFilterModuleContainer"
					};
					var rendered = sandbox.publish("RerenderQuickFilterModule", args, [replicaFilterModuleId]);
					if (rendered) {
						return;
					}
					sandbox.loadModule("QuickFilterModuleV2", {
						renderTo: args.renderTo,
						id: replicaFilterModuleId,
						instanceConfig: {
							moduleConfig: {
								CustomFilters: {
									viewConfigModuleName: "CustomFilterViewV2",
									viewModelConfigModuleName: "CustomFilterViewModelV2",
									configPropertyName: "customFilterConfig"
								}
							}
						}
					});
				},

				/**
				 * Returns replica filter module schema config.
				 * @protected
				 * @return {Object} Replica filter module schema config.
				 */
				getReplicaFilterModuleSchemaConfig: function() {
					return {
						entitySchema: this.Ext.create("BPMSoft.BaseEntitySchema", {
							columns: {
								DCReplica: {
									name: "DCReplica",
									dataValueType: this.BPMSoft.DataValueType.LOOKUP
								}
							}
						}),
						filterDefaultColumnName: "DCReplica",
						isShortFilterVisible: true
					};
				},

				/**
				 * Returns replica extended filter config.
				 * @protected
				 * @return {Object} Replica extended filter config.
				 */
				getReplicaExtendedFilterConfig: function() {
					return {
						filterIcon: this.get("Resources.Images.ReplicaFilterButtonImage"),
						showButtonCaption: true,
						values: {
							buttonCaption: this.get("Resources.Strings.ReplicaExtendedFilterButtonCaption"),
							columnEditVisible: false,
							showSelectedColumnCaption: false,
							filterProposedColumnValue: this.$ReplicaList,
							useSingleColumnFilter: true
						}
					};
				},

				/**
				 * Handles when replica filter was updated.
				 * @protected
				 * @param {Object} filters Filters.
				 */
				onReplicaFilterUpdate: function(filters) {
					var replica = filters && filters.filtersValue && filters.filtersValue.DCReplica;
					if (this.Ext.isEmpty(this.$ReplicaFilter) && !replica) {
						return;
					}
					if (replica) {
						var replicaMask;
						var replicaId = replica.value;
						if (this.BPMSoft.isGUID(replicaId)) {
							replicaMask = this.$ReplicaList[replicaId].mask;
						} else {
							return;
						}
						this.$ReplicaFilter = BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"BpmReplicaMask",
							replicaMask);
					} else {
						this.$ReplicaFilter = null;
					}
					this.reloadGridData();
				},

				/**
				 * Initializes replica repository of detail.
				 */
				initReplicaRepository: function() {
					var sandbox = this.sandbox;
					var repository = sandbox.publish("GetReplicaRepository", [], [sandbox.id]);
					if (!repository) {
						repository = Ext.create("BPMSoft.DCTemplateReplicaRepository");
						repository.init(this.$MasterRecordId);
					}
					this.$ReplicaRepository = repository;
				},

				/**
				 * Prepares replica list.
				 * @protected
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The context in which the callback function will be called.
				 */
				prepareReplicaList: function(callback, scope) {
					this.$ReplicaRepository.loadSent(function(replicas) {
						var newList;
						if (replicas) {
							newList = {};
							this.BPMSoft.each(replicas, function(replica) {
								newList[replica.Id] = {
									value: replica.Id,
									mask: replica.Mask,
									displayValue: replica.Name
								};
							}, this);
						}
						this.$ReplicaList = newList;
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Initializes replica list.
				 * @protected
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The context in which the callback function will be called.
				 */
				initReplicaList: function(callback, scope) {
					var sandbox = this.sandbox;
					var replicaFilterModuleId = this.getReplicaFilterModuleId();
					this.$ReplicaFilter = null;
					this.$ReplicaRepository = null;
					sandbox.publish("UpdateExtendedFilter", {
						value: "",
						displayValue: ""
					}, [replicaFilterModuleId]);
					this.initReplicaRepository();
					this.prepareReplicaList(function() {
						if (!this.BPMSoft.isEmptyObject(this.$ReplicaList)) {
							var replicaExtendedFilterConfig = this.getReplicaExtendedFilterConfig() || {};
							sandbox.publish("UpdateExtendedFilterValues", replicaExtendedFilterConfig.values, [replicaFilterModuleId]);
						}
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * Removes tracking parameters from link.
				 * @protected
				 * @param {BPMSoft.BaseViewModelCollection} linkCollection Links collection to process.
				 */
				removeQueryExtraParameters: function(linkCollection) {
					var queryParams = ["bpmtrackid", "bpmreplica"];
					this.BPMSoft.each(linkCollection, function(collectionItem) {
						var encodedLink = this.BPMSoft.encodeQueryParameters(collectionItem.$Url);
						var link = this.BPMSoft.removeQueryParameters(encodedLink, queryParams);
						collectionItem.$Url = decodeURIComponent(link);
					}, this);
				},

				/**
				 * Groups links by URL.
				 * @protected
				 * @param {Array} linkCollection Links collection to process.
				 */
				groupLinksByUrl: function(linkCollection) {
					var aggregatedCollection = [];
					var groups = this.BPMSoft.groupBy(linkCollection, function(item) {
						return item.$Url;
					});
					this.BPMSoft.each(groups, function(groupItem) {
						var aggregatedItem = groupItem.reduce(function(total, currentItem) {
							total.$ClicksCount += currentItem.$ClicksCount;
							return total;
						});
						aggregatedCollection.push(aggregatedItem);
					});
					return aggregatedCollection;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#updateLoadedGridData
				 * @overridden
				 */
				updateLoadedGridData: function(response, callback, scope) {
					var linksCollection = response.collection;
					this.removeQueryExtraParameters(linksCollection);
					if (this.$IsGroupingApplied) {
						var modifiedLinksArray = this.groupLinksByUrl(linksCollection.getItems());
						linksCollection.clear();
						linksCollection.loadAll(modifiedLinksArray);
					}
					callback.call(scope, response);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#initQueryOptions
				 * @overridden
				 */
				initQueryOptions: function(esq) {
					if (this.$IsGroupingApplied) {
						esq.rowCount = -1;
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc GridUtilitiesV2#initCanLoadMoreData
				 * @overridden
				 */
				initCanLoadMoreData: function() {
					if (this.$IsGroupingApplied) {
						this.set("CanLoadMoreData", false);
					} else {
						this.callParent(arguments);
					}
				},

				// endregion

				// region Methods: Public

				/**
				 * Returns replica filter module container visibility.
				 * @return {Boolean}
				 */
				getReplicaFilterModuleContainerVisible: function() {
					var replicaList = this.$ReplicaList;
					return this.getIsFeatureEnabled("BulkEmailDynamicContentBuilder") && this.getToolsVisible() &&
						!this.BPMSoft.isEmptyObject(replicaList) && Object.keys(replicaList).length > 1;
				},

				/**
				 * Returns grouping checkbox visibility.
				 * @return {Boolean}
				 */
				getGroupingCheckboxVisible: function() {
					return this.getIsFeatureEnabled("BulkEmailDynamicContentBuilder") && this.getToolsVisible();
				}

				// endregion

			},
			diff: [{
				"operation": "remove",
				"name": "AddRecordButton"
			},
				{
					"name":"IsGroupingApplied",
					"operation":"insert",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"labelConfig": {"visible": false},
						"dataValueType": BPMSoft.DataValueType.BOOLEAN,
						"click": {
							"bindTo": "reloadGridData"
						},
						"classes": {
							"wrapClassName": ["grouping-ckeckbox"]
						},
						"visible": {
							"bindTo": "getGroupingCheckboxVisible"
						}
					}
				},
				{
					"name":"GroupingLabel",
					"operation":"insert",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.ApplyGroupingCaption"
						},
						"classes": {
							"labelClass": ["grouping-ckeckbox-label"]
						},
						"visible": {
							"bindTo": "getGroupingCheckboxVisible"
						},
						"click": {
							"bindTo": "_onGroupingLabelClick"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Detail",
					"propertyName": "tools",
					"name": "ReplicaFilterButton",
					"values": {
						"id": "ReplicaFilterModuleContainer",
						"selectors": {
							"wrapEl": "#ReplicaFilterModuleContainer"
						},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["replica-filter-container", "detail-filter-container-style"],
						"items": [],
						"visible": {
							"bindTo": "getReplicaFilterModuleContainerVisible"
						},
						"afterrender": {
							"bindTo": "loadReplicaFilterModule"
						},
						"afterrerender": {
							"bindTo": "loadReplicaFilterModule"
						}
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [{
								"name": "CaptionListedGridColumn",
								"bindTo": "Caption",
								"position": {
									"column": 1,
									"colSpan": 8
								}
							},
								{
									"name": "UrlListedGridColumn",
									"bindTo": "Url",
									"position": {
										"column": 9,
										"column": 13
									}
								},
								{
									"name": "ClicksCountListedGridColumn",
									"bindTo": "ClicksCount",
									"position": {
										"column": 22,
										"colSpan": 3
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 2
							},
							"items": [{
								"name": "ContactTiledGridColumn",
								"bindTo": "Caption",
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 20
								},
								"type": this.BPMSoft.GridCellType.TITLE
							},
								{
									"name": "EmailAddressTiledGridColumn",
									"bindTo": "ClicksCount",
									"position": {
										"row": 1,
										"column": 21,
										"colSpan": 4
									}
								},
								{
									"name": "ResponseTiledGridColumn",
									"bindTo": "Url",
									"position": {
										"row": 2,
										"column": 1,
										"colSpan": 24
									}
								}
							]
						}
					}
				}
			]
		};
	});