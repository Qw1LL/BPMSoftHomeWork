define("QueueFillingUtilities", ["BPMSoft", "LookupUtilities", "ConfigurationEnums", "ConfigurationConstants",
		"ServiceHelper"],
	function(BPMSoft, LookupUtilities,  ConfigurationEnums, ConfigurationConstants, ServiceHelper) {
	/**
	 * @class BPMSoft.configuration.mixins.QueueFillingUtilities
	 * ###### ########## ########.
	 */
	Ext.define("BPMSoft.configuration.mixins.QueueFillingUtilities", {
		alternateClassName: "BPMSoft.QueueFillingUtilities",

		//region Methods: Private

		/**
		 * ######### ###### # #######.
		 * @private
		 * @param {String[]} primaryColumnValues ############## #######.
		 */
		addEntityRecords: function(primaryColumnValues) {
			var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
			BPMSoft.each(primaryColumnValues, function(primaryColumnValue) {
				var insert = this.getQueueItemInsertQuery(primaryColumnValue);
				batchQuery.add(insert);
			}.bind(this));
			if (batchQuery.queries.length) {
				batchQuery.execute(this.onAddEntitiesResponse, this);
			}
		},

		/**
		 * ######### ###### ##### # #######.
		 * @private
		 * @param {String[]} folderIds ############## ####### #####.
		 */
		addEntityFolders: function(folderIds) {
			const methodName = this.getIsFeatureEnabled("UseAsyncAddingFolderQueueItems") ?
				"ScheduleAddFoldersQueueItems" : "AddFoldersQueueItems";
			this.showBodyMask();
			ServiceHelper.callService({
				serviceName: "QueuesService",
				methodName: methodName,
				data: {
					folderIds: folderIds,
					entitySchemaName: this.get("EntitySchemaName"),
					queueId: this.get("QueueId")
				},
				callback: this.onAddEntityFoldersResponse,
				scope: this
			});
		},

		/**
		 * ######### ######## ###### ####### #######.
		 * @private
		 * @param {Object} cardResponse ######### ########## ########## ########.
		 */
		openEntitiesLookup: function(cardResponse) {
			if (!cardResponse.success) {
				return;
			}
			var config = {
				entitySchemaName: this.get("EntitySchemaName"),
				multiSelect: true,
				columns: [this.get("EntitySchemaPrimaryDisplayColumnName")]
			};
			var filterGroup = this.getNotExistsQueueItemFilter();
			config.filters = filterGroup;
			LookupUtilities.Open(this.sandbox, config, this.onEntityRecordsSelected, this, null, false, false);
		},

		/**
		 * ######### ######## ###### ####### ##### #######.
		 * @private
		 * @param {Object} cardResponse ######### ########## ########## ########.
		 */
		openEntityFoldersLookup: function(cardResponse) {
			if (!cardResponse.success) {
				return;
			}
			var config = {
				entitySchemaName: this.get("EntitySchemaName") + "Folder",
				multiSelect: true,
				columns: ["Name"]
			};
			var folderTypesFilter = BPMSoft.createColumnInFilterWithParameters("FolderType",
				[ConfigurationConstants.Folder.Type.General, ConfigurationConstants.Folder.Type.Search]);
			folderTypesFilter.comparisonType = BPMSoft.ComparisonType.EQUAL;
			config.filters = folderTypesFilter;
			LookupUtilities.Open(this.sandbox, config, this.onEntityFoldersSelected, this, null, false, false);
		},

		/**
		 * ########## ###### ## ########## ###### ######## #######.
		 * @private
		 * @param {String} primaryColumnValue ############# ###### ####### #######.
		 * @return {BPMSoft.InsertQuery} ###### ## ########## ###### ######## #######.
		 */
		getQueueItemInsertQuery: function(primaryColumnValue) {
			var insert = this.Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "QueueItem"
			});
			insert.setParameterValue("EntityRecordId", primaryColumnValue, this.BPMSoft.DataValueType.GUID);
			insert.setParameterValue("Queue", this.get("QueueId"), this.BPMSoft.DataValueType.GUID);
			return insert;
		},

		/**
		 * ########## ###### ######## ############## ####### # ########## #######.
		 * @private
		 * @return {BPMSoft.FilterGroup} ###### ######## ############## ####### # ########## #######.
		 */
		getNotExistsQueueItemFilter: function() {
			var filterGroup = Ext.create("BPMSoft.FilterGroup");
			var subFilterGroup = Ext.create("BPMSoft.FilterGroup");
			var queueColumnFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"Queue", this.get("QueueId"));
			subFilterGroup.addItem(queueColumnFilter);
			var existsFilter = BPMSoft.createNotExistsFilter("[QueueItem:EntityRecordId:Id].Queue",
				subFilterGroup);
			filterGroup.addItem(existsFilter);
			return filterGroup;
		},

		/**
		 * ######### ######## ######### # ### ############# ########## ######## ########.
		 * @protected
		 * @param {Function} callback ####### ######### ######.
		 */
		checkIsSavedCard: function(callback) {
			var sandbox = this.sandbox;
			var sandboxId = sandbox.id;
			var masterCardState = sandbox.publish("GetCardState", null, [sandboxId]);
			var state = masterCardState.state;
			var isNewRecord = (state === ConfigurationEnums.CardStateV2.ADD ||
				state === ConfigurationEnums.CardStateV2.COPY);
			if (!isNewRecord) {
				callback.call(this, {success: true});
			} else {
				var args = {
					isSilent: true,
					callBaseSilentSavedActions: true,
					messageTags: [sandboxId],
					scope: this,
					callback: callback
				};
				sandbox.publish("SaveRecord", args, [sandboxId]);
			}
		},

		/**
		 * ############ ########## ####### ######### #######.
		 * ########## ######### # ########## ########### ####### # ######### ###### ###### ##########.
		 * @private
		 * @param {Number} addedEntitiesCount ########## ##### #######.
		 */
		onQueueItemsAdded: function(addedEntitiesCount) {
			var addedEntitiesMessage = this.Ext.String.format(this.get("Resources.Strings.AddedEntitiesMessage"),
				addedEntitiesCount);
			this.showInformationDialog(addedEntitiesMessage);
			if (addedEntitiesCount > 0) {
				this.set("ActiveRow", null);
				this.reloadGridData();
			}
		},

		/**
		 * ########## ########## ###### ####### ########## ######### ####### ## ######### ####### #######.
		 * @private
		 * @param {Object} response ###### ###### #######.
		 */
		onAddEntitiesResponse: function(response) {
			if (!response.success) {
				return;
			}
			var queryResults = response.queryResults;
			if (!queryResults || (queryResults.length === 0)) {
				return;
			}
			var addedEntitiesCount = 0;
			BPMSoft.each(queryResults, function(queryResult) {
				addedEntitiesCount = addedEntitiesCount + queryResult.rowsAffected;
			});
			this.onQueueItemsAdded(addedEntitiesCount);
		},

		/**
		 * ########## ########## ###### ####### ########## ######### ####### ## ######### ####### #######.
		 * @private
		 * @param {Object} response ###### ###### #######.
		 * @param {Boolean} success ####### ######### ########## #######.
		 */
		onAddEntityFoldersResponse: function(response, success) {
			this.hideBodyMask();
			if (!success) {
				return;
			}
			const responseData = BPMSoft.decode(response);
			if (Ext.isEmpty(responseData)) {
				return;
			}
			const errorMessages = responseData.errorMessages;
			if (!Ext.isEmpty(errorMessages)) {
				this.error(errorMessages);
			}
			const addedEntitiesCount = responseData.addedEntitiesCount;
			const infoMessage = responseData.infoMessage;
			if (Ext.isEmpty(addedEntitiesCount) && !Ext.isEmpty(infoMessage)) {
				return this.showInformationDialog(infoMessage);
			}
			this.onQueueItemsAdded(addedEntitiesCount);
		},

		//endregion

		//region Methods: Protected

		/**
		 * ########## ####### ###### ###### #### ###### "########" ###### "########## #######".
		 * @protected
		 */
		onAddEntityRecordClick: function() {
			this.checkIsSavedCard(this.openEntitiesLookup);
		},

		/**
		 * ########## ####### ###### ###### #### ###### "######## ######" ###### "########## #######".
		 * @protected
		 */
		onAddEntityFolderRecordClick: function() {
			this.checkIsSavedCard(this.openEntityFoldersLookup);
		},

		/**
		 * ########## ####### ###### ####### ### ##########.
		 * @protected
		 * @param {Object} entityRecords ######### ######.
		 */
		onEntityRecordsSelected: function(entityRecords) {
			if (!entityRecords.selectedRows.isEmpty()) {
				var entityRecordsKeys = entityRecords.selectedRows.getKeys();
				this.addEntityRecords(entityRecordsKeys);
			}
		},

		/**
		 * ########## ####### ###### ##### ### ##########.
		 * @protected
		 * @param {Object} entityFolders ######### ######.
		 */
		onEntityFoldersSelected: function(entityFolders) {
			if (!entityFolders.selectedRows.isEmpty()) {
				var entityFoldersKeys = entityFolders.selectedRows.getKeys();
				this.addEntityFolders(entityFoldersKeys);
			}
		}

		//endregion

	});
});
