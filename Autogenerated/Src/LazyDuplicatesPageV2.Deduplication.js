 define("LazyDuplicatesPageV2", ["InformationButtonResources", "css!LazyDuplicatesPageCSS",
	 "LazyDuplicatesDetailViewConfig", "LazyDuplicatesDetailViewModel"], function(informationButtonResources) {
	return {
		entitySchemaName: "DuplicatesRule",
		mixins: {},
		attributes: {
			
			/**
			 * Count of default loaded duplicates per group.
			 * @protected
			 */
			"TopDuplicatesPerGroup": {
				"value": 5,
				"dataValueType": BPMSoft.DataValueType.INTEGER
			},
			/**
			 * Loaded groups count per page.
			 * @protected
			 */
			"DuplicatesPageRowCount": {
				"value": 10,
				"dataValueType": BPMSoft.DataValueType.INTEGER
			},
			/**
			 * Grid row columns configuration.
			 * @protected
			 */
			"RowConfig": {
				"value": null,
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Is success run of duplicates search.
			 * @protected
			 */
			"IsSuccess": {
				"value": true,
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Is first run of duplicates search.
			 * @protected
			 */
			"IsFirstRun": {
				"value": false,
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Duplicates search process label text.
			 * @protected
			 */
			"ProcessedPercentCaption": {
				"value": "",
				"dataValueType": BPMSoft.DataValueType.TEXT
			},
			/**
			 * Maximum duplicates row per record.
			 * @protected
			 */
			"MaxDuplicatesPerRecord": {
				"value": 0,
				"dataValueType": BPMSoft.DataValueType.INTEGER
			},
		},
		messages: {
			/**
			 * @message FetchGroupData
			 * Fetch group duplicates.
			 * @param {Object} config Load group data config.
			 * @param {String} config.groupId Group id.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function scope.
			 */
			"FetchGroupData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDuplicatesDetailModuleRootContainerId: function () {
				return Ext.String.format("Lazy{0}", this.callParent(arguments));
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			loadDuplicatesDetailModule: function(id, rootItem, rows, group) {
				this.callParent(arguments);
				const detailId = this.getDuplicatesDetailModuleId(id);
				this.sandbox.subscribe("FetchGroupData", this.onFetchGroupData, this, [detailId]);
			},
			
			/**
			 * FetchGroupData message handler.
			 * @param {Object} config Load group data config.
			 * @param {String} config.groupId Group id.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function scope.
			 */
			onFetchGroupData: function(config) {
				BPMSoft.DeduplicationStorage.fetchDuplicatesByGroup({
					"groupId": config.groupId,
					"entityName": this.getDuplicatesSchemaName(),
					"columns": this.getDuplicatesColumns()
				}, function (response) {
					const groupRows = this.groupOfDuplicatesToViewModelCollection(response.rows,
							this.$RowConfig);
					this.prepareResponseCollection(groupRows);
					Ext.callback(config.callback, config.scope, [groupRows]);
				}, this);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDuplicatesGroupDetailConfig: function(groupId, rootItem, group) {
				return Ext.apply(this.callParent(arguments), {
					topDuplicatesPerGroup: this.$TopDuplicatesPerGroup,
					maxDuplicatesPerRecord: this.$MaxDuplicatesPerRecord,
					count: group.duplicatesCount,
				});
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getBulkESDeduplicationResults: function() {
				if (this.$NextDuplicatesGroupOffset === -1) {
					return;
				}
				this.showBodyMask();
				const filters = this.getCustomFiltersGroup();
				var config = {
					"entityName": this.getDuplicatesSchemaName(),
					"columns": this.getDuplicatesColumns(),
					"offset": this.$NextDuplicatesGroupOffset,
					"count": this.$DuplicatesPageRowCount,
					"topDuplicatesPerGroup": this.$TopDuplicatesPerGroup,
					"filters": filters.serialize()
				};
				BPMSoft.DeduplicationStorage.fetchGroupOfDuplicates(config, function(result) {
					this.processDeduplicationResults(result);
				}, this);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			processDeduplicationResults: function(result) {
				this.$RowConfig = result.rowConfig;
				this.callParent(arguments);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getRootDuplicateViewModel: function(group) {
				var entityCollection = this.groupOfDuplicatesToViewModelCollection([group.sourceEntity], this.$RowConfig);
				return entityCollection.first();
			},

			getCheckImage: function() {
				var image = this.get("Resources.Images.CheckImage");
				return BPMSoft.ImageUrlBuilder.getUrl(image);
			},
			сheckImageVisible: function() {
				return this.$ProcessedPercentCaption !== "";
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			bulkDeduplicationInfoCallbackHandler: function(deduplicationInfo) {
				this.$IsSuccess = deduplicationInfo.isSuccess;
				this.$IsFirstRun = deduplicationInfo.isFirstRun;
				const messageTemplate = deduplicationInfo.processedPercent >= 100
						? this.get("Resources.Strings.FinishedDuplcatesSearchMsgTpl")
						: this.get("Resources.Strings.FinishedDuplcatesSearchMsgTpl");
				this.$ProcessedPercentCaption = Ext.String.format(messageTemplate, deduplicationInfo.processedPercent);
				this.$MaxDuplicatesPerRecord = deduplicationInfo.maxDuplicatesPerRecord;
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			hideItems: function() {
				this.callParent(arguments);
				this.$ProcessedPercentCaption = BPMSoft.emptyString;
				this.$IsSuccess = true;
			},
			
			/**
			 * Returns is duplicates search is not success.
			 * @returns {Boolean} Is duplicates search is not success.
			 */
			isUnsuccessDuplicatesSearch: function() {
				return !this.$IsSuccess && !this.$IsFirstRun;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["card-content-container", "duplicates-content-wrap", "lazy-duplicates-page"]
				}
			},
			{
				"operation": "insert",
				"name": "DuplicateContainerLabel",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["duplicate-container"]
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
				},
				"index": 10
			},
			{
				"operation": "insert",
				"name": "CheckImage",
				"parentName": "DuplicateContainerLabel",
				"propertyName": "items",
				"values": {
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
					"onPhotoChange": BPMSoft.emptyFn,
					"getSrcMethod": "getCheckImage",
					"classes": {
						"wrapClass": ["duplicate-container-image"]
					},
					"visible": {
						"bindTo": "сheckImageVisible",
					},
				}
			},
			{
				"operation": "insert",
				"name": "DeduplicationProcessLabel",
				"parentName": "DuplicateContainerLabel",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["deduplication-process-label"]
					},
					"caption": { "bindTo": "ProcessedPercentCaption" },
					"visible": {
						"bindTo": "IsFirstRun",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					},
				}
			},
			{
				"operation": "insert",
				"name": "ErrorInfoButton",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "Resources.Strings.DuplicatesSearchErrorMsg"},
					"style": BPMSoft.TipStyle.RED,
					"controlConfig": {
						"imageConfig": informationButtonResources.localizableImages.WarningIcon,
						"visible": {
							"bindTo": "isUnsuccessDuplicatesSearch"
						}
					}
				},
				"index": 11
			}
		]/**SCHEMA_DIFF*/
	};
});
