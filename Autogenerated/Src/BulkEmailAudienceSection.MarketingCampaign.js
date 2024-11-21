define("BulkEmailAudienceSection", ["BulkEmailAudienceSectionResources", "ConfigurationEnums"],
	function(resources, ConfigurationEnums) {
		return {
			entitySchemaName: "VwBulkEmailAudience",
			properties: {
				masterRecordEntitySchemaName: "BulkEmail"
			},
			attributes: {
				/**
				 * Lookup for DuplicateType.
				 */
				"DuplicateType": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Values collection of lookup for DuplicateType.
				 */
				"DuplicateTypeCollection": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Ext.create("BPMSoft.Collection")
				},

				/**
				 * Values of lookup for DuplicateType.
				 */
				"DuplicateTypeEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Default: {
							value: 0,
							caption: "Resources.Strings.DuplicateTypeDefault"
						},
						Email: {
							value: 1,
							caption: "Resources.Strings.DuplicateTypeEmail"
						},
						Contact: {
							value: 2,
							caption: "Resources.Strings.DuplicateTypeContact"
						}
					}
				}
			},
			methods: {
				/**
				 * @private
				 */
				_initAudienceSchemaName: function() {
					var historyState = this.sandbox.publish("GetHistoryState");
					if (historyState && historyState.state && historyState.hash) {
						this.audienceSchemaName = historyState.state.audienceSchemaName || historyState.hash.operationType;
						this.audienceSchema = BPMSoft.EntitySchemaManager.findItemByName(this.audienceSchemaName);
						this.entitySchema.columns.LinkedEntity.referenceSchemaName = this.audienceSchemaName;
						this.entitySchema.columns.LinkedEntity.referenceSchema = this.audienceSchema;
					}
				},

				/**
				 * Handles change of the "DuplicateType" property.
				 * @private
				 */
				_onDuplicateTypeLookupChanged: function(model, value, event) {
					if (Ext.isEmpty(value)) {
						var defaultValue = this.$DuplicateTypeCollection.getByIndex(0);
						this.set("DuplicateType", defaultValue, { silent: true });
					}
					this.onFilterUpdate();
				},

				/**
				 * @private
				 */
				_initDuplicateTypeLookup: function() {
					var collection = Ext.create("BPMSoft.Collection");
					BPMSoft.each(this.$DuplicateTypeEnum, function(item) {
						if (this.$DuplicateTypeEnum.hasOwnProperty(this.audienceSchemaName)
								&& this.$DuplicateTypeEnum[this.audienceSchemaName].value === item.value) {
							return;
						}
						collection.add(item.value, {
							value: item.value,
							displayValue: this.get(item.caption)
						});
					}, this);
					this.$DuplicateTypeCollection.reloadAll(collection);
					this.set("DuplicateType", collection.getByIndex(0), { silent: true });
					this.on("change:DuplicateType", this._onDuplicateTypeLookupChanged, this);
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#init
				* @override
				*/
				init: function() {
					this._initAudienceSchemaName();
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#initSection
				 * @override
				 */
				initSection: function() {
					this.callParent(arguments);
					this._initDuplicateTypeLookup();
				},

				/**
				 * Returns config for service to load audience.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query to filter audience.
				 * @returns {Object} Config.
				*/
				getSelectAudienceConfig: function(esq) {
					return {
						serviceName: "BulkEmailAudience",
						methodName: "SelectAudience",
						data: {
							BulkEmailId: this.$RecordId,
							DuplicateType: this.$DuplicateType.value,
							EsqSerialized: esq.serialize(),
							LinkedEntitySchemaName: this.audienceSchemaName
						}
					};
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getEntityCollection
				 * @override
				 */
				getEntityCollection: function(esq, callback, scope) {
					var config = this.getSelectAudienceConfig(esq);
					this.callService(config, function(response) {
						esq.parseResponse({
							rowConfig: JSON.parse(response.RowConfig),
							rows: JSON.parse(response.Rows),
							rowsAffected: response.RowsAffected,
							success: response.Success
						}, callback, scope);
					}, scope);
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#linkClicked
				 * @override
				 */
				linkClicked: function(recordId, columnName) {
					var result;
					if (columnName === "LinkedEntity") {
						var row = this.$GridData.get(recordId);
						var linkedEntity = row.get(columnName);
						var historyState = this.sandbox.publish("GetHistoryState");
						this.mixins.NetworkUtilities.openCardInChain({
							sandbox: this.sandbox,
							entitySchemaName: this.audienceSchemaName,
							operation: ConfigurationEnums.CardStateV2.EDIT,
							primaryColumnValue: linkedEntity.value,
							entitySchemaUId: this.audienceSchema,
							historyState: historyState
						});
						result = false;
					} else {
						result = this.callParent(arguments);
					}
					this.set("IsSectionVisible", false);
					this.saveSectionVisibleStateToProfile(false);
					this.hideSection();
					return result;
				},

				/**
				 * Returns specific config for bulk email audience service to provide remove audience action.
				 * @protected
				 * @param {Number} sourceType Source type for remove action.
				 * @param {Array} sourceCollection Source data collection to remove.
				 * @param {Number} estimatedCount Estimated records count to remove.
				 * @param {String} esqSerialized Serialized esq to filter records for remove.
				 * @returns {Object}
				 */
				getRemoveAudienceConfig: function(sourceType, sourceCollection, estimatedCount, esqSerialized) {
					return {
						serviceName: "BulkEmailAudience",
						methodName: "Remove",
						data: {
							BulkEmailId: this.$RecordId,
							SourceCollection: sourceCollection || [],
							EstimatedEntitiesCount: estimatedCount || 0,
							SourceType: sourceType,
							EsqSerialized: esqSerialized,
							DuplicateType: this.$DuplicateType.value
						}
					};
				},

				/**
				 * Loads values into grouping mode combobox.
				 * @protected
				 * @param {Object} filter ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				onPrepareDuplicateTypeList: function(filter, list) {
					list.reloadAll(this.$DuplicateTypeCollection);
				},

				/**
				 * Handler on WebSocket channel message received event.
				 * @inheritdoc BPMSoft.BaseManageAudienceSection#onChannelMessageReceived
				 * @override
				 */
				onChannelMessageReceived: function(channel, message) {
					if (message.Header.Sender !== "BulkEmailNotifier") {
						return;
					}
					var messageBody = BPMSoft.decode(message.Body);
					if (messageBody.BulkEmailId === this.$RecordId) {
						this.updateSection();
					}
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "DuplicateTypeContainer",
					"parentName": "LeftGridUtilsContainer",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["filters-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "DuplicateType",
					"parentName": "DuplicateTypeContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": "$onPrepareDuplicateTypeList"
						},
						"isRequired": true,
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				}
			]
		};
	}
);
