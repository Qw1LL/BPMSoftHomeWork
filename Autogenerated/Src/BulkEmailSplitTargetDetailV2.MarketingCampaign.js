define("BulkEmailSplitTargetDetailV2", ["ConfigurationConstants", "MarketingEnums", "SegmentsStatusUtils",
		"ProcessModuleUtilities"],
	function(ConfigurationConstants, MarketingEnums, SegmentsStatusUtils, ProcessModuleUtilities) {
		return {
			entitySchemaName: "BulkEmailSplitTarget",
			attributes: {
				/** Returns true if test audience is eligible for edit. */
				"IsAudienceEditable": {dataValueType: BPMSoft.DataValueType.BOOLEAN}
			},
			messages: {
				/**
				 * ######## ######### ######## ##############.
				 */
				"GetIsChanged": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddTypedRecordButtonVisible
				 * @overridden
				 */
				getAddTypedRecordButtonVisible: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @overridden
				 */
				getDeleteRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: BPMSoft.emptyFn,

				/**
				 * Initializes detail.
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.updateIsAudienceEditable();
				},

				/**
				 *  Adds Contact Folder.
				 *  @protected
				 */
				addContactFolder: function() {
					var state = this.sandbox.publish("GetIsChanged", null, [this.sandbox.id]);
					var isChanged = state.isChanged;
					if (isChanged) {
						var args = {
							isSilent: true,
							messageTags: [this.sandbox.id],
							callback: this.addContactFolder,
							scope: this
						};
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
						return;
					}
					this.updateIsAudienceEditable(function(errorMessage) {
						if (!Ext.isEmpty(errorMessage)) {
							this.showInformationDialog(this.get("Resources.Strings." + errorMessage));
							return;
						}
						if (this.get("IsAudienceEditable") === false) {
							return;
						}
						var config = {
							entitySchemaName: "ContactFolder",
							multiSelect: true,
							columns: ["FolderType"]
						};
						var groupType = BPMSoft.createColumnInFilterWithParameters("FolderType",
							[ConfigurationConstants.Folder.Type.General,
								ConfigurationConstants.Folder.Type.Search]);
						groupType.comparisonType = BPMSoft.ComparisonType.EQUAL;
						config.filters = groupType;
						this.openLookup(config, this.addContactFolderCallback, this);
					}.bind(this));
				},


				/**
				 * Returns configuration for the UpdateSplitTestAudience process execution.
				 * @private
				 * @returns {Object} Configuration.
				 */
				getUpdateAudienceProcessParameters: function() {
					var masterRecordId = this.get("MasterRecordId");
					return {
						"RecordId": masterRecordId
					};
				},

				/**
				 * Callback function for UpdateSplitTestAudience process.
				 * @private
				 * @param {Object} config Config.
				 */
				updateAudienceProcessCallback: function(config) {
					var scope = config.scope || this;
					setTimeout(function() {
						scope.sandbox.publish("DetailChanged", {}, [scope.sandbox.id]);
						scope.reloadGridData();
						scope.hideBodyMask();
					}, scope.timeoutBeforeUpdate);
				},

				/**
				 * Return config for the UpdateSplitTestAudience process.
				 * @private
				 * @param {Object} callbackConfig Config for the callback function.
				 * @return {Object} Config.
				 */
				getUpdateAudienceProcessConfig: function(callbackConfig) {
					return {
						"sysProcessName": "UpdateSplitTestAudience",
						"sysProcessId": "",
						"parameters": this.getUpdateAudienceProcessParameters(),
						"callback": this.updateAudienceProcessCallback.bind(this, callbackConfig)
					};
				},

				/**
				 * Callback method for addContactFolder.
				 * @private
				 * @param {Object} config Config with inserted element.
				 */
				addContactFolderCallback: function(config) {
					var bulkEmailSplitId = this.get("MasterRecordId");
					var contactFolders = config.selectedRows;
					var foldersCount = contactFolders.getCount();
					var contactWillBeAddedMessage = (foldersCount === 1) ?
						this.get("Resources.Strings.ContactsOfOneWillBeAdded")
						: this.get("Resources.Strings.ContactsWillBeAdded");
					this.showInformationDialog(this.Ext.String.format(contactWillBeAddedMessage, foldersCount));
					var bq = this.Ext.create("BPMSoft.BatchQuery");
					contactFolders.each(function(item) {
						bq.add(this.getContactFolderInsert(bulkEmailSplitId, item.Id));
					}, this);
					bq.execute(function() {
						this.timeoutBeforeUpdate = SegmentsStatusUtils.timeoutBeforeUpdate;
						var config = {
							scope: this
						};
						var processConfig = this.getUpdateAudienceProcessConfig(config);
						ProcessModuleUtilities.executeProcess(processConfig);
					}, this);
				},

				/**
				 * Creates insert query Contact group into split test segments.
				 * @param {String} bulkEmailId Split test identifier.
				 * @param {String} contactFolderId Contact group identifier.
				 * @return {BPMSoft.InsertQuery} Insert query.
				 */
				getContactFolderInsert: function(bulkEmailId, contactFolderId) {
					var insertQuery = this.Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "BulkEmailSplitSegment"
					});
					insertQuery.setParameterValue("BulkEmailSplit", bulkEmailId, BPMSoft.DataValueType.GUID);
					insertQuery.setParameterValue("Segment", contactFolderId, BPMSoft.DataValueType.GUID);
					insertQuery.setParameterValue("State", MarketingEnums.SegmentsStatus.REQUIERESUPDATING,
						BPMSoft.DataValueType.GUID);
					return insertQuery;
				},

				/**
				 * Validates split test for possibility of audience editing.
				 * @param {Function} callback Callback function.
				 */
				updateIsAudienceEditable: function(callback) {
					var recordId = this.get("MasterRecordId");
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmail"
					});
					esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
					esq.addColumn("SplitTest.Status");
					esq.addColumn("SplitTest.RecipientPercent");
					esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"SplitTest", recordId));
					esq.getEntityCollection(function(response) {
						var result = false;
						var errorMessage = "";
						if (response && response.success) {
							var collection = response.collection;
							if (collection && collection.getCount() > 0) {
								var entity = collection.getByIndex(0);
								var count = entity.get("Count");
								var recipientpercent = entity.get("SplitTest.RecipientPercent");
								var bulkEmailSplitStatus = entity.get("SplitTest.Status").value;
								if (bulkEmailSplitStatus !== MarketingEnums.BulkEmailSplitStatus.PLANNED) {
									errorMessage = "AudienceEditingDisabledMessage";
								} else if (count <= 1) {
									errorMessage = "BulkEmailDetailIsEmptyMessage";
									result = true;
								} else if (recipientpercent > 100 || recipientpercent <= 0) {
									errorMessage = "InvalidRecipientPercentMessage";
									result = true;
								} else {
									result = true;
								}
							} else {
								errorMessage = "BulkEmailDetailIsEmptyMessage";
								result = true;
							}
						}
						this.set("IsAudienceEditable", result);
						if (callback) {
							callback.call(this, errorMessage);
						}
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "AddRecordButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "addContactFolder"},
						"visible": {"bindTo": "IsAudienceEditable"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
