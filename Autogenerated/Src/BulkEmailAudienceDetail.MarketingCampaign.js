define("BulkEmailAudienceDetail", ["BulkEmailAudienceDetailResources", "ConfigurationEnums", "MarketingEnums",
	"BulkEmailHelper", "VwMandrillRecipientDetailV2", ],
	function(resources, ConfigurationEnums, MarketingEnums, BulkEmailHelper) {
			return {
				entitySchemaName: "VwBulkEmailAudience",
				properties: {
					importSectionHashPattern: "AudienceSectionModule/ImportBulkEmailAudienceSection/{0}/{1}",
					manageAudienceHashPattern: "AudienceSectionModule/BulkEmailAudienceSection/{0}",
					masterRecordEntitySchemaName: "BulkEmail",
					/**
					 * Unique identifier of audience schema by default (Contact).
					 * @type {String}
					 */
					defaultAudienceSchemaId: "2db96695-3d62-40e4-9f31-2f1fff23eefb",
					/**
					 * Types of bulk email queue messages.
					 * @type {Object}
					 */
					queueMessageTypes: {
						removeAllAudience: 2
					}
				},
				attributes: {
					/**
					 * Collection of schemas to import audience by.
					 * @type {BPMSoft.BaseViewModelCollection}
					 */
					"AudienceSchemaCollection": {
						dataValueType: BPMSoft.DataValueType.COLLECTION,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true,
						value: Ext.create("BPMSoft.BaseViewModelCollection")
					},

					/**
					 * Name of current bulk email.
					 * @type {String}
					 */
					"BulkEmailName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Name of audience sysSchema.
					 * @type {String}
					 */
					"AudienceSysSchemaName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},

					/**
					 * Bulk email audience schema to import.
					 * @type {String}
					 */
					"AudienceSchema": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: null
					},

					/**
					 * Unique identifier of bulk email audience schema to import.
					 * @type {String}
					 */
					"SelectedAudienceSchemaId": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: null
					},

					/**
					 * Caption for detail.
					 * @type {String}
					 */
					"DetailCaption": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				messages: {
					/**
					 * @message GetBulkEmailImportAudienceData
					 * @return {String} Current bulk email audience data.
					 */
					"GetBulkEmailImportAudienceData": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message ReloadBulkEmailQueueState
					 */
					"ReloadBulkEmailQueueState": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					},
					/**
					 * @message ResetAudienceSchema
					 */
					"ResetAudienceSchema": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {
					/**
					 * @private
					 */
					_getImageConfigFromSysImage: function(sysImage) {
						if (!Ext.isEmpty(sysImage)) {
							return {
								source: BPMSoft.ImageSources.SYS_IMAGE,
								params: { primaryColumnValue: sysImage.value }
							};
						}
						return this.get("Resources.Images.DefaultAudienceSchemaImage");
					},

					/**
					 * @private
					 */
					_getImportAudienceData: function() {
						var importAudienceData = this.sandbox.publish("GetBulkEmailImportAudienceData");
						var audienceSchema = this.$AudienceSchemaCollection.findByFn(function(schema) {
							return schema.$Id === importAudienceData.audienceSchemaId;
						});
						return {
							audienceSchema: audienceSchema,
							bulkEmailName: importAudienceData.bulkEmailName
						};
					},

					/**
					 * @private
					 */
					_loadEntitySchemaNameByUId: function(uId, callback, scope) {
						BPMSoft.EntitySchemaManager.findItemByUId(uId, function(schema) {
							var schemaName = schema && schema.name;
							this.$AudienceSysSchemaName = schemaName;
							this._actualizeDetailCaption(schema);
							callback.call(scope, schemaName);
						}, this);
					},

					/**
					 * @private
					 */
					_isCurrentAudienceSchema: function(audienceSchemaId) {
						if (!this.$AudienceSchema) {
							return true;
						}
						return this.$AudienceSchema.$Id === audienceSchemaId;
					},

					/**
					 * @private
					 */
					_initImportAudienceData: function() {
						var importAudienceData = this._getImportAudienceData();
						if (importAudienceData) {
							this.$BulkEmailName = importAudienceData.bulkEmailName;
							this.$AudienceSchema = importAudienceData.audienceSchema;
						}
					},

					/**
					 * @private
					 */
					_getAudienceSchema: function(audienceSchemaId) {
						return this.$AudienceSchemaCollection.findByFn(function(el) {
							return el.$Id === audienceSchemaId;
						}, this);
					},

					/**
					 * @private
					 */
					_actualizeDetailCaption: function(schema) {
						var caption = resources.localizableStrings.DetailCaption;
						if (schema) {
							caption = Ext.String.format("{0}: {1}", caption, schema.caption);
						}
						this.$DetailCaption = caption;
					},

					/**
					 * @private
					 * @returns {Object} Identifier of bulk email status from BulkEmailPageV2.
					 */
					_getBulkEmailStatus: function() {
						var status = this.sandbox.publish("GetEmailStatus", null, [this.sandbox.id]);
						return status && status.value;
					},

					/**
					 * @private
					 */
					_openObjectManagementPage: function() {
						this.sandbox.publish("PushHistoryState", {
							hash: "LookupSectionModule/BulkEmailAudienceSchemaLookupSection"
						});
					},

					/**
					 * @private
					 */
					_onManageAudienceClick: function() {
						var action = this._openObjectManagementPage.bind(this);
						this.trySaveBeforeAction(action);
					},

					/**
					 * @private
					 */
					_clearAudienceSchema: function() {
						this.$AudienceSchema = null;
						this._actualizeDetailCaption();
						this.sandbox.publish("ResetAudienceSchema");
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetail#onGridDataLoaded
					 * @override
					 */
					onGridDataLoaded: function(response) {
						var parentMethod = this.getParentMethod(this, arguments);
						if (response.collection.getCount() === 0 || !this.$AudienceSchema) {
							parentMethod();
							return;
						}
						this._loadEntitySchemaNameByUId(this.$AudienceSchema.$EntityObject.value, function(schemaName) {
							if (response.success && schemaName) {
								this.columns.LinkedEntity.referenceSchemaName = schemaName;
								var items = response.collection.getItems();
								BPMSoft.each(items, function(item) {
									var linkedEntityColumn = item.columns.LinkedEntity;
									if (linkedEntityColumn) {
										linkedEntityColumn.referenceSchemaName = schemaName;
										item.$LinkedEntity.displayValue = schemaName;
									}
								}, this);
							}
							parentMethod();
						}, this);
					},

					/**
					 * Handler on WebSocket channel message received event.
					 * @protected
					 * @param {BPMSoft.ServerChannel} channel WebSocket channel instance.
					 * @param {Object} message WebSocket message instance.
					 */
					onChannelMessageReceived: function(channel, message) {
						if (message.Header.Sender !== "BulkEmailNotifier") {
							return;
						}
						var messageBody = BPMSoft.decode(message.Body);
						if (messageBody.BulkEmailId === this.$MasterRecordId) {
							if (messageBody.Type === this.queueMessageTypes.removeAllAudience) {
								this._clearAudienceSchema();
							}
							this.updateDetail({});
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetail#linkClicked
					 * @override
					 */
					linkClicked: function(recordId, columnName) {
						if (columnName === "LinkedEntity") {
							var row = this.$Collection.get(recordId);
							var linkedEntity = row.get(columnName);
							this.setLastActiveRow(recordId);
							var historyState = this.sandbox.publish("GetHistoryState");
							this.mixins.NetworkUtilities.openCardInChain({
								sandbox: this.sandbox,
								entitySchemaName: this.$AudienceSysSchemaName,
								operation: ConfigurationEnums.CardStateV2.EDIT,
								primaryColumnValue: linkedEntity.value,
								entitySchemaUId: this.$AudienceSchema.$EntityObject.value,
								historyState: historyState
							});
							return false;
						}
						return this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseDetailV2#updateDetail
					 * @override
					 */
					updateDetail: function() {
						this.callParent(arguments);
						this._initImportAudienceData();
						this.initAddMenuItems();
						this.loadAllRecordsCountAsync();
					},

					/**
					 * Generates query for list of audience schemas.
					 * @protected
					 * @return {BPMSoft.data.queries.EntitySchemaQuery} Query.
					 */
					getAudienceSchemaEsq: function() {
						var esq = new BPMSoft.EntitySchemaQuery("BulkEmailAudienceSchema");
						esq.addColumn("Id");
						esq.addColumn("EntityObject");
						esq.addColumn("DisplayName");
						esq.addColumn("Image");
						var sortColumn = esq.addColumn("CreatedOn");
						sortColumn.orderPosition = 0;
						sortColumn.orderDirection = BPMSoft.OrderDirection.ASC;
						return esq;
					},

					/**
					 * Checks is audience empty async and sets default schema if there is no audience.
					 * @protected
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Context.
					 */
					trySetDefaultSchema: function(callback, scope) {
						var esq = this.getEsqForAllRecordsCount();
						this.getEntityCollection(esq, function(response) {
							if (response.success) {
								var result = response.collection.first();
								var count = result && result.$Count || 0;
								if (count > 0) {
									var defaultAudienceSchema = this._getAudienceSchema(this.defaultAudienceSchemaId);
									this.$AudienceSchema = defaultAudienceSchema;
								}
							}
							callback.call(scope);
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.BaseViewModel#init
					 * @override
					 */
					init: function() {
						var parentInit = this.getParentMethod(this, arguments);
						this.loadAllRecordsCountAsync();
						this._actualizeDetailCaption();
						var esq = this.getAudienceSchemaEsq();
						esq.getEntityCollection(function(response) {
							if (response.success) {
								this.$AudienceSchemaCollection.reloadAll(response.collection);
							}
							this._initImportAudienceData();
							if (!this.$AudienceSchema) {
								this.trySetDefaultSchema(function() {
									parentInit();
								}, this);
							} else {
								parentInit();
							}
						}, this);
					},

					/**
					 * Tries to save bulk email before audience import.
					 * @protected
					 * @param {String} audienceSchemaId Audience schema unique identifier.
					 */
					saveBulkEmailBeforeAudienceImport: function(audienceSchemaId) {
						var audienceSchema = this._getAudienceSchema(audienceSchemaId);
						if (!audienceSchema) {
							return;
						}
						var audienceSysSchemaUId = audienceSchema.$EntityObject.value;
						this.$SelectedAudienceSchemaId = audienceSchemaId;
						BPMSoft.EntitySchemaManager.findItemByUId(audienceSysSchemaUId, function(schema) {
							this.$AudienceSysSchemaName = schema.name;
							var action = this.openImportBulkEmailAudienceSection.bind(this);
							this.trySaveBeforeAction(action);
						}, this);
					},

					/**
					 * Handler on import audience menu button click event.
					 * @protected
					 */
					openImportBulkEmailAudienceSection: function() {
						var hash = Ext.String.format(this.importSectionHashPattern, this.$AudienceSysSchemaName,
							this.$SelectedAudienceSchemaId);
						this.sandbox.publish("PushHistoryState", {
							hash: hash,
							stateObj: {
								recordName: this.get("BulkEmailName"),
								entitySchema: this.get("AudienceSysSchemaName"),
								recordId: this.get("MasterRecordId"),
								audienceSchemaId: this.$SelectedAudienceSchemaId,
								canSaveFilter: false
							}
						});
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#getDeleteAudienceConfig
					 * @override
					 */
					getDeleteAudienceConfig: function(sourceType, sourceCollection, estimatedCount) {
						return {
							serviceName: "BulkEmailAudience",
							methodName: "Remove",
							data: {
								BulkEmailId: this.$MasterRecordId,
								SourceCollection: sourceCollection || [],
								EstimatedEntitiesCount: estimatedCount || 0,
								SourceType: sourceType
							}
						};
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#onDeleteCompleted
					 * @override
					 */
					onDeleteCompleted: function(result) {
						var res = this.callParent(arguments);
						if (res) {
							this.sandbox.publish("ReloadBulkEmailQueueState");
						}
						return res;
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#getManageAudienceConfig
					 * @override
					 */
					getManageAudienceConfig: function() {
						var config = this.callParent(arguments);
						var manageAudienceUrl = Ext.String.format(this.manageAudienceHashPattern,
							this.$AudienceSysSchemaName);
						Ext.apply(config, {
							url: manageAudienceUrl,
							recordName: this.get("BulkEmailName"),
							audienceSchemaName: this.get("AudienceSysSchemaName")
						});
						return config;
					},

					/**
					 * @inheritdoc BPMSoft.BaseAudienceDetail#canManageAudience
					 * @override
					 */
					canManageAudience: function() {
						var bulkEmailStatus = this._getBulkEmailStatus();
						return this.isAudienceEditableForStatus(bulkEmailStatus);
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
					 * @override
					 */
					getDeleteRecordMenuItem: function() {
						return this.getButtonMenuItem({
							Caption: "$Resources.Strings.DeleteSelectedMenuCaption",
							Click: "$tryDeleteRecords",
							Visible: "$isDeleteSelectedRecordsVisible"
						});
					},

					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
					 * @override
					 */
					getEditRecordMenuItem: BPMSoft.emptyFn,

					/**
					 * Hides Tooltip property.
					 * @override
					 */
					setTooltipVisible: function() {
						this.set("TooltipVisible", false);
					},

					/**
					 * @inheritdoc BPMSoft.VwMandrillRecipientDetailV2#isAudienceEditableForStatus
					 * @override
					 */
					isAudienceEditableForStatus: function(bulkEmailStatus) {
						var config = {
							status: bulkEmailStatus
						};
						return BulkEmailHelper.GetIsAudienceEditable(config)
					},

					/**
					 * @inheritdoc BPMSoft.VwMandrillRecipientDetailV2#initAddMenuItems
					 * @override
					 */
					initAddMenuItems: function() {
						var addMenuItems = Ext.create("BPMSoft.BaseViewModelCollection");
						var schemaCollection = this.get("AudienceSchemaCollection");
						schemaCollection.each(function(schema) {
							addMenuItems.add(schema.$Id, Ext.create("BPMSoft.BaseViewModel", {
								values: {
									"ImageConfig": this._getImageConfigFromSysImage(schema.$Image),
									"Caption": schema.$DisplayName,
									"Click": "$saveBulkEmailBeforeAudienceImport",
									"Tag": schema.$Id,
									"Enabled": "$_isCurrentAudienceSchema"
								}
							}));
						}, this);
						addMenuItems.addItem(this.getButtonMenuItem({
							"Type": "BPMSoft.MenuSeparator"
						}));
						addMenuItems.add("addContactItem", Ext.create("BPMSoft.BaseViewModel", {
							values: {
								"ImageConfig": this.get("Resources.Images.ManageAudienceSchemasImage"),
								"Caption": {"bindTo": "Resources.Strings.ManageAudienceSchemasCaption"},
								"Click": "$_onManageAudienceClick",
								"Tag": "ManageObjectsMenuItem"
							}
						}));
						this.set("addMenuItems", addMenuItems);
					}
				},
				diff: [
					{
						"operation": "merge",
						"name": "Detail",
						"values": {
							"caption": "$DetailCaption"
						}
					}
				]
			};
		}
);
